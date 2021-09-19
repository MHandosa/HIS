using Endoscopy.Models;
using Endoscopy.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for FoundationsWindow.xaml
    /// </summary>
    public partial class FoundationsWindow : Window
    {
        private readonly FoundationViewModel _foundationViewModel;

        public FoundationModel SelectedFoundation { get; private set; }
        public FoundationsWindow()
        {
            InitializeComponent();
            _foundationViewModel = new FoundationViewModel();
            FoundationView.DataContext = _foundationViewModel;
            FoundationView.ListView.SelectionChanged += ListView_SelectionChanged;
            UpdateUI();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _foundationViewModel.LoadFoundations();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedFoundation = FoundationView.ListView.SelectedItem as FoundationModel;
            DialogResult = true;
        }

        private void UpdateUI()
        {
            OkButton.IsEnabled = FoundationView.ListView.SelectedItem != null;
        }
    }
}
