namespace CareGiver.Account
{
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.grdListJounal = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textAmountRecived = new System.Windows.Forms.TextBox();
            this.labelTotalPayment = new DevExpress.XtraEditors.LabelControl();
            this.labelTotalPayable = new DevExpress.XtraEditors.LabelControl();
            this.textNetAmount = new System.Windows.Forms.TextBox();
            this.buttonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.inputAmount = new DevComponents.Editors.DoubleInput();
            this.buttonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.dtmTransation = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevExpress.XtraEditors.LabelControl();
            this.labelX12 = new DevExpress.XtraEditors.LabelControl();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.labelX17 = new DevExpress.XtraEditors.LabelControl();
            this.textNotes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupPanel1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProviderMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListJounal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmTransation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).BeginInit();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.grdListJounal);
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Location = new System.Drawing.Point(-3, 167);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(460, 201);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.Color = System.Drawing.SystemColors.Control;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 214;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.expandablePanel1.TitleStyle.BackColor2.Color = System.Drawing.SystemColors.Control;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.Color = System.Drawing.Color.Transparent;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Payment Detail";
            // 
            // grdListJounal
            // 
            this.grdListJounal.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grdListJounal.AllowUserToAddRows = false;
            this.grdListJounal.AllowUserToDeleteRows = false;
            this.grdListJounal.AllowUserToOrderColumns = true;
            this.grdListJounal.AllowUserToResizeRows = false;
            this.grdListJounal.BackgroundColor = System.Drawing.Color.White;
            this.grdListJounal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdListJounal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdListJounal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdListJounal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colDetail,
            this.colDebit,
            this.colPaymentType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdListJounal.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdListJounal.EnableHeadersVisualStyles = false;
            this.grdListJounal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdListJounal.Location = new System.Drawing.Point(5, 26);
            this.grdListJounal.MultiSelect = false;
            this.grdListJounal.Name = "grdListJounal";
            this.grdListJounal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdListJounal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdListJounal.RowHeadersVisible = false;
            this.grdListJounal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdListJounal.Size = new System.Drawing.Size(452, 170);
            this.grdListJounal.TabIndex = 212;
            this.grdListJounal.TabStop = false;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Transaction Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "Notes";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            // 
            // colDebit
            // 
            this.colDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDebit.HeaderText = "Amount";
            this.colDebit.Name = "colDebit";
            this.colDebit.ReadOnly = true;
            // 
            // colPaymentType
            // 
            this.colPaymentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPaymentType.HeaderText = "PaymentType";
            this.colPaymentType.Name = "colPaymentType";
            this.colPaymentType.ReadOnly = true;
            this.colPaymentType.Visible = false;
            // 
            // textAmountRecived
            // 
            this.textAmountRecived.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textAmountRecived.Enabled = false;
            this.textAmountRecived.Font = new System.Drawing.Font("Verdana", 10F);
            this.textAmountRecived.Location = new System.Drawing.Point(241, 402);
            this.textAmountRecived.Name = "textAmountRecived";
            this.textAmountRecived.ReadOnly = true;
            this.textAmountRecived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAmountRecived.Size = new System.Drawing.Size(205, 24);
            this.textAmountRecived.TabIndex = 344;
            // 
            // labelTotalPayment
            // 
            this.labelTotalPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalPayment.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalPayment.Appearance.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPayment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelTotalPayment.Location = new System.Drawing.Point(133, 400);
            this.labelTotalPayment.Name = "labelTotalPayment";
            this.labelTotalPayment.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelTotalPayment.Size = new System.Drawing.Size(102, 19);
            this.labelTotalPayment.TabIndex = 343;
            this.labelTotalPayment.Text = "Total Payment:";
            // 
            // labelTotalPayable
            // 
            this.labelTotalPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalPayable.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalPayable.Appearance.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPayable.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelTotalPayable.Location = new System.Drawing.Point(133, 375);
            this.labelTotalPayable.Name = "labelTotalPayable";
            this.labelTotalPayable.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelTotalPayable.Size = new System.Drawing.Size(95, 19);
            this.labelTotalPayable.TabIndex = 342;
            this.labelTotalPayable.Text = "Total Amount:";
            // 
            // textNetAmount
            // 
            this.textNetAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textNetAmount.Enabled = false;
            this.textNetAmount.Font = new System.Drawing.Font("Verdana", 10F);
            this.textNetAmount.Location = new System.Drawing.Point(241, 374);
            this.textNetAmount.Name = "textNetAmount";
            this.textNetAmount.ReadOnly = true;
            this.textNetAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textNetAmount.Size = new System.Drawing.Size(205, 24);
            this.textNetAmount.TabIndex = 341;
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Appearance.Options.UseFont = true;
            this.buttonAdd.Image = global::CareGiver.Properties.Resources.Add___CAD;
            this.buttonAdd.Location = new System.Drawing.Point(282, 122);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(79, 25);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.ToolTip = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // inputAmount
            // 
            // 
            // 
            // 
            this.inputAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inputAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inputAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inputAmount.Increment = 1D;
            this.inputAmount.Location = new System.Drawing.Point(116, 31);
            this.inputAmount.MaxValue = 999999D;
            this.inputAmount.MinValue = 0D;
            this.inputAmount.Name = "inputAmount";
            this.inputAmount.ShowUpDown = true;
            this.inputAmount.Size = new System.Drawing.Size(330, 21);
            this.inputAmount.TabIndex = 297;
            // 
            // buttonRemove
            // 
            this.buttonRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Appearance.Options.UseFont = true;
            this.buttonRemove.Image = global::CareGiver.Properties.Resources.Remove___CAD;
            this.buttonRemove.Location = new System.Drawing.Point(365, 122);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(79, 25);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.ToolTip = "Remove";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
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
            this.dtmTransation.Location = new System.Drawing.Point(116, 7);
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
            this.dtmTransation.Size = new System.Drawing.Size(330, 21);
            this.dtmTransation.TabIndex = 1;
            this.dtmTransation.Value = new System.DateTime(2008, 8, 28, 16, 53, 36, 786);
            // 
            // labelX1
            // 
            this.labelX1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(37, 13);
            this.labelX1.TabIndex = 296;
            this.labelX1.Text = "Notes:";
            // 
            // labelX12
            // 
            this.labelX12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelX12.Location = new System.Drawing.Point(447, 35);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(5, 16);
            this.labelX12.TabIndex = 273;
            this.labelX12.Text = "*";
            // 
            // labelUser
            // 
            this.labelUser.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(12, 8);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(102, 13);
            this.labelUser.TabIndex = 274;
            this.labelUser.Text = "Transaction Date:";
            // 
            // labelX17
            // 
            this.labelX17.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(12, 31);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(49, 13);
            this.labelX17.TabIndex = 269;
            this.labelX17.Text = "Amount:";
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
            this.textNotes.Location = new System.Drawing.Point(116, 55);
            this.textNotes.MaxLength = 5000;
            this.textNotes.Multiline = true;
            this.textNotes.Name = "textNotes";
            this.textNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textNotes.Size = new System.Drawing.Size(330, 46);
            this.textNotes.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::CareGiver.Properties.Resources.Save_16X16;
            this.btnSave.Location = new System.Drawing.Point(294, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 25);
            this.btnSave.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(377, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.ToolTip = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Appearance.Options.UseBackColor = true;
            this.groupPanel1.Controls.Add(this.labelControl1);
            this.groupPanel1.Controls.Add(this.expandablePanel1);
            this.groupPanel1.Controls.Add(this.textAmountRecived);
            this.groupPanel1.Controls.Add(this.inputAmount);
            this.groupPanel1.Controls.Add(this.labelTotalPayment);
            this.groupPanel1.Controls.Add(this.buttonRemove);
            this.groupPanel1.Controls.Add(this.labelTotalPayable);
            this.groupPanel1.Controls.Add(this.labelUser);
            this.groupPanel1.Controls.Add(this.textNetAmount);
            this.groupPanel1.Controls.Add(this.textNotes);
            this.groupPanel1.Controls.Add(this.buttonAdd);
            this.groupPanel1.Controls.Add(this.labelX17);
            this.groupPanel1.Controls.Add(this.labelX12);
            this.groupPanel1.Controls.Add(this.dtmTransation);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Location = new System.Drawing.Point(0, 6);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(460, 438);
            this.groupPanel1.TabIndex = 216;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(447, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(5, 16);
            this.labelControl1.TabIndex = 345;
            this.labelControl1.Text = "*";
            // 
            // superValidator1
            // 
            this.superValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // errorProviderMain
            // 
            this.errorProviderMain.ContainerControl = this;
            this.errorProviderMain.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderMain.Icon")));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Transaction Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Detail";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount Debit";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount Credit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 478);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListJounal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmTransation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdListJounal;
        private DevExpress.XtraEditors.SimpleButton buttonAdd;
        private DevExpress.XtraEditors.LabelControl labelX1;
        private DevExpress.XtraEditors.LabelControl labelX12;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraEditors.LabelControl labelX17;
        public DevComponents.DotNetBar.Controls.TextBoxX textNotes;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dtmTransation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton buttonRemove;
        private DevComponents.Editors.DoubleInput inputAmount;
        private DevExpress.XtraEditors.LabelControl labelTotalPayable;
        private System.Windows.Forms.TextBox textNetAmount;
        private System.Windows.Forms.TextBox textAmountRecived;
        private DevExpress.XtraEditors.LabelControl labelTotalPayment;
        private DevExpress.XtraEditors.PanelControl groupPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentType;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProviderMain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}