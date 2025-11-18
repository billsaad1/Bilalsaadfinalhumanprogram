using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class StockItemListForm : Form
    {
        private readonly StockService _stockService;

        public StockItemListForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _stockService = new StockService();
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            txtSearchStockItem.AccessibleName = "Search Stock Items";
            txtSearchStockItem.AccessibleDescription = "Enter item name or description to search for stock items.";
            btnSearchStockItem.AccessibleName = "Search Button";
            btnSearchStockItem.AccessibleDescription = "Starts the search for stock items.";
            btnClearSearchStockItem.AccessibleName = "Clear Search or Refresh List";
            btnClearSearchStockItem.AccessibleDescription = "Clears the search term and refreshes the list of stock items.";
            dgvStockItems.AccessibleName = "Stock Items Table";
            dgvStockItems.AccessibleDescription = "Displays stock items. Select a row to edit, delete, or manage transactions.";
            btnAddNewItem.AccessibleName = "Add New Stock Item";
            btnAddNewItem.AccessibleDescription = "Opens a form to add a new stock item.";
            btnEditItem.AccessibleName = "Edit Selected Stock Item";
            btnEditItem.AccessibleDescription = "Opens a form to edit the details of the selected stock item.";
            btnDeleteItem.AccessibleName = "Delete Selected Stock Item";
            btnDeleteItem.AccessibleDescription = "Deletes the selected stock item after confirmation.";
            btnRecordTransaction.AccessibleName = "Record Stock Transaction";
            btnRecordTransaction.AccessibleDescription = "Opens a form to record a new transaction (in/out/adjustment) for the selected item.";
            btnViewItemHistory.AccessibleName = "View Stock Item History";
            btnViewItemHistory.AccessibleDescription = "Opens a form to view the transaction history for the selected item.";
        }

        private async void StockItemListForm_Load(object sender, EventArgs e)
        {
            await LoadStockItemsAsync();
        }

        private async Task LoadStockItemsAsync(string searchTerm = null)
        {
            SetLoadingState(true);
            try
            {
                List<StockItem> stockItems = await _stockService.GetAllStockItemsAsync(searchTerm);
                dgvStockItems.DataSource = stockItems;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvStockItems.Columns["StockItemID"] != null)
                dgvStockItems.Columns["StockItemID"].Visible = false;
            if (dgvStockItems.Columns["StockTransactions"] != null)
                dgvStockItems.Columns["StockTransactions"].Visible = false; // Hide navigation property

            if (dgvStockItems.Columns["ItemName"] != null)
                dgvStockItems.Columns["ItemName"].HeaderText = "Item Name";
            if (dgvStockItems.Columns["Description"] != null)
                dgvStockItems.Columns["Description"].HeaderText = "Description";
            if (dgvStockItems.Columns["UnitOfMeasure"] != null)
                dgvStockItems.Columns["UnitOfMeasure"].HeaderText = "Unit";
            if (dgvStockItems.Columns["CurrentQuantity"] != null)
                dgvStockItems.Columns["CurrentQuantity"].HeaderText = "Current Qty";
            if (dgvStockItems.Columns["MinStockLevel"] != null)
                dgvStockItems.Columns["MinStockLevel"].HeaderText = "Min Level";
            if (dgvStockItems.Columns["LastStockUpdate"] != null)
            {
                dgvStockItems.Columns["LastStockUpdate"].HeaderText = "Last Update";
                dgvStockItems.Columns["LastStockUpdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }

            // Auto-size visible columns
            foreach (DataGridViewColumn column in dgvStockItems.Columns)
            {
                if (column.Visible)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            if (dgvStockItems.Columns["Description"] != null && dgvStockItems.Columns["Description"].Visible)
            {
                dgvStockItems.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.UseWaitCursor = isLoading;
            pnlSearch.Enabled = !isLoading;
            dgvStockItems.Enabled = !isLoading;
            pnlStockItemControls.Enabled = !isLoading;
        }

        private async void btnSearchStockItem_Click(object sender, EventArgs e)
        {
            await LoadStockItemsAsync(txtSearchStockItem.Text.Trim());
        }

        private async void btnClearSearchStockItem_Click(object sender, EventArgs e)
        {
            txtSearchStockItem.Clear();
            await LoadStockItemsAsync();
        }

        private async void btnAddNewItem_Click(object sender, EventArgs e)
        {
            using (StockItemCreateEditForm addItemForm = new StockItemCreateEditForm())
            {
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadStockItemsAsync();
                }
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            if (dgvStockItems.SelectedRows.Count > 0)
            {
                StockItem selectedItemSummary = (StockItem)dgvStockItems.SelectedRows[0].DataBoundItem;
                SetLoadingState(true);
                StockItem itemToEdit = null;
                try
                {
                    itemToEdit = await _stockService.GetStockItemByIdAsync(selectedItemSummary.StockItemID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving item details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SetLoadingState(false);
                }

                if (itemToEdit == null && !this.IsDisposed)
                {
                    MessageBox.Show("Could not retrieve item details. The record may have been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadStockItemsAsync(); // Refresh
                    return;
                }

                if (itemToEdit != null)
                {
                    using (StockItemCreateEditForm editItemForm = new StockItemCreateEditForm(itemToEdit))
                    {
                        if (editItemForm.ShowDialog(this) == DialogResult.OK)
                        {
                            await LoadStockItemsAsync();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvStockItems.SelectedRows.Count > 0)
            {
                StockItem selectedItem = (StockItem)dgvStockItems.SelectedRows[0].DataBoundItem;
                DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete item '{selectedItem.ItemName}' (ID: {selectedItem.StockItemID})?\nThis action cannot be undone.",
                                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    SetLoadingState(true);
                    bool success = false;
                    try
                    {
                        // Note: Deleting a stock item might fail if there are related StockTransaction records
                        // due to foreign key constraints. The service method or DB should handle this.
                        success = await _stockService.DeleteStockItemAsync(selectedItem.StockItemID);
                        if (success)
                        {
                            MessageBox.Show("Stock item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete stock item. It might be in use (e.g., has transactions) or an error occurred.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        SetLoadingState(false);
                        if (success) await LoadStockItemsAsync(); // Refresh list
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnRecordTransaction_Click(object sender, EventArgs e)
        {
            if (dgvStockItems.SelectedRows.Count > 0)
            {
                StockItem selectedItem = (StockItem)dgvStockItems.SelectedRows[0].DataBoundItem;
                using (StockTransactionCreateForm addTransactionForm = new StockTransactionCreateForm(selectedItem.StockItemID, selectedItem.ItemName))
                {
                    if (addTransactionForm.ShowDialog(this) == DialogResult.OK)
                    {
                        await LoadStockItemsAsync(); // Refresh list to show updated quantity
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to record a transaction for.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewItemHistory_Click(object sender, EventArgs e)
        {
            if (dgvStockItems.SelectedRows.Count > 0)
            {
                StockItem selectedItem = (StockItem)dgvStockItems.SelectedRows[0].DataBoundItem;
                StockItemHistoryForm historyForm = new StockItemHistoryForm(selectedItem.StockItemID, selectedItem.ItemName);
                historyForm.Show(this); // Or ShowDialog(this) for modal
            }
            else
            {
                MessageBox.Show("Please select an item to view its history.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
