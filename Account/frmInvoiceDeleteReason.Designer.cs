namespace CareGiver.Account
{
    partial class frmInvoiceDeleteReason
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceDeleteReason));
            this.groupPanel1 = new DevExpress.XtraEditors.PanelControl();
            this.labelX1 = new DevExpress.XtraEditors.LabelControl();
            this.lblReason = new DevExpress.XtraEditors.LabelControl();
            this.txtReason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.commandCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Mandatory = new DevExpress.XtraEditors.LabelControl();
            this.commandSave = new DevExpress.XtraEditors.SimpleButton();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.lblReason);
            this.groupPanel1.Controls.Add(this.txtReason);
            this.groupPanel1.Controls.Add(this.commandCancel);
            this.groupPanel1.Controls.Add(this.Mandatory);
            this.groupPanel1.Controls.Add(this.commandSave);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(394, 162);
            this.groupPanel1.TabIndex = 283;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelX1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(363, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(6, 16);
            this.labelX1.TabIndex = 283;
            this.labelX1.Text = "*";
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReason.Location = new System.Drawing.Point(11, 11);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(40, 13);
            this.lblReason.TabIndex = 1;
            this.lblReason.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtReason.Border.Class = "TextBoxBorder";
            this.txtReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReason.Location = new System.Drawing.Point(58, 11);
            this.txtReason.MaxLength = 5000;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(298, 101);
            this.txtReason.TabIndex = 1;
            // 
            // commandCancel
            // 
            this.commandCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.commandCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commandCancel.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.commandCancel.Appearance.Options.UseFont = true;
            this.commandCancel.Image = global::CareGiver.Properties.Resources.Cancel___CAD1;
            this.commandCancel.Location = new System.Drawing.Point(274, 120);
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Size = new System.Drawing.Size(82, 25);
            this.commandCancel.TabIndex = 3;
            this.commandCancel.Text = "Cancel";
            this.commandCancel.ToolTip = "Cancel";
            this.commandCancel.Click += new System.EventHandler(this.commandCancel_Click);
            // 
            // Mandatory
            // 
            this.Mandatory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mandatory.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Mandatory.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Mandatory.Appearance.ForeColor = System.Drawing.Color.Red;
            this.Mandatory.Location = new System.Drawing.Point(395, 2);
            this.Mandatory.Name = "Mandatory";
            this.Mandatory.Size = new System.Drawing.Size(5, 16);
            this.Mandatory.TabIndex = 276;
            this.Mandatory.Text = "*";
            // 
            // commandSave
            // 
            this.commandSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.commandSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commandSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.commandSave.Appearance.Options.UseFont = true;
            this.commandSave.Image = global::CareGiver.Properties.Resources.OK_16X16;
            this.commandSave.Location = new System.Drawing.Point(189, 120);
            this.commandSave.Name = "commandSave";
            this.commandSave.Size = new System.Drawing.Size(82, 25);
            this.commandSave.TabIndex = 2;
            this.commandSave.Text = "OK";
            this.commandSave.ToolTip = "OK";
            this.commandSave.Click += new System.EventHandler(this.commandSave_Click);
            // 
            // superValidator1
            // 
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            this.superValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // frmInvoiceDeleteReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 162);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoiceDeleteReason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Delete Reason";
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblReason;
        private DevExpress.XtraEditors.LabelControl Mandatory;
        private DevExpress.XtraEditors.SimpleButton commandSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReason;
        private DevExpress.XtraEditors.PanelControl groupPanel1;
        private DevExpress.XtraEditors.LabelControl labelX1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private DevExpress.XtraEditors.SimpleButton commandCancel;
    }
}