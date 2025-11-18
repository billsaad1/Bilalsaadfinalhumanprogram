
namespace HumanitarianProjectManagement.Forms
{
    partial class PurchasingMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.lblTotalSuppliers = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblPendingRequisitions = new System.Windows.Forms.Label();
            this.lblActiveOrders = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnPurchaseRequisitions = new System.Windows.Forms.Button();
            this.btnPurchaseOrders = new System.Windows.Forms.Button();
            this.btnGoodsReceipts = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.grpStatistics.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(165, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إدارة المشتريات";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1080, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.grpStatistics);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 80);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDashboard.Size = new System.Drawing.Size(1200, 150);
            this.pnlDashboard.TabIndex = 1;
            // 
            // grpStatistics
            // 
            this.grpStatistics.Controls.Add(this.lblTotalSuppliers);
            this.grpStatistics.Controls.Add(this.lblTotalProducts);
            this.grpStatistics.Controls.Add(this.lblPendingRequisitions);
            this.grpStatistics.Controls.Add(this.lblActiveOrders);
            this.grpStatistics.Controls.Add(this.label1);
            this.grpStatistics.Controls.Add(this.label2);
            this.grpStatistics.Controls.Add(this.label3);
            this.grpStatistics.Controls.Add(this.label4);
            this.grpStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatistics.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpStatistics.Location = new System.Drawing.Point(20, 20);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpStatistics.Size = new System.Drawing.Size(1160, 110);
            this.grpStatistics.TabIndex = 0;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "إحصائيات سريعة";
            // 
            // lblTotalSuppliers
            // 
            this.lblTotalSuppliers.AutoSize = true;
            this.lblTotalSuppliers.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalSuppliers.Location = new System.Drawing.Point(950, 60);
            this.lblTotalSuppliers.Name = "lblTotalSuppliers";
            this.lblTotalSuppliers.Size = new System.Drawing.Size(25, 30);
            this.lblTotalSuppliers.TabIndex = 0;
            this.lblTotalSuppliers.Text = "0";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTotalProducts.Location = new System.Drawing.Point(700, 60);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(25, 30);
            this.lblTotalProducts.TabIndex = 1;
            this.lblTotalProducts.Text = "0";
            // 
            // lblPendingRequisitions
            // 
            this.lblPendingRequisitions.AutoSize = true;
            this.lblPendingRequisitions.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPendingRequisitions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblPendingRequisitions.Location = new System.Drawing.Point(450, 60);
            this.lblPendingRequisitions.Name = "lblPendingRequisitions";
            this.lblPendingRequisitions.Size = new System.Drawing.Size(25, 30);
            this.lblPendingRequisitions.TabIndex = 2;
            this.lblPendingRequisitions.Text = "0";
            // 
            // lblActiveOrders
            // 
            this.lblActiveOrders.AutoSize = true;
            this.lblActiveOrders.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblActiveOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblActiveOrders.Location = new System.Drawing.Point(200, 60);
            this.lblActiveOrders.Name = "lblActiveOrders";
            this.lblActiveOrders.Size = new System.Drawing.Size(25, 30);
            this.lblActiveOrders.TabIndex = 3;
            this.lblActiveOrders.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(900, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "إجمالي الموردين";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(650, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "إجمالي المنتجات";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(380, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "طلبات الشراء المعلقة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(130, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "أوامر الشراء النشطة";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSuppliers);
            this.pnlButtons.Controls.Add(this.btnProducts);
            this.pnlButtons.Controls.Add(this.btnPurchaseRequisitions);
            this.pnlButtons.Controls.Add(this.btnPurchaseOrders);
            this.pnlButtons.Controls.Add(this.btnGoodsReceipts);
            this.pnlButtons.Controls.Add(this.btnInvoices);
            this.pnlButtons.Controls.Add(this.btnPayments);
            this.pnlButtons.Controls.Add(this.btnReports);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 230);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(20);
            this.pnlButtons.Size = new System.Drawing.Size(1200, 470);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSuppliers.FlatAppearance.BorderSize = 0;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.Location = new System.Drawing.Point(900, 40);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(250, 80);
            this.btnSuppliers.TabIndex = 0;
            this.btnSuppliers.Text = "إدارة الموردين";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(620, 40);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(250, 80);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "إدارة المنتجات";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnPurchaseRequisitions
            // 
            this.btnPurchaseRequisitions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnPurchaseRequisitions.FlatAppearance.BorderSize = 0;
            this.btnPurchaseRequisitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRequisitions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseRequisitions.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseRequisitions.Location = new System.Drawing.Point(340, 40);
            this.btnPurchaseRequisitions.Name = "btnPurchaseRequisitions";
            this.btnPurchaseRequisitions.Size = new System.Drawing.Size(250, 80);
            this.btnPurchaseRequisitions.TabIndex = 2;
            this.btnPurchaseRequisitions.Text = "طلبات الشراء";
            this.btnPurchaseRequisitions.UseVisualStyleBackColor = false;
            this.btnPurchaseRequisitions.Click += new System.EventHandler(this.btnPurchaseRequisitions_Click);
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPurchaseOrders.FlatAppearance.BorderSize = 0;
            this.btnPurchaseOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseOrders.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseOrders.Location = new System.Drawing.Point(60, 40);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(250, 80);
            this.btnPurchaseOrders.TabIndex = 3;
            this.btnPurchaseOrders.Text = "أوامر الشراء";
            this.btnPurchaseOrders.UseVisualStyleBackColor = false;
            this.btnPurchaseOrders.Click += new System.EventHandler(this.btnPurchaseOrders_Click);
            // 
            // btnGoodsReceipts
            // 
            this.btnGoodsReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnGoodsReceipts.FlatAppearance.BorderSize = 0;
            this.btnGoodsReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsReceipts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGoodsReceipts.ForeColor = System.Drawing.Color.White;
            this.btnGoodsReceipts.Location = new System.Drawing.Point(900, 150);
            this.btnGoodsReceipts.Name = "btnGoodsReceipts";
            this.btnGoodsReceipts.Size = new System.Drawing.Size(250, 80);
            this.btnGoodsReceipts.TabIndex = 4;
            this.btnGoodsReceipts.Text = "إيصالات الاستلام";
            this.btnGoodsReceipts.UseVisualStyleBackColor = false;
            this.btnGoodsReceipts.Click += new System.EventHandler(this.btnGoodsReceipts_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnInvoices.FlatAppearance.BorderSize = 0;
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInvoices.ForeColor = System.Drawing.Color.White;
            this.btnInvoices.Location = new System.Drawing.Point(620, 150);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(250, 80);
            this.btnInvoices.TabIndex = 5;
            this.btnInvoices.Text = "الفواتير";
            this.btnInvoices.UseVisualStyleBackColor = false;
            this.btnInvoices.Click += new System.EventHandler(this.btnInvoices_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(340, 150);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(250, 80);
            this.btnPayments.TabIndex = 6;
            this.btnPayments.Text = "المدفوعات";
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(60, 150);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(250, 80);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "التقارير";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // PurchasingMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PurchasingMainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة المشتريات";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.grpStatistics.ResumeLayout(false);
            this.grpStatistics.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.Label lblTotalSuppliers;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblPendingRequisitions;
        private System.Windows.Forms.Label lblActiveOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnPurchaseRequisitions;
        private System.Windows.Forms.Button btnPurchaseOrders;
        private System.Windows.Forms.Button btnGoodsReceipts;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnReports;
    }
}

