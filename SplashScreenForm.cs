using System;
using System.Windows.Forms;
using System.Reflection; // For Assembly Version

namespace HumanitarianProjectManagement.UI // Assuming this namespace, adjust if needed
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            // Apply custom theme if needed, though splash screens often have their own design
            // ThemeManager.ApplyThemeToForm(this);
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            // Set texts dynamically if desired
            lblLogo.Text = "HPM Aid"; // Placeholder for a logo or org name
            lblSystemName.Text = "Humanitarian Project Management System";

            // Get assembly version for lblVersion
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            lblVersion.Text = $"Version {version.Major}.{version.Minor}.{version.Build}";

            splashTimer.Start();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop(); // Stop the timer
            this.DialogResult = DialogResult.OK; // Set DialogResult before closing if shown with ShowDialog()
            this.Close();
        }
    }
}
