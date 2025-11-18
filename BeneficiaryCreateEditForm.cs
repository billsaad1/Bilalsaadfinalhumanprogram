using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    public partial class BeneficiaryCreateEditForm : Form
    {
        private readonly BeneficiaryService _beneficiaryService;
        private Beneficiary _currentBeneficiary;
        private readonly bool _isEditMode;
        private readonly int _beneficiaryListId;
        private readonly string _beneficiaryListName;

        public BeneficiaryCreateEditForm(int beneficiaryListId, string beneficiaryListName, Beneficiary beneficiaryToEdit = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _beneficiaryService = new BeneficiaryService();
            _beneficiaryListId = beneficiaryListId;
            _beneficiaryListName = beneficiaryListName;

            txtBeneficiaryListDisplay.Text = _beneficiaryListName;

            _isEditMode = (beneficiaryToEdit != null);

            if (_isEditMode)
            {
                _currentBeneficiary = beneficiaryToEdit;
                this.Text = $"Edit Beneficiary - {_currentBeneficiary.FirstName} {_currentBeneficiary.LastName}";
                PopulateControls();
            }
            else
            {
                _currentBeneficiary = new Beneficiary
                {
                    BeneficiaryListID = _beneficiaryListId,
                    RegistrationDate = DateTime.Today // Default registration date to today
                };
                this.Text = "Add New Beneficiary";
                // Initialize controls for new entry
                dtpRegistrationDate.Value = _currentBeneficiary.RegistrationDate;
                chkSpecifyDateOfBirth.Checked = false;
                dtpDateOfBirth.Enabled = false;
                chkSpecifyHouseholdSize.Checked = false;
                numHouseholdSize.Enabled = false;
            }
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            txtBeneficiaryListDisplay.AccessibleName = "Beneficiary List Name (Display Only)";
            txtBeneficiaryListDisplay.AccessibleDescription = "Shows the name of the list this beneficiary belongs to.";
            txtFirstName.AccessibleName = "First Name";
            txtFirstName.AccessibleDescription = "Enter the beneficiary's first name. This field is required.";
            txtLastName.AccessibleName = "Last Name";
            txtLastName.AccessibleDescription = "Enter the beneficiary's last name.";
            txtNationalID.AccessibleName = "National ID";
            txtNationalID.AccessibleDescription = "Enter the beneficiary's national identification number (optional).";
            dtpDateOfBirth.AccessibleName = "Date of Birth";
            dtpDateOfBirth.AccessibleDescription = "Select the beneficiary's date of birth.";
            chkSpecifyDateOfBirth.AccessibleName = "Specify Date of Birth";
            chkSpecifyDateOfBirth.AccessibleDescription = "Check this box to enable and set the date of birth.";
            cmbGender.AccessibleName = "Gender";
            cmbGender.AccessibleDescription = "Select the beneficiary's gender.";
            txtAddress.AccessibleName = "Address";
            txtAddress.AccessibleDescription = "Enter the beneficiary's address.";
            txtContactNumber.AccessibleName = "Contact Number";
            txtContactNumber.AccessibleDescription = "Enter the beneficiary's phone number or other contact details.";
            numHouseholdSize.AccessibleName = "Household Size";
            numHouseholdSize.AccessibleDescription = "Enter the number of people in the beneficiary's household.";
            chkSpecifyHouseholdSize.AccessibleName = "Specify Household Size";
            chkSpecifyHouseholdSize.AccessibleDescription = "Check this box to enable and set the household size.";
            txtVulnerabilityCriteria.AccessibleName = "Vulnerability Criteria";
            txtVulnerabilityCriteria.AccessibleDescription = "Describe any vulnerability criteria that apply to this beneficiary.";
            dtpRegistrationDate.AccessibleName = "Registration Date";
            dtpRegistrationDate.AccessibleDescription = "The date the beneficiary was registered.";
            btnSave.AccessibleName = "Save Beneficiary Details";
            btnCancel.AccessibleName = "Cancel Editing";
        }

        private void PopulateControls()
        {
            if (_currentBeneficiary == null) return;

            txtFirstName.Text = _currentBeneficiary.FirstName;
            txtLastName.Text = _currentBeneficiary.LastName;
            txtNationalID.Text = _currentBeneficiary.NationalID;

            if (_currentBeneficiary.DateOfBirth.HasValue)
            {
                dtpDateOfBirth.Value = _currentBeneficiary.DateOfBirth.Value;
                dtpDateOfBirth.Enabled = true;
                chkSpecifyDateOfBirth.Checked = true;
            }
            else
            {
                dtpDateOfBirth.Value = DateTime.Today; // Default if null
                dtpDateOfBirth.Enabled = false;
                chkSpecifyDateOfBirth.Checked = false;
            }

            cmbGender.SelectedItem = _currentBeneficiary.Gender;
            txtAddress.Text = _currentBeneficiary.Address;
            txtContactNumber.Text = _currentBeneficiary.ContactNumber;

            if (_currentBeneficiary.HouseholdSize.HasValue)
            {
                numHouseholdSize.Value = _currentBeneficiary.HouseholdSize.Value;
                numHouseholdSize.Enabled = true;
                chkSpecifyHouseholdSize.Checked = true;
            }
            else
            {
                numHouseholdSize.Value = 0; // Default if null
                numHouseholdSize.Enabled = false;
                chkSpecifyHouseholdSize.Checked = false;
            }

            txtVulnerabilityCriteria.Text = _currentBeneficiary.VulnerabilityCriteria;
            dtpRegistrationDate.Value = _currentBeneficiary.RegistrationDate;
        }

        private bool CollectAndValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }

            _currentBeneficiary.FirstName = txtFirstName.Text.Trim();
            _currentBeneficiary.LastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text.Trim();
            _currentBeneficiary.NationalID = string.IsNullOrWhiteSpace(txtNationalID.Text) ? null : txtNationalID.Text.Trim();

            _currentBeneficiary.DateOfBirth = chkSpecifyDateOfBirth.Checked ? (DateTime?)dtpDateOfBirth.Value : null;

            _currentBeneficiary.Gender = cmbGender.SelectedItem?.ToString();
            _currentBeneficiary.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();
            _currentBeneficiary.ContactNumber = string.IsNullOrWhiteSpace(txtContactNumber.Text) ? null : txtContactNumber.Text.Trim();

            _currentBeneficiary.HouseholdSize = chkSpecifyHouseholdSize.Checked ? (int?)numHouseholdSize.Value : null;

            _currentBeneficiary.VulnerabilityCriteria = string.IsNullOrWhiteSpace(txtVulnerabilityCriteria.Text) ? null : txtVulnerabilityCriteria.Text.Trim();
            _currentBeneficiary.RegistrationDate = dtpRegistrationDate.Value;
            _currentBeneficiary.BeneficiaryListID = _beneficiaryListId;

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!CollectAndValidateData())
            {
                return;
            }

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            this.UseWaitCursor = true;

            try
            {
                bool success = await _beneficiaryService.SaveBeneficiaryAsync(_currentBeneficiary);
                if (success)
                {
                    MessageBox.Show("Beneficiary saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save beneficiary. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the beneficiary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkSpecifyDateOfBirth_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateOfBirth.Enabled = chkSpecifyDateOfBirth.Checked;
            if (!chkSpecifyDateOfBirth.Checked)
            {
                // Optional: Clear value or set to a specific display when unchecked
                // dtpDateOfBirth.Value = dtpDateOfBirth.MinDate; // Or some other indicator of null
                // dtpDateOfBirth.CustomFormat = " "; // Requires ShowCheckBox to be false and Format to Custom
            }
            else
            {
                // dtpDateOfBirth.CustomFormat = null; // Restore default format
            }
        }

        private void chkSpecifyHouseholdSize_CheckedChanged(object sender, EventArgs e)
        {
            numHouseholdSize.Enabled = chkSpecifyHouseholdSize.Checked;
            if (!chkSpecifyHouseholdSize.Checked)
            {
                // Optional: Clear value when unchecked
                // numHouseholdSize.Value = 0; 
            }
        }
    }
}
