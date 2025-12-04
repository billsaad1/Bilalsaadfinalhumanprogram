using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Forms;
using HumanitarianProjectManagement.UI;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace HumanitarianProjectManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                TestRunner.MainTestEntry();
                return;
            }

            // Load settings and set culture
            var settingsService = new SettingsService();
            var settings = settingsService.LoadSettings();
            if (!string.IsNullOrEmpty(settings.Language))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen first
            SplashScreenForm splashScreen = new SplashScreenForm();
            splashScreen.ShowDialog();

            // Then proceed to login
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login is successful, run the main application form (Dashboard)
                Application.Run(new DashboardForm());
            }
        }
    }
}
