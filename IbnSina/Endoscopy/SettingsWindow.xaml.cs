using System.Windows;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow(Window owner)
        {
            InitializeComponent();
            this.Owner = owner;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
