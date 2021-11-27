using Endoscopy.Models;
using Endoscopy.ViewModels;
using System.Windows;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for FoundationsWindow.xaml
    /// </summary>
    public partial class FoundationsWindow : Window
    {
        internal FoundationsWindow(Window owner, FoundationViewModel foundationViewModel)
        {
            InitializeComponent();

            Owner = owner;
            DataContext = FoundationView.DataContext = foundationViewModel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}