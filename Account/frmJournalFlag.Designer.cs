namespace CareGiver.Account
{
    partial class frmJournalFlag
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
            DevExpress.XtraSpellChecker.OptionsSpelling optionsSpelling1 = new DevExpress.XtraSpellChecker.OptionsSpelling();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalFlag));
            this.groupPanel3 = new DevExpress.XtraEditors.PanelControl();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveNotes = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveNotes = new DevExpress.XtraEditors.SimpleButton();
            this.grdList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTaskLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX1 = new DevExpress.XtraEditors.LabelControl();
            this.labelX17 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.spellChecker1 = new DevExpress.XtraSpellChecker.SpellChecker();
            this.sharedDictionaryStorage1 = new DevExpress.XtraSpellChecker.SharedDictionaryStorage();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel3)).BeginInit();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.Appearance.Options.UseBackColor = true;
            this.groupPanel3.Controls.Add(this.textBoxNotes);
            this.groupPanel3.Controls.Add(this.lblEndTime);
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.btnClose);
            this.groupPanel3.Controls.Add(this.btnSaveNotes);
            this.groupPanel3.Controls.Add(this.btnRemoveNotes);
            this.groupPanel3.Controls.Add(this.grdList);
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.labelX17);
            this.groupPanel3.Controls.Add(this.cmbTypes);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(530, 495);
            this.groupPanel3.TabIndex = 1;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(48, 34);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.spellChecker1.SetShowSpellCheckMenu(this.textBoxNotes, false);
            this.textBoxNotes.Size = new System.Drawing.Size(458, 225);
            this.spellChecker1.SetSpellCheckerOptions(this.textBoxNotes, optionsSpelling1);
            this.textBoxNotes.TabIndex = 298;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblEndTime.Location = new System.Drawing.Point(510, 34);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(5, 16);
            this.lblEndTime.TabIndex = 297;
            this.lblEndTime.Text = "*";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::CareGiver.Properties.Resources.cancel16;
            this.btnCancel.Location = new System.Drawing.Point(424, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ToolTip = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::CareGiver.Properties.Resources.Save___CAD;
            this.btnSave.Location = new System.Drawing.Point(336, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.ToolTip = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = global::CareGiver.Properties.Resources.Cancel___CAD;
            this.btnClose.Location = new System.Drawing.Point(423, 459);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.ToolTip = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveNotes
            // 
            this.btnSaveNotes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNotes.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNotes.Appearance.Options.UseFont = true;
            this.btnSaveNotes.Image = global::CareGiver.Properties.Resources.Add___CAD;
            this.btnSaveNotes.Location = new System.Drawing.Point(253, 265);
            this.btnSaveNotes.Name = "btnSaveNotes";
            this.btnSaveNotes.Size = new System.Drawing.Size(82, 25);
            this.btnSaveNotes.TabIndex = 2;
            this.btnSaveNotes.Text = "Add";
            this.btnSaveNotes.ToolTip = "Add";
            this.btnSaveNotes.Click += new System.EventHandler(this.btnSaveNotes_Click);
            // 
            // btnRemoveNotes
            // 
            this.btnRemoveNotes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemoveNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveNotes.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveNotes.Appearance.Options.UseFont = true;
            this.btnRemoveNotes.Image = global::CareGiver.Properties.Resources.Remove___CAD;
            this.btnRemoveNotes.Location = new System.Drawing.Point(339, 265);
            this.btnRemoveNotes.Name = "btnRemoveNotes";
            this.btnRemoveNotes.Size = new System.Drawing.Size(82, 25);
            this.btnRemoveNotes.TabIndex = 3;
            this.btnRemoveNotes.Text = "Remove";
            this.btnRemoveNotes.ToolTip = "Remove";
            this.btnRemoveNotes.Click += new System.EventHandler(this.btnRemoveNotes_Click);
            // 
            // grdList
            // 
            this.grdList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grdList.AllowUserToAddRows = false;
            this.grdList.AllowUserToDeleteRows = false;
            this.grdList.AllowUserToOrderColumns = true;
            this.grdList.AllowUserToResizeRows = false;
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdList.BackgroundColor = System.Drawing.Color.White;
            this.grdList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Notes,
            this.LogTypeID,
            this.ServiceTaskLogID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdList.EnableHeadersVisualStyles = false;
            this.grdList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdList.Location = new System.Drawing.Point(8, 296);
            this.grdList.MultiSelect = false;
            this.grdList.Name = "grdList";
            this.grdList.ReadOnly = true;
            this.grdList.RowHeadersVisible = false;
            this.grdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdList.Size = new System.Drawing.Size(498, 157);
            this.grdList.TabIndex = 5;
            this.grdList.TabStop = false;
            this.grdList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdList_CellMouseDoubleClick);
            // 
            // Type
            // 
            this.Type.HeaderText = "Flag";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 120;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // LogTypeID
            // 
            this.LogTypeID.HeaderText = "LogTypeID";
            this.LogTypeID.Name = "LogTypeID";
            this.LogTypeID.ReadOnly = true;
            this.LogTypeID.Visible = false;
            // 
            // ServiceTaskLogID
            // 
            this.ServiceTaskLogID.HeaderText = "ServiceTaskLogID";
            this.ServiceTaskLogID.Name = "ServiceTaskLogID";
            this.ServiceTaskLogID.ReadOnly = true;
            this.ServiceTaskLogID.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(8, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(37, 13);
            this.labelX1.TabIndex = 296;
            this.labelX1.Text = "Notes:";
            // 
            // labelX17
            // 
            this.labelX17.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(8, 10);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(28, 13);
            this.labelX17.TabIndex = 269;
            this.labelX17.Text = "Flag:";
            // 
            // cmbTypes
            // 
            this.cmbTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypes.DisplayMember = "Text";
            this.cmbTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.ItemHeight = 15;
            this.cmbTypes.Location = new System.Drawing.Point(48, 7);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(458, 21);
            this.cmbTypes.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "LogTypeID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ServiceTaskLogID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
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
            // spellChecker1
            // 
            this.spellChecker1.Culture = new System.Globalization.CultureInfo("en-US");
            this.spellChecker1.ParentContainer = null;
            // 
            // frmJournalFlag
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 495);
            this.Controls.Add(this.groupPanel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJournalFlag";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flag";
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel3)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl groupPanel3;
        private System.Windows.Forms.TextBox textBoxNotes;
        private DevExpress.XtraEditors.LabelControl lblEndTime;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNotes;
        private DevExpress.XtraEditors.SimpleButton btnRemoveNotes;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdList;
        private DevExpress.XtraEditors.LabelControl labelX1;
        private DevExpress.XtraEditors.LabelControl labelX17;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DevExpress.XtraSpellChecker.SpellChecker spellChecker1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevExpress.XtraSpellChecker.SharedDictionaryStorage sharedDictionaryStorage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTaskLogID;
    }
}