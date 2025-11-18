using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.Services;
using HumanitarianProjectManagement.UI;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Forms
{
    public partial class SupplierListForm : Form
    {
        private readonly SupplierService _supplierService;
        private List<Supplier> _suppliers;

        public SupplierListForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _supplierService = new SupplierService();
            this.Load += SupplierListForm_Load;
        }

        private async void SupplierListForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliersAsync();
        }

        private async Task LoadSuppliersAsync()
        {
            try
            {
                _suppliers = await _supplierService.GetAllSuppliersAsync();
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الموردين: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView()
        {
            dgvSuppliers.DataSource = null;
            dgvSuppliers.DataSource = _suppliers;
            
            // Configure columns
            if (dgvSuppliers.Columns.Count > 0)
            {
                dgvSuppliers.Columns["SupplierID"].HeaderText = "رقم المورد";
                dgvSuppliers.Columns["Name"].HeaderText = "اسم المورد";
                dgvSuppliers.Columns["ContactPerson"].HeaderText = "الشخص المسؤول";
                dgvSuppliers.Columns["Email"].HeaderText = "البريد الإلكتروني";
                dgvSuppliers.Columns["Phone"].HeaderText = "الهاتف";
                dgvSuppliers.Columns["Address"].HeaderText = "العنوان";
                dgvSuppliers.Columns["PaymentTerms"].HeaderText = "شروط الدفع";
                dgvSuppliers.Columns["Category"].HeaderText = "الفئة";
                dgvSuppliers.Columns["Status"].HeaderText = "الحالة";
                dgvSuppliers.Columns["CreatedAt"].HeaderText = "تاريخ الإنشاء";
                dgvSuppliers.Columns["UpdatedAt"].HeaderText = "تاريخ التحديث";

                // Hide unnecessary columns
                dgvSuppliers.Columns["SupplierID"].Visible = false;
                dgvSuppliers.Columns["CreatedAt"].Visible = false;
                dgvSuppliers.Columns["UpdatedAt"].Visible = false;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new SupplierCreateEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadSuppliersAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                var selectedSupplier = (Supplier)dgvSuppliers.SelectedRows[0].DataBoundItem;
                var editForm = new SupplierCreateEditForm(selectedSupplier);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadSuppliersAsync();
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار مورد للتعديل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                var selectedSupplier = (Supplier)dgvSuppliers.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"هل أنت متأكد من حذف المورد '{selectedSupplier.Name}'؟", 
                    "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await _supplierService.DeleteSupplierAsync(selectedSupplier.SupplierID);
                        await LoadSuppliersAsync();
                        MessageBox.Show("تم حذف المورد بنجاح.", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ في حذف المورد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار مورد للحذف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                _suppliers = await _supplierService.SearchSuppliersAsync(searchTerm);
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في البحث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadSuppliersAsync();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}

