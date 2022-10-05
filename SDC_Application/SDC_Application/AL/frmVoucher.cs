using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
using SDC_Application.LanguageManager;
namespace SDC_Application.AL
{
    public partial class frmVoucher : Form
    {

        #region //Calss Varibles
        AutoComplete objauto = new AutoComplete();
        DL.Database ojbdb = new DL.Database();
        AL.frmToken objtoken = new AL.frmToken();
        BL.frmVoucher objbusines = new BL.frmVoucher();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        Taxes tax = new Taxes();
        datagrid_controls objdatagrid = new datagrid_controls();

        DataTable dt = new DataTable();
        DataTable dtPayment = new DataTable();
        static bool btnload = false;
        SqlDataReader dr = null;
        static string tokenverifed = "False";
       
        public string IntiqalId { get; set; }
        public string FGPId { get; set; }
        public string Token_From_khataJat { get; set; }
        BindingSource bs = new BindingSource();
        LanguageConverter lang = new LanguageConverter();
        int check;
        #endregion

        public frmVoucher()
        {
            InitializeComponent();
        }

        
        #region Loadform
        private void frmVoucher_Load(object sender, EventArgs e)
        {
            string TehsilId=UsersManagments._Tehsilid.ToString();
            tooltip_for_voucher();
            this.btnAddTazIntiqal.Enabled = false;
            this.timer1.Start();

          
            try
            {
                calldataGrid();
            }
            catch (Exception ex) {  }

        }
        #endregion
        
        #region Enable-Disable
    
        public void DisableDetailPortion()
        {
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAddTazIntiqal.Enabled = false;
            txtPVDetatils.Enabled = true;
        }
        public void EnableDetailPortion()
        {
            this.btnAddTazIntiqal.Enabled = true;
            btnClear.Enabled = true;          
            btnSave.Enabled = true;
            txtServiceName.Enabled = true;
            txtRsPerPage.Enabled = false;
            txtQuantity.Enabled = true;
            txtTotalRs.Enabled = false;
            txtPVDetatils.Enabled = true;
        }
        #endregion       

