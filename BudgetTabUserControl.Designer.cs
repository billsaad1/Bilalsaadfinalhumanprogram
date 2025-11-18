namespace HumanitarianProjectManagement
{
    partial class BudgetTabUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scMainBudgetLayout = new System.Windows.Forms.SplitContainer();
            this.pnlCategorySidebar = new System.Windows.Forms.Panel();
            this.tlpCategoryButtons = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBudgetMainArea = new System.Windows.Forms.Panel();
            this.pnlMainBudgetContentArea = new System.Windows.Forms.FlowLayoutPanel(); // Changed to FlowLayoutPanel

            ((System.ComponentModel.ISupportInitialize)(this.scMainBudgetLayout)).BeginInit();
            this.scMainBudgetLayout.Panel1.SuspendLayout();
            this.scMainBudgetLayout.Panel2.SuspendLayout();
            this.scMainBudgetLayout.SuspendLayout();
            this.pnlCategorySidebar.SuspendLayout();
            this.pnlBudgetMainArea.SuspendLayout();
            this.SuspendLayout();

            // 
            // scMainBudgetLayout
            // 
            this.scMainBudgetLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainBudgetLayout.Name = "scMainBudgetLayout";
            this.scMainBudgetLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMainBudgetLayout.IsSplitterFixed = true;
            this.scMainBudgetLayout.SplitterDistance = 230; // Adjusted distance
                                                            // Removed the invalid 'MinSize' property usage
            this.scMainBudgetLayout.SplitterDistance = 230; // Adjusted distance

            this.scMainBudgetLayout.TabIndex = 1;
            // 
            // scMainBudgetLayout.Panel1 (Category Sidebar)
            // 
            this.scMainBudgetLayout.Panel1.Controls.Add(this.pnlCategorySidebar);
            this.scMainBudgetLayout.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // scMainBudgetLayout.Panel2 (Main Content Area)
            // 
            this.scMainBudgetLayout.Panel2.Controls.Add(this.pnlBudgetMainArea);
            this.scMainBudgetLayout.Panel2.Padding = new System.Windows.Forms.Padding(3);
            // 
            // pnlCategorySidebar
            // 
            this.pnlCategorySidebar.Controls.Add(this.tlpCategoryButtons);
            this.pnlCategorySidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategorySidebar.Name = "pnlCategorySidebar";
            this.pnlCategorySidebar.BackColor = System.Drawing.Color.FromArgb(248, 249, 250); // Enhanced color
            this.pnlCategorySidebar.TabIndex = 0;
            // 
            // tlpCategoryButtons
            // 
            this.tlpCategoryButtons.ColumnCount = 1;
            this.tlpCategoryButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCategoryButtons.Name = "tlpCategoryButtons";
            this.tlpCategoryButtons.AutoScroll = true;
            this.tlpCategoryButtons.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tlpCategoryButtons.TabIndex = 0;

            // 
            // pnlBudgetMainArea
            // 
            this.pnlBudgetMainArea.Controls.Add(this.pnlMainBudgetContentArea);
            this.pnlBudgetMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBudgetMainArea.Location = new System.Drawing.Point(0, 0);
            this.pnlBudgetMainArea.Name = "pnlBudgetMainArea";
            this.pnlBudgetMainArea.TabIndex = 10;
            this.pnlBudgetMainArea.Padding = new System.Windows.Forms.Padding(0);
            this.pnlBudgetMainArea.BackColor = System.Drawing.Color.White; // Enhanced color

            // 
            // pnlMainBudgetContentArea 
            // 
            this.pnlMainBudgetContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBudgetContentArea.Location = new System.Drawing.Point(0, 0);
            this.pnlMainBudgetContentArea.Name = "pnlMainBudgetContentArea";
            this.pnlMainBudgetContentArea.AutoScroll = true;
            this.pnlMainBudgetContentArea.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlMainBudgetContentArea.WrapContents = false;
            this.pnlMainBudgetContentArea.TabIndex = 0;
            this.pnlMainBudgetContentArea.Padding = new System.Windows.Forms.Padding(10); // Added padding

            // 
            // BudgetTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMainBudgetLayout);
            this.Name = "BudgetTabUserControl";
            this.Size = new System.Drawing.Size(1350, 1100);

            this.scMainBudgetLayout.Panel1.ResumeLayout(false);
            this.scMainBudgetLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainBudgetLayout)).EndInit();
            this.scMainBudgetLayout.ResumeLayout(false);

            this.pnlCategorySidebar.ResumeLayout(false);
            this.pnlBudgetMainArea.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer scMainBudgetLayout;
        private System.Windows.Forms.Panel pnlCategorySidebar;
        private System.Windows.Forms.TableLayoutPanel tlpCategoryButtons;
        private System.Windows.Forms.Panel pnlBudgetMainArea;
        private System.Windows.Forms.FlowLayoutPanel pnlMainBudgetContentArea;

        private System.Windows.Forms.SplitContainer splitVerticalContent;
    }
}
