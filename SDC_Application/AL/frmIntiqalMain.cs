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
    public partial class frmIntiqalMain : Form
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

        public frmIntiqalMain()
        {


            InitializeComponent();
        }

        private void groupBoxRapat_Enter(object sender, EventArgs e)
        {

        }

        #region Tooltip

        public void tooltip()
        {
            toolTip.SetToolTip(txtCourt,"عدالت");
            toolTip.SetToolTip(txtCourtName,"عدالت کا نام");
            toolTip.SetToolTip(txtHawalaNo,"حوالہ نمبر");
            toolTip.SetToolTip(txtIntiqalNo,"انتقال نمبر");
            toolTip.SetToolTip(txtIntiqalRapatNo,"انتقال رپٹ نمبر");
            toolTip.SetToolTip(txtLandValue,"زمین کی قیمت");
            toolTip.SetToolTip(txtMisalNo,"مثل نمبر");
            toolTip.SetToolTip(txtRegisteryNo,"رجسٹری نمبر");
            toolTip.SetToolTip(txtTafsil,"تفصیل");
            toolTip.SetToolTip(txtTrialNo,"مقدمہ نمبر");
            toolTip.SetToolTip(txtTrialSubject,"عنوان مقدمہ");
            toolTip.SetToolTip(txtValuationTableValue,"");
            toolTip.SetToolTip(txtVersus,"بنام");
            //toolTip.SetToolTip(btnCancel,"منسوخ کریں");
            toolTip.SetToolTip(btnDelMain,"خذف کریں");
            toolTip.SetToolTip(btnIntiqalDoc,"انتقال کے لیے لازمی دستاویزات");
            //toolTip.SetToolTip(btnModifyIntiqal,"انقال تبدیل کریں");
            toolTip.SetToolTip(btnNewInteqal,"نیا انتقال");
            toolTip.SetToolTip(btnSave,"مخفوظ کریں");
            toolTip.SetToolTip(btnSearchInteqal,"انتقال تلاش کریں");
            toolTip.SetToolTip(btnValuationTable,"جانچ پڑتال");
            toolTip.SetToolTip(cboIntiqalInitiation,"انتقال بذریعہ");
            toolTip.SetToolTip(cboIntiqalType,"قسم انتقال");
            toolTip.SetToolTip(cboQismArazi,"قسم اراضی");

        }

        #endregion

        private void frmIntiqalMain_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            tooltip();
            fillIntiqalType();
            GetIntiqalInitiationList();
            fillIntiqalAreaType();
            fillIntiqalPlotType();
            this.FillMoza();
            this.IntiqalId = "-1";
           // this.FillPatwarCircle();


           // bool tes  = isDowraAllowedToday(); // sak_debug
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
        private void fillIntiqalListForMinhayeIntiqal(string MozaIdForIntiqalList)
        {
            this.IntiqalList = Iq.GetintiqalNoListByMozaId(MozaIdForIntiqalList);
            DataRow IntiqalType = IntiqalList.NewRow();
            IntiqalType["IntiqalId"] = "0";
            IntiqalType["IntiqalNo"] = " - انتقال نمبر - ";
            IntiqalList.Rows.InsertAt(IntiqalType, 0);
            cmbIntialListForMinhayeIntiqal.DataSource = IntiqalList;
            cmbIntialListForMinhayeIntiqal.DisplayMember = "IntiqalNo";
            cmbIntialListForMinhayeIntiqal.ValueMember = "IntiqalId";
            cmbIntialListForMinhayeIntiqal.SelectedValue = 0;
            if (MinhayeIntiqalId != "0")
            {
                this.cmbIntialListForMinhayeIntiqal.SelectedValue =Convert.ToInt32( MinhayeIntiqalId);
            }
        }

        private void fillIntiqalAreaType()
        {
            this.dttx = tx.GetIntiqalTerritoryTypeList();
            DataRow AreaType = dttx.NewRow();
            AreaType["PlotTerritoryTypeId"] = "0";
            AreaType["PlotTerritory_Urdu"] = " - قسم علاقہ چنیے - ";
            dttx.Rows.InsertAt(AreaType, 0);
            cboAreaType.DataSource = dttx;
            cboAreaType.DisplayMember = "PlotTerritory_Urdu";
            cboAreaType.ValueMember = "PlotTerritoryTypeId";
            cboAreaType.SelectedValue = 0;
        }

        private void fillIntiqalPlotType()
        {
            this.dtpt = tx.GetIntiqalPlotTypeList();
            DataRow PlotType = dtpt.NewRow();
            PlotType["PlotTypeId"] = "0";
            PlotType["PlotType_Urdu"] = " - قسم اراضی / پلاٹ چنیے - ";
            dtpt.Rows.InsertAt(PlotType, 0);
            cboPlotType.DataSource = dtpt;
            cboPlotType.DisplayMember = "PlotType_Urdu";
            cboPlotType.ValueMember = "PlotTypeId";
            cboPlotType.SelectedValue = 0;
        }

        private void fillIntiqalPlotConstrucitonType(string PlotTypeId)
        {

            this.dtcpt = tx.GetIntiqalPlotConstructionTypeList(PlotTypeId);
            DataRow PlotConType = dtcpt.NewRow();
            PlotConType["PlotConstructionTypeId"] = "0";
            PlotConType["PlotConstructionType_Urdu"] = " - حالت قسم اراضی / پلاٹ چنیے - ";
            dtcpt.Rows.InsertAt(PlotConType, 0);
            cboPlotConstructionType.DataSource = dtcpt;
            cboPlotConstructionType.DisplayMember = "PlotConstructionType_Urdu";
            cboPlotConstructionType.ValueMember = "PlotConstructionTypeId";
            cboPlotConstructionType.SelectedValue = 0;
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
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);
            Labels.Add(lbl3.Text);
            Labels.Add(lbl4.Text);
            Labels.Add(lbl5.Text);
            Labels.Add(lbl6.Text);
            Labels.Add(lbl7.Text);
            Labels.Add(lbl8.Text);
           // Labels.Add(lbl9.Text);
            Labels.Add(lbl10.Text);
            Labels.Add(lbl13.Text);
            Labels.Add(lbl14.Text);
            Labels.Add(lbl15.Text);
            Labels.Add(lbl16.Text);
            Labels.Add(lbl17.Text);
            Labels.Add(lbl19.Text);
            ArrayList collection = new ArrayList();
            string empty = null;
            string ReceivngId = "0";
            collection.Add(this.txtTokenNo.Text.ToString());
            collection.Add(this.cboPC.SelectedIndex.ToString());

            collection.Add(this.cboMoza.SelectedIndex.ToString());
            collection.Add(this.txtIntiqalNo.Text.ToString());
            collection.Add(this.cboIntiqalType.SelectedIndex.ToString());
            collection.Add(this.cboIntiqalInitiation.SelectedIndex.ToString());
            DataRowView dv = (DataRowView)cboIntiqalType.SelectedItem;
            string s = (string)dv.Row["IntiqalType"];
            if (s != "وراثت")
            {
                
                collection.Add(this.cboPlotType.SelectedIndex.ToString());
                collection.Add(this.cboPlotConstructionType.SelectedIndex.ToString());
                collection.Add(this.cboAreaType.SelectedIndex.ToString());
            }
            
            DataRowView II = (DataRowView)cboIntiqalInitiation.SelectedItem;
            string t = (string)II.Row["IntiqalInitiationType"];
            if (t == "رجسٹری")
            {
                
                    if (txtRegisteryNo.Text.Trim().Length == 0 || txtRegisteryNo.Text == "0")
                    {
                        MessageBox.Show("- رجسٹری نمبر کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dtpDateOfDec.Checked == false)
                    {
                        MessageBox.Show("- تاریخ رجسٹری کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dtpDateOfDec.Checked == true)
                    {
                        if (dtpDateOfDec.Value > DateTime.Now)
                        {
                            MessageBox.Show("- تاریخ رجسٹری کا غلط ہے", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //if (dtpDateOfDec.Value > DateTime.ParseExact("2019-04-30", "yyyy-MM-dd", null) && ConfigurationSettings.AppSettings["sdc"] == "mrd" && (string)dv.Row["IntiqalType"]=="بیع")
                    //{

                    //    if (dtFardToken.Checked == false || cmbFardTokenNo.SelectedIndex==0)
                    //    {
                    //        MessageBox.Show("- رجسٹری کا ٹوکن چنئے", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                    string RegIntiqal = Iq.CheckRegAlreadyEntered(txtRegisteryNo.Text, dtpDateOfDec.Value.Year, MozaId.ToString());
                    if (RegIntiqal != "-1")
                    {
                        if (this.txtIntiqalNo.Text != RegIntiqal)
                        {
                            MessageBox.Show(" رجسٹری نمبر" + txtRegisteryNo.Text + " پر پہلے سے انتقال نمبر " + RegIntiqal + " کا اندراج ہو چکا ہے۔", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    ReceivngId = Iq.CheckRegAlreadyReceived(txtRegisteryNo.Text, dtpDateOfDec.Value.Year, MozaId.ToString());
                   
                    if (ReceivngId == "-1")
                    {

                        MessageBox.Show("سال "+dtpDateOfDec.Value.Year.ToString()+"  میں رجسٹری نمبر" + txtRegisteryNo.Text + " کا ریکارڈ موضع " + cboMoza.Text + "  میں موجود نہیں ہے۔ پہلے رجسٹری وصول کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        return;

                    }
                
            }
            //collection.Add(this.cboIntiqalInitiation.SelectedIndex.ToString());
            //collection.Add(this.cboPlotType.SelectedIndex.ToString());
            //collection.Add(this.cboPlotConstructionType.SelectedIndex.ToString());
            //collection.Add(this.cboAreaType.SelectedIndex.ToString());
           // collection.Add(this.txtLandValue.Text.ToString());
            if (checkBoxRegistry.Checked)
            {
               // collection.Add(this.txtRegisteryNo.Text.ToString());
               // collection.Add(this.txtCourt.Text.ToString());
               // collection.Add(this.txtTrialNo.Text.ToString());
               // collection.Add(this.txtTrialSubject.Text.ToString());
               // collection.Add(this.txtVersus.Text.ToString());            
            }
            if (checkBoxRaptEntry.Checked)
            {
                collection.Add(this.txtIntiqalRapatNo.Text.ToString());
            }
            

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
                    if (cmbFardTokenNo.SelectedIndex == 0)
                    {
                        dtFardToken.Checked = false;
                        dtFardToken.Enabled = false;
                    }
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
                    string rapatNo = txtIntiqalRapatNo.Text.Trim() != "" ? txtIntiqalRapatNo.Text.ToString() : "NULL";
                    string rapatDate = dtpIntiqalRapatDate.Checked ? dtpIntiqalRapatDate.Value.ToShortDateString() : "";
                    string amalDaramadDate = dtpIntiqalAmaldramadDate.Checked ? dtpIntiqalAmaldramadDate.Value.ToShortDateString() : "";
                    string landValue = txtLandValue.Text.Trim() != "" ? txtLandValue.Text.ToString() : "0";
                    string AttestDate = dtpTasdiq.Checked ? dtpTasdiq.Value.ToShortDateString() : "";
                    string landTypeId = cboQismArazi.SelectedIndex != -1 ? cboQismArazi.SelectedValue.ToString() : "1";
                    string DegreeDate = dtpDateOfDec.Checked ? dtpDateOfDec.Value.ToShortDateString() : "";
                   
                    string courtname = txtCourt.Text.Trim() != "" ? txtCourt.Text.ToString() : "";
                    string misalNo = txtMisalNo.Text.Trim() != "" ? txtMisalNo.Text.Trim().ToString() : "NULL";
                    string LandValutionTablVal = txtValuationTableValue.Text.Trim() != "" ? txtValuationTableValue.Text.Trim().ToString() : "0";
                    string tafseel = this.txtTrialSubject.Text.Trim() != "" ? txtTrialSubject.Text.ToString() : "NULL";
                    
                    string PlotTypeId = cboPlotType.SelectedValue != null ? cboPlotType.SelectedValue.ToString() : "0";
                    string PlotConstType = cboPlotConstructionType.SelectedValue != null ? cboPlotConstructionType.SelectedValue.ToString() : "0";
                    string PlotTerritType = cboAreaType.SelectedValue!=null?cboAreaType.SelectedValue.ToString():"0";
                    string LastIntiqalDate = DateTime.Now.ToShortDateString();
                    string mozaId = this.cboMoza.SelectedValue.ToString();
                    string usrId = UsersManagments.UserId.ToString();
                    string usrName = UsersManagments.UserName.ToString();
                    string MinhayeIntiqalId = cmbIntialListForMinhayeIntiqal.SelectedValue.ToString();
                    string txtRegNo = txtRegisteryNo.Text.Trim()!=""?txtRegisteryNo.Text.Trim():"0";
                    string RegDate = dtRegisteryDate.Checked ? dtRegisteryDate.Value.ToShortDateString() : "NULL";
                    //string TrialSubject = txtTrialSubject.Text;
                    string FardTokenDate = dtFardToken.Checked ? dtFardToken.Value.ToShortDateString() : "";
                    string FardTokenIdSelected = cmbFardTokenNo.SelectedIndex != 0 ? cmbFardTokenNo.SelectedValue.ToString() : "0";
                    
                    if (mozaId != "-1" && mozaId != "0")
                    {

                        string LastId = Iq.SaveintiqalMain(intiqalId, mozaId, radKhanaMalkiat.Checked.ToString(), radKhanaKasht.Checked.ToString(), this.radkhanakashtmalkiat.Checked.ToString(), intiqalNo, txtRegNo, intiqalTypeId, intiqalInitaionId, IndrajDate, rapatNo, rapatDate, amalDaramadDate, landValue, AttestDate, "1", landTypeId, LandValutionTablVal, DegreeDate, courtname, misalNo, tafseel, usrId, usrName, TokenId, PlotTypeId, PlotConstType, PlotTerritType, LastIntiqalDate, MinhayeIntiqalId, FardTokenIdSelected, FardTokenDate,ReceivngId);
                        MessageBox.Show("انتقال کا اندراج  ہو گیا ہے۔");
                        this.ClearFormControls(groupBox6);
                        this.ClearFormControls(groupBox5);
                        this.ClearFormControls(groupBoxRapat);
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
            this.intiqalRtrv = Iq.GetintiqalMainByIntiqalIdMozaId(mozaId, intiqalNo);
            
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
                    dtpIntiqalAmaldramadDate.Value = Convert.ToDateTime(data["IntiqalAmaldramadDate"]); 
                    dtpTasdiq.Value = Convert.ToDateTime(data["IntiqalAttestationDate"]);
                    cboIntiqalType.SelectedValue = data["IntiqalTypeId"];
                    this.intiqalTypeId = data["IntiqalTypeId"].ToString();
                    cboIntiqalInitiation.SelectedValue = data["IntiqalInitiationId"];
                    this.intiqalIId = data["IntiqalInitiationId"].ToString();
                    txtRegisteryNo.Text = data["IntiqalHawalaNo"].ToString();
                    txtLandValue.Text = data["LandValue"].ToString();
                    LandValue = data["LandValue"].ToString();
                    txtIntiqalRapatNo.Text = data["IntiqalRapatNo"].ToString();
                    dtpIntiqalRapatDate.Value = Convert.ToDateTime(data["IntiqalRapatDate"]);
                    txtTafsil.Text = data["OtherDetail"].ToString();
                    this.Teh_Report = data["Teh_Report"].ToString().Length;
                    // dtpTasdiq.Value = data.IntiqalAttestationDate;
                    if (cboIntiqalInitiation.SelectedValue.ToString() == "2") // Not registery
                    {
                        dtpDateOfDec.Checked = true;
                        dtFardToken.Checked = true;
                        btnIntiqalPersonSnaps.Enabled = false;
                        btnChkGainTax.Enabled = false;
                        btnIntiqalTaxes.Enabled = false;
                        btnIntiqalWitness.Enabled = false;
                        btnBankChallan.Enabled = false;
                        btnIntiqalTasdiqDate.Enabled = false;

                    }
                    else
                    {
                        btnIntiqalPersonSnaps.Enabled = true;
                        btnChkGainTax.Enabled = true;
                        btnIntiqalTaxes.Enabled = true;
                        btnIntiqalWitness.Enabled = true;
                        btnBankChallan.Enabled = true;
                        btnIntiqalTasdiqDate.Enabled = true;
                    }
                    dtpDateOfDec.Value = Convert.ToDateTime(data["DegreeDate"]);
                    txtCourt.Text = data["CourtName"].ToString();
                    txtMisalNo.Text = data["MisalNo"].ToString();
                    txtTrialSubject.Text = data["LastIntiqalDate"].ToString();
                    cboAreaType.SelectedValue = data["PlotTerritoryTypeId"];
                    cboPlotType.SelectedValue = data["PlotTypeId"];
                    dtFardToken.Value = Convert.ToDateTime(data["fardTokenDate"]);

                // ,,,,,,,,,,,,,If registry fard is of same date,,,,,,,,,,,,,,,,,,,,,,,,,
 
                    if (cboIntiqalInitiation.SelectedValue.ToString() == "2")
                    {
                        DateTime date = dtFardToken.Value;
                        string month = date.Month.ToString();
                        string day = date.Day.ToString();
                        string year = date.Year.ToString();
                        datetoken = year + "-" + month + "-" + day;
                        this.TokenList = Iq.GetTransactionalTokenNoListByDate(this.MozaId, datetoken);
                        DataRow Token = TokenList.NewRow();
                        Token["TokenId"] = "0";
                        Token["TokenNo"] = " - ٹوکن نمبر - ";
                        TokenList.Rows.InsertAt(Token, 0);
                        cmbFardTokenNo.DataSource = TokenList;
                        cmbFardTokenNo.DisplayMember = "TokenNo";
                        cmbFardTokenNo.ValueMember = "TokenId";
                        cmbFardTokenNo.SelectedIndex = 0;

                    }
                //,,,,,,,,,,,,,,,,,,,end,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,

                    cmbFardTokenNo.SelectedValue = data["fardTokenId"];
                    this.fardTokenId = data["fardTokenId"].ToString();
                    fillIntiqalPlotConstrucitonType(cboPlotType.SelectedValue != null ? cboPlotType.SelectedValue.ToString() : "0");
                    cboPlotConstructionType.SelectedValue = data["PlotConstructionTypeId"];
                    string tokId = data["TokenId"].ToString();
                    TokenId = data["TokenId"].ToString();
                    txtTokenNo.Text = dtTok.GetTokenNoByTokenId((tokId != null && tokId != "") ? tokId : "0");
                    btnDelMain.Enabled = true;
                    //radKhanaKasht.Enabled = false;
                    //radKhanaMalkiat.Enabled = false;
                    //radkhanakashtmalkiat.Enabled = false;
                    this.MinhayeIntiqalId = data["MinhaieIntiqalId"].ToString();
                    this.AmalDaramad = Convert.ToBoolean(data["AmalDaramadStatus"]);
                    this.Attested = Convert.ToBoolean(data["Attested"]);  //Cancelled
                    this.isConfirmed = Convert.ToBoolean(data["OperatorConfirm"]); 
                    this.btnConfirm.Enabled =!this.isConfirmed;
                    this.Cancelled = Convert.ToBoolean(data["Cancelled"]);
                    this.GardawarId = data["GardawarId"].ToString();
                    this.GardawarUserId = data["GardawarUserId"].ToString();

                    if (cboMoza.SelectedIndex != -1 && txtIntiqalNo.Text.Trim().Length > 0 && cboIntiqalInitiation.SelectedValue.ToString() == "2")
                    {
                        chkkhata = Iq.GetRegistryIntiqalKhataCheck(cboMoza.SelectedValue.ToString(), txtIntiqalNo.Text.Trim());
                        if (this.chkkhata == "1")
                        {
                            cmbFardTokenNo.Enabled = false;
                            dtFardToken.Enabled = false;
                        }
                        else
                        {
                            cmbFardTokenNo.Enabled = true;
                            dtFardToken.Enabled = true;
                        }
                    }

                    if(AmalDaramad)
                    {
                        btnIntiqalRevert.Enabled = true;
                    }
                    else
                    {
                        btnIntiqalRevert.Enabled = false;
                    }
                    
                    if (Attested)
                    {
                        this.btnROattestation.Enabled = false;
                        this.btnIntiqalCancel.Enabled = false;
                        this.btnIntiqalTasdiqDate.Enabled = false;
                        this.btnSave.Enabled = false;
                    }
                    else
                    {
                        this.btnROattestation.Enabled = true;
                        this.btnIntiqalCancel.Enabled = true;
                        this.btnSave.Enabled = true;
                        if(this.intiqalIId=="2")
                        {
                            this.btnIntiqalTasdiqDate.Enabled = false;
                        }
                        else
                        {
                            this.btnIntiqalTasdiqDate.Enabled = true;
                        }
                        
                    }
                    if (this.GardawarUserId == "0")
                    {
                        this.btnGirdawar.Enabled = true;
                        if(!Attested)
                        {
                            //this.btnROattestation.Enabled = false;
                            //this.btnIntiqalCancel.Enabled = false;
                            this.btnSave.Enabled = true;
                        }
                      
                    }
                    else
                    {
                        this.btnGirdawar.Enabled = false;
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
                        this.groupBox7.Enabled = false;
                        this.groupBox1.Enabled = false;
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
                    this.fillIntiqalListForMinhayeIntiqal(mozaId);

                    
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
            this.ClearFormControls(groupBox5);
            this.ClearFormControls(groupBox6);
            this.ClearFormControls(groupBoxRapat);
            panelCurrentStatus.Visible = false;
        }

        private void checkBoxRaptEntry_CheckedChanged(object sender, EventArgs e)
        {
            
                groupBoxRapat.Visible = checkBoxRaptEntry.Checked;
           

        }

        private void btnKhataJat_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
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
                    frmIK.isGardawar = this.GardawarUserId;
                    frmIK.Teh_Report = this.Teh_Report;
                    frmIK.isConfirmed = this.isConfirmed;
                    frmIK.MalkiatKashkat = true;
                    frmIK.MinhayeIntiqalId = this.MinhayeIntiqalId;

                    frmIK.IntiqalTypeId = this.intiqalTypeId;
                    frmIK.FardTokenId = this.fardTokenId;
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



        bool isDowraAllowedToday()
        {

                int Tehsilid= UsersManagments._Tehsilid;
                if (Tehsilid == -1 || Tehsilid == 0) return true;


            //DateTime.Now.DayOfWeek = DayOfWeek.Friday
            string dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
            string db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
            string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                /*
                                if (!Int32.TryParse(this.txtTehsilid.Text, out Tehsilid))
                                {
                                    MessageBox.Show(this.txtTehsilid.Text + " is not tehsil id");
                                }*/

                string Query = @"
DECLARE @Tehsilid INT = {0} 
DECLARE @id int = {1}

       SELECT id,
              @Tehsilid AS Tehsilid,
              [WeekDay]
              INTO #TEmp
       FROM   DowaraWeekDays
       WHERE  (
                  EXISTS(
                      SELECT *
                      FROM   DowaraWeekDays
                      WHERE  TehsilId = @TehsilId
                  )
                  AND Tehsilid = @TehsilId
              )
              OR  (
                      NOT EXISTS(
                          SELECT *
                          FROM   DowaraWeekDays
                          WHERE  TehsilId = @TehsilId
                      )
                      AND Tehsilid = 0
                  )


    
IF EXISTS( SELECT * FROM #TEmp WHERE id = @id)
BEGIN
	SELECT 1 as id
END
ELSE SELECT 0 as id

DROP TABLE  #TEmp    
";
                int dayintval = (int) DateTime.Now.DayOfWeek;

                Query = String.Format(Query, Tehsilid, dayintval);

Query = Query.Replace("@TehsilId" , Tehsilid.ToString());

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 5;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    int idValue = (int)ds.Tables[0].Rows[0]["id"];

                    return idValue == 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return false;

        }


        public void frmIntiqalDucomentCheckList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIntiqalDucomentCheckList frmIntiqalDucomentCheckList = sender as frmIntiqalDucomentCheckList;
        }

        private void checkBoxRegistry_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox5.Visible = checkBoxRegistry.Checked;
        }

        private void btnIntiqalPersonSnaps_Click(object sender, EventArgs e)
        {

            if (!isDowraAllowedToday())
            {
                string today = DateTime.Now.DayOfWeek.ToString();
                MessageBox.Show("Dowra is not allowed on " + today);
                return;
            }

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

        private void cboPlotType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPlotType.SelectedIndex > 0)
            {
                fillIntiqalPlotConstrucitonType(cboPlotType.SelectedValue.ToString());
            }
        }

        private void btnSrchToken_Click(object sender, EventArgs e)
        {
            this.btnNewInteqal_Click(sender, e);

            frmTokenPopulate Populate = new frmTokenPopulate();
            Populate.ServiceTypeId = GetServiceTypeIdByServiceName("Inteqal");
            Populate.fromform = "1";
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);

            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
            Populate.InteqalMain = true;
            Populate.ShowDialog();

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

        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTokenPopulate Populate = sender as frmTokenPopulate;
            this.TokenId = Populate.TokenID;
           txtTokenNo.Text=Populate.TokenNo;
           this.MozaId =  Convert.ToInt32(Populate.Mouzaid);
           this.cboMoza.SelectedValue = (Populate.Mouzaid != null && Populate.Mouzaid != "") ? Populate.Mouzaid : "0";
           string lastNo= Iq.GetNextIntiqalNoForMoza((Populate.Mouzaid != null && Populate.Mouzaid != "") ? Populate.Mouzaid : "0", Populate.TokenID);
           this.fillIntiqalListForMinhayeIntiqal(cboMoza.SelectedValue!=null?cboMoza.SelectedValue.ToString():"0");
           long MaxNo=0;
           if (long.TryParse(lastNo, out MaxNo))
           {
               this.txtIntiqalNo.Text = MaxNo.ToString();
           }
           else
           {
               MessageBox.Show("سسٹم اگلے انتقال نمبر پیدا کرنے میں ناکام راہا۔ خود سے نیا انتقال نمبر کا اندراج کریں-", "انتقال نمبر غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           panelCurrentStatus.Visible = false;
        }

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

        #region Button Intiqal Tasdiq Date and Time Click Event

        private void btnIntiqalTasdiqDate_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmIntiqalTasdiqDate intiqalTasdiq = new frmIntiqalTasdiqDate();
                intiqalTasdiq.IntiqalId = this.IntiqalId;
                intiqalTasdiq.IntiqalNo = txtIntiqalNo.Text;
                intiqalTasdiq.TokenId = this.TokenId;
                intiqalTasdiq.TokenNo = this.txtTokenNo.Text;
                intiqalTasdiq.MozaId = this.MozaId.ToString();
                intiqalTasdiq.isloadFromIntiqal = true;
                intiqalTasdiq.ShowDialog();
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
           // txtLandValue.Text = "0";
            //txtLandValue.Enabled = false;
            cboPlotConstructionType.Enabled = true;
            cboPlotType.Enabled = true;
            cboAreaType.Enabled = true;
        }
        public void Disable_Warisat()
        {
            if (cboPlotConstructionType.SelectedIndex > 1)
            {
                cboPlotConstructionType.SelectedIndex = 1;
            }
            if (cboPlotType.SelectedIndex > 1)
            {
              cboPlotType.SelectedIndex = 1;
              }

            if (cboAreaType.SelectedIndex > 1)
            {
                cboAreaType.SelectedIndex = 1;
            }
cboPlotConstructionType.Enabled = false;
cboPlotType.Enabled = false;
cboAreaType.Enabled=false;
txtLandValue.Text = "0";
txtLandValue.Enabled = false;
        }

        public void Enable_Warisat()
        {
            cboPlotConstructionType.Enabled = true;
            cboPlotType.Enabled = true;
            cboAreaType.Enabled = true;
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

        private void dtFardToken_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dtFardToken.Value;
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string year = date.Year.ToString();
            datetoken = year + "-"+ month + "-" + day;
            this.TokenList = Iq.GetTransactionalTokenNoListByDate(this.MozaId,datetoken);
            DataRow Token = TokenList.NewRow();
            Token["TokenId"] = "0";
            Token["TokenNo"] = " - ٹوکن نمبر - ";
            TokenList.Rows.InsertAt(Token, 0);
            cmbFardTokenNo.DataSource = TokenList;
            cmbFardTokenNo.DisplayMember = "TokenNo";
            cmbFardTokenNo.ValueMember = "TokenId";
            cmbFardTokenNo.SelectedIndex = 0;
           
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

        private void cboIntiqalInitiation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboIntiqalInitiation.SelectedValue.ToString() == "2")
            {

                txtRegisteryNo.Enabled = true;
                dtFardToken.Checked = true;
                dtFardToken.Enabled = true;
                cmbFardTokenNo.Enabled = true;
                dtpDateOfDec.Checked = true;
                dtpDateOfDec.Enabled = true;
                if(txtCourt.Text.Trim()=="")
                {
                    txtCourt.Text = " سب رجسٹرار" + UsersManagments.TehsilNameUrdu;
                }
                if (dtpDateOfDec.Value < DateTime.ParseExact("1925-01-01", "yyyy-MM-dd", null))
                {
                    dtpDateOfDec.Value = DateTime.Now;
                }

                if (cboMoza.SelectedIndex != -1 && txtIntiqalNo.Text.Trim().Length > 0)
                {
                    chkkhata = Iq.GetRegistryIntiqalKhataCheck(cboMoza.SelectedValue.ToString(), txtIntiqalNo.Text.Trim());
                    if (this.chkkhata == "1")
                    {
                        cmbFardTokenNo.Enabled = false;
                        dtFardToken.Enabled = false;
                    }
                    else
                    {
                        cmbFardTokenNo.Enabled = true;
                        dtFardToken.Enabled = true;
                    }
                }
               
            }
            else
            {
                txtRegisteryNo.Text = "0";
                if(txtCourt.Text.Contains("رجسٹرار"))
                {
                    txtCourt.Clear();
                }
                txtRegisteryNo.Enabled = false;
                dtFardToken.Checked = false;
                dtFardToken.Enabled = false;
                if (cmbFardTokenNo.Items.Count > 0)
                    cmbFardTokenNo.SelectedIndex = 0;
                cmbFardTokenNo.Enabled = false;
                dtpDateOfDec.Checked = false;
                dtpDateOfDec.Enabled = false;
            }


           
        }

        private void btnRoznamcha_Click(object sender, EventArgs e)
        {
            if (IntiqalId != "-1")
            {
                frmRoznamcha frmRoz = new frmRoznamcha();
                frmRoz.IntiqalId = this.IntiqalId;
                frmRoz.IntiqalNo = this.txtIntiqalNo.Text;
                frmRoz.Attested = this.Attested;
                frmRoz.tokenId = this.TokenId;
                frmRoz.dtRoznamcha = dtpIntiqalAndrajDate.Value.ToShortDateString();
                frmRoz.MozaId = MozaId.ToString();
                frmRoz.Show();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnLandTax_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1")
            {

                frmIntiqalTaxAIT TaxReport = new frmIntiqalTaxAIT();
                TaxReport.IntiqalId = this.IntiqalId;
                TaxReport.ShowDialog();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "انتقال لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      

    }
}
