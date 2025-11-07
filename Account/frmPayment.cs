using BusinessRule;
using DataModel;
using DevComponents.DotNetBar;
using DevExpress.XtraEditors;
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
    public partial class frmPayment : DevExpress.XtraEditors.XtraForm
    {
        int _billingTypeID;
        DateTime _GeneratedDate;
        ePaymentTypeID paymentTypeID;
        List<DataModel.JournalPayment> lstJournalPayment;
        int mainJournalID;
        public List<DataModel.JournalPayment> LstJournalPayment
        {
            get { return lstJournalPayment; }
            set { lstJournalPayment = value; }
        }
        public frmPayment(decimal netAmount,decimal totalPaid,int billingTypeID,EUserType userType,ePaymentTypeID journalType,int journalMainID, DateTime GeneratedDate )
        {
            InitializeComponent(); 

            if (BusinessRule.Utilities.IsDesignMode)
                return;

            _billingTypeID = billingTypeID;
            _GeneratedDate = GeneratedDate;
            textNetAmount.Text = netAmount.ToString();
            textAmountRecived.Text = totalPaid.ToString();
            //this.BackColor = System.Drawing.Color.FromArgb(194, 217, 247);
            dtmTransation.Value = DateTime.Now;
            mainJournalID = journalMainID;
            paymentTypeID = journalType;
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderMain.Clear();
               if ( (DateTime?)dtmTransation.Value == DateTime.MinValue)
               {

                   errorProviderMain.SetError(dtmTransation, "Transaction Date is required.");
                   dtmTransation.Focus();
                   return;
               }
               if ((DateTime?)dtmTransation.Value.Date > DateTime.Now.Date)
               {

                   errorProviderMain.SetError(dtmTransation, "Transaction Date must be less or equal to current date.");
                   dtmTransation.Focus();
                   return;
               }
               if ((DateTime?)dtmTransation.Value.Date < _GeneratedDate.Date)
               {

                   errorProviderMain.SetError(dtmTransation, "Transaction Date must be greater or equal to exported date.");
                   dtmTransation.Focus();
                   return;
               }
                if (inputAmount.Value == null || inputAmount.Value < 0.01)
                {
                    errorProviderMain.SetError(inputAmount, "Amount must be greater than 0.0");
                    inputAmount.Focus();
                    return;
                }
                
                DataGridViewRow dr = grdListJounal.Rows[grdListJounal.Rows.Add()];
                dr.Cells[colDate.Name].Value = (DateTime?)dtmTransation.Value == DateTime.MinValue ? null : (DateTime?)dtmTransation.Value;//dtmTransation.Value;
                dr.Cells[colDetail.Name].Value =textNotes.Text.Trim();
               
                dr.Cells[colPaymentType.Name].Value = (int)eAccountPaymentType.Debit;              

                switch (paymentTypeID)
                {

                    case ePaymentTypeID.Payment:
                        {
                            

                            dr.Cells[colDebit.Name].Value = inputAmount.Value;
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) + inputAmount.Value).ToString();

                        }
                        break;
                    case ePaymentTypeID.Adjustment:
                        {
                            dr.Cells[colDebit.Name].Value = -inputAmount.Value;
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) - inputAmount.Value).ToString();

                        }
                        break;
                    case ePaymentTypeID.Discount:
                        {
                            
                            dr.Cells[colDebit.Name].Value = inputAmount.Value;
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) - inputAmount.Value).ToString();
                        }
                        break;

                }
               dtmTransation.Value = DateTime.Now;
                inputAmount.Value = 0;
                textNotes.Text = "";
               
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {

                

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lstJournalPayment = new List<DataModel.JournalPayment>();
                foreach (DataGridViewRow dr in grdListJounal.Rows)
                {
                    DataModel.JournalPayment jor = new DataModel.JournalPayment();
                    jor.TransactionDate = Convert.ToDateTime(dr.Cells[colDate.Name].Value);
                    jor.CreatedBy = BusinessRule.Utilities.LoggedinUserId;
                    jor.PaymentID = -1;
                    jor.Amount = Convert.ToDecimal(dr.Cells[colDebit.Name].Value);
                    jor.Notes = dr.Cells[colDetail.Name].Value.ToString();
                    jor.MainJournalID = mainJournalID;
                    jor.PaymentTypeID = (int)paymentTypeID;
                    lstJournalPayment.Add(jor);
                }
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdListJounal.SelectedRows.Count == 0)
                    return;

                DataGridViewRow dr = grdListJounal.SelectedRows[0];
             
                double amount = 0.0;

                amount = Convert.ToDouble(dr.Cells[colDebit.Name].Value);

                switch (paymentTypeID)
                {

                    case ePaymentTypeID.Payment:
                        {
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) - amount).ToString();
                        }
                        break;
                    case ePaymentTypeID.Adjustment:
                        {
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) + Math.Abs(amount)).ToString();
                        }
                        break;
                    case ePaymentTypeID.Discount:
                        {
                            textAmountRecived.Text = (Convert.ToDouble(textAmountRecived.Text) + amount).ToString();
                        }
                        break;

                }

                grdListJounal.Rows.Remove(grdListJounal.SelectedRows[0]);

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
    }
}
