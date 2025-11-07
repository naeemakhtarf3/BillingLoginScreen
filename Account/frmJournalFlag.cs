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
    public partial class frmJournalFlag : DevExpress.XtraEditors.XtraForm
    {
        BusinessRule.Journal journalInstance;
        List<DataModel.JournalFlag> accountFlagList;
        int _mainJournalID;
        int _clientID;
        public frmJournalFlag(int mainJournalID,int clientID)
        {
            InitializeComponent(); 

            if (BusinessRule.Utilities.IsDesignMode)
                return;

            _mainJournalID = mainJournalID;
            _clientID = clientID;

            journalInstance = new BusinessRule.Journal();

            FillFlagTypes();

        }
        private void FillFlagTypes()
        {
            try
            {
                grdList.Rows.Clear();
                accountFlagList = journalInstance.SearchJournalFlag(_mainJournalID,_clientID);

                foreach (DataModel.JournalFlag cLog in accountFlagList)
                {
                    grdList.Rows.Add(cLog.Flag, cLog.Notes, cLog.FlagID, cLog.JournalFlagID);
                }

                cmbTypes.DataSource = Lookup.Cache.AcountFlag;
                cmbTypes.DisplayMember = "Name";
                cmbTypes.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnSaveNotes_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();               

                if (string.IsNullOrEmpty(textBoxNotes.Text.Trim()))
                {
                    errorProvider1.SetError(textBoxNotes, "Notes required.");
                    textBoxNotes.Focus();
                    return;
                }

                if (btnCancel.Enabled == false)
                {
                    grdList.Rows.Add(cmbTypes.Text, textBoxNotes.Text, Convert.ToInt32(cmbTypes.SelectedValue), -1);
                }
                else //update
                {
                    if (grdList.SelectedRows.Count > 0)
                    {
                        grdList.SelectedRows[0].Cells["Notes"].Value = textBoxNotes.Text;
                        grdList.SelectedRows[0].Cells["Type"].Value = cmbTypes.SelectedText;
                        grdList.SelectedRows[0].Cells["LogTypeID"].Value = Convert.ToInt32(cmbTypes.SelectedValue);
                    }
                    btnCancel.Enabled = false;
                    btnRemoveNotes.Enabled = true;
                    btnSaveNotes.Text = "Add";
                    grdList.Enabled = true;
                }
                textBoxNotes.Text = string.Empty;
                cmbTypes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnRemoveNotes_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdList.SelectedRows.Count > 0)
                {
                    int JournalFlagID = Convert.ToInt32(grdList.SelectedRows[0].Cells["ServiceTaskLogID"].Value);
                    if (JournalFlagID > 0 && accountFlagList != null && accountFlagList.Count > 0)
                    {
                        var temp = from stl in accountFlagList
                                   where stl.JournalFlagID == JournalFlagID
                                   select stl;
                        if (temp != null)
                        {
                            temp.ToList<DataModel.JournalFlag>()[0].IsDeleted = true;
                        }
                    }

                    grdList.Rows.Remove(grdList.SelectedRows[0]);
                }
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancel.Enabled = false;
                btnRemoveNotes.Enabled = true;
                btnSaveNotes.Text = "Add";
                grdList.Enabled = true;
                textBoxNotes.Text = string.Empty;
                cmbTypes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                BusinessRule.ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
               
                if (btnCancel.Enabled == true)
                {
                    errorProvider1.SetError(btnCancel, "Update / Cancel the record first.");
                    btnCancel.Focus();
                    return;
                }

               
                List<DataModel.JournalFlag> flagList = new List<DataModel.JournalFlag>();

                foreach (DataGridViewRow dgRow in grdList.Rows)
                {
                    int journalFlagID = Convert.ToInt32(dgRow.Cells["ServiceTaskLogID"].Value);
                    flagList.Add(new DataModel.JournalFlag()
                    {
                        JournalFlagID = journalFlagID,
                        MainJournalID = _mainJournalID,
                        ClientID = _clientID,
                        Notes = Convert.ToString(dgRow.Cells["Notes"].Value),
                        FlagID = Convert.ToInt32(dgRow.Cells["LogTypeID"].Value),
                        CreatedBy =BusinessRule.Utilities.LoggedinUserId,
                        CreatedAt =DateTime.Now,
                        IsDeleted =false,
                    });

                    flagList.AddRange(accountFlagList.FindAll(m => m.IsDeleted == true));
                }

                journalInstance.AddJournalFlag(flagList);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ApplicationExceptions.HandleAppExc(ex);
            }
        }

        private void grdList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grdList.SelectedRows.Count == 0)
                    return;


                cmbTypes.SelectedValue = cmbTypes.FindStringExact(Convert.ToString(grdList.SelectedRows[0].Cells["Type"].Value));
                textBoxNotes.Text = Convert.ToString(grdList.SelectedRows[0].Cells["Notes"].Value);
                textBoxNotes.Tag = Convert.ToInt32(grdList.SelectedRows[0].Cells["ServiceTaskLogID"].Value);
                btnCancel.Enabled = true;
                btnRemoveNotes.Enabled = false;
                btnSaveNotes.Text = "Update";
                btnSaveNotes.ToolTip = "Update";
                grdList.Enabled = false;
            }
            catch (Exception ex)
            {
                BusinessRule.ApplicationExceptions.HandleAppExc(ex);
            }
        }
    }
}
