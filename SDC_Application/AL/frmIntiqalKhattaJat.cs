using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;      

namespace SDC_Application.AL
{
    public partial class frmIntiqalKhattaJat : Form
    {
        public string IntiqalId { get; set; }
        public bool IntiqalPending { get; set; }
        public bool isAttested { get; set; }
        public int Teh_Report;
        public string isGardawar { get; set; }
        public bool isConfirmed { get; set; }
        public string MinhayeIntiqalId { get; set; }
        public string IntiqalTypeId { get; set; }
        public string BS_AreaHissa { get; set; }
        public string RegStatus { get; set; }
        string datetoken;
        //  AutoComplete on = new AutoComplete();
        //public string lastId { get; set; }
        Intiqal inteq = new Intiqal();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        DataTable dtkj = new DataTable();
        DataTable saveKhata = new DataTable();
        DataTable dtmg = new DataTable();
        DataTable dtMinGrpDet = new DataTable();
        DataView dvTaqseemMalkan;
        DataView dvTaqseemMushtryan;
        BindingSource bs = new BindingSource();
        DataTable MinhayeIntiqals = new DataTable();
        DataTable dtKhatooniAreaHissa = new DataTable();
        DataTable TokenList = new DataTable();
        BindingSource bb = new BindingSource();
        Misal misalBL = new Misal();
        BL.TaqseemNewKhataJatMin taqseemnewkhata = new BL.TaqseemNewKhataJatMin();

        //string KhewatGroupFareeqId;

        #region Varibles frmSellers

        public string NewKhataCreate
        {
            get;
            set;
        }
        public string Khatoniid
        {
            get;
            set;
        }

        public string KhatoniRecid
        {
            get;
            set;
        }

        public string MushtriFareeqId
        {
            get;
            set;
        }

        public string IntiqalKhataRecId
        {
            get;
            set;
        }
        public string IntiqalKhataId
        {
            get;
            set;
        }

        float KhataHissa = 0;
        int KhataKanal = 0;
        int KhataMarla = 0;
        float KhataSarsai = 0;
        float KhataFeet = 0;


        Khatoonies Khatooni = new Khatoonies();
        DataView viewMF;
        public string RegisterHqDKhataId { get; set; }
        public string RegisterHqId { get; set; }
        public string ParentKhataID { get; set; }
        public string Taraf { get; set; }
        public string Pati { get; set; }
        public bool AmalDaramad { get; set; }
        public bool MalkiatKashkat { get; set; }
        AutoComplete AutoFillCombo = new AutoComplete();
        CommanFunctions CommanFunctions = new CommanFunctions();
        datagrid_controls datacontrols = new datagrid_controls();
        LanguageConverter lang = new LanguageConverter();
        Intiqal Intiqal = new Intiqal();
        DataTable dt = new DataTable();
        DataTable Mushdt = new DataTable();
        bool GridSelection = true;
        #endregion

        #region Properties
        /// <summary>
        /// get or set inteqal id
        /// </summary>
        //public string IntiqalId { get; set; }
        public string IntiqalMinGroupId { get; set; }
        public string MinGroupNo { get; set; }
        public string khatoniNo { get; set; }
        public string InteqKhataId { get; set; }
        public string intiqalIId { get; set; }
        public string IntiqalKhatooniRecId { get; set; }
        public string IntiqalMinKhatoniNo { get; set; }
        public string IntiqalMinOldKhatooniId { get; set; }
        public string IntiqalMinKhatooniRecId { get; set; }
        public string KhewatGroupFareeqId { get; set; }
        public string MushtriFareeqIdTaqseem { get; set; }
        public bool IsJuzviKhatta { get; set; }
        //  public string RegisterHqDKhataId { get; set; }
        /// <summary>
        /// get or set entry mode
        /// </summary>
        public int EntryMode { get; set; }
        /// <summary>
        /// get or set Moza id
        /// </summary>
        public int MozaId { get; set; }
        // Registry Fard Token
        public string FardTokenId { get; set; }

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
                // this.lblMozaName.Text = value;
            }
        }

        #endregion

        #region Default Constructor

        public frmIntiqalKhattaJat()
        {
            InitializeComponent();
        }

        #endregion

        #region Code for Tab IntiqalKhataJat

        #region Custom Methods

        private void fillIntiqalkhatajatList(string mozaId)
        {
            try
            {
                this.dtkj = inteq.GetKhataJatForintiqalByMozaId(mozaId);
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر چنیے - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbokhataNo.DataSource = dtkj;
                cbokhataNo.DisplayMember = "KhataNo";
                cbokhataNo.ValueMember = "RegisterHqDKhataId";
                cbokhataNo.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void fillRegistryIntiqalkhatajatList(string fardTokenId)
        //{
        //    try
        //    {
        //        this.dtkj = inteq.GetKhataJatForRegistryintiqalByFardTokenId(FardTokenId);
        //        DataRow inteqKj = dtkj.NewRow();
        //        inteqKj["RegisterHqDKhataId"] = "0";
        //        inteqKj["KhataNo"] = " - کھاتہ نمبر چنیے - ";
        //        dtkj.Rows.InsertAt(inteqKj, 0);
        //        cbokhataNo.DataSource = dtkj;
        //        cbokhataNo.DisplayMember = "KhataNo";
        //        cbokhataNo.ValueMember = "RegisterHqDKhataId";
        //        cbokhataNo.SelectedValue = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        #region Set AmalDaramadStatus
        private void SetAmalDaramadStatus(bool Status)
        {
            DataTable minGroups = Intiqal.GetIntiqalMinGroup(this.IntiqalId);
            int mingrp = 0;
            if (minGroups != null)
            {
                if (minGroups.Rows.Count > 0)
                {
                    mingrp = 1;
                }
                else
                {
                    mingrp = 0;
                }
            }
            if (mingrp == 0)
            {
                this.groupBox19.Visible = false; // TAQSIM GROUP VISIALBE FALSE
                gbAmalDaramad.Visible = true;  
                if (Status)
                {
                    lblMutStatus.Text = "عمل درامد شدہ";
                    lblMutStatus.ForeColor = Color.Green;
                    //this.IntiqalStatus = false;
                    btnAmaldaramad.Enabled = false;
                    this.btnWarisanManderjaKhata.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbSellersControls.Enabled = false;
                    this.PanelBuyersControl.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.btndeletenewKhassra.Enabled = false;

                   // this.panel5.Enabled = false;
                   // this.gbIntiqalKhatajat.Enabled = false;
                    //this.groupBox25.Enabled = false;

                }
                else if(this.isAttested)
                {
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                       
                       
                            btnAmaldaramad.Enabled = true;
                        
                        this.btnWarisanManderjaKhata.Enabled = false;
                       
                        this.gbKhataMainContols.Enabled = false;
                        this.gbSellersControls.Enabled = false;
                        this.PanelBuyersControl.Enabled = false;
                        this.gbSubKhataControls.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnSaveKhatonichagne.Enabled = false;
                        this.btnDeleteKhatoonichange.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.btndeletenewKhassra.Enabled = false;
                    }
                    else if (isConfirmed)
                    {
                            lblMutStatus.Text = " عمل درامد زیر غور";
                            lblMutStatus.ForeColor = Color.Red;
                           
                            btnAmaldaramad.Enabled = false;
                            this.btnWarisanManderjaKhata.Enabled = false;
                            btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                            gbSellersControls.Enabled = false;
                            PanelBuyersControl.Enabled = false;
                            gbKhataMainContols.Enabled = false;
                            this.gbSubKhataControls.Enabled = false;
                            this.btnSaveChangeMalikan.Enabled = false;
                            this.btndeleteChangeMalikan.Enabled = false;
                            this.btnSaveKhatonichagne.Enabled = false;
                            this.btnDeleteKhatoonichange.Enabled = false;
                            this.btnsavenewkhasra.Enabled = false;
                            this.btndeletenewKhassra.Enabled = false;
                    }
             
                else
                {
                    lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                    // this.IntiqalStatus = false;
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                }
                
                       
                   
            }
            else if (mingrp == 1)
            {
                this.groupBox19.Visible = true;// TAQSIM GROUP VISIALBE true
                gbAmalDaramad.Visible = true;
                if (Status)
                {
                    lblMutStatus.Text = "عمل درامد شدہ";
                    lblMutStatus.ForeColor = Color.Green;
                    //this.IntiqalStatus = false;
                    btnAmaldaramad.Enabled = false;
                    this.btnWarisanManderjaKhata.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbSellersControls.Enabled = false;
                    this.PanelBuyersControl.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.btndeletenewKhassra.Enabled = false;

                    this.groupBox17.Enabled = false;
                    this.groupBox18.Enabled = false;
                }
                else if(isAttested)
                {
                   
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;

                       
                            btnAmaldaramad.Enabled = true;
                       
                        this.btnWarisanManderjaKhata.Enabled = false;
                        //btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        this.gbKhataMainContols.Enabled = false;
                        this.gbSellersControls.Enabled = false;
                        this.PanelBuyersControl.Enabled = false;
                        this.gbSubKhataControls.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnSaveKhatonichagne.Enabled = false;
                        this.btnDeleteKhatoonichange.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.btndeletenewKhassra.Enabled = false;

                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                }
                    else if(isConfirmed)
                    {

                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                        btnAmaldaramad.Enabled = false;
                        btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        this.btnWarisanManderjaKhata.Enabled = false;

                         gbSellersControls.Enabled = false;
                            PanelBuyersControl.Enabled = false;
                            gbKhataMainContols.Enabled = false;
                            this.gbSubKhataControls.Enabled = false;
                            this.btnSaveChangeMalikan.Enabled = false;
                            this.btndeleteChangeMalikan.Enabled = false;
                            this.btnSaveKhatonichagne.Enabled = false;
                            this.btnDeleteKhatoonichange.Enabled = false;
                            this.btnsavenewkhasra.Enabled = false;
                            this.btndeletenewKhassra.Enabled = false;

                       
                       
                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                       
                       
                    }
                else
                {
                         lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                    // this.IntiqalStatus = false;
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    }

                }

            this.txtSearchSeller.Enabled = true;
           }
        #endregion

        #endregion

        private void frmkhatta_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            //FillGridMalikanChange();
            if (UsersManagments.Implementation == "0")
            {
                this.btnAmaldaramad.Visible = false;
            }
            TaqseemNewTabDisable();
            if (IntiqalId != "-1")
            {
                txtParentid.Text = IntiqalId.ToString();///get for newtaqseem tab
                                                        ///
                //// =================for wirasat intiqal  =============================

                //if (IntiqalTypeId == "37")
                //{
                //    AutoFillCombo.FillCombo("proc_Self_Get_Rishta ", cmbRishta, "Rishta", "RishtaId");
                //    cmbRishta.Visible = true;
                //    lbRishta.Visible = true;

                //}
                //else
                //{
                    tabControl1.TabPages.Remove(tabPageShajra);
                //}
                ////========== end =============================================================

                    fillIntiqalkhatajatList(this.MozaId.ToString());

                if (this.FardTokenId != "0")
                {
                    //fillRegistryIntiqalkhatajatList(this.FardTokenId.ToString());
                    
                }
                else
                {
                    //fillIntiqalkhatajatList(this.MozaId.ToString());
                    lbFard.Visible = false;
                    txtFardFeet.Visible = false;
                    txtFardHissay.Visible = false;
                    txtFardKanal.Visible = false;
                    txtFardMarla.Visible = false;
                    txtFardSarsai.Visible = false;
                    lbTotal.Visible = false;
                    lbTokenDate.Visible = false;
                    lbTokenNo.Visible = false;
                    dtFardToken.Visible = false;
                    cmbFardTokenNo.Visible = false;
                    //groupBox15.Visible = false;
                    cboPersonSeller.Location = new Point(13, 53);
                    groupBox9.Size = new Size(358, 126);
                    groupBox9.Location = new Point(896, 30);
                }
                Fill_InteqalKhataGrid();
                txtKhattaRecId.Text = "-1";
                this.MinhayeIntiqals = Intiqal.GetIntiqalMinhayeIntiqals(this.IntiqalId);
                AutoFillCombo.FillCombo("proc_Get_AreaTypes " + UsersManagments._Tehsilid.ToString(), cmbAreaTypesTaqseem, "AreaType", "AreaTypeId");
                this.SetAmalDaramadStatus(this.AmalDaramad);
                if (this.IntiqalPending)
                {
                    this.btnAmaldaramad.Enabled = false;
                    this.btnAmalDaramadTaqseem.Enabled = false;
                    this.btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                }
                //Set Attestation Status
                //if (this.isAttested)
                //{
                //    gbBuyersControls.Enabled = false;
                //    //gbSellersControls.Enabled = false; 
                //    gbKhataMainContols.Enabled = false;
                //    gbSubKhataControls.Enabled = false;
                //    gbSubKhataMalkan.Enabled = false;
                //    gbSubKhataKhatooni.Enabled = false;
                //    gbSubKhataKhassras.Enabled = false;
                  
                //}
              

            }
            else
            {
                this.Close();
                MessageBox.Show("انتقال لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //AutoComplete on = new AutoComplete();
            //on.FillCombo("Proc_Get_AreaTypes_List ", this.cmbKhassraType, "AreaType", "AreaTypeId");

            Fill_InteqalGrid();
            btnsavemingroup.Enabled = false;
            if (IntiqalMinGroupId != string.Empty)
            {
                txtGroupMinId.Text = IntiqalMinGroupId;
                cboMinGroups.Text = MinGroupNo;
            }

            if (MalkiatKashkat)
            {
                Khatoniid = "NULL";
                KhatoniRecid = "NUll";
                groupBox13.Visible = false;
            }
            else
            {
                groupBox16.Visible = false;
                groupBox22.Visible = false;
                // chkMushtharaqa.Visible = false;
            }

            // ================= show / hide tabs for taqseem intiqal ======================

            //if (IntiqalTypeId != "15")
            //{
            //    tabControl1.TabPages.Remove(tabPage4);
            //    tabControl1.TabPages.Remove(tabPage5);

            //}


            //==================== end =======================================

        }

        #region Taqseem New Khata Controls Diable / Enable

        public void TaqseemNewTabDisable()
        {
            txtKhataNoChange.Enabled = false;
            txthissayChagne.Enabled = false;
            txtKanalChange.Enabled = false;
            txtMarlayChange.Enabled = false; txtSarsasiChange.Enabled = false; txtFeetChange.Enabled = false; txtMaliaChange.Enabled = false; txtKefiyatChange.Enabled = false; btnSaveChange.Enabled = false;
            btnDeleteChange.Enabled = false;
            btnClearChange.Enabled = false;
        }
        public void TaqseemNewTabEnable()
        {
            btnDeleteChange.Enabled = true;
            btnClearChange.Enabled = true;
            txtKhataNoChange.Enabled = true;
            txthissayChagne.Enabled = true;
            txtKanalChange.Enabled = true;
            txtMarlayChange.Enabled = true; txtSarsasiChange.Enabled = true; txtFeetChange.Enabled = true; txtMaliaChange.Enabled = true; txtKefiyatChange.Enabled = true; btnSaveChange.Enabled = true;
        }

        #endregion

        private void btnSearchInteqal_Click(object sender, EventArgs e)
        {

        }

        private void cboIntiqalType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnSaveWarsanManderjaKhatta_Click(object sender, EventArgs e)
        {

        }

        private void txtKharidFeet_Leave(object sender, EventArgs e)
        {

        }


        private void txtKharidSarsai_Leave(object sender, EventArgs e)
        {

        }

        #region Fill Grid view method

        public void Fill_InteqalKhataGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = inteq.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
                GridViewInteqalKhattas.DataSource = dt;
                GridViewInteqalKhattas.Columns["IntiqalId"].Visible = false;
                GridViewInteqalKhattas.Columns["IntiqalKhataId"].Visible = false;
                GridViewInteqalKhattas.Columns["IntiqalKhataRecId"].Visible = false;
                GridViewInteqalKhattas.Columns["AmaldaramadStatus"].Visible = false;
                GridViewInteqalKhattas.Columns["AmaldaramadDate"].Visible = false;
                GridViewInteqalKhattas.Columns["IsJuzviKhatta"].Visible=false;
                GridViewInteqalKhattas.Columns["TotalParts"].Visible = false;
                GridViewInteqalKhattas.Columns["Kanal"].Visible = false;
                GridViewInteqalKhattas.Columns["Marla"].Visible = false;
                GridViewInteqalKhattas.Columns["Sarsai"].Visible = false;
                GridViewInteqalKhattas.Columns["Feet"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private void btnSaveKhatta_Click(object sender, EventArgs e)
        {
            SaveIntiqalKhata();
            //KhataControlsDisable();
            btnNewKhatta.Enabled = true;
            Fill_InteqalKhataGrid();
            Fill_InteqalGrid();

        }
        private void SaveIntiqalKhata()
        {
            try
            {
                string KhataRecId = txtKhattaRecId.Text.ToString();
                string khataid = cbokhataNo.SelectedValue.ToString();
                string intiqalId = this.IntiqalId;
                string LastId = inteq.SaveintiqalKhataJaat(KhataRecId, intiqalId, khataid, UsersManagments.UserId.ToString());
                if (LastId == "-1")
                {
                    MessageBox.Show(" کھاتہ میں خانہ کاشت موجود ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LastId == "-2")
                {
                    MessageBox.Show(" خانہ کاشت سے ملکیت گوشوارہ منسلک نہیں ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //txtKhattaRecId.Text = LastId;
                txtKhattaRecId.Text = "-1";
                txtparentKhataId.Text = "-1";
                cbokhataNo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewKhatta_Click(object sender, EventArgs e)
        {
            txtKhattaRecId.Text = "-1";
            txtparentKhataId.Text = "-1";
            cbokhataNo.SelectedIndex = 0;
            Fill_InteqalKhataGrid();
        }
        private void cbokhataNo_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnDelIntiqalKhatta_Click(object sender, EventArgs e)
        {


            if (txtKhattaRecId.Text != "-1" && txtKhattaRecId.Text != "")
            {
                try
                {
                    inteq.DeleteIntiqalKhattajat(this.txtKhattaRecId.Text);
                    txtKhattaRecId.Text = "-1";
                    txtparentKhataId.Text = "-1";
                    cbokhataNo.SelectedIndex = 0;
                    Fill_InteqalKhataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("برائے مہربانی کھاتہ چنیے");
        }

        private void GridViewInteqalKhattas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridViewInteqalKhattas.Columns["Sellers"].Index && e.RowIndex >= 0)
            {



            }

        }
        private void frmIntiqalSellers_FormClosed(object sender, FormClosedEventArgs e)
        {

            // frmIntiqalSellers frmIntiqalSellers = sender as frmIntiqalSellers;

        }

        private void GridViewInteqalKhattas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboPersonSeller.DataSource = null;
                GridSellerList.DataSource = null;
                GridBuyersList.DataSource = null;
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (GridViewInteqalKhattas.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                           
                            row.Cells["colChoose"].Value = 1;
                            txtKhattaRecId.Text = row.Cells["IntiqalKhataRecId"].Value.ToString();
                            IntiqalKhataRecId = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataRecId"].Value.ToString();
                            this.cbokhataNo.SelectedValue = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataId"].Value.ToString();
                            IntiqalKhataId = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataId"].Value.ToString();
                            this.txtparentKhataId.Text = IntiqalKhataId;
                            NewKhataCreate = GridViewInteqalKhattas.CurrentRow.Cells["KhataNo"].Value.ToString();
                            IsJuzviKhatta = Convert.ToBoolean(GridViewInteqalKhattas.CurrentRow.Cells["IsJuzviKhatta"].Value.ToString());;
                            cbJuzviKhata.Checked = IsJuzviKhatta;
                            KhataHissa = float.Parse(GridViewInteqalKhattas.CurrentRow.Cells["TotalParts"].Value.ToString());
                            KhataKanal = Convert.ToInt32(GridViewInteqalKhattas.CurrentRow.Cells["Kanal"].Value.ToString());
                            KhataMarla = Convert.ToInt32(GridViewInteqalKhattas.CurrentRow.Cells["Marla"].Value.ToString());
                            KhataSarsai = float.Parse(GridViewInteqalKhattas.CurrentRow.Cells["Sarsai"].Value.ToString());
                            KhataFeet = float.Parse(GridViewInteqalKhattas.CurrentRow.Cells["Feet"].Value.ToString());

                            //cbJuzviKhata_CheckedChanged(sender, e);
                            if (IntiqalKhataId != string.Empty)
                            {

                                if(this.FardTokenId!="0" && this.FardTokenId!=null)
                                    AutoFillCombo.FillCombo("proc_Self_Get_RegistryIntiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'" + "," + FardTokenId, cboPersonSeller, "personname", "KhewatGroupFareeqId");
                                else
                                    AutoFillCombo.FillCombo("proc_Get_Intiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'", cboPersonSeller, "personname", "KhewatGroupFareeqId");
                                proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                                FillgridByBuyerList();

                            }


                            Fill_ComboKhewatTypes();
                            gridselection();
                            btnNewBuyer_Click(sender, e);
                            CalculateSellerBuyerRaqbaHissa();
                            txthiddenBuyerRecId.Text = "-1";
                            this.FillGridviewSalamJuzviKhassra();
                            // this.cbJuzviKhata.Enabled = true;
                            // this.IsJuzviKhatta = inteq.GetIntiqalKhataJuzviStatus(IntiqalKhataRecId);
                            //this.cbJuzviKhata.Checked = this.IsJuzviKhatta;
                            //FillgridByBuyerList();
                        }
                        else
                        {
                            row.Cells["colChoose"].Value = 0;
                            //this.cbJuzviKhata.Enabled = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Method for Checking Khatta Min Status



        #endregion

        private void btnKhatoniSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool duplication = true;
                string IntiqalKhatooniRecId = txtIntiqalKhatooniRecId.Text.ToString();
                string KhatoniId = this.cmbKhatoniNo.SelectedValue.ToString();
                string intiqalId = this.IntiqalId;
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
                            string LastId = inteq.SaveintiqalKhatoni(IntiqalKhatooniRecId, intiqalId, IntiqalKhataRecId, IntiqalKhataId, KhatoniId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                            txtIntiqalKhatooniRecId.Text = LastId;
                            GetKhatoni(IntiqalKhataId);
                        }
                    }
                    else
                    {
                        string LastId = inteq.SaveintiqalKhatoni(IntiqalKhatooniRecId, intiqalId, IntiqalKhataRecId, IntiqalKhataId, KhatoniId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        txtIntiqalKhatooniRecId.Text = LastId;
                        GetKhatoni(IntiqalKhataId);
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

        public void GetKhatoni(string IntiqalKhataId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = inteq.GetKhatoniDetails(IntiqalKhataId);
                grdKhatoniDetails.DataSource = dt;
                grdKhatoniDetails.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "کھتونی نمبر";
                grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].Visible = false;
                grdKhatoniDetails.Columns["IntiqalKhatooniRecId"].Visible = false;
                grdKhatoniDetails.Columns["KhatooniId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKhatoniClear_Click(object sender, EventArgs e)
        {
            txtIntiqalKhatooniRecId.Text = "-1";
        }

        private void grdKhatoniDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    grdKhatoniDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == grdKhatoniDetails.CurrentRow.Cells["chkkhatoni"].ColumnIndex)
                    {

                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (grdKhatoniDetails.SelectedRows.Count > 0)
                            {

                                if (row.Selected)
                                {

                                    row.Cells["chkkhatoni"].Value = true;
                                    this.txtIntiqalKhatooniRecId.Text = this.grdKhatoniDetails.CurrentRow.Cells["IntiqalKhatooniRecId"].Value.ToString();
                                    Khatoniid = this.grdKhatoniDetails.CurrentRow.Cells["KhatooniId"].Value.ToString();
                                    KhatoniRecid = this.grdKhatoniDetails.CurrentRow.Cells["IntiqalKhatooniRecId"].Value.ToString();
                                    string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                                    string IntiqalKhatooniRecId = txtIntiqalKhatooniRecId.Text.ToString();
                                    FillgridByBuyerList();
                                    proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhattaRecId, IntiqalKhatooniRecId);

                                }
                                else
                                {
                                    row.Cells["chkkhatoni"].Value = false;
                                    //grfIntiqalPersonSanps.Rows.Clear();
                                }
                            }
                        }
                    }

                    if (!MalkiatKashkat)
                    {
                        AutoFillCombo.FillCombo("proc_Get_Intiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'", cboPersonSeller, "personname", "MushtriFareeqId");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbKhatoniNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtIntiqalKhatooniRecId.Text = "-1";
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        #region Code for Tab IntiqalSellers

        #region LoadForm
        private void frmIntiqalSellers_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            //if (IntiqalKhataId != string.Empty)
            //{
            //    AutoFillCombo.FillCombo("proc_Get_Intiqal_Khata_Malkan '" + IntiqalKhataId + "'", cboPersonSeller, "personname", "KhewatGroupFareeqId");
            //}
            //txtHiddenKhataRecID.Text = IntiqalKhataRecId;
            //txtKhataID.Text = IntiqalKhataId;
            //proc_Get_Intiqal_Sellers_List_ByKhata();
            //GridSellerList1.ClearSelection();
        }

        public void proc_Get_Intiqal_Sellers_List_ByKhata(string IntiqalKhattaRecId, string IntiqalKhatooniRecId)
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt = inteq.GetintiqalSellersListByKhataRecId(IntiqalKhattaRecId, IntiqalKhatooniRecId, MalkiatKashkat.ToString());
                // dt = Intiqal.GetintiqalSellersListByKhataRecId(IntiqalKhataRecId);
                if (dtt != null)
                {
                    bs.DataSource = dtt;
                    GridSellerList.DataSource = bs;
                    GridSellerList.DataSource = dtt;
                    if (dtt != null)
                    {
                        FillGridIntiqalKhataRecId();
                    }
                }
                else
                {
                    MessageBox.Show("کوئی ریکارڈ نہں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Calculated Area

        private void btnHisaBamutabiqRaqba_Click(object sender, EventArgs e)
        {
            CalulateArea();
        }
        public void CalulateArea()
        {
            try
            {
                float khissayWOTM = txtKulHissayWOTminhay.Text.Trim() != "" ? float.Parse(txtKulHissayWOTminhay.Text.Trim()) : 0;
                float khissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
                float shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
                float fhissay = txtFardHissay.Text.Trim() != "" ? float.Parse(txtFardHissay.Text.Trim()) : 0;
               
                //Owners raqba
                int kkanal = txtKullKanal.Text.Trim() != "" ? Convert.ToInt32(txtKullKanal.Text.Trim()) : 0;
                int kmarla = txtKullMarla.Text.Trim() != "" ? Convert.ToInt32(txtKullMarla.Text.Trim()) : 0;
                float ksarsai = txtKullSarsai.Text.Trim() != "" ? float.Parse(txtKullSarsai.Text.Trim()) : 0;
                float ksft = txtKulFeet.Text.Trim() != "" ? float.Parse(txtKulFeet.Text.Trim()) : 0;
                //decimal raqbainSft = (kkanal * 20 * (decimal)272.25) + (kmarla * (decimal)272.25) + ksft; //+ ((ksarsai / 9) * 272) sarsai not included in raqba
               
                //Buyers Raqba
                int bkanal = txtFrokhtKanal.Text.Trim() != "" ? Convert.ToInt32(txtFrokhtKanal.Text.Trim()) : 0;
                int bmarla = txtFrokhtMarla.Text.Trim() != "" ? Convert.ToInt32(txtFrokhtMarla.Text.Trim()) : 0;
                float bsarsai = txtFrokhtSarsai.Text.Trim() != "" ? float.Parse(txtFrokhtSarsai.Text.Trim()) : 0;
                float bsft = txtFrokhtFeet.Text.Trim() != "" ? float.Parse(txtFrokhtFeet.Text.Trim()) : 0;

                //Buyers Raqba of Fard
                int fkanal = txtFardKanal.Text.Trim() != "" ? Convert.ToInt32(txtFardKanal.Text.Trim()) : 0;
                int fmarla = txtFardMarla.Text.Trim() != "" ? Convert.ToInt32(txtFardMarla.Text.Trim()) : 0;
                float fsarsai = txtFardSarsai.Text.Trim() != "" ? float.Parse(txtFardSarsai.Text.Trim()) : 0;
                float fsft = txtFardFeet.Text.Trim() != "" ? float.Parse(txtFardFeet.Text.Trim()) : 0;
                int mkhDecimal = shissay.ToString().Length - (((int)shissay).ToString().Length + 1); //CommanFunctions.GetDecimalPlaces(shissay); 
                mkhDecimal = mkhDecimal > 0 ? mkhDecimal : 0;
                if (txtFrokhtHisay.Text.Trim() != "" && txtFrokhtHisay.Text != "0")
                {
                    txtFrokhtKanal.Text = "";
                    txtFrokhtMarla.Text = "";
                    txtFrokhtSarsai.Text = "";
                    txtFrokhtFeet.Text = "";

                    if (this.FardTokenId!=null && this.FardTokenId != "0")
                    {
                        if (Math.Round(shissay, mkhDecimal) > Math.Round(fhissay, mkhDecimal))
                        {
                            MessageBox.Show("مالک اس فرد کے بقایا حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else if (Math.Round(shissay, mkhDecimal) > Math.Round(khissayWOTM, mkhDecimal) || Math.Round(shissay, mkhDecimal) > Math.Round(khissay, mkhDecimal))
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            //string[] raqba = CommanFunctions.CalculatedAreaFromHisa(fhissay, shissay, fkanal, fmarla, fsarsai, fsft);
                            //string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                            string[] raqba = CommanFunctions.CalculatedAreaFromHisa(KhataHissa, shissay, KhataKanal, KhataMarla, KhataSarsai, KhataFeet);
                            txtFrokhtKanal.Text = raqba[0];
                            txtFrokhtMarla.Text = raqba[1];
                            txtFrokhtSarsai.Text = raqba[2];
                            txtFrokhtFeet.Text = raqba[3];
                        }
                    }
                    else
                    {
                        decimal val = Math.Round(decimal.Parse(khissayWOTM.ToString()), mkhDecimal);
                        if (Math.Round(shissay, mkhDecimal) > Math.Round(khissayWOTM, mkhDecimal) || Math.Round(shissay, mkhDecimal) > Math.Round(khissay, mkhDecimal))
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            string[] raqba;
                            if (cbJuzviKhata.Checked)
                            {
                                int Khassra_Kanal = 0; int Khassra_Marla = 0; float Khassra_Sarsai = 0; float Khassra_Feet = 0;
                                if (GridviewSaveSalamJuzviKhassra.DataSource != null)
                                {
                                    if (GridviewSaveSalamJuzviKhassra.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in GridviewSaveSalamJuzviKhassra.Rows)
                                        {
                                            Khassra_Kanal = Khassra_Kanal + int.Parse(row.Cells["Min_Kanal"].Value.ToString());
                                            Khassra_Marla = Khassra_Marla + int.Parse(row.Cells["Min_Marla"].Value.ToString());
                                            Khassra_Sarsai = Khassra_Sarsai + float.Parse(row.Cells["Min_Sarsai"].Value.ToString());
                                            Khassra_Feet = Khassra_Feet + float.Parse(row.Cells["Min_Feet"].Value.ToString());
                                        }
                                    }
                                }
                                raqba = CommanFunctions.CalculatedAreaFromHisa(KhataHissa, shissay, Khassra_Kanal, Khassra_Marla, Khassra_Sarsai, Khassra_Feet);
                            }
                            else
                                raqba = CommanFunctions.CalculatedAreaFromHisa(KhataHissa, shissay, KhataKanal, KhataMarla, KhataSarsai, KhataFeet);
                            txtFrokhtKanal.Text = raqba[0];
                            txtFrokhtMarla.Text = raqba[1];
                            txtFrokhtSarsai.Text = raqba[2];
                            txtFrokhtFeet.Text = raqba[3];
                        }
                    }

                }
                else
                {
                    if (this.FardTokenId != "0" && this.FardTokenId != null)
                    {
                        txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
                        fhissay = txtFardHissay.Text.Trim() != "" ? float.Parse(txtFardHissay.Text.Trim()) : 0;
                        shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
                        if (shissay > fhissay)
                        {
                            MessageBox.Show("مالک اس فرد کے بقایا حصے سے زیادہ حصے فروخت نہیں کر سکتے", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                    }
                    else
                    {
                        if (cbJuzviKhata.Checked)
                        {
                            int Khassra_Kanal = 0; int Khassra_Marla = 0; float Khassra_Sarsai = 0; float Khassra_Feet = 0;
                            if (GridviewSaveSalamJuzviKhassra.DataSource != null)
                            {
                                if (GridviewSaveSalamJuzviKhassra.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in GridviewSaveSalamJuzviKhassra.Rows)
                                    {
                                        Khassra_Kanal = Khassra_Kanal + int.Parse(row.Cells["Min_Kanal"].Value.ToString());
                                        Khassra_Marla = Khassra_Marla + int.Parse(row.Cells["Min_Marla"].Value.ToString());
                                        Khassra_Sarsai = Khassra_Sarsai + float.Parse(row.Cells["Min_Sarsai"].Value.ToString());
                                        Khassra_Feet = Khassra_Feet + float.Parse(row.Cells["Min_Feet"].Value.ToString());
                                    }
                                }
                            }
                            txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(float.Parse( GridViewInteqalKhattas.SelectedRows[0].Cells["TotalParts"].Value.ToString()), shissay, Khassra_Kanal, Khassra_Marla, Khassra_Sarsai, Khassra_Feet, bkanal, bmarla, bsarsai, bsft).ToString();
                        }
                        else
                        txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(KhataHissa, shissay, KhataKanal, KhataMarla, KhataSarsai, KhataFeet, bkanal, bmarla, bsarsai, bsft).ToString();

                        khissayWOTM = txtKulHissayWOTminhay.Text.Trim() != "" ? float.Parse(txtKulHissayWOTminhay.Text.Trim()) : 0;
                        khissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
                        shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
                        if (shissay > khissay)
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
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

        #region Save,FillGrid Of Seller


        public void FillGridIntiqalKhataRecId()
        {
            try
            {
                GridSellerList.Columns["checkListNew"].DisplayIndex = 0;
                GridSellerList.Columns["PersonName"].DisplayIndex = 1;
                GridSellerList.Columns["KhewatType"].DisplayIndex = 2;

                GridSellerList.Columns["Seller_Total_Hissa"].DisplayIndex = 3;
                GridSellerList.Columns["Seller_Total_Area"].DisplayIndex = 4;

                GridSellerList.Columns["Seller_Sold_Hissa"].DisplayIndex = 5;
                GridSellerList.Columns["Seller_Sold_Area"].DisplayIndex = 6;
                GridSellerList.Columns["colMutwafiKhataJat"].DisplayIndex = 12;

                GridSellerList.Columns["checkListNew"].HeaderText = "انتخاب کریں";
                GridSellerList.Columns["PersonName"].HeaderText = "نام";
                GridSellerList.Columns["KhewatType"].HeaderText = "فرد کی قسم";

                GridSellerList.Columns["Seller_Total_Hissa"].HeaderText = "کل حصہ";
                GridSellerList.Columns["Seller_Total_Area"].HeaderText = "کل رقبہ";

                GridSellerList.Columns["Seller_Sold_Hissa"].HeaderText = " حصہ منتقلہ";
                GridSellerList.Columns["Seller_Sold_Area"].HeaderText = "رقبہ منتقلہ";

                GridSellerList.Columns["IntiqalSellerRecId"].Visible = false;
                GridSellerList.Columns["IntiqalKhataRecId"].Visible = false;
                GridSellerList.Columns["IntiqalSellerPersonId"].Visible = false;
                GridSellerList.Columns["SellerPersonDied"].Visible = false;
                GridSellerList.Columns["SellerPersonDeathDate"].Visible = false;
                GridSellerList.Columns["IntiqalKhatooniRecId"].Visible = false;
                GridSellerList.Columns["MushtriFareeqId"].Visible = false;
                GridSellerList.Columns["Seller_Total_Marla"].Visible = false;
                GridSellerList.Columns["Seller_Total_Kanal"].Visible = false;
                GridSellerList.Columns["Seller_Total_Sarsai"].Visible = false;
                GridSellerList.Columns["Seller_Total_Feet"].Visible = false;
                GridSellerList.Columns["Seller_Sold_Kanal"].Visible = false;
                GridSellerList.Columns["Seller_Sold_Marla"].Visible = false;
                GridSellerList.Columns["Seller_Sold_Sarsai"].Visible = false;
                GridSellerList.Columns["Seller_Sold_Feet"].Visible = false;

            
                GridSellerList.Columns["KhewatTypeId"].Visible = false;
                GridSellerList.Columns["KhewatGroupFareeqId"].Visible = false;
                GridSellerList.Columns["FardTokenId"].Visible = false;
                GridSellerList.Columns["FardTokenDate"].Visible = false;
                datacontrols.colorrbackgrid(GridSellerList);
                datacontrols.gridControls(GridSellerList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridSellerList1_SelectionChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region ClearForm
        private void btnNewSeller_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            this.txtKulFeet.Text = "";
            this.txtKulHissayWOTminhay.Text = "";
            this.txtKulHisay.Text = "";
            this.txtKullMarla.Text = "";
            this.txtKullSarsai.Text = "";
            this.txtKullKanal.Text = "";

            this.txtFrokhtHisay.Text = "";
            this.txtFrokhtFeet.Text = "";
            this.txtFrokhtKanal.Text = "";
            this.txtFrokhtSarsai.Text = "";
            this.txtFrokhtMarla.Text = "";

            this.txtMushterkaKanal.Text = "";
            this.txtMushterkaSarsai.Text = "";
            this.lblMushterkaMarla.Text = "";

            this.txtFardHissay.Text = "";
            this.txtFardKanal.Text = "";
            this.txtFardMarla.Text = "";
            this.txtFardSarsai.Text = "";
            this.txtFardFeet.Text = "";

            groupBox22.Enabled = false;
            //chkMushtharaqa.Enabled = false;
            //chkMushtharaqa.Checked = false;

            chkDeath.Checked = false;
            txtSellerID.Text = "-1";
            if (cboPersonSeller.Items.Count > 0)
            {
                cboPersonSeller.SelectedIndex = 0;
            }
            txtHiddenPersonID.Text = "";

            //txtHiddenKhataRecID.Text = row.Cells["IntiqalKhataRecId"].Value.ToString();
        }
        #endregion

        #region Delete Seller
        private void btnDelSeller_Click(object sender, EventArgs e)
        {
            string IntiqalSellerId = this.txtSellerID.Text.ToString();
            try
            {
                if (IntiqalSellerId != "-1")
                {
                    if (MessageBox.Show(" کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = Intiqal.DeleteIntiqalSeller(IntiqalSellerId);
                        string IntiqalKhatooniRecId;
                        if (dt != null)
                        {
                            txtSellerID.Text = "-1";
                            proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                            CalculateSellerBuyerRaqbaHissa();
                            btnDelSeller.Enabled = false;
                            ClearAll();

                        }

                    }
                }
                else
                {
                    MessageBox.Show("ریکاڈکاانتخاب کریں", "ریکارڈ کا انتخاب کریں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Find in Grid
        public void fillgrid_byfilter(string Condition)
        {

            try
            {
                if (dt != null)
                {
                    DataView v = new DataView(dt);
                    v.RowFilter = Condition;
                    this.GridSellerList.DataSource = v;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchSeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Name = this.txtSearchSeller.Text;
                this.fillgrid_byfilter("PersonName like '%" + Name + "%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GridSellerList1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                GridSelection = false;

                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == GridSellerList.CurrentRow.Cells["checkListNew"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (GridSellerList.SelectedRows.Count > 0)
                        {
                            btnDelSeller.Enabled = true;
                            if (row.Selected)
                            {

                                row.Cells["checkListNew"].Value = 1;
                                if (this.FardTokenId != "0" && this.FardTokenId != null)
                                {
                                    dtFardToken.Value = Convert.ToDateTime(row.Cells["FardTokenDate"].Value);
                                    cmbFardTokenNo.SelectedValue = row.Cells["FardTokenId"].Value;

                                }
                                this.cboPersonSeller.SelectedValue = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                this.txtFrokhtHisay.Text = row.Cells["Seller_Sold_Hissa"].Value.ToString();
                                this.txtFrokhtKanal.Text = row.Cells["Seller_Sold_Kanal"].Value.ToString();
                                this.txtFrokhtMarla.Text = row.Cells["Seller_Sold_Marla"].Value.ToString();
                                this.txtFrokhtSarsai.Text = row.Cells["Seller_Sold_Sarsai"].Value.ToString();
                                this.txtFrokhtFeet.Text = row.Cells["Seller_Sold_Feet"].Value.ToString();


                                this.txtHiddenKewatGroupFareeqID.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                txtHiddenPersonID.Text = row.Cells["IntiqalSellerPersonId"].Value.ToString();

                                //------------------------ for remaining area in case of updatation

                                DataTable dtFareeqain = new DataTable();
                                DataTable dtFard = new DataTable();
                                if (this.FardTokenId != "0")
                                {
                                  
                                    dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaRegistryIntiqal(row.Cells["KhewatGroupFareeqId"].Value.ToString(), this.FardTokenId);
                                    dtFard = mnk.GetFardKhewatFareeqainRemainingAreaofFard(row.Cells["KhewatGroupFareeqId"].Value.ToString(), row.Cells["IntiqalSellerPersonId"].Value.ToString(), this.FardTokenId);

                                }
                                else
                                {
                                    dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaNewFard(row.Cells["KhewatGroupFareeqId"].Value.ToString());
                                }

                                if (dtFareeqain.Rows.Count > 0)
                                {
                                    double KulHissayWOTM = Convert.ToDouble(dtFareeqain.Rows[0]["FardAreaPartTotal"].ToString());
                                    double KulHissay = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Hissa"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Hissa"].Value.ToString());
                                    double KulKanal = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Kanal"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Kanal"].Value.ToString());
                                    double KulMarla = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Marla"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Marla"].Value.ToString());
                                    double KulSarsai = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Sarsai"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Sarsai"].Value.ToString());
                                    double KulFeet = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Feet"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Feet"].Value.ToString());

                                    //================================= function for raqba calculate =============================

                                    double PersonRaqba = ((KulKanal * 20 + KulMarla) * 272.25) + (KulSarsai > 0 ? KulSarsai * 30.25 : KulFeet);
                                   
                                    
                                    if (PersonRaqba >= 272.25)
                                    {
                                        KulFeet = PersonRaqba % 272.25;
                                        KulMarla = Convert.ToInt32((PersonRaqba - KulFeet) / 272.25);

                                        if (KulMarla >= 20)
                                        {
                                            KulKanal = (KulMarla - (KulMarla % 20)) / 20;
                                            KulMarla = KulMarla % 20;
                                          

                                        }
                                        else
                                        {
                                            KulKanal = 0;
                                        }

                                    }
                                    else
                                    {
                                        KulMarla = 0;
                                        KulKanal = 0;
                                       
                                    }
                                    if (KulFeet > 0)
                                    {
                                        KulSarsai = Math.Round(KulFeet / 30.25, 4);
                                    }
                                    else
                                    {
                                        KulSarsai = 0;
                                    }
                                    

                                    //================================================================================================

                                    txtKulHissayWOTminhay.Text = KulHissayWOTM.ToString();
                                    txtKulHisay.Text = KulHissay.ToString();
                                    txtKullKanal.Text = Math.Round(KulKanal,0).ToString();
                                    txtKullMarla.Text = Math.Round(KulMarla,0).ToString();
                                    txtKullSarsai.Text = Math.Round(KulSarsai,4).ToString();
                                    txtKulFeet.Text = Math.Round(KulFeet,0).ToString();
                                  
                                    //_________________________________Self__________________________
                                    if (this.FardTokenId != "0")
                                    {

                                        double FardHissay = Convert.ToDouble(dtFard.Rows[0]["Rem_Hissa"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Hissa"].Value.ToString());
                                        double FardKanal = Convert.ToDouble(dtFard.Rows[0]["Rem_Kanal"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Kanal"].Value.ToString());
                                        double FardMarla = Convert.ToDouble(dtFard.Rows[0]["Rem_Marla"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Marla"].Value.ToString());
                                        double FardSarsai = Convert.ToDouble(dtFard.Rows[0]["Rem_Sarsai"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Sarsai"].Value.ToString());
                                        double FardFeet = Convert.ToDouble(dtFard.Rows[0]["Rem_Feet"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Feet"].Value.ToString());


                                        //================================= function for raqba calculate =============================

                                        double PersonRaqbaFard = ((FardKanal * 20 + FardMarla) * 272.25) + (FardSarsai > 0 ? FardSarsai * 30.25 : FardFeet);
                                       
                                        if (PersonRaqbaFard >= 272.25)
                                        {
                                            FardFeet = PersonRaqbaFard % 272.25;
                                            FardMarla = Convert.ToInt32((PersonRaqbaFard - FardFeet) / 272.25);

                                            if (FardMarla >= 20)
                                            {
                                                FardKanal = (FardMarla - (FardMarla % 20)) / 20;
                                                FardMarla = FardMarla % 20;


                                            }
                                            else
                                            {
                                                FardKanal = 0;
                                            }

                                        }
                                        else
                                        {
                                            FardMarla = 0;
                                            FardKanal = 0;

                                        }
                                        if (FardFeet > 0)
                                        {
                                            FardSarsai = Math.Round(FardFeet / 30.25,4);
                                        }
                                        else
                                        {
                                            FardSarsai = 0;
                                        }

                                        //================================================================================================
                                        txtFardHissay.Text = FardHissay.ToString();
                                        txtFardKanal.Text = Math.Round(FardKanal, 0).ToString();
                                        txtFardMarla.Text = Math.Round(FardMarla, 0).ToString();
                                        txtFardSarsai.Text = Math.Round(FardSarsai, 4).ToString();
                                        txtFardFeet.Text = Math.Round(FardFeet, 0).ToString();

                                       


                                    }

                                   
                                    //----------------------------------end Self-----------------------------------------

                                  
                                }



                                //-----------------------------------------------------------

                             

                                UsersManagments.Personid = row.Cells["IntiqalSellerPersonId"].Value.ToString();
                                txtSellerID.Text = row.Cells["IntiqalSellerRecId"].Value.ToString();
                                txtHiddenKhataRecID.Text = row.Cells["IntiqalKhataRecId"].Value.ToString();
                                string abc = row.Cells["SellerPersonDied"].Value.ToString();
                                if (abc == "True")
                                {
                                    chkDeath.Checked = true;
                                    dateDeath.Text = row.Cells["SellerPersonDeathDate"].Value.ToString();
                                }
                                else
                                {
                                    chkDeath.Checked = false;

                                }

                            }
                            else
                            {
                                row.Cells["checkListNew"].Value = 0;
                            }
                        }
                    }
                }
                if (chkMushtharaqa.Checked)
                {
                    groupBox16.Enabled = false;
                    MessageBox.Show(" مشترکہ منتقلہ کا انتخا ب ہٹائیے ");
                }
                else
                { groupBox16.Enabled = true; }

                if (e.ColumnIndex == GridSellerList.CurrentRow.Cells["colMutwafiKhataJat"].ColumnIndex)
                {
                    if (this.txtHiddenPersonID.Text != "")
                    {
                        frmPersonKhattaSearch frmPersonKhattaSearch = new frmPersonKhattaSearch();
                        frmPersonKhattaSearch.FormClosed -= new FormClosedEventHandler(frmPersonKhattaSearch_FormClosed);
                        frmPersonKhattaSearch.FormClosed += new FormClosedEventHandler(frmPersonKhattaSearch_FormClosed);
                        frmPersonKhattaSearch.PersonId = this.txtHiddenPersonID.Text;
                        frmPersonKhattaSearch.MozaID = this.MozaId.ToString();
                        //string PersonNmae=
                        frmPersonKhattaSearch.PersonName = this.GridSellerList.CurrentRow.Cells["PersonName"].Value.ToString();
                        frmPersonKhattaSearch.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Select Person from the grid ...");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region load matawafi Khatajat
        public void frmPersonKhattaSearch_FormClosed(object sender, EventArgs e)
        {
        }

        private void GridSellerList1_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region keypress events


        private void txtFrokhtSarsai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtFrokhtMarla_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }


        private void txtSearchSeller_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }

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
        private void txtMushterkaSarsai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtMushterkamarla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }
        #endregion

        #region btn Save Mushtarika
        private void btnSaveMushtarika_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkHissaTransferred.Checked && float.Parse(txtMushterkaSarsai.Text.Trim()) >= 0 && txtHissaMuntaqila.Text.Trim().Length > 0 && float.Parse(txtHissaMuntaqila.Text.Trim()) > KhataHissa)
                {

                    MessageBox.Show(" منتقل کردہ حصہ کھاتے کے کل حصے سے زیادہ ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    bool Exists = false;
                    if (chkMushtharaqa.Checked)
                    {
                        dt = Intiqal.GetIntiqalKhataMalikanByKhataId(IntiqalKhataId);

                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string IntiqalSellerRecId = this.txtSellerID.Text.ToString();
                                string SellerPersonDied = "False";
                                string SellerPersonDeathDate = "";
                                string Seller_Total_Hissa = row["FardAreaPart"].ToString();
                                string Seller_Total_Kanal = row["Farad_Kanal"].ToString();
                                string Seller_Total_Marla = row["Fard_Marla"].ToString();
                                string Seller_Total_Sarsai = row["Fard_Sarsai"].ToString();
                                string Seller_Total_Feet = row["Fard_Feet"].ToString();
                                string IntiqalSellerPersonId = row["PersonId"].ToString();
                                string KhewatGroupFareeqId = row["KhewatGroupFareeqId"].ToString();
                                string Seller_Sold_Hissa = "0";
                                string Seller_Sold_Kanal = "0";
                                string Seller_Sold_Marla = "0";
                                string Seller_Sold_Sarsai = "0";
                                string Seller_Sold_Feet = "0";
                                string MushtriFareeqId = "NULL";
                                if (GridSellerList.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow rowss in GridSellerList.Rows)
                                    {
                                        if (KhewatGroupFareeqId == rowss.Cells["KhewatGroupFareeqId"].Value.ToString())
                                        {
                                            Exists = true;
                                            break;
                                        }
                                    }
                                }
                                if (!Exists)
                                {
                                    string lastid = Intiqal.SaveintiqalSellers(IntiqalSellerRecId,
                                    IntiqalKhataRecId, IntiqalSellerPersonId,
                                    SellerPersonDied, SellerPersonDeathDate,

                                    Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                   , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, UsersManagments.UserId.ToString());
                                }


                            }
                            int mmrKanal = txtMushterkaKanal.Text.Trim() != "" ? Convert.ToInt32(txtMushterkaKanal.Text) : 0;
                            int mmrMarla = txtMushterkamarla.Text.Trim() != "" ? Convert.ToInt32(txtMushterkamarla.Text.Trim()) : 0;
                            float mmrSarsai = txtMushterkaSarsai.Text.Trim() != "" ? float.Parse(txtMushterkaSarsai.Text.Trim()) : 0;
                            float mmrSft = mmrSarsai * (float)30.25;
                            string chkMushtharaqachecked = this.chkMushtharaqa.Checked.ToString();
                            float TotalHissaMuniaqila = txtHissaMuntaqila.Text.Trim() != "" ? float.Parse(txtHissaMuntaqila.Text.Trim()) : 0;
                            if (chkHissaTransferred.Checked && float.Parse(txtMushterkaSarsai.Text.Trim()) >= 0 && txtHissaMuntaqila.Text.Trim().Length > 0)
                            {

                                Intiqal.SetMushtarkaRaqbaMuntiqlaByHissa(IntiqalKhataRecId, TotalHissaMuniaqila.ToString(), mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());


                            }
                            else
                            {
                                Intiqal.SetMushtarkaRaqbaMuntiqla(IntiqalKhataRecId, chkMushtharaqachecked, mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());
                            }
                            proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                            ClearAll();

                            //MessageBox.Show(" ریکارڈز محفوظ محفوظ ھو چکے ہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show(" اس کھاتہ کا کوئی ریکارڈ نہیں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 1)
            {
                if (IntiqalId != "-1")
                {
                    // fillIntiqalkhatajatList("19001");
                    //Fill_InteqalGrid();
                    //txtKhattaRecId.Text = "-1";
                    //tabControl1.SelectTab(1);
                    MessageBox.Show("good");
                }
                else
                {
                    //this.Close();
                    MessageBox.Show("انتقال لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void chkMushtharaqa_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkMushtharaqa.Checked == true)
            {
                groupBox22.Enabled = true;
                groupBox16.Enabled = false;
                txtFrokhtKanal.Text = "";
                txtFrokhtMarla.Text = "";
                txtFrokhtSarsai.Text = "";
                txtFrokhtFeet.Text = "";
                txtFrokhtHisay.Text = "";
            }
            else
            {
                groupBox22.Enabled = false;
                groupBox16.Enabled = true;
                txtMushterkaKanal.Text = "";
                txtMushterkamarla.Text = "";
                txtMushterkaSarsai.Text = "";

            }
        }

        private void cboPersonSeller_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int Khassra_Kanal = 0; int Khassra_Marla = 0; float Khassra_Sarsai = 0; float Khassra_Feet = 0;
                if (GridviewSaveSalamJuzviKhassra.DataSource != null)
                {
                    if (GridviewSaveSalamJuzviKhassra.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in GridviewSaveSalamJuzviKhassra.Rows)
                        {
                            Khassra_Kanal = Khassra_Kanal + int.Parse(row.Cells["Min_Kanal"].Value.ToString());
                            Khassra_Marla = Khassra_Marla + int.Parse(row.Cells["Min_Marla"].Value.ToString());
                            Khassra_Sarsai = Khassra_Sarsai + float.Parse(row.Cells["Min_Sarsai"].Value.ToString());
                            Khassra_Feet = Khassra_Feet + float.Parse(row.Cells["Min_Feet"].Value.ToString());
                        }
                    }
                }
                txtSellerID.Text = "-1";
                if (cboPersonSeller.SelectedIndex == 0)
                { ClearAll(); }
                else
                {
                    if (chkMushtharaqa.Checked == true) { }

                    else
                    {
                        if (MalkiatKashkat)
                        {
                            if (this.FardTokenId != "0" && this.FardTokenId != null)
                            {
                                //dt = Intiqal.GetRegistryIntiqalKhataMalikanByKhataIdByFardTokenId(IntiqalKhataId,this.FardTokenId);
                                dt = Intiqal.GetRegistryIntiqalKhataMalikanByKhataIdByFardTokenId(IntiqalKhataId, cmbFardTokenNo.SelectedValue.ToString());
                            }
                            else
                            {
                                dt = Intiqal.GetIntiqalKhataMalikanByKhataId(IntiqalKhataId);
                            }
                            if (dt != null)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row["KhewatGroupFareeqId"].ToString() == this.cboPersonSeller.SelectedValue.ToString())
                                    {
                                        DataTable dtFareeqain = new DataTable();
                                        DataTable dtFard = new DataTable();
                                        if (this.FardTokenId!= "0")
                                        {
                                            String PersonId = Intiqal.GetPersonIdByKhewatgroupFareeqId(cboPersonSeller.SelectedValue.ToString());
                                            //dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaRegistryIntiqal(cboPersonSeller.SelectedValue.ToString(),this.FardTokenId);
                                            //dtFard = mnk.GetFardKhewatFareeqainRemainingAreaofFard(cboPersonSeller.SelectedValue.ToString(), PersonId, this.FardTokenId);
                                            dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaRegistryIntiqal(cboPersonSeller.SelectedValue.ToString(), cmbFardTokenNo.SelectedValue.ToString());
                                            dtFard = mnk.GetFardKhewatFareeqainRemainingAreaofFard(cboPersonSeller.SelectedValue.ToString(), PersonId, cmbFardTokenNo.SelectedValue.ToString());
                                            
                                        }
                                        else
                                        {
                                             dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaNewFard(cboPersonSeller.SelectedValue.ToString());
                                        }
                                        
                                        if (dtFareeqain.Rows.Count > 0)
                                        {
                                            txtKulHissayWOTminhay.Text = dtFareeqain.Rows[0]["FardAreaPartTotal"].ToString();
                                            txtKulHisay.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                            txtKullKanal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                            txtKullMarla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                            txtKullSarsai.Text =dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                            txtKulFeet.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();
                                            txtHiddenPersonID.Text = row["PersonId"].ToString();
                                            txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                            txtHidenMustariFareeqID.Text = "NULL";

                                            //Self__________________________
                                            if (this.FardTokenId!= "0")
                                            {

                                                txtFardHissay.Text = dtFard.Rows[0]["Rem_Hissa"].ToString();
                                                txtFardKanal.Text = dtFard.Rows[0]["Rem_Kanal"].ToString();
                                                txtFardMarla.Text = dtFard.Rows[0]["Rem_Marla"].ToString();
                                                txtFardSarsai.Text = dtFard.Rows[0]["Rem_Sarsai"].ToString();
                                                txtFardFeet.Text = dtFard.Rows[0]["Rem_Feet"].ToString();

                                                txtFrokhtHisay.Text = dtFard.Rows[0]["Rem_Hissa"].ToString();
                                                txtFrokhtKanal.Text = dtFard.Rows[0]["Rem_Kanal"].ToString();
                                                txtFrokhtMarla.Text = dtFard.Rows[0]["Rem_Marla"].ToString();
                                                txtFrokhtSarsai.Text = dtFard.Rows[0]["Rem_Sarsai"].ToString();
                                                txtFrokhtFeet.Text = dtFard.Rows[0]["Rem_Feet"].ToString();

                                            }

                                            else
                                            {
                                                txtFrokhtHisay.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                                if (cbJuzviKhata.Checked)
                                                {
                                                    string[] area = CommanFunctions.CalculatedAreaFromHisa(float.Parse(GridViewInteqalKhattas.SelectedRows[0].Cells["TotalParts"].Value.ToString()), float.Parse(txtFrokhtHisay.Text),
                                                        Khassra_Kanal, Khassra_Marla, Khassra_Sarsai, Khassra_Feet);
                                                    txtFrokhtKanal.Text = area[0]!=null?area[0]:"0";
                                                    txtFrokhtMarla.Text = area[1] != null ? area[1] : "0";
                                                    txtFrokhtSarsai.Text = area[2] != null ? area[2] : "0";
                                                    txtFrokhtFeet.Text = area[3] != null ? area[3] : "0";
                                                }
                                                else
                                                {
                                                    txtFrokhtKanal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                                    txtFrokhtMarla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                                    txtFrokhtSarsai.Text = dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                                    txtFrokhtFeet.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();
                                                }
                                            }
                                            //end Self_________________________
                                           
                                            break;
                                        }
                                        #region Code Commented after Transaction Fard
                                        //if (this.MinhayeIntiqals.Rows.Count > 0)
                                        //{
                                        //    string isDependent = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                        //    //bool SellerExistsInMinhaye = false;
                                        //    if (isDependent == "0")
                                        //    {
                                        //        txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //        txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //        txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //        txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //        txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //        txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //        txtHidenMustariFareeqID.Text = "NULL";
                                        //        break;
                                        //    }
                                        //    else
                                        //    {
                                        //        string MinhayeIntiqalIdIfexists = "0";
                                        //        MinhayeIntiqalIdIfexists = Intiqal.GetIntiqalMinhayeIntiqalIdByKhewatGroupId(row["KhewatGroupFareeqId"].ToString());
                                        //        if (MinhayeIntiqalIdIfexists == "0")
                                        //        {
                                        //            MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + isDependent + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //            ClearAll();
                                        //        }
                                        //        else
                                        //        {
                                        //            DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalIdIfexists, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                        //            DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                        //            if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                        //            {
                                        //                txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                        //                txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                        //                txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                        //                txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                        //                txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                        //                txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //                txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //                txtHidenMustariFareeqID.Text = "NULL";
                                        //                break;
                                        //            }
                                        //        }
                                        //    }

                                        //    #region Commented old Code

                                        //    //DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalId, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                        //    //DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                        //    //if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                        //    //{
                                        //    //    txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                        //    //    txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                        //    //    txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                        //    //    txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                        //    //    txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                        //    //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //    //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //    //    txtHidenMustariFareeqID.Text = "NULL";
                                        //    //    break;
                                        //    //}
                                        //    //else
                                        //    //{
                                        //    //    txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //    //    txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //    //    txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //    //    txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //    //    txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //    //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //    //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //    //    txtHidenMustariFareeqID.Text = "NULL";
                                        //    //    break;
                                        //    //}

                                        //    #endregion
                                        //}
                                        //else
                                        //{
                                        //    string CheckForMinhayeIntiqalDependency = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                        //    if (CheckForMinhayeIntiqalDependency == "0")
                                        //    {
                                        //        txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //        txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //        txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //        txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //        txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //        txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //        txtHidenMustariFareeqID.Text = "NULL";
                                        //        break;
                                        //    }
                                        //    else
                                        //    {
                                        //        MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + CheckForMinhayeIntiqalDependency + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //        ClearAll();
                                        //    }

                                        //}
                                        #endregion
                                    }
                                }
                            }
                        }
                        else
                        {
                            dt = Intiqal.GetIntiqalKhanaKasht(IntiqalKhataId);
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["MushtriFareeqId"].ToString() == this.cboPersonSeller.SelectedValue.ToString())
                                {
                                    txtKulHisay.Text = row["FardAreaPart"].ToString();
                                    txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                    txtKullMarla.Text = row["Fard_Marla"].ToString();
                                    txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                    txtKulFeet.Text = row["Fard_Feet"].ToString();
                                    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                    txtHiddenKewatGroupFareeqID.Text = "NULL";
                                    txtHidenMustariFareeqID.Text = row[" MushtriFareeqId"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    groupBox16.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnWerasathKhattajat_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSaveSeller_Click(object sender, EventArgs e)
        {
            try
            {
                bool isExists = false;
                string duplicationCheck;
                string SellerPersonDied;
                string SellerPersonDeathDate;

                if (this.txtFrokhtHisay.Text.Trim() == string.Empty ||  this.cboPersonSeller.SelectedIndex == 0)
                {
                    MessageBox.Show("ریکارڈز خالی ہیں", "ریکارڈز", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ///Setting DB Attributes and Assigned Text Boxes Values....
                    string IntiqalSellerRecId = this.txtSellerID.Text.ToString();
                    string IntiqalKhataRecId = this.IntiqalKhataRecId.ToString();
                    string IntiqalSellerPersonId = this.txtHiddenPersonID.Text.ToString();
                    if (chkDeath.Checked)
                    {
                        SellerPersonDied = chkDeath.Checked.ToString();
                        SellerPersonDeathDate = dateDeath.Value.ToShortDateString();
                    }
                    else
                    {
                        SellerPersonDied = "False";
                        SellerPersonDeathDate = "";

                    }
                    // Call Hissa Raqba Bamutabiq Hissa before save
                    txtFrokhtHisay_Leave(sender, e);
                    // txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;

                    //if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                       
                        string Seller_Total_Hissa = this.txtKulHisay.Text.ToString();
                        string Seller_Total_Kanal = txtKullKanal.Text.ToString();
                        string Seller_Total_Marla = txtKullMarla.Text.ToString();
                        string Seller_Total_Sarsai = txtKullSarsai.Text.ToString();
                        string Seller_Total_Feet = txtKulFeet.Text.ToString();

                       

                        string Seller_Sold_Hissa = txtFrokhtHisay.Text.Trim() != "" ? txtFrokhtHisay.Text.Trim() : "0";
                        string Seller_Sold_Kanal = txtFrokhtKanal.Text.Trim() != "" ? txtFrokhtKanal.Text.Trim() : "0";
                        string Seller_Sold_Marla = txtFrokhtMarla.Text.Trim() != "" ? txtFrokhtMarla.Text.Trim() : "0";
                        string Seller_Sold_Sarsai = txtFrokhtSarsai.Text.Trim() != "" ? txtFrokhtSarsai.Text.Trim() : "0";
                        string Seller_Sold_Feet = txtFrokhtFeet.Text.Trim() != "" ? txtFrokhtFeet.Text.Trim() : "0";
                        if (Seller_Sold_Sarsai != "0")
                        {
                            Seller_Sold_Feet = (float.Parse(Seller_Sold_Sarsai) * 30.25).ToString();
                        }
                        else if (Seller_Sold_Feet != "0")
                        {
                            Seller_Sold_Sarsai = (float.Parse(Seller_Sold_Feet) / 30.25).ToString();
                        }

                        if (MalkiatKashkat)
                        {
                            txtHidenMustariFareeqID.Text = "NULL";
                        }
                        else
                        {
                            txtHiddenKewatGroupFareeqID.Text = "NULL";
                        }
                        MushtriFareeqId = txtHidenMustariFareeqID.Text.ToString();
                        string KhewatGroupFareeqId = txtHiddenKewatGroupFareeqID.Text.ToString();

                        if (GridSellerList.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in GridSellerList.Rows)
                            {

                                if (this.FardTokenId != "0")
                                {
                                    if (KhewatGroupFareeqId == row.Cells["KhewatGroupFareeqId"].Value.ToString() && txtSellerID.Text == "-1" && cmbFardTokenNo.SelectedValue.ToString() == row.Cells["FardTokenId"].Value.ToString())
                                    {
                                        isExists = true;

                                        MessageBox.Show("ریکارڈ پہلے سے موجود ہے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                }
                                else
                                {
                                    if (KhewatGroupFareeqId == row.Cells["KhewatGroupFareeqId"].Value.ToString() && txtSellerID.Text == "-1")
                                    {
                                        isExists = true;

                                        MessageBox.Show("ریکارڈ پہلے سے موجود ہے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                }

                            }

                        }
                        if (!isExists)
                        {
                            string lastid;
                              //  frmGainTax fr = new frmGainTax(); fr.Personid=IntiqalSellerPersonId;//set for gain tax
                            if(this.FardTokenId!="0")
                            {
                                 lastid = Intiqal.SaveRegistryintiqalSellers(IntiqalSellerRecId,
                                          IntiqalKhataRecId, IntiqalSellerPersonId,
                                          SellerPersonDied, SellerPersonDeathDate,

                                          Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                         , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, cmbFardTokenNo.SelectedValue.ToString(), UsersManagments.UserId.ToString());
                            }
                            else
                            {
                                 lastid = Intiqal.SaveintiqalSellers(IntiqalSellerRecId,
                                          IntiqalKhataRecId, IntiqalSellerPersonId,
                                          SellerPersonDied, SellerPersonDeathDate,

                                          Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                         , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, UsersManagments.UserId.ToString());
                            }
                            

                            if (lastid != "0")
                            {
                                //MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtSellerID.Text = lastid;
                                proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                                btnDelSeller.Enabled = true;
                                ClearAll();
                                CalculateSellerBuyerRaqbaHissa();
                            }

                        }
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFrokhtHisay_Leave(object sender, EventArgs e)
        {
            if (txtFrokhtHisay.Text == "0" || txtFrokhtHisay.Text.Trim() == "")
            {
                txtFrokhtKanal.Text = "0";
                txtFrokhtMarla.Text = "0";
                txtFrokhtSarsai.Text = "0";
                txtFrokhtFeet.Text = "0";

            }
            if (txtFrokhtHisay.Text.Trim() != "" &&  txtFrokhtHisay.Text != "0")
            {
                CalulateArea();
            }
        }

        private void chkDeath_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeath.Checked == true)
            {
                groupBox24.Visible = true;
            }
            else
            {
                groupBox24.Visible = false;
            }
        }

        private void txtSearchSeller_TextChanged_1(object sender, EventArgs e)
        {
            bs.Filter = string.Format("PersonName LIKE '%{0}%' ", txtSearchSeller.Text);
        }

        #endregion

        #region Common Methods for Buyer and Seller Tabs

        #region Calculate Seller and Buyer Khatta and Raqba Difference

        private void CalculateSellerBuyerRaqbaHissa()
        {
            try
            {
                decimal hissay = 0;
                int kanal = 0;
                int marlas = 0;
                decimal sars = 0;
                decimal sft = 0;
                //Calculate Sold Hissay and Raqba
                foreach (DataGridViewRow row in GridSellerList.Rows)
                {
                    hissay += row.Cells["Seller_Sold_Hissa"].Value != null ? Convert.ToDecimal(row.Cells["Seller_Sold_Hissa"].Value.ToString()) : 0;
                    kanal += row.Cells["Seller_Sold_Kanal"].Value != null ? Convert.ToInt32(row.Cells["Seller_Sold_Kanal"].Value.ToString()) : 0;
                    marlas += row.Cells["Seller_Sold_Marla"].Value != null ? Convert.ToInt32(row.Cells["Seller_Sold_Marla"].Value.ToString()) : 0;
                    sars = 0;//sars += row.Cells[16].Value != null ? Convert.ToDecimal(row.Cells[16].Value.ToString()) : 0;
                    sft += row.Cells["Seller_Sold_Feet"].Value != null ? Convert.ToDecimal(row.Cells["Seller_Sold_Feet"].Value.ToString()) : 0;
                }

                #region Calculate Raqba for Seller

                decimal PersonRaqba = ((kanal * 20 + marlas) * (decimal)272.25) + (sars * (decimal)30.25) + sft;
                if (PersonRaqba >= (decimal)272.25)
                {
                    sft = PersonRaqba % (decimal)272.25;
                    marlas = Convert.ToInt32((PersonRaqba - sft) / (decimal)272.25);

                    if (marlas >= 20)
                    {
                        kanal = (marlas - (marlas % 20)) / 20;
                        marlas = marlas % 20;
                        //if (sft >= 31)
                        //{
                        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                        //    sft = Convert.ToInt32(sft % 30.25);
                        //}

                    }
                    else
                    {
                        kanal = 0;
                    }

                }
                else
                {
                    marlas = 0;
                    kanal = 0;
                    //if (sft >= 31)
                    //{
                    //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                    //    sft = Convert.ToInt32(sft % 30.25);
                    //}
                }
                if (sft > 0)
                {
                    sars = sft / (decimal)30.25;
                }
                //return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 4, MidpointRounding.AwayFromZero).ToString() + "-" + Math.Round(sft, 4, MidpointRounding.AwayFromZero).ToString();


                #endregion


                this.S_Kanal = kanal;
                this.S_Marla = marlas;
                this.S_Sarsai = float.Parse(sars.ToString());
                this.S_Sft = float.Parse(sft.ToString());
                //calculate Buyers Hissay and Raqba

                decimal bhissay = 0;
                int bKanal = 0;
                int bMarla = 0;
                decimal bSars = 0;
                decimal bsft = 0;

                foreach (DataGridViewRow row in GridBuyersList.Rows)
                {
                    bhissay += row.Cells["Buyer_Hissa"].Value != null ? Convert.ToDecimal(row.Cells["Buyer_Hissa"].Value.ToString()) : 0;
                    bKanal += row.Cells["Buyer_Kanal"].Value != null ? Convert.ToInt32(row.Cells["Buyer_Kanal"].Value.ToString()) : 0;
                    bMarla += row.Cells["Buyer_Marla"].Value != null ? Convert.ToInt32(row.Cells["Buyer_Marla"].Value.ToString()) : 0;
                    bSars = 0; //bSars += row.Cells["Buyer_Sarsai"].Value != null ? Convert.ToDecimal(row.Cells["Buyer_Sarsai"].Value.ToString()) : 0;
                    bsft += row.Cells["Buyer_Feet"].Value != null ? Convert.ToDecimal(row.Cells["Buyer_Feet"].Value.ToString()) : 0;
                }

                #region Calculate Raqba for Buyer

                decimal PersonRaqbaBuyer = ((bKanal * 20 + bMarla) * (decimal)272.25) + (bSars * (decimal)30.25) + bsft;
                if (PersonRaqbaBuyer >= (decimal)272.25)
                {
                    bsft = PersonRaqbaBuyer % (decimal)272.25;
                    bMarla = Convert.ToInt32((PersonRaqbaBuyer - bsft) / (decimal)272.25);

                    if (bMarla >= 20)
                    {
                        bKanal = (bMarla - (bMarla % 20)) / 20;
                        bMarla = bMarla % 20;
                        //if (sft >= 31)
                        //{
                        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                        //    sft = Convert.ToInt32(sft % 30.25);
                        //}

                    }
                    else
                    {
                        bKanal = 0;
                    }

                }
                else
                {
                    bMarla = 0;
                    bKanal = 0;
                    //if (sft >= 31)
                    //{
                    //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                    //    sft = Convert.ToInt32(sft % 30.25);
                    //}
                }
                if (bsft > 0)
                {
                    bSars = sft / (decimal)30.25;
                }
                //return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 4, MidpointRounding.AwayFromZero).ToString() + "-" + Math.Round(sft, 4, MidpointRounding.AwayFromZero).ToString();


                #endregion

                txtIntiqalHissay.Text = hissay.ToString();
                txtHissaDiff.Text = (hissay - bhissay).ToString();
                txtIntiqalRaqba.Text = kanal.ToString() + "-" + marlas.ToString() + "-" + Math.Round(sft, 0).ToString();
                float RaqbaDiffInSft = (float)((((kanal * 20) + marlas) * 272.25) + (double)sft) - (float)(((decimal)((bKanal * 20) + bMarla) * (decimal)272.25) + (decimal)bsft);
                int RemKanal = 0;
                int RemMarla = 0;
                float Remsarsai = 0;
                int RemSft = 0;
                if (RaqbaDiffInSft > 272.25)
                {
                    RemSft = Convert.ToInt32(RaqbaDiffInSft % (float)272.25);
                    RemMarla = Convert.ToInt32((RaqbaDiffInSft - RemSft) / (float)272.25);
                    if (RemMarla > 20)
                    {
                        RemKanal = Convert.ToInt32(RemMarla / 20);
                        RemMarla = Convert.ToInt32(RemMarla - (RemKanal * 20));
                    }
                    if (RemSft > 0)
                    {
                        Remsarsai = RemSft / (float)30.25;
                    }
                    RemSft = Convert.ToInt32(RemSft);
                }
                else if (RaqbaDiffInSft < -272.25)
                {
                    RemSft = Convert.ToInt32(RaqbaDiffInSft % (float)272.25);
                    RemMarla = Convert.ToInt32((RaqbaDiffInSft - RemSft) / (float)272.25);
                    if (RemMarla < -20)
                    {
                        RemKanal = Convert.ToInt32(RemMarla / 20);
                        RemMarla = Convert.ToInt32(RemMarla - (RemKanal * 20));
                    }
                    if (RemSft < 0)
                    {
                        Remsarsai = RemSft / (float)30.25;
                    }
                    RemSft = Convert.ToInt32(RemSft);

                }
                else
                {
                    RemSft = Convert.ToInt32(RaqbaDiffInSft);
                    if (RemSft < 10 && RemSft > 0)
                        RemSft = 0;
                }
                txtRaqbaDiff.Text = RemKanal.ToString() + "K__" + RemMarla.ToString() + "M__" + RemSft.ToString() + "Sft";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        # region Code for Tab IntiqalBuyers

        private void frmIntiqalBuyers_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            //Fill_ComboKhewatTypes();
            //FillgridByBuyerList();
            //gridselection();
            //this.ClearFormControls(groupBoxHisse);
            //this.ClearFormControls(groupBoxNameSearch);
            //txthiddenBuyerRecId.Text = "-1";
        }

        #region Calculated Area for Buyer

        //private void btnHisaBamutabiqRaqba_Click(object sender, EventArgs e)
        //{
        //    CalulateBuyerArea();
        //}
        #region Calculate from Hisa Area
        public void CalulateBuyerArea_FromHissa()
        {
            try
            {


                float khissay = txtIntiqalHissay.Text.Trim() != "" ? float.Parse(txtIntiqalHissay.Text.Trim()) : 0;
                float shissay = txtKharidHisay.Text.Trim() != "" ? float.Parse(txtKharidHisay.Text.Trim()) : 0;
                //Owners raqba              
                string IntiqalRaqba = txtIntiqalRaqba.Text.ToString();
                string[] raqbaSplit = IntiqalRaqba.Split('-');
                int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0; ///seller Kanal
                int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0; ///seller Marla
                float ksarsai = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0;
                if (ksarsai > 0)
                {
                    ksarsai = (float)(ksarsai / 30.25);
                    // Math.Round(ksarsai);
                }
                // MessageBox.Show(raqbaSplit[0].ToString());
                float ksft = 0;
                //Buyers Raqba
                int bkanal = txtKharidKanal.Text.Trim() != "" ? Convert.ToInt32(txtKharidKanal.Text.Trim()) : 0;
                int bmarla = txtKharidMarla.Text.Trim() != "" ? Convert.ToInt32(txtKharidMarla.Text.Trim()) : 0;
                float bsarsai = txtKharidSarsai.Text.Trim() != "" ? float.Parse(txtKharidSarsai.Text.Trim()) : 0;
                float bsft = txtKharidFeet.Text.Trim() != "" ? float.Parse(txtKharidFeet.Text.Trim()) : 0;

                if (txtKharidHisay.Text.Trim() != "" && txtKharidHisay.Text != "0")
                {
                    txtKharidKanal.Text = "0";
                    txtKharidMarla.Text = "0";
                    txtKharidSarsai.Text = "0";
                    txtKharidFeet.Text = "0";

                    if (shissay > khissay)
                    {
                        MessageBox.Show("مالک کے کل حصے سے زیادہ حصے خرید نہیں کیے جا سکتے ", "خرید", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtKharidHisay.Clear();
                        txtKharidHisay.Focus();
                    }
                    else
                    {

                        string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                        txtKharidKanal.Text = raqba[0];
                        txtKharidMarla.Text = raqba[1];
                        txtKharidSarsai.Text = raqba[2];
                        txtKharidFeet.Text = raqba[3];
                    }

                }
                else
                {
                    //  txtKharidHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region Fill Grid By Buyers List

        public void FillgridByBuyerList()
        {
            try
            {
                DataTable dt = new DataTable();
                string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                if (MalkiatKashkat)
                {
                    //  IntiqalKhatooniRecId = txtIntiqalKhatooniRecId.Text.ToString();
                }
                else
                {
                    //IntiqalKhatooniRecId = KhatoniRecid;
                }
                dt = inteq.GetIntiqalBuyersByIntiqalKhataRecId(IntiqalKhattaRecId, KhatoniRecid, MalkiatKashkat.ToString());
                if (dt != null)
                {
                    bb.DataSource = dt;
                    GridBuyersList.DataSource = bb;
                    GridBuyersList.DataSource = dt;
                    BuyerGrid();
                }
                //GridBuyersList.DataSource = dt;
                //BuyerGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyerGrid()
        {
            GridBuyersList.Columns["IntiqalBuyerRecId"].Visible = false;
            GridBuyersList.Columns["IntiqalKhataRecId"].Visible = false;
            GridBuyersList.Columns["IntiqalBuyerPersonId"].Visible = false;
            GridBuyersList.Columns["Buyer_Hissa"].HeaderText = "حصے";
            GridBuyersList.Columns["Buyer_Kanal"].Visible = false;
            GridBuyersList.Columns["Buyer_Marla"].Visible = false;
            GridBuyersList.Columns["Buyer_Sarsai"].Visible = false;
            GridBuyersList.Columns["Buyer_Feet"].Visible = false;
            GridBuyersList.Columns["IntiqalKhatooniRecId"].Visible = false;
            GridBuyersList.Columns["Buyer_Area"].HeaderText = "رقبہ";
            GridBuyersList.Columns["PersonName"].HeaderText = "نام";
            GridBuyersList.Columns["KhewatType"].HeaderText = "قسم ملکیت";
            //if (IntiqalTypeId == "37")
            //{
            //    GridBuyersList.Columns["Rishta"].HeaderText = "رشتہ";
            //}
            //else
            //{
                GridBuyersList.Columns["Rishta"].Visible = false;
            //}
            GridBuyersList.Columns["KhewatTypeId"].Visible = false;
            GridBuyersList.Columns["RishtaId"].Visible = false;
            GridBuyersList.Columns["chk1"].DisplayIndex = 0;
            GridBuyersList.Columns["chk1"].Width = 100;
            GridBuyersList.Columns["Buyer_Hissa"].Width = 100;
            GridBuyersList.Columns["Buyer_Area"].Width = 100;

            this.setRowNumber(GridBuyersList);
        }
        #endregion
        private void clearMushtryanControls()
        {
            this.txtHiddenPersonID.Clear();

        }
        private void btnBuyerSearch_Click(object sender, EventArgs e)
        {
            frmSearchPerson Sp = new frmSearchPerson();
            Sp.MozaId = this.MozaId.ToString();
            Sp.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
            Sp.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
            Sp.ShowDialog();
        }
        void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson ap = sender as frmSearchPerson;
            this.txthiddnPersonId.Text = ap.PersonId.ToString();
            this.txtnameKharidar.Text = ap.PersonName;
            btnFamilySelection.Visible = true;

        }
        private void btnSaveBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                //if (IntiqalTypeId == "37" && Convert.ToInt32(cmbRishta.SelectedValue) < 1)
                //{
                //    MessageBox.Show("وارث کا رشتہ چنےَ", "وراثت", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (txtnameKharidar.Text.Trim() != "" && txtKharidHisay.Text.Trim() != "" && txtKharidKanal.Text.Trim() != "" && txtKharidMarla.Text.Trim() != "" && txtKharidSarsai.Text.Trim() != "" && txtKharidFeet.Text != "" && Convert.ToInt32(cboKhewatType.SelectedValue) > 0)
                {
                    bool buyerNotExists = true;
                    if (this.txthiddenBuyerRecId.Text == "-1")
                    {
                        foreach (DataGridViewRow r in GridBuyersList.Rows)
                        {
                            if (r.Cells["IntiqalBuyerPersonId"].Value.ToString() == this.txthiddnPersonId.Text.ToString() && r.Cells["KhewatTypeId"].Value.ToString() == this.cboKhewatType.SelectedValue.ToString())
                            {
                                buyerNotExists = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow r in GridBuyersList.Rows)
                        {
                            if (r.Cells["IntiqalBuyerRecId"].Value.ToString() != this.txthiddenBuyerRecId.Text.ToString())
                            {
                                if (r.Cells["IntiqalBuyerPersonId"].Value.ToString() == this.txthiddnPersonId.Text.ToString() && r.Cells["KhewatTypeId"].Value.ToString() == this.cboKhewatType.SelectedValue.ToString())
                                {
                                    buyerNotExists = false;
                                }
                            }
                        }
                    }
                    if (buyerNotExists)
                    {
                        // Call Hissa Raqba Bamutabiq Hissa before save
                        txtKharidHisay_Leave(sender, e);
                        this.SaveIntiqalBuyerRecord();

                        btnModifyBuyer.Enabled = true;
                        btnSaveBuyer.Enabled = true;
                        btnNewBuyer.Enabled = true;
                        btnBuyerSearch.Enabled = true;
                        FillgridByBuyerList();
                        gridselection();
                        this.ClearFormControls(groupBox8);
                        CalculateSellerBuyerRaqbaHissa();
                        // this.ClearFormControls(groupBoxNameSearch);
                    }
                    else
                    {
                        MessageBox.Show("یہ گرہندہ پہلے سے موجود ہے");
                    }
                }
                else
                { MessageBox.Show(" برائے مہربانی خریدار کے تمام کوائف پر کریں"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SaveIntiqalBuyerRecord()
        {
            try
            {
                string IntiqalBuyerPersonId = txthiddnPersonId.Text;
                string IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                string IntiqalKhataRecId = this.IntiqalKhataRecId;
                //string buyerid = this.BuyerId.ToString();
                string buerHisabata = txtBuyerHIsaBata.Text.Trim() != "" ? txtBuyerHIsaBata.Text.Trim() : "0";

                decimal buyerhissay = this.txtKharidHisay.Text.ToString() != "" ? Convert.ToDecimal(this.txtKharidHisay.Text.ToString()) : 0;
                string buyerkanal = this.txtKharidKanal.Text.ToString() != "" ? this.txtKharidKanal.Text.ToString() : "0";
                string buyermarla = this.txtKharidMarla.Text.ToString() != "" ? this.txtKharidMarla.Text.ToString() : "0";
                decimal buyersarsai = txtKharidSarsai.Text.Trim() != "" ? Convert.ToDecimal(this.txtKharidSarsai.Text.ToString()) : 0;
                string khewattypeid = this.cboKhewatType.SelectedValue.ToString() != "" ? this.cboKhewatType.SelectedValue.ToString() : " 0";
                decimal buyerfeet = txtKharidFeet.Text.Trim() != "" ? Convert.ToDecimal(txtKharidFeet.Text.Trim()) : 0;
                if (buyersarsai > 0 && buyerfeet == 0)
                {
                    buyerfeet = buyersarsai * Convert.ToDecimal("30.25");
                }
                else if (buyerfeet > 0 && buyersarsai == 0)
                {
                    buyersarsai = buyerfeet / Convert.ToDecimal("30.25");
                }

                //if (this.IntiqalTypeId == "37")
                //{
                //    string s = inteq.SaveintiqalBuyersSelf(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, buerHisabata, cmbRishta.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString()).FirstOrDefault().ToString();
                //}

                //else
                //{
                    string s = inteq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, buerHisabata, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString()).FirstOrDefault().ToString();

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
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

        #region Fill Combo Box By khewat Types

        public void Fill_ComboKhewatTypes()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = inteq.GetKhewatTypes(UsersManagments._Tehsilid.ToString());

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

        #region Button New Buyers Click Event


        private void btnNewBuyer_Click(object sender, EventArgs e)
        {
            cboKhewatType.SelectedValue = 0;
            this.txtKharidFeet.Clear();
            this.txthiddnPersonId.Clear();
            this.txtnameKharidar.Clear();
            this.txtKharidHisay.Clear();
            this.txtKharidKanal.Clear();
            this.txtKharidMarla.Clear();
            this.txtKharidSarsai.Clear();
            cmbRishta.SelectedValue = 0;
            btnModifyBuyer.Enabled = false;
            btnSaveBuyer.Enabled = true;
            btnNewBuyer.Enabled = false;
            btnBuyerSearch.Enabled = true;
            txthiddenBuyerRecId.Text = "-1";
            gridselection();

        }
        #endregion

        private void btnModifyBuyer_Click(object sender, EventArgs e)
        {
            btnBuyerSearch.Enabled = true;
            btnNewBuyer.Enabled = false;
            btnModifyBuyer.Enabled = false;
            btnSaveBuyer.Enabled = true;
            CalculateSellerBuyerRaqbaHissa();

        }
        private void txtnameKharidar_KeyPress(object sender, KeyPressEventArgs e)
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
        private void GridBuyersList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.btnNewBuyer.Enabled = true;
                this.btnModifyBuyer.Enabled = true;
                btnDelBuyer.Enabled = true;
                foreach (DataGridViewRow row in GridBuyersList.Rows)
                {
                    if (row.Selected)
                    {

                        row.Cells["chk1"].Value = 1;
                        txthiddenBuyerRecId.Text = row.Cells["IntiqalBuyerRecId"].Value.ToString();
                        row.Cells["IntiqalKhataRecId"].Value.ToString();
                        txthiddnPersonId.Text = row.Cells["IntiqalBuyerPersonId"].Value.ToString();
                        txtKharidHisay.Text = row.Cells["Buyer_Hissa"].Value.ToString();
                        txtKharidKanal.Text = row.Cells["Buyer_Kanal"].Value.ToString();
                        txtKharidMarla.Text = row.Cells["Buyer_Marla"].Value.ToString();
                        txtKharidSarsai.Text = row.Cells["Buyer_Sarsai"].Value.ToString();
                        txtKharidFeet.Text = row.Cells["Buyer_Feet"].Value.ToString();
                        //txtarea.Text= row.Cells["Buyer_Area"].Value.ToString();
                        txtnameKharidar.Text = row.Cells["PersonName"].Value.ToString();
                        cboKhewatType.SelectedItem = row.Cells["KhewatType"].Value.ToString();
                        cboKhewatType.SelectedValue = row.Cells["KhewatTypeId"].Value.ToString();
                        //cmbRishta.SelectedValue = row.Cells["RishtaId"].Value.ToString();

                    }
                    else
                    {
                        row.Cells["chk1"].Value = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btncancelBuyer_Click(object sender, EventArgs e)
        {
            this.ClearFormControls(groupBox8);
            //this.ClearFormControls(groupBoxNameSearch);
            txthiddenBuyerRecId.Text = "-1";
        }
        public void gridselection()
        {
            foreach (DataGridViewRow row in GridBuyersList.Rows)
            {
                if (row.Selected)
                {
                    row.Selected = false;
                }
            }
        }

        private void btnBuyerHissaBamutabiqraqba_Click(object sender, EventArgs e)
        {
            CommanFunctions Cfun = new CommanFunctions();
            CalulateBuyerHissa_FromArea();

        }
        #region
        public void CalulateBuyerHissa_FromArea()
        {
            try
            {


                float khissay = txtIntiqalHissay.Text.Trim() != "" ? float.Parse(txtIntiqalHissay.Text.Trim()) : 0;
                float shissay = txtKharidHisay.Text.Trim() != "" ? float.Parse(txtKharidHisay.Text.Trim()) : 0;                //Owners raqba              
                string IntiqalRaqba = txtIntiqalRaqba.Text.ToString();
                string[] raqbaSplit = IntiqalRaqba.Split('-');
                int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0; ///seller Kanal
                int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0; ///seller Marla
                float ksarsai = 0;
                float ksft = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0;
                //Buyers Raqba
                int bkanal = txtKharidKanal.Text.Trim() != "" ? Convert.ToInt32(txtKharidKanal.Text.Trim()) : 0;
                int bmarla = txtKharidMarla.Text.Trim() != "" ? Convert.ToInt32(txtKharidMarla.Text.Trim()) : 0;
                float bsarsai = txtKharidSarsai.Text.Trim() != "" ? float.Parse(txtKharidSarsai.Text.Trim()) : 0;
                float bsft = txtKharidFeet.Text.Trim() != "" ? float.Parse(txtKharidFeet.Text.Trim()) : 0;
                txtKharidKanal.Text = bkanal.ToString();
                txtKharidMarla.Text = bmarla.ToString();
                txtKharidSarsai.Text = bsarsai.ToString();
                txtKharidFeet.Text = bsft.ToString();
                txtKharidHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void btnFamilySelection_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (cboKhewatType.SelectedIndex > 0)
                {

                    frmSearchPersonForNaqalIntiqal SPNI = new frmSearchPersonForNaqalIntiqal();
                    SPNI.CallForIntiqalBuyers = 1;
                    SPNI.khewatTypeId = cboKhewatType.SelectedValue.ToString();

                    SPNI.MozaId = this.MozaId.ToString();
                    SPNI.FormClosed -= new FormClosedEventHandler(SPNI_FormClosed);
                    SPNI.FormClosed += new FormClosedEventHandler(SPNI_FormClosed);
                    SPNI.KhatoniRecid = KhatoniRecid;
                    SPNI.IntiqalKhataRecId = this.IntiqalKhataRecId;
                    btnNewBuyer_Click(sender, e);

                    SPNI.ShowDialog();
                }
                else
                {
                    MessageBox.Show("قسم ملکیت کا انتخاب کریں", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void SPNI_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnFamilySelection.Visible = true;
            FillgridByBuyerList();

        }
        private void txtKharidHisay_Leave(object sender, EventArgs e)
        {
            if (txtKharidHisay.Text.Trim() != "" && txtKharidHisay.Text != "0")
            {
                CalulateBuyerArea_FromHissa();
            }
            else if (txtKharidHisay.Text == "0")
            {
                txtKharidKanal.Text = "0";
                txtKharidMarla.Text = "0";
                txtKharidSarsai.Text = "0";
                txtKharidFeet.Text = "0";
            }
            else
            {
                txtKharidKanal.Text = "";
                txtKharidMarla.Text = "";
                txtKharidSarsai.Text = "";
                txtKharidFeet.Text = "";
            }
        }

        private void btnDelBuyer_Click(object sender, EventArgs e)
        {

            string ByerKhataRecId = this.txthiddenBuyerRecId.Text.ToString();
            try
            {
                if (ByerKhataRecId != "-1")
                {
                    if (MessageBox.Show(" کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Intiqal.DeleteIntiqalBuyer(ByerKhataRecId);
                        txthiddenBuyerRecId.Text = "-1";
                        CalculateSellerBuyerRaqbaHissa();
                        //FillgridByBuyerList();
                        this.ClearFormControls(groupBox8);
                        btnDelSeller.Enabled = false;
                        btnModifyBuyer.Enabled = false;
                        btnSaveBuyer.Enabled = true;
                        btnNewBuyer.Enabled = true;
                        btnBuyerSearch.Enabled = true;
                        FillgridByBuyerList();
                        gridselection();
                    }
                }
                else
                {
                    MessageBox.Show("ریکاڈکاانتخاب کریں", "ریکارڈ کا انتخاب کریں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Code for Tab IntiqalTaqseem

        #region Fill Griview Methods

        public void Fill_InteqalGrid()
        {
            DataTable dt = new DataTable();
            dt = inteq.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
            GridIntiqalKhattaJatforMin.DataSource = dt;
            GridIntiqalKhattaJatforMin.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            GridIntiqalKhattaJatforMin.Columns["IntiqalId"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["IntiqalKhataId"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["IntiqalKhataRecId"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["Kanal"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["Marla"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["Sarsai"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["Feet"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["TotalParts"].Visible = false;

            GridIntiqalKhattaJatforMin.Columns["AmaldaramadStatus"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["AmaldaramadDate"].Visible = false;
            GridIntiqalKhattaJatforMin.Columns["IsJuzviKhatta"].Visible = false;
        }

        public void FillGridMalikan()
        {
            DataTable dt = new DataTable();
            if (cboMinGroups.SelectedIndex > 0)
            {
                //String v_IntiqalMinGroupId = "";
                //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                //{
                //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                //}

                //dt = inteq.GetIntiqalMinFareeqain(IntiqalId, v_IntiqalMinGroupId);
                dt = inteq.GetIntiqalMinFareeqain(IntiqalId, cboMinGroups.SelectedValue.ToString());
                if (dt != null)
                {
                    gridmalikan.DataSource = dt;
                    gridmalikan.Columns["CompleteName"].HeaderText = "نام مالک";
                    gridmalikan.Columns["Intiqal_Min_Hissa"].HeaderText = "انتقال من حصہ";
                    gridmalikan.Columns["IntiqalMinArea"].HeaderText = "انتقال من رقبہ";
                    gridmalikan.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                    gridmalikan.Columns["IntiqalMinKhewatFareeqId"].Visible = false;
                    gridmalikan.Columns["SeqNo"].Visible = false;
                    gridmalikan.Columns["IntiqalMinPersonId"].Visible = false;
                    gridmalikan.Columns["MushtriFareeqId"].Visible = false;
                }
            }
            else
            {
                gridmalikan.DataSource = "";

            }
        }

        public void FillGridKhasraJat()
        {
            DataTable dtk = new DataTable();
            if (cboMinGroups.SelectedIndex > 0)
            {

                //String v_IntiqalMinGroupId = "";
                //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                //{
                //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                //}
                //else v_IntiqalMinGroupId = this.cboMinGroups.SelectedValue.ToString();
                dtk = inteq.GetIntiqalMinKhassraJat(IntiqalId, cboMinGroups.SelectedValue.ToString());
                //dtk = inteq.GetIntiqalMinKhassraJat(IntiqalId, v_IntiqalMinGroupId);
                gridkhasrajat.DataSource = dtk;
                gridkhasrajat.Columns["MinTypeName"].HeaderText = "قسم تہتیمہ";
                gridkhasrajat.Columns["Min_KhassraNo"].HeaderText = "من خسرہ نمبر";
                gridkhasrajat.Columns["KhassraMinArea"].HeaderText = "رقبہ";
                gridkhasrajat.Columns["IntiqalMinKhassraRecId"].Visible = false;
                gridkhasrajat.Columns["IntiqalId"].Visible = false;
                gridkhasrajat.Columns["IntiqalMinGroupId"].Visible = false;
                gridkhasrajat.Columns["OldKhataId"].Visible = false;
                gridkhasrajat.Columns["oldkhatooniid"].Visible = false;
                gridkhasrajat.Columns["OldKhassraId"].Visible = false;
                gridkhasrajat.Columns["OldKhassraDetailId"].Visible = false;
                gridkhasrajat.Columns["MinKhassraId"].Visible = false;
                // gridkhasrajat.Columns["Min_KhassraNo"].Visible = false;
                gridkhasrajat.Columns["MinNo"].Visible = false;
                gridkhasrajat.Columns["Min_KhatooniNo"].Visible = false;
                gridkhasrajat.Columns["AreaTypeId"].Visible = false;
                gridkhasrajat.Columns["AreaType"].Visible = false;
                gridkhasrajat.Columns["MinTypeId"].Visible = false;
                //gridkhasrajat.Columns["MinTypeName"].Visible = false;
                gridkhasrajat.Columns["Min_Kanal"].Visible = false;
                gridkhasrajat.Columns["Min_Marla"].Visible = false;
                gridkhasrajat.Columns["Min_Sarsai"].Visible = false;
                gridkhasrajat.Columns["Min_Feet"].Visible = false;
                //gridkhasrajat.Columns["KhassraMinArea"].Visible = false;
            }
            else
            {
                gridkhasrajat.DataSource = "";
            }
        }

        public void GetKhasrasTotalAreabyMinGroupId()
        {
            if (cboMinGroups.SelectedIndex > 0)
            {
                //String v_IntiqalMinGroupId = "";
                //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                //{
                //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();                
                //}
                //else
                //{
                //    v_IntiqalMinGroupId = cboMinGroups.SelectedValue.ToString();
                //}


                //string dtTotalKhasras = inteq.GetKhassraMIntotalRaqbaByMinGroup(v_IntiqalMinGroupId);
                string dtTotalKhasras = inteq.GetKhassraMIntotalRaqbaByMinGroup(cboMinGroups.SelectedValue.ToString());
                lblKulRaqbaKhasras.Text = dtTotalKhasras.ToString();
            }
            else
            {
                lblKulRaqbaKhasras.Text = "0-0-0";
            }
        }

        public void GetGrpDetailbyMinGroupId()
        {
            if (cboMinGroups.SelectedIndex > 0)
            {
                //String v_IntiqalMinGroupId = "";
                //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                //{
                //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                //}
                //else
                //{
                //    v_IntiqalMinGroupId = cboMinGroups.SelectedValue.ToString();
                //}

                //this.dtMinGrpDet = inteq.GetIntiqalMinGroupDetails(v_IntiqalMinGroupId);
                this.dtMinGrpDet = inteq.GetIntiqalMinGroupDetails(cboMinGroups.SelectedValue.ToString());
                txtMinKulHissay.Text = dtMinGrpDet.Rows[0]["IntiqalMin_TotalParts"].ToString();
                txtMinKulRaqba.Text = dtMinGrpDet.Rows[0]["IntiqalMin_Area"].ToString();
            }
            else
            {
                txtMinKulHissay.Clear();
                txtMinKulRaqba.Clear();
            }
        }


        #endregion

        private void frmIntiqalTaqseem_Load(object sender, EventArgs e)
        {
            //Fill_InteqalGrid();
            //btnsavemingroup.Enabled = false;
            //if (IntiqalMinGroupId != string.Empty)
            //{
            //    txtGroupMinId.Text = IntiqalMinGroupId;
            //    cboMinGroups.Text = MinGroupNo;
            //}
        }
        #region Check Box Events

        private void ChkMinCheckedChange(object sender, EventArgs e)
        {

            if (chknewkhatta.Checked)
            {
                cboMinGroups.Visible = false;
                btnsavemingroup.Enabled = true;
                chkBadasthor.Visible = true;
                txtmingroup.Focus();
                chkBadasthor.Visible = true;
            }
            else
            {
                cboMinGroups.Visible = true;
                btnsavemingroup.Enabled = false;
                chkBadasthor.Visible = false;
                chkBadasthor.Visible = false;
            }
        }

        private void chkBadasthor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBadasthor.Checked)
            {
                txtmingroup.Clear();
                txtmingroup.Enabled = false;
            }
            else
            {
                //txtmingroup.Clear();
                txtmingroup.Enabled = true;
            }
        }

        #endregion

        #region Grid Selection Change Event


        private void GridViewInteqalKhattas_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView g = sender as DataGridView;
            //foreach (DataGridViewRow row in g.SelectedRows)
            //{
            //    if (GridIntiqalKhattaJatforMin.SelectedRows.Count > 0)
            //    {
            //        if (row.Selected)
            //        {
            //            row.Cells["colChose"].Value = 1;
            //            txtkhataRecId.Text = row.Cells["IntiqalKhataRecId"].Value.ToString();
            //            string khataRecId = txtkhataRecId.Text.Trim().ToString();
            //            fillIntiqalMinGroup(IntiqalId, khataRecId);
            //        }
            //        else
            //        {
            //            row.Cells["colChose"].Value = 0;
            //        }
            //    }
            //}
        }

        #endregion

        # region Save Itiqal Min Group

        private void SaveIntiqalMinGroup()
        {
            try
            {
                if (chkBadasthor.Checked && cboMinGroups.Items.Count > 0)
                {
                    string LastId = inteq.IntiqalMinBadasthor(IntiqalId, InteqKhataId);
                    if (LastId != "" && LastId != "Failed")
                    {
                        //this.txtIntiqalMinGroupId.Text = s;
                        inteq.SetIntiqalMinGrpTotal(LastId);
                        MessageBox.Show("من گروپ محفوظ ہو گیا ہے");
                        this.chknewkhatta.Checked = false;
                        this.chkBadasthor.Checked = false;
                        this.txtmingroup.Clear();
                    }
                    else
                    {
                        MessageBox.Show("من گروپ محفوظ نہیں ہو سکا", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (chknewkhatta.Checked && txtmingroup.Text.Trim() != "")
                {
                    string KhataRecId = txtkhataRecId.Text.ToString();
                    string khataid = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();
                    string intiqalId = this.IntiqalId;
                    string minGroupId = txtMinGroupId.Text.Trim().ToString();
                    string minGroupNo = txtmingroup.Text.Trim().ToString();
                    string khataNo = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["KhataNo"].Value.ToString();
                    string khataTotalParts = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["Khata_TotalParts"].Value.ToString();
                    string totalRaqba = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["Khata_Area"].Value.ToString();
                    string[] raqbaSplit = totalRaqba.Split('-');
                    string raqbaKanal = raqbaSplit[0].ToString();
                    string raqbaMarla = raqbaSplit[1].ToString();
                    string raqbaSarsai = raqbaSplit[2].ToString();
                    string raqbaSft = (raqbaSarsai != null || raqbaSarsai != "") ? (Convert.ToDecimal(raqbaSarsai) * (decimal)30.25).ToString() : "0";
                    string usr = UsersManagments.UserId.ToString();
                    this.IntiqalMinKhatooniRecId = this.IntiqalMinKhatooniRecId != null ? this.IntiqalMinKhatooniRecId : "0";
                    this.IntiqalMinOldKhatooniId = this.IntiqalMinOldKhatooniId != null ? this.IntiqalMinOldKhatooniId : "0";
                    this.IntiqalMinKhatoniNo = this.IntiqalMinKhatoniNo != null ? this.IntiqalMinKhatoniNo : "0";
                    // string usrName = UsersManagments._UserName.ToString();
                    //string loginName = UsersManagments._UserName.ToString();
                    if (IsMinGrpExist())
                    {
                        MessageBox.Show("من گروپ پہلے سے محفوظ ہے");
                        txtmingroup.Focus();
                    }
                    else
                    {
                        string LastId = inteq.SaveIntiqalMinGroup(minGroupId, intiqalId, khataid, minGroupNo, khataNo, IntiqalMinOldKhatooniId, IntiqalMinKhatooniRecId, IntiqalMinKhatoniNo, khataTotalParts, raqbaKanal, raqbaMarla, raqbaSarsai, raqbaSft, usr, "Admin", usr, "Admin", this.MozaId.ToString());
                        if (LastId != "" && LastId != "Failed")
                        {
                            inteq.SetIntiqalMinGrpTotal(LastId);
                            MessageBox.Show("من گروپ محفوظ ہو گیا ہے");
                            chknewkhatta.Checked = false;
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

        #region Check Min Group Exiting Record

        public bool IsMinGrpExist()
        {
            bool iEx = false;
            DataTable dtMinGroup = Intiqal.GetIntiqalMinGroup(this.IntiqalId);
            foreach (DataRow dtrow in dtMinGroup.Rows)
            {
                string MinGroupNo = txtmingroup.Text.Trim().ToString();
                if (dtrow["IntiqalMinGroupNo"].ToString() == MinGroupNo)
                {
                    //MessageBox.Show("من گروپ محفوظ ہو گیا ہے");
                    iEx = true;
                    break;
                }
            }

            return iEx;
        }

        #endregion

        #region Combo Box Fill Methods

        private void fillIntiqalMinGroup(string intiqalId, string intiqalKhataId, string IntiqalKhatooniRecId)
        {
            try
            {
                this.dtmg = inteq.GetIntiqalMinGroup(intiqalId, intiqalKhataId, IntiqalKhatooniRecId);
                DataRow rowMg = dtmg.NewRow();
                rowMg["IntiqalMinGroupId"] = "0";
                rowMg["IntiqalMinGroupNo"] = " - من گروپ چنیے - ";
                // MinGroupNo = rowMg["IntiqalMinGroupNo"].ToString();
                dtmg.Rows.InsertAt(rowMg, 0);
                cboMinGroups.DataSource = dtmg;
                cboMinGroups.DisplayMember = "IntiqalMinGroupNo";
                cboMinGroups.ValueMember = "IntiqalMinGroupId";
                cboMinGroups.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        # region Min Group Save Event

        private void btnsavemingroup_Click(object sender, EventArgs e)
        {
            SaveIntiqalMinGroup();
            fillIntiqalMinGroup(IntiqalId, InteqKhataId, this.IntiqalKhatooniRecId);
            //tabControl1_Selected(null, null);
        }

        #endregion

        private void btnmlikan_Click(object sender, EventArgs e)
        {
            try
            {
                frmMalkanTaqseem frmMT = new frmMalkanTaqseem();
                frmMT.KhataId = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();// txtkhataRecId.Text.Trim().ToString();
                frmMT.IntiqalMinGroupId = txtGroupMinId.Text;
                frmMT.IntiqalId = IntiqalId;
                frmMT.MinGroupNo = MinGroupNo;
                frmMT.FormClosed -= new FormClosedEventHandler(frmMT_FormClosed);
                frmMT.FormClosed += new FormClosedEventHandler(frmMT_FormClosed);
                frmMT.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmMT_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGridMalikan();
        }
        public void minGroupId()
        {
            try
            {
                if (cboMinGroups.SelectedIndex > 0)
                {
                    //String v_IntiqalMinGroupId = "";
                    //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                    //{
                    //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                    //    txtGroupMinId.Text = v_IntiqalMinGroupId;
                    //}
                    //else
                    //{
                    //    txtGroupMinId.Text = cboMinGroups.SelectedValue.ToString();
                    //}
                    txtGroupMinId.Text = cboMinGroups.SelectedValue.ToString();
                    MinGroupNo = cboMinGroups.Text;
                }
                else
                {
                    txtGroupMinId.Text = "";
                }
                if (cboMinGroups.SelectedIndex > 0)
                {
                    String v_IntiqalMinGroupId = "";
                    if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                    {
                        v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                        txtGroupMinId.Text = v_IntiqalMinGroupId;                    
                    }
                    else
                    {
                        txtGroupMinId.Text = cboMinGroups.SelectedValue.ToString();
                    }

                    MinGroupNo = txtGroupMinId.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMinGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMinGroups.SelectedIndex > 0)
            {
                FillGridMalikan();
                FillGridKhasraJat();
                minGroupId();
                GetKhasrasTotalAreabyMinGroupId();
                GetGrpDetailbyMinGroupId();
                btnmlikan.Enabled = true;
                btnkhasrajat.Enabled = true;
                this.IntiqalMinGroupId = cboMinGroups.SelectedValue.ToString();
                    //String v_IntiqalMinGroupId = "";
                    //if (this.cboMinGroups.SelectedValue.GetType() == typeof(System.Data.DataRowView))
                    //{
                    //    v_IntiqalMinGroupId = (this.cboMinGroups.SelectedValue as System.Data.DataRowView).Row[0].ToString();
                    //}
                    //else
                    //{
                    //    v_IntiqalMinGroupId = cboMinGroups.SelectedValue.ToString();
                    //}

                    //this.IntiqalMinGroupId = v_IntiqalMinGroupId;
            }
            else
            {
                btnmlikan.Enabled = false;
                btnkhasrajat.Enabled = false;
            }
        }

        private void btnkhasrajat_Click(object sender, EventArgs e)
        {
            try
            {
                frmKhassraMinTaqseem frmKMT = new frmKhassraMinTaqseem();
                frmKMT.KhataId = GridIntiqalKhattaJatforMin.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();
                frmKMT.IntiqalMinGroupId = txtGroupMinId.Text;
                frmKMT.IntiqalId = IntiqalId;
                frmKMT.FormClosed -= new FormClosedEventHandler(frmKMT_FormClosed);
                frmKMT.FormClosed += new FormClosedEventHandler(frmKMT_FormClosed);
                frmKMT.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmKMT_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGridKhasraJat();
        }

        private void gridkhasrajat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                GridSelection = false;
                if (e.RowIndex != -1)
                {
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == gridkhasrajat.CurrentRow.Cells["ActColChose"].ColumnIndex)
                    {
                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (gridkhasrajat.SelectedRows.Count > 0)
                            {
                                //btnDelSeller.Enabled = true;
                                if (row.Selected)
                                {

                                    row.Cells["ActColChose"].Value = 1;

                                    this.txtKanalMuntaqla.Text = row.Cells["Min_Kanal"].Value.ToString();
                                    this.txtMarlaMuntaqla.Text = row.Cells["Min_Marla"].Value.ToString();
                                    this.txtSarsaiMuntaqla.Text = row.Cells["Min_Sarsai"].Value.ToString();
                                    this.txtSftMuntaqila.Text = row.Cells["Min_Feet"].Value.ToString();
                                    this.txtarea.Text = row.Cells["KhassraMinArea"].Value.ToString();
                                    txtoldkhasra.Text = row.Cells["Min_KhassraNo"].Value.ToString();
                                    txtAreaType.Text = row.Cells["AreaType"].Value.ToString();
                                    this.txtOldKhatoniId.Text = row.Cells["oldkhatooniid"].Value.ToString();
                                    this.txtMinKhassraId.Text = row.Cells["MinKhassraId"].Value.ToString();
                                    this.txtOldKhattaId.Text = row.Cells["OldKhataId"].Value.ToString();
                                    this.txtOldKhassraDetailId.Text = row.Cells["OldKhassraDetailId"].Value.ToString();
                                    this.txtIntiqalMinKhasraRecId.Text = row.Cells["IntiqalMinKhassraRecId"].Value.ToString();
                                    this.txtAreaTypeId.Text = row.Cells["AreaTypeId"].Value.ToString();
                                    this.txtOldKhassraId.Text = row.Cells["OldKhassraId"].Value.ToString();
                                    this.txtIntiqalMinGroupId.Text = row.Cells["IntiqalMinGroupId"].Value.ToString();
                                    this.khatoniNo = row.Cells["Min_KhatooniNo"].Value.ToString();
                                    this.cboTaqseemType.Text = row.Cells["MinTypeName"].Value.ToString();

                                    txtmin.Clear();
                                    txtnewkhasra.Clear();
                                    txtkhatoni.Clear();
                                }
                                else
                                {
                                    row.Cells["ActColChose"].Value = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtmin_Leave(object sender, EventArgs e)
        {
            txtnewkhasra.Text = txtoldkhasra.Text + "/" + txtmin.Text;
            txtkhatoni.Text = this.khatoniNo + "/" + txtmin.Text;
            btnSaveIntiqalMinKhassra.Enabled = true;
        }

        private void gridmalikan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == gridmalikan.CurrentRow.Cells["colSelct"].ColumnIndex)
                    {
                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (gridmalikan.SelectedRows.Count > 0)
                            {
                                //btnDelSeller.Enabled = true;
                                if (row.Selected)
                                {

                                    row.Cells["colSelct"].Value = 1;

                                    this.txtnamemalik.Text = row.Cells["CompleteName"].Value.ToString();
                                    this.txtoldHisa.Text = row.Cells["Intiqal_Min_Hissa"].Value.ToString();
                                    this.txtMinFareeqRecId.Text = row.Cells["IntiqalMinKhewatFareeqId"].Value.ToString();
                                    txtHisatransfer.Clear();
                                    txtMinFareeqKanal.Clear();
                                    txtMinFareeqMarla.Clear();
                                    txtMinFareeqSarsai.Clear();
                                    txtMinFareeqSft.Clear();
                                    btnSaveMinFareeq.Enabled = true;
                                }
                                else
                                {
                                    row.Cells["colSelct"].Value = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveMinFareeq_Click(object sender, EventArgs e)
        {
            try
            {

                string IntiqalMinFareeqId = this.txtMinFareeqRecId.Text.ToString();
                float IntiqalMinHissa = txtHisatransfer.Text.Trim() != "" ? float.Parse(txtHisatransfer.Text.Trim()) : 0;
                int MinKanal = txtMinFareeqKanal.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqKanal.Text.Trim()) : 0;
                int MinMarla = txtMinFareeqMarla.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqMarla.Text.Trim()) : 0;
                float MinSarsai = txtMinFareeqSarsai.Text.Trim() != "" ? float.Parse(txtMinFareeqSarsai.Text.Trim()) : 0;
                float MinSft = txtMinFareeqSft.Text.Trim() != "" ? Convert.ToInt32(txtMinFareeqSft.Text.Trim()) : 0;
                if (MinSarsai > 0 && MinSft <= 0)
                {
                    MinSft = MinSarsai * (float)30.25;
                }
                else if (MinSarsai <= 0 && MinSft > 0)
                {
                    MinSarsai = MinSft / (float)30.25;
                }
                if (IntiqalMinFareeqId != "-1" && IntiqalMinFareeqId != "")
                {
                    inteq.UpdateIntiqalMinFareeqHissa(IntiqalMinFareeqId, IntiqalMinHissa, MinKanal.ToString(), MinMarla.ToString(), MinSarsai, MinSft, "19001");
                    //this.GetIntiqalMinFareeqainDataBinding.DataSource = client.GetIntiqalMinFareeqain(this.IntiqalId.ToString(), txtIntiqalMinGroupId.Text.Trim()).ToList();
                    inteq.SetIntiqalMinGrpTotal(IntiqalMinGroupId);
                    // Clear Controls
                    btnSaveMinFareeq.Enabled = false;
                    this.txtMinFareeqRecId.Text = "-1";
                    this.txtnamemalik.Clear();
                    this.txtoldHisa.Clear();
                    txtHisatransfer.Clear();
                    txtMinFareeqKanal.Clear();
                    txtMinFareeqMarla.Clear();
                    txtMinFareeqSarsai.Clear();
                    txtMinFareeqSft.Clear();
                    inteq.SetIntiqalMinGrpTotal(txtIntiqalMinGroupId.Text);
                    FillGridMalikan();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveIntiqalMinKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                string OldkhatoniId = txtOldKhatoniId.Text.ToString();
                string KhattaId = txtOldKhattaId.Text.ToString();
                string OldKhassraId = txtOldKhassraId.Text.ToString();
                string oldKhassraDetailId = txtOldKhassraDetailId.Text.ToString();
                string MinKhassraId = txtMinKhassraId.Text.ToString();
                string areTypeId = txtAreaTypeId.Text.ToString();
                string MinType = cboTaqseemType.Text == "سالم" ? "2" : "1";
                string Kanal = txtKanalMuntaqla.Text != "" ? txtKanalMuntaqla.Text.ToString() : "0";
                string marla = txtMarlaMuntaqla.Text != "" ? txtMarlaMuntaqla.Text.ToString() : "0";
                float sarsai = txtSarsaiMuntaqla.Text != "" ? float.Parse(txtSarsaiMuntaqla.Text) : 0;
                float sft = txtSftMuntaqila.Text != "" ? Convert.ToInt32(txtSftMuntaqila.Text) : 0;
                string s = inteq.SaveIntiqalMinKhassra(this.txtIntiqalMinKhasraRecId.Text.ToString(), this.IntiqalId, this.txtIntiqalMinGroupId.Text.ToString(), KhattaId, OldkhatoniId, OldKhassraId, MinKhassraId, oldKhassraDetailId, txtmin.Text.Trim(), txtnewkhasra.Text.Trim(), txtkhatoni.Text, areTypeId, MinType, Kanal, marla, sarsai, sft, "19001", "Admin", "19001", "Admin", "19001");
                if (s != "" || s != null)
                {
                    FillGridKhasraJat();
                }
                txtmin.Clear();
                txtnewkhasra.Clear();
                txtkhatoni.Clear();
                txtMinKhassraId.Text = "-1";
                txtAreaTypeId.Text = "-1";
                txtOldKhattaId.Text = "-1";
                txtOldKhassraDetailId.Text = "-1";
                txtIntiqalMinKhasraRecId.Text = "-1";
                txtOldKhassraId.Text = "-1";
                txtIntiqalMinGroupId.Text = "-1";
                txtOldKhatoniId.Text = "-1";
                this.ClearFormControls(gbKhassraMinControls);
                btnSaveIntiqalMinKhassra.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridIntiqalKhattaJatforMin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (GridIntiqalKhattaJatforMin.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colChos"].Value = true;
                            txtkhataRecId.Text = row.Cells["IntiqalKhataRecId"].Value.ToString();
                            InteqKhataId = row.Cells["IntiqalKhataId"].Value.ToString();
                            this.IntiqalKhatooniRecId = "0";
                            //string khataRecId = txtkhataRecId.Text.Trim().ToString();
                            fillIntiqalMinGroup(IntiqalId, InteqKhataId, IntiqalKhatooniRecId);
                        }
                        else
                        {
                            row.Cells["colChos"].Value = false;
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

       

        private void btnDelMinKhassra_Click(object sender, EventArgs e)
        {
            if (this.txtIntiqalMinKhasraRecId.Text != null)
            {
                Intiqal.DeleteMinKhasra(this.txtIntiqalMinKhasraRecId.Text);
                FillGridKhasraJat();
            }

        }

        private void btnDeleteMalikan_Click(object sender, EventArgs e)
        {
            if (this.txtMinFareeqRecId.Text != null)
            {
                Intiqal.DeleteMinFareeq(this.txtMinFareeqRecId.Text);
                inteq.SetIntiqalMinGrpTotal(txtIntiqalMinGroupId.Text);
                FillGridMalikan();
            }

        }

        private void btnAmalDaramadTaqseem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(" عمل درآمد ک بعد آپ اس انتقال میں میں تبدیلی نہیں کر سکتے۔ پھر بھی عمل درآمد کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //MessageBox.Show("Yes");

                    {
                        Intiqal.IntiqalAmalDaramadCombined(this.MozaId.ToString(), this.IntiqalId);
                        //client.IntiqalAmalDaramadCombined(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());
                    }
                    //if (s != null || s != "")
                    //{
                    MessageBox.Show("عمل درامد ہو گیا");
                    //}
                    //this.LoadIntiqalDetails();
                }
                else
                {
                    //MessageBox.Show("No");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            try
            {
                if (isGardawar.ToString() == "0" )
                {
                    MessageBox.Show("گرداور سے پڑتال کرائیں۔", "انتقال عمل درآمد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(this.Teh_Report < 11)
                {
                    MessageBox.Show("انتقال پر تحصیلدار کا حکم درج کریں۔", "انتقال عمل درآمد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (RegStatus.ToString() == "3")
                {
                    MessageBox.Show("ریکارڈ کے مطابق رجسٹری زیر التوا ہے۔", "انتقال عمل درآمد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (RegStatus.ToString() == "4")
                {
                    MessageBox.Show("ریکارڈ کے مطابق رجسٹری، سب رجسٹرار آفس کو واپس بھجوائی گئی ہے۔", "انتقال عمل درآمد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool MinhayeIntiqalAmaldaramadStatus = true;// Convert.ToBoolean(Intiqal.GetIntiqalAmaldaramadStatusForMinhayeIntiqal(this.MinhayeIntiqalId));
                string MinIntiqalNo = "0";
                foreach(DataRow row in this.MinhayeIntiqals.Rows)
                {
                    if (Convert.ToBoolean(row["AmalDaramadStatus"].ToString()) == false)
                    {
                        MinhayeIntiqalAmaldaramadStatus = false;
                        MinIntiqalNo = row["IntiqalNo"].ToString();
                        break;
                    }

                }
                if (MinhayeIntiqalAmaldaramadStatus)
                {
                    if (MessageBox.Show(" عمل درآمد ک بعد آپ اس انتقال میں میں تبدیلی نہیں کر سکتے۔ پھر بھی عمل درآمد کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.btnAmaldaramad.Enabled = false;
                        //MessageBox.Show("Yes");
                         //check whether seller and buyer raqba and hissa are same

                        this.BS_AreaHissa = Intiqal.GetIntiqalSellerBuyerAreaCheck(this.IntiqalId);
                        if (BS_AreaHissa != "-1")
                        {
                            MessageBox.Show(BS_AreaHissa, "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            if (Intiqal.CheckMalikRemainingHissaCheck(this.IntiqalId) == "1")
                            {
                                // Seller area and hissa is according to save values in seller table

                                {

                                    Intiqal.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId, UsersManagments.UserId.ToString(), UsersManagments.UserName);

                                    //client.IntiqalAmalDaramadCombined(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());
                                }
                                //if (s != null || s != "")
                                //{
                                MessageBox.Show("عمل درامد ہو گیا");
                                this.AmalDaramad = true;
                                this.SetAmalDaramadStatus(this.AmalDaramad);
                            }
                            else
                            {
                                MessageBox.Show("بایع / دہندہ کے محفوظ شدہ حصہ و رقبہ اور اصل ملکییتی حصہ و رقبہ برابر نہیں ہے۔", "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No");
                    }
                }
                else
                {
                    MessageBox.Show("  عملدرادمد نہیں ہو سکا۔ اس انتقال کے عملدرامد سے پہلے منہائے انتقال نمبر  "+MinIntiqalNo+ " پر عملدرامد کریں۔", "عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void GridIntiqalKhattaJatforMin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region Check box new Khata Checked Change Event

        private void chkNewKhataChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewKhataChange.Checked == true)
            {
                TaqseemNewTabEnable();
                ClearTaqseemNewTab();
                string moza = this.IntiqalId.Substring(0, 5);
                try
                {
                    dt = taqseemnewkhata.Proc_Get_Max_Khata_No_By_Moza(moza);
                    foreach (DataRow d in dt.Rows)
                    {
                        int kata = Convert.ToInt32(d["Column1"].ToString());
                        kata = kata + 1;
                        string[] strArr = null;
                        strArr = this.NewKhataCreate.Split('/');
                        this.txtKhataNoChange.Text = kata + "/" + strArr[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                TaqseemNewTabDisable();
                btnDeleteChange.Enabled = true;
                btnClearChange.Enabled = true;
                btnSaveChange.Enabled = true;

            }

        }

        #endregion

        #region Button Save Malak Event


        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (this.txtparentKhataId.Text.Trim() != "-1" && txtParentid.Text.Trim() != "-1")
            {
                txtParentid.Text = IntiqalId.ToString();
                // RegisterHqDKhataId = txtRegHaqKhataID.Text.ToString();
                RegisterHqId = txtRegHagDaranID.Text.ToString();
                ParentKhataID = txtParentid.Text.ToString();
                Taraf = txtTaraf.Text.ToString();
                Pati = txtPati.Text.ToString();
                string kNo = txtKhataNoChange.Text != "" ? txtKhataNoChange.Text.ToString() : "0";
                string hissay = txthissayChagne.Text != "" ? txthissayChagne.Text.ToString() : "0";
                string kannal = txtKanalChange.Text != "" ? txtKanalChange.Text.ToString() : "0";
                string marala = txtMarlayChange.Text != "" ? txtMarlayChange.Text.ToString() : "0";
                string sarsai = txtSarsasiChange.Text != "" ? txtSarsasiChange.Text.ToString() : "0";
                string feet = txtFeetChange.Text != "" ? txtFeetChange.Text.ToString() : "0";
                string malia = txtMaliaChange.Text != "" ? txtMaliaChange.Text.ToString() : "";
                string kefiat = txtKefiyatChange.Text != "" ? txtKefiyatChange.Text.ToString() : "";
                string ss = misalBL.CheckParentKhata(IntiqalId.ToString(), txtparentKhataId.Text.ToString());
                if (ss != "-1")
                {

                    MessageBox.Show(ss, "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (misalBL.CheckKhataInMoza(MozaId.ToString(), kNo.ToString(), txtRegHaqKhataID.Text.ToString()) == "1")
                {

                    MessageBox.Show("  کھاتہ نمبر" + kNo.ToString() + " موضع میں پہلے سے موجود ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                string Registerkid = taqseemnewkhata.WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta(txtRegHaqKhataID.Text.ToString(), RegisterHqId, kNo, Taraf, Pati, hissay, kannal, marala, sarsai, feet, malia, kefiat, MozaId.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), txtparentKhataId.Text, ParentKhataID);
                string minGroupId = inteq.SaveIntiqalMinGroup("-1", IntiqalId, this.IntiqalKhataId, "1", kNo, "0", "0", "0", hissay, kannal, marala, sarsai, feet, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName, MozaId.ToString());
                txtRegHaqKhataID.Text = Registerkid;
                RegisterHqDKhataId = Registerkid;
                if (RegisterHqDKhataId != null)
                {
                    AutoComplete on = new AutoComplete();
                    //on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                    on.FillCombo("Proc_Self_Get_Moza_Register_KhataJat_ParentKhataID " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + IntiqalId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                    cmbtaqseemChangeKhata.SelectedValue = RegisterHqDKhataId;
                    Get_TaqseemRegHadkhataid(RegisterHqDKhataId);
                    getkhasrajattotalarea();
                }
            }
            else
                MessageBox.Show("برائے مہربانی کھاتا ٹیب جا کر کھاتے کا انتخاب کریں-", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Get New KhatajatByParent KhataId

        public void Get_TaqseemRegHadkhataid(string RegHadkhataid)
        {
            DataTable dt = new DataTable();
            dt = taqseemnewkhata.Proc_Get_Taqseem_RegisterHqDKhataId(RegHadkhataid);
            foreach (DataRow dr in dt.Rows)
            {
                //RegisterHqDKhataId = dr["RegisterHqDKhataId"].ToString();
                txtRegHaqKhataID.Text = dr["RegisterHqDKhataId"].ToString();
                txtRegHagDaranID.Text = dr["RegisterHaqdaranId"].ToString();
                txtParentid.Text = dr["ParentKhattaId"].ToString();
                txtKhataNoChange.Text = dr["KhataNo"].ToString();
                txthissayChagne.Text = dr["TotalParts"].ToString();
                txtKanalChange.Text = dr["Khata_Kanal"].ToString();
                txtMarlayChange.Text = dr["Khata_Marla"].ToString();
                txtSarsasiChange.Text = dr["Khata_Sarsai"].ToString();
                txtFeetChange.Text = dr["Khata_Feet"].ToString();
                txtMaliaChange.Text = dr["Malia"].ToString();
                txtKefiyatChange.Text = dr["Kyfiat"].ToString();
                txtPati.Text = dr["Pati"].ToString();
                txtTaraf.Text = dr["Tarf"].ToString();

            }

        }

        #endregion

        private void btnClearChange_Click(object sender, EventArgs e)
        {
            ClearTaqseemNewTab();
        }

        #region Clear Taqseen New Tab Khata Controls

        public void ClearTaqseemNewTab()
        {
            txtRegHaqKhataID.Text = "-1";
            txtRegHagDaranID.Text = "-1";
            //txtParentid.Text = "-1";
            txtKhataNoChange.Text = "";
            txthissayChagne.Text = "";
            txtKanalChange.Text = "";
            txtMarlayChange.Text = "";
            txtSarsasiChange.Text = "";
            txtFeetChange.Text = "";
            txtMaliaChange.Text = "";
            txtKefiyatChange.Text = "";

        }

        #endregion

        private void btnMushtrianIshtirak_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("کیا آپ کھاتہ اشتراک کا مشتریان محفوظ کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo))
                {

                    taqseemnewkhata.Proc_Intiqal_Ishtrak_Mushtrian(this.IntiqalId.ToString());
                    taqseemnewkhata.proc_Intiqal_Ishtirak_Khattajat(this.IntiqalId.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetMushtrian_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = taqseemnewkhata.proc_Get_Intiqal_Buyers_List_ByIntiqal(this.IntiqalId);
                GridBuyersList.DataSource = dt;
                BuyerGrid();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void txtFeetChange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
            }
        }

        
        public static string getStringFromCombo(ComboBox cmb)
        {
            String str = "";
            if (cmb.SelectedValue.GetType() == typeof(System.Data.DataRowView))
            {
                System.Data.DataRowView v = (System.Data.DataRowView)cmb.SelectedValue;
                str = v.Row[0].ToString();
            }
            else str = cmb.SelectedValue.ToString();
            return str;
        }

        #region Comboxo Selection Change commited Event

        private void cmbtaqseemChange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            //RegisterHqDKhataId = this.cmbtaqseemChangeKhata.SelectedValue.ToString();
            RegisterHqDKhataId=SDC_Application.AL.frmIntiqalKhattaJat.getStringFromCombo(cmbtaqseemChangeKhata);
            Get_TaqseemRegHadkhataid(this.cmbtaqseemChangeKhata.SelectedValue.ToString());

            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                TaqseemNewTabEnable();
                //RegisterHqDKhataId = cmbtaqseemChangeKhata.SelectedValue.ToString();
                //txtRegHaqKhataID.Text = cmbtaqseemChangeKhata.SelectedValue.ToString();

                RegisterHqDKhataId=SDC_Application.AL.frmIntiqalKhattaJat.getStringFromCombo(cmbtaqseemChangeKhata);
                txtRegHaqKhataID.Text =SDC_Application.AL.frmIntiqalKhattaJat.getStringFromCombo(cmbtaqseemChangeKhata);
            }
            else
            {

                RegisterHqDKhataId = "0";
                txtKhataNoChange.Clear();
                txthissayChagne.Clear();
                txtFeetChange.Clear();
                txtKanalChange.Clear();
                txtMarlayChange.Clear();
                txtSarsasiChange.Clear();
            }

            FillGrdiTaqseemMalkan();
            FillGridKhatooniChange();
            Fillkhatoniforkhasra();
            getkhasrajattotalarea();
            GetKhataAreaHissa(this.cmbtaqseemChangeKhata.SelectedValue.ToString());

            txtkolhisa.Text = txthissayChagne.Text != null ? txthissayChagne.Text : "0";
            txtkolfeet.Text = txtFeetChange.Text != null ? txtFeetChange.Text : "0"; ;
            txtkolkanal.Text = txtKanalChange.Text != null ? txtKanalChange.Text : "0";
            txtkolmarala.Text = txtMarlayChange.Text != null ? txtMarlayChange.Text : "0";
            txtkolsarsai.Text = txtSarsasiChange.Text != null ? txtSarsasiChange.Text : "0";
        }

        #endregion

        #region Fill Grid Taqseem Malkan

        private void FillGrdiTaqseemMalkan()
        {
            DataTable dt = new DataTable();
            if (this.cmbtaqseemChangeKhata.SelectedIndex > 0)
            {
                string khataid = RegisterHqDKhataId;
                if (khataid == null)
                {
                    khataid = "0";
                }
                dt = this.taqseemnewkhata.Proc_Get_KhewatFareeqeinByKhataId(khataid);
                dvTaqseemMalkan = new DataView(dt);
                FillGridMalikanChange(dt);

            }
        }
        private void GetKhatooniMushteryan(string KhatooniId)
        {
            try
            {


                Mushdt = Khatooni.Get_Self_MushtriFareeqein_By_KhatooniId(KhatooniId);
                dvTaqseemMushtryan = new DataView(Mushdt);
                FillGridTaqseemMushtryan(Mushdt);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetKhatooniAreaHissa(string KhatooniId)
        {
            try
            {
                DataTable dtKhatooniAreaHissa = Khatooni.Proc_Self_Get_Khatooni_Mushtryan_Area_Hissa(KhatooniId);
                foreach (DataRow row in dtKhatooniAreaHissa.Rows)
                {
                    this.txtKHThissa.Text = row["Khatooni_Hissa"].ToString();
                    this.txtKHTarea.Text = row["khatooniArea"].ToString();
                    this.txtMushHissa.Text = row["mushHissa"].ToString();
                    this.txtMushArea.Text = row["mushArea"].ToString();
                    this.txtKHThissaDiff.Text = row["HissaDiff"].ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetKhataAreaHissa(string KhataId)
        {
            try
            {
                DataTable dtKhataAreaHissa = Khatooni.Proc_Self_Get_Khata_Malkan_Area_Hissa(KhataId);
                foreach (DataRow row in dtKhataAreaHissa.Rows)
                {
                    this.txtKhataHissay.Text = row["TotalParts"].ToString();
                    this.txtKhataArea.Text = row["KhataArea"].ToString();
                    this.txtMalikanHissay.Text = row["MalikanHissa"].ToString();
                    this.txtMalkanArea.Text = row["MalikanArea"].ToString();
                    this.txthissamaifarq.Text = row["HissaDiff"].ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void fillMushtrichangetextboxes()
        {
            float ksarsai = 0;
            MushtriFareeqIdTaqseem = dgvMushtryan.CurrentRow.Cells["MushtriFareeqId"].Value.ToString();
            this.txtMushNameChange.Text = dgvMushtryan.CurrentRow.Cells["CompleteName"].Value.ToString();
            this.txtMushHisachange.Text = dgvMushtryan.CurrentRow.Cells["FardAreaPart"].Value.ToString();
            this.txtMushkanalchange.Text = dgvMushtryan.CurrentRow.Cells["Mushtri_Area_KMSqft"].Value.ToString();

            string IntiqalRaqba = this.txtMushkanalchange.Text.ToString();
            string[] raqbaSplit = IntiqalRaqba.Split('-');
            int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0; ///seller Kanal
            int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0; ///seller Marla
            float kfeet = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0;
            txtMushFeetchange.Text = kfeet.ToString();

            txtMushmarlachange.Text = kmarla.ToString();
            txtMushkanalchange.Text = kkanal.ToString();
            if (kfeet > 0)
            {
                ksarsai = (float)(kfeet / 30.25);

            }
            this.txtMushsarsaichange.Text = Math.Round(ksarsai, 7).ToString();
            if (isAttested || AmalDaramad || isConfirmed)
            { }
            else
            {
                btnSaveChangeMalikan.Enabled = true;
                btndeleteChangeMalikan.Enabled = true;
            }

        }
        public void ClearMushtrichangetextboxes()
        {

            MushtriFareeqIdTaqseem = "-1";
            this.txtMushNameChange.Clear();
            this.txtMushHisachange.Clear();
            this.txtMushkanalchange.Clear();
            this.txtMushFeetchange.Clear();
            this.txtMushmarlachange.Clear();
            this.txtMushsarsaichange.Clear();
            this.chbDelAll.Checked = false;

            btnSaveChangeMalikan.Enabled = false;
            btndeleteChangeMalikan.Enabled = false;

        }
        #endregion
        #region Fill Gridview Mushtryan Taqseem

        public void FillGridTaqseemMushtryan(DataTable dt)
        {
            dgvMushtryan.DataSource = dt;
            dgvMushtryan.Columns["FardAreaPart"].HeaderText = "حصہ";
            dgvMushtryan.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
            dgvMushtryan.Columns["CompleteName"].HeaderText = "نام مالک";
            dgvMushtryan.Columns["SeqNo"].HeaderText = "نمبر شمار";

            dgvMushtryan.Columns["MushtriFareeqId"].Visible = false;
            dgvMushtryan.Columns["PersonId"].Visible = false;


            dgvMushtryan.Columns["CompleteName"].DisplayIndex = 2;
            dgvMushtryan.Columns["seqno"].DisplayIndex = 1;



        }

        #endregion
        #region Get Khatooni For Khassrajat Drop Down

        public void Fillkhatoniforkhasra()
        {

            string khataid = RegisterHqDKhataId;
            AutoComplete on = new AutoComplete();
            on.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RegisterHqDKhataId + "", this.cmbkhatoonisnew, "KhatooniNo", "KhatooniId");

        }
        #endregion

        #region Button Select Malak from Bayan/Mushteryan etc

        private void btnGetChangeMalikan_Click(object sender, EventArgs e)
        {
            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                if (Convert.ToInt32(RegisterHqDKhataId) > 0)
                {
                    AL.frmMalkan_Taqseem frmMTv = new AL.frmMalkan_Taqseem();
                    try
                    {
                        
                        frmMTv.KhataId = IntiqalKhataId;
                        frmMTv.IntiqalId = IntiqalId;
                        frmMTv.RegisterhaqkhataId = RegisterHqDKhataId;//cmbtaqseemChangeKhata.SelectedValue.ToString();
                        frmMTv.FormClosed -= new FormClosedEventHandler(frmMTv_FormClosed);
                        frmMTv.FormClosed += new FormClosedEventHandler(frmMTv_FormClosed);
                        frmMTv.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        frmMTv.ShowDialog();
                    }
                    DataTable dt = new DataTable();
                    //dt = taqseemnewkhata.proc_Get_Intiqal_Buyers_List_ByIntiqal(this.IntiqalId);
                    //grdMushtrianMalinkanChange.DataSource = dt;
                    //gridfillchangemalikan();
                }
            }
            else
            {
                MessageBox.Show("کھاتہ نمبر کا انتخاب کریں", "", MessageBoxButtons.OK);
            }
        }

        void frmMTv_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrdiTaqseemMalkan();
        }
        #endregion

        #region Fill Gridview Malkan New Khata

        public void FillGridMalikanChange( DataTable dt)
        {
                grdMushtrianMalinkanChange.DataSource = dt;
                grdMushtrianMalinkanChange.Columns["chk_change_Malikan"].DisplayIndex = 0;
                grdMushtrianMalinkanChange.Columns["PersonName"].DisplayIndex = 2;
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].DisplayIndex = 5;
                grdMushtrianMalinkanChange.Columns["KhewatType"].DisplayIndex = 3;
                grdMushtrianMalinkanChange.Columns["FardAreaPart"].DisplayIndex = 4;
                grdMushtrianMalinkanChange.Columns["seqno"].DisplayIndex = 1;
                grdMushtrianMalinkanChange.Columns["PersonName"].HeaderText = "نام مالک";
                grdMushtrianMalinkanChange.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].HeaderText = "رقبہ";
                grdMushtrianMalinkanChange.Columns["seqno"].HeaderText = "نمبر شمار";
                grdMushtrianMalinkanChange.Columns["FardAreaPart"].HeaderText = "حصہ";
                grdMushtrianMalinkanChange.Columns["KhewatGroupFareeqId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhewatGroupId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonId"].Visible = false;
                
                grdMushtrianMalinkanChange.Columns["KhewatTypeId"].Visible = false;

                grdMushtrianMalinkanChange.Columns["DarNo"].Visible = false;
                grdMushtrianMalinkanChange.Columns["TotalDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardPart_Bata"].Visible = false;
                
                grdMushtrianMalinkanChange.Columns["CNIC"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonNetPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["OfDarPart"].Visible = false;

                GetFaraqIstirak();

        }

        #endregion

        #region Get Farq Ishtirak

        public void GetFaraqIstirak()
        {
            float sum = 0;
            if (grdMushtrianMalinkanChange.Rows.Count > 0)
            {

                foreach (DataGridViewRow rows in grdMushtrianMalinkanChange.Rows)
                {
                    float a = float.Parse(rows.Cells["FardAreaPart"].Value.ToString());
                    sum = sum + a;

                }
            }
            // MessageBox.Show();
            float farq =float.Parse( Math.Round((Convert.ToDecimal(this.txthissayChagne.Text) -Convert.ToDecimal(sum)),3).ToString());
            this.txthissamaifarq.Text = farq.ToString();
            //this.txthissamaifarq.Text = farq.ToString();
        }

        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            if (tabControl1.SelectedIndex == 4)
            {
                AutoComplete on = new AutoComplete();
                //on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                on.FillCombo("Proc_Self_Get_Moza_Register_KhataJat_ParentKhataID " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "," + IntiqalId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (this.IntiqalKhataId == null)
                {
                    MessageBox.Show("Kindly first select the khata");
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    AutoComplete ac = new AutoComplete();
                    ac.FillCombo("Proc_Get_Intiqal_MinGroupsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.IntiqalId + "," + this.IntiqalKhataId + ",0", cboMinGroups, "IntiqalMinGroupNo", "IntiqalMinGroupId");
                }
            }
        }

        #region Gridview New Khata Malkan Click Event

        private void grdMushtrianMalinkanChange_DoubleClick(object sender, EventArgs e)
        {
            filltaqseemchangetextboxes();
        }
        public void filltaqseemchangetextboxes()
        {
            float ksarsai = 0;
            KhewatGroupFareeqId = grdMushtrianMalinkanChange.CurrentRow.Cells["KhewatGroupFareeqId"].Value.ToString();
            this.txtNameChange.Text = grdMushtrianMalinkanChange.CurrentRow.Cells["PersonName"].Value.ToString();
            this.txtHisamuntaqialachangee.Text = grdMushtrianMalinkanChange.CurrentRow.Cells["FardAreaPart"].Value.ToString();
            this.txtkanalchangee.Text = grdMushtrianMalinkanChange.CurrentRow.Cells["Khewat_Area"].Value.ToString();
            this.txtHisamuntaqialachangeevb.Text = grdMushtrianMalinkanChange.CurrentRow.Cells["FardAreaPart"].Value.ToString();
            string IntiqalRaqba = this.txtkanalchangee.Text.ToString();
            string[] raqbaSplit = IntiqalRaqba.Split('-');
            int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0; ///seller Kanal
            int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0; ///seller Marla
            float kfeet = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0;
            txtfeetchagee.Text = kfeet.ToString();

            txtmarlachangee.Text = kmarla.ToString();
            txtkanalchangee.Text = kkanal.ToString();
            if (kfeet > 0)
            {
                ksarsai = (float)(kfeet / 30.25);

            }
            this.txtsarsaichangee.Text = Math.Round(ksarsai, 7).ToString();
            if(isAttested || AmalDaramad || isConfirmed)
            { }
            else
            {
                btnSaveChangeMalikan.Enabled = true;
                btndeleteChangeMalikan.Enabled = true;
            }
           
        }

        #endregion

        private void chkselectallchangemalikan_Click(object sender, EventArgs e)
        {
            if (this.grdMushtrianMalinkanChange.Rows.Count > 0)
            {
                if (this.chkselectallchangemalikan.Checked)
                {
                    foreach (DataGridViewRow row in grdMushtrianMalinkanChange.Rows)
                    {

                        row.Cells["chk_change_Malikan"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdMushtrianMalinkanChange.Rows)
                    {

                        row.Cells["chk_change_Malikan"].Value = 0;

                    }
                }
            }
        }

        #region Button Save new Khata Malklan Click Event 

        private void btnSaveChangeMalikan_Click(object sender, EventArgs e)
        {

            try
            {
                string KhewatGroupFareeqId = grdMushtrianMalinkanChange.CurrentRow.Cells["KhewatGroupFareeqId"].Value.ToString();
                string PersonId = grdMushtrianMalinkanChange.CurrentRow.Cells["PersonId"].Value.ToString();
                decimal FardAreaPart = this.txtHisamuntaqialachangeevb.Text.Trim() != "" ? Convert.ToDecimal(this.txtHisamuntaqialachangeevb.Text.ToString()) : 0;
                string fardkanal = this.txtkanalchangee.Text != "" ? this.txtkanalchangee.Text.ToString() : "0";
                string fardmarla = this.txtmarlachangee.Text != "" ? this.txtmarlachangee.Text.ToString() : "0";
                string fardsarsai = txtsarsaichangee.Text != "" ? this.txtsarsaichangee.Text.ToString() : "0";
                decimal fardfeet = txtfeetchagee.Text.Trim() != "" ? Convert.ToDecimal(this.txtfeetchagee.Text.ToString()) : 0;
                string KhewatTypeId = grdMushtrianMalinkanChange.CurrentRow.Cells["KhewatTypeId"].Value.ToString();
                string KhewatGroupId = grdMushtrianMalinkanChange.CurrentRow.Cells["KhewatGroupId"].Value.ToString();
                string Dar = grdMushtrianMalinkanChange.CurrentRow.Cells["DarNo"].Value.ToString();
                string TotalDarPart = grdMushtrianMalinkanChange.CurrentRow.Cells["TotalDarPart"].Value.ToString();
                string PersonDarPart = grdMushtrianMalinkanChange.CurrentRow.Cells["PersonDarPart"].Value.ToString();
                string OfDarPart = grdMushtrianMalinkanChange.CurrentRow.Cells["OfDarPart"].Value.ToString();
                string PersonNetPart = grdMushtrianMalinkanChange.CurrentRow.Cells["PersonNetPart"].Value.ToString();
                string FardPart_Bata = grdMushtrianMalinkanChange.CurrentRow.Cells["FardPart_Bata"].Value.ToString();
                //string RegisterHqDKhataIdd = RegisterHqDKhataId;
                string lastid = taqseemnewkhata.WEB_SP_INSERT_KhewatGroupFareeqein(KhewatGroupFareeqId, KhewatGroupId, PersonId.ToString(), FardAreaPart.ToString(), fardkanal.ToString(), fardmarla.ToString(), fardsarsai.ToString(), fardfeet.ToString(), KhewatTypeId, RegisterHqDKhataId.ToString(), UsersManagments.UserId.ToString(), Dar, TotalDarPart, PersonDarPart, OfDarPart, UsersManagments.UserName, FardPart_Bata);
                btnSaveChangeMalikan.Enabled = false;
                btndeleteChangeMalikan.Enabled = false;
                FillGrdiTaqseemMalkan();
                GetKhataAreaHissa(this.cmbtaqseemChangeKhata.SelectedValue.ToString());
                txtSearchMalik_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void grdMushtrianMalinkanChange_SelectionChanged(object sender, EventArgs e)
        {

            if (grdMushtrianMalinkanChange.CurrentRow.Selected)
            {

                foreach (DataGridViewRow row in grdMushtrianMalinkanChange.Rows)
                {
                    row.Cells["chk_change_Malikan"].Value = 0;
                }
                grdMushtrianMalinkanChange.CurrentRow.Cells["chk_change_Malikan"].Value = 1;
                filltaqseemchangetextboxes();

            }
            else
            {
                grdMushtrianMalinkanChange.CurrentRow.Cells["chk_change_Malikan"].Value = 0;

                txtNameChange.Text = "";//grdMushtrianMalinkanChange.CurrentRow.Cells["PersonName"].Value.ToString();
                this.txtHisamuntaqialachangee.Text = "";// = grdMushtrianMalinkanChange.CurrentRow.Cells["FardAreaPart"].Value.ToString();
                this.txtkanalchangee.Text = "";//grdMushtrianMalinkanChange.CurrentRow.Cells["kanal"].Value.ToString();
                this.txtmarlachangee.Text = "";// grdMushtrianMalinkanChange.CurrentRow.Cells["marla"].Value.ToString();
                this.txtsarsaichangee.Text = "";// grdMushtrianMalinkanChange.CurrentRow.Cells["sarsai"].Value.ToString();
                btnSaveChangeMalikan.Enabled = false;
                btndeleteChangeMalikan.Enabled = false;

            }
        }

        #region Button Delete Malak new Khata Click Event

        private void btndeleteChangeMalikan_Click(object sender, EventArgs e)
        {
            //taqseemnewkhata.WEB_SP_DELETE_KhewatGroupFareeqein(KhewatGroupFareeqId);
            //MessageBox.Show("  مالک حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            //FillGrdiTaqseemMalkan();

            if (chbDellAllMalikan.Checked)
            {
                if (MessageBox.Show(" کیا آپ تمام مالکان حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taqseemnewkhata.WEB_SP_DELETE_KhewatGroupFareeqein_Taqseem("-1", this.cmbtaqseemChangeKhata.SelectedValue.ToString(), "1");
                }
            }

            else
            {
                if (MessageBox.Show(" کیا آپ منتخب کردہ مالک حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taqseemnewkhata.WEB_SP_DELETE_KhewatGroupFareeqein_Taqseem(KhewatGroupFareeqId, "-1", "0");
                }
            }



            //taqseemnewkhata.WEB_SP_DELETE_KhewatGroupFareeqein_Taqseem(KhewatGroupFareeqId);
            // MessageBox.Show("  مالک حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            FillGrdiTaqseemMalkan();
            GetKhataAreaHissa(this.cmbtaqseemChangeKhata.SelectedValue.ToString());
            chbDellAllMalikan.Checked = false;
        }

        #endregion

        #region Get Khatoonies from Previous Khatoonies

        private void btnGetKhatooni_Click(object sender, EventArgs e)
        {
            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                try
                {
                    AL.frmNewKhatooniAdd frmKhatooni = new AL.frmNewKhatooniAdd();
                    frmKhatooni.IntiqalId = IntiqalId;
                    frmKhatooni.RegisterHaqKhataID = RegisterHqDKhataId;
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
            Fillkhatoniforkhasra();
        }

        #endregion

        #region Get Khatooni Data by Khata

        public void FillGridKhatooniChange()
        {
            try
            {



                string khataid = RegisterHqDKhataId;
                //dt = taqseemnewkhata.Proc_Get_Khatoonis(RegisterHqDKhataId.ToString());
                dt = taqseemnewkhata.Proc_Self_Get_Khatoonis(RegisterHqDKhataId.ToString());
                grdGetkhatonichange.DataSource = dt;
                grdGetkhatonichange.ReadOnly = false;
                grdGetkhatonichange.Columns[1].ReadOnly = true;
                grdGetkhatonichange.Columns[2].ReadOnly = true;
                grdGetkhatonichange.Columns[3].ReadOnly = true;
                grdGetkhatonichange.Columns[4].ReadOnly = true;
                grdGetkhatonichange.Columns[5].ReadOnly = true;
                grdGetkhatonichange.Columns["KhatooniId"].Visible = false;
                grdGetkhatonichange.Columns["RegisterHqDKhataId"].Visible = false;
                grdGetkhatonichange.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdGetkhatonichange.Columns["Khatooni_Hissa"].HeaderText = "حصہ";
                grdGetkhatonichange.Columns["Khatooni_Kanal"].HeaderText = "کنال";
                grdGetkhatonichange.Columns["Khatooni_Marla"].HeaderText = "مرلہ";
                grdGetkhatonichange.Columns["Khatooni_Sarsai"].HeaderText = "سرسائی";
                grdGetkhatonichange.Columns["Khatooni_Feet"].HeaderText = "فٹ";
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

        private void grdGetkhatonichange_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;

                if (e.ColumnIndex == grdGetkhatonichange.CurrentRow.Cells["chkkk"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grdGetkhatonichange.SelectedRows.Count > 0)
                        {
                            if (row.Selected)
                            {

                                row.Cells["chkkk"].Value = 1;

                                txtabbpashi.Text = grdGetkhatonichange.CurrentRow.Cells["Wasail_e_Abpashi"].Value.ToString();
                                this.txttafsel.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
                                this.txtlagan.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniLagan"].Value.ToString();
                                this.txtKhatooninumchagee.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniNo"].Value.ToString();
                                this.txtNewkhatooniId.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString();

                                this.txtKKulHissa.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Hissa"].Value.ToString();
                                this.txtKKulKanal.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Kanal"].Value.ToString();
                                this.txtKKulMarla.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Marla"].Value.ToString();
                                this.txtKKulSarsai.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Sarsai"].Value.ToString();
                                this.txtKKulFeet.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Feet"].Value.ToString();

                                this.txtKhatooniHissa.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Hissa"].Value.ToString();
                                this.txtKhatooniKanal.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Kanal"].Value.ToString();
                                this.txtKhatooniMarla.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Marla"].Value.ToString();
                                this.txtKhatooniSarsai.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Sarsai"].Value.ToString();
                                this.txtKhatooniFeet.Text = grdGetkhatonichange.CurrentRow.Cells["Khatooni_Feet"].Value.ToString();

                                this.GetKhatooniMushteryan(this.txtNewkhatooniId.Text.ToString());
                                this.GetKhatooniAreaHissa(this.txtNewkhatooniId.Text.ToString());
                            }

                            else
                            {
                                row.Cells["chkkk"].Value = 0;



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void ClearKhatooni()
        {
            this.txtNewkhatooniId.Text = "-1";
            this.txtKhatooninumchagee.Clear();
            this.txttafsel.Clear();
            this.txtlagan.Clear();
            this.txtabbpashi.Clear();
            this.txtKhatooniHissa.Clear();
            this.txtKhatooniKanal.Clear();
            this.txtKhatooniMarla.Clear();
            this.txtKhatooniSarsai.Clear();
            this.txtKhatooniFeet.Clear();
            this.chbDellAllKhatoonies.Checked = false;
        }

        #region Gridview new  Khatoonies double click Event 

        private void grdGetkhatonichange_DoubleClick(object sender, EventArgs e)
        {
            try
            {

            txtabbpashi.Text = grdGetkhatonichange.CurrentRow.Cells["Wasail_e_Abpashi"].Value.ToString();
            this.txttafsel.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
            this.txtlagan.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniLagan"].Value.ToString();
            this.txtKhatooninumchagee.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniNo"].Value.ToString();
            this.txtNewkhatooniId.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Khatooni New Khatooni No Click Event

        private void btnGetkhatoni_Click(object sender, EventArgs e)
        {
            try
            {
                ClearKhatooni();
                string moza = this.IntiqalId.Substring(0, 5);
                dt = taqseemnewkhata.Proc_Get_Max_Khatooni_No_By_Moza(moza);
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

        #region Button Save Khatooni New click Event

        private void btnSaveKhatonichagne_Click(object sender, EventArgs e)
        {
            try
            {
                string KhatooniId = this.txtNewkhatooniId.Text; // grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString();
                string KhatooniNo = this.txtKhatooninumchagee.Text != null ? (this.txtKhatooninumchagee.Text.ToString()) : grdGetkhatonichange.CurrentRow.Cells["KhatooniNo"].Value.ToString();
                string KhatooniKashtkaranFullDetail_New = this.txttafsel.Text != null ? (this.txttafsel.Text.ToString()) : "";
                string RegisterHqDKhataId = this.txtRegHaqKhataID.Text;// this.grdGetkhatonichange.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString();
                string Wasail_e_Abpashi = this.txtabbpashi.Text != null ? (this.txtabbpashi.Text.ToString()) : "";
                string KhatooniLagan = this.txtlagan.Text != null ? (this.txtlagan.Text.ToString()) : "";

                float KhatooniHissa = this.txtKhatooniHissa.Text.Trim() != "" ? float.Parse(txtKhatooniHissa.Text.Trim()) : 0;
                int KhatooniKanal = this.txtKhatooniKanal.Text.Trim() != "" ? Convert.ToInt32(txtKhatooniKanal.Text.Trim()) : 0;
                int KhatooniMarla = this.txtKhatooniMarla.Text.Trim() != "" ? Convert.ToInt32(txtKhatooniMarla.Text.Trim()) : 0;
                float KhatooniSarsai = this.txtKhatooniSarsai.Text.Trim() != "" ? float.Parse(txtKhatooniSarsai.Text.Trim()) : 0;
                float KhatooniFeet = this.txtKhatooniFeet.Text.Trim() != "" ? float.Parse(txtKhatooniFeet.Text.Trim()) : 0;
                string khatoniid = this.taqseemnewkhata.WEB_Self_SP_INSERT_KhatooniRegister_Taqseem(KhatooniId, KhatooniNo, KhatooniKashtkaranFullDetail_New, RegisterHqDKhataId, Wasail_e_Abpashi, KhatooniLagan, KhatooniHissa, KhatooniKanal, KhatooniMarla, KhatooniSarsai, KhatooniFeet, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                if (khatoniid != null)
                {
                    this.txtNewkhatooniId.Text = khatoniid;
                    //MessageBox.Show("کھتونی محفوظ ہوگیے", "کھتونی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGridKhatooniChange();
                    Fillkhatoniforkhasra();
                    ClearKhatooni();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Select Khassra from Prevoius Khassrajat Click Event

        private void btnselectchangekhasra_Click(object sender, EventArgs e)
        {
            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                if (Convert.ToInt32(RegisterHqDKhataId) > 0)
                {
                    try
                    {
                        AL.frmNewKhasrajat frmNewKhasra = new AL.frmNewKhasrajat();
                        frmNewKhasra.KhataId = IntiqalKhataId;
                        frmNewKhasra.IntiqalId = IntiqalId;
                        frmNewKhasra.khatoniid = this.cmbkhatoonisnew.SelectedValue.ToString();
                        frmNewKhasra.RegisterhaqkhataId = RegisterHqDKhataId;//cmbtaqseemChangeKhata.SelectedValue.ToString();
                        frmNewKhasra.FormClosed -= new FormClosedEventHandler(frmNewKhasra_FormClosed);
                        frmNewKhasra.FormClosed += new FormClosedEventHandler(frmNewKhasra_FormClosed);
                        frmNewKhasra.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else
            {
                MessageBox.Show("کھاتہ نمبر کا انتخاب کریں", "", MessageBoxButtons.OK);
            }
        }
        
        void frmNewKhasra_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillKhasraJatNew();
            calculateKhassrasRaqba();
        }

        #endregion


        #region Fill New Khassrajat 

        public void FillKhasraJatNew()
        {
            if (cmbkhatoonisnew.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string khatooniid = cmbkhatoonisnew.SelectedValue.ToString();
                dt = taqseemnewkhata.Proc_Get_KhatooniKhassraDetail(khatooniid.ToString());
                if (dt != null)
                {
                    this.grdNewKhasrajat.DataSource = dt;

                    grdNewKhasrajat.Columns["KhassraDetailId"].Visible = false;
                    grdNewKhasrajat.Columns["AreaTypeId"].Visible = false;
                    grdNewKhasrajat.Columns["KhatooniId"].Visible = false;
                    grdNewKhasrajat.Columns["KhassraId"].Visible = false;
                    //grdNewKhasrajat.Columns["AreaType"].Visible = false;
                    //grdNewKhasrajat.Columns["Kanal"].Visible = false;
                    //grdNewKhasrajat.Columns["Marla"].Visible = false;
                    //grdNewKhasrajat.Columns["Sarsai"].Visible = false;
                    //grdNewKhasrajat.Columns["Feet"].Visible = false;
                    grdNewKhasrajat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                    grdNewKhasrajat.Columns["AreaType"].HeaderText = "قسم خسرہ";

                    grdNewKhasrajat.Columns["Kanal"].HeaderText = "کنال";
                    grdNewKhasrajat.Columns["Marla"].HeaderText = "مرلہ";
                    grdNewKhasrajat.Columns["Sarsai"].HeaderText = "سرسائی";
                    grdNewKhasrajat.Columns["Feet"].HeaderText = "فٹ";
                }
            }
        }

        #endregion

        #region Combobox New Khatooni Selection Change Comitted Event
        private void cmbkhatoonisnew_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillKhasraJatNew();
            calculateKhassrasRaqba();
        }
        #endregion

        #region Gridview New Khassrajat Dluble Click Event

        private void grdNewKhasrajat_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdNewKhasrajat.Rows.Count > 0)
                {
                    grdNewKhasrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    grdNewKhasrajat.CurrentRow.Cells["KhatooniId"].Value.ToString();
                    this.txt_kanal_Khasra.Text = grdNewKhasrajat.CurrentRow.Cells["Kanal"].Value.ToString();
                    this.txt_Marala_Khasra.Text = grdNewKhasrajat.CurrentRow.Cells["Marla"].Value.ToString();
                    this.txthiddenKhasarno.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.OldKhassraNo.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txthiddenkhasraid.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    this.txthiddendetailid.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraDetailId"].Value.ToString();
                    this.txtkhasratypeid.Text = grdNewKhasrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString();
                    cmbAreaTypesTaqseem.SelectedValue = Convert.ToInt32(grdNewKhasrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString());
                    decimal sar = Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Sarsai"].Value) != null ? Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Sarsai"].Value) : 0;
                    this.txt_Sarsai_Khasra.Text = Math.Round(sar, 7).ToString();
                    decimal fe = Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Feet"].Value) != null ? Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Feet"].Value) : 0;
                    this.txt_Feet_Khasra.Text = Math.Round(fe, 7).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save NewKhassra Click Event

        private void btnsavenewkhasra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txthiddenkhasraid.Text != null && OldKhassraNo.Text.Trim() != null)
                {
                    string khasraid = this.txthiddenkhasraid.Text;
                    string khasradetailid = this.txthiddendetailid.Text;
                    string khassrno = this.OldKhassraNo.Text;
                    string kanal = this.txt_kanal_Khasra.Text;
                    string marla = this.txt_Marala_Khasra.Text;
                    string feet = this.txt_Feet_Khasra.Text;
                    string sarsar = this.txt_Sarsai_Khasra.Text;
                    string AreaTypeId ="0";
                    if (cmbAreaTypesTaqseem.SelectedValue.ToString() != "0")
                    {
                        AreaTypeId = cmbAreaTypesTaqseem.SelectedValue.ToString();
                    }
                    else
                    {
                        AreaTypeId = this.txtkhasratypeid.Text;
                    }
                    if (txt_Feet_Khasra.Text.Trim() != "0" && txt_Feet_Khasra.Text.Trim() != "")
                    {
                        txt_Sarsai_Khasra.Text = Math.Round(Convert.ToDouble(txt_Feet_Khasra.Text) / 30.25, 4).ToString();
                    }
                    else if (txt_Sarsai_Khasra.Text.Trim() != "0" && txt_Sarsai_Khasra.Text.Trim() != "")
                    {
                        txt_Feet_Khasra.Text = Math.Round(Convert.ToDouble(txt_Sarsai_Khasra.Text) * 30.25, 0).ToString();
                    }
                    
                    string last = "", last1 = "";
                    //string str = IntiqalId;
                    //string mozaid = str.Substring(0,5);
                    if (OldKhassraNo.Text != txthiddenKhasarno.Text)
                    {
                        last = taqseemnewkhata.WEB_SP_INSERT_KhassraRegistert(khasraid, MozaId.ToString(), "0", khassrno, "", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                    }
                    last1 = taqseemnewkhata.WEB_SP_INSERT_KhassraRegisterDetail(khasradetailid, khasraid, AreaTypeId, kanal, marla, sarsar, feet, UsersManagments.UserId.ToString());

                    FillKhasraJatNew();
                    calculateKhassrasRaqba();
                }

            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Get Total Area KhassraJat

        public void getkhasrajattotalarea()
        {
            try
            {
                DataTable dt = new DataTable();
                //dt = Intiqal.Proc_Get_KhassrasTotalArea_By_KhataId(RegisterHqDKhataId);
                dt = Intiqal.Proc_Self_Get_KhassrasTotalArea_By_KhataId(RegisterHqDKhataId);
                foreach (DataRow d in dt.Rows)
                {
                    label109.Text = d["AREA"].ToString();
                }
                if (dt.Rows.Count < 1)
                {
                    label109.Text = "0-0-0";
                }
            }

            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Button Delete New Khatooni Click Event

        private void btnDeleteKhatoonichange_Click(object sender, EventArgs e)
        {

            if (chbDellAllKhatoonies.Checked)
            {
                if (MessageBox.Show(" کیا آپ کھاتے کے تمام کھتونیاں حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    taqseemnewkhata.WEB_SP_DELETE_KhatooniRegister_Taqseem("-1", this.cmbtaqseemChangeKhata.SelectedValue.ToString(), "1");
                }
            }

            else
            {
                if (MessageBox.Show(" کیا آپ منتخب شدہ کھتونی حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.taqseemnewkhata.WEB_SP_DELETE_KhatooniRegister_Taqseem(this.txtNewkhatooniId.Text, "-1", "0");
                }
            }
            FillGridKhatooniChange();
            Fillkhatoniforkhasra();
            chbDellAllKhatoonies.Checked = false;
            ClearKhatooni();
        }

        #endregion

        #region Button Delete New Khassra Click event

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbDellAllKhassrajat.Checked)
                {
                    if (MessageBox.Show(" کیا آپ منتخب شدہ کھتونی کے تمام خسرہ جات حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        taqseemnewkhata.WEB_SP_DELETE_KhassraRegister_Taqseem(this.cmbkhatoonisnew.SelectedValue.ToString());
                    }
                }

                else
                {
                    if (this.txthiddendetailid.Text != null)
                    {
                        taqseemnewkhata.WEB_SP_DELETE_KhassraRegisterDetail_Direct(this.txthiddendetailid.Text);
                    }
                }
                // MessageBox.Show("خسرہ نمبر حذف ہوگیا ہے", "", MessageBoxButtons.OK);
                this.FillKhasraJatNew();
                calculateKhassrasRaqba();
                chbDellAllKhassrajat.Checked = false;
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Button Delete New Khata Taqseen Click Event

        private void btnDeleteChange_Click(object sender, EventArgs e)
        {
            if (this.txtRegHaqKhataID.Text != "")
            {
                try
                {
                    inteq.DeleteRegisterHaqdaranKhattaByKhataId(this.txtRegHaqKhataID.Text);
                    AutoComplete on = new AutoComplete();
                    on.FillCombo("Proc_Self_Get_Moza_Register_KhataJat_ParentKhataID "+UsersManagments._Tehsilid.ToString()+"," + MozaId + "," + IntiqalId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                    cmbtaqseemChangeKhata.SelectedValue = RegisterHqDKhataId;
                    Get_TaqseemRegHadkhataid(RegisterHqDKhataId);
                    getkhasrajattotalarea(); 
                    ClearTaqseemNewTab();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else

                MessageBox.Show("برائے مہربانی کھاتہ چنیے");
        }

        #endregion

        #region Key Press Event for Auto Urdu language conversion

        private void cboPersonSeller_KeyPress(object sender, KeyPressEventArgs e)
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
            //else if (e.KeyChar == 1)
            //{
            //    //     ComboBox txt = sender as ComboBox;
            //    //    txt.SelectAll();
            //}
            ////else if(e.KeyChar==13)
            ////{
            ////    MessageBox.Show("");
            ////}
        }

        private void cboKhewatType_KeyPress(object sender, KeyPressEventArgs e)
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

        }

        #endregion

        #region Gridview New KhassraJat Cell Click Event

        private void grdNewKhasrajat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["chk"].Value = 1;
                }
                else
                {
                    row.Cells["chk"].Value = 0;
                }
            }
            try
            {
                if (grdNewKhasrajat.Rows.Count > 0)
                {
                    grdNewKhasrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    grdNewKhasrajat.CurrentRow.Cells["KhatooniId"].Value.ToString();
                    this.txt_kanal_Khasra.Text = grdNewKhasrajat.CurrentRow.Cells["Kanal"].Value.ToString();
                    this.txt_Marala_Khasra.Text = grdNewKhasrajat.CurrentRow.Cells["Marla"].Value.ToString();
                    this.txthiddenKhasarno.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.OldKhassraNo.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txthiddenkhasraid.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    this.txthiddendetailid.Text = grdNewKhasrajat.CurrentRow.Cells["KhassraDetailId"].Value.ToString();
                    this.txtkhasratypeid.Text = grdNewKhasrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString();
                    cmbAreaTypesTaqseem.SelectedValue = Convert.ToInt32(grdNewKhasrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString());
                    decimal sar = Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Sarsai"].Value) != null ? Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Sarsai"].Value) : 0;
                    this.txt_Sarsai_Khasra.Text = Math.Round(sar, 7).ToString();
                    decimal fe = Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Feet"].Value) != null ? Convert.ToDecimal(grdNewKhasrajat.CurrentRow.Cells["Feet"].Value) : 0;
                    this.txt_Feet_Khasra.Text = Math.Round(fe, 7).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CalulateArea_Mush_HissabamutabiqRaqba()
        {
            try
            {

                float khissay = this.txtKKulHissa.Text.Trim() != "" ? float.Parse(txtKKulHissa.Text.Trim()) : 0;
                float shissay = this.txtMushHisachange.Text.Trim() != "" ? float.Parse(txtMushHisachange.Text.Trim()) : 0;
                int kkanal = this.txtKKulKanal.Text.Trim() != "" ? Convert.ToInt32(txtKKulKanal.Text.Trim()) : 0;
                int kmarla = this.txtKKulMarla.Text.Trim() != "" ? Convert.ToInt32(txtKKulMarla.Text.Trim()) : 0;
                float ksarsai = this.txtKKulSarsai.Text.Trim() != "" ? float.Parse(txtKKulSarsai.Text.Trim()) : 0;
                float ksft = this.txtKKulFeet.Text.Trim() != "" ? float.Parse(txtKKulFeet.Text.Trim()) : 0;


                int bkanal = txtMushkanalchange.Text.Trim() != "" ? Convert.ToInt32(txtMushkanalchange.Text.Trim()) : 0;
                int bmarla = txtMushmarlachange.Text.Trim() != "" ? Convert.ToInt32(txtMushmarlachange.Text.Trim()) : 0;
                float bsarsai = txtMushsarsaichange.Text.Trim() != "" ? float.Parse(txtMushsarsaichange.Text.Trim()) : 0;
                float bsft = txtMushFeetchange.Text.Trim() != "" ? float.Parse(txtMushFeetchange.Text.Trim()) : 0; //0;


                if (shissay > 0)
                {
                    string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                    txtMushkanalchange.Text = raqba[0];
                    txtMushmarlachange.Text = raqba[1];
                    txtMushsarsaichange.Text = raqba[2];
                    txtMushFeetchange.Text = raqba[3];


                }
                else
                {

                    txtMushHisachange.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void txttafsel_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Button Hissa / Raqba Calculate Click Event

        private void btnishtarakhisabamutabiq_Click(object sender, EventArgs e)
        {
            CalulateArea_Taqseem_isshtiraq();
        }

        public void CalulateArea_Taqseem_isshtiraq()
        {
            try
            {

                float khissay = this.txthissayChagne.Text.Trim() != "" ? float.Parse(txthissayChagne.Text.Trim()) : 0;
                float shissay = txtHisamuntaqialachangeevb.Text.Trim() != "" ? float.Parse(txtHisamuntaqialachangeevb.Text.Trim()) : 0;
                int kkanal = this.txtKanalChange.Text.Trim() != "" ? Convert.ToInt32(txtKanalChange.Text.Trim()) : 0;
                int kmarla = this.txtMarlayChange.Text.Trim() != "" ? Convert.ToInt32(txtMarlayChange.Text.Trim()) : 0;
                float ksarsai = this.txtSarsasiChange.Text.Trim() != "" ? float.Parse(txtSarsasiChange.Text.Trim()) : 0;
                float ksft = this.txtFeetChange.Text.Trim() != "" ? float.Parse(txtFeetChange.Text.Trim()) : 0;


                int bkanal = txtkanalchangee.Text.Trim() != "" ? Convert.ToInt32(txtkanalchangee.Text.Trim()) : 0;
                int bmarla = this.txtmarlachangee.Text.Trim() != "" ? Convert.ToInt32(txtmarlachangee.Text.Trim()) : 0;
                float bsarsai = this.txtsarsaichangee.Text.Trim() != "" ? float.Parse(txtsarsaichangee.Text.Trim()) : 0;
                float bsft = this.txtfeetchagee.Text.Trim() != "" ? float.Parse(txtfeetchagee.Text.Trim()) : 0; //0;


                if (shissay > 0)
                {
                    string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                    txtkanalchangee.Text = raqba[0];
                    this.txtmarlachangee.Text = raqba[1];
                    this.txtsarsaichangee.Text = raqba[2];
                    this.txtfeetchagee.Text = raqba[3];


                }
                else
                {

                    txtHisamuntaqialachangeevb.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Combo box New Khata by Parent Khata Selection Change Event

        private void cmbtaqseemChangeKhata_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtkolhisa.Text = txthissayChagne.Text != null ? txthissayChagne.Text : "0";
            txtkolfeet.Text = txtFeetChange.Text != null ? txtFeetChange.Text : "0"; ;
            txtkolkanal.Text = txtKanalChange.Text != null ? txtKanalChange.Text : "0";
            txtkolmarala.Text = txtMarlayChange.Text != null ? txtMarlayChange.Text : "0";
            txtkolsarsai.Text = txtSarsasiChange.Text != null ? txtSarsasiChange.Text : "0";
         
        }

        #endregion

        #region Drop Down Get KhassraJat By Khatooni Id Selection Change Event

        private void cmbkhatoonisnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillKhasraJatNew();
            calculateKhassrasRaqba();
        }

        public void getkhasrajatbykhatoni()
        {
            //try
            //{
            //    string kanal = "0";
            //    string marala = "0";
            //    string sarsai = "0";
            //    DataTable dt = new DataTable();
            //    if (Convert.ToInt32(cmbkhatoonisnew.SelectedValue )> 0)
            //    {

            //        dt = Intiqal.Proc_Get_KhassaAreaByKhatooniId(cmbkhatoonisnew.SelectedValue.ToString());
            //        foreach (DataRow d in dt.Rows)
            //        {
            //            string str = d["sumofkhasrakhatoniid"].ToString();
            //            string[] arr = str.Split(new string[] { " " }, StringSplitOptions.None);
            //            foreach (string a in arr)
            //            {
            //                if (a != string.Empty)
            //                {
            //                    if (a.Contains("کنال"))
            //                    {
            //                        string[] k = a.Split(new string[] { "کنال" }, StringSplitOptions.None);
            //                        t1kanal.Text = k[0].ToString();
            //                    }
            //                    if (a.Contains("مرلہ"))
            //                    {
            //                        string[] M = a.Split(new string[] { "مرلہ" }, StringSplitOptions.None);
            //                        t1marla.Text = M[0].ToString();
            //                    }
            //                    if (a.Contains("سرسائی"))
            //                    {
            //                        string[] S = a.Split(new string[] { "سرسائی" }, StringSplitOptions.None);
            //                        t1sarsai.Text = S[0].ToString();
            //                    }
            //                }
            //            }

            //        }
            //        string kanaal = t1kanal.Text != null ? t1kanal.Text : "0";
            //        string marla = t1marla.Text != null ? t1marla.Text : "0";
            //        string sarsari = t1sarsai.Text != null ? t1sarsai.Text : "0";
            //        string com = kanaal + "-" + marla + "-" + sarsai;
            //        label92.Text = com;
            //    }
            //    else
            //    {
            //        label92.Text = "0-0-0";
            //    }


            //}
            //catch (Exception ex)
            //{
            //}
        }

        #endregion
        #region Calculate total raqba khassrajaat of a khatoni

        private void calculateKhassrasRaqba()
        {
            double kanal = 0;
            double marla = 0;
            double sarsai = 0;
            double feet = 0;

            foreach (DataGridViewRow row in grdNewKhasrajat.Rows)
            {
                try
                {
                    kanal += row.Cells["Kanal"].Value != null ? Convert.ToInt32(row.Cells["Kanal"].Value) : 0;
                    marla += row.Cells["Marla"].Value != null ? Convert.ToInt32(row.Cells["Marla"].Value) : 0;
                    sarsai += row.Cells["Sarsai"].Value != null ? Convert.ToDouble(row.Cells["Sarsai"].Value) : 0;

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
            label92.Text = kanal.ToString() + "-" + marla.ToString() + "-" + Convert.ToInt32(sarsai * 30.25).ToString();

        }

        #endregion

        #region Juzvi Salam Khassra Section

        private void cbJuzviKhata_CheckedChanged(object sender, EventArgs e)
        {

            if (cbJuzviKhata.Checked)
            {
                if (!IsJuzviKhatta)
                {
                    if (this.GridViewInteqalKhattas.SelectedRows.Count > 0)
                    {
                        if (MessageBox.Show("کیا اپ انتقال کے اس کھاتے میں سالم/جزوی خسرے کا اندراج چاہتے ہے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool isJuzvi = inteq.UpdateIntiqalKhataJuzviStatus("1", this.IntiqalKhataRecId);
                            if (isJuzvi)
                            {
                                gbJuzviSalamKhassraEntry.Visible = true;
                                string khataId = GridViewInteqalKhattas.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();
                                AutoFillCombo.FillCombo("Proc_Get_Khatoonis " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khataId, cmbKhatooniListforKhassras, "KhatooniNo", "KhatooniId");
                            }
                        }
                    }
                }
                else
                {
                    gbJuzviSalamKhassraEntry.Visible = true;
                    string khataId = GridViewInteqalKhattas.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();
                    AutoFillCombo.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataId, cmbKhatooniListforKhassras, "KhatooniNo", "KhatooniId");
                }

            }
            else if (!cbJuzviKhata.Checked)
            {
                if (IsJuzviKhatta)
                {
                    if (MessageBox.Show("کیا اپ انتقال کے اس کھاتے میں سالم/جزوی خسرے کا اندراج ختم کرنا چاہتے ہے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("اس کھاتے کے تمام سالم/جزوی خسرے خزف ہو جائنگے- کیا اپ جاری رکھنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // delete all khassras against this khatta in juzvi/Salam Khassra table.
                            foreach (DataGridViewRow row in GridviewSaveSalamJuzviKhassra.Rows)
                            {
                                Intiqal.DeleteIntiqalSalamJuzviKhassra(row.Cells["SalamJuzviKhassraId"].Value.ToString());
                            }

                            bool isJuzvi = inteq.UpdateIntiqalKhataJuzviStatus("0", this.IntiqalKhataRecId);

                            // Set the Group Box visible to false
                            if (!isJuzvi)
                            {
                                gbJuzviSalamKhassraEntry.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Intiqal AmalDaramad for Taqseem and Shirakat

        private void btnAmalDaramadTaqseemWaIshterak_Click(object sender, EventArgs e)
        {
            try
            {
                bool MinhayeIntiqalAmaldaramadStatus = Convert.ToBoolean(Intiqal.GetIntiqalAmaldaramadStatusForMinhayeIntiqal(this.MinhayeIntiqalId));
                if (MinhayeIntiqalAmaldaramadStatus)
                {
                    if (MessageBox.Show(" عمل درآمد ک بعد آپ اس انتقال میں میں تبدیلی نہیں کر سکتے۔ پھر بھی عمل درآمد کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        //MessageBox.Show("Yes");

                        Intiqal.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                        //client.IntiqalAmalDaramadCombined(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());

                        //if (s != null || s != "")
                        //{
                        MessageBox.Show("عمل درامد ہو گیا");
                        this.AmalDaramad = true;
                        this.SetAmalDaramadStatus(this.AmalDaramad);

                    }
                    else
                    {
                        //MessageBox.Show("No");
                    }
                }
                else
                {
                    MessageBox.Show("عملدرادمد نہیں ہو سکا۔ اس انتقال کے عملدرامد سے پہلے منہائے انتقال پر عملدرامد کریں۔", "عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Warisan Bamutabiq Manderja Khata

        private void btnWarisanManderjaKhata_Click(object sender, EventArgs e)
        {
            try
            {
                 if (!isAttested  && !this.AmalDaramad)
                {
                if (GridViewInteqalKhattas.Rows.Count > 1)
                {
                    if (cbAllKhatajat.Checked)
                    {
                        if (GridViewInteqalKhattas.SelectedRows[0].Index == 0)
                        {
                            if (GridSellerList.Rows.Count > 0)
                            {
                                string intiqalRecId = GridViewInteqalKhattas.SelectedRows[0].Cells[3].Value.ToString();
                                string s = Intiqal.IntiqalWarasathManderjaKhattajatWarisan(intiqalRecId, this.IntiqalId.ToString());
                                DataGridViewCellEventArgs ea = new DataGridViewCellEventArgs(0, 0);
                                this.GridViewInteqalKhattas_CellClick((object)GridViewInteqalKhattas, ea);
                            }
                            else
                            {
                                MessageBox.Show(" پہلے متوفی/ متوفیہ کا ریکارڈ محفوظ کریں", "مندرجہ کھاتہ وارثان");
                            }
                        }
                        else
                        {
                            MessageBox.Show("انتقال کا پہلا کھاتہ سیلیکٹ کریں۔", "مندرجہ کھاتہ وارثان");
                        }
                    }
                    else
                    {
                        if (GridViewInteqalKhattas.SelectedRows[0].Index > 0)
                        {
                            if (GridSellerList.Rows.Count > 0)
                            {
                                string intiqalRecId = GridViewInteqalKhattas.SelectedRows[0].Cells[3].Value.ToString();
                                string s = Intiqal.IntiqalWarasathManderjaKhattaWarisan(intiqalRecId, this.IntiqalId.ToString());
                                DataGridViewCellEventArgs ea = new DataGridViewCellEventArgs(0, 0);
                                this.GridViewInteqalKhattas_CellClick((object)GridViewInteqalKhattas, ea);
                            }
                            else
                            {
                                MessageBox.Show(" پہلے متوفی/ متوفیہ کا ریکارڈ محفوظ کریں", "مندرجہ کھاتہ وارثان");
                            }
                        }
                        else
                        {
                            MessageBox.Show("یہ سہولت انتقال کے پہلے کھاتے کے لیے کارامد  نہیں ہے", "مندرجہ کھاتہ وارثان");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("یہ سہولت صرف ایک سے زیادہ کھاتے کے لیے کارامد ہے", "مندرجہ کھاتہ وارثان");
                }
                }
                 else
                 {
                     MessageBox.Show("یہ انتقال تصدیق شدہ / عمل شدہ ہے", "مندرجہ کھتونی وارثان");
                 }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Get Mushteryan from Previous Khatooni Click Event

        private void btnMusheryanFromKhatooni_Click(object sender, EventArgs e)
        {
            try
            {
                frmKhatooniMushteryanFromKhatooni frmMushteryan = new frmKhatooniMushteryanFromKhatooni();
                frmMushteryan.NewKhatooniId = Convert.ToInt32(this.txtNewkhatooniId.Text != "" ? this.txtNewkhatooniId.Text : "0");
                frmMushteryan.IntiqalId = this.IntiqalId.ToString();
                frmMushteryan.MozaId = this.MozaId.ToString();
                frmMushteryan.FormClosed -= new FormClosedEventHandler(frmMushteryan_FormClosed);
                frmMushteryan.FormClosed += new FormClosedEventHandler(frmMushteryan_FormClosed);
                frmMushteryan.ShowDialog();
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

        #region Button Raqba Bamutabiq Hissa Calculation
  
        private void btnRaqbaBamutabiqHissa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdMushtrianMalinkanChange.Rows)
                        {
                            string kgf_id = row.Cells["KhewatGroupFareeqId"].Value != null ? row.Cells["KhewatGroupFareeqId"].Value.ToString() : "0";
                            float netpart = float.Parse(row.Cells["FardAreaPart"].Value != null ? row.Cells["FardAreaPart"].Value.ToString() : "0");  //Convert.ToInt32(PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).Count() > 0 ? PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).FirstOrDefault().FardAreaPart : 0);
                            string raqba = this.PersonRaqba(netpart);
                            int kanal =  raqba.Split('-').ElementAt(0) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(0)) : 0;
                            int marla = raqba.Split('-').ElementAt(1) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(1)) : 0;
                            float sarsai =  raqba.Split('-').ElementAt(2) != "" ? float.Parse(raqba.Split('-').ElementAt(2)) : 0;
                            float sft =Convert.ToInt32(  raqba.Split('-').ElementAt(3) != "" ? float.Parse(raqba.Split('-').ElementAt(3)) : 0);
                            Intiqal.UpdateMalakRaqbaByHissa(kgf_id, "0", kanal.ToString(), marla.ToString(), sarsai.ToString(), sft.ToString()); // netpart updation disabled in SP because no need of updating fard parts
                        }
                FillGrdiTaqseemMalkan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Calculates Person Raqba on basis of person area parts

        private string PersonRaqba(float hissa)
        {
            //Previous Calculation
            //int totalHissay = txtKulHisay.Text.Trim() != "" ? Convert.ToInt32(txtKulHisay.Text.Trim()) : 0;

            //textBox1 is Sum of fareeqain total parts after calculation
            float totalHissay = txthissayChagne.Text.Trim() != "" ? float.Parse(txthissayChagne.Text.Trim()) : 0; //Modified by Yousaf
            //MessageBox.Show(textBox1.Text);
            int tkanal = txtKanalChange.Text != "" ? Convert.ToInt32(txtKanalChange.Text) : 0;
            int tmarla = txtMarlayChange.Text != "" ? Convert.ToInt32(txtMarlayChange.Text) : 0;
            float tsarsai = txtSarsasiChange.Text != "" ? float.Parse(txtSarsasiChange.Text) : 0;
            if (hissa != totalHissay)
            {
                double totalRaqba = Convert.ToDouble(Math.Round((((((20 * tkanal) + tmarla) * 9) + tsarsai) * 30.25), 3, MidpointRounding.AwayFromZero).ToString()); //in square feet
                double PersonRaqba = 0;
                if (totalHissay != 0)
                {
                    PersonRaqba = Convert.ToDouble(Math.Round(((hissa / totalHissay) * totalRaqba), 3, MidpointRounding.AwayFromZero).ToString());
                }
                //MessageBox.Show("Hissa " +hissa.ToString() + " total Hissay "+ totalHissay.ToString()+ " Kul Raqba "+ totalRaqba.ToString());


                int marla = 0;
                int kanal = 0;
                float sarsai = 0;
                double sft = 0;
                sft = PersonRaqba;
                if (PersonRaqba >= 272.25)
                {
                    sft = PersonRaqba % (double)272.25;
                    marla = Convert.ToInt32((float)(PersonRaqba - sft) / (float)272.25);

                    if (marla >= 20)
                    {
                        kanal = (marla - (marla % 20)) / 20;
                        marla = marla % 20;
                        //if (sft >= 31)
                        //{
                        //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                        //    sft = Convert.ToInt32(sft % 30.25);
                        //}

                    }
                    else
                    {
                        kanal = 0;
                    }

                }
                else
                {
                    marla = 0;
                    kanal = 0;
                    //if (sft >= 31)
                    //{
                    //    sarsai = Convert.ToInt32((sft - (sft % 30.25)) / 30.25);
                    //    sft = Convert.ToInt32(sft % 30.25);
                    //}
                }
                if (sft > 0)
                {
                    sarsai = float.Parse((sft / (double)30.25).ToString());
                }
                return kanal.ToString() + "-" + marla.ToString() + "-" + Math.Round(sarsai, 4, MidpointRounding.AwayFromZero).ToString() + "-" + Math.Round(sft, 4, MidpointRounding.AwayFromZero).ToString();

            }
            else
            {
                return tkanal.ToString() + "-" + tmarla.ToString() + "-" + tsarsai.ToString() + "-0.0";
            }
        }

        #endregion

        #region Salam/Juzvi Khassra Khatooni selection

        private void cmbKhatooniListforKhassras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //AutoFillCombo.FillCombo("Proc_Get_Khatooni_KhassraArea_Detail " + cmbKhatooniListforKhassras.SelectedValue.ToString(), cmbKhassraList, "KhassraNo", "KhassraDetailId");
                gridviewSalamjuzviKhassraList.DataSource = Intiqal.GetKhassrasByKhatoni(cmbKhatooniListforKhassras.SelectedValue.ToString());
                //gridviewSalamjuzviKhassraList.DataSource= Intiqal.GetKhassrasByKhatoni(cmbKhatooniListforKhassras.SelectedValue.ToString());
                //String str = SDC_Application.AL.frmIntiqalKhattaJat.getStringFromCombo(cmbKhatooniListforKhassras);
                

                //gridviewSalamjuzviKhassraList.DataSource= Intiqal.GetKhassrasByKhatoni(str);
                gridviewSalamjuzviKhassraList.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                gridviewSalamjuzviKhassraList.Columns["Kanal"].HeaderText = "کنال";
                gridviewSalamjuzviKhassraList.Columns["Marla"].HeaderText = "مرلہ";
                gridviewSalamjuzviKhassraList.Columns["Sarsai"].HeaderText = "سرسائی";
                gridviewSalamjuzviKhassraList.Columns["Feet"].HeaderText = "فٹ";
                gridviewSalamjuzviKhassraList.Columns["AreaType"].HeaderText = "قسم زمین";
                gridviewSalamjuzviKhassraList.Columns["AreaTypeId"].Visible = false;
                gridviewSalamjuzviKhassraList.Columns["KhassraDetailId"].Visible = false;
                gridviewSalamjuzviKhassraList.Columns["KhassraId"].Visible = false;
                gridviewSalamjuzviKhassraList.Columns["KhatooniId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Gridview Salamjuzvi Khassra List cell click event

        private void gridviewSalamjuzviKhassraList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView  g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    cmbJuzviSalamList.SelectedIndex = 0;
                    this.txtMinKhassraNewKhassraNo.Text = g.SelectedRows[0].Cells["KhassraNo"].Value.ToString();
                    this.txtMinKhassraKanal.Text = g.SelectedRows[0].Cells["Kanal"].Value.ToString();
                    txtMinKhassraMarla.Text = g.SelectedRows[0].Cells["Marla"].Value.ToString();
                    txtMinKhassraSarsai.Text = g.SelectedRows[0].Cells["Sarsai"].Value.ToString();
                    txtMinKhassraSft.Text = g.SelectedRows[0].Cells["Feet"].Value.ToString();
                    txtsalamjuzviKhassraId.Text = g.SelectedRows[0].Cells["KhassraId"].Value.ToString();
                    txtsalamjuzviKhatooniId.Text = g.SelectedRows[0].Cells["KhatooniId"].Value.ToString();
                    txtsalamjuzviKhassraDetailId.Text = g.SelectedRows[0].Cells["KhassraDetailId"].Value.ToString();
                    txtsalamjuzviAreaTypeId.Text = g.SelectedRows[0].Cells["AreaTypeId"].Value.ToString();
                    txtsalamjuzviKhassraRecId.Text = "-1";
                    this.EnableDisableSalamJuzviKhassraControls(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnableDisableSalamJuzviKhassraControls(bool Enable)
        {
            if (Enable)
            {
                this.txtMinKhassraNewKhassraNo.Enabled=true;
                this.txtMinKhassraKanal.Enabled=true; 
                txtMinKhassraMarla.Enabled=true;
                txtMinKhassraSarsai.Enabled = true;
                txtMinKhassraSft.Enabled = true;
            }
            else
            {
                this.txtMinKhassraNewKhassraNo.Enabled = false;
                this.txtMinKhassraKanal.Enabled = false;
                txtMinKhassraMarla.Enabled = false;
                txtMinKhassraSarsai.Enabled = false;
                txtMinKhassraSft.Enabled = false;
            }
        }

        #endregion

        #region SalamJuzvi Combobox selection change Event

        private void cmbJuzviSalamList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbJuzviSalamList.SelectedIndex == 0)
            {
                EnableDisableSalamJuzviKhassraControls(false);
                txtMinKhassraNewKhassraNo.Text = gridviewSalamjuzviKhassraList.SelectedRows[0].Cells["KhassraNo"].Value.ToString() ;
            }
            else
            {
                EnableDisableSalamJuzviKhassraControls(true);
                txtMinKhassraNewKhassraNo.Text = gridviewSalamjuzviKhassraList.SelectedRows[0].Cells["KhassraNo"].Value.ToString()+"/1";
            }
        }

        #endregion

        #region Button Save Salam Juzvi Khassra click Event

        private void btnSaveJuzviSalamKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbJuzviSalamList.SelectedIndex >= 0 && txtMinKhassraNewKhassraNo.Text.Trim() != "" && txtsalamjuzviKhassraId.Text != "-1" && txtsalamjuzviAreaTypeId.Text != "-1" && txtsalamjuzviKhassraDetailId.Text != "-1" && txtsalamjuzviKhassraId.Text != "-1")
                {
                    string kanal = txtMinKhassraKanal.Text.Trim() != "" ? txtMinKhassraKanal.Text.Trim() : "0";
                    string marla = txtMinKhassraMarla.Text.Trim() != "" ? txtMinKhassraMarla.Text.Trim() : "0";
                    string sarsai = txtMinKhassraSarsai.Text.Trim() != "" ? txtMinKhassraSarsai.Text.Trim() : "0";
                    string feet = txtMinKhassraSft.Text.Trim() != "" ? txtMinKhassraSft.Text.Trim() : "0";
                    string SalamJuzvi=cmbJuzviSalamList.SelectedIndex==0?"سالم":"جزوی";
                    string lastId = Intiqal.SaveSalamJuzviKhassraDetail(txtsalamjuzviKhassraRecId.Text, txtsalamjuzviKhassraId.Text, txtsalamjuzviKhassraDetailId.Text, txtMinKhassraNewKhassraNo.Text.Trim(), SalamJuzvi, txtsalamjuzviKhatooniId.Text, this.IntiqalKhataRecId, "0", kanal, marla, sarsai, feet, txtsalamjuzviAreaTypeId.Text, this.MozaId.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (lastId != null)
                    {
                        this.ClearSalamJuzviKhassraControls();
                        this.FillGridviewSalamJuzviKhassra();
                        
                    }
                }
                else
                {
                    MessageBox.Show("من خسرہ کے تمام کوائف پرا کریں۔", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Clear Salam Juzvi Khassra Controls
        private void ClearSalamJuzviKhassraControls()
        {
            cmbJuzviSalamList.SelectedIndex = 0;
            this.txtMinKhassraNewKhassraNo.Clear();
            this.txtMinKhassraKanal.Text ="";
            txtMinKhassraMarla.Text ="";
            txtMinKhassraSarsai.Text = "";
            txtMinKhassraSft.Text = "";
            txtsalamjuzviKhassraId.Text = "-1" ;
            txtsalamjuzviKhatooniId.Text = "-1";
            txtsalamjuzviKhassraDetailId.Text ="-1";
            txtsalamjuzviAreaTypeId.Text = "-1";
            txtsalamjuzviKhassraRecId.Text = "-1";
            this.EnableDisableSalamJuzviKhassraControls(false);
        }
        #endregion

        #region Button New Salam Juzvi Khassra Click Event

    private void btnNewJuzviSalamKhassra_Click(object sender, EventArgs e)
    {
        this.ClearSalamJuzviKhassraControls();
    }

    #endregion

        #region Get Saved Intiqal salam Juzvi Khassra List

    private void FillGridviewSalamJuzviKhassra()
    {
        GridviewSaveSalamJuzviKhassra.DataSource = Intiqal.GetIntiqalSalamJuzviKhassra(this.IntiqalKhataRecId);
        GridviewSaveSalamJuzviKhassra.Columns["MinType"].HeaderText = "قسم من";
        GridviewSaveSalamJuzviKhassra.Columns["Min_KhassraNo"].HeaderText = "نمبر خسرہ";
        GridviewSaveSalamJuzviKhassra.Columns["KhatooniNo"].HeaderText = "نمبر کھتونی";
        GridviewSaveSalamJuzviKhassra.Columns["AreaType"].HeaderText = "قسم زمین";
        GridviewSaveSalamJuzviKhassra.Columns["Min_Kanal"].HeaderText = "کنال";
        GridviewSaveSalamJuzviKhassra.Columns["Min_Marla"].HeaderText = "مرلہ";
        GridviewSaveSalamJuzviKhassra.Columns["Min_Sarsai"].HeaderText = "سرسائی";
        GridviewSaveSalamJuzviKhassra.Columns["Min_Feet"].HeaderText = "فٹ";

        GridviewSaveSalamJuzviKhassra.Columns["SalamJuzviKhassraId"].Visible = false;
        GridviewSaveSalamJuzviKhassra.Columns["KhatooniId"].Visible = false;
        GridviewSaveSalamJuzviKhassra.Columns["KhassraId"].Visible = false;
        GridviewSaveSalamJuzviKhassra.Columns["IntiqalKhataRecId"].Visible = false;
        GridviewSaveSalamJuzviKhassra.Columns["AreaTypeId"].Visible = false;
        GridviewSaveSalamJuzviKhassra.Columns["khassraDetailId"].Visible = false;

    }
        #endregion

        #region Gridview Salam Juzvi Saved Khassra Cell Click event

    private void GridviewSaveSalamJuzviKhassra_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView g = sender as DataGridView;
        if (g.SelectedRows.Count > 0)
        {
            this.txtsalamjuzviKhassraId.Text = g.SelectedRows[0].Cells["KhassraId"].Value.ToString();
            this.txtsalamjuzviKhassraDetailId.Text = g.SelectedRows[0].Cells["khassraDetailId"].Value.ToString();
            this.txtsalamjuzviAreaTypeId.Text = g.SelectedRows[0].Cells["AreaTypeId"].Value.ToString();
            this.txtsalamjuzviKhassraRecId.Text = g.SelectedRows[0].Cells["SalamJuzviKhassraId"].Value.ToString();
            this.txtsalamjuzviKhatooniId.Text = g.SelectedRows[0].Cells["KhatooniId"].Value.ToString();

            txtMinKhassraKanal.Text = g.SelectedRows[0].Cells["Min_Kanal"].Value.ToString();
            txtMinKhassraMarla.Text = g.SelectedRows[0].Cells["Min_Marla"].Value.ToString();
            txtMinKhassraSarsai.Text = g.SelectedRows[0].Cells["Min_Sarsai"].Value.ToString();
            txtMinKhassraSft.Text = g.SelectedRows[0].Cells["Min_Feet"].Value.ToString();
            txtMinKhassraNewKhassraNo.Text = g.SelectedRows[0].Cells["Min_KhassraNo"].Value.ToString();
            cmbJuzviSalamList.SelectedIndex = g.SelectedRows[0].Cells["MinType"].Value.ToString() == "سالم" ? 0 : 1;
        }
    }

    #endregion

        #region Button Delete Salam Juzvi Khassra

    private void btnDeleteJuzviSalamKhassra_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtsalamjuzviKhassraRecId.Text != "-1")
            {
                if (MessageBox.Show("کیا انتخاب کردہ سالم/جزوی خسرہ خذف کرنا چاہتے ہے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Intiqal.DeleteIntiqalSalamJuzviKhassra(txtsalamjuzviKhassraRecId.Text);
                    ClearSalamJuzviKhassraControls();
                    FillGridviewSalamJuzviKhassra();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
  
    #endregion

        #region Adding Row Number to Gridview Buyers

    private void setRowNumber(DataGridView dgv)
    {
        foreach (DataGridViewRow row in dgv.Rows)
        {
            row.HeaderCell.Value = (row.Index + 1).ToString();
        }
    }
        #endregion

        #region Search taqseem Malkan in Gridview

        private void txtSearchMalik_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearchMalik.Text.Trim();
            dvTaqseemMalkan.RowFilter = "PersonName LIKE '%" + filter + "%'";
            FillGridMalikanChange(dvTaqseemMalkan.ToTable());
        }
        private void txtMushtriTaqseemSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtMushtriTaqseemSearch.Text.Trim();
            dvTaqseemMushtryan.RowFilter = "CompleteName LIKE '%" + filter + "%'";
            FillGridTaqseemMushtryan(dvTaqseemMushtryan.ToTable());


        }
        #endregion

        private void btnMlaknManderjaKhata_Click(object sender, EventArgs e)
        {
            try
            {
                frmIntiqalMalkanManderjaKhata frmMalkan = new frmIntiqalMalkanManderjaKhata();
                frmMalkan.KhataId = RegisterHqDKhataId;
                frmMalkan.MozaId=this.MozaId;
                frmMalkan.ForKhataKhatooni = 1;
                frmMalkan.FormClosed -= new FormClosedEventHandler(frmMalkan_FormClosed);
                frmMalkan.FormClosed += new FormClosedEventHandler(frmMalkan_FormClosed);
                frmMalkan.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmMalkan_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrdiTaqseemMalkan();
        }

        # region "Shajra"
        private void tabPageShajra_Paint(object sender, PaintEventArgs e)
        {
            //+++++++++++++   متوفی  +++++++++++++++++++++++++++++

            DataTable warisan = inteq.GetWarisan(this.IntiqalId);
            if (warisan.Rows.Count > 0)
            {

                string MutawafiHissa = inteq.GetMutawafiHissa(this.IntiqalId);
                string MutawafiName = inteq.GetMutawafiName(this.IntiqalId);


                Graphics myGraphics = e.Graphics;
                Pen myPen = new Pen(Color.Black);
                Font font1 = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Rectangle r = new Rectangle(600, 30, 120, 120);
                e.Graphics.DrawString(MutawafiName + System.Environment.NewLine + "کل حصے: " + MutawafiHissa, font1, Brushes.Black, r, sf);
                myGraphics.DrawRectangle(myPen, r);
                myGraphics.DrawLine(myPen, 660, 150, 660, 180);

                //+++++++++++++   متوفی ختم  +++++++++++++++++++++++++++++

                //+++++++++++++++++++++++ بیٹا  +++++++++++++++++++++++++++

                int x1 = 660, x2 = 730, y1 = 180, y2 = 180, w = 120, h = 120;


                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";
                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() == "2")
                    {
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);
                        myGraphics.DrawLine(myPen, x2, y1, x2, y1 + 30);

                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;
                        Rectangle r1 = new Rectangle(x2 - (w / 2), y1 + 30, w, h);

                        myGraphics.FillRectangle(Brushes.LightGreen, r1);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r1, sf);
                        // myGraphics.DrawRectangle(myPen, r1);


                        x1 = x2;
                        x2 = x2 + w + 20;
                    }

                }


                //+++++++++++++++++++++++ بیٹاختم  +++++++++++++++++++++++++++
                //+++++++++++++++++++++++ بیٹی  +++++++++++++++++++++++++++

                x1 = 660; x2 = 590; y1 = 180; y2 = 180; w = 120; h = 120;

                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";





                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() == "3")
                    {
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);
                        myGraphics.DrawLine(myPen, x2, y1, x2, y1 + 30);
                        Rectangle r2 = new Rectangle(x2 - (w / 2), y1 + 30, w, h);

                        myGraphics.FillEllipse(Brushes.LightSalmon, r2);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r2, sf);
                        //myGraphics.DrawEllipse(myPen, r2);

                        x1 = x2;
                        x2 = x2 - w - 20;
                    }

                }


                //+++++++++++++++++++++++ بیٹی ختم  +++++++++++++++++++++++++++


                //+++++++++++++++++++++++ زوجہ  +++++++++++++++++++++++++++

                x1 = 600; x2 = 560; y1 = 90; y2 = 90; w = 120; h = 120;

                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";
                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() == "1")
                    {
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);
                        Rectangle r3 = new Rectangle(x2 - w, y1 - (h / 2), w, h);

                        myGraphics.FillEllipse(Brushes.LightCoral, r3);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r3, sf);
                        //myGraphics.DrawEllipse(myPen, r3);

                        x1 = x2 - w;
                        x2 = x1 - 30;
                    }

                }


                //+++++++++++++++++++++++ زوجہ ختم  +++++++++++++++++++++++++++

                //+++++++++++++++++++++++ شوہر  +++++++++++++++++++++++++++

                x1 = 720; x2 = 760; y1 = 90; y2 = 90; w = 120; h = 120;

                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";
                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() == "6")
                    {
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);

                        Rectangle r4 = new Rectangle(x2, y1 - (h / 2), w, h);
                        myGraphics.FillRectangle(Brushes.LightSlateGray, r4);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r4, sf);
                        //myGraphics.DrawRectangle(myPen, r4);



                        x1 = x2 + w;
                        x2 = x1 + 30;

                    }

                }


                //+++++++++++++++++++++++ شوہر ختم  +++++++++++++++++++++++++++


                //+++++++++++++++++++++++ Other Males  +++++++++++++++++++++++++++

                x1 = 660; x2 = 730; y1 = 380; y2 = 380; w = 120; h = 120;

                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";
                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() != "6" && data["RishtaId"].ToString() != "2" && data["Gender"].ToString() == "1")
                    {
                        myGraphics.DrawLine(myPen, 660, 160, 660, 380);
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);
                        myGraphics.DrawLine(myPen, x2, y1, x2, y1 + 30);

                        Rectangle r5 = new Rectangle(x2 - (w / 2), y1 + 30, w, h);

                        myGraphics.FillRectangle(Brushes.Olive, r5);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r5, sf);
                        //myGraphics.DrawRectangle(myPen, r5);

                        x1 = x2;
                        x2 = x2 + w + 20;
                    }

                }


                //+++++++++++++++++++++++ other males finish  +++++++++++++++++++++++++++

                //+++++++++++++++++++++++ Other females  +++++++++++++++++++++++++++

                x1 = 660; x2 = 580; y1 = 380; y2 = 380; w = 120; h = 120;

                foreach (DataRow data in warisan.Rows)
                {
                    string name = "";
                    string rishta = "";
                    string hissa = "";
                    if (data["RishtaId"].ToString() != "1" && data["RishtaId"].ToString() != "3" && data["Gender"].ToString() == "0")
                    {
                        myGraphics.DrawLine(myPen, 660, 160, 660, 380);
                        name = data["PersonName"].ToString();
                        rishta = data["Rishta"].ToString();
                        hissa = data["Hissa"].ToString();

                        myGraphics.DrawLine(myPen, x1, y1, x2, y2);
                        myGraphics.DrawLine(myPen, x2, y1, x2, y1 + 30);

                        Rectangle r6 = new Rectangle(x2 - (w / 2), y1 + 30, w, h);

                        myGraphics.FillEllipse(Brushes.MediumTurquoise, r6);
                        e.Graphics.DrawString(name + System.Environment.NewLine + "حصہ: " + hissa + System.Environment.NewLine + rishta, font1, Brushes.Black, r6, sf);
                        //myGraphics.DrawEllipse(myPen, r6);


                        x1 = x2;
                        x2 = x2 - w - 20;
                    }

                }


                //+++++++++++++++++++++++ other females finish  +++++++++++++++++++++++++++

                myGraphics.Dispose();
            }
            else
            {
                Graphics myGraphics = e.Graphics;
                Pen myPen = new Pen(Color.Black);
                Font font1 = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Rectangle r = new Rectangle(500, 200, 500, 120);
                e.Graphics.DrawString("اس انتقال کا خاکہ موجود نہیں ہے", font1, Brushes.Red, r, sf);
                myGraphics.DrawRectangle(myPen, r);

            }
        }
        # endregion

      

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtKhattaRecId.Text = "-1";
            txtparentKhataId.Text = "-1";
            Fill_InteqalKhataGrid();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void btnLandTax_Click(object sender, EventArgs e)
        {
            if (this.txtHiddenPersonID.Text != null && this.txtHiddenPersonID.Text != "0" && this.txtHiddenPersonID.Text != "-1")
            {
                frmLandTax frmlandtax = new frmLandTax();
                frmlandtax.Personid = this.txtHiddenPersonID.Text;
                frmlandtax.ShowDialog();

                //frmSDCReportingMain LandTaxReport = new frmSDCReportingMain();
                //LandTaxReport.FardPersonId = this.txtHiddenPersonID.Text;
                //LandTaxReport.IntiqalId = this.IntiqalId;
                //UsersManagments.check = 23;
                //LandTaxReport.ShowDialog();
            }
            else
            {
                MessageBox.Show("مالک کا انتخاب کریں");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.txthiddnPersonId.Text != null && this.txthiddnPersonId.Text != "0" && this.txthiddnPersonId.Text != "-1")
            {
                frmLandTax frmlandtax = new frmLandTax();
                frmlandtax.Personid = this.txthiddnPersonId.Text;
                frmlandtax.ShowDialog();

                //frmSDCReportingMain LandTaxReport = new frmSDCReportingMain();
                //LandTaxReport.FardPersonId = this.txthiddnPersonId.Text;
                //LandTaxReport.IntiqalId = this.IntiqalId;
                //UsersManagments.check = 24;
                //LandTaxReport.ShowDialog();


            }
            else
            {
                MessageBox.Show("مالک کا انتخاب کریں");
            }
        }
        private void chkHissaTransferred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHissaTransferred.Checked)
            {
                txtHissaMuntaqila.Clear();
                txtHissaMuntaqila.Enabled = true;
            }
            else
            {
                txtHissaMuntaqila.Clear();
                txtHissaMuntaqila.Enabled = false;
            }
        }

        private void btnRahinSellers_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhewatType.SelectedIndex > 0)
                {
                    frmBuyersRahin frmBR = new frmBuyersRahin();
                    frmBR.IntiqalKhataRecId = this.IntiqalKhataRecId;
                    //frmTMSIW.IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                    //frmTMSIW.MozaId = this.MozaId.ToString();
                    //frmBR.FormClosed -= new FormClosedEventHandler(frmTMSIW_closed);
                    //frmBR.FormClosed += new FormClosedEventHandler(frmTMSIW_closed);
                    //frmTMSIW.KhatoniRecid = KhatoniRecid;
                    //frmTMSIW.IntiqalKhataRecId = this.IntiqalKhataRecId;
                    frmBR.ShowDialog();
                }
                else
                {
                    MessageBox.Show("قسم ملکیت کا انتخاب کریں", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMushtryan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMushtryan.CurrentRow.Selected)
            {

                foreach (DataGridViewRow row in dgvMushtryan.Rows)
                {
                    row.Cells["chk_change_Mushtryan"].Value = 0;
                }
                dgvMushtryan.CurrentRow.Cells["chk_change_Mushtryan"].Value = 1;
                fillMushtrichangetextboxes();
                if (AmalDaramad == false && isAttested == false)
                {
                    btnSaveChangeMushtryan.Enabled = true;
                    btndeleteChangeMushtryan.Enabled = true;
                }

            }
            else
            {
                dgvMushtryan.CurrentRow.Cells["chk_change_Mushtryan"].Value = 0;



            }
        }

        private void btniMushhisabamutabiqRaqba_Click(object sender, EventArgs e)
        {
            CalulateArea_Mush_HissabamutabiqRaqba();
        }

        private void btnSaveChangeMushtryan_Click(object sender, EventArgs e)
        {
            try
            {


                string MushtriFareeqIdTaqseem = dgvMushtryan.CurrentRow.Cells["MushtriFareeqId"].Value.ToString();
                string MushPersonId = dgvMushtryan.CurrentRow.Cells["PersonId"].Value.ToString();
                decimal MushFardAreaPart = this.txtMushHisachange.Text.Trim() != "" ? Convert.ToDecimal(this.txtMushHisachange.Text.ToString()) : 0;
                string Mushfardkanal = this.txtMushkanalchange.Text != "" ? this.txtMushkanalchange.Text.ToString() : "0";
                string Mushfardmarla = this.txtMushmarlachange.Text != "" ? this.txtMushmarlachange.Text.ToString() : "0";
                string Mushardsarsai = txtMushsarsaichange.Text != "" ? this.txtMushsarsaichange.Text.ToString() : "0";
                decimal Mushfardfeet = txtMushFeetchange.Text.Trim() != "" ? Convert.ToDecimal(this.txtMushFeetchange.Text.ToString()) : 0;

                string lastid = taqseemnewkhata.WEB_SP_Update_MushtriFareeqein(MushtriFareeqIdTaqseem, MushFardAreaPart.ToString(), Mushfardkanal.ToString(), Mushfardmarla.ToString(), Mushardsarsai.ToString(), Mushfardfeet.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                btnSaveChangeMushtryan.Enabled = false;
                btndeleteChangeMushtryan.Enabled = false;
                this.GetKhatooniMushteryan(this.txtNewkhatooniId.Text.ToString());
                this.GetKhatooniAreaHissa(this.txtNewkhatooniId.Text.ToString());
                ClearMushtrichangetextboxes();
                //txtSearchMalik_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMushtriTaqseemSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSearchBuyers_TextChanged(object sender, EventArgs e)
        {
            bb.Filter = string.Format("PersonName LIKE '%{0}%' ", txtSearchBuyers.Text);
        }

        private void txtSearchBuyers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btndeleteChangeMushtryan_Click(object sender, EventArgs e)
        {


            if (chbDelAll.Checked)
            {
                if (MessageBox.Show(" کیا آپ تمام مشتریان حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taqseemnewkhata.WEB_SP_DELETE_MushtriGroupFareeqein("-1", this.txtNewkhatooniId.Text.ToString(), "1");

                    btnSaveChangeMushtryan.Enabled = false;
                    btndeleteChangeMushtryan.Enabled = false;
                    this.GetKhatooniMushteryan(this.txtNewkhatooniId.Text.ToString());
                    this.GetKhatooniAreaHissa(this.txtNewkhatooniId.Text.ToString());
                    ClearMushtrichangetextboxes();
                }

            }

            else
            {
                if (MushtriFareeqIdTaqseem == "null" || MushtriFareeqIdTaqseem == "" || MushtriFareeqIdTaqseem == "-1")
                {
                    MessageBox.Show("  مشتری سیلیکٹ کریں", "", MessageBoxButtons.OK);
                }
                else
                {
                    if (MessageBox.Show(" کیا آپ منتخب کردہ مشتری حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        taqseemnewkhata.WEB_SP_DELETE_MushtriGroupFareeqein(MushtriFareeqIdTaqseem, "-1", "0");

                        btnSaveChangeMushtryan.Enabled = false;
                        btndeleteChangeMushtryan.Enabled = false;
                        this.GetKhatooniMushteryan(this.txtNewkhatooniId.Text.ToString());
                        this.GetKhatooniAreaHissa(this.txtNewkhatooniId.Text.ToString());
                        ClearMushtrichangetextboxes();
                    }
                }
            }


        }

        private void btnLoadKhatajat_Click(object sender, EventArgs e)
        {
            frmKhattaSearchByPersonForIntiqal SPI = new frmKhattaSearchByPersonForIntiqal();
            SPI.MozaID = this.MozaId.ToString();
            SPI.IntiqalId = this.IntiqalId.ToString();
            SPI.FM = "M";

            SPI.FormClosed -= new FormClosedEventHandler(SPI_FormClosed);
            SPI.FormClosed += new FormClosedEventHandler(SPI_FormClosed);
            SPI.ShowDialog();
        }


        void SPI_FormClosed(object sender, FormClosedEventArgs e)
        {

            Fill_InteqalKhataGrid();
            GridSellerList.DataSource = null;
            GridBuyersList.DataSource = null;
        }

        private void btnMlaknManderjaKhtooni_Click(object sender, EventArgs e)
        {
            if (RegisterHqDKhataId == null || RegisterHqDKhataId == "0")
            {
                MessageBox.Show("کھاتہ سیلیکٹ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                frmIntiqalMalkanManderjaKhata frmMalkan = new frmIntiqalMalkanManderjaKhata();
                frmMalkan.KhataId = RegisterHqDKhataId;
                frmMalkan.KhataKulHissay = txthissayChagne.Text;
                frmMalkan.KhataKanal = txtKanalChange.Text;
                frmMalkan.KhataMarla = txtMarlayChange.Text;
                frmMalkan.KhataSarsai = txtSarsasiChange.Text;
                frmMalkan.KhataFeet = txtFeetChange.Text;
                frmMalkan.ForKhataKhatooni = 2;
                frmMalkan.MozaId = this.MozaId;
                frmMalkan.FormClosed -= new FormClosedEventHandler(frmMalkan_FormClosed);
                frmMalkan.FormClosed += new FormClosedEventHandler(frmMalkan_FormClosed);
                frmMalkan.ShowDialog();
            }

        }

        private void dtFardToken_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dtFardToken.Value;
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string year = date.Year.ToString();
            datetoken = year + "-" + month + "-" + day;
            this.TokenList = inteq.GetTransactionalTokenNoListByDateKhata(this.IntiqalKhataId.ToString(), datetoken);
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
            cboPersonSeller.DataSource = null;
            if (cmbFardTokenNo.SelectedIndex != 0)
            {

                AutoFillCombo.FillCombo("proc_Self_Get_RegistryIntiqal_Khata_Malkan '" + IntiqalKhataId + "'" + "," + cmbFardTokenNo.SelectedValue.ToString(), cboPersonSeller, "personname", "KhewatGroupFareeqId");

            }

        }



        private void txtSearchComp_KeyPress(object sender, KeyPressEventArgs e)
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



        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label147_Click(object sender, EventArgs e)
        {

        }

        private void txtlagan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtabbpashi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtKhatooniHissa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtKhatooniKanal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtKhatooniMarla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtKhatooniSarsai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void txtKhatooniFeet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        private void btnBuyerFamilySel_Click(object sender, EventArgs e)
        {
            if (cboKhewatType.SelectedIndex > 0)
            {
                frmTestMalkanSelcIntiqalWirasath frmTMSIW = new frmTestMalkanSelcIntiqalWirasath();
                frmTMSIW.khewatTypeId = cboKhewatType.SelectedValue.ToString();
                frmTMSIW.IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                frmTMSIW.MozaId = this.MozaId.ToString();
                frmTMSIW.FormClosed -= new FormClosedEventHandler(frmTMSIW_closed);
                frmTMSIW.FormClosed += new FormClosedEventHandler(frmTMSIW_closed);
                frmTMSIW.KhatoniRecid = KhatoniRecid;
                frmTMSIW.IntiqalKhataRecId = this.IntiqalKhataRecId;
                frmTMSIW.ShowDialog();
            }
            else
            {
                MessageBox.Show("قسم ملکیت کا انتخاب کریں", "", MessageBoxButtons.OK);
            }
        }
        void frmTMSIW_closed(object sender, FormClosedEventArgs e)
        {
            FillgridByBuyerList();
        }

        #region button Auto Khata Creation 

        private void btnAutoKhataCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridviewSaveSalamJuzviKhassra.DataSource != null)
                {
                    if (GridviewSaveSalamJuzviKhassra.Rows.Count > 0 )
                    {
                        if (cmbtaqseemChangeKhata.Items.Count < 2)
                        {
                            string KhataRecId = txtKhattaRecId.Text;
                            string retVal = Intiqal.SaveAutoKhatajatForKhassraIntiqal(KhataRecId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            if (retVal.Length > 5)
                            {
                                AutoComplete on = new AutoComplete();
                                //on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                                on.FillCombo("Proc_Self_Get_Moza_Register_KhataJat_ParentKhataID " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + IntiqalId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
                                cmbtaqseemChangeKhata.SelectedValue = RegisterHqDKhataId;
                                Get_TaqseemRegHadkhataid(RegisterHqDKhataId);
                                getkhasrajattotalarea();
                            }
                        }
                        else
                            MessageBox.Show("کھاتہ پہلے سے موجود ہیں۔");
                    }
                    else
                        MessageBox.Show("یہ سہولت صرف جزوی کھاتہ کیلئے  کار امد ہے۔ پہلے جزوی کھاتہ میں نمبر خسرہ محفوظ کریں۔");
                }
                else
                    MessageBox.Show("یہ سہولت صرف جزوی کھاتہ کیلئے  کار امد ہے۔ پہلے جزوی کھاتہ میں نمبر خسرہ محفوظ کریں۔");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnAutoSaveKhatooniKhassras_Click(object sender, EventArgs e)
        {
            try 
	            {
                    string KhataNoNew = "0";
                    string KhataNo = GridViewInteqalKhattas.SelectedRows[0].Cells["KhataNo"].Value.ToString();
                    KhataNoNew = KhataNo == cmbtaqseemChangeKhata.Text ? "0" : cmbtaqseemChangeKhata.Text;
                    if (cmbtaqseemChangeKhata.SelectedValue.ToString().Length > 2)
                    {
                        if (grdGetkhatonichange.DataSource == null || grdGetkhatonichange.Rows.Count == 0)
                        {
                           string retVal= taqseemnewkhata.SaveAutoKhatooniesInKhassraIntiqal(txtKhattaRecId.Text, cmbtaqseemChangeKhata.SelectedValue.ToString(), KhataNoNew, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                           if (retVal.Length > 5)
                           {
                               FillGridKhatooniChange();
                               Fillkhatoniforkhasra();
                               ClearKhatooni();
                           }
                        }
                        else
                            MessageBox.Show("کھتونی ریکارڈ پہلے سے موجود ہے۔");
                    }
                    else
                        MessageBox.Show("کھاتے کا انتخاب کریں۔");
	            }
	       catch (Exception ex)
	            {
		            MessageBox.Show(ex.Message);
	            }
            
        }
    }
}

















