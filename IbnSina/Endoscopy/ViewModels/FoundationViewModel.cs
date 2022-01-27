using Endoscopy.API;
using Endoscopy.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Endoscopy.ViewModels
{
    internal class FoundationViewModel : INotifyPropertyChanged
    {
        private string _filterText;
        private readonly CollectionViewSource _foundationsViewSource;
        private readonly ObservableCollection<FoundationModel> _foundations;

        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand SelectFoundation { get; private set; }

        public FoundationModel SelectedFoundation { get; private set; }

        public FoundationViewModel()
        {
            _foundations = new ObservableCollection<FoundationModel>();
            SelectFoundation = new DelegateCommand(OnSelectFoundation, CanSelectFoundation);

            _foundationsViewSource = new CollectionViewSource
            {
                Source = _foundations
            };

            _foundationsViewSource.Filter += Filter;
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Clear()
        {
            _foundations.Clear();
            SelectedFoundation = null;
            RaisePropertyChanged(nameof(SelectedFoundation));
        }

        public void Load()
        {
            _foundations.Clear();

            List<FoundationModel> foundations = Server.GetFoundations();

            foreach (FoundationModel foundation in foundations)
            {
                _foundations.Add(foundation);
            }
        }

        public ICollectionView Foundations
        {
            get
            {
                return _foundationsViewSource.View;
            }
        }

        public bool CanSelectFoundation()
        {
            return _foundationsViewSource.View.CurrentItem != null;
        }

        public void OnSelectFoundation()
        {
            SelectedFoundation = _foundationsViewSource.View.CurrentItem as FoundationModel;
            RaisePropertyChanged(nameof(SelectedFoundation));
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
                _foundationsViewSource.View.Refresh();
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
                FoundationModel foundation = e.Item as FoundationModel;
                e.Accepted = foundation.ToString().ToUpper().Contains(FilterText.ToUpper());
            }
        }
    }
}
