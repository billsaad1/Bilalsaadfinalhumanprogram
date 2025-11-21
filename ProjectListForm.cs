using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using HumanitarianProjectManagement.UI;

namespace HumanitarianProjectManagement.Forms
{
    public partial class ProjectListForm : Form
    {
        private readonly ProjectService _projectService;
        private readonly int? _sectionId; // Added field

        // Modified default constructor
        public ProjectListForm() : this(null)
        {
        }

        // New constructor accepting sectionId
        public ProjectListForm(int? sectionId = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _projectService = new ProjectService();
            _sectionId = sectionId;

            this.Load += new System.EventHandler(this.ProjectListForm_Load);
            SetAccessibilityProperties();

            // Optional: Adjust form title if sectionId is provided
            if (_sectionId.HasValue)
            {
                // This would be better if we fetched the Section Name.
                // For now, just indicate filtering.
                this.Text += $" (Section ID: {_sectionId.Value})";
            }
        }

        private void SetAccessibilityProperties()
        {
            dgvProjects.AccessibleName = "List of projects";
            dgvProjects.AccessibleDescription = "Displays a list of all humanitarian projects. Select a project to edit or delete.";
            btnAddProject.AccessibleName = "Add New Project";
            btnAddProject.AccessibleDescription = "Opens a form to create a new project.";
            btnEditProject.AccessibleName = "Edit Selected Project";
            btnEditProject.AccessibleDescription = "Opens a form to edit the currently selected project in the list.";
            btnDeleteProject.AccessibleName = "Delete Selected Project";
            btnDeleteProject.AccessibleDescription = "Deletes the currently selected project from the list after confirmation.";
            btnRefresh.AccessibleName = "Refresh Project List";
            btnRefresh.AccessibleDescription = "Reloads the list of projects from the database.";
            btnGoToMonitoring.AccessibleName = "Project Monitoring and Evaluation";
            btnGoToMonitoring.AccessibleDescription = "Opens the Monitoring and Evaluation form for the selected project.";
        }

        private async void ProjectListForm_Load(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            pnlButtons.Enabled = false;
            dgvProjects.Enabled = false;
            this.UseWaitCursor = true;

            try
            {
                dgvProjects.DataSource = null; // Clear previous data
                List<Project> projects;
                if (_sectionId.HasValue)
                {
                    projects = await _projectService.GetProjectsBySectionIdAsync(_sectionId.Value);
                }
                else
                {
                    projects = await _projectService.GetAllProjectsAsync();
                }
                dgvProjects.DataSource = projects;

                // Configure DataGridView columns
                if (dgvProjects.Columns["ProjectID"] != null)
                    dgvProjects.Columns["ProjectID"].Visible = false;

                if (dgvProjects.Columns["ProjectName"] != null)
                    dgvProjects.Columns["ProjectName"].HeaderText = "Project Name";

                if (dgvProjects.Columns["ProjectCode"] != null)
                    dgvProjects.Columns["ProjectCode"].HeaderText = "Code";

                if (dgvProjects.Columns["Status"] != null)
                    dgvProjects.Columns["Status"].HeaderText = "Status";

                if (dgvProjects.Columns["StartDate"] != null)
                {
                    dgvProjects.Columns["StartDate"].HeaderText = "Start Date";
                    dgvProjects.Columns["StartDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dgvProjects.Columns["EndDate"] != null)
                {
                    dgvProjects.Columns["EndDate"].HeaderText = "End Date";
                    dgvProjects.Columns["EndDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dgvProjects.Columns["TotalBudget"] != null)
                {
                    dgvProjects.Columns["TotalBudget"].HeaderText = "Budget";
                    dgvProjects.Columns["TotalBudget"].DefaultCellStyle.Format = "N2"; // Format as number with 2 decimal places
                }

                // Hide less relevant columns or those with complex objects if not handled by ToString()
                string[] columnsToHide = { "SectionID", "ManagerUserID", "Section", "ManagerUser", "BeneficiaryLists", "ProjectIndicators", "Budgets", "ProjectReports", "Feedbacks", "FollowUpVisits", "OverallObjective", "Location", "Donor", "UpdatedAt", "CreatedAt" };
                foreach (string colName in columnsToHide)
                {
                    if (dgvProjects.Columns[colName] != null)
                        dgvProjects.Columns[colName].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pnlButtons.Enabled = true;
                dgvProjects.Enabled = true;
                this.UseWaitCursor = false;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async void btnAddProject_Click(object sender, EventArgs e)
        {
            // Pass _sectionId to ProjectCreateEditForm
            using (ProjectCreateEditForm addForm = new ProjectCreateEditForm(projectToEdit: null, initialSectionId: _sectionId))
            {
                if (addForm.ShowDialog(this) == DialogResult.OK) // Set owner
                {
                    await LoadProjectsAsync(); // Refresh the list
                }
            }
        }

        private async void btnEditProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                Project selectedProjectSummary = (Project)dgvProjects.SelectedRows[0].DataBoundItem;

                btnEditProject.Enabled = false; // Corrected this line for better UX
                pnlButtons.Enabled = false; // Disable whole panel for better UX
                dgvProjects.Enabled = false;
                this.UseWaitCursor = true;
                Project projectToEdit = null;

                try
                {
                    // Fetch the full, fresh project details
                    projectToEdit = await _projectService.GetProjectByIdAsync(selectedProjectSummary.ProjectID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving project details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnEditProject.Enabled = true; // Re-enable specific button
                    pnlButtons.Enabled = true; // Re-enable panel
                    dgvProjects.Enabled = true;
                    this.UseWaitCursor = false;
                }


                if (projectToEdit != null)
                {
                    using (ProjectCreateEditForm editForm = new ProjectCreateEditForm(projectToEdit))
                    {
                        if (editForm.ShowDialog(this) == DialogResult.OK) // Set owner
                        {
                            await LoadProjectsAsync();
                        }
                    }
                }
                else if (!this.IsDisposed) // Check if form is still alive before showing another message box
                {
                    MessageBox.Show("Could not retrieve project details. The project may have been deleted or an error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadProjectsAsync(); // Refresh the list as the project might be gone
                }
            }
            else
            {
                MessageBox.Show("Please select a project to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                Project selectedProject = (Project)dgvProjects.SelectedRows[0].DataBoundItem;
                DialogResult result = MessageBox.Show($"Are you sure you want to delete project: '{selectedProject.ProjectName}' (ID: {selectedProject.ProjectID})?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    pnlButtons.Enabled = false;
                    dgvProjects.Enabled = false;
                    this.UseWaitCursor = true;
                    bool success = false;

                    try
                    {
                        success = await _projectService.DeleteProjectAsync(selectedProject.ProjectID);

                        if (success)
                        {
                            MessageBox.Show("Project deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadProjectsAsync(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete project. It might be in use or an error occurred. Check logs for details.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        pnlButtons.Enabled = true;
                        dgvProjects.Enabled = true;
                        this.UseWaitCursor = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a project to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGoToMonitoring_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                Project selectedProject = (Project)dgvProjects.SelectedRows[0].DataBoundItem;
                ProjectMonitoringForm monitoringForm = new ProjectMonitoringForm(selectedProject.ProjectID, selectedProject.ProjectName);
                monitoringForm.Show(this);
            }
            else
            {
                MessageBox.Show("Please select a project to view its M&E / Progress.", "No Project Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
