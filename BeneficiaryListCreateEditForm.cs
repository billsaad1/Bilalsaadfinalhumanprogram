using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    public partial class BeneficiaryListCreateEditForm : Form
    {
        private readonly BeneficiaryService _beneficiaryService;
        private BeneficiaryList _currentList;
        private readonly bool _isEditMode;
        private readonly int _projectId;
        private readonly string _projectName;

        public BeneficiaryListCreateEditForm(int projectId, string projectName, BeneficiaryList listToEdit = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _beneficiaryService = new BeneficiaryService();
            _projectId = projectId;
            _projectName = projectName;

            txtProjectNameDisplay.Text = _projectName;
            txtProjectNameDisplay.TabStop = false; // As it's read-only

            _isEditMode = (listToEdit != null);

            if (_isEditMode)
            {
                _currentList = listToEdit;
                this.Text = $"Edit List: {_currentList.ListName}";
                PopulateControls();
            }
            else
            {
                _currentList = new BeneficiaryList
                {
                    ProjectID = _projectId,
                    CreationDate = DateTime.UtcNow // Set by service if not provided, or set here
                };
                this.Text = "Add New Beneficiary List";
            }
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            txtProjectNameDisplay.AccessibleName = "Project Name (Display Only)";
            txtProjectNameDisplay.AccessibleDescription = "Displays the name of the project for which this list is being created or edited.";
            txtListName.AccessibleName = "Beneficiary List Name";
            txtListName.AccessibleDescription = "Enter the name for the beneficiary list. This field is required.";
            txtDescription.AccessibleName = "List Description";
            txtDescription.AccessibleDescription = "Enter an optional description for the beneficiary list.";
            btnSave.AccessibleName = "Save Beneficiary List";
            btnSave.AccessibleDescription = "Saves the current beneficiary list details.";
            btnCancel.AccessibleName = "Cancel Editing";
            btnCancel.AccessibleDescription = "Discards changes and closes this form.";
        }

        private void PopulateControls()
        {
            if (_currentList == null) return;
            txtListName.Text = _currentList.ListName;
            txtDescription.Text = _currentList.Description;
        }

        private bool CollectAndValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtListName.Text))
            {
                MessageBox.Show("List Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtListName.Focus();
                return false;
            }

            _currentList.ListName = txtListName.Text.Trim();
            _currentList.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            _currentList.ProjectID = _projectId; // Ensure ProjectID is correctly set

            // CreationDate is handled by the constructor for new items or already exists for edited items.
            // The service also defaults CreationDate if needed.

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
                bool success = await _beneficiaryService.SaveBeneficiaryListAsync(_currentList);
                if (success)
                {
                    MessageBox.Show("Beneficiary list saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save beneficiary list. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the beneficiary list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                this.UseWaitCursor = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
