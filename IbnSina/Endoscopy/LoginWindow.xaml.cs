using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            ServerTextBox.Visibility = Visibility.Collapsed;
            ServerTextBlock.Visibility = Visibility.Collapsed;
            ServerTextBox.Text = Properties.Settings.Default.ServerAddress;

            switch (Properties.Settings.Default.Language.ToUpper())
            {
                case "EN":
                    CultureButton.Content = "ع";
                    break;

                case "AR":
                default:
                    CultureButton.Content = "EN";
                    break;
            }

            UserNameTextBox.Text = "Handosa";
            PasswordPasswordBox.Password = "123";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServerAPI.Login(UserNameTextBox.Text, PasswordPasswordBox.Password))
            {
                Properties.Settings.Default.ServerAddress = ServerTextBox.Text;
                Properties.Settings.Default.Save();
                DialogResult = true;
            }
            else
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void ServerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private void UserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private void PasswordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private void ServerToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ServerTextBox.Visibility = Visibility.Visible;
            ServerTextBlock.Visibility = Visibility.Visible;
        }

        private void ServerToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ServerTextBox.Visibility = Visibility.Collapsed;
            ServerTextBlock.Visibility = Visibility.Collapsed;
        }

        private void CultureButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.Language.ToUpper())
            {
                case "EN":
                    Properties.Settings.Default.Language = "AR";
                    Properties.Settings.Default.FlowDirection = "RightToLeft";
                    Properties.Settings.Default.Save();
                    break;

                case "AR":
                default:
                    Properties.Settings.Default.Language = "EN";
                    Properties.Settings.Default.FlowDirection = "LeftToRight";
                    Properties.Settings.Default.Save();
                    break;
            }

            Process.Start(Environment.ProcessPath);
            Application.Current.Shutdown();
        }
    }
}
