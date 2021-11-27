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
        internal PatientsWindow(Window owner, PatientViewModel patientViewModel)
        {
            InitializeComponent();
            Owner = owner;
            DataContext = patientViewModel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
