using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class BeneficiaryMainForm : Form
    {
        private readonly BeneficiaryService _beneficiaryService;
        private readonly int _currentBeneficiaryListId;
        private readonly string _currentBeneficiaryListName;

        public BeneficiaryMainForm(int beneficiaryListId, string beneficiaryListName)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _beneficiaryService = new BeneficiaryService();
            _currentBeneficiaryListId = beneficiaryListId;
            _currentBeneficiaryListName = beneficiaryListName;

            this.Text = $"Beneficiaries in List: {_currentBeneficiaryListName}";
            lblListNameDisplay.Text = $"List Name: {_currentBeneficiaryListName}";

            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            lblListNameDisplay.AccessibleName = "Current Beneficiary List Name";
            txtSearchBeneficiary.AccessibleName = "Search Beneficiaries";
            txtSearchBeneficiary.AccessibleDescription = "Enter name or national ID to search for beneficiaries in the current list.";
            btnSearchBeneficiary.AccessibleName = "Search Button";
            btnSearchBeneficiary.AccessibleDescription = "Starts the search for beneficiaries based on the entered term.";
            btnClearSearchBeneficiary.AccessibleName = "Clear Search Button";
            btnClearSearchBeneficiary.AccessibleDescription = "Clears the search term and refreshes the list of beneficiaries.";
            dgvBeneficiaries.AccessibleName = "Beneficiaries Table";
            dgvBeneficiaries.AccessibleDescription = "Displays beneficiaries in the current list. Select a row to edit or delete a beneficiary.";
            btnAddBeneficiary.AccessibleName = "Add New Beneficiary";
            btnAddBeneficiary.AccessibleDescription = "Opens a form to add a new beneficiary to this list.";
            btnEditBeneficiary.AccessibleName = "Edit Selected Beneficiary";
            btnEditBeneficiary.AccessibleDescription = "Opens a form to edit the details of the selected beneficiary.";
            btnDeleteBeneficiary.AccessibleName = "Delete Selected Beneficiary";
            btnDeleteBeneficiary.AccessibleDescription = "Deletes the selected beneficiary after confirmation.";
            btnImportBeneficiaries.AccessibleName = "Import Beneficiaries";
            btnImportBeneficiaries.AccessibleDescription = "Opens a dialog to import beneficiaries from a file (functionality not yet implemented).";
            btnExportBeneficiaries.AccessibleName = "Export Beneficiaries";
            btnExportBeneficiaries.AccessibleDescription = "Opens a dialog to export the current list of beneficiaries to a file (functionality not yet implemented).";
        }


        private async void BeneficiaryMainForm_Load(object sender, EventArgs e)
        {
            await LoadBeneficiariesAsync();
        }

        private async Task LoadBeneficiariesAsync(string searchTerm = null)
        {
            SetLoadingState(true);
            try
            {
                List<Beneficiary> beneficiaries;
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    beneficiaries = await _beneficiaryService.GetBeneficiariesByListIdAsync(_currentBeneficiaryListId);
                }
                else
                {
                    beneficiaries = await _beneficiaryService.SearchBeneficiariesAsync(searchTerm, _currentBeneficiaryListId);
                }
                dgvBeneficiaries.DataSource = beneficiaries;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading beneficiaries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvBeneficiaries.Columns["BeneficiaryID"] != null)
                dgvBeneficiaries.Columns["BeneficiaryID"].Visible = false;
            if (dgvBeneficiaries.Columns["BeneficiaryListID"] != null)
                dgvBeneficiaries.Columns["BeneficiaryListID"].Visible = false;
            if (dgvBeneficiaries.Columns["BeneficiaryList"] != null)
                dgvBeneficiaries.Columns["BeneficiaryList"].Visible = false;
            if (dgvBeneficiaries.Columns["StockTransactions"] != null)
                dgvBeneficiaries.Columns["StockTransactions"].Visible = false;
            if (dgvBeneficiaries.Columns["Feedbacks"] != null)
                dgvBeneficiaries.Columns["Feedbacks"].Visible = false;
            if (dgvBeneficiaries.Columns["FollowUpVisits"] != null)
                dgvBeneficiaries.Columns["FollowUpVisits"].Visible = false;

            if (dgvBeneficiaries.Columns["FirstName"] != null)
                dgvBeneficiaries.Columns["FirstName"].HeaderText = "First Name";
            if (dgvBeneficiaries.Columns["LastName"] != null)
                dgvBeneficiaries.Columns["LastName"].HeaderText = "Last Name";
            if (dgvBeneficiaries.Columns["NationalID"] != null)
                dgvBeneficiaries.Columns["NationalID"].HeaderText = "National ID";
            if (dgvBeneficiaries.Columns["Gender"] != null)
                dgvBeneficiaries.Columns["Gender"].HeaderText = "Gender";
            if (dgvBeneficiaries.Columns["DateOfBirth"] != null)
            {
                dgvBeneficiaries.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                dgvBeneficiaries.Columns["DateOfBirth"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
            if (dgvBeneficiaries.Columns["RegistrationDate"] != null)
            {
                dgvBeneficiaries.Columns["RegistrationDate"].HeaderText = "Registered On";
                dgvBeneficiaries.Columns["RegistrationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
            // Auto-size columns for better fit
            foreach (DataGridViewColumn column in dgvBeneficiaries.Columns)
            {
                if (column.Visible) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.UseWaitCursor = isLoading;
            txtSearchBeneficiary.Enabled = !isLoading;
            btnSearchBeneficiary.Enabled = !isLoading;
            btnClearSearchBeneficiary.Enabled = !isLoading;
            dgvBeneficiaries.Enabled = !isLoading;
            pnlBeneficiaryControls.Enabled = !isLoading;
        }

        private async void btnSearchBeneficiary_Click(object sender, EventArgs e)
        {
            await LoadBeneficiariesAsync(txtSearchBeneficiary.Text.Trim());
        }

        private async void btnClearSearchBeneficiary_Click(object sender, EventArgs e)
        {
            txtSearchBeneficiary.Clear();
            await LoadBeneficiariesAsync();
        }

        private async void btnAddBeneficiary_Click(object sender, EventArgs e)
        {
            using (BeneficiaryCreateEditForm addForm = new BeneficiaryCreateEditForm(_currentBeneficiaryListId, _currentBeneficiaryListName))
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadBeneficiariesAsync();
                }
            }
        }

        private async void btnEditBeneficiary_Click(object sender, EventArgs e)
        {
            if (dgvBeneficiaries.SelectedRows.Count > 0)
            {
                Beneficiary selected = (Beneficiary)dgvBeneficiaries.SelectedRows[0].DataBoundItem;
                SetLoadingState(true); // UI Feedback for potentially long GetByIdAsync
                Beneficiary beneficiaryToEdit = null;
                try
                {
                    beneficiaryToEdit = await _beneficiaryService.GetBeneficiaryByIdAsync(selected.BeneficiaryID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving beneficiary details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SetLoadingState(false);
                }

                if (beneficiaryToEdit == null && !this.IsDisposed)
                {
                    MessageBox.Show("Could not retrieve beneficiary details. The record may have been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadBeneficiariesAsync(); // Refresh
                    return;
                }

                if (beneficiaryToEdit != null)
                {
                    using (BeneficiaryCreateEditForm editForm = new BeneficiaryCreateEditForm(_currentBeneficiaryListId, _currentBeneficiaryListName, beneficiaryToEdit))
                    {
                        if (editForm.ShowDialog(this) == DialogResult.OK)
                        {
                            await LoadBeneficiariesAsync();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a beneficiary to edit.", "No Beneficiary Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteBeneficiary_Click(object sender, EventArgs e)
        {
            if (dgvBeneficiaries.SelectedRows.Count > 0)
            {
                Beneficiary selectedBeneficiary = (Beneficiary)dgvBeneficiaries.SelectedRows[0].DataBoundItem;
                DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete beneficiary '{selectedBeneficiary.FirstName} {selectedBeneficiary.LastName}' (ID: {selectedBeneficiary.BeneficiaryID})?",
                                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    SetLoadingState(true);
                    bool success = false;
                    try
                    {
                        success = await _beneficiaryService.DeleteBeneficiaryAsync(selectedBeneficiary.BeneficiaryID);
                        if (success)
                        {
                            MessageBox.Show("Beneficiary deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete beneficiary. An error occurred or the beneficiary was not found.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        SetLoadingState(false);
                        if (success)
                        {
                            await LoadBeneficiariesAsync(); // Refresh list
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a beneficiary to delete.", "No Beneficiary Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImportBeneficiaries_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Import functionality not yet implemented.", "Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportBeneficiaries_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export functionality not yet implemented.", "Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
