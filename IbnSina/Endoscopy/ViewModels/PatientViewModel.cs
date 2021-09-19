using Endoscopy.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Endoscopy.ViewModels
{
    class PatientViewModel
    {
        private string _filterText;
        private readonly CollectionViewSource _patientsViewSource;
        private readonly ObservableCollection<PatientModel> _patients;

        public PatientViewModel()
        {
            _patients = new ObservableCollection<PatientModel>();

            _patientsViewSource = new CollectionViewSource
            {
                Source = _patients
            };

            _patientsViewSource.Filter += Filter;
        }

        public ICollectionView Patients
        {
            get
            {
                return _patientsViewSource.View;
            }
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

        public void LoadPatients(FoundationModel foundation)
        {
            _patients.Clear();

            List<PatientModel> patients = API.GetPatients(foundation);

            foreach (PatientModel patient in patients)
            {
                _patients.Add(patient);
            }
        }
    }
}
