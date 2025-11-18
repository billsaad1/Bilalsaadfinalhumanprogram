using System;
using System.Windows.Forms;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.Services;
using HumanitarianProjectManagement.UI;

namespace HumanitarianProjectManagement.Forms
{
    public partial class SupplierCreateEditForm : Form
    {
        private readonly SupplierService _supplierService;
        private Supplier _supplier;
        private bool _isEditMode;

        public SupplierCreateEditForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _supplierService = new SupplierService();
            _supplier = new Supplier();
            _isEditMode = false;
            this.Text = "إضافة مورد جديد";
        }

        public SupplierCreateEditForm(Supplier supplier)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _supplierService = new SupplierService();
            _supplier = supplier;
            _isEditMode = true;
            this.Text = "تعديل المورد";
            LoadSupplierData();
        }

        private void LoadSupplierData()
        {
            if (_supplier != null)
            {
                txtName.Text = _supplier.Name;
                txtContactPerson.Text = _supplier.ContactPerson;
                txtEmail.Text = _supplier.Email;
                txtPhone.Text = _supplier.Phone;
                txtAddress.Text = _supplier.Address;
                txtPaymentTerms.Text = _supplier.PaymentTerms;
                txtCategory.Text = _supplier.Category;
                cmbStatus.Text = _supplier.Status;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المورد.", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("يرجى إدخال بريد إلكتروني صحيح.", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _supplier.Name = txtName.Text.Trim();
                _supplier.ContactPerson = txtContactPerson.Text.Trim();
                _supplier.Email = txtEmail.Text.Trim();
                _supplier.Phone = txtPhone.Text.Trim();
                _supplier.Address = txtAddress.Text.Trim();
                _supplier.PaymentTerms = txtPaymentTerms.Text.Trim();
                _supplier.Category = txtCategory.Text.Trim();
                _supplier.Status = cmbStatus.Text;
                _supplier.UpdatedAt = DateTime.UtcNow;

                if (_isEditMode)
                {
                    await _supplierService.UpdateSupplierAsync(_supplier);
                    MessageBox.Show("تم تحديث المورد بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _supplier.CreatedAt = DateTime.UtcNow;
                    await _supplierService.AddSupplierAsync(_supplier);
                    MessageBox.Show("تم إضافة المورد بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SupplierCreateEditForm_Load(object sender, EventArgs e)
        {
            // Initialize status combo box
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "نشط", "غير نشط", "معلق" });
            
            if (!_isEditMode)
            {
                cmbStatus.SelectedIndex = 0; // Default to "نشط"
            }
        }
    }
}

