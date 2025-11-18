using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    public partial class BeneficiaryListManagementForm : Form
    {
        private readonly ProjectService _projectService;
        private readonly BeneficiaryService _beneficiaryService;

        public BeneficiaryListManagementForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _projectService = new ProjectService();
            _beneficiaryService = new BeneficiaryService();

            // Accessibility Enhancements
            cmbProjects.AccessibleName = "Select Project";
            cmbProjects.AccessibleDescription = "Choose a project to view its beneficiary lists.";
            dgvBeneficiaryLists.AccessibleName = "Beneficiary Lists";
            dgvBeneficiaryLists.AccessibleDescription = "Displays beneficiary lists for the selected project.";
            btnAddList.AccessibleName = "Add New Beneficiary List";
            btnAddList.AccessibleDescription = "Adds a new beneficiary list to the selected project.";
            btnEditList.AccessibleName = "Edit Selected Beneficiary List";
            btnEditList.AccessibleDescription = "Edits the currently selected beneficiary list.";
            btnDeleteList.AccessibleName = "Delete Selected Beneficiary List";
            btnDeleteList.AccessibleDescription = "Deletes the currently selected beneficiary list after confirmation.";
            btnViewBeneficiaries.AccessibleName = "Manage Beneficiaries in Selected List";
            btnViewBeneficiaries.AccessibleDescription = "Opens a new form to manage individual beneficiaries within the selected list.";
            btnRefreshLists.AccessibleName = "Refresh Beneficiary Lists";
            btnRefreshLists.AccessibleDescription = "Reloads the beneficiary lists for the currently selected project.";
        }

        private async void BeneficiaryListManagementForm_Load(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            this.UseWaitCursor = true;
            cmbProjects.Enabled = false;
            pnlButtons.Enabled = false;

            try
            {
                List<Project> projects = await _projectService.GetAllProjectsAsync();
                cmbProjects.DataSource = projects;
                cmbProjects.DisplayMember = "ProjectName";
                cmbProjects.ValueMember = "ProjectID";
                cmbProjects.SelectedIndex = -1; // No project selected initially
                dgvBeneficiaryLists.DataSource = null; // Clear lists
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                cmbProjects.Enabled = true;
                // pnlButtons remains disabled until a project and potentially a list is selected
            }
        }

        private async void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectId)
            {
                await LoadBeneficiaryListsAsync(projectId);
            }
            else
            {
                dgvBeneficiaryLists.DataSource = null;
                pnlButtons.Enabled = false;
            }
        }

        private async Task LoadBeneficiaryListsAsync(int projectId)
        {
            this.UseWaitCursor = true;
            cmbProjects.Enabled = false;
            pnlButtons.Enabled = false;
            dgvBeneficiaryLists.Enabled = false;

            try
            {
                List<BeneficiaryList> lists = await _beneficiaryService.GetBeneficiaryListsAsync(projectId);
                dgvBeneficiaryLists.DataSource = lists;

                // Configure columns
                if (dgvBeneficiaryLists.Columns["BeneficiaryListID"] != null)
                    dgvBeneficiaryLists.Columns["BeneficiaryListID"].Visible = false;
                if (dgvBeneficiaryLists.Columns["ProjectID"] != null)
                    dgvBeneficiaryLists.Columns["ProjectID"].Visible = false;
                if (dgvBeneficiaryLists.Columns["Project"] != null)
                    dgvBeneficiaryLists.Columns["Project"].Visible = false;
                if (dgvBeneficiaryLists.Columns["Beneficiaries"] != null)
                    dgvBeneficiaryLists.Columns["Beneficiaries"].Visible = false;


                if (dgvBeneficiaryLists.Columns["ListName"] != null)
                {
                    dgvBeneficiaryLists.Columns["ListName"].HeaderText = "List Name";
                    dgvBeneficiaryLists.Columns["ListName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvBeneficiaryLists.Columns["Description"] != null)
                {
                    dgvBeneficiaryLists.Columns["Description"].HeaderText = "Description";
                    dgvBeneficiaryLists.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvBeneficiaryLists.Columns["CreationDate"] != null)
                {
                    dgvBeneficiaryLists.Columns["CreationDate"].HeaderText = "Created On";
                    dgvBeneficiaryLists.Columns["CreationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvBeneficiaryLists.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading beneficiary lists: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                cmbProjects.Enabled = true;
                pnlButtons.Enabled = true; // Enable buttons after loading lists
                dgvBeneficiaryLists.Enabled = true;
            }
        }

        private async void btnAddList_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int selectedProjectId && cmbProjects.SelectedItem is Project selectedProject)
            {
                using (BeneficiaryListCreateEditForm addForm = new BeneficiaryListCreateEditForm(selectedProjectId, selectedProject.ProjectName))
                {
                    if (addForm.ShowDialog(this) == DialogResult.OK)
                    {
                        await LoadBeneficiaryListsAsync(selectedProjectId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a project first.", "Project Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEditList_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int selectedProjectId && cmbProjects.SelectedItem is Project selectedProject)
            {
                if (dgvBeneficiaryLists.SelectedRows.Count > 0)
                {
                    BeneficiaryList listToEdit = (BeneficiaryList)dgvBeneficiaryLists.SelectedRows[0].DataBoundItem;
                    // Optional: Fetch fresh list details if concurrent edits are a concern
                    // BeneficiaryList freshList = await _beneficiaryService.GetBeneficiaryListByIdAsync(listToEdit.BeneficiaryListID);
                    // if (freshList == null) { MessageBox.Show("Could not retrieve list details.", "Error"); return; }
                    using (BeneficiaryListCreateEditForm editForm = new BeneficiaryListCreateEditForm(selectedProjectId, selectedProject.ProjectName, listToEdit))
                    {
                        if (editForm.ShowDialog(this) == DialogResult.OK)
                        {
                            await LoadBeneficiaryListsAsync(selectedProjectId);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a list to edit.", "List Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a project first.", "Project Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteList_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int selectedProjectId)
            {
                if (dgvBeneficiaryLists.SelectedRows.Count > 0)
                {
                    BeneficiaryList selectedList = (BeneficiaryList)dgvBeneficiaryLists.SelectedRows[0].DataBoundItem;
                    DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete the list '{selectedList.ListName}'? This action cannot be undone.",
                                                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmation == DialogResult.Yes)
                    {
                        this.UseWaitCursor = true;
                        pnlButtons.Enabled = false;
                        dgvBeneficiaryLists.Enabled = false;
                        bool success = false;
                        try
                        {
                            success = await _beneficiaryService.DeleteBeneficiaryListAsync(selectedList.BeneficiaryListID);
                            if (success)
                            {
                                MessageBox.Show("Beneficiary list deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete beneficiary list. It might be in use or an error occurred.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            this.UseWaitCursor = false;
                            pnlButtons.Enabled = true;
                            dgvBeneficiaryLists.Enabled = true;
                            if (success) // Refresh only if delete was successful
                            {
                                await LoadBeneficiaryListsAsync(selectedProjectId);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a beneficiary list to delete.", "List Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a project first.", "Project Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewBeneficiaries_Click(object sender, EventArgs e)
        {
            if (dgvBeneficiaryLists.SelectedRows.Count > 0)
            {
                BeneficiaryList selectedList = (BeneficiaryList)dgvBeneficiaryLists.SelectedRows[0].DataBoundItem;
                BeneficiaryMainForm beneficiariesForm = new BeneficiaryMainForm(selectedList.BeneficiaryListID, selectedList.ListName);
                beneficiariesForm.Show(this); // Or ShowDialog(this) if modal is preferred
            }
            else
            {
                MessageBox.Show("Please select a list to view beneficiaries.", "List Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnRefreshLists_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectId)
            {
                await LoadBeneficiaryListsAsync(projectId);
            }
            else
            {
                dgvBeneficiaryLists.DataSource = null; // Clear if no project selected
                MessageBox.Show("Please select a project to refresh its lists.", "Project Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
