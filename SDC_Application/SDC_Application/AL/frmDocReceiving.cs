using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmDocReceiving : Form
    {
        #region Class Variables

        AutoComplete objauto = new AutoComplete();
        LanguageConverter Lang = new LanguageConverter();
        DocReceiving DocRc = new DocReceiving();

        #endregion

        #region Default Constructor

        public frmDocReceiving()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmDocReceiving_Load(object sender, EventArgs e)
        {
            // Load Mouza List 
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString(), cboMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + UsersManagments._Tehsilid.ToString(), cboMouzaSearch, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("proc_Get_DocumentTypes", cboDocType, "DocumentTypeDescription", "DocumentTypeID");
        }

        #endregion

        #region Language Auto Conversion on Key Press Event

        private void ConvertLang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
        }

        #endregion

        #region Key press restriction numeric only

        private void txtNumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion

        #region Save Button Click Event for Saving Document Receiving Record
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string retVal=DocRc.SaveDocReceiving(txtRcId.Text, UsersManagments._Tehsilid.ToString(), cboMouza.SelectedValue.ToString(), dtpReceivingDate.Value.ToShortDateString(), txtDocNo.Text.Trim(), cboDocType.SelectedValue.ToString(), txtNoOfDocs.Text.Trim(), txtNoOfPages.Text.Trim(), txtDocDetails.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "1");
                if (retVal != "" && retVal != "Null")
                {
                    MessageBox.Show("دستویز محفوظ ہو گیا۔");
                    ResetEntryControles();
                    this.GetDocRecByDate(dtpReceivingDate.Value.ToShortDateString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Reset Doc Entry

        private void ResetEntryControles()
        {
            txtDocDetails.Clear();
            txtDocNo.Clear();
            txtNoOfDocs.Clear();
            txtNoOfPages.Clear();
            cboMouza.SelectedValue = 0;
            cboDocType.SelectedValue = 0;
            this.txtRcId.Text = "-1";
            //dtpReceivingDate.Value = DateTime.Now;
        }

        #endregion

        #region Receiving Date Value Changed Event

        private void dtpReceivingDate_ValueChanged(object sender, EventArgs e)
        {
            GetDocRecByDate(dtpReceivingDate.Value.ToShortDateString());
        }

        #endregion

        #region Get Doc Received By Date

        private void GetDocRecByDate(string Date)
        {
            try
            {
                DataTable dt = DocRc.GetDocReceivedByDate(Date);
                this.gridviewRcByDate.DataSource = dt;
                if (dt != null)
                {
                    gridviewRcByDate.Columns["DocumentNo"].HeaderText = "دستویز نمبر";
                    //gridviewRcByDate.Columns["ReceivingDate"].HeaderText = "تاریخ";
                    gridviewRcByDate.Columns["No_of_Records"].HeaderText = "تعداد دستویز";
                    gridviewRcByDate.Columns["No_of_Pages"].HeaderText = "تعداد صفحات";
                    gridviewRcByDate.Columns["ReceivingRemarks"].HeaderText = "تفصیل دستویز";

                    gridviewRcByDate.Columns["DocumentTypeId"].Visible = false;
                    gridviewRcByDate.Columns["MozaId"].Visible = false;
                    gridviewRcByDate.Columns["ReceivingId"].Visible = false;
                    gridviewRcByDate.Columns["RecStatus"].Visible = false;
                    gridviewRcByDate.Columns["ReceivingDate"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region gridviewDocRecByDate Cell Click Event

        private void gridviewRcByDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    this.txtDocDetails.Text = g.SelectedRows[0].Cells["ReceivingRemarks"].Value.ToString();
                    txtDocNo.Text = g.SelectedRows[0].Cells["DocumentNo"].Value.ToString();
                    txtNoOfDocs.Text = g.SelectedRows[0].Cells["No_of_Records"].Value.ToString();
                    txtNoOfPages.Text = g.SelectedRows[0].Cells["No_of_Pages"].Value.ToString();
                    cboDocType.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["DocumentTypeId"].Value.ToString());
                    cboMouza.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["MozaId"].Value.ToString());
                    this.txtRcId.Text = g.SelectedRows[0].Cells["ReceivingId"].Value.ToString();
                }

                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                        row.Cells["colSel"].Value = 1;
                    else
                        row.Cells["colSel"].Value = 0;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Search Doc Received
 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string DocNo = txtDocNoSearch.Text.Trim();
                string sDate =dtpDateStart.Checked?dtpDateStart.Value.ToShortDateString():"0";
                string eDate = dtpDateEnd.Checked? dtpDateEnd.Value.ToShortDateString():"0";
                string MouzaId = cboMouzaSearch.SelectedValue.ToString();
                DataTable dt = DocRc.GetDocReceivedByDateMozaDocNo(DocNo, sDate, eDate, MouzaId);
                gridveiwDocs.DataSource = dt;
                if (dt != null)
                {
                    gridveiwDocs.Columns["DocumentNo"].HeaderText = "دستویز نمبر";
                    //gridviewRcByDate.Columns["ReceivingDate"].HeaderText = "تاریخ";
                    gridveiwDocs.Columns["No_of_Records"].HeaderText = "تعداد دستویز";
                    gridveiwDocs.Columns["No_of_Pages"].HeaderText = "تعداد صفحات";
                    gridveiwDocs.Columns["ReceivingRemarks"].HeaderText = "تفصیل دستویز";

                    gridveiwDocs.Columns["DocumentTypeId"].Visible = false;
                    gridveiwDocs.Columns["MozaId"].Visible = false;
                    gridveiwDocs.Columns["ReceivingId"].Visible = false;
                    gridveiwDocs.Columns["ActivityStatus"].Visible = false;
                    gridveiwDocs.Columns["ReceivingDate"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region gridviewDocs Cell Click Event

        private void gridveiwDocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                string status = gridveiwDocs.SelectedRows[0].Cells["ActivityStatus"].Value.ToString();
                txtReceivingIdForUpdate.Text = gridveiwDocs.SelectedRows[0].Cells["ReceivingId"].Value.ToString();
                if (status == "1")
                    rbRecieved.Checked = true;
                else if (status == "2")
                    rbInProcess.Checked = true;
                else if (status == "3")
                    rbPending.Checked = true;
                else
                    rbComplete.Checked = true;

                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                        row.Cells["ColCheck"].Value = 1;
                    else
                        row.Cells["ColCheck"].Value = 0;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Update Document Status

        private void btnSaveDocStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string RcStatus = rbRecieved.Checked ? "1" : rbInProcess.Checked ? "2" : rbPending.Checked ? "3" : "4";
                string retVal=DocRc.UpdateDocStatus(txtReceivingIdForUpdate.Text, RcStatus);
                if (retVal != null)
                {
                    MessageBox.Show("دستویز محفوظ ہو گیا۔");
                    txtReceivingIdForUpdate.Text = "-1";
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        #endregion

        #region Button New Click Event

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ResetEntryControles();
        }

        #endregion
    }
}
