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

namespace SDC_Application.AL
{
    public partial class frmFardeBadarManual : Form
    {
        #region Class Variables
        /// <summary>
        /// Objects of Langauage Converter, Web Service and Lists for data manipulation
        /// </summary>
        LanguageConverter Lang = new LanguageConverter();
        EFardeBadar fardBadarBL = new EFardeBadar();
        Misal misalBL = new Misal();
        Khatoonies khatooni = new Khatoonies();
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
        DataTable fbAfradListProposed = new DataTable();
        DataTable fbMushteriFareeqain = new DataTable();
        TaqseemNewKhataJatMin MinKhataMethods = new TaqseemNewKhataJatMin();
        Intiqal intiqal=new Intiqal();
        DataView dvMinKhataMalkan = new DataView();
        RhzSDC rhz = new RhzSDC();
        CommanFunctions cmnFns = new CommanFunctions();
        fileIndexing fi = new fileIndexing();
        bool ConfirmationStatus = false;
        bool AmaldaramadStatus = false;
        bool isManualFb = false;
        
        int registerNo = 0;
        string khatoniNo = "";
        string seqNo = "";

        public string IndexedKhattaNo { get; set; }
        private string SelectedPersonId { get; set; }

        #region Class Variables for Shajra Malik name Changes

        //int UserId = Classes.CurrentUser.UserId;
        //List<Proc_Get_Moza_AfradList_All_Types_Result> AllPerson = new List<Proc_Get_Moza_AfradList_All_Types_Result>();
        //List<Proc_Get_Moza_AfradList_All_Types_FB_Result> mozaAllAfrad = new List<Proc_Get_Moza_AfradList_All_Types_FB_Result>();
        bool familyHead = false;

        #endregion

        #endregion

        #region Default Constructor

        public frmFardeBadarManual()
        {
            InitializeComponent();
            //this.tabKhataDetail.TabPages.Remove(gardawarTab);
            //this.tabKhataDetail.TabPages.Remove(tehsilDarTb);
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
            //}
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
                    //string Malya = this.txtMalia.Text;
                    //string Kafiat = this.txtKafyat.Text;

                    string DrustKullHissay = txtDrustKulHissay.Text.Trim() != "" ? this.txtDrustKulHissay.Text.ToString() : "0";
                    string DrustKanal = txtDrustKanal.Text.Trim() != "" ? this.txtDrustKanal.Text.ToString() : "0";
                    string DrustMarla = txtDrustMarla.Text.Trim() != "" ? this.txtDrustMarla.Text.ToString() : "0";
                    float DrustSarSai = txtDrustSarsai.Text.Trim() != "" ? float.Parse(this.txtDrustSarsai.Text) : 0;
                    float DrustFeet = DrustSarSai > 0 ? DrustSarSai * float.Parse("30.25") : (txtDrustFeet.Text.Trim() != "" ? float.Parse(txtDrustFeet.Text) : 0);
                    if (!(DrustSarSai > 0))
                        {
                        DrustSarSai = txtDrustFeet.Text.Trim() != "" ? float.Parse(txtDrustFeet.Text) / float.Parse("30.25") : 0;
                        }

                    if (chbIsKhataMeezanChange.Checked)
                        {
                        if (DrustKullHissay == "0")
                            DrustKullHissay = KullHissay;

                        if (DrustKanal == "0")
                            DrustKanal = Kanal;

                        if (DrustMarla == "0")
                            DrustMarla = Marla;

                        if (DrustSarSai == 0)
                            DrustSarSai = SarSai;

                        if (DrustFeet == 0)
                            DrustFeet = Feet;
                        }
                    
                    string FbKhattaId = txtFbKhataId.Text;
                    if (FbKhattaId == "0")
                        FbKhattaId = "-1";

                    string FbId = txtFbId.Text;

                    int InsertUserId = UsersManagments.UserId;
                    string InsertLoginName = UsersManagments.UserName;
                    string LastId = fardBadarBL.SaveFBKhattajatProposed(FbKhattaId, FbId, KhattaId, KullHissay, DrustKullHissay, Kanal, DrustKanal, Marla, DrustMarla, SarSai.ToString(), DrustSarSai.ToString(),
                        Feet.ToString(), DrustFeet.ToString(),chbIsKhataMeezanChange.Checked?"1":"0", InsertUserId, InsertLoginName);
                    this.FillKhataJaatByMoza();
                    //this.tableLayoutPanel3.Enabled = false;
                    //this.cboKhataNo.SelectedValue = Convert.ToInt32(LastID);
                    //this.splitContainer1.Panel2.Enabled = false;
                    MessageBox.Show("کھاتہ محفوظ ہو گیا ہے۔", "");
                    //this.ClearFormControls(gbBabat);
                    this.ClearFormControls(gbKhataRaqba);
                    this.txtKhatatNo.Clear();
                    this.txtKulHisay.Clear();
                    this.txtDrustKulHissay.Clear();
                    this.chbIsKhataMeezanChange.Checked = false;
                    this.cbFBDocuments.SelectedValue = -1;
                    LoadFBKhatajat(txtFbId.Text);
	            }
	            catch (Exception ex)
	            {
		            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	            }
           

        }
        #endregion

        #region Load FB Data for existing FB

        private void loadFbData(string fbId)
        {
            //Load Fard Bader Khattajat

            //fbKhattaJat = fardBadarBL.GetFbKhattajatProposed(fbId);
            //if (fbKhattaJat.Rows.Count > 0)
            //{
            ////string[] area = khatta.Khata_Area.Split('-');
            //    cboKhataNo.SelectedValue = fbKhattaJat.Rows[0]["FB_RegisterHqDKhataId"].ToString();
            //    txtKhatatNo.Text = fbKhattaJat.Rows[0]["KhataNo"].ToString();
            //    //txtMalia.Text = fbKhattaJat.Rows[0]["Malia"].ToString();
            //    //txtKafyat.Text = fbKhattaJat.Rows[0]["Kyfiat"].ToString();

            //    txtKulHisay.Text = fbKhattaJat.Rows[0]["TotalParts"].ToString();
            //    txtDrustKulHissay.Text = fbKhattaJat.Rows[0]["TotalParts_Proposed"].ToString();
            //    txtKanal.Text = fbKhattaJat.Rows[0]["Khata_Kanal"].ToString();
            //    txtDrustKanal.Text = fbKhattaJat.Rows[0]["Khata_Kanal_Proposed"].ToString();
            //    txtMarla.Text = fbKhattaJat.Rows[0]["Khata_Marla"].ToString();
            //    txtDrustMarla.Text = fbKhattaJat.Rows[0]["Khata_Marla_Proposed"].ToString();
            //    txtSarsai.Text = fbKhattaJat.Rows[0]["Khata_Sarsai"].ToString();
            //    txtDrustSarsai.Text = fbKhattaJat.Rows[0]["Khata_Sarsai_Proposed"].ToString();
            //    txtFeet.Text = fbKhattaJat.Rows[0]["Khata_Feet"].ToString();
            //    txtDrustFeet.Text = fbKhattaJat.Rows[0]["Khata_Feet_Proposed"].ToString();
            //    txtFbKhataId.Text = fbKhattaJat.Rows[0]["FB_KhataId"].ToString();
            //}

            // Load Fard Bader Malikan and Select Khatta from drop down if malikan changes occurred in the searched fard bader.///
            //khewatMalikanByFB = misalBL.GetKhewatFarqeenGroupByKhatId_Misal(fbId, cboKhataNo.SelectedValue.ToString());

            //Tested with EXEC Proc_Get_KhewatFareeqeinGroup_By_Khata_FB_Proposed 15141140004
            //Returns no rows
            this.khewatMalikanByFB = fardBadarBL.GetKhewatGroupFareeqeinByKhataIdByFbId(txtFbId.Text.Trim(), cboKhataNo.SelectedValue.ToString());
            //khewatMalikanByFB = fardBadarBL.GetKhewatGroupFareeqeinByKhataId(txtFbKhataId.Text.Trim());
            this.FillKhatoniListbyKhattaId();
            this.FillGridviewMushteriFareeqain();
            objauto.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cboKhataNo.SelectedValue.ToString(), cbKashtKhatooni, "KhatooniNo", "KhatooniId");
            objauto.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cboKhataNo.SelectedValue.ToString(), cmbKhatooniNoMeezan, "KhatooniNo", "KhatooniId");
            objauto.FillCombo("Proc_Get_KhewatTypes "+ UsersManagments._Tehsilid.ToString(), cbKashtKhewatType, "KhewatType", "KhewatTypeId");
            objauto.FillCombo("Proc_Get_KhewatTypes " + UsersManagments._Tehsilid.ToString(), cbKashtKhewatTypeProposed, "KhewatType", "KhewatTypeId");
            if (khewatMalikanByFB.Rows.Count > 0)
            {
                FillGridviewMalkan(khewatMalikanByFB);
                int khattaid =Convert.ToInt32(khewatMalikanByFB.Rows[0]["RegisterHqDKhataId"].ToString());
                cboKhataNo.SelectedValue = khattaid;
                SetKhataDetailsToTextboxes(khattaid.ToString());
                this.txtKhattaId.Text = khattaid.ToString();
                
            }
            //---- Khassra Area Details
            this.KhatooniKhassrasAreaDetailsFB = fardBadarBL.GetKhassrajatDetailByFbId(txtFbId.Text, cboKhataNo.SelectedValue.ToString());
            this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);

            // Load Khatoni details if khatoni changed occured in the searched fard bader
            int RegHaqKhattaId = Convert.ToInt32(cboKhataNo.SelectedValue);
            KhatoniesByFb = misalBL.GetKhatonisByKhataIdFB(fbId, RegHaqKhattaId);
            if (KhatoniesByFb.Rows.Count > 0)
            {
                //FillGridviewKhatooni(KhatoniesByFb);
                FillGridviewKhatooniRegister();
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

                this.GridViewKhewatMalikaan.Columns["CNIC"].Visible = false;
                this.GridViewKhewatMalikaan.Columns["PersonId_Proposed"].Visible = false;
                this.GridViewKhewatMalikaan.Columns["FardPart_Bata_Proposed"].Visible = false;
                this.GridViewKhewatMalikaan.Columns["FB_FareeqeinId"].Visible = false;

                ////// Set Grid columns Names ///////////

                this.GridViewKhewatMalikaan.Columns["PersonName"].HeaderText = "نام مالک";
                this.GridViewKhewatMalikaan.Columns["FardAreaPart"].HeaderText = "حصہ";
                this.GridViewKhewatMalikaan.Columns["Khewat_Area"].HeaderText = "رقبہ";
                this.GridViewKhewatMalikaan.Columns["KhewatType"].HeaderText = "قسم مالک";
                this.GridViewKhewatMalikaan.Columns["seqno"].HeaderText = "نمبر شمار";
                this.GridViewKhewatMalikaan.Columns["FardAreaPart_Proposed"].HeaderText = "درست حصہ";
                this.GridViewKhewatMalikaan.Columns["Khewat_Area_Proposed"].HeaderText = "درست رقبہ";
            }
        }

        private void FillGridviewKhatooni(DataTable dtKhatooni)
        {
            /*if (dtKhatooni != null)
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
            }*/
        }

        private void FillGridviewKhassrasByKhatooni(DataTable dtKhassra)
        {
            if (dtKhassra != null)
            {
                this.gridViewKhassraAreaDetails.DataSource = dtKhassra;
                this.gridViewKhassraAreaDetails.Columns["FB_KhassraRegisterDetailId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["KhassraId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["KhatooniId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["KhassraDetailId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["AreaTypeId"].Visible = false;
                this.gridViewKhassraAreaDetails.Columns["FB_KhassraId"].Visible = false;

                ////// Set Grid columns Names ///////////

                this.gridViewKhassraAreaDetails.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                this.gridViewKhassraAreaDetails.Columns["KhassraNo_Proposed"].HeaderText = " درست خسرہ نمبر";
                this.gridViewKhassraAreaDetails.Columns["AreaType"].HeaderText = "قسم اراضی";
                this.gridViewKhassraAreaDetails.Columns["Kanal"].HeaderText = "کنال";
                this.gridViewKhassraAreaDetails.Columns["Marla"].HeaderText = "مرلہ";
                this.gridViewKhassraAreaDetails.Columns["Sarsai"].HeaderText = "سرسائی";
                this.gridViewKhassraAreaDetails.Columns["Feet"].HeaderText = "مربع فٹ";
                this.gridViewKhassraAreaDetails.Columns["Kanal_Proposed"].HeaderText = "درست کنال";
                this.gridViewKhassraAreaDetails.Columns["Marla_Proposed"].HeaderText = "درست مرلہ";
                this.gridViewKhassraAreaDetails.Columns["Sarsai_Proposed"].HeaderText = "درست سرسائی";
                this.gridViewKhassraAreaDetails.Columns["Feet_Proposed"].HeaderText = " درست مربع فٹ";
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

            DataTable khewatTypesProp = misalBL.GetKhewatTypes(UsersManagments._Tehsilid);
            DataRow row1 = khewatTypesProp.NewRow();
            row1["KhewatTypeId"] = 0;
            row1["KhewatType"] = "- قسم مالک چنِے  -";
            khewatTypesProp.Rows.Add(row1);
            this.cboQismMalikProp.DataSource = khewatTypesProp;
            this.cboQismMalikProp.DisplayMember = "KhewatType";
            this.cboQismMalikProp.ValueMember = "KhewatTypeId";
            this.cboQismMalikProp.SelectedValue = 0;
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
                    //ClearKhataControls();
                    //ClearKhataControls();
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
            this.txtPersonIdProposed.Text = p.PersonId.ToString();

            if (p.IsForKhata)
                {
                int khewatTypeId = p.KhewatTypeId;
                string fardAreaPart = p.FardAreaPart;
                string fardBata = p.FardBata;
                this.txtKhewatFreeqainGroupId.Text = p.KhewatGroupFareeqId;
                this.txtKhewatGroupId.Text = p.khewatGroupId;
                this.txtKhewatKhataId.Text = p.KhataId;

                cboQismMalik.SelectedValue = khewatTypeId;
                txtPersonNetHissa.Text = fardAreaPart;
                txtNetHissa.Text = fardBata;
                }
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
            /*if (txtKhatoniNo.Text.Trim() != "")
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
            }*/
        }
        #endregion

        #region Function Fill Khatoni List By Khatta Id
        /// <summary>
        /// Fills khatoni record of specific khata by Khata Id into gridview khatoni Register.
        /// </summary>
        private void FillKhatoniListbyKhattaId()
        {
            this.khatoniByKhata = misalBL.GetKhatonisByKhataId(Convert.ToInt32(cboKhataNo.SelectedValue.ToString()));
            DataRow khatoniSelect = khatoniByKhata.NewRow();
            khatoniSelect["KhatooniId"] = 0;
            khatoniSelect["KhatooniNo"] = "- کھتونی نمبر -";
            this.khatoniByKhata.Rows.InsertAt(khatoniSelect,0);
            cboKhatoni.DataSource = this.khatoniByKhata;
            cboKhatoni.ValueMember = "KhatooniId";
            cboKhatoni.DisplayMember = "KhatooniNo";

        }
        #endregion

        #region Function Fills Khatoni Khasra gridview
        /// <summary>
        ///Fills Khatoni Khasra gridview for a specific khatoni using khatoni id.
        /// </summary>

        private void FillKhatoniKhassraList()
        {
            //string khatoniid = this.txtKhatoniId.Text.ToString();
            //this.KhatooniKhassrasAreaDetails = null;
            //this.KhatooniKhassrasAreaDetails = misalBL.GetKhatoniKhassraAreaDetail(khatoniid);
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
                /*ComboBox g = sender as ComboBox;
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

                }*/
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
           
            //this.ClearFormControls(gbBabat);
            this.ClearFormControls(gbKhataMain);
            this.ClearFormControls(gbKhataRaqba);
            this.txtKhatatNo.Focus();
            this.txtKhattaId.Text = "-1";
            this.txtFbKhataId.Text = "-1";
           
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
            if (DialogResult.Yes == MessageBox.Show("آپ فرد بدر کھاتہ ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    string FB_khattaId = txtFbKhataId.Text;
                    string fbId = txtFbId.Text;
                    if (FB_khattaId != "0")
                    {
                        fardBadarBL.DeleteFbKhata(fbId, FB_khattaId);
                        ClearFormControls(gbKhataMain);
                        this.FillKhataJaatByMoza();
                        ClearFormControls(gbKhataRaqba);
                       // ClearFormControls(gbBabat);
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

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            FillMalikanTypeDropDown();
            this.AreaTypesList = misalBL.GetAreaTypesList();
            this.FillKhataJaatByMoza();
            fillAreaType();
            this.FillQoamCombo();
            Fill_ComboKhewatTypes();
            //this.FillMisalMian();
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
            MisalSelect["FB_DocumentNo"] = "- فرد بدر کا انتخاب کریں -";
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
        bool validNumeric = false;
        float validValue = 0;
         if (string.IsNullOrEmpty(txtPersonId.Text) || txtPersonId.Text == "-1")
             {
             MessageBox.Show("پہلے فرد کا انتخاب کریں");
             return;
             }
         else if (string.IsNullOrEmpty(txtDrustHissa.Text))
             {
             MessageBox.Show("درست حصے کااندراج کریں");
             txtDrustHissa.Focus();
             return;
             }
         else if (string.IsNullOrEmpty(txtDrustPersonKanal.Text))
             {
             MessageBox.Show("درست کنال کااندراج کریں");
             txtDrustPersonKanal.Focus();
             return;
             }
         else if (string.IsNullOrEmpty(txtDrustPersonMarla.Text))
             {
             MessageBox.Show("درست مرلہ کااندراج کریں");
             txtDrustPersonMarla.Focus();
             return;
             }
         else if (string.IsNullOrEmpty(txtDrustPersonSarsai.Text))
             {
             txtDrustPersonSarsai.Text = "0";
             }
         else if (string.IsNullOrEmpty(txtDrustPersonFeet.Text))
             {
             txtDrustPersonFeet.Text = "0";
             }

         validNumeric = float.TryParse(txtDrustHissa.Text, out validValue);
         if (!validNumeric)
             {
             MessageBox.Show("حصےدرست طریقے سے اندراج کریں");
             txtDrustHissa.Focus();
             return;
             }

         validNumeric = float.TryParse(txtDrustPersonKanal.Text, out validValue);
         if (!validNumeric)
             {
             MessageBox.Show("حصےدرست طریقے سے اندراج کریں");
             txtDrustPersonKanal.Focus();
             return;
             }

         validNumeric = float.TryParse(txtDrustPersonMarla.Text, out validValue);
         if (!validNumeric)
             {
             MessageBox.Show("حصےدرست طریقے سے اندراج کریں");
             txtDrustPersonMarla.Focus();
             return;
             }

         validNumeric = float.TryParse(txtDrustPersonSarsai.Text, out validValue);
         if (!validNumeric)
             {
             MessageBox.Show("حصےدرست طریقے سے اندراج کریں");
             txtDrustPersonSarsai.Focus();
             return;
             }

         validNumeric = float.TryParse(txtDrustPersonFeet.Text, out validValue);
         if (!validNumeric)
             {
             MessageBox.Show("حصےدرست طریقے سے اندراج کریں");
             txtDrustPersonFeet.Focus();
             return;
             }

         if (txtPersonId.Text != "-1" && txtPersonId.Text != "")
            {
                string  fbId =txtFbId.Text != "" ? txtFbId.Text : "0";
                string fbExistsKGF = txtFbExistsKGF.Text;
              DataTable dtFardatIntiqalat = fardBadarBL.GetFardatIntiqalatOnKhewatGrpupFareeqId(txtKhewatFreeqainGroupId.Text.Length > 0 ? txtKhewatFreeqainGroupId.Text : "0");
                bool isProceed = true;
             if(dtFardatIntiqalat.Rows.Count>0)
             {
                 if (DialogResult.Yes == MessageBox.Show("اپکا انتخاب کردہ ریکارڈ " + dtFardatIntiqalat.Rows[0][0].ToString() + "  فردات اور " + dtFardatIntiqalat.Rows[0][1].ToString() + "  انتقالات میں موجود ہیں، کیا اپ اس مالک کو فرد بدر کے ذرئعے تبدیل کرنا چاہتے ہیں؟ ", "تبدیل کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                 {
                     isProceed = true;
                 }
                 else
                     isProceed = false;
                }
             if (isProceed)
             {
                 if (saveMalikNew())
                 {
                     //this.GetKhewatMaalikanBindingSource.DataSource = client.GetKhewatMalikanByKhataId(Convert.ToInt32(cboKhataNo.SelectedValue)).ToList();
                     // this.txtPersonName.Focus();

                     this.khewatMalikanByFB = fardBadarBL.GetKhewatGroupFareeqeinByKhataIdByFbId(fbId, cboKhataNo.SelectedValue.ToString());
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
        }
        		 
	#endregion

        #region Save malik entry

        private float calculateNetPart(string valueInBata)
        {
            float NetPart = 0;
            try
            {
                if (valueInBata.Contains('/'))
                {
                    string[] parts = valueInBata.Split('/');

                    if (parts.Count() == 2)
                    {
                        int d = Convert.ToInt32(parts[1]);
                        if (d != 0)
                        {
                            float num = float.Parse(parts[0]);
                            float den = float.Parse(parts[1]);
                            NetPart = (float)(Math.Round((Decimal)(num / den), 5, MidpointRounding.AwayFromZero));
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
                    NetPart = float.Parse(valueInBata);
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
            string pidProposed = txtPersonIdProposed.Text.ToString() != "" ? txtPersonIdProposed.Text : "0";
            string pName = txtPersonName.Text.Trim();
            string kgf_id = txtKhewatFreeqainGroupId.Text != "" ? txtKhewatFreeqainGroupId.Text : "-1";
            string kg_id = txtKhewatGroupId.Text != "" ?txtKhewatGroupId.Text : "0";
            int kh_id = txtKhewatKhataId.Text != "" ? Convert.ToInt32(txtKhewatKhataId.Text) : 0;

            //Old Shares
            string fardParts = txtPersonNetHissa.Text.Trim(); //txtPersonNetHissa.Text.Trim() != "" ? Convert.ToInt32(txtPersonNetHissa.Text.Trim()) : 0;
            int kanal = txtPersonKanal.Text.Trim() != "" ? Convert.ToInt32(txtPersonKanal.Text.Trim()) : 0;
            int marla = txtPersonMarla.Text.Trim() != "" ? Convert.ToInt32(txtPersonMarla.Text.Trim()) : 0;
            float sarsai = txtPersonSarsai.Text.Trim() != "" ? float.Parse(txtPersonSarsai.Text.Trim()) : 0;
            float sft = txtPersonFeet.Text.Trim() != "" ? float.Parse(txtPersonFeet.Text.Trim()) : 0;

            //Corrected Shares
            string fardDrustParts = txtDrustHissa.Text.Trim(); //txtPersonNetHissa.Text.Trim() != "" ? Convert.ToInt32(txtPersonNetHissa.Text.Trim()) : 0;
            int kanalProposed = txtDrustPersonKanal.Text.Trim() != "" ? Convert.ToInt32(txtDrustPersonKanal.Text.Trim()) : 0;
            int marlaProposed = txtDrustPersonMarla.Text.Trim() != "" ? Convert.ToInt32(txtDrustPersonMarla.Text.Trim()) : 0;
            float sarsaiProposed = txtDrustPersonSarsai.Text.Trim() != "" ? float.Parse(txtDrustPersonSarsai.Text.Trim()) : 0;
            float sftProposed = txtDrustPersonFeet.Text.Trim() != "" ? float.Parse(txtDrustPersonFeet.Text.Trim()) : 0;

            int khewatTypeId = Convert.ToInt32(cboQismMalik.SelectedValue);
            int khewatTypeIdProposed = Convert.ToInt32(cboQismMalikProp.SelectedValue);

            string netPart = this.txtPersonNetHissa.Text;
            string netPartProposed = this.txtDrustHissa.Text;
            long FbId = long.Parse(txtFbId.Text);
            long FbFareeqId =long.Parse(txtFbFareeqId.Text!=""?txtFbFareeqId.Text:"-1");
            string fbExistsKGF = txtFbExistsKGF.Text;
            int sqNo = Convert.ToInt32(txtSeqNo.Text!=""?txtSeqNo.Text:"1");
            if (pid != "0" && khewatTypeId != 0 && KhattaId!=0 && cboQismMalikProp.SelectedValue.ToString().Length>2)
            {
                try
                {
                    if (kgf_id.Length < 5)
                    {
                        kgf_id = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus("-1", "0", txtPersonId.Text, "0", "0", "0", "0", "0", cboQismMalikProp.SelectedValue.ToString(), cboKhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "0", "Fard e Badar", "1");
                    }
                   // string s = client.SaveKhewatGrouFreeqein(kgf_id, kg_id, pid, netPart, kanal, marla, sarsai, sft, khewatTypeId, kh_id, CurrentUser.UserId, darNo, totalDarParts, personParts, ofDarPart, CurrentUser.UserName, txtPersonNetHissa.Text.Trim());
                    /*string s = misalBL.SaveFBKhewatGroupFarqeen(FbFareeqId,FbId, kgf_id, kg_id, "Misal", "0", sqNo, pid, khewatTypeId, netPart, kanal, marla, sarsai, sft, UsersManagments.UserId, UsersManagments.UserName, 0, txtPersonNetHissa.Text.Trim(), KhattaId); 
                    */
                    string s = fardBadarBL.SaveFBKhewatGroupFarqeenProposed(
                        FbFareeqId.ToString(), 
                        FbId.ToString(), 
                        kgf_id, 
                        kg_id, 
                        "Fard_e_Badar", 
                        "0", 
                        sqNo.ToString(), 
                        pid, 
                        pidProposed, 
                        khewatTypeId.ToString(), 
                        khewatTypeIdProposed.ToString(),
                        netPart,
                        netPartProposed, 
                        kanal.ToString(), 
                        kanalProposed.ToString(), 
                        marla.ToString(), 
                        marlaProposed.ToString(), 
                        sarsai.ToString(), 
                        sarsaiProposed.ToString(), 
                        sft.ToString(), 
                        sftProposed.ToString(), 
                        UsersManagments.UserId.ToString(), 
                        UsersManagments.UserName, 
                        txtPersonNetHissa.Text.Trim(), 
                        txtDrustHissa.Text.Trim(), 
                        KhattaId.ToString());

                    if (s != "")
                        {
                        //lblMessageMalik.Text = "ریکارڈ محفوظ ہو گیا";
                        //lblMessageMalik.ForeColor = Color.Green;
                            MessageBox.Show("ریکارڈ محفوظ ہو گیا", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSaved = true;
                        }
                    else
                        {
                        MessageBox.Show("ریکارڈ محفوظ نہیں ہو سکا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (txtFbFareeqId.Text != "-1")
            {
                string fbFareeqainId = txtFbFareeqId.Text != "" ? txtFbFareeqId.Text : "0";
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                      string retVal=  fardBadarBL.DeleteFbKhewatGroupFareeq(fbFareeqainId);
                      if (retVal != "0")
                      {
                          MessageBox.Show("مالک خذف ہو گیا ہے", "خذف مکمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          this.khewatMalikanByFB = fardBadarBL.GetKhewatGroupFareeqeinByKhataIdByFbId(txtFbId.Text, cboKhataNo.SelectedValue.ToString());
                          this.FillGridviewMalkan(khewatMalikanByFB);
                          this.txtFbFareeqId.Text = "-1";
                          this.txtKhewatFreeqainGroupId.Text = "-1";

                      }
                      else
                      {
                          MessageBox.Show(" مالک خذف نہیں ہو سکا ", "خذف نا مکمل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
        if (string.IsNullOrWhiteSpace(cboKhataNo.SelectedValue.ToString()))
            {
            MessageBox.Show("تلاش کرنے سے پہلے کہاتے کا انتخاب کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }
        frmSearchPerson serch = new frmSearchPerson();
        serch.KhataId = cboKhataNo.SelectedValue.ToString();
        serch.IsForKhata = true;
        serch.FormClosed -= new FormClosedEventHandler(serch_FormClosed);
        serch.FormClosed += new FormClosedEventHandler(serch_FormClosed);
        serch.ShowDialog();
            //this.FindPerson(1);
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
           
                /*if (txtKhatoniNo.Text.Trim() != "")
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
                    MessageBox.Show("کھتونی نمبر خالی ہے");*/

            

        }
        #endregion

        #region Khatooni Delete Button Click Event

        private void btnDeleteKhatoni_Click(object sender, EventArgs e)
        {
            /*if (DialogResult.Yes == MessageBox.Show("آپ واقعی کھتونی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
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
            }*/
        }
        		 
	    #endregion

        #region Khassra Register Save Button Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string khatoniid =this.txtKhatooniIdofKhassra.Text;
                string khasraDetailId = txtKhassraDetailId.Text;
                string khasrano = txtKhassraNo.Text;
                string KhassranoProposed = txtDrustKhassraNo.Text.Trim();
                string aretype = cboAreaType.SelectedValue.ToString();
                string k = txtKhassraKanal.Text.Trim() != "" ? txtKhassraKanal.Text.Trim() : "0";
                string kp = txtDrustKhassraKanal.Text.Trim() != "" ? txtDrustKhassraKanal.Text.Trim() : "0";
                string m = txtKhassraMarla.Text.Trim() != "" ?txtKhassraMarla.Text.Trim() : "0";
                string mp = txtDrustKhassraMarla.Text.Trim() != "" ?txtDrustKhassraMarla.Text.Trim() : "0";
                string s = txtKhassraSarsai.Text.Trim() != "" ? txtKhassraSarsai.Text.Trim() :"0";
                string sp = txtDrustKhassraSarsai.Text.Trim() != "" ? txtDrustKhassraSarsai.Text.Trim() :"0";
                string f = Math.Round(Convert.ToDecimal(txtKhassraSarsai.Text.Trim())*(decimal)30.25).ToString();
                string fp = Math.Round(Convert.ToDecimal(txtKhassraSarsai.Text.Trim())*(decimal)30.25).ToString();

                string FbId = txtFbId.Text;
                string FbKhasraDetailId = txtFbKhassraDetailId.Text;
                string FbKhassraId = txtFbKhassraId.Text;
                   
                string khasraId= txtKhassraId.Text;
                    string lastId = fardBadarBL.SaveFBKhassraRegister(FbKhassraId, FbKhasraDetailId, FbId,khasraId,cmbMouza.SelectedValue.ToString(),txtKhassraNo.Text.Trim(), KhassranoProposed, khasraDetailId,khatoniid, aretype, k,kp, m,mp, s,sp, f,fp, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (lastId != "-1")
                    {
                        this.txtKhassraNo.ReadOnly = false;
                        //this.btnKhassraDelete.Enabled = false;
                        txtKhassraDetailId.Text = "-1";
                        txtFbKhassraDetailId.Text = "-1";
                        txtFbKhassraId.Text = "-1";
                        txtKhassraId.Text = "-1";
                        txtKhassraNo.Clear();
                        cboAreaType.SelectedValue = 0;
                        txtKhassraKanal.Clear();
                        txtKhassraMarla.Clear();
                        txtKhassraSarsai.Clear();
                        txtDrustKhassraKanal.Clear();
                        txtDrustKhassraMarla.Clear();
                        txtDrustKhassraSarsai.Clear();
                        txtDrustKhassraNo.Clear();
                        txtKhassraNo.Focus();
                        this.KhatooniKhassrasAreaDetailsFB = fardBadarBL.GetKhassrajatDetailByFbId( FbId, cboKhataNo.SelectedValue.ToString());
                        this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);
                    }
                    else
                    {
                        MessageBox.Show("یہ خسرہ پہلے سے موجود ہے");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        		 
	    #endregion

        #region Count of Khassras in a Khatoni of a Khewat

        private void GetKhassrasCount()
        {
            try
            {
                /*string count = misalBL.GetKhatoniKhassraCount(cboKhatoni.SelectedValue.ToString());
                this.lblKulKhasrajaat.Text = count;*/
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
                int khatoniId = Convert.ToInt32(cboKhatoni.SelectedValue);
                string LastId= fardBadarBL.DeleteFbKhassraDetail(fbId, txtKhassraDetailId.Text);
                if (LastId != "0")
                {
                    this.txtKhassraDetailId.Text = "-1";
                    this.txtFbKhassraDetailId.Text="-1";
                    this.txtFbKhassraId.Text = "-1";
                    this.ClearFormControls(this.gBKhassraContols);
                    this.ClearFormControls(gbKhassraProposed);
                    this.txtKhassraNo.ReadOnly = false;
                    //this.btnKhassraDelete.Enabled = false;
                    this.txtKhassraNo.Focus();
                    this.KhatooniKhassrasAreaDetailsFB = fardBadarBL.GetKhassrajatDetailByFbId(fbId, cboKhataNo.SelectedValue.ToString());
                    this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);
                }
               
               
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
                                txtDrustHissa.Text = row.Cells["FardPart_Bata"].Value.ToString();
                                txtPersonName.Text = row.Cells["PersonName"].Value.ToString();
                                txtSeqNo.Text = row.Cells["seqno"].Value.ToString();
                                txtFbFareeqId.Text = row.Cells["FB_FareeqeinId"].Value.ToString();
                                //txtFbExistsKGF.Text = row.Cells["FB_Exists"].Value.ToString();

                                txtPersonId.Text = row.Cells["PersonId"].Value.ToString();
                                txtDrustHissa.Text = row.Cells["FardAreaPart_Proposed"].Value.ToString();
                                txtDrustHissaBata.Text = row.Cells["FardPart_Bata_Proposed"].Value.ToString();
                                string khewatArea = row.Cells["Khewat_Area_Proposed"].Value.ToString();
                                
                                string[] areaValues = khewatArea.Split('-');
                                txtDrustPersonKanal.Text = areaValues[0];
                                txtDrustPersonMarla.Text = areaValues[1];
                                txtDrustPersonFeet.Text = areaValues[2];
                                txtDrustPersonSarsai.Text =(Math.Round(Convert.ToDecimal( Convert.ToInt32(txtDrustFeet.Text.Trim()!=""?txtDrustFeet.Text.Trim():"0")*(float)30.25) , 3)).ToString();
                                
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
                        DataTable dtExistingNo= misalBL.GetFardBaderMainByDocNo(txtFardBadarDocNO.Text.Trim(),Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
		           if(dtExistingNo.Rows.Count==0)
                   {
                   string fbId=txtFbId.Text.Trim()!=""?txtFbId.Text.Trim():"-1";
                        int isManualFb=rbManualFb.Checked?1:0;
                        string LastId = misalBL.SaveFardBadarMain(fbId, Convert.ToInt32(cmbMouza.SelectedValue.ToString()), txtFardBadarDocNO.Text.Trim(), dtpDateGardawari.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), dtpDateTehsilDar.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtFardBadarTafseel.Text, UsersManagments.UserId, UsersManagments.UserName, isManualFb);
                        txtFbId.Text = LastId;
                        if (txtFbId.Text.Length > 5)
                        {
                            MessageBox.Show("مثل / فرد بدر اندراج ہو گیا ہے۔", "");
                            this.txtFardBadarDocNO.Clear();
                            this.dtpDateGardawari.Value = DateTime.Now;
                            this.dtpDateTehsilDar.Value = DateTime.Now;
                            this.txtFardBadarDocNO.Focus();
                            this.txtFbId.Text = "-1";
                        }
	                }
                   else
                       MessageBox.Show("فرد بدر / مثل نمبر"+ dtExistingNo.Rows[0]["FB_DocumentNo"].ToString()+" پہلے سے موجود ہے۔" );
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
            //this.ClearFormControls(gbBabat);
            this.ClearFormControls(gbKhataMain);
            this.ClearFormControls(gbKhataRaqba);
            this.ClearFormControls(gBKhassraContols);
            //this.ClearFormControls(gBKhatoniControls);
        }
        		 
	#endregion

        #region Search Misal by Misal Number
		 
        private void btnSearchFB_Click(object sender, EventArgs e)
        {
            enableControles();
        if (cmbMouza.SelectedValue.ToString() == "-1" || cmbMouza.SelectedValue.ToString() == "0")
                {
                MessageBox.Show("موضع کا انتخاب کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            else if (txtFardBadarDocNO.Text.Length == 0)
                {
                MessageBox.Show("فرد بدر نمبر مہیا کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            try
                {
                DataTable dtMisalDetails = new DataTable();
                string fbDocNo = txtFardBadarDocNO.Text.Trim() != "" ? txtFardBadarDocNO.Text.Trim() : "0";
                int mozaId = Convert.ToInt32(cmbMouza.SelectedValue.ToString());
                dtMisalDetails = misalBL.GetFardBaderMainByDocNoSDC(fbDocNo, mozaId);
                if (dtMisalDetails.Rows.Count > 0)
                    {
                   // dtpDateGardawari.Value = Convert.ToDateTime(dtMisalDetails.Rows[0]["GardawarDate"].ToString());
                    //dtpDateTehsilDar.Value = Convert.ToDateTime(dtMisalDetails.Rows[0]["ConfirmationDate"].ToString());
                    txtFardBadarTafseel.Text = dtMisalDetails.Rows[0]["FB_Detail"].ToString();
                    txtFbId.Text = dtMisalDetails.Rows[0]["FB_Id"].ToString();
                    this.ConfirmationStatus = Convert.ToBoolean(dtMisalDetails.Rows[0]["ConfirmationStatus"].ToString());
                    this.AmaldaramadStatus = Convert.ToBoolean(dtMisalDetails.Rows[0]["AmaldaramadStatus"].ToString());
                    this.isManualFb = Convert.ToBoolean(dtMisalDetails.Rows[0]["isManualFB"].ToString());
                    rbManualFb.Checked = isManualFb;
                    btnAmaldaramad.Enabled = false;
                    btnConfirm.Enabled = UsersManagments._IsAdmin ? !ConfirmationStatus : false;
                   /// btnConfirm.Enabled = true;
                    if (this.ConfirmationStatus)
                        {
                        btnAmaldaramad.Enabled = !AmaldaramadStatus;
                        disableControles();
                        //this.tabKhataDetail.TabPages.Remove(gardawarTab);
                        //this.tabKhataDetail.TabPages.Remove(tehsilDarTb);
                        //this.tabKhataDetail.TabPages.Add(gardawarTab);
                        //this.tabKhataDetail.TabPages.Add(tehsilDarTb);
                        }
                    if(this.AmaldaramadStatus)
                    {
                        //this.DisAbleControls();
                        btnFbRevert.Enabled = UsersManagments._IsAdmin ? true : false;
                        disableControles();
                    }
                    else
                        {
                            btnFbRevert.Enabled = false;
                        //this.tabKhataDetail.TabPages.Remove(gardawarTab);
                        //this.tabKhataDetail.TabPages.Remove(tehsilDarTb);
                        //btnConfirm.Enabled = true;
                        }
                   // if(UsersManagments.UserId.ToString()==
                    this.LoadFBKhatajat(txtFbId.Text);
                    loadFbData(txtFbId.Text);
                    //Load Data for Afrad
                    this.FillDgFBAfrad();
                    }
                else
                    {
                    MessageBox.Show("اپکا مطلوبہ فرد بدر موجود نہیں", "فرد بدر موجود نہیں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFbId.Text = "-1";
                    btnConfirm.Enabled = false;
                    }
                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
      #endregion
        #region Controle Enable disable
        private void disableControles()
        {
            btnConfirm.Enabled = false;
            gbKhattaControls.Enabled = false;
            gbKhataMalikan.Enabled = false;
            gbKhassra.Enabled = false;
            gbKhatooniMain.Enabled = false;
            gbKasht.Enabled = false;
            gbAfradRegisterControls.Enabled = false;
            gbMinKhataButtons.Enabled = false;
            gbMinMalikan.Enabled = false;
            gbMinKhataKhatooni.Enabled = false;
            gbMinKhassras.Enabled = false;
        }
        private void enableControles()
        {
            btnConfirm.Enabled = true;
            //dgFBKhatajat.Enabled = true;
            gbKhataMalikan.Enabled = true;
            gbKhassra.Enabled = true;
            gbKhatooniMain.Enabled = true;
            gbKasht.Enabled = true;
            gbAfradRegisterControls.Enabled = true;
            gbMinKhataButtons.Enabled = true;
            gbMinMalikan.Enabled = true;
            gbMinKhataKhatooni.Enabled = true;
            gbMinKhassras.Enabled = true;
        }
        #endregion

        #region Load Save Fb Afrad gridview
        private void FillDgFBAfrad()
        {
            fbAfradListProposed.Clear();
            dgFBAfrad.DataSource = null;
            fbAfradListProposed = fardBadarBL.GetFBAfradListProposed(cmbMouza.SelectedValue.ToString(), txtFbId.Text);

            if (fbAfradListProposed.Rows.Count > 0)
            {
                dgFBAfrad.DataSource = fbAfradListProposed;
                dgFBAfrad.Columns["PersonId"].Visible = false;
                //dgFBAfrad.Columns["PersonName"].Visible = false;
                //dgFBAfrad.Columns["PersonNameProposed"].Visible = false;
                dgFBAfrad.Columns["QoamId"].Visible = false;
                dgFBAfrad.Columns["FB_Personid"].Visible = false;

                dgFBAfrad.Columns["PersonName"].HeaderText = "نام";
                dgFBAfrad.Columns["PersonNameProposed"].HeaderText = "درست نام";
                dgFBAfrad.Columns["CNIC"].HeaderText = "شناختی کارڈ";
                dgFBAfrad.Columns["PersonExtraDetails"].HeaderText = "تفصیل افراد";
                dgFBAfrad.Columns["PersonKhataDetails"].HeaderText = "تفصیل کھاتہ جات";
                //loadFbData(txtFardBadarDocNO.Text);FamilyNameProposed
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
            //txtKhassraGroupId.Text = "-1";
            // txtKhasraNo.Clear();
            //txtKhassraGroupId.Clear();
        }

        private void ClearkhatoniControls()
        {
            this.GetKhatoonisFB = null;
            //txtKhatoniId.Text = "-1";
            // txtKhatatNo.Clear();
            //this.txtKhatoniNo.Clear();
            //txtKhatoniLagaan.Clear();
            //txtKhatoniWasailAbpashi.Clear();
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
            ClearDGVs();
            dgFBKhatajat.DataSource = null;
            this.FillMisalMian();
            DataTable RegisNo=misalBL.GetHaqdaraanRegistersByMoza(Convert.ToInt32(cmbMouza.SelectedValue));
            if(RegisNo.Rows.Count > 0)
            {
                this.registerNo =Convert.ToInt32(RegisNo.Rows[0][0].ToString());
            }
            this.FillKhataJaatByMoza();
        }

        #endregion
        #region Clear Gridview Lists
        private void ClearDGVs()
        {
            
            GridViewKhewatMalikaan.DataSource = null;
            gridViewKhassraAreaDetails.DataSource = null;
            gridviewKhatooniMeezan.DataSource = null;
            dgFBAfrad.DataSource = null;
            DgMinKhataList.DataSource = null;
            dgMinKhataMalkan.DataSource = null;
            grdGetkhatonichange.DataSource = null;
            dgMinKhataKhassraJat.DataSource = null;
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
                //this.ClearFormControls(gBKhatoniControls); // Clear Khatoni Controls
                this.ClearFormControls(gBKhassraContols);  // Clear Khassra Controls
                this.ClearFormControls(gbKhewatGroupFareeq);
                ClearkhatoniControls();
                ClearKhasrasControls();
                ClearKhasraDetailControls();
                FillKhewatMalikanByKhataId();
                FillKhatoniListbyKhattaId();
                LoadKhatonies(Convert.ToInt32(txtKhattaId.Text));
                this.FillGridviewKhatooniRegister();

                
            }
        }

        #endregion
        
        #region Fill Khatoni  By Khata Id
        private void LoadKhatonies(int KhattaId)
        {
            try
            {
                // Load Khatoni details if khatoni changed occured in the searched fard bader
                 //KhatoniesByFb = misalBL.GetKhatonisByKhataIdFB(txtFbId.Text, KhattaId);
                if (KhatoniesByFb.Rows.Count > 0)
                {
                    this.GetKhatoonisFB = KhatoniesByFb;
                    //this.GridViewKhatoniList.Columns[0].Visible = false;
                    //this.GridViewKhatoniList.DataSource = GetKhatoonisFB;
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
             
                //this.khewatMalikanByFB= misalBL.GetKhewatFarqeenGroupByKhatId_Misal(this.txtFbId.Text, khataid.ToString());
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

        #region Txtbox Name Malik Search Key Press Event

        private void txtNameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            //{
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
            //}
        }

        #endregion

        #region Name Malik Search Text Change Event

        /*private void txtNameSearch_TextChanged(object sender, EventArgs e)
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
        }*/

        #endregion

        #region Gridview Khatooni List Click Event

        private void GridViewKhatoniList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    /*if (GridViewKhatoniList.SelectedRows.Count > 0)
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

                    }*/
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
            /*foreach (DataGridViewRow Myrow in GridViewKhatoniList.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToInt32(Myrow.Cells["FB_Exists"].Value) == 1)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }

            }*/
        }

        #endregion

        #region Gridview Khatooni List cell click Event
        
        private void cboKhatoni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int khatooniId=Convert.ToInt32(cboKhatoni.SelectedValue);
            //KhatooniKhassrasAreaDetailsFB = misalBL.GetKhatoniKhassraAreaDetailFB(txtFbId.Text, khatooniId);
            this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);
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
                            cboKhatoni.SelectedValue = row.Cells["KhatooniId"].Value.ToString();
                            txtKhassraNo.Text = row.Cells["KhassraNo"].Value.ToString();
                            txtDrustKhassraNo.Text = row.Cells["KhassraNo_Proposed"].Value.ToString();
                            txtKhassraId.Text = row.Cells["KhassraId"].Value.ToString();
                            txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
                            txtFbKhassraId.Text = row.Cells["FB_KhassraId"].Value.ToString();
                            txtFbKhassraDetailId.Text = row.Cells["FB_KhassraRegisterDetailId"].Value.ToString();
                            // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                            cboAreaType.SelectedValue = row.Cells["AreaTypeId"].Value.ToString();
                            txtKhassraKanal.Text = row.Cells["Kanal"].Value.ToString();
                            txtKhassraMarla.Text = row.Cells["Marla"].Value.ToString();
                            txtKhassraSarsai.Text = row.Cells["Sarsai"].Value.ToString();
                            txtDrustKhassraKanal.Text = row.Cells["Kanal_Proposed"].Value.ToString();
                            txtDrustKhassraMarla.Text = row.Cells["Marla_Proposed"].Value.ToString();
                            txtDrustKhassraSarsai.Text = row.Cells["Sarsai_Proposed"].Value.ToString();

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

        #region TextBox Person Net Part Leave Event

        private void txtPersonNetHissa_Leave(object sender, EventArgs e)
        {
            this.txtNetHissa.Text = this.calculateNetPart(this.txtPersonNetHissa.Text.Trim()).ToString();
        
        }

        #endregion

        #region Button Confirmation Click event

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فائنل کرنے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز فائنل ہے تو یس کلک کریں۔؟", "Confirmation of Fard e Badar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    string fbId = this.txtFbId.Text;
                    
                    if (fbId != "0" && fbId!="" )
                    {
                        misalBL.UpdateFardBaderMainConfirmationAmaldaramad(fbId, "Confirmation", UsersManagments.UserName, " ");
                        ClearFormControls(gbKhataMain);
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
            this.gbKhanaKasht.Enabled = false;
            this.gbKhatooniMeezan.Enabled = false;
            //this.gBKhatoniControls.Enabled = false;
        }
        public void EnableControls()
        {
            this.btnSaveFardBadar.Enabled = true;
            this.gbAfradRegisterControls.Enabled = true;
            this.gBKhassraContols.Enabled = true;
            this.gbKhattaControls.Enabled = true;
            this.gbKhewatGroupFareeq.Enabled = true;
            this.gbKhanaKasht.Enabled = true;
            this.gbKhatooniMeezan.Enabled = true;
            //this.gBKhatoniControls.Enabled = false;
        }


        #endregion
        
        #region Misal Badar Amaldaramad

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFbId.Text.Trim() != "")
                {
                    misalBL.FardBaderAmaldaramadManualFb(txtFbId.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    btnAmaldaramad.Enabled = false;
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
            UsersManagments.check = 12;
            rptMain.ShowDialog();
        }

        #endregion

        #region Search a Fard within a Moza

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int mozaId = Convert.ToInt32(cmbMouza.SelectedValue.ToString());
            //misalBL.
        }

        private void btnSearchaFard_Click(object sender, EventArgs e)
            {
            if (cmbMouza.SelectedValue.ToString() == "0")
                {
                MessageBox.Show("موضع کا انتخاب کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            dgFBAfrad.DataSource = null;
            this.SelectedPersonId = "";
            frmSearchPerson Sp = new frmSearchPerson();
            Sp.MozaId = cmbMouza.SelectedValue.ToString();
            Sp.isforShajraFb = true;
            Sp.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
            Sp.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
            Sp.ShowDialog();
            }

        void Sp_FormClosed(object sender, FormClosedEventArgs e)
            {

            frmSearchPerson ap = sender as frmSearchPerson;
            if (ap.PersonId != 0)
            {
                this.SelectedPersonId = ap.PersonId.ToString();
                this.cbQoam.SelectedValue = ap.QoamId;
                if (!string.IsNullOrEmpty(ap.CNIC) && ap.CNIC != "0")
                {
                    txtNIC.Text = ap.CNIC;
                }
                this.txtDrustNaam.Text = ap.PersonNameForFB;
                this.txtfbShajraOldName.Text = ap.PersonNameForFB;
                this.txtName.Text = ap.PersonName;
            }
            }

        #endregion

        #region Saving Correct Name as Proposed Value

        private void btnSaveShajra_Click(object sender, EventArgs e)
            {
            if (cmbMouza.SelectedValue.ToString() == null)
                {
                MessageBox.Show("موضع چنیے", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMouza.Focus();
                return;
                }
            else if(txtFbId.Text=="0" || txtFbId.Text=="-1")
                {
                MessageBox.Show("فرد بدر نمبر مہیا کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFardBadarDocNO.Focus();
                return;
                }
            else if (string.IsNullOrEmpty(this.SelectedPersonId) || string.IsNullOrWhiteSpace(this.txtName.Text))
                {
                MessageBox.Show("نام درستگی کے لیے پوری معلومات فراہم کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            string cnic=txtNIC.Text.Trim()!=""?txtNIC.Text:"0";
            try
                {
                string lastId = fardBadarBL.SaveProposedNameToShajarah(txtFBPersonId.Text, txtFbId.Text, this.SelectedPersonId, this.cbQoam.SelectedValue.ToString(), txtfbShajraOldName.Text,cnic ,this.txtDrustNaam.Text, this.txtPersonExtraDetails.Text.Trim(), this.txtPersonKhataDetails.Text.Trim());
                if (lastId != "0")
                    {
                    MessageBox.Show("درست نام تبدیل ہوگیاہے۔", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtDrustNaam.Clear();
                    txtfbShajraOldName.Clear();
                    txtFBPersonId.Text = "-1";
                    //cmbMouza.SelectedValue = 0;
                    cbQoam.SelectedValue = 0;
                    txtNIC.Clear();
                    this.FillDgFBAfrad();
                    }
                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region Loading FB Related Data
        private void dgFBAfrad_DoubleClick(object sender, EventArgs e)
            {
            
                    foreach (DataGridViewRow row in dgFBAfrad.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["ColSelPerson"].Value = 1;
                            this.SelectedPersonId = row.Cells["PersonId"].Value.ToString();
                            this.txtfbShajraOldName.Text = row.Cells["PersonName"].Value.ToString();
                            this.txtFBPersonId.Text = row.Cells["FB_Personid"].Value.ToString();
                            //this.txtName.Text = row.Cells["FamilyName"].Value.ToString();
                            this.txtDrustNaam.Text = row.Cells["PersonNameProposed"].Value.ToString();
                            this.txtNIC.Text = row.Cells["CNIC"].Value.ToString();
                            this.cbQoam.SelectedValue = row.Cells["QoamId"].Value.ToString();
                            this.txtPersonExtraDetails.Text = row.Cells["PersonExtraDetails"].Value.ToString();
                            this.txtPersonKhataDetails.Text = row.Cells["PersonKhataDetails"].Value.ToString();
                        }
                        else
                            row.Cells["ColSelPerson"].Value = 0;

                    }
            }
        #endregion

        #region Textbox drost Hissay bata events

        private void txtDrustHissaBata_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if((e.KeyChar !=8 && e.KeyChar != 13) && (e.KeyChar<47 || e.KeyChar>58))
                {
                    e.Handled=true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDrustHissaBata_Leave(object sender, EventArgs e)
        {
            this.txtDrustHissa.Text = this.calculateNetPart(this.txtDrustHissaBata.Text.Trim()).ToString();
            if (txtDrustHissa.Text.Length > 0)
            {
                string[] Area = cmnFns.CalculatedAreaFromHisa(float.Parse(txtKulHisay.Text), float.Parse(txtDrustHissa.Text), Convert.ToInt32(txtKanal.Text), Convert.ToInt32(txtMarla.Text), float.Parse(txtSarsai.Text != "" ? txtSarsai.Text : "0"), float.Parse(txtFeet.Text != "" ? txtFeet.Text : "0"));
                txtDrustPersonKanal.Text = Area[0] != null ? Area[0].ToString() : "0";
                txtDrustPersonMarla.Text = Area[1] != null ? Area[1].ToString() : "0";
                txtDrustPersonSarsai.Text = Area[2] != null ? Area[2].ToString() : "0";
                txtDrustPersonFeet.Text = Area[3] != null ? Area[3].ToString() : "0";
            }
        }
        #endregion

        #region Button New FB Malik Add Event
  
        private void btnNewFbMalik_Click(object sender, EventArgs e)
        {

            try
            {
                frmSearchPerson searchp = new frmSearchPerson();
                searchp.MozaId = cmbMouza.SelectedValue.ToString();
                searchp.FormClosed -= new FormClosedEventHandler(searchp_FormClosed);
                searchp.FormClosed += new FormClosedEventHandler(searchp_FormClosed);
                searchp.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void searchp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson searchp = sender as frmSearchPerson;
            this.txtPersonId.Text = searchp.PersonId.ToString();
            this.txtPersonIdProposed.Text = txtPersonId.Text;
            this.txtPersonName.Text = searchp.PersonName;
            this.txtFbFareeqId.Text = "-1";
            this.txtKhewatFreeqainGroupId.Text = "-1";


        }

        #endregion

        #region Button Search Khassra Click Event

        private void btnSearchKhassra_Click(object sender, EventArgs e)
        {
            frmKhassraFardBadar kmt = new frmKhassraFardBadar();
            kmt.KhataId = cboKhataNo.SelectedValue.ToString();
            kmt.FormClosed -= new FormClosedEventHandler(kmt_FormClosed);
            kmt.FormClosed += new FormClosedEventHandler(kmt_FormClosed);
            kmt.ShowDialog();
        }

        void kmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKhassraFardBadar kmt = sender as frmKhassraFardBadar;
            try
            {
                txtKhassraId.Text = kmt.KhassraId;
                txtKhassraDetailId.Text = kmt.KhassraDetailId;
                txtKhassraNo.Text = kmt.KhassraNo;
                this.cboKhatoni.SelectedValue = kmt.khatoniId;
                this.txtKhatooniIdofKhassra.Text = kmt.khatoniId;
                cboAreaType.SelectedValue = kmt.KhassraTypeId;
                txtKhassraKanal.Text = kmt.KhassraKanal;
                txtKhassraMarla.Text = kmt.khassraMarla;
                txtKhassraSarsai.Text = kmt.khassraSarsai;
            }
            catch (Exception ex)
            {
                //
            }

        }

        #endregion

        #region Khana kasht Malkan related code

        #region Button Select Kasht Malik
 
        private void btnSelectKashtMalik_Click(object sender, EventArgs e)
        {
            if (cbKashtKhatooni.SelectedValue.ToString() != "0")
            {
                frmSearchPerson sp = new frmSearchPerson();
                sp.KhatooniId = cbKashtKhatooni.SelectedValue.ToString();
                sp.isForKhatooni = true;
                sp.FormClosed -= new FormClosedEventHandler(sp_FormClosed);
                sp.FormClosed += new FormClosedEventHandler(sp_FormClosed);
                sp.ShowDialog();
            }
        }

        void sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSearchPerson sp = sender as frmSearchPerson;
                this.txtMushteriFareeqId.Text = sp.MushteriFareeqId;
                this.txtkashtPersonId.Text = sp.PersonId.ToString();
                this.txtKashtMalikName.Text = sp.PersonName;
                this.txtKashtRaqba.Text = sp.KhewatArea;
                this.cbKashtKhewatType.SelectedValue = sp.KhewatTypeId;
                this.txtKashtHisa.Text = sp.FardAreaPart;
                this.txtKashtHisaBata.Text = sp.FardBata;
                this.txtFbMushteriFareeqId.Text = "-1";
            }
            catch (Exception ex)
            {
                //
            }
           
        }

        #endregion

        #region Textbox Kasht hisa bata leave event

        private void txtkashtHisaBata_Pro_Leave(object sender, EventArgs e)
        {
            this.txtKahstHisa_Pro.Text = this.calculateNetPart(this.txtkashtHisaBata_Pro.Text.Trim()).ToString();
            if (txtKahstHisa_Pro.Text.Length > 0)
            {
                string[] Area = cmnFns.CalculatedAreaFromHisa(float.Parse(txtKhatooniHissa.Text.Length > 0 ? txtKhatooniHissa.Text : "0"), float.Parse(txtKahstHisa_Pro.Text), int.Parse(txtKhatooniKanal.Text.Length > 0 ? txtKhatooniKanal.Text : "0"), int.Parse(txtKhatooniMarla.Text.Length > 0 ? txtKhatooniMarla.Text : "0"), float.Parse(txtKhatooniSarsai.Text.Length > 0 ? txtKhatooniSarsai.Text : "0"), float.Parse(txtSFT.Text.Length > 0 ? txtSFT.Text : "0"));
                txtKashtKanal.Text = Area[0] != null ? Area[0] : "0";
                txtKashtMarla.Text = Area[1] != null ? Area[1] : "0";
                txtKashtSarsai.Text = Area[2] != null ? Area[2] : "0";
                txtKashtFeet.Text = Area[3] != null ? Area[3] : "0";
            }
        }

        #endregion

        #region Button Save kasht fb Malik Click Event

        private void btnSaveKashtMalik_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtkashtPersonId.Text.Length > 5 && cbKashtKhewatType.SelectedValue.ToString().Length > 2 && cbKashtKhatooni.SelectedValue.ToString().Length > 5)
                {
                    string FbMushteriFareeqId = txtFbMushteriFareeqId.Text;
                    string kashtHisaBata = txtkashtHisaBata_Pro.Text.Trim() != "" ? txtkashtHisaBata_Pro.Text.Trim() : "0";
                    string kashtHisa = txtKahstHisa_Pro.Text.Trim() != "" ? txtKahstHisa_Pro.Text.Trim() : "0";
                    string kashtKanal = txtKashtKanal.Text.Trim() != "" ? txtKashtKanal.Text.Trim() : "0";
                    string kashtMarla = txtKashtMarla.Text.Trim() != "" ? txtKashtMarla.Text.Trim() : "0";
                    string kashtSarsai = txtKashtSarsai.Text.Trim() != "" ? txtKashtSarsai.Text.Trim() : "0";
                    string kashtFeet = txtKashtFeet.Text.Trim() != "" ? txtKashtFeet.Text.Trim() : "0";
                    if (txtMushteriFareeqId.Text.Length < 5)
                    {
                        txtMushteriFareeqId.Text = rhz.SaveMushteriFareeq(txtMushteriFareeqId.Text, "Fard e Badar", cbKashtKhatooni.SelectedValue.ToString(), txtkashtPersonId.Text, cbKashtKhewatType.SelectedValue.ToString(), kashtHisa, kashtHisaBata, kashtKanal, kashtMarla, kashtSarsai, kashtFeet, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    }
                    string lastId = fardBadarBL.SaveFbMushteriFareeain(FbMushteriFareeqId, txtFbId.Text, txtMushteriFareeqId.Text, cbKashtKhatooni.SelectedValue.ToString(), txtkashtPersonId.Text, "0", cbKashtKhewatType.SelectedValue.ToString(), cbKashtKhewatTypeProposed.SelectedValue.ToString(), kashtHisa, kashtHisa, kashtHisaBata, kashtKanal, kashtMarla, kashtSarsai, kashtFeet, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (lastId != "0")
                    {
                        this.ClearFormControls(gbKashtCurrent);
                        this.ClearFormControls(gbKashtProposed);
                        this.txtFbMushteriFareeqId.Text = "-1";
                        this.txtMushteriFareeqId.Text = "-1";

                        this.FillGridviewMushteriFareeqain();
                    }
                }
                else
                    MessageBox.Show("مشتری کے تمام کوائف پر کریں");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Load Gridview MushteriFareeqain

        private void FillGridviewMushteriFareeqain()
        {
            try
            {
                DataTable dt = fardBadarBL.GetFBMushteriFareeqainByFbId(txtFbId.Text);
                dgMushteriFareeqain.DataSource =dt ;
                dgMushteriFareeqain.Columns["CompleteName"].HeaderText = "نام مالک";
                dgMushteriFareeqain.Columns["KhewatType"].HeaderText = "قسم مالکیت";
                dgMushteriFareeqain.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgMushteriFareeqain.Columns["FardAreaPart_Proposed"].HeaderText = "درست حصہ";
                dgMushteriFareeqain.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                dgMushteriFareeqain.Columns["Mushtri_Area_KMSqft_Proposed"].HeaderText = "درست رقبہ";

                dgMushteriFareeqain.Columns["MushtriFareeqId"].Visible = false;
                dgMushteriFareeqain.Columns["KhatooniId"].Visible = false;
                dgMushteriFareeqain.Columns["PersonId"].Visible = false;
                dgMushteriFareeqain.Columns["KhewatTypeId"].Visible = false;
                dgMushteriFareeqain.Columns["KhewatTypeIdProposed"].Visible = false;
                dgMushteriFareeqain.Columns["Farad_Kanal_Proposed"].Visible = false;
                dgMushteriFareeqain.Columns["Fard_Marla_Proposed"].Visible = false;
                dgMushteriFareeqain.Columns["Fard_Sarsai_Proposed"].Visible = false;
                dgMushteriFareeqain.Columns["Fard_Feet_Proposed"].Visible = false;
                dgMushteriFareeqain.Columns["FardPart_Bata"].Visible = false;
                dgMushteriFareeqain.Columns["FardPart_Bata_Proposed"].Visible = false;
                dgMushteriFareeqain.Columns["FB_MushteriFareeqId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Gridview FB MushteriFareeqain Cell Click Event

        private void dgMushteriFareeqain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgMushteriFareeqain.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["ColSelMushteri"].Value = 1;
                            txtkashtPersonId.Text = row.Cells["PersonId"].Value.ToString();
                            cbKashtKhatooni.SelectedValue = row.Cells["KhatooniId"].Value.ToString();
                            txtFbMushteriFareeqId.Text = row.Cells["FB_MushteriFareeqId"].Value.ToString();
                            txtMushteriFareeqId.Text = row.Cells["MushtriFareeqId"].Value.ToString();
                            txtKashtHisa.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtKahstHisa_Pro.Text = row.Cells["FardAreaPart_Proposed"].Value.ToString();
                            txtKashtMalikName.Text = row.Cells["CompleteName"].Value.ToString();
                            txtKashtHisaBata.Text = row.Cells["FardPart_Bata"].Value.ToString();
                            txtkashtHisaBata_Pro.Text = row.Cells["FardPart_Bata_Proposed"].Value.ToString();
                            txtKashtKanal.Text = row.Cells["Farad_Kanal_Proposed"].Value.ToString();
                            txtKashtMarla.Text = row.Cells["Fard_Marla_Proposed"].Value.ToString();
                            txtKashtSarsai.Text = row.Cells["Fard_Sarsai_Proposed"].Value.ToString();
                            txtKashtFeet.Text = row.Cells["Fard_Feet_Proposed"].Value.ToString();
                            cbKashtKhewatType.SelectedValue = row.Cells["KhewatTypeId"].Value.ToString();
                            cbKashtKhewatTypeProposed.SelectedValue = row.Cells["KhewatTypeIdProposed"].Value.ToString().Length>2?row.Cells["KhewatTypeIdProposed"].Value:0;
                            // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();

                        }
                        else
                        {
                            row.Cells["ColSelMushteri"].Value = 0;
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

        private void btnDelKashtMalik_Click(object sender, EventArgs e)
        {
            if (txtFbMushteriFareeqId.Text != "-1")
            {
                string fbMushteriFareeqId = txtFbMushteriFareeqId.Text != "" ? txtFbMushteriFareeqId.Text : "0";
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string retVal = fardBadarBL.DeleteFbMushteriFareeq(fbMushteriFareeqId);
                        if (retVal != "0")
                        {
                            MessageBox.Show("مالک خذف ہو گیا ہے", "خذف مکمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.FillGridviewMushteriFareeqain();
                            this.txtFbMushteriFareeqId.Text = "-1";
                            this.txtMushteriFareeqId.Text = "-1";
                            this.txtkashtPersonId.Text = "-1";
                            this.ClearFormControls(gbKashtCurrent);
                            this.ClearFormControls(gbKashtProposed);

                        }
                        else
                        {
                            MessageBox.Show(" مالک خذف نہیں ہو سکا ", "خذف نا مکمل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("خذف کرنے سے پہلے گریڈ میں مالک چنیے", "کوئی مالک نہیں چنا گیا");
        }

        #endregion

        #region Button Delete FB Afrad

        private void btnDelFbFard_Click(object sender, EventArgs e)
        {
            if (txtFBPersonId.Text != "-1")
            {
                string fbPersonId = txtFBPersonId.Text != "" ? txtFBPersonId.Text : "0";
                if (DialogResult.Yes == MessageBox.Show("آپ فرد کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string retVal = fardBadarBL.DeleteFbFard(fbPersonId);
                        if (retVal != "0")
                        {
                            MessageBox.Show("مالک خذف ہو گیا ہے", "خذف مکمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.FillDgFBAfrad();
                            this.txtFBPersonId.Text = "-1";
                            this.SelectedPersonId = "-1";
                            this.txtNIC.Clear();
                            this.txtpersonIdShajra.Text = "-1";
                            this.txtNIC.Clear();
                            this.cbQoam.SelectedValue = 0;
                            this.txtDrustNaam.Clear();
                            this.txtName.Clear();


                        }
                        else
                        {
                            MessageBox.Show(" مالک خذف نہیں ہو سکا ", "خذف نا مکمل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("خذف کرنے سے پہلے گریڈ میں مالک چنیے", "کوئی مالک نہیں چنا گیا");
        }

        #endregion

        #region Combo Khatooni for Meezan change selection event

        private void cmbKhatooniNoMeezan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKhatooniNoMeezan.SelectedValue.ToString()!="0")
            {
                DataTable dt = khatooni.GetKhatooniDetailbyKhatooniId(cmbKhatooniNoMeezan.SelectedValue.ToString());
                if(dt!=null)
                {
                    if(dt.Rows.Count>0)
                    {
                        chkIsBeahShuda.Checked =Convert.ToBoolean(dt.Rows[0]["BeahShud"].ToString());
                        txtKhatooniHissa.Text = dt.Rows[0]["KhatooniHissa"].ToString();
                        this.txtKhatooniDrostHissa.Text= dt.Rows[0]["KhatooniHissa"].ToString();
                        txtKhatooniKanal.Text= dt.Rows[0]["KhatooniKanal"].ToString();
                        txtKhatooniDrostKanal.Text= dt.Rows[0]["KhatooniKanal"].ToString();
                        txtKhatooniMarla.Text= dt.Rows[0]["KhatooniMarla"].ToString();
                        txtKhatooniDrostMarla.Text= dt.Rows[0]["KhatooniMarla"].ToString();
                        txtKhatooniSarsai.Text= dt.Rows[0]["KhatooniSarsai"].ToString();
                        txtKhatooniDrostSarsai.Text= dt.Rows[0]["KhatooniSarsai"].ToString();
                    }
                    else
                    {
                        this.clearKhatooniMeezanControls();
                    }
                }
                else
                {
                    this.clearKhatooniMeezanControls();
                }
            }
            else
            {
                this.clearKhatooniMeezanControls();
            }
        }

        #endregion

        #region Clear Khatooni Meezan Controls
        private void clearKhatooniMeezanControls()
        {
            chkIsBeahShuda.Checked = false;
            chbIsKhatooniMeezanChange.Checked = false;
            this.txtKhatooniHissa.Clear();
            this.txtKhatooniDrostHissa.Clear();
            txtKhatooniKanal.Clear();
            txtKhatooniDrostKanal.Clear();
            txtKhatooniMarla.Clear();
            txtKhatooniDrostMarla.Clear();
            txtKhatooniSarsai.Clear();
            txtKhatooniDrostSarsai.Clear();
        }
        #endregion

        #region Save Khatooni Meezan

        private void btnSaveKhatooniMeezan_Click(object sender, EventArgs e)
        {
            string isKhatooniMeezanChange = "0";
            isKhatooniMeezanChange = chbIsKhatooniMeezanChange.Checked ? "1" : "0";
            string lastId = fardBadarBL.SaveFbKhatooniRegisterProposed(txtFbKhatooniId.Text, txtFbId.Text, cmbKhatooniNoMeezan.SelectedValue.ToString(), cboKhataNo.SelectedValue.ToString(), cmbKhatooniNoMeezan.Text, txtKhatooniHissa.Text, txtKhatooniDrostHissa.Text
                                                         , txtKhatooniKanal.Text, txtKhatooniDrostKanal.Text, txtKhatooniMarla.Text, txtKhatooniDrostMarla.Text, txtKhatooniSarsai.Text, txtKhatooniDrostSarsai.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName, isKhatooniMeezanChange);
            this.clearKhatooniMeezanControls();
            this.FillGridviewKhatooniRegister();

        }

        #endregion

        #region Fill Gridview Khatooni Register Meezan
        private void FillGridviewKhatooniRegister()
        {
            DataTable dt = fardBadarBL.GetFBKhatooniRegisterProposed(this.txtFbId.Text, cboKhataNo.SelectedValue.ToString());
            if (dt != null)
            {
                gridviewKhatooniMeezan.DataSource = dt;
                gridviewKhatooniMeezan.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                gridviewKhatooniMeezan.Columns["KhatooniHissa"].HeaderText = "حصہ";
                gridviewKhatooniMeezan.Columns["KhatooniHissa_Proposed"].HeaderText = "درست حصہ";
                gridviewKhatooniMeezan.Columns["KhatooniKanal"].HeaderText = "کنال";
                gridviewKhatooniMeezan.Columns["KhatooniKanal_Proposed"].HeaderText = "درست کنال";
                gridviewKhatooniMeezan.Columns["KhatooniMarla"].HeaderText = "مرلہ";
                gridviewKhatooniMeezan.Columns["KhatooniMarla_Proposed"].HeaderText = "درست مرلہ";
                gridviewKhatooniMeezan.Columns["KhatooniSarsai"].HeaderText = "سرسائی";
                gridviewKhatooniMeezan.Columns["KhatooniSarsai_Proposed"].HeaderText = "درست سرسائی";
                gridviewKhatooniMeezan.Columns["isApplicableForMeezan"].HeaderText = "حصص، رقبہ میں تبدیلی";
                gridviewKhatooniMeezan.Columns["FB_Id"].Visible = false;
                gridviewKhatooniMeezan.Columns["FB_KhatooniId"].Visible = false;
                gridviewKhatooniMeezan.Columns["KhatooniId"].Visible = false;
            }
        }
        #endregion

        #region Gridview Khatooni Meezan Click

        private void gridviewKhatooniMeezan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (g.SelectedRows.Count > 0)
            {
                txtFbKhatooniId.Text= g.SelectedRows[0].Cells["FB_KhatooniId"].Value.ToString();
                txtKhatooniHissa.Text= g.SelectedRows[0].Cells["KhatooniHissa"].Value.ToString();
                txtKhatooniDrostHissa.Text = g.SelectedRows[0].Cells["KhatooniHissa_Proposed"].Value.ToString();
                txtKhatooniKanal.Text = g.SelectedRows[0].Cells["KhatooniKanal"].Value.ToString();
                txtKhatooniDrostKanal.Text = g.SelectedRows[0].Cells["KhatooniKanal_Proposed"].Value.ToString();
                txtKhatooniMarla.Text = g.SelectedRows[0].Cells["KhatooniMarla"].Value.ToString();
                txtKhatooniDrostMarla.Text = g.SelectedRows[0].Cells["KhatooniMarla_Proposed"].Value.ToString();
                txtKhatooniSarsai.Text = g.SelectedRows[0].Cells["KhatooniSarsai"].Value.ToString();
                txtKhatooniDrostSarsai.Text = g.SelectedRows[0].Cells["KhatooniSarsai_Proposed"].Value.ToString();
                cmbKhatooniNoMeezan.SelectedValue = g.SelectedRows[0].Cells["KhatooniId"].Value.ToString();
                chbIsKhatooniMeezanChange.Checked = Convert.ToBoolean(g.SelectedRows[0].Cells["isApplicableForMeezan"].Value.ToString());
            }
            foreach(DataGridViewRow row in g.Rows)
                {
                if (row.Selected)
                {
                    row.Cells["colSelKhatooni"].Value = 1;
                }
                else
                {
                    row.Cells["colSelKhatooni"].Value = 0;
                }
                 }
        }

        #endregion

        #region Button Delete Khatooni Meezan

        private void btnDelKhatooniMeezan_Click(object sender, EventArgs e)
        {

            if (txtFbKhatooniId.Text != "-1")
            {
                string fbKhatooniId = txtFbKhatooniId.Text != "" ? txtFbKhatooniId.Text : "0";
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی کھتونی کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string retVal = fardBadarBL.DeleteFbKhatooniRegisterProposed(txtFbId.Text , fbKhatooniId);
                        MessageBox.Show("کھتونی خذف ہو گیا ہے", "خذف مکمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.clearKhatooniMeezanControls();
                        this.FillGridviewKhatooniRegister();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("خذف کرنے سے پہلے گریڈ میں مالک چنیے", "کوئی مالک نہیں چنا گیا");
        }

        private void gbKhataRaqba_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        #region Load FB Khatajat
        private void LoadFBKhatajat(string FBId)
        {
            DataTable dt = fardBadarBL.GetFbKhattajatProposed(FBId);
            if (dt != null)
            {
                dgFBKhatajat.DataSource = dt;
                dgFBKhatajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                dgFBKhatajat.Columns["TotalParts"].HeaderText = "کل حصہ";
                dgFBKhatajat.Columns["Khata_Kanal"].HeaderText = "کنال";
                dgFBKhatajat.Columns["Khata_Marla"].HeaderText = "مرلہ";
                dgFBKhatajat.Columns["Khata_Sarsai"].HeaderText = "سرسائی";
                dgFBKhatajat.Columns["FB_ID"].Visible = false;
                dgFBKhatajat.Columns["FB_KhataId"].Visible = false;
                dgFBKhatajat.Columns["FB_RegisterHqDKhataId"].Visible = false;
                dgFBKhatajat.Columns["TotalParts_Proposed"].Visible = false;
                dgFBKhatajat.Columns["Khata_Kanal_Proposed"].Visible = false;
                dgFBKhatajat.Columns["Khata_Marla_Proposed"].Visible = false;
                dgFBKhatajat.Columns["Khata_Sarsai_Proposed"].Visible = false;
                dgFBKhatajat.Columns["Khata_Feet"].Visible = false;
                dgFBKhatajat.Columns["Khata_Feet_Proposed"].Visible = false;
            }
        }

        #endregion

        #region data Gridview Khatajat Click Event

        private void dgFBKhatajat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            ClearDGVs();
            try
            {
                cboKhataNo.SelectedValue = dg.CurrentRow.Cells["FB_RegisterHqDKhataId"].Value.ToString();
                txtKhatatNo.Text = dg.CurrentRow.Cells["KhataNo"].Value.ToString();
                //    //txtMalia.Text = fbKhattaJat.Rows[0]["Malia"].ToString();
                //    //txtKafyat.Text = fbKhattaJat.Rows[0]["Kyfiat"].ToString();

                txtKulHisay.Text = dg.CurrentRow.Cells["TotalParts"].Value.ToString();
                txtDrustKulHissay.Text = dg.CurrentRow.Cells["TotalParts_Proposed"].Value.ToString();
                txtKanal.Text = dg.CurrentRow.Cells["Khata_Kanal"].Value.ToString();
                txtDrustKanal.Text = dg.CurrentRow.Cells["Khata_Kanal_Proposed"].Value.ToString();
                txtMarla.Text = dg.CurrentRow.Cells["Khata_Marla"].Value.ToString();
                txtDrustMarla.Text = dg.CurrentRow.Cells["Khata_Marla_Proposed"].Value.ToString();
                txtSarsai.Text = dg.CurrentRow.Cells["Khata_Sarsai"].Value.ToString();
                txtDrustSarsai.Text = dg.CurrentRow.Cells["Khata_Sarsai_Proposed"].Value.ToString();
                txtFeet.Text = dg.CurrentRow.Cells["Khata_Feet"].Value.ToString();
                txtDrustFeet.Text = dg.CurrentRow.Cells["Khata_Feet_Proposed"].Value.ToString();
                txtFbKhataId.Text = dg.CurrentRow.Cells["FB_KhataId"].Value.ToString();
                foreach (DataGridViewRow row in dg.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["colKhataSel"].Value = 1;
                    }
                    else
                        row.Cells["colKhataSel"].Value = 0;
                }
                // Load Khewat Malkan if any
                //this.khewatMalikanByFB = fardBadarBL.GetKhewatGroupFareeqeinByKhataIdByFbId(txtFbId.Text, cboKhataNo.SelectedValue.ToString());
                //this.FillGridviewMalkan(khewatMalikanByFB);
                //this.txtKhewatFreeqainGroupId.Text = "-1";

                //// load Khassra Details if any

                //this.KhatooniKhassrasAreaDetailsFB = fardBadarBL.GetKhassrajatDetailByFbId(txtFbId.Text, cboKhataNo.SelectedValue.ToString());
                //this.FillGridviewKhassrasByKhatooni(KhatooniKhassrasAreaDetailsFB);

                //// Load Khatoonies By Khata
                //FillKhatoniListbyKhattaId();

                loadFbData(txtFbId.Text);
                FillGridviewMinKhatas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region New Min Khata Button Click Event

        private void btnNewMinKhata_Click(object sender, EventArgs e)
        {

            this.ClearFormControls(gbMinKhataMain);
            txtMinKhataId.Text = "-1";
            string moza = this.cmbMouza.SelectedValue.ToString();
            try
            {
                if (txtKhatatNo.Text.Trim().Length > 1 && txtFbId.Text!="-1" && txtFbId.Text!="")
                {
                    DataTable dt = MinKhataMethods.Proc_Get_Max_Khata_No_By_Moza(moza);
                    foreach (DataRow d in dt.Rows)
                    {
                        int MaxKhataNo = Convert.ToInt32(d["Column1"].ToString());
                        MaxKhataNo = MaxKhataNo + 1;
                        string[] strArr = null;
                        strArr = this.txtKhatatNo.Text.Trim().Split('/');
                        this.txtMinKhataNo.Text = MaxKhataNo + "/" + strArr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save Min Khata Click Event

        private void btnSaveMinKhata_Click(object sender, EventArgs e)
        {
            if (this.cboKhataNo.SelectedValue.ToString().Trim() != "-1" && txtFbId.Text.Trim()!="-1")
            {
                string Registerkid = MinKhataMethods.WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta(txtMinKhataId.Text, cmbMouza.SelectedValue.ToString()+"0001", txtMinKhataNo.Text, "", "", txtMinKhataKulHisa.Text.Trim(), txtMinKhataKanal.Text, txtMinKhataMarla.Text, txtMinKhataSarsai.Text, txtMinKhataSFT.Text, txtMinKhataMalia.Text, txtMinKhataKyfiat.Text,cmbMouza.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), cboKhataNo.SelectedValue.ToString(), "0");
                if (Registerkid != null)
                {
                    this.ClearFormControls(gbMinKhataMain);
                    FillGridviewMinKhatas();
                    this.txtMinKhataId.Text = "-1";
                    
                }
            }
            else
                MessageBox.Show("برائے مہربانی کھاتا ٹیب جا کر مین کھاتے کا انتخاب کریں-", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        #endregion

        #region Fill Gridview Min Khatas List
        private void FillGridviewMinKhatas()
        {
            DataTable dtMinKhatas = new DataTable();
            dtMinKhatas = MinKhataMethods.Proc_Get_Moza_Register_KhataJat_ParentKhataID(cmbMouza.SelectedValue.ToString(), cboKhataNo.SelectedValue.ToString());
            DgMinKhataList.DataSource = dtMinKhatas;
            DgMinKhataList.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            DgMinKhataList.Columns["TotalParts"].HeaderText = "حصہ";
            DgMinKhataList.Columns["Khata_Area"].HeaderText = "رقبہ";
            DgMinKhataList.Columns["Kyfiat"].HeaderText = "کیفیت";
            DgMinKhataList.Columns["RegisterHaqdaranId"].Visible = false;
            DgMinKhataList.Columns["RegisterHqDKhataId"].Visible = false;
            DgMinKhataList.Columns["Kanal"].Visible = false;
            DgMinKhataList.Columns["Marla"].Visible = false;
            DgMinKhataList.Columns["sarsai"].Visible = false;
            DgMinKhataList.Columns["Feet"].Visible = false;
            DgMinKhataList.Columns["Malia"].Visible = false;
            DgMinKhataList.Columns["RegisterHaqdaranNo"].Visible = false;
        }
        #endregion

        #region Gridveiw Min Khata Click Evenet

        private void DgMinKhataList_Click(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            try
            {
                txtMinKhataNo.Text = dg.CurrentRow.Cells["KhataNo"].Value.ToString();
                txtMinKhataKulHisa.Text = dg.CurrentRow.Cells["TotalParts"].Value.ToString();
                txtMinKhataKanal.Text = dg.CurrentRow.Cells["Kanal"].Value.ToString();
                txtMinKhataMarla.Text = dg.CurrentRow.Cells["Marla"].Value.ToString();
                txtMinKhataSarsai.Text = dg.CurrentRow.Cells["sarsai"].Value.ToString();
                txtMinKhataSFT.Text = dg.CurrentRow.Cells["Feet"].Value.ToString();
                txtMinKhataId.Text = dg.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString();
                txtMinKhataMalia.Text = dg.CurrentRow.Cells["Malia"].Value.ToString();
                txtMinKhataKyfiat.Text = dg.CurrentRow.Cells["Kyfiat"].Value.ToString();
                //dg.CurrentRow.Cells[0].Value = 1;
                DataTable dtMalkan = this.MinKhataMethods.Proc_Get_KhewatFareeqeinByKhataId(txtMinKhataId.Text);
                dvMinKhataMalkan = new DataView(dtMalkan);
                FillGridViewMinKhataMalkan(dvMinKhataMalkan);
                FillGridKhatooniChange();
                Fillkhatoniforkhasra();
                AutoComplete oc = new AutoComplete();
                oc.FillCombo("proc_Get_AreaTypes " + UsersManagments._Tehsilid.ToString(), cmbMinKhewattypes, "AreaType", "AreaTypeId");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Delete Min Khata 
  
        private void btnDelMinKhata_Click(object sender, EventArgs e)
        {
            try
            {

                if (DialogResult.Yes == MessageBox.Show("کیا آپ من کھاتہ حذف کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo))
                {
                    if (txtMinKhataId.Text != "-1")
                    {
                        MinKhataMethods.DeleteRegisterHaqdaranKhattaByKhataId(this.txtMinKhataId.Text);
                        ClearFormControls(gbMinKhataMain);
                        txtMinKhataId.Text = "-1";
                        FillGridviewMinKhatas();
                    }
                }
                  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        #endregion

        #region Get Min Khata Malkan from Current Khata

        private void btnMalkanFromCurrentKhata_Click(object sender, EventArgs e)
        {
            frmIntiqalMalkanManderjaKhata malkan = new frmIntiqalMalkanManderjaKhata();
            malkan.FormClosed -= new FormClosedEventHandler(malkan_FormClosed);
            malkan.FormClosed += new FormClosedEventHandler(malkan_FormClosed);
            malkan.KhataId = txtMinKhataId.Text;
            malkan.MozaId = Convert.ToInt32(cmbMouza.SelectedValue);
            malkan.ShowDialog();
        }

        void malkan_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataTable dtMalkan = this.MinKhataMethods.Proc_Get_KhewatFareeqeinByKhataId(txtMinKhataId.Text);
            dvMinKhataMalkan = new DataView(dtMalkan);
            FillGridViewMinKhataMalkan(dvMinKhataMalkan);
        }

        #endregion

        #region Fill Gridview Min Khata Malkan 

        private void FillGridViewMinKhataMalkan(DataView dv)
        {

            dgMinKhataMalkan.DataSource = dv;
            dgMinKhataMalkan.Columns["PersonName"].DisplayIndex = 2;
            dgMinKhataMalkan.Columns["Khewat_Area"].DisplayIndex = 5;
            dgMinKhataMalkan.Columns["KhewatType"].DisplayIndex = 3;
            dgMinKhataMalkan.Columns["FardAreaPart"].DisplayIndex = 4;
            dgMinKhataMalkan.Columns["seqno"].DisplayIndex = 1;
            dgMinKhataMalkan.Columns["PersonName"].HeaderText = "نام مالک";
            dgMinKhataMalkan.Columns["KhewatType"].HeaderText = "قسم ملکیت";
            dgMinKhataMalkan.Columns["Khewat_Area"].HeaderText = "رقبہ";
            dgMinKhataMalkan.Columns["seqno"].HeaderText = "نمبر شمار";
            dgMinKhataMalkan.Columns["FardAreaPart"].HeaderText = "حصہ";
            dgMinKhataMalkan.Columns["KhewatGroupFareeqId"].Visible = false;
            dgMinKhataMalkan.Columns["KhewatGroupId"].Visible = false;
            dgMinKhataMalkan.Columns["PersonId"].Visible = false;
            dgMinKhataMalkan.Columns["KhewatTypeId"].Visible = false;
            dgMinKhataMalkan.Columns["DarNo"].Visible = false;
            dgMinKhataMalkan.Columns["TotalDarPart"].Visible = false;
            dgMinKhataMalkan.Columns["FardPart_Bata"].Visible = false;
            dgMinKhataMalkan.Columns["CNIC"].Visible = false;
            dgMinKhataMalkan.Columns["PersonDarPart"].Visible = false;
            dgMinKhataMalkan.Columns["PersonNetPart"].Visible = false;
            dgMinKhataMalkan.Columns["OfDarPart"].Visible = false;
        }
        #endregion

        #region Serach Min Khata Malkan

        private void txtSearchMalik_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchMalik.Text.Trim();
            dvMinKhataMalkan.RowFilter = "PersonName LIKE '%" + filter + "%'";
            FillGridViewMinKhataMalkan(dvMinKhataMalkan);
        }

        #endregion

        #region Button New Malik Select 
    
        private void btnNewMinMalik_Click(object sender, EventArgs e)
        {
            frmSearchPerson SearchMalik = new frmSearchPerson();
            SearchMalik.MozaId = cmbMouza.SelectedValue.ToString();
            SearchMalik.FormClosed -= new FormClosedEventHandler(SearchMalik_FormClosed);
            SearchMalik.FormClosed += new FormClosedEventHandler(SearchMalik_FormClosed);
            SearchMalik.ShowDialog();
        }

        void SearchMalik_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson ap = sender as frmSearchPerson;
            this.txtMinMalikPersonId.Text = ap.PersonId.ToString();
            this.txtMinMalkinName.Text = ap.PersonName;
        }
        
        #endregion

        #region Button Save Min Khata Malik

        private void btnSaveMinMalik_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMinKhataSarsai.Text.Trim() != "" && txtMinKhataMarla.Text.Trim() != "" && txtMinKhataKanal.Text.Trim() != "" && cboKhewatType.SelectedValue.ToString()!="0")
                {
                    string khewatgroupid = "0";
                    string personid = txtMinMalikPersonId.Text;
                    string fardsarsai = txtMinKhataSarsai.Text.Trim() == "" ? "0" : txtMinKhataSarsai.Text.Trim();// row.Cells["FardAreaPart"].Value.ToString() != "" ? float.Parse(row.Cells["FardAreaPart"].Value.ToString()) : 0;
                    //MessageBox.Show(float.Parse("3.25"));
                    float fardfeet = txtMinKhataSFT.Text.Trim() == "" ? float.Parse(fardsarsai) * float.Parse("30.25") : float.Parse(txtMinKhataSFT.Text);// fardsarsai > 0 ? fardsarsai * float.Parse("30.25") : float.Parse("0.0");
                    string s = MinKhataMethods.WEB_SP_INSERT_KhewatGroupFareeqein(txtKhewatGroupFareeqId.Text, khewatgroupid, personid, txtMinMalikHissa.Text, txtMinMalikkanal.Text, txtMinMalikMarla.Text, fardsarsai, fardfeet.ToString(), cboKhewatType.SelectedValue.ToString(), txtMinKhataId.Text, UsersManagments.UserId.ToString(), "0", "0", "0", "0", " ", "0").ToString();
                    if (s.Length>1)
                    {
                        DataTable dtMalkan = this.MinKhataMethods.Proc_Get_KhewatFareeqeinByKhataId(txtMinKhataId.Text);
                        dvMinKhataMalkan = new DataView(dtMalkan);
                        FillGridViewMinKhataMalkan(dvMinKhataMalkan);
                        ClearFormControls(gbMinKhataMalkan);
                        txtKhewatGroupFareeqId.Text = "-1";
                        txtMinMalikPersonId.Text = "-1";
                    }
                }
                else
                    MessageBox.Show("مالک کے تمام کوائف پر کریں");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Combo Box By khewat Types

        public void Fill_ComboKhewatTypes()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = MinKhataMethods.GetKhewatTypes(UsersManagments._Tehsilid.ToString());

                DataRow TypeRow = dt.NewRow();
                TypeRow["KhewatTypeId"] = "0";
                TypeRow["KhewatType"] = " - انتخاب مالک - ";
                dt.Rows.InsertAt(TypeRow, 0);
                cboKhewatType.DataSource = dt;
                cboKhewatType.DisplayMember = "KhewatType";
                cboKhewatType.ValueMember = "KhewatTypeId";
                cboKhewatType.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Button Delete Min Khata Malik
        
       
        private void btnDelMalik_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhewatGroupFareeqId.Text != "-1")
                {
                    if (DialogResult.Yes == MessageBox.Show("کیا آپ من کھاتہ حذف کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo))
                    {
                        MinKhataMethods.WEB_SP_DELETE_KhewatGroupFareeqein(txtKhewatGroupFareeqId.Text);
                        DataTable dtMalkan = this.MinKhataMethods.Proc_Get_KhewatFareeqeinByKhataId(txtMinKhataId.Text);
                        dvMinKhataMalkan = new DataView(dtMalkan);
                        FillGridViewMinKhataMalkan(dvMinKhataMalkan);
                        ClearFormControls(gbMinKhataMalkan);
                        txtKhewatGroupFareeqId.Text = "-1";
                        txtMinMalikPersonId.Text = "-1";
                    }
                }
                else
                    MessageBox.Show("مالک کا انتخاب کریں۔");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Grdview Min Khata Malkan Click Event

        private void dgMinKhataMalkan_Click(object sender, EventArgs e)
        {
            DataGridView g = sender as DataGridView;
            float ksarsai = 0;
            txtKhewatGroupFareeqId.Text = g.CurrentRow.Cells["KhewatGroupFareeqId"].Value.ToString();
            this.txtMinMalkinName.Text = g.CurrentRow.Cells["PersonName"].Value.ToString();
            this.txtMinMalikHissa.Text = g.CurrentRow.Cells["FardAreaPart"].Value.ToString();
            string IntiqalRaqba = g.CurrentRow.Cells["Khewat_Area"].Value.ToString();
            txtMinMalikPersonId.Text = g.CurrentRow.Cells["PersonId"].Value.ToString();
            cboKhewatType.SelectedValue = Convert.ToInt32(g.CurrentRow.Cells["KhewatTypeId"].Value.ToString());
            string[] raqbaSplit = IntiqalRaqba.Split('-');
            int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0; ///seller Kanal
            int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0; ///seller Marla
            float kfeet = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0;
            txtMinMalikSFT.Text = kfeet.ToString();
            txtMinMalikMarla.Text = kmarla.ToString();
            txtMinMalikkanal.Text = kkanal.ToString();
            if (kfeet > 0)
            {
                ksarsai = (float)(kfeet / 30.25);

            }
            txtMinMalikSarsai.Text = Math.Round(ksarsai, 3).ToString();
        }

        #endregion

        #region Button Save Min Khatoonies from Current Khata

        private void btnGetKhatooni_Click(object sender, EventArgs e)
        {
            if (txtMinKhataId.Text != "-1")
            {
                try
                {
                    AL.frmNewKhatooniAdd frmKhatooni = new AL.frmNewKhatooniAdd();
                    frmKhatooni.RegisterHaqKhataID = cboKhataNo.SelectedValue.ToString();
                    frmKhatooni.MinKhataId = txtMinKhataId.Text;
                    frmKhatooni.byKhta = true;
                    frmKhatooni.FormClosed -= new FormClosedEventHandler(frmKhatooni_FormClosed);
                    frmKhatooni.FormClosed += new FormClosedEventHandler(frmKhatooni_FormClosed);
                    frmKhatooni.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("کھاتہ نمبر کا انتخاب کریں", "", MessageBoxButtons.OK);
            }
        }
        void frmKhatooni_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGridKhatooniChange();
        }

        #endregion

        #region Get Khatooni Data by Khata

        public void FillGridKhatooniChange()
        {
            try
            {
                DataTable dt = MinKhataMethods.Proc_Get_Khatoonis(txtMinKhataId.Text);
                grdGetkhatonichange.DataSource = dt;
                grdGetkhatonichange.Columns["KhatooniId"].Visible = false;
                grdGetkhatonichange.Columns["RegisterHqDKhataId"].Visible = false;
                grdGetkhatonichange.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdGetkhatonichange.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "تفصیل حصہ داران وکاشتکاران";
                grdGetkhatonichange.Columns["KhatooniLagan"].HeaderText = "لگان";
                grdGetkhatonichange.Columns["Wasail_e_Abpashi"].HeaderText = "وسایل آبپاشی";
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Gridview Min Khatooni Click

        private void grdGetkhatonichange_Click(object sender, EventArgs e)
        {
            try
            {

                txtabbpashi.Text = grdGetkhatonichange.CurrentRow.Cells["Wasail_e_Abpashi"].Value.ToString();
                this.txttafsel.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
                this.txtlagan.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniLagan"].Value.ToString();
                this.txtKhatooninumchagee.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniNo"].Value.ToString();
                this.txtMinKhatooniId.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save Khatooni Event

        private void btnSaveKhatonichagne_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhatooninumchagee.Text.Trim() != "" && txttafsel.Text.Trim() != "")
                {
                    string khatoniid = this.MinKhataMethods.WEB_SP_INSERT_KhatooniRegister(txtMinKhatooniId.Text, txtKhatooninumchagee.Text, txttafsel.Text, txtMinKhataId.Text, txtabbpashi.Text, txtlagan.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                    if (khatoniid != null)
                    {
                        txtMinKhatooniId.Text = khatoniid;
                        ClearFormControls(gbMinKhatooni);
                        txtMinKhatooniId.Text = "-1";
                        FillGridKhatooniChange();
                    }
                }
                else
                    MessageBox.Show("کھتونی نمبر اور کاشتکاران تفصیل کا اندراج کریں۔");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Delete Min Khatooni 

        private void btnDeleteKhatoonichange_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMinKhatooniId.Text != "-1")
                {
                    if (DialogResult.Yes == MessageBox.Show("کیا آپ من کھتونی حذف کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo))
                    {
                        MinKhataMethods.WEB_SP_DELETE_KhatooniRegister(txtMinKhatooniId.Text);
                        FillGridKhatooniChange();
                        ClearFormControls(gbMinKhatooni);
                        txtMinKhatooniId.Text = "-1";
                    }
                }
                else
                    MessageBox.Show("کھتونی کا انتخاب کریں۔");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button New Min Khatooni Click

        private void btnNewMinKhatooni_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFormControls(gbMinKhatooni);
                this.txtMinKhatooniId.Text = "-1";
                DataTable dt = MinKhataMethods.Proc_Get_Max_Khatooni_No_By_Moza(cmbMouza.SelectedValue.ToString());
                foreach (DataRow d in dt.Rows)
                {
                    int kata = Convert.ToInt32(d["NewKhatooniNo"].ToString());
                    kata = kata + 1;
                    this.txtKhatooninumchagee.Text = kata.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Mushteryan fom current khata Khatooni

        private void btnMusheryanFromKhatooni_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMinKhatooniId.Text != "-1")
                {
                    frmKhatooniMushteryanFromKhatooni frmMushteryan = new frmKhatooniMushteryanFromKhatooni();
                    frmMushteryan.NewKhatooniId = Convert.ToInt32(txtMinKhatooniId.Text);
                    frmMushteryan.MozaId = cmbMouza.SelectedValue.ToString();
                    frmMushteryan.FormClosed -= new FormClosedEventHandler(frmMushteryan_FormClosed);
                    frmMushteryan.FormClosed += new FormClosedEventHandler(frmMushteryan_FormClosed);
                    frmMushteryan.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void frmMushteryan_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }

        #endregion

        #region Get Khatooni For Khassrajat Drop Down

        public void Fillkhatoniforkhasra()
        {
            AutoComplete on = new AutoComplete();
            on.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + txtMinKhataId.Text + "", this.cmbkhatoonisnew, "KhatooniNo", "KhatooniId");

        }
        #endregion

        #region  Button Min Khatooni Khassras from current khata

        private void btnMinKhatooniKhassras_Click(object sender, EventArgs e)
        {

            if (cmbkhatoonisnew.SelectedValue.ToString()!="0")
            {
                try
                {
                    AL.frmNewKhasrajat frmNewKhasra = new AL.frmNewKhasrajat();
                    frmNewKhasra.KhataId = cboKhataNo.SelectedValue.ToString();
                    frmNewKhasra.khatoniid = cmbkhatoonisnew.SelectedValue.ToString();
                    frmNewKhasra.RegisterhaqkhataId = cboKhataNo.SelectedValue.ToString();
                    frmNewKhasra.byKhata = true;
                    frmNewKhasra.FormClosed -= new FormClosedEventHandler(frmNewKhasra_FormClosed);
                    frmNewKhasra.FormClosed += new FormClosedEventHandler(frmNewKhasra_FormClosed);
                    frmNewKhasra.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("کھتونی کا انتخاب کریں", "", MessageBoxButtons.OK);
            }
        }
        void frmNewKhasra_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillKhasraJatNew();
            //getkhasrajatbykhatoni();
        }
        #region Fill New Khassrajat

        public void FillKhasraJatNew()
        {
            string khatooniid = cmbkhatoonisnew.SelectedValue.ToString();
            DataTable dt = MinKhataMethods.Proc_Get_KhatooniKhassraDetail(khatooniid.ToString());
            if (dt != null)
            {
                this.dgMinKhataKhassraJat.DataSource = dt;

                dgMinKhataKhassraJat.Columns["KhassraDetailId"].Visible = false;
                dgMinKhataKhassraJat.Columns["AreaTypeId"].Visible = false;
                dgMinKhataKhassraJat.Columns["KhatooniId"].Visible = false;
                dgMinKhataKhassraJat.Columns["KhassraId"].Visible = false;
                dgMinKhataKhassraJat.Columns["Feet"].Visible = false;
                dgMinKhataKhassraJat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                dgMinKhataKhassraJat.Columns["AreaType"].HeaderText = "قسم زمین";
                dgMinKhataKhassraJat.Columns["Kanal"].HeaderText = "کنال";
                dgMinKhataKhassraJat.Columns["Marla"].HeaderText = "مرلہ";
                dgMinKhataKhassraJat.Columns["Sarsai"].HeaderText = "سرسائی";
            }
        }

        #endregion

        #region Gridview Min khata Khassrajat click

        private void dgMinKhataKhassraJat_Click(object sender, EventArgs e)
        {
            DataGridView g = sender as DataGridView;
            try
            {
                if (g.Rows.Count > 0)
                {
                    txtMinKhassraId.Text= g.CurrentRow.Cells["KhassraId"].Value.ToString();
                    // g.CurrentRow.Cells["KhatooniId"].Value.ToString();
                    this.txt_kanal_Khasra.Text = g.CurrentRow.Cells["Kanal"].Value.ToString();
                    this.txt_Marala_Khasra.Text = g.CurrentRow.Cells["Marla"].Value.ToString();
                    this.txtMinKhassraNo.Text = g.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txtMinKhassraDetailId.Text = g.CurrentRow.Cells["KhassraDetailId"].Value.ToString();
                    this.txt_Sarsai_Khasra.Text = g.CurrentRow.Cells["Sarsai"].Value.ToString();
                    this.txt_Feet_Khasra.Text = g.CurrentRow.Cells["Feet"].Value.ToString();
                    cmbMinKhewattypes.SelectedValue = Convert.ToInt32(g.CurrentRow.Cells["AreaTypeId"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void cmbkhatoonisnew_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillKhasraJatNew();
        }


        #endregion

        #region Button Save Min Khassra

        private void btnSaveMinKhassra_Click(object sender, EventArgs e)
        {
            string KhassrDetailId=MinKhataMethods.WEB_SP_INSERT_KhassraRegisterDetail(txtMinKhassraDetailId.Text, txtMinKhassraId.Text, cmbMinKhewattypes.SelectedValue.ToString(), txt_kanal_Khasra.Text, txt_Marala_Khasra.Text, txt_Sarsai_Khasra.Text, txt_Feet_Khasra.Text, UsersManagments.UserId.ToString());
            FillKhasraJatNew();
            ClearFormControls(gbMinKhataKhassras);
            txtMinKhassraDetailId.Text = "-1";
            txtMinKhassraId.Text = "-1";
        }

        #endregion

        #region Button New Min Khassra and Delete Min Khassra Click

        private void btnNewMinKhassra_Click(object sender, EventArgs e)
        {
            ClearFormControls(gbMinKhataKhassras);
            txtMinKhassraDetailId.Text = "-1";
            txtMinKhassraId.Text = "-1";
        }

        private void btnDelMinKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("کیا آپ من کھتونی حذف کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo))
                {
                    if (this.txtMinKhassraDetailId.Text != "-1")
                    {
                        MinKhataMethods.WEB_SP_DELETE_KhassraRegisterDetail_Direct(this.txtMinKhassraDetailId.Text);
                        FillKhasraJatNew();
                        ClearFormControls(gbMinKhataKhassras);
                        txtMinKhassraDetailId.Text = "-1";
                        txtMinKhassraId.Text = "-1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void gridViewKhassraAreaDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgMinKhataMalkan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHissaRaqba_Click(object sender, EventArgs e)
        {
            if (txtDrustHissa.Text.Length > 0)
            {
                string[] Area = cmnFns.CalculatedAreaFromHisa(float.Parse(txtKulHisay.Text), float.Parse(txtDrustHissa.Text), Convert.ToInt32(txtKanal.Text), Convert.ToInt32(txtMarla.Text), float.Parse(txtSarsai.Text != "" ? txtSarsai.Text : "0"), float.Parse(txtFeet.Text != "" ? txtFeet.Text : "0"));
                txtDrustPersonKanal.Text = Area[0] != null ? Area[0].ToString() : "0";
                txtDrustPersonMarla.Text = Area[1] != null ? Area[1].ToString() : "0";
                txtDrustPersonSarsai.Text = Area[2] != null ? Area[2].ToString() : "0";
                txtDrustPersonFeet.Text = Area[3] != null ? Area[3].ToString() : "0";
            }
        }

        private void btnNewMushteri_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchPerson searchMushteri = new frmSearchPerson();
                searchMushteri.MozaId = cmbMouza.SelectedValue.ToString();
                searchMushteri.FormClosed -= new FormClosedEventHandler(searchMushteri_FormClosed);
                searchMushteri.FormClosed += new FormClosedEventHandler(searchMushteri_FormClosed);
                searchMushteri.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void searchMushteri_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson searchp = sender as frmSearchPerson;
            this.txtkashtPersonId.Text = searchp.PersonId.ToString();
            //this.txtPersonIdProposed.Text = txtPersonId.Text;
            this.txtKashtMalikName.Text = searchp.PersonName;
            this.txtFbMushteriFareeqId.Text = "-1";
            this.txtMushteriFareeqId.Text = "-1";


        }

        private void btnShowScanImg_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString().Length > 3 && txtFardBadarDocNO.Text.Length > 0)
            {
                string url = @"https://kplr.gkp.pk:5002/Images?mozaId=" + cmbMouza.SelectedValue.ToString() + "&documentTypeId=13&recordNo=" + txtFardBadarDocNO.Text;
                //System.Diagnostics.Process.Start(url);
                //frmDocumentImageViewer iv = new frmDocumentImageViewer();
                //iv.url = url;
                //iv.ShowDialog();
                frmImageViewerBrowser iv = new frmImageViewerBrowser();
                iv.url = url;
                iv.Show();
            }
            else
                MessageBox.Show("موضع اور انتقال نمبر درج کرکے سکین دستاویز دیکھئے۔");
        }

        private void btnUploadDoc_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString().Length > 3 && txtFardBadarDocNO.Text.Length > 0)
            {
                OpenFileDialog openFD = new OpenFileDialog();
                openFD.Filter = "Bitmaps|*.bmp|JPEG|*.jpg|PNG|*.png|Tiff|*.tiff";
                openFD.Multiselect = true;
                openFD.Title = " دستاویز کا انتخاب اور اپلوڈ";
                string message = "";
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    int imageNo = 1;
                    DataTable dtFiles = fi.GetFileIndexingFileNameByDocNo(cmbMouza.SelectedValue.ToString(), "13", txtFardBadarDocNO.Text.Split('/').First());
                    if (dtFiles != null)
                        if (dtFiles.Rows.Count > 0)
                            imageNo = dtFiles.Rows.Count+1;
                    
                    foreach (String file in openFD.FileNames)
                    {
                        string path = file; //Path.GetDirectoryName(openFD.FileName)+"/"+file;
                        string FardBadarNo = txtFardBadarDocNO.Text.Split('/').First();
                        
                         message = fi.UploadFileToServer(@path, "https://kplr.gkp.pk:5002/Images/Uploads", Convert.ToInt32(cmbMouza.SelectedValue.ToString()), 13, Convert.ToInt32(FardBadarNo), imageNo, DateTime.Parse(DateTime.Now.ToShortDateString()));
                        imageNo = imageNo + 1;
                        //I want to get the directory path Picturebox.Imagelocation is not working for me
                    }
                    MessageBox.Show(message.Length > 1 ? message : "مطلوبہ دستاویزات اپلوڈ ہو گئے ہیں۔");
                }
                
             }
        }

        private void btnFbRevert_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ فرد بدر عمل ری ورٹ کرنا چاہتے ہے؟", "ری ورٹ کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                   string msg= fardBadarBL.RevertFardBadar(txtFbId.Text, UsersManagments.UserId, UsersManagments.UserName);
                   MessageBox.Show(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
