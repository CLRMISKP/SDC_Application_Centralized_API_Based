using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using SDC_Application.DL;
using SDC_Application.BL;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using SDC_Application.LanguageManager;


namespace SDC_Application.AL
{
    public partial class frmIntiqalMainForManual : Form
    {
        bool KhanaMalkiat = false;
        bool KhanaKasht = true;
        bool intiqalPending = true;
        bool Attested = false;
        bool Cancelled = false;
        bool isConfirmed = false;
        string GardawarId = "0";
        string GardawarUserId = "0";
        int Teh_Report = 0;
        string datetoken;
        DataTable dt = new DataTable();

        #region Properties
        public bool AmalDaramad { get; set; }
        public string MinhayeIntiqalId { get; set; }
        /// <summary>
        /// get or set inteqal id
        /// </summary>
        public string IntiqalId { get; set; }
        public string TokenId { get; set; }
        public string userId { get; set; }
        public string intiqalTypeId { get; set; }
        public string intiqalIId { get; set; }

        /// <summary>
        /// get or set entry mode
        /// </summary>
        public int EntryMode { get; set; }
        /// <summary>
        /// get or set Moza id
        /// </summary>
        public int MozaId { get; set; }

        public string fardTokenId { get; set; }

        public string fardTokenIdSelected { get; set; }

        public int S_Kanal { get; set; }

        public int S_Marla { get; set; }

        public float S_Sarsai { get; set; }

        public float S_Sft { get; set; }

        public string LandValue { get; set; }

        public bool IntiqalStatus { get; set; }
        public string chkkhata { get; set; }
       // public bool IntiqalStatus { get; set; }

        private string mozaname;

        /// <summary>
        /// Get or set Moza Name
        /// </summary>
        public string MozaName
        {
            get { return mozaname; }
            set
            {
                mozaname = value;
               // this.lblMozaName.Text = value;
            }
        }

        public string  dtVisitingPlan { get; set; }
        public string dtGainTax { get; set; }
        public string dtTaxesReceived { get; set; }
        public string dtChkGainTax { get; set; }
        public string dtChkPersonSnaps { get; set; }

        #endregion

        Intiqal Iq = new Intiqal();
        Taxes tx = new Taxes();
        BL.frmToken dtTok = new BL.frmToken();
        LanguageConverter lang = new LanguageConverter();
        DataTable dttx = new DataTable();
        DataTable dtpt = new DataTable();
        DataTable dtcpt = new DataTable();
        DataTable iqDt = new DataTable();
        DataTable inType = new DataTable();
        DataTable inList = new DataTable();
        DataTable IntiqalList = new DataTable();
        DataTable TokenList = new DataTable();
        DataTable intiqalRtrv = new DataTable();
        AreaProfile area = new AreaProfile();
        DataTable PatwarCircles = new DataTable();
        DataTable Mozas = new DataTable();
        AutoComplete objauto = new AutoComplete();
        BL.frmVoucher objbusines = new BL.frmVoucher();

        public frmIntiqalMainForManual()
        {


            InitializeComponent();
        }

        private void groupBoxRapat_Enter(object sender, EventArgs e)
        {

        }

        #region Tooltip

        public void tooltip()
        {
            
            toolTip.SetToolTip(txtHawalaNo,"حوالہ نمبر");
            toolTip.SetToolTip(txtIntiqalNo,"انتقال نمبر");
           
            toolTip.SetToolTip(txtLandValue,"زمین کی قیمت");
            toolTip.SetToolTip(txtMisalNo,"مثل نمبر");
           
            //toolTip.SetToolTip(btnCancel,"منسوخ کریں");
            toolTip.SetToolTip(btnDelMain,"  انتخاب شدہ انتقال کو خذف کریں ۔ اگر انتقال میں کھاتہ ، دہندہ گان اور گریندہ گان کا اندراج ہوا ہو تو پہلے وہ حزف کریں۔");
           
            //toolTip.SetToolTip(btnModifyIntiqal,"انقال تبدیل کریں");
            toolTip.SetToolTip(btnNewInteqal," نیا انتقال کے اندراج کے لئے کلک کریں۔");
            toolTip.SetToolTip(btnSave,"مخفوظ کریں");
            toolTip.SetToolTip(btnSearchInteqal,"انتقال تلاش کریں");
           
            toolTip.SetToolTip(cboIntiqalInitiation,"انتقال بذریعہ");
            toolTip.SetToolTip(cboIntiqalType,"قسم انتقال");

            toolTip.SetToolTip(btnIntiqalAmal, "اگر آپ انتقال کے اندراج سے مطمئن ہے  تو عمل درامد کریں۔");
           

        }

        #endregion

        private void frmIntiqalMain_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            tooltip();
            fillIntiqalType();
            GetIntiqalInitiationList();
            this.FillMoza();
            this.IntiqalId = "-1";
           // this.FillPatwarCircle();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveIntiqal();
           
        }

        #region Key Press Event for Language


        public void LanguageCheckUrdu(object sender, KeyPressEventArgs e)
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

        public void CheckNumericField(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
               
        }

        #endregion

        #region Custom Methods

        private void fillIntiqalType()
        {
            this.inType = Iq.GetintiqalTypes();
            DataRow IntiqalType = inType.NewRow();
            IntiqalType["IntiqalTypeId"] = "0";
            IntiqalType["IntiqalType"] = " - انتقال قسم چنیے - ";
            inType.Rows.InsertAt(IntiqalType, 0);
            cboIntiqalType.DataSource = inType;
            cboIntiqalType.DisplayMember = "IntiqalType";
            cboIntiqalType.ValueMember = "IntiqalTypeId";
            cboIntiqalType.SelectedValue = 0;
        }
        

        private void GetIntiqalInitiationList()
        {
            this.inList = Iq.GetIntiqalInitiationList();
            DataRow IntiqalList = inList.NewRow();
            IntiqalList["IntiqalInitiationId"] = "0";
            IntiqalList["IntiqalInitiationType"] = " - انتقال بذریعہ چنیے - ";
            inList.Rows.InsertAt(IntiqalList, 0);
            cboIntiqalInitiation.DataSource = inList;
            cboIntiqalInitiation.DisplayMember = "IntiqalInitiationType";
            cboIntiqalInitiation.ValueMember = "IntiqalInitiationId";
            cboIntiqalInitiation.SelectedValue = 0;
        }



