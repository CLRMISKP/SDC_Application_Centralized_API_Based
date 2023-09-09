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
        datagrid_controls objdatagrid = new datagrid_controls();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        Intiqal Iq = new Intiqal();
        public string DispatchId { get; set; }
        DataTable dt = new DataTable();
        BL.Malikan_n_Khattajat obj = new BL.Malikan_n_Khattajat();
        BL.frmToken objbusines = new BL.frmToken();
        Intiqal Intiqal = new Intiqal();
        UserMangement a = new UserMangement();
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
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
            
            // Load Mouza List 
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cboMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cboMouzaSearch, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbRegMoza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbRegSearchMoza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbRegUpdateMoza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("proc_Get_DocumentTypes", cboDocType, "DocumentTypeDescription", "DocumentTypeID");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cboMouzaUpdate, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("proc_Get_DocumentTypes", cboDocTypeUpdate, "DocumentTypeDescription", "DocumentTypeID");
            objauto.FillCombo("Proc_Self_Get_Letter_List" + "'R'", cbLetterNo, "number", "RegFardDispatchMainId");
            objauto.FillComboWithTopIndex("Proc_Self_Get_SR_List "+ SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbSR, "SRUrduName", "SRId");
            objauto.FillComboWithTopIndex("Proc_Self_Get_SR_List "+ SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbRegUpdateSR, "SRUrduName", "SRId");
            this.GetRegReceivedByDate(DateTime.Now.ToShortDateString());
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
                if(cboMouza.SelectedIndex==0)
                {
                    MessageBox.Show("موضع سیلیکٹ کریں");
                    cboMouza.Focus();
                    return;
                }
                else if (cboDocType.SelectedIndex==0)
                {
                    MessageBox.Show("قسم دستاویز سیلیکٹ کریں");
                    cboDocType.Focus();
                    return;
                }
                else if (txtDocNo.Text.Trim() == "")
                {
                    MessageBox.Show("دستاویز نمبر درج کریں");
                    txtDocNo.Focus();
                    return;
                }
                else if (txtNoOfPages.Text.Trim() == "")
                {
                    MessageBox.Show("صفحات درج کریں");
                    txtNoOfPages.Focus();
                    return;
                }
                else if (dtpReceivingDate.Value>DateTime.Now)
                {
                    MessageBox.Show("درست تاریخ وصولی درج کریں");
                    dtpReceivingDate.Focus();
                    return;
                }
                string retVal=DocRc.SaveDocReceiving(txtRcId.Text, UsersManagments._Tehsilid.ToString(), cboMouza.SelectedValue.ToString(), dtpReceivingDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtDocNo.Text.Trim(), cboDocType.SelectedValue.ToString(), txtTitle.Text.Trim(), txtNoOfPages.Text.Trim(), txtDocDetails.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "1");
                if (retVal != "" && retVal != "Null")
                {
                    MessageBox.Show("دستویز محفوظ ہو گیا۔");
                    ResetEntryControles();
                    this.GetDocRecByDate(dtpReceivingDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
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
            txtTitle.Clear();
            txtNoOfPages.Clear();
            cboMouza.SelectedValue = 0;
            cboDocType.SelectedValue = 0;
            this.txtRcId.Text = "-1";
            //dtpReceivingDate.Value = DateTime.Now;
        }

        private void ResetUpdateControles()
        {
            txtDocNoUpdate.Clear();
            txtReceivingIdForUpdate.Text = "-1";
            cboMouzaUpdate.SelectedIndex = 0;
            cboDocTypeUpdate.SelectedIndex = 0;
            txtNoOfPagesUpdate.Clear();
            dtpReceivingDateUpdate.Value = DateTime.Now;
            txtTitleUpdate.Clear();
            txtKafiyatUpdate.Clear();
            txtIntiqalNoUpdate.Clear();
            rbRecieved.Checked = false;
            rbPending.Checked = false;
            rbComplete.Checked = false;
           
            //dtpReceivingDate.Value = DateTime.Now;
        }

        #endregion

        #region Receiving Date Value Changed Event

        private void dtpReceivingDate_ValueChanged(object sender, EventArgs e)
        {
            GetDocRecByDate(dtpReceivingDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
        }

        #endregion

        #region Get Doc Received By Date

        private void GetDocRecByDate(string Date)
        {
            try
            {
                DataTable dt = DocRc.GetDocReceivedByDate(Date);
                this.gridviewRcByDate.DataSource = dt;
                    gridviewRcByDate.Columns["DocumentNo"].HeaderText = "دستویز نمبر";
                    //gridviewRcByDate.Columns["ReceivingDate"].HeaderText = "تاریخ";
                    gridviewRcByDate.Columns["Title"].HeaderText = "عنوان";
                    gridviewRcByDate.Columns["No_of_Pages"].HeaderText = "تعداد صفحات";
                    gridviewRcByDate.Columns["ReceivingRemarks"].HeaderText = "تفصیل دستویز";

                    gridviewRcByDate.Columns["DocumentTypeId"].Visible = false;
                    gridviewRcByDate.Columns["MozaId"].Visible = false;
                    gridviewRcByDate.Columns["ReceivingId"].Visible = false;
                    gridviewRcByDate.Columns["RecStatus"].Visible = false;
                    gridviewRcByDate.Columns["ReceivingDate"].Visible = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region Get Registry Received By Date

        private void GetRegReceivedByDate(string Date)
        {
            try
            {
                DataTable dt = DocRc.GetRegReceivedByDate(Date);
                this.grdvReg.DataSource = dt;

                grdvReg.Columns["RegNo"].DisplayIndex = 0;
                grdvReg.Columns["JildNo"].DisplayIndex = 1;
                grdvReg.Columns["RegDate"].DisplayIndex = 2;
                grdvReg.Columns["SRUrduName"].DisplayIndex = 4;
                grdvReg.Columns["Seller"].DisplayIndex = 5;
                grdvReg.Columns["Buyer"].DisplayIndex = 6;
                grdvReg.Columns["MozaNameUrdu"].DisplayIndex = 3;
                grdvReg.Columns["status"].DisplayIndex = 7;
                grdvReg.Columns["Kafiyat"].DisplayIndex = 8;

                grdvReg.Columns["RegNo"].HeaderText = "رجسٹری نمبر";
                grdvReg.Columns["JildNo"].HeaderText = "جلد نمبر";
                grdvReg.Columns["RegDate"].HeaderText = "رجسٹری تاریخ";
                grdvReg.Columns["MozaNameUrdu"].HeaderText = "موضع";
                grdvReg.Columns["SRUrduName"].HeaderText = "سب رجسٹرار";
                grdvReg.Columns["Seller"].HeaderText = "بائع";
                grdvReg.Columns["Buyer"].HeaderText = "مشتری";
                grdvReg.Columns["status"].HeaderText = "حالت";
                grdvReg.Columns["Kafiyat"].HeaderText = "کیفیت";
                grdvReg.Columns["SRId"].Visible = false;
                
                grdvReg.Columns["MozaId"].Visible = false;
                grdvReg.Columns["ReceivingId"].Visible = false;
                grdvReg.Columns["RecStatus"].Visible = false;

                objdatagrid.colorrbackgrid(grdvReg);
                objdatagrid.gridControls(grdvReg);
                grdvReg.ColumnHeadersHeight = 20;
               

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
                   txtTitle.Text = g.SelectedRows[0].Cells["Title"].Value.ToString();
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
                ResetUpdateControles();
                string DocNo = txtDocNoSearch.Text.Trim();
                string Title = txtTitleSearch.Text.Trim();
                string sDate =dtpDateStart.Checked?dtpDateStart.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()):"0";
                string eDate = dtpDateEnd.Checked? dtpDateEnd.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()):"0";
                string MouzaId = cboMouzaSearch.SelectedValue.ToString();
                DataTable dt = DocRc.GetDocReceivedByDateMozaDocNo(DocNo, sDate, eDate, MouzaId,Title);
                gridveiwDocs.DataSource = dt;
                if (dt != null)
                {
                    gridveiwDocs.Columns["DocumentNo"].HeaderText = "دستویز نمبر";
                    gridveiwDocs.Columns["DocumentTypeDescription"].HeaderText = "قسم دستاویز";
                    gridveiwDocs.Columns["MozaNameUrdu"].HeaderText = "موضع";
                    gridveiwDocs.Columns["ReceivingDate"].HeaderText = "تاریخ وصولی";
                    gridveiwDocs.Columns["Title"].HeaderText = "عنوان";
                    gridveiwDocs.Columns["ActivityStatusUrdu"].HeaderText = "حالت";
                    gridveiwDocs.Columns["No_of_Pages"].HeaderText = "تعداد صفحات";
                    gridveiwDocs.Columns["intiqalNo"].HeaderText = "انتقال نمبر";
                    gridveiwDocs.Columns["ReceivingRemarks"].HeaderText = "تفصیل دستویز";

                    gridveiwDocs.Columns["DocumentTypeId"].Visible = false;
                    gridveiwDocs.Columns["MozaId"].Visible = false;
                    gridveiwDocs.Columns["ReceivingId"].Visible = false;
                    gridveiwDocs.Columns["ActivityStatus"].Visible = false;
                   // gridveiwDocs.Columns["ReceivingDate"].Visible = false;
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
                
                dtpReceivingDateUpdate.Value = DateTime.ParseExact(g.SelectedRows[0].Cells["ReceivingDate"].Value.ToString(), "dd-MM-yyyy", null);
                //string receivingDateStr = g.SelectedRows[0].Cells["ReceivingDate"].Value.ToString();

                txtTitleUpdate.Text = gridveiwDocs.SelectedRows[0].Cells["Title"].Value.ToString();
                txtDocNoUpdate.Text = gridveiwDocs.SelectedRows[0].Cells["DocumentNo"].Value.ToString();
                cboMouzaUpdate.SelectedValue = gridveiwDocs.SelectedRows[0].Cells["MozaId"].Value.ToString();
                cboDocTypeUpdate.SelectedValue = gridveiwDocs.SelectedRows[0].Cells["DocumentTypeId"].Value.ToString();
                txtNoOfPagesUpdate.Text = gridveiwDocs.SelectedRows[0].Cells["No_of_Pages"].Value.ToString();
                txtKafiyatUpdate.Text = gridveiwDocs.SelectedRows[0].Cells["ReceivingRemarks"].Value.ToString();

                if (status == "1")
                    rbRecieved.Checked = true;
                //else if (status == "2")
                //    rbInProcess.Checked = true;
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
                if (txtReceivingIdForUpdate.Text.ToString() != "-1")
                {
                   
                    string activityStatus = "";
                    if (rbRecieved.Checked)
                    {
                        activityStatus = "1";
                    }
                    else if (rbPending.Checked)
                    {
                        activityStatus = "3";
                    }
                    else if (rbComplete.Checked)
                    {
                        activityStatus = "4";
                    }
                    string intiqalNo = "";
                    if(txtIntiqalNoUpdate.Text.Trim()=="")
                    {
                        intiqalNo = null;
                    }
                    else
                    {
                        intiqalNo = txtIntiqalNoUpdate.Text.Trim();
                    }

                    if (cboMouzaUpdate.SelectedIndex == 0)
                    {
                        MessageBox.Show("موضع سیلیکٹ کریں");
                        cboMouzaUpdate.Focus();
                        return;
                    }
                    else if (cboDocTypeUpdate.SelectedIndex == 0)
                    {
                        MessageBox.Show("قسم دستاویز سیلیکٹ کریں");
                        cboDocTypeUpdate.Focus();
                        return;
                    }
                    else if (txtDocNoUpdate.Text.Trim() == "")
                    {
                        MessageBox.Show("دستاویز نمبر درج کریں");
                        txtDocNoUpdate.Focus();
                        return;
                    }
                    else if (txtNoOfPagesUpdate.Text.Trim() == "")
                    {
                        MessageBox.Show("صفحات درج کریں");
                        txtNoOfPagesUpdate.Focus();
                        return;
                    }
                    else if (dtpReceivingDateUpdate.Value > DateTime.Now)
                    {
                        MessageBox.Show("درست تاریخ وصولی درج کریں");
                        dtpReceivingDateUpdate.Focus();
                        return;
                    }
                    //string retVal = DocRc.SaveRegReceiving(txtUpdateRecId.Text, UsersManagments._Tehsilid.ToString(), cmbRegUpdateMoza.SelectedValue.ToString(), dtUpdateRegDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtUpdateRegNo.Text, txtUpdateJildNo.Text.Trim(), txtUpdateSeller.Text, txtUpdateBuyer1.Text, txtUpdateKafiyat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, activityStatus);
                    string retVal=DocRc.UpdateDocStatus(txtReceivingIdForUpdate.Text, cboMouzaUpdate.SelectedValue.ToString() , dtpReceivingDateUpdate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) , txtDocNoUpdate.Text , cboDocTypeUpdate.SelectedValue.ToString() ,txtTitleUpdate.Text.Trim() , txtNoOfPagesUpdate.Text.Trim(), txtKafiyatUpdate.Text.Trim(), UsersManagments.UserId.ToString(),   activityStatus, intiqalNo);
                    if (retVal != "" && retVal != "Null")
                    {
                        MessageBox.Show("دستویز محفوظ ہو گیا۔");
                        //this.GetRegReceivedByDateMozaDocNo(txtUpdateRegNo.Text.Trim(), "0", "0", "0");
                        btnSearch_Click(sender, e);
                        ResetUpdateControles();
                    }
                }
                else
                {
                    MessageBox.Show("تبدیلی کے لئے ریکارڈ سیلیکٹ کریں۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            //try
            //{
            //   // string RcStatus = rbRecieved.Checked ? "1" : rbInProcess.Checked ? "2" : rbPending.Checked ? "3" : "4";
            //    string RcStatus = rbRecieved.Checked ? "1" :  rbPending.Checked ? "3" : "4";
            //    DocRc.UpdateDocStatus(txtReceivingIdForUpdate.Text, RcStatus);
            //    txtReceivingIdForUpdate.Text = "-1";
            //    btnSearch_Click(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        #endregion

        #region Button New Click Event

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ResetEntryControles();
        }

        #endregion

        #region Button Save Registry
        private void btnRegSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRegMoza.SelectedIndex == 0)
                {
                    MessageBox.Show("موضع سیلیکٹ کریں");
                    cmbRegMoza.Focus();
                    return;
                }
               
                else if (txtRegNo.Text.Trim() == "")
                {
                    MessageBox.Show("رجسٹری نمبر درج کریں");
                    txtRegNo.Focus();
                    return;
                }
                else if (dtReg.Value > DateTime.Now)
                {
                    MessageBox.Show("درست تاریخ وصولی درج کریں");
                    dtReg.Focus();
                    return;
                }


                if (txtRegId.Text == "-1")
                {
                    string Reg = Iq.CheckRegAlreadyReceivedForRecvReg(txtRegNo.Text.Trim(), "0", dtReg.Value.Year, cboMouza.SelectedValue.ToString(), cmbSR.SelectedValue.ToString());
                    if (Reg != "-1")
                    {

                        MessageBox.Show(" رجسٹری نمبر" + txtRegNo.Text + " کا اندراج سال" + dtReg.Value.Year.ToString() + " میں ہو چکا ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
                string retVal = DocRc.SaveRegReceiving(txtRegId.Text, UsersManagments._Tehsilid.ToString(), cmbRegMoza.SelectedValue.ToString(), dtReg.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtRegNo.Text, txtJildNo.Text.Trim(), txtSeller.Text, txtBuyer.Text, txtKafiyat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "1", cmbSR.SelectedValue.ToString());
                if (retVal != "" && retVal != "Null")
                {
                   // MessageBox.Show("دستویز محفوظ ہو گیا۔");
                    txtRegNo.Clear();
                    txtJildNo.Clear();
                    cmbRegMoza.SelectedIndex = 0;
                    txtKafiyat.Clear();
                    txtSeller.Clear();
                    txtBuyer.Clear();
                    dtReg.Value = Convert.ToDateTime(DateTime.Now);
                    txtRegId.Text = "-1";
                   
                   this.GetRegReceivedByDate(DateTime.Now.ToShortDateString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnRegSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchRegNo = txtSearchRegNo.Text.Trim();
                string sDate = dtRegFrom.Checked ? dtRegFrom.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) : "0";
                string eDate = dtRegTo.Checked ? dtRegTo.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) : "0";
                string SearchMouzaId = cmbRegSearchMoza.SelectedValue.ToString();
                this.GetRegReceivedByDateMozaDocNo(SearchRegNo, sDate, eDate, SearchMouzaId);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void grdvReg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    txtRegNo.Text = g.SelectedRows[0].Cells["RegNo"].Value.ToString();
                    txtJildNo.Text = g.SelectedRows[0].Cells["JildNo"].Value.ToString();
                    txtSeller.Text = g.SelectedRows[0].Cells["Seller"].Value.ToString();
                    txtBuyer.Text = g.SelectedRows[0].Cells["Buyer"].Value.ToString();
                    txtKafiyat.Text = g.SelectedRows[0].Cells["Kafiyat"].Value.ToString();
                    //cboDocType.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["DocumentTypeId"].Value.ToString());
                    dtReg.Value = DateTime.ParseExact(g.SelectedRows[0].Cells["RegDate"].Value.ToString(), "dd-MM-yyyy", null);

                    cmbRegMoza.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["MozaId"].Value.ToString());
                    cmbSR.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["SRId"].Value.ToString());
                    txtRegId.Text = g.SelectedRows[0].Cells["ReceivingId"].Value.ToString();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void btnRegNew_Click(object sender, EventArgs e)
            {
                txtRegNo.Clear();
                txtJildNo.Clear();
                txtSeller.Clear();
                txtBuyer.Clear();
                txtKafiyat.Clear();
                
                dtReg.Value = Convert.ToDateTime(DateTime.Now);
                cmbRegMoza.SelectedIndex = 0;
                txtRegId.Text = "-1";
            }

            private void dgvRegUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    DataGridView g = sender as DataGridView;
                    if (g.SelectedRows.Count > 0)
                    {
                        txtUpdateRegNo.Text = g.SelectedRows[0].Cells["RegNo"].Value.ToString();
                        txtUpdateJildNo.Text = g.SelectedRows[0].Cells["JildNo"].Value.ToString();
                        txtUpdateSeller.Text = g.SelectedRows[0].Cells["Seller"].Value.ToString();
                        txtUpdateBuyer1.Text = g.SelectedRows[0].Cells["Buyer"].Value.ToString();
                        txtUpdateKafiyat.Text = g.SelectedRows[0].Cells["Kafiyat"].Value.ToString();
                        //cboDocType.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["DocumentTypeId"].Value.ToString());
                        dtUpdateRegDate.Value = DateTime.ParseExact(g.SelectedRows[0].Cells["RegDate"].Value.ToString(), "dd-MM-yyyy", null);
                        cmbRegUpdateSR.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["SRId"].Value.ToString());
                        cmbRegUpdateMoza.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["MozaId"].Value.ToString());
                        txtUpdateRecId.Text = g.SelectedRows[0].Cells["ReceivingId"].Value.ToString();
                        if (g.SelectedRows[0].Cells["ActivityStatus"].Value.ToString() == "1")
                       {
                           this.rbUpdateRecieve.Checked=true;
                       }
                        else if (g.SelectedRows[0].Cells["ActivityStatus"].Value.ToString() == "2")
                        {
                            this.rbUpdateComplete.Checked = true;
                        }
                        else if (g.SelectedRows[0].Cells["ActivityStatus"].Value.ToString() == "3")
                        {
                            this.rbUpdatePending.Checked = true;
                        }
                        else if (g.SelectedRows[0].Cells["ActivityStatus"].Value.ToString() == "4")
                        {
                            this.rbBackToSR.Checked = true;

                            //Get Letter Number by clickin on the cell content
                            if (e.RowIndex != -1)
                            {
                                if (dgvRegUpdate.Columns.Count > 1)
                                {
                                    if (e.ColumnIndex == dgvRegUpdate.CurrentRow.Cells["Status"].ColumnIndex)
                                    {
                                        frmMessageBox mb = new frmMessageBox();
                                        string val = Iq.GetLetterNo(dgvRegUpdate.CurrentRow.Cells["ReceivingId"].Value.ToString());
                                        mb.Width = 732;
                                        mb.Height = 170;
                                        mb.lbMessageBox.Width = 732;
                                        mb.btnOK.Location = new Point(310, 110);
                                        mb.lbMessageBox.Text = val;
                                        mb.ShowDialog();
                                    }
                                }
                            }
                        }
                        // if intiqal entered against this registry then some of its value can not be changed
                        if (g.SelectedRows[0].Cells["intiqalno"].Value.ToString().Length > 0)
                        {
                            txtUpdateRegNo.Enabled = false;
                            txtUpdateJildNo.Enabled = false;
                            dtUpdateRegDate.Enabled = false;
                            cmbRegUpdateMoza.Enabled = false;

                        }
                        else
                        {
                            txtUpdateRegNo.Enabled = true;
                            txtUpdateJildNo.Enabled = true;
                            dtUpdateRegDate.Enabled = true;
                            cmbRegUpdateMoza.Enabled = true;

                        }
                        
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void btnRegUpdate_Click(object sender, EventArgs e)
            {
                try
                {

                    if (cmbRegUpdateMoza.SelectedIndex == 0)
                    {
                        MessageBox.Show("موضع سیلیکٹ کریں");
                        cmbRegUpdateMoza.Focus();
                        return;
                    }

                    else if (txtUpdateRegNo.Text.Trim() == "")
                    {
                        MessageBox.Show("رجسٹری نمبر درج کریں");
                        txtUpdateRegNo.Focus();
                        return;
                    }
                    else if (dtUpdateRegDate.Value > DateTime.Now)
                    {
                        MessageBox.Show("درست تاریخ وصولی درج کریں");
                        dtUpdateRegDate.Focus();
                        return;
                    }

                    if (txtUpdateRecId.Text.ToString() != "-1")
                        
                    {
                        string Reg = Iq.CheckRegAlreadyReceivedForRecvReg(txtUpdateRegNo.Text, txtUpdateRecId.Text, dtUpdateRegDate.Value.Year, cmbRegMoza.SelectedValue.ToString(), cmbSR.SelectedValue.ToString());
                        if (Reg != "-1")
                        {

                            MessageBox.Show(" رجسٹری نمبر" + txtUpdateRegNo.Text + " کا اندراج سال" + dtUpdateRegDate.Value.Year.ToString() + " میں ہو چکا ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }


                        string activityStatus = "";
                        if (rbUpdateRecieve.Checked)
                        {
                            activityStatus = "1";
                        }
                        else if (rbUpdatePending.Checked)
                        {
                            activityStatus = "3";
                        }
                        else if (rbUpdateComplete.Checked)
                        {
                            activityStatus = "2";
                        }
                        string retVal = DocRc.SaveRegReceiving(txtUpdateRecId.Text, UsersManagments._Tehsilid.ToString(), cmbRegUpdateMoza.SelectedValue.ToString(), dtUpdateRegDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtUpdateRegNo.Text, txtUpdateJildNo.Text.Trim(), txtUpdateSeller.Text, txtUpdateBuyer1.Text, txtUpdateKafiyat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, activityStatus, cmbRegUpdateSR.SelectedValue.ToString());
                        if (retVal != "" && retVal != "Null")
                        {
                             MessageBox.Show("دستویز محفوظ ہو گیا۔");
                             this.GetRegReceivedByDateMozaDocNo(txtUpdateRegNo.Text.Trim(), "0", "0", "0");
                             txtUpdateRegNo.Clear();
                            txtUpdateJildNo.Clear();
                            cmbRegUpdateMoza.SelectedIndex = 0;
                            txtUpdateKafiyat.Clear();
                            txtUpdateSeller.Clear();
                            txtUpdateBuyer1.Clear();
                            dtUpdateRegDate.Value = Convert.ToDateTime(DateTime.Now);
                            txtUpdateRecId.Text = "-1";

                            //this.GetRegReceivedByDate(DateTime.Now.ToShortDateString());
                            //DocRc.GetRegReceivedByDateMozaDocNo(txtRegNo.Text.Trim(), "0", "0", "0")
                        }
                    }
                    else
                    {
                        MessageBox.Show("تبدیلی کے لئے ریکارڈ سیلیکٹ کریں۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            #region Get Registry Received By Diff Paramaters

            private void GetRegReceivedByDateMozaDocNo(string UpdateRegNo, string sDate, string eDate, string UpdateMouzaId)
            {
                try
                {
                    DataTable dt = DocRc.GetRegReceivedByDateMozaDocNo(UpdateRegNo, sDate, eDate, UpdateMouzaId);
                    dgvRegUpdate.DataSource = dt;
                    if (dt != null)
                    {
                        
                        dgvRegUpdate.Columns["RegNo"].HeaderText = "رجسٹری نمبر";
                        dgvRegUpdate.Columns["MozaNameUrdu"].HeaderText = "موضع";
                        dgvRegUpdate.Columns["SRUrduName"].HeaderText = "سب رجسٹرار";
                        dgvRegUpdate.Columns["RegDate"].HeaderText = "تاریخ رجسٹری";
                        dgvRegUpdate.Columns["JildNo"].HeaderText = "جلد نمبر";
                        dgvRegUpdate.Columns["Seller"].HeaderText = "بائع";
                        dgvRegUpdate.Columns["Buyer"].HeaderText = "مشتری";
                        dgvRegUpdate.Columns["Kafiyat"].HeaderText = "کیفیت";
                        dgvRegUpdate.Columns["Status"].HeaderText = "حالت رجسٹری";
                        dgvRegUpdate.Columns["intiqalno"].HeaderText = "انتقال نمبر";
                        dgvRegUpdate.Columns["intiqalstatus"].HeaderText = "حالت انتقال";
                        dgvRegUpdate.Columns["srId"].Visible = false;
                        dgvRegUpdate.Columns["mozaid"].Visible = false;
                        dgvRegUpdate.Columns["ReceivingId"].Visible = false;
                        dgvRegUpdate.Columns["RecStatus"].Visible = false;
                        dgvRegUpdate.Columns["ActivityStatus"].Visible = false;

                        objdatagrid.colorrbackgrid(dgvRegUpdate);
                        objdatagrid.gridControls(dgvRegUpdate);
                        dgvRegUpdate.ColumnHeadersHeight = 20;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion

            private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
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

            private void cboDocTypeUpdate_SelectedIndexChanged(object sender, EventArgs e)
            {
                
                if(cboDocTypeUpdate.SelectedValue.ToString()=="15")
                {
                txtIntiqalNoUpdate.Visible = true;
                lbIntiqalNo.Visible = true;
                }
                else
                {
                    txtIntiqalNoUpdate.Visible = false;
                    lbIntiqalNo.Visible = false;
                }
            }

            private void txtTitleSearch_KeyPress(object sender, KeyPressEventArgs e)
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

            private void txtTitleUpdate_KeyPress(object sender, KeyPressEventArgs e)
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

            private void cboMouzaSearch_KeyPress(object sender, KeyPressEventArgs e)
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

            private void cboMouzaUpdate_KeyPress(object sender, KeyPressEventArgs e)
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

            private void txtKafiyatUpdate_KeyPress(object sender, KeyPressEventArgs e)
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

            private void btnPrintMisalBadar_Click(object sender, EventArgs e)
            {

            }

            private void btnNewLetter_Click(object sender, EventArgs e)
            {
                if (DialogResult.Yes == MessageBox.Show("آپ رجسٹرار آفس کے لئے نیا ڈاک بنا رہے ہیں؟", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    dtDispatchDate.Enabled = true;
                    dtDispatchDate.Value = DateTime.Today;
                    cbLetterNo.SelectedIndex = 0;
                    btnSaveLetter.Enabled = true;
                    btnInsert.Enabled = false;
                    btnRemove.Enabled = false;
                    btnConfirm.Enabled = false;
                }


            }
            private void btnSaveLetter_Click(object sender, EventArgs e)
            {
                if (DialogResult.Yes == MessageBox.Show("کیا آپ لیٹر محفوظ کرنا چاہتے ہے؟", "محفوظ کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    string dtDispatch = dtDispatchDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    string lastId = mnk.SaveFardDispatchToRegistrar("R", dtDispatch, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    dtDispatchDate.Enabled = false;
                    objauto.FillCombo("Proc_Self_Get_Letter_List" + "'R'", cbLetterNo, "number", "RegFardDispatchMainId");
                    cbLetterNo.SelectedValue = lastId;
                    btnSave.Enabled = false;
                    btnDel.Enabled = true;
                }
            }
            public void Load_RegistryList_Saved_For_Registrar_Dispatch()
            {
                try
                {

                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_RegistryList_Registrar_Dispatch " + DispatchId);

                    DataTable outputTable = dt.Clone();

                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        outputTable.ImportRow(dt.Rows[i]);
                    }
                    grdInsertedFardat.DataSource = outputTable;
                    PopulategridSavedRegistries();
                    LbFardatNos.Text = grdInsertedFardat.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            public void PopulategridSavedRegistries()
            {
                grdInsertedFardat.Columns["RegNo"].DisplayIndex = 1;
                grdInsertedFardat.Columns["RegDate"].DisplayIndex = 2;
                grdInsertedFardat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                grdInsertedFardat.Columns["Kafiyat"].DisplayIndex = 4;

                grdInsertedFardat.Columns["RegNo"].HeaderText = "رجسٹری نمبر";
                grdInsertedFardat.Columns["RegDate"].HeaderText = "تاریخ رجسٹری";
                grdInsertedFardat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                grdInsertedFardat.Columns["Kafiyat"].HeaderText = "کیفیت";
                grdInsertedFardat.Columns["RegDispatchId"].Visible = false;
                grdInsertedFardat.Columns["ReceivingId"].Visible = false;



            }
            private void cbLetterNo_SelectionChangeCommitted(object sender, EventArgs e)
            {
                if (cbLetterNo.SelectedIndex > 0)
                {
                    DispatchId = cbLetterNo.SelectedValue.ToString();
                    Load_RegistryList_Saved_For_Registrar_Dispatch();
                    Proc_Get_Registries_List_For_Registrar();


                    dt = obj.GetRegistrarFardatStatus(DispatchId);
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            dtDispatchDate.Value = Convert.ToDateTime(row["DispatchDate"]);
                            if (row["status"].ToString() == "0")
                            {

                                btnConfirm.Enabled = true;
                                btnInsert.Enabled = true;
                                btnRemove.Enabled = true;
                            }
                            else
                            {

                                btnConfirm.Enabled = false;
                                btnInsert.Enabled = false;
                                btnRemove.Enabled = false;
                            }
                        }
                    }

                }
                else
                {
                    DispatchId = cbLetterNo.SelectedValue.ToString();
                    Load_RegistryList_Saved_For_Registrar_Dispatch();
                    btnInsert.Enabled = false;
                    btnRemove.Enabled = false;
                    btnConfirm.Enabled = false;

                }
            }

            private void chkAllToSave_CheckedChanged(object sender, EventArgs e)
            {
                if (this.grdFardToInsert.Rows.Count > 0)
                {

                    for (int i = 0; i <= grdFardToInsert.Rows.Count - 1; i++)
                    {

                        if (chkAllToSave.Checked)
                        {

                            grdFardToInsert.Rows[i].Cells["colCheckInsert"].Value = true;

                        }
                        else
                        {

                            grdFardToInsert.Rows[i].Cells["colCheckInsert"].Value = false;
                        }
                    }


                }
            }
            private void chkAllDetails_CheckedChanged(object sender, EventArgs e)
            {
                if (this.grdInsertedFardat.Rows.Count > 0)
                {

                    for (int i = 0; i <= grdInsertedFardat.Rows.Count - 1; i++)
                    {

                        if (chkAllDetails.Checked)
                        {

                            grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value = true;

                        }
                        else
                        {

                            grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value = false;
                        }
                    }


                }
            }
            private void txtRegToInsert_TextChanged(object sender, EventArgs e)
            {
                if (this.grdFardToInsert.Rows.Count > 0)
                {

                    for (int i = 0; i <= grdFardToInsert.Rows.Count - 1; i++)
                    {

                        if (grdFardToInsert.Rows[i].Cells["RegNo"].Value.ToString().Contains(txtRegToInsert.Text.Trim()))
                        {

                            grdFardToInsert.Rows[i].Visible = true;
                        }
                        else
                        {

                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdFardToInsert.DataSource];
                            currencyManager1.SuspendBinding();
                            grdFardToInsert.Rows[i].Visible = false;
                            currencyManager1.ResumeBinding();
                            grdFardToInsert.Rows[i].Visible = false;


                        }
                    }


                }
            }
            private void txtRegistryInserted_TextChanged(object sender, EventArgs e)
            {
                if (this.grdInsertedFardat.Rows.Count > 0)
                {

                    for (int i = 0; i <= grdInsertedFardat.Rows.Count - 1; i++)
                    {

                        if (grdInsertedFardat.Rows[i].Cells["RegNo"].Value.ToString().Contains(txtRegistryInserted.Text.Trim()))
                        {

                            grdInsertedFardat.Rows[i].Visible = true;
                        }
                        else
                        {

                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdInsertedFardat.DataSource];
                            currencyManager1.SuspendBinding();
                            grdInsertedFardat.Rows[i].Visible = false;
                            currencyManager1.ResumeBinding();
                            grdInsertedFardat.Rows[i].Visible = false;


                        }
                    }


                }

            }
            private void btnInsert_Click(object sender, EventArgs e)
            {


                for (int i = 0; i <= this.grdFardToInsert.Rows.Count - 1; i++)
                {
                    int b = Convert.ToInt32(grdFardToInsert.Rows[i].Cells["colCheckInsert"].Value);
                    if (b == 1)
                    {
                        bool isExists = false;


                        string ReceivingId = grdFardToInsert.Rows[i].Cells["ReceivingId"].Value.ToString();

                        //string retVal = Intiqal.GetRegistriesDispatchStatus(ReceivingId, DispatchId);
                        //if (retVal != "1")
                        //{
                        //    MessageBox.Show(retVal, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        //}

                        //else
                        //{

                        try
                        {
                            if (this.grdInsertedFardat.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in grdInsertedFardat.Rows)
                                {

                                    if (row.Cells["ReceivingId"].Value.ToString() == grdFardToInsert.Rows[i].Cells["ReceivingId"].Value.ToString())
                                    {
                                        isExists = true;
                                        break;
                                    }
                                    else
                                    {
                                        isExists = false;
                                    }
                                }

                            }

                            if (!isExists)
                            {

                                string s = obj.SaveRegistriesDispatchDetails(ReceivingId, DispatchId, UsersManagments.UserId.ToString(), UsersManagments.UserName);


                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        //}

                    }

                }
                for (int k = 0; k <= grdFardToInsert.Rows.Count - 1; k++)
                {
                    grdFardToInsert.Rows[k].Cells["colCheckInsert"].Value = 0;
                }

                this.chkAllToSave.Checked = false;
                Load_RegistryList_Saved_For_Registrar_Dispatch();
                Proc_Get_Registries_List_For_Registrar();
            }
            public void Proc_Get_Registries_List_For_Registrar()
            {
                try
                {

                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_Registries_List_For_Registrar");

                    DataTable outputTable = dt.Clone();

                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        outputTable.ImportRow(dt.Rows[i]);
                    }
                    grdFardToInsert.DataSource = outputTable;


                    Populategrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            public void Populategrid()
            {
                grdFardToInsert.Columns["RegNo"].DisplayIndex = 1;
                grdFardToInsert.Columns["Regdate"].DisplayIndex = 2;
                grdFardToInsert.Columns["MozaNameUrdu"].DisplayIndex = 3;
                grdFardToInsert.Columns["Kafiyat"].DisplayIndex = 4;

                grdFardToInsert.Columns["RegNo"].HeaderText = "رجسٹری نمبر";
                grdFardToInsert.Columns["Regdate"].HeaderText = "تاریخ رجسٹری";
                grdFardToInsert.Columns["MozaNameUrdu"].HeaderText = "موضع";
                grdFardToInsert.Columns["Kafiyat"].HeaderText = "کیفیت";

                grdFardToInsert.Columns["ReceivingId"].Visible = false;

            }
            private void grdFardToInsert_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                DataGridView g = sender as DataGridView;

                if (e.RowIndex != -1)
                {

                    if (e.ColumnIndex == this.grdFardToInsert.CurrentRow.Cells["colCheckInsert"].ColumnIndex)
                    {
                        if (Convert.ToInt32(this.grdFardToInsert.CurrentRow.Cells["colCheckInsert"].Value) == 1)
                        {
                            this.grdFardToInsert.CurrentRow.Cells["colCheckInsert"].Value = 0;
                        }
                        else
                        {
                            this.grdFardToInsert.CurrentRow.Cells["colCheckInsert"].Value = 1;
                        }
                    }
                }
            }
            private void grdInsertedFardat_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                DataGridView g = sender as DataGridView;

                if (e.RowIndex != -1)
                {

                    if (e.ColumnIndex == this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].ColumnIndex)
                    {
                        if (Convert.ToInt32(this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value) == 1)
                        {
                            this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value = 0;
                        }
                        else
                        {
                            this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value = 1;
                        }
                    }
                }
            }
            private void btnRemove_Click(object sender, EventArgs e)
            {
                DataGridView g = sender as DataGridView;


                if (this.grdInsertedFardat.Rows.Count > 0)
                {
                    for (int i = 0; i < grdInsertedFardat.Rows.Count; i++)
                    {
                        int rowvalue = Convert.ToInt32(grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value);

                        if (rowvalue == 1)
                        {
                            string ReceivingId = grdInsertedFardat.Rows[i].Cells["ReceivingId"].Value.ToString();

                            obj.DeleteSavedRegistries(ReceivingId);

                        }
                    }

                }


                this.chkAllDetails.Checked = false;
                Load_RegistryList_Saved_For_Registrar_Dispatch();
                Proc_Get_Registries_List_For_Registrar();


            }
            private void btnPrint_Click(object sender, EventArgs e)
            {
                if (this.grdInsertedFardat.Rows.Count > 0)
                {
                    frmSDCReportingMain TokenReport = new frmSDCReportingMain();
                    TokenReport.RegFardDispatchMainId = this.DispatchId;
                    TokenReport.userId = UsersManagments.UserId.ToString();

                    UsersManagments.check = 46;

                    TokenReport.ShowDialog();
                }
            }
    }
}
