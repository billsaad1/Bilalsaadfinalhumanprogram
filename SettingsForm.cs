using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
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
            cmbLanguage.SelectedIndex = _settings.Language == "ar" ? 1 : 0;
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
            _settings.Language = cmbLanguage.SelectedIndex == 1 ? "ar" : "en";
            _settingsService.SaveSettings(_settings);

            // Apply the new culture immediately
            ApplicationStyleManager.SetLanguage(_settings.Language);

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
            ApplicationStyleManager.SetLanguage(culture);
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblOrganizationName.Text = resources.GetString("lblOrganizationName.Text");
            this.lblAddress.Text = resources.GetString("lblAddress.Text");
            this.lblEmail.Text = resources.GetString("lblEmail.Text");
            this.lblCountry.Text = resources.GetString("lblCountry.Text");
            this.lblLogo.Text = resources.GetString("lblLogo.Text");
            this.btnBrowseLogo.Text = resources.GetString("btnBrowseLogo.Text");
            this.btnSave.Text = resources.GetString("btnSave.Text");
            this.btnCancel.Text = resources.GetString("btnCancel.Text");
        }
    }
}
