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
    public partial class frmIntiqalKhattaJatKhatooni : Form
    {
        public string IntiqalId { get; set; }
        public bool isAttested { get; set; }
        public int Teh_Report;
        public string isGardawar { get; set; }
        public bool isConfirmed { get; set; }
        public string MinhayeIntiqalId { get; set; }
        public string IntiqalTypeId { get; set; }
        public string BS_AreaHissa { get; set; }
        public string RegStatus { get; set; }
        //public string lastId { get; set; }
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        Intiqal inteq = new Intiqal();
        DataTable dtkj = new DataTable();
        DataTable saveKhata = new DataTable();
        DataTable dtmg = new DataTable();
        DataTable dtMinGrpDet = new DataTable();
        BindingSource bs = new BindingSource();
        BindingSource bb = new BindingSource();
        DataTable dtKhatooniesByParentKhatooni = new DataTable();
        BL.TaqseemNewKhataJatMin taqseemnewkhata = new BL.TaqseemNewKhataJatMin();
        Khatoonies khatooni = new Khatoonies();
        public bool IsJuzviKhatta { get; set; }
        public bool IsJuzviKhatooni { get; set; }
        DataTable MinhayeIntiqals = new DataTable();


        //string KhewatGroupFareeqId;

        #region Varibles frmSellers
        public string NewKhatooniCreate
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
        float KhatooniHissa = 0;
        int KhatooniKanal = 0;
        int KhatooniMarla = 0;
        float KhatooniSarsai = 0;
        float KhatooniFeet = 0;
        public bool AmalDaramad { get; set; }

        public bool MalkiatKashkat { get; set; }
        AutoComplete AutoFillCombo = new AutoComplete();
        CommanFunctions CommanFunctions = new CommanFunctions();
        datagrid_controls datacontrols = new datagrid_controls();
        LanguageConverter lang = new LanguageConverter();
        Intiqal Intiqal = new Intiqal();
        DataTable dt = new DataTable();
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
        public string IntiqalKhatooniRecId { get; set; }
        public string IntiqalMinKhatoniNo { get; set; }
        public string IntiqalMinOldKhatooniId { get; set; }
        public string IntiqalMinKhatooniRecId { get; set; }
        // Registry Fard Token
        public string FardTokenId { get; set; }
        public string intiqalIId { get; set; }
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
                // this.lblMozaName.Text = value;
            }
        }

        #endregion

        public frmIntiqalKhattaJatKhatooni()
        {
            InitializeComponent();
        }



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
                this.groupBox19.Visible = false;
                gbAmalDaramad.Visible = true;
                if (Status)
                {
                    lblMutStatus.Text = "عمل درامد شدہ";
                    lblMutStatus.ForeColor = Color.Green;
                    btnAmaldaramad.Enabled = false;
                    this.btnWarisanManderjaKhatooni.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainContols.Enabled = false;
                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.btndeletenewKhassra.Enabled = false;
                    

                }
                else if (isAttested)
                {
                    
                   
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                       
                       
                            btnAmaldaramad.Enabled = true;
                      
                         this.btnWarisanManderjaKhatooni.Enabled = false;
                        this.gbKhataMainContols.Enabled = false;
                        this.gbKhatooniMainContols.Enabled = false;
                        this.gbSellersControls.Enabled = false;
                        this.gbBuyersControls.Enabled = false;
                        this.gbSubKhatooniMain.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.btndeletenewKhassra.Enabled = false;
                 }
                else if(isConfirmed)
                {
                    lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                    btnAmaldaramad.Enabled = false;
                    this.btnWarisanManderjaKhatooni.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainContols.Enabled = false;
                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.btndeletenewKhassra.Enabled = false;
                }
                
                    else
                    {
                       lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                   
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    }
                
            }
            else if (mingrp == 1)
            {
                this.groupBox19.Visible = true;
                //gbAmalDaramad.Visible = false;
                if (Status)
                {
                    lblMutStatus.Text = "عمل درامد شدہ";
                    lblMutStatus.ForeColor = Color.Green;
                    btnAmaldaramad.Enabled = false;
                    this.btnWarisanManderjaKhatooni.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainContols.Enabled = false;
                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.btndeletenewKhassra.Enabled = false;

                    this.groupBox17.Enabled = false;
                    this.groupBox18.Enabled = false;
                   
                }
                else if (isAttested)
                {
                    

                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;

                       
                            btnAmaldaramad.Enabled = true;
                        
                        this.btnWarisanManderjaKhatooni.Enabled = false;
                        this.gbKhataMainContols.Enabled = false;
                        this.gbKhatooniMainContols.Enabled = false;
                        this.gbSellersControls.Enabled = false;
                        this.gbBuyersControls.Enabled = false;
                        this.gbSubKhatooniMain.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.btndeletenewKhassra.Enabled = false;

                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                }  
                    
                    else if (isConfirmed)
                    {
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                        btnAmaldaramad.Enabled = false;
                        this.btnWarisanManderjaKhatooni.Enabled = false;
                        this.gbKhataMainContols.Enabled = false;
                        this.gbKhatooniMainContols.Enabled = false;
                        this.gbSellersControls.Enabled = false;
                        this.gbBuyersControls.Enabled = false;
                        this.gbSubKhatooniMain.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.btndeletenewKhassra.Enabled = false;

                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                    }
                    else
                    {

                        
                       lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                   
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        btnAmalDaramadTaqseem.Enabled = false;
                         this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                    

                      
                    }
                

            }

        }
        #endregion

        #endregion

        private void frmkhatta_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
            if (UsersManagments.Implementation == "0")
            {
                this.btnAmaldaramad.Visible = false;
            }
            if (IntiqalId != "-1")
            {
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
                if (this.FardTokenId != "0" && this.FardTokenId!=null)
                {
                    fillRegistryIntiqalkhatajatList(this.FardTokenId.ToString());

                }
                else
                {
                    fillIntiqalkhatajatList(this.MozaId.ToString());
                    lbFard.Visible = false;
                    txtFardFeet.Visible = false;
                    txtFardHissay.Visible = false;
                    txtFardKanal.Visible = false;
                    txtFardMarla.Visible = false;
                    txtFardSarsai.Visible = false;
                    lbTotal.Visible = false;
                }
                Fill_InteqalKhataGrid();
                txtKhattaRecId.Text = "-1";
                this.MinhayeIntiqals = Intiqal.GetIntiqalMinhayeIntiqals(this.IntiqalId);
                this.SetAmalDaramadStatus(this.AmalDaramad);
                //if (isAttested)
                //{
                //    gbBuyersControls.Enabled = false;
                //    gbSellersControls.Enabled = false;
                //    gbKhataMainContols.Enabled = false;
                //    gbSubKhatooniMain.Enabled = false;
                //    gbSubKhatooniMalkan.Enabled = false;
                //    gbSubKhatooniKhassras.Enabled = false;
                //}
               

            }
            else
            {
                this.Close();
                MessageBox.Show("انتقال لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

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
        }

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
                GridViewInteqalKhattas.Columns["IsJuzviKhatta"].Visible = false;
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
                    inteq.DeleteIntiqalKhattajat(Convert.ToInt32(this.txtKhattaRecId.Text));
                    txtKhattaRecId.Text = "-1";
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
                GridSellerList1.DataSource = null;
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
                            //string KhataId = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataId"].Value.ToString();
                            if (IntiqalKhataId != string.Empty)
                            {

                                if (!MalkiatKashkat)
                                {
                                    if (this.FardTokenId != "0" && this.FardTokenId!=null)
                                        AutoFillCombo.FillCombo("proc_Self_Get_Khatoonies_of_Khata_for_RegistryIntiqal_By_FardTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'" + "," + FardTokenId, cmbKhatoniNo, "KhatooniNo", "KhatooniId");
                                    else
                                        AutoFillCombo.FillCombo("dbo.Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'", cmbKhatoniNo, "KhatooniNo", "KhatooniId");

                                    GetKhatoni(txtKhattaRecId.Text);
                                   
                                }

                                //if (MalkiatKashkat)
                                //{

                                //   AutoFillCombo.FillCombo("proc_Get_Intiqal_Khata_Malkan '" + IntiqalKhataId + "'", cboPersonSeller, "personname", "KhewatGroupFareeqId");
                                //   proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                                //   FillgridByBuyerList();

                                //}
                            }


                            Fill_ComboKhewatTypes();
                            gridselection();
                            btnNewBuyer_Click(sender, e);
                            this.ClearFormControls(groupBox8);
                            CalculateSellerBuyerRaqbaHissa();
                            txthiddenBuyerRecId.Text = "-1";
                            //FillgridByBuyerList();
                        }
                        else
                        {
                            row.Cells["colChoose"].Value = 0;
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
                            //txtIntiqalKhatooniRecId.Text = LastId;
                            this.txtIntiqalKhatooniRecId.Text = "-1";
                            txtparentKhatooniId.Text = "-1";
                            cmbKhatoniNo.SelectedIndex = 0;
                            GetKhatoni(txtKhattaRecId.Text);
                           
                        }
                    }
                    else
                    {
                        string LastId = inteq.SaveintiqalKhatoni(IntiqalKhatooniRecId, intiqalId, IntiqalKhataRecId, IntiqalKhataId, KhatoniId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        //txtIntiqalKhatooniRecId.Text = LastId;
                        this.txtIntiqalKhatooniRecId.Text = "-1";
                        txtparentKhatooniId.Text = "-1";
                        cmbKhatoniNo.SelectedIndex = 0;
                        GetKhatoni(txtKhattaRecId.Text);
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

        public void GetKhatoni(string IntiqalKhataRecId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = inteq.GetKhatoniDetails(IntiqalKhataRecId);
                grdKhatoniDetails.DataSource = dt;
                grdKhatoniDetails.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdKhatoniDetails.Columns["Khatooni_TotalParts"].HeaderText = "کل حصے";
                grdKhatoniDetails.Columns["Khatooni_Area"].HeaderText = "کل رقبہ";
                grdKhatoniDetails.Columns["IntiqalKhatooniRecId"].Visible = false;
                grdKhatoniDetails.Columns["KhatooniId"].Visible = false;
                grdKhatoniDetails.Columns["isJuzvi"].Visible = false;
                grdKhatoniDetails.Columns["TotalParts"].Visible = false;
                grdKhatoniDetails.Columns["Kanal"].Visible = false;
                grdKhatoniDetails.Columns["Marla"].Visible = false;
                grdKhatoniDetails.Columns["Sarsai"].Visible = false;
                grdKhatoniDetails.Columns["Feet"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKhatoniClear_Click(object sender, EventArgs e)
        {
            this.txtIntiqalKhatooniRecId.Text = "-1";
            txtparentKhatooniId.Text = "-1";
            cmbKhatoniNo.SelectedIndex = 0;
            GetKhatoni(txtKhattaRecId.Text);
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
                                    this.cmbKhatoniNo.SelectedValue = this.grdKhatoniDetails.CurrentRow.Cells["KhatooniId"].Value.ToString();
                                    this.txtparentKhatooniId.Text = Khatoniid;
                                    this.NewKhatooniCreate = this.grdKhatoniDetails.CurrentRow.Cells["KhatooniNo"].Value.ToString();
                                    KhatoniRecid = this.grdKhatoniDetails.CurrentRow.Cells["IntiqalKhatooniRecId"].Value.ToString();
                                    IsJuzviKhatooni = Convert.ToBoolean(g.CurrentRow.Cells["isJuzvi"].Value.ToString()); ;
                                    cbJuzviKhata.Checked = IsJuzviKhatooni;
                                    string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                                    string IntiqalKhatooniRecId = txtIntiqalKhatooniRecId.Text.ToString();
                                    KhatooniHissa = float.Parse(grdKhatoniDetails.CurrentRow.Cells["TotalParts"].Value.ToString());
                                    KhatooniKanal = Convert.ToInt32(grdKhatoniDetails.CurrentRow.Cells["Kanal"].Value.ToString());
                                    KhatooniMarla = Convert.ToInt32(grdKhatoniDetails.CurrentRow.Cells["Marla"].Value.ToString());
                                    KhatooniSarsai = float.Parse(grdKhatoniDetails.CurrentRow.Cells["Sarsai"].Value.ToString());
                                    KhatooniFeet = float.Parse(grdKhatoniDetails.CurrentRow.Cells["Feet"].Value.ToString());

                                    FillgridByBuyerList();
                                    proc_Get_Intiqal_Sellers_List_ByKhata("-1", IntiqalKhatooniRecId);
                                    this.GetMinKhatooniesByKhatooniId(Khatoniid);
                                    this.dtKhatooniesByParentKhatooni = Intiqal.GetKhatooniByParentKhatooniId(Khatoniid, IntiqalId);
                                    this.FillKhassraList(Khatoniid);
                                    this.FillGridviewSalamJuzviKhassra();
                                    btnNewBuyer_Click(sender, e);
                                    this.CalculateSellerBuyerRaqbaHissa();
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
                        if (this.FardTokenId != "0" && this.FardTokenId!=null)
                            AutoFillCombo.FillCombo("proc_Self_Get_RegistryIntiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Khatoniid + "'" + "," + FardTokenId, cboPersonSeller, "personname", "MushtriFareeqId");
                        else
                            AutoFillCombo.FillCombo("proc_Get_Intiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Khatoniid + "'", cboPersonSeller, "personname", "MushtriFareeqId");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Get Khassras by Khatoonies for Juzvi Khatooni

        private void FillKhassraList(string KhatooniId)
        {
            try
            {
                //AutoFillCombo.FillCombo("Proc_Get_Khatooni_KhassraArea_Detail " + cmbKhatooniListforKhassras.SelectedValue.ToString(), cmbKhassraList, "KhassraNo", "KhassraDetailId");
                gridviewSalamjuzviKhassraList.DataSource = Intiqal.GetKhassrasByKhatoni(KhatooniId);
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

        private void GetMinKhatooniesByKhatooniId(string ParentKhatooniId)
        {
            AutoFillCombo.FillCombo("Proc_Get_Khatoonis_ByParentKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentKhatooniId + "," + this.IntiqalId, cmbMinKhatooniByParentKhatooni, "KhatooniNo", "KhatooniId");
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
                    GridSellerList1.DataSource = bs;
                    GridSellerList1.DataSource = dtt;
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

                if (txtFrokhtHisay.Text.Trim() != "" && txtFrokhtHisay.Text != "0")
                {
                    txtFrokhtKanal.Text = "";
                    txtFrokhtMarla.Text = "";
                    txtFrokhtSarsai.Text = "";
                    txtFrokhtFeet.Text = "";

                    if (this.FardTokenId != "0" && this.FardTokenId != null)
                    {
                        if (Math.Round(shissay, 6) > Math.Round(fhissay, 6))
                        {
                            MessageBox.Show("مالک اس فرد کے بقایا حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }

                        else if  (Math.Round(shissay, 6) > Math.Round(khissayWOTM, 6) || Math.Round(shissay, 6) > Math.Round(khissay, 6))
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            //string[] raqba = CommanFunctions.CalculatedAreaFromHisa(fhissay, shissay, fkanal, fmarla, fsarsai, fsft);
                            //string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                            string[] raqba = CommanFunctions.CalculatedAreaFromHisa(KhatooniHissa, shissay, KhatooniKanal, KhatooniMarla, KhatooniSarsai, KhatooniFeet);
                            txtFrokhtKanal.Text = raqba[0];
                            txtFrokhtMarla.Text = raqba[1];
                            txtFrokhtSarsai.Text = raqba[2];
                            txtFrokhtFeet.Text = raqba[3];
                        }
                    }
                    else
                    {

                        if (Math.Round(shissay, 6) > Math.Round(khissayWOTM, 6) || Math.Round(shissay, 6) > Math.Round(khissay, 6))
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            // string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                            string[] raqba = CommanFunctions.CalculatedAreaFromHisa(KhatooniHissa, shissay, KhatooniKanal, KhatooniMarla, KhatooniSarsai, KhatooniFeet);
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
                        //txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
                        txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(KhatooniHissa, shissay, KhatooniKanal, KhatooniMarla, KhatooniSarsai, KhatooniFeet, bkanal, bmarla, bsarsai, bsft).ToString();
                        fhissay = txtFardHissay.Text.Trim() != "" ? float.Parse(txtFardHissay.Text.Trim()) : 0;
                        shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
                        if (shissay > fhissay)
                        {
                            MessageBox.Show("مالک اس فرد کے بقایا حصے سے زیادہ حصے فروخت نہیں کر سکتے", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else if (shissay > khissay)
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                    }
                    else
                    {
                        //txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
                        txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(KhatooniHissa, shissay, KhatooniKanal, KhatooniMarla, KhatooniSarsai, KhatooniFeet, bkanal, bmarla, bsarsai, bsft).ToString();
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
                GridSellerList1.Columns["checkListNew"].DisplayIndex = 0;
                GridSellerList1.Columns["PersonName"].DisplayIndex = 1;
                GridSellerList1.Columns["KhewatType"].DisplayIndex = 2;

                GridSellerList1.Columns["Seller_Total_Hissa"].DisplayIndex = 3;
                GridSellerList1.Columns["Seller_Total_Area"].DisplayIndex = 4;

                GridSellerList1.Columns["Seller_Sold_Hissa"].DisplayIndex = 5;
                GridSellerList1.Columns["Seller_Sold_Area"].DisplayIndex = 6;
                GridSellerList1.Columns["colMutwafiKhataJat"].DisplayIndex = 12;

                GridSellerList1.Columns["checkListNew"].HeaderText = "انتخاب کریں";
                GridSellerList1.Columns["PersonName"].HeaderText = "نام";
                GridSellerList1.Columns["KhewatType"].HeaderText = "فرد کی قسم";

                GridSellerList1.Columns["Seller_Total_Hissa"].HeaderText = "کل حصہ";
                GridSellerList1.Columns["Seller_Total_Area"].HeaderText = "کل رقبہ";

                GridSellerList1.Columns["Seller_Sold_Hissa"].HeaderText = " حصہ منتقلہ";
                GridSellerList1.Columns["Seller_Sold_Area"].HeaderText = "رقبہ منتقلہ";

                GridSellerList1.Columns["IntiqalSellerRecId"].Visible = false;
                GridSellerList1.Columns["IntiqalKhataRecId"].Visible = false;
                GridSellerList1.Columns["IntiqalSellerPersonId"].Visible = false;
                GridSellerList1.Columns["SellerPersonDied"].Visible = false;
                GridSellerList1.Columns["SellerPersonDeathDate"].Visible = false;
                GridSellerList1.Columns["IntiqalKhatooniRecId"].Visible = false;
                GridSellerList1.Columns["MushtriFareeqId"].Visible = false;
                GridSellerList1.Columns["Seller_Total_Marla"].Visible = false;
                GridSellerList1.Columns["Seller_Total_Kanal"].Visible = false;
                GridSellerList1.Columns["Seller_Total_Sarsai"].Visible = false;
                GridSellerList1.Columns["Seller_Total_Feet"].Visible = false;
                GridSellerList1.Columns["Seller_Sold_Kanal"].Visible = false;
                GridSellerList1.Columns["Seller_Sold_Marla"].Visible = false;
                GridSellerList1.Columns["Seller_Sold_Sarsai"].Visible = false;
                GridSellerList1.Columns["Seller_Sold_Feet"].Visible = false;
                GridSellerList1.Columns["KhewatTypeId"].Visible = false;
                GridSellerList1.Columns["KhewatGroupFareeqId"].Visible = false;
                datacontrols.colorrbackgrid(GridSellerList1);
                datacontrols.gridControls(GridSellerList1);
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
            this.txtKulHissayWOTminhay.Text = "";
            this.txtKulFeet.Text = "";
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
            cboPersonSeller.SelectedIndex = 0;
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
                    this.GridSellerList1.DataSource = v;
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
                if (e.ColumnIndex == GridSellerList1.CurrentRow.Cells["checkListNew"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (GridSellerList1.SelectedRows.Count > 0)
                        {
                            btnDelSeller.Enabled = true;
                            if (row.Selected)
                            {

                                row.Cells["checkListNew"].Value = 1;


                                this.cboPersonSeller.SelectedValue = row.Cells["MushtriFareeqId"].Value.ToString();
                                this.txtFrokhtHisay.Text = row.Cells["Seller_Sold_Hissa"].Value.ToString();
                                this.txtFrokhtKanal.Text = row.Cells["Seller_Sold_Kanal"].Value.ToString();
                                this.txtFrokhtMarla.Text = row.Cells["Seller_Sold_Marla"].Value.ToString();
                                this.txtFrokhtSarsai.Text = row.Cells["Seller_Sold_Sarsai"].Value.ToString();
                                this.txtFrokhtFeet.Text = row.Cells["Seller_Sold_Feet"].Value.ToString();
                                this.txtHiddenKewatGroupFareeqID.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                this.txtHidenMustariFareeqID.Text = row.Cells["MushtriFareeqId"].Value.ToString();
                                
                                txtHiddenPersonID.Text = row.Cells["IntiqalSellerPersonId"].Value.ToString();

                                //------------------------ for remaining area in case of updatation

                                DataTable dtMushteryan = new DataTable();
                                DataTable dtFard = new DataTable();

                                if (this.FardTokenId != "0" && this.FardTokenId != null)
                                {
                                    String PersonId = Intiqal.GetPersonIdByMushtriFareeqId(cboPersonSeller.SelectedValue.ToString());
                                    dtMushteryan = mnk.GetFardMushtriFareeqainRemainingAreaRegistryIntiqal(row.Cells["MushtriFareeqId"].Value.ToString(), this.FardTokenId);
                                    dtFard = mnk.GetFardMushtriFareeqainRemainingAreaofFard(row.Cells["MushtriFareeqId"].Value.ToString(), row.Cells["IntiqalSellerPersonId"].Value.ToString(), this.FardTokenId);

                                }
                                else
                                {
                                    dtMushteryan = mnk.GetFardMushteriFareeqainRemainingAreaNewFard(row.Cells["MushtriFareeqId"].Value.ToString());
                                }



                                if (dtMushteryan.Rows.Count > 0)
                                {
                                    double KulHissayWOTM = Convert.ToDouble(dtMushteryan.Rows[0]["FardAreaPartTotal"].ToString());
                                    double KulHissay = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Hissa"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Hissa"].Value.ToString());
                                    double KulKanal = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Kanal"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Kanal"].Value.ToString());
                                    double KulMarla = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Marla"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Marla"].Value.ToString());
                                    double KulSarsai = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Sarsai"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Sarsai"].Value.ToString());
                                    double KulFeet = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Feet"].ToString()) + Convert.ToDouble(row.Cells["Seller_Sold_Feet"].Value.ToString());

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
                                    txtKullKanal.Text = Math.Round(KulKanal, 0).ToString();
                                    txtKullMarla.Text = Math.Round(KulMarla, 0).ToString();
                                    txtKullSarsai.Text = Math.Round(KulSarsai, 4).ToString();
                                    txtKulFeet.Text = Math.Round(KulFeet, 0).ToString();

                                    //_________________________________Self__________________________
                                    if (this.FardTokenId != "0" && this.FardTokenId != null)
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



                                //-----------------------END-----------------------------------

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
                                groupBox16.Visible = true;
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

                if (e.ColumnIndex == GridSellerList1.CurrentRow.Cells["colMutwafiKhataJat"].ColumnIndex)
                {
                    if (this.txtHiddenPersonID.Text != "")
                    {
                        frmPersonKhattaSearch frmPersonKhattaSearch = new frmPersonKhattaSearch();
                        frmPersonKhattaSearch.FormClosed -= new FormClosedEventHandler(frmPersonKhattaSearch_FormClosed);
                        frmPersonKhattaSearch.FormClosed += new FormClosedEventHandler(frmPersonKhattaSearch_FormClosed);
                        frmPersonKhattaSearch.PersonId = this.txtHiddenPersonID.Text;
                        frmPersonKhattaSearch.MozaID = this.MozaId.ToString();
                        //string PersonNmae=
                        frmPersonKhattaSearch.PersonName = this.GridSellerList1.CurrentRow.Cells["PersonName"].Value.ToString();
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
                bool Exists = false;
                if (chkMushtharaqa.Checked)
                {
                    dt = khatooni.Get_MushtriFareeqein_By_KhatooniId(this.Khatoniid);

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
                            string KhewatGroupFareeqId = "0";// row["KhewatGroupFareeqId"].ToString();
                            string MushtriFareeqId = row["MushtriFareeqId"].ToString();
                            string Seller_Sold_Hissa = "0";
                            string Seller_Sold_Kanal = "0";
                            string Seller_Sold_Marla = "0";
                            string Seller_Sold_Sarsai = "0";
                            string Seller_Sold_Feet = "0";
                            //string MushtriFareeqId = "NULL";
                            if (GridSellerList1.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow rowss in GridSellerList1.Rows)
                                {
                                    if (MushtriFareeqId == rowss.Cells["MushtriFareeqId"].Value.ToString())
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

                        if (chkMushtharaqa.Checked)
                        {
                            Intiqal.SetMushtarkaRaqbaMuntiqlaKhatooni(txtIntiqalKhatooniRecId.Text, chkMushtharaqachecked, mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());
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
                groupBox22.Visible = true;
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
                groupBox22.Visible = false;
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
                            dt = Intiqal.GetIntiqalKhataMalikanByKhataId(IntiqalKhataId);
                            if (dt != null)
                            {
                                foreach (DataRow row in dt.Rows)
                                {


                                    if (row["KhewatGroupFareeqId"].ToString() == this.cboPersonSeller.SelectedValue.ToString())
                                    {
                                        txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        txtHidenMustariFareeqID.Text = "NULL";
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.FardTokenId != "0" && this.FardTokenId!=null)
                            {
                                dt = Intiqal.GetRegistryIntiqalKhatooniMalikanByFardTokenId(Khatoniid, this.FardTokenId);
                            }
                            else
                            {
                                
                                dt = Intiqal.GetIntiqalKhanaKasht(Khatoniid);
                            }
                            
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["MushtriFareeqId"].ToString() == this.cboPersonSeller.SelectedValue.ToString())
                                {
                                    DataTable dtMushteryan = new DataTable();
                                    DataTable dtFard = new DataTable();

                                    if (this.FardTokenId != "0" && this.FardTokenId!=null)
                                    {
                                        String PersonId = Intiqal.GetPersonIdByMushtriFareeqId(cboPersonSeller.SelectedValue.ToString());
                                        dtMushteryan = mnk.GetFardMushtriFareeqainRemainingAreaRegistryIntiqal(cboPersonSeller.SelectedValue.ToString(), this.FardTokenId);
                                        dtFard = mnk.GetFardMushtriFareeqainRemainingAreaofFard(cboPersonSeller.SelectedValue.ToString(), PersonId, this.FardTokenId);

                                    }
                                    else
                                    {
                                        dtMushteryan = mnk.GetFardMushteriFareeqainRemainingAreaNewFard(cboPersonSeller.SelectedValue.ToString());
                                    }

                                    if (dtMushteryan.Rows.Count > 0)
                                    {
                                        txtKulHissayWOTminhay.Text = dtMushteryan.Rows[0]["FardAreaPartTotal"].ToString();
                                        txtKulHisay.Text = dtMushteryan.Rows[0]["Rem_Hissa"].ToString();
                                        txtKullKanal.Text = dtMushteryan.Rows[0]["Rem_Kanal"].ToString();
                                        txtKullMarla.Text = dtMushteryan.Rows[0]["Rem_Marla"].ToString();
                                        txtKullSarsai.Text = dtMushteryan.Rows[0]["Rem_Sarsai"].ToString();
                                        txtKulFeet.Text = dtMushteryan.Rows[0]["Rem_Feet"].ToString();
                                        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        txtHiddenKewatGroupFareeqID.Text = "NULL";
                                        txtHidenMustariFareeqID.Text = row["MushtriFareeqId"].ToString();

                                        //------------self--------------------------
                                        if (this.FardTokenId != "0" && this.FardTokenId!=null)
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

                                            txtFrokhtHisay.Text = dtMushteryan.Rows[0]["Rem_Hissa"].ToString();
                                            txtFrokhtKanal.Text = dtMushteryan.Rows[0]["Rem_Kanal"].ToString();
                                            txtFrokhtMarla.Text = dtMushteryan.Rows[0]["Rem_Marla"].ToString();
                                            txtFrokhtSarsai.Text = dtMushteryan.Rows[0]["Rem_Sarsai"].ToString();
                                            txtFrokhtFeet.Text = dtMushteryan.Rows[0]["Rem_Feet"].ToString();
                                        }


                                        //------------end self----------------
                                        break;
                                    }

                                    #region Code Commented after Transactional Fard

                                    //if (this.MinhayeIntiqals.Rows.Count > 0)
                                    //{
                                    //    //------------//
                                    //    string isDependent = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), "0", row["MushtriFareeqId"].ToString(), row["FardAreaPart"].ToString());
                                    //    //bool SellerExistsInMinhaye = false;
                                    //    if (isDependent == "0")
                                    //    {
                                    //        txtKulHisay.Text = row["FardAreaPart"].ToString();
                                    //        txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                    //        txtKullMarla.Text = row["Fard_Marla"].ToString();
                                    //        txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                    //        txtKulFeet.Text = row["Fard_Feet"].ToString();
                                    //        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                    //        txtHiddenKewatGroupFareeqID.Text = "NULL";
                                    //        txtHidenMustariFareeqID.Text = row["MushtriFareeqId"].ToString();
                                    //        break;
                                    //    }
                                    //    else
                                    //    {
                                    //        string MinhayeIntiqalIdIfexists = "0";
                                    //        MinhayeIntiqalIdIfexists = Intiqal.GetIntiqalMinhayeIntiqalIdByMushteriFareeqId(row["MushtriFareeqId"].ToString());
                                    //        if (MinhayeIntiqalIdIfexists == "0")
                                    //        {
                                    //            MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + isDependent + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //            ClearAll();
                                    //        }
                                    //        else
                                    //        {
                                    //            DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalIdIfexists, IntiqalKhataId, "0", row["MushtriFareeqId"].ToString());
                                    //            DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                    //            if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                    //            {
                                    //                txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                    //                txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                    //                txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                    //                txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                    //                txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                    //                txtHiddenPersonID.Text = row["PersonId"].ToString();
                                    //                txtHiddenKewatGroupFareeqID.Text = "NULL";
                                    //                txtHidenMustariFareeqID.Text = row["MushtriFareeqId"].ToString();
                                    //                break;
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    string CheckForMinhayeIntiqalDependency = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), "0", row["MushtriFareeqId"].ToString(), row["FardAreaPart"].ToString());
                                    //    if (CheckForMinhayeIntiqalDependency == "0")
                                    //    {
                                    //        txtKulHisay.Text = row["FardAreaPart"].ToString();
                                    //        txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                    //        txtKullMarla.Text = row["Fard_Marla"].ToString();
                                    //        txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                    //        txtKulFeet.Text = row["Fard_Feet"].ToString();
                                    //        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                    //        txtHiddenKewatGroupFareeqID.Text = "NULL";
                                    //        txtHidenMustariFareeqID.Text = row["MushtriFareeqId"].ToString();
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
                    groupBox16.Enabled = true;
                    groupBox16.Visible = true;
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
                    // txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
                    // Call Hissa Raqba Bamutabiq Hissa before save
                    txtFrokhtHisay_Leave(sender, e);
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

                        if (GridSellerList1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in GridSellerList1.Rows)
                            {
                                if (MalkiatKashkat)
                                {
                                    duplicationCheck = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                }
                                else
                                {
                                    duplicationCheck = row.Cells["MushtriFareeqId"].Value.ToString();
                                }

                                if (this.cboPersonSeller.SelectedValue.ToString() == duplicationCheck && txtSellerID.Text == "-1")
                                {
                                    isExists = true;

                                    MessageBox.Show("ریکارڈ پہلے سے موجود ہے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }

                        }
                        if (!isExists)
                        {
                            string lastid;
                            if (this.FardTokenId != "0" && this.FardTokenId != null)
                            {
                                                             
                                lastid = Intiqal.SaveRegistryintiqalSellers(IntiqalSellerRecId,
                                       IntiqalKhataRecId, IntiqalSellerPersonId,
                                       SellerPersonDied, SellerPersonDeathDate,

                                       Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                      , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, this.FardTokenId, UsersManagments.UserId.ToString());
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
            if (txtFrokhtHisay.Text.Trim() != "" && txtFrokhtHisay.Text != "0")
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
                foreach (DataGridViewRow row in GridSellerList1.Rows)
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
                    bSars = 0;//bSars += row.Cells["Buyer_Sarsai"].Value != null ? Convert.ToDecimal(row.Cells["Buyer_Sarsai"].Value.ToString()) : 0;
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
        public void CalulateBuyerArea()
        {
            try
            {
                float khissay = txtIntiqalHissay.Text.Trim() != "" ? float.Parse(txtIntiqalHissay.Text.Trim()) : 0;
                float shissay = txtKharidHisay.Text.Trim() != "" ? float.Parse(txtKharidHisay.Text.Trim()) : 0;
                //Owners raqba

                string IntiqalRaqba = txtIntiqalRaqba.Text.ToString();
                string[] raqbaSplit = IntiqalRaqba.Split('-');
                int kkanal = raqbaSplit[0] != "" ? Convert.ToInt32(raqbaSplit[0]) : 0;
                int kmarla = raqbaSplit[1] != "" ? Convert.ToInt32(raqbaSplit[1]) : 0;
                float ksarsai = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) / (float)30.25 : 0;
                float ksft = 0;
                //Buyers Raqba
                int bkanal = txtKharidKanal.Text.Trim() != "" ? Convert.ToInt32(txtKharidKanal.Text.Trim()) : 0;
                int bmarla = txtKharidMarla.Text.Trim() != "" ? Convert.ToInt32(txtKharidMarla.Text.Trim()) : 0;
                float bsarsai = txtKharidSarsai.Text.Trim() != "" ? float.Parse(txtKharidSarsai.Text.Trim()) : 0;
                float bsft = txtKharidFeet.Text.Trim() != "" ? float.Parse(txtKharidFeet.Text.Trim()) : 0;

                if (txtKharidHisay.Text.Trim() != "" && txtKharidHisay.Text != "0")
                {
                    txtKharidKanal.Text = "";
                    txtKharidMarla.Text = "";
                    txtKharidSarsai.Text = "";
                    txtKharidFeet.Text = "";

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

                    txtKharidHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
                dt = inteq.GetIntiqalBuyersByIntiqalKhataRecId("-1", KhatoniRecid, MalkiatKashkat.ToString());
                bb.DataSource = dt;
                GridBuyersList.DataSource = bb;
                GridBuyersList.DataSource = dt;

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
              // this.setRowNumber(GridBuyersList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

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
                        btnSaveBuyer.Enabled = true;
                        btnNewBuyer.Enabled = true;
                        btnBuyerSearch.Enabled = true;
                        
                        gridselection();
                        this.ClearFormControls(groupBox8);
                        FillgridByBuyerList();
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

                decimal buyerhissay = this.txtKharidHisay.Text.ToString() != "" ? Convert.ToDecimal(this.txtKharidHisay.Text.ToString()) : 0;
                string buyerkanal = this.txtKharidKanal.Text.ToString() != "" ? this.txtKharidKanal.Text.ToString() : "0";
                string buyermarla = this.txtKharidMarla.Text.ToString() != "" ? this.txtKharidMarla.Text.ToString() : "0";
                decimal buyersarsai = txtKharidSarsai.Text.Trim() != "" ? Convert.ToDecimal(this.txtKharidSarsai.Text.ToString()) : 0;
                string khewattypeid = this.cboKhewatType.SelectedValue.ToString() != "" ? this.cboKhewatType.SelectedValue.ToString() : " 0";
                decimal buyerfeet = txtKharidFeet.Text.Trim() != "" ? Convert.ToDecimal(txtKharidFeet.Text.Trim()) : 0;
                string BuyerHisaBata = txtBuyerHIsaBata.Text.Trim() != "" ? txtBuyerHIsaBata.Text.Trim() : "0";
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
                //    string s = inteq.SaveintiqalBuyersSelf(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, BuyerHisaBata, cmbRishta.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString()).FirstOrDefault().ToString();
                //}

                //else
                //{
                    string s = inteq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, BuyerHisaBata, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString()).FirstOrDefault().ToString();
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
            //CalulateBuyerArea();
            CalulateBuyerHissa_FromArea();

        }

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

        private void btnFamilySelection_Click(object sender, EventArgs e)
        {
            try
            {
                //frmTestMalkanSelcIntiqalWirasath frmTMSIW = new frmTestMalkanSelcIntiqalWirasath();
                //frmTMSIW.khewatTypeId = cboKhewatType.SelectedValue.ToString();
                //frmTMSIW.IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                //frmTMSIW.MozaId = this.MozaId.ToString();
                //frmTMSIW.FormClosed -= new FormClosedEventHandler(frmTMSIW_closed);
                //frmTMSIW.FormClosed += new FormClosedEventHandler(frmTMSIW_closed);
                //frmTMSIW.KhatoniRecid = KhatoniRecid;
                //frmTMSIW.IntiqalKhataRecId = this.IntiqalKhataRecId;
                //frmTMSIW.ShowDialog();
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
        //void frmTMSIW_closed(object sender, FormClosedEventArgs e)
        //{
        //    FillgridByBuyerList();
        //}
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
                        FillgridByBuyerList();
                        this.ClearFormControls(groupBox8);
                        btnDelSeller.Enabled = false;
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
        }

        public void FillGridMalikan()
        {
            DataTable dt = new DataTable();
            if (cboMinGroups.SelectedIndex > 0)
            {
                dt = inteq.GetIntiqalMinFareeqain(IntiqalId, cboMinGroups.SelectedValue.ToString());
                gridmalikan.DataSource = dt;
                gridmalikan.Columns["CompleteName"].HeaderText = "نام مالک";
                gridmalikan.Columns["Intiqal_Min_Hissa"].HeaderText = "انتقال من حصہ";
                gridmalikan.Columns["IntiqalMinArea"].HeaderText = "انتقال من رقبہ";
                gridmalikan.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                gridmalikan.Columns["IntiqalMinKhewatFareeqId"].Visible = false;
                gridmalikan.Columns["SeqNo"].Visible = false;
                gridmalikan.Columns["IntiqalMinPersonId"].Visible = false;
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
                dtk = inteq.GetIntiqalMinKhassraJat(IntiqalId, cboMinGroups.SelectedValue.ToString());
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
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

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
                        string LastId = inteq.SaveIntiqalMinGroup(minGroupId, intiqalId, khataid, minGroupNo, khataNo, IntiqalMinOldKhatooniId, IntiqalMinKhatooniRecId, IntiqalMinKhatoniNo, khataTotalParts, raqbaKanal, raqbaMarla, raqbaSarsai, raqbaSft, usr, "Admin", usr, "Admin", "19001");
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
            foreach (DataRow dtrow in dtmg.Rows)
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
                    txtGroupMinId.Text = cboMinGroups.SelectedValue.ToString();
                }
                else
                {
                    txtGroupMinId.Text = "";
                }
                if (cboMinGroups.SelectedIndex > 0)
                {
                    txtGroupMinId.Text = cboMinGroups.SelectedValue.ToString();
                    MinGroupNo = cboMinGroups.Text;
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

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            try
            {
                if (isGardawar.ToString() == "0")
                {
                    MessageBox.Show("گرداور سے پڑتال کرائیں۔", "انتقال عمل درآمد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Teh_Report < 11)
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
                foreach (DataRow row in this.MinhayeIntiqals.Rows)
                {
                    if (Convert.ToBoolean(row["AmalDaramadStatus"].ToString()) == false)
                    {
                        MinhayeIntiqalAmaldaramadStatus = false;
                        MinIntiqalNo = row["IntiqalNo"].ToString();
                        break;
                    }

                }
                //bool MinhayeIntiqalAmaldaramadStatus = Convert.ToBoolean(Intiqal.GetIntiqalAmaldaramadStatusForMinhayeIntiqal(this.MinhayeIntiqalId));
                if (MinhayeIntiqalAmaldaramadStatus)
                {
                    if (MessageBox.Show(" عمل درآمد ک بعد آپ اس انتقال میں میں تبدیلی نہیں کر سکتے۔ پھر بھی عمل درآمد کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show("Yes");
                        this.btnAmaldaramad.Enabled = false;
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
                                Intiqal.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                                //client.IntiqalAmalDaramadCombined(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());
                                //if (s != null || s != "")
                                //{
                                MessageBox.Show("عمل درامد ہو گیا");
                                this.AmalDaramad = true;
                                this.SetAmalDaramadStatus(this.AmalDaramad);
                                //}
                                //this.LoadIntiqalDetails();
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
                    MessageBox.Show("  عملدرادمد نہیں ہو سکا۔ اس انتقال کے عملدرامد سے پہلے منہائے انتقال نمبر  " + MinIntiqalNo + " پر عملدرامد کریں۔", "عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                        Intiqal.IntiqalMinAmalDaramadKhanakasht(this.MozaId.ToString(), this.IntiqalId, this.IntiqalKhataId);
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

        private void btnDeleteKhatoni_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridSellerList1.RowCount == 0 && GridBuyersList.RowCount == 0)
                {
                    Intiqal.DeleteIntiqalKhanakashtKhatooni(txtIntiqalKhatooniRecId.Text);
                    this.txtIntiqalKhatooniRecId.Text = "-1";
                    txtparentKhatooniId.Text = "-1";
                    cmbKhatoniNo.SelectedIndex = 0;
                    GetKhatoni(txtKhattaRecId.Text);
                }
                else
                {
                    MessageBox.Show("اس کھتونی کے بائع/مشتری موجود ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chkNewKhataChange_CheckedChanged(object sender, EventArgs e)
        {

            if (chkNewKhataChange.Checked == true)
            {
                //this.txtNewKhatooniNo.Visible = true;
                //this.cmbMinKhatooniByParentKhatooni.Visible = false;
                this.ClearKhatooniMinControls();
                string moza = this.IntiqalId.Substring(0, 5);
                try
                {
                    dt = taqseemnewkhata.Proc_Get_Max_Khatooni_No_By_Moza(moza);
                    foreach (DataRow d in dt.Rows)
                    {
                        int NewkhatooniNo = Convert.ToInt32(d["NewKhatooniNo"].ToString());
                        NewkhatooniNo = NewkhatooniNo + 1;
                        string[] strArr = null;
                        strArr = this.NewKhatooniCreate.Split('/');
                        this.txtNewKhatooniNo.Text = NewkhatooniNo + "/" + strArr[0].ToString();
                        this.txtKhatooniNoChange.Text = this.txtNewKhatooniNo.Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                btnDeleteChange.Enabled = true;
                btnClearChange.Enabled = true;
                btnSaveChange.Enabled = true;
                this.ClearKhatooniMinControls();
                //this.txtNewKhatooniNo.Visible = true;
                // this.cmbMinKhatooniByParentKhatooni.Visible = false;

            }
        }
        private void ClearKhatooniMinControls()
        {
            this.txtKhatooniNoChange.Clear();
            this.txthissayChagne.Clear();
            this.txtKanalChange.Clear();
            this.txtMarlayChange.Clear();
            this.txtSarsasiChange.Clear();
            this.txtFeetChange.Clear();
            this.txtKhatooniID.Text = "-1";
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (this.txtparentKhatooniId.Text.Trim() != "-1")
            {
                string KhataId = IntiqalKhataId;
                string ParentKhatooniID = Khatoniid;// .Text.ToString();
                string Lagan = txtLagan.Text;
                string wasaielAbpashi = txtWasailAbpashiChange.Text;
                string NKhatooniNo = txtKhatooniNoChange.Text != "" ? txtKhatooniNoChange.Text : "0";
                string hissay = txthissayChagne.Text != "" ? txthissayChagne.Text.ToString() : "0";
                string kannal = txtKanalChange.Text != "" ? txtKanalChange.Text.ToString() : "0";
                string marala = txtMarlayChange.Text != "" ? txtMarlayChange.Text.ToString() : "0";
                string sarsai = txtSarsasiChange.Text != "" ? txtSarsasiChange.Text.ToString() : "0";
                string feet = txtFeetChange.Text != "" ? txtFeetChange.Text.ToString() : "0";
                string KhatooniId = taqseemnewkhata.SaveSubKhatooni(txtKhatooniID.Text, ParentKhatooniID, hissay, kannal, marala, sarsai, feet, this.IntiqalId, NKhatooniNo, " ", KhataId, wasaielAbpashi, Lagan, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                string minGroupId = inteq.SaveIntiqalMinGroup("-1", this.IntiqalId, IntiqalKhataId, "1", "0", ParentKhatooniID, KhatoniRecid, NKhatooniNo, hissay, kannal, marala, sarsai, feet, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName, MozaId.ToString());
                txtKhatooniID.Text = KhatooniId;
                if (KhatooniId != null)
                {
                    AutoFillCombo.FillCombo("Proc_Get_Khatoonis_ByParentKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentKhatooniID + "," + this.IntiqalId, cmbMinKhatooniByParentKhatooni, "KhatooniNo", "KhatooniId");
                    this.dtKhatooniesByParentKhatooni = Intiqal.GetKhatooniByParentKhatooniId(ParentKhatooniID, IntiqalId);
                    // cmbMinKhatooniByParentKhatooni.SelectedValue = KhatooniId;
                    this.ClearKhatooniMinControls();
                    this.txtNewKhatooniNo.Visible = false;
                    this.cmbMinKhatooniByParentKhatooni.Visible = true;
                    this.chkNewKhataChange.Checked = false;
                }
            }
            else
                MessageBox.Show("برائے مہربانی کھاتا ٹیب جا کر کھاتے کا انتخاب کریں-", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbMinKhatooniByParentKhatooni_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbMinKhatooniByParentKhatooni.SelectedValue.ToString() != "0")
                {
                    this.FillNewKhatooniControlsByKhatooniSelection();
                    this.GetMushteryanByKhatooni();
                    this.GetKhassrajatNew();
                }
                else
                {
                    this.grdMushtrianMalinkanChange.DataSource = null;
                    this.ClearKhatooniMinControls();
                    this.grdNewKhasrajat.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Get New Khatooni Data By Khatooni Id

        private void FillNewKhatooniControlsByKhatooniSelection()
        {
            if (dtKhatooniesByParentKhatooni.Rows.Count > 0)
            {
                foreach (DataRow row in dtKhatooniesByParentKhatooni.Rows)
                {
                    if (row["KhatooniId"].ToString() == cmbMinKhatooniByParentKhatooni.SelectedValue.ToString())
                    {
                        this.txtKhatooniNoChange.Text = row["KhatooniNo"].ToString();
                        this.txthissayChagne.Text = row["Khatooni_Hissa"].ToString();
                        this.txtKanalChange.Text = row["Khatooni_Kanal"].ToString();
                        this.txtMarlayChange.Text = row["Khatooni_Marla"].ToString();
                        this.txtSarsasiChange.Text = row["Khatooni_Sarsai"].ToString();
                        this.txtFeetChange.Text = row["Khatooni_Feet"].ToString();
                        this.txtKhatooniID.Text = row["KhatooniId"].ToString();
                        this.lblNewKhatooniNo.Text = row["KhatooniNo"].ToString();
                        this.lblNewKhatooniNoKhassra.Text = row["KhatooniNo"].ToString();
                        this.txtKhatooniID.Text = row["KhatooniId"].ToString();
                    }
                }
            }
        }

        #endregion

        #region Get Mushteryan By KhatooniId

        private void GetMushteryanByKhatooni()
        {
            try
            {

                DataTable dtMushteryan = new DataTable();
                //if (cmbMinKhatooniByParentKhatooni.SelectedValue.ToString())
                dtMushteryan = khatooni.Get_MushtriFareeqein_By_KhatooniId(txtKhatooniID.Text);
                grdMushtrianMalinkanChange.DataSource = dtMushteryan;
                grdMushtrianMalinkanChange.Columns["CompleteName"].HeaderText = "نام مالک";
                grdMushtrianMalinkanChange.Columns["SeqNo"].HeaderText = "نمبر شمار";
                grdMushtrianMalinkanChange.Columns["KhewatType"].HeaderText = "قسم مالک";
                grdMushtrianMalinkanChange.Columns["FardAreaPart"].HeaderText = "حصہ";
                grdMushtrianMalinkanChange.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                grdMushtrianMalinkanChange.Columns["MushtriFareeqId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardPart_Bata"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhatooniId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["IntiqalId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["TransactionType"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["MurthinId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhewatTypeId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["Farad_Kanal"].Visible = false;
                grdMushtrianMalinkanChange.Columns["Fard_Marla"].Visible = false;
                grdMushtrianMalinkanChange.Columns["Fard_Sarsai"].Visible = false;
                grdMushtrianMalinkanChange.Columns["Fard_Feet"].Visible = false;
                grdMushtrianMalinkanChange.Columns["Mushtri_Area_KMSr"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        private void btnAmalDaramadTaqseemWaIshterak_Click(object sender, EventArgs e)
        {

        }

        #region Delete new Khatooni

        private void btnDeleteChange_Click(object sender, EventArgs e)
        {
            try
            {

                taqseemnewkhata.DeleteKhatooniRegister(txtKhatooniID.Text);
                inteq.DeleteIntiqalMinGroupByKhatooni(KhatoniRecid);
                ClearKhatooniMinControls();
                AutoFillCombo.FillCombo("Proc_Get_Khatoonis_ByParentKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + txtparentKhatooniId.Text + "," + this.IntiqalId, cmbMinKhatooniByParentKhatooni, "KhatooniNo", "KhatooniId");
                this.dtKhatooniesByParentKhatooni = Intiqal.GetKhatooniByParentKhatooniId(txtparentKhatooniId.Text, IntiqalId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Select and Save Khatooni Mushteryan for New Khatooni

        private void btnGetChangeMalikan_Click(object sender, EventArgs e)
        {
            try
            {
                frmMushteryanTaqseem fmt = new frmMushteryanTaqseem();
                fmt.KhataId = this.txtKhataID.Text;
                fmt.KhatooniId = this.txtKhatooniID.Text;
                fmt.KhatooniRecId = this.txtIntiqalKhatooniRecId.Text;
                fmt.IntiqalId = this.IntiqalId;
                fmt.ParentKhatooniId = this.txtparentKhatooniId.Text;
                fmt.FormClosed -= new FormClosedEventHandler(fmt_FormClosed);
                fmt.FormClosed += new FormClosedEventHandler(fmt_FormClosed);
                fmt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void fmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.GetMushteryanByKhatooni();
        }

        #endregion

        #region Gridview Mushteryan Cell Click Event

        private void grdMushtrianMalinkanChange_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == g.CurrentRow.Cells["ColSel"].ColumnIndex)
                    {
                        g.CurrentRow.Cells["ColSel"].Value = 1;
                        txtMushteryName.Text = g.CurrentRow.Cells["CompleteName"].Value.ToString();
                        txtMushteryOldhissa.Text = g.CurrentRow.Cells["FardAreaPart"].Value.ToString();
                        //txtMushhteryHissaMuntaqla.Text = g.CurrentRow.Cells[""].Value.ToString();
                        txtMushteryKanal.Text = g.CurrentRow.Cells["Farad_Kanal"].Value.ToString();
                        txtMushteryMarla.Text = g.CurrentRow.Cells["Fard_Marla"].Value.ToString();
                        txtMushterySarsai.Text = g.CurrentRow.Cells["Fard_Sarsai"].Value.ToString();
                        txtMushteryFeet.Text = g.CurrentRow.Cells["Fard_Feet"].Value.ToString();
                        txtMushteryFareeqId.Text = g.CurrentRow.Cells["MushtriFareeqId"].Value.ToString();
                        txtMushteryPersonId.Text = g.CurrentRow.Cells["PersonId"].Value.ToString();
                        txtMushteryKhewatTypeId.Text = g.CurrentRow.Cells["KhewatTypeId"].Value.ToString();
                        txtSeqNo.Text = g.CurrentRow.Cells["SeqNo"].Value.ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Save MushteryFareeq After Changing Hissa Raqba

        private void btnSaveChangeMalikan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMushteryFareeqId.Text != "-1" && cmbMinKhatooniByParentKhatooni.SelectedValue.ToString() != "0")
                {
                    khatooni.SaveMushtriFareeqein(txtMushteryFareeqId.Text, "0", "Intiqal", "0", txtKhatooniID.Text, txtSeqNo.Text, txtMushteryPersonId.Text, "0", txtMushteryKhewatTypeId.Text, txtMushhteryHissaMuntaqla.Text, "0", txtMushteryKanal.Text, txtMushteryMarla.Text, txtMushterySarsai.Text, txtMushteryFeet.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    this.ClearMushteryFareeqControls();
                    this.GetMushteryanByKhatooni();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearMushteryFareeqControls()
        {
            txtMushteryFeet.Clear();
            txtMushteryKanal.Clear();
            txtMushteryKhewatTypeId.Clear();
            txtMushteryMarla.Clear();
            txtMushteryName.Clear();
            txtMushteryOldhissa.Clear();
            txtMushteryPersonId.Text = "-1";
            txtMushterySarsai.Clear();
            txtSeqNo.Text = "0";
            txtMushhteryHissaMuntaqla.Clear();
            txtMushteryFareeqId.Text = "-1";
        }

        #endregion

        #region Key Press Event for Numerical Values only

        private void txtMushhteryHissaMuntaqla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion

        #region Calculate Hissa / Raqba Taqseem Khatooni

        public void CalulateArea_Taqseem_isshtiraq()
        {
            try
            {


                float khissay = this.txtMushteryOldhissa.Text.Trim() != "" ? float.Parse(txtMushteryOldhissa.Text.Trim()) : 0;
                float KhatoonikulHissay = txthissayChagne.Text.Trim() != "" ? float.Parse(txthissayChagne.Text.Trim()) : 0;
                float shissay = txtMushhteryHissaMuntaqla.Text.Trim() != "" ? float.Parse(txtMushhteryHissaMuntaqla.Text.Trim()) : 0;
                int kkanal = this.txtKanalChange.Text.Trim() != "" ? Convert.ToInt32(txtKanalChange.Text.Trim()) : 0;
                int kmarla = this.txtMarlayChange.Text.Trim() != "" ? Convert.ToInt32(txtMarlayChange.Text.Trim()) : 0;
                float ksarsai = this.txtSarsasiChange.Text.Trim() != "" ? float.Parse(txtSarsasiChange.Text.Trim()) : 0;
                float ksft = this.txtFeetChange.Text.Trim() != "" ? float.Parse(txtFeetChange.Text.Trim()) : 0;
                //
                int mkanal = this.txtMushteryKanal.Text.Trim() != "" ? Convert.ToInt32(txtMushteryKanal.Text.Trim()) : 0;
                int mmarla = this.txtMushteryMarla.Text.Trim() != "" ? Convert.ToInt32(txtMushteryMarla.Text.Trim()) : 0;
                float msarsai = this.txtMushterySarsai.Text.Trim() != "" ? float.Parse(txtMushterySarsai.Text.Trim()) : 0;
                float msft = this.txtMushteryFeet.Text.Trim() != "" ? float.Parse(txtMushteryFeet.Text.Trim()) : 0;


                if (shissay > 0)
                {
                    string[] raqba = CommanFunctions.CalculatedAreaFromHisa(KhatoonikulHissay, shissay, kkanal, kmarla, ksarsai, ksft);
                    txtMushteryKanal.Text = raqba[0];
                    this.txtMushteryMarla.Text = raqba[1];
                    this.txtMushterySarsai.Text = raqba[2];
                    this.txtMushteryFeet.Text = raqba[3];


                }
                else
                {

                    txtMushhteryHissaMuntaqla.Text = CommanFunctions.CalculatedHisaFromArea(KhatoonikulHissay, shissay, kkanal, kmarla, ksarsai, ksft, mkanal, mmarla, msarsai, msft).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Hissa / Rqab Calculate Button Click

        private void btnishtarakhisabamutabiq_Click(object sender, EventArgs e)
        {
            this.CalulateArea_Taqseem_isshtiraq();
        }

        #endregion

        #region Save Khassrajat for new Khatooni

        private void btnselectchangekhasra_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewKhasrajat nkt = new frmNewKhasrajat();
                nkt.IntiqalId = this.IntiqalId;
                nkt.khatoniid = txtKhatooniID.Text;
                nkt.FormClosed -= new FormClosedEventHandler(nkt_FormClosed);
                nkt.FormClosed += new FormClosedEventHandler(nkt_FormClosed);
                nkt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void nkt_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetKhassrajatNew();
            ClearKhassraNewControls();
        }

        #endregion

        #region Get Khassrajat By KhatooniId New

        private void GetKhassrajatNew()
        {
            try
            {

            DataTable dtKhassras = khatooni.GetKhassrajatByKhatooniId(this.txtKhatooniID.Text);
            grdNewKhasrajat.DataSource = dtKhassras;
            grdNewKhasrajat.Columns["KhassraDetailId"].Visible = false;
            grdNewKhasrajat.Columns["AreaTypeId"].Visible = false;
            grdNewKhasrajat.Columns["KhatooniId"].Visible = false;
            grdNewKhasrajat.Columns["KhassraId"].Visible = false;
            grdNewKhasrajat.Columns["AreaType"].HeaderText = "قسم زمین";
            grdNewKhasrajat.Columns["Kanal"].HeaderText = "کنال";
            grdNewKhasrajat.Columns["Marla"].HeaderText = "مرلہ";
            grdNewKhasrajat.Columns["Sarsai"].HeaderText = "سرسائی";
            grdNewKhasrajat.Columns["Feet"].HeaderText = "فٹ";
            grdNewKhasrajat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Khassra Update / Delete  Events and Grid cell click event
  
        private void grdNewKhasrajat_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    string AreaTypeId = this.txtkhasratypeid.Text;
                    string last = "", last1 = "";
                    //string str = IntiqalId;
                    //string mozaid = str.Substring(0,5);
                    if (OldKhassraNo.Text != txthiddenKhasarno.Text)
                    {
                        last = taqseemnewkhata.WEB_SP_INSERT_KhassraRegistert(khasraid, MozaId.ToString(), "0", khassrno, "", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                    }
                    last1 = taqseemnewkhata.WEB_SP_INSERT_KhassraRegisterDetail(khasradetailid, khasraid, AreaTypeId, kanal, marla, sarsar, feet, UsersManagments.UserId.ToString());

                    GetKhassrajatNew();
                    ClearKhassraNewControls();
                    //getkhasrajattotalarea();
                    //getkhasrajatbykhatoni();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txthiddendetailid.Text != null)
                {
                    taqseemnewkhata.WEB_SP_DELETE_KhassraRegisterDetail_Direct(this.txthiddendetailid.Text);
                }
                MessageBox.Show("خسرہ نمبر حذف ہوگیا ہے", "", MessageBoxButtons.OK);
                GetKhassrajatNew();
                ClearKhassraNewControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearKhassraNewControls()
        {
            this.txthiddendetailid.Text="-1";
            this.OldKhassraNo.Text = "";
            this.txt_kanal_Khasra.Text="";
             this.txt_Marala_Khasra.Text="";
            this.txt_Feet_Khasra.Text="";
           this.txt_Sarsai_Khasra.Text="";
            this.txtkhasratypeid.Text="-1";
        }

        #endregion

        #region Delete Mushtery from saved Mushteryan
  
        private void btndeleteChangeMalikan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMushteryFareeqId.Text != "" && txtMushteryFareeqId.Text != "-1")
                {
                    khatooni.DELETE_MushtriFareeqein(txtMushteryFareeqId.Text);
                    GetMushteryanByKhatooni();
                }
                else
                    MessageBox.Show("خزف کرنے کیلیے نیچے گریڈ سے مالک کا انتخاب کریں۔");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        #endregion

        #region Juzvi Khatooni Check Change event

        private void cbJuzviKhata_CheckedChanged(object sender, EventArgs e)
        {

            if (cbJuzviKhata.Checked)
            {
                if (!IsJuzviKhatooni)
                {
                    if (this.GridViewInteqalKhattas.SelectedRows.Count > 0)
                    {
                        if (MessageBox.Show("کیا اپ انتقال کے اس کھتونی میں سالم/جزوی خسرے کا اندراج چاہتے ہے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool isJuzvi = inteq.UpdateIntiqalKhatooniJuzviStatus("1", this.KhatoniRecid);
                            if (isJuzvi)
                            {
                                gbJuzviSalamKhassraEntry.Visible = true;
                                string khatooniId = grdKhatoniDetails.SelectedRows[0].Cells["KhatooniId"].Value.ToString();
                                
                            }
                        }
                    }
                }
                else
                {
                    gbJuzviSalamKhassraEntry.Visible = true;
                    string khatooniId = grdKhatoniDetails.SelectedRows[0].Cells["KhatooniId"].Value.ToString();
                    
                }

            }
            else if (!cbJuzviKhata.Checked)
            {
                if (IsJuzviKhatooni)
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

        #region Salam/Juzvi Khassra Khatooni selection

        private void FillGridviewKhassraByKhatoonies(string IntiqalkhatooniId)
        {
            try
            {
                //AutoFillCombo.FillCombo("Proc_Get_Khatooni_KhassraArea_Detail " + cmbKhatooniListforKhassras.SelectedValue.ToString(), cmbKhassraList, "KhassraNo", "KhassraDetailId");
                gridviewSalamjuzviKhassraList.DataSource = Intiqal.GetKhassrasByKhatoni(IntiqalkhatooniId);
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

        private void gridviewSalamjuzviKhassraList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
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
                this.txtMinKhassraNewKhassraNo.Enabled = true;
                this.txtMinKhassraKanal.Enabled = true;
                txtMinKhassraMarla.Enabled = true;
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

        private void btnNewJuzviSalamKhassra_Click(object sender, EventArgs e)
        {
            this.ClearSalamJuzviKhassraControls();
        }

        private void ClearSalamJuzviKhassraControls()
        {
            cmbJuzviSalamList.SelectedIndex = 0;
            this.txtMinKhassraNewKhassraNo.Clear();
            this.txtMinKhassraKanal.Text = "";
            txtMinKhassraMarla.Text = "";
            txtMinKhassraSarsai.Text = "";
            txtMinKhassraSft.Text = "";
            txtsalamjuzviKhassraId.Text = "-1";
            txtsalamjuzviKhatooniId.Text = "-1";
            txtsalamjuzviKhassraDetailId.Text = "-1";
            txtsalamjuzviAreaTypeId.Text = "-1";
            txtsalamjuzviKhassraRecId.Text = "-1";
            this.EnableDisableSalamJuzviKhassraControls(false);
        }

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
                    string SalamJuzvi = cmbJuzviSalamList.SelectedIndex == 0 ? "سالم" : "جزوی";
                    string lastId = Intiqal.SaveSalamJuzviKhassraDetail(txtsalamjuzviKhassraRecId.Text, txtsalamjuzviKhassraId.Text, txtsalamjuzviKhassraDetailId.Text, txtMinKhassraNewKhassraNo.Text.Trim(), SalamJuzvi, txtsalamjuzviKhatooniId.Text, this.IntiqalKhataRecId, KhatoniRecid ,kanal, marla, sarsai, feet, txtsalamjuzviAreaTypeId.Text, this.MozaId.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
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

        #region Get Saved Intiqal salam Juzvi Khassra List

        private void FillGridviewSalamJuzviKhassra()
        {
            GridviewSaveSalamJuzviKhassra.DataSource = Intiqal.GetIntiqalSalamJuzviKhassraByKhatooni(this.KhatoniRecid);
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

        #region Adding Row Number to Gridview Buyers

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        #endregion

        #region Post Row Event
        private void dgGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        #endregion

        private void btnWarisanManderjaKhatooni_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAttested  && !this.AmalDaramad)
                {
                    if (grdKhatoniDetails.Rows.Count > 1)
                    {
                        if (grdKhatoniDetails.SelectedRows[0].Index > 0)
                        {
                            if (GridSellerList1.Rows.Count > 0)
                            {
                                string intiqalKhataRecId = IntiqalKhataRecId;
                                string intiqalKhatooniRecId = grdKhatoniDetails.SelectedRows[0].Cells[1].Value.ToString();

                                string s = Intiqal.IntiqalWarasathManderjaKhatooniWarisan(intiqalKhatooniRecId, intiqalKhataRecId, this.IntiqalId.ToString());
                                DataGridViewCellEventArgs ea = new DataGridViewCellEventArgs(0, 0);
                                this.grdKhatoniDetails_CellClick((object)grdKhatoniDetails, ea);

                            }
                            else
                            {
                                MessageBox.Show(" پہلے متوفی/ متوفیہ کا ریکارڈ محفوظ کریں", "مندرجہ کھتونی وارثان");
                            }
                        }
                        else
                        {
                            MessageBox.Show("یہ سہولت کھاتے کے پہلے کھتونی کے لیے کارامد  نہیں ہے", "مندرجہ کھتونی وارثان");
                        }

                    }
                    else
                    {
                        MessageBox.Show("یہ سہولت صرف ایک سے زیادہ کھتونی کے لیے کارامد ہے", "مندرجہ کھتونی وارثان");
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

        #region Auto Urdu Conversion

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

        private void fillRegistryIntiqalkhatajatList(string fardTokenId)
        {
            try
            {
                this.dtkj = inteq.GetKhataJatofKhatooniesForRegistryintiqalByFardTokenId(FardTokenId);
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

        private void GridBuyersList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.btnNewBuyer.Enabled = true;
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

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtKhattaRecId.Text = "-1";
            Fill_InteqalKhataGrid();
        }

        private void cmbKhatoniNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtIntiqalKhatooniRecId.Text = "-1";
            txtparentKhatooniId.Text = "-1";
            GetKhatoni(txtKhattaRecId.Text);
            
        }

        private void txtSearchBuyers_TextChanged(object sender, EventArgs e)
        {
            bb.Filter = string.Format("PersonName LIKE '%{0}%' ", txtSearchBuyers.Text);
        }

        private void txtSearchBuyers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

      
      
    }

}

















