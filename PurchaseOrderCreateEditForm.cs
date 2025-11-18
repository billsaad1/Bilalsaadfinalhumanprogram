using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using HumanitarianProjectManagement; // For AppContext

namespace HumanitarianProjectManagement.Forms
{
    public partial class PurchaseOrderCreateEditForm : Form
    {
        
        private readonly ProjectService _projectService;
        private readonly UserService _userService; // For ApprovedBy ComboBox
        private PurchaseOrder _currentPO;
        private readonly bool _isEditMode;
        private List<Project> _projects;
        private List<User> _users;

        public PurchaseOrderCreateEditForm(PurchaseOrder poToEdit = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

        
            _projectService = new ProjectService();
            _userService = new UserService();

            _isEditMode = (poToEdit != null);

            if (_isEditMode)
            {
                _currentPO = poToEdit;
                this.Text = $"Edit Purchase Order - PO ID: {_currentPO.PurchaseOrderID}";
                PopulateControls();
                dtpOrderDate.Enabled = false; // OrderDate cannot be changed for existing POs
                lblCreatedByDisplay.Visible = true;
                // CreatedBy info will be populated in PopulateControls or LoadComboBoxDataAsync
            }
            else
            {
                _currentPO = new PurchaseOrder
                {
                    OrderDate = DateTime.Today // Default for new PO
                };
                this.Text = "Create New Purchase Order";
                dtpOrderDate.Value = _currentPO.OrderDate;
                dtpOrderDate.Enabled = true;
                lblCreatedByDisplay.Visible = false;
                chkSpecifyExpectedDeliveryDate.Checked = false;
                dtpExpectedDeliveryDate.Enabled = false;
                chkSpecifyActualDeliveryDate.Checked = false;
                dtpActualDeliveryDate.Enabled = false;
            }

            _ = LoadComboBoxDataAsync();

            chkSpecifyExpectedDeliveryDate.CheckedChanged += chkSpecifyExpectedDeliveryDate_CheckedChanged;
            chkSpecifyActualDeliveryDate.CheckedChanged += chkSpecifyActualDeliveryDate_CheckedChanged;
            SetAccessibilityProperties();
        }

        private void SetAccessibilityProperties()
        {
            cmbProject.AccessibleName = "Project";
            cmbProject.AccessibleDescription = "Select the project associated with this purchase order. This field is required.";
            txtSupplierName.AccessibleName = "Supplier Name";
            txtSupplierName.AccessibleDescription = "Enter the name of the supplier. This field is required.";
            dtpOrderDate.AccessibleName = "Order Date";
            dtpOrderDate.AccessibleDescription = "Select the date the purchase order was created.";
            chkSpecifyExpectedDeliveryDate.AccessibleName = "Specify Expected Delivery Date";
            dtpExpectedDeliveryDate.AccessibleName = "Expected Delivery Date";
            chkSpecifyActualDeliveryDate.AccessibleName = "Specify Actual Delivery Date";
            dtpActualDeliveryDate.AccessibleName = "Actual Delivery Date";
            numTotalAmount.AccessibleName = "Total Amount";
            numTotalAmount.AccessibleDescription = "Enter the total monetary value of the purchase order. This field is required.";
            cmbStatus.AccessibleName = "Status";
            cmbStatus.AccessibleDescription = "Select the current status of the purchase order. This field is required.";
            txtShippingAddress.AccessibleName = "Shipping Address";
            txtBillingAddress.AccessibleName = "Billing Address";
            txtNotes.AccessibleName = "Notes";
            lblCreatedByDisplay.AccessibleName = "Creation Information";
            cmbApprovedBy.AccessibleName = "Approved By User";
            cmbApprovedBy.AccessibleDescription = "Select the user who approved this purchase order (optional).";
            btnSave.AccessibleName = "Save Purchase Order";
            btnCancel.AccessibleName = "Cancel Editing";
        }

