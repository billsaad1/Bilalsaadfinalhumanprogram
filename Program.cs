using HumanitarianProjectManagement.Forms;
using HumanitarianProjectManagement.UI; // Added using directive
using System;
using System.Windows.Forms;

namespace HumanitarianProjectManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen first
            SplashScreenForm splashScreen = new SplashScreenForm(); // Simplified instantiation
            splashScreen.ShowDialog(); // Show as a dialog to wait for it to close

            // Then proceed to login
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login is successful, run the main application form (Dashboard)
                Application.Run(new DashboardForm());
            }
            // If loginForm is closed with Cancel or any other DialogResult, the application will exit.
            // No explicit Application.Exit() needed here if that's the desired behavior.
        }
    }
}
