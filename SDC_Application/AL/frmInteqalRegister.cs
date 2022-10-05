using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using LandInfo.Client.LandServiceProxy;
//using LandInfo.Client.AmalDaramdProxy;
//using LandInfo.Client.Classes;
using System.IO;

namespace LandInfo.Client
{
    public partial class frmInteqalRegister : Form
    {
        #region class variables

        //ClientServiceClient client = new ClientServiceClient();
        //List<Proc_Get_IntiqalTypeCategoroies_Result> intCategories = new List<Proc_Get_IntiqalTypeCategoroies_Result>();
        //List<proc_Intiqal_Type_List_Result> inteqalTypes = new List<proc_Intiqal_Type_List_Result>();
        //List<proc_Get_PersonChilds_Result> personChild = new List<proc_Get_PersonChilds_Result>();
        //List<proc_Get_Intiqal_Main_By_MozaId_Result> IntiqalMainByMozaList = new List<proc_Get_Intiqal_Main_By_MozaId_Result>();
        //string inteqalType = "";
        //LanguageManager.LanguageConverter Lang = new LanguageManager.LanguageConverter();

        #region properties

        public int inteqalCatId { get; set; }
        public int inteqaltypeid { get; set; }

        public string KhassraTatimaNo { get; set; }

        public string IntiqalKhattaRecId { get; set; }
        public string IntiqalType { get; set; }

        #endregion

        #endregion

        #region deault constructor
        /// <summary>
        /// form Load Event
        /// </summary>
        public frmInteqalRegister()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize Reocrds
        /// <summary>
        /// Fills fee types drop down
        /// </summary>
        private void FillFeesTypes()
        {
            //this.IntiqalFeeTypeBindingSource.DataSource = client.GetIntiqalFeesTypes();
            //this.cboFeeType.SelectedIndex = -1;
        }

        /// <summary>
        /// Fills Moza drop down list
        /// </summary>
        private void FillMozaList()
        {
            //this.MozaBindingSource.DataSource = client.GetAllMozaList();
            //this.cboMoza.SelectedIndex = -1;
        }
        /// <summary>
        /// Fills owners/Malikan types drop down
        /// </summary>
        private void FillMalikanTypeDropDown()
        {
            //List<Proc_Get_MalkanTypes_Result> malikantypes = client.GetMalikanTypes().ToList();
            //this.cboKhewatType.DataSource = malikantypes.ToList();
            //this.cboKhewatType.DisplayMember = "KhewatType";
            //this.cboKhewatType.ValueMember = "KhewatTypeId";
            //this.cboKhewatType.SelectedIndex = -1;
        }
        #endregion

        #region Properties
        /// <summary>
        /// get or set inteqal id
        /// </summary>
        public int IntiqalId { get; set; }
        /// <summary>
        /// get or set entry mode
        /// </summary>
        public int EntryMode { get; set; }
        /// <summary>
        /// get or set Moza id
        /// </summary>
        public int MozaId { get; set; }

        public int S_Kanal { get; set; }

        public int S_Marla { get; set; }

        public float S_Sarsai { get; set; }

        public float S_Sft { get; set; }

