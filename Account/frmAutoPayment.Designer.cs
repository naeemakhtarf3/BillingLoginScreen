namespace CareGiver.Account
{
    partial class frmAutoPayment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoPayment));
            this.groupPanel1 = new DevExpress.XtraEditors.PanelControl();
            this.labelX12 = new DevExpress.XtraEditors.LabelControl();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.textNotes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtmTransation = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.spellChecker1 = new DevExpress.XtraSpellChecker.SpellChecker(this.components);
            this.sharedDictionaryStorage1 = new DevExpress.XtraSpellChecker.SharedDictionaryStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmTransation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Appearance.Options.UseBackColor = true;
            this.groupPanel1.Controls.Add(this.labelX12);
            this.groupPanel1.Controls.Add(this.labelUser);
            this.groupPanel1.Controls.Add(this.textNotes);
            this.groupPanel1.Controls.Add(this.dtmTransation);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Location = new System.Drawing.Point(1, 4);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(342, 146);
            this.groupPanel1.TabIndex = 217;
            // 
            // labelX12
            // 
            this.labelX12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelX12.Location = new System.Drawing.Point(328, 35);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(5, 16);
            this.labelX12.TabIndex = 297;
            this.labelX12.Text = "*";
            // 
            // labelUser
            // 
            this.labelUser.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(6, 8);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(102, 13);
            this.labelUser.TabIndex = 274;
            this.labelUser.Text = "Transaction Date:";
            // 
            // textNotes
            // 
            this.textNotes.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.textNotes.Border.Class = "TextBoxBorder";
            this.textNotes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textNotes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.textNotes.Location = new System.Drawing.Point(110, 33);
            this.textNotes.MaxLength = 5000;
            this.textNotes.Multiline = true;
            this.textNotes.Name = "textNotes";
            this.textNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textNotes.Size = new System.Drawing.Size(216, 98);
            this.textNotes.TabIndex = 3;
            // 
            // dtmTransation
            // 
            this.dtmTransation.AutoAdvance = true;
            // 
            // 
            // 
            this.dtmTransation.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtmTransation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtmTransation.ButtonDropDown.Visible = true;
            this.dtmTransation.CustomFormat = "dd/MM/yyyy";
            this.dtmTransation.FieldNavigation = DevComponents.Editors.eInputFieldNavigation.Tab;
            this.dtmTransation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmTransation.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtmTransation.IsPopupCalendarOpen = false;
            this.dtmTransation.Location = new System.Drawing.Point(110, 7);
            // 
            // 
            // 
            this.dtmTransation.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtmTransation.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtmTransation.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtmTransation.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.dtmTransation.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtmTransation.MonthCalendar.DisplayMonth = new System.DateTime(2008, 12, 1, 0, 0, 0, 0);
            this.dtmTransation.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtmTransation.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtmTransation.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtmTransation.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtmTransation.Name = "dtmTransation";
            this.dtmTransation.Size = new System.Drawing.Size(216, 21);
            this.dtmTransation.TabIndex = 1;
            this.dtmTransation.Value = new System.DateTime(2008, 8, 28, 16, 53, 36, 786);
            // 
            // labelX1
            // 
            this.labelX1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(6, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(37, 13);
            this.labelX1.TabIndex = 296;
            this.labelX1.Text = "Notes:";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::CareGiver.Properties.Resources.Save_16X16;
            this.btnSave.Location = new System.Drawing.Point(178, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 25);
            this.btnSave.TabIndex = 218;
            this.btnSave.Text = "Save";
            this.btnSave.ToolTip = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = global::CareGiver.Properties.Resources.Cancel___CAD;
            this.btnClose.Location = new System.Drawing.Point(261, 155);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 219;
            this.btnClose.Text = "Close";
            this.btnClose.ToolTip = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // frmAutoPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 181);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoPayment";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Payment";
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmTransation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl groupPanel1;
        private DevExpress.XtraEditors.LabelControl labelUser;
        public DevComponents.DotNetBar.Controls.TextBoxX textNotes;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dtmTransation;
        private DevExpress.XtraEditors.LabelControl labelX1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelX12;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevExpress.XtraSpellChecker.SpellChecker spellChecker1;
        private DevExpress.XtraSpellChecker.SharedDictionaryStorage sharedDictionaryStorage1;
    }
}