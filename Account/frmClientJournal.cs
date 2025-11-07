using BusinessRule;
using CareGiver.Helper_Classes;
using CareGiver.Search;
using DataModel;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
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
    public partial class frmClientJournal : DevExpress.XtraEditors.XtraForm
    {
        BusinessRule.Journal journalInstance;
        List<MainJournal> resultData;
        string PayerTerm = string.Empty;
        public frmClientJournal()
        {
            InitializeComponent();
            if (BusinessRule.Settings.Obj.General[0].OptimizedVersion != null && BusinessRule.Settings.Obj.General[0].OptimizedVersion)
                Lookup.LoadLookup(lookupType.ExportInvoice);
            if (BusinessRule.Utilities.IsDesignMode)
                return;

            journalInstance = new BusinessRule.Journal();

            journalInstance.onSearchJournalCompleted += journalInstance_onSearchJournalCompleted;

            journalInstance.onSearchClientInvoiceJournal += journalInstance_onSearchClientInvoiceJournal;


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
            TaskGridView.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
            // PopulateFlagTree();
            PopulatePayerNames();

            //Assigning currency sign to the labels
            if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
            {
                labelTotalPayable.Text = "Total  Amount (" + BusinessRule.Utilities.CurrencySign + "):";
                labelTotalPayment.Text = "Total Payment (" + BusinessRule.Utilities.CurrencySign + "):";
                lblRemainingBalance.Text = "Remaining Balance (" + BusinessRule.Utilities.CurrencySign + "):";
            }

            //if (BusinessRule.Utilities.LoggedinUserRoleStatus == eUserRole.SuperAdmin)
            //{
            //    uctrlUserSearchClient.LabelCaption = Lookup.Cache.Franchise[0].ClientTerm;
            //}
            //else
            //{
            //    uctrlUserSearchClient.LabelCaption = CareGiver.Helper_Classes.FranchiseInfo.GetFranchiseClientWorkTerm(BusinessRule.Utilities.FranchiseID);
            //}
            lblClient.Text = Lookup.Cache.Franchise[0].ClientTerm + ":";
            RolebaseForm.SetRolebase(this, eFormName.InvoicePayment, contextMenuExpence, barManager1);
            if ((int)ReportFor.LB != Settings.Obj.General[0].HomeHelpReportFor)
            {
                btnDelete.Text = "Delete Invoice";
                btnPreviewInvoice.Text = "Preview Invoice";
                this.labelX1.Text = "Invoice No:";
                this.expandablePanelInvoice.Text = "Invoice";
            }
        }

        private void journalInstance_onSearchClientInvoiceJournal(object sender, BusinessRule.JournalService.SearchClientInvoiceJournalCompletedEventArgs e)
        {
            try
            {
                buttonSearch.Enabled = true;

                if (e.Result == null)
                    return;

                ClientJournelResultSet ClientJournelResultSet = e.Result;

                if (ClientJournelResultSet.mainJournel == null)
                    return;

                resultData = ClientJournelResultSet.mainJournel;


                DataSet ds = new DataSet();
                DataTable dtmain = ClientJournelResultSet.mainJournel.ToDataTable();
                DataTable dtchild = ClientJournelResultSet.journalDetail.ToDataTable();

                ds.Tables.Add(dtmain);
                ds.Tables.Add(dtchild);

                ds.Relations.Add("Invoice Detail", ds.Tables[0].Columns["MainJournalID"], ds.Tables[1].Columns["MainJournalID"]);

                this.BatchGrid.DataSource = null;
                this.BatchGridView.Columns.Clear();
                this.BatchGrid.DataSource = ds.Tables[0];
                this.BatchGrid.ForceInitialize();


                this.BatchGrid.LevelTree.Nodes.Add("Activities", JournelDetail);
                
                JournelDetail.ViewCaption = "Invoice Detail";
                JournelDetail.PopulateColumns(ds.Tables[1]);

                //this.ReferralsGridView.Columns["FranchiseID"].VisibleIndex = -1;

                //this.TaskGrid.LevelTree.Nodes.Add("Activities", GridActivities);

                //GridActivities.ViewCaption = "Referral Activities";
                //GridActivities.PopulateColumns(ds.Tables[1]);
                //GridActivities.Columns["ReferralID"].VisibleIndex = -1;

                //ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                //TaskGridView.ExpandAllGroups();
                BatchGridView.Columns["PaymentTypeID"].Visible = false;
                BatchGridView.Columns["BillingTypeID"].Visible = false;
                BatchGridView.Columns["AmountRecievedPaid"].Visible = false;
                BatchGridView.Columns["Adjustment"].Visible = false;
                BatchGridView.Columns["CurrentBalance"].Visible = false;
                BatchGridView.Columns["Insertedat"].Visible = true;
                BatchGridView.Columns["Insertedat"].Caption = "Generated and Exported At";
                BatchGridView.Columns["MainJournalID"].Visible = false;
                BatchGridView.Columns["IsExportToDrData"].Visible = false;
               
                BatchGridView.Columns["ReferenceMainJournalID"].Visible = false;
                BatchGridView.Columns["FullName"].Visible = false;
                BatchGridView.Columns["JournalStatusID"].Visible = false;
                BatchGridView.Columns["PayerTypeID"].Visible = false;
                BatchGridView.Columns["DepartmentID"].Visible = false;
                BatchGridView.Columns["DepartmentContactID"].Visible = false;
                BatchGridView.Columns["InvoiceReport"].Visible = false;
                BatchGridView.Columns["UserID"].Visible = false;
                // BatchGridView.Columns["BatchID"].Visible = false;
                BatchGridView.Columns["RemainingAmount"].Visible = false;
                // BatchGridView.Columns["MainJournalID"].Caption = "Invoice Number";
               

                if ((int)ReportFor.LB != Settings.Obj.General[0].HomeHelpReportFor)
                {
                    BatchGridView.Columns["InvoiceNumber"].Caption = "Invoice Number";
                    BatchGridView.Columns["ExportToNetSuite"].Visible = false;
                    BatchGridView.Columns["NetSuiteExportedDate"].Visible = false;
                }
                else
                {
                    BatchGridView.Columns["InvoiceNumber"].Caption = "Invoice/Journal Number";
                  
                }
                BatchGridView.Columns["InsertedByName"].Visible = true;
                BatchGridView.Columns["InsertedByName"].Caption = "Generated and Exported By";
                BatchGridView.Columns["PayerType"].Caption = PayerTerm;
                if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
                {
                    BatchGridView.Columns["TotalAmount"].Caption = "Total Amount(" + BusinessRule.Utilities.CurrencySign + ")";
                }





                //JournelDetail.Columns["MainJournalID"].VisibleIndex = -1;
                //JournelDetail.Columns["MainJournalID"].Caption = "Invoice Number";
                //JournelDetail.Columns["JournalID"].Visible = false;
                //JournelDetail.Columns["ClientID"].Visible = false;
                //JournelDetail.Columns["IsMovedTo"].Visible = false;
                //JournelDetail.Columns["Flagged"].Visible = false;








                //JournelDetail.OptionsView.ShowAutoFilterRow = ShowFilterPanelMode.Never;

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

        //private void PopulateFlagTree()
        //{
        //    try
        //    {
        //        advFlagTree.Nodes[0].Nodes.AddRange((from x in Lookup.Cache.AcountFlag
        //                                             select new Node()
        //                                             {
        //                                                 CheckBoxVisible = true,
        //                                                 Text = x.Description,
        //                                                 Tag = x.ID
        //                                             }).ToArray());

        //        advFlagTree.ExpandAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        ApplicationExceptions.HandleAppExc(ex);
        //    }
        //}
        private void PopulatePayerNames()
        {
            try
            {
                cboPayer.Enabled = true;
                cboPayer.DataSource = null;

                cboDepartment.Enabled = true;
                cboDepartment.DataSource = null;


                Company cmp = new Company();
                cmp = new Company()
                {
                    CompanyID = -1,
                    CompanyName = "All"
                };
                List<DataModel.Company> Comps = new List<Company>();
                Comps.Add(cmp);

                var insuranceCompanies = from c in BusinessRule.Lookup.Cache.Company.GetActiveAndUsedLookup(null, "IsActive", "CompanyID", 0)
                                         where c.CompanyTypeID == (int)CompanyTypes.Insurance
                                         select c;

                Comps.AddRange(insuranceCompanies.ToList());
                cboPayer.ValueMember = "CompanyID";
                cboPayer.DisplayMember = "CompanyName";
                cboPayer.DataSource = Comps;
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void PopulateCompanyDepartments()
        {
            try
            {
                var companyDepartments = from department in BusinessRule.Lookup.Cache.CompanyDepartment.GetActiveAndUsedLookup(null, "IsActive", "DepartmentID", 0)
                                         where department.CompanyID == (int)cboPayer.SelectedValue
                                         select department;

                CompanyDepartment dept;
                dept = new CompanyDepartment()
                {
                    DepartmentID = -1,
                    DepartmentName = "All"
                };
                List<DataModel.CompanyDepartment> Comps = new List<CompanyDepartment>();
                Comps.Add(dept);

                if (cboPayer.SelectedValue != null && (int)cboPayer.SelectedValue > 0)
                    if (companyDepartments != null && companyDepartments.ToList().Count > 0)
                    {
                        Comps.AddRange(companyDepartments.ToList());
                    }

                cboDepartment.ValueMember = "DepartmentID";
                cboDepartment.DisplayMember = "DepartmentName";
                cboDepartment.DataSource = Comps;
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        private void PopulateDepartmentContact()
        {
            try
            {
                if (cboDepartment.SelectedIndex < 0)
                    return;

                int departmentID = Convert.ToInt32(cboDepartment.SelectedValue);
                var dep = (from dc in
                               Lookup.Cache.DepartmentContact.GetActiveAndUsedLookup<DepartmentContact>(null, "IsActive", "DepartmentContactID", 0)
                           where dc.DepartmentID == departmentID
                                 && dc.FranchiseID == (int)uctrlFranchise1.SelectedFranchiseID
                           select dc).ToList();

                //if (dep.Count < 1)
                //    return;

                List<DepartmentContact> deparmentContacts = dep;//dep.ToList();

                DepartmentContact contact;
                contact = new DepartmentContact()
                {
                    DepartmentContactID = -1,
                    ContactName = "All"
                };

                deparmentContacts.Insert(0, contact);

                comboDepartmentContact.DisplayMember = "ContactName";
                comboDepartmentContact.ValueMember = "DepartmentContactID";
                comboDepartmentContact.DataSource = deparmentContacts;
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        void journalInstance_onSearchJournalCompleted(object sender, BusinessRule.JournalService.SearchJournalCompletedEventArgs e)
        {
            try
            {
                buttonSearch.Enabled = true;

                if (e.Result == null)
                    return;

                resultData = e.Result;


                this.BatchGrid.DataSource = resultData;


                //ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                //DataSet ds = new DataSet();
                //DataTable dtmain = resultData.ToDataTable();
                //DataTable dtchild = journalDetail.ToDataTable();

                //ds.Tables.Add(dtmain);
                //ds.Tables.Add(dtchild);

                //ds.Relations.Add("Activities", ds.Tables[0].Columns["referralID"], ds.Tables[1].Columns["referralID"]);

                //this.TaskGrid.DataSource = null;
                //this.ReferralsGridView.Columns.Clear();
                //this.TaskGrid.DataSource = ds.Tables[0];
                //this.TaskGrid.ForceInitialize();

                //this.ReferralsGridView.Columns["FranchiseID"].VisibleIndex = -1;

                //this.TaskGrid.LevelTree.Nodes.Add("Activities", GridActivities);

                //GridActivities.ViewCaption = "Referral Activities";
                //GridActivities.PopulateColumns(ds.Tables[1]);
                //GridActivities.Columns["ReferralID"].VisibleIndex = -1;

                //ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                //TaskGridView.ExpandAllGroups();

                BatchGridView.Columns["BillingTypeID"].Visible = false;
                BatchGridView.Columns["AmountRecievedPaid"].Visible = false;
                BatchGridView.Columns["Adjustment"].Visible = false;
                BatchGridView.Columns["CurrentBalance"].Visible = false;
                BatchGridView.Columns["Insertedat"].Visible = false;

                BatchGridView.Columns["ReferenceMainJournalID"].Visible = false;
                BatchGridView.Columns["FullName"].Visible = false;
                BatchGridView.Columns["JournalStatusID"].Visible = false;
                BatchGridView.Columns["PayerTypeID"].Visible = false;
                BatchGridView.Columns["DepartmentID"].Visible = false;
                BatchGridView.Columns["DepartmentContactID"].Visible = false;

                BatchGridView.Columns["UserID"].Visible = false;
                BatchGridView.Columns["BatchID"].Visible = false;
                BatchGridView.Columns["RemainingAmount"].Visible = false;
                // BatchGridView.Columns["MainJournalID"].Caption = "Invoice Number";

                if ((int)ReportFor.LB != Settings.Obj.General[0].HomeHelpReportFor)
                {
                    BatchGridView.Columns["InvoiceNumber"].Caption = "Invoice Number";
                }
                else
                {
                    BatchGridView.Columns["InvoiceNumber"].Caption = "Invoice/Journal Number";
                }
               

                BatchGridView.Columns["TotalAmount"].Caption = "Total Amount(" + BusinessRule.Utilities.CurrencySign + ")";

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
                if (buttonSearch.Visible == false)
                    return;
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


                if (!string.IsNullOrEmpty(uctrlUserSearchClient.UserName))
                {
                    searchParam.ClientID = uctrlUserSearchClient.UserID;

                }
                else
                {
                    searchParam.ClientID = null;

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

                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.Billing);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.MileageClaim);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.NetSuiteJournal);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.LBHCPWesternHealth);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.Budget);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.Fee);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.ConsumedItem);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.HCPWestern_Client);
                selectedBillingTypeIDs.Add((int)WageExpenseSearchResultType.HCPWestern_Govt);
                List<int> selectedFlagTypeIDs = new List<int>();

                //selectedFlagTypeIDs = (from DevComponents.AdvTree.Node childNode in advFlagTree.Nodes[0].Nodes
                //                          where childNode.Tag != null && childNode.Checked == true
                //                          select Convert.ToInt32(childNode.Tag)).ToList();

                searchParam.PayerTypeID = Convert.ToInt32(cboPayer.SelectedValue);
                searchParam.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
                searchParam.DepartmentContactID = Convert.ToInt32(comboDepartmentContact.SelectedValue);

                searchParam.FlagTypeIDs = null;
                //searchParam.FlagTypeIDs = string.Join(",", selectedFlagTypeIDs);
                searchParam.BillingTypeIDs = string.Join(",", selectedBillingTypeIDs);

                searchParam.GroupIds = uCtrlGroupListForUser1.GetSelectedGroupIDs();
                searchParam.InvoiceNumber = txtInvoiceNumber.Text;
                searchParam.BatchNumber = txtBatchID.Text;

                DisplayProgressBar(true);

                //  journalInstance.SearchJournal(searchParam);
                journalInstance.SearchClientInvoiceJournal(searchParam);

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

            this.TaskGrid.DataSource = journalData.journalDetail;

            GridColumnSortInfo[] sortInfo = { 
                new GridColumnSortInfo(TaskGridView.Columns["Client"], DevExpress.Data.ColumnSortOrder.Ascending)};

            TaskGridView.SortInfo.ClearAndAddRange(sortInfo, 1);
            //TaskGridView.ExpandAllGroups();

            TaskGridView.Columns["JournalID"].Visible = false;
            TaskGridView.Columns["MainJournalID"].Visible = false;
            TaskGridView.Columns["IsMovedTo"].Visible = false;
            TaskGridView.Columns["JournalTypeID"].Visible = false;
            TaskGridView.Columns["ClientID"].Visible = false;
          //  TaskGridView.Columns["ServiceTaskID"].Caption = "Task ID";
            TaskGridView.Columns["ServiceTaskID"].Caption = "ID";




            TaskGridView.Columns["MainJournalID"].Visible = false;
            if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
            {
                TaskGridView.Columns["Amount"].Caption = "Amount(" + BusinessRule.Utilities.CurrencySign + ")";
            }

            this.PaymentGrid.DataSource = journalData.journalPayment;
            PaymentGridView.Columns["Amount"].Caption = "Amount(" + BusinessRule.Utilities.CurrencySign + ")";
            PaymentGridView.Columns["MainJournalID"].Visible = false;
            PaymentGridView.Columns["PaymentTypeID"].Visible = false;
            PaymentGridView.Columns["CreatedBy"].Visible = false;
            PaymentGridView.Columns["TransactionDate"].Caption = "Transaction Date";
            PaymentGridView.Columns["InsertedBy"].Caption = "Transaction By";




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

            if (this.BatchGridView.Columns.ColumnByName("ExportToDrData") == null)
            {
                this.BatchGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = " ",
                    Name = "ExportToDrData",
                    FieldName = "ExportToDrData",
                    Visible = true,
                    UnboundType = DevExpress.Data.UnboundColumnType.Object,
                    VisibleIndex = 0,
                    Width = 25,
                    MaxWidth = 25,
                    ToolTip = "Export to drData",
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

        private void uctrlFranchise1_OnSelectedFranchiseChanged(object sender, EventArgs e)
        {
            try
            {
                int franchiseid = -1;
                if (this.uctrlFranchise1.SelectedFranchiseID != null)
                    franchiseid = Convert.ToInt32(this.uctrlFranchise1.SelectedFranchiseID);

                uCtrlGroupListForUser1.DisplayUserGroup(null, franchiseid);
                this.labelX6.Text = Common.FranchiseInfo.GetFranchiseGroupTerm(franchiseid) + ":";
                PayerTerm = Common.FranchiseInfo.GetFranchisePayerTerm(franchiseid);
                lblPayerType.Text = PayerTerm + ":";
                uctrlUserSearchClient.FranchiseID = franchiseid;
                SetDateSearchCriteria();
                PopulateDepartmentContact();

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void addPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void advTreeStatusType_MouseClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        if (advFlagTree.SelectedNode == null)
        //            return;

        //        int checkednodes = 0;
        //        if (advFlagTree.SelectedNode.Text == "All")
        //        {
        //            bool checkedState = advFlagTree.SelectedNode.Checked;
        //            foreach (DevComponents.AdvTree.Node cNode in advFlagTree.SelectedNode.Nodes)
        //            {
        //                foreach (DevComponents.AdvTree.Node cTNode in cNode.Nodes)
        //                {
        //                    cTNode.Checked = checkedState;
        //                }
        //                cNode.Checked = checkedState;
        //            }
        //        }
        //        else
        //        {
        //            if (advFlagTree.SelectedNode.Level == 1 && advFlagTree.SelectedNode.Nodes.Count > 0)
        //            {
        //                foreach (DevComponents.AdvTree.Node cNode in advFlagTree.SelectedNode.Nodes)
        //                {
        //                    cNode.Checked = advFlagTree.SelectedNode.Checked;
        //                }
        //            }
        //            else if (advFlagTree.SelectedNode.Level == 2)
        //            {
        //                DevComponents.AdvTree.Node pNode = advFlagTree.SelectedNode.Parent;
        //                checkednodes = 0;
        //                foreach (DevComponents.AdvTree.Node cNode in pNode.Nodes)
        //                {
        //                    if (cNode.Checked)
        //                        checkednodes++;
        //                }
        //                pNode.Checked = !(checkednodes < pNode.Nodes.Count);
        //            }

        //            checkednodes = 0;
        //            foreach (DevComponents.AdvTree.Node cNode in nodeAllStatus.Nodes)
        //            {
        //                if (cNode.Level == 1)

        //                    if (cNode != nodeAllStatus && cNode.Checked)
        //                        checkednodes++;
        //            }
        //            nodeAllStatus.Checked = !(checkednodes < nodeAllStatus.Nodes.Count);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ApplicationExceptions.HandleAppExc(ex);
        //    }
        //}              
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

            //DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

            //if (jor == null)
            //    return;


            int MainJournalID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "MainJournalID"));
            int BillingTypeID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "BillingTypeID"));

            DateTime GeneratedDate = Convert.ToDateTime(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "Insertedat"));

            if (MainJournalID <= 0)
                return;



            using (frmPayment obj = new frmPayment(Convert.ToDecimal(textNetAmount.Text), Convert.ToDecimal(textAmountRecived.Text), BillingTypeID, EUserType.Client, journalType, MainJournalID, GeneratedDate))
            {
                obj.Text = journalType.ToString();
                if (obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    journalInstance.AddJournalPayment(obj.LstJournalPayment);

                    ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(MainJournalID);
                    //ViewJournalSearchResultByID getjournalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                    SetInvoiceDetailgrid(getjournalDetail);

                }
            };
        }

        private void TaskGrid_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                AddImageColumnsToTask();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void TaskGridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
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
                            e.Value = (Bitmap)imageListGrid.Images["Expense"];
                        }
                        break;
                    case WageExpenseSearchResultType.HomeHelpExpense:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Expense"];
                        }
                        break;
                    case WageExpenseSearchResultType.Wages:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Wages"];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void cboPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCompanyDepartments();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDepartmentContact();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TaskGridView.SelectedRowsCount <= 0)
                {
                    return;
                }

                DataModel.Journal jor = this.TaskGridView.GetRow(this.TaskGridView.GetSelectedRows()[0]) as DataModel.Journal;

                if (jor == null)
                    return;

                using (frmJournalFlag objFlag = new frmJournalFlag(jor.MainJournalID, jor.ClientID))
                {
                    objFlag.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void BatchGridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                DataRowView dr = e.Row as DataRowView;
                DataModel.MainJournal jor = e.Row as DataModel.MainJournal;

                //if (jor == null)
                //    return;
                if (dr == null)
                    return;
                eJournalStatusTypeID statusID = (eJournalStatusTypeID)dr.Row["JournalStatusID"];//(eJournalStatusTypeID)jor.JournalStatusID;
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
                if (e.Column.FieldName.Equals("ExportToDrData", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Convert.ToBoolean(dr.Row["IsExportToDrData"]))
                    {
                        e.Value = (Bitmap)imageListGrid.Images["Exported"];

                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void BatchGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (this.BatchGridView.SelectedRowsCount <= 0)
                {
                    return;
                }

                // DataModel.MainJournal jor = this.BatchGridView.GetRow(this.BatchGridView.GetSelectedRows()[0]) as DataModel.MainJournal;

                int MainJournalID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "MainJournalID"));



                if (MainJournalID < 0)
                    return;
                ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(MainJournalID);

                //if (jor == null)
                //    return;
                //ViewJournalSearchResultByID journalDetail = journalInstance.SearchJournalByID(jor.MainJournalID);

                SetInvoiceDetailgrid(journalDetail);

                DateTime InvoiceGeneratedAt = Convert.ToDateTime(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "Insertedat"));

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
                            e.Value = (Bitmap)imageListGrid.Images["Discount"];
                        }
                        break;
                    case ePaymentTypeID.Discount:
                        {
                            e.Value = (Bitmap)imageListGrid.Images["Discount1"];
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

            uctrlUserSearchClient.FranchiseID = uctrlFranchise1.SelectedFranchiseID;
            uctrlUserSearchClient.UserID = -1;
            uctrlUserSearchClient.UserName = "";
            //dateTimeFrom.Value = DateTime.Today.Date;
            //dateTimeTo.Value = DateTime.Today.Date;
            comboDepartmentContact.SelectedIndex = 0;
            cboPayer.SelectedIndex = 0;
            cboDepartment.SelectedIndex = 0;

            BatchGrid.DataSource = null;
            TaskGrid.DataSource = null;
            PaymentGrid.DataSource = null;
            //buttonSearch.Enabled = false;
            textAmountRecived.Text = string.Empty;
            textInvoiceDate.Text = string.Empty;
            textNetAmount.Text = string.Empty;
            textRemainingBalance.Text = string.Empty;
            btnDelete.Enabled = false;
            txtBatchID.Text = "";
            txtInvoiceNumber.Text = "";
            SetDateSearchCriteria();
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


                    if ((int)ReportFor.LB == Settings.Obj.General[0].HomeHelpReportFor)
                    {
                        reportViewer.Text = "Invoice/Journal Report";
                    }
                    else
                    {
                        reportViewer.Text = "Invoice Report";
                    }
                    reportViewer.PrintingSystem = ps;
                    reportViewer.MdiParent = this.ParentForm;
                    reportViewer.Show();
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
                int _billingTypeID = Convert.ToInt32(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "BillingTypeID"));

                bool _IsExportedToNetSuite = Convert.ToBoolean(this.BatchGridView.GetRowCellValue(this.BatchGridView.GetSelectedRows()[0], "ExportToNetSuite"));
                string msg = string.Empty;
                if ((int)ReportFor.LB != Settings.Obj.General[0].HomeHelpReportFor)
                {
                    msg = "Invoice Number";
                }
                else
                {
                    msg = "Invoice/Journal Number";
                    if (_IsExportedToNetSuite)
                    {
                        Messages.Information("" + msg + "  cannot be deleted once exported to NetSuite.");
                        return;
                    }
                }
              
              
                if (MainJournalID > 0)
                {
                    if (XtraMessageBox.Show("Are you sure you want to delete this " + msg + " ? If you delete this " + msg + " it will be completely removed \nfrom the system and all tasks will revert to a status of Unexported.\nThe " + msg + " will have to be re-generated if you want to generate" + msg + " for these tasks.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (frmInvoiceDeleteReason obj = new frmInvoiceDeleteReason())
                        {

                            if (obj.ShowDialog() == DialogResult.OK)
                            {

                                journalInstance.DeleteInvoice(MainJournalID, obj.Reason, _billingTypeID,BusinessRule.Utilities.LoggedinUserId);

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

        private void BatchGridView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {


            //JournelDetail.Columns["ClientID"].OptionsColumn.AllowShowHide = false;
            //JournelDetail.Columns["MainJournalID"].Caption = "Invoice Number";
            //JournelDetail.Columns["JournalID"].Visible = false;
            //JournelDetail.Columns["ClientID"].Visible = false;
            //JournelDetail.Columns["IsMovedTo"].Visible = false;
            //JournelDetail.Columns["Flagged"].Visible = false;




        }

        private void BatchGrid_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = (e.View as GridView);

            if (view.IsDetailView == false)
                return;


            if ((int)ReportFor.LB != Settings.Obj.General[0].HomeHelpReportFor)
            {
                view.Columns["InvoiceNumber"].Caption = "Invoice Number";
            }
            else
            {
                view.Columns["InvoiceNumber"].Caption = "Invoice/Journal Number";
            }
            //view.Columns["MainJournalID"].Caption = "Invoice Number";
         
            view.Columns["MainJournalID"].Visible = false;
            view.Columns["JournalID"].Visible = false;
            view.Columns["ClientID"].Visible = false;
            view.Columns["IsMovedTo"].Visible = false;
            view.Columns["Flagged"].Visible = false;
            view.Columns["Notes"].Visible = false;
            view.Columns["IsMovedTo"].Visible = false;
            view.Columns["JournalTypeID"].Visible = false;

            int _franchiseID = -1;
            if (uctrlFranchise1.SelectedFranchiseID != null)
                _franchiseID = (int)uctrlFranchise1.SelectedFranchiseID;

            view.Columns["Client"].Caption = Common.FranchiseInfo.GetFranchiseClientWorkTerm(_franchiseID);
            view.Columns["HomeHelp"].Caption = Common.FranchiseInfo.GetFranchiseWorkForceTerm(_franchiseID);
            view.Columns["ServiceTaskID"].Caption = "ID";
            if (!string.IsNullOrEmpty(BusinessRule.Utilities.CurrencySign))
            {
                view.Columns["Amount"].Caption = "Amount(" + BusinessRule.Utilities.CurrencySign + ")";
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

        private void btnAddDiscount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void buttonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.TaskGridView.SelectedRowsCount <= 0)
                {
                    return;
                }

                DataModel.Journal jor = this.TaskGridView.GetRow(this.TaskGridView.GetSelectedRows()[0]) as DataModel.Journal;

                if (jor == null)
                    return;

                using (frmJournalFlag objFlag = new frmJournalFlag(jor.MainJournalID, jor.ClientID))
                {
                    objFlag.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                if (e.SelectedControl != this.BatchGrid)
                    return;

                ToolTipControlInfo info = null;
                //Get the view at the current mouse position
                GridView view = this.BatchGrid.GetViewAt(e.ControlMousePosition) as GridView;
                if (view == null)
                    return;

                //Get the view's element information that resides at the current position
                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                //Display a hint for row indicator cells
                //  hi.HitTest = GridHitTest.RowCell;

                if (hi.HitTest == GridHitTest.RowCell)
                {
                    //An object that uniquely identifies a row indicator cell
                    object o = hi.RowHandle.ToString();

                    DataModel.MainJournal jor = this.BatchGridView.GetRow(hi.RowHandle) as DataModel.MainJournal;
                    DataRowView dr = this.BatchGridView.GetRow(hi.RowHandle) as DataRowView;
                    if (dr == null)
                        return;
                    string text = "Row " + hi.RowHandle.ToString();

                    if (hi.Column.FieldName.Equals("ExportToDrData", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (Convert.ToBoolean(dr.Row["IsExportToDrData"]))
                        {
                            info = new ToolTipControlInfo(o, "Export to DrData");

                            info.SuperTip = new SuperToolTip();
                            info.SuperTip.AllowHtmlText = new DefaultBoolean();
                            info.ToolTipType = ToolTipType.SuperTip;

                            info.Text = "Export to DrData";
                            info.ToolTipImage = imageListGrid.Images["Exported"];
                            info.Title = "Exported Status";
                        }
                    }

                    if (info != null)
                        e.Info = info;
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void frmClientJournal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void txtBatchID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buttonSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void frmClientJournal_Load(object sender, EventArgs e)
        {

        }

        public void Dispose()
        {
            try
            {
                this.Dispose(true);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (uctrlFranchise1 != null)
                    {
                        this.uctrlFranchise1.OnSelectedFranchiseChanged -= this.uctrlFranchise1_OnSelectedFranchiseChanged;
                        this.uctrlFranchise1.Dispose();
                        this.uctrlFranchise1 = null;
                    }
                    if (journalInstance != null)
                    {
                        journalInstance.onSearchJournalCompleted -= journalInstance_onSearchJournalCompleted;
                        journalInstance.onSearchClientInvoiceJournal -= journalInstance_onSearchClientInvoiceJournal;
                        journalInstance.Dispose();
                        journalInstance = null;
                    }

                    if (uCtrlGroupListForUser1 != null)
                    {
                        uCtrlGroupListForUser1.Dispose();
                        uCtrlGroupListForUser1 = null;
                    }
                    //if()


                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void cboPayer_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cboPayer.DataSource != null)
                {
                    List<DataModel.Company> list = (List<DataModel.Company>)cboPayer.DataSource;

                    if (list != null && list.Count > 0)
                    {
                        string MaxLengthText = list.OrderByDescending(x => x.CompanyName.Length).FirstOrDefault().CompanyName;

                        Graphics g = cboPayer.CreateGraphics();
                        float largestSize = 0;

                        SizeF textSize = g.MeasureString(MaxLengthText, cboPayer.Font);
                        if (textSize.Width > largestSize)
                            largestSize = textSize.Width;

                        if (largestSize > 0)
                            cboPayer.DropDownWidth = (int)largestSize + 30;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartment.DataSource != null)
                {
                    List<DataModel.CompanyDepartment> list = (List<DataModel.CompanyDepartment>)cboDepartment.DataSource;

                    if (list != null && list.Count > 0)
                    {
                        string MaxLengthText = list.OrderByDescending(x => x.DepartmentName.Length).FirstOrDefault().DepartmentName;

                        Graphics g = cboDepartment.CreateGraphics();
                        float largestSize = 0;

                        SizeF textSize = g.MeasureString(MaxLengthText, cboDepartment.Font);
                        if (textSize.Width > largestSize)
                            largestSize = textSize.Width;

                        if (largestSize > 0)
                            cboDepartment.DropDownWidth = (int)largestSize + 30;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void comboDepartmentContact_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (comboDepartmentContact.DataSource != null)
                {
                    List<DataModel.DepartmentContact> list = (List<DataModel.DepartmentContact>)comboDepartmentContact.DataSource;

                    if (list != null && list.Count > 0)
                    {
                        string MaxLengthText = list.OrderByDescending(x => x.ContactName.Length).FirstOrDefault().ContactName;

                        Graphics g = comboDepartmentContact.CreateGraphics();
                        float largestSize = 0;

                        SizeF textSize = g.MeasureString(MaxLengthText, comboDepartmentContact.Font);
                        if (textSize.Width > largestSize)
                            largestSize = textSize.Width;

                        if (largestSize > 0)
                            comboDepartmentContact.DropDownWidth = (int)largestSize + 30;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

    }
}
