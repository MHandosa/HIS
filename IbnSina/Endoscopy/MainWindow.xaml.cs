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
        private PatientModel _currentPatient;
        private FoundationModel _currentFoundation;
        private SessionViewModel _sessionViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _currentPatient = null;
            _currentFoundation = null;
            _sessionViewModel = new SessionViewModel();
            SessionView.DataContext = _sessionViewModel;

            UpdateUI();
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
            FoundationsWindow foundationsWindow = new()
            {
                Owner = this
            };

            if (foundationsWindow.ShowDialog() == true)
            {
                _currentFoundation = foundationsWindow.SelectedFoundation;
                FoundationTextBox.Text = _currentFoundation.ToString();

                _currentPatient = null;
                PatientTextBox.Text = null;

                _sessionViewModel.Clear();

                UpdateUI();
            }
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            PatientsWindow patientsWindow = new(_currentFoundation)
            {
                Owner = this
            };

            if (patientsWindow.ShowDialog() == true)
            {
                _currentPatient = patientsWindow.SelectedPatient;
                PatientTextBox.Text = _currentPatient.ToString();

                _sessionViewModel.Load(_currentPatient);

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            PatientsButton.IsEnabled = _currentFoundation != null;
        }
    }
}