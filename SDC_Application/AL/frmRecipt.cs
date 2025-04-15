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
    public partial class frmRecipt : Form
    {
        #region Class Variables

        AutoComplete objauto = new AutoComplete();
        Validations objvalid = new Validations();
        DL.Database ojbdb = new DL.Database();
        BL.frmRecipt objbusines = new BL.frmRecipt();
        frmToken objtoken = new frmToken();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        DataTable dtGrd = new DataTable();
        static bool btnload = false;
        SqlDataReader dr = null;
        static string tokenverifed = "False";
        static string userid = "123";
        static string username = "afzal";
        static string useridupdate = "";
        static string usernameupdate = "";
        static string tehsilid = "11";
        string duplicate;
        int check;
        BindingSource bs = new BindingSource();
        LanguageConverter lang = new LanguageConverter();

        #endregion

       

        public frmRecipt()
        {
            InitializeComponent();
        }
        #region Tooltip
        public void tooltipRPT()
        {
            TTRPT.SetToolTip(txtAccountNo,"اکاونٹ نمبر");
            TTRPT.SetToolTip(txtAmountRecieve,"رقم وصول");
            TTRPT.SetToolTip(txtAmounttoPay,"قابل ادا رقم");
            TTRPT.SetToolTip(txtBankBranch,"بینک برانچ");
            TTRPT.SetToolTip(txtBankName,"بینک کا نام");
            TTRPT.SetToolTip(txtchalanFormDate,"چالان فارم تاریخ");
            TTRPT.SetToolTip(txtChalanFormNo1,"چالان نمبر");
            TTRPT.SetToolTip(txtChalanFormNum,"چالان فارم نمبر بذریعہ");
            TTRPT.SetToolTip(txtCNIC,"شناختی کارڈ نمبر");
            TTRPT.SetToolTip(txtFatherName,"والد کا نام");
            TTRPT.SetToolTip(txtMasterRemarks, "تفصیلات");
            TTRPT.SetToolTip(txtMasterRemarks,"ریمارکس");
            TTRPT.SetToolTip(txtMouza,"موضع");
            TTRPT.SetToolTip(txtNetAmountToPay,"کل قابل ادا رقم");
            TTRPT.SetToolTip(txtPVDetailID,"");
            TTRPT.SetToolTip(txtReciptDate,"رسید کی تاریخ");
            TTRPT.SetToolTip(txtReciptNo,"رسیدنمبر");
            TTRPT.SetToolTip(txtReciptTokenID,"رسید کا ٹوکن ای ڈی");
            TTRPT.SetToolTip(txtRemarks,"ریمارکس"); 
            TTRPT.SetToolTip(txtService,"سہولت");
            TTRPT.SetToolTip(txtTokenDate,"ٹوکن تاریخ");
            TTRPT.SetToolTip(txtTotPaymentRecived,"کل وصول کی گئ رقم");
            TTRPT.SetToolTip(txtVisitorName,"سائل کا نام");
            TTRPT.SetToolTip(btnClear,"نیا ریکارڈ");
            TTRPT.SetToolTip(btnMasterSave,"محفوظ کریں");
            TTRPT.SetToolTip(btnNewMaster,"نیا ریکارڈ");
            TTRPT.SetToolTip(btnReciptPopulate,"رسید بنائیں");
            TTRPT.SetToolTip(btnSaveDetails,"تفصیلات محفوظ کریں");
            TTRPT.SetToolTip(cmbPaymentofSource,"رقم کی وصو لی بذریعہ");
            TTRPT.SetToolTip(cmbServices,"سہولیات");
            TTRPT.SetToolTip(frmSearch,"تلاش کریں");
            
        
        }
        #endregion
        #region LoadForm
        private void frmRecipt_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cmbPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
           // objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenNo", this.txtReciptTokenID);
          //  btnMasterSave.Enabled = false;
            btnSaveDetails.Enabled = false;
            chkVerfiedReciptMaster.Enabled = false;
            chkVerfiedReciptMaster.Checked = false;
            Enable_Disable();
            tooltipRPT();
            call_Details_Recipt_Grd();
            //this.txtAmountRecieve.Location = new System.Drawing.Point(590, 70);
            //this.lbl2.Location = new System.Drawing.Point(602, 30);
        }
        #endregion
        #region payment mode
        private void cmbPaymentofSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Enable_Disable();
        }
        
       public void Enable_Disable()
        {

          
            string SDC=UsersManagments._Tehsilid+"001";
            string Bank = UsersManagments._Tehsilid + "002";
            string Bank1 = UsersManagments._Tehsilid + "003";

            if (cmbPaymentofSource.SelectedValue.ToString() == SDC.ToString() || cmbPaymentofSource.SelectedIndex == 0)
            {
                this.txtChalanFormNum.Visible = true;
                this.txtchalanFormDate.Visible = true;
                txtBankBranch.Visible = true;
                txtBankName.Visible = true;
                txtAccountNo.Visible = true;
                lblaccount.Visible = true;
                lblbank.Visible = true;
                lblbankbranch.Visible = true;
                lblchalandate.Visible = true;
                lblchalanform.Visible = true;
                //this.txtChalanFormNum.Visible = false;
                //this.txtchalanFormDate.Visible = false;
                //txtBankBranch.Visible = false;
                //txtBankName.Visible = false;
                //txtAccountNo.Visible = false;
                //lblaccount.Visible = false;
                //lblbank.Visible = false;
                //lblbankbranch.Visible = false;
                //lblchalandate.Visible = false;
                //lblchalanform.Visible = false;
                //this.txtAmountRecieve.Location = new System.Drawing.Point(621, 70);
                //this.lbl2.Location = new System.Drawing.Point(637, 30);
              
            }
            else if (cmbPaymentofSource.SelectedValue.ToString() == Bank.ToString() || cmbPaymentofSource.SelectedValue.ToString() == Bank1.ToString())
            {
                this.txtChalanFormNum.Visible = true;
                this.txtchalanFormDate.Visible = true;
                txtBankBranch.Visible = true;
                txtBankName.Visible = true;
                txtAccountNo.Visible = true;
                lblaccount.Visible = true;
                lblbank.Visible = true;
                lblbankbranch.Visible = true;
                lblchalandate.Visible = true;
                lblchalanform.Visible = true;
                //this.txtAmountRecieve.Location = new System.Drawing.Point(73, 69);
                //this.lbl2.Location = new System.Drawing.Point(81, 27);
            }
            else
            {
                this.txtChalanFormNum.Visible = true;
                this.txtchalanFormDate.Visible = true;
                lblchalandate.Visible = true;
                lblchalanform.Visible = true;
                //this.txtAmountRecieve.Location = new System.Drawing.Point(393, 71);
                //this.lbl2.Location = new System.Drawing.Point(415, 29);
                //txtBankBranch.Visible = false;
                //txtBankName.Visible = false;
                //txtAccountNo.Visible = false;
                //lblaccount.Visible = false;
                //lblbank.Visible = false;
                //lblbankbranch.Visible = false;
                this.txtChalanFormNum.Visible = true;
                this.txtchalanFormDate.Visible = true;
                txtBankBranch.Visible = true;
                txtBankName.Visible = true;
                txtAccountNo.Visible = true;
                lblaccount.Visible = true;
                lblbank.Visible = true;
                lblbankbranch.Visible = true;
                lblchalandate.Visible = true;
                lblchalanform.Visible = true;
            }
            //if (cmbPaymentofSource.SelectedIndex == 3)
            //{
            //    this.txtChalanFormNum.Visible = true;
            //    this.txtchalanFormDate.Visible = true;
            //    lblchalandate.Visible = true;
            //    lblchalanform.Visible = true;
            //    this.txtAmountRecieve.Location = new System.Drawing.Point(393, 71);
            //    this.lblreciptamount.Location = new System.Drawing.Point(415, 29);
            //    txtBankBranch.Visible = false;
            //    txtBankName.Visible = false;
            //    txtAccountNo.Visible = false;
            //    lblaccount.Visible = false;
            //    lblbank.Visible = false;
            //    lblbankbranch.Visible = false;
            //}
        }
        #endregion
        #region fill from paymentochour
       private void frmSearch_Click(object sender, EventArgs e)
        {

            frmSearchRecipt frmSearchRecipt1 = new frmSearchRecipt();
            frmSearchRecipt1.FormClosed -= new FormClosedEventHandler(frmSearchRecipt1_FormClosed);
            frmSearchRecipt1.FormClosed += new FormClosedEventHandler(frmSearchRecipt1_FormClosed);
            frmSearchRecipt1.ShowDialog();
        }

        private void frmSearchRecipt1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                

                frmSearchRecipt frmSearchRecipt = sender as frmSearchRecipt;
                
                    if (frmSearchRecipt.btn)
                    {
                        string RecieptNo = this.GetRecieptNoAgainstTokenId(frmSearchRecipt.tokenID);
                    if (RecieptNo != null)
                    {
                        if (RecieptNo == "0")
                        {
                            ClearWholeForm();
                            this.txtReciptTokenID.Text = frmSearchRecipt.tokennum;
                            this.txtVisitorName.Text = frmSearchRecipt.name;
                            this.txtFatherName.Text = frmSearchRecipt.father_name;
                            this.txtCNIC.Text = frmSearchRecipt.cnic;
                            this.txtHidenMouzaID.Text = frmSearchRecipt.mouzaid;
                            this.txtMouza.Text = frmSearchRecipt.mouzaname;
                            this.txtTokenDate.Text = frmSearchRecipt.pvdate;
                            this.txtHiddenTokenID.Text = frmSearchRecipt.tokenID;
                            this.txtChalanFormNo1.Text = frmSearchRecipt.pvno;
                            //this.txtChalanFormNum.Text = frmSearchRecipt.pvno;
                            this.txtHiddenPvid.Text = frmSearchRecipt.pvid;
                            // this.txtchalanFormDate.Text = frmSearchRecipt.pvdate;
                            this.txtService.Text = frmSearchRecipt.servicename;
                            btnMasterSave.Enabled = frmSearchRecipt.btn;
                            this.txtRIV.Text = "-1";
                            this.txtRNo.Text = "-1";
                            this.label6.Text = "تصدیق کریں";
                            chkVerfiedReciptMaster.Checked = false;
                            chkVerfiedReciptMaster.Enabled = false;
                            objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                            objtoken.errorChar.SetError(txtAmountRecieve, "");
                        }
                        else
                        {
                            MessageBox.Show(RecieptNo, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            
             }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Check Reciept if Already Exists against a token No

        private string GetRecieptNoAgainstTokenId(string TokenId)
        {
            string RecieptNo="0";
            DataTable dtReciept = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherNo_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId);
            if (dtReciept != null)
            {
                if (dtReciept.Rows.Count > 0)
                {
                    RecieptNo = "اس ٹوکن پر رسید پہلے سے موجود ہے۔" + " - رسید نمبر -" + dtReciept.Rows[0][0].ToString() + " - بتاریخ - " + dtReciept.Rows[0][1].ToString();
                }
            }
            return RecieptNo;
        }

        #endregion

        #region MasterSave Recipt

        private void btnMasterSave_Click(object sender, EventArgs e)
        {

            if (txtReciptTokenID.Text == "" || txtReciptTokenID.Text==string.Empty)
            {
                if (MessageBox.Show("ریکارڈز کے اندراج کے لئے چالان فارم لوڈ کریں", "چالان فارم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSearch_Click(sender, e);
                }
            }
            else
                try
                {
                    {

                        if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_ReceiptVoucherMaster '" + this.txtRIV.Text.ToString() + "','" + this.txtRNo.Text.ToString() + "','" + UsersManagments._Tehsilid.ToString() + "','" + this.txtHidenMouzaID.Text.ToString() + "','" + this.txtReciptDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + this.txtHiddenTokenID.Text + "',N'" + txtMasterRemarks.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
                            if (dt != null)
                            {

                               // MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    this.txtReciptNo.Text = dr[1].ToString();
                                    this.txtRIV.Text = dr[0].ToString();
                                    this.txtRNo.Text = dr[1].ToString();
                                    
                                }
                                txtRvsequence.Text = "-1";
                                txtRVDetailid.Text = "-1";
                                btnSaveDetails.Enabled = true;
                                btnClear.Enabled = true;
                                chkVerfiedReciptMaster.Enabled = false;
                                chkVerfiedReciptMaster.Checked = false;
                                btnSaveDetails.Enabled = true;
                                btnClear.Enabled = true;
                                Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId();
                               
                            }
                            else
                            {
                                MessageBox.Show("ریکارڈ میں کوئی غلطی ہے", "غلط اندراج", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId()
         {
             objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
                                + this.txtHiddenPvid.Text.ToString() + "'", cmbServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");
                                txtRemarks.Text = "";
                                txtAmounttoPay.Text = "";
                                 }
        #endregion
       
        #region  Keypress event
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
        #endregion

        #region service changed
        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }
        #endregion

        #region Details_Saved
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);


            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.cmbServices.Text.ToString());
            collection.Add(this.txtAmountRecieve.Text.ToString());


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
                    if (this.cmbServices.SelectedValue.ToString() == row.Cells["TaxNotificationDetailId"].Value.ToString())
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
                    objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                    groupBox2.Enabled = true;
                    txtRVDetailid.Text = "-1";
                    txtRvsequence.Text = "-1";
                    cmbServices.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(empty + "- کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (txtAmountRecieve.Text == "" || txtAmountRecieve.Text == null || txtAmountRecieve.Text == string.Empty)
                    {
                        objtoken.errorChar.SetError(txtAmountRecieve, "Error");
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
           //if (txtAmounttoPay.Text != "" && this.txtAmountRecieve.Text != "" && cmbPaymentofSource.SelectedIndex!=0 && cmbServices.SelectedIndex!=0)
           //{
                try
                {
                 if (cmbPaymentofSource.SelectedIndex == 1)
                    {
                           // txtChalanFormNum.Text = txtChalanFormNo1.Text.ToString();
                            txtchalanFormDate.Text=txtTokenDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    }
                 if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                            string @RVDetailId = this.txtRVDetailid.Text.ToString(); 
                            string @RVId=this.txtRIV.Text.ToString();
                            string  @PVDetailId= this.txtPVDetailID.Text.ToString() ;                               
                            string  @RVDetailSeqNo=	 this.txtRvsequence.Text.ToString();								    
                            string  @TaxNotificationDetailId=  cmbServices.SelectedValue.ToString();                                    
                            string  @NetPayableAmount=  this.txtAmounttoPay.Text.ToString();                               
                            string  @PaymentTypeId=     cmbPaymentofSource.SelectedValue.ToString();                            
                            string  @ReceivedAmountv =   this.txtAmountRecieve.Text.ToString();                                  
                            string  @ChallanNo=      txtChalanFormNum.Text.ToString() ;                               
                            string  @ChallanDate=   txtchalanFormDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());                                   
                            string  @BankAccountNo=  txtAccountNo.Text.ToString();
                            string  @BankName = txtBankName.Text.ToString();                                 
                            string  @BankBranchName=   txtBankBranch.Text.ToString();                          
                            string  @InsertUserId=       UsersManagments.UserId.ToString() ;                           
                            string  @InsertLoginName=    UsersManagments.UserName.ToString() ;                              
                            string  @UpdateUserId=         UsersManagments.UserId.ToString();                               
                            string  @UpdateLoginName=UsersManagments.UserName.ToString() ;

                            dt = objbusines.SaveRecptDetails(@RVDetailId, @RVId, @PVDetailId, @RVDetailSeqNo, @TaxNotificationDetailId, @NetPayableAmount, @PaymentTypeId, @ReceivedAmountv, @ChallanNo, @ChallanDate, @BankAccountNo, @BankName, @BankBranchName, @InsertUserId, @InsertLoginName, @UpdateUserId, @UpdateLoginName);
                     //+ this.txtRVDetailid.Text + "','"
                     //+ this.txtRIV.Text.ToString() + "','"
                     //+ this.txtPVDetailID.Text.ToString() + "','"
                     //+ this.txtRvsequence.Text.ToString() + "','"
                     //+ this.cmbServices.SelectedValue.ToString() + "','"
                     //+ this.txtAmounttoPay.Text.ToString() + "','"
                     //+ this.cmbPaymentofSource.SelectedValue.ToString() + "','"
                     //+ this.txtAmountRecieve.Text.ToString() + "','"
                     //+ this.txtChalanFormNum.Text.ToString() + "','"
                     //+ txtchalanFormDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','"
                     //+ this.txtAccountNo.Text.ToString() + "','"
                     //+ this.txtBankName.Text.ToString() + "','"
                     //+ this.txtBankBranch.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
                     if (dt != null)
                     {
                         foreach (DataRow dr in dt.Rows)
                         {
                             txtRVDetailid.Text = dr[0].ToString();
                         }
                         call_Details_Recipt_Grd();
                         objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                         objtoken.errorChar.SetError(txtAmountRecieve, "");
                     }
                 }
                
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           //else
           //{
           //   // MessageBox.Show("متلغقہ سہولت کی انتخاب کریں", "انتخاب",MessageBoxButtons.OK,MessageBoxIcon.Error);
               
           //}
        //}
        #endregion
          
        #region  Details from ReciptVochar fill in datagrid
        public void call_Details_Recipt_Grd()
        {
            try
            {
                dtGrd = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherDetail_By_RVId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.txtRIV.Text + "'");
                //DataTable outputTable = dtGrd.Clone();

                //for (int i = dtGrd.Rows.Count - 1; i >= 0; i--)
                //{
                //    outputTable.ImportRow(dtGrd.Rows[i]);
                //}
                // grdVoucherDetails.DataSource = outputTable;
                if (dtGrd != null)
                {
                    grdRecipt.DataSource = dtGrd;
                    objbusines.VoucherGrid(grdRecipt);
                    if (grdRecipt.Rows.Count > 0)
                    {
                        objdatagrid.SumDataGridColumn(grdRecipt, txtTotPaymentRecived, "ReceivedAmount");
                        objdatagrid.SumDataGridColumn(grdRecipt, this.txtNetAmountToPay, "NetPayableAmount");
                    }
                    chkVerfiedReciptMaster.Enabled = true;
                    DataGridViewColumn column = grdRecipt.Columns["RVDetailSeqNo"];
                    column.Width = 40;
                    DataGridViewColumn column1 = grdRecipt.Columns["PVDetailRemarks"];
                    column1.Width = 500;
                    //DataGridViewColumn column2 = grdRecipt.Columns["ReceivedAmount"];
                    //column1.Width = 30;
                    //DataGridViewColumn column3 = grdRecipt.Columns["NetPayableAmount"];
                    //column1.Width = 30;
                    for (int i = 0; i <= grdRecipt.Rows.Count - 1; i++)
                    {
                        DataGridViewRow row = grdRecipt.Rows[i];
                        row.Height = 35;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdRecipt_DoubleClick(object sender, EventArgs e)
        {
            this.txtRvsequence.Text= grdRecipt.CurrentRow.Cells["RVDetailSeqNo"].Value.ToString();
            this.txtRIV.Text=grdRecipt.CurrentRow.Cells["RVId"].Value.ToString();
            this.txtRVDetailid.Text= grdRecipt.CurrentRow.Cells["RVDetailId"].Value.ToString();
            this.txtPVDetailID.Text=grdRecipt.CurrentRow.Cells["PVDetailId"].Value.ToString();
            this.txtAmounttoPay.Text = grdRecipt.CurrentRow.Cells["NetPayableAmount"].Value.ToString();
            this.txtAmountRecieve.Text = grdRecipt.CurrentRow.Cells["ReceivedAmount"].Value.ToString();
            this.txtRemarks.Text = grdRecipt.CurrentRow.Cells["PVDetailRemarks"].Value.ToString();
            this.txtRemarks.SelectedText = this.txtRemarks.Text;
            this.cmbPaymentofSource.Text = grdRecipt.CurrentRow.Cells["PaymentType_Urdu"].Value.ToString();
            this.cmbServices.Text = grdRecipt.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
            this.txtBankBranch.Text = grdRecipt.CurrentRow.Cells["BankBranchName"].Value.ToString();
            this.txtBankName.Text = grdRecipt.CurrentRow.Cells["BankName"].Value.ToString();
            this.txtAccountNo.Text = grdRecipt.CurrentRow.Cells["BankAccountNo"].Value.ToString();
            this.txtChalanFormNum.Text = grdRecipt.CurrentRow.Cells["ChallanNo"].Value.ToString();

           // this.txtchalanFormDate.Text = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
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
                    this.txtchalanFormDate.Text = challanDate.ToString("dd MMM yyyy");
                }
                else
                {
                    this.txtchalanFormDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                }
            }
            else
            {
                this.txtchalanFormDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            }


            objtoken.errorNumeric.SetError(txtAmountRecieve, "Ok");
            //objtoken.errorNumeric.SetError(txtTotalRs, "Ok");


                 }

        #endregion
        #region  Verified Recipt and ClearThe form
        private void chkVerfiedReciptMaster_Click(object sender, EventArgs e)
        {
            if (txtTotPaymentRecived.Text != "" & txtNetAmountToPay.Text != "" && txtRIV.Text != "")
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtRIV.Text + "','" + chkVerfiedReciptMaster.Checked + "',''");
                       // MessageBox.Show("ریکارڈ کی تصدیق ہوچکی ہے", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.chkVerfiedReciptMaster.Enabled = false;
                        this.btnSaveDetails.Enabled = false;
                        btnMasterSave.Enabled = false;
                        this.btnClear.Enabled = false;
                        label6.Text = "تصدیق شدہ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void ClearWholeForm()
        {
            cmbPaymentofSource.SelectedIndex = 0;
            //this.cmbServices.SelectedIndex = 0;
            this.txtBankBranch.Text = "";
            this.txtBankName.Text = "";
            this.txtAccountNo.Text = "";
            txtChalanFormNum.Text = "";
            txtchalanFormDate.Text = DateTime.Today.ToString();
            txtTokenDate.Text = DateTime.Today.ToString();
            btnMasterSave.Enabled = false;
            chkVerfiedReciptMaster.Enabled = false;
            chkVerfiedReciptMaster.Checked = false;
            this.btnSaveDetails.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnMasterSave.Enabled = false;
            txtNetAmountToPay.Text = "";
            txtTotPaymentRecived.Text = "";
            if (dtGrd != null)
            {
                dtGrd.Clear();
                ClearFormsGroupsFields.ClearGroupBoxControls(groupBox2, groupBox5);
            }
                   }

        #endregion
        #region ClearAll

        private void btnClear_Click(object sender, EventArgs e)
        {
            
                ClearReciptDetails();
                objtoken.errorChar.SetError(txtAmountRecieve, "");
                objtoken.errorChar.SetError(txtAmounttoPay, "");
                objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                objtoken.errorNumeric.SetError(txtAmounttoPay, "");
            
        }
        public void ClearReciptDetails()
        {
            txtRvsequence.Text = "-1";
            txtRVDetailid.Text = "-1";
            txtRemarks.Text = "";
            txtRemarks.Text = "";
            txtAmounttoPay.Text = "";
            txtAccountNo.Text = "";
            txtBankBranch.Text = "";
            txtBankName.Text = "";
            txtAmountRecieve.Text = "";
            txtChalanFormNum.Text = "";
            cmbPaymentofSource.SelectedIndex = 0;
                    }
        #endregion
             
        #region ReciptPopulate
        private void btnReciptPopulate_Click(object sender, EventArgs e)
        {
            frmReciptPopulate frmReciptPopulate = new frmReciptPopulate();
            frmReciptPopulate.FormClosed -= new FormClosedEventHandler(frmReciptPopulate_FormClosed);
            frmReciptPopulate.FormClosed += new FormClosedEventHandler(frmReciptPopulate_FormClosed);
            frmReciptPopulate.ShowDialog();
        }

        private void frmReciptPopulate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
       
            frmReciptPopulate frmReciptPopulate = sender as frmReciptPopulate;
            if (frmReciptPopulate.btn)
            {
                ClearWholeForm();
                objtoken.errorChar.SetError(txtAmountRecieve,"");
                objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                this.txtRIV.Text = frmReciptPopulate.RVId;
                this.txtRNo.Text = frmReciptPopulate.RVNo;
                txtChalanFormNo1.Text = frmReciptPopulate.PVNo;
                txtchalanFormDate.Text = frmReciptPopulate.PVdate;
                txtVisitorName.Text = frmReciptPopulate.Name;
                txtFatherName.Text = frmReciptPopulate.FatherName;
                txtCNIC.Text = frmReciptPopulate.CNIC;
                txtService.Text = frmReciptPopulate.ServiceName;
                txtTokenDate.Text = frmReciptPopulate.PVdate;
                txtMouza.Text = frmReciptPopulate.Mouza;
                txtReciptNo.Text = frmReciptPopulate.RVNo;
                txtHidenMouzaID.Text = frmReciptPopulate.Mouzaid;
                this.txtHiddenPvid.Text = frmReciptPopulate.PVId; 
                txtHiddenTokenID.Text = frmReciptPopulate.TokenID;
                txtReciptTokenID.Text = frmReciptPopulate.TokenNo;
                txtReciptDate.Text = frmReciptPopulate.RVdate;
                this.txtHiddenServiceType.Text =frmReciptPopulate.ServiceType;
                txtRvsequence.Text = "-1";
                txtRVDetailid.Text = "-1";
                string Rvstatus = frmReciptPopulate.Rvstatus;

                bool Populated = frmReciptPopulate.btn;
                if (Populated)
                {
                    Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId();

                    call_Details_Recipt_Grd();
                    cmbServices.SelectedIndex = 0;
                    cmbPaymentofSource.SelectedIndex = 0;

                    if (Rvstatus == "1")
                    {
                        btnClear.Enabled = false;
                        this.btnMasterSave.Enabled = false;
                        this.btnSaveDetails.Enabled = false;
                        this.chkVerfiedReciptMaster.Checked = true;
                        chkVerfiedReciptMaster.Enabled = false;
                       // groupBox2.Enabled = false;
                    }
                    else
                    {
                        btnClear.Enabled = true;
                        this.btnMasterSave.Enabled = false;
                        this.btnSaveDetails.Enabled = true;
                        this.chkVerfiedReciptMaster.Checked = false;
                        chkVerfiedReciptMaster.Enabled = true;
                        groupBox2.Enabled = true;

                    }
                    if (grdRecipt.Rows.Count <= 0)
                    {
                        this.chkVerfiedReciptMaster.Checked = false;
                        chkVerfiedReciptMaster.Enabled = false;
                        btnSaveDetails.Enabled = true;
                        btnClear.Enabled = true;
                        label6.Text = "تصدیق کریں";
                        
                    }
                }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId()
         {
             objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
                                 + this.txtHiddenPvid.Text.ToString() + "'", cmbServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");
             txtRemarks.Text = "";
             txtAmounttoPay.Text = "";
         }
        #endregion
        #region KeyPress
        private void txtAmountRecieve_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;
                objtoken.errorNumeric.SetError(txtAmountRecieve, "");
                objtoken.errorChar.SetError(txtAmountRecieve, "error");

            }
            else
            {
                objtoken.errorChar.SetError(txtAmountRecieve, "");
                objtoken.errorNumeric.SetError(txtAmountRecieve, "ok");
            }
           
             char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }


        }
      
        private void txtBankBranch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;



            }

            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }

        private void btnNewMaster_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ نیا چالان لوڈ کرنا چاہتے ہیں:::::", "نیا چالان لوڈ ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSearch_Click(sender, e);
            }
           
        }

       



        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        private void txtChalanFormNum_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtAmountRecieve_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountRecieve.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtAmountRecieve,"OK");
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
                // MessageBox.Show(txtRVDetailid.Text.ToString());
            if (this.txtRIV.Text.ToString() != "-1")
            {
                UsersManagments.check = 3;
                frmSDCReportingMain TokenReport = new frmSDCReportingMain();
                TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
                TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
                TokenReport.RVID = this.txtRIV.Text.ToString();
                TokenReport.Tehsilid = UsersManagments._Tehsilid.ToString();
                TokenReport.ShowDialog();
            }

        }
        private void TokenReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            SDCReports Populate = sender as SDCReports;
        }

        private void cmbServices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbServices.SelectedIndex == 0)
            {
                txtRemarks.Text = "";
                txtRemarks.Text = "";
                txtAmounttoPay.Text = "";
                txtAccountNo.Text = "";
                txtBankBranch.Text = "";
                txtBankName.Text = "";
                txtChalanFormNum.Text = "";
                txtAmountRecieve.Text = "";
                cmbPaymentofSource.SelectedIndex = 0;

            }
            else
            {
                string serrviceId = this.cmbServices.SelectedValue.ToString() != "0" ? this.cmbServices.SelectedValue.ToString() : "0";
                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtHiddenPvid.Text + "','" + serrviceId + "'");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.txtAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
                        this.txtRemarks.Text = dr["PVDetailRemarks"].ToString();
                        this.txtRemarks.SelectedText = this.txtRemarks.Text;
                        this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
                        this.cmbPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
                    }
                }
            }
        }

        private void grdRecipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     
       
    }
}
