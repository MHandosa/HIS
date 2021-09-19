using Endoscopy.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Endoscopy.ViewModels
{
    internal class FoundationViewModel
    {
        private string _filterText;
        private readonly CollectionViewSource _foundationsViewSource;
        private readonly ObservableCollection<FoundationModel> _foundations;

        public FoundationViewModel()
        {
            _foundations = new ObservableCollection<FoundationModel>();
            
            _foundationsViewSource = new CollectionViewSource
            {
                Source = _foundations
            };

            _foundationsViewSource.Filter += Filter;
        }

        public ICollectionView Foundations
        {
            get
            {
                return _foundationsViewSource.View;
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

        public void LoadFoundations()
        {
            _foundations.Clear();

            List<FoundationModel> foundations = API.GetFoundations();

            foreach (FoundationModel foundation in foundations)
            {
                _foundations.Add(foundation);
            }
        }
    }
}
