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
    public partial class frmIntiqalKhattaJatKhtooniMalkiat : Form
    {
        public string IntiqalId { get; set; }
        public bool IsKhattaMalkan { get; set; }
        public bool isAttested { get; set; }
        public int Teh_Report;
        public string isGardawar { get; set; }
        public bool isConfirmed { get; set; }
        public string MinhayeIntiqalId { get; set; }
        public string IntiqalTypeId { get; set; }
        public string BS_AreaHissa { get; set; }
        //public string lastId { get; set; }
        Malikan_n_Khattajat mnk=new Malikan_n_Khattajat();
        Intiqal inteq = new Intiqal();
        DataTable dtkj = new DataTable();
        DataTable saveKhata = new DataTable();
        DataTable dtmg = new DataTable();
        DataTable dtMinGrpDet = new DataTable();
        BindingSource bs = new BindingSource();
        DataTable MinhayeIntiqals = new DataTable();
        DataTable dtKhatooniesByParentKhatooni = new DataTable();
        BL.TaqseemNewKhataJatMin taqseemnewkhata = new BL.TaqseemNewKhataJatMin();
        Khatoonies khatooni = new Khatoonies();


        //string KhewatGroupFareeqId;

        #region Varibles frmSellers

        public string NewKhataCreate
        {
            get;
            set;
        }

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
        public string intiqalIId { get; set; }
        public string IntiqalKhatooniRecId { get; set; }
        public string IntiqalMinKhatoniNo { get; set; }
        public string IntiqalMinOldKhatooniId { get; set; }
        public string IntiqalMinKhatooniRecId { get; set; }
        public bool AmalDaramad { get; set; }
        public string KhewatGroupFareeqId { get; set; }
        public string RegisterHqDKhataId { get; set; }
        public string RegisterHqId { get; set; }
        public string ParentKhataID { get; set; }
        public string Taraf { get; set; }
        public string Pati { get; set; }
        /// <summary>
        /// get or set entry mode
        /// </summary>
        public int EntryMode { get; set; }
        /// <summary>
        /// get or set Moza id
        /// </summary>
        public int MozaId { get; set; }

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

        public frmIntiqalKhattaJatKhtooniMalkiat()
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
                inteqKj["KhataNo"] = " - انتخاب کریں - ";
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
                //gbAmalDaramad.Visible = true;
                if (Status)
                {
                    lblMutStatus.Text = "عمل درامد شدہ";
                    lblMutStatus.ForeColor = Color.Green;
                    
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainControls.Enabled = false;

                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.button12.Enabled = false;
                    this.button13.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnDeleteKhassraNew.Enabled = false;
                    this.button17.Enabled = false;

                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.button8.Enabled = false;




                }
                else if (isAttested)
                {
                    
                    
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                        
                       
                        btnAmaldaramad.Enabled = true;
                        
                        this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainControls.Enabled = false;

                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.button12.Enabled = false;
                    this.button13.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnDeleteKhassraNew.Enabled = false;
                    this.button17.Enabled = false;

                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.button8.Enabled = false;

                    }

                else if (isConfirmed)
                {
                    lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                    btnAmaldaramad.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainControls.Enabled = false;

                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.button12.Enabled = false;
                    this.button13.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnDeleteKhassraNew.Enabled = false;
                    this.button17.Enabled = false;

                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.button8.Enabled = false;
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
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainControls.Enabled = false;

                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.button12.Enabled = false;
                    this.button13.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnDeleteKhassraNew.Enabled = false;
                    this.button17.Enabled = false;

                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.button8.Enabled = false;

                    this.groupBox17.Enabled = false;
                    this.groupBox18.Enabled = false;
                   
                }
                else if (isAttested)
                {
                    
                    
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;

                       
                            btnAmaldaramad.Enabled = true;
                        
                        this.gbKhataMainContols.Enabled = false;
                        this.gbKhatooniMainControls.Enabled = false;

                        this.gbSellersControls.Enabled = false;
                        this.gbBuyersControls.Enabled = false;
                        this.gbSubKhataControls.Enabled = false;
                        this.button12.Enabled = false;
                        this.button13.Enabled = false;
                        this.btnSaveKhatonichagne.Enabled = false;
                        this.btnDeleteKhatoonichange.Enabled = false;
                        this.btnDeleteKhassraNew.Enabled = false;
                        this.button17.Enabled = false;

                        this.gbSubKhatooniMain.Enabled = false;
                        this.btnSaveChangeMalikan.Enabled = false;
                        this.btndeleteChangeMalikan.Enabled = false;
                        this.btnsavenewkhasra.Enabled = false;
                        this.button8.Enabled = false;

                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                       
                    }

                else if (isConfirmed)
                {
                    lblMutStatus.Text = " عمل درامد زیر غور";
                    lblMutStatus.ForeColor = Color.Red;
                    btnAmaldaramad.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.gbKhatooniMainControls.Enabled = false;

                    this.gbSellersControls.Enabled = false;
                    this.gbBuyersControls.Enabled = false;
                    this.gbSubKhataControls.Enabled = false;
                    this.button12.Enabled = false;
                    this.button13.Enabled = false;
                    this.btnSaveKhatonichagne.Enabled = false;
                    this.btnDeleteKhatoonichange.Enabled = false;
                    this.btnDeleteKhassraNew.Enabled = false;
                    this.button17.Enabled = false;

                    this.gbSubKhatooniMain.Enabled = false;
                    this.btnSaveChangeMalikan.Enabled = false;
                    this.btndeleteChangeMalikan.Enabled = false;
                    this.btnsavenewkhasra.Enabled = false;
                    this.button8.Enabled = false;

                    this.groupBox17.Enabled = true;
                    this.groupBox18.Enabled = true;
                }
                    else
                    {
                        lblAmalDaramdTaqseem.Text = "  عمل درامد زیر غور";
                        lblAmalDaramdTaqseem.ForeColor = Color.Red;
                        btnAmalDaramadTaqseem.Enabled = false;
                        btnAmaldaramad.Enabled = false;
                       
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
                txtParentid.Text = IntiqalId.ToString();///get for newtaqseem tab
                if (this.FardTokenId != null)
                {
                    //fillRegistryIntiqalkhatajatList(this.FardTokenId.ToString());

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
                //    gbKhatooniMainControls.Enabled = false;
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
                cboMinGroups.Text = MinGroupNo; // MinGroupNo assigned in void minGroupId(){MinGroupNo = cboMinGroups.Text;}
            }

            if (MalkiatKashkat)
            {
                Khatoniid = "NULL";
                KhatoniRecid = "NUll";
                groupBox13.Visible = true;
            }
            else
            {
                //groupBox16.Visible = false;
                //groupBox22.Visible = false;
                // chkMushtharaqa.Visible = false;
            }
        }

        private void fillRegistryIntiqalkhatajatList(string fardTokenId)
        {
            try
            {
                this.dtkj = inteq.GetKhataJatKhatooniesForRegistryintiqalByFardTokenId(FardTokenId);
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
                    inteq.DeleteIntiqalKhattajat(Convert.ToInt32(this.txtKhattaRecId.Text));
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
                GridSellerList1.DataSource = null;
                GridBuyersList.DataSource = null;
                DataGridView g = sender as DataGridView;
                this.KhatoniRecid = "-1";
                this.IntiqalKhatooniRecId = "-1";
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
                            //string KhataId = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataId"].Value.ToString();
                            if (IntiqalKhataId != string.Empty)
                            {

                                if (this.FardTokenId != null)
                                    AutoFillCombo.FillCombo("proc_Self_Get_Khatoonies_of_Khata_for_RegistryIntiqal_By_FardTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'" + "," + FardTokenId, cmbKhatoniNo, "KhatooniNo", "KhatooniId");
                                else
                                    AutoFillCombo.FillCombo("dbo.Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'", cmbKhatoniNo, "KhatooniNo", "KhatooniId");
                               
                                
                                GetKhatoni(txtKhattaRecId.Text);
                                if (this.FardTokenId != null)
                                    AutoFillCombo.FillCombo("proc_Self_Get_RegistryIntiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'" + "," + FardTokenId, cboPersonSeller, "personname", "KhewatGroupFareeqId");
                                else
                                    AutoFillCombo.FillCombo("proc_Get_Intiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "'", cboPersonSeller, "personname", "KhewatGroupFareeqId");
                               
                                proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, "-1");
                                FillgridByBuyerList(IntiqalKhataRecId, "-1");


                            }

                            IsKhattaMalkan = true;
                            Fill_ComboKhewatTypes();
                            gridselection();
                            this.ClearFormControls(gbBuyersControls);
                            CalculateSellerBuyerRaqbaHissa();
                            txthiddenBuyerRecId.Text = "-1";
                            this.tabControl3.Enabled = true;
                            this.tabControl2.Enabled = false;
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
                    this.GridBuyersList.DataSource = null;
                    this.GridSellerList1.DataSource = null;
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
                                    string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                                    string IntiqalKhatooniRecId = txtIntiqalKhatooniRecId.Text.ToString();
                                    FillgridByBuyerList("-1", IntiqalKhatooniRecId);
                                   // if (Convert.ToDouble(IntiqalKhataRecId) > 0)
                                        this.IsKhattaMalkan = false;
                                    //else
                                    //    this.IsKhattaMalkan = true;
                                    proc_Get_Intiqal_Sellers_List_ByKhata("-1", IntiqalKhatooniRecId);
                                    // this.GetMinKhatooniesByKhatooniId(Khatoniid);

                                    // Get Khatooni Taqseem Data
                                    this.GetMinKhatooniesByKhatooniId(Khatoniid);
                                    this.dtKhatooniesByParentKhatooni = Intiqal.GetKhatooniByParentKhatooniId(Khatoniid, IntiqalId);
                                    this.tabControl3.Enabled = false; // disable new khata taqseem when khatooni added for operations
                                    this.tabControl2.Enabled = true; // enable new khatooni taqseem when khatooni added for operations
                                    this.CalculateSellerBuyerRaqbaHissa();

                                }
                                else
                                {
                                    row.Cells["chkkhatoni"].Value = false;
                                    this.tabControl3.Enabled = true;
                                    this.tabControl2.Enabled = false;
                                    //grfIntiqalPersonSanps.Rows.Clear();
                                }
                            }
                        }
                    }
                    this.IsKhattaMalkan = false;
                    if (this.FardTokenId != null)
                        AutoFillCombo.FillCombo("proc_Self_Get_RegistryIntiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Khatoniid + "'" + "," + FardTokenId, cboPersonSeller, "personname", "MushtriFareeqId");
                    else
                        AutoFillCombo.FillCombo("proc_Get_Intiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Khatoniid + "'", cboPersonSeller, "personname", "MushtriFareeqId");
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GetMinKhatooniesByKhatooniId(string ParentKhatooniId)
        {
            AutoFillCombo.FillCombo("Proc_Get_Khatoonis_ByParentKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentKhatooniId + "," + this.IntiqalId, cmbMinKhatooniByParentKhatooni, "KhatooniNo", "KhatooniId");
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
                dtt = inteq.GetintiqalSellersListByKhataRecId(IntiqalKhattaRecId, IntiqalKhatooniRecId, IsKhattaMalkan.ToString());
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

                    if (this.FardTokenId != null)
                    {
                        if (shissay > fhissay)
                        {
                            MessageBox.Show("مالک اس فرد کے بقایا حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            //string[] raqba = CommanFunctions.CalculatedAreaFromHisa(fhissay, shissay, fkanal, fmarla, fsarsai, fsft);
                            string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                            txtFrokhtKanal.Text = raqba[0];
                            txtFrokhtMarla.Text = raqba[1];
                            txtFrokhtSarsai.Text = raqba[2];
                            txtFrokhtFeet.Text = raqba[3];
                        }
                    }
                    else
                    {
                        if (shissay > khissay)
                        {
                            MessageBox.Show("مالک کل حصے سے زیادہ حصے فروخت نہیں کر سکتے ", "فروخت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtFrokhtHisay.Clear();
                            txtFrokhtHisay.Focus();
                        }
                        else
                        {
                            string[] raqba = CommanFunctions.CalculatedAreaFromHisa(khissay, shissay, kkanal, kmarla, ksarsai, ksft);
                            txtFrokhtKanal.Text = raqba[0];
                            txtFrokhtMarla.Text = raqba[1];
                            txtFrokhtSarsai.Text = raqba[2];
                            txtFrokhtFeet.Text = raqba[3];
                        }
                    }
                }
                else
                {
                    if (this.FardTokenId != null)
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
                        txtFrokhtHisay.Text = CommanFunctions.CalculatedHisaFromArea(khissay, shissay, kkanal, kmarla, ksarsai, ksft, bkanal, bmarla, bsarsai, bsft).ToString();
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

        #region ClearForm
        private void btnNewSeller_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
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

            this.txtFardHissay.Text = "";
            this.txtFardFeet.Text = "";
            this.txtFardKanal.Text = "";
            this.txtFardSarsai.Text = "";
            this.txtFardMarla.Text = "";

            this.txtMushterkaKanal.Text = "";
            this.txtMushterkaSarsai.Text = "";
            this.txtMushterkamarla.Text = "";

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
                        //string IntiqalKhatooniRecId;
                        if (dt != null)
                        {
                            txtSellerID.Text = "-1";
                            proc_Get_Intiqal_Sellers_List_ByKhata(IsKhattaMalkan ? IntiqalKhataRecId : "-1", IsKhattaMalkan ? "-1" : KhatoniRecid);
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

                               

                                this.txtFrokhtHisay.Text = row.Cells["Seller_Sold_Hissa"].Value.ToString();
                                this.txtFrokhtKanal.Text = row.Cells["Seller_Sold_Kanal"].Value.ToString();
                                this.txtFrokhtMarla.Text = row.Cells["Seller_Sold_Marla"].Value.ToString();
                                this.txtFrokhtSarsai.Text = row.Cells["Seller_Sold_Sarsai"].Value.ToString();
                                this.txtFrokhtFeet.Text = row.Cells["Seller_Sold_Feet"].Value.ToString();
                                this.txtHiddenKewatGroupFareeqID.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                this.txtHidenMustariFareeqID.Text = row.Cells["MushtriFareeqId"].Value.ToString();
                                //}
                                txtHiddenPersonID.Text = row.Cells["IntiqalSellerPersonId"].Value.ToString();

                                //===================  for Malkiat ================================================

                                if (row.Cells["MushtriFareeqId"].Value.ToString() == null || row.Cells["MushtriFareeqId"].Value.ToString() == "0")
                                {
                                    this.cboPersonSeller.SelectedValue = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                    //------------------------ for remaining area in case of updatation

                                    DataTable dtFareeqain = new DataTable();
                                    DataTable dtFard = new DataTable();
                                    if (this.FardTokenId != null)
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
                                            KulSarsai = KulFeet / 30.25;
                                        }


                                        //================================================================================================


                                        txtKulHisay.Text = KulHissay.ToString();
                                        txtKullKanal.Text = Math.Round(KulKanal, 0).ToString();
                                        txtKullMarla.Text = Math.Round(KulMarla, 0).ToString();
                                        txtKullSarsai.Text = Math.Round(KulSarsai, 4).ToString();
                                        txtKulFeet.Text = Math.Round(KulFeet, 0).ToString();

                                        //_________________________________Self__________________________
                                        if (this.FardTokenId != null)
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
                                                FardSarsai = FardFeet / 30.25;
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

                             
                                }


                                //=================== end for Malkiat ================================================

                                //===================  for KK ================================================


                                if (row.Cells["KhewatGroupFareeqId"].Value.ToString() == ""  ||row.Cells["KhewatGroupFareeqId"].Value.ToString() == null || row.Cells["KhewatGroupFareeqId"].Value.ToString()=="0")
                                {
                                    this.cboPersonSeller.SelectedValue = row.Cells["MushtriFareeqId"].Value.ToString();
                                    //------------------------ for remaining area in case of updatation

                                    DataTable dtMushteryan = new DataTable();
                                    DataTable dtFard = new DataTable();

                                    if (this.FardTokenId != null)
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
                                            KulSarsai = Math.Round(KulFeet / 30.25,4);
                                        }
                                        else
                                        {
                                            KulSarsai = 0;
                                        }


                                        //================================================================================================


                                        txtKulHisay.Text = KulHissay.ToString();
                                        txtKullKanal.Text = Math.Round(KulKanal, 0).ToString();
                                        txtKullMarla.Text = Math.Round(KulMarla, 0).ToString();
                                        txtKullSarsai.Text = Math.Round(KulSarsai, 4).ToString();
                                        txtKulFeet.Text = Math.Round(KulFeet, 0).ToString();

                                        //_________________________________Self__________________________
                                        if (this.FardTokenId !=null)
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
                                                FardSarsai = Math.Round(FardFeet / 30.25, 4);
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
                                }


                                //===================  for KK ================================================

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
                    if (this.KhatoniRecid!="0" && KhatoniRecid!="" && KhatoniRecid!="NULL")
                    {
                        dt = Intiqal.GetIntiqalKhanaKasht(Khatoniid);
                        
                    }
                    else
                    {
                        dt = Intiqal.GetIntiqalKhataMalikanByKhataId(IntiqalKhataId); 
                    }

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
                            string KhewatGroupFareeqId = (this.KhatoniRecid!="0" && KhatoniRecid!="" && KhatoniRecid!="NULL")?"NULL":row["KhewatGroupFareeqId"].ToString();
                            string Seller_Sold_Hissa = "0";
                            string Seller_Sold_Kanal = "0";
                            string Seller_Sold_Marla = "0";
                            string Seller_Sold_Sarsai = "0";
                            string Seller_Sold_Feet = "0";
                            string MushtriFareeqId =this.KhatoniRecid!="0" && KhatoniRecid!="" && KhatoniRecid!="NULL"?row["MushtriFareeqId"].ToString():"NULL";
                            if (GridSellerList1.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow rowss in GridSellerList1.Rows)
                                {
                                    if (Convert.ToDouble(this.KhatoniRecid) > 0)
                                    {
                                        if (MushtriFareeqId == rowss.Cells["MushtriFareeqId"].Value.ToString())
                                        {
                                            Exists = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (KhewatGroupFareeqId == rowss.Cells["KhewatGroupFareeqId"].Value.ToString())
                                        {
                                            Exists = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!Exists)
                            {
                                string lastid = Intiqal.SaveintiqalSellers(IntiqalSellerRecId,
                                IntiqalKhataRecId, IntiqalSellerPersonId,
                                SellerPersonDied, SellerPersonDeathDate,

                                Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                               , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid,UsersManagments.UserId.ToString());
                            }
                           

                        }

                        int mmrKanal = txtMushterkaKanal.Text.Trim() != "" ? Convert.ToInt32(txtMushterkaKanal.Text) : 0;
                        int mmrMarla = txtMushterkamarla.Text.Trim() != "" ? Convert.ToInt32(txtMushterkamarla.Text.Trim()) : 0;
                        float mmrSarsai = txtMushterkaSarsai.Text.Trim() != "" ? float.Parse(txtMushterkaSarsai.Text.Trim()) : 0;
                        float mmrSft = mmrSarsai * (float)30.25;
                        string chkMushtharaqachecked = this.chkMushtharaqa.Checked.ToString();

                        if (this.KhatoniRecid != "0" && KhatoniRecid != "" && KhatoniRecid != "NULL")
                        {
                            Intiqal.SetMushtarkaRaqbaMuntiqlaKhatooni(KhatoniRecid, chkMushtharaqachecked, mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());
                        }
                        else
                        {
                            Intiqal.SetMushtarkaRaqbaMuntiqla(IntiqalKhataRecId, chkMushtharaqachecked, mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());
                        }
                        proc_Get_Intiqal_Sellers_List_ByKhata(IsKhattaMalkan?IntiqalKhataRecId:"-1", IsKhattaMalkan?"-1":KhatoniRecid);

                        ClearAll();

                        MessageBox.Show(" ریکارڈز محفوظ محفوظ ھو چکے ہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtSellerID.Text = "-1";
                if (cboPersonSeller.SelectedIndex == 0)
                { ClearAll(); }



                else
                {
                    if (chkMushtharaqa.Checked == true) { }

                    else
                    {
                        if (IsKhattaMalkan)
                        {
                            if (this.FardTokenId != null)
                            {
                                dt = Intiqal.GetRegistryIntiqalKhataMalikanByKhataIdByFardTokenId(IntiqalKhataId, this.FardTokenId);
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
                                        if (this.FardTokenId != null)
                                        {
                                            String PersonId = Intiqal.GetPersonIdByKhewatgroupFareeqId(cboPersonSeller.SelectedValue.ToString());
                                            dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaRegistryIntiqal(cboPersonSeller.SelectedValue.ToString(), this.FardTokenId);
                                            dtFard = mnk.GetFardKhewatFareeqainRemainingAreaofFard(cboPersonSeller.SelectedValue.ToString(), PersonId, this.FardTokenId);

                                        }
                                        else
                                        {
                                            dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaNewFard(cboPersonSeller.SelectedValue.ToString());
                                        }
                                       
                                        if (dtFareeqain.Rows.Count > 0)
                                        {
                                            txtKulHisay.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                            txtKullKanal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                            txtKullMarla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                            txtKullSarsai.Text = dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                            txtKulFeet.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();
                                            txtHiddenPersonID.Text = row["PersonId"].ToString();
                                            txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                            txtHidenMustariFareeqID.Text = "NULL";

                                            //Self__________________________
                                            if (this.FardTokenId != null)
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
                                                txtFrokhtKanal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                                txtFrokhtMarla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                                txtFrokhtSarsai.Text = dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                                txtFrokhtFeet.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();
                                            }
                                            //end Self_________________________
                                            break;
                                        }
                                        #region Code Commented After Transacational Fard

                                        //    if (this.MinhayeIntiqals.Rows.Count > 0)
                                        //    {
                                        //        string isDependent = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                        //        //bool SellerExistsInMinhaye = false;
                                        //        if (isDependent == "0")
                                        //        {
                                        //            txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //            txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //            txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //            txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //            txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //            txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //            txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //            txtHidenMustariFareeqID.Text = "NULL";
                                        //            break;
                                        //        }
                                        //        else
                                        //        {
                                        //            string MinhayeIntiqalIdIfexists = "0";
                                        //            MinhayeIntiqalIdIfexists = Intiqal.GetIntiqalMinhayeIntiqalIdByKhewatGroupId(row["KhewatGroupFareeqId"].ToString());
                                        //            if (MinhayeIntiqalIdIfexists == "0")
                                        //            {
                                        //                MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + isDependent + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //                ClearAll();
                                        //            }
                                        //            else
                                        //            {
                                        //                DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalIdIfexists, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                        //                DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                        //                if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                        //                {
                                        //                    txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                        //                    txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                        //                    txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                        //                    txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                        //                    txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                        //                    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //                    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //                    txtHidenMustariFareeqID.Text = "NULL";
                                        //                    break;
                                        //                }
                                        //            }
                                        //        }

                                        //        #region Commented old Code

                                        //        //DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalId, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                        //        //DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                        //        //if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                        //        //{
                                        //        //    txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                        //        //    txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                        //        //    txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                        //        //    txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                        //        //    txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                        //        //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //        //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //        //    txtHidenMustariFareeqID.Text = "NULL";
                                        //        //    break;
                                        //        //}
                                        //        //else
                                        //        //{
                                        //        //    txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //        //    txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //        //    txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //        //    txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //        //    txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //        //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //        //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //        //    txtHidenMustariFareeqID.Text = "NULL";
                                        //        //    break;
                                        //        //}

                                        //        #endregion
                                        //    }
                                        //    else
                                        //    {
                                        //        string CheckForMinhayeIntiqalDependency = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                        //        if (CheckForMinhayeIntiqalDependency == "0")
                                        //        {
                                        //            txtKulHisay.Text = row["FardAreaPart"].ToString();
                                        //            txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                        //            txtKullMarla.Text = row["Fard_Marla"].ToString();
                                        //            txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                        //            txtKulFeet.Text = row["Fard_Feet"].ToString();
                                        //            txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        //            txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                        //            txtHidenMustariFareeqID.Text = "NULL";
                                        //            break;
                                        //        }
                                        //        else
                                        //        {
                                        //            MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + CheckForMinhayeIntiqalDependency + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //            ClearAll();
                                        //        }
                                        //    }
                                        //}

                                        #endregion
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.FardTokenId != null)
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

                                    if (this.FardTokenId != null)
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
                                        txtKulHisay.Text = dtMushteryan.Rows[0]["Rem_Hissa"].ToString();
                                        txtKullKanal.Text = dtMushteryan.Rows[0]["Rem_Kanal"].ToString();
                                        txtKullMarla.Text = dtMushteryan.Rows[0]["Rem_Marla"].ToString();
                                        txtKullSarsai.Text = dtMushteryan.Rows[0]["Rem_Sarsai"].ToString();
                                        txtKulFeet.Text = dtMushteryan.Rows[0]["Rem_Feet"].ToString();
                                        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                        txtHiddenKewatGroupFareeqID.Text = "NULL";
                                        txtHidenMustariFareeqID.Text = row["MushtriFareeqId"].ToString();

                                        //------------self--------------------------
                                        if (this.FardTokenId != null)
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
                                    #region Code Commented after Trasactional Fard
                            
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

                if (this.txtFrokhtHisay.Text.Trim() == string.Empty  || this.cboPersonSeller.SelectedIndex==0)
                    
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
                        if (Seller_Sold_Feet == "0" && Seller_Sold_Sarsai != "0")
                        {
                            Seller_Total_Feet = (float.Parse(Seller_Sold_Sarsai) * 30.25).ToString();
                        }
                        else if (Seller_Sold_Feet != "0" && Seller_Sold_Sarsai == "0")
                        {
                            Seller_Sold_Sarsai = (float.Parse(Seller_Total_Feet) / 30.25).ToString();
                        }

                        if (IsKhattaMalkan)
                        {
                            txtHidenMustariFareeqID.Text = "NULL";
                            this.KhatoniRecid = "NULL";

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
                                if (IsKhattaMalkan)
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
                            // MessageBox.Show(KhewatGroupFareeqId);
                             string lastid;
                             if (this.FardTokenId != null)
                             {
                                 lastid = Intiqal.SaveRegistryintiqalSellers(IntiqalSellerRecId,
                                        IntiqalKhataRecId, IntiqalSellerPersonId,
                                        SellerPersonDied, SellerPersonDeathDate,

                                        Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                       , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, this.FardTokenId,UsersManagments.UserId.ToString());
                             }
                             else
                             {
                                  lastid = Intiqal.SaveintiqalSellers(IntiqalSellerRecId,
                                               IntiqalKhataRecId, IntiqalSellerPersonId,
                                               SellerPersonDied, SellerPersonDeathDate,

                                               Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                              , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid, UsersManagments.UserId.ToString());
                             }

                            //MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSellerID.Text = lastid;
                            proc_Get_Intiqal_Sellers_List_ByKhata(IsKhattaMalkan?IntiqalKhataRecId:"-1",IsKhattaMalkan?"-1":KhatoniRecid);
                            btnDelSeller.Enabled = true;
                            ClearAll();
                            CalculateSellerBuyerRaqbaHissa();

                        }
                   // }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFrokhtHisay_Leave(object sender, EventArgs e)
        {
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
                        RemKanal = Convert.ToInt32((RemKanal % (float)272.25) / (float)20);
                        RemMarla = Convert.ToInt32(RemMarla % (float)272.25);
                    }
                    if (RemSft > 0)
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
                float ksarsai = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) / (float)30.25 : 0; // raqbaSplit[1] != "" ? float.Parse(raqbaSplit[2]) : 0;
                float ksft = raqbaSplit[2] != "" ? float.Parse(raqbaSplit[2]) : 0; 
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

        public void FillgridByBuyerList(string IntKhataRecId, string IntKhatooniRecId)
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
                dt = inteq.GetIntiqalBuyersByIntiqalKhataRecId(IntKhataRecId, IntKhatooniRecId, MalkiatKashkat.ToString());
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
                if (txthiddenBuyerRecId.Text != "" && txtnameKharidar.Text.Trim() != "" && txtKharidHisay.Text.Trim() != "" && txtKharidKanal.Text.Trim() != "" && txtKharidMarla.Text.Trim() != "" && txtKharidSarsai.Text.Trim() != "" && txtKharidFeet.Text != "" && Convert.ToInt32(cboKhewatType.SelectedValue) > 0)
                {
                    bool buyerNotExists = true;
                    foreach (DataGridViewRow r in GridBuyersList.Rows)
                    {
                        if (r.Cells[2].Value.ToString() == this.txthiddnPersonId.Text.ToString())
                        {
                            buyerNotExists = false;
                        }
                    }
                    if (buyerNotExists)
                    {

                        this.SaveIntiqalBuyerRecord();

                        btnModifyBuyer.Enabled = true;
                        btnSaveBuyer.Enabled = true;
                        btnNewBuyer.Enabled = true;
                        btnBuyerSearch.Enabled = true;
                        
                        if (IsKhattaMalkan)
                            FillgridByBuyerList(IntiqalKhataRecId, "-1");
                        else
                            FillgridByBuyerList("-1", this.txtIntiqalKhatooniRecId.Text);
                        gridselection();
                        this.ClearFormControls(groupBox2);
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
                string IntiqalKhatooniRecId = "0";
                if (IsKhattaMalkan)
                {
                    IntiqalKhatooniRecId = "0";
                }
                else
                {
                    IntiqalKhatooniRecId = this.txtIntiqalKhatooniRecId.Text;
                }
                //string buyerid = this.BuyerId.ToString();

                decimal buyerhissay = this.txtKharidHisay.Text.ToString() != "" ? Convert.ToDecimal(this.txtKharidHisay.Text.ToString()) : 0;
                string buyerkanal = this.txtKharidKanal.Text.ToString() != "" ? this.txtKharidKanal.Text.ToString() : "0";
                string buyermarla = this.txtKharidMarla.Text.ToString() != "" ? this.txtKharidMarla.Text.ToString() : "0";
                decimal buyersarsai = txtKharidSarsai.Text.Trim() != "" ? Convert.ToDecimal(this.txtKharidSarsai.Text.ToString()) : 0;
                string khewattypeid = this.cboKhewatType.SelectedValue.ToString() != "" ? this.cboKhewatType.SelectedValue.ToString() : " 0";
                string BuyerHisaBata = txtBuyerHIsaBata.Text.Trim() != "" ? txtBuyerHIsaBata.Text.Trim() : "0";
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
                //    string s = inteq.SaveintiqalBuyersSelf(IntiqalBuyerRecId, IntiqalKhataRecId, IntiqalKhatooniRecId, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, BuyerHisaBata, cmbRishta.SelectedValue.ToString(), UsersManagments.UserId.ToString(),UsersManagments.UserName.ToString()).FirstOrDefault().ToString();
                //}

                //else
                //{
                    string s = inteq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, IntiqalKhatooniRecId, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, BuyerHisaBata, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString()).FirstOrDefault().ToString();

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
            this.ClearFormControls(gbBuyersControls);
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
                frmTestMalkanSelcIntiqalWirasath frmTMSIW = new frmTestMalkanSelcIntiqalWirasath();
                frmTMSIW.khewatTypeId = cboKhewatType.SelectedValue.ToString();
                frmTMSIW.MozaId = this.MozaId.ToString();
                frmTMSIW.IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                frmTMSIW.FormClosed -= new FormClosedEventHandler(frmTMSIW_closed);
                frmTMSIW.FormClosed += new FormClosedEventHandler(frmTMSIW_closed);
                frmTMSIW.KhatoniRecid = KhatoniRecid;
                frmTMSIW.IntiqalKhataRecId = this.IntiqalKhataRecId;
                frmTMSIW.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void frmTMSIW_closed(object sender, FormClosedEventArgs e)
        {
            FillgridByBuyerList(IsKhattaMalkan ? IntiqalKhataRecId : "-1", IsKhattaMalkan ? "-1" : IntiqalKhatooniRecId);
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
                        //FillgridByBuyerList(IsKhattaMalkan ? IntiqalKhataRecId : "-1", IsKhattaMalkan ? "-1" : IntiqalKhatooniRecId);
                        this.ClearFormControls(gbBuyersControls);
                        btnDelSeller.Enabled = false;
                        btnModifyBuyer.Enabled = false;
                        btnSaveBuyer.Enabled = true;
                        btnNewBuyer.Enabled = true;
                        btnBuyerSearch.Enabled = true;
                        FillgridByBuyerList(IsKhattaMalkan ? IntiqalKhataRecId : "-1", IsKhattaMalkan ? "-1" : this.txtIntiqalKhatooniRecId.Text);
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
                    MinGroupNo = cboMinGroups.Text;
                }
                else
                {
                    txtGroupMinId.Text = "";
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
                                Intiqal.IntiqalAmalDaramad(UsersManagments.MozaId.ToString(), this.IntiqalId);
                                //client.IntiqalAmalDaramadCombined(CurrentUser.MozaId.ToString(), this.IntiqalId.ToString());
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

        private void cmbMinKhatooniByParentKhatooni_SelectionChangeCommitted(object sender, EventArgs e)
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
                    string khasraid = this.txtNewKhassraId.Text;
                    string khasradetailid = this.txtNewKhassraDetailId.Text;
                    string khassrno = this.txtNewKhassraMinKhassraNo.Text;
                    string kanal = this.txtNewKhassraKanal.Text;
                    string marla = this.txtNewKhassraMarla.Text;
                    string feet = this.txtNewKhassraFeet.Text;
                    string sarsar = this.txtNewKhassraSarsai.Text;
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
            this.txthiddendetailid.Text = "-1";
            this.OldKhassraNo.Text = "";
            this.txt_kanal_Khasra.Text = "";
            this.txt_Marala_Khasra.Text = "";
            this.txt_Feet_Khasra.Text = "";
            this.txt_Sarsai_Khasra.Text = "";
            this.txtkhasratypeid.Text = "-1";
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


        #region Khata Taqseem Portion

        #region Check box new Khata Checked Change Event

        private void chkNewKhataChange_For_Khata_CheckedChanged(object sender, EventArgs e)
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
                //TaqseemNewTabDisable();
                btnDeleteChange.Enabled = true;
                btnClearChange.Enabled = true;
                btnSaveChange.Enabled = true;

            }

        }

        #endregion

        #region Taqseem New Khata Controls Diable / Enable , Clear controls

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

        #region Combo box New Khata by Parent Khata Selected Index Change Event

        private void cmbtaqseemChangeKhata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Comboxo Selection Change commited Event

        private void cmbtaqseemChange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RegisterHqDKhataId = this.cmbtaqseemChangeKhata.SelectedValue.ToString();
            Get_TaqseemRegHadkhataid(this.cmbtaqseemChangeKhata.SelectedValue.ToString());

            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                TaqseemNewTabEnable();
                RegisterHqDKhataId = cmbtaqseemChangeKhata.SelectedValue.ToString();
                txtRegHaqKhataID.Text = cmbtaqseemChangeKhata.SelectedValue.ToString();

            }
            else
            {

                RegisterHqDKhataId = "0";
            }

            FillGridMalikanChange();
            FillGridKhatooniChange();
            Fillkhatoniforkhasra();
            getkhasrajattotalarea();
        }

        #endregion

        #region Fill Gridview Malkan New Khata

        public void FillGridMalikanChange()
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
                grdMushtrianMalinkanChange.DataSource = dt;
                //grdMushtrianMalinkanChange.Columns["chk_change_Malikan"].DisplayIndex = 0;
                grdMushtrianMalinkanChange.Columns["PersonName"].DisplayIndex = 1;
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].DisplayIndex = 3;
                grdMushtrianMalinkanChange.Columns["KhewatType"].DisplayIndex = 2;
                grdMushtrianMalinkanChange.Columns["PersonName"].HeaderText = "نام مالک";
                grdMushtrianMalinkanChange.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].HeaderText = "رقبہ";
                grdMushtrianMalinkanChange.Columns["KhewatGroupFareeqId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhewatGroupId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardAreaPart"].Visible = true;
                grdMushtrianMalinkanChange.Columns["KhewatTypeId"].Visible = false;

                grdMushtrianMalinkanChange.Columns["DarNo"].Visible = false;
                grdMushtrianMalinkanChange.Columns["TotalDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardPart_Bata"].Visible = false;
                grdMushtrianMalinkanChange.Columns["seqno"].Visible = false;
                grdMushtrianMalinkanChange.Columns["CNIC"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonNetPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["OfDarPart"].Visible = false;

                GetFaraqIstirak();



            }
            else
            {
                dt = this.taqseemnewkhata.Proc_Get_KhewatFareeqeinByKhataId("0");
                grdMushtrianMalinkanChange.DataSource = dt;
                grdMushtrianMalinkanChange.Columns["chk_change_Malikan"].DisplayIndex = 0;
                grdMushtrianMalinkanChange.Columns["PersonName"].DisplayIndex = 1;
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].DisplayIndex = 2;
                grdMushtrianMalinkanChange.Columns["KhewatType"].DisplayIndex = 3;

                grdMushtrianMalinkanChange.Columns["KhewatGroupFareeqId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhewatGroupId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonId"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardAreaPart"].Visible = false;
                //grdMushtrianMalinkanChange.Columns["Kanal"].Visible = false;
                //grdMushtrianMalinkanChange.Columns["marla"].Visible = false;
                //grdMushtrianMalinkanChange.Columns["sarsai"].Visible = false;
                grdMushtrianMalinkanChange.Columns["KhewatTypeId"].Visible = false;
                //  grdMushtrianMalinkanChange.Columns["KhewatType"].Visible = false;
                //grdMushtrianMalinkanChange.Columns["PersonType"].Visible = false;
                //  grdMushtrianMalinkanChange.Columns["RegisterHqDKhataId"].Visible = false;
                // grdMushtrianMalinkanChange.Columns["Khewat_Area"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonName"].HeaderText = "نام مالک";
                grdMushtrianMalinkanChange.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                grdMushtrianMalinkanChange.Columns["Khewat_Area"].HeaderText = "رقبہ";
                grdMushtrianMalinkanChange.Columns["DarNo"].Visible = false;
                grdMushtrianMalinkanChange.Columns["TotalDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["FardPart_Bata"].Visible = false;
                grdMushtrianMalinkanChange.Columns["seqno"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonDarPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["PersonNetPart"].Visible = false;
                grdMushtrianMalinkanChange.Columns["OfDarPart"].Visible = false;
            }

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

        #region Get Khatooni Data by Khata

        public void FillGridKhatooniChange()
        {
            try
            {



                string khataid = RegisterHqDKhataId;
                dt = taqseemnewkhata.Proc_Get_Khatoonis(RegisterHqDKhataId.ToString());
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
            float farq = float.Parse(this.txthissayChagne.Text) - sum;
            this.txthissamaifarqbox18.Text = farq.ToString();
        }

        #endregion

        #region Button Save Malak Event

        private void btnSaveChangeKhatataqseem_Click(object sender, EventArgs e)
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
                string Registerkid = taqseemnewkhata.WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta(txtRegHaqKhataID.Text.ToString(), RegisterHqId, kNo, Taraf, Pati, hissay, kannal, marala, sarsai, feet, malia, kefiat, MozaId.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), txtparentKhataId.Text, ParentKhataID);
                string minGroupId = inteq.SaveIntiqalMinGroup("-1", IntiqalId, this.IntiqalKhataId, "1", kNo, "0", "0", "0", hissay, kannal, marala, sarsai, feet, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName, MozaId.ToString());
                txtRegHaqKhataID.Text = Registerkid;
                RegisterHqDKhataId = Registerkid;
                if (RegisterHqDKhataId != null)
                {
                    AutoComplete on = new AutoComplete();
                    on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
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

        #region Get Total Area KhassraJat

        public void getkhasrajattotalarea()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Intiqal.Proc_Get_KhassrasTotalArea_By_KhataId(RegisterHqDKhataId);
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

        #region Button Delete New Khata Taqseen Click Event

        private void btnDeleteChange_For_Khata_Click(object sender, EventArgs e)
        {
            if (this.txtRegHaqKhataID.Text != "")
            {
                try
                {
                    inteq.DeleteRegisterHaqdaranKhattaByKhataId(this.txtRegHaqKhataID.Text);
                    AutoComplete on = new AutoComplete();
                    on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + ParentKhataID + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
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

        #region Button Select Malak from Bayan/Mushteryan etc

        private void btnGetChangeMalikan_For_Khata_Click(object sender, EventArgs e)
        {
            if (cmbtaqseemChangeKhata.SelectedIndex != 0)
            {
                if (Convert.ToInt32(RegisterHqDKhataId) > 0)
                {
                    try
                    {
                        AL.frmMalkan_Taqseem frmMTv = new AL.frmMalkan_Taqseem();
                        frmMTv.KhataId = IntiqalKhataId;
                        frmMTv.IntiqalId = IntiqalId;
                        frmMTv.RegisterhaqkhataId = RegisterHqDKhataId;//cmbtaqseemChangeKhata.SelectedValue.ToString();
                        frmMTv.FormClosed -= new FormClosedEventHandler(frmMTv_FormClosed);
                        frmMTv.FormClosed += new FormClosedEventHandler(frmMTv_FormClosed);
                        frmMTv.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
            FillGridMalikanChange();
        }

        #endregion

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

            btnSaveChangeMalikan.Enabled = true;
            btndeleteChangeMalikan.Enabled = true;
        }

        #endregion

        #region Button Hissa / Raqba Calculate Click Event

        private void btnishtarakhisabamutabiq_For_Khata_Click(object sender, EventArgs e)
        {
            CalulateArea_Taqseem_Khata_Malkan();
        }
        public void CalulateArea_Taqseem_Khata_Malkan()
        {
            try
            {
                float khissay = this.txthissayChagne.Text.Trim() != "" ? float.Parse(txtNewKhataTotalParts.Text.Trim()) : 0;
                float shissay = txtHisamuntaqialachangeevb.Text.Trim() != "" ? float.Parse(txtHisamuntaqialachangeevb.Text.Trim()) : 0;
                int kkanal = this.txtNewKhataTotalKanal.Text.Trim() != "" ? Convert.ToInt32(txtNewKhataTotalKanal.Text.Trim()) : 0;
                int kmarla = this.txtNewKhataTotalMarla.Text.Trim() != "" ? Convert.ToInt32(txtNewKhataTotalMarla.Text.Trim()) : 0;
                float ksarsai = this.txtNewKhataTotalSarsai.Text.Trim() != "" ? float.Parse(txtNewKhataTotalSarsai.Text.Trim()) : 0;
                float ksft = this.txtNewKhataTotalFeet.Text.Trim() != "" ? float.Parse(txtNewKhataTotalFeet.Text.Trim()) : 0;


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

        #region Button Get Hissa/Raqba Calculation Click Event
    
        private void btnCalculateArea_Click(object sender, EventArgs e)
        {
            this.CalulateArea_Taqseem_Khata_Malkan();
        }

        #endregion

        #region Button Save new Khata Malklan Click Event

        private void btnSaveChangeMalikan_For_Khata_Click(object sender, EventArgs e)
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
                FillGridMalikanChange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Delete Malak new Khata Click Event

        private void btndeleteChangeMalikan_For_Khata_Click(object sender, EventArgs e)
        {
            taqseemnewkhata.WEB_SP_DELETE_KhewatGroupFareeqein(KhewatGroupFareeqId);
            MessageBox.Show("  مالک حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            FillGridMalikanChange();
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
        }

        #endregion

        #region Get Khatooni New Khatooni No Click Event

        private void btnGetkhatoni_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtNewkhatooniId.Text = "-1";
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
                string KhatooniLagan = this.txtNewKhatooniLagan.Text != null ? (this.txtNewKhatooniLagan.Text.ToString()) : "";
                string khatoniid = this.taqseemnewkhata.WEB_SP_INSERT_KhatooniRegister(KhatooniId, KhatooniNo, KhatooniKashtkaranFullDetail_New, RegisterHqDKhataId, Wasail_e_Abpashi, KhatooniLagan, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                if (khatoniid != null)
                {
                    this.txtNewkhatooniId.Text = khatoniid;
                    MessageBox.Show("کھتونی محفوظ ہوگیے", "کھتونی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGridKhatooniChange();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Delete New Khatooni Click Event

        private void btnDeleteKhatoonichange_Click(object sender, EventArgs e)
        {

            this.taqseemnewkhata.WEB_SP_DELETE_KhatooniRegister(this.txtNewkhatooniId.Text); //grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString());
            MessageBox.Show("  کھتونی حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            FillGridKhatooniChange();
        }

        #endregion

        #region Gridview new  Khatoonies double click Event

        private void grdGetkhatonichange_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                txtabbpashi.Text = grdGetkhatonichange.CurrentRow.Cells["Wasail_e_Abpashi"].Value.ToString();
                this.txttafsel.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
                this.txtNewKhatooniLagan.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniLagan"].Value.ToString();
                this.txtKhatooninumchagee.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniNo"].Value.ToString();
                this.txtNewkhatooniId.Text = grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString();

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

        #region Drop Down Get KhassraJat By Khatooni Id Selection Change Event

        private void cmbkhatoonisnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            getkhasrajatbykhatoni();
        }

        public void getkhasrajatbykhatoni()
        {
            try
            {
                string kanal = "0";
                string marala = "0";
                string sarsai = "0";
                DataTable dt = new DataTable();
                if (cmbkhatoonisnew.SelectedIndex > 0)
                {
                    dt = Intiqal.Proc_Get_KhassaAreaByKhatooniId(cmbkhatoonisnew.SelectedValue.ToString());
                    foreach (DataRow d in dt.Rows)
                    {
                        string str = d["sumofkhasrakhatoniid"].ToString();
                        string[] arr = str.Split(new string[] { " " }, StringSplitOptions.None);
                        foreach (string a in arr)
                        {
                            if (a != string.Empty)
                            {
                                if (a.Contains("کنال"))
                                {
                                    string[] k = a.Split(new string[] { "کنال" }, StringSplitOptions.None);
                                    t1kanal.Text = k[0].ToString();
                                }
                                if (a.Contains("مرلہ"))
                                {
                                    string[] M = a.Split(new string[] { "مرلہ" }, StringSplitOptions.None);
                                    t1marla.Text = M[0].ToString();
                                }
                                if (a.Contains("سرسائی"))
                                {
                                    string[] S = a.Split(new string[] { "سرسائی" }, StringSplitOptions.None);
                                    t1sarsai.Text = S[0].ToString();
                                }
                            }
                        }

                    }
                    string kanaal = t1kanal.Text != null ? t1kanal.Text : "0";
                    string marla = t1marla.Text != null ? t1marla.Text : "0";
                    string sarsari = t1sarsai.Text != null ? t1sarsai.Text : "0";
                    string com = kanaal + "-" + marla + "-" + sarsai;
                    label92.Text = com;
                }
                else
                {
                    label92.Text = "0-0-0";
                }


            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Button Select Khassra from Prevoius Khassrajat Click Event

        private void btnselectchangekhasra_For_Khata_Click(object sender, EventArgs e)
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
            getkhasrajatbykhatoni();
        }

        #endregion

        #region Button Save NewKhassra Click Event

        private void btnsavenewkhasra_For_Khata_Click(object sender, EventArgs e)
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

                    FillKhasraJatNew();
                    //getkhasrajattotalarea();
                    getkhasrajatbykhatoni();
                }

            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Fill New Khassrajat
        public void FillKhasraJatNew()
        {
            string khatooniid = cmbkhatoonisnew.SelectedValue.ToString();
            dt = taqseemnewkhata.Proc_Get_KhatooniKhassraDetail(khatooniid.ToString());
            this.grdNewKhasrajat.DataSource = dt;

            grdNewKhasrajat.Columns["KhassraDetailId"].Visible = false;
            grdNewKhasrajat.Columns["AreaTypeId"].Visible = false;
            grdNewKhasrajat.Columns["KhatooniId"].Visible = false;
            grdNewKhasrajat.Columns["KhassraId"].Visible = false;
            grdNewKhasrajat.Columns["AreaType"].Visible = false;
            grdNewKhasrajat.Columns["Kanal"].Visible = false;
            grdNewKhasrajat.Columns["Marla"].Visible = false;
            grdNewKhasrajat.Columns["Sarsai"].Visible = false;
            grdNewKhasrajat.Columns["Feet"].Visible = false;
            grdNewKhasrajat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
        }
        #endregion

        #region Button Delete New Khassra Click event

        private void btnDeleteNewKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txthiddendetailid.Text != null)
                {
                    taqseemnewkhata.WEB_SP_DELETE_KhassraRegisterDetail_Direct(this.txthiddendetailid.Text);
                }
                MessageBox.Show("خسرہ نمبر حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Combobox New Khatooni Selection Change Comitted Event
        private void cmbkhatoonisnew_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillKhasraJatNew();
        }
        #endregion

        #region Gridview New Khassrajat Dluble Click Event

        private void grdNewKhasrajat_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewNewKhassrajat.Rows.Count > 0)
                {
           
                    this.txtNewKhassraKanal.Text = gridViewNewKhassrajat.CurrentRow.Cells["Kanal"].Value.ToString();
                    this.txtNewKhassraMarla.Text = gridViewNewKhassrajat.CurrentRow.Cells["Marla"].Value.ToString();
                    this.txtOldKhassrNo.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txtNewKhassraMinKhassraNo.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txtNewKhassraId.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    this.txtNewKhassraDetailId.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraDetailId"].Value.ToString();
                    this.txtNewKhassraAreatypeId.Text = gridViewNewKhassrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString();
                    decimal sar = Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Sarsai"].Value) != null ? Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Sarsai"].Value) : 0;
                    this.txtNewKhassraSarsai.Text = Math.Round(sar, 7).ToString();
                    decimal fe = Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Feet"].Value) != null ? Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Feet"].Value) : 0;
                    this.txtNewKhassraFeet.Text = Math.Round(fe, 7).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (gridViewNewKhassrajat.Rows.Count > 0)
                {

                    this.txtNewKhassraKanal.Text = gridViewNewKhassrajat.CurrentRow.Cells["Kanal"].Value.ToString();
                    this.txtNewKhassraMarla.Text = gridViewNewKhassrajat.CurrentRow.Cells["Marla"].Value.ToString();
                    this.txtOldKhassrNo.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txtNewKhassraMinKhassraNo.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraNo"].Value.ToString();
                    this.txtNewKhassraId.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraId"].Value.ToString();
                    this.txtNewKhassraDetailId.Text = gridViewNewKhassrajat.CurrentRow.Cells["KhassraDetailId"].Value.ToString();
                    this.txtNewKhassraAreatypeId.Text = gridViewNewKhassrajat.CurrentRow.Cells["AreaTypeId"].Value.ToString();
                    decimal sar = Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Sarsai"].Value) != null ? Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Sarsai"].Value) : 0;
                    this.txtNewKhassraSarsai.Text = Math.Round(sar, 7).ToString();
                    decimal fe = Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Feet"].Value) != null ? Convert.ToDecimal(gridViewNewKhassrajat.CurrentRow.Cells["Feet"].Value) : 0;
                    this.txtNewKhassraFeet.Text = Math.Round(fe, 7).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 4)
            {
                AutoComplete on = new AutoComplete();
                on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                AutoComplete ac = new AutoComplete();
                ac.FillCombo("Proc_Get_Intiqal_MinGroupsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.IntiqalId + "," + this.IntiqalKhataId + ",0", cboMinGroups, "IntiqalMinGroupNo", "IntiqalMinGroupId");
            }
        }


        #endregion

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

        private void cmbKhatoniNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtIntiqalKhatooniRecId.Text = "-1";
            txtparentKhatooniId.Text = "-1";
            GetKhatoni(txtKhattaRecId.Text);
        }

       

    }
}

