        #region Call_Proc_Get_SDC_Services_For_PaymentVoucher Change ServiceType
        public void Call_Proc_Get_SDC_Services_For_PaymentVoucher()
        {

            dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Services_For_PaymentVoucher '" + this.txtHidenServiceTypeID.Text + "'");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtRsPerPage.Text = dr["ServiceCostPerUnit"].ToString();
                    this.txtServiceName.Text = dr["SDCServiceName_Urdu"].ToString();
                    this.txtMasterServiceID.Text = dr["SDCServiceId"].ToString();
                    this.txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();
                    this.txtNotificationUnitID.Text = dr["ServiceNotificationId"].ToString();

                }
            }
        }
        #endregion        

        #region Validations
        private void txtTokenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            check = 2;
            Validations.errorprovider(e, txtTokenNO, objtoken.errorChar, objtoken.errorNumeric, check);
        }

       

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            check = 2;
            Validations.errorprovider(e, txtQuantity, objtoken.errorChar, objtoken.errorNumeric, check);
           
            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                btnSave_Click(sender, e);
            }

        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            
            
            if (txtQuantity.Text== null || txtQuantity.Text== "")
            {
                objtoken.errorChar.SetError(txtQuantity, "");
            }

            totalCostCalculated();
        }
        public void totalCostCalculated()
        {
            if (txtQuantity.Text.Trim() != string.Empty && txtRsPerPage.Text !=string.Empty)
            {
                if (txtServiceName.Text != "انتقال پرت فیس")
                {
                    Double amount = Convert.ToDouble(this.txtRsPerPage.Text) * Convert.ToDouble(this.txtQuantity.Text.ToString());
                    if (txtPVDetatils.Text != "")
                    {
                        amount = amount + 125;
                        double q = Convert.ToDouble(this.txtQuantity.Text.ToString());
                        if (q > 1)
                        {
                            if (q <= 5)
                            {
                                amount = amount + ((q - 1) * 25);
                            }
                            else
                            {
                                amount = amount + 100;
                            }
                        }


                    }
                    this.txtTotalRs.Text = amount.ToString();
                }
                else if (txtServiceName.Text == "انتقال پرت فیس")
                {
                    Double amount = Convert.ToDouble(this.txtRsPerPage.Text) * Convert.ToDouble(this.txtQuantity.Text.ToString());
                    this.txtTotalRs.Text = amount.ToString();
                }
                
            }
            else
            {
               
                if (txtQuantity.Text != "")
                { 
                    MessageBox.Show( "شرح  فی اکائی داخل کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        #endregion       

        #region Save data in details 

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);
           

            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.txtServiceName.Text.ToString());
            collection.Add(this.txtQuantity.Text.ToString());
            

            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "--انتخاب کریں--")
                {
                    empty += "," + Labels[i].ToString();

                }

            }
            try
            {
                totalCostCalculated();
                bool isExists = false;

                if (empty!=null)
                {
                    MessageBox.Show(empty + "- کا اندراج کریں","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    //

                    if (grdVoucherDetails.Rows.Count > 0 && txtSequenceID.Text == "-1")
                    {
                        foreach (DataGridViewRow row in grdVoucherDetails.Rows)
                        {
                            if (this.txtServiceName.SelectedValue.ToString() == row.Cells["TaxNotificationDetailId"].Value.ToString())
                            {
                                isExists = true;
                                break;
                            }
                        }

                    }
                    if (!isExists)
                    {
                        if (Submit())
                        {
                            txtVoucherDetailsLastID.Text = "-1";
                            txtSequenceID.Text = "-1";
                            ClearFormsGroupsFields.ClearGroupBoxControls(groupBox2);
                            txtServiceName.SelectedIndex = 0;
                            //MessageBox.Show("ریکارڈ محفوظ ھوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTotalCostVoucher.Text = "";
                            objdatagrid.SumDataGridColumn(grdVoucherDetails, txtTotalCostVoucher, "ServiceCostAmount");
                            chkMasterVoucherUpdate.Checked = false;
                            chkMasterVoucherUpdate.Enabled = true;
                           

                        }
                    }
                    else
                    {
                        MessageBox.Show("ریکارڈ پہلے سے داخل ہے ", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message);
            }
        
        }
        public bool Submit()
        {

            try
            {
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    totalCostCalculated();
                    insert_update();
                    return true;

                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }

        public void insert_update()
        {
            
            try
            {
                if (txtPVID.Text != "")
                {
                    InsertioninVocherDetails();
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtVoucherDetailsLastID.Text = dr["LastID"].ToString();
                    }

                    calldataGrid();
                }
                else
                {
                    //MessageBox.Show("can not inserted ,first generate voucher");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion  
       

     public void  InsertioninVocherDetails()
        {
                    string VocherDetailId = this.txtVoucherDetailsLastID.Text.ToString();
                    string PVID = this.txtPVID.Text.ToString();
                    string SeqNo = this.txtSequenceID.Text.ToString();
                    string Notificationunitid = this.txtNotificationUnitID.Text.ToString();
                    string costunitid = txtMasterCostunitID.Text.ToString();
                    string Rsperpage = txtRsPerPage.Text.ToString();
                    string txtquntity = txtQuantity.Text.ToString();
                    string totalamount = txtTotalRs.Text.ToString();
                    string PVdetails = txtPVDetatils.Text.ToString();

                    if (IntiqalId == null)
                    {
                        IntiqalId = "NULL";
                    }
                    if (FGPId == null)
                    {
                        FGPId = "NULL"; 
                    }

                     dt = objbusines.SaveVocherDetails(VocherDetailId, PVID, SeqNo, FGPId, IntiqalId, Notificationunitid, costunitid, Rsperpage, txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());


                     objtoken.errorNumeric.SetError(txtTotalRs, "");
                     objtoken.errorNumeric.SetError(txtQuantity, "");
                     objtoken.errorChar.SetError(txtTotalRs, "");
                     objtoken.errorChar.SetError(txtQuantity, "");
     }
        #region GridFilling after Saving In Details
        public void calldataGrid()
        {

            try
            {

                dtPayment = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId '" + this.txtPVID.Text + "'");
                //grdVoucherDetails.Columns["ServiceCostAmount"].Width = 60;
                //DataTable outputTable = dtPayment.Clone();

                //for (int i = dtPayment.Rows.Count - 1; i >= 0; i--)
                //{
                //    outputTable.ImportRow(dtPayment.Rows[i]);
                //}
                grdVoucherDetails.DataSource = dtPayment;
                objbusines.VoucherGrid(grdVoucherDetails);
                if (dtPayment != null)
                { 
                grdVoucherDetails.Columns["ServiceCostAmount"].Width = 100;

                if  (grdVoucherDetails.Rows.Count > 0)
                {
                    objdatagrid.SumDataGridColumn(grdVoucherDetails, txtTotalCostVoucher, "ServiceCostAmount");
                }


                grdVoucherDetails.ColumnHeadersHeight = 35;
                }
            }
            catch (Exception ex)
            {
             
            }

        }
        private void grdVoucherDetails_DoubleClick(object sender, EventArgs e)
        {
            cleardeatails();
            txtVoucherDetailsLastID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailId"].Value.ToString();
            txtSequenceID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailSeqNo"].Value.ToString();
            txtQuantity.Text = grdVoucherDetails.CurrentRow.Cells["ServiceQuantity"].Value.ToString();
            txtRsPerPage.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostPerUnit"].Value.ToString();
            txtTotalRs.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostAmount"].Value.ToString();
            txtServiceName.Text = grdVoucherDetails.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();          
            txtPVDetatils.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailRemarks"].Value.ToString();
            this.txtPVDetatils.SelectedText = this.txtPVDetatils.Text;
            objtoken.errorNumeric.SetError(txtQuantity, "Ok");
            objtoken.errorNumeric.SetError(txtTotalRs, "Ok");
            txtNotificationUnitID.Text = grdVoucherDetails.CurrentRow.Cells["TaxNotificationDetailId"].Value.ToString();
            txtMasterCostunitID.Text = grdVoucherDetails.CurrentRow.Cells["SDCUnitId"].Value.ToString();        
            txtUnit.Text = grdVoucherDetails.CurrentRow.Cells["SDCUnitName_Urdu"].Value.ToString();
          
        }
        #endregion

        #region Saving Master Data
        private void btnMasterSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMozaID.Text == "" && txtTokenNO.Text == "" && txtTokenNO.Text==string.Empty)
                {
                    if (MessageBox.Show("ریکارڈز کے اندراج کے لیے ٹوکن لوڈ کریں", "ٹوکن", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                    {
                        frmSearch_Click(sender, e);
                    }
               
                }
                else
                {
                    if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster '"
                        + this.txtPVID.Text + "','"
                        + UsersManagments._Tehsilid.ToString() + "','"
                        + this.txtPVNo.Text + "','"
                        + this.txtMaster_Details_Date.Value.ToShortDateString() + "','"
                        + this.txtTokenID.Text + "','"
                        + this.txtMozaID.Text.ToString() + "','"
                        + this.txtMasterStatus.Text + "',N'" + this.txtMasterRemarks.Text.ToString() + "','"
                        + UsersManagments.UserId.ToString() + "','"
                        + UsersManagments.UserName.ToString() + "','',''");

                        foreach (DataRow dr in dt.Rows)
                        {
                            txtPVID.Text = dr[0].ToString();
                            this.txtPVNo.Text = dr[1].ToString();
                            this.txtVoucherNo.Text = dr[1].ToString();
                            if (txtPVID.Text != "")
                            {                           
                                    
                          
                                Proc_Get_SDC_Services_For_PaymentVoucher();
                               EnableDetailPortion();
                               btnAddTazIntiqal.Enabled = true;
                            }
                        }
                    }
                    txtRsPerPage.Text = "";
                   // MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Proc_Get_SDC_Services_For_PaymentVoucher()
        {
            objauto.FillCombo("Proc_Get_SDC_Services_For_PaymentVoucher '" + txtHidenServiceTypeID.Text + "'", txtServiceName, "SDCServiceName_Urdu", "TaxNotificationDetailId");
           // MessageBox.Show(txtServiceName.SelectedIndex.ToString());
            //txtServiceName.SelectedIndex = 0;
            //txtRsPerPage.Text = "";
            //txtPVDetatils.Text = "";
            //txtUnit.Text = "";

        }
        #endregion    

        #region Fill per page cost by service id

        private void txtServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion  

        #region Check Voucher if Already saved against a token no

        private string CheckSavedVouvherAgainstToken(string TokenId)
        {
             string PV_No = "0";
             DataTable dtVoucher = new DataTable();
             dtVoucher= objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherNo_By_TokenId '" + TokenId + "'");
             if (dtVoucher!=null? dtVoucher.Rows.Count > 0:false)
             {
                 PV_No ="اس ٹوکن پر چلان پہلے سے موجود ہے۔"+ " - چلان نمبر -"+ dtVoucher.Rows[0][0].ToString() +" - بتاریخ - "+ dtVoucher.Rows[0][1].ToString();
             }
             return PV_No;
        }

        #endregion

        #region go to frmsearch for Selecting TokenNumbers

        private void frmSearch_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            frmSearch.FormClosed -= new FormClosedEventHandler(frmSearch_FormClosed);
            frmSearch.FormClosed += new FormClosedEventHandler(frmSearch_FormClosed);
            frmSearch.ShowDialog();
        }

        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            
          
            frmSearch frmSearch = sender as frmSearch;
            if (frmSearch.btn)
            {
                try
                {

               
                    string isPVexists=this.CheckSavedVouvherAgainstToken(frmSearch.tokenID);
                    if (isPVexists!=null? isPVexists == "0":false)
                    {
                        ClearAllformFields();
                        this.txtTokenID.Text = frmSearch.tokenID;
                        this.txtVisitorName.Text = frmSearch.name;
                        this.txtFatherName.Text = frmSearch.fathername;
                        this.TxtCNIC.Text = frmSearch.cnic;
                        this.txtService.Text = frmSearch.service;
                        this.txtTokenNO.Text = frmSearch.tokenno;
                        this.txtMouza.Text = frmSearch.mouza;
                        this.txtMozaID.Text = frmSearch.mouzaid;
                        this.txtPVID.Text = frmSearch.pvid;
                        this.txtPVNo.Text = frmSearch.pvno;
                        this.txtHidenServiceTypeID.Text = frmSearch.hiddenservvicetypeid;
                        this.btnMasterSave.Enabled = frmSearch.btn;
                        btnMasterSave.Enabled = true;
                        label11.Text = "تصدیق کریں";
                        chkMasterVoucherUpdate.Checked = false;
                        chkMasterVoucherUpdate.Enabled = false;
                        objtoken.errorNumeric.SetError(txtTotalRs, "");
                        objtoken.errorNumeric.SetError(txtQuantity, "");
                        objtoken.errorChar.SetError(txtTotalRs, "");
                        objtoken.errorChar.SetError(txtQuantity, "");
                    }
                    else
                    {
                        MessageBox.Show(isPVexists, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            }
        }
        #endregion

        #region voucher verified ChecjBox
        private void chkMasterVoucherUpdate_Click(object sender, EventArgs e)
        {
            if (chkMasterVoucherUpdate.Checked && txtPVID.Text != "" && grdVoucherDetails.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster '" + this.txtPVID.Text + "','" + chkMasterVoucherUpdate.Checked + "','" + this.txtTotalCostVoucher.Text.ToString() + "'") != null)
                        {
                           //// MessageBox.Show("ریکاڈ کی تصدیق ہوچکی ہے", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkMasterVoucherUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnMasterSave.Enabled = false;
                            btnAddTazIntiqal.Enabled = false;
                            label11.Text = "تصدیق شدہ";
                        }
                    }
                    else
                    {
                        chkMasterVoucherUpdate.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("تصدیق کے لیے  ریکارڈز خالی ہیں", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkMasterVoucherUpdate.Checked = false;
            }
        }
        public void ClearAllformFields()
        {
            btnSave.Enabled = false;
            btnMasterSave.Enabled = false;
            txtServiceName.Text = "--انتخاب کریں--";
            ClearFormsGroupsFields.ClearGroupBoxControls(groupBox2);
            ClearFormsGroupsFields.ClearGroupBoxControls(groupBox2, groupBox5);
            txtVoucherDetailsLastID.Text = "-1";
            txtTotalCostVoucher.Text = "";
            this.txtSequenceID.Text = "-1";
            this.txtPVID.Text = "-1";
            this.txtPVNo.Text = "-1";
            dtPayment = null;
          

        }
        #endregion

        #region ClearFields and Validations
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ ریکارڈز خالی کرنا چاہتے ہیں:::::", "ریکارڈز خالی", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cleardeatails();
            }
        }
        public void cleardeatails()
        {
            txtVoucherDetailsLastID.Text = "-1";
            this.txtSequenceID.Text = "-1";
            ClearFormsGroupsFields.ClearGroupBoxControls(groupBox2);
            txtServiceName.SelectedValue = 0;
        }

        private void txtPVDetatils_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }

            if (e.KeyChar == (char)13)
            { btnAddDetails_Click(sender,e); }
        }

        private void txtMasterRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chkMasterVoucherUpdate_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Populate Saved Master/Details
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            frmVoucherPopulate frmVoucherPopulate = new frmVoucherPopulate();
            frmVoucherPopulate.FormClosed -= new FormClosedEventHandler(frmVoucherPopulate_FormClosed);
            frmVoucherPopulate.FormClosed += new FormClosedEventHandler(frmVoucherPopulate_FormClosed);
            frmVoucherPopulate.ShowDialog();
        }
        private void frmVoucherPopulate_FormClosed(object sender, FormClosedEventArgs e)
        {
            


            frmVoucherPopulate frmVoucherPopulate = sender as frmVoucherPopulate;
            if (frmVoucherPopulate.btn)
            {
                txtVisitorName.Text = "";
                ClearAllformFields();
                txtMozaID.Text = frmVoucherPopulate.Mouzaid;
                txtVoucherNo.Text = frmVoucherPopulate.PVNo;
                txtTokenNO.Text = frmVoucherPopulate.TokenNo;
                txtVisitorName.Text = frmVoucherPopulate.Name;
                txtFatherName.Text = frmVoucherPopulate.FatherName;
                txtMouza.Text = frmVoucherPopulate.Mouza;
                TxtCNIC.Text = frmVoucherPopulate.CNIC;
                txtService.Text = frmVoucherPopulate.ServiceName;
                txtPVID.Text = frmVoucherPopulate.PVId;
                txtPVNo.Text = frmVoucherPopulate.PVNo;
                txtTokenID.Text = frmVoucherPopulate.TokenID;
                txtMasterRemarks.Text = frmVoucherPopulate.Remarks;
                txtHidenServiceTypeID.Text = frmVoucherPopulate.ServiceType;
                bool pvstatus = frmVoucherPopulate.Pvstatus != "null" ? Convert.ToBoolean( frmVoucherPopulate.Pvstatus):false;
                txtSequenceID.Text = "-1";
                txtVoucherDetailsLastID.Text = "-1";
                bool Populated = frmVoucherPopulate.btn;
                if (Populated)
                {
                    Proc_Get_SDC_Services_For_PaymentVoucher();
                    calldataGrid();


                    if (pvstatus)
                    {
                        btnClear.Enabled = false;
                        btnSave.Enabled = false;
                        btnAddTazIntiqal.Enabled = false;
                        btnMasterSave.Enabled = false;
                        chkMasterVoucherUpdate.Checked = true;
                        chkMasterVoucherUpdate.Enabled = false;
                        label11.Text = "تصدیق شدہ";
                       
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        chkMasterVoucherUpdate.Enabled = true;
                        btnAddTazIntiqal.Enabled = true;
                        chkMasterVoucherUpdate.Checked = false;
                        label11.Text = "تصدیق کریں";
                       
                    }

                    //if (grdVoucherDetails.Rows.Count <= 0)
                    //{
                    //    btnSave.Enabled = false;
                    //    btnAddTazIntiqal.Enabled = true;
                    //    chkMasterVoucherUpdate.Enabled = false;
                    //    chkMasterVoucherUpdate.Checked = false;
                    //    label11.Text = "تصدیق کریں";
                    //}

                    
                }
            }
        }
        #endregion

        #region Add Details of Fard Malikans and Khattas

        // add by Noor

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            if (txtTokenID.Text != string.Empty && txtPVID.Text != string.Empty)
            {
                frmSearchPersonByMoza fpk = new frmSearchPersonByMoza();
                bool personRecord = txtServiceName.Text.Contains("ذاتی") ? true : false;
                fpk.isPersonalRecord = personRecord;
                fpk.TokenId = txtTokenID.Text;
                fpk.MozaId = txtMozaID.Text;
                fpk.FormClosed += new FormClosedEventHandler(fpk_FormClosed);
                fpk.ShowDialog();
            }
        }

        void fpk_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSearchPersonByMoza fpk = sender as frmSearchPersonByMoza;

                Token_From_khataJat = fpk.TokenId;
                DataTable Khattas = new DataTable();
                Khattas = mnk.GetFardMalkanKhataJats(Token_From_khataJat);
                if (Khattas != null)
                {
                    foreach (DataRow row in Khattas.Rows)
                    {
                        txtPVDetatils.Text = row["malkan_khatajats"].ToString();
                    }
                }
                this.txtQuantity.Text = fpk.NoOfPages.ToString();
                this.FGPId = fpk.FPGid;
                //this.txtPVDetatils.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
    }


        #endregion

        #region New Master load
        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ نیا ٹوکن لوڈ کرنا چاہتے ہیں:::::", "نیا ٹوکن لوڈ ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              frmSearch_Click(sender,e);
            }
        
            
        }
        public void tooltip_for_voucher()
        {
            TTVR.SetToolTip(TxtCNIC,"شناختی کارڈ");
            TTVR.SetToolTip(txtFatherName,"والد کانام");
            TTVR.SetToolTip(txtMaster_Details_Date,"تاریخ");
            TTVR.SetToolTip(txtMasterCostunitID,"فی یونٹ خرچہ");
            TTVR.SetToolTip(txtMasterRemarks,"ریمارکس");
            TTVR.SetToolTip(txtMasterServiceID,"");
            TTVR.SetToolTip(txtMasterStatus,"حیثیت");
            TTVR.SetToolTip(txtMouza,"موضع");
            TTVR.SetToolTip(txtMozaID,"موضع ای ڈی");
            TTVR.SetToolTip(txtNotificationUnitID,"");
            TTVR.SetToolTip(txtQuantity,"تعداد");
            TTVR.SetToolTip(txtRsPerPage,"خرچہ فی صفحہ");
            TTVR.SetToolTip(txtSequenceID,"");
            TTVR.SetToolTip(txtService,"سہولت");
            TTVR.SetToolTip(txtServiceName,"سہولت کا نام");
            TTVR.SetToolTip(txtTokenID,"ٹوکن آئی ڈی");
            TTVR.SetToolTip(txtTokenNO,"ٹوکن نمبر");
            TTVR.SetToolTip(txtTotalCostVoucher,"کل خرچہ");
            TTVR.SetToolTip(txtTotalRs,"کل وقم");
            TTVR.SetToolTip(txtVisitorName,"سائل کا نام");
            TTVR.SetToolTip(txtVoucherDetailsLastID,"چالان آئی ڈی");
            TTVR.SetToolTip(txtVoucherNo,"چالان نمبر");
            TTVR.SetToolTip(btnAddDetails,"تفصیلات جمع کریں");
            TTVR.SetToolTip(btnClear,"نیا ریکارڈ");
            TTVR.SetToolTip(btnMasterSave,"محفوظ کریں");
            TTVR.SetToolTip(btnNewVoucher,"نیا چالان بنائیں");
            TTVR.SetToolTip(btnPopulate,"محفوظ شدہ چالان لوڈکریں");
            TTVR.SetToolTip(btnSave,"محفوظ کریں");
            TTVR.SetToolTip(btnSearch,"تلاش کریں");
        }
        #endregion

        private void btnAddTazIntiqal_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            DataTable dtTax = new DataTable();
            try
            {
                calldataGrid();
                if (chkMasterVoucherUpdate.Checked != true)
                {
                    if (txtTokenID.Text != null && this.txtPVID.Text != null)
                    {
                        dtTax = tax.GetIntiqalTaxDetailsByTokenId(txtTokenID.Text.ToString());

                        if (dtTax != null)
                        {
                            foreach (DataRow row in dtTax.Rows)
                            {
                                IntiqalId = row["IntiqalId"].ToString();
                                this.txtNotificationUnitID.Text = row["TaxNotificationDetailId"].ToString();
                                txtMasterCostunitID.Text = row["SDCUnitId"].ToString();
                                txtRsPerPage.Text = row["TaxRate"].ToString();
                                txtQuantity.Text = row["TaxableQuantity"].ToString();
                                txtTotalRs.Text = row["taxamount"].ToString();
                                if (grdVoucherDetails.Rows.Count > 0 && txtSequenceID.Text == "-1")
                                {
                                    foreach (DataGridViewRow rows in grdVoucherDetails.Rows)
                                    {
                                        if (this.txtNotificationUnitID.Text == rows.Cells["TaxNotificationDetailId"].Value.ToString())
                                        {
                                            isExists = true;
                                            break;
                                        }
                                    }

                                }
                                if (!isExists)
                                {
                                    InsertioninVocherDetails();
                                }

                            }
                            IntiqalId = null;
                            calldataGrid();
                            //IntiqalId = row["IntiqalId"].ToString();
                            this.txtNotificationUnitID.Text = "";// row["TaxNotificationDetailId"].ToString();
                            txtMasterCostunitID.Text = "";// row["SDCUnitId"].ToString();
                            txtRsPerPage.Text = "";// row["TaxRate"].ToString();
                            txtQuantity.Text = "";// row["TaxableQuantity"].ToString();
                            txtTotalRs.Text = "";// row["taxamount"].ToString();
                            chkMasterVoucherUpdate.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("کوئی ریکارڈ نہں ملا", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                    else
                    {
                        MessageBox.Show("چالان  فارم لوڈ کریں", "ٹوکن نمبر نہں ملا ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Procedure or function"))
                {
                    MessageBox.Show("چالان  فارم لوڈ کریں","ٹوکن نمبر نہں ملا ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               
            }
        }

        private void txtServiceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtServiceName.SelectedIndex == 0)
            {

            }

            else
            {

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Service_Detail '" + this.txtServiceName.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {

                    txtRsPerPage.Text = dr["ServiceCostPerUnit"].ToString();
                    txtNotificationUnitID.Text = dr["TaxNotificationDetailId"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();
                    txtMasterServiceID.Text = dr["TaxNotificationDetailId"].ToString();
                    txtUnit.Text = dr["SDCUnitName_Urdu"].ToString();

                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 2;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.txtMozaID.Text;
                sdcReports.TokenID = this.txtTokenID.Text;
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();
                //UsersManagments.check = 2;
                //SDCReports TokenReport = new SDCReports();
                //TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
                //TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
                //TokenReport.PVID = this.txtPVID.Text;
                //TokenReport.TokenID = this.txtTokenID.Text;
                //TokenReport.Tehsilid = UsersManagments._Tehsilid.ToString();
                //TokenReport.ShowDialog();
            }

        }
        private void TokenReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            SDCReports Populate = sender as SDCReports;
        }

        private void btnPrintFard_Click(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 6;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.txtMozaID.Text;
                sdcReports.TokenID = this.txtTokenID.Text;
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();
            }
        }

    }


}








