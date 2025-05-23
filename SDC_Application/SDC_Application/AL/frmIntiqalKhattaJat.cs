﻿using System;
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
        public bool isConfirmed { get; set; }
        public string MinhayeIntiqalId { get; set; }
        //  AutoComplete on = new AutoComplete();
        //public string lastId { get; set; }
        Intiqal inteq = new Intiqal();
        DataTable dtkj = new DataTable();
        DataTable saveKhata = new DataTable();
        DataTable dtmg = new DataTable();
        DataTable dtMinGrpDet = new DataTable();
        BindingSource bs = new BindingSource();
        DataTable MinhayeIntiqals = new DataTable();
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
        public string KhewatGroupFareeqId { get; set; }
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
                    //this.IntiqalStatus = false;
                    btnAmaldaramad.Enabled = false;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.panel5.Enabled = false;
                    this.groupBox12.Enabled = false;
                    this.groupBox25.Enabled = false;




                }
                else
                {
                    if (this.isAttested)
                    {
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                        // this.IntiqalStatus = false;
                        btnAmaldaramad.Enabled = true;
                        btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        this.gbKhataMainContols.Enabled = true;
                        this.panel5.Enabled = true;
                        this.groupBox12.Enabled = true;
                        this.groupBox25.Enabled = true;
                        gbBuyersControls.Enabled = false;
                        //gbSellersControls.Enabled = false;
                        gbKhataMainContols.Enabled = false;
                        gbSubKhataControls.Enabled = false;
                        gbSubKhataMalkan.Enabled = false;
                        gbSubKhataKhatooni.Enabled = false;
                        gbSubKhataKhassras.Enabled = false;
                    }
                    else
                    {
                        lblMutStatus.Text = " عمل درامد زیر غور";
                        lblMutStatus.ForeColor = Color.Red;
                        // this.IntiqalStatus = false;
                        btnAmaldaramad.Enabled = false;
                        btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        this.gbKhataMainContols.Enabled = true;
                        this.panel5.Enabled = true;
                        this.groupBox12.Enabled = true;
                        this.groupBox25.Enabled = true;

                        // Confirmation by Operator //
                        if (isConfirmed)
                        {
                            gbBuyersControls.Enabled = false;
                            gbSellersControls.Enabled = false;
                            //gbSellersControls.Enabled = false;
                            gbKhataMainContols.Enabled = false;
                            gbSubKhataControls.Enabled = false;
                            gbSubKhataMalkan.Enabled = false;
                            gbSubKhataKhatooni.Enabled = false;
                            gbSubKhataKhassras.Enabled = false;
                        }
                        else
                        {
                            
                                gbBuyersControls.Enabled = true;
                                gbSellersControls.Enabled = true;
                                //gbSellersControls.Enabled = false;
                                gbKhataMainContols.Enabled = true;
                                gbSubKhataControls.Enabled = true;
                                gbSubKhataMalkan.Enabled = true;
                                gbSubKhataKhatooni.Enabled = true;
                                gbSubKhataKhassras.Enabled = true;
                            
                        }
                    }
                }
            }
            else if (mingrp == 1)
            {
                this.groupBox19.Visible = true;
                gbAmalDaramad.Visible = true;
                if (Status)
                {
                    lblAmalDaramdTaqseem.Text = "عمل درامد شدہ";
                    lblAmalDaramdTaqseem.ForeColor = Color.Green;
                    btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                    btnAmaldaramad.Enabled = false;
                    this.gbKhataMainContols.Enabled = false;
                    this.panel5.Enabled = false;
                    this.groupBox17.Enabled = false;
                    this.groupBox18.Enabled = false;
                    gbBuyersControls.Enabled = false;
                    gbSellersControls.Enabled = false;
                    gbKhataMainContols.Enabled = false;
                    gbSubKhataControls.Enabled = false;
                    gbSubKhataMalkan.Enabled = false;
                    gbSubKhataKhatooni.Enabled = false;
                    gbSubKhataKhassras.Enabled = false;
                }
                else
                {
                    if (isAttested)
                    {
                        lblAmalDaramdTaqseem.Text = "  عمل درامد زیر غور";
                        lblAmalDaramdTaqseem.ForeColor = Color.Red;
                        btnAmalDaramadTaqseemWaIshterak.Enabled = true;
                        btnAmaldaramad.Enabled = false;
                        this.gbKhataMainContols.Enabled = true;
                        this.panel5.Enabled = false;
                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                        gbBuyersControls.Enabled = false;
                        //gbSellersControls.Enabled = false;
                        gbKhataMainContols.Enabled = false;
                        gbSubKhataControls.Enabled = false;
                        gbSubKhataMalkan.Enabled = false;
                        gbSubKhataKhatooni.Enabled = false;
                        gbSubKhataKhassras.Enabled = false;
                    }
                    else
                    {
                        lblAmalDaramdTaqseem.Text = "  عمل درامد زیر غور";
                        lblAmalDaramdTaqseem.ForeColor = Color.Red;
                        btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                        btnAmaldaramad.Enabled = false;
                        this.gbKhataMainContols.Enabled = true;
                        this.panel5.Enabled = false;
                        this.groupBox17.Enabled = true;
                        this.groupBox18.Enabled = true;
                       
                        // Confrimation by Operator //
                        if (isConfirmed)
                        {
                            gbBuyersControls.Enabled = false;
                            gbSellersControls.Enabled = false;
                            //gbSellersControls.Enabled = false;
                            gbKhataMainContols.Enabled = false;
                            gbSubKhataControls.Enabled = false;
                            gbSubKhataMalkan.Enabled = false;
                            gbSubKhataKhatooni.Enabled = false;
                            gbSubKhataKhassras.Enabled = false;
                        }
                        else
                        {
                            {
                                gbBuyersControls.Enabled = true;
                                gbSellersControls.Enabled = true;
                                //gbSellersControls.Enabled = false;
                                gbKhataMainContols.Enabled = true;
                                gbSubKhataControls.Enabled = true;
                                gbSubKhataMalkan.Enabled = true;
                                gbSubKhataKhatooni.Enabled = true;
                                gbSubKhataKhassras.Enabled = true;
                            }
                        }
                    }

                }

            }
            

        }
        #endregion

        #endregion

        private void frmkhatta_Load(object sender, EventArgs e)
        {
            //FillGridMalikanChange();
            TaqseemNewTabDisable();
            if (IntiqalId != "-1")
            {
                txtParentid.Text = IntiqalId.ToString();///get for newtaqseem tab
                fillIntiqalkhatajatList(this.MozaId.ToString());
                Fill_InteqalKhataGrid();
                txtKhattaRecId.Text = "-1";
                this.MinhayeIntiqals = Intiqal.GetIntiqalMinhayeIntiqals(this.IntiqalId);
                this.SetAmalDaramadStatus(this.AmalDaramad);
                if (this.IntiqalPending)
                {
                    this.btnAmaldaramad.Enabled = false;
                    this.btnAmalDaramadTaqseem.Enabled = false;
                    this.btnAmalDaramadTaqseemWaIshterak.Enabled = false;
                }
                //Set Attestation Status
                if (this.isAttested)
                {
                    gbBuyersControls.Enabled = false;
                    //gbSellersControls.Enabled = false; 
                    gbKhataMainContols.Enabled = false;
                    gbSubKhataControls.Enabled = false;
                    gbSubKhataMalkan.Enabled = false;
                    gbSubKhataKhatooni.Enabled = false;
                    gbSubKhataKhassras.Enabled = false;
                    if (!this.AmalDaramad)
                    {
                        btnAmaldaramad.Enabled = true;
                    }
                }
                // MessageBox.Show(IntiqalId);

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
            // tabControl1.TabPages.Remove(tabPage4);
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
                if (dt != null)
                {
                    GridViewInteqalKhattas.Columns["IntiqalId"].Visible = false;
                    GridViewInteqalKhattas.Columns["IntiqalKhataId"].Visible = false;
                    GridViewInteqalKhattas.Columns["IntiqalKhataRecId"].Visible = false;
                    GridViewInteqalKhattas.Columns["AmaldaramadStatus"].Visible = false;
                    GridViewInteqalKhattas.Columns["AmaldaramadDate"].Visible = false;
                    GridViewInteqalKhattas.Columns["IsJuzviKhatta"].Visible = false;
                }
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
                string LastId = inteq.SaveintiqalKhataJaat(KhataRecId, intiqalId, khataid);
                txtKhattaRecId.Text = LastId;
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
                            IntiqalKhataId = GridViewInteqalKhattas.CurrentRow.Cells["IntiqalKhataId"].Value.ToString();
                            this.txtparentKhataId.Text = IntiqalKhataId;
                            NewKhataCreate = GridViewInteqalKhattas.CurrentRow.Cells["KhataNo"].Value.ToString();
                            IsJuzviKhatta = Convert.ToBoolean(GridViewInteqalKhattas.CurrentRow.Cells["IsJuzviKhatta"].Value.ToString());;
                            cbJuzviKhata.Checked = IsJuzviKhatta;
                            //cbJuzviKhata_CheckedChanged(sender, e);
                            if (IntiqalKhataId != string.Empty)
                            {

                                AutoFillCombo.FillCombo("proc_Get_Intiqal_Khata_Malkan '" + IntiqalKhataId + "'", cboPersonSeller, "personname", "KhewatGroupFareeqId");
                                proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                                FillgridByBuyerList();

                            }


                            Fill_ComboKhewatTypes();
                            gridselection();
                            this.ClearFormControls(groupBox8);
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
                if (dt != null)
                {
                    grdKhatoniDetails.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                    grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "کھتونی نمبر";
                    grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].Visible = false;
                    grdKhatoniDetails.Columns["IntiqalKhatooniRecId"].Visible = false;
                    grdKhatoniDetails.Columns["KhatooniId"].Visible = false;
                }
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
                        AutoFillCombo.FillCombo("proc_Get_Intiqal_KhanaKashtKhatooni_Malkan '" + IntiqalKhataId + "'", cboPersonSeller, "personname", "MushtriFareeqId");
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
                float khissay = txtKulHisay.Text.Trim() != "" ? float.Parse(txtKulHisay.Text.Trim()) : 0;
                float shissay = txtFrokhtHisay.Text.Trim() != "" ? float.Parse(txtFrokhtHisay.Text.Trim()) : 0;
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

                if (txtFrokhtHisay.Text.Trim() != "" && txtFrokhtHisay.Text != "0")
                {
                    txtFrokhtKanal.Text = "";
                    txtFrokhtMarla.Text = "";
                    txtFrokhtSarsai.Text = "";
                    txtFrokhtFeet.Text = "";

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
                        Intiqal.DeleteIntiqalSeller(IntiqalSellerId);
                        string IntiqalKhatooniRecId;
                        txtSellerID.Text = "-1";
                        proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                        CalculateSellerBuyerRaqbaHissa();
                            btnDelSeller.Enabled = false;
                            ClearAll();

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

                                txtKulHisay.Text = row.Cells["Seller_Total_Hissa"].Value.ToString();
                                txtKullKanal.Text = row.Cells["Seller_Total_Kanal"].Value.ToString();
                                txtKullMarla.Text = row.Cells["Seller_Total_Marla"].Value.ToString();
                                txtKullSarsai.Text = row.Cells["Seller_Total_Sarsai"].Value.ToString();
                                txtKulFeet.Text = row.Cells["Seller_Total_Feet"].Value.ToString();

                                this.txtFrokhtHisay.Text = row.Cells["Seller_Sold_Hissa"].Value.ToString();
                                this.txtFrokhtKanal.Text = row.Cells["Seller_Sold_Kanal"].Value.ToString();
                                this.txtFrokhtMarla.Text = row.Cells["Seller_Sold_Marla"].Value.ToString();
                                this.txtFrokhtSarsai.Text = row.Cells["Seller_Sold_Sarsai"].Value.ToString();
                                this.txtFrokhtFeet.Text = row.Cells["Seller_Sold_Feet"].Value.ToString();
                                this.txtHiddenKewatGroupFareeqID.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                                //}
                                txtHiddenPersonID.Text = row.Cells["IntiqalSellerPersonId"].Value.ToString();

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
                               , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid);
                            }


                        }
                        int mmrKanal = txtMushterkaKanal.Text.Trim() != "" ? Convert.ToInt32(txtMushterkaKanal.Text) : 0;
                        int mmrMarla = txtMushterkamarla.Text.Trim() != "" ? Convert.ToInt32(txtMushterkamarla.Text.Trim()) : 0;
                        float mmrSarsai = txtMushterkaSarsai.Text.Trim() != "" ? float.Parse(txtMushterkaSarsai.Text.Trim()) : 0;
                        float mmrSft = mmrSarsai * (float)30.25;
                        string chkMushtharaqachecked = this.chkMushtharaqa.Checked.ToString();
                        Intiqal.SetMushtarkaRaqbaMuntiqla(IntiqalKhataRecId, chkMushtharaqachecked, mmrKanal.ToString(), mmrMarla.ToString(), mmrSarsai.ToString(), mmrSft.ToString());
                        proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
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
                                        if (this.MinhayeIntiqals!=null? this.MinhayeIntiqals.Rows.Count > 0:false)
                                        {
                                            string isDependent = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                            //bool SellerExistsInMinhaye = false;
                                            if (isDependent == "0")
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
                                            else
                                            {
                                                string MinhayeIntiqalIdIfexists = "0";
                                                MinhayeIntiqalIdIfexists = Intiqal.GetIntiqalMinhayeIntiqalIdByKhewatGroupId(row["KhewatGroupFareeqId"].ToString());
                                                if (MinhayeIntiqalIdIfexists == "0")
                                                {
                                                    MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + isDependent + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearAll();
                                                }
                                                else
                                                {
                                                    DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalIdIfexists, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                                    DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                                    if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                                    {
                                                        txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                                        txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                                        txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                                        txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                                        txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                                        txtHiddenPersonID.Text = row["PersonId"].ToString();
                                                        txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                                        txtHidenMustariFareeqID.Text = "NULL";
                                                        break;
                                                    }
                                                }
                                            }

                                            #region Commented old Code

                                            //DataTable Rem_HissaRaqba = Intiqal.GetIntiqalSellerHisaRaqbaMinhayeIntiqal(MinhayeIntiqalId, IntiqalKhataId, row["KhewatGroupFareeqId"].ToString(), "0");
                                            //DataRow FirstRecord = Rem_HissaRaqba.Rows.Count > 0 ? Rem_HissaRaqba.Rows[0] : null;
                                            //if (Convert.ToBoolean(FirstRecord["isFound"]) == true)
                                            //{
                                            //    txtKulHisay.Text = FirstRecord["Rem_Hissa"].ToString();
                                            //    txtKullKanal.Text = FirstRecord["Rem_Kanal"].ToString();
                                            //    txtKullMarla.Text = FirstRecord["Rem_Marla"].ToString();
                                            //    txtKullSarsai.Text = FirstRecord["Rem_Sarsai"].ToString();
                                            //    txtKulFeet.Text = FirstRecord["Rem_Feet"].ToString();
                                            //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                            //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                            //    txtHidenMustariFareeqID.Text = "NULL";
                                            //    break;
                                            //}
                                            //else
                                            //{
                                            //    txtKulHisay.Text = row["FardAreaPart"].ToString();
                                            //    txtKullKanal.Text = row["Farad_Kanal"].ToString();
                                            //    txtKullMarla.Text = row["Fard_Marla"].ToString();
                                            //    txtKullSarsai.Text = row["Fard_Sarsai"].ToString();
                                            //    txtKulFeet.Text = row["Fard_Feet"].ToString();
                                            //    txtHiddenPersonID.Text = row["PersonId"].ToString();
                                            //    txtHiddenKewatGroupFareeqID.Text = row["KhewatGroupFareeqId"].ToString();
                                            //    txtHidenMustariFareeqID.Text = "NULL";
                                            //    break;
                                            //}

                                            #endregion
                                        }
                                        else
                                        {
                                            string CheckForMinhayeIntiqalDependency = Intiqal.GetIntiqalSellerStatusHisaRaqba(row["PersonId"].ToString(), row["KhewatGroupFareeqId"].ToString(), "0", row["FardAreaPart"].ToString());
                                            if (CheckForMinhayeIntiqalDependency == "0")
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
                                            else
                                            {
                                                MessageBox.Show("اپکا انتخاب کردہ بائع پہلے سے انتقال نمبر " + CheckForMinhayeIntiqalDependency + " میں محفوظ ہو چکا ہے۔ اگر اس بائع کا دوسرا انتقال کروانا چاہتے ہو تہ مزکورہ انتقال نمبر کو منہائے انتقال میں محفوظ کرو۔ ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearAll();
                                            }
                                        }
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

                if (this.txtFrokhtHisay.Text.Trim() == string.Empty)
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

                    if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
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
                                if (this.cboPersonSeller.SelectedValue.ToString() == row.Cells["KhewatGroupFareeqId"].Value.ToString())
                                {
                                    isExists = true;

                                    MessageBox.Show("ریکارڈ پہلے سے موجود ہئے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }

                        }
                        if (!isExists)
                        {
                              //  frmGainTax fr = new frmGainTax(); fr.Personid=IntiqalSellerPersonId;//set for gain tax
                            string lastid = Intiqal.SaveintiqalSellers(IntiqalSellerRecId,
                                          IntiqalKhataRecId, IntiqalSellerPersonId,
                                          SellerPersonDied, SellerPersonDeathDate,

                                          Seller_Total_Hissa, Seller_Total_Kanal, Seller_Total_Marla, Seller_Total_Sarsai, Seller_Total_Feet
                                         , Seller_Sold_Hissa, Seller_Sold_Kanal, Seller_Sold_Marla, Seller_Sold_Sarsai, Seller_Sold_Feet, KhewatGroupFareeqId, MushtriFareeqId, KhatoniRecid);

                            if (lastid != "0")
                            {
                                MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtSellerID.Text = lastid;
                                proc_Get_Intiqal_Sellers_List_ByKhata(IntiqalKhataRecId, KhatoniRecid);
                                btnDelSeller.Enabled = true;
                                ClearAll();
                                CalculateSellerBuyerRaqbaHissa();
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
                    bSars += row.Cells["Buyer_Sarsai"].Value != null ? Convert.ToDecimal(row.Cells["Buyer_Sarsai"].Value.ToString()) : 0;
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
                GridBuyersList.DataSource = dt;
                BuyerGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyerGrid()
        {
            if (GridBuyersList.DataSource != null)
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
                GridBuyersList.Columns["KhewatTypeId"].Visible = false;
                GridBuyersList.Columns["chk1"].DisplayIndex = 0;
                GridBuyersList.Columns["chk1"].Width = 100;
                GridBuyersList.Columns["Buyer_Hissa"].Width = 100;
                GridBuyersList.Columns["Buyer_Area"].Width = 100;
            }

            this.setRowNumber(GridBuyersList);
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
                if (txtnameKharidar.Text.Trim() != "" && txtKharidHisay.Text.Trim() != "" && txtKharidKanal.Text.Trim() != "" && txtKharidMarla.Text.Trim() != "" && txtKharidSarsai.Text.Trim() != "" && txtKharidFeet.Text != "" && Convert.ToInt32(cboKhewatType.SelectedValue) > 0)
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

                string s = inteq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, buyerhissay.ToString(), buyerkanal, buyermarla, buyersarsai.ToString(), buyerfeet.ToString(), khewattypeid, buerHisabata).FirstOrDefault().ToString();


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
                    frmTestMalkanSelcIntiqalWirasath frmTMSIW = new frmTestMalkanSelcIntiqalWirasath();
                    frmTMSIW.khewatTypeId = cboKhewatType.SelectedValue.ToString();
                    frmTMSIW.IntiqalBuyerRecId = txthiddenBuyerRecId.Text;
                    frmTMSIW.FormClosed -= new FormClosedEventHandler(frmTMSIW_closed);
                    frmTMSIW.FormClosed += new FormClosedEventHandler(frmTMSIW_closed);
                    frmTMSIW.KhatoniRecid = KhatoniRecid;
                    frmTMSIW.IntiqalKhataRecId = this.IntiqalKhataRecId;
                    frmTMSIW.MozaId = this.MozaId.ToString();
                    frmTMSIW.ShowDialog();
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
        void frmTMSIW_closed(object sender, FormClosedEventArgs e)
        {
            FillgridByBuyerList();
        }
        private void txtKharidHisay_Leave(object sender, EventArgs e)
        {
            if (txtKharidHisay.Text.Trim() != "" && txtKharidHisay.Text != "0")
            {
                CalulateBuyerArea_FromHissa();
            }
            else
            {
                txtKharidKanal.Text = "0";
                txtKharidMarla.Text = "0";
                txtKharidSarsai.Text = "0";
                txtKharidFeet.Text = "0";
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
            if (dt != null)
            {
                GridIntiqalKhattaJatforMin.DataSource = dt;
                GridIntiqalKhattaJatforMin.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                GridIntiqalKhattaJatforMin.Columns["IntiqalId"].Visible = false;
                GridIntiqalKhattaJatforMin.Columns["IntiqalKhataId"].Visible = false;
                GridIntiqalKhattaJatforMin.Columns["IntiqalKhataRecId"].Visible = false;
            }
        }

        public void FillGridMalikan()
        {
            DataTable dt = new DataTable();
            if (cboMinGroups.SelectedIndex > 0)
            {
                dt = inteq.GetIntiqalMinFareeqain(IntiqalId, cboMinGroups.SelectedValue.ToString());
                gridmalikan.DataSource = dt;
                if (dt != null)
                {
                    gridmalikan.Columns["CompleteName"].HeaderText = "نام مالک";
                    gridmalikan.Columns["Intiqal_Min_Hissa"].HeaderText = "انتقال من حصہ";
                    gridmalikan.Columns["IntiqalMinArea"].HeaderText = "انتقال من رقبہ";
                    gridmalikan.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                    gridmalikan.Columns["IntiqalMinKhewatFareeqId"].Visible = false;
                    gridmalikan.Columns["SeqNo"].Visible = false;
                    gridmalikan.Columns["IntiqalMinPersonId"].Visible = false;
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
                dtk = inteq.GetIntiqalMinKhassraJat(IntiqalId, cboMinGroups.SelectedValue.ToString());
                gridkhasrajat.DataSource = dtk;
                if (dtk != null)
                {
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

        private void GridSellerList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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
                        if (Intiqal.CheckMalikRemainingHissaCheck(this.IntiqalId) == "1")
                        {
                            // Seller area and hissa is according to save values in seller table

                            {

                                Intiqal.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId);

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
                string Registerkid = taqseemnewkhata.WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta(txtRegHaqKhataID.Text.ToString(), RegisterHqId, kNo, Taraf, Pati, hissay, kannal, marala, sarsai, feet, malia, kefiat, MozaId.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), txtparentKhataId.Text, ParentKhataID);
                string minGroupId = inteq.SaveIntiqalMinGroup("-1", IntiqalId, this.IntiqalKhataId, "1", kNo, "0", "0", "0", hissay, kannal, marala, sarsai, feet, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName, MozaId.ToString());
                txtRegHaqKhataID.Text = Registerkid;
                RegisterHqDKhataId = Registerkid;
                if (RegisterHqDKhataId != null)
                {
                    AutoComplete on = new AutoComplete();
                    on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID " + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
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

        #region Get Khatooni For Khassrajat Drop Down   

        public void Fillkhatoniforkhasra()
        {

            string khataid = RegisterHqDKhataId;
            AutoComplete on = new AutoComplete();
            on.FillCombo("Proc_Get_Khatoonis " + RegisterHqDKhataId + "", this.cmbkhatoonisnew, "KhatooniNo", "KhatooniId");

        }
        #endregion

        #region Button Select Malak from Bayan/Mushteryan etc

        private void btnGetChangeMalikan_Click(object sender, EventArgs e)
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
                if (dt != null)
                {
                    grdMushtrianMalinkanChange.Columns["chk_change_Malikan"].DisplayIndex = 0;
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


            }
            else
            {
                dt = this.taqseemnewkhata.Proc_Get_KhewatFareeqeinByKhataId("0");
                grdMushtrianMalinkanChange.DataSource = dt;
                if (dt != null)
                {
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
            this.txthissamaifarqbox18.Text = farq.ToString();
        }

        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            if (tabControl1.SelectedIndex == 4)
            {
                AutoComplete on = new AutoComplete();
                on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID " + MozaId + "," + txtparentKhataId.Text + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                AutoComplete ac = new AutoComplete();
                ac.FillCombo("Proc_Get_Intiqal_MinGroupsList " + this.IntiqalId + "," + this.IntiqalKhataId + ",0", cboMinGroups, "IntiqalMinGroupNo", "IntiqalMinGroupId");
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
                FillGridMalikanChange();
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

        #region Get Khatooni Data by Khata

        public void FillGridKhatooniChange()
        {
            try
            {



                string khataid = RegisterHqDKhataId;
                dt = taqseemnewkhata.Proc_Get_Khatoonis(RegisterHqDKhataId.ToString());
                grdGetkhatonichange.DataSource = dt;
                if (dt != null)
                {
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

                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                    {

                        row.Cells["chkkk"].Value = 1;
                    }

                    else
                    {
                        row.Cells["chkkk"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
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
                string KhatooniLagan = this.txtlagan.Text != null ? (this.txtlagan.Text.ToString()) : "";
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
            getkhasrajatbykhatoni();
        }

        #endregion


        #region Fill New Khassrajat 

        public void FillKhasraJatNew()
        {
            string khatooniid = cmbkhatoonisnew.SelectedValue.ToString();
            dt = taqseemnewkhata.Proc_Get_KhatooniKhassraDetail(khatooniid.ToString());
            this.grdNewKhasrajat.DataSource = dt;
            if (dt != null)
            {
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

        #region Button Delete New Khatooni Click Event

        private void btnDeleteKhatoonichange_Click(object sender, EventArgs e)
        {

            this.taqseemnewkhata.WEB_SP_DELETE_KhatooniRegister(this.txtNewkhatooniId.Text); //grdGetkhatonichange.CurrentRow.Cells["KhatooniId"].Value.ToString());
            MessageBox.Show("  کھتونی حذف ہوگیا ہے", "", MessageBoxButtons.OK);
            FillGridKhatooniChange();
        }

        #endregion

        #region Button Delete New Khassra Click event

        private void button8_Click(object sender, EventArgs e)
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

        #region Button Delete New Khata Taqseen Click Event

        private void btnDeleteChange_Click(object sender, EventArgs e)
        {
            if (this.txtRegHaqKhataID.Text != "")
            {
                try
                {
                    inteq.DeleteRegisterHaqdaranKhattaByKhataId(this.txtRegHaqKhataID.Text);
                    AutoComplete on = new AutoComplete();
                    on.FillCombo("Proc_Get_Moza_Register_KhataJat_ParentKhataID " + MozaId + "," + ParentKhataID + "", cmbtaqseemChangeKhata, "KhataNo", "RegisterHqDKhataId");
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
            txtkulhisabox16.Text = txthissayChagne.Text != null ? txthissayChagne.Text : "0";
            txtkulraqbabox17.Text = this.txtKanalChange.Text + "-" + this.txtMarlayChange.Text + "-" + this.txtSarsasiChange.Text;
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
                                AutoFillCombo.FillCombo("Proc_Get_Khatoonis " + khataId, cmbKhatooniListforKhassras, "KhatooniNo", "KhatooniId");
                            }
                        }
                    }
                }
                else
                {
                    gbJuzviSalamKhassraEntry.Visible = true;
                    string khataId = GridViewInteqalKhattas.SelectedRows[0].Cells["IntiqalKhataId"].Value.ToString();
                    AutoFillCombo.FillCombo("Proc_Get_Khatoonis " + khataId, cmbKhatooniListforKhassras, "KhatooniNo", "KhatooniId");
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

                        Intiqal.IntiqalAmalDaramad(this.MozaId.ToString(), this.IntiqalId);
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

                if (GridViewInteqalKhattas.Rows.Count > 1)
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
                else
                {
                    MessageBox.Show("یہ سہولت صرف ایک سے زیادہ کھاتے کے لیے کارامد ہے", "مندرجہ کھاتہ وارثان");
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
                FillGridMalikanChange();
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
                gridviewSalamjuzviKhassraList.DataSource= Intiqal.GetKhassrasByKhatoni(cmbKhatooniListforKhassras.SelectedValue.ToString());
                if (gridviewSalamjuzviKhassraList.DataSource != null)
                {
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
            if (GridviewSaveSalamJuzviKhassra.DataSource!=null)
            {
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
    }
}

















