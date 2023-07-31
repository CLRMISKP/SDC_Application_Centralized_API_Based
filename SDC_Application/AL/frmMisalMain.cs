using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.BL;
using SDC_Application.Classess;
using System.IO;
using System.Net;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Drawing.Imaging;
using SDC_Application.DL;
using LandInfo.ControlsLib;
using System.Data.SqlClient;



using System.Diagnostics;

namespace SDC_Application.AL
{
    public partial class frmMisalMain : Form
    {
        #region Class Variables
        /// <summary>
        /// Objects of Langauage Converter, Web Service and Lists for data manipulation
        /// </summary>
        LanguageConverter Lang = new LanguageConverter();
        Misal misalBL=new Misal();
        AutoComplete objauto = new AutoComplete();
        DataTable fbKhattaJat=new DataTable();
        DataTable khewatMalikanByFB=new DataTable();
        DataTable KhatoniesByFb=new DataTable();
        DataTable khattasByMoza=new DataTable();
        DataTable AreaTypesList=new DataTable();
        DataTable KhatooniKhassrasAreaDetails=new DataTable();
        DataTable KhatooniKhassrasAreaDetailsFB = new DataTable();
        DataTable GetKhatoonisFB=new DataTable();
        DataTable khewatTypes = new DataTable();
        DataTable AreaTypes = new DataTable();
        DataTable khatoniByKhata = new DataTable();
        DataTable MisalMainListByMozaId = new DataTable();
        DataTable KhassraAreaByKhassraId = new DataTable();
        DataTable GetTotalRaqba = new DataTable();
        bool ConfirmationStatus = false;
        bool AmaldaramadStatus = false;
        
        int registerNo = 0;
        string khatoniNo = "";
        string seqNo = "";

        public string IndexedKhattaNo { get; set; }

        ArrayList list = new ArrayList();
        Intiqal Iq = new Intiqal();
        public string MouzaId { get; set; }

        public byte[] ReceivedImage { get; set; }
        string ToSaveFileTo = "";
        BL.frmToken objbusines = new BL.frmToken();

        #region Class Variables for Shajra Malik name Changes

        //int UserId = Classes.CurrentUser.UserId;
        //List<Proc_Get_Moza_AfradList_All_Types_Result> AllPerson = new List<Proc_Get_Moza_AfradList_All_Types_Result>();
        //List<Proc_Get_Moza_AfradList_All_Types_FB_Result> mozaAllAfrad = new List<Proc_Get_Moza_AfradList_All_Types_FB_Result>();
        bool familyHead = false;

        #endregion

        #endregion

        #region Default Constructor

        public frmMisalMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Custom Functions

        #region Check wether khatta number already exists before saving new khatta
        /// <summary>
        /// Check if khatta already exists, return true if exists else return false if not exists.
        /// </summary>
        /// <returns>True or False</returns>

        private bool isExistsKhatta()
        {
            bool retVal = false;
            foreach (DataRow row in khattasByMoza.Rows)
            {
                if (row["KhataNo"].ToString() == txtKhatatNo.Text.Trim())
                {
                   retVal= true;
                }
               
            }
            return retVal;
            //if (this.khattasByMoza.Where(p => p.KhataNo.Equals(txtKhatatNo.Text.Trim())).Count() > 0)
            //{
            //    return true;
            //}registerNo
            //else
            //    return false;
        }

        #endregion

        #region Function SaveKhatta
        /// <summary>
        /// This method Save's New Khata or Update Existing Khata.
        /// </summary>
        private void SaveKhata()
        {
            try 
	            {	        
		            int KhattaId = Convert.ToInt32(this.txtKhattaId.Text.ToString());
                    int mozaId = Convert.ToInt32(cmbMouza.SelectedValue!=null?cmbMouza.SelectedValue.ToString():"0");
                    string KhattaNo = this.txtKhatatNo.Text;
                    string KullHissay = txtKulHisay.Text.Trim() != "" ?this.txtKulHisay.Text.ToString() : "0";
                    string Kanal = txtKanal.Text.Trim() != "" ? this.txtKanal.Text.ToString() : "0";
                    string Marla = txtMarla.Text.Trim() != "" ? this.txtMarla.Text.ToString() : "0";
                    float SarSai = txtSarsai.Text.Trim() != "" ? float.Parse(this.txtSarsai.Text) : 0;
                    float Feet = SarSai > 0 ? SarSai * float.Parse("30.25") : (txtFeet.Text.Trim() != "" ? float.Parse(txtFeet.Text) : 0);
                    if (!(SarSai > 0))
                    {
                        SarSai = txtFeet.Text.Trim() != "" ? float.Parse(txtFeet.Text) / float.Parse("30.25") : 0;
                    }
                    string Malya = this.txtMalia.Text;
                    string Kafiat = this.txtKafyat.Text;

                    string FbKhattaId = txtFbKhataId.Text;
                    string FbId = txtFbId.Text;

                    //string LastID = client.SaveHaqdaranZameenKhatajaat(KhattaId, registerNo, KhattaNo, "", "", KullHissay, Kanal, Marla, SarSai, Feet, Malya, Kafiat, UserId, CurrentUser.UserName).ToString();
                    string LastID = misalBL.SaveFBKhattaRecord(FbKhattaId, FbId, KhattaId.ToString(), this.registerNo.ToString(), KhattaNo, "", "", KullHissay, Kanal, Marla, SarSai.ToString(), Feet.ToString(), Malya, Kafiat,UsersManagments.UserId.ToString(), UsersManagments.UserName);




                    this.txtKhattaId.Text = LastID.ToString();
                    
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = client.GetAllKhatasByMozaIdByRegisterId(mozaId , RegisterNo);
                    //this.cboKhataNo.Refresh();
                    this.FillKhataJaatByMoza();
                    //this.tableLayoutPanel3.Enabled = false;
                    //this.cboKhataNo.SelectedValue = Convert.ToInt32(LastID);
                    //this.splitContainer1.Panel2.Enabled = false;
                    MessageBox.Show("کھاتہ محفوظ ہو گیا ہے۔", "");
                    this.ClearFormControls(gbBabat);
                    this.ClearFormControls(gbKhataRaqba);
                    this.txtKhatatNo.Clear();
                    this.txtKulHisay.Clear();
	            }
	            catch (Exception ex)
	            {
		            MessageBox.Show(ex.Message);
	            }
           

        }
        #endregion

        #region Load FB Data for existing FB

        private void loadFbData(string fbId)
        {
            //Load Fard Bader Khattajat

            fbKhattaJat = misalBL.GetFbKhattajat(fbId);
            if (fbKhattaJat.Rows.Count > 0)
            {
                cboKhataNo.SelectedValue = fbKhattaJat.Rows[0]["RegisterHqDKhataId"].ToString();
                txtKhatatNo.Text = fbKhattaJat.Rows[0]["KhataNo"].ToString();
                txtKulHisay.Text = fbKhattaJat.Rows[0]["TotalParts"].ToString();
                //string[] area = khatta.Khata_Area.Split('-');
                txtMalia.Text = fbKhattaJat.Rows[0]["Malia"].ToString();
                txtKafyat.Text = fbKhattaJat.Rows[0]["Kyfiat"].ToString();
                txtKanal.Text = fbKhattaJat.Rows[0]["Khata_Kanal"].ToString();
                txtMarla.Text = fbKhattaJat.Rows[0]["Khata_Marla"].ToString();
                txtSarsai.Text = fbKhattaJat.Rows[0]["Khata_Sarsai"].ToString();
                txtFeet.Text = fbKhattaJat.Rows[0]["Khata_Feet"].ToString();
                txtFbKhataId.Text = fbKhattaJat.Rows[0]["RegisterHqDKhataId"].ToString();

            }

            // Load Fard Bader Malikan and Select Khatta from drop down if malikan changes occurred in the searched fard bader.///
            // ALL GROUP MEMBERS IN KHATA WITH FB_Exists switch
             khewatMalikanByFB = misalBL.GetKhewatFarqeenGroupByKhatId_Misal(fbId, cboKhataNo.SelectedValue.ToString());
            if (khewatMalikanByFB.Rows.Count > 0)
            {
                FillGridviewMalkan(khewatMalikanByFB);
                int khattaid =Convert.ToInt32(khewatMalikanByFB.Rows[0]["RegisterHqDKhataId"].ToString());
                cboKhataNo.SelectedValue = khattaid;
                SetKhataDetailsToTextboxes(khattaid.ToString());
                this.txtKhattaId.Text = khattaid.ToString();
                this.FillKhatoniListbyKhattaId();
            }

            // Load Khatoni details if khatoni changed occured in the searched fard bader
            int RegHaqKhattaId = Convert.ToInt32(cboKhataNo.SelectedValue);
            KhatoniesByFb = misalBL.GetKhatonisByKhataIdFB(fbId, RegHaqKhattaId);
            if (KhatoniesByFb.Rows.Count > 0)
            {
                FillGridviewKhatooni(KhatoniesByFb);
                int khattaid =Convert.ToInt32(KhatoniesByFb.Rows[0]["RegisterHqDKhataId"].ToString());
                cboKhataNo.SelectedValue = khattaid;
                SetKhataDetailsToTextboxes(khattaid.ToString());
                this.txtKhattaId.Text = khattaid.ToString();
            }

            #region Set Khata Details to Text boxes
            
            
            #endregion

            //Load Fard Bader Afrad details 
       


        }

        #endregion

        private void SetKhataDetailsToTextboxes(string khataid)
        {
            foreach (DataRow row in khattasByMoza.Rows)
            {
                if (row["RegisterHqDKhataId"].ToString() == khataid)
                {
                    this.txtKhatatNo.Text = row["KhataNo"].ToString();
                    this.txtKulHisay.Text = row["TotalParts"].ToString();
                    this.txtKanal.Text = row["kanal"].ToString();
                    this.txtMarla.Text = row["Marla"].ToString();
                    this.txtSarsai.Text = row["Sarsai"].ToString();
                    this.txtMalia.Text = row["Malia"].ToString();
                    this.txtKafyat.Text = row["Kyfiat"].ToString();
                }
            }
        }

        #region Fill Gridview of Malkan / Khatooni / khassra from Data Set

        private void FillGridviewMalkan(DataTable dtMalkan)
        {
            if (dtMalkan != null)
            {
                this.GridViewKhewatMalikaan.DataSource = dtMalkan;
                this.GridViewKhewatMalikaan.Columns["KhewatGroupFareeqId"].Visible = false;
                if (this.GridViewKhewatMalikaan.Columns.Contains("RegisterHqDKhataId"))
                {
                    this.GridViewKhewatMalikaan.Columns["RegisterHqDKhataId"].Visible = false;
                }
                this.GridViewKhewatMalikaan.Columns["KhewatGroupId"].Visible = false;
                this.GridViewKhewatMalikaan.Columns["PersonId"].Visible = false;
                if (this.GridViewKhewatMalikaan.Columns.Contains("KhewatTypeId"))
                {
                    this.GridViewKhewatMalikaan.Columns["KhewatTypeId"].Visible = false;
                }
                if (this.GridViewKhewatMalikaan.Columns.Contains("FB_Exists"))
                {
                    this.GridViewKhewatMalikaan.Columns["FB_Exists"].Visible = false;
                }
                this.GridViewKhewatMalikaan.Columns["FardPart_Bata"].Visible = false;
                this.GridViewKhewatMalikaan.Columns["CNIC"].Visible = false;

                ////// Set Grid columns Names ///////////

                this.GridViewKhewatMalikaan.Columns["PersonName"].HeaderText = "نام مالک";
                this.GridViewKhewatMalikaan.Columns["FardAreaPart"].HeaderText = "حصہ";
                this.GridViewKhewatMalikaan.Columns["Khewat_Area"].HeaderText = "رقبہ";
                this.GridViewKhewatMalikaan.Columns["KhewatType"].HeaderText = "قسم مالک";
                this.GridViewKhewatMalikaan.Columns["seqno"].HeaderText = "نمبر شمار";
            }
        }

        private void FillGridviewKhatooni(DataTable dtKhatooni)
        {
            if (dtKhatooni != null)
            {
                this.GridViewKhatoniList.DataSource = dtKhatooni;
                this.GridViewKhatoniList.Columns["KhatooniId"].Visible = false;
                this.GridViewKhatoniList.Columns["RegisterHqDKhataId"].Visible = false;
                this.GridViewKhatoniList.Columns["FB_Exists"].Visible = false;

                ////// Set Grid columns Names ///////////

                this.GridViewKhatoniList.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                this.GridViewKhatoniList.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "تفصیل حصہ داران، مشتریان و کاشتکاران";
                this.GridViewKhatoniList.Columns["KhatooniLagan"].HeaderText = "لگان";
                this.GridViewKhatoniList.Columns["Wasail_e_Abpashi"].HeaderText = "وسائل ابپاشی";
            }
        }

