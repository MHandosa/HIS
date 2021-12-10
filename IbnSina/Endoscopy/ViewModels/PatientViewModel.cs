using Endoscopy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Endoscopy.ViewModels
{
    class PatientViewModel :INotifyPropertyChanged
    {
        private string _filterText;
        private readonly CollectionViewSource _patientsViewSource;
        private readonly ObservableCollection<PatientModel> _patients;

        public event PropertyChangedEventHandler PropertyChanged;
        public PatientModel SelectedPatient { get; private set; }

        public DelegateCommand SelectPatient { get; private set; }
        public DelegateCommand<FoundationModel> ListPatients { get; private set; }

        public PatientViewModel()
        {
            _patients = new ObservableCollection<PatientModel>();
            SelectPatient = new DelegateCommand(OnSelectPatient, CanSelectPatient);
            ListPatients = new DelegateCommand<FoundationModel>(OnListPatients, CanListPatients);

            _patientsViewSource = new CollectionViewSource
            {
                Source = _patients
            };

            _patientsViewSource.Filter += Filter;
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Clear()
        {
            _patients.Clear();
            SelectedPatient = null;
            RaisePropertyChanged(nameof(SelectedPatient));
        }

        public void Load(FoundationModel foundation)
        {
            _patients.Clear();

            List<PatientModel> patients = ServerAPI.GetPatients(foundation);

            foreach (PatientModel patient in patients)
            {
                _patients.Add(patient);
            }
        }

        public ICollectionView Patients
        {
            get
            {
                return _patientsViewSource.View;
            }
        }

        public bool CanSelectPatient()
        {
            return _patientsViewSource.View.CurrentItem != null;
        }

        public void OnSelectPatient()
        {
            SelectedPatient = _patientsViewSource.View.CurrentItem as PatientModel;
            RaisePropertyChanged(nameof(SelectedPatient));
        }

        private bool CanListPatients(FoundationModel selectedFoundation)
        {
            return selectedFoundation != null;
        }

        private void OnListPatients(FoundationModel selectedFoundation)
        {
            // Just a placeholder
        }

        public string FilterText
        {
            get
            {
                return _filterText;
            }
            set
            {
                _filterText = value;
                _patientsViewSource.View.Refresh();
            }
        }

        private void Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
            }
            else
            {
                PatientModel patient = e.Item as PatientModel;
                e.Accepted = patient.ToString().ToUpper().Contains(FilterText.ToUpper());
            }
        }
    }
}