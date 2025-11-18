using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class ProjectMonitoringForm : Form
    {
        private readonly MonitoringService _monitoringService;
        private readonly int _projectId;
        private readonly string _projectName;

        public ProjectMonitoringForm(int projectId, string projectName)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _monitoringService = new MonitoringService();
            _projectId = projectId;
            _projectName = projectName;

            this.Text = $"Monitoring: {projectName}";
            lblProjectNameDisplay.Text = $"Indicators for Project: {projectName}";
            this.CancelButton = btnClose;

            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            lblProjectNameDisplay.AccessibleName = "Project Name Display";
            lblProjectNameDisplay.AccessibleDescription = "Displays the name of the project whose indicators are being monitored.";
            dgvProjectIndicators.AccessibleName = "Project Indicators Table";
            dgvProjectIndicators.AccessibleDescription = "Displays a list of indicators for the selected project. Select a row to edit or delete an indicator.";
            btnAddIndicator.AccessibleName = "Add New Indicator";
            btnAddIndicator.AccessibleDescription = "Opens a form to add a new indicator for this project.";
            btnEditIndicator.AccessibleName = "Edit Selected Indicator";
            btnEditIndicator.AccessibleDescription = "Opens a form to edit the details of the selected project indicator.";
            btnDeleteIndicator.AccessibleName = "Delete Selected Indicator";
            btnDeleteIndicator.AccessibleDescription = "Deletes the selected project indicator after confirmation.";
            btnRefreshIndicators.AccessibleName = "Refresh Indicators List";
            btnRefreshIndicators.AccessibleDescription = "Reloads the list of indicators for this project from the database.";
            btnClose.AccessibleName = "Close Monitoring Window";
            btnClose.AccessibleDescription = "Closes the project monitoring window.";
        }

        private async void ProjectMonitoringForm_Load(object sender, EventArgs e)
        {
            await LoadIndicatorsAsync();
        }

        private async Task LoadIndicatorsAsync()
        {
            SetLoadingState(true);
            try
            {
                List<ProjectIndicator> indicators = await _monitoringService.GetIndicatorsForProjectAsync(_projectId);
                dgvProjectIndicators.DataSource = indicators;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading project indicators: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void ConfigureDataGridView()
        {
            string[] columnsToHide = { "ProjectIndicatorID", "ProjectID", "Project", "VerificationMeans", "Description", "BaselineValue", "StartDate", "EndDate" }; // Changed IndicatorID to ProjectIndicatorID
            foreach (string colName in columnsToHide)
            {
                if (dgvProjectIndicators.Columns.Contains(colName))
                    dgvProjectIndicators.Columns[colName].Visible = false;
            }

            if (dgvProjectIndicators.Columns.Contains("IndicatorName"))
                dgvProjectIndicators.Columns["IndicatorName"].HeaderText = "Indicator";
            if (dgvProjectIndicators.Columns.Contains("TargetValue"))
                dgvProjectIndicators.Columns["TargetValue"].HeaderText = "Target";
            if (dgvProjectIndicators.Columns.Contains("ActualValue"))
                dgvProjectIndicators.Columns["ActualValue"].HeaderText = "Actual";
            if (dgvProjectIndicators.Columns.Contains("UnitOfMeasure"))
                dgvProjectIndicators.Columns["UnitOfMeasure"].HeaderText = "Unit";
            if (dgvProjectIndicators.Columns.Contains("IsKeyIndicator"))
                dgvProjectIndicators.Columns["IsKeyIndicator"].HeaderText = "Key?";

            foreach (DataGridViewColumn column in dgvProjectIndicators.Columns)
            {
                if (column.Visible) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvProjectIndicators.Columns.Contains("IndicatorName") && dgvProjectIndicators.Columns["IndicatorName"].Visible)
            {
                dgvProjectIndicators.Columns["IndicatorName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.UseWaitCursor = isLoading;
            pnlIndicatorActions.Enabled = !isLoading;
            dgvProjectIndicators.Enabled = !isLoading;
        }

        private async void btnAddIndicator_Click(object sender, EventArgs e)
        {
            using (ProjectIndicatorCreateEditForm addForm = new ProjectIndicatorCreateEditForm(_projectId, _projectName))
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadIndicatorsAsync();
                }
            }
        }

        private async void btnEditIndicator_Click(object sender, EventArgs e)
        {
            if (dgvProjectIndicators.SelectedRows.Count > 0)
            {
                ProjectIndicator selectedSummary = (ProjectIndicator)dgvProjectIndicators.SelectedRows[0].DataBoundItem;
                SetLoadingState(true);
                ProjectIndicator indicatorToEdit = null;
                try
                {
                    indicatorToEdit = await _monitoringService.GetIndicatorByIdAsync(selectedSummary.ProjectIndicatorID); // Changed to ProjectIndicatorID
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving indicator details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SetLoadingState(false);
                }

                if (indicatorToEdit == null && !this.IsDisposed)
                {
                    MessageBox.Show("Could not retrieve indicator details. The record may have been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadIndicatorsAsync(); // Refresh
                    return;
                }

                if (indicatorToEdit != null)
                {
                    using (ProjectIndicatorCreateEditForm editForm = new ProjectIndicatorCreateEditForm(_projectId, _projectName, indicatorToEdit))
                    {
                        if (editForm.ShowDialog(this) == DialogResult.OK)
                        {
                            await LoadIndicatorsAsync();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an indicator to edit.", "No Indicator Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteIndicator_Click(object sender, EventArgs e)
        {
            if (dgvProjectIndicators.SelectedRows.Count > 0)
            {
                ProjectIndicator selectedIndicator = (ProjectIndicator)dgvProjectIndicators.SelectedRows[0].DataBoundItem;
                DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete indicator: '{selectedIndicator.IndicatorName}'?",
                                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    SetLoadingState(true);
                    bool success = false;
                    try
                    {
                        success = await _monitoringService.DeleteProjectIndicatorAsync(selectedIndicator.ProjectIndicatorID); // Changed to ProjectIndicatorID
                        if (success)
                        {
                            MessageBox.Show("Indicator deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete indicator. It might be in use or an error occurred.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        SetLoadingState(false);
                        if (success) await LoadIndicatorsAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an indicator to delete.", "No Indicator Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnRefreshIndicators_Click(object sender, EventArgs e)
        {
            await LoadIndicatorsAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
