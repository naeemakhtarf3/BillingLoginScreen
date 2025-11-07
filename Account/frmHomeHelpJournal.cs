using BusinessRule;
using CareGiver.Helper_Classes;
using CareGiver.Search;
using DataModel;
using DevComponents.DotNetBar;
using DevComponents.Tree;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CareGiver.Account
{
    public partial class frmHomeHelpJournal : DevExpress.XtraEditors.XtraForm
    {
        BusinessRule.Journal journalInstance;
        List<MainJournal> resultData;

        public frmHomeHelpJournal()
        {
            InitializeComponent();


            if (BusinessRule.Utilities.IsDesignMode)
                return;

            journalInstance = new BusinessRule.Journal();

            journalInstance.onSearchJournalCompleted += journalInstance_onSearchJournalCompleted;

            if (BusinessRule.Utilities.LoggedinUserRoleStatus == eUserRole.SuperAdmin)
            {
                uctrlFranchise1.Enabled = true;
            }
            else
            {
                uctrlFranchise1.SelectedFranchiseID = BusinessRule.Utilities.FranchiseID;
                uctrlFranchise1.Enabled = false;
            }

            //this.BackColor = System.Drawing.Color.FromArgb(194, 217, 247);
            uctrlFranchise1.ShowAllItem = true;
            uctrlUserSearchHomeHelp.LabelCaption = Lookup.Cache.Franchise[0].WorkForceTerm + ": ";
            uctrlUserSearchHomeHelp.LoadNonPrimaryOnly = 0;


            if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
            {
                labelTotalPayable.Text = "Total Amount (" + BusinessRule.Utilities.CurrencySign + "):";
            }
            //RolebaseForm.SetRolebaseBarDockControl(this, eFormName.PayrollPayment, standaloneBarDockControl1);
            //RolebaseForm.SetRolebaseBarDockControl(this, eFormName.PayrollPayment, standaloneBarDockControl2);
            //RolebaseForm.SetRolebaseBarDockControl(this, eFormName.PayrollPayment, standaloneBarDockControl3);
            RolebaseForm.SetRolebase(this, eFormName.PayrollPayment, contextMenuExpence, barManager1);
        }

        void journalInstance_onSearchJournalCompleted(object sender, BusinessRule.JournalService.SearchJournalCompletedEventArgs e)
        {
            try
            {
                buttonSearch.Enabled = true;

                if (e.Result == null)
                    return;

                resultData = e.Result;

                //  resultData= resultData.Where(x => x.TotalAmount > 0).ToList();

                if (resultData == null)
                    return;

                this.BatchGrid.DataSource = resultData;

                GridColumnSortInfo[] sortInfo = { 
                new GridColumnSortInfo(BatchGridView.Columns["BatchID"], DevExpress.Data.ColumnSortOrder.Ascending)};

                BatchGridView.SortInfo.ClearAndAddRange(sortInfo, 1);
                BatchGridView.ExpandAllGroups();

                BatchGridView.Columns["BillingTypeID"].Visible = false;
                BatchGridView.Columns["MainJournalID"].Visible = false;
                BatchGridView.Columns["AmountRecievedPaid"].Visible = false;
                BatchGridView.Columns["Adjustment"].Visible = false;
                BatchGridView.Columns["CurrentBalance"].Visible = false;
                BatchGridView.Columns["Insertedat"].Visible = true;
                BatchGridView.Columns["Insertedat"].Caption = "Generated and Exported At";
                BatchGridView.Columns["InsertedByName"].Caption = "Generated and Exported By";
                BatchGridView.Columns["InvoiceReport"].Visible = false;
                BatchGridView.Columns["ReferenceMainJournalID"].Visible = false;
                BatchGridView.Columns["JournalStatusID"].Visible = false;
                BatchGridView.Columns["PayerTypeID"].Visible = false;
                BatchGridView.Columns["DepartmentID"].Visible = false;
                BatchGridView.Columns["DepartmentContactID"].Visible = false;
                BatchGridView.Columns["PayerType"].Visible = false;
                BatchGridView.Columns["Department"].Visible = false;
                BatchGridView.Columns["DepartmentContact"].Visible = false;
                BatchGridView.Columns["UserID"].Visible = false;
                BatchGridView.Columns["RemainingAmount"].Visible = false;
                BatchGridView.Columns["InvoiceNumber"].Visible = false;
                BatchGridView.Columns["FullName"].Caption = Lookup.Cache.Franchise[0].WorkForceTerm;
                BatchGridView.Columns["PaymentTypeID"].Visible = false;
                BatchGridView.Columns["IsExportToDrData"].Visible = false;

                BatchGridView.Columns["NetSuiteExportedDate"].Visible = false;
                BatchGridView.Columns["ExportToNetSuite"].Visible = false;
                BatchGridView.Columns["InvoiceDate"].Visible = false;



                if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
                {
                    BatchGridView.Columns["TotalAmount"].ToolTip = "Total Amount (" + BusinessRule.Utilities.CurrencySign + "):";
                }

                //BatchGridView.Columns["IsExportToDrData"].Caption = "Export to Dr Data";

                if (BatchGridView.SelectedRowsCount > 0)
                {
                    BatchGridView_FocusedRowChanged(this, null);
                }


            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
            finally
            {
                DisplayProgressBar(false);

            }
        }
        private void DisplayProgressBar(Boolean show)
        {
            try
            {
                if (show)
                {
                    //Show Search Bar
                    circularProgress1.Visible = show;
                    circularProgress1.IsRunning = show;
                }
                else
                {
                    //Hide Progress Bar 
                    circularProgress1.Visible = show;
                    circularProgress1.IsRunning = show;

                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderMain.Clear();

                if (dateTimeFrom.LockUpdateChecked && dateTimeTo.LockUpdateChecked)
                {
                    if (dateTimeTo.Value.Date < dateTimeFrom.Value.Date)
                    {
                        errorProviderMain.SetError(dateTimeTo, "Date To should not be less than Date From.");
                        dateTimeTo.Focus();
                        return;
                    }
                }

                BatchGrid.DataSource = null;
                TaskGrid.DataSource = null;
                PaymentGrid.DataSource = null;
                buttonSearch.Enabled = false;
                textAmountRecived.Text = string.Empty;
                textInvoiceDate.Text = string.Empty;
                textNetAmount.Text = string.Empty;
                textRemainingBalance.Text = string.Empty;

                ViewJournalSearchParam searchParam = new ViewJournalSearchParam();

                if (!dateTimeFrom.LockUpdateChecked)
                {
                    searchParam.FromDate = null;
                }
                else
                {
                    searchParam.FromDate = new DateTime(dateTimeFrom.Value.Year, dateTimeFrom.Value.Month, dateTimeFrom.Value.Day, 0, 0, 0);
                }

                if (!dateTimeTo.LockUpdateChecked)
                {
                    searchParam.ToDate = null;
                }
                else
                {
                    searchParam.ToDate = new DateTime(dateTimeTo.Value.Year, dateTimeTo.Value.Month, dateTimeTo.Value.Day, 23, 59, 59);
                }

                if (uctrlFranchise1.SelectedFranchiseID.HasValue)
                {
                    searchParam.FranchiseID = uctrlFranchise1.SelectedFranchiseID.Value;
                }
                else
                {
                    searchParam.FranchiseID = null;
                }

                List<int> selectedBillingTypeIDs = new List<int>();

                List<int> selectedJournalStatusTypeIDs = new List<int>();

                selectedBillingTypeIDs = (from DevComponents.AdvTree.Node childNode in advTreeStatusType.Nodes[0].Nodes
                                          where childNode.Tag != null && childNode.Checked == true
                                          select Convert.ToInt32(childNode.Tag)).ToList();

                if (selectedBillingTypeIDs.Count == 0)
                {
                    selectedBillingTypeIDs = (from DevComponents.AdvTree.Node childNode in advTreeStatusType.Nodes[0].Nodes
                                              where childNode.Tag != null
                                              select Convert.ToInt32(childNode.Tag)).ToList();

                }

                searchParam.FlagTypeIDs = string.Join(",", selectedJournalStatusTypeIDs);
                searchParam.BillingTypeIDs = string.Join(",", selectedBillingTypeIDs);

                searchParam.GroupIds = uCtrlGroupListForUser1.GetSelectedGroupIDs();
                if (uctrlUserSearchHomeHelp.UserID > 0)
                    searchParam.ClientID = uctrlUserSearchHomeHelp.UserID;
                else
                    searchParam.ClientID = null;
                DisplayProgressBar(true);

                journalInstance.SearchJournal(searchParam);


            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }
        private void SetInvoiceDetailgrid(ViewJournalSearchResultByID journalData)
        {
            this.TaskGrid.DataSource = null;
            PaymentGrid.DataSource = null;
            Bitmap bmpRecordType = new Bitmap(16, 16);
            string journalTypeTooltip = string.Empty;

            if (journalData == null && journalData.journalDetail == null)
                return;


            //  this.TaskGrid.DataSource = journalData.journalDetail.Where(x=>x.Amount>0);

            this.TaskGrid.DataSource = journalData.journalDetail.Where(x => x.JournalTypeID != (int)WageExpenseSearchResultType.Leave);

            GridColumnSortInfo[] sortInfo = { 
                new GridColumnSortInfo(TaskGridView.Columns["Client"], DevExpress.Data.ColumnSortOrder.Ascending)};

            TaskGridView.SortInfo.ClearAndAddRange(sortInfo, 1);
            if (this.TaskGridView.Columns.Count > 2)
            {
                TaskGridView.Columns["JournalID"].Visible = false;
                TaskGridView.Columns["MainJournalID"].Visible = false;
                TaskGridView.Columns["IsMovedTo"].Visible = false;
                TaskGridView.Columns["JournalTypeID"].Visible = false;
                TaskGridView.Columns["ClientID"].Visible = false;
                TaskGridView.Columns["ClientID"].Visible = false;
                TaskGridView.Columns["ServiceTaskID"].Caption = "Task ID";
                TaskGridView.Columns["Flagged"].Visible = false;
                TaskGridView.Columns["HomeHelp"].Visible = false;
                TaskGridView.Columns["InvoiceNumber"].Visible = false;
                TaskGridView.Columns["Client"].Caption = Lookup.Cache.Franchise[0].ClientTerm;

                this.PaymentGrid.DataSource = journalData.journalPayment;

                PaymentGridView.Columns["MainJournalID"].Visible = false;
                PaymentGridView.Columns["PaymentTypeID"].Visible = false;
                PaymentGridView.Columns["CreatedBy"].Visible = false;
                PaymentGridView.Columns["TransactionDate"].Caption = "Transaction Date";
                PaymentGridView.Columns["InsertedBy"].Caption = "Transaction By";

            }

            if (journalData.userPaymentStatus != null)
            {
                textInvoiceDate.Text = journalData.userPaymentStatus.MainJournalDate.ToString(Settings.Obj.General[0].DateFormat);
                textNetAmount.Text = journalData.userPaymentStatus.TotalPayment.ToString();
                textAmountRecived.Text = journalData.userPaymentStatus.PaymentPaid.ToString();
                textRemainingBalance.Text = (journalData.userPaymentStatus.TotalPayment - journalData.userPaymentStatus.PaymentPaid).ToString();
            }
            else
            {
                textInvoiceDate.Text = string.Empty;
                textNetAmount.Text = string.Empty;
                textAmountRecived.Text = string.Empty;
                textRemainingBalance.Text = string.Empty;

            }
        }

        private void uctrlFranchise1_OnSelectedFranchiseChanged(object sender, EventArgs e)
        {
            try
            {
                int franchiseid = -1;
                if (this.uctrlFranchise1.SelectedFranchiseID != null)
                    franchiseid = Convert.ToInt32(this.uctrlFranchise1.SelectedFranchiseID);

                uCtrlGroupListForUser1.DisplayUserGroup(null, franchiseid);

                this.labelX6.Text = Common.FranchiseInfo.GetFranchiseGroupTerm(franchiseid) + ":";

                uctrlUserSearchHomeHelp.FranchiseID = franchiseid;
                SetDateSearchCriteria();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        public void SetDateSearchCriteria()
        {
            if (!Common.FranchiseInfo.GetFranchiseDateCriteria(BusinessRule.Utilities.FranchiseID))
            {
                dateTimeFrom.Value = DateTime.Today.Date;
                dateTimeTo.Value = DateTime.Today.Date;
            }
            else
            {
                if (uctrlFranchise1.SelectedFranchiseID == null)
                {
                    dateTimeFrom.Value = Common.FranchiseInfo.GetFranchiseStartDate(BusinessRule.Utilities.FranchiseID);
                    dateTimeTo.Value = Common.FranchiseInfo.GetFranchiseEndDate(BusinessRule.Utilities.FranchiseID);
                }
                else
                {
                    dateTimeFrom.Value = Common.FranchiseInfo.GetFranchiseStartDate((int)uctrlFranchise1.SelectedFranchiseID);
                    dateTimeTo.Value = Common.FranchiseInfo.GetFranchiseEndDate((int)uctrlFranchise1.SelectedFranchiseID);
                }
            }
        }

        private void addPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void advTreeStatusType_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (advTreeStatusType.SelectedNode == null)
                    return;

                int checkednodes = 0;
                if (advTreeStatusType.SelectedNode.Text == "All")
                {
                    bool checkedState = advTreeStatusType.SelectedNode.Checked;
                    foreach (DevComponents.AdvTree.Node cNode in advTreeStatusType.SelectedNode.Nodes)
                    {
                        foreach (DevComponents.AdvTree.Node cTNode in cNode.Nodes)
                        {
                            cTNode.Checked = checkedState;
                        }
                        cNode.Checked = checkedState;
                    }
                }
                else
                {
                    if (advTreeStatusType.SelectedNode.Level == 1 && advTreeStatusType.SelectedNode.Nodes.Count > 0)
                    {
                        foreach (DevComponents.AdvTree.Node cNode in advTreeStatusType.SelectedNode.Nodes)
                        {
                            cNode.Checked = advTreeStatusType.SelectedNode.Checked;
                        }
                    }
                    else if (advTreeStatusType.SelectedNode.Level == 2)
                    {
                        DevComponents.AdvTree.Node pNode = advTreeStatusType.SelectedNode.Parent;
                        checkednodes = 0;
                        foreach (DevComponents.AdvTree.Node cNode in pNode.Nodes)
                        {
                            if (cNode.Checked)
                                checkednodes++;
                        }
                        pNode.Checked = !(checkednodes < pNode.Nodes.Count);
                    }

                    checkednodes = 0;
                    foreach (DevComponents.AdvTree.Node cNode in nodeAllStatus.Nodes)
                    {
                        if (cNode.Level == 1)

                            if (cNode != nodeAllStatus && cNode.Checked)
                                checkednodes++;
                    }
                    nodeAllStatus.Checked = !(checkednodes < nodeAllStatus.Nodes.Count);
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            if (this.TaskGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.Journal jor = this.TaskGridView.GetRow(this.TaskGridView.GetSelectedRows()[0]) as DataModel.Journal;

            if (jor == null)
                return;

            if (this.BatchGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.MainJournal Mainjor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

            if (Mainjor == null)
                return;

            if (jor.IsMovedTo)
            {
                XtraMessageBox.Show("Selected Task payroll cannot be shifted because it already be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (jor.JournalTypeID == (int)WageExpenseSearchResultType.TaskMoved)
            {
                XtraMessageBox.Show("Selected Task payroll cannot be shifted because it already be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (XtraMessageBox.Show("Task payroll will be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + " , do you still want to continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            frmSearchCareGiver searchForm = null;

            try
            {
                searchForm = new frmSearchCareGiver();
                searchForm.FranchiseID = BusinessRule.Utilities.FranchiseID;
                searchForm.CloseFormOnRowSelection = true;
                searchForm.ShowCheckBoxColumn = false;
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    List<DataModel.Journal> journal = new List<DataModel.Journal>();
                    List<MainJournal> mainJournal = new List<MainJournal>();

                    int selectedHomeHelpID = searchForm.CheckedUsersList[0].ID;

                    // reverser entry for existing home help
                    MainJournal objMainJournelOldHomeHelp = new MainJournal();
                    objMainJournelOldHomeHelp.MainJournalID = -1;
                    objMainJournelOldHomeHelp.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    objMainJournelOldHomeHelp.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    objMainJournelOldHomeHelp.BillingTypeID = (int)WageExpenseSearchResultType.ReverseWages;
                    objMainJournelOldHomeHelp.UserID = Mainjor.UserID;
                    objMainJournelOldHomeHelp.TotalAmount = -jor.Amount;
                    objMainJournelOldHomeHelp.ReferenceMainJournalID = jor.MainJournalID;
                    mainJournal.Add(objMainJournelOldHomeHelp);

                    DataModel.Journal objJournelOldHomeHelp = new DataModel.Journal();
                    objJournelOldHomeHelp.JournalID = -1;
                    objJournelOldHomeHelp.MainJournalID = -1;
                    objJournelOldHomeHelp.ServiceTaskID = jor.ServiceTaskID;
                    objJournelOldHomeHelp.Amount = -jor.Amount;
                    objJournelOldHomeHelp.JournalTypeID = jor.JournalTypeID;
                    objJournelOldHomeHelp.Notes = "Task is shifted To Home Help " + searchForm.CheckedUsersList[0].FirstName;
                    journal.Add(objJournelOldHomeHelp);


                    // new entry for new home help
                    MainJournal objMainJournelNewHomeHelp = new MainJournal();
                    objMainJournelNewHomeHelp.MainJournalID = -2;
                    objMainJournelNewHomeHelp.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    objMainJournelNewHomeHelp.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    objMainJournelNewHomeHelp.BillingTypeID = (int)WageExpenseSearchResultType.Wages;
                    objMainJournelNewHomeHelp.UserID = selectedHomeHelpID;
                    objMainJournelNewHomeHelp.TotalAmount = jor.Amount;
                    objMainJournelNewHomeHelp.ReferenceMainJournalID = jor.MainJournalID;
                    mainJournal.Add(objMainJournelNewHomeHelp);

                    DataModel.Journal objJournelNewHomeHelp = new DataModel.Journal();
                    objJournelNewHomeHelp.JournalID = -2;
                    objJournelNewHomeHelp.MainJournalID = -2;
                    objJournelNewHomeHelp.ServiceTaskID = jor.ServiceTaskID;
                    objJournelNewHomeHelp.Amount = jor.Amount;
                    objJournelNewHomeHelp.JournalTypeID = jor.JournalTypeID;
                    objJournelNewHomeHelp.Notes = "Task is shifted from Payroll ID " + jor.MainJournalID;
                    journal.Add(objJournelNewHomeHelp);

                    // update entry for existing journal                  

                    jor.JournalTypeID = (int)WageExpenseSearchResultType.TaskMoved;
                    jor.Notes = "Task is shifted To Home Help " + searchForm.CheckedUsersList[0].FirstName;
                    journal.Add(jor);

                    journalInstance.UpdateIsExportedStatus(mainJournal, journal, BusinessRule.Utilities.LoggedinUserId, "", "", Convert.ToInt32(searchForm.FranchiseID), "");

                    ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                    SetInvoiceDetailgrid(getjournalDetail);


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error creating window handle"))
                {
                    ShowWindowAfterHandleCreated(searchForm);
                }
                else
                    ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void ShowWindowAfterHandleCreated(Control ctrl)
        {
            while (!ctrl.IsHandleCreated)
            {
                try
                {
                    IntPtr ptr = ctrl.Handle;
                }
                catch
                {

                }
            }
            ctrl.Show();
        }

        private void grdListJounalDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //if (_userType == EUserType.Client)
                //{
                //    if (grdListJounalDetail.Rows[e.RowIndex].Cells[colJournalTypeID.Index].Value.ToString() == "1"
                //        && grdListJounalDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor
                //        != System.Drawing.ColorTranslator.FromHtml(CareGiver.Helper_Classes.StatusColor.Completed))
                //    {

                //        grdListJounalDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(CareGiver.Helper_Classes.StatusColor.Completed);

                //    }
                //}
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                AddPaymentToSystem(ePaymentTypeID.Payment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnAddAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                AddPaymentToSystem(ePaymentTypeID.Adjustment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                AddPaymentToSystem(ePaymentTypeID.Discount);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void AddPaymentToSystem(ePaymentTypeID journalType)
        {
            if (this.BatchGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;
            DateTime GeneratedDate = Convert.ToDateTime(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "Insertedat"));
            if (jor == null)
                return;


            using (frmPayment obj = new frmPayment(Convert.ToDecimal(textNetAmount.Text), Convert.ToDecimal(textAmountRecived.Text), jor.BillingTypeID, EUserType.Carer, journalType, jor.MainJournalID, GeneratedDate))
            {
                if (obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    journalInstance.AddJournalPayment(obj.LstJournalPayment);

                    ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                    SetInvoiceDetailgrid(getjournalDetail);

                }
                buttonSearch_Click(null, null);
            };
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                DataModel.Journal jorDetail = e.Row as DataModel.Journal;
                if (jorDetail == null)
                    return;

                WageExpenseSearchResultType resultType = (WageExpenseSearchResultType)jorDetail.JournalTypeID;
                switch (resultType)
                {
                    case WageExpenseSearchResultType.Billing:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Billing"];
                        }
                        break;
                    case WageExpenseSearchResultType.Premium:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Bonus"];
                        }
                        break;
                    case WageExpenseSearchResultType.Expense:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["expense"];
                        }
                        break;
                    case WageExpenseSearchResultType.HomeHelpExpense:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["expense"];
                        }
                        break;
                    case WageExpenseSearchResultType.Wages:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["wages"];
                        }
                        break;
                    case WageExpenseSearchResultType.ReverseWages:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Replacement"];
                        }
                        break;
                    case WageExpenseSearchResultType.TaskMoved:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Replacement"];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void TaskGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                DataModel.MainJournal jor = e.Row as DataModel.MainJournal;

                if (jor == null)
                    return;

                eJournalStatusTypeID statusID = (eJournalStatusTypeID)jor.JournalStatusID;
                switch (statusID)
                {
                    case eJournalStatusTypeID.Paid:
                        e.Value = (Bitmap)imageListGrid.Images["paid"];
                        break;
                    case eJournalStatusTypeID.UnPaid:
                        e.Value = (Bitmap)imageListGrid.Images["unpaid"];
                        break;
                    case eJournalStatusTypeID.LessPaid:
                        e.Value = (Bitmap)imageListGrid.Images["Lesspayment"];
                        break;
                    case eJournalStatusTypeID.OverPaid:
                        e.Value = (Bitmap)imageListGrid.Images["overpaid"];
                        break;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }

        private void BatchGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (this.BatchGridView.SelectedRowsCount <= 0)
                {
                    return;
                }

                DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

                if (jor == null)
                    return;
                if (jor.IsAutoPayment)
                {
                    btnAutoPayment.Enabled = false;
                    btnAddPayment.Enabled = false;
                }
                else if (!jor.IsAutoPayment && jor.PaymentTypeID != 0)
                {
                    btnAutoPayment.Enabled = false;
                    btnAddPayment.Enabled = true;
                }
                else
                {
                    btnAutoPayment.Enabled = true;
                    btnAddPayment.Enabled = true;
                }
                ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                SetInvoiceDetailgrid(journalDetail);

                DateTime InvoiceGeneratedAt = Convert.ToDateTime(jor.Insertedat);//(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "Insertedat"));

                double NoofDays = (DateTime.Today - InvoiceGeneratedAt).TotalDays;

                if (NoofDays > BusinessRule.Settings.Obj.General[0].CancelInvoicePeriod)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }

        private void TaskGrid_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TaskGridView.RowCount > 0)
                {
                    AddImageColumnsToTask();
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void BatchGrid_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                AddImageColumnsToBatch();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void AddImageColumnsToTask()
        {

            RepositoryItemPictureEdit pictureEdit = this.TaskGrid.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = PictureSizeMode.Zoom;
            TaskGridView.OptionsView.AnimationType = GridAnimationType.AnimateAllContent;
            pictureEdit.NullText = " ";

            if (this.TaskGridView.Columns.ColumnByName("JournalType") == null)
            {
                this.TaskGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = " ",
                    Name = "JournalType",
                    FieldName = "JournalType",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Object,
                    VisibleIndex = 0,
                    Width = 25,
                    MaxWidth = 25,
                    ToolTip = "Journal Type",
                    ColumnEdit = pictureEdit
                });
            }
        }
        private void AddImageColumnsToBatch()
        {

            RepositoryItemPictureEdit pictureEdit1 = this.BatchGrid.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit1.SizeMode = PictureSizeMode.Zoom;
            BatchGridView.OptionsView.AnimationType = GridAnimationType.AnimateAllContent;
            pictureEdit1.NullText = " ";

            if (this.BatchGridView.Columns.ColumnByName("JournalStatusImage") == null)
            {
                this.BatchGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = " ",
                    Name = "JournalStatusImage",
                    FieldName = "JournalStatusImage",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Object,
                    VisibleIndex = 0,
                    Width = 25,
                    MaxWidth = 25,
                    ToolTip = "Journal Status",
                    ColumnEdit = pictureEdit1
                });
            }
        }
        private void AddImageColumnsToPayment()
        {
            RepositoryItemPictureEdit pictureEdit2 = this.PaymentGrid.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit2.SizeMode = PictureSizeMode.Zoom;
            PaymentGridView.OptionsView.AnimationType = GridAnimationType.AnimateAllContent;
            pictureEdit2.NullText = " ";

            if (this.PaymentGridView.Columns.ColumnByName("TypeImage") == null)
            {
                this.PaymentGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = " ",
                    Name = "TypeImage",
                    FieldName = "TypeImage",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Object,
                    VisibleIndex = 0,
                    Width = 25,
                    MaxWidth = 25,
                    ToolTip = "Payment Type",
                    ColumnEdit = pictureEdit2
                });
            }
        }

        private void btnAutoPayment_Click(object sender, EventArgs e)
        {
            try
            {
                AddAutoPaymentToSystem(ePaymentTypeID.Payment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void AddAutoPaymentToSystem(ePaymentTypeID journalType)
        {
            if (this.BatchGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

            if (jor == null)
                return;

            using (frmAutoPayment obj = new frmAutoPayment())
            {
                obj.InsertedAt = jor.Insertedat;

                if (obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    List<MainJournal> mainJournalData = resultData.FindAll(m => m.BatchID == jor.BatchID && m.PaymentTypeID == 0);

                    List<DataModel.JournalPayment> journalPaymentList = new List<JournalPayment>();

                    foreach (MainJournal main in mainJournalData)
                    {
                        DataModel.JournalPayment journalPaymentObj = new JournalPayment();
                        journalPaymentObj.PaymentID = -1;
                        journalPaymentObj.MainJournalID = main.MainJournalID;
                        journalPaymentObj.Amount = main.RemainingAmount;
                        journalPaymentObj.Notes = obj.Notes;
                        journalPaymentObj.CreatedBy = BusinessRule.Utilities.LoggedinUserId;
                        journalPaymentObj.InsertedAt = DateTime.Now;
                        journalPaymentObj.PaymentTypeID = (int)ePaymentTypeID.Payment;
                        journalPaymentObj.IsAutoPayment = true;
                        journalPaymentList.Add(journalPaymentObj);
                    }

                    journalInstance.AddJournalPayment(journalPaymentList);

                    ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);
                    buttonSearch_Click(null, null);
                    SetInvoiceDetailgrid(getjournalDetail);

                }
            };
        }

        private void PaymentGridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                DataModel.JournalPayment jorDetail = e.Row as DataModel.JournalPayment;

                if (jorDetail == null)
                    return;

                ePaymentTypeID resultType = (ePaymentTypeID)jorDetail.PaymentTypeID;
                switch (resultType)
                {
                    case ePaymentTypeID.Payment:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Payment"];
                        }
                        break;
                    case ePaymentTypeID.Adjustment:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Replacement"];
                        }
                        break;
                    case ePaymentTypeID.Discount:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Discount"];
                        }
                        break;
                    case ePaymentTypeID.Reverse:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Replacement"];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void PaymentGrid_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                AddImageColumnsToPayment();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void Reset()
        {
            if (BusinessRule.Utilities.LoggedinUserRoleStatus == eUserRole.SuperAdmin)
            {
                uctrlFranchise1.SelectedFranchiseID = null;
            }
            else
            {
                uctrlFranchise1.SelectedFranchiseID = BusinessRule.Utilities.FranchiseID;
            }
            uctrlUserSearchHomeHelp.FranchiseID = null;
            uctrlUserSearchHomeHelp.UserID = -1;
            uctrlUserSearchHomeHelp.UserName = "";
            //dateTimeFrom.Value = DateTime.Today.Date;
            //dateTimeTo.Value = DateTime.Today.Date;

            BatchGrid.DataSource = null;
            TaskGrid.DataSource = null;
            PaymentGrid.DataSource = null;
            // buttonSearch.Enabled = false;
            textAmountRecived.Text = string.Empty;
            textInvoiceDate.Text = string.Empty;
            textNetAmount.Text = string.Empty;
            textRemainingBalance.Text = string.Empty;
            btnDelete.Enabled = false;
            dateTimeFrom.LockUpdateChecked = true;
            dateTimeTo.LockUpdateChecked = true;
            SetDateSearchCriteria();
        }

        private void btnAutoPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataModel.MainJournal jor = BatchGridView.GetFocusedRow() as DataModel.MainJournal;
                if (jor.IsAutoPayment)
                {
                    //  Messages.Information("Auto Paymnet is already paid");
                    return;
                }
                AddAutoPaymentToSystem(ePaymentTypeID.Payment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnAddPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddPaymentToSystem(ePaymentTypeID.Payment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnAddAdjustment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddPaymentToSystem(ePaymentTypeID.Adjustment);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void buttonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.TaskGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.Journal jor = this.TaskGridView.GetRow(this.TaskGridView.GetSelectedRows()[0]) as DataModel.Journal;

            if (jor == null)
                return;

            if (this.BatchGridView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataModel.MainJournal Mainjor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

            if (Mainjor == null)
                return;

            if (jor.IsMovedTo)
            {
                XtraMessageBox.Show("Selected Task payroll cannot be shifted because it is already be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (jor.JournalTypeID == (int)WageExpenseSearchResultType.TaskMoved)
            {
                XtraMessageBox.Show("Selected Task payroll cannot be shifted because it is already be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show("Task payroll will be shifted to another " + Lookup.Cache.Franchise[0].WorkForceTerm + " , do you still want to continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            frmSearchCareGiver searchForm = null;

            try
            {
                searchForm = new frmSearchCareGiver();
                searchForm.FranchiseID = BusinessRule.Utilities.FranchiseID;
                searchForm.CloseFormOnRowSelection = true;
                searchForm.ShowCheckBoxColumn = false;
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    List<DataModel.Journal> journal = new List<DataModel.Journal>();
                    List<MainJournal> mainJournal = new List<MainJournal>();

                    int selectedHomeHelpID = searchForm.CheckedUsersList[0].ID;

                    // reverser entry for existing home help
                    MainJournal objMainJournelOldHomeHelp = new MainJournal();
                    objMainJournelOldHomeHelp.MainJournalID = -1;
                    objMainJournelOldHomeHelp.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    objMainJournelOldHomeHelp.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    objMainJournelOldHomeHelp.BillingTypeID = (int)WageExpenseSearchResultType.ReverseWages;
                    objMainJournelOldHomeHelp.UserID = Mainjor.UserID;
                    objMainJournelOldHomeHelp.TotalAmount = -jor.Amount;
                    objMainJournelOldHomeHelp.ReferenceMainJournalID = jor.MainJournalID;
                    mainJournal.Add(objMainJournelOldHomeHelp);

                    DataModel.Journal objJournelOldHomeHelp = new DataModel.Journal();
                    objJournelOldHomeHelp.JournalID = -1;
                    objJournelOldHomeHelp.MainJournalID = -1;
                    objJournelOldHomeHelp.ServiceTaskID = jor.ServiceTaskID;
                    objJournelOldHomeHelp.Amount = -jor.Amount;
                    objJournelOldHomeHelp.JournalTypeID = jor.JournalTypeID;
                    objJournelOldHomeHelp.Notes = "Task is shifted To Home Help " + searchForm.CheckedUsersList[0].FirstName;
                    journal.Add(objJournelOldHomeHelp);

                    // new entry for new home help
                    MainJournal objMainJournelNewHomeHelp = new MainJournal();
                    objMainJournelNewHomeHelp.MainJournalID = -2;
                    objMainJournelNewHomeHelp.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    objMainJournelNewHomeHelp.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    objMainJournelNewHomeHelp.BillingTypeID = (int)WageExpenseSearchResultType.Wages;
                    objMainJournelNewHomeHelp.UserID = selectedHomeHelpID;
                    objMainJournelNewHomeHelp.TotalAmount = jor.Amount;
                    objMainJournelNewHomeHelp.ReferenceMainJournalID = jor.MainJournalID;
                    mainJournal.Add(objMainJournelNewHomeHelp);

                    DataModel.Journal objJournelNewHomeHelp = new DataModel.Journal();
                    objJournelNewHomeHelp.JournalID = -2;
                    objJournelNewHomeHelp.MainJournalID = -2;
                    objJournelNewHomeHelp.ServiceTaskID = jor.ServiceTaskID;
                    objJournelNewHomeHelp.Amount = jor.Amount;
                    objJournelNewHomeHelp.JournalTypeID = jor.JournalTypeID;
                    objJournelNewHomeHelp.Notes = "Task is shifted from Payroll ID " + jor.MainJournalID;
                    journal.Add(objJournelNewHomeHelp);

                    // update entry for existing journal                  

                    jor.JournalTypeID = (int)WageExpenseSearchResultType.TaskMoved;
                    jor.Notes = "Task is shifted To Home Help " + searchForm.CheckedUsersList[0].FirstName;
                    journal.Add(jor);

                    journalInstance.UpdateIsExportedStatus(mainJournal, journal, BusinessRule.Utilities.LoggedinUserId, "", "", Convert.ToInt32(searchForm.FranchiseID), "");

                    ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                    SetInvoiceDetailgrid(getjournalDetail);
                    buttonSearch_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Error creating window handle"))
                {
                    ShowWindowAfterHandleCreated(searchForm);
                }
                else
                    ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnPreviewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.BatchGridView.RowCount <= 0)
                    return;
                int MainJournalID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "MainJournalID"));
                InvoiceReportBinary report = journalInstance.GetInvoiceReport(MainJournalID);
                //   var Report  = this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "InvoiceReport");

                if (report == null)
                    return;

                if (report.InvoiceReport != null)
                {

                    byte[] ReportStream = report.InvoiceReport as byte[];

                    if (ReportStream == null)
                        return;
                    MemoryStream stream = new MemoryStream(ReportStream);
                    PrintingSystem ps = new PrintingSystem();

                    // Load the document from a stream.
                    ps.LoadDocument(stream);

                    frmReportViewer reportViewer = new frmReportViewer();
                    reportViewer.Text = "Payroll Report";
                    reportViewer.PrintingSystem = ps;
                    reportViewer.MdiParent = this.ParentForm;
                    reportViewer.Show();

                    //using (frmReportViewer reportViewer = new frmReportViewer())
                    //{
                    //    reportViewer.Text = "Payroll Report";
                    //    reportViewer.PrintingSystem = ps;
                    //    reportViewer.MdiParent = this.ParentForm;
                    //    reportViewer.Show();
                    //}

                }
                if (report.InvoiceReport1 != null)
                {

                    byte[] ReportStream1 = report.InvoiceReport1 as byte[];

                    if (ReportStream1 == null)
                        return;
                    MemoryStream stream1 = new MemoryStream(ReportStream1);
                    PrintingSystem ps1 = new PrintingSystem();

                    // Load the document from a stream.
                    ps1.LoadDocument(stream1);

                    frmReportViewer reportViewer1 = new frmReportViewer();
                    reportViewer1.Text = "Leave Timesheet Report";
                    reportViewer1.PrintingSystem = ps1;
                    reportViewer1.MdiParent = this.ParentForm;
                    reportViewer1.Show();

                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.BatchGridView.RowCount <= 0)
                    return;

                int MainJournalID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "MainJournalID"));
                DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

                if (MainJournalID > 0)
                {
                    if (XtraMessageBox.Show("Are you sure you wish to Delete this Payroll? If you Delete this Payroll it will be completely removed \nfrom  the system  and all Tasks will revert to a Status of Un-exported. \nThe Invoice will have to be re-generated if you wish to Invoice for these tasks", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (frmInvoiceDeleteReason obj = new frmInvoiceDeleteReason())
                        {
                            if (obj.ShowDialog() == DialogResult.OK)
                            {
                                journalInstance.DeleteInvoice(MainJournalID, obj.Reason, 3,BusinessRule.Utilities.LoggedinUserId);

                                buttonSearch_Click(null, null);
                            }
                        }
                    }
                }
                else if (jor.MainJournalID > 0)
                {
                    if (XtraMessageBox.Show("Are you sure you wish to Delete this batch? If you Delete this batch it will be completely removed \nfrom the system and all Tasks will revert to a Status of Un-exported. \nThe Invoice will have to be re-generated if you wish to Invoice for these tasks.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (frmInvoiceDeleteReason obj = new frmInvoiceDeleteReason())
                        {
                            if (obj.ShowDialog() == DialogResult.OK)
                            {
                                List<MainJournal> mainJournalData = resultData.FindAll(m => m.BatchID == jor.BatchID);
                                foreach (MainJournal main in mainJournalData)
                                {
                                    journalInstance.DeleteInvoice(main.MainJournalID, obj.Reason, 3,BusinessRule.Utilities.LoggedinUserId);
                                }

                                buttonSearch_Click(null, null);
                            }
                        }
                    }
                }

                // DeleteInvoice
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void frmHomeHelpJournal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
    }
}
