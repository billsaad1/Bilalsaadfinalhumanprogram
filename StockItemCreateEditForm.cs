using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    public partial class StockItemCreateEditForm : Form
    {
        private readonly StockService _stockService;
        private StockItem _currentItem;
        private readonly bool _isEditMode;

        public StockItemCreateEditForm(StockItem itemToEdit = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _stockService = new StockService();

            _isEditMode = (itemToEdit != null);

            if (_isEditMode)
            {
                _currentItem = itemToEdit;
                this.Text = $"Edit Stock Item - {_currentItem.ItemName}";

                numCurrentQuantity.Enabled = false;
                numCurrentQuantity.Visible = false; // Hide NumericUpDown for edits
                lblCurrentQuantity.Visible = false; // Hide label for NumericUpDown

                txtCurrentQuantityDisplay.Visible = true;
                lblCurrentQuantityDisplay.Visible = true; // Show label for TextBox
                txtCurrentQuantityDisplay.Text = _currentItem.CurrentQuantity.ToString();

                lblLastStockUpdateDisplay.Text = $"Last Update: {_currentItem.LastStockUpdate:yyyy-MM-dd HH:mm}";
                lblLastStockUpdateDisplay.Visible = true;

                PopulateControls();
            }
            else
            {
                _currentItem = new StockItem
                {
                    // CurrentQuantity will be taken from numCurrentQuantity for new items
                    MinStockLevel = 0 // Default for new items
                };
                this.Text = "Add New Stock Item";

                numCurrentQuantity.Enabled = true;
                numCurrentQuantity.Visible = true; // Show NumericUpDown for new items
                lblCurrentQuantity.Visible = true; // Show label for NumericUpDown

                txtCurrentQuantityDisplay.Visible = false;
                lblCurrentQuantityDisplay.Visible = false; // Hide label for TextBox

                lblLastStockUpdateDisplay.Visible = false;
                chkSpecifyMaxStockLevel.Checked = false;
                numMaxStockLevel.Enabled = false;
            }

            this.chkSpecifyMaxStockLevel.CheckedChanged += new System.EventHandler(this.chkSpecifyMaxStockLevel_CheckedChanged);
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            txtItemName.AccessibleName = "Item Name";
            txtItemName.AccessibleDescription = "Enter the name of the stock item. This field is required.";
            txtDescription.AccessibleName = "Description";
            txtDescription.AccessibleDescription = "Enter a detailed description for the stock item.";
            txtUnitOfMeasure.AccessibleName = "Unit of Measure";
            txtUnitOfMeasure.AccessibleDescription = "Enter the unit of measure for this item (e.g., kg, pcs, box).";
            numCurrentQuantity.AccessibleName = "Current Quantity";
            numCurrentQuantity.AccessibleDescription = "Enter the initial quantity for a new stock item.";
            txtCurrentQuantityDisplay.AccessibleName = "Current Quantity (Display)";
            txtCurrentQuantityDisplay.AccessibleDescription = "Displays the current quantity of an existing stock item.";
            numMinStockLevel.AccessibleName = "Minimum Stock Level";
            numMinStockLevel.AccessibleDescription = "Enter the minimum desired stock level for this item.";
            numMaxStockLevel.AccessibleName = "Maximum Stock Level";
            numMaxStockLevel.AccessibleDescription = "Enter the maximum desired stock level for this item.";
            chkSpecifyMaxStockLevel.AccessibleName = "Specify Maximum Stock Level";
            chkSpecifyMaxStockLevel.AccessibleDescription = "Check this box to set a maximum stock level.";
            txtNotes.AccessibleName = "Notes";
            txtNotes.AccessibleDescription = "Enter any additional notes for this stock item.";
            lblLastStockUpdateDisplay.AccessibleName = "Last Stock Update Date";
            btnSave.AccessibleName = "Save Stock Item";
            btnCancel.AccessibleName = "Cancel Editing";
        }

        private void PopulateControls()
        {
            if (_currentItem == null) return;

            txtItemName.Text = _currentItem.ItemName;
            txtDescription.Text = _currentItem.Description;
            txtUnitOfMeasure.Text = _currentItem.UnitOfMeasure;
            // CurrentQuantity is handled in constructor (display vs input)
            numMinStockLevel.Value = _currentItem.MinStockLevel;

            if (_currentItem.MaxStockLevel.HasValue)
            {
                numMaxStockLevel.Value = _currentItem.MaxStockLevel.Value;
                numMaxStockLevel.Enabled = true;
                chkSpecifyMaxStockLevel.Checked = true;
            }
            else
            {
                numMaxStockLevel.Value = 0; // Or some other default if needed when not specified
                numMaxStockLevel.Enabled = false;
                chkSpecifyMaxStockLevel.Checked = false;
            }
            txtNotes.Text = _currentItem.Notes;
        }

        private bool CollectAndValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemName.Focus();
                return false;
            }

            _currentItem.ItemName = txtItemName.Text.Trim();
            _currentItem.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            _currentItem.UnitOfMeasure = string.IsNullOrWhiteSpace(txtUnitOfMeasure.Text) ? null : txtUnitOfMeasure.Text.Trim();

            if (!_isEditMode) // Only set CurrentQuantity from NumericUpDown if it's a new item
            {
                _currentItem.CurrentQuantity = (int)numCurrentQuantity.Value;
            }
            // For edits, CurrentQuantity is typically updated via transactions, not directly here.

            _currentItem.MinStockLevel = (int)numMinStockLevel.Value;
            _currentItem.MaxStockLevel = chkSpecifyMaxStockLevel.Checked ? (int?)numMaxStockLevel.Value : null;

            if (_currentItem.MaxStockLevel.HasValue && _currentItem.MinStockLevel > _currentItem.MaxStockLevel.Value)
            {
                MessageBox.Show("Minimum stock level cannot be greater than the maximum stock level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numMinStockLevel.Focus();
                return false;
            }

            _currentItem.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
            // LastStockUpdate is set by the service or DB trigger for existing items, or by service for new ones.

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
                bool success = await _stockService.SaveStockItemAsync(_currentItem);
                if (success)
                {
                    MessageBox.Show("Stock item saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save stock item. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the stock item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnSave.Enabled = true;
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

        private void chkSpecifyMaxStockLevel_CheckedChanged(object sender, EventArgs e)
        {
            numMaxStockLevel.Enabled = chkSpecifyMaxStockLevel.Checked;
            if (!chkSpecifyMaxStockLevel.Checked)
            {
                // Optional: Clear value when unchecked, or let it be as is
                // numMaxStockLevel.Value = 0; 
            }
        }
    }
}
