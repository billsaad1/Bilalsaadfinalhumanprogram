using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class ProjectIndicatorCreateEditForm : Form
    {
        private readonly MonitoringService _monitoringService;
        private ProjectIndicator _currentIndicator;
        private readonly bool _isEditMode;
        private readonly int _projectId;
        private readonly string _projectName;

        // Temporary storage for Means of Verification text if not directly mapped
        private string _initialDescription = "";
        private const string MeansOfVerificationSeparator = "\n\n--- Means of Verification ---\n";


        public ProjectIndicatorCreateEditForm(int projectId, string projectName, ProjectIndicator indicatorToEdit = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _monitoringService = new MonitoringService();
            _projectId = projectId;
            _projectName = projectName;

            txtProjectDisplay.Text = $"Project: {projectName}";
            txtProjectDisplay.TabStop = false;

            _isEditMode = (indicatorToEdit != null);

            if (_isEditMode)
            {
                _currentIndicator = indicatorToEdit;
                this.Text = $"Edit Indicator - {_currentIndicator.IndicatorName.Substring(0, Math.Min(_currentIndicator.IndicatorName.Length, 30))}{(_currentIndicator.IndicatorName.Length > 30 ? "..." : "")}";
                PopulateControls();
            }
            else
            {
                _currentIndicator = new ProjectIndicator
                {
                    ProjectID = _projectId,
                    IsKeyIndicator = false // Default for new
                };
                this.Text = "Add New Project Indicator";
                // Initialize controls for new entry
                chkSpecifyStartDate.Checked = false;
                dtpStartDate.Enabled = false;
                chkSpecifyEndDate.Checked = false;
                dtpEndDate.Enabled = false;
                chkIsKeyIndicator.Checked = false;
            }

            chkSpecifyStartDate.CheckedChanged += chkSpecifyStartDate_CheckedChanged;
            chkSpecifyEndDate.CheckedChanged += chkSpecifyEndDate_CheckedChanged;
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            txtProjectDisplay.AccessibleName = "Project Name (Display Only)";
            txtProjectDisplay.AccessibleDescription = "Displays the name of the project for which this indicator is being created or edited.";
            txtIndicatorName.AccessibleName = "Indicator Name";
            txtIndicatorName.AccessibleDescription = "Enter the name or title of the project indicator. This field is required.";
            txtDescription.AccessibleName = "Indicator Description";
            txtDescription.AccessibleDescription = "Provide a detailed description of the project indicator.";
            txtTargetValue.AccessibleName = "Target Value";
            txtTargetValue.AccessibleDescription = "Specify the target value for this indicator (e.g., 1000 units, 80%).";
            txtActualValue.AccessibleName = "Actual Value";
            txtActualValue.AccessibleDescription = "Enter the current actual value achieved for this indicator.";
            txtUnitOfMeasure.AccessibleName = "Unit of Measure";
            txtUnitOfMeasure.AccessibleDescription = "Specify the unit of measure for the target and actual values (e.g., beneficiaries, %, items).";
            txtBaselineValue.AccessibleName = "Baseline Value";
            txtBaselineValue.AccessibleDescription = "Enter the baseline value for this indicator at the start of the project or period.";
            chkSpecifyStartDate.AccessibleName = "Specify Start Date";
            dtpStartDate.AccessibleName = "Indicator Start Date";
            chkSpecifyEndDate.AccessibleName = "Specify End Date";
            dtpEndDate.AccessibleName = "Indicator End Date";
            chkIsKeyIndicator.AccessibleName = "Is Key Indicator";
            chkIsKeyIndicator.AccessibleDescription = "Check if this is a key performance indicator (KPI) for the project.";
            txtMeansOfVerificationText.AccessibleName = "Means of Verification";
            txtMeansOfVerificationText.AccessibleDescription = "Describe how the achievement of this indicator will be verified (e.g., reports, surveys, site visits).";
            btnSave.AccessibleName = "Save Indicator";
            btnCancel.AccessibleName = "Cancel Editing";
        }

        private void PopulateControls()
        {
            if (_currentIndicator == null) return;

            txtIndicatorName.Text = _currentIndicator.IndicatorName;

            // Separate Description and Means of Verification
            string fullDescription = _currentIndicator.Description ?? "";
            int separatorIndex = fullDescription.IndexOf(MeansOfVerificationSeparator);
            if (separatorIndex >= 0)
            {
                _initialDescription = fullDescription.Substring(0, separatorIndex);
                txtDescription.Text = _initialDescription;
                txtMeansOfVerificationText.Text = fullDescription.Substring(separatorIndex + MeansOfVerificationSeparator.Length);
            }
            else
            {
                _initialDescription = fullDescription;
                txtDescription.Text = _initialDescription;
                txtMeansOfVerificationText.Text = ""; // No separator found
            }

            txtTargetValue.Text = _currentIndicator.TargetValue;
            txtActualValue.Text = _currentIndicator.ActualValue;
            txtUnitOfMeasure.Text = _currentIndicator.UnitOfMeasure;
            txtBaselineValue.Text = _currentIndicator.BaselineValue;

            if (_currentIndicator.StartDate.HasValue)
            {
                chkSpecifyStartDate.Checked = true;
                dtpStartDate.Value = _currentIndicator.StartDate.Value;
                dtpStartDate.Enabled = true;
            }
            else
            {
                chkSpecifyStartDate.Checked = false;
                dtpStartDate.Enabled = false;
            }

            if (_currentIndicator.EndDate.HasValue)
            {
                chkSpecifyEndDate.Checked = true;
                dtpEndDate.Value = _currentIndicator.EndDate.Value;
                dtpEndDate.Enabled = true;
            }
            else
            {
                chkSpecifyEndDate.Checked = false;
                dtpEndDate.Enabled = false;
            }
            chkIsKeyIndicator.Checked = _currentIndicator.IsKeyIndicator;
        }

        private bool CollectAndValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtIndicatorName.Text))
            {
                MessageBox.Show("Indicator Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIndicatorName.Focus();
                return false;
            }

            _currentIndicator.IndicatorName = txtIndicatorName.Text.Trim();

            string mainDescription = string.IsNullOrWhiteSpace(txtDescription.Text) ? "" : txtDescription.Text.Trim();
            string meansText = string.IsNullOrWhiteSpace(txtMeansOfVerificationText.Text) ? "" : txtMeansOfVerificationText.Text.Trim();

            if (!string.IsNullOrEmpty(meansText))
            {
                _currentIndicator.Description = $"{mainDescription}{MeansOfVerificationSeparator}{meansText}";
            }
            else
            {
                // If meansText is empty, only save mainDescription, or _initialDescription if mainDescription is also empty and we had something before.
                _currentIndicator.Description = !string.IsNullOrEmpty(mainDescription) ? mainDescription : _initialDescription;
            }
            // Ensure description is null if effectively empty
            if (string.IsNullOrWhiteSpace(_currentIndicator.Description)) _currentIndicator.Description = null;


            _currentIndicator.TargetValue = string.IsNullOrWhiteSpace(txtTargetValue.Text) ? null : txtTargetValue.Text.Trim();
            _currentIndicator.ActualValue = string.IsNullOrWhiteSpace(txtActualValue.Text) ? null : txtActualValue.Text.Trim();
            _currentIndicator.UnitOfMeasure = string.IsNullOrWhiteSpace(txtUnitOfMeasure.Text) ? null : txtUnitOfMeasure.Text.Trim();
            _currentIndicator.BaselineValue = string.IsNullOrWhiteSpace(txtBaselineValue.Text) ? null : txtBaselineValue.Text.Trim();

            _currentIndicator.StartDate = chkSpecifyStartDate.Checked ? (DateTime?)dtpStartDate.Value : null;
            _currentIndicator.EndDate = chkSpecifyEndDate.Checked ? (DateTime?)dtpEndDate.Value : null;

            if (_currentIndicator.StartDate.HasValue && _currentIndicator.EndDate.HasValue && _currentIndicator.EndDate.Value < _currentIndicator.StartDate.Value)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpEndDate.Focus();
                return false;
            }

            _currentIndicator.IsKeyIndicator = chkIsKeyIndicator.Checked;
            _currentIndicator.ProjectID = _projectId;

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!CollectAndValidateData())
            {
                return;
            }

            SetLoadingState(true);
            try
            {
                bool success = await _monitoringService.SaveProjectIndicatorAsync(_currentIndicator);
                if (success)
                {
                    MessageBox.Show("Project Indicator saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save Project Indicator. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed) SetLoadingState(false);
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.UseWaitCursor = isLoading;
            foreach (Control c in this.Controls)
            {
                c.Enabled = !isLoading;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkSpecifyStartDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = chkSpecifyStartDate.Checked;
        }

        private void chkSpecifyEndDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = chkSpecifyEndDate.Checked;
        }
    }
}
