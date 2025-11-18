namespace HumanitarianProjectManagement
{
    partial class LogFrameTabUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlInputArea = new System.Windows.Forms.Panel();
            this.splitContainerContent = new System.Windows.Forms.SplitContainer();
            this.pnlDisplayContainer = new System.Windows.Forms.Panel();
            this.flpLogFrameDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLogFrameDisplayPlaceholder = new System.Windows.Forms.Label();
            this.flpOutcomesSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContent)).BeginInit();
            this.splitContainerContent.Panel1.SuspendLayout();
            this.splitContainerContent.Panel2.SuspendLayout();
            this.splitContainerContent.SuspendLayout();
            this.pnlDisplayContainer.SuspendLayout();
            this.flpLogFrameDisplay.SuspendLayout();
            this.flpOutcomesSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.splitContainerMain.SplitterWidth = 10;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = false;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.pnlInputArea);
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerMain.Panel1MinSize = 450;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerContent);
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.splitContainerMain.Panel2MinSize = 750;
            this.splitContainerMain.Size = new System.Drawing.Size(1600, 900);
            this.splitContainerMain.SplitterDistance = 480;
            this.splitContainerMain.TabIndex = 0;
            // 
            // pnlInputArea
            // 
            this.pnlInputArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputArea.Location = new System.Drawing.Point(0, 0);
            this.pnlInputArea.Name = "pnlInputArea";
            this.pnlInputArea.Size = new System.Drawing.Size(480, 900);
            this.pnlInputArea.TabIndex = 0;
            this.pnlInputArea.BackColor = System.Drawing.Color.White;
            this.pnlInputArea.Padding = new System.Windows.Forms.Padding(15);
            this.pnlInputArea.AutoScroll = true;
            // 
            // splitContainerContent
            // 
            this.splitContainerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerContent.Location = new System.Drawing.Point(0, 0);
            this.splitContainerContent.Name = "splitContainerContent";
            this.splitContainerContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.splitContainerContent.SplitterWidth = 10;
            this.splitContainerContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerContent.IsSplitterFixed = false;
            // 
            // splitContainerContent.Panel1
            // 
            this.splitContainerContent.Panel1.Controls.Add(this.pnlDisplayContainer);
            this.splitContainerContent.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerContent.Panel1MinSize = 600;
            // 
            // splitContainerContent.Panel2
            // 
            this.splitContainerContent.Panel2.Controls.Add(this.flpOutcomesSidebar);
            this.splitContainerContent.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.splitContainerContent.Panel2MinSize = 300;
            this.splitContainerContent.Size = new System.Drawing.Size(1110, 900);
            this.splitContainerContent.SplitterDistance = 780;
            this.splitContainerContent.TabIndex = 0;
            // 
            // pnlDisplayContainer
            // 
            this.pnlDisplayContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplayContainer.Name = "pnlDisplayContainer";
            this.pnlDisplayContainer.Size = new System.Drawing.Size(780, 900);
            this.pnlDisplayContainer.TabIndex = 0;
            this.pnlDisplayContainer.BackColor = System.Drawing.Color.White;
            this.pnlDisplayContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDisplayContainer.AutoScroll = true;
            this.pnlDisplayContainer.Controls.Add(this.flpLogFrameDisplay);
            // 
            // flpLogFrameDisplay
            // 
            this.flpLogFrameDisplay.AutoScroll = false;
            this.flpLogFrameDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpLogFrameDisplay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLogFrameDisplay.Location = new System.Drawing.Point(10, 10);
            this.flpLogFrameDisplay.Name = "flpLogFrameDisplay";
            this.flpLogFrameDisplay.Size = new System.Drawing.Size(760, 880);
            this.flpLogFrameDisplay.TabIndex = 0;
            this.flpLogFrameDisplay.WrapContents = false;
            this.flpLogFrameDisplay.BackColor = System.Drawing.Color.White;
            this.flpLogFrameDisplay.Padding = new System.Windows.Forms.Padding(15);
            this.flpLogFrameDisplay.AutoSize = true;
            this.flpLogFrameDisplay.Controls.Add(this.lblLogFrameDisplayPlaceholder);
            // 
            // lblLogFrameDisplayPlaceholder
            // 
            this.lblLogFrameDisplayPlaceholder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogFrameDisplayPlaceholder.AutoSize = true;
            this.lblLogFrameDisplayPlaceholder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogFrameDisplayPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblLogFrameDisplayPlaceholder.Location = new System.Drawing.Point(240, 420);
            this.lblLogFrameDisplayPlaceholder.Name = "lblLogFrameDisplayPlaceholder";
            this.lblLogFrameDisplayPlaceholder.Size = new System.Drawing.Size(300, 25);
            this.lblLogFrameDisplayPlaceholder.TabIndex = 1;
            this.lblLogFrameDisplayPlaceholder.Text = "📋 Enhanced LogFrame Display";
            this.lblLogFrameDisplayPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogFrameDisplayPlaceholder.Visible = true;
            // 
            // flpOutcomesSidebar
            // 
            this.flpOutcomesSidebar.AutoScroll = true;
            this.flpOutcomesSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOutcomesSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpOutcomesSidebar.Location = new System.Drawing.Point(0, 0);
            this.flpOutcomesSidebar.Name = "flpOutcomesSidebar";
            this.flpOutcomesSidebar.Size = new System.Drawing.Size(320, 900);
            this.flpOutcomesSidebar.TabIndex = 0;
            this.flpOutcomesSidebar.WrapContents = false;
            this.flpOutcomesSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.flpOutcomesSidebar.Padding = new System.Windows.Forms.Padding(15);
            this.flpOutcomesSidebar.Controls.Add(this.lblSidebarTitle);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(18, 18);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(180, 21);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "📊 Quick Navigation";
            this.lblSidebarTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            // 
            // LogFrameTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "LogFrameTabUserControl";
            this.Size = new System.Drawing.Size(1600, 900);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerContent.Panel1.ResumeLayout(false);
            this.splitContainerContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContent)).EndInit();
            this.splitContainerContent.ResumeLayout(false);
            this.pnlDisplayContainer.ResumeLayout(false);
            this.pnlDisplayContainer.PerformLayout();
            this.flpLogFrameDisplay.ResumeLayout(false);
            this.flpLogFrameDisplay.PerformLayout();
            this.flpOutcomesSidebar.ResumeLayout(false);
            this.flpOutcomesSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlInputArea;
        private System.Windows.Forms.SplitContainer splitContainerContent;
        private System.Windows.Forms.Panel pnlDisplayContainer;
        private System.Windows.Forms.FlowLayoutPanel flpLogFrameDisplay;
        private System.Windows.Forms.FlowLayoutPanel flpOutcomesSidebar;
        private System.Windows.Forms.Label lblLogFrameDisplayPlaceholder;
        private System.Windows.Forms.Label lblSidebarTitle;
    }
}
