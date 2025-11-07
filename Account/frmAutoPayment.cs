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
    public partial class frmAutoPayment : DevExpress.XtraEditors.XtraForm
    {
        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public DateTime InsertedAt { get; set; }

        private DateTime _TransactionDate;
        public DateTime Transactiondate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
        }
        public frmAutoPayment()
        {
            InitializeComponent(); 

            //this.BackColor = System.Drawing.Color.FromArgb(194, 217, 247);
            dtmTransation.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textNotes.Text.Trim()))
                {
                    errorProvider1.SetError(textNotes, "Notes required.");
                    textNotes.Focus();
                    return;
                }
                if (dtmTransation.Value < InsertedAt.Date)
                {
                    errorProvider1.SetError(dtmTransation, "Enter valid transaction date.");
                    dtmTransation.Focus();
                    return;
                }

                _notes = textNotes.Text;
                _TransactionDate = dtmTransation.Value;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
    }
}