        private async Task LoadComboBoxDataAsync()
        {
            try
            {
                // Load Projects
                _projects = await _projectService.GetAllProjectsAsync();
                cmbProject.DataSource = _projects;
                cmbProject.DisplayMember = "ProjectName";
                cmbProject.ValueMember = "ProjectID";
                if (_projects.Any()) cmbProject.SelectedIndex = 0; // Default selection


                // Load Statuses
                string[] statuses = { "Pending", "Approved", "Ordered", "Shipped", "Delivered", "Cancelled" };
                cmbStatus.Items.AddRange(statuses);
                cmbStatus.SelectedItem = "Pending"; // Default for new PO

                // Load Users for ApprovedBy
                _users = await _userService.GetAllUsersAsync(); // Assuming GetAllUsersAsync is implemented
                var approverList = new List<User> { new User { UserID = 0, FullName = "(None)" } }; // Allow no approver
                approverList.AddRange(_users);
                cmbApprovedBy.DataSource = approverList;
                cmbApprovedBy.DisplayMember = "FullName"; // Or Username
                cmbApprovedBy.ValueMember = "UserID";
                cmbApprovedBy.SelectedValue = 0;


                // If editing, set selected values
                if (_isEditMode && _currentPO != null)
                {
                    cmbProject.SelectedValue = _currentPO.ProjectID;
                    cmbStatus.SelectedItem = _currentPO.Status ?? "Pending";
                    if (_currentPO.ApprovedByUserID.HasValue)
                    {
                        cmbApprovedBy.SelectedValue = _currentPO.ApprovedByUserID.Value;
                    }
                    // Display CreatedBy info
                    User creator = _users.FirstOrDefault(u => u.UserID == _currentPO.CreatedByUserID);
                    lblCreatedByDisplay.Text = $"Created by: {creator?.FullName ?? "N/A"} on {_currentPO.OrderDate:yyyy-MM-dd}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo box data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateControls()
        {
            if (_currentPO == null) return;

            txtSupplierName.Text = _currentPO.SupplierName;
            dtpOrderDate.Value = _currentPO.OrderDate; // Already set, but good for consistency

            if (_currentPO.ExpectedDeliveryDate.HasValue)
            {
                chkSpecifyExpectedDeliveryDate.Checked = true;
                dtpExpectedDeliveryDate.Value = _currentPO.ExpectedDeliveryDate.Value;
                dtpExpectedDeliveryDate.Enabled = true;
            }
            else
            {
                chkSpecifyExpectedDeliveryDate.Checked = false;
                dtpExpectedDeliveryDate.Enabled = false;
            }

            if (_currentPO.ActualDeliveryDate.HasValue)
            {
                chkSpecifyActualDeliveryDate.Checked = true;
                dtpActualDeliveryDate.Value = _currentPO.ActualDeliveryDate.Value;
                dtpActualDeliveryDate.Enabled = true;
            }
            else
            {
                chkSpecifyActualDeliveryDate.Checked = false;
                dtpActualDeliveryDate.Enabled = false;
            }

            numTotalAmount.Value = _currentPO.TotalAmount;
            // Status and Project are set in LoadComboBoxDataAsync after datasources are set
            txtShippingAddress.Text = _currentPO.ShippingAddress;
            txtBillingAddress.Text = _currentPO.BillingAddress;
            txtNotes.Text = _currentPO.Notes;
            // ApprovedBy is set in LoadComboBoxDataAsync
        }

        private bool CollectAndValidateData()
        {
            if (cmbProject.SelectedValue == null || (int)cmbProject.SelectedValue == 0 && _projects.Any(p => p.ProjectID != 0)) // Check if a real project is selected
            {
                MessageBox.Show("Please select a Project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProject.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplierName.Focus();
                return false;
            }
            if (numTotalAmount.Value <= 0)
            {
                MessageBox.Show("Total Amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numTotalAmount.Focus();
                return false;
            }
            if (cmbStatus.SelectedItem == null || string.IsNullOrWhiteSpace(cmbStatus.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStatus.Focus();
                return false;
            }


            _currentPO.ProjectID = (int)cmbProject.SelectedValue;
            _currentPO.SupplierName = txtSupplierName.Text.Trim();
            _currentPO.OrderDate = dtpOrderDate.Value; // Only set for new, but no harm reading it

            _currentPO.ExpectedDeliveryDate = chkSpecifyExpectedDeliveryDate.Checked ? (DateTime?)dtpExpectedDeliveryDate.Value : null;
            _currentPO.ActualDeliveryDate = chkSpecifyActualDeliveryDate.Checked ? (DateTime?)dtpActualDeliveryDate.Value : null;

            _currentPO.TotalAmount = numTotalAmount.Value;
            _currentPO.Status = cmbStatus.SelectedItem.ToString();
            _currentPO.ShippingAddress = string.IsNullOrWhiteSpace(txtShippingAddress.Text) ? null : txtShippingAddress.Text.Trim();
            _currentPO.BillingAddress = string.IsNullOrWhiteSpace(txtBillingAddress.Text) ? null : txtBillingAddress.Text.Trim();
            _currentPO.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

            if (cmbApprovedBy.SelectedValue != null && (int)cmbApprovedBy.SelectedValue != 0)
            {
                _currentPO.ApprovedByUserID = (int)cmbApprovedBy.SelectedValue;
            }
            else
            {
                _currentPO.ApprovedByUserID = null;
            }

            if (!_isEditMode)
            {
                _currentPO.CreatedByUserID = ApplicationState.CurrentUser?.UserID; // Set on create
            }

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
                bool success = await _poService.SavePurchaseOrderAsync(_currentPO);
                if (success)
                {
                    MessageBox.Show("Purchase Order saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save Purchase Order. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void chkSpecifyExpectedDeliveryDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpectedDeliveryDate.Enabled = chkSpecifyExpectedDeliveryDate.Checked;
        }

        private void chkSpecifyActualDeliveryDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpActualDeliveryDate.Enabled = chkSpecifyActualDeliveryDate.Checked;
        }
    }
}
