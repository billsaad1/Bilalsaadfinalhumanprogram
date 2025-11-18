using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class PurchaseOrderListForm : Form
    {
        private readonly PurchaseOrderServiceAdo _poService;
        private readonly ProjectService _projectService;
        private List<Project> _projectsForFilter; // To hold projects including "All Projects"

        public PurchaseOrderListForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _poService = new PurchaseOrderServiceAdo();
            _projectService = new ProjectService();
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            cmbFilterProject.AccessibleName = "Filter by Project";
            cmbFilterProject.AccessibleDescription = "Select a project to filter the purchase orders.";
            cmbFilterStatus.AccessibleName = "Filter by Status";
            cmbFilterStatus.AccessibleDescription = "Select a status to filter the purchase orders.";
            chkFilterFromDate.AccessibleName = "Enable From Date Filter";
            chkFilterFromDate.AccessibleDescription = "Check to filter purchase orders from a specific start date.";
            dtpFilterFromDate.AccessibleName = "Filter From Date";
            dtpFilterFromDate.AccessibleDescription = "Select the start date for filtering.";
            chkFilterToDate.AccessibleName = "Enable To Date Filter";
            chkFilterToDate.AccessibleDescription = "Check to filter purchase orders up to a specific end date.";
            dtpFilterToDate.AccessibleName = "Filter To Date";
            dtpFilterToDate.AccessibleDescription = "Select the end date for filtering.";
            btnApplyFilters.AccessibleName = "Apply Filters";
            btnApplyFilters.AccessibleDescription = "Applies the selected filters to the purchase order list.";
            btnClearFilters.AccessibleName = "Clear Filters and Refresh";
            btnClearFilters.AccessibleDescription = "Clears all filters and refreshes the purchase order list.";
            dgvPurchaseOrders.AccessibleName = "Purchase Orders Table";
            dgvPurchaseOrders.AccessibleDescription = "Displays a list of purchase orders based on the applied filters.";
            btnCreatePO.AccessibleName = "Create New Purchase Order";
            btnCreatePO.AccessibleDescription = "Opens a form to create a new purchase order.";
            btnViewEditPO.AccessibleName = "View or Edit Selected Purchase Order";
            btnViewEditPO.AccessibleDescription = "Opens a form to view or edit the details of the selected purchase order.";
            btnCancelDeletePO.AccessibleName = "Cancel or Delete Selected Purchase Order";
            btnCancelDeletePO.AccessibleDescription = "Cancels or deletes the selected purchase order after confirmation.";
        }

        private async void PurchaseOrderListForm_Load(object sender, EventArgs e)
        {
            await LoadInitialDataAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            SetLoadingState(true, "Loading initial data...");
            await LoadProjectsForFilterAsync();
            PopulateStatusComboBox();
            await LoadPurchaseOrdersAsync();
            SetLoadingState(false);
        }

        private async Task LoadProjectsForFilterAsync()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                _projectsForFilter = new List<Project> { new Project { ProjectID = 0, ProjectName = "All Projects" } };
                _projectsForFilter.AddRange(projects);

                cmbFilterProject.DataSource = _projectsForFilter;
                cmbFilterProject.DisplayMember = "ProjectName";
                cmbFilterProject.ValueMember = "ProjectID";
                cmbFilterProject.SelectedIndex = 0; // Default to "All Projects"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStatusComboBox()
        {
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");
            // Common PO statuses - these can be expanded or moved to a config/DB
            string[] statuses = { "Pending", "Approved", "Ordered", "Shipped", "Delivered", "Cancelled" };
            cmbFilterStatus.Items.AddRange(statuses);
            cmbFilterStatus.SelectedIndex = 0; // Default to "All"
        }

        private async Task LoadPurchaseOrdersAsync()
        {
            SetLoadingState(true, "Loading purchase orders...");
            try
            {
                int? projectId = null;
                if (cmbFilterProject.SelectedValue != null && (int)cmbFilterProject.SelectedValue != 0)
                {
                    projectId = (int)cmbFilterProject.SelectedValue;
                }

                string status = null;
                if (cmbFilterStatus.SelectedItem != null && cmbFilterStatus.SelectedItem.ToString() != "All")
                {
                    status = cmbFilterStatus.SelectedItem.ToString();
                }

                DateTime? fromDate = chkFilterFromDate.Checked ? dtpFilterFromDate.Value.Date : (DateTime?)null;
                DateTime? toDate = chkFilterToDate.Checked ? dtpFilterToDate.Value.Date.AddDays(1).AddTicks(-1) : (DateTime?)null; // End of day

                List<PurchaseOrder> purchaseOrders = await _poService.GetPurchaseOrdersAsync(projectId, status, fromDate, toDate);
                dgvPurchaseOrders.DataSource = purchaseOrders;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading purchase orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void ConfigureDataGridView()
        {
            // Hide ID columns and complex navigation properties by default
            string[] columnsToHide = { "PurchaseID", "CreatedByUserID", "ApprovedByUserID", "CreatedByUser", "ApprovedByUser", "BudgetItemPurchase", "Project", "StockTransactions" };
            foreach (string colName in columnsToHide)
            {
                if (dgvPurchaseOrders.Columns.Contains(colName))
                    dgvPurchaseOrders.Columns[colName].Visible = false;
            }

            if (dgvPurchaseOrders.Columns.Contains("PurchaseOrderID"))
                dgvPurchaseOrders.Columns["PurchaseOrderID"].HeaderText = "PO ID";

            if (dgvPurchaseOrders.Columns.Contains("ProjectID")) // This will show ID, consider joining in service for Name
                dgvPurchaseOrders.Columns["ProjectID"].HeaderText = "Project ID";

            if (dgvPurchaseOrders.Columns.Contains("SupplierName"))
                dgvPurchaseOrders.Columns["SupplierName"].HeaderText = "Supplier";

            if (dgvPurchaseOrders.Columns.Contains("OrderDate"))
            {
                dgvPurchaseOrders.Columns["OrderDate"].HeaderText = "Order Date";
                dgvPurchaseOrders.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
            if (dgvPurchaseOrders.Columns.Contains("TotalAmount"))
            {
                dgvPurchaseOrders.Columns["TotalAmount"].HeaderText = "Total Amount";
                dgvPurchaseOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            }
            if (dgvPurchaseOrders.Columns.Contains("Status"))
                dgvPurchaseOrders.Columns["Status"].HeaderText = "Status";


            foreach (DataGridViewColumn column in dgvPurchaseOrders.Columns)
            {
                if (column.Visible) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvPurchaseOrders.Columns.Contains("SupplierName") && dgvPurchaseOrders.Columns["SupplierName"].Visible)
            {
                dgvPurchaseOrders.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetLoadingState(bool isLoading, string message = "Loading...")
        {
            this.UseWaitCursor = isLoading;
            pnlFilters.Enabled = !isLoading;
            dgvPurchaseOrders.Enabled = !isLoading;
            pnlActions.Enabled = !isLoading;
            // Optionally, display 'message' in a status bar if available
        }

        private void chkFilterFromDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterFromDate.Enabled = chkFilterFromDate.Checked;
        }

        private void chkFilterToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterToDate.Enabled = chkFilterToDate.Checked;
        }

        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            await LoadPurchaseOrdersAsync();
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterProject.SelectedIndex = 0; // "All Projects"
            cmbFilterStatus.SelectedIndex = 0; // "All"
            chkFilterFromDate.Checked = false;
            chkFilterToDate.Checked = false;
            // dtp enabled state will be handled by their CheckedChanged events
            await LoadPurchaseOrdersAsync();
        }

        private async void btnCreatePO_Click(object sender, EventArgs e)
        {
            using (PurchaseOrderCreateEditForm createForm = new PurchaseOrderCreateEditForm())
            {
                if (createForm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadPurchaseOrdersAsync();
                }
            }
        }

        private async void btnViewEditPO_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrders.SelectedRows.Count > 0)
            {
                PurchaseOrder selectedPO = (PurchaseOrder)dgvPurchaseOrders.SelectedRows[0].DataBoundItem;
                SetLoadingState(true, "Loading PO Details...");
                PurchaseOrder poToEdit = null;
                try
                {
                    poToEdit = await _poService.GetPurchaseOrderByIdAsync(selectedPO.PurchaseOrderID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving Purchase Order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SetLoadingState(false);
                }

                if (poToEdit == null && !this.IsDisposed)
                {
                    MessageBox.Show("Could not retrieve PO details. The record may have been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadPurchaseOrdersAsync(); // Refresh
                    return;
                }

                if (poToEdit != null)
                {
                    using (PurchaseOrderCreateEditForm editForm = new PurchaseOrderCreateEditForm(poToEdit))
                    {
                        if (editForm.ShowDialog(this) == DialogResult.OK)
                        {
                            await LoadPurchaseOrdersAsync();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Purchase Order to view/edit.", "No PO Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnCancelDeletePO_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrders.SelectedRows.Count > 0)
            {
                PurchaseOrder selectedPO = (PurchaseOrder)dgvPurchaseOrders.SelectedRows[0].DataBoundItem;
                DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete Purchase Order ID: {selectedPO.PurchaseOrderID} (Supplier: {selectedPO.SupplierName})?\nThis action cannot be undone.",
                                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    SetLoadingState(true, "Deleting PO...");
                    bool success = false;
                    try
                    {
                        success = await _poService.DeletePurchaseOrderAsync(selectedPO.PurchaseOrderID);
                        if (success)
                        {
                            MessageBox.Show("Purchase Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete Purchase Order. It might be in use or an error occurred.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        SetLoadingState(false);
                        if (success) await LoadPurchaseOrdersAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Purchase Order to delete.", "No PO Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
