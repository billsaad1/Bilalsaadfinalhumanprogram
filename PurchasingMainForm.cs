using System;
using System.Windows.Forms;
using HumanitarianProjectManagement.UI;
using HumanitarianProjectManagement.Forms;
using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumanitarianProjectManagement.DataAccessLayer;

namespace HumanitarianProjectManagement.Forms
{
    public partial class PurchasingMainForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly ProductService _productService;
        private readonly PurchaseRequisitionService _purchaseRequisitionService;
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchasingMainForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);

            // Initialize services
            _supplierService = new SupplierService(); // Replace with your actual service initialization
            _productService = new ProductService(); // Example initialization
            _purchaseRequisitionService = new PurchaseRequisitionService(); // Example initialization
            _purchaseOrderService = new PurchaseOrderService(); // Example initialization

            // Wire up event handlers
            this.Load += PurchasingMainForm_Load;
        }

        private async void PurchasingMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadDashboardDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDashboardDataAsync()
        {
            // Load dashboard statistics
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            var products = await _productService.GetAllProductsAsync();
            var requisitions = await _purchaseRequisitionService.GetAllPurchaseRequisitionsAsync();
            var orders = await _purchaseOrderService.GetAllPurchaseOrdersAsync();

            // Update dashboard labels
            lblTotalSuppliers.Text = suppliers.Count.ToString();
            lblTotalProducts.Text = products.Count.ToString();
            lblPendingRequisitions.Text = requisitions.FindAll(r => r.Status == "معلق").Count.ToString();
            lblActiveOrders.Text = orders.FindAll(o => o.Status == "نشط").Count.ToString();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            var supplierListForm = new SupplierListForm();
            supplierListForm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var productListForm = new ProductListForm();
            // productListForm.ShowDialog();
        }

        private void btnPurchaseRequisitions_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var requisitionListForm = new PurchaseRequisitionListForm();
            // requisitionListForm.ShowDialog();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            var orderListForm = new PurchaseOrderListForm();
            orderListForm.ShowDialog();
        }

        private void btnGoodsReceipts_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var goodsReceiptListForm = new GoodsReceiptListForm();
            // goodsReceiptListForm.ShowDialog();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var invoiceListForm = new InvoiceListForm();
            // invoiceListForm.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var paymentListForm = new PaymentListForm();
            // paymentListForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // This form does not exist in the original project
            // var reportsForm = new PurchasingReportsForm();
            // reportsForm.ShowDialog();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardDataAsync();
        }
    }
}
