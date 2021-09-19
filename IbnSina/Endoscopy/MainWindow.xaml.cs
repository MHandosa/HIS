using Endoscopy.Models;
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

        public MainWindow()
        {
            InitializeComponent();

            _currentPatient = null;
            _currentFoundation = null;

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
                Title += " (" + API.GetUserDisplayName() + ")";
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
                FoundationModel foundation = foundationsWindow.SelectedFoundation;

                if (_currentFoundation != foundation)
                {
                    _currentPatient = null;
                    _currentFoundation = foundation;
                    FoundationTextBox.Text = _currentFoundation.ToString();

                    UpdateUI();
                }
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
                PatientModel patient = patientsWindow.SelectedPatient;

                if (_currentPatient != patient)
                {
                    _currentPatient = patient;
                    PatientTextBox.Text = _currentPatient.ToString();

                    UpdateUI();
                }
            }
        }

        private void UpdateUI()
        {
            PatientsButton.IsEnabled = _currentFoundation != null;
        }
    }
}