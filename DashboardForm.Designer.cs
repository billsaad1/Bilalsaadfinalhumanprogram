namespace HumanitarianProjectManagement.Forms
{
    partial class DashboardForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlDashboardCards = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuickStats = new System.Windows.Forms.Panel();
            this.lblQuickStatsTitle = new System.Windows.Forms.Label();
            this.pnlStatsCards = new System.Windows.Forms.Panel();
            this.pnlProjectsCard = new System.Windows.Forms.Panel();
            this.lblProjectsCount = new System.Windows.Forms.Label();
            this.lblProjectsLabel = new System.Windows.Forms.Label();
            this.pnlBeneficiariesCard = new System.Windows.Forms.Panel();
            this.lblBeneficiariesCount = new System.Windows.Forms.Label();
            this.lblBeneficiariesLabel = new System.Windows.Forms.Label();
            this.pnlBudgetCard = new System.Windows.Forms.Panel();
            this.lblBudgetAmount = new System.Windows.Forms.Label();
            this.lblBudgetLabel = new System.Windows.Forms.Label();
            this.pnlWelcomeSection = new System.Windows.Forms.Panel();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.pnlQuickActions = new System.Windows.Forms.Panel();
            this.lblQuickActionsTitle = new System.Windows.Forms.Label();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.btnManageBeneficiaries = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnToggleSidebar = new System.Windows.Forms.Button();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.pnlSectionsGroup = new System.Windows.Forms.Panel();
            this.lblSectionsTitle = new System.Windows.Forms.Label();
            this.tvwSections = new System.Windows.Forms.TreeView();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.pnlModulesGroup = new System.Windows.Forms.Panel();
            this.lblModulesTitle = new System.Windows.Forms.Label();
            this.flpModuleButtons = new System.Windows.Forms.FlowLayoutPanel();

            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlDashboardCards.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlQuickStats.SuspendLayout();
            this.pnlStatsCards.SuspendLayout();
            this.pnlProjectsCard.SuspendLayout();
            this.pnlBeneficiariesCard.SuspendLayout();
            this.pnlBudgetCard.SuspendLayout();
            this.pnlWelcomeSection.SuspendLayout();
            this.pnlQuickActions.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarHeader.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlSectionsGroup.SuspendLayout();
            this.pnlModulesGroup.SuspendLayout();
            this.SuspendLayout();

            // All other control initializations are the same...

            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlQuickStats, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlQuickActions, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 120);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 456);
            this.tableLayoutPanel1.TabIndex = 3;

            //
            // pnlDashboardCards
            //
            this.pnlDashboardCards.AutoScroll = true;
            this.pnlDashboardCards.Controls.Add(this.tableLayoutPanel1);
            this.pnlDashboardCards.Controls.Add(this.pnlWelcomeSection);
            this.pnlDashboardCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardCards.Location = new System.Drawing.Point(30, 30);
            this.pnlDashboardCards.Name = "pnlDashboardCards";
            this.pnlDashboardCards.Size = new System.Drawing.Size(860, 576);
            this.pnlDashboardCards.TabIndex = 0;

            // ... The rest of the designer file is the same

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // All other control declarations are the same...
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
