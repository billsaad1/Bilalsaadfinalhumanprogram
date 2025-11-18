namespace HumanitarianProjectManagement.Forms
{
    partial class BeneficiaryListCreateEditForm
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
            this.lblProjectNameDisplay = new System.Windows.Forms.Label();
            this.txtProjectNameDisplay = new System.Windows.Forms.TextBox();
            this.lblListName = new System.Windows.Forms.Label();
            this.txtListName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProjectNameDisplay
            // 
            this.lblProjectNameDisplay.AutoSize = true;
            this.lblProjectNameDisplay.Location = new System.Drawing.Point(20, 23);
            this.lblProjectNameDisplay.Name = "lblProjectNameDisplay";
            this.lblProjectNameDisplay.Size = new System.Drawing.Size(43, 13);
            this.lblProjectNameDisplay.TabIndex = 0;
            this.lblProjectNameDisplay.Text = "Project:";
            // 
            // txtProjectNameDisplay
            // 
            this.txtProjectNameDisplay.Location = new System.Drawing.Point(100, 20);
            this.txtProjectNameDisplay.Name = "txtProjectNameDisplay";
            this.txtProjectNameDisplay.ReadOnly = true;
            this.txtProjectNameDisplay.Size = new System.Drawing.Size(280, 20);
            this.txtProjectNameDisplay.TabIndex = 1; // Will be set to TabStop=false in code
            // 
            // lblListName
            // 
            this.lblListName.AutoSize = true;
            this.lblListName.Location = new System.Drawing.Point(20, 53);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(57, 13);
            this.lblListName.TabIndex = 2;
            this.lblListName.Text = "List Name:";
            // 
            // txtListName
            // 
            this.txtListName.Location = new System.Drawing.Point(100, 50);
            this.txtListName.Name = "txtListName";
            this.txtListName.Size = new System.Drawing.Size(280, 20);
            this.txtListName.TabIndex = 0; // First actual input
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(280, 100);
            this.txtDescription.TabIndex = 1; // Second actual input
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 2; // Third actual input
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3; // Fourth actual input
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BeneficiaryListCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 241);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtListName);
            this.Controls.Add(this.lblListName);
            this.Controls.Add(this.txtProjectNameDisplay);
            this.Controls.Add(this.lblProjectNameDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeneficiaryListCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Beneficiary List Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectNameDisplay;
        private System.Windows.Forms.TextBox txtProjectNameDisplay;
        private System.Windows.Forms.Label lblListName;
        private System.Windows.Forms.TextBox txtListName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
