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
using System.Collections;

namespace SDC_Application.AL
    {
    public partial class frmIntiqalTaxReceipt : Form
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
        Intiqal Intiq = new Intiqal();

       
        DataTable khewatMalikanByFB = new DataTable();
        Taxes tax = new Taxes();
        DataTable dtKhewatFareeqainByKhataId = new DataTable();
        DataTable dtMushteriFareeqainByKhatooniId = new DataTable();
        DataTable dtFardKhatas = new DataTable();

        public string MaalikType { get; set; }
        public string MozaId { get; set; }
        public string SelectedMozaId { get; set; }
        public string SelectedTokenId { get; set; }
        public string SelectedTokenNo { get; set; }
        public string IntiqalId { get; set; }
        string IntiqalTaxId { get; set; }
        string RIntiqalTaxId { get; set; }
      
        #endregion

        #region Default Construction

        public frmIntiqalTaxReceipt()
            {

            InitializeComponent();

            }

        #endregion

        #region Form Load Event

        private void frmFard_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            txtTotalRs.Clear();
            txtServiceName.Clear();
            txtRsPerPage.Clear();
            txtQuantity.Clear();
            txtVoucherDetailsLastID.Text = "-1";
            txtTotalCostVoucher.Clear();

            grdVoucherDetails.DataSource = null;
            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "'," + "P");


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

                  

                    calldataGrid();

                    if (pvstatus)
                    {

                        btnSave.Enabled = false;

                        chkMasterVoucherUpdate.Checked = true;
                        chkMasterVoucherUpdate.Enabled = false;
                        chkPaymentCorrection.Enabled = true;
                        lbPaymentTasdeeq.Text = "تصدیق شدہ";

                    }
                    else
                    {
                        btnSave.Enabled = true;
                        chkMasterVoucherUpdate.Enabled = true;
                        chkMasterVoucherUpdate.Checked = false;
                        chkPaymentCorrection.Enabled = false;
                        lbPaymentTasdeeq.Text = "تصدیق کریں";

                    }

                }
            }

            else
            {

                txtSDCUnit.Clear();
                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");

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
                       
                        btnMasterSave.Enabled = true;


                        chkMasterVoucherUpdate.Enabled = true;
                        chkMasterVoucherUpdate.Checked = false;
                        chkPaymentCorrection.Enabled = false;
                        lbPaymentTasdeeq.Text = "تصدیق کریں";


                    }
                }

            }

        }

        #endregion

    

        #region Get services for payment voucher
      
     

        public void call_Details_Recipt_Grd()
        {
            try
            {
                dtGrd = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherDetail_By_RVId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtRVID.Text + "'");

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



                case 0:
                    {
                            txtServiceName.Clear();
                            txtRsPerPage.Clear();
                            txtTotalRs.Clear();
                            txtQuantity.Clear();
                            txtVoucherDetailsLastID.Text = "-1";
                            txtTotalCostVoucher.Clear();

                            grdVoucherDetails.DataSource = null;
                            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "'," + "P");


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

                                  
                                    calldataGrid();

                                    if (pvstatus)
                                    {

                                        btnSave.Enabled = false;

                                        chkMasterVoucherUpdate.Checked = true;
                                        chkMasterVoucherUpdate.Enabled = false;
                                        chkPaymentCorrection.Enabled = true;
                                        lbPaymentTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnSave.Enabled = true;
                                        chkMasterVoucherUpdate.Enabled = true;
                                        chkMasterVoucherUpdate.Checked = false;
                                        chkPaymentCorrection.Enabled = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";

                                    }

                                }
                            }

                            else
                            {

                                txtSDCUnit.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");

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
                                       
                                        btnMasterSave.Enabled = true;


                                        chkMasterVoucherUpdate.Enabled = true;
                                        chkMasterVoucherUpdate.Checked = false;
                                        chkPaymentCorrection.Enabled = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";


                                    }
                                }

                            }

                        break;
                    }

                // ======== TAB Receipt ===================================================


                case 1:
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



                            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cmbRPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
                            dtReceipt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_ReceiptVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");


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
                                        chkReceiptCorrection.Enabled = true;
                                        lbReceiptTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnRSaveDetails.Enabled = true;
                                        btnRClear.Enabled = true;
                                        btnDelReceipt.Enabled = true;

                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        chkReceiptCorrection.Enabled = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }

                                    Proc_Get_SDC_PaymentVoucherDetail_BY_VoucherId();
                                    call_Details_Recipt_Grd();
                                    btnRClear_Click(sender, e);

                                }
                            }

                            else
                            {
                                cmbRServices.DataSource = null;
                                cmbRServices.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "'," + "R");

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
                                        chkReceiptCorrection.Enabled = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }
                                }

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
                dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster " + "'"
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
                    if (Intiq.ChecIntiqalTaxVsPayment(IntiqalId) == "1")
                    {
                        if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtPVID.Text + "','" + chkMasterVoucherUpdate.Checked + "','" + this.txtTotalCostVoucher.Text.ToString() + "'") != null)
                            {

                                chkMasterVoucherUpdate.Enabled = false;
                                chkMasterVoucherUpdate.Checked = true;
                                chkPaymentCorrection.Enabled = true;
                                chkPaymentCorrection.Checked = false;
                                btnSave.Enabled = false;
                                btnMasterSave.Enabled = false;
                                btnDelPaymentDetail.Enabled = false;
                                lbPaymentTasdeeq.Text = "تصدیق شدہ";
                            }
                        }
                        else
                        {
                            chkMasterVoucherUpdate.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("درج شدہ ٹیکسز اور چالان کی کل رقم برابر نہیں ہے۔", "انتقال ٹیکسز", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool isExists = false;
            DataTable dtTax = new DataTable();
            try
            {
                calldataGrid();
                if (chkMasterVoucherUpdate.Checked != true)
                {
                    if (this.SelectedTokenId != null && this.txtPVID.Text != null)
                    {
                        dtTax = tax.GetIntiqalTaxDetailsByTokenId(this.SelectedTokenId);

                        if (dtTax != null)
                        {
                            foreach (DataRow row in dtTax.Rows)
                            {
                                IntiqalId = row["IntiqalId"].ToString();
                                this.txtNotificationUnitID.Text = row["TaxNotificationDetailId"].ToString();
                                this.IntiqalTaxId = row["IntiqalTaxId"].ToString();
                                txtMasterCostunitID.Text = row["SDCUnitId"].ToString();
                                txtRsPerPage.Text = row["TaxRate"].ToString();
                                txtQuantity.Text = row["TaxableQuantity"].ToString();
                                txtTotalRs.Text = row["taxamount"].ToString();
                             
                                
                                if (grdVoucherDetails.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow rows in grdVoucherDetails.Rows)
                                    {
                                     
                                        if (this.IntiqalTaxId == rows.Cells["IntiqalTaxId"].Value.ToString())
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
                                    InsertioninVocherDetails();
                                }

                            }
                           
                            calldataGrid();
                            
                            this.txtNotificationUnitID.Text = "";
                            txtMasterCostunitID.Text = "";
                            txtRsPerPage.Text = "";
                            txtQuantity.Text = "";
                            txtTotalRs.Text = "";
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

            }
        }



      
        public void InsertioninVocherDetails()
        {
           
            string PVID = this.txtPVID.Text.ToString();
            string Notificationunitid = this.txtNotificationUnitID.Text.ToString();
            string costunitid = txtMasterCostunitID.Text.ToString();
            string Rsperpage = txtRsPerPage.Text.ToString();
            string txtquntity = txtQuantity.Text.ToString();
            string totalamount = txtTotalRs.Text.ToString();
            string PVdetails = txtPVDetatils.Text.ToString();
            string TaxId = this.IntiqalTaxId.ToString();



            dt = objVoucher.SaveVocherDetailsSelf("-1", PVID, "-1", "NULL", this.IntiqalId, Notificationunitid, costunitid, Rsperpage, txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), TaxId);

            objtoken.errorNumeric.SetError(txtTotalRs, "");
            objtoken.errorNumeric.SetError(txtQuantity, "");
            objtoken.errorChar.SetError(txtTotalRs, "");
            objtoken.errorChar.SetError(txtQuantity, "");
        }

      

        public void calldataGrid()
        {

            try
            {

                dtPayment = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtPVID.Text + "'");

                grdVoucherDetails.DataSource = dtPayment;
                objVoucher.VoucherGridSelfIntiqal(grdVoucherDetails);
                grdVoucherDetails.Columns["ServiceCostAmount"].Width = 100;
                grdVoucherDetails.Columns["IntiqalTaxId"].Visible=false;

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

       

       

        private void grdVoucherDetails_DoubleClick(object sender, EventArgs e)
        {
            if (grdVoucherDetails.Rows.Count > 0)
            {
                txtVoucherDetailsLastID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailId"].Value.ToString();
                txtSequenceID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailSeqNo"].Value.ToString();
                txtQuantity.Text = grdVoucherDetails.CurrentRow.Cells["ServiceQuantity"].Value.ToString();

                txtTotalRs.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostAmount"].Value.ToString();
                txtSDCUnit.Text = grdVoucherDetails.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
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

                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_ReceiptVoucherMaster " + "'" + this.txtRVID.Text.ToString() + "','" + this.txtRNo.Text.ToString() + "','" + UsersManagments._Tehsilid.ToString() + "','" + this.MozaId.ToString() + "','" + this.dtReciptDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + this.SelectedTokenId.ToString() + "',N'" + txtMasterRemarks.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
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
            //if (this.cmbRServices.SelectedIndex == 0)
            //{

            //    txtRAmounttoPay.Text = "";
            //    txtRAccountNo.Text = "";
            //    txtRBankBranch.Text = "";
            //    txtRBankName.Text = "";
            //    txtRChalanFormNum.Text = "";
            //    txtRAmountRecieve.Text = "";
            //    cmbRPaymentofSource.SelectedIndex = 0;
            //    this.RIntiqalTaxId = null;

            //}
            //else
            //{
            //    DataTable dt2;
            //    dt2 = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt '" + this.txtRPVID.Text + "','" + this.cmbRServices.SelectedValue.ToString() + "'");
            //    foreach (DataRow dr in dt2.Rows)
            //    {
            //        this.txtRAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
            //        this.txtRAmountRecieve.Text = dr["ServiceCostAmount"].ToString();
            //        this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
            //        this.cmbRPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
            //        this.RIntiqalTaxId = dr["IntiqalTaxId"].ToString();
            //    }


            //}
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
                    if (this.cmbRServices.SelectedValue.ToString() == row.Cells["TaxNotificationDetailId"].Value.ToString() && this.RIntiqalTaxId == row.Cells["IntiqalTaxId"].Value.ToString())
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
                    string RTaxId = this.RIntiqalTaxId.ToString();

                    dt = objfrmRecipt.SaveRecptDetailsSelf(@RVDetailId, @RVId, @PVDetailId, @RVDetailSeqNo, @TaxNotificationDetailId, @NetPayableAmount, @PaymentTypeId, @ReceivedAmountv, @ChallanNo, @ChallanDate, @BankAccountNo, @BankName, @BankBranchName, @InsertUserId, @InsertLoginName, @UpdateUserId, @UpdateLoginName, RTaxId);
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
                    if (Intiq.ChecIntiqalReceiptVsPayment(IntiqalId) == "1")
                    {
                        if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtRVID.Text + "','" + chkVerfiedReciptMaster.Checked + "',''");

                            this.chkVerfiedReciptMaster.Enabled = false;
                            this.btnDelReceipt.Enabled = false;
                            this.btnRSaveDetails.Enabled = false;
                            this.btnRClear.Enabled = false;
                            this.chkVerfiedReciptMaster.Checked = true;
                            this.chkReceiptCorrection.Enabled = true;
                            this.chkReceiptCorrection.Checked = false;
                            lbReceiptTasdeeq.Text = "تصدیق شدہ";
                        }
                        else
                        {
                            chkVerfiedReciptMaster.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("رسیداور چالان کی کل رقم برابر نہیں ہے۔", "انتقال ٹیکسز", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            

            this.cmbRPaymentofSource.Text = grdRecipt.CurrentRow.Cells["PaymentType_Urdu"].Value.ToString();
            this.cmbRServices.Text = grdRecipt.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
            this.txtRAmountRecieve.Text = grdRecipt.CurrentRow.Cells["ReceivedAmount"].Value.ToString();
            this.txtRBankBranch.Text = grdRecipt.CurrentRow.Cells["BankBranchName"].Value.ToString();
            this.txtRBankName.Text = grdRecipt.CurrentRow.Cells["BankName"].Value.ToString();
            this.txtRAccountNo.Text = grdRecipt.CurrentRow.Cells["BankAccountNo"].Value.ToString();
            this.txtRChalanFormNum.Text = grdRecipt.CurrentRow.Cells["ChallanNo"].Value.ToString();

            //this.dtRChalanFormDate.Text = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
            object challanDateObj = grdRecipt.CurrentRow.Cells["ChallanDate"].Value;
            DateTime challanDate;

            if (challanDateObj is DateTime)
            {
                challanDate = (DateTime)challanDateObj;
            }
            else if (challanDateObj is string)
            {
                string challanDateStr = (string)challanDateObj;
                if (DateTime.TryParse(challanDateStr, out challanDate))
                {
                    this.dtRChalanFormDate.Text = challanDate.ToString("dd MMM yyyy");
                }
                else
                {
                    this.dtRChalanFormDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                }
            }
            else
            {
                this.dtRChalanFormDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            }



            objtoken.errorNumeric.SetError(txtRAmountRecieve, "Ok");
            if (this.txtRVDetailid.Text.Trim().Length > 5)
            {
                btnDelReceipt.Enabled = true;
            }
        }

        private void grdVoucherDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVoucherDetailsLastID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailId"].Value.ToString();
            txtQuantity.Text = grdVoucherDetails.CurrentRow.Cells["ServiceQuantity"].Value.ToString();
            txtRsPerPage.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostPerUnit"].Value.ToString();
            txtTotalRs.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostAmount"].Value.ToString();
            txtServiceName.Text = grdVoucherDetails.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
            txtSDCUnit.Text = grdVoucherDetails.CurrentRow.Cells["SDCUnitName_Urdu"].Value.ToString();
            if(chkMasterVoucherUpdate.Checked==false)
            {
                btnDelPaymentDetail.Enabled = true;
            }
            
        }

        private void btnDelPaymentDetail_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {

                    mnk.DeleteDetailedPayment(txtVoucherDetailsLastID.Text);
                    calldataGrid();
                    btnDelPaymentDetail.Enabled = false;
                    txtTotalRs.Clear();
                    txtServiceName.Clear();
                    txtRsPerPage.Clear();
                    txtQuantity.Clear();
                    txtVoucherDetailsLastID.Text = "-1";
                    

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void chkPaymentCorrection_Click(object sender, EventArgs e)
        {
            if (chkMasterVoucherUpdate.Checked && chkPaymentCorrection.Checked)
            {
                try
                {
                    
                        if (MessageBox.Show("کیا آپ درستگی کرنا چاہتے ہیں:::::", "درستگی", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtPVID.Text + "','" + "0" + "','" + "0" + "'") != null)
                            {

                                chkMasterVoucherUpdate.Enabled = true;
                                chkMasterVoucherUpdate.Checked = false;
                                btnSave.Enabled = true;
                                chkPaymentCorrection.Checked = false;
                                chkPaymentCorrection.Enabled = false;
                               
                                btnDelPaymentDetail.Enabled = true;
                                lbPaymentTasdeeq.Text = "تصدیق کریں";
                            }
                        }
                        else
                        {
                            chkPaymentCorrection.Checked = false;
                        }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void chkReceiptCorrection_Click(object sender, EventArgs e)
        {
            if (chkVerfiedReciptMaster.Checked && chkReceiptCorrection.Checked)
            {
                try
                {
                    
                        if (MessageBox.Show("کیا آپ درستگی کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtRVID.Text + "','" + "0" + "',''");

                            this.chkVerfiedReciptMaster.Enabled = true;
                            this.chkVerfiedReciptMaster.Checked = false;
                            this.btnDelReceipt.Enabled = true;
                            this.btnRSaveDetails.Enabled = true;
                            this.btnRClear.Enabled = true;

                            chkReceiptCorrection.Checked = false;
                            chkReceiptCorrection.Enabled = false;
                            lbReceiptTasdeeq.Text = "تصدیق کریں";
                        }
                        else
                        {
                            chkReceiptCorrection.Checked = false;
                        }
                    
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void cmbRServices_SelectionChangeCommitted(object sender, EventArgs e)
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
                this.RIntiqalTaxId = null;

            }
            else
            {
                DataTable dt2;
                dt2 = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtRPVID.Text + "','" + this.cmbRServices.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt2.Rows)
                {
                    this.txtRAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
                    this.txtRAmountRecieve.Text = dr["ServiceCostAmount"].ToString();
                    this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
                    this.cmbRPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
                    this.RIntiqalTaxId = dr["IntiqalTaxId"].ToString();
                }


            }
        }

       
    }
}