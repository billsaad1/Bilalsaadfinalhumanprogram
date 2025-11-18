using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class StockItemHistoryForm : Form
    {
        private readonly StockService _stockService;
        // private readonly UserService _userService; // Optional, if you want to display user names instead of IDs
        private readonly int _stockItemId;
        private readonly string _stockItemName;

        public StockItemHistoryForm(int stockItemId, string stockItemName)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _stockService = new StockService();
            // _userService = new UserService(); // Uncomment if needed
            _stockItemId = stockItemId;
            _stockItemName = stockItemName;

            this.Text = $"Transaction History for: {_stockItemName}";
            lblStockItemNameDisplay.Text = $"Item History for: {_stockItemName}";

            // Initialize date filters
            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpToDate.Value = DateTime.Today;
            chkFilterFromDate.Checked = false;
            chkFilterToDate.Checked = false;
            dtpFromDate.Enabled = false;
            dtpToDate.Enabled = false;

            this.CancelButton = btnClose; // Set CancelButton
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            lblStockItemNameDisplay.AccessibleName = "Stock Item Name Display";
            lblStockItemNameDisplay.AccessibleDescription = "Displays the name of the stock item whose history is being viewed.";
            chkFilterFromDate.AccessibleName = "Filter From Date Checkbox";
            chkFilterFromDate.AccessibleDescription = "Check to enable filtering transactions from a specific start date.";
            dtpFromDate.AccessibleName = "From Date Picker";
            dtpFromDate.AccessibleDescription = "Select the start date for filtering transaction history.";
            chkFilterToDate.AccessibleName = "Filter To Date Checkbox";
            chkFilterToDate.AccessibleDescription = "Check to enable filtering transactions up to a specific end date.";
            dtpToDate.AccessibleName = "To Date Picker";
            dtpToDate.AccessibleDescription = "Select the end date for filtering transaction history.";
            btnApplyDateFilter.AccessibleName = "Apply Date Filter Button";
            btnApplyDateFilter.AccessibleDescription = "Applies the selected date range filter to the transaction history.";
            btnClearDateFilter.AccessibleName = "Clear Date Filter Button";
            btnClearDateFilter.AccessibleDescription = "Clears the date range filter and shows all transactions for the item.";
            dgvTransactionHistory.AccessibleName = "Transaction History Table";
            dgvTransactionHistory.AccessibleDescription = "Displays the list of stock transactions for the selected item and date range.";
            btnClose.AccessibleName = "Close Button";
            btnClose.AccessibleDescription = "Closes the transaction history window.";
        }


        private async void StockItemHistoryForm_Load(object sender, EventArgs e)
        {
            await LoadTransactionHistoryAsync();
        }

        private async Task LoadTransactionHistoryAsync()
        {
            SetLoadingState(true);
            try
            {
                DateTime? fromDate = chkFilterFromDate.Checked ? dtpFromDate.Value.Date : (DateTime?)null;
                DateTime? toDate = chkFilterToDate.Checked ? dtpToDate.Value.Date.AddDays(1).AddTicks(-1) : (DateTime?)null; // End of day

                List<StockTransaction> transactions = await _stockService.GetTransactionsForItemAsync(_stockItemId, fromDate, toDate);
                dgvTransactionHistory.DataSource = transactions;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transaction history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void ConfigureDataGridView()
        {
            // Hide IDs and navigation properties
            string[] columnsToHide = { "TransactionID", "StockItemID", "StockItem", "Project", "PurchaseOrder", "Activity", "Beneficiary", "RecordedByUser" };
            foreach (string colName in columnsToHide)
            {
                if (dgvTransactionHistory.Columns[colName] != null)
                    dgvTransactionHistory.Columns[colName].Visible = false;
            }

            // Set Headers and Formats
            if (dgvTransactionHistory.Columns["TransactionDate"] != null)
            {
                dgvTransactionHistory.Columns["TransactionDate"].HeaderText = "Date";
                dgvTransactionHistory.Columns["TransactionDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            if (dgvTransactionHistory.Columns["TransactionType"] != null)
                dgvTransactionHistory.Columns["TransactionType"].HeaderText = "Type";
            if (dgvTransactionHistory.Columns["Quantity"] != null)
                dgvTransactionHistory.Columns["Quantity"].HeaderText = "Qty";
            if (dgvTransactionHistory.Columns["Reason"] != null)
                dgvTransactionHistory.Columns["Reason"].HeaderText = "Reason";
            if (dgvTransactionHistory.Columns["DistributedTo"] != null)
                dgvTransactionHistory.Columns["DistributedTo"].HeaderText = "Source/Recipient";
            if (dgvTransactionHistory.Columns["RecordedByUserID"] != null)
                dgvTransactionHistory.Columns["RecordedByUserID"].HeaderText = "User ID"; // Later, could resolve to username
            if (dgvTransactionHistory.Columns["Notes"] != null)
                dgvTransactionHistory.Columns["Notes"].HeaderText = "Notes";

            // Auto-size columns for better fit
            foreach (DataGridViewColumn column in dgvTransactionHistory.Columns)
            {
                if (column.Visible) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvTransactionHistory.Columns["Reason"] != null && dgvTransactionHistory.Columns["Reason"].Visible)
            {
                dgvTransactionHistory.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvTransactionHistory.Columns["Notes"] != null && dgvTransactionHistory.Columns["Notes"].Visible)
            {
                dgvTransactionHistory.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.UseWaitCursor = isLoading;
            pnlDateFilter.Enabled = !isLoading;
            dgvTransactionHistory.Enabled = !isLoading;
        }

        private void chkFilterFromDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Enabled = chkFilterFromDate.Checked;
        }

        private void chkFilterToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToDate.Enabled = chkFilterToDate.Checked;
        }

        private async void btnApplyDateFilter_Click(object sender, EventArgs e)
        {
            await LoadTransactionHistoryAsync();
        }

        private async void btnClearDateFilter_Click(object sender, EventArgs e)
        {
            chkFilterFromDate.Checked = false;
            chkFilterToDate.Checked = false;
            // dtpFromDate.Enabled and dtpToDate.Enabled will be updated by their respective CheckedChanged events
            await LoadTransactionHistoryAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
