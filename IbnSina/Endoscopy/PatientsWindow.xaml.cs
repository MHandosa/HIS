using Endoscopy.Models;
using Endoscopy.ViewModels;
using Endoscopy.Views;
using System.Windows;
using System.Windows.Controls;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        private readonly FoundationModel _foundationModel;
        private readonly PatientViewModel _patientViewModel;

        public PatientModel SelectedPatient { get; private set; }
        public PatientsWindow(FoundationModel foundationModel)
        {
            InitializeComponent();
            _foundationModel = foundationModel;
            _patientViewModel = new PatientViewModel();
            PatientView.DataContext = _patientViewModel;
            PatientView.ListView.SelectionChanged += ListView_SelectionChanged;
            UpdateUI();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _patientViewModel.LoadPatients(_foundationModel);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPatient = PatientView.ListView.SelectedItem as PatientModel;
            DialogResult = true;
        }

        private void UpdateUI()
        {
            OkButton.IsEnabled = PatientView.ListView.SelectedItem != null;
        }
    }
}
