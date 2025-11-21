using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.Services;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settingsService;
        private Settings _settings;

        public SettingsForm()
        {
            InitializeComponent();
            _settingsService = new SettingsService();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _settings = _settingsService.LoadSettings();
            txtOrganizationName.Text = _settings.OrganizationName;
            txtAddress.Text = _settings.Address;
            txtEmail.Text = _settings.Email;
            txtCountry.Text = _settings.Country;
            lblLogoPath.Text = _settings.LogoPath;

            // Language selection
            cmbLanguage.Items.Add("English");
            cmbLanguage.Items.Add("العربية");
            cmbLanguage.SelectedIndex = Thread.CurrentThread.CurrentUICulture.Name == "ar" ? 1 : 0;
            cmbLanguage.SelectedIndexChanged += CmbLanguage_SelectedIndexChanged;

            ApplyLocalization();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.OrganizationName = txtOrganizationName.Text;
            _settings.Address = txtAddress.Text;
            _settings.Email = txtEmail.Text;
            _settings.Country = txtCountry.Text;
            _settings.LogoPath = lblLogoPath.Text;
            _settingsService.SaveSettings(_settings);
            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblLogoPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string culture = cmbLanguage.SelectedIndex == 1 ? "ar" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblOrganizationName.Text = resources.GetString("OrganizationName");
            this.lblAddress.Text = resources.GetString("Address");
            this.lblEmail.Text = resources.GetString("Email");
            this.lblCountry.Text = resources.GetString("Country");
            this.lblLogo.Text = resources.GetString("Logo");
            this.btnBrowseLogo.Text = resources.GetString("Browse");
            this.btnSave.Text = resources.GetString("Save");
            this.btnCancel.Text = resources.GetString("Cancel");
        }
    }
}
