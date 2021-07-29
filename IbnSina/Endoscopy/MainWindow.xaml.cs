using System.Windows;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            if(loginWindow.ShowDialog() == true)
            {

                MessageBox.Show("Welcome");
            }
            else
            {
                Close();
            }
        }
    }
}
