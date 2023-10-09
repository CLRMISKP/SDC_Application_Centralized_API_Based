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
    public partial class frmDetailedFard : Form
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
       
        DataTable khewatMalikanByFB = new DataTable();
        DataView view;
        DataTable dtKhewatFareeqainByKhataId = new DataTable();
        DataTable dtMushteriFareeqainByKhatooniId = new DataTable();
        DataTable dtFardKhatas = new DataTable();

        public string MaalikType { get; set; }
        public string MozaId { get; set; }
        public string SelectedMozaId { get; set; }
        public string SelectedTokenId { get; set; }
        public string SelectedTokenNo { get; set; }
        public bool isConfirm { get; set; }
        public string Khatoniid {get;set; }

        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }

        #endregion

        #region Default Construction

        public frmDetailedFard()
            {

            InitializeComponent();

            }

        #endregion

        #region Search Token

        private void btnSearchToken_Click(object sender, EventArgs e)
            {
                
                frmSearch searchToken = new frmSearch();
                searchToken.fromform = "2";
                searchToken.FormClosed -= new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.FormClosed += new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.ShowDialog();
            }

        #endregion

        #region Load Token Click Evetn

        private void searchToken_FormClosed(object sender, FormClosedEventArgs e)
            {
               
                btnNewKhata_Click(sender, e);
                frmSearch frm = sender as frmSearch;
                this.SelectedMozaId = frm.mouzaid;
                this.SelectedTokenId = frm.tokenID;
                this.SelectedTokenNo = frm.tokenno;
                txtHiddenServiceTypeId.Text = frm.hiddenservvicetypeid;
                txtReciptTokenID.Text = this.SelectedTokenNo;
                FillKhataJaatByMoza();
                //DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId!=null?this.SelectedTokenId:"0");
                getOperatorReport();
                this.filldgFardKhatas();
                this.tabControl1.SelectedIndex = 0;
           // this.GetFardConfDetails(this.SelectedTokenId);
            }

        #endregion



        #region Fill Khatajat Drop Dowm
        /// <summary>
        /// Fills khattas drop down with the event of moza selection.
        /// </summary>
        private void FillKhataJaatByMoza()
        {
            try
            {
                DataTable khattasByMoza = new DataTable();
                int mozaid = Convert.ToInt32(this.SelectedMozaId);
                if (mozaid != 0)
                {
                    khattasByMoza =mnk.GetMozaKhattajat(mozaid.ToString());
                    DataRow row = khattasByMoza.NewRow();
                    row["RegisterHqDKhataId"] = 0;
                    row["KhataNo"] = "- کھاتہ چنِے -";
                    khattasByMoza.Rows.InsertAt(row, 0);
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = this.khattasByMoza;
                    cbokhataNo.DataSource = khattasByMoza;
                    cbokhataNo.DisplayMember = "KhataNo";
                    cbokhataNo.ValueMember = "RegisterHqDKhataId";
                    cbokhataNo.SelectedIndex = 0;
                }
                else
                {
                    cbokhataNo.DataSource = null;
                    khattasByMoza = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
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
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
            //DataGridViewHelper.addHelpterToAllFormGridViews(this);
        }

        #endregion

        #region Operator Auto Urdu Conversion

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
        #endregion

      
       

      

        #region Fard Khata controls

        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbokhataNo.SelectedValue.ToString()!="0")
                {


                    string lastId = mnk.InsertUpdateDetailedFardKhattas("-1", UsersManagments._Tehsilid.ToString(), SelectedTokenId, "0", cbokhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);

                    this.filldgFardKhatas();
                    txtFardKhataRecId.Text = "-1";
                    if (cbokhataNo.Items.Count > 0)
                        cbokhataNo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnNewKhata_Click(object sender, EventArgs e)
        {
            txtFardKhataRecId.Text = "-1";
            if (cbokhataNo.Items.Count > 0)
                cbokhataNo.SelectedIndex = 0;
        }

        private void btnDelKhata_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی کھاتہ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {

                    mnk.DeleteDetailedFardKhataRecId(txtFardKhataRecId.Text);
                    this.txtFardKhataRecId.Text = "-1";
                    this.filldgFardKhatas();
                    if(cbokhataNo.Items.Count>0)
                    cbokhataNo.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GridViewFardKhatajat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
               
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    foreach(DataGridViewRow row in g.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colCheckKhata"].Value = 1;
                            txtFardKhataRecId.Text = row.Cells["PVKhataRecId"].Value.ToString();
                            string KhataId = row.Cells["PVKhataId"].Value.ToString();
                            cbokhataNo.SelectedValue = row.Cells["PVKhataId"].Value.ToString();
                        
                            
                        }
                        else
                            row.Cells["colCheckKhata"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

      

        #region Fill Grid view Fard Khatajat
        private void filldgFardKhatas()
        {
            this.dtFardKhatas = mnk.GetDetailedFardKhatajat(this.SelectedTokenId != null ? this.SelectedTokenId : "0");
            GridViewFardKhatajat.DataSource = dtFardKhatas;
            GridViewFardKhataJat_KTab.DataSource = dtFardKhatas;
            if (GridViewFardKhatajat.DataSource != null)
            {
                GridViewFardKhatajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                GridViewFardKhatajat.Columns["RecordLockedDetails"].HeaderText = "تفصیل لاک";
                GridViewFardKhatajat.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                GridViewFardKhatajat.Columns["RecordLockedCon"].HeaderText = "لاک شدہ";
                GridViewFardKhatajat.Columns["PVKhataRecId"].Visible = false;
                GridViewFardKhatajat.Columns["PVKhataId"].Visible = false;
                GridViewFardKhatajat.Columns["TotalParts"].Visible = false;
                GridViewFardKhatajat.Columns["Khata_Total_Area"].Visible = false;

                GridViewFardKhataJat_KTab.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                GridViewFardKhataJat_KTab.Columns["RecordLockedDetails"].HeaderText = "تفصیل لاک";
                GridViewFardKhataJat_KTab.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                GridViewFardKhataJat_KTab.Columns["RecordLockedCon"].HeaderText = "لاک شدہ";
                GridViewFardKhataJat_KTab.Columns["PVKhataRecId"].Visible = false;
                GridViewFardKhataJat_KTab.Columns["PVKhataId"].Visible = false;
                GridViewFardKhataJat_KTab.Columns["TotalParts"].Visible = false;
                GridViewFardKhataJat_KTab.Columns["Khata_Total_Area"].Visible = false;
                
            }
            //FillFardKhataForKhanakasht(dtFardKhatas);
        }

       
        #endregion



        #region Print Detailed Fard
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.SelectedTokenId != null && this.SelectedTokenId != "0")
            {

                FardMalikan_Report rptDetail = new FardMalikan_Report();
                rptDetail.TokenID = this.SelectedTokenId;
                rptDetail.isTrans = false;
                rptDetail.ShowDialog();

                //FardMalikan_Report_TTx rptDetail = new FardMalikan_Report_TTx();
                //rptDetail.TokenId = this.SelectedTokenId.ToString();
                ////rptDetail.isTrans = false;
                //rptDetail.ShowDialog();
                
            }
        }
        #endregion

        #region Save Operator Report
        private void btnSaveOperatorReport_Click_1(object sender, EventArgs e)
        {
            if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
            {
                mnk.InsertDetailedFardOperatorReport(this.SelectedTokenId, txtOperatorReport.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);

                MessageBox.Show("اپریٹر رپورٹ محفوظ ہو گیا ہے۔");
            }

            else
            {
                MessageBox.Show("پہلے ٹوکن منتخب کریں۔");
            }
        }
        #endregion

        #region Get services for payment voucher
        public void Proc_Get_SDC_Services_For_PaymentVoucher()
        {

            objauto.FillCombo("Proc_Get_SDC_Services_For_PaymentVoucher  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtHiddenServiceTypeId.Text + "'", txtServiceName, "SDCServiceName_Urdu", "TaxNotificationDetailId");

        }

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId()
        {
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
                                + this.txtRPVID.Text.ToString() + "'", cmbRServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");

            txtRAmounttoPay.Text = "";
        }

        public void call_Details_Recipt_Grd()
        {
            try
            {
                dtGrd = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherDetail_By_RVId "+SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+", '" + this.txtRVID.Text + "'");

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
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
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
                            txtTotalRs.Clear();
                            txtQuantity.Clear();
                            txtVoucherDetailsLastID.Text = "-1";
                            txtTotalCostVoucher.Clear();

                            grdVoucherDetails.DataSource = null;
                            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId "+SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+", '" + this.SelectedTokenId.ToString() + "'," + "P");


                            if (dtPayment.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtPayment.Rows)
                                {
                                    txtTokenNO.Text = dr["TokenNo"].ToString();
                                    dtTokenDate.Text = dr["TokenDate"].ToString();
                                    txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                    txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                    txtMouza.Text = dr["MozaNameUrdu"].ToString();
                                    txtService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                    TxtCNIC.Text = dr["Visitor_CNIC"].ToString();
                                    this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                    txtMasterRemarks.Text = dr["PV_Remarks"].ToString();
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
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        txtTokenNO.Text = dr["TokenNo"].ToString();
                                        dtTokenDate.Text = dr["TokenDate"].ToString();
                                        txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                        txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                        txtMouza.Text = dr["MozaNameUrdu"].ToString();
                                        txtService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                        TxtCNIC.Text = dr["Visitor_CNIC"].ToString();
                                        this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                        txtPVID.Text = "-1";
                                        txtPVNo.Text = "-1";
                                        this.txtVoucherNo.Clear();
                                        dtChallan.Value = DateTime.Now;
                                        txtMasterRemarks.Clear();
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
                            txtRNo.Text = "-1";
                            txtRPVID.Clear();
                            txtPVDetailID.Clear();
                            txtRVID.Text = "-1";

                            txtRChallanNo.Clear();
                            txtRCNIC.Clear();
                            txtReciptNo.Clear();
                            txtRFatherName.Clear();
                            txtRMouza.Clear();
                            txtRName.Clear();
                            txtRRemarks.Clear();
                            txtRService.Clear();
                            txtRTokenNo.Clear();

                            dtRChallanDate.Value = DateTime.Now;
                            dtReciptDate.Value = DateTime.Now;
                            dtRTokenDate.Value = DateTime.Now;

                            grdRecipt.DataSource = null;
                            txtTotPaymentRecived.Clear();
                            txtNetAmountToPay.Clear();

                            chkVerfiedReciptMaster.Enabled = true;
                            chkVerfiedReciptMaster.Checked = false;



                            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbRPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
                            dtReceipt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_ReceiptVoucherMaster_List_By_TokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");


                            if (dtReceipt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtReceipt.Rows)
                                {
                                    txtRTokenNo.Text = dr["TokenNo"].ToString();
                                    dtRTokenDate.Text = dr["TokenDate"].ToString();
                                    txtRService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                    txtRName.Text = dr["Visitor_Name"].ToString();
                                    txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                    txtRMouza.Text = dr["MozaNameUrdu"].ToString();
                                    txtRCNIC.Text = dr["Visitor_CNIC"].ToString();

                                    txtRRemarks.Text = dr["RVRemarks"].ToString();
                                    txtRChallanNo.Text = dr["PV_No"].ToString();
                                    dtRChallanDate.Text = dr["PV_Date"].ToString();
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
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.SelectedTokenId.ToString() + "'," + "R");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        txtRTokenNo.Text = dr["TokenNo"].ToString();
                                        dtRTokenDate.Text = dr["TokenDate"].ToString();
                                        txtRService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                        txtRName.Text = dr["Visitor_Name"].ToString();
                                        txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                        txtRMouza.Text = dr["MozaNameUrdu"].ToString();
                                        txtRCNIC.Text = dr["Visitor_CNIC"].ToString();

                                        txtRPVID.Text = dr["PVID"].ToString();
                                        txtRChallanNo.Text = dr["PV_No"].ToString();
                                        dtRChallanDate.Text = dr["PV_Date"].ToString();



                                        txtRNo.Text = "-1";
                                        txtRVID.Text = "-1";
                                        txtReciptNo.Clear();
                                        dtReciptDate.Value = DateTime.Now;
                                        txtRRemarks.Clear();

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
            if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster '"
                + "-1" + "','"
                + UsersManagments._Tehsilid.ToString() + "','"
                + "-1" + "','"
                + this.dtChallan.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','"
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
        }
        #endregion

        #region Tasdeeq Payment Master
        private void chkMasterVoucherUpdate_Click(object sender, EventArgs e)
        {
            if (chkMasterVoucherUpdate.Checked && txtPVID.Text != "" && grdVoucherDetails.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.txtPVID.Text + "','" + chkMasterVoucherUpdate.Checked + "','" + this.txtTotalCostVoucher.Text.ToString() + "'") != null)
                        {

                            chkMasterVoucherUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnMasterSave.Enabled = false;

                            lbPaymentTasdeeq.Text = "تصدیق شدہ";
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
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

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

                dtPayment = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.txtPVID.Text + "'");

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

        private void txtServiceName_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (txtServiceName.SelectedIndex == 0)
            {

            }

            else
            {

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Service_Detail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtServiceName.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {


                    txtNotificationUnitID.Text = dr["TaxNotificationDetailId"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();
                    txtUnit.Text = dr["SDCUnitName_Urdu"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();

                }
            }
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
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

    

        private void btnMasterReceiptSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                {


                    if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_ReceiptVoucherMaster " + "'" + this.txtRVID.Text.ToString() + "','" + this.txtRNo.Text.ToString() + "','" + UsersManagments._Tehsilid.ToString() + "','" + this.SelectedMozaId.ToString() + "','" + this.dtReciptDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + this.SelectedTokenId.ToString() + "',N'" + txtMasterRemarks.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
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

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtRPVID.Text + "','" + this.cmbRServices.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtRAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
                    this.txtRAmountRecieve.Text = dr["ServiceCostAmount"].ToString();
                    this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
                    this.cmbRPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
                }


            }
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

        private void btnRSaveDetails_Click(object sender, EventArgs e)
        {
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);


            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.cmbRServices.Text.ToString());
            collection.Add(this.txtRAmountRecieve.Text.ToString());


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

        public void WEB_SP_INSERT_SDC_ReceiptVoucherDetail()
        {

            try
            {
                if (cmbRPaymentofSource.SelectedIndex == 1)
                {

                    dtRChalanFormDate.Text = dtRTokenDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                }
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string @RVDetailId = this.txtRVDetailid.Text.ToString();
                    string @RVId = this.txtRVID.Text.ToString();
                    string @PVDetailId = this.txtPVDetailID.Text.ToString();
                    string @RVDetailSeqNo = this.txtRvsequence.Text.ToString();
                    string @TaxNotificationDetailId = cmbRServices.SelectedValue.ToString();
                    string @NetPayableAmount = this.txtRAmounttoPay.Text.ToString();
                    string @PaymentTypeId = cmbRPaymentofSource.SelectedValue.ToString();
                    string @ReceivedAmountv = this.txtRAmountRecieve.Text.ToString();
                    string @ChallanNo = txtRChalanFormNum.Text.ToString();
                    string @ChallanDate = dtRChalanFormDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
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
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + txtRVID.Text + "','" + chkVerfiedReciptMaster.Checked + "',''");

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

        private void grdRecipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            
           // this.dtRChalanFormDate.Text = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
            string challanDateStr = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
            DateTime challanDate;
            bool isValidDate = DateTime.TryParse(challanDateStr, out challanDate);

            if (isValidDate)
            {
                string formattedDate = challanDate.ToString("dd MMM yyyy");
                this.dtRChalanFormDate.Text = formattedDate;
            }
            else
            {
                // Handle the case where the date value is not in a valid format
                this.dtRChalanFormDate.Text = "Invalid date";
            }



            objtoken.errorNumeric.SetError(txtRAmountRecieve, "Ok");
            if (this.txtRVDetailid.Text.Trim().Length > 5)
            {
                btnDelReceipt.Enabled = true;
            }
        }

        private void GridViewFardKhataJat_KTab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                    
                txtKhattaRecId.Text = "-1";
                txtKhatooniRecId.Text = "-1";
                cmbKhatoniNo.DataSource = null;
                grdKhatoniDetails.DataSource = null;

                GridViewFardKhataJat_KTab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == GridViewFardKhataJat_KTab.CurrentRow.Cells["colChoose"].ColumnIndex)
                {
                    int b = Convert.ToInt32(GridViewFardKhataJat_KTab.CurrentRow.Cells["colChoose"].Value);

                    if (b == 1)
                    {
                        GridViewFardKhataJat_KTab.CurrentRow.Cells["colChoose"].Value = 0;
                        this.txtKhattaRecId.Text = "-1";
                       
                    }
                    else
                    {

                        GridViewFardKhataJat_KTab.CurrentRow.Cells["colChoose"].Value = 1;
                        txtKhattaRecId.Text = this.GridViewFardKhataJat_KTab.CurrentRow.Cells["PVKhataRecId"].Value.ToString();
                        string K_KhataId = GridViewFardKhataJat_KTab.CurrentRow.Cells["PVKhataId"].Value.ToString();

                        if (K_KhataId != string.Empty)
                        {
                            AutoFillCombo.FillCombo("dbo.Proc_Get_Khatoonis '" + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "','" + K_KhataId + "'", cmbKhatoniNo, "KhatooniNo", "KhatooniId");
                            GetDetailedFardKhatonies(txtKhattaRecId.Text);
                        }
                        

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKhatoniSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool duplication = true;
                string KhatooniRecId = txtKhatooniRecId.Text.ToString();
                string KhatoniId = this.cmbKhatoniNo.SelectedValue.ToString();
                string FardTokenId = this.SelectedTokenId;
                if (cmbKhatoniNo.SelectedIndex != 0)
                {
                    if (grdKhatoniDetails.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.grdKhatoniDetails.Rows.Count; i++)
                        {
                            if (this.cmbKhatoniNo.SelectedValue.ToString() == this.grdKhatoniDetails.Rows[i].Cells["KhatooniId"].Value.ToString())
                            {
                                duplication = false;
                                break;
                            }
                            else
                            {
                                duplication = true;

                            }
                        }
                        if (duplication)
                        {
                            if(mnk.GetDetailedFardKhatooniParts(KhatoniId)=="1")
                            {
                                string LastId = mnk.SaveDetailedFardKhatoni(KhatooniRecId, FardTokenId, txtKhattaRecId.Text, KhatoniId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                                this.txtKhatooniRecId.Text = "-1";
                                cmbKhatoniNo.SelectedIndex = 0;
                                GetDetailedFardKhatonies(txtKhattaRecId.Text);
                            }
                           
                            else
                            {
                                MessageBox.Show("کھتونی میں ریکارڈ موجود نہیں ہے۔:::::", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                           
                            

                        }
                    }
                    else
                    {
                        if (mnk.GetDetailedFardKhatooniParts(KhatoniId) == "1")
                        {
                            string LastId = mnk.SaveDetailedFardKhatoni(KhatooniRecId, FardTokenId, txtKhattaRecId.Text, KhatoniId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                            this.txtKhatooniRecId.Text = "-1";
                            cmbKhatoniNo.SelectedIndex = 0;
                            GetDetailedFardKhatonies(txtKhattaRecId.Text);
                        }

                        else
                        {
                            MessageBox.Show("کھتونی میں ریکارڈ موجود نہیں ہے۔:::::", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("کھتونی نمبر کا انتخاب کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDetailedFardKhatonies(string KhataRecId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = mnk.GetDetailedFardKhatonies(KhataRecId);
                grdKhatoniDetails.DataSource = dt;
                grdKhatoniDetails.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdKhatoniDetails.Columns["Khatooni_TotalParts"].HeaderText = "کل حصے";
                grdKhatoniDetails.Columns["Khatooni_Area"].HeaderText = "کل رقبہ";
                grdKhatoniDetails.Columns["KhatooniRecId"].Visible = false;
                grdKhatoniDetails.Columns["KhatooniId"].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdKhatoniDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                  
                        grdKhatoniDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        if (e.ColumnIndex == grdKhatoniDetails.CurrentRow.Cells["chkkhatoni"].ColumnIndex)
                        {
                            int b = Convert.ToInt32(grdKhatoniDetails.CurrentRow.Cells["chkkhatoni"].Value);

                            if (b == 1)
                            {
                                grdKhatoniDetails.CurrentRow.Cells["chkkhatoni"].Value = 0;
                                this.txtKhatooniRecId.Text = "-1";
                                this.cmbKhatoniNo.SelectedIndex = 0;
                                
                            }
                            else
                            {
                               
                                grdKhatoniDetails.CurrentRow.Cells["chkkhatoni"].Value = 1;
                                this.txtKhatooniRecId.Text = this.grdKhatoniDetails.CurrentRow.Cells["KhatooniRecId"].Value.ToString();

                                this.cmbKhatoniNo.SelectedValue = this.grdKhatoniDetails.CurrentRow.Cells["KhatooniId"].Value.ToString();
                               
                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnKhatoniClear_Click(object sender, EventArgs e)
        {
            this.txtKhatooniRecId.Text = "-1";
            cmbKhatoniNo.SelectedIndex = 0;
            GetDetailedFardKhatonies(txtKhattaRecId.Text);
        }

        private void btnDeleteKhatoni_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhatooniRecId.Text!="-1")
                {
                    mnk.DeleteDetailedFardKhatooni(txtKhatooniRecId.Text);
                    this.txtKhatooniRecId.Text = "-1";
                    cmbKhatoniNo.SelectedIndex = 0;
                    GetDetailedFardKhatonies(txtKhattaRecId.Text);
                   
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnKKPrint_Click(object sender, EventArgs e)
        {

            frmSDCReportingMain TokenReport = new frmSDCReportingMain();

            TokenReport.TokenID = this.SelectedTokenId;
            TokenReport.userId = UsersManagments.UserId.ToString();
            
                UsersManagments.check = 21;
           
            TokenReport.ShowDialog();     
            
            
        }
    }
}