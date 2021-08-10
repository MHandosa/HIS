using System.Globalization;
using System.Threading;
using System.Windows;

namespace Endoscopy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string language = Endoscopy.Properties.Settings.Default.Language.ToLower();

            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            MainWindow window = new MainWindow();
            MainWindow = window;
            window.Show();
        }
    }
}
