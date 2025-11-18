using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class StockTransactionCreateForm : Form
    {
        private readonly StockService _stockService;
        private readonly int _stockItemId;
        private readonly string _stockItemName;
        private StockItem _selectedStockItem; // To store full details including CurrentQuantity

        public StockTransactionCreateForm(int stockItemId, string stockItemName)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            _stockService = new StockService();
            _stockItemId = stockItemId;
            _stockItemName = stockItemName;

            this.Text = $"Record Transaction for: {_stockItemName}";
            txtStockItemDisplay.Text = _stockItemName;
            txtStockItemDisplay.TabStop = false; // As it's read-only

            cmbTransactionType.SelectedIndex = 0; // Default to "IN"
            dtpTransactionDate.Value = DateTime.Now;

            SetAccessibilityProperties();
            _ = LoadStockItemDetailsAsync(); // Fire and forget with error handling within
        }

        private void SetAccessibilityProperties()
        {
            txtStockItemDisplay.AccessibleName = "Stock Item (Display Only)";
            txtStockItemDisplay.AccessibleDescription = "Displays the name of the stock item for this transaction.";
            cmbTransactionType.AccessibleName = "Transaction Type";
            cmbTransactionType.AccessibleDescription = "Select the type of stock transaction (IN, OUT, or ADJUSTMENT).";
            numQuantity.AccessibleName = "Quantity";
            numQuantity.AccessibleDescription = "Enter the quantity for this transaction. Must be greater than 0.";
            dtpTransactionDate.AccessibleName = "Transaction Date";
            dtpTransactionDate.AccessibleDescription = "Select the date of this transaction.";
            txtReason.AccessibleName = "Reason";
            txtReason.AccessibleDescription = "Enter the reason for this transaction (e.g., initial stock, distribution, damage).";
            txtDistributedTo.AccessibleName = "Distributed To / Source";
            txtDistributedTo.AccessibleDescription = "Enter the recipient if type is OUT, or the source if type is IN.";
            txtNotes.AccessibleName = "Notes";
            txtNotes.AccessibleDescription = "Enter any additional notes for this transaction.";
            btnSaveTransaction.AccessibleName = "Save Transaction";
            btnSaveTransaction.AccessibleDescription = "Saves the current stock transaction details.";
            btnCancel.AccessibleName = "Cancel Transaction";
            btnCancel.AccessibleDescription = "Discards changes and closes this form.";
        }

        private async Task LoadStockItemDetailsAsync()
        {
            try
            {
                _selectedStockItem = await _stockService.GetStockItemByIdAsync(_stockItemId);
                if (_selectedStockItem == null)
                {
                    MessageBox.Show("Could not load stock item details. Saving will be disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSaveTransaction.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock item details: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSaveTransaction.Enabled = false;
            }
        }


        private bool CollectAndValidateData(StockTransaction transaction)
        {
            if (cmbTransactionType.SelectedItem == null)
            {
                MessageBox.Show("Please select a Transaction Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTransactionType.Focus();
                return false;
            }

            transaction.TransactionType = cmbTransactionType.SelectedItem.ToString();
            transaction.Quantity = (int)numQuantity.Value;

            if (transaction.Quantity <= 0) // Already handled by NumericUpDown Min, but good for robustness
            {
                MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numQuantity.Focus();
                return false;
            }

            if (transaction.TransactionType.ToUpper() == "OUT")
            {
                if (_selectedStockItem == null)
                {
                    MessageBox.Show("Stock item details not loaded. Cannot validate 'OUT' transaction.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (transaction.Quantity > _selectedStockItem.CurrentQuantity)
                {
                    MessageBox.Show($"Cannot transact 'OUT' quantity ({transaction.Quantity}) greater than current stock ({_selectedStockItem.CurrentQuantity}).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numQuantity.Focus();
                    return false;
                }
            }

            transaction.StockItemID = _stockItemId;
            transaction.TransactionDate = dtpTransactionDate.Value;
            transaction.Reason = string.IsNullOrWhiteSpace(txtReason.Text) ? null : txtReason.Text.Trim();
            transaction.DistributedTo = string.IsNullOrWhiteSpace(txtDistributedTo.Text) ? null : txtDistributedTo.Text.Trim();
            transaction.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
            transaction.RecordedByUserID = ApplicationState.CurrentUser?.UserID; // Using ApplicationState

            return true;
        }

        private async void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            StockTransaction newTransaction = new StockTransaction();
            if (!CollectAndValidateData(newTransaction))
            {
                return;
            }

            btnSaveTransaction.Enabled = false;
            btnCancel.Enabled = false;
            this.UseWaitCursor = true;

            try
            {
                bool success = await _stockService.AddStockTransactionAsync(newTransaction);
                if (success)
                {
                    MessageBox.Show("Stock transaction recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to record stock transaction. Check logs for details. The stock quantity might be insufficient if this was an 'OUT' transaction and the item details were not up-to-date.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnSaveTransaction.Enabled = true;
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
    }
}
