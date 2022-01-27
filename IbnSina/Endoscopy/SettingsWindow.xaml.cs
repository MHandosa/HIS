using System.IO.Ports;
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
            Owner = owner;

            camera1TextBox.Text = Properties.Settings.Default.Camera1Name;
            camera2TextBox.Text = Properties.Settings.Default.Camera2Name;
            camera3TextBox.Text = Properties.Settings.Default.Camera3Name;
            camera4TextBox.Text = Properties.Settings.Default.Camera4Name;

            SerialPortNameComboBox.Items.Clear();
            string[] serialPortNames = SerialPort.GetPortNames();
            for(int i = 0; i < serialPortNames.Length; i++)
            {
                SerialPortNameComboBox.Items.Add(serialPortNames[i]);
                if(serialPortNames[i] == Properties.Settings.Default.FootPedalPort)
                {
                    SerialPortNameComboBox.SelectedIndex = i;
                }
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Camera1Name = camera1TextBox.Text;
            Properties.Settings.Default.Camera2Name = camera2TextBox.Text;
            Properties.Settings.Default.Camera3Name = camera3TextBox.Text;
            Properties.Settings.Default.Camera4Name = camera4TextBox.Text;
            Properties.Settings.Default.FootPedalPort = SerialPortNameComboBox.SelectedItem?.ToString();
            Properties.Settings.Default.Save();

            DialogResult = true;
        }
    }
}