        public bool IntiqalStatus { get; set; }

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
                this.lblMozaName.Text = value;
            }
        }

        #endregion

        #region Form Load Event

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInteqalRegister_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            ////FillMozaList();
            //FillFeesTypes();
            //FillMalikanTypeDropDown();
            //SplitContainerMain.Panel2.Enabled = true;
            //isMozaSet();
            ////this.intCategories = client.GetInteqalTypesCategoriesList().ToList();
            //this.inteqalTypes = client.GetIntiqalTypes().ToList();

            ////Load Combo for New Inteqal Entry tabs
            //this.GetIntiqalInitiationBindingSource.DataSource = client.GetIntiqalInitiationList();
            //this.cboIntiqalInitiation.SelectedIndex = -1;
            //this.GetintiqalTypeBindingSource.DataSource = client.GetIntiqalTypes();
            //this.cboIntiqalType.SelectedIndex = -1;

            //this.procGetAreaTypesListResultBindingSource.DataSource = client.GetAreaTypesList();
            //this.cboQismArazi.SelectedIndex = -1;
            //this.txtIntiqalId.Text = "-1";
            //if (this.EntryMode == 1)
            //{
            //    //Entry Mode 1 represents New Intiqal
            //}
            //else
            //{
            //    // Entry Mode 2 Represents ModifyIntiqal
            //    FillIntiqalByIntiqalId();
            //}
            //this.TabControlInteqalDetails.TabPages[2].Hide();
            //this.TabControlInteqalDetails.TabPages[3].Hide();

        }
        #region Fill Inteqal by Inteqal Id

        /// <summary>
        /// Gets main inteqal record by inteqal id and fills inteqal controls
        /// </summary>
        private void FillIntiqalByIntiqalId()
        {
            //List<proc_Get_Intiqal_Main_Result> Intiqals = client.GetIntiqalMainByIntiqalId(this.IntiqalId).ToList();
            //foreach (var data in Intiqals.Take(1).ToList())
            //{
            //    // cboMoza.SelectedValue = Convert.ToInt32(data.MozaId.ToString());
            //    //checkBoxKhanaMalkiat.Checked = data.IntiqalKhanaMalkiat.Value;
            //    //checkBoxKhanaKasht.Checked = data.IntiqalKhanaKasht.Value;
            //    txtIntiqalNo.Text = data.IntiqalNo.ToString();
            //    dtpIntiqalAndrajDate.Value = data.IntiqalAndrajDate;
            //    dtpIntiqalAmaldramadDate.Value = data.IntiqalAmaldramadDate;
            //    dtpTasdiq.Value = data.IntiqalAttestationDate;
            //    cboIntiqalType.SelectedValue = data.IntiqalTypeId;
            //    cboIntiqalInitiation.SelectedValue = data.IntiqalInitiationId;
            //    txtHawalaNo.Text = data.IntiqalHawalaNo.ToString();
            //    txtLandValue.Text = data.LandValue.ToString();
            //    txtIntiqalRapatNo.Text = data.IntiqalRapatNo;
            //    dtpIntiqalRapatDate.Value = data.IntiqalRapatDate;
            //    dtpTasdiq.Value = data.IntiqalAttestationDate;
            //    dtDegreeDate.Value = data.DegreeDate;
            //    this.IntiqalType = data.IntiqalType;
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
        }

        #endregion

        #endregion

        #region New Inteqal Button Click Event

        /// <summary>
        /// call method for opening of new inteqal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewInteqal_Click(object sender, EventArgs e)
        {
            ////this.OpenNewIntiqalForm(1 , -1);
            //this.EntryMode = 1;
            //this.IntiqalId = -1;
            //this.txtIntiqalNo.Clear();
            //this.txtIntiqalNo.Focus();
            //this.ClearFormControls(groupBox6);
            //this.ClearFormControls(groupBox5);
            //this.btnNewInteqal.Enabled = false;
            //this.btnCancel.Enabled = true;
            //this.btnSave.Enabled = true;
            //this.btnSave.Visible = true;
            //this.btnDelMain.Visible = true;
            ////this.panel8.Visible = true;
            ////this.panel9.Visible = true;
        }

        #endregion

        #region Custom Methods

        #region Changes Moza selection

        private void linkLabelMoza_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    frmMozaSelection f = new frmMozaSelection();
            //    f.ShowDialog();
            //    if (CurrentUser.MozaId == 0)
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        List<Proc_Get_Moza_Detail_Result> Moza = new List<Proc_Get_Moza_Detail_Result>();
            //        Moza = client.GetMozaDetailByMoza(CurrentUser.MozaId).ToList();
            //        if (Moza != null && Moza.Count > 0)
            //        {
            //            this.txtMozaID.Text = CurrentUser.MozaId.ToString();
            //            this.lblMozaName.Text = CurrentUser.MozaName;
            //            this.lblPC.Text = CurrentUser.PatwarcircleName;
            //            this.FillMozaIntiqalatListByMozaId();
            //        }
            //        else
            //        {
            //            MessageBox.Show("یہ موضع زیر کار ہے۔ ");
            //        }
            //    }
            //    //this.cboKhataNo_SelectionChangeCommitted(sender, e);
            //    //this.kashtkaran = client.GetAfraadListByMozaByTypeByPersonName(CurrentUser.MozaId, 2, "").ToList();
            //    //this.filtered = client.GetAfraadListByMozaByTypeByPersonName(CurrentUser.MozaId, 2, "").ToList();
            //    //this.GetSearchedAfradListBindingSource.DataSource = filtered;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        #region check wether is moza is selected by the user or not
        /// <summary>
        /// Check wether Moza is selected by the user or not
        /// </summary>
        private void isMozaSet()
        {
            //try
            //{
            //    List<Proc_Get_Moza_Detail_Result> Moza = new List<Proc_Get_Moza_Detail_Result>();
            //    if (CurrentUser.MozaId != 0)
            //    {
            //        Moza = client.GetMozaDetailByMoza(CurrentUser.MozaId).ToList();
            //        if (Moza != null && Moza.Count > 0)
            //        {
            //            this.lblMozaName.Text = CurrentUser.MozaName;
            //            this.lblPC.Text = CurrentUser.PatwarcircleName;
            //            this.FillMozaIntiqalatListByMozaId();
            //            //this.txtDistrict.Text = CurrentUser.District;
            //            //this.txtTehsil.Text = CurrentUser.TehsilName;
            //        }
            //        else
            //        {
            //            MessageBox.Show("یہ موضع زیر کار ہے۔ ");
            //        }
            //    }
            //    else
            //    {
            //        frmMozaSelection f = new frmMozaSelection();
            //        f.ShowDialog();
            //        if (CurrentUser.MozaId == 0)
            //        {
            //            //this.Close();
            //        }
            //        else
            //        {
            //            Moza = client.GetMozaDetailByMoza(CurrentUser.MozaId).ToList();
            //            if (Moza != null && Moza.Count > 0)
            //            {
            //                this.txtMozaID.Text = CurrentUser.MozaId.ToString();
            //                this.lblMozaName.Text = CurrentUser.MozaName;
            //                this.lblPC.Text = CurrentUser.PatwarcircleName;
            //                this.FillMozaIntiqalatListByMozaId();
            //            }
            //            else
            //            {
            //                MessageBox.Show("یہ موضع زیر کار ہے۔ ");
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion

        ///// <summary>
        ///// opens up new inteqal and set properties of the new inteqal form for mode and inteqal id.
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="intiqalid"></param>
        //private void OpenNewIntiqalForm(int mode,int intiqalid)
        //{
        //    frmInteqalEntry f = new frmInteqalEntry();
        //    f.EntryMode = mode;
        //    f.IntiqalId = intiqalid;
        //    f.MozaId =CurrentUser.MozaId;
        //    f.MozaName = CurrentUser.MozaName;
        //    if (f.MozaId != 0)
        //    {
        //        f.FormClosed -= new FormClosedEventHandler(f_FormClosed);
        //        f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        //        f.ShowDialog();
        //    }
        //}

        /// <summary>
        /// Fills save inteqalat of the selected moza by reloading the data after daving new inteqal entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.FillMozaIntiqalatListByMozaId();
        }

        /// <summary>
        /// fill grid view of inteqalat for selected moza
        /// </summary>
        private void FillMozaIntiqalatListByMozaId()
        {
            //try
            //{
            //    int mozaid = Convert.ToInt32(CurrentUser.MozaId);
            //    this.GetIntiqalMainByMozaIdBindingSource.DataSource = null;
            //    this.IntiqalMainByMozaList = client.GetIntiqalMainListByMozaId(CurrentUser.MozaId).ToList();

            //    //this.GetIntiqalMainByMozaIdBindingSource.DataSource = client.GetIntiqalMainListByMozaId(mozaid);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        #endregion

        #region Controls Events

        /// <summary>
        /// calls method for filling saved inteqalat into inteqalat grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMoza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //FillMozaIntiqalatListByMozaId();
        }

        /// <summary>
        /// calls method for opening inteqal main form with selected inteqal record to be laoded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyIntiqal_Click(object sender, EventArgs e)
        {
            //int intiqalid = txtIntiqalId.Text.Trim() != "" ? Convert.ToInt32(this.txtIntiqalId.Text.ToString()) : -1;
            //this.IntiqalId = intiqalid;
            //if (intiqalid != -1)
            //{
            //    this.FillIntiqalByIntiqalId();
            //    //this.OpenNewIntiqalForm(2, intiqalid);
            //}
            //else
            //{
            //    MessageBox.Show("تبدیلی کے لیے پہلے گرڈ سے انتقال کا انتخاب کریں");
            //}
        }

        /// <summary>
        /// Calls method for saving khata of the inteqal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveKhatta_Click(object sender, EventArgs e)
        {
            //SaveIntiqalKhata();
            //KhataControlsDisable();
            //btnNewKhatta.Enabled = true;

        }

        /// <summary>
        /// Fills fee, buyers and seller controls and gridview for the selected inteqal record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewInteqalList_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView gr = sender as DataGridView;
            //    txtIntiqalId.Text = gr.SelectedRows[0].Cells[4].Value.ToString();
            //    int IntiqalId = Convert.ToInt32(txtIntiqalId.Text);
            //    int mozaId = CurrentUser.MozaId;
            //    this.GetKhatajatByMozaId.DataSource = client.GetKhataJatForIntiqalByMozaId(mozaId);
            //    this.GetintiqalKhatasByIntiqalidBindingSource.DataSource = client.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
            //    KhataControlsDisable();
            //    FillIntiqalFeeListByIntiqalId();
            //    FillChallanGridByIntiqalId();


            //    SplitContainerMain.Panel2.Enabled = true;
            //    splitContainer1.Panel2.Enabled = true;

            //}
            //catch (Exception ex)
            //{
            //    // MessageBox.Show(ex.Message);
            //}
        }

        /// <summary>
        /// call method for enableing the khata controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewKhatta_Click(object sender, EventArgs e)
        {
            //KhataControlsEnable();
            //txtKhataRecId.Text = "-1";
        }


        #endregion

        #region Custom Methods

        #region Find seller/buyers custom method

        /// <summary>
        /// opens up window/form for searching of person/buyers
        /// </summary>
        /// <param name="typeid"></param>
        private void FindPerson(int typeid)
        {
            //int mozaid = CurrentUser.MozaId;

            //frmSearchPersonAmalDaramad p = new frmSearchPersonAmalDaramad();
            //p.MozaId = mozaid;
            //p.PersonType = typeid;
            //p.FormClosed -= new FormClosedEventHandler(p_FormClosed);
            //p.FormClosed += new FormClosedEventHandler(p_FormClosed);

            //p.ShowDialog();

        }

        #endregion

        #region Search Buyer Custom Method

        /// <summary>
        /// Opens up new window/form for seaching of person
        /// </summary>
        /// <param name="typeid"></param>
        private void FindBuyer(int typeid)
        {
            //int mozaid = CurrentUser.MozaId;

            //frmSearchPersonAmalDaramad buyer = new frmSearchPersonAmalDaramad();
            //buyer.MozaId = mozaid;
            //buyer.PersonType = typeid;
            //buyer.FormClosed -= new FormClosedEventHandler(buyer_FormClosed);
            //buyer.FormClosed += new FormClosedEventHandler(buyer_FormClosed);
            //buyer.ShowDialog();
        }

        #endregion

        /// <summary>
        /// Saves the selected khata for inteqal
        /// </summary>
        private void SaveIntiqalKhata()
        {
            //int KhataRecId = Convert.ToInt32(txtKhataRecId.Text);
            //int khataid = Convert.ToInt32(cbokhataNo.SelectedValue.ToString());
            //int intiqalId = Convert.ToInt32(txtIntiqalId.Text);
            //string LastId = client.SaveIntiqalKhataJaat(KhataRecId, intiqalId, khataid);
            //txtKhataRecId.Text = LastId;
            ////Reload inteqal khattas in gridview
            //int IntiqalId = Convert.ToInt32(txtIntiqalId.Text);
            ////int mozaId = CurrentUser.MozaId;
            ////this.GetKhatajatByMozaId.DataSource = client.GetKhataJatForIntiqalByMozaId(mozaId);
            //this.GetintiqalKhatasByIntiqalidBindingSource.DataSource = client.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
        }

        /// <summary>
        /// Saves the seller record and selling information
        /// </summary>
        private void SaveSellerRec()
        {
            //try
            //{
            //    bool sellerNotExits = true;
            //    foreach (DataGridViewRow row in GridSellersList.Rows)
            //    {
            //        if (row.Cells[1].Value.ToString() == this.cboPersonSeller.SelectedValue.ToString())
            //        {
            //            sellerNotExits = false;
            //        }
            //    }
            //    if (sellerNotExits || this.txtIntiqalSellerRecordId.Text != "-1")
            //    {
            //        int intiqalsellerid = Convert.ToInt32(this.txtIntiqalSellerRecordId.Text.ToString());
            //        int intiqalKhataRecId = Convert.ToInt32(txtIntiqalKhataRecId.Text);
            //        int personid = Convert.ToInt32(this.cboPersonSeller.SelectedValue.ToString());
            //        bool persondied = this.chkIsDead.Checked == true ? true : false;
            //        DateTime deathdate = this.chkIsDead.Checked == true ? this.dtpDateOfDeath.Value : Convert.ToDateTime("01/01/1700");
            //        float totalhissay = txtKulHisay.Text.Trim() != "" ? float.Parse(this.txtKulHisay.Text.ToString()) : 0;
            //        int totalkanal = Convert.ToInt32(this.txtKullKanal.Text.ToString());
            //        int totalmarla = Convert.ToInt32(this.txtKullMarla.Text.ToString());
            //        float totalsarsai = this.txtKullSarsai.Text.Trim() != "" ? float.Parse(this.txtKullSarsai.Text.ToString()) : 0;
            //        float totalfeet = 0;
            //        if (totalsarsai > 0 && txtKulFeet.Text.Trim() != "")
            //        {
            //            totalfeet = totalsarsai > 0 ? totalsarsai * float.Parse("30.25") : 0;
            //        }
            //        else
            //        {
            //            totalfeet = float.Parse(txtKulFeet.Text);
            //        }
            //        if (!(totalsarsai > 0) || txtKullSarsai.Text.Trim() == "")
            //        {
            //            totalsarsai = txtKulFeet.Text.Trim() != "" ? float.Parse(txtKulFeet.Text) / float.Parse("30.25") : 0;
            //        }
            //        float soldhissay = float.Parse(this.txtFrokhtHisay.Text.ToString().Trim() != "" ? this.txtFrokhtHisay.Text.ToString().Trim() : "0");
            //        int soldkanal = Convert.ToInt32(this.txtFrokhtKanal.Text.ToString().Trim() != "" ? this.txtFrokhtKanal.Text.ToString().Trim() : "0");
            //        int soldmarla = Convert.ToInt32(this.txtFrokhtMarla.Text.ToString().Trim() != "" ? this.txtFrokhtMarla.Text.ToString().Trim() : "0");
            //        float soldsarsai = txtFrokhtSarsai.Text.Trim() != "" ? float.Parse(this.txtFrokhtSarsai.Text.ToString()) : 0;
            //        float soldfeet = txtFrokhtFeet.Text.Trim() != "" ? float.Parse(txtFrokhtFeet.Text.Trim()) : 0;
            //        int khewatgroupfreeqid = Convert.ToInt32(this.txtKhewatGroupFareeqId.Text.ToString());
            //        //float soldfeet;
            //        //if (txtFrokhtFeet.Text.Trim() == "")
            //        //{
            //        //    soldfeet = soldsarsai > 0 ? soldsarsai * float.Parse("30.25") : 0;
            //        //}
            //        //else
            //        //{
            //        //    soldfeet = txtFrokhtFeet.Text.Trim() != "" ? float.Parse(txtFrokhtFeet.Text.Trim()) : 0;
            //        //}
            //        //if (!(soldsarsai > 0) || txtFrokhtSarsai.Text.Trim() == "")
            //        //{
            //        //    soldsarsai = soldfeet != 0 ? soldfeet / float.Parse("30.25") : 0;
            //        //}
            //        string s = client.SaveIntiqalSellers(intiqalsellerid, intiqalKhataRecId, personid, persondied, deathdate, totalhissay, totalkanal, totalmarla, totalsarsai, totalfeet, soldhissay, soldkanal, soldmarla, soldsarsai, soldfeet, khewatgroupfreeqid).ToString();
            //        this.txtIntiqalSellerRecordId.Text = s;
            //        this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = null;
            //        this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = client.GetIntiqalSellersListByKhataRecId(intiqalKhataRecId);
            //        this.ClearFormControls(groupBoxSeller);
            //        this.btnSaveSeller.Enabled = false;
            //        this.btnNewSeller.Enabled = true;
            //        this.btnModifySeller.Enabled = false;
            //        this.btncancelSeller.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("یہ دہندہ انتقال میں پہلے سے محفو ظ ہو چکا ہے۔");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            ////client.SaveIntiqalSellers(-1, intiqalKhataRecId, personid, persondied, deathdate, totalhissay, totalkanal, totalmarla, totalsarsai, totalfeet, soldhissay, soldkanal, soldmarla, soldsarsai, soldfeet, khewatgroupfreeqid);
        }

        /// <summary>
        /// saves buyers information along with raqba bought
        /// </summary>
        private void SaveIntiqalBuyerRecord()
        {
            //try
            //{
            //    int intiqalBuyerrecid = Convert.ToInt32(this.txtBuyerRecordId.Text.ToString());
            //    int intiqalKhataRecId = Convert.ToInt32(txtIntiqalKhataRecId.Text);
            //    int buyerid = Convert.ToInt32(this.txtBuyerId.Text.ToString());
            //    float buyerhissay = this.txtKharidHisay.Text.ToString() != "" ? float.Parse(this.txtKharidHisay.Text.ToString()) : 0;
            //    int buyerkanal = this.txtKharidKanal.Text.ToString() != "" ? Convert.ToInt32(this.txtKharidKanal.Text.ToString()) : 0;
            //    int buyermarla = this.txtKharidMarla.Text.ToString() != "" ? Convert.ToInt32(this.txtKharidMarla.Text.ToString()) : 0;
            //    float buyersarsai = txtKharidSarsai.Text.Trim() != "" ? float.Parse(this.txtKharidSarsai.Text.ToString()) : 0;
            //    int khewattypeid = this.cboKhewatType.SelectedValue.ToString() != "" ? Convert.ToInt32(this.cboKhewatType.SelectedValue.ToString()) : 0;
            //    float buyerfeet = 0;
            //    if (txtKharidFeet.Text.Trim() == "" || txtKharidFeet.Text.Trim()=="0")
            //    {
            //        buyerfeet = buyersarsai > 0 ? buyersarsai * float.Parse("30.25") : 0;
            //    }
            //    else
            //    {
            //        buyerfeet = txtKharidFeet.Text.Trim() != "" ? float.Parse(txtKharidFeet.Text) : 0;
            //    }
            //    if ((buyersarsai <= 0) || txtKharidSarsai.Text.Trim() == "" || txtKharidSarsai.Text.Trim()=="0")
            //    {
            //        buyersarsai = buyerfeet != 0 ? buyerfeet / float.Parse("30.25") : 0;
            //    }
            //    string s = client.SaveIntiqalBuyers(intiqalBuyerrecid, intiqalKhataRecId, buyerid, buyerhissay, buyerkanal, buyermarla, buyersarsai, buyerfeet, khewattypeid).FirstOrDefault().ToString();
            //    this.txtBuyerRecordId.Text = s;
            //    this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = null;
            //    this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = client.GetIntiqalBuyersByKhataRecordId(intiqalKhataRecId);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        /// <summary>
        /// enables the khata controls for selection of khata
        /// </summary>
        private void KhataControlsEnable()
        {
            //cbokhataNo.Enabled = true;
            //btnSaveKhatta.Enabled = true;
        }

        /// <summary>
        /// disables the khata controls for selection of khata
        /// </summary>
        private void KhataControlsDisable()
        {
            //this.btnSaveKhatta.Enabled = false;
            //this.btnDelIntiqalKhatta.Enabled = false;
            //this.cbokhataNo.Enabled = false;
        }

        #endregion

        #region Gridview Inteqallat Khattas Double Click Event

        /// <summary>
        /// reset information of buyers and sellers and enable/disable buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewInteqalKhattas_DoubleClick(object sender, EventArgs e)
        {
            ////clear kharidar controls
            //this.txtnameKharidar.Clear();
            //this.txtKharidHisay.Clear();
            //this.txtKharidKanal.Clear();
            //this.txtKharidMarla.Clear();
            //this.txtKharidSarsai.Clear();
            //cboKhewatType.SelectedIndex = -1;
            //btnSaveSeller.Enabled = false;
            //btnModifySeller.Enabled = false;
            //btnNewSeller.Enabled = true;
            //btncancelSeller.Enabled = false;
            //cboPersonSeller.Enabled = false;

            //try
            //{
            //    DataGridView gr = sender as DataGridView;
            //    int IntiqalKhataRecID = Convert.ToInt32(gr.SelectedRows[0].Cells[3].Value.ToString());
            //    int intiqalkhataid = Convert.ToInt32(gr.SelectedRows[0].Cells[2].Value.ToString());
            //    txtIntiqalKhataRecId.Text = IntiqalKhataRecID.ToString();
            //    this.IntiqalKhattaRecId = IntiqalKhataRecID.ToString();
            //    this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = null;
            //    this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = client.GetIntiqalSellersListByKhataRecId(IntiqalKhataRecID);
            //    this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = null;
            //    this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = client.GetIntiqalBuyersByKhataRecordId(IntiqalKhataRecID);
            //    //client.Open();
            //    //List<proc_Get_Intiqal_Khata_Malkan_Result> KhattaMalkan = new List<proc_Get_Intiqal_Khata_Malkan_Result>();
            //    //proc_Get_Intiqal_Khata_Malkan_Result ZeroIndedMalik = new proc_Get_Intiqal_Khata_Malkan_Result();
            //    //ZeroIndedMalik.PersonId = 0;
            //    //ZeroIndedMalik.personname = "انتخاب مالک";
            //    //KhattaMalkan = client.GetIntiqalKhataMalikanByKhataId(intiqalkhataid).ToList();
            //    //KhattaMalkan.Insert(0, ZeroIndedMalik);
            //    //this.cboPersonSeller.DataSource = KhattaMalkan;
            //    //this.cboPersonSeller.DisplayMember = "personname";
            //    //this.cboPersonSeller.ValueMember = "PersonId";
            //    this.GetKhataMalikanByKhataBindingSource.DataSource = client.GetIntiqalKhataMalikanByKhataId(intiqalkhataid);

            //    btnSaveSeller.Enabled = true;
            //    btnSellerSearch.Enabled = false;
            //    btnNewSeller.Enabled = true;
            //    btnBuyerSearch.Enabled = false;
            //    btnSaveBuyer.Enabled = false;
            //    splitContainer1.Panel2.Enabled = true;
            //    SplitContainerMain.Panel2.Enabled = true;
            //    btnDelIntiqalKhatta.Enabled = true;

            //    //Load Khatta Min Groups in Combo Box Min 

            //    //Commented Becuase of Incomplete Taqseem

            //    List<Proc_Get_Intiqal_MinGroupsList_Result> mingrp = new List<Proc_Get_Intiqal_MinGroupsList_Result>();
            //    Proc_Get_Intiqal_MinGroupsList_Result m = new Proc_Get_Intiqal_MinGroupsList_Result();
            //    mingrp = client.GetIntiqalMinGroup(this.IntiqalId.ToString(), intiqalkhataid.ToString()).ToList();
            //    m.IntiqalMinGroupId = 0;
            //    m.IntiqalMinGroupNo = "انتخاب من";
            //    mingrp.Insert(0, m);
            //    this.cboMinGroups.DataSource = mingrp;
            //    this.cboMinGroups.DisplayMember = "IntiqalMinGroupNo";
            //    this.cboMinGroups.ValueMember = "IntiqalMinGroupId";
            //    this.GetIntiqalMinFareeqainDataBinding.DataSource = null;
            //    this.GetKhassraMinBindingSource.DataSource = null;
            //    //////
            //    // Fill Taqseem Types Drop down list.


            //    //Clear Buyers Tab Controls
            //    this.ClearFormControls(groupBoxBuyer);
            //    btnModifyBuyer.Enabled = true;
            //    btnSaveBuyer.Enabled = false;
            //    btnNewBuyer.Enabled = true;
            //    btnBuyerSearch.Enabled = false;

            //    // Check weather the khatta used for intiqal Mushtarika Raqba Muntaqila

            //    List<Proc_Get_Intiqal_RaqbaMutiqla_Result> MMR = client.GetIntiqalMushtariqaRaqbaMuntaqila(IntiqalKhataRecID.ToString()).ToList();
            //    if (MMR.Count > 0)
            //    {
            //        if (MMR.FirstOrDefault().MustarqaMuntiqla != null)
            //        {
            //            chkMushtharaqa.Checked = true;
            //            txtMushterkaKanal.Text = MMR.FirstOrDefault().MMR_Kanal.ToString();
            //            txtMushterkamarla.Text = MMR.FirstOrDefault().MMR_Marla.ToString();
            //            txtMushterkaSarsai.Text = MMR.FirstOrDefault().MMR_Sarsai.ToString();
            //            this.btnSaveMushterqaRaqba.Enabled = false;
            //        }
            //        else
            //        {
            //            chkMushtharaqa.Checked = false;
            //            txtMushterkaKanal.Clear();
            //            txtMushterkamarla.Clear();
            //            txtMushterkaSarsai.Clear();
            //            this.btnSaveMushterqaRaqba.Enabled = true;
            //        }
            //    }
                

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }

        #endregion

        #region Button Seller Search Click event

        /// <summary>
        /// calls searching method for searching of sellers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSellerSearch_Click(object sender, EventArgs e)
        {
            //FindPerson(1);
        }

        #endregion

        #region searching form close event

        /// <summary>
        /// returns id of the searched person/owner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmSearchPersonAmalDaramad p = sender as frmSearchPersonAmalDaramad;
            //if (p.PersonType == 1)
            //{
            //    //we are returning value for Seller
            //    //txtNameFarokhtknnda.Text = p.PersonName;
            //    txtSellerId.Text = p.PersonId.ToString();
            //}
            //else if (p.PersonType == 2)
            //{
            //    //we are returning value for Buyer
            //}

        }

        #endregion

        #region Button Buyer Search Click

        /// <summary>
        /// call search method for searching of byuers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyerSearch_Click(object sender, EventArgs e)
        {
            //FindBuyer(1);
        }

        #endregion

        #region Searching Buyer Form Close Event

        /// <summary>
        /// Retrurn id of the searched person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmSearchPersonAmalDaramad p = sender as frmSearchPersonAmalDaramad;
            //if (p.PersonType == 1)
            //{
            //    foreach (DataGridViewRow row in GridSellersList.Rows)
            //    {
            //        if ((row.Cells[1].Value != null ? Convert.ToInt32(row.Cells[1].Value) : 0) == p.PersonId)
            //        {
            //            MessageBox.Show("دہندہ اور گریندہ ایک نہیں ہو سکتا");
            //        }
            //        else
            //        {
            //            txtnameKharidar.Text = p.PersonName;
            //            txtBuyerId.Text = p.PersonId.ToString();
            //        }
            //    }
            //    //we are returning value for Seller

            //}
            //else if (p.PersonType == 2)
            //{
            //    //we are returning value for Buyer
            //}
        }

        #endregion

        #region Check if the seller is alive or dead

        /// <summary>
        /// check wether the seller is alive or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsDead_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.lblDateofDeath.Visible = this.chkIsDead.Checked;
            //    this.dtpDateOfDeath.Visible = this.chkIsDead.Checked;
            //}
            //catch (Exception ex)
            //{

            //    //throw;
            //}
        }

        #endregion

        #region Button New Seller Click Event

        /// <summary>
        /// clear controls of the seller and selection of ne seller from drop down is enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewSeller_Click(object sender, EventArgs e)
        {
            //this.chkIsDead.Checked = false;

            //// this.txtNameFarokhtknnda.Clear();
            //this.txtIntiqalSellerRecordId.Text = "-1";
            ////this.txtSellerId.Clear();
            ////this.txtKulHisay.Clear();
            ////this.txtKullKanal.Clear();
            ////this.txtKullMarla.Clear();
            ////this.txtKullSarsai.Clear();
            //this.ClearFormControls(groupBoxSeller);
            //this.txtFrokhtHisay.Clear();
            //this.txtFrokhtKanal.Clear();
            //this.txtFrokhtMarla.Clear();
            //this.txtFrokhtSarsai.Clear();
            //this.txtFrokhtFeet.Clear();
            //txtIntiqalSellerRecordId.Text = "-1";
            //btnModifySeller.Enabled = false;
            //btnNewSeller.Enabled = false;
            //btnSaveSeller.Enabled = true;
            //btnSellerSearch.Enabled = false;
            //cboPersonSeller.Enabled = true;
            //GridSellersList.Enabled = false;
            //btncancelSeller.Enabled = true;


        }

        #endregion

        #region Button Save seller click event

        /// <summary>
        /// calls method for saving of the new seller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSeller_Click(object sender, EventArgs e)
        {
            //int personid = Convert.ToInt32(this.cboPersonSeller.SelectedValue.ToString());

            //if (this.inteqalCatId == 2)
            //{
            //    string personCat = client.GetPersonCategoryBYPersonId(personid);
            //    this.personChild = client.GetPersonChild(personid).ToList();
            //    if (personChild.Count <= 0)
            //    {
            //        SaveSellerRec();
            //        this.btnNewBuyer.Visible = true; //temporary


            //        //if (personCat.Equals("لاولد"))
            //        //{
            //        //    this.btnNewBuyer.Visible = true;
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("اگر انتخاب شدہ مالک کے اولاد ہے تو اولاد کا شجرہ بناو، اگر اولاد نہیں تو شجرہ میں لاولد کردو۔");

            //        //}
            //    }
            //    else
            //    {
            //        SaveSellerRec();
            //        this.btnNewBuyer.Visible = true;
            //        if (this.inteqalType == "وراثت")
            //        {
            //            //this.txtBuyerRecordId.Text = "-1";
            //            //foreach (var waris in personChild)
            //            //{
            //            //    this.txtBuyerId.Text = waris.PersonId.ToString();
            //            //    SaveIntiqalBuyerRecord();
            //            //    this.btnNewBuyer.Visible = false;

            //            //}
            //        }
            //        else if (this.inteqalType == "تملیک")
            //        {
            //            this.btnNewBuyer.Visible = true;
            //        }
            //    }

            //}
            //else
            //{
            //    SaveSellerRec();
            //    this.btnNewBuyer.Visible = true;
            //}


            ////int personid = Convert.ToInt32(this.cboPersonSeller.SelectedValue.ToString());
            ////if (this.inteqalCatId == 2)
            ////{
            ////    if (this.inteqaltypeid == 37)
            ////    {

            ////        this.personChild = client.GetPersonChild(personid).ToList();
            ////        this.txtBuyerRecordId.Text = "-1";
            ////        foreach (var waris in personChild)
            ////        {
            ////            this.txtBuyerId.Text = waris.PersonId.ToString();
            ////            SaveIntiqalBuyerRecord();

            ////        }
            ////    }
            ////}
            ////btnSaveSeller.Enabled = false;
            ////btnNewSeller.Enabled = true;
            ////btnModifySeller.Enabled = true;
            ////btnSellerSearch.Enabled = true;
            ////GridSellersList.Enabled = true;
        }

        #endregion

        #region Button New Buyer Click Event

        /// <summary>
        /// Calls method for selecting of new buyer and clear controls of buyer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewBuyer_Click(object sender, EventArgs e)
        {
            //this.txtBuyerRecordId.Text = "-1";
            //this.txtBuyerId.Clear();
            //this.txtnameKharidar.Clear();
            //this.txtKharidHisay.Clear();
            //this.txtKharidKanal.Clear();
            //this.txtKharidMarla.Clear();
            //this.txtKharidSarsai.Clear();
            //this.cboKhewatType.SelectedIndex = -1;
            //btnModifyBuyer.Enabled = false;
            //btnSaveBuyer.Enabled = true;
            //btnNewBuyer.Enabled = false;
            //btnBuyerSearch.Enabled = true;
            //FindBuyer(1);

        }

        #endregion

        #region Clear Form

        //Reset Form controls and clear all values 
        private void ClearFormControls(GroupBox gBox)
        {
            //foreach (Control ctl in gBox.Controls)
            //{
            //    if (ctl.GetType() == typeof(TextBox))
            //    {
            //        TextBox t = ctl as TextBox;
            //        t.Clear();
            //    }
            //    else if (ctl.GetType() == typeof(ComboBox))
            //    {
            //        ComboBox b = ctl as ComboBox;
            //        b.SelectedValue = 0;
            //    }
            //    else if (ctl.GetType() == typeof(CheckBox))
            //    {
            //        CheckBox chk = ctl as CheckBox;
            //        chk.Checked = false;
            //    }
            //    else if (ctl.GetType() == typeof(DateTimePicker))
            //    {
            //        DateTimePicker dt = ctl as DateTimePicker;
            //        dt.Value = DateTime.Today;
            //    }
            //}

        }
        #endregion

        #region Button Save Buyer Click Event

        /// <summary>
        /// call method for daving of the buyers record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveBuyer_Click(object sender, EventArgs e)
        {
            //if (txtnameKharidar.Text.Trim() != "" && txtKharidHisay.Text.Trim() != "" && txtKharidKanal.Text.Trim() != "" && txtKharidMarla.Text.Trim() != "" && txtKharidSarsai.Text.Trim() != "" && txtKharidFeet.Text != "" && Convert.ToInt32(cboKhewatType.SelectedValue) > 0)
            //{
            //    //bool buyerNotExists = true;
            //    //foreach (DataGridViewRow r in GridBuyersList.Rows)
            //    //{
            //    //    if(r.Cells[7].Value.ToString()==this.txtBuyerId.Text.ToString())
            //    //    {
            //    //        buyerNotExists=false;
            //    //    }
            //    //}
            //    //if(buyerNotExists)
            //    //{

            //    this.SaveIntiqalBuyerRecord();
            //    this.ClearFormControls(groupBoxBuyer);
            //    btnModifyBuyer.Enabled = true;
            //    btnSaveBuyer.Enabled = false;
            //    btnNewBuyer.Enabled = true;
            //    btnBuyerSearch.Enabled = false;
            //    this.CalculateSellerBuyerRaqbaHissa();
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("یہ گریندہ پہلے سے موجود ہے");
            //    //}
            //}
            //else
            //    MessageBox.Show(" برائے مہربانی خریدار کے تمام کوائف پر کریں");
        }

        #endregion

        #region Gridview Seller Selection Change event

        /// <summary>
        /// fills up sellere controls form grid view selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSellersList_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView dg = sender as DataGridView;
            //    txtKhataRecId.Text = dg.SelectedRows[0].Cells[0].Value.ToString();
            //    txtIntiqalSellerRecordId.Text = dg.SelectedRows[0].Cells[2].Value.ToString();
            //    txtSellerId.Text = dg.SelectedRows[0].Cells[1].Value.ToString(); ;

            //    // following record need to be fixed, and update combo box value
            //    // txtNameFarokhtknnda.Text=dg.SelectedRows[0].Cells[3].Value.ToString(); 
            //    dtpDateOfDeath.Value = Convert.ToDateTime(dg.SelectedRows[0].Cells[4].Value.ToString());
            //    chkIsDead.Checked = Convert.ToBoolean(dg.SelectedRows[0].Cells[5].Value.ToString());
            //    txtFrokhtHisay.Text = dg.SelectedRows[0].Cells[8].Value.ToString();
            //    txtFrokhtKanal.Text = dg.SelectedRows[0].Cells[9].Value.ToString();
            //    txtFrokhtMarla.Text = dg.SelectedRows[0].Cells[10].Value.ToString();
            //    txtFrokhtSarsai.Text = (dg.SelectedRows[0].Cells[11].Value.ToString() != "" ? Convert.ToInt32(dg.SelectedRows[0].Cells[11].Value.ToString()) : 0).ToString();
            //    txtKulHisay.Text = dg.SelectedRows[0].Cells[14].Value.ToString();
            //    txtKullKanal.Text = dg.SelectedRows[0].Cells[15].Value.ToString();
            //    txtKullMarla.Text = dg.SelectedRows[0].Cells[16].Value.ToString();
            //    txtKullSarsai.Text = (dg.SelectedRows[0].Cells[17].Value.ToString() != "" ? Convert.ToInt32(dg.SelectedRows[0].Cells[17].Value.ToString()) : 0).ToString();
            //    this.btnModifySeller.Enabled = true;
            //    this.btnNewSeller.Enabled = true;




            //}
            //catch (Exception ex)
            //{

            //    //throw;
            //}
        }

        #endregion

        #region Button Gridview Buyers selection Change Event

        /// <summary>
        /// fills up buyers controls from gridview buyers selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridBuyersList_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView dg = sender as DataGridView;
            //    txtBuyerRecordId.Text = dg.SelectedRows[0].Cells[8].Value.ToString();
            //    txtBuyerId.Text = dg.SelectedRows[0].Cells[7].Value.ToString();
            //    txtnameKharidar.Text = dg.SelectedRows[0].Cells[0].Value.ToString();
            //    txtKharidHisay.Text = dg.SelectedRows[0].Cells[1].Value.ToString();
            //    txtKharidKanal.Text = dg.SelectedRows[0].Cells[4].Value.ToString();
            //    txtKharidMarla.Text = dg.SelectedRows[0].Cells[5].Value.ToString();
            //    txtKharidSarsai.Text = Math.Round(float.Parse(dg.SelectedRows[0].Cells[6].Value.ToString()), 1, MidpointRounding.ToEven).ToString();
            //    txtKharidFeet.Text = dg.SelectedRows[0].Cells[3].Value.ToString();
            //    //this.cboKhewatType.SelectedValue=

            //}
            //catch (Exception ex)
            //{

            //    //MessageBox.Show(ex.Message);
            //}

        }

        #endregion

        #region Inteqal Fee Tab Controls and Events

        #region Button New Fee Click event

        /// <summary>
        /// clears fee controls and enable controls to enter data for saving the new fee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewFee_Click(object sender, EventArgs e)
        {
            //this.txtIntiqalFeeId.Text = "-1";
            //this.cboFeeType.Enabled = true;
            //this.txtFeeAmount.Enabled = true;
            //this.btnSaveFee.Enabled = true;
            //this.btnNewFee.Enabled = false;
            //this.txtFeeAmount.Clear();
            //this.cboFeeType.SelectedIndex = -1;
            //this.cboFeeType.Focus();
        }

        #endregion

        #region Button Modify Fee Click event

        /// <summary>
        /// enable editing of inteqal fee record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyFee_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //this.txtIntiqalFeeId.Text = GridViewFeeList.SelectedRows[0].Cells[5].Value.ToString();
            //    this.cboFeeType.Enabled = true;
            //    this.txtFeeAmount.Enabled = true;
            //    this.btnSaveFee.Enabled = true;
            //    this.btnNewFee.Enabled = false;
            //    //this.txtFeeAmount.Clear();
            //    //this.cboFeeType.SelectedIndex = -1;
            //    this.cboFeeType.Focus();

            //}
            //catch (Exception ex)
            //{
            //    //
            //}
        }

        #endregion

        #region Button Save Fee Click Event

        /// <summary>
        /// calls save method for saving of inteqlat fees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFee_Click(object sender, EventArgs e)
        {
            //this.SaveIntiqalFee();
            //this.cboFeeType.Enabled = false;
            //this.txtFeeAmount.Enabled = false;
            //this.btnSaveFee.Enabled = false;
            //this.btnNewFee.Enabled = true;
        }

        #endregion

        #region Save Intiqal Fees
        /// <summary>
        /// Saves the inteqalat fee
        /// </summary>
        private void SaveIntiqalFee()
        {
            //try
            //{

            //    int feeid = Convert.ToInt32(this.txtIntiqalFeeId.Text.ToString());
            //    int intiqalid = Convert.ToInt32(this.txtIntiqalId.Text.ToString());
            //    int feetype = Convert.ToInt32(this.cboFeeType.SelectedValue.ToString());
            //    decimal feeamt = Convert.ToDecimal(this.txtFeeAmount.Text.ToString());
            //    string s = client.SaveIntiqalFees(feeid, intiqalid, feetype, feeamt).ToString();
            //    this.txtIntiqalFeeId.Text = s.ToString();
            //    FillIntiqalFeeListByIntiqalId();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        #endregion

        #region Fills Inteqal fee list method

        /// <summary>
        /// get fee details for a specific inteqal by iteal id
        /// </summary>
        private void FillIntiqalFeeListByIntiqalId()
        {
            //int intiqalid = Convert.ToInt32(this.txtIntiqalId.Text.ToString());
            //this.GetIntiqalFeeByIntiqalBindingSource.DataSource = null;
            //this.GetIntiqalFeeByIntiqalBindingSource.DataSource = client.GetIntiqalFeeListByIntiqalId(intiqalid);

        }

        #endregion

        #endregion

        #region Bank Challan Events and controls


        #region Method fills challan grid

        /// <summary>
        /// Get challan information for a specific inteqal
        /// </summary>
        private void FillChallanGridByIntiqalId()
        {
            //int intiqalid = Convert.ToInt32(this.txtIntiqalId.Text.ToString());
            //this.GetIntiqalChallanListBindingSource.DataSource = null;
            //this.GetIntiqalChallanListBindingSource.DataSource = client.GetIntiqalBankChallanByIntiqalId(intiqalid);
        }

        #endregion

        #region Button New Challan Click Event

        /// <summary>
        /// enable/disable concerned controls acoording to ne wchallan entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewChallan_Click(object sender, EventArgs e)
        {
            //this.txtChallanId.Text = "-1";
            //this.txtChalanNo.Clear();
            //this.dtpChalanDate.Value = DateTime.Today;
            //this.dtpChalanDate.Checked = false;
            //this.txtBankName.Clear();
            //this.txtBranchName.Clear();
            //this.txtChalanAmount.Clear();
            //this.pnlChallanEntry.Enabled = true;
            //this.btnSaveChallan.Enabled = true;
            //this.btnCancelChallan.Enabled = true;
            //this.btnNewChallan.Enabled = false;
            //this.btnModifyChallan.Enabled = false;
        }

        #endregion

        #region Button Modify Challan Click Event

        /// <summary>
        /// enable the selected record for editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyChallan_Click(object sender, EventArgs e)
        {
            //this.pnlChallanEntry.Enabled = true;
            //this.btnSaveChallan.Enabled = true;
            //this.btnCancelChallan.Enabled = true;
            //this.btnNewChallan.Enabled = false;
            //this.btnModifyChallan.Enabled = false;
        }

        #endregion

        #region Button Save Challan Click Event

        /// <summary>
        /// calls method for saving the callan and relaod the grid view so that new added challan may become visible in it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChallan_Click(object sender, EventArgs e)
        {
            ////Save Challan Method
            //SaveChallan();
            //FillChallanGridByIntiqalId();
            //this.pnlChallanEntry.Enabled = false;
            //this.btnSaveChallan.Enabled = false;
            //this.btnCancelChallan.Enabled = false;
            //this.btnNewChallan.Enabled = true;
            //this.btnModifyChallan.Enabled = true;
        }

        #endregion

        #region Button Cancel Challan Click Event

        /// <summary>
        /// cancel new challan entry or old challan modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelChallan_Click(object sender, EventArgs e)
        {
            //this.txtChallanId.Text = "-1";
            //this.txtChalanNo.Clear();
            //this.dtpChalanDate.Value = DateTime.Today;
            //this.dtpChalanDate.Checked = false;
            //this.txtBankName.Clear();
            //this.txtBranchName.Clear();
            //this.txtChalanAmount.Clear();

            //this.pnlChallanEntry.Enabled = false;
            //this.btnSaveChallan.Enabled = false;
            //this.btnCancelChallan.Enabled = false;
            //this.btnNewChallan.Enabled = true;
            //this.btnModifyChallan.Enabled = true;
        }

        #endregion

        #region Method Save Challan Record

        /// <summary>
        /// save challan against the selected inteqal
        /// </summary>
        private void SaveChallan()
        {
            //int challanid = Convert.ToInt32(this.txtChallanId.Text.ToString());
            //int intiqalid = Convert.ToInt32(this.txtIntiqalId.Text.ToString());
            //string challanno = this.txtChalanNo.Text;
            //DateTime challandate = this.dtpChalanDate.Value;
            //string bankname = this.txtBankName.Text;
            //string branchname = this.txtBranchName.Text;
            //decimal chalanamt = Convert.ToDecimal(this.txtChalanAmount.Text.ToString());
            //string s = client.SaveIntiqalBankChallan(challanid, intiqalid, challanno, challandate, bankname, branchname, chalanamt, CurrentUser.UserId).ToString();
            //this.txtChallanId.Text = s;

        }

        #endregion

        #region Gridview Fee Selection Change Event

        /// <summary>
        /// fills fee controls from gridview selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewFeeList_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView gr = sender as DataGridView;
            //    txtIntiqalFeeId.Text = gr.SelectedRows[0].Cells[0].Value.ToString();
            //    cboFeeType.SelectedValue = Convert.ToInt32(gr.SelectedRows[0].Cells[3].Value.ToString());
            //    txtFeeAmount.Text = gr.SelectedRows[0].Cells[2].Value.ToString();
            //}
            //catch (Exception ex)
            //{
            //    //
            //}
        }

        #endregion

        #region Gridview Challanlist Selection Change Event

        /// <summary>
        /// fills callan controls from grid view selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewChalanList_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView gr = sender as DataGridView;
            //    this.txtChallanId.Text = gr.SelectedRows[0].Cells[5].Value.ToString();
            //    this.txtChalanNo.Text = gr.SelectedRows[0].Cells[0].Value.ToString();
            //    this.dtpChalanDate.Value = Convert.ToDateTime(gr.SelectedRows[0].Cells[1].Value.ToString());
            //    this.txtBankName.Text = gr.SelectedRows[0].Cells[2].Value.ToString();
            //    this.txtBranchName.Text = gr.SelectedRows[0].Cells[3].Value.ToString();
            //    this.txtChalanAmount.Text = gr.SelectedRows[0].Cells[4].Value.ToString();
            //}
            //catch (Exception ex)
            //{
            //    //
            //}

        }

        #endregion

        #endregion

        #region Button Modify Seller Click

        /// <summary>
        /// does nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifySeller_Click(object sender, EventArgs e)
        {
            //btnNewSeller.Enabled = false;
            //btnSaveSeller.Enabled = true;
            //cboPersonSeller.Enabled = true;
            //btncancelSeller.Enabled = true;
            //btnModifySeller.Enabled = false;
            //GridSellersList.Enabled = false;
        }

        #endregion

        #region Button Modify Buyer Click Event

        /// <summary>
        /// enable buyers information for modifcation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyBuyer_Click(object sender, EventArgs e)
        {
            //btnBuyerSearch.Enabled = true;
            //btnNewBuyer.Enabled = false;
            //btnModifyBuyer.Enabled = false;
            //btnSaveBuyer.Enabled = true;
        }

        #endregion

        #region Combo box seller selection changed event

        /// <summary>
        /// focuses the seller hissay text field after selecting of seller drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPersonSeller_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = client.GetIntiqalSellersListByKhataRecId(IntiqalKhataRecID);
            //txtFrokhtHisay.Focus();
        }

        #endregion

        #region Gridview Inteqal List Selection Change Event

        /// <summary>
        /// get inteqal id and assign it to text field of inteqal, useable in inteqal modification/editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewInteqalList_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridView gr = sender as DataGridView;
            //    txtIntiqalId.Text = gr.SelectedRows[0].Cells[4].Value.ToString();
            //    int IntiqalId = Convert.ToInt32(txtIntiqalId.Text);
            //    int mozaId = CurrentUser.MozaId;
            //    this.GetKhatajatByMozaId.DataSource = client.GetKhataJatForIntiqalByMozaId(mozaId);
            //    this.GetintiqalKhatasByIntiqalidBindingSource.DataSource = client.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
            //    KhataControlsDisable();
            //    FillIntiqalFeeListByIntiqalId();
            //    FillChallanGridByIntiqalId();

            //    int inteqalTypeId = gr.SelectedRows[0].Cells[12].Value != null ? Convert.ToInt32(gr.SelectedRows[0].Cells[12].Value) : 0;
            //    this.inteqalType = gr.SelectedRows[0].Cells[1].Value.ToString();
            //    this.inteqaltypeid = inteqalTypeId;
            //    if (inteqalTypeId != 0)
            //    {
            //        this.txtInteqalCatId.Text = inteqalTypes.Where(p => p.IntiqalTypeId == inteqalTypeId).FirstOrDefault().IntiqalTypeCategoryId.ToString();
            //        this.inteqalCatId = (Int32)inteqalTypes.Where(p => p.IntiqalTypeId == inteqalTypeId).FirstOrDefault().IntiqalTypeCategoryId;

            //        this.setIneqalType(Convert.ToInt32(txtInteqalCatId.Text));
            //    }
            //    else
            //    {
            //        MessageBox.Show("unable to recognise the inteqal type");
            //    }

            //    btnSaveSeller.Enabled = false;
            //    btnSellerSearch.Enabled = false;
            //    btnNewSeller.Enabled = true;
            //    btnBuyerSearch.Enabled = false;
            //    btnSaveBuyer.Enabled = false;
            //    splitContainer1.Panel2.Enabled = true;
            //    SplitContainerMain.Panel2.Enabled = true;
            //    SplitContainerMain.Panel2.Enabled = true;

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        #region Method set inteqal Type

        private void setIneqalType(int inteqalTypeCatId)
        {
            //this.gbWarasanmanderjaKhatta.Visible = false;
            //this.btnFamilySelection.Visible = false;
            //this.btnWerasathKhattajat.Visible = false;

            //if (this.inteqalCatId == 1 ) //Set template for seller and buyers
            //{
            //    this.TabControlInteqalKhataDetails.TabPages[0].Text = "بائعان";
            //    this.TabControlInteqalKhataDetails.TabPages[1].Text = "مشتریان";
            //}
            //else if (inteqalCatId == 2) //set template for werasath and tamleek
            //{
            //    if (this.inteqaltypeid == 37 || this.IntiqalType=="وراثت") //Werasath
            //    {
            //        this.TabControlInteqalKhataDetails.TabPages[0].Text = "متوفی/متوافیہ";
            //        this.TabControlInteqalKhataDetails.TabPages[1].Text = "وارثان";
            //        this.gbWarasanmanderjaKhatta.Visible = true;
            //        this.btnFamilySelection.Visible = true;
            //        this.btnWerasathKhattajat.Visible = true;
            //    }
            //    else if (this.inteqaltypeid == 38 || this.IntiqalType == "تملیک") //tamleek
            //    {
            //        this.TabControlInteqalKhataDetails.TabPages[0].Text = "تملیک دہندہ";
            //        this.TabControlInteqalKhataDetails.TabPages[1].Text = "تملیک گریندہ";
            //    }
            //}
            //else if (inteqalCatId == 3 ) //set template for Rehan/Ur-rehan
            //{
            //    this.TabControlInteqalKhataDetails.TabPages[0].Text = "راہن";
            //    this.TabControlInteqalKhataDetails.TabPages[1].Text = "مرتہن";
            //}
            //else if (inteqalCatId == 4) //set template for Rehan return-fakurehan
            //{
            //    this.TabControlInteqalKhataDetails.TabPages[0].Text = "مرتہن";
            //    this.TabControlInteqalKhataDetails.TabPages[1].Text = "رہن";
            //}
        }

        #endregion

        #region Text Field Kharid hissay text change event

        /// <summary>
        /// call method for hissay validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKharidHisay_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Method validate buyers hissay to seller hissay
        /// <summary>
        /// Validates the seller and buyers hissay, so that buyers may not get more hissay then sold one.
        /// </summary>
        /// <returns></returns>
        private bool isValid()
        {
            //bool isvalid = true;
            //float sellerhissay = 0;
            //float buyershissay = 0;
            //foreach (DataGridViewRow row in GridSellersList.Rows)
            //{

            //    sellerhissay += float.Parse(row.Cells[9].Value.ToString() != "" ? row.Cells[9].Value.ToString() : "0");
            //}
            //foreach (DataGridViewRow d in GridBuyersList.Rows)
            //{
            //    buyershissay += float.Parse(d.Cells[1].Value.ToString() != "" ? d.Cells[1].Value.ToString() : "0");
            //}

            //buyershissay += float.Parse(txtKharidHisay.Text.Trim() != "" ? txtKharidHisay.Text.Trim() : "0");
            //if (txtBuyerRecordId.Text != "-1")
            //{
            //    isvalid = true;
            //}
            //else if (buyershissay <= sellerhissay)
            //{
            //    isvalid = true;
            //}
            //else
            //    isvalid = false;
            //return isvalid;
            return true;
        }

        #endregion

        #region Text Kharid Hissay Leave event

        /// <summary>
        /// call method for hissay validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKharidHisay_Leave(object sender, EventArgs e)
        {
            //if (isValid())
            //{
            //    string personRaqba = this.PersonRaqba(float.Parse(txtKharidHisay.Text.Trim()), float.Parse(txtIntiqalHissay.Text), this.S_Kanal, this.S_Marla, this.S_Sarsai, this.S_Sft);
            //    string[] raqba = personRaqba.Split('-');
            //    this.txtKharidKanal.Text = raqba[0];
            //    this.txtKharidMarla.Text = raqba[1];
            //    this.txtKharidSarsai.Text = raqba[2];
            //    this.txtKharidFeet.Text = raqba[3];
            //}
            //else
            //{
            //    MessageBox.Show("فروخت شدہ حصے سے زیادہ حصے خریدار کو نہیں دے سکتے");
            //    txtKharidHisay.Clear();
            //    txtKharidHisay.Focus();
            //}
        }

        #endregion

        #region Text Field Farokht HIssay Move Event

        /// <summary>
        /// validate sold hissay may not exceed owners hissay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFrokhtHisay_Move(object sender, EventArgs e)
        {
            //try
            //{
            //    float kulhissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
            //    float soldhissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
            //    if (soldhissay > kulhissay)
            //    {
            //        MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ");
            //        txtFrokhtHisay.Clear();
            //        txtFrokhtHisay.Focus();
            //    }
            //    else
            //    {
            //        string[] raqba = getRaba();
            //        txtFrokhtKanal.Text = raqba[0];
            //        txtFrokhtMarla.Text = raqba[1];
            //        txtFrokhtSarsai.Text = raqba[2];
            //        txtFrokhtFeet.Text = raqba[3];
            //    }

            //}
            //catch (Exception)
            //{

            //}
        }


        #endregion

        #region Calculate sold raqba on basis of sold hissay

        //private string[] getRaba()
         private string getRaba()
        {
            //string[] raqba = new string[4];
            //float khissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
            //float shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
            ////---Owners raqba
            //int kkanal = txtKullKanal.Text.Trim() != "" ? Convert.ToInt32(txtKullKanal.Text.Trim()) : 0;
            //int kmarla = txtKullMarla.Text.Trim() != "" ? Convert.ToInt32(txtKullMarla.Text.Trim()) : 0;
            //float ksarsai = txtKullSarsai.Text.Trim() != "" ? float.Parse(txtKullSarsai.Text.Trim()) : 0;
            //float ksft = txtKulFeet.Text.Trim() != "" ? float.Parse(txtKulFeet.Text.Trim()) : 0;
            ////owners raqba in SFT
            //float raqbainSft = (kkanal * 20 * (float) 272.25) + (kmarla *(float) 272.25) + ksft; //+ ((ksarsai / 9) * 272) sarsai not included in raqba
            ////Owners sold raqba in sft
            //float sraqbainsft = 0;
            //if (khissay != 0 && shissay != 0)
            //{
            //    sraqbainsft = (raqbainSft / khissay) * shissay;
            //}

            ////owners sold raqba in kanal , marla etc.
            //if (sraqbainsft != 0)
            //{
            //    int remsft = 0;
            //    int skanal = 0;
            //    int smarla = 0;
            //    int remMarla = 0;
            //    float ssft = 0;
            //    float ssarsai = 0;
            //    if (sraqbainsft > 272.25)
            //    {
            //        remsft = Convert.ToInt32(sraqbainsft % (float)272.25);
            //        smarla = Convert.ToInt32((sraqbainsft - remsft) /(float)272.25);
            //    }
            //    else
            //    {
            //        remsft = Convert.ToInt32(sraqbainsft);
            //    }

            //    if (smarla >= 20)
            //    {
            //        remMarla = smarla % 20;
            //        skanal = (smarla - remMarla) / 20;
            //    }
            //    else
            //        remMarla = smarla;

            //    raqba[0] = skanal.ToString();
            //    raqba[1] = remMarla.ToString();
            //    raqba[2] = Math.Round(remsft/(float)30.25, 3).ToString();
            //    raqba[3] = remsft.ToString();
            //}
            //return raqba;
            return "raqba";
        }

        #endregion


        private void txtKulHisay_TextChanged(object sender, EventArgs e)
        {
            //this.txtFrokhtHisay.Clear();
            //this.txtFrokhtFeet.Clear();
            //this.txtFrokhtKanal.Clear();
            //this.txtFrokhtMarla.Clear();
            //this.txtFrokhtSarsai.Clear();
            //this.txtFrokhtHisay.Enabled = true;
            //this.txtFrokhtKanal.Enabled = true;
            //this.txtFrokhtMarla.Enabled = true;
            //this.txtFrokhtSarsai.Enabled = true;
            //this.txtFrokhtFeet.Enabled = true;
            //if (this.inteqalCatId == 1) //Set template for seller and buyers / hiba, etc
            //{

            //}
            //else if (inteqalCatId == 2) //set template for werasath and tamleek
            //{
            //    if (this.inteqalType == "وراثت") //Werasath
            //    {
            //        this.txtFrokhtHisay.Enabled = false;
            //        this.txtFrokhtKanal.Enabled = false;
            //        this.txtFrokhtMarla.Enabled = false;
            //        this.txtFrokhtSarsai.Enabled = false;
            //        this.txtFrokhtFeet.Enabled = false;
            //        this.txtFrokhtHisay.Text = txtKulHisay.Text;
            //        this.txtFrokhtFeet.Text = txtKulFeet.Text;
            //        this.txtFrokhtKanal.Text = txtKullKanal.Text;
            //        this.txtFrokhtMarla.Text = txtKullMarla.Text;
            //        this.txtFrokhtSarsai.Text = txtKullSarsai.Text;
            //    }
            //    else if (this.inteqalType == "تملیک") //tamleek
            //    {
            //        this.txtFrokhtHisay.Enabled = true;
            //        this.txtFrokhtKanal.Enabled = true;
            //        this.txtFrokhtMarla.Enabled = true;
            //        this.txtFrokhtSarsai.Enabled = true;
            //        this.txtFrokhtFeet.Enabled = true;
            //    }
            //}
            //else if (inteqalCatId == 3) //set template for Rehan/Ur-rehan
            //{

            //}
            //else if (inteqalCatId == 4) //set template for Rehan return-fakurehan
            //{

            //}
        }

        private void btncancelSeller_Click(object sender, EventArgs e)
        {
            //btnModifySeller.Enabled = true;
            //btnSaveSeller.Enabled = false;
            //btnNewSeller.Enabled = true;
            //btnSellerSearch.Enabled = true;
            //GridSellersList.Enabled = true;
        }

        private void checkBoxRaptEntry_CheckedChanged(object sender, EventArgs e)
        {
            //groupBoxRapat.Visible = checkBoxRaptEntry.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SaveIntiqal();
            //this.IntiqalMainByMozaList = client.GetIntiqalMainListByMozaId(CurrentUser.MozaId).ToList();
            //this.ClearFormControls(groupBox6);
            //this.ClearFormControls(groupBox5);
            //this.ClearFormControls(groupBoxRapat);
            //this.btnSave.Enabled = false;
            //this.btnNewInteqal.Enabled = true;
            //this.btnCancel.Enabled = false;
            //this.btnDelMain.Enabled = false;
        }

        #region Save Inteqal Entry
        /// <summary>
        /// Saves Inteqal Main Entry
        /// </summary>
        private void SaveIntiqal()
        {
            //try
            //{
            //    int intiqalId = this.IntiqalId;
            //    int mozaId = CurrentUser.MozaId;
            //    bool KhanaMalkiat = true;
            //    // if (checkBoxKhanaMalkiat.Checked)
            //    // {
            //    //KhanaMalkiat = true;
            //    // }
            //    bool KhanaKasht = false;
            //    //if (checkBoxKhanaKasht.Checked)
            //    //{
            //    // KhanaKasht = true;
            //    // }
            //    string intiqalNo = txtIntiqalNo.Text;
            //    string hawalaNo = txtHawalaNo.Text;
            //    int intiqalTypeId = Convert.ToInt32(cboIntiqalType.SelectedValue);
            //    int intiqalInitaionId = Convert.ToInt32(cboIntiqalInitiation.SelectedValue);
            //    DateTime IndrajDate = dtpIntiqalAndrajDate.Value;
            //    string rapatNo = txtIntiqalRapatNo.Text;
            //    DateTime rapatDate = dtpIntiqalRapatDate.Value;
            //    DateTime amalDaramadDate = dtpIntiqalAmaldramadDate.Value;
            //    decimal landValue = txtLandValue.Text.Trim() != "" ? Convert.ToDecimal(txtLandValue.Text) : 0;
            //    DateTime AttestDate = dtpTasdiq.Value;
            //    int landTypeId = cboQismArazi.SelectedIndex != -1 ? Convert.ToInt32(cboQismArazi.SelectedValue) : 1;
            //    DateTime DegreeDate = dtDegreeDate.Value;
            //    string courtname = txtCourtName.Text.Trim();
            //    int misalNo = txtMisalNo.Text.Trim() != "" ? Convert.ToInt32(txtMisalNo.Text.Trim()) : 0;
            //    decimal LandValutionTablVal = txtValuationTableValue.Text.Trim() != "" ? Convert.ToDecimal(txtValuationTableValue.Text.Trim()) : 0;
            //    string tafseel = this.txtTafsil.Text.Trim();

            //    string LastId = client.SaveIntiqalMain(intiqalId, CurrentUser.MozaId, KhanaMalkiat, KhanaKasht, intiqalNo, hawalaNo, intiqalTypeId, intiqalInitaionId, IndrajDate, rapatNo, rapatDate, amalDaramadDate, landValue, AttestDate, 1, landTypeId, LandValutionTablVal, DegreeDate, courtname, misalNo, tafseel, CurrentUser.UserId, CurrentUser.UserName);
            //    txtIniqalId.Text = LastId;
            //    MessageBox.Show("انتقال کا اندراج رجسٹر میں ہو گیا ہے۔");
            //    //this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        #endregion

        private void btnSearchInteqal_Click(object sender, EventArgs e)
        {
            //int intiqalId=0;
            //this.IntiqalId = this.IntiqalMainByMozaList.Where(p => p.IntiqalNo == txtIntiqalNo.Text.Trim()).Count() > 0 ? this.IntiqalMainByMozaList.Where(p => p.IntiqalNo == txtIntiqalNo.Text.Trim()).FirstOrDefault().IntiqalId : 0;
            //txtIntiqalId.Text = IntiqalId.ToString();
            //this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = null;
            //this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = null;
            //if (IntiqalId > 0) //Intiqal Entry found 
            //{

            //    FillIntiqalByIntiqalId();
            //    LoadIntiqalDetails();
            //    btnSave.Enabled = true;
            //    btnNewInteqal.Enabled = true;
            //    btnCancel.Enabled = false;
            //    this.btnDelMain.Enabled = true;


            //}
            //else //not found, we will display a message 
            //{
            //    MessageBox.Show("آپکا مطلوبہ انتقال نمبر درست نہیں۔ دوبارہ کوشش کریں ");
            //    this.txtIntiqalNo.Clear();
            //    this.txtIntiqalNo.Focus();
            //    ClearFormControls(groupBox6);
            //    //this.cboIntiqalType.SelectedIndex = -1;
            //    //this.cboIntiqalInitiation.SelectedIndex = -1;
            //    //this.GetintiqalKhatasByIntiqalidBindingSource.DataSource = null;
            //    //this.txtTafsil.Clear();
            //}

        }

        #region Method for Checking Pending Intiqal Status

        private void CheckIntiqalPendingStatus()
        {
            
        }

        #endregion

        #region Enable Disable Controls
        private void EnableDisableControls(string Flag, GroupBox Container)
        {
            //string idx;
            //char[] st = Flag.ToCharArray();
            //foreach (Control ctl in Container.Controls)
            //{

            //    if (ctl.Tag == null)
            //    {

            //    }
            //    else
            //    {
            //        idx = ctl.Tag.ToString();
            //        Int32 n = Int32.Parse(idx);
            //        if (st[n - 1] == 1)
            //        {
            //            ctl.Enabled = true;
            //        }
            //        else
            //        {
            //            ctl.Enabled = false;
            //        }
            //    }
            //}
        }
        #endregion

        #region Load Intiqal details by Search

        private void LoadIntiqalDetails()
        {
            //try
            //{
            //    int mozaId = CurrentUser.MozaId;
            //    this.GetKhatajatByMozaId.DataSource = client.GetKhataJatForIntiqalByMozaId(mozaId);
            //    this.GetintiqalKhatasByIntiqalidBindingSource.DataSource = client.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
            //    KhataControlsDisable();
            //    FillIntiqalFeeListByIntiqalId();
            //    FillChallanGridByIntiqalId();

            //    int inteqalTypeId = Convert.ToInt32(this.IntiqalMainByMozaList.Where(p => p.IntiqalId == this.IntiqalId).Count() > 0 ? this.IntiqalMainByMozaList.Where(p => p.IntiqalId == this.IntiqalId).FirstOrDefault().IntiqalTypeId : 0);
            //    this.inteqalType = this.IntiqalMainByMozaList.Where(p => p.IntiqalId == this.IntiqalId).Count() > 0 ? this.IntiqalMainByMozaList.Where(p => p.IntiqalId == this.IntiqalId).FirstOrDefault().IntiqalType : "";
            //    this.inteqaltypeid = inteqalTypeId;
            //    if (inteqalTypeId != 0)
            //    {
            //        this.txtInteqalCatId.Text = inteqalTypes.Where(p => p.IntiqalTypeId == inteqalTypeId).FirstOrDefault().IntiqalTypeCategoryId.ToString();
            //        this.inteqalCatId = (Int32)inteqalTypes.Where(p => p.IntiqalTypeId == inteqalTypeId).FirstOrDefault().IntiqalTypeCategoryId;

            //        this.setIneqalType(Convert.ToInt32(txtInteqalCatId.Text));
            //    }
            //    else
            //    {
            //        MessageBox.Show("unable to recognise the inteqal type");
            //    }

            //    btnSaveSeller.Enabled = false;
            //    btnSellerSearch.Enabled = false;
            //    btnNewSeller.Enabled = true;
            //    btnBuyerSearch.Enabled = false;
            //    btnSaveBuyer.Enabled = false;
            //    splitContainer1.Panel2.Enabled = true;
            //    SplitContainerMain.Panel2.Enabled = true;
            //    SplitContainerMain.Panel2.Enabled = true;

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            ////This List will remain as it is 

            //if (txtIntiqalNo.Text.Trim() != "")
            //{
            //    if (ImagePathManger.ImageLocation == null)
            //    {
            //        frmSetPath f = new frmSetPath();
            //        f.ShowDialog();
            //    }
            //    List<KhataNoIndex> KhataPics = new List<KhataNoIndex>();
            //    KhataPics.Clear();
            //    //string[] khattaNo = txtKhatatNo.Text.Trim().Split('/');
            //    List<Proc_Get_IndexedFiles_by_Type_Result> IndexedFiles = new List<Proc_Get_IndexedFiles_by_Type_Result>();
            //    IndexedFiles = client.GetIndexFilesByType(CurrentUser.MozaId, txtIntiqalNo.Text.Trim(), 12).ToList();
            //    if (ImagePathManger.ImageLocation != null)
            //    {

            //        foreach (var q in IndexedFiles)
            //        {
            //            KhataNoIndex pic = new KhataNoIndex();
            //            pic.KhataNo = q.RecordNo;
            //            pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(ImagePathManger.ImageLocation, q.FileName + ".jpg"));
            //            //pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(q.DestinationFolder, q.FileName + ".jpg"));
            //            //MessageBox.Show(pic.DocumentNo);
            //            KhataPics.Add(pic);
            //        }
            //    }
            //    //What To do Next
            //    // 1 : Call Stored Procedure With Khata No and Moza Id
            //    // 2 : Return Record Set
            //    // 3 : Loop From Record Set and In each loop step
            //    //     Create a new Object of KhataPics and Assign Record Set Values to this object
            //    // 4 : Add this object to Above KhataPics List
            //    // 5 : Create New Form Object Which is already underneath.
            //    // 6 : Assign KhataPics List to KhataPictures Property
            //    // 7 : Show Form and Enjoy !
            //    //pic.KhataNo ="49";
            //    //pic.DocumentNo = @"C:\\Users\\Yousaf Gill\\Desktop\\Output\\49_1.jpg";
            //    //KhataPics.Add(pic);
            //    //KhataNoIndex pic1 = new KhataNoIndex();
            //    //pic1.KhataNo = this.txtKhatatNo.Text;
            //    //pic1.DocumentNo = @"C:\\Users\\Yousaf Gill\\Desktop\\Output\\49_2.jpg";
            //    //KhataPics.Add(pic1);
            //    //KhataNoIndex pic2 = new KhataNoIndex();
            //    //pic2.KhataNo = this.txtKhatatNo.Text;
            //    //pic2.DocumentNo = @"C:\\Users\\Yousaf Gill\\Desktop\\Output\\49_3.jpg";
            //    //KhataPics.Add(pic2);

            //    //Remain as it is , it will cover Step 6 and 7
            //    if (IndexedFiles.Count > 0 && ImagePathManger.ImageLocation != null)
            //    {
            //        frmKhataPictureViewer fv = new frmKhataPictureViewer();
            //        fv.KhataPictures = KhataPics;
            //        fv.Show();
            //    }
            //    else if (IndexedFiles.Count > 0 && ImagePathManger.ImageLocation == null)
            //    {
            //        MessageBox.Show("اس فرد بدر کی انڈکسڈ دستاویز کی جگہ تعین نہیں ");
            //    }
            //    else
            //    {
            //        MessageBox.Show("اس فرد بدر کی انڈکسڈ دستاویز موجود نہیں");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("براے مہربانی فرد بدر نمبر چنِے");
            //}
        }

        private void txtTafsil_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar((Keys.Back)))
            //{

            //}
            //else
            //{
            //    e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            //}
        }

        #region Combo Box Intiqal Type Slection Change evetn.. Check wether intiqal aready exists..

        /// <summary>
        /// Check whether the intiqal no already exists..?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIntiqalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ////int intiqalId=0;
            //this.IntiqalId = this.IntiqalMainByMozaList.Where(p => p.IntiqalNo == txtIntiqalNo.Text.Trim()).Count() > 0 ? this.IntiqalMainByMozaList.Where(p => p.IntiqalNo == txtIntiqalNo.Text.Trim()).FirstOrDefault().IntiqalId : 0;
            //txtIntiqalId.Text = IntiqalId.ToString();
            //if (IntiqalId > 0) //Intiqal Entry found 
            //{
            //    MessageBox.Show("یہ انتقال پہلے سے اندراج شدہ ہے", "انتقال", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.cboIntiqalType.SelectedIndex = -1;
            //    this.txtIntiqalNo.Focus();

            //}
            //else //not found, go farword to insert new inteqal. 
            //{

            //}
        }

        #endregion

        #region Calculate Seller and Buyer Khatta and Raqba Difference

        private void CalculateSellerBuyerRaqbaHissa()
        {
            //try
            //{
            //    decimal hissay = 0;
            //    int kanal = 0;
            //    int marlas = 0;
            //    decimal sars = 0;
            //    decimal sft = 0;
            //    //Calculate Sold Hissay and Raqba
            //    foreach (DataGridViewRow row in GridSellersList.Rows)
            //    {
            //        hissay += row.Cells[9].Value != null ? Convert.ToDecimal(row.Cells[9].Value.ToString()) : 0;
            //        kanal += row.Cells[14].Value != null ? Convert.ToInt32(row.Cells[14].Value.ToString()) : 0;
            //        marlas += row.Cells[15].Value != null ? Convert.ToInt32(row.Cells[15].Value.ToString()) : 0;
            //        sars = 0;//sars += row.Cells[16].Value != null ? Convert.ToDecimal(row.Cells[16].Value.ToString()) : 0;
            //        sft += row.Cells[13].Value != null ? Convert.ToDecimal(row.Cells[13].Value.ToString()) : 0;
            //    }

                #region Calculate Raqba for Seller

                //decimal PersonRaqba = ((kanal * 20 + marlas) * (decimal)272.25) + (sars * (decimal)30.25) + sft;
                //if (PersonRaqba >= (decimal)272.25)
                //{
                //    sft = PersonRaqba % (decimal)272.25;
                //    marlas = Convert.ToInt32((PersonRaqba - sft) / (decimal)272.25);

                //    if (marlas >= 20)
                //    {
                //        kanal = (marlas - (marlas % 20)) / 20;
                //        marlas = marlas % 20;
                //        //if (sft >= 31)
                //        //{
                //        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                //        //    sft = Convert.ToInt32(sft % 30.25);
                //        //}

                //    }
                //    else
                //    {
                //        kanal = 0;
                //    }

                //}
                //else
                //{
                //    marlas = 0;
                //    kanal = 0;
                //    //if (sft >= 31)
                //    //{
                //    //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                //    //    sft = Convert.ToInt32(sft % 30.25);
                //    //}
                //}
                //if (sft > 0)
                //{
                //    sars= sft /(decimal)30.25;
                //}
                ////return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 4, MidpointRounding.AwayFromZero).ToString() + "-" + Math.Round(sft, 4, MidpointRounding.AwayFromZero).ToString();


                #endregion


                //this.S_Kanal = kanal;
                //this.S_Marla = marlas;
                //this.S_Sarsai =float.Parse(sars.ToString());
                //this.S_Sft =float.Parse(sft.ToString());
                ////calculate Buyers Hissay and Raqba

                //decimal bhissay = 0;
                //int bKanal = 0;
                //int bMarla = 0;
                //decimal bSars = 0;
                //decimal bsft = 0;

                //foreach (DataGridViewRow row in GridBuyersList.Rows)
                //{
                //    bhissay += row.Cells[1].Value != null ? Convert.ToDecimal(row.Cells[1].Value) : 0;
                //    bKanal += row.Cells[4].Value != null ? Convert.ToInt32(row.Cells[4].Value) : 0;
                //    bMarla += row.Cells[5].Value != null ? Convert.ToInt32(row.Cells[5].Value) : 0;
                //    bSars += row.Cells[6].Value != null ? Convert.ToDecimal(row.Cells[6].Value) : 0;
                //    bsft += row.Cells[3].Value != null ? Convert.ToDecimal(row.Cells[3].Value) : 0;
                //}

                #region Calculate Raqba for Buyer

                //decimal PersonRaqbaBuyer = ((bKanal * 20 + bMarla) * (decimal)272.25) + (bSars * (decimal)30.25) + bsft;
                //if (PersonRaqbaBuyer >= (decimal)272.25)
                //{
                //    bsft = PersonRaqbaBuyer % (decimal)272.25;
                //    bMarla = Convert.ToInt32((PersonRaqbaBuyer - bsft) / (decimal)272.25);

                //    if (bMarla >= 20)
                //    {
                //        bKanal = (bMarla - (bMarla % 20)) / 20;
                //        bMarla = bMarla % 20;
                //        //if (sft >= 31)
                //        //{
                //        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                //        //    sft = Convert.ToInt32(sft % 30.25);
                //        //}

                //    }
                //    else
                //    {
                //        bKanal = 0;
                //    }

                //}
                //else
                //{
                //    bMarla = 0;
                //    bKanal = 0;
                //    //if (sft >= 31)
                //    //{
                //    //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                //    //    sft = Convert.ToInt32(sft % 30.25);
                //    //}
                //}
                //if (bsft > 0)
                //{
                //    bSars = sft /(decimal)30.25;
                //}
                ////return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 4, MidpointRounding.AwayFromZero).ToString() + "-" + Math.Round(sft, 4, MidpointRounding.AwayFromZero).ToString();


                #endregion

            //    txtIntiqalHissay.Text = hissay.ToString();
            //    txtHissaDiff.Text = (hissay - bhissay).ToString();
            //    txtIntiqalRaqba.Text = kanal.ToString() + "-" + marlas.ToString() + "-" + Math.Round(sft, 0).ToString();
            //    float RaqbaDiffInSft =(float) ((((kanal * 20) + marlas) * 272.25) + (double)sft) -(float) (((decimal)((bKanal * 20) + bMarla) *(decimal) 272.25) + (decimal)bsft);
            //    int RemKanal = 0;
            //    int RemMarla = 0;
            //    float Remsarsai = 0;
            //    int RemSft = 0;
            //    if (RaqbaDiffInSft > 272.25)
            //    {
            //        RemSft =Convert.ToInt32( RaqbaDiffInSft % (float)272.25);
            //        RemMarla =Convert.ToInt32( (RaqbaDiffInSft - RemSft) / (float)272.25);
            //        if (RemMarla > 20)
            //        {
            //            RemKanal=Convert.ToInt32( (RemKanal% (float) 272.25)/(float)20);
            //            RemMarla=Convert.ToInt32(RemMarla%(float)272.25);
            //        }
            //        if(RemSft>0)
            //        {
            //            Remsarsai=RemSft/(float)30.25;
            //        }
            //        RemSft=Convert.ToInt32(RemSft);

            //    }
            //    txtRaqbaDiff.Text = RemKanal.ToString() + "K__" + RemMarla.ToString() + "M__" +RemSft.ToString() + "Sft";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        
        #endregion

        #region Tabe Selection Changed

        private void TabControlInteqalKhataDetails_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if (this.TabControlInteqalKhataDetails.SelectedTab == TabControlInteqalKhataDetails.TabPages["tabKhareedar"])
            //{
            //    this.CalculateSellerBuyerRaqbaHissa();
            //}
        }

        #endregion

        #region Delete Buttons click events

        private void btnDelMain_Click(object sender, EventArgs e)
        {
        //    try
        //    {

        //        client.DeleteIntiqalMain(Convert.ToInt32(this.IntiqalId));
        //        this.btnNewInteqal_Click(sender, e);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void btnDelIntiqalKhatta_Click(object sender, EventArgs e)
        //{
        //    if (txtIntiqalKhataRecId.Text != "-1" && txtIntiqalKhataRecId.Text != "")
        //    {
        //        try
        //        {
        //            client.DeleteIntiqalKhattajat(Convert.ToInt32(this.txtIntiqalKhataRecId.Text));
        //            this.GetKhatajatByMozaId.DataSource = null;
        //            this.GetKhatajatByMozaId.DataSource = client.GetKhataJatForIntiqalByMozaId(CurrentUser.MozaId);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //        MessageBox.Show("برائے مہربانی کھاتہ چنیے");
        }


        #endregion

        #region Gridview Seller and Buyers double click events

        private void GridSellersList_DoubleClick(object sender, EventArgs e)
        {
        //    try
        //    {
        //        this.txtSellerId.Text = this.GridSellersList.SelectedRows[0].Cells[1].Value != null ? this.GridSellersList.SelectedRows[0].Cells[1].Value.ToString() : "-1";
        //        this.txtIntiqalSellerRecordId.Text = this.GridSellersList.SelectedRows[0].Cells[2].Value != null ? this.GridSellersList.SelectedRows[0].Cells[2].Value.ToString() : "-1";
        //        this.cboPersonSeller.SelectedValue = Convert.ToInt32(this.txtSellerId.Text); //this.GridSellersList.SelectedRows[0].Cells[1].Value != null ? this.GridSellersList.SelectedRows[0].Cells[1].Value : "0";
        //        this.btnDelSeller.Enabled = true;
        //        this.btnModifySeller.Enabled = true;
        //        this.cboPersonSeller.Enabled = true;
        //        this.txtFrokhtHisay.Text = this.GridSellersList.SelectedRows[0].Cells[9].Value != null ? Convert.ToDecimal(this.GridSellersList.SelectedRows[0].Cells[9].Value.ToString()).ToString() : "0";
        //        this.txtFrokhtKanal.Text = this.GridSellersList.SelectedRows[0].Cells[14].Value != null ? this.GridSellersList.SelectedRows[0].Cells[14].Value.ToString() : "0";
        //        this.txtFrokhtMarla.Text = this.GridSellersList.SelectedRows[0].Cells[15].Value != null ? this.GridSellersList.SelectedRows[0].Cells[15].Value.ToString() : "0";
        //        this.txtFrokhtSarsai.Text = this.GridSellersList.SelectedRows[0].Cells[16].Value != null ? Math.Round(Convert.ToDecimal(this.GridSellersList.SelectedRows[0].Cells[16].Value.ToString()), 3).ToString() : "0";
        //        this.txtFrokhtFeet.Text = this.GridSellersList.SelectedRows[0].Cells[13].Value != null ? this.GridSellersList.SelectedRows[0].Cells[13].Value.ToString() : "0";
        //        btnSaveSeller.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void GridBuyersList_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.txtBuyerRecordId.Text = this.GridBuyersList.SelectedRows[0].Cells[8].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[8].Value.ToString() : "-1";
        //        this.txtBuyerId.Text = this.GridBuyersList.SelectedRows[0].Cells[7].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[7].Value.ToString() : "-1";
        //        this.txtnameKharidar.Text = this.GridBuyersList.SelectedRows[0].Cells[0].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[0].Value.ToString() : "error";
        //        this.txtKharidHisay.Text = this.GridBuyersList.SelectedRows[0].Cells[1].Value != null ? Convert.ToDecimal(this.GridBuyersList.SelectedRows[0].Cells[1].Value.ToString()).ToString() : "0";
        //        this.txtKharidKanal.Text = this.GridBuyersList.SelectedRows[0].Cells[4].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[4].Value.ToString() : "0";
        //        this.txtKharidMarla.Text = this.GridBuyersList.SelectedRows[0].Cells[5].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[5].Value.ToString() : "0";
        //        this.txtKharidSarsai.Text = this.GridBuyersList.SelectedRows[0].Cells[6].Value != null ? this.GridBuyersList.SelectedRows[0].Cells[6].Value.ToString() : "0";
        //        this.txtKharidFeet.Text = this.GridBuyersList.SelectedRows[0].Cells[3].Value != null ? Math.Round(Convert.ToDecimal(this.GridBuyersList.SelectedRows[0].Cells[3].Value.ToString()), 0).ToString() : "0";
        //        this.cboKhewatType.SelectedValue = this.GridBuyersList.SelectedRows[0].Cells[12].Value != null ? Convert.ToInt32(this.GridBuyersList.SelectedRows[0].Cells[12].Value.ToString()) : 0;
        //        this.btnDelBuyer.Enabled = true;
        //    }
        //    catch (Exception Ex)
        //    {

        //        MessageBox.Show(Ex.Message);
        //    }
        }

        #endregion

        #region Button Seller Delete Click Event


        private void btnDelSeller_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtIntiqalSellerRecordId.Text != "" && txtIntiqalSellerRecordId.Text != "-1")
            //    {
            //        client.DeleteIntiqalSeller(Convert.ToInt32(txtIntiqalSellerRecordId.Text));
            //        this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = null;
            //        this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = client.GetIntiqalSellersListByKhataRecId(Convert.ToInt32(txtKhataRecId.Text)).ToList();
            //        this.btnDelSeller.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("برائے مہربانی دہندہ چنیے");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        #region Button Buyer Delete Click Event

        private void btnDelBuyer_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtBuyerRecordId.Text != "" && txtBuyerRecordId.Text != "-1")
            //    {
            //        client.DleteIntiqalBuyer(Convert.ToInt32(txtBuyerRecordId.Text));
            //        this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = null;
            //        this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = client.GetIntiqalBuyersByIntiqalKhataRecId(Convert.ToInt32(txtKhataRecId.Text)).ToList();
            //        this.btnDelBuyer.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("برائے مہربانی گریندہ چنیے");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        #region Button New Khassra Click Event

        private void btnNewKhassra_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmKhassraTatima khasra = new frmKhassraTatima();
            //    khasra.KhattaId = Convert.ToInt32(cbokhataNo.SelectedValue);
            //    khasra.FbId = long.Parse(this.IntiqalId.ToString());
            //    khasra.FormClosed -= new FormClosedEventHandler(khasra_FormClosed);
            //    khasra.FormClosed += new FormClosedEventHandler(khasra_FormClosed);
            //    khasra.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        void khasra_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmKhassraTatima kt = sender as frmKhassraTatima;
            //this.KhassraTatimaNo = kt.KhassraTatimaNo;
        }

        private void btnKhassraSearch_Click(object sender, EventArgs e)
        {
            //frmKhassraSearch KhasraSearch = new frmKhassraSearch();
            //KhasraSearch.ShowDialog();
        }

        #region Cell Content of Gridview Mushteryan Click event

        private void GridBuyersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex !=
            //GridBuyersList.Columns[10].Index) return;

            //string BuyerPersonId = GridBuyersList.Rows[e.RowIndex].Cells[8].Value.ToString();
            //string buyerPersonName = GridBuyersList.Rows[e.RowIndex].Cells[0].Value.ToString();
            //if (BuyerPersonId != "")
            //{
            //    frmKhassraBuyerAssignment km = new frmKhassraBuyerAssignment();
            //    km.BuyerPersonId = BuyerPersonId;
            //    km.BuyerPersonName = buyerPersonName;
            //    km.KhassraNo = this.KhassraTatimaNo;
            //    km.IntiqalId = this.IntiqalId.ToString();
            //    km.ShowDialog();
            //}



        }

        #endregion

        private void txtSearchSeller_TextChanged(object sender, EventArgs e)
        {
            //this.GetKhataMalikanByKhataBindingSource.DataSource = client.GetIntiqalKhataMalikanByKhataId(Convert.ToInt32(cbokhataNo.SelectedValue)).ToList().Where(p=>p.personname;
        }

        #region Calculates Person Raqba on basis of person area parts

        private string PersonRaqba(float hissa, float KulHissa, int k, int m, float s, float f)
        {
            ////Previous Calculation
            ////int totalHissay = txtKulHisay.Text.Trim() != "" ? Convert.ToInt32(txtKulHisay.Text.Trim()) : 0;

            ////textBox1 is Sum of fareeqain total parts after calculation
            //float totalHissay = KulHissa; //Modified by Yousaf
            ////MessageBox.Show(textBox1.Text);
            //int tkanal = k;
            //int tmarla = m;
            //float tsarsai = s;
            //if (hissa != totalHissay)
            //{
            //    float totalRaqba = float.Parse(Math.Round((((((20 * tkanal) + tmarla) * 9) + tsarsai) * 30.25) + f, 3, MidpointRounding.AwayFromZero).ToString()); //in square feet
            //    float PersonRaqba = 0;
            //    if (totalHissay != 0)
            //    {
            //        PersonRaqba = float.Parse(Math.Round(((hissa / totalHissay) * totalRaqba), 3, MidpointRounding.AwayFromZero).ToString());
            //    }
            //    //MessageBox.Show("Hissa " +hissa.ToString() + " total Hissay "+ totalHissay.ToString()+ " Kul Raqba "+ totalRaqba.ToString());


            //    float marla = 0;
            //    float kanal = 0;
            //    float sarsai = 0;
            //    float sft = 0;
            //    sft = PersonRaqba;
            //    if (PersonRaqba >= 272.25)
            //    {
            //        sft = PersonRaqba % (float)272.25;
            //        marla = (float)(PersonRaqba - sft) / (float)272.25;

            //        if (marla >= 20)
            //        {
            //            kanal = (float)(marla - (marla % 20)) / 20;
            //            marla = (float)marla % 20;
            //            //if (sft >= 31)
            //            //{
            //            //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
            //            //    sft = Convert.ToInt32(sft % 30.25);
            //            //}

            //        }
            //        else
            //        {
            //            kanal = 0;
            //        }

            //    }
            //    else
            //    {
            //        marla = 0;
            //        kanal = 0;
            //        //if (sft >= 31)
            //        //{
            //        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
            //        //    sft = Convert.ToInt32(sft % 30.25);
            //        //}
            //    }
            //    if (sft > 0)
            //    {
            //        sarsai = sft / (float)30.25;
            //    }
            //    return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 3).ToString() + "-" + Math.Round(sft, 0).ToString();

            //}
            //else
            //{
            //    return tkanal.ToString() + "-" + tmarla.ToString() + "-" + Math.Round((decimal)tsarsai, 3).ToString() + "-"+f.ToString();
            //}
            return "raqba";
        }

        #endregion

        #region Amal Daramd Button Click Event

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            //if (this.IntiqalId != 0 && this.IntiqalId != -1)
            //{
            //    try
            //    {
            //        if (GridSellersList.Rows.Count > 0 && GridBuyersList.Rows.Count > 0)
            //        {
            //            if (MessageBox.Show("کیا آپ واقعی اس انتقال پر عمل درآمد کرنا چاہتے ہیں", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                string s = client.IniqalAmalDaramad(this.IntiqalId.ToString()).ToString();
            //                if (s == "I")
            //                {
            //                    MessageBox.Show("انتقال پر عمل درآمد ہو گیا");
            //                }
            //                else
            //                {
            //                    MessageBox.Show(s);
            //                }
            //                this.FillIntiqalByIntiqalId();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("انتقال پر عمل درآمد سے پہلے انتقال دہندہ اور گریندہ محفوظ کریں");
            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        #endregion

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void btnsavemingroup_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int KhattaId = Convert.ToInt32(GridViewInteqalKhattas.SelectedRows[0].Cells[2].Value.ToString());
            //    if (chkBadasthor.Checked && cboMinGroups.Items.Count > 0)
            //    {
            //        string s = client.IntiqalMinBadasthor(this.IntiqalId.ToString(), KhattaId.ToString());
            //        if (s != "")
            //        {
            //            //this.txtIntiqalMinGroupId.Text = s;
            //            MessageBox.Show("ریکارڈ محفوظ ہو گیا");
            //            this.chknewkhatta.Checked = false;
            //            this.chkBadasthor.Checked = false;
            //            this.txtmingroup.Clear();
            //        }
            //    }
            //    else if (chknewkhatta.Checked && txtmingroup.Text.Trim() != "")
            //    {

            //        List<Proc_Get_Moza_Register_KhataJat_ByUserId_Result> Khattas = client.GetKhattajaatByUser(CurrentUser.MozaId, CurrentUser.UserId).ToList();
            //        Proc_Get_Moza_Register_KhataJat_ByUserId_Result k = new Proc_Get_Moza_Register_KhataJat_ByUserId_Result();
            //        string MinkhattaNo = k.KhataNo;
            //        if (Khattas.Count > 0)
            //        {
            //            k = Khattas.Where(p => p.RegisterHqDKhataId == KhattaId).FirstOrDefault();
            //        }
            //        if (txtmingroup.Text.Trim() != "")
            //        {
            //            MinkhattaNo = k.KhataNo + "/" + txtmingroup.Text.Trim();
            //        }
            //        string s = client.SaveIntiqalMinGroup(this.txtIntiqalMinGroupId.Text, this.IntiqalId, KhattaId, txtmingroup.Text.Trim(), MinkhattaNo, (int)k.TotalParts, k.Kanal, k.Marla, float.Parse(k.sarsai.ToString()), 0, CurrentUser.UserId, CurrentUser.UserLogin, CurrentUser.UserId, CurrentUser.UserLogin, CurrentUser.MozaId);
            //        if (s != "")
            //        {
            //            this.txtIntiqalMinGroupId.Text = s;
            //            MessageBox.Show("ریکارڈ محفوظ ہو گیا");
            //            this.chknewkhatta.Checked = false;
            //            this.chkBadasthor.Checked = false;
            //            this.txtmingroup.Clear();
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnmlikan_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmMalkanTaqseem fm = new frmMalkanTaqseem();
            //    fm.IntiqalId = this.IntiqalId;
            //    //fm.MalikanType = "RHZ";
            //    fm.KhataId = GridViewInteqalKhattas.SelectedRows[0].Cells[2].Value.ToString();
            //    fm.IntiqalMinGroupId = this.txtIntiqalMinGroupId.Text;
            //    fm.FormClosed -= new FormClosedEventHandler(fm_FormClosed);
            //    fm.FormClosed += new FormClosedEventHandler(fm_FormClosed);
            //    fm.ShowDialog();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}



        }

        void fm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //client.SetIntiqalMinGrpTotal(txtIntiqalMinGroupId.Text);
            //this.GetIntiqalMinFareeqainDataBinding.DataSource = client.GetIntiqalMinFareeqain(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text).ToList();
        }

        private void chknewkhatta_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    cboMinGroups.Visible = !chknewkhatta.Checked;
            //    if (chknewkhatta.Checked)
            //    {
            //        this.txtIntiqalMinGroupId.Text = "-1";
            //        this.chkBadasthor.Visible = true;
            //        this.lblYabs.Visible = true;
            //        this.GridIntiqalKhattaJatforMin.Enabled = false;
            //        this.btnmlikan.Enabled = false;
            //        this.btnkhasrajat.Enabled = false;
            //    }
            //    else
            //    {
            //        this.chkBadasthor.Visible = false;
            //        this.lblYabs.Visible = false;
            //        this.GridIntiqalKhattaJatforMin.Enabled = true;
            //        this.btnmlikan.Enabled = true;
            //        this.btnkhasrajat.Enabled = true;
            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cboMinGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //this.txtIntiqalMinGroupId.Text = cboMinGroups.SelectedValue.ToString();
            //this.GetIntiqalMinFareeqainDataBinding.DataSource = client.GetIntiqalMinFareeqain(this.IntiqalId.ToString(), this.txtIntiqalMinGroupId.Text).ToList();
            //if (Convert.ToInt32(cboMinGroups.SelectedValue) > 0) // MinGroup Zero mean no min group so reset the controls to none
            //{
            //    Proc_Get_Intiqal_MinGroup_Detail_Result minDetail = client.GetIntiqalMinGroupDetails(this.txtIntiqalMinGroupId.Text).FirstOrDefault();
            //    this.lblKhattaMinNo.Text = minDetail.IntiqalMinKhataNo;
            //    this.txtMinKulHissay.Text = minDetail.IntiqalMin_TotalParts.ToString();
            //    this.txtMinKulRaqba.Text = minDetail.IntiqalMin_Area;

            //    // Set Total Area Khassrajat 
            //    this.lblKulRaqbaKhasras.Text = client.GetKhassraMinTotalRaqbaByMinGroup(txtIntiqalMinGroupId.Text);
               
            //}
            //else
            //{
            //    this.lblKhattaMinNo.Text = "";
            //    this.txtMinKulHissay.Clear();
            //    this.txtMinKulRaqba.Clear();
            //    this.lblKulRaqbaKhasras.Text = "0-0-0";
            //}
            //// Get Min Khassra for Selected Group
            //this.GetKhassraMinBindingSource.DataSource = client.GetIntiqalMinKhassraJat(this.IntiqalId.ToString(), this.txtIntiqalMinGroupId.Text).ToList();

        }

        private void btnkhasrajat_Click(object sender, EventArgs e)
        {
            //frmKhassraMinTaqseem khasraMin = new frmKhassraMinTaqseem();
            //khasraMin.khattaId = Convert.ToInt32(GridViewInteqalKhattas.SelectedRows[0].Cells[2].Value.ToString());
            //khasraMin.IntiqalMinGroupId = txtIntiqalMinGroupId.Text;
            //khasraMin.IntiqalId = this.IntiqalId;
            //khasraMin.FormClosed -= new FormClosedEventHandler(khasraMin_FormClosed);
            //khasraMin.FormClosed += new FormClosedEventHandler(khasraMin_FormClosed);
            //khasraMin.ShowDialog();
        }

        void khasraMin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.GetKhassraMinBindingSource.DataSource = client.GetIntiqalMinKhassraJat(this.IntiqalId.ToString(), this.txtIntiqalMinGroupId.Text).ToList();
        }

        private void gridkhasrajat_DoubleClick(object sender, EventArgs e)
        {
            //DataGridView g = sender as DataGridView;
            //if (g.SelectedRows.Count > 0)
            //{
            //    try
            //    {               
            //        this.cboTaqseemType.SelectedIndex = g.SelectedRows[0].Cells[0].Value.ToString() == "سالم" ? 1 : 0;
            //        this.txtoldkhasra.Text = g.SelectedRows[0].Cells[1].Value.ToString();
            //        this.txtkhatoni.Text = g.SelectedRows[0].Cells[3].Value.ToString();
            //        this.txtarea.Text = g.SelectedRows[0].Cells[4].Value.ToString();
            //        this.txtAreaType.Text = g.SelectedRows[0].Cells[2].Value.ToString();
            //        this.txtOldKhattaId.Text = g.SelectedRows[0].Cells[14].Value.ToString();
            //        this.txtOldKhassraId.Text = g.SelectedRows[0].Cells[13].Value.ToString();
            //        this.txtOldKhassraDetailId.Text = g.SelectedRows[0].Cells[12].Value.ToString();
            //        this.txtMinKhassraId.Text = g.SelectedRows[0].Cells[10].Value.ToString();
            //        this.txtIntiqalMinKhasraRecId.Text = g.SelectedRows[0].Cells[11].Value.ToString();
            //        this.txtAreaTypeId.Text = g.SelectedRows[0].Cells[15].Value.ToString();
            //        this.txtOldKhatoniId.Text =g.SelectedRows[0].Cells[17].Value!=null? g.SelectedRows[0].Cells[17].Value.ToString():"-1";
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }

            //}
        }

        private void btnSaveIntiqalMinKhassra_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int OldkhatoniId = Convert.ToInt32(txtOldKhatoniId.Text);
            //int KhattaId = Convert.ToInt32(txtOldKhattaId.Text);
            //int OldKhassraId = Convert.ToInt32(txtOldKhassraId.Text);
            //int oldKhassraDetailId = Convert.ToInt32(txtOldKhassraDetailId.Text);
            //int MinKhassraId = Convert.ToInt32(txtMinKhassraId.Text);
            //int areTypeId = Convert.ToInt32(txtAreaTypeId.Text);
            //string MinType = cboTaqseemType.Text == "سالم" ? "2" : "1";
            //int Kanal = txtKanalMuntaqla.Text != "" ? Convert.ToInt32(txtKanalMuntaqla.Text) : 0;
            //int marla = txtMarlaMuntaqla.Text != "" ? Convert.ToInt32(txtMarlaMuntaqla.Text) : 0;
            //float sarsai = txtSarsaiMuntaqla.Text != "" ? Convert.ToInt32(txtSarsaiMuntaqla.Text) : 0;
            //float sft = txtSftMuntaqila.Text != "" ? Convert.ToInt32(txtSftMuntaqila.Text) : 0;
            //string s = client.SaveIntiqalMinKhassra(this.txtIntiqalMinKhasraRecId.Text, this.IntiqalId, this.txtIntiqalMinGroupId.Text, KhattaId,OldkhatoniId,  OldKhassraId, MinKhassraId, oldKhassraDetailId, txtmin.Text.Trim(), txtnewkhasra.Text.Trim(), txtkhatoni.Text, areTypeId, MinType, Kanal, marla, sarsai, sft, CurrentUser.UserId, CurrentUser.UserName, CurrentUser.UserId, CurrentUser.UserName, CurrentUser.MozaId);
            //if (s != "" || s != null)
            //{
            //    this.GetKhassraMinBindingSource.DataSource = client.GetIntiqalMinKhassraJat(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text).ToList();
            //    this.ClearFormControls(gbKhassraMinControls);
            //}

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtmin_Leave(object sender, EventArgs e)
        {
        //    if (txtmin.Text.Trim() != "")
        //    {
        //        this.txtnewkhasra.Text = txtoldkhasra.Text + "/" + txtmin.Text.Trim();
        //    }
        //}

        //private void chkBadasthor_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkBadasthor.Checked)
        //    {
        //        txtmingroup.Clear();
        //        txtmingroup.Enabled = false;
        //    }
        //    else
        //    {
        //        //txtmingroup.Clear();
        //        txtmingroup.Enabled = true;
        //    }
        }

        private void btnAmalDaramadTaqseem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (MessageBox.Show(" عمل درآمد ک بعد آپ اس انتقال میں میں تبدیلی نہیں کر سکتے۔ پھر بھی عمل درآمد کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        //MessageBox.Show("Yes");
            //        string s = client.IntiqalMinAmalDaramad(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());
            //    }
            //    else
            //    {
            //        //MessageBox.Show("No");
            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        #region Grid View Min Fareeqain Cell Content Click Event

        private void gridmalikan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // try
           // {

           // DataGridView g = sender as DataGridView;
           // if (e.RowIndex < 0 || e.ColumnIndex !=
           //g.Columns[6].Index) return;
           
           //     string IntiqalMinKhewarFareeqId = g.Rows[e.RowIndex].Cells[3].Value.ToString();
           //     //string buyerPersonName = GridBuyersList.Rows[e.RowIndex].Cells[0].Value.ToString();
           //     if (MessageBox.Show("کیا آپ واقعی ریکارڈ خزف کرنا چاہتے ہیں؟", "خزف ریکارڈ ", MessageBoxButtons.YesNo) == DialogResult.Yes)
           //     {
           //         client.DeleteIntiqalMinFareeq(IntiqalMinKhewarFareeqId);
           //         client.SetIntiqalMinGrpTotal(txtIntiqalMinGroupId.Text);
           //         this.GetIntiqalMinFareeqainDataBinding.DataSource = client.GetIntiqalMinFareeqain(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text).ToList();
           //     }
            

           // }
           // catch (Exception ex)
           // {

           //     MessageBox.Show(ex.Message);
           // }


        }
        #endregion

        private void gridkhasrajat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //    DataGridView g = sender as DataGridView;
            //    if (e.RowIndex < 0 || e.ColumnIndex !=
            //   g.Columns[16].Index) return;
               
            //    string IntiqalMinKhassraRecId = g.Rows[e.RowIndex].Cells[11].Value.ToString();
            //    //string buyerPersonName = GridBuyersList.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    if (MessageBox.Show("کیا آپ واقعی ریکارڈ خزف کرنا چاہتے ہیں؟", "خزف ریکارڈ ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        client.DeleteIntiqalMinKhassra(IntiqalMinKhassraRecId);
            //        this.GetKhassraMinBindingSource.DataSource = client.GetIntiqalMinKhassraJat(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text).ToList();
            //    }
                
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }

        private void gridmalikan_DoubleClick(object sender, EventArgs e)
        {
            
           //DataGridView g=sender as DataGridView;
           // if(g.SelectedRows.Count>0)
           // {
           //     this.txtMinFareeqRecId.Text=g.SelectedRows[0].Cells[3].Value.ToString();
           //     this.txtnamemalik.Text=g.SelectedRows[0].Cells[0].Value.ToString();
           //     this.txtoldHisa.Text=g.SelectedRows[0].Cells[1].Value.ToString();
           //     btnSaveMinFareeq.Enabled = true;
           //     //this.txtHisatransfer.Text=g.SelectedRows[0].Cells[].Value.ToString();
           // }
        }

        private void btnSaveMinFareeq_Click(object sender, EventArgs e)
        {
            //try
            //{

            //string IntiqalMinFareeqId = this.txtMinFareeqRecId.Text;
            //float IntiqalMinHissa =txtHisatransfer.Text.Trim()!=""? float.Parse(txtHisatransfer.Text.Trim()):0;
            //int MinKanal =txtMinFareeqKanal.Text.Trim()!=""? Convert.ToInt32(txtMinFareeqKanal.Text.Trim()):0;
            //int MinMarla = txtMinFareeqMarla.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqMarla.Text.Trim()) : 0;
            //float MinSarsai = txtMinFareeqSarsai.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqSarsai.Text.Trim()) : 0;
            //float MinSft = txtMinFareeqSft.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqSft.Text.Trim()) : 0;
            //if (MinSarsai > 0 && MinSft <= 0)
            //{
            //    MinSft = MinSarsai * (float)30.25;
            //}
            //else if(MinSarsai<=0 && MinSft>0)
            //{
            //    MinSarsai = MinSft / (float)30.25;
            //}
            //if (IntiqalMinFareeqId != "-1" && IntiqalMinFareeqId != "")
            //{
            //    client.UpdateIntiqalMinFareeqHissa(IntiqalMinFareeqId, IntiqalMinHissa, MinKanal, MinMarla, MinSarsai, MinSft, CurrentUser.MozaId);
            //    this.GetIntiqalMinFareeqainDataBinding.DataSource = client.GetIntiqalMinFareeqain(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text.Trim()).ToList();

            //    // Clear Controls
            //    btnSaveMinFareeq.Enabled = false;
            //    this.txtMinFareeqRecId.Text = "-1";
            //    this.txtnamemalik.Clear();
            //    this.txtoldHisa.Clear();
            //    txtHisatransfer.Clear();
            //    txtMinFareeqKanal.Clear();
            //    txtMinFareeqMarla.Clear();
            //    txtMinFareeqSarsai.Clear();
            //    txtMinFareeqSft.Clear();
            //    client.SetIntiqalMinGrpTotal(txtIntiqalMinGroupId.Text);
            //}

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }

        private void chkMushtharaqa_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkMushtharaqa.Checked)
            //{
            //    this.txtMushterkaKanal.Visible = true;
            //    this.txtMushterkamarla.Visible = true;
            //    this.txtMushterkaSarsai.Visible = true;
            //    this.btnSaveMushterqaRaqba.Visible = true;
            //    this.lblMushterkaKanal.Visible = true;
            //    this.lblMushterkaMarla.Visible = true;
            //    this.lblMushterkaSarsai.Visible = true;
            //}
            //else
            //{
            //    this.txtMushterkaKanal.Visible =    false;
            //    this.txtMushterkamarla.Visible =    false;
            //    this.txtMushterkaSarsai.Visible =   false;
            //    this.btnSaveMushterqaRaqba.Visible =false;
            //    this.lblMushterkaKanal.Visible =    false;
            //    this.lblMushterkaMarla.Visible =    false;
            //    this.lblMushterkaSarsai.Visible =   false;
            //}
        }

        private void btnSaveMushterqaRaqba_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int KhattaId=Convert.ToInt32(cbokhataNo.SelectedValue);
            //    int intiqalKhataRecId = Convert.ToInt32(txtIntiqalKhataRecId.Text);
            //    List<proc_Get_Intiqal_Khata_Malkan_Result> Fareeqain=client.GetIntiqalKhataMalikanByKhataId(KhattaId).ToList();
            //    foreach(var far in Fareeqain)
            //    {
            //        string s = client.SaveIntiqalSellers(-1, intiqalKhataRecId, (int)far.PersonId, false, DateTime.Now, (float)far.FardAreaPart, far.Farad_Kanal, far.Fard_Marla, (float)far.Fard_Sarsai, (float)far.Fard_Feet, (float)far.FardAreaPart, far.Farad_Kanal, far.Fard_Marla, (float)far.Fard_Sarsai, (float)far.Fard_Feet, (int)far.KhewatGroupFareeqId).FirstOrDefault().ToString();
            //    }

            //    int mmrKanal=txtMushterkaKanal.Text.Trim()!=""?Convert.ToInt32(txtMushterkaKanal.Text):0;
            //    int mmrMarla=txtMushterkamarla.Text.Trim()!=""?Convert.ToInt32(txtMushterkamarla.Text.Trim()):0;
            //    float mmrSarsai=txtMushterkaSarsai.Text.Trim()!=""?float.Parse(txtMushterkaSarsai.Text.Trim()):0;
            //    float mmrSft=mmrSarsai*(float)30.25;
            //    client.SetMushtarkaRaqbaMuntiqla(intiqalKhataRecId.ToString(), true, mmrKanal, mmrMarla, mmrSarsai, mmrSft);
            //    this.IntiqalSellersByKhattaRecordIdBindingSource.DataSource = client.GetIntiqalSellersListByKhataRecId(KhattaId).ToList();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnHisaBamutabiqRaqba_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Get Hissa From Raqba Entered by DEO.
            //    decimal khissay = txtKulHisay.Text.Trim() != "" ? Convert.ToDecimal(txtKulHisay.Text.Trim()) : 0;
            //    decimal shissay = txtFrokhtHisay.Text.Trim() != "" ? Convert.ToDecimal(txtFrokhtHisay.Text.Trim()) : 0;
            //    //---Owners raqba
            //    int kkanal = txtKullKanal.Text.Trim() != "" ? Convert.ToInt32(txtKullKanal.Text.Trim()) : 0;
            //    int kmarla = txtKullMarla.Text.Trim() != "" ? Convert.ToInt32(txtKullMarla.Text.Trim()) : 0;
            //    decimal ksarsai = txtKullSarsai.Text.Trim() != "" ? Convert.ToDecimal(txtKullSarsai.Text.Trim()) : 0;
            //    decimal ksft = txtKulFeet.Text.Trim() != "" ? Convert.ToDecimal(txtKulFeet.Text.Trim()) : 0;

            //    //--- Buyers Raqba
            //    int bkanal = txtKullKanal.Text.Trim() != "" ? Convert.ToInt32(txtFrokhtKanal.Text.Trim()) : 0;
            //    int bmarla = txtKullMarla.Text.Trim() != "" ? Convert.ToInt32(txtFrokhtMarla.Text.Trim()) : 0;
            //    decimal bsarsai = txtKullSarsai.Text.Trim() != "" ?Convert.ToDecimal(txtFrokhtSarsai.Text.Trim()) : 0;
            //    decimal bsft = txtKulFeet.Text.Trim() != "" ? Convert.ToDecimal(txtFrokhtFeet.Text.Trim()) : 0;

            //    //owners raqba in SFT
            //    decimal raqbainSft = (kkanal * 20 *(decimal) 272.25) + (kmarla * (decimal)272.25) + ksft; //+ ((ksarsai / 9) * 272) sarsai not included in raqba

            //    //-- Buyer raqba in SFT
            //    decimal bRaqbaInSft = (bkanal * 20 * (decimal)272.25) + (bmarla * (decimal)272.25) + bsft;

            //    //Owners sold raqba in sft
            //    decimal bHissay = 0;
            //    if (raqbainSft != 0 && bRaqbaInSft != 0)
            //    {
            //        bHissay = ( khissay*bRaqbaInSft)/raqbainSft;
            //    }

            //    //owners sold raqba in kanal , marla etc.
            //    txtFrokhtHisay.Text = bHissay.ToString();
               
            //        //string[] raqba = getRaba();
            //        //txtFrokhtKanal.Text = raqba[0];
            //        //txtFrokhtMarla.Text = raqba[1];
            //        //txtFrokhtSarsai.Text = raqba[2];
            //        //txtFrokhtFeet.Text = raqba[3];
               
            //}
            //catch (Exception)
            //{

            //}
        }

        private void txtFrokhtSarsai_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtFrokhtSarsai.Text.Trim() != "")
            //    {
            //        decimal bsft = Convert.ToDecimal(txtFrokhtSarsai.Text.Trim());
            //        txtFrokhtFeet.Text = Math.Round(bsft*(decimal)30.25,2).ToString();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
           
        }

        private void btnBuyerHissaBamutabiqraqba_Click(object sender, EventArgs e)
        {
           // try
           // {

           //     //--- Raqba Total
           //decimal KulHissay=Convert.ToDecimal(txtIntiqalHissay.Text.Trim());
           // //decimal BuyerHisay=Convert.ToDecimal(txtIntiqalHissay.Text);
           // int tkanal = this.S_Kanal;
           // int tmarla = this.S_Marla;
           // float tsarsai = this.S_Sarsai;
           //  float sft = this.S_Sft;
           //  decimal totalRaqbaInSft =Math.Round((((20 * tkanal) + tmarla) *(decimal)272.25) +Convert.ToDecimal( this.S_Sft), 0);

           //     // ----Buyer Raqba
           //     int bkanal=txtKharidKanal.Text.Trim()!=""?Convert.ToInt32(txtKharidKanal.Text.Trim()):0;
           //     int bMarla=txtKharidMarla.Text.Trim()!=""?Convert.ToInt32(txtKharidMarla.Text.Trim()):0;
           //     decimal bSarsai=txtKharidSarsai.Text.Trim()!=""?Convert.ToDecimal(txtKharidSarsai.Text.Trim()):0;
           //     decimal bSft=txtKharidFeet.Text.Trim()!=""?Convert.ToDecimal(txtKharidFeet.Text.Trim()):0;



           //     decimal RaqbaMutaqla=Math.Round((((bkanal*20)+bMarla)*(decimal)272.25)+bSft, 0);

           //     if (KulHissay != 0 && totalRaqbaInSft != 0 && RaqbaMutaqla != 0)
           //     {
           //         //in square feet
           //         decimal PersonHissay = ((KulHissay * RaqbaMutaqla) / totalRaqbaInSft);
           //         this.txtKharidHisay.Text = PersonHissay.ToString();

           //     }

           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message);
           // }
        }

        private void txtKharidSarsai_Leave(object sender, EventArgs e)
        {
            //if (txtKharidSarsai.Text.Trim() != "")
            //{
            //    this.txtKharidFeet.Text =Math.Round( (Convert.ToDecimal(txtKharidSarsai.Text.Trim()) *(decimal)30.25), 2).ToString();
            //}
        }

        private void txtKharidFeet_Leave(object sender, EventArgs e)
        {
            //if (txtKharidFeet.Text.Trim() != "")
            //{
            //    this.txtKharidSarsai.Text = Math.Round((Convert.ToDecimal(txtKharidFeet.Text.Trim()) /(decimal)30.25), 3).ToString();
            //}
        }

        private void txtFrokhtFeet_Leave(object sender, EventArgs e)
        {
            //if (txtFrokhtFeet.Text.Trim() != "")
            //{
            //    this.txtFrokhtSarsai.Text = Math.Round((Convert.ToDecimal(txtFrokhtFeet.Text.Trim()) / (decimal)30.25), 3).ToString();
            //}
        }

        private void btnSaveWarsanManderjaKhatta_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (GridViewInteqalKhattas.Rows.Count > 1)
            //    {
            //        if (GridViewInteqalKhattas.SelectedRows[0].Index > 0)
            //        {
            //            if (GridSellersList.Rows.Count > 0)
            //            {
            //                string intiqalRecId = GridViewInteqalKhattas.SelectedRows[0].Cells[3].Value.ToString();
            //                string s = client.IntiqalWarasathManderjaKhattaWarisan(intiqalRecId, this.IntiqalId.ToString()).FirstOrDefault().ToString();
            //                this.GridViewInteqalKhattas_DoubleClick((object)GridViewInteqalKhattas, e);
            //            }
            //            else
            //            {
            //                MessageBox.Show(" پہلے متوفی/ متوفیہ کا ریکارڈ محفوظ کریں", "مندرجہ کھاتہ وارثان");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("یہ سہولت انتقال کے پہلے کھاتے کے لیے کارامد  نہیں ہے", "مندرجہ کھاتہ وارثان");
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("یہ سہولت صرف ایک سے زیادہ کھاتے کے لیے کارامد ہے","مندرجہ کھاتہ وارثان");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnFamilySelection_Click(object sender, EventArgs e)
        {
            //frmTestMalkanSelcIntiqalWirasath frmFamilySelectionForWarsan = new frmTestMalkanSelcIntiqalWirasath();
            //frmFamilySelectionForWarsan.khewatTypeId = client.GetKhewatTypes(CurrentUser.TehsilId).FirstOrDefault().KhewatTypeId;
            //frmFamilySelectionForWarsan.KhataId = this.IntiqalKhattaRecId;
            //frmFamilySelectionForWarsan.FormClosed -= new FormClosedEventHandler(frmFamilySelectionForWarsan_FormClosed);
            //frmFamilySelectionForWarsan.FormClosed += new FormClosedEventHandler(frmFamilySelectionForWarsan_FormClosed);
            //frmFamilySelectionForWarsan.ShowDialog();
        }

        void frmFamilySelectionForWarsan_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.GetIntiqalBuyerByKhataRecIdBindingSource.DataSource = client.GetIntiqalBuyersByKhataRecordId(Convert.ToInt32(this.IntiqalKhattaRecId)).ToList();
            ////this.CalculateSellerBuyerRaqbaHissa();
        }

        private void btnWerasathKhattajat_Click(object sender, EventArgs e)
        {
            //if (GridSellersList.Rows.Count > 0)
            //{
            //    string personName=GridSellersList.Rows[0].Cells[6].Value.ToString();
            //    string PersonId=GridSellersList.Rows[0].Cells[1].Value.ToString();
            //    frmPersonKhattaSearch f = new frmPersonKhattaSearch();
            //    f.PersonName =personName;
            //    f.PersonId=PersonId;
            //    f.ShowDialog();
            //}
           
        }

        private void chkPendingIntiqal_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkPendingIntiqal.Checked)
            //{
            //    frmIntiqalPendingReasons frmReasonStatus = new frmIntiqalPendingReasons();
            //    frmReasonStatus.IntiqalId = this.IntiqalId.ToString();
            //    frmReasonStatus.FormClosed -= new FormClosedEventHandler(frmReasonStatus_FormClosed);
            //    frmReasonStatus.FormClosed += new FormClosedEventHandler(frmReasonStatus_FormClosed);
            //    frmReasonStatus.ShowDialog();
            //}
            //else
            //{
            //    if (DialogResult.Yes == MessageBox.Show("کیا آپ اس انتقال کے زیر التواء حئثیت ختم کرنا چاہتے ہیں", "", MessageBoxButtons.YesNo))
            //    {
            //        client.setIntiqalPendingReason(this.IntiqalId.ToString(), false, "");
            //        this.btnSearchInteqal_Click(sender, e);
            //    }
            //}
        }

        void frmReasonStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.btnSearchInteqal_Click(sender, e);
        }

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //bool isOk = client.GetKhattaInconsistencyStatus(cbokhataNo.SelectedValue.ToString());
            //if (isOk)
            //{
            //}
            //else
            //{
            //    MessageBox.Show("اپکا مطلوبہ کھاتہ 1/1 نہیں ہے");
            //}
            //btnSaveKhatta.Enabled = isOk;
        }


       
       
    }

}