        #endregion 

        #region Save Inteqal Entry

        private void SaveIntiqal()
        {
           
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl3.Text);
            Labels.Add(lbl4.Text);
            Labels.Add(lbl5.Text);
            Labels.Add(lbl6.Text);
           // Labels.Add(lbl9.Text);
            Labels.Add(lbl10.Text);
            ArrayList collection = new ArrayList();
            string empty = null;
            string ReceivngId = "0";

            collection.Add(this.cboMoza.SelectedIndex.ToString());
            collection.Add(this.txtIntiqalNo.Text.ToString());
            collection.Add(this.cboIntiqalType.SelectedIndex.ToString());
            collection.Add(this.cboIntiqalInitiation.SelectedIndex.ToString());
            DataRowView dv = (DataRowView)cboIntiqalType.SelectedItem;
            string s = (string)dv.Row["IntiqalType"];
            DataRowView II = (DataRowView)cboIntiqalInitiation.SelectedItem;
            string t = (string)II.Row["IntiqalInitiationType"]; 

            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "0")
                {
                    empty += "," + Labels[i].ToString();

                }

            }

            if (empty == null)//this.cmbMouza.SelectedIndex != 0 && this.txtFatherHusband.Text != string.Empty && this.txtVisitorName.Text != string.Empty && this.txtTempAddress.Text != string.Empty && cmbPurpose.SelectedIndex != 0 && cmbServiceId.SelectedIndex != 0 && txtCNCI.TextLength == 15)
            {          
                try
                {
                    
                    string intiqalId = this.IntiqalId.ToString();
                    //string mozaId = UsersManagments.MozaId.ToString();
                    KhanaMalkiat = true;
                    // if (checkBoxKhanaMalkiat.Checked)
                    // {
                    //KhanaMalkiat = true;
                    // }
                    bool KhanaKasht = false;
                    //if (checkBoxKhanaKasht.Checked)
                    //{
                    // KhanaKasht = true;
                    // }
                    string intiqalNo = txtIntiqalNo.Text.Trim() != "" ? txtIntiqalNo.Text.ToString() : "NULL";
                    string hawalaNo = txtHawalaNo.Text.Trim() != "" ? txtHawalaNo.Text.ToString() : "NULL";
                    string intiqalTypeId = cboIntiqalType.SelectedValue.ToString();
                    string intiqalInitaionId = cboIntiqalInitiation.SelectedValue.ToString();
                    string IndrajDate = dtpIntiqalAndrajDate.Checked ? dtpIntiqalAndrajDate.Value.ToShortDateString() : "NULL";
                    string landValue = txtLandValue.Text.Trim() != "" ? txtLandValue.Text.ToString() : "0";
                    string AttestDate = dtpTasdiq.Checked ? dtpTasdiq.Value.ToShortDateString() : "";

                    string misalNo = txtMisalNo.Text.Trim() != "" ? txtMisalNo.Text.Trim().ToString() : "NULL";
                    
                    
                    string LastIntiqalDate = DateTime.Now.ToShortDateString();
                    string mozaId = this.cboMoza.SelectedValue.ToString();
                    string usrId = UsersManagments.UserId.ToString();
                    string usrName = UsersManagments.UserName.ToString();
                    //string TrialSubject = txtTrialSubject.Text;
                    
                    if (mozaId .Length>3)
                    {

                        string LastId = Iq.SaveIntiqalMainManual(intiqalId, mozaId, radKhanaMalkiat.Checked.ToString(), radKhanaKasht.Checked.ToString(), this.radkhanakashtmalkiat.Checked.ToString(), intiqalNo, "0", intiqalTypeId, intiqalInitaionId, IndrajDate, "0", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), landValue, DateTime.Now.ToShortDateString(), "0", "NULL", "0", DateTime.Now.ToShortDateString(), "NULL", misalNo, "دستی گمشدہ انتقال کا اندراج و عمل ", usrId, usrName);
                        if (LastId.Length > 5)
                        {
                            MessageBox.Show("انتقال کا اندراج  ہو گیا ہے۔");
                            this.ClearFormControls(groupBox6);
                        }
                        else
                        MessageBox.Show("انتقال کا اندراج نہیں ہو سکا۔");
                    }
                    else
                    {
                        MessageBox.Show("Select Moza");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "انتقال نمبر پہلے سے درج ہے", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show(empty + "- کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Retrive Form Data

        private void FillIntiqalByIntiqalId(string mozaId, string intiqalNo)
        {
            intiqalRtrv = Iq.GetintiqalMainByIntiqalNoMozaId(mozaId, intiqalNo);
            
           if (intiqalRtrv.Rows.Count > 0)
            {
            foreach (DataRow data in intiqalRtrv.Rows)
            {
                
                    this.MozaId = Convert.ToInt32(mozaId);
                    this.IntiqalId = data["IntiqalId"].ToString();
                    txtIntiqalNo.Text = data["IntiqalNo"].ToString();
                    radKhanaMalkiat.Checked = (bool)(data["IntiqalKhanaMalkiat"]!=""?data["IntiqalKhanaMalkiat"]:false);
                    radKhanaKasht.Checked = (bool)(data["IntiqalKhanaKasht"]!=""?data["IntiqalKhanaKasht"]:false);
                    this.radkhanakashtmalkiat.Checked = (bool)(data["IntiqalKhanaMalkiatKasht"]!=""?data["IntiqalKhanaMalkiatKasht"]:false);
                    dtpIntiqalAndrajDate.Value = Convert.ToDateTime(data["IntiqalAndrajDate"]);
                    dtpTasdiq.Value = Convert.ToDateTime(data["IntiqalAttestationDate"]);
                    cboIntiqalType.SelectedValue = data["IntiqalTypeId"];
                    this.intiqalTypeId = data["IntiqalTypeId"].ToString();
                    cboIntiqalInitiation.SelectedValue = data["IntiqalInitiationId"];
                    this.intiqalIId = data["IntiqalInitiationId"].ToString();
                    txtLandValue.Text = data["LandValue"].ToString();
                    LandValue = data["LandValue"].ToString();
                    //this.Teh_Report = data["Teh_Report"].ToString().Length;
                    // dtpTasdiq.Value = data.IntiqalAttestationDate;
                isConfirmed=Convert.ToBoolean(data["isConfirm"].ToString());
                    btnConfirm.Enabled = !isConfirmed;
                   
                //,,,,,,,,,,,,,,,,,,,end,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,

                    
                    
                    if (!AmalDaramad && isConfirmed && UsersManagments._IsAdmin)
                    {
                        btnIntiqalAmal.Enabled = true;                           
                    }
                    else
                        btnIntiqalAmal.Enabled = false;

                    if (cboMoza.SelectedIndex != -1 && txtIntiqalNo.Text.Trim().Length > 0 && cboIntiqalInitiation.SelectedValue.ToString() == "2")
                    {
                       
                    }

                    if(AmalDaramad)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    
                    if (Attested)
                    {
                        
                        this.btnSave.Enabled = false;
                    }
                    else
                    {
                       
                        this.btnSave.Enabled = true;
                        if(this.intiqalIId=="2")
                        {
                           
                        }
                        else
                        {
                           
                        }
                        
                    }
                    if (this.GardawarUserId == "0")
                    {
                        
                        if(!Attested)
                        {
                            //this.btnROattestation.Enabled = false;
                            //this.btnIntiqalCancel.Enabled = false;
                            this.btnSave.Enabled = true;
                        }
                      
                    }
                    else
                    {
                      
                        this.btnSave.Enabled = false;
                        //if (!Attested)
                        //{
                        //    this.btnROattestation.Enabled = true;
                        //    this.btnIntiqalCancel.Enabled = true;
                        //}
                       
                    }
                    if (Cancelled)
                    {
                        this.groupBox1.Enabled = false;
                        this.groupBox7.Enabled = false;
                    }
                    else
                    {
                        this.groupBox1.Enabled = true;
                        this.groupBox7.Enabled = true;
                    }
                    if (data["IntiqalPending"].ToString()=="True")
                    {
                        this.chkPendingIntiqal.Checked = true;
                        //this.groupBox7.Enabled = false;
                        //this.groupBox1.Enabled = false;
                        //this.gbAmalDaramad.Height = 150;
                        this.lblIntiqalPending.Text = data["IntiqalPendingReason_Urdu"].ToString();
                        //this.IntiqalRemarks = data.IntiqalPendingRemakrs;
                        this.intiqalPending = true;
                    }
                    else
                    {
                        this.chkPendingIntiqal.Checked = false;
                        //this.gbAmalDaramad.Height = 80;
                        this.groupBox7.Enabled = true;
                        this.groupBox1.Enabled = true;
                        this.lblIntiqalPending.Text = "";
                        this.intiqalPending = false;
                        this.lblIntiqalPending.Text = "";
                        lblOperatorNote.Text = data["IntiqalPendingReason_Urdu"].ToString() == "" ? "آپریٹر نوٹ لکھنے کیلئے کلک کریں" : data["IntiqalPendingReason_Urdu"].ToString();
                    }

                //========== for current status ============================
                    panelCurrentStatus.Visible = true;
                if(Cancelled)
                {
                    lbCurrentStatus.Text = "کینسل شدہ";
                    lbCurrentStatus.ForeColor = Color.Red;
                }
                else if (intiqalPending)
                {
                    lbCurrentStatus.Text = "زیر التوا";
                    lbCurrentStatus.ForeColor = Color.DarkViolet;
                }
                else if (AmalDaramad)
                {
                    lbCurrentStatus.Text = "عمل درآمدشدہ";
                    lbCurrentStatus.ForeColor = Color.Green;
                }
                else if (Attested)
                {
                    lbCurrentStatus.Text = "تصدیق شدہ";
                    lbCurrentStatus.ForeColor = Color.Chocolate;
                }
                else if (GardawarUserId!="0")
                {
                    lbCurrentStatus.Text = "منظور شدہ";
                    lbCurrentStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lbCurrentStatus.Text = "درج شدہ";
                    lbCurrentStatus.ForeColor = Color.Teal;
                }


                //============== end ========================================

                #region UnUsed Text
                // this.IntiqalType = data.IntiqalType;
                    //    if (data.IntiqalPending)
                    //    {
                    //        this.chkPendingIntiqal.Checked = true;
                    //        this.gbAmalDaramad.Height = 150;
                    //        this.lblIntiqalPending.Text = data.IntiqalPendingReason_Urdu;
                    //    }
                    //    else
                    //    {
                    //        this.chkPendingIntiqal.Checked = false;
                    //        this.gbAmalDaramad.Height = 80;
                    //        this.lblIntiqalPending.Text = "";
                    //    }
                    //    if (data.AmalDaramadStatus )
                    //    {

                    //        lblMutStatus.Text = "عمل درامد شدہ";
                    //        lblMutStatus.ForeColor = Color.Green;
                    //        this.IntiqalStatus = true;
                    //        btnAmaldaramad.Enabled = false;
                    //        btnAmalDaramadTaqseem.Visible = false;
                    //        btnSave.Visible = false;
                    //        btnDelMain.Visible = false;
                    //        //btnSaveSeller.Visible = false;
                    //        //btnSaveBuyer.Visible = false;
                    //        //btnDelSeller.Visible = false;
                    //        //btnDelBuyer.Visible = false;
                    //        this.panel8.Visible = false;  // Intiqal Sellers Operation Buttons set to invisible
                    //        this.panel9.Visible = false;  // Intiqal Buyers Operation Buttons set to invisible
                    //        // Disable MinGroup Editing

                    //        lblAmalDaramdTaqseem.Text = "عمل درامد شدہ";
                    //        lblAmalDaramdTaqseem.ForeColor = Color.Green;
                    //        this.btnsavemingroup.Visible = false;
                    //        this.btnmlikan.Visible = false;
                    //        this.btnkhasrajat.Visible = false;
                    //        this.btnSaveMinFareeq.Visible = false;
                    //        this.btnSaveIntiqalMinKhassra.Visible = false;
                    //        this.gridkhasrajat.Columns[16].Visible = false;
                    //        this.gridmalikan.Columns[6].Visible = false;

                    //    }
                    //    else
                    //    {

                    //        lblMutStatus.Text = " عمل درامد زیر غور";
                    //        lblMutStatus.ForeColor = Color.Red;
                    //        this.IntiqalStatus = false;
                    //        btnAmaldaramad.Enabled = true;
                    //        btnSave.Visible = true;
                    //        btnDelMain.Visible = true;
                    //        this.panel9.Visible = true;   // Intiqal Sellers Operation Buttons set to invisible
                    //        this.panel8.Visible = true;   // Intiqal Buyers Operation Buttons set to invisible
                    //        //btnSaveSeller.Visible = true;
                    //        //btnSaveBuyer.Visible = true;
                    //        //btnDelSeller.Visible = true;
                    //        //btnDelBuyer.Visible = true;
                    //        // Enable MinGroup Editing
                    //        lblAmalDaramdTaqseem.Text = " عمل درامد زیر غور";
                    //        lblAmalDaramdTaqseem.ForeColor = Color.Red;
                    //        this.btnAmalDaramadTaqseem.Visible = true;
                    //        this.btnsavemingroup.Visible = true;
                    //        this.btnmlikan.Visible = true;
                    //        this.btnkhasrajat.Visible = true;
                    //        this.btnSaveMinFareeq.Visible = true;
                    //        this.btnSaveIntiqalMinKhassra.Visible = true;
                    //        this.gridkhasrajat.Columns[16].Visible = true;
                    //        this.gridmalikan.Columns[6].Visible = true;
                    //        if (data.IntiqalPending)
                    //        {
                    //            btnAmaldaramad.Enabled = false;
                    //            btnAmalDaramadTaqseem.Enabled = false;
                    //        }
                    //    }


                //}
                #endregion
            }
               
            }

            else
            {

                MessageBox.Show("یہ انتقال نمبر درج نہیں ہے", "انتقال نمبر", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #endregion

        private void btnSearchInteqal_Click(object sender, EventArgs e)
        {
            
            if (txtIntiqalNo.Text.Trim() != "")
            {

                try
                {
                    this.MinhayeIntiqalId = "0";
                    string mozaId = cboMoza.SelectedValue.ToString();
                    string intiqalNo = txtIntiqalNo.Text.Trim();
                    FillIntiqalByIntiqalId(mozaId, intiqalNo);
                    // LoadIntiqalDetails();
                    //btnSave.Enabled = true;
                    btnNewInteqal.Enabled = true;                   
                    this.btnDelMain.Enabled = true;

                    
                }
                catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
            else
            {
                MessageBox.Show("تلاش کے لئے مطلوبہ انتقال نمبر درج کریں","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtIntiqalNo.Focus();

            }
        }

        private void btnNewInteqal_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            radKhanaKasht.Enabled = true;
            radKhanaMalkiat.Enabled = true;
            radkhanakashtmalkiat.Enabled = true;
            this.IntiqalId = "-1";
            this.ClearFormControls(groupBox6);
            panelCurrentStatus.Visible = false;
        }

        private void btnKhataJat_Click(object sender, EventArgs e)
        {
            if (IntiqalId.Length>5)
            {
               
                //bool MalkyatType;
                if (radKhanaMalkiat.Checked)
                {
                    frmIntiqalKhattaJat frmIK = new frmIntiqalKhattaJat();
                    frmIK.IntiqalId = this.IntiqalId;
                    frmIK.IntiqalPending = this.intiqalPending;
                    frmIK.MozaId = this.MozaId;
                    frmIK.MdiParent = this.ParentForm;
                    frmIK.AmalDaramad = this.AmalDaramad;
                    frmIK.isAttested = this.Attested;
                    frmIK.isGardawar = this.GardawarId;
                    frmIK.Teh_Report = this.Teh_Report;
                    frmIK.isConfirmed = this.isConfirmed;
                    frmIK.MalkiatKashkat = true;
                    frmIK.MinhayeIntiqalId = this.MinhayeIntiqalId;

                    frmIK.IntiqalTypeId = this.intiqalTypeId;
                    frmIK.FardTokenId = "0";
                    frmIK.intiqalIId = this.intiqalIId;

                    frmIK.Show();
                }
                else if (radKhanaKasht.Checked)
                {
                    frmIntiqalKhattaJatKhatooni frmIK = new frmIntiqalKhattaJatKhatooni();
                    frmIK.IntiqalId = this.IntiqalId;
                    frmIK.MozaId = this.MozaId;
                    frmIK.isAttested = this.Attested;
                    frmIK.isGardawar = this.GardawarId;
                    frmIK.Teh_Report = this.Teh_Report;
                    frmIK.isConfirmed = this.isConfirmed;
                    frmIK.AmalDaramad = this.AmalDaramad;
                    frmIK.MdiParent = this.ParentForm;
                    frmIK.MalkiatKashkat = false;
                    frmIK.MinhayeIntiqalId = this.MinhayeIntiqalId;

                    frmIK.IntiqalTypeId = this.intiqalTypeId;
                    frmIK.FardTokenId = this.fardTokenId;
                    frmIK.intiqalIId = this.intiqalIId;

                    frmIK.Show();
                }
                else if (radkhanakashtmalkiat.Checked)
                {
                    frmIntiqalKhattaJatKhtooniMalkiat frmIK = new frmIntiqalKhattaJatKhtooniMalkiat();
                    frmIK.IntiqalId = this.IntiqalId;
                    frmIK.MozaId = this.MozaId;
                    frmIK.isAttested = this.Attested;
                    frmIK.isGardawar = this.GardawarId;
                    frmIK.Teh_Report = this.Teh_Report;
                    frmIK.isConfirmed = this.isConfirmed;
                    frmIK.AmalDaramad = this.AmalDaramad;
                    frmIK.MdiParent = this.ParentForm;
                    frmIK.MalkiatKashkat = true;
                    frmIK.MinhayeIntiqalId = this.MinhayeIntiqalId;

                    frmIK.IntiqalTypeId = this.intiqalTypeId;
                    frmIK.FardTokenId = this.fardTokenId;
                    frmIK.intiqalIId = this.intiqalIId;

                    frmIK.Show();
                }
                
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnTaqseem_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmIntiqalRevenueReports frmTq = new frmIntiqalRevenueReports();
                frmTq.IntiqalId = this.IntiqalId;
                frmTq.IntiqalNo = this.txtIntiqalNo.Text;
                frmTq.AmalDaramad = this.AmalDaramad;
                frmTq.tokenId = this.TokenId;
                frmTq.Show();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        #region Clear Form Controls

        private void ClearFormControls(GroupBox gBox)
        {
            foreach (Control ctl in gBox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox t = ctl as TextBox;
                    t.Clear();
                }
                else if (ctl.GetType() == typeof(ComboBox))
                {
                    ComboBox b = ctl as ComboBox;
                    b.SelectedValue = 0;
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = ctl as CheckBox;
                    chk.Checked = false;
                }
                else if (ctl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker dt = ctl as DateTimePicker;
                    dt.Value = DateTime.Today;
                }
            }

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            frmIntiqalDucomentCheckList frmIntiqalDucomentCheckList = new frmIntiqalDucomentCheckList();
              // frmIntiqalTaqseem frmIntiqalTaqseem = new frmIntiqalTaqseem();
            frmIntiqalDucomentCheckList.FormClosed -= new FormClosedEventHandler( frmIntiqalDucomentCheckList_FormClosed);
            frmIntiqalDucomentCheckList.FormClosed += new FormClosedEventHandler( frmIntiqalDucomentCheckList_FormClosed);
            frmIntiqalDucomentCheckList.IntiqalId = IntiqalId;
          
            frmIntiqalDucomentCheckList.ShowDialog();
        }

        public void frmIntiqalDucomentCheckList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIntiqalDucomentCheckList frmIntiqalDucomentCheckList = sender as frmIntiqalDucomentCheckList;
        }

        private void btnIntiqalPersonSnaps_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                 // Load Intiqal Visiting Date //

                    //this.dtVisitingPlan=Iq.GetIntiqalTaqdeeqDateStatus(this.IntiqalId);
                   
                   //if (this.dtVisitingPlan=="0")
                    
                   // {
                        
                   //     MessageBox.Show("مقرر کردہ تاریخ سے پہلے دورہ نہیں ہو سکتا۔ ایڈمنسٹریٹر سے رابطہ کریں", "دورہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // }
                   //else 
                  if (this.intiqalIId == "1" && (this.intiqalTypeId == "5" || this.intiqalTypeId == "37" || this.intiqalTypeId == "38" || this.intiqalTypeId == "35") && Iq.GetIntiqalWitnessYesNo(this.IntiqalId) == "-1")
                   {
                       MessageBox.Show("پہلے گواہان کا اندراج کریں", "گواہان", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
                    else
                    {
                        frmIntiqalPersonSnaps psnap = new frmIntiqalPersonSnaps();
                        psnap.IntiqalId = this.IntiqalId;
                        psnap.Attested = this.Attested;
                        psnap.Amaldaramad = this.AmalDaramad;
                        psnap.ShowDialog();
                    }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWitness_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmIntiqalDucomentCheckList frmIntiqalDucomentCheckList = new frmIntiqalDucomentCheckList();
                frmIntiqalDucomentCheckList.FormClosed -= new FormClosedEventHandler(frmIntiqalDucomentCheckList_FormClosed);
                frmIntiqalDucomentCheckList.FormClosed += new FormClosedEventHandler(frmIntiqalDucomentCheckList_FormClosed);
                frmIntiqalDucomentCheckList.IntiqalId = IntiqalId;
                frmIntiqalDucomentCheckList.ShowDialog();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void frmIntiqalDucomentCheckList_FormClosed(object sender, EventArgs e)
        { frmIntiqalDucomentCheckList frmIntiqalDucomentCheckList = sender as frmIntiqalDucomentCheckList; 
        }

        private void btnRecivedDucoments_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmDucomentRecievedForScan frmDucomentRecievedForScan = new frmDucomentRecievedForScan();
                frmDucomentRecievedForScan.FormClosed -= new FormClosedEventHandler(frmDucomentRecievedForScan_FormClosed);
                frmDucomentRecievedForScan.FormClosed += new FormClosedEventHandler(frmDucomentRecievedForScan_FormClosed);
                frmDucomentRecievedForScan.IntiqalId = IntiqalId;
                frmDucomentRecievedForScan.ShowDialog();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void frmDucomentRecievedForScan_FormClosed(object sender, EventArgs e)
        {
            frmDucomentRecievedForScan frmDucomentRecievedForScan = sender as frmDucomentRecievedForScan;
        }

        private void FillPatwarCircle()
        {
            //try
            //{
            //    PatwarCircles = area.GetPatwarCircle(UsersManagments._Tehsilid.ToString());
            //    DataRow pcRow = PatwarCircles.NewRow();
            //    pcRow["PatwarCircleNameUrdu"] = " - پٹوار سرکل کا انتخاب - ";
            //    pcRow["PatwarCircleId"] = "0";
            //    PatwarCircles.Rows.InsertAt(pcRow, 0);

            //    cboPC.DataSource = PatwarCircles;
            //    cboPC.DisplayMember = "PatwarCircleNameUrdu";
            //    cboPC.ValueMember = "PatwarCircleId";
            //    cboPC.SelectedValue = 0;

            //}
            //catch (Exception)
            //{

            //}
        }
        private void FillMoza()
        {
            try
            {
                objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cboMoza, "MozaNameUrdu", "MozaId");
                ////int pcId = Convert.ToInt32(cboPC.SelectedValue);
                //Mozas = area.GetMozaByPatwarCircle(UsersManagments._Tehsilid.ToString(), PcId);
                //DataRow MozaRow = Mozas.NewRow();
                //MozaRow["MozaId"] = "0";
                //MozaRow["MozaNameUrdu"] = " - موضع چنیے - ";
                //Mozas.Rows.InsertAt(MozaRow, 0);
                //cboMoza.DataSource = Mozas;
                //cboMoza.DisplayMember = "MozaNameUrdu";
                //cboMoza.ValueMember = "MozaId";
                //cboMoza.SelectedValue = 0;

            }
            catch (Exception)
            {

            }
        }

        private void cboPC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string pcId = cboPC.SelectedValue.ToString();
            //this.FillMoza(pcId);
        }

        private void btnIntiqalWitness_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                //this.dtVisitingPlan = Iq.GetIntiqalTaqdeeqDateStatus(this.IntiqalId);

                //if (this.dtVisitingPlan == "0")
                //{
                //    MessageBox.Show("مقرر کردہ تاریخ سے پہلے دورہ نہیں ہو سکتا۔ ایڈمنسٹریٹر سے رابطہ کریں");
                //}
               
                //else
                //{
                    if (this.intiqalTypeId == "5" && this.intiqalIId == "1")
                    {
                        this.dtGainTax = Iq.GetIntiqalGainTaxStatus(this.IntiqalId);
                        this.dtTaxesReceived = Iq.ChecIntiqalEnteredTaxReceived(this.TokenId);

                        if (this.dtGainTax == "0")
                        {
                            MessageBox.Show("اس انتقال پر گین ٹیکس لاگو ہے- پہلے گین ٹیکس جمع کریں");
                        }
                        else if (dtTaxesReceived != "1")
                        {
                             MessageBox.Show("پہلے تمام درج شدہ ٹیکسز وصول کریں۔");
                        }
                        else
                        {
                            frmInteqalWitness intWit = new frmInteqalWitness();
                            intWit.IntiqalId = this.IntiqalId;
                            intWit.MozaID = this.MozaId.ToString();
                            intWit.Attested = this.Attested;
                            intWit.Amaldaramad = this.AmalDaramad;
                            intWit.ShowDialog();
                        }
                    }
                    else
                    {
                        frmInteqalWitness intWit = new frmInteqalWitness();
                        intWit.IntiqalId = this.IntiqalId;
                        intWit.MozaID = this.MozaId.ToString();
                        intWit.Attested = this.Attested;
                        intWit.Amaldaramad = this.AmalDaramad;
                        intWit.ShowDialog();
                    }
                //}
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnIntiqalTaxes_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                if (this.intiqalIId == "2" || this.intiqalTypeId == "15" || this.intiqalIId == "3")
                {
                   
                }
                else
                {
                    if (ConfigurationSettings.AppSettings["sdc"] == "mrd" && Iq.GetIntiqalVisitingPlanYesNo(this.IntiqalId) == "-1")
                    {
                        MessageBox.Show("تاریخ دورہ کا اندراج کریں۔", "تاریخ دورہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                frmIntiqalTaxes intiqalTax = new frmIntiqalTaxes();
                intiqalTax.Intiqal_Id = this.IntiqalId;
                intiqalTax.LandValue = this.LandValue;
                intiqalTax.TokenId = this.TokenId;
                intiqalTax.Show();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           

        }

        private void btnDelMain_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnIntiqalDoc_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmIntiqalDucomentCheckList idchkList = new frmIntiqalDucomentCheckList();
                idchkList.IntiqalId = this.IntiqalId.ToString();
                idchkList.Show();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Get ServiceTypeId by Service Name

        private string GetServiceTypeIdByServiceName(string ServiceNameEng)
        {
            string ServiceTypeId = "0";
            DataTable dtServiceTypes = new DataTable();
            dtServiceTypes = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_ServiceTypes_ByServiceTypeName " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + ServiceNameEng + "'");
            if (dtServiceTypes != null)
            {
                if(dtServiceTypes.Rows.Count>0)
                ServiceTypeId = dtServiceTypes.Rows[0][0].ToString();
            }
            return ServiceTypeId;
        }

        #endregion


        private void cboMoza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoza.SelectedIndex > 0)
            {
                txtIntiqalNo.Enabled = true;
            }
            else
            {
                txtIntiqalNo.Enabled = false;
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            
            if(this.IntiqalId!=string.Empty && this.IntiqalId!="-1" )
            {
                //SDCReports TokenReport = new SDCReports();
                frmSDCReportingMain TokenReport = new frmSDCReportingMain();
                TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
                TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
                TokenReport.IntiqalId = this.IntiqalId;
                TokenReport.userId = UsersManagments.UserId.ToString();
                if(this.intiqalTypeId=="37")
                    UsersManagments.check = 18;
                else if(this.intiqalTypeId=="15")
                    UsersManagments.check = 19;
                else if(radKhanaKasht.Checked)
                    UsersManagments.check = 16;
                else if (radkhanakashtmalkiat.Checked)
                    UsersManagments.check = 17;
                else if(radKhanaMalkiat.Checked)
                UsersManagments.check = 4;
                TokenReport.ShowDialog();     
         
                // Above Code replaced by the following new code - using DotNet reortviewer instead of using builtin web browser control.

                //frmReportViewer frmRpt = new frmReportViewer();
                //frmRpt.IntiqalId = this.IntiqalId;
                //frmRpt.ShowDialog();

               }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TokenReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSDCReportingMain Populate = sender as frmSDCReportingMain;

        }

        #region Button Bank Challan Click Event
 
        private void btnBankChallan_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {

                frmIntiqalTaxReport TaxReport = new frmIntiqalTaxReport();
                TaxReport.IntiqalId = this.IntiqalId;
                TaxReport.ShowDialog();
                //frmSDCReportingMain TokenReport = new frmSDCReportingMain();
                //TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
                //TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
                //TokenReport.IntiqalId = this.IntiqalId;
                //UsersManagments.check = 5;
                //TokenReport.ShowDialog();

            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion


        private void cboIntiqalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }
        #region wirasat and khaqooqmalkiat disable
        public void Disable_Warisat_Cost()
        {

        }
        public void Disable_Warisat()
        {
           
        }

        public void Enable_Warisat()
        {
           
            txtLandValue.Enabled = true;

        }
        private void cboIntiqalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dv = (DataRowView)cboIntiqalType.SelectedItem;
            string s = (string)dv.Row["IntiqalType"];
            if (s == "وراثت")
            {
                Disable_Warisat();
            }

            else if (s == "تبدیلی حقوق ملکیت")
            {
                Disable_Warisat_Cost();
            }

            else
            {
                Enable_Warisat();

            }
        }
        #endregion

        #region Set Intiqal Pending Reason for Intiqal Pendency

        private void chkPendingIntiqal_Click(object sender, EventArgs e)
        {
            if (chkPendingIntiqal.Checked)
            {
                frmIntiqalPendingReasons frmReasonStatus = new frmIntiqalPendingReasons();
                frmReasonStatus.IntiqalId = this.IntiqalId.ToString();
                frmReasonStatus.FormClosed -= new FormClosedEventHandler(frmReasonStatus_FormClosed);
                frmReasonStatus.FormClosed += new FormClosedEventHandler(frmReasonStatus_FormClosed);
                frmReasonStatus.ShowDialog();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("کیا آپ اس انتقال کے زیر التواء حئثیت ختم کرنا چاہتے ہیں", "", MessageBoxButtons.YesNo))
                {
                    Iq.setIntiqalPendingReason(this.IntiqalId.ToString(), false, "", "");
                    this.btnSearchInteqal_Click(sender, e);
                }
            }
        }

        void frmReasonStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnSearchInteqal_Click(sender, e);
        }

        #endregion

        private void btnIntiqalAmalDaramadByKhata_Click(object sender, EventArgs e)
        {
             if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {
                 if(this.radkhanakashtmalkiat.Checked)
                 {
                     MessageBox.Show(" خانہ کاشت یا ملکیت سلیکٹ کریں", "کھاتہ در کھاتہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                try
                {
            frmIntiqalAmalDaramadByKhata IntiqalKhataAmal = new frmIntiqalAmalDaramadByKhata();
            IntiqalKhataAmal.IntiqalId = this.IntiqalId;
            IntiqalKhataAmal.MozaId = this.MozaId.ToString();
            IntiqalKhataAmal.KhanaMalkiat = this.radKhanaMalkiat.Checked;
            IntiqalKhataAmal.Khanakasht = this.radKhanaKasht.Checked;
            IntiqalKhataAmal.IntiqalAmalDaramad = this.AmalDaramad;

            IntiqalKhataAmal.isAttested = this.Attested;
            IntiqalKhataAmal.isGardawar = this.GardawarId;
            IntiqalKhataAmal.Teh_Report = this.Teh_Report;

            IntiqalKhataAmal.MdiParent = this.ParentForm;
            IntiqalKhataAmal.IntiqalPending = this.intiqalPending;
            IntiqalKhataAmal.Show();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
             else
             {
                 MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void btnROattestation_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {
                try
                {
                    // Load Intiqal Visiting Date //

                   // this.dtVisitingPlan = Iq.GetIntiqalTaqdeeqDateStatus(this.IntiqalId);
                  
                    //if (this.dtVisitingPlan == "0")
                    //{
                    //    MessageBox.Show("مقرر کردہ تاریخ سے پہلے تصدیق نہیں ہو سکتا۔ ایڈمنسٹریٹر سے رابطہ کریں");
                    //}

                    if (this.GardawarUserId == "0" && ConfigurationSettings.AppSettings["sdc"] == "mrd" && this.intiqalTypeId != "15")
                   {
                       MessageBox.Show("پہلے گرداور سے پڑتال کروالیں", "تصدیق انتقال", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                   }
                    //else  if (this.intiqalIId != "2" && Iq.GetIntiqalPersonsImagesYesNo(this.IntiqalId)!="1")
                    //{
                    //    MessageBox.Show(Iq.GetIntiqalPersonsImagesYesNo(this.IntiqalId).ToString(), "دورہ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                
                    //}
                     
                    else
                    {
                        //if (this.intiqalTypeId == "5" && this.intiqalIId == "1")
                        //{
                        //    this.dtGainTax = Iq.GetIntiqalGainTaxStatus(this.IntiqalId);

                        //    if (this.dtGainTax == "0")
                        //    {
                        //        MessageBox.Show("اس انتقال پر گین ٹیکس لاگو ہے- پہلے گین ٹیکس جمع کریں");
                        //    }
                        //    else
                        //    {
                        //        frmIntiqalAttestationByRO IntiqalAtt = new frmIntiqalAttestationByRO();
                        //        IntiqalAtt.intiqalId = this.IntiqalId;
                        //        IntiqalAtt.FormClosed -= new FormClosedEventHandler(IntiqalAtt_FormClosed);
                        //        IntiqalAtt.FormClosed += new FormClosedEventHandler(IntiqalAtt_FormClosed);
                        //        IntiqalAtt.ShowDialog();
                        //    }
                        //}
                        //else
                        //{
                            frmIntiqalAttestationByRO IntiqalAtt = new frmIntiqalAttestationByRO();
                            IntiqalAtt.intiqalId = this.IntiqalId;
                            IntiqalAtt.FormClosed -= new FormClosedEventHandler(IntiqalAtt_FormClosed);
                            IntiqalAtt.FormClosed += new FormClosedEventHandler(IntiqalAtt_FormClosed);
                            IntiqalAtt.ShowDialog();
                        //}

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IntiqalAtt_FormClosed(object sender, FormClosedEventArgs e)
        {
            // reload Intiqal Data
            btnSearchInteqal_Click(sender, e);
        }

        #region Form Minhaye Intiqal 

        private void btnMinhayeIntiqal_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMoza.SelectedValue.ToString() != "0" && this.IntiqalId != "-1")
                {
                    frmIntiqalMinhayeIntiqal min = new frmIntiqalMinhayeIntiqal();
                    min.MozaId = Convert.ToInt32(cboMoza.SelectedValue);
                    min.IntiqalId = Convert.ToInt32(this.IntiqalId);
                    min.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        #endregion

        #region Button Confirm by Operator Click

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فائنل کرنے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز فائنل ہے تو یس کلک کریں۔؟", "Confirmation of Intiqal Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    bool isConfirm=Iq.UpdateIntiqalMainConfirmByOperator(this.IntiqalId, "1");
                    this.isConfirmed = true;
                    this.btnConfirm.Enabled = !isConfirm;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Lable Operator Note Click Event
  
        private void lblOperatorNote_Click(object sender, EventArgs e)
        {
            try
            {
                frmIntiqalOperatorNote ipn = new frmIntiqalOperatorNote();
                ipn.IntiqalId = this.IntiqalId;
                if (lblOperatorNote.Text != "آپریٹر نوٹ لکھنے کیلئے کلک کریں")
                {
                    ipn.txtOperatorNote.Text = lblOperatorNote.Text;
                }
                ipn.FormClosed -= new FormClosedEventHandler(ipn_FormClosed);
                ipn.FormClosed += new FormClosedEventHandler(ipn_FormClosed);
                ipn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ipn_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnSearchInteqal_Click(sender, e);
           
        }

        #endregion

        private void btnIntiqalCancel_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {
                try
                {

                    frmIntiqalCacellationByRO IntiqalAtt = new frmIntiqalCacellationByRO();
                    IntiqalAtt.intiqalId = this.IntiqalId;
                    IntiqalAtt.FormClosed -= new FormClosedEventHandler(IntiqalCancel_FormClosed);
                    IntiqalAtt.FormClosed += new FormClosedEventHandler(IntiqalCancel_FormClosed);
                    IntiqalAtt.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void IntiqalCancel_FormClosed(object sender, FormClosedEventArgs e)
        {
            // reload Intiqal Data
            btnSearchInteqal_Click(sender, e);
        }

        #region Intiqal Revert for Nazar sani Button Click Event

        private void btnIntiqalRevert_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {
                try
                {
                    string IntiqalNoMalkiat = Iq.CheckIntiqalDependencyBeforeRevert(this.IntiqalId);
                    string IntiqalNoKhanakasht = Iq.CheckIntiqalDependencyBeforeRevertKhanakasht(this.IntiqalId);
                    if (IntiqalNoMalkiat != "0") // --- Khana Malkiat Dependent Intiqal
                    {
                        MessageBox.Show("اس انتقال کو نظر ثانی کیلئے واپس کرنے سے پہلے انتقال نمبر " + IntiqalNoMalkiat + " واپس/ریورٹ کریں۔ ", "نظرثانی انتقال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (IntiqalNoKhanakasht != "0") // --- Khana kasht Dependent Intiqal
                    {
                        MessageBox.Show("اس انتقال کو نظر ثانی کیلئے واپس کرنے سے پہلے انتقال نمبر " + IntiqalNoKhanakasht + " واپس/ریورٹ کریں۔ ", "نظرثانی انتقال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // --- if Dependent Intiqal not found go for reversion
                    {
                        if (MessageBox.Show(" کیا آپ اس انتقال کو نظر ثانی کیلئے واپس/ریورٹ کرنا چاہتے ہیں۔", "نظرثانی انتقال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmIntiqalCancellationByRO IntiqalRevert = new frmIntiqalCancellationByRO();
                            IntiqalRevert.intiqalId = this.IntiqalId;
                            IntiqalRevert.FormClosed -= new FormClosedEventHandler(IntiqalRevert_FormClosed);
                            IntiqalRevert.FormClosed += new FormClosedEventHandler(IntiqalRevert_FormClosed);
                            IntiqalRevert.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IntiqalRevert_FormClosed(object sender, FormClosedEventArgs e)
        {
            // reload Intiqal Data
            btnSearchInteqal_Click(sender, e);
        }

        #endregion

        private void btnGirdawar_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {
                try
                {

                    frmIntiqalAttestationByGardawar IntiqalAtt = new frmIntiqalAttestationByGardawar();
                    IntiqalAtt.intiqalId = this.IntiqalId;
                    IntiqalAtt.tokenId = this.TokenId;
                    IntiqalAtt.FormClosed -= new FormClosedEventHandler(IntiqalAtt_FormClosed);
                    IntiqalAtt.FormClosed += new FormClosedEventHandler(IntiqalAtt_FormClosed);
                    IntiqalAtt.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnChkGainTax_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                if(this.intiqalTypeId=="5" && this.intiqalIId=="1")
                {
                this.dtChkGainTax = Iq.CheckIntiqalGainTax(this.IntiqalId);

                if (this.dtChkGainTax.ToString() == "0")
                {
                    MessageBox.Show("سسٹم کو گین ٹیکس کے بارے میں معلومات نہیں ملی", "گین ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }

                else
                {
                    MessageBox.Show(this.dtChkGainTax.ToString(), "گین ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                
                }
                }
                else
                {
                    MessageBox.Show("گین ٹیکس صرف بیع کے انتقالات پر لاگو ہے", "گین ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }


        private void cmbFardTokenNo_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbFardTokenNo.SelectedIndex != 0)
            //{
            //    this.fardTokenId = cmbFardTokenNo.SelectedValue.ToString();

            //}
            //else
            //    this.fardTokenId = "0";
        }

        private void btnIntiqalAmal_Click(object sender, EventArgs e)
        {
            if (UsersManagments._IsAdmin)
            {
                if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ انتقال پر عمل درامد کرنا چاہتے ہے؟", "عمل درامد کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        this.btnIntiqalAmal.Enabled = false;
                        //MessageBox.Show("Yes");
                         //check whether seller and buyer raqba and hissa are same

                         string BS_AreaHissa = Iq.GetIntiqalSellerBuyerAreaCheck(this.IntiqalId);
                        if (BS_AreaHissa != "-1")
                        {
                            MessageBox.Show(BS_AreaHissa, "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            if (Iq.CheckMalikRemainingHissaCheck(this.IntiqalId) == "1")
                            {
                                DataTable dtIntiqalaAmal=Iq.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId);
                                if (dtIntiqalaAmal.Rows.Count > 0)
                                {
                                    if (dtIntiqalaAmal.Rows[0][0].ToString().Length > 5)
                                    {
                                        MessageBox.Show("عمل درامد ہو گیا");
                                        this.AmalDaramad = true;
                                        //this.SetAmalDaramadStatus(this.AmalDaramad);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("بایع / دہندہ کے محفوظ شدہ حصہ و رقبہ اور اصل ملکییتی حصہ و رقبہ برابر نہیں ہے۔", "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
        }
    }
}
