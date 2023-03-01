using SDC_Application.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;
using Microsoft.Reporting.WinForms;
using System.Collections;

namespace SDC_Application.AL
    {
    public partial class frmShortFard : Form
    {
        #region Calss Variables

        Search search = new Search();
        Persons person = new Persons();
        AutoComplete objauto = new AutoComplete();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        LanguageConverter lang = new LanguageConverter();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        AutoComplete auto = new AutoComplete();
        CommanFunctions common = new CommanFunctions();
        BL.frmToken objbusines = new BL.frmToken();
        BL.frmRecipt objfrmRecipt = new BL.frmRecipt();
        AL.frmToken objtoken = new AL.frmToken();
        datagrid_controls objdatagird = new datagrid_controls();
        BL.frmVoucher objVoucher = new BL.frmVoucher();
        DataTable dt = new DataTable();
        DataTable dtPayment = new DataTable();
        DataTable dtReceipt = new DataTable();
        DataTable dtGrd = new DataTable();
        AutoComplete AutoFillCombo = new AutoComplete();
        Intiqal Intiq = new Intiqal();
        BL.frmToken objBusiness = new BL.frmToken();
       
        DataTable khewatMalikanByFB = new DataTable();
        DataView view;
        DataTable dtKhewatFareeqainByKhataId = new DataTable();
        DataTable dtMushteriFareeqainByKhatooniId = new DataTable();
        DataTable dtFardKhatas = new DataTable();
        DataTable TokenRetrieve = new DataTable();
        DataTable Persons = new DataTable();
        int countSelectedPersons = 0;
        string selectedPersons = "";
        public string MaalikType { get; set; }
        public string MozaId { get; set; }
        public string SelectedMozaId { get; set; }
        public string SelectedTokenId { get; set; }
        public string SelectedTokenNo { get; set; }
        public bool isConfirm { get; set; }
        public string Khatoniid {get;set; }
        public DateTime tokenDate { get; set; }

        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }
          public string PersonName { get; set; }
        public string FatherName { get; set; }
        bool pvstatus = false;


        #endregion

        #region Default Construction

        public frmShortFard()
            {

            InitializeComponent();

            }

        #endregion


        #region Load Token Click Evetn

        private void searchToken_FormClosed(object sender, FormClosedEventArgs e)
        {

            
            frmSearch frm = sender as frmSearch;
            this.SelectedMozaId = frm.mouzaid;
            this.SelectedTokenId = frm.tokenID;
            this.SelectedTokenNo = frm.tokenno;
            txtHiddenServiceTypeId.Text = frm.hiddenservvicetypeid;
            txtReciptTokenID.Text = this.SelectedTokenNo;
            this.tokenDate = frm.tokenDate;
            txtMoza.Text = frm.mouza;
            txtFardType.Text = frm.service;
            dtTokenAndrajDate.Value = frm.tokenDate;
            pvstatus = Convert.ToBoolean(frm.PV_Verified);
            if (pvstatus)
            {
                btnSavePersons.Enabled = false;
                btnDelPersons.Enabled = false;
            }
            else
            {
                btnSavePersons.Enabled = true;
                btnDelPersons.Enabled = true;
            }
            
            this.tabControl1.SelectedIndex = 0;
            GetPersonSavedRecord(SelectedTokenId);
            getOperatorReport();
           
        }

        #endregion

        #region Get Operator Report

        private void getOperatorReport()
        {
            try
            {
                txtOperatorReport.Clear();
                DataTable dt = new DataTable();
                dt = mnk.GetDetailedFardOperatorReport(this.SelectedTokenId != null ? this.SelectedTokenId : "0");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtOperatorReport.Text = dt.Rows[0]["OperatorReport"].ToString();
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region Form Load Event

        private void frmFard_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Operator Auto Urdu Conversion

        #endregion







        #region Print Detailed Fard
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.SelectedTokenId != null && this.SelectedTokenId != "0")
            {
                    string ReceiptVerified = Intiq.CheckFardReceiptVerified(this.SelectedTokenId.ToString(), UsersManagments.UserId.ToString());
                    FardMalikan_Report rptDetail = new FardMalikan_Report();
                    rptDetail.TokenID = this.SelectedTokenId;
                    rptDetail.isTrans = false;
                    rptDetail.ReceiptVerified = ReceiptVerified;
                    rptDetail.ShowDialog();
                
            }
        }
        #endregion

        

        #region Get services for payment voucher
        public void Proc_Get_SDC_Services_For_PaymentVoucher()
        {

            objauto.FillCombo("Proc_Get_SDC_Services_For_PaymentVoucher "+UsersManagments._Tehsilid.ToString()+",'" + txtHiddenServiceTypeId.Text + "'", txtServiceName, "SDCServiceName_Urdu", "TaxNotificationDetailId");

        }

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId()
        {
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId "+UsersManagments._Tehsilid.ToString()+",'"
                                + this.txtRPVID.Text.ToString() + "'", cmbRServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");

            txtRAmounttoPay.Text = "";
        }

        public void call_Details_Recipt_Grd()
        {
            try
            {
                dtGrd = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherDetail_By_RVId "+UsersManagments._Tehsilid.ToString()+",'" + this.txtRVID.Text + "'");

                grdRecipt.DataSource = dtGrd;
                //======= fill grid=============

                grdRecipt.Columns["RVDetailSeqNo"].DisplayIndex = 0;
                grdRecipt.Columns["SDCServiceName_Urdu"].DisplayIndex = 1;
                grdRecipt.Columns["PaymentType_Urdu"].DisplayIndex = 2;

                grdRecipt.Columns["NetPayableAmount"].DisplayIndex = 3;
                grdRecipt.Columns["ReceivedAmount"].DisplayIndex = 4;

                grdRecipt.Columns["RVDetailSeqNo"].HeaderText = "نمبرشمار";
                grdRecipt.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت";
                grdRecipt.Columns["PaymentType_Urdu"].HeaderText = "رقم کی ادائیگی بذریعہ";

                grdRecipt.Columns["NetPayableAmount"].HeaderText = "قابل ادا رقم";
                grdRecipt.Columns["ReceivedAmount"].HeaderText = "وصول کی گئی رقم";


                grdRecipt.Columns["BankAccountNo"].Visible = false;
                grdRecipt.Columns["BankName"].Visible = false;
                grdRecipt.Columns["PVDetailRemarks"].Visible = false;
                grdRecipt.Columns["BankBranchName"].Visible = false;
                grdRecipt.Columns["PaymentTypeId"].Visible = false;
                grdRecipt.Columns["RVDetailId"].Visible = false;
                grdRecipt.Columns["IntiqalTaxId"].Visible = false;
                grdRecipt.Columns["PVDetailId"].Visible = false;

                grdRecipt.Columns["RVId"].Visible = false;
                grdRecipt.Columns["ChallanNo"].Visible = false;
                grdRecipt.Columns["TaxNotificationDetailId"].Visible = false;
                grdRecipt.Columns["ChallanDate"].Visible = false;

                grdRecipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grdRecipt.DefaultCellStyle.ForeColor = Color.Black;


                //    =========== end====================
                if (grdRecipt.Rows.Count > 0)
                {
                    objdatagird.SumDataGridColumn(grdRecipt, txtTotPaymentRecived, "ReceivedAmount");
                    objdatagird.SumDataGridColumn(grdRecipt, this.txtNetAmountToPay, "NetPayableAmount");
                }
                else
                {
                    txtTotPaymentRecived.Clear();
                    txtNetAmountToPay.Clear();
                }

                DataGridViewColumn column = grdRecipt.Columns["RVDetailSeqNo"];
                column.Width = 70;

                for (int i = 0; i <= grdRecipt.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = grdRecipt.Rows[i];
                    row.Height = 35;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucherId()
        {
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId "+UsersManagments._Tehsilid.ToString()+",'"
            + this.txtRPVID.Text.ToString() + "'", cmbRServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");

            txtRAmounttoPay.Clear();
            cmbRPaymentofSource.SelectedIndex = 0;
            txtRAmountRecieve.Clear();
            txtRChalanFormNum.Clear();
            dtRChalanFormDate.Value = DateTime.Now;
        }

        #endregion







        #region Tab Control Change
        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {

              

                case 2:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            btnSavePersons.Enabled = false;
                            btnDelPersons.Enabled = false;
                            txtTotalRs.Clear();
                            txtQuantity.Clear();
                            txtVoucherDetailsLastID.Text = "-1";
                            txtTotalCostVoucher.Clear();

                            grdVoucherDetails.DataSource = null;
                            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId '" + this.SelectedTokenId.ToString() + "'," + "P");


                            if (dtPayment.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtPayment.Rows)
                                {
                                   
                                    txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                    txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                  
                                    this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                  
                                    this.txtVoucherNo.Text = dr["PV_No"].ToString();
                                    dtChallan.Text = dr["PV_Date"].ToString();
                                    txtPVID.Text = dr["PVID"].ToString();
                                    txtPVNo.Text = dr["PV_No"].ToString();
                                    bool pvstatus = Convert.ToBoolean(dr["PV_Verified_Status"]);
                                    btnMasterSave.Enabled = false;

                                    txtQuantity.Enabled = true;

                                    txtServiceName.Enabled = true;
                                    Proc_Get_SDC_Services_For_PaymentVoucher();
                                    calldataGrid();

                                    if (pvstatus)
                                    {

                                        btnSave.Enabled = false;

                                        chkMasterVoucherUpdate.Checked = true;
                                        chkMasterVoucherUpdate.Enabled = false;
                                        lbPaymentTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnSave.Enabled = true;
                                        chkMasterVoucherUpdate.Enabled = true;

                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";

                                    }

                                }
                            }

                            else
                            {
                                txtServiceName.DataSource = null;
                                txtServiceName.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId '" + this.SelectedTokenId.ToString() + "' ");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                       
                                        txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                        txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                     
                                        this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                        txtPVID.Text = "-1";
                                        txtPVNo.Text = "-1";
                                        this.txtVoucherNo.Clear();
                                        dtChallan.Value = DateTime.Now;
                                      
                                        btnSave.Enabled = false;
                                        txtQuantity.Enabled = false;

                                        txtServiceName.Enabled = false;
                                        btnMasterSave.Enabled = true;


                                        chkMasterVoucherUpdate.Enabled = true;
                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";


                                    }
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }

                // ======== TAB Receipt ===================================================


                case 3:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            btnSavePersons.Enabled = false;
                            btnDelPersons.Enabled = false;
                            txtRNo.Text = "-1";
                            txtRPVID.Clear();
                            txtPVDetailID.Clear();
                            txtRVID.Text = "-1";

                           
                            
                            txtReciptNo.Clear();
                            txtRFatherName.Clear();
                         
                            txtRName.Clear();
                           
                           
                            dtReciptDate.Value = DateTime.Now;
                          

                            grdRecipt.DataSource = null;
                            txtTotPaymentRecived.Clear();
                            txtNetAmountToPay.Clear();

                            chkVerfiedReciptMaster.Enabled = true;
                            chkVerfiedReciptMaster.Checked = false;



                            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List "+UsersManagments._Tehsilid.ToString(), cmbRPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
                            dtReceipt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_ReceiptVoucherMaster_List_By_TokenId "+UsersManagments._Tehsilid.ToString()+",'" + this.SelectedTokenId.ToString() + "' ");


                            if (dtReceipt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtReceipt.Rows)
                                {
                                   
                                    txtRName.Text = dr["Visitor_Name"].ToString();
                                    txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                   
                                  
                                    txtReciptNo.Text = dr["RVNo"].ToString();
                                    txtRNo.Text = dr["RVNo"].ToString();
                                    dtReciptDate.Text = dr["RVDate"].ToString();
                                    txtRPVID.Text = dr["PVID"].ToString();
                                    txtRVID.Text = dr["RVID"].ToString();
                                    bool rvstatus = Convert.ToBoolean(dr["RV_VerifiedStatus"]);

                                    btnMasterReceiptSave.Enabled = false;
                                    btnRSaveDetails.Enabled = true;
                                    btnRClear.Enabled = true;
                                    cmbRServices.Enabled = true;


                                    if (rvstatus)
                                    {

                                        btnRSaveDetails.Enabled = false;
                                        btnRClear.Enabled = false;
                                        btnDelReceipt.Enabled = false;

                                        chkVerfiedReciptMaster.Checked = true;
                                        chkVerfiedReciptMaster.Enabled = false;
                                        lbReceiptTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnRSaveDetails.Enabled = true;
                                        btnRClear.Enabled = true;
                                        btnDelReceipt.Enabled = true;

                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }

                                    Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId();
                                    call_Details_Recipt_Grd();
                                    btnRClear_Click(sender, e);

                                }
                            }

                            else
                            {
                                cmbRServices.DataSource = null;
                                cmbRServices.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId '" + this.SelectedTokenId.ToString() + "'," + "R");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        
                                        txtRName.Text = dr["Visitor_Name"].ToString();
                                        txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                       

                                        txtRPVID.Text = dr["PVID"].ToString();
                                       


                                        txtRNo.Text = "-1";
                                        txtRVID.Text = "-1";
                                        txtReciptNo.Clear();
                                        dtReciptDate.Value = DateTime.Now;
                                      

                                        btnMasterReceiptSave.Enabled = true;
                                        btnRSaveDetails.Enabled = false;
                                        btnRClear.Enabled = false;
                                        cmbRServices.Enabled = false;


                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }

                        break;
                    }



                //=== END TAB Receipt =========================================================

            }

        }
        #endregion

        #region Master Payment Save
        private void btnMasterSave_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster '"
                + "-1" + "','"
                + UsersManagments._Tehsilid.ToString() + "','"
                + "-1" + "','"
                + this.dtChallan.Value.ToShortDateString() + "','"
                + this.SelectedTokenId.ToString() + "','"
                + this.MozaId + "','"
                 + "Generated" + "',N'" + this.txtMasterRemarks.Text.ToString() + "','"
                + UsersManagments.UserId.ToString() + "','"
                + UsersManagments.UserName.ToString() + "','',''");

                foreach (DataRow dr in dt.Rows)
                {
                    txtPVID.Text = dr[0].ToString();
                    this.txtPVNo.Text = dr[1].ToString();
                    this.txtVoucherNo.Text = dr[1].ToString();
                    if (txtPVID.Text != "")
                    {
                        btnMasterSave.Enabled = false;
                        btnSave.Enabled = true;
                        txtQuantity.Enabled = true;
                        //txtTotalRs.Enabled = true;
                        txtServiceName.Enabled = true;
                        Proc_Get_SDC_Services_For_PaymentVoucher();

                    }
                }
            //}
        }
        #endregion

      

        #region Save Payment data in details

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtServiceName.SelectedIndex == 0)
            {
                MessageBox.Show("- سہولت کا انتخاب کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (txtQuantity.Text.Trim().Length == 0)
            {
                MessageBox.Show("- صفحات کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (txtTotalRs.Text.Trim().Length == 0)
            {
                MessageBox.Show("- رقم کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdVoucherDetails.Rows.Count > 0 && txtVoucherDetailsLastID.Text == "-1")
            {
                MessageBox.Show("ریکارڈ پہلے سے داخل ہے ", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {

                if (Submit())
                {
                    txtVoucherDetailsLastID.Text = "-1";
                    txtSequenceID.Text = "-1";
                   
                    txtServiceName.SelectedIndex = 0;
                    txtTotalRs.Clear();
                    txtQuantity.Clear();

                }

            }

        }

        public bool Submit()
        {

            try
            {
                //if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{

                    insert_update();
                    return true;

                //}
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
                        //  txtVoucherDetailsLastID.Text = dr["LastID"].ToString();
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

        public void InsertioninVocherDetails()
        {
            string VocherDetailId = this.txtVoucherDetailsLastID.Text.ToString();
            string PVID = this.txtPVID.Text.ToString();
            string SeqNo = this.txtSequenceID.Text.ToString();
            string Notificationunitid = this.txtNotificationUnitID.Text.ToString();
            string costunitid = txtMasterCostunitID.Text.ToString();
            string txtquntity = txtQuantity.Text.ToString();
            string totalamount = txtTotalRs.Text.ToString();
            string PVdetails = txtPVDetatils.Text.ToString();

            

            if (txtVoucherDetailsLastID.Text.ToString() == "-1")
            {

                dt = objVoucher.SaveVocherDetails("-1", PVID, "-1", "NULL", "NULL", Notificationunitid, costunitid, "75.00", txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());

            }
            else
            {
                dt = objVoucher.SaveVocherDetails(VocherDetailId, PVID, SeqNo, "NULL", "NULL", Notificationunitid, costunitid, "75.00", txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
            }

            objtoken.errorNumeric.SetError(txtTotalRs, "");
            objtoken.errorNumeric.SetError(txtQuantity, "");
            objtoken.errorChar.SetError(txtTotalRs, "");
            objtoken.errorChar.SetError(txtQuantity, "");
        }

      

        public void calldataGrid()
        {

            try
            {

                dtPayment = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId "+UsersManagments._Tehsilid.ToString()+",'" + this.txtPVID.Text + "'");

                grdVoucherDetails.DataSource = dtPayment;
                objVoucher.VoucherGridSelf(grdVoucherDetails);
                grdVoucherDetails.Columns["ServiceCostAmount"].Width = 100;
                grdVoucherDetails.Columns["IntiqalTaxId"].Visible = false;

                if (grdVoucherDetails.Rows.Count > 0)
                {
                    objdatagird.SumDataGridColumn(grdVoucherDetails, txtTotalCostVoucher, "ServiceCostAmount");
                }


                grdVoucherDetails.ColumnHeadersHeight = 35;
            }
            catch (Exception ex)
            {

            }

        }





          #endregion

        #region Print Challan
        private void btnPrintVoucher_Click(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 2;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.SelectedMozaId;
                sdcReports.TokenID = this.SelectedTokenId;
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();

            }
        }
        #endregion

    

        public void WEB_SP_INSERT_SDC_ReceiptVoucherDetail()
        {

            try
            {
                if (cmbRPaymentofSource.SelectedIndex == 1)
                {

                    dtRChalanFormDate.Text = dtRTokenDate.Value.ToShortDateString();
                }
                //if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                    string @RVDetailId = this.txtRVDetailid.Text.ToString();
                    string @RVId = this.txtRVID.Text.ToString();
                    string @PVDetailId = this.txtPVDetailID.Text.ToString();
                    string @RVDetailSeqNo = this.txtRvsequence.Text.ToString();
                    string @TaxNotificationDetailId = cmbRServices.SelectedValue.ToString();
                    string @NetPayableAmount = this.txtRAmounttoPay.Text.ToString();
                    string @PaymentTypeId = cmbRPaymentofSource.SelectedValue.ToString();
                    string @ReceivedAmountv = this.txtRAmountRecieve.Text.ToString();
                    string @ChallanNo = txtRChalanFormNum.Text.ToString();
                    string @ChallanDate = dtRChalanFormDate.Value.ToShortDateString();
                    string @BankAccountNo = txtRAccountNo.Text.ToString();
                    string @BankName = txtRBankName.Text.ToString();
                    string @BankBranchName = txtRBankBranch.Text.ToString();
                    string @InsertUserId = UsersManagments.UserId.ToString();
                    string @InsertLoginName = UsersManagments.UserName.ToString();
                    string @UpdateUserId = UsersManagments.UserId.ToString();
                    string @UpdateLoginName = UsersManagments.UserName.ToString();

                    dt = objfrmRecipt.SaveRecptDetails(@RVDetailId, @RVId, @PVDetailId, @RVDetailSeqNo, @TaxNotificationDetailId, @NetPayableAmount, @PaymentTypeId, @ReceivedAmountv, @ChallanNo, @ChallanDate, @BankAccountNo, @BankName, @BankBranchName, @InsertUserId, @InsertLoginName, @UpdateUserId, @UpdateLoginName);
                    if (dt != null)
                    {

                        call_Details_Recipt_Grd();
                        objtoken.errorNumeric.SetError(txtRAmountRecieve, "");
                        objtoken.errorChar.SetError(txtRAmountRecieve, "");
                    }
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        #region Search Token
        private void btnSearchToken_Click_1(object sender, EventArgs e)
        {
            grdPersonKatajats.DataSource = null;
            gridviewPersonNames.DataSource = null;
            gridviewSavedRecord.DataSource = null;
            countSelectedPersons = 0;
            selectedPersons = "";
           
            txtName.Clear();
            txtFName.Clear();
            
            if (txtReciptTokenID.Enabled)
            {
                if (txtReciptTokenID.Text.Trim().Length > 0)
                {
                    this.TokenRetrieve = Intiq.GetNonTransactionalFard(this.txtReciptTokenID.Text, dtTokenAndrajDate.Value.ToShortDateString());

                    if (TokenRetrieve.Rows.Count > 0)
                    {
                        foreach (DataRow data in TokenRetrieve.Rows)
                        {
                            this.SelectedMozaId = data["MozaId"].ToString();
                            this.SelectedTokenId = data["TokenId"].ToString();
                            this.SelectedTokenNo = data["TokenNo"].ToString(); 
                            this.tokenDate = Convert.ToDateTime(data["TokenDate"]);
                            pvstatus = Convert.ToBoolean(data["pvstatus"].ToString());
                            if (pvstatus)
                            {
                                btnSavePersons.Enabled = false;
                                btnDelPersons.Enabled = false;
                            }
                            else
                            {
                                btnSavePersons.Enabled = true;
                                btnDelPersons.Enabled = true;
                            }

                            this.tabControl1.SelectedIndex = 0;


                            txtMoza.Text = data["MozaNameUrdu"].ToString();
                            txtReciptTokenID.Text = this.SelectedTokenNo;
                            txtReciptTokenID.Enabled = false;
                            txtFardType.Text = data["TokenPurpose_Urdu"].ToString();
                            txtHiddenServiceTypeId.Text = data["ServiceTypeId"].ToString();
                            dtTokenAndrajDate.Value = Convert.ToDateTime(data["TokenDate"]);
                            dtTokenAndrajDate.Enabled = false;
                            getOperatorReport();
                            GetPersonSavedRecord(SelectedTokenId);




                        }
                    }
                    else
                    {
                        MessageBox.Show("فردات میں مطلوبہ ٹوکن کا ریکارڈ نہیں مل سکا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ٹوکن نمبر درج کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                frmSearch searchToken = new frmSearch();
                searchToken.fromform = "4";
                searchToken.FormClosed -= new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.FormClosed += new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.ShowDialog();
            }
        }
        #endregion

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            if (txtReciptTokenID.Enabled && txtReciptTokenID.Text.Trim().Length == 0)
            {
                dtTokenAndrajDate.Enabled = false;
                txtReciptTokenID.Enabled = false;
            }
            else
            {
                dtTokenAndrajDate.Enabled = true;
                txtReciptTokenID.Enabled = true;
            }

            this.SelectedTokenId = "-1";
            gridviewPersonNames.DataSource = null;
            grdPersonKatajats.DataSource = null;
            gridviewSavedRecord.DataSource = null;
            
            grdVoucherDetails.DataSource = null;
            grdRecipt.DataSource = null;


            txtMoza.Clear();
            txtReciptTokenID.Clear();
            txtFardType.Clear();
            txtHiddenServiceTypeId.Clear();
        }

        #region Fill Person Gridview

        private void FillPersonGridview(DataTable datatable)
        {
            if (datatable.Rows.Count > 0)
            {

                this.gridviewPersonNames.DataSource = datatable;
                this.gridviewPersonNames.Columns["PersonFullName"].HeaderText = "نام مالک";
                this.gridviewPersonNames.Columns["PersonId"].Visible = false;
                this.gridviewPersonNames.Columns["CNIC"].Visible = false;
                this.gridviewPersonNames.Columns["MozaId"].Visible = false;
                this.gridviewPersonNames.Columns["QoamId"].Visible = false;
                this.gridviewPersonNames.Columns["PersonName"].Visible = false;
                this.gridviewPersonNames.Columns["FatherName"].Visible = false;

            }
        }

        #endregion

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            grdPersonKatajats.DataSource = null;
            countSelectedPersons = 0;
            selectedPersons = "";
            if (txtReciptTokenID.Text.Length > 0)
            {

           
            if ((txtName.Text.Trim() != "" || txtFName.Text.Trim() != ""))
            {

                this.PersonName = txtName.Text.Trim();
                this.FatherName = txtFName.Text.Trim();
                this.Persons = null;
                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Searched_Afrad_List "+UsersManagments._Tehsilid.ToString()+"," + this.SelectedMozaId + ",1, N'" + PersonName + "',N'" + FatherName + "'");
                if (this.Persons != null)
                {
                    this.FillPersonGridview(Persons);
                }
            }
            }
            else
            {
                MessageBox.Show("ٹوکن سلیکٹ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridviewPersonNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    gridviewPersonNames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (e.ColumnIndex == gridviewPersonNames.CurrentRow.Cells["colchk"].ColumnIndex)
                    {
                        int b = Convert.ToInt32(gridviewPersonNames.CurrentRow.Cells["colchk"].Value);

                        if (b == 1)
                        {
                            gridviewPersonNames.CurrentRow.Cells["colchk"].Value = 0;
                           countSelectedPersons -= 1;
                        }
                        else
                        {
                            gridviewPersonNames.CurrentRow.Cells["colchk"].Value = 1;
                           countSelectedPersons += 1;
                        }
                    }
                }

                //string PersonId = "0";
                // Check box column check uncheck.
                //DataGridView g = sender as DataGridView;
                //foreach (DataGridViewRow row in g.Rows)
                //{
                //    if (row.Cells["colchk"].RowIndex == e.RowIndex)
                //    {
                //        row.Cells["colchk"].Value = true;
                //    }
                //    else
                //    {
                //        row.Cells["colchk"].Value = false;
                //    }
                //}

                // Get Malikiat Information
               // PersonId = g.Rows[e.RowIndex].Cells["PersonId"].Value.ToString();

                //if (PersonId != "0")
                //{
                     
                //        GetPersonKhattas(PersonId);
                    
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Get Person Khattas

        private void GetPersonKhattas(string PersonId)
        {
            chkAll.Visible = false;
            chkAll.Checked = false;
            DataTable dtKhattas = new DataTable();
            //self----------------------------------
           // dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_ForShortFard " + this.SelectedMozaId + "," + PersonId);
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_ForShortFard1 " + this.SelectedMozaId + "," + PersonId);
            
            //---------------------------------------
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas.Rows.Count > 0)
            {
                chkAll.Visible = true;
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ";
                grdPersonKatajats.Columns["khatooniNo"].HeaderText = "کھتونی";
                //grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Hissa"].HeaderText = "حصہ";
                //grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["Malik_Area"].HeaderText = "رقبہ";
               // grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
               // grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";

                grdPersonKatajats.Columns["TotalParts"].Visible = false;
                //grdPersonKatajats.Columns["Khata_Area"].Visible = false;
                //grdPersonKatajats.Columns["RecordLockedDetails"].Visible = false;
                //grdPersonKatajats.Columns["HissaDifference"].Visible = false;
                grdPersonKatajats.Columns["KhewatGroupFareeqId"].Visible = false;
                grdPersonKatajats.Columns["PersonId"].Visible = false;
                //grdPersonKatajats.Columns["KhewatGroupId"].Visible = false;
                grdPersonKatajats.Columns["Kanal"].Visible = false;
                grdPersonKatajats.Columns["Marla"].Visible = false;
                grdPersonKatajats.Columns["Sarsai"].Visible = false;
                grdPersonKatajats.Columns["Feet"].Visible = false;
                grdPersonKatajats.Columns["Khata_Kanal"].Visible = false;
                grdPersonKatajats.Columns["Khata_Marla"].Visible = false;
                grdPersonKatajats.Columns["Khata_Sarsai"].Visible = false;
                grdPersonKatajats.Columns["Khata_Feet"].Visible = false;
               // grdPersonKatajats.Columns["Khata_Area"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["KhewatTypeId"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Hissa"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Kanal"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Marla"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Sarsai"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Feet"].Visible = false;
                grdPersonKatajats.Columns["MushtriFareeqId"].Visible = false;
                grdPersonKatajats.Columns["khatoonid"].Visible = false;
                grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value = 1;
                chkAll.Checked = true;


                for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                {

                    grdPersonKatajats.Rows[i].Cells["cbgrid"].Value = true;
                }

            }
            else
            {
                
                this.grdPersonKatajats.DataSource = null;
                MessageBox.Show("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
          

        }

        #endregion


        #region Get Person Khatoonies

        private void GetPersonKhaoonies(string PID)
        {

            grdPersonKatajats.DataSource = null;
            DataTable dtKhatoonies = new DataTable();
            dtKhatoonies = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_Khatoonies_ForShortFard " + PID);
            this.grdPersonKatajats.DataSource = dtKhatoonies;
            if (dtKhatoonies.Rows.Count > 0)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdPersonKatajats.Columns["Hissa"].HeaderText = "حصہ";
                grdPersonKatajats.Columns["Malik_Area"].HeaderText = "رقبہ";

                grdPersonKatajats.Columns["MushtriFareeqId"].Visible = false;
                grdPersonKatajats.Columns["PersonId"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["KhewatTypeId"].Visible = false;
                grdPersonKatajats.Columns["KhatooniId"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Hissa"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Kanal"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Marla"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Sarsai"].Visible = false;
                grdPersonKatajats.Columns["Khatooni_Feet"].Visible = false;
                grdPersonKatajats.Columns["kanal"].Visible = false;
                grdPersonKatajats.Columns["marla"].Visible = false;
                grdPersonKatajats.Columns["sarsai"].Visible = false;
                grdPersonKatajats.Columns["feet"].Visible = false;

            }
            else
            {
                if (grdPersonKatajats.Columns.Contains("cbgriddetail") == true)
                {
                    grdPersonKatajats.Columns.Remove("cbgriddetail");
                }
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }


           
        }

        #endregion

        #region Get Person Saved Records

        private void GetPersonSavedRecord(string TokenId)
        {
            chkAllSaved.Visible = false;
            chkAllSaved.Checked = false;
            DataTable dtSaved = new DataTable();
            //self----------------------------------
            dtSaved = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_SavedRecord_of_ShortFard " + this.SelectedTokenId);
            //---------------------------------------
            this.gridviewSavedRecord.DataSource = dtSaved;
            if (dtSaved.Rows.Count > 0)
            {
                chkAllSaved.Visible = true;
                gridviewSavedRecord.Columns["KhataNo"].HeaderText = "کھاتہ";
                gridviewSavedRecord.Columns["KhatooniNo"].HeaderText = "کھتونی";
                gridviewSavedRecord.Columns["CompleteName"].HeaderText = "نام";
                gridviewSavedRecord.Columns["FardAreaPart"].HeaderText = "حصہ";
                gridviewSavedRecord.Columns["Malik_Area"].HeaderText = "مالک کا رقبہ";
                

                gridviewSavedRecord.Columns["fardpersonrecId"].Visible = false;
                gridviewSavedRecord.Columns["FardMushteriRecId"].Visible = false;
                gridviewSavedRecord.Columns["fardKhataRecId"].Visible = false;
                gridviewSavedRecord.Columns["FardKhatooniRecId"].Visible = false;
                gridviewSavedRecord.Columns["RegisterHqDKhataId"].Visible = false;
                gridviewSavedRecord.Columns["KhatooniId"].Visible = false;
                gridviewSavedRecord.Columns["khewatgroupfareeqId"].Visible = false;
                gridviewSavedRecord.Columns["Mushtrifareeqid"].Visible = false;
              

            }
            else
            {

                this.gridviewSavedRecord.DataSource = null;
            }



        }

        #endregion

        private void grdPersonKatajats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                grdPersonKatajats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == grdPersonKatajats.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value = 0;
                    }
                    else
                    {
                        grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value = 1; 
                    }
                }


                if (this.grdPersonKatajats.Rows.Count > 0)
                {
                   
                    int aa = 0;
                   
                    for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                    {
                        
                        int b = Convert.ToInt32(grdPersonKatajats.Rows[i].Cells["cbgrid"].Value);
                        if (b == 1)
                        {
                            aa = aa + 1;

                        }
                       
                    }

                    if (aa == this.grdPersonKatajats.Rows.Count)
                    {
                        chkAll.Checked = true;
                    }
                    else
                    {
                        chkAll.Checked = false;
                    }

                   

                }
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (this.grdPersonKatajats.Rows.Count > 0)
            {

                for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                {

                    if (chkAll.Checked)
                    {

                        grdPersonKatajats.Rows[i].Cells["cbgrid"].Value = true;
                        

                    }
                    else
                    {
                        grdPersonKatajats.Rows[i].Cells["cbgrid"].Value = false;
                        
                    }
                }


            }
        }

        private void btnSavePersons_Click(object sender, EventArgs e)
        {
            int countSelectedRecord=0;
            for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(grdPersonKatajats.Rows[i].Cells["cbgrid"].Value) == 1)
                {
                    countSelectedRecord += 1;
                }
            }
                    if (countSelectedRecord < 1)
                    {
                        MessageBox.Show("کم از کم ایک ریکارڈ سیلیکٹ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                 
            if (this.grdPersonKatajats.Rows.Count > 0)
            {
                
                string fardKhataRecId = "-1";
                string FardKhatooniRecId = "-1";
                string fardpersonrecId = "-1";
                string FardMushteriRecId = "-1";

                for (int j = 0; j <= grdPersonKatajats.Rows.Count - 1; j++)
                {
                    if (Convert.ToInt32(grdPersonKatajats.Rows[j].Cells["cbgrid"].Value) == 1)
                    {

                        //++++++++++++++++ check if already khata, khtooni, malik or mushtri exist  ==============================
                        if (gridviewSavedRecord.Rows.Count > 0)
                        {
                             
                             fardKhataRecId = "-1";
                             FardKhatooniRecId = "-1";
                             fardpersonrecId = "-1";
                             FardMushteriRecId = "-1";
                            foreach (DataGridViewRow row in gridviewSavedRecord.Rows)
                            {
                                if (grdPersonKatajats.Rows[j].Cells["RegisterHqDKhataId"].Value.ToString() == row.Cells["RegisterHqDKhataId"].Value.ToString())
                                    {
                                       
                                        fardKhataRecId = row.Cells["fardKhataRecId"].Value.ToString(); 
                                        break;
                                    }
                            }

                            foreach (DataGridViewRow row in gridviewSavedRecord.Rows)
                            {
                                if (grdPersonKatajats.Rows[j].Cells["khatoonid"].Value.ToString() == row.Cells["KhatooniId"].Value.ToString())
                                {
                                    
                                    FardKhatooniRecId = row.Cells["FardKhatooniRecId"].Value.ToString();
                                    break;
                                }
                            }

                            foreach (DataGridViewRow row in gridviewSavedRecord.Rows)
                            {
                                if (grdPersonKatajats.Rows[j].Cells["KhewatGroupFareeqId"].Value.ToString() == row.Cells["khewatgroupfareeqId"].Value.ToString())
                                {
                                   
                                    fardpersonrecId = row.Cells["fardpersonrecId"].Value.ToString();
                                    break;
                                }
                            }

                            foreach (DataGridViewRow row in gridviewSavedRecord.Rows)
                            {
                                if (grdPersonKatajats.Rows[j].Cells["MushtriFareeqId"].Value.ToString() == row.Cells["Mushtrifareeqid"].Value.ToString())
                                {
                                   
                                    FardMushteriRecId = row.Cells["FardMushteriRecId"].Value.ToString();
                                    break;
                                }
                            }

                        }




                        //=============================== end =========================================================================


                        string TotalParts = grdPersonKatajats.Rows[j].Cells["TotalParts"].Value.ToString();
                        string Hissa = grdPersonKatajats.Rows[j].Cells["Hissa"].Value.ToString();
                        string KhewatGroupFareeqId = grdPersonKatajats.Rows[j].Cells["KhewatGroupFareeqId"].Value.ToString();
                        string KhewatTypeId = grdPersonKatajats.Rows[j].Cells["KhewatTypeId"].Value.ToString();
                        string PersonId = grdPersonKatajats.Rows[j].Cells["PersonId"].Value.ToString();
                        string feet = grdPersonKatajats.Rows[j].Cells["feet"].Value.ToString();
                        string Kanal = grdPersonKatajats.Rows[j].Cells["Kanal"].Value.ToString();
                        string Marla = grdPersonKatajats.Rows[j].Cells["Marla"].Value.ToString();
                        string Sarsai = grdPersonKatajats.Rows[j].Cells["Sarsai"].Value.ToString();
                        string Feet = grdPersonKatajats.Rows[j].Cells["Feet"].Value.ToString();
                        string Khata_Kanal = grdPersonKatajats.Rows[j].Cells["Khata_Kanal"].Value.ToString();
                        string Khata_Marla = grdPersonKatajats.Rows[j].Cells["Khata_Marla"].Value.ToString();
                        string Khata_Sarsai = grdPersonKatajats.Rows[j].Cells["Khata_Sarsai"].Value.ToString();
                        string Khata_Feet = grdPersonKatajats.Rows[j].Cells["Khata_Feet"].Value.ToString();
                        string RegisterHqDKhataId = grdPersonKatajats.Rows[j].Cells["RegisterHqDKhataId"].Value.ToString();

                        string MushtriFareeqId = grdPersonKatajats.Rows[j].Cells["MushtriFareeqId"].Value.ToString();
                        string khatoonid = grdPersonKatajats.Rows[j].Cells["khatoonid"].Value.ToString();
                        string Khatooni_Hissa = grdPersonKatajats.Rows[j].Cells["Khatooni_Hissa"].Value.ToString();
                        string Khatooni_Kanal = grdPersonKatajats.Rows[j].Cells["Khatooni_Kanal"].Value.ToString();
                        string Khatooni_Marla = grdPersonKatajats.Rows[j].Cells["Khatooni_Marla"].Value.ToString();
                        string Khatooni_Sarsai = grdPersonKatajats.Rows[j].Cells["Khatooni_Sarsai"].Value.ToString();
                        string Khatooni_Feet = grdPersonKatajats.Rows[j].Cells["Khatooni_Feet"].Value.ToString();

                        if(MushtriFareeqId=="-1")
                        {
                            string lastId = Intiq.WEB_Self_SP_INSERT_ShortFard_Khattajat_KhewatGroupFareeqein(fardpersonrecId, fardKhataRecId ,this.SelectedTokenId.ToString(), RegisterHqDKhataId.ToString(), TotalParts, Khata_Kanal, Khata_Marla, Khata_Sarsai, Khata_Feet, PersonId.ToString(), KhewatGroupFareeqId, Hissa, Kanal, Marla, Sarsai, Feet, KhewatTypeId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        }
                        else
                        {
                           string lastId = Intiq.WEB_Self_SP_INSERT_ShortFard_Khattajat_Khatoonies_MushtriFareeqein(FardMushteriRecId, FardKhatooniRecId, fardKhataRecId, this.SelectedTokenId.ToString(), RegisterHqDKhataId.ToString(), TotalParts, Khata_Kanal, Khata_Marla, Khata_Sarsai, Khata_Feet,khatoonid,Khatooni_Hissa, Khatooni_Kanal, Khatooni_Marla, Khatooni_Sarsai, Khatooni_Feet , PersonId.ToString(), MushtriFareeqId, Hissa, Kanal, Marla, Sarsai, Feet, KhewatTypeId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        
                        }
                        GetPersonSavedRecord(SelectedTokenId);
                    }
                }


            }

           
          
        }

        private void gridviewSavedRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                gridviewSavedRecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == gridviewSavedRecord.CurrentRow.Cells["colChkSaved"].ColumnIndex)
                {
                    int b = Convert.ToInt32(gridviewSavedRecord.CurrentRow.Cells["colChkSaved"].Value);

                    if (b == 1)
                    {
                        gridviewSavedRecord.CurrentRow.Cells["colChkSaved"].Value = 0;
                    }
                    else
                    {
                        gridviewSavedRecord.CurrentRow.Cells["colChkSaved"].Value = 1; ;
                    }
                }


                if (this.gridviewSavedRecord.Rows.Count > 0)
                {

                    int aa = 0;

                    for (int i = 0; i <= gridviewSavedRecord.Rows.Count - 1; i++)
                    {

                        int b = Convert.ToInt32(gridviewSavedRecord.Rows[i].Cells["colChkSaved"].Value);
                        if (b == 1)
                        {
                            aa = aa + 1;

                        }

                    }

                    if (aa == this.gridviewSavedRecord.Rows.Count)
                    {
                        chkAllSaved.Checked = true;
                    }
                    else
                    {
                        chkAllSaved.Checked = false;
                    }



                }
            }
        }

        private void chkAllSaved_Click(object sender, EventArgs e)
        {
            if (this.gridviewSavedRecord.Rows.Count > 0)
            {

                for (int i = 0; i <= gridviewSavedRecord.Rows.Count - 1; i++)
                {

                    if (chkAllSaved.Checked)
                    {

                        gridviewSavedRecord.Rows[i].Cells["colChkSaved"].Value = true;


                    }
                    else
                    {
                        gridviewSavedRecord.Rows[i].Cells["colChkSaved"].Value = false;

                    }
                }


            }
        }

        private void btnDelPersons_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی کھاتہ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                int countSelectedRecord = 0;
                for (int i = 0; i <= gridviewSavedRecord.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(gridviewSavedRecord.Rows[i].Cells["colChkSaved"].Value) == 1)
                    {
                        countSelectedRecord += 1;
                    }
                }
                if (countSelectedRecord < 1)
                {
                    MessageBox.Show("کم از کم ایک ریکارڈ سیلیکٹ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (this.gridviewSavedRecord.Rows.Count > 0)
                {

                    for (int j = 0; j <= gridviewSavedRecord.Rows.Count - 1; j++)
                    {
                        if (Convert.ToInt32(gridviewSavedRecord.Rows[j].Cells["colChkSaved"].Value) == 1)
                        {
                            string fardpersonrecId = gridviewSavedRecord.Rows[j].Cells["fardpersonrecId"].Value.ToString();
                            string FardMushteriRecId = gridviewSavedRecord.Rows[j].Cells["FardMushteriRecId"].Value.ToString();
                            string fardKhataRecId = gridviewSavedRecord.Rows[j].Cells["fardKhataRecId"].Value.ToString();
                            string FardKhatooniRecId = gridviewSavedRecord.Rows[j].Cells["FardKhatooniRecId"].Value.ToString();
                            
                            string lastId = Intiq.WEB_Self_SP_DELETE_ShortFard_Record(fardpersonrecId, FardMushteriRecId, fardKhataRecId, FardKhatooniRecId);

                            
                        }
                    }


                }
                GetPersonSavedRecord(SelectedTokenId);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {

                case 0:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            if (pvstatus)
                            {
                                btnSavePersons.Enabled = false;
                                btnDelPersons.Enabled = false;
                            }
                            else
                            {
                                btnSavePersons.Enabled = true;
                                btnDelPersons.Enabled = true;
                            }
                        }
                        break;
                    }

                case 1:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            btnSavePersons.Enabled = false;
                            btnDelPersons.Enabled = false;
                        }
                        break;
                    }

                case 2:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            btnSavePersons.Enabled = false;
                            btnDelPersons.Enabled = false;
                            txtTotalRs.Clear();
                            txtQuantity.Clear();
                            txtVoucherDetailsLastID.Text = "-1";
                            txtTotalCostVoucher.Clear();

                            grdVoucherDetails.DataSource = null;
                            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId "+UsersManagments._Tehsilid.ToString()+",'" + this.SelectedTokenId.ToString() + "'," + "P");


                            if (dtPayment.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtPayment.Rows)
                                {
                                   
                                    txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                    txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                  
                                    this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                   
                                    this.txtVoucherNo.Text = dr["PV_No"].ToString();
                                    dtChallan.Text = dr["PV_Date"].ToString();
                                    txtPVID.Text = dr["PVID"].ToString();
                                    txtPVNo.Text = dr["PV_No"].ToString();
                                    pvstatus = Convert.ToBoolean(dr["PV_Verified_Status"]);
                                    btnMasterSave.Enabled = false;

                                    txtQuantity.Enabled = true;

                                    txtServiceName.Enabled = true;
                                    Proc_Get_SDC_Services_For_PaymentVoucher();
                                    calldataGrid();

                                    if (pvstatus)
                                    {

                                        btnSave.Enabled = false;

                                        chkMasterVoucherUpdate.Checked = true;
                                        chkMasterVoucherUpdate.Enabled = false;
                                        lbPaymentTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnSave.Enabled = true;
                                        chkMasterVoucherUpdate.Enabled = true;

                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";

                                    }

                                }
                            }

                            else
                            {
                                txtServiceName.DataSource = null;
                                txtServiceName.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId '" + this.SelectedTokenId.ToString() + "' ");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                      
                                        txtRName.Text = dr["Visitor_Name"].ToString();
                                        txtRFatherName.Text= dr["Visitor_FatherName"].ToString();
                                     
                                        this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                        txtPVID.Text = "-1";
                                        txtPVNo.Text = "-1";
                                        this.txtVoucherNo.Clear();
                                        dtChallan.Value = DateTime.Now;
                                       
                                        btnSave.Enabled = false;
                                        txtQuantity.Enabled = false;

                                        txtServiceName.Enabled = false;
                                        btnMasterSave.Enabled = true;
                                        pvstatus = false;


                                        chkMasterVoucherUpdate.Enabled = true;
                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";


                                    }
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }

                // ======== TAB Receipt ===================================================


                case 3:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            btnSavePersons.Enabled = false;
                            btnDelPersons.Enabled = false;
                            txtRNo.Text = "-1";
                            txtRPVID.Clear();
                            txtPVDetailID.Clear();
                            txtRVID.Text = "-1";
                            txtReciptNo.Clear();
                            txtRFatherName.Clear();
                           
                            txtRName.Clear();
                          
                            dtReciptDate.Value = DateTime.Now;
                            

                            grdRecipt.DataSource = null;
                            txtTotPaymentRecived.Clear();
                            txtNetAmountToPay.Clear();

                            chkVerfiedReciptMaster.Enabled = true;
                            chkVerfiedReciptMaster.Checked = false;



                            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List "+UsersManagments._Tehsilid.ToString(), cmbRPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
                            dtReceipt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_ReceiptVoucherMaster_List_By_TokenId "+UsersManagments._Tehsilid.ToString()+",'" + this.SelectedTokenId.ToString() + "' ");


                            if (dtReceipt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtReceipt.Rows)
                                {
                                    
                                    txtRName.Text = dr["Visitor_Name"].ToString();
                                    txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                    
                                 
                                    txtReciptNo.Text = dr["RVNo"].ToString();
                                    txtRNo.Text = dr["RVNo"].ToString();
                                    dtReciptDate.Text = dr["RVDate"].ToString();
                                    txtRPVID.Text = dr["PVID"].ToString();
                                    txtRVID.Text = dr["RVID"].ToString();
                                    bool rvstatus = Convert.ToBoolean(dr["RV_VerifiedStatus"]);

                                    btnMasterReceiptSave.Enabled = false;
                                    btnRSaveDetails.Enabled = true;
                                    btnRClear.Enabled = true;
                                    cmbRServices.Enabled = true;


                                    if (rvstatus)
                                    {

                                        btnRSaveDetails.Enabled = false;
                                        btnRClear.Enabled = false;
                                        btnDelReceipt.Enabled = false;

                                        chkVerfiedReciptMaster.Checked = true;
                                        chkVerfiedReciptMaster.Enabled = false;
                                        lbReceiptTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnRSaveDetails.Enabled = true;
                                        btnRClear.Enabled = true;
                                        btnDelReceipt.Enabled = true;

                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }

                                    Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId();
                                    call_Details_Recipt_Grd();
                                    btnRClear_Click(sender, e);

                                }
                            }

                            else
                            {
                                cmbRServices.DataSource = null;
                                cmbRServices.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId "+UsersManagments._Tehsilid.ToString()+",'" + this.SelectedTokenId.ToString() + "'," + "R");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        
                                        txtRName.Text = dr["Visitor_Name"].ToString();
                                        txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                       

                                        txtRPVID.Text = dr["PVID"].ToString();
                                    



                                        txtRNo.Text = "-1";
                                        txtRVID.Text = "-1";
                                        txtReciptNo.Clear();
                                        dtReciptDate.Value = DateTime.Now;
                                       

                                        btnMasterReceiptSave.Enabled = true;
                                        btnRSaveDetails.Enabled = false;
                                        btnRClear.Enabled = false;
                                        cmbRServices.Enabled = false;
                                        

                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }



                //=== END TAB Receipt =========================================================

            }
        }

        private void btnMasterSave_Click_1(object sender, EventArgs e)
        {
            dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster '"
             + "-1" + "','"
             + UsersManagments._Tehsilid.ToString() + "','"
             + "-1" + "','"
             + this.dtChallan.Value.ToShortDateString() + "','"
             + this.SelectedTokenId.ToString() + "','"
             + this.MozaId + "','"
              + "Generated" + "',N'" + this.txtMasterRemarks.Text.ToString() + "','"
             + UsersManagments.UserId.ToString() + "','"
             + UsersManagments.UserName.ToString() + "','',''");

            foreach (DataRow dr in dt.Rows)
            {
                txtPVID.Text = dr[0].ToString();
                this.txtPVNo.Text = dr[1].ToString();
                this.txtVoucherNo.Text = dr[1].ToString();
                if (txtPVID.Text != "")
                {
                    btnMasterSave.Enabled = false;
                    btnSave.Enabled = true;
                    txtQuantity.Enabled = true;
                    //txtTotalRs.Enabled = true;
                    txtServiceName.Enabled = true;
                    Proc_Get_SDC_Services_For_PaymentVoucher();

                }
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim().Length > 0)
            {
                double amount = 0;
                double q = Convert.ToDouble(this.txtQuantity.Text.ToString());
                if (q == 0)
                {

                }
                else if (q == 1)
                {
                    amount = 200;
                }
                else if (q > 1 && q < 6)
                {
                    amount = 200 + ((q - 1) * 100);
                }

                else if (q > 5)
                {
                    amount = 600 + ((q - 5) * 75);
                }

                txtTotalRs.Text = amount.ToString();

            }
            else
            {
                txtTotalRs.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServiceName.SelectedIndex == 0)
            {
                MessageBox.Show("- سہولت کا انتخاب کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (txtQuantity.Text.Trim().Length == 0)
            {
                MessageBox.Show("- صفحات کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (txtTotalRs.Text.Trim().Length == 0)
            {
                MessageBox.Show("- رقم کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdVoucherDetails.Rows.Count > 0 && txtVoucherDetailsLastID.Text == "-1")
            {
                MessageBox.Show("ریکارڈ پہلے سے داخل ہے ", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {

                if (Submit())
                {
                    txtVoucherDetailsLastID.Text = "-1";
                    txtSequenceID.Text = "-1";

                    txtServiceName.SelectedIndex = 0;
                    txtTotalRs.Clear();
                    txtQuantity.Clear();

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

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Service_Detail "+UsersManagments._Tehsilid.ToString()+",'" + this.txtServiceName.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {


                    txtNotificationUnitID.Text = dr["TaxNotificationDetailId"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();
                    txtUnit.Text = dr["SDCUnitName_Urdu"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();

                }
            }
        }

      
        private void chkMasterVoucherUpdate_Click_1(object sender, EventArgs e)
        {
            if (chkMasterVoucherUpdate.Checked && txtPVID.Text != "" && grdVoucherDetails.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster "+UsersManagments._Tehsilid.ToString()+",'" + this.txtPVID.Text + "','" + chkMasterVoucherUpdate.Checked + "','" + this.txtTotalCostVoucher.Text.ToString() + "'") != null)
                        {

                            chkMasterVoucherUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnMasterSave.Enabled = false;
                            pvstatus = true;

                            lbPaymentTasdeeq.Text = "تصدیق شدہ";
                        }
                    }
                    else
                    {
                        chkMasterVoucherUpdate.Checked = false;
                        pvstatus = false;
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

        private void grdVoucherDetails_DoubleClick(object sender, EventArgs e)
        {
            if (grdVoucherDetails.Rows.Count > 0)
            {
                txtVoucherDetailsLastID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailId"].Value.ToString();
                txtSequenceID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailSeqNo"].Value.ToString();
                txtQuantity.Text = grdVoucherDetails.CurrentRow.Cells["ServiceQuantity"].Value.ToString();

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
        }

        private void btnMasterReceiptSave_Click(object sender, EventArgs e)
        {
            try
            {
                {


                    //if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_ReceiptVoucherMaster "+UsersManagments._Tehsilid.ToString()+",'" + this.txtRVID.Text.ToString() + "','" + this.txtRNo.Text.ToString() + "','" + UsersManagments._Tehsilid.ToString() + "','" + this.SelectedMozaId.ToString() + "','" + this.dtReciptDate.Value.ToShortDateString() + "','" + this.SelectedTokenId.ToString() + "',N'" + txtMasterRemarks.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
                    if (dt != null)
                    {


                        foreach (DataRow dr in dt.Rows)
                        {
                            this.txtReciptNo.Text = dr[1].ToString();
                            this.txtRVID.Text = dr[0].ToString();
                            this.txtRNo.Text = dr[1].ToString();

                        }
                        txtRvsequence.Text = "-1";
                        txtRVDetailid.Text = "-1";
                        btnMasterReceiptSave.Enabled = false;
                        btnRClear.Enabled = true;
                        btnRSaveDetails.Enabled = true;
                        cmbRServices.Enabled = true;

                        chkVerfiedReciptMaster.Enabled = true;
                        chkVerfiedReciptMaster.Checked = false;

                        Proc_Get_SDC_PaymentVoucherDetail_BY_VoucherId();

                    }

                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void groupBox24_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbRServices.SelectedIndex == 0)
            {

                txtRAmounttoPay.Text = "";
                txtRAccountNo.Text = "";
                txtRBankBranch.Text = "";
                txtRBankName.Text = "";
                txtRChalanFormNum.Text = "";
                txtRAmountRecieve.Text = "";
                cmbRPaymentofSource.SelectedIndex = 0;

            }
            else
            {
                string cmbRServiceSelectedValue  ;
                if (cmbRServices.SelectedValue == null)
                {
                    cmbRServiceSelectedValue = "-1";
                }
                else
                {
                    cmbRServiceSelectedValue = cmbRServices.SelectedValue.ToString();
                }
                if(this.txtRPVID.Text==null)
                {
                    txtRPVID.Text = "-1";
                }
                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt "+UsersManagments._Tehsilid.ToString()+",'" + this.txtRPVID.Text + "','" + cmbRServiceSelectedValue + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtRAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
                    this.txtRAmountRecieve.Text = dr["ServiceCostAmount"].ToString();
                    this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
                    this.cmbRPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
                }


            }
        }

        private void btnRSaveDetails_Click(object sender, EventArgs e)
        {
            ArrayList Labels = new ArrayList();
            Labels.Add(label50.Text);
            Labels.Add(label47.Text);
            Labels.Add("بینک چالان فارم نمبر");


            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.cmbRServices.Text.ToString());
            collection.Add(this.txtRAmountRecieve.Text.ToString());
            collection.Add(this.txtRChalanFormNum.Text.ToString());


            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "--انتخاب کریں--")
                {
                    empty += "," + Labels[i].ToString();

                }

            }
            bool isExists = false;
            if (grdRecipt.Rows.Count > 0 && txtRVDetailid.Text == "-1")
            {
                foreach (DataGridViewRow row in grdRecipt.Rows)
                {
                    if (this.cmbRServices.SelectedValue.ToString() == row.Cells["TaxNotificationDetailId"].Value.ToString())
                    {
                        isExists = true;
                        break;
                    }
                }

            }
            if (!isExists)
            {

                if (empty == null)
                {
                    WEB_SP_INSERT_SDC_ReceiptVoucherDetail();
                    objtoken.errorNumeric.SetError(txtRAmountRecieve, "");

                    txtRVDetailid.Text = "-1";
                    txtRvsequence.Text = "-1";
                    cmbRServices.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(empty + "- کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (txtRAmountRecieve.Text == "" || txtRAmountRecieve.Text == null || txtRAmountRecieve.Text == string.Empty)
                    {
                        objtoken.errorChar.SetError(txtRAmountRecieve, "Error");
                    }
                }

            }
            else
            {
                MessageBox.Show("ریکارڈ پہلے سے موجود ہے:::::", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnRClear_Click(object sender, EventArgs e)
        {
            this.txtRVDetailid.Text = "-1";
            btnDelReceipt.Enabled = false;
            cmbRPaymentofSource.SelectedIndex = 0;
            cmbRServices.SelectedIndex = 0;
            txtRAmounttoPay.Clear();
            txtRAmountRecieve.Clear();
            txtRChalanFormNum.Clear();
            dtRChalanFormDate.Value = DateTime.Now;
        }

        private void btnDelReceipt_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {

                    mnk.DeleteDetailedReceipt(txtRVDetailid.Text);
                    btnRClear_Click(sender, e);
                    call_Details_Recipt_Grd();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (this.txtRVID.Text.ToString() != "-1")
            {
                UsersManagments.check = 3;
                frmSDCReportingMain TokenReport = new frmSDCReportingMain();

                TokenReport.RVID = this.txtRVID.Text.ToString();
                TokenReport.Tehsilid = UsersManagments._Tehsilid.ToString();
                TokenReport.ShowDialog();
            }
        }

        private void chkVerfiedReciptMaster_Click(object sender, EventArgs e)
        {
            if (txtTotPaymentRecived.Text != "" & txtNetAmountToPay.Text != "" && txtRVID.Text != "" && grdRecipt.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster "+UsersManagments._Tehsilid.ToString()+",'" + txtRVID.Text + "','" + chkVerfiedReciptMaster.Checked + "',''");

                        this.chkVerfiedReciptMaster.Enabled = false;
                        this.btnDelReceipt.Enabled = false;
                        this.btnRSaveDetails.Enabled = false;
                        this.btnRClear.Enabled = false;
                        lbReceiptTasdeeq.Text = "تصدیق شدہ";
                    }
                    else
                    {
                        chkVerfiedReciptMaster.Checked = false;
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
                chkVerfiedReciptMaster.Checked = false;
            }
        }

        private void grdRecipt_DoubleClick(object sender, EventArgs e)
        {
            this.txtRvsequence.Text = grdRecipt.CurrentRow.Cells["RVDetailSeqNo"].Value.ToString();
            this.txtRVID.Text = grdRecipt.CurrentRow.Cells["RVId"].Value.ToString();
            this.txtRVDetailid.Text = grdRecipt.CurrentRow.Cells["RVDetailId"].Value.ToString();
            this.txtPVDetailID.Text = grdRecipt.CurrentRow.Cells["PVDetailId"].Value.ToString();
            this.txtRAmounttoPay.Text = grdRecipt.CurrentRow.Cells["NetPayableAmount"].Value.ToString();
            this.txtRAmountRecieve.Text = grdRecipt.CurrentRow.Cells["ReceivedAmount"].Value.ToString();

            this.cmbRPaymentofSource.Text = grdRecipt.CurrentRow.Cells["PaymentType_Urdu"].Value.ToString();
            this.cmbRServices.Text = grdRecipt.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
            this.txtRBankBranch.Text = grdRecipt.CurrentRow.Cells["BankBranchName"].Value.ToString();
            this.txtRBankName.Text = grdRecipt.CurrentRow.Cells["BankName"].Value.ToString();
            this.txtRAccountNo.Text = grdRecipt.CurrentRow.Cells["BankAccountNo"].Value.ToString();
            this.txtRChalanFormNum.Text = grdRecipt.CurrentRow.Cells["ChallanNo"].Value.ToString();
            this.dtRChalanFormDate.Text = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
            objtoken.errorNumeric.SetError(txtRAmountRecieve, "Ok");
            if (this.txtRVDetailid.Text.Trim().Length > 5 && chkVerfiedReciptMaster.Checked==false)
            {
                btnDelReceipt.Enabled = true;
            }
        }

        private void btnSaveOperatorReport_Click(object sender, EventArgs e)
        {
            if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
            {
                if(txtOperatorReport.Text.Trim().Length>3)
                {
                    mnk.InsertDetailedFardOperatorReport(this.SelectedTokenId, txtOperatorReport.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);

                    MessageBox.Show("اپریٹر رپورٹ محفوظ ہو گیا ہے۔");
                }
                else
                {
                    MessageBox.Show("رپورٹ لکھیں۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }

            else
            {
                MessageBox.Show("پہلے ٹوکن منتخب کریں۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void txtOperatorReport_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Print_Click(object sender, EventArgs e)
        {
             if (this.SelectedTokenId != null && this.SelectedTokenId != "0")
            {
                string ReceiptVerified = Intiq.CheckShortFardReceiptVerified(this.SelectedTokenId.ToString(), UsersManagments.UserId.ToString());
                UsersManagments.check = 47;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.SelectedMozaId;
                sdcReports.TokenID = this.SelectedTokenId.ToString();
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ReceiptVerified = ReceiptVerified;
                sdcReports.ShowDialog();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.gridviewPersonNames.Rows.Count > 0)
            {
                selectedPersons = "";
                int count = 0;
                for (int i = 0; i <= gridviewPersonNames.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(gridviewPersonNames.Rows[i].Cells["colchk"].Value) == 1)
                    {
                        count = +1;
                        if(selectedPersons=="")
                        {
                            selectedPersons = gridviewPersonNames.Rows[i].Cells["PersonId"].Value.ToString();
                        }
                        else
                        {
                            selectedPersons = selectedPersons + "," + gridviewPersonNames.Rows[i].Cells["PersonId"].Value.ToString();
                        }
                        
                      
                        
                    }
                }
                if (count>0)
                {
                    GetPersonKhattas("'"+selectedPersons+"'");
                }

            }
            
        }

        private void btnPrintVoucher_Click_1(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 2;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.SelectedMozaId.ToString();
                sdcReports.TokenID = this.SelectedTokenId.ToString();
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();

            }
        }

     

     

    }
}