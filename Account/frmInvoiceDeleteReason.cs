using BusinessRule;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CareGiver.Account
{
    public partial class frmInvoiceDeleteReason : DevExpress.XtraEditors.XtraForm
    {
        private string _reason = string.Empty;
        public string Reason
        {
            get{
                return _reason;
            }
            set{
                _reason = value;
            }
        }

        public string FormText
        {
            
            set
            {
                this.Text = value;
            }
        }

        public frmInvoiceDeleteReason()
        {
            InitializeComponent(); 
        }

        public frmInvoiceDeleteReason(string formname)
        {
            InitializeComponent();

            this.Text = formname;
            commandCancel.Enabled = false;
            this.ControlBox = false;
        }

        private void commandCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;

            }
            catch(Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void commandSave_Click(object sender, EventArgs e)
        {
            try
            {
                highlighter1.SetHighlightColor(txtReason, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                errorProvider1.Clear();
                if(string.IsNullOrEmpty(txtReason.Text.Trim()))
                {
                    highlighter1.SetHighlightColor(txtReason, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    errorProvider1.SetError(labelX1,"Enter Reason");
                    txtReason.Focus();
                    return;
                }
               _reason= txtReason.Text;

               this.DialogResult = DialogResult.OK;                
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }
    }
}