        private void FillGridviewKhassrasByKhatooni(DataTable dtKhassra)
        {
            if (dtKhassra != null)
            {
                this.gridViewKhassraAreaDetails.DataSource = dtKhassra;
                this.gridViewKhassraAreaDetails.Columns["KhatooniId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["KhassraId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["KhassraDetailId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["AreaTypeId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["FB_Exists"].Visible = false;

                ////// Set Grid columns Names ///////////

                this.gridViewKhassraAreaDetails.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                this.gridViewKhassraAreaDetails.Columns["AreaType"].HeaderText = "قسم اراضی";
                this.gridViewKhassraAreaDetails.Columns["Kanal"].HeaderText = "کنال";
                this.gridViewKhassraAreaDetails.Columns["Marla"].HeaderText = "مرلہ";
                this.gridViewKhassraAreaDetails.Columns["Sarsai"].HeaderText = "سرسائی";
                this.gridViewKhassraAreaDetails.Columns["Feet"].HeaderText = "مربع فٹ";
            }
        }

        #endregion

        #region Fill Malkan Type (Qism Malkiat Drop Down)
        /// <summary>
        /// Fills the drop down of Mailkan types, ie asal malik, malik-e-qabza etc.
        /// </summary>

        private void FillMalikanTypeDropDown()
        {
            this.khewatTypes = misalBL .GetKhewatTypes(UsersManagments._Tehsilid);
            DataRow row = khewatTypes.NewRow();
            row["KhewatTypeId"] = 0;
            row["KhewatType"] = "- قسم مالک چنِے  -";
            khewatTypes.Rows.Add(row);
            this.cboQismMalik.DataSource = khewatTypes;
            this.cboQismMalik.DisplayMember = "KhewatType";
            this.cboQismMalik.ValueMember = "KhewatTypeId";
            this.cboQismMalik.SelectedValue = 0;
        }
        #endregion

        #region Method filling qoam combobox

        /// <summary>
        /// Fills qoam drop down for family head
        /// </summary>
        private void FillQoamCombo()
        {
            cbQoam.DataSource = misalBL.GetQoamList(); // Fill Head Qoam List
            cbQoam.DisplayMember = "Qoam";
            cbQoam.ValueMember = "QoamId";
            cbQoam.SelectedIndex = -1;
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

                int mozaid = Convert.ToInt32(cmbMouza.SelectedValue);
                if (mozaid != 0)
                {
                    this.khattasByMoza = misalBL.GetKhatajatByMoza(mozaid);
                    DataRow row = khattasByMoza.NewRow() ;
                    row["RegisterHqDKhataId"] = 0;
                    row["KhataNo"] = "- کھاتہ چنِے -";
                    this.khattasByMoza.Rows.InsertAt(row,0);
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = this.khattasByMoza;
                    this.cboKhataNo.DataSource = this.khattasByMoza;
                    this.cboKhataNo.DisplayMember = "KhataNo";
                    this.cboKhataNo.ValueMember = "RegisterHqDKhataId";
                    this.cboKhataNo.SelectedIndex = 0;
                }
                else
                {
                    this.cboKhataNo.DataSource = null;
                    this.khattasByMoza = null;
                    //this.GetKhatoniGroupTafseelBindingSource.DataSource = null;
                    //GetKhewatMaalikanBindingSource.DataSource = null;
                    ClearKhataControls();
                    ClearKhataControls();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Fill Area Type combo for khassra insert update.

        private void fillAreaType()
        {
            this.AreaTypes = misalBL.GetAreaTypesList();
            DataRow row = AreaTypes.NewRow();
            row["AreaType"] = " - قسم اراضی چنیے - ";
            row["AreaTypeId"] = 0;
            this.AreaTypes.Rows.Add(row);
            cboAreaType.DataSource = AreaTypes;
            cboAreaType.DisplayMember = "AreaType";
            cboAreaType.ValueMember = "AreaTypeId";
            cboAreaType.SelectedValue = 0;

        }

        #endregion

        #region Search for Persons
        /// <summary>
        /// Make Search for a specific person by Name and type-Malik, Kashtkar.
        /// </summary>
        /// <param name="typeid">Type ID, 1 for malik, 2 for kashtkar</param>
        private void FindPerson(int typeid)
        {
            string mozaid =cmbMouza.SelectedValue.ToString(); //Convert.ToInt32(this.cbMoza.SelectedValue.ToString());

            frmSearchPerson serch = new frmSearchPerson();
            serch.MozaId = mozaid;
            serch.FormClosed -= new FormClosedEventHandler(serch_FormClosed);
            serch.FormClosed += new FormClosedEventHandler(serch_FormClosed);
            serch.ShowDialog();

        }
        #endregion

        #region Search Person form closed event
        /// <summary>
        /// form closed event of Search person form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void serch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson p = sender as frmSearchPerson;
                this.txtPersonName.Text = p.PersonName;
                this.txtPersonId.Text = p.PersonId.ToString();
        }

        #endregion

        #region Text Field Malik Name Double click event
        /// <summary>
        /// Text Field Malik Name Double click event, calling Malik Searching form to open
        /// </summary>
        /// <param name="sender">Button as Sender</param>
        /// <param name="e">Event Args</param>

        private void txtMalik_DoubleClick(object sender, EventArgs e)
        {
            FindPerson(1);
        }

        #endregion

        #region Khatoni Related Functions

        #region Function Save Khatoni Main Entry
        /// <summary>
        /// Saves khatoni number, wasial Abpashi etc.
        /// </summary>
        private void SaveKhatoniRegister()
        {
            if (txtKhatoniNo.Text.Trim() != "")
            {
                try
                {
                    int khatoniid = Convert.ToInt32(this.txtKhatoniId.Text!=""?this.txtKhatoniId.Text:"-1");
                    string khatonino = this.txtKhatoniNo.Text;
                    int khatonikhataid = Convert.ToInt32(this.cboKhataNo.SelectedValue);
                    string wasailabpashi = this.txtKhatoniWasailAbpashi.Text;
                    string lagaan = this.txtKhatoniLagaan.Text;
                    string kashtkaranTafseel = this.txtKhatoniKashtkaranTafseel.Text;

                    long FbId = long.Parse(txtFbId.Text);
                    long FbKhatoniId = long.Parse("-1");
                    string fbExistsKhatoni = txtFbExistsKhatoni.Text;
                    if (fbExistsKhatoni != "1")
                    {
                        FbKhatoniId = long.Parse("-1"); // For inserting of new record.
                    }
                    else
                    {
                        FbKhatoniId = long.Parse("-2"); // for updation of existing record
                    }
                    //string s = client.SaveKhatoniRegister(khatoniid, khatonino, kashtkaranTafseel, khatonikhataid, wasailabpashi, lagaan, CurrentUser.UserId, CurrentUser.UserName).ToString();
                    string s = misalBL.SaveFBKhatoniRegister(FbKhatoniId, FbId, khatoniid, khatonino, khatonikhataid, kashtkaranTafseel, wasailabpashi, lagaan, UsersManagments.UserId, DateTime.Now, UsersManagments.UserName); 
                    this.txtKhatoniId.Text = s;
                    FillKhatoniListbyKhattaId();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region Function Fill Khatoni List By Khatta Id
        /// <summary>
        /// Fills khatoni record of specific khata by Khata Id into gridview khatoni Register.
        /// </summary>
        private void FillKhatoniListbyKhattaId()
        {
            int khataid = Convert.ToInt32(this.txtKhattaId.Text!=""?txtKhattaId.Text:"0");
            this.txtKhatoniKhataId.Text = khataid.ToString();
            this.khatoniByKhata = misalBL.GetKhatonisByKhataId(khataid);
            DataRow khatoniSelect = khatoniByKhata.NewRow();
            khatoniSelect["KhatooniId"] = 0;
            khatoniSelect["KhatooniNo"] = "- کھتونی چنِے -";
            this.khatoniByKhata.Rows.InsertAt(khatoniSelect,0);
            cboKhatoni.DataSource = this.khatoniByKhata;
            cboKhatoni.ValueMember = "KhatooniId";
            cboKhatoni.DisplayMember = "KhatooniNo";
            this.splitContainerKhatoni.Panel2.Enabled = false;
            //this.btnModifyKhatoni.Enabled = false;
            this.GridViewKhatoniList.Columns[0].Visible = false; //Set Khatoni ID column visible false

        }
        #endregion

        #region Function Fills Khatoni Khasra gridview
        /// <summary>
        ///Fills Khatoni Khasra gridview for a specific khatoni using khatoni id.
        /// </summary>

        private void FillKhatoniKhassraList()
        {
            string khatoniid = this.txtKhatoniId.Text.ToString();
            this.KhatooniKhassrasAreaDetails = null;
            this.KhatooniKhassrasAreaDetails = misalBL.GetKhatoniKhassraAreaDetail(khatoniid);
        }

        #endregion

        #region Function, filling khatoni controls from gridview
        /// <summary>
        /// fills khatoni controls from gridview/ List
        /// </summary>
        /// <param name="sender"></param>

        private void FillKhatoniGroupControls(object sender)
        {
            try
            {
                //DataGridView g = sender as DataGridView;
                ComboBox g = sender as ComboBox;
                int khatoniId = Convert.ToInt32(g.SelectedValue);
                if (khatoniId != 0)
                {
                    DataRow CurrentKhatoni = khatoniByKhata.NewRow();
                    foreach (DataRow row in khatoniByKhata.Rows)
                    {
                        if (row["KhatooniId"].ToString() == khatoniId.ToString())
                        {
                            CurrentKhatoni = row;
                        }
                    }
                    this.txtKhatoniNo.Text = CurrentKhatoni["KhatooniNo"].ToString(); //g.SelectedRows[0].Cells[0].Value.ToString();
                    this.txtKhatoniLagaan.Text = CurrentKhatoni["KhatooniLagan"].ToString(); //g.SelectedRows[0].Cells[1].Value.ToString();
                    this.txtKhatoniId.Text = CurrentKhatoni["KhatooniId"].ToString(); //g.SelectedRows[0].Cells[2].Value.ToString();
                    this.txtKhatoniKhataId.Text = CurrentKhatoni["RegisterHqDKhataId"].ToString(); //g.SelectedRows[0].Cells[3].Value.ToString();
                    this.txtKhatoniWasailAbpashi.Text = CurrentKhatoni["Wasail_e_Abpashi"].ToString(); //g.SelectedRows[0].Cells[4].Value.ToString();
                    splitContainerKhatoni.Panel2.Enabled = true;
                    btnModifyKhatoni.Enabled = true;
                }
                else
                {
                    ClearkhatoniControls();
                    splitContainerKhatoni.Panel2.Enabled = false;
                    btnModifyKhatoni.Enabled = false;

                }
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        #endregion

        #endregion

        #endregion

        #region Clear Form
        //Reset Form controls and clear all values 
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

        #region Action Buttons click Events

        private void btnNewKhata_Click(object sender, EventArgs e)
        {
            this.txtKhattaId.Text = "-1";
            this.txtFbKhataId.Text = "-1";
            this.ClearFormControls(gbBabat);
            this.ClearFormControls(gbKhataMain);
            this.ClearFormControls(gbKhataRaqba);
            this.txtKhatatNo.Focus();
           
        }


        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            if (isExistsKhatta() && txtKhattaId.Text.Trim() == "-1")
            {
                MessageBox.Show("اپکا نیا محفوظ ہونے والا کھاتہ پہلے سے موجود ہیں");
            }
            else
            {
                SaveKhata();
            }
        }


        private void btnDelKhatta_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی خسرہ ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    int khattaId = Convert.ToInt32(txtFbKhataId.Text);
                    string fbId = txtFbId.Text;
                    if (khattaId != 0)
                    {
                        misalBL.DeleteFbKhatta(fbId, khattaId);
                        //ClearFormControls(gbKhataMain);
                        this.FillKhataJaatByMoza();
                        ClearFormControls(gbKhataRaqba);
                        ClearFormControls(gbBabat);
                        this.loadFbData(fbId);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Form Load Event

        private void frmMisalMain_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            FillMalikanTypeDropDown();
            this.AreaTypesList = misalBL.GetAreaTypesList();
            this.FillKhataJaatByMoza();
            fillAreaType();
            this.FillQoamCombo();
            this.FillMisalMian();
            txtFbId.Text = "-1";
        }

        #endregion

        #region Get Misal Main by Moza Id

        private void FillMisalMian()
        {
            try
            {

            this.MisalMainListByMozaId = misalBL.GetFardBaderListByMozaId(cmbMouza.SelectedValue.ToString());
            DataRow MisalSelect = MisalMainListByMozaId.NewRow();
            MisalSelect["FB_Id"] = "0";
            MisalSelect["FB_DocumentNo"] = "- مثل کا انتخاب کریں -";
            MisalMainListByMozaId.Rows.InsertAt(MisalSelect,0);
            cbFBDocuments.DataSource = MisalMainListByMozaId;
            cbFBDocuments.DisplayMember = "FB_DocumentNo";
            cbFBDocuments.ValueMember = "FB_Id";
            cbFBDocuments.SelectedValue = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region KhewatgroupFareeq Save button click event

        private void btnPersonSave_Click(object sender, EventArgs e)
        {
         if (txtPersonId.Text != "-1" && txtPersonId.Text != "")
            {
                string  fbId =txtFbId.Text != "" ? txtFbId.Text : "0";
                string fbExistsKGF = txtFbExistsKGF.Text;
                   if (saveMalikNew())
                        {
                            //this.GetKhewatMaalikanBindingSource.DataSource = client.GetKhewatMalikanByKhataId(Convert.ToInt32(cboKhataNo.SelectedValue)).ToList();
                            // this.txtPersonName.Focus();
                            
                            this.khewatMalikanByFB = misalBL.GetKhewatFarqeenGroupByKhatId_Misal(fbId,cboKhataNo.SelectedValue.ToString());
                            this.FillGridviewMalkan(khewatMalikanByFB);
                            this.txtKhewatFreeqainGroupId.Text = "-1";
                            this.txtKhewatGroupId.Text = "0";
                           // this.ClearFormControls(groupBox1);
                            this.btnSearchPerson.Focus();
                            //this.btnDeleteMalik.Enabled = false;
                            //this.txtSeqNo.Enabled = false;
                            int idx = this.GridViewKhewatMalikaan.Rows.Count;
                            this.txtSeqNo.Text = (idx + 1).ToString();
                        }
              
            }
        }
        		 
	#endregion

        #region Save malik entry

        private float calculateNetPart()
        {
            float NetPart = 0;
            try
            {
                if (txtPersonNetHissa.Text.Trim().Contains('/'))
                {
                    string[] parts = txtPersonNetHissa.Text.Trim().Split('/');

                    if (parts.Count() == 2)
                    {
                        int d = Convert.ToInt32(parts[1]);
                        if (d != 0)
                        {
                            float num = float.Parse(parts[0]);
                            float den = float.Parse(parts[1]);
                            NetPart = (float)(Math.Round((Decimal)(num / den), 3, MidpointRounding.AwayFromZero));
                        }
                        else
                            NetPart = 0;
                    }
                    else
                    {
                        NetPart = 0;
                    }
                }
                else
                {
                    NetPart = float.Parse(txtPersonNetHissa.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return NetPart;
        }

        private bool saveMalikNew()
        {
            bool isSaved = false;
            int KhattaId = Convert.ToInt32(cboKhataNo.SelectedValue);
            string pid = txtPersonId.Text.Trim() != "" ? txtPersonId.Text : "0";
            string pName = txtPersonName.Text.Trim();
            string kgf_id = txtKhewatFreeqainGroupId.Text != "" ? txtKhewatFreeqainGroupId.Text : "-1";
            string kg_id = txtKhewatGroupId.Text != "" ?txtKhewatGroupId.Text : "0";
            int kh_id = txtKhewatKhataId.Text != "" ? Convert.ToInt32(txtKhewatKhataId.Text) : 0;
            string fardParts = txtPersonNetHissa.Text.Trim(); //txtPersonNetHissa.Text.Trim() != "" ? Convert.ToInt32(txtPersonNetHissa.Text.Trim()) : 0;
            int kanal = txtPersonKanal.Text.Trim() != "" ? Convert.ToInt32(txtPersonKanal.Text.Trim()) : 0;
            int marla = txtPersonMarla.Text.Trim() != "" ? Convert.ToInt32(txtPersonMarla.Text.Trim()) : 0;
            float sarsai = txtPersonSarsai.Text.Trim() != "" ? float.Parse(txtPersonSarsai.Text.Trim()) : 0;
            float sft = txtPersonFeet.Text.Trim() != "" ? float.Parse(txtPersonFeet.Text.Trim()) : 0;
            int khewatTypeId = Convert.ToInt32(cboQismMalik.SelectedValue);

            string netPart = this.calculateNetPart().ToString();
            long FbId = long.Parse(txtFbId.Text);
            long FbFareeqId = long.Parse("-1");
            string fbExistsKGF = txtFbExistsKGF.Text;
            if (fbExistsKGF != "1")
            {
                FbFareeqId = long.Parse("-1"); // for insertion of new record
            }
            else
            {
                FbFareeqId = long.Parse("-2"); // for updating existing record
            }
            int sqNo = Convert.ToInt32(txtSeqNo.Text!=""?txtSeqNo.Text:"1");
            if (pid != "0" && khewatTypeId != 0 && KhattaId!=0)
            {
                try
                {
                   // string s = client.SaveKhewatGrouFreeqein(kgf_id, kg_id, pid, netPart, kanal, marla, sarsai, sft, khewatTypeId, kh_id, CurrentUser.UserId, darNo, totalDarParts, personParts, ofDarPart, CurrentUser.UserName, txtPersonNetHissa.Text.Trim());
                    string s = misalBL.SaveFBKhewatGroupFarqeen(FbFareeqId,FbId, kgf_id, kg_id, "Misal", "0", sqNo, pid, khewatTypeId, netPart, kanal, marla, sarsai, sft, UsersManagments.UserId, UsersManagments.UserName, 0, txtPersonNetHissa.Text.Trim(), KhattaId); 
                    if (s != "")
                    {
                        //lblMessageMalik.Text = "ریکارڈ محفوظ ہو گیا";
                        //lblMessageMalik.ForeColor = Color.Green;
                        isSaved = true;
                    }
                    else
                    {
                        MessageBox.Show("ریکارڈ محفوظ نہیں ہو سکا");
                        //lblMessageMalik.ForeColor = Color.Red;
                        isSaved = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //lblMessageMalik.ForeColor = Color.Red;
                }

            }
            else
            {
                MessageBox.Show("ریکارڈ محفوظ نہیں ہو سکا۔ مالک کے کوائف کا پڑتال کر کے دوبارہ کوشش کریں");
                //lblMessageMalik.ForeColor = Color.Red;
                isSaved = false;
            }

            return isSaved;
        }

        #endregion

        #region Khewat Group Fareeq Delete Button Click Event

        private void btnDeleteMalik_Click(object sender, EventArgs e)
        {
            
            if (txtKhewatFreeqainGroupId.Text != "-1")
            {
                string fbId = txtFbId.Text != "" ? txtFbId.Text : "0";
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    string fbExists = txtFbExistsKGF.Text;
                    if (fbExists == "1")
                    {
                        misalBL.DeleteFbKhewatGroupFareeq(fbId, txtKhewatFreeqainGroupId.Text);
                        this.khewatMalikanByFB = misalBL.GetKhewatFarqeenGroupByKhatId_Misal(fbId, cboKhataNo.SelectedValue.ToString());
                        this.FillGridviewMalkan(khewatMalikanByFB);
                        //this.GetKhewatFareeqeinGroupByKhataFBBindingSource.DataSource = client.GetKhewatGroupFarqeenByKhattaFB(fbId).ToList();
                        this.ClearFormControls(gbKhewatGroupFareeq);
                        this.btnSearchPerson.Focus();
                        this.txtKhewatFreeqainGroupId.Text = "-1";
                        this.txtSeqNo.Enabled = false;
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("انتخاب کردہ مالک کا ریکارڈ رجسٹر حقداران زمین سے مکمل خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            misalBL.DeleteKhewatGroupFard(txtKhewatFreeqainGroupId.Text);
                            //this.GetKhewatFareeqeinGroupByKhataFBBindingSource.DataSource = client.GetKhewatGroupFarqeenByKhattaFB(fbId).ToList();
                            //this.ClearFormControls(groupBox1);
                            this.btnSearchPerson.Focus();
                            this.txtKhewatFreeqainGroupId.Text = "-1";
                            this.txtSeqNo.Enabled = false;
                            this.khewatMalikanByFB = misalBL.GetKhewatFarqeenGroupByKhatId_Misal(fbId, cboKhataNo.SelectedValue.ToString());
                            this.FillGridviewMalkan(khewatMalikanByFB);
                        }
                       // MessageBox.Show("اپکا مطلوبہ ریکارڈ فرد بدر میں نہیں ہے- لہذا خزف نہں ہو سکتا ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("خذف کرنے سے پہلے گریڈ میں مالک چنیے", "کوئی مالک نہیں چنا گیا");
        }
        
    
	    #endregion

        #region Search Person Button Click Event

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            this.FindPerson(1);
        }

        #endregion

        #region Save Khatoni Click event
        /// <summary>
        /// Save Khatoni Button Click event, calling save method for khatoni record and also check if khatoni already exists. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveKhatoni_Click(object sender, EventArgs e)
        {
           
                if (txtKhatoniNo.Text.Trim() != "")
                {
                    SaveKhatoniRegister();
                    //tableLayoutPanel2.Enabled = false;
                    FillKhatoniListbyKhattaId();
                    this.cboKhatoni.Enabled = true;
                    txtKhatoniId.Text = "-1";
                    txtKhatoniNo.Clear();
                    txtKhatoniWasailAbpashi.Clear();
                    txtKhatoniLagaan.Clear();
                    txtKhatoniKashtkaranTafseel.Clear();
                    txtKhatoniNo.Focus();
                    this.ClearFormControls(gBKhatoniControls);
                    this.GetKhatoonisFB = misalBL.GetKhatonisByKhataIdFB(txtFbId.Text, Convert.ToInt32(cboKhataNo.SelectedValue));
                    FillGridviewKhatooni(GetKhatoonisFB);
                }
                else
                    MessageBox.Show("کھتونی نمبر خالی ہے");

            

        }
        #endregion

        #region Khatooni Delete Button Click Event

        private void btnDeleteKhatoni_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی کھتونی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                string fbId = txtFbId.Text != "" ? txtFbId.Text : "0";
                int khattaID=Convert.ToInt32(cboKhataNo.SelectedValue!=null?cboKhataNo.SelectedValue:0);
                this.KhatooniKhassrasAreaDetails = misalBL.GetKhatoniKhassraAreaDetail(txtKhatoniId.Text);
                if (KhatooniKhassrasAreaDetails.Rows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("اس کھتونی کے ساتھ    " + KhatooniKhassrasAreaDetails.Rows.Count.ToString() + "  خسرہ جات ریکارڈ بھی خذف ہو جائنگے۔ کیا آپ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        string khtId =txtKhatoniId.Text.Trim();
                        misalBL.DeleteKhatoniRegister(fbId, khtId);
                         //= null;
                        GetKhatoonisFB = misalBL.GetKhatonisByKhataIdFB(fbId,khattaID);
                        this.FillGridviewKhatooni(GetKhatoonisFB);
                    }
                }
                else
                {
                    string khatooniId = txtKhatoniId.Text;
                    misalBL.DeleteKhatoniRegister(khatooniId);
                    GetKhatoonisFB = null;
                    GetKhatoonisFB = misalBL.GetKhatonisByKhataIdFB(fbId, khattaID);

                }
            }
        }
        		 
	    #endregion

        #region Khassra Register Save Button Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string khatoniid =cboKhatoni.SelectedValue.ToString();
                long khasraDetailId = long.Parse(txtKhassraDetailId.Text);
                string khasrano = txtKhassraNo.Text;
                int aretype = Convert.ToInt32(cboAreaType.SelectedValue);
                int k = txtKhassraKanal.Text.Trim() != "" ? Convert.ToInt32(txtKhassraKanal.Text.Trim()) : 0;
                int m = txtKhassraMarla.Text.Trim() != "" ? Convert.ToInt32(txtKhassraMarla.Text.Trim()) : 0;
                float s = txtKhassraSarsai.Text.Trim() != "" ? float.Parse(txtKhassraSarsai.Text.Trim()) : 0;
                float f = 0;

                long FbId = long.Parse(txtFbId.Text);
                long FbKhatoniId = long.Parse(cboKhatoni.SelectedValue.ToString());
                if(txtKhassraNo.Text==txtKhassraNoOld.Text) // if changes occur in khassra area detail without changes in khassra no etc...
                {
                    if (txtKhassraNo.Text.Trim().Length>0 && cboAreaType.SelectedValue.ToString().Length>2 && cboKhatoni.SelectedValue.ToString().Length>2)
                    {
                        long FbKhasraDetailId = long.Parse("-1");
                        long FbKhassraId = long.Parse("-1");
                        string fbExists = txtFbExistsKhassra.Text;
                        if (fbExists == "1"){
                            FbKhasraDetailId = long.Parse("-2");  // for update existing record
                            FbKhassraId = long.Parse("-2");
                        }
                        else
                        {
                            FbKhasraDetailId = long.Parse("-1"); // for insertig new record
                            FbKhassraId = long.Parse("-1");
                        }
                   
                        string khasraId= txtKhassraId.Text;
                        //string lastKhassraId = client.SaveFBKhassraRegister(FbKhassraId, FbId, khasraId, CurrentUser.MozaId, 0, txtKhassraNo.Text, DateTime.Now, DateTime.Now, DateTime.Now, "Active", CurrentUser.UserId, CurrentUser.UserName);
                        //string lastId = client.saveKhassraRegisterDirect(khasraDetailId, CurrentUser.MozaId, khatoniid, khasrano, aretype, k, m, s, f, CurrentUser.UserId, CurrentUser.UserName);
                        string lastId = misalBL.SaveFBKhassraRegisterDetails(FbKhasraDetailId.ToString(), FbId.ToString(), khasraDetailId.ToString(),khatoniid,txtKhassraNo.Text.Trim(), aretype.ToString(), k.ToString(), m.ToString(), s.ToString(), f.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "Fard_e_Bader");
                        if (lastId != "-1")
                        {
                            this.txtKhassraNo.ReadOnly = false;
                            this.txtKhassraNoOld.Text="0";
                            this.btnKhassraDelete.Enabled = false;
                            txtKhassraDetailId.Text = "-1";
                            txtKhassraId.Text = "-1";
                            txtKhassraNo.Clear();
                            cboAreaType.SelectedValue = 0;
                            txtKhassraKanal.Clear();
                            txtKhassraMarla.Clear();
                            txtKhassraSarsai.Clear();
                            txtKhassraNo.Focus();
                            this.KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB( FbId.ToString(), khatoniid);
                            this.calculateKhassrasRaqba();
                            this.GetKhassrasCount();
                        }
                        else
                        {
                            MessageBox.Show("یہ خسرہ پہلے سے موجود ہے");
                        }
                    }
                    else
                        MessageBox.Show("خسرہ نمبر خالی ہے");
                }
                else if (txtKhassraNoOld.Text != txtKhassraNo.Text.Trim())
                {
                    long fbKhasraDetailId = long.Parse(txtKhassraDetailId.Text);
                    string khasraId = txtKhassraId.Text;
                    if (txtKhassraId.Text == "-1" && txtKhassraDetailId.Text == "-1") // if new khassra to be added to RHZ via Fard Bader...
                    {
                        string lastKhassraDetailId = misalBL.saveKhassraRegisterDirect("-1", cmbMouza.SelectedValue.ToString(), Convert.ToInt32(cboKhatoni.SelectedValue), txtKhassraNo.Text.Trim(), aretype, k, m, s, f, UsersManagments.UserId, UsersManagments.UserName);
                        //string lastId = client.SaveFBKhassraRegisterDetails(fbKhasraDetailId, FbId, Convert.ToInt32(txtKhassraDetailId.Text), khatoniid, txtKhassraNo.Text.Trim(), aretype, k, m, s, f, CurrentUser.UserId, CurrentUser.UserName);

                        long lstKhId=0;
                        if (lastKhassraDetailId.Length>5)
                        {
                            this.txtKhassraNo.ReadOnly = false;
                            this.txtKhassraNoOld.Text = "0";
                            this.btnKhassraDelete.Enabled = false;
                            txtKhassraDetailId.Text = "-1";
                            txtKhassraId.Text = "-1";
                            txtKhassraNo.Clear();
                            cboAreaType.SelectedValue = 0;
                            txtKhassraKanal.Clear();
                            txtKhassraMarla.Clear();
                            txtKhassraSarsai.Clear();
                            txtKhassraNo.Focus();
                            this.KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB(FbId.ToString(), Convert.ToInt32(cboKhatoni.SelectedValue));
                            this.calculateKhassrasRaqba();
                            this.GetKhassrasCount();

                        }
                        else
                        {
                            MessageBox.Show(lastKhassraDetailId.ToString());
                        }
                    }
                    else // if khassra no change happens in existing records....  Here Transaction Type must have to send to SP and Table.. for time bieng it is skipped.
                    {
                        string lastId = misalBL.SaveFBKhassraRegister("-1", FbId.ToString(), khasraId, cmbMouza.SelectedValue.ToString(), txtKhassraNo.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName, fbKhasraDetailId.ToString(), khatoniid, aretype.ToString(), k.ToString(), m.ToString(), s.ToString(), f.ToString());
                        if (lastId != "-1")
                        {
                            this.txtKhassraNo.ReadOnly = false;
                            this.txtKhassraNoOld.Text = "0";
                            this.btnKhassraDelete.Enabled = false;
                            txtKhassraDetailId.Text = "-1";
                            txtKhassraId.Text = "-1";
                            txtKhassraNo.Clear();
                            cboAreaType.SelectedValue = 0;
                            txtKhassraKanal.Clear();
                            txtKhassraMarla.Clear();
                            txtKhassraSarsai.Clear();
                            txtKhassraNo.Focus();
                            this.KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB(FbId.ToString(), Convert.ToInt32(cboKhatoni.SelectedValue));
                            this.calculateKhassrasRaqba();
                            this.GetKhassrasCount();

                        }
                    }
                    long FbKhassraId = long.Parse("-1");
                    if (txtFbExistsKhassra.Text == "1")
                    {
                        FbKhassraId = long.Parse("-2");
                    }
                    else
                    {
                        FbKhassraId = long.Parse("-1");
                    }
                    
                    try
                    {
                       // string s = client.SaveFBKhassraRegister(FbKhassraId, FbId, khasraId, CurrentUser.MozaId, 0, txtKhassraNo.Text, DateTime.Now, DateTime.Now, DateTime.Now, "Active", CurrentUser.UserId, CurrentUser.UserName);
                    }
                    catch (Exception ex)
                    {
                        //string s2 = client.SaveFBKhassraRegisterDetails(-1, FbId, Convert.ToInt32(txtKhassraDetailId.Text), txtKhassraNo.Text.Trim(), areaType, Kanal, marla, sarsai, feet, CurrentUser.UserId, CurrentUser.UserName);
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        		 
	    #endregion

        #region Calculate total raqba khassrajaat of a khatoni

        private void calculateKhassrasRaqba()
        {
            int kanal = 0;
            int marla = 0;
            int sarsai = 0;
            foreach (DataGridViewRow row in gridViewKhassraAreaDetails.Rows)
            {
                try
                {
                    kanal += row.Cells[6].Value != null ? Convert.ToInt32(row.Cells[6].Value) : 0;
                    marla += row.Cells[7].Value != null ? Convert.ToInt32(row.Cells[7].Value) : 0;
                    sarsai += row.Cells[8].Value != null ? Convert.ToInt32(row.Cells[8].Value) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (sarsai >= 9)
            {
                marla += (sarsai - (sarsai % 9)) / 9;
                sarsai = sarsai % 9;
            }
            if (marla >= 20)
            {
                kanal += (marla - (marla % 20)) / 20;
                marla = marla % 20;
            }
            lblKulRaqbaKhasras.Text = kanal.ToString() + "__" + marla.ToString() + "__" + Convert.ToInt32(sarsai * 30.25).ToString();
        }

        #endregion

        #region Count of Khassras in a Khatoni of a Khewat

        private void GetKhassrasCount()
        {
            try
            {
                string count = misalBL.GetKhatoniKhassraCount(cboKhatoni.SelectedValue.ToString());
                this.lblKulKhasrajaat.Text = count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Khasra Delete Button Event

        private void btnKhassraDelete_Click(object sender, EventArgs e)
        {
             if (DialogResult.Yes == MessageBox.Show("آپ واقعی خسرہ ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                string fbId = txtFbId.Text != "" ? txtFbId.Text : "0";
                string fbExistsKhassra = txtFbExistsKhassra.Text;
                int khatoniId = Convert.ToInt32(cboKhatoni.SelectedValue);
                misalBL.DeleteFbKhassra(fbId,txtKhassraDetailId.Text);
                this.KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB(fbId, khatoniId);
                this.txtKhassraDetailId.Text = "-1";
                this.ClearFormControls(this.gBKhassraContols);
                this.txtKhassraNo.ReadOnly = false;
                this.btnKhassraDelete.Enabled = false;
                this.txtKhassraNo.Focus();
                this.calculateKhassrasRaqba();
                this.GetKhassrasCount();
                this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);
            }
        }
    		 
	    #endregion

        #region Gridview Malkan Click Event

        private void GridViewKhewatMalikaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
	            {	        
		            DataGridView g = sender as DataGridView;
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (GridViewKhewatMalikaan.SelectedRows.Count > 0)
                        {
                            if (row.Selected)
                            {
                                row.Cells["colCheck"].Value = 1;
                                txtKhewatFreeqainGroupId.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                txtKhewatGroupId.Text = row.Cells["KhewatGroupId"].Value.ToString();
                                txtKhewatKhataId.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                cboQismMalik.SelectedValue = row.Cells["KhewatTypeId"].Value.ToString();
                                txtPersonNetHissa.Text = row.Cells["KhewatGroupId"].Value.ToString();
                                txtNetHissa.Text = row.Cells["FardAreaPart"].Value.ToString();
                                txtPersonId.Text = row.Cells["PersonId"].Value.ToString();
                                txtPersonNetHissa.Text = row.Cells["FardPart_Bata"].Value.ToString();
                                txtPersonName.Text = row.Cells["PersonName"].Value.ToString();
                                txtSeqNo.Text = row.Cells["seqno"].Value.ToString();
                                txtFbExistsKGF.Text = row.Cells["FB_Exists"].Value.ToString();
                               
	                        }
                          else
                       {
                          row.Cells["colCheck"].Value = 0;
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

        #region Save Misal
        /// <summary>
        /// Save Fard Badar Entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnSaveFardBadar_Click(object sender, EventArgs e)
        {
               try 
	                {	        
		                string fbId=txtFbId.Text.Trim()!=""?txtFbId.Text.Trim():"-1";
                        string LastId = misalBL.SaveFardBadarMain(fbId, Convert.ToInt32(cmbMouza.SelectedValue.ToString()), txtFardBadarDocNO.Text.Trim(), dtpDateGardawari.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), dtpDateTehsilDar.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtFardBadarTafseel.Text, UsersManagments.UserId, UsersManagments.UserName, 0);
                        txtFbId.Text = LastId;
                        MessageBox.Show("مثل اندراج ہو گیا ہے۔", "");
                        this.txtFardBadarDocNO.Clear();
                        this.dtpDateGardawari.Value = DateTime.Now;
                        this.dtpDateTehsilDar.Value = DateTime.Now;
                        this.txtFardBadarDocNO.Focus();
	                }
	                catch (Exception ex)
	                {
		                MessageBox.Show(ex.Message);
	                }
        }
        		 
	    #endregion

        #region New Misal Button Click Event

        private void btnNewFardBadar_Click(object sender, EventArgs e)
        {
            this.txtFbId.Text = "-1";
            this.txtFardBadarTafseel.Clear();
            this.dtpDateGardawari.Value = DateTime.Now;
            this.dtpDateTehsilDar.Value = DateTime.Now;
            this.txtFardBadarDocNO.Clear();
            this.txtFardBadarDocNO.Focus();
            ClearFardBaderDetails();
            this.btnSaveFardBadar.Enabled = true;
            //this.DisAbleControls();
        }

        private void ClearFardBaderDetails()
        {
            this.khewatMalikanByFB= null;
            this.GetKhatoonisFB= null;
            this.KhatooniKhassrasAreaDetailsFB = null;
            //this.GetMozaFamilyListBindingSource.DataSource = null;
            this.cboKhataNo.SelectedValue = 0;
            this.cboKhatoni.SelectedValue = 0;
            this.ClearFormControls(gbBabat);
            this.ClearFormControls(gbKhataMain);
            this.ClearFormControls(gbKhataRaqba);
            this.ClearFormControls(gBKhassraContols);
            this.ClearFormControls(gBKhatoniControls);
        }
        		 
	#endregion

        #region Search Misal by Misal Number
		 
        private void btnSearchFB_Click(object sender, EventArgs e)
        {
             try
            {
                ClearFardBaderDetails();
                DataTable dtMisalDetails = new DataTable();
                string fbDocNo =txtFardBadarDocNO.Text.Trim() != "" ? txtFardBadarDocNO.Text.Trim() : "0";
                 int mozaId=Convert.ToInt32(cmbMouza.SelectedValue.ToString());
                 this.MouzaId = cmbMouza.SelectedValue.ToString();
                 dtMisalDetails = misalBL.GetFardBaderMainByDocNoSDC(fbDocNo, mozaId);
                if (dtMisalDetails.Rows.Count > 0)
                {
                    dtpDateGardawari.Value = Convert.ToDateTime(dtMisalDetails.Rows[0]["GardawarDate"].ToString());
                    dtpDateTehsilDar.Value =Convert.ToDateTime(dtMisalDetails.Rows[0]["ConfirmationDate"].ToString());
                    txtFardBadarTafseel.Text = dtMisalDetails.Rows[0]["FB_Detail"].ToString();
                    txtFbId.Text = dtMisalDetails.Rows[0]["FB_Id"].ToString();
                    GetMisalImages(txtFbId.Text);
                    this.ConfirmationStatus =Convert.ToBoolean(dtMisalDetails.Rows[0]["ConfirmationStatus"].ToString());
                    this.AmaldaramadStatus = Convert.ToBoolean(dtMisalDetails.Rows[0]["AmaldaramadStatus"].ToString());
                    if (this.ConfirmationStatus)
                    {
                        btnAmaldaramad.Enabled = !AmaldaramadStatus;
                        btnConfirm.Enabled = false;
                        this.DisAbleControls();
                    }
                    else
                    {
                        btnConfirm.Enabled = true;
                    }

                    loadFbData(txtFbId.Text);
                }
                else
                {
                    MessageBox.Show("اپکا مطلوبہ فرد بدر/مثل موجود نہیں", "فرد بدر موجود/مثل نہیں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFbId.Text = "-1";
                    btnConfirm.Enabled = false;
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("یہ فرد بدر/مثل اپکے انتخاب کردہ موضع میں موجود نہیں ہے", "فرد بدر/مثل موجود نہیں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirm.Enabled = false;
            }
        }
      #endregion

        #region Clear Controls of prtions of the form

         private void ClearKhasraDetailControls()
        {
            this.KhassraAreaByKhassraId = null;

        }

        private void ClearKhasrasControls()
        {
            this.KhatooniKhassrasAreaDetails = null;
            txtKhassraGroupId.Text = "-1";
            // txtKhasraNo.Clear();
            txtKhassraGroupId.Clear();
        }

        private void ClearkhatoniControls()
        {
            this.GetKhatoonisFB = null;
            txtKhatoniId.Text = "-1";
            // txtKhatatNo.Clear();
            this.txtKhatoniNo.Clear();
            txtKhatoniLagaan.Clear();
            txtKhatoniWasailAbpashi.Clear();
        }

        private void ClearKhewatControls()
        {
            //this.GetKhewatMaalikanBindingSource.DataSource = null;
            txtMalia.Clear();
            cboQismMalik.SelectedIndex = 0;
            txtPersonNetHissa.Clear();
            txtNetHissa.Clear();
        }

        private void ClearKhataControls()
        {
            this.khattasByMoza = null;
            txtKulHisay.Clear();
            txtKanal.Clear();
            txtMalia.Clear();
            txtMarla.Clear();
            txtKafyat.Clear();
            txtSarsai.Clear();
            txtKhatatNo.Clear();
        }

	    #endregion

        #region Drop Down Moza Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.FillMisalMian();
            DataTable RegisNo=misalBL.GetHaqdaraanRegistersByMoza(Convert.ToInt32(cmbMouza.SelectedValue));
            if(RegisNo.Rows.Count > 0)
            {
                this.registerNo =Convert.ToInt32(RegisNo.Rows[0][0].ToString());
            }

            this.FillKhataJaatByMoza();
        }

        #endregion

        #region Drop Down Khata No selection Change Event

        private void cboKhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboKhataNo.SelectedValue != null)
            {

                this.txtKhattaId.Text = this.cboKhataNo.SelectedValue.ToString();
                foreach (DataRow row in khattasByMoza.Rows)
                {
                    if (row["RegisterHqDKhataId"].ToString() == this.txtKhattaId.Text)
                    {
                        this.txtKhatatNo.Text = row["KhataNo"].ToString();
                        this.txtKulHisay.Text = row["TotalParts"].ToString();
                        this.txtKanal.Text = row["kanal"].ToString();
                        this.txtMarla.Text = row["Marla"].ToString();
                        this.txtSarsai.Text = row["Sarsai"].ToString();
                        this.txtMalia.Text = row["Malia"].ToString();
                        this.txtKafyat.Text = row["Kyfiat"].ToString();
                    }
                }
               // this.ClearFormControls(groupBox1); //Clear Khewat Malikan controls
                this.ClearFormControls(gBKhatoniControls); // Clear Khatoni Controls
                this.ClearFormControls(gBKhassraContols);  // Clear Khassra Controls
                this.ClearFormControls(gbKhewatGroupFareeq);
                ClearkhatoniControls();
                ClearKhasrasControls();
                ClearKhasraDetailControls();
                FillKhewatMalikanByKhataId();
                FillKhatoniListbyKhattaId();
                LoadKhatonies(Convert.ToInt32(txtKhattaId.Text));
                KhataTotalRaqbaByKhataId();
                //----Kathoni----////
                //btnNewKhatoni.Enabled = true;
                //btnModifyKhatoni.Enabled = false;
                //btnSaveKhatoni.Enabled = false;
                //btnCancelKhatoni.Enabled = false;
                //---File --- Controls----- ////

                try
                {
                    KhataHissayDiff();
                }
                catch (Exception ex)
                {

                    // MessageBox.Show(ex.Message.ToString());
                }

                
            }
        }

        #endregion

        #region Function Calculates Khata hissay Difference
        /// <summary>
        /// Calculates the difference between Khata Total Hissay (parts) and Khata Entered (Malikan Assigned Hissay).
        /// </summary>
        /// <returns></returns>
        protected void KhataHissayDiff()
        {
            float diff = 0;
            float khataKulHissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text) : 0;
            float KhataEnteredHissay = textBox1.Text.Trim() != "" ? float.Parse(textBox1.Text) : 0;
            diff = khataKulHissay - KhataEnteredHissay;
            this.txtPartsDiff.Text = diff.ToString();
            if (diff != 0)
            {
                this.panelKataHisayDiff.BackColor = Color.DarkSalmon;
            }
            else
            {
                this.panelKataHisayDiff.BackColor = Color.LightGreen;
            }

        }
        #endregion

        #region Function Get Khata Total Raqba
        /// <summary>
        /// Gets total raqba of a khata/Khewat.
        /// </summary>
        private void KhataTotalRaqbaByKhataId()
        {
            try
            {
                int khataid = Convert.ToInt32(this.txtKhattaId.Text.ToString());
                this.GetTotalRaqba = misalBL.GetTotalAreaByKhattaId(khataid);
                txtFeetTotalRaqba.Text = (textBox4.Text != "" && textBox4.Text != "0") ? (Convert.ToInt32((Convert.ToInt32(textBox4.Text) * 30.25))).ToString() : "0";

            }
            catch (Exception)
            {

                //throw;
            }
        }
        #endregion
        
        #region Fill Khatoni  By Khata Id
        private void LoadKhatonies(int KhattaId)
        {
            try
            {
                // Load Khatoni details if khatoni changed occured in the searched fard bader
                 KhatoniesByFb = misalBL.GetKhatonisByKhataIdFB(txtFbId.Text, KhattaId);
                if (KhatoniesByFb.Rows.Count > 0)
                {
                    this.GetKhatoonisFB = KhatoniesByFb;
                    this.GridViewKhatoniList.Columns[0].Visible = false;
                    this.GridViewKhatoniList.DataSource = GetKhatoonisFB;
                    //int khattaid = KhatoniesByFb.FirstOrDefault().RegisterHqDKhataId.Value;
                    //cboKhataNo.SelectedValue = khattaid;
                    this.txtKhattaId.Text = KhattaId.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Function Fill Khewat Malikan By Khatta Id
        /// <summary>
        /// fills inserted malikaan record of a specific khata into gridview khata malikan
        /// </summary>
        private void FillKhewatMalikanByKhataId()
        {
            try
            {

                this.khewatMalikanByFB = null;
                int khataid = Convert.ToInt32(this.txtKhattaId.Text.ToString());
                this.txtKhewatKhataId.Text = khataid.ToString();
                string fbId = txtFbId.Text != "" ? txtFbId.Text : "0";
             
                this.khewatMalikanByFB= misalBL.GetKhewatFarqeenGroupByKhatId_Misal(this.txtFbId.Text, khataid.ToString());
                FillGridviewMalkan(khewatMalikanByFB);
                int idx = this.GridViewKhewatMalikaan.Rows.Count;
                this.txtSeqNo.Text = (idx + 1).ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Drop Down Misal No selection Change Event

        private void cbFBDocuments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtFardBadarDocNO.Text = cbFBDocuments.Text;
            btnSearchFB_Click(sender, e);
        }

        #endregion

        #region Gridview Cell Formatting Event

        private void GridViewKhewatMalikaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(GridViewKhewatMalikaan.Columns.Contains("FB_Exists"))
            {
                
            foreach (DataGridViewRow Myrow in GridViewKhewatMalikaan.Rows)
            { 
                //Here 2 cell is target value and 1 cell is Volume
                try
                {
                   
                        if (Convert.ToInt32(Myrow.Cells["FB_Exists"].Value) == 1)// Or your condition 
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Red;
                        }
                    
                }
                catch (Exception ex)
                {
                }
                
            }
            }
        }

        #endregion

        #region Txtbox Name Malik Search Key Press Event

        private void txtNameSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Name Malik Search Text Change Event

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridViewKhewatMalikaan.Rows)
            {
                if ((row.Cells["PersonName"].Value != null ? row.Cells["PersonName"].Value.ToString() : "").Contains(txtNameSearch.Text.Trim()))
                {
                    row.Selected = true;
                    GridViewKhewatMalikaan.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        #endregion

        #region Gridview Khatooni List Click Event

        private void GridViewKhatoniList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (GridViewKhatoniList.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colCheckKhatooni"].Value = 1;
                            txtKhatoniId.Text = row.Cells["KhatooniId"].Value.ToString();
                            txtKhatoniNo.Text = row.Cells["KhatooniNo"].Value.ToString();
                           // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                            txtKhatoniKashtkaranTafseel.Text = row.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
                            txtKhatoniLagaan.Text = row.Cells["KhatooniLagan"].Value.ToString();
                            txtKhatoniWasailAbpashi.Text = row.Cells["Wasail_e_Abpashi"].Value.ToString();
                            txtFbExistsKhatoni.Text = row.Cells["FB_Exists"].Value.ToString();

                        }
                        else
                        {
                            row.Cells["colCheckKhatooni"].Value = 0;
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

        #region Gridview Khatooni List cell click Event

        private void GridViewKhatoniList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in GridViewKhatoniList.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToInt32(Myrow.Cells["FB_Exists"].Value) == 1)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        #endregion

        #region Gridview Khatooni List cell click Event
        
        private void cboKhatoni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int khatooniId=Convert.ToInt32(cboKhatoni.SelectedValue);
            KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB(txtFbId.Text, khatooniId);
            this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);
            this.calculateKhassrasRaqba();
            this.GetKhassrasCount();

        }

        #endregion

        #region Gridview Khassra Cell Click Event

        private void gridViewKhassraAreaDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (gridViewKhassraAreaDetails.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colCheckKhassra"].Value = 1;
                            txtKhatooniIdofKhassra.Text = row.Cells["KhatooniId"].Value.ToString();
                            txtKhassraNo.Text = row.Cells["KhassraNo"].Value.ToString();
                            txtKhassraNoOld.Text = row.Cells["KhassraNo"].Value.ToString();
                            txtKhassraId.Text = row.Cells["KhassraId"].Value.ToString();
                            txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
                            // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                            cboAreaType.SelectedValue = row.Cells["AreaTypeId"].Value.ToString();
                            txtKhassraKanal.Text = row.Cells["Kanal"].Value.ToString();
                            txtKhassraMarla.Text = row.Cells["Marla"].Value.ToString();
                            txtKhassraSarsai.Text = row.Cells["Sarsai"].Value.ToString();
                            txtFbExistsKhassra.Text = row.Cells["FB_Exists"].Value.ToString();

                        }
                        else
                        {
                            row.Cells["colCheckKhassra"].Value = 0;
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

        #region Gridview Khassra Area Details Formating

        private void gridViewKhassraAreaDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in gridViewKhassraAreaDetails.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToInt32(Myrow.Cells["FB_Exists"].Value) == 1)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        #endregion

        #region TextBox Person Net Part Leave Event

        private void txtPersonNetHissa_Leave(object sender, EventArgs e)
        {
            this.txtNetHissa.Text = this.calculateNetPart().ToString();
        
        }

        #endregion

        #region Button Confirmation Click event

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فائنل کرنے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز فائنل ہے تو یس کلک کریں۔؟", "Confirmation of Misal/Badar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    string fbId = this.txtFbId.Text;
                    
                    if (fbId != "0" && fbId!="" )
                    {
                        misalBL.UpdateFardBaderMainConfirmationAmaldaramad(fbId, "Confirmation", UsersManagments.UserName, " ");
                        //ClearFormControls(gbKhataMain);
                        this.btnSearchFB_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Method Disabling Misal/Badar Controls after Confirmation

        public void DisAbleControls()
        {
            this.btnSaveFardBadar.Enabled = false;
            this.gbAfradRegisterControls.Enabled = false;
            this.gBKhassraContols.Enabled = false;
            this.gbKhattaControls.Enabled = false;
            this.gbKhewatGroupFareeq.Enabled = false;
            this.gBKhatoniControls.Enabled = false;
        }

        #endregion
        
        #region Misal Badar Amaldaramad

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFbId.Text.Trim() != "")
                {
                    frmMisalBadarAttestationByAdmin misalAttestation = new frmMisalBadarAttestationByAdmin();
                    misalAttestation.FB_Id = txtFbId.Text;
                    misalAttestation.FormClosed -= new FormClosedEventHandler(misalAttestation_FormClosed);
                    misalAttestation.FormClosed += new FormClosedEventHandler(misalAttestation_FormClosed);
                    misalAttestation.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void misalAttestation_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnSearchFB_Click(sender, e);
        }

        #endregion

        #region Print Misal badar Report
    
        private void btnPrintMisalBadar_Click(object sender, EventArgs e)
        {
            int MozaId = Convert.ToInt32(cmbMouza.SelectedValue);
            frmSDCReportingMain rptMain = new frmSDCReportingMain();
            rptMain.FbID = txtFbId.Text;
            rptMain.MozaId = MozaId.ToString();
            UsersManagments.check = 9;
            rptMain.ShowDialog();
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int mozaId = Convert.ToInt32(cmbMouza.SelectedValue.ToString());
            //misalBL.
        }

        private void btnAttachMisalDocs_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;";
                    dlg.Multiselect = true;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        grdScanedDocStatus.Rows.Clear();
                        list.Clear();
                        string tempFolder = System.IO.Path.GetTempPath();
                        foreach (string fileName in dlg.FileNames)
                        {

                            list.Add(fileName);
                        }

                        int last = list.Count;
                        if (last != null)
                        {

                        }
                        for (int i = 0; i <= last - 1; i++)
                        {
                            string filepath = list[i].ToString();
                            grdScanedDocStatus.Rows.Add();

                            this.grdScanedDocStatus.Rows[i].Cells["ImageId"].Value = "-1";
                            this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = list[i].ToString();

                            byte[] image = System.IO.File.ReadAllBytes(filepath);
                            MemoryStream stream = new MemoryStream(image);
                            try
                            {
                                Image img = Image.FromStream(stream);


                                ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;
                            }
                            catch (Exception ex)
                            {
                                this.grdScanedDocStatus.Rows[i].Cells["Image_Pic_DB"].Value = image;

                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;

                            }

                        }


                    }


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #region GetImages from Database
        public void GetMisalImages(string MisalId)
        {
            try
            {
                //((DataGridViewImageColumn)this.grdScanedDocStatus.Columns["PictureLoad"]).DefaultCellStyle.NullValue = null;
                DataTable RetriveImages = new DataTable();

                RetriveImages = Iq.GetMisalIamges(MisalId);

                if (RetriveImages != null)
                {


                    grdMisalScanDocs.Rows.Clear();
                    list.Clear();
                    int Total_Records = RetriveImages.Rows.Count;
                    for (int i = 0; i <= Total_Records - 1; i++)
                    {
                        grdMisalScanDocs.Rows.Add();
                        grdMisalScanDocs.Rows[i].Height = 70;

                    }
                    int count = 0;
                    foreach (DataRow row in RetriveImages.Rows)
                    {


                        byte[] doc = (byte[])row["Picture"];
                        try
                        {
                            MemoryStream stream = new MemoryStream(doc);
                            Image RetrunImgae = Image.FromStream(stream);
                            list.Add(RetrunImgae);
                            RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                            this.grdMisalScanDocs.Rows[count].Cells["Picture"].Value = RetrunImgae;


                        }
                        catch (Exception ex)
                        {

                            list.Add(doc);
                            Image RetrunImgae = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                            this.grdMisalScanDocs.Rows[count].Cells["Picture"].Value = RetrunImgae;
                        }
                        this.grdMisalScanDocs.Rows[count].Cells["PageNos"].Value = row["PageNos"];
                        this.grdMisalScanDocs.Rows[count].Cells["SNo"].Value = row["SNo"];

                        this.grdMisalScanDocs.Rows[count].Cells["InsertDate"].Value = row["InsertDate"];

                        this.grdMisalScanDocs.Rows[count].Cells["GetImageId"].Value = row["ImageId"];

                        count++;
                    }

                    //grdScanedDocStatus_Formats();
                }
                else
                {
                    // btnNewDoc.Enabled = false;
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region Get Stream from Image File

        /// <summary>
        /// Gets the image at the specified path, shrinks it, converts to JPG, and returns as a stream
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private Stream GetImageStream(string imagePath)
        {
            var ms = new MemoryStream();
            using (var img = Image.FromFile(imagePath))
            {
                var jpegCodec = ImageCodecInfo.GetImageEncoders()
                    .Where(x => x.MimeType == "image/jpeg")
                    .FirstOrDefault();

                var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)20);

                int dpi = 175;
                var thumb = img.GetThumbnailImage((int)(11.692 * dpi), (int)(8.267 * dpi), null, IntPtr.Zero);
                thumb.Save(ms, jpegCodec, encoderParams);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        #endregion

        private void btnSaveMisalDocs_Click(object sender, EventArgs e)
        {
            if (txtFbId.Text=="-1")
            {
                MessageBox.Show("مثل سیلیکٹ کریں", "دستاویزات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (grdScanedDocStatus.Rows.Count == 0)
            {
                MessageBox.Show("دستاویزات سیلیکٹ کریں", "دستاویزات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(" کیا آپ دستاویزات محفوظ کرنا چاہتے ہیں:::::", "دستاویزات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                try
                {


                    string PageNos = "";

                    string ImageId = "-1";

                    using (var ms = new MemoryStream())
                    {
                        var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 0, 0, 0, 0);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                        document.Open();
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {

                            PageNos = this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value.ToString();

                            string path = "";

                            if (grdScanedDocStatus.Rows[i].Cells["source"].Value != null)
                            {
                                path = grdScanedDocStatus.Rows[i].Cells["source"].Value.ToString();

                                var imgStream = GetImageStream(path);
                                var image = iTextSharp.text.Image.GetInstance(imgStream);
                                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                document.Add(image);

                            }


                            //ImageId = grdScanedDocStatus.Rows[i].Cells["ImageId"].Value.ToString();


                        }
                        document.Close();
                        byte[] array = ms.ToArray();

                        string picId = "-1";
                        picId = Iq.SaveMisalImages(ImageId, this.MouzaId.ToString(), txtFbId.Text, array, PageNos, UsersManagments.UserId.ToString(), UsersManagments.UserName);





                         if (picId != "-1")
                         {
                             grdScanedDocStatus.Rows.Clear();
                             MessageBox.Show("دستاویزات منسلک ہو گئے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             GetMisalImages(txtFbId.Text);
                             
                         }
                         else
                         {
                             MessageBox.Show("دستاویزات منسلک نہیں ہوسکے", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void grdMisalScanDocs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        void p_Exited(object sender, EventArgs e)
        {
            string fName = "IntImgDoc";
            try
            {
                File.Delete(ToSaveFileTo);
                int count = 0;
                while (File.Exists(fName + ".pdf"))
                {
                    File.Delete(fName + ".pdf");
                    fName = fName + count.ToString();
                    count++;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void grdMisalScanDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {





                if (e.ColumnIndex == this.grdMisalScanDocs.CurrentRow.Cells["Picture"].ColumnIndex)
                {
                    string ImageId = grdMisalScanDocs.CurrentRow.Cells["GetImageId"].Value.ToString();
                    ToSaveFileTo = "IntImgDoc";
                    DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Misal_ImagesByImageId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + ImageId + "'");
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            byte[] fileData = (byte[])dr["Image"];
                            this.ReceivedImage = fileData;
                        }
                    }
                    try
                    {

                        int Fileno = 0;
                        while (File.Exists(ToSaveFileTo + ".pdf"))
                        {
                            ToSaveFileTo = ToSaveFileTo + Fileno.ToString();
                            Fileno++;
                        }

                        ToSaveFileTo = ToSaveFileTo + ".pdf";
                        using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {

                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {

                                bw.Write(this.ReceivedImage);

                                bw.Close();

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Process p = new Process();
                    p.StartInfo.FileName = ToSaveFileTo;
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(p_Exited);
                    //Process.Start(ToSaveFileTo);
                    p.Start();

                    //frmKhataPictureViewerFunction(docid);

                }
            }
        }

        private void btnSaveShajra_Click(object sender, EventArgs e)
        {

        }
    }
}
