namespace HumanitarianProjectManagement.UI
{
    partial class SplashScreenForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer splashTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // lblLogo
            //
            this.lblLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(12, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(376, 50);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Your Organization";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSystemName
            //
            this.lblSystemName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.Location = new System.Drawing.Point(12, 100);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(376, 40);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Humanitarian Project Management";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblVersion
            //
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVersion.Location = new System.Drawing.Point(12, 200);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(376, 23);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version 1.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(50, 240);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            //
            // splashTimer
            //
            this.splashTimer.Interval = 3500; // 3.5 seconds
            this.splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            //
            // SplashScreenForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSystemName);
            this.Controls.Add(this.lblLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);
            this.ResumeLayout(false);
        }
    }
}
