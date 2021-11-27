using Endoscopy.Models;
using Endoscopy.ViewModels;
using System.Windows;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SessionViewModel _sessionViewModel;
        private readonly PatientViewModel _patientViewModel;
        private readonly FoundationViewModel _foundationViewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            _sessionViewModel = new SessionViewModel();
            _patientViewModel = new PatientViewModel();
            _foundationViewModel = new FoundationViewModel();

            SessionView.DataContext = _sessionViewModel;
            PatientTextBox.DataContext = _patientViewModel;
            PatientsButton.DataContext = _patientViewModel;
            FoundationTextBox.DataContext = _foundationViewModel;
            FoundationsButton.DataContext = _foundationViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new()
            {
                Owner = this
            };
            
            if (loginWindow.ShowDialog() == true)
            {
                Title += " - " + API.GetUserDisplayName();
            }
            else
            {
                Close();
            }
        }

        private void FoundationsButton_Click(object sender, RoutedEventArgs e)
        {
            _foundationViewModel.Load();

            FoundationsWindow foundationsWindow = new(this, _foundationViewModel);

            if (foundationsWindow.ShowDialog() == true)
            {
                _patientViewModel.Clear();
                _sessionViewModel.Clear();
            }
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            _patientViewModel.Load(_foundationViewModel.SelectedFoundation);

            PatientsWindow patientsWindow = new(this, _patientViewModel);

            if (patientsWindow.ShowDialog() == true)
            {
                _sessionViewModel.Load(_patientViewModel.SelectedPatient);
            }
        }
    }
}