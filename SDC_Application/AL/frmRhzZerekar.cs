﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmRhzZerejar : Form
    {
        #region Class Variables

        Intiqal intiqal = new Intiqal();
        RhzZerekar misal = new RhzZerekar();
        AutoComplete objauto = new AutoComplete();
        RhzZerekrKhatas khatas = new RhzZerekrKhatas();
        KhatooniesZerekar Khatooni = new KhatooniesZerekar();

        // Data Tables //----------
        DataTable dtkj = new DataTable();
        DataTable dtFardBadar = new DataTable();
        DataTable dtKhewatFareeqain = new DataTable();
        DataTable dtKhewatFareeqainAll = new DataTable();
        DataTable dtMushteriFareeqain = new DataTable();
        DataTable dtMushteriFareeqainSel = new DataTable();
        Khatoonies khatooni = new Khatoonies();
        DataView dtvKhewatFareeqainByPerson = new DataView();

        DataView viewMF;
        DataView view;
        DataView viewAll;
        DataView viewKhassra;
        DataView viewMushteryan;
        // --------- /// ----------//

        public string MozaId { get; set; }
        LanguageConverter lang = new LanguageConverter();
        CommanFunctions cfs = new CommanFunctions();
        public string KhataId { get; set; }
        public string ScanDataPath { get; set; }

        #endregion

        public frmRhzZerejar()
        {
            InitializeComponent();
        }

        private void frmRhzAmaladaramad_Load(object sender, EventArgs e)
        {
            ScanDataPath = System.Configuration.ConfigurationSettings.AppSettings["ScanData"];
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Khata_DropDown();
        }

        #region Fill Grid view method

        public void Fill_Khata_DropDown()
        {
            try
            {
              
                dtkj = misal.GetKhatajatByMoza(Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
                DataRow inteqKj = dtkj.NewRow();
                if (inteqKj != null)
                {
                    inteqKj["RegisterHqDKhataId"] = "0";
                    inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                    dtkj.Rows.InsertAt(inteqKj, 0);
                    cbokhataNo.DataSource = dtkj;
                    cbokhataNo.DisplayMember = "KhataNo";
                    cbokhataNo.ValueMember = "RegisterHqDKhataId";
                    cbokhataNo.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Combo Khata No Selection Change Event

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgKhatooniBayan.DataSource = null;
            dgKhatooniKhassras.DataSource = null;
            dgKhewatFareeqainAll.DataSource = null;
            dgMushteriFareeqainAll.DataSource = null;
            dgMushteriFareeqainDetails.DataSource = null;
            this.txtParentKhata.Clear();
            this.ClearKhatooniControls();
            if (dtkj != null)
            {
                foreach (DataRow row in dtkj.Rows)
                {
                    if ((row["RegisterHqDKhataId"].ToString() == cbokhataNo.SelectedValue.ToString()) && cbokhataNo.SelectedValue.ToString() != "0")
                    {
                        this.txtKhataHissa.Text = row["TotalParts"].ToString();
                        txtKhataMeezanKulHissay.Text = row["TotalParts"].ToString();
                        this.txtKhataKanal.Text = row["Kanal"].ToString();
                        txtKhataMarla.Text = row["Marla"].ToString();
                        txtKhataSarsai.Text = row["sarsai"].ToString();
                        txtKhataSFT.Text = Math.Round(float.Parse(row["sarsai"].ToString()) * (float)30.25, 0).ToString();
                        txtKhataMeezanRaqba.Text = txtKhataKanal.Text + "-" + txtKhataMarla.Text + "-" + txtKhataSarsai.Text;
                        txtKhataKifiat.Text = row["Kyfiat"].ToString();
                        this.KhataId = row["RegisterHqDKhataId"].ToString();
                        LoadDataByKhata();
                        FillKhatooniList();
                        this.LoadKhewatFareeqainMeezan(cbokhataNo.SelectedValue.ToString());
                        tabControl1.Enabled = true;
                        this.LoadKhataLockDetails(cbokhataNo.SelectedValue.ToString());
                        break;
                    }
                    else
                    {
                        this.txtKhataHissa.Clear();
                        this.txtKhataKanal.Clear();
                        txtKhataMarla.Clear();
                        txtKhataSarsai.Clear();
                        txtKhataSFT.Clear();
                        txtKhataKifiat.Clear();
                        this.KhataId = "0";
                        tabControl1.Enabled = false;
                    }
                }
            }
            else
            {
                this.txtKhataHissa.Clear();
                this.txtKhataKanal.Clear();
                txtKhataMarla.Clear();
                txtKhataSarsai.Clear();
                txtKhataSFT.Clear();
                txtKhataKifiat.Clear();
                this.KhataId = "0";
                tabControl1.Enabled = false;
            }
        }

        #region Load Data By Khatta Id

        private void LoadKhewatFareeqainMeezan(string KhataId)
        {
            DataTable dtKhewatFareeqainMeezan = khatooni.GetKhewatFareeqainMeezan(KhataId);
            if (dtKhewatFareeqainMeezan != null)
            {
                foreach (DataRow row in dtKhewatFareeqainMeezan.Rows)
                {
                    this.txtKhataMeezanKhewatFareeqainHissay.Text = row["TotalHissa"].ToString();
                    this.txtKhataMeezanKhewatFareeqainRaqba.Text = row["TotalRaqba"].ToString();
                    if (Math.Round(decimal.Parse(this.txtKhataMeezanKhewatFareeqainHissay.Text), 4) != Math.Round(decimal.Parse(this.txtKhataMeezanKulHissay.Text), 4))
                    {
                        txtKhataMeezanKhewatFareeqainHissay.BackColor = Color.Red;
                    }
                    else { txtKhataMeezanKhewatFareeqainHissay.BackColor = Color.White; }
                }
            }
            else
            {
                this.txtKhataMeezanKhewatFareeqainHissay.Clear();
                this.txtKhataMeezanKhewatFareeqainRaqba.Clear();
            }
            txtKhataMeezanKhassraRaqba.Text=intiqal.GetKhassraTotalRaqbaByKhattaId(KhataId);
        }

        private void LoadKhataLockDetails(string KhataId)
        {
            DataTable dtKhataLock = khatooni.GetKhataLockindDetailsByKhataId(KhataId);
            if (dtKhataLock == null)
            {
                foreach (DataRow row in dtKhataLock.Rows)
                {
                    if (Convert.ToBoolean(row["RecordLocked"].ToString()))
                    {

                        chkKhataLocked.Checked = true;
                        //txtKhataLocking.Text = row["RecordLockedDetails"].ToString();
                        //txtKhataLocking.Visible = true;
                    }
                    else
                    {
                        chkKhataLocked.Checked = false;
                        //txtKhataLocking.Clear();
                        //txtKhataLocking.Visible = false;
                    }
                    txtKhataLocking.Visible = true;
                    txtKhataLocking.Text = row["RecordLockedDetails"].ToString();
                }

                txtKhataMeezanKhassraRaqba.Text = intiqal.GetKhassraTotalRaqbaByKhattaId(KhataId);
            }
        }

        private void LoadDataByKhata()
        {
            
        }
        #endregion

        #endregion

        #region Khewat Group Fareeqain Portion


        private void btnShowCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtKhewatFareeqain = khatas.Proc_Self_Get_KhewatFareeqeinByKhataId(this.KhataId);
                this.dgKhewatFareeqainAll.DataSource = dtKhewatFareeqain;
                view = new DataView(dtKhewatFareeqain);
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void btnShowPrevious_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.dtKhewatFareeqainAll = intiqal.GetKhewatFareeqeinGroupByKhataPrevious(this.KhataId);
            //    this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainAll;
            //    viewAll = new DataView(dtKhewatFareeqainAll);
            //    this.PopulateGridViewKhewatMalkanAll(dgKhewatFreeqDetails, false);
            //} 
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        #endregion

        #region Fill Gridview Malkan by Khata

        private void PopulateGridViewKhewatMalkanAll(DataGridView g, Boolean All)
        {
            try
            {
                if (g.DataSource != null)
                {
                    g.Columns["FardAreaPart"].HeaderText = "حصہ";
                    g.Columns["Khewat_Area"].HeaderText = "رقبہ";
                    g.Columns["PersonName"].HeaderText = "نام مالک";
                    g.Columns["CNIC"].HeaderText = "شناختی نمبر";
                    g.Columns["KhewatType"].HeaderText = "قسم مالک";
                    g.Columns["FardPart_Bata"].Visible = false;
                    g.Columns["seqno"].HeaderText = "نمبر شمار";
                    g.Columns["KhewatGroupFareeqId"].Visible = false;
                    g.Columns["KhewatGroupId"].Visible = false;
                    g.Columns["PersonId"].Visible = false;
                    g.Columns["KhewatTypeId"].Visible = false;
                    g.Columns["RecStatus"].HeaderText = "حالت";
                    g.Columns["PersonName"].DisplayIndex = 2;
                    g.Columns["KhewatType"].DisplayIndex = 3;
                    g.Columns["seqno"].DisplayIndex = 1;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region KhewatFareeqain Search text boxes
        
        #endregion

        private void txtSearchCurrentKhewatFareeqain_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchCurrentKhewatFareeqain.Text.ToString();
            if (view != null)
            {
                view.RowFilter = "PersonName LIKE '%" + filter + "%'";
                dgKhewatFareeqainAll.DataSource = view;
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
            }
        }

  

        private void txtSearchCurrentKhewatFareeqain_KeyPress(object sender, KeyPressEventArgs e)
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
        #region Khatoonies Controls and Methods
        private void FillKhatooniList()
        {
            try
            {
                DataTable KhatooniesByKhata = new DataTable();
                string KhataId =cbokhataNo.SelectedValue.ToString();
               // MessageBox.Show(KhataId);
                KhatooniesByKhata = khatooni.GetKhatooniNosListbyKhataId(KhataId.ToString());
                if (KhatooniesByKhata != null)
                {
                    DataRow row = KhatooniesByKhata.NewRow();
                    row["KhatooniId"] = 0;
                    row["KhatooniNo"] = "- کھتونی کا انتخاب کریں -";
                    KhatooniesByKhata.Rows.InsertAt(row, 0);
                    cboKhatoonies.DataSource = KhatooniesByKhata;
                    cboKhatoonies.DisplayMember = "KhatooniNo";
                    cboKhatoonies.ValueMember = "KhatooniId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region MushterFareeqain Gridview Population
        private void PopulateGrid(DataGridView g)
        {
            try
            {
                if (g.DataSource != null)
                {
                    g.Columns["FardAreaPart"].HeaderText = "حصہ";
                    g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                    g.Columns["CompleteName"].HeaderText = "نام مالک";
                    g.Columns["KhewatType"].HeaderText = "قسم مالک";
                    g.Columns["FardPart_Bata"].Visible = false;
                    g.Columns["seqno"].HeaderText = "نمبر شمار";
                    g.Columns["MushtriFareeqId"].Visible = false;
                    g.Columns["KhatooniId"].Visible = false;
                    g.Columns["PersonId"].Visible = false;
                    g.Columns["KhewatTypeId"].Visible = false;
                    g.Columns["RecStatus"].HeaderText = "حالت";
                    g.Columns["CompleteName"].DisplayIndex = 2;
                    g.Columns["KhewatType"].DisplayIndex = 3;
                    g.Columns["seqno"].DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cboKhatoonies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboKhatoonies.SelectedValue.ToString() != "0")
                {
                    this.panelKhassra.Enabled = true;
                    DataTable KhatooniDetail = khatooni.GetKhatooniDetailbyKhatooniId(cboKhatoonies.SelectedValue.ToString());
                    if (KhatooniDetail != null)
                    {
                        foreach (DataRow row in KhatooniDetail.Rows)
                        {
                            txtKhatooniLagan.Text = row["KhatooniLagan"].ToString();
                            txtWasailAbpashi.Text = row["Wasail_e_Abpashi"].ToString();
                            txtKhatooniFullDeatils.Text = row["KhatooniKashtkaranFullDetail_New"].ToString();
                            chkBeahShoda.Checked = Convert.ToBoolean(row["BeahShud"].ToString());
                            if (chkBeahShoda.Checked)
                            {
                                txtKhatooniHissa.Text = row["KhatooniHissa"].ToString();
                                txtKhatooniKanal.Text = row["KhatooniKanal"].ToString();
                                txtKhatooniMarla.Text = row["KhatooniMarla"].ToString();
                                txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString();
                                txtKhatooniFeet.Text = row["KhatooniFeet"].ToString();

                            }
                        }

                        this.GetKhatooniMushteryan(cboKhatoonies.SelectedValue.ToString());
                        this.GetKhatooniBayan(cboKhatoonies.SelectedValue.ToString());
                    }
                }
                else
                {
                    this.ClearKhatooniControls();
                    this.panelKhassra.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Clear Khatooni Controls

        private void ClearKhatooniControls()
        {
            txtKhatooniLagan.Clear();
            txtWasailAbpashi.Clear();
            txtKhatooniFullDeatils.Clear();
            chkBeahShoda.Checked = false;
            txtKhatooniHissa.Text = "";
            txtKhatooniKanal.Text = "";
            txtKhatooniMarla.Text = "";
            txtKhatooniSarsai.Text = "";
            txtKhatooniFeet.Text = "";
            this.dgMushteriFareeqainAll.DataSource = null;
            
            this.dgKhatooniBayan.DataSource = null;
            this.dgKhatooniKhassras.DataSource = null;
        }

        #endregion

        private void GetKhatooniMushteryan(string KhatooniId)
        {
            try
            {
                //DataTable mushteryanCUrrent = khatooni.Get_MushtriFareeqein_By_KhatooniId(KhatooniId);
                DataTable mushteryanCUrrent = khatooni.Get_MushtriFareeqein_By_Khatooni_All_Status(KhatooniId);
                dgMushteriFareeqainAll.DataSource = mushteryanCUrrent;
                viewMF = new DataView(mushteryanCUrrent);
                PopulateGrid(dgMushteriFareeqainAll);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetKhatooniBayan(string KhatooniId)
        {
            try
            {
                DataTable dtKhatooniBayan = khatooni.GetKhatooniBayanByKhatooniId(KhatooniId);
                dgKhatooniBayan.DataSource = dtKhatooniBayan;
                if (dtKhatooniBayan != null)
                {
                    dgKhatooniBayan.Columns["CompleteName"].HeaderText = "نام مالک";
                    dgKhatooniBayan.Columns["KhewatFareeq_Sold_Hissa"].HeaderText = "بیع کردہ حصہ";
                    dgKhatooniBayan.Columns["KhewatFareeq_Sold_Kanal"].HeaderText = "بیع کنال";
                    dgKhatooniBayan.Columns["KhewatFareeq_Sold_Marla"].HeaderText = "بیع مرلہ";
                    dgKhatooniBayan.Columns["KhewatFareeq_Sold_Sarsai"].HeaderText = "بیع سرسائی";
                    dgKhatooniBayan.Columns["KhewatFareeq_Sold_Feet"].HeaderText = "بیع فٹ";
                    dgKhatooniBayan.Columns["Khatooni_Area_KMSqft"].HeaderText = "کل رقبہ";
                    dgKhatooniBayan.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatGroupFareeqId"].Visible = false;
                    dgKhatooniBayan.Columns["PersonId"].Visible = false;
                    dgKhatooniBayan.Columns["RegisterHqDKhataId"].Visible = false;
                    dgKhatooniBayan.Columns["KhatooniId"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatFareeq_Total_Hissa"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatFareeq_Total_Kanal"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatFareeq_Total_Marla"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatFareeq_Total_Sarsai"].Visible = false;
                    dgKhatooniBayan.Columns["KhewatFareeq_Total_Feet"].Visible = false;
                    dgKhatooniBayan.Columns["Khatooni_Area_KMSr"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnLoadKhassras_Click(object sender, EventArgs e)
        {
            try
            {
            DataTable dtKhassras = new DataTable();
            dtKhassras = khatooni.GetKhassrajatByKhatooniId(cboKhatoonies.SelectedValue.ToString());
            dgKhatooniKhassras.DataSource = dtKhassras;
            this.viewKhassra = new DataView(dtKhassras);
            this.PopulateKhassraGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateKhassraGrid()
        {
            if (dgKhatooniKhassras != null)
            {
                dgKhatooniKhassras.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                dgKhatooniKhassras.Columns["AreaType"].HeaderText = "قسم آراضی";
                dgKhatooniKhassras.Columns["Kanal"].HeaderText = "کنال";
                dgKhatooniKhassras.Columns["Marla"].HeaderText = "مرلہ";
                dgKhatooniKhassras.Columns["Sarsai"].HeaderText = "سرسائی";
                dgKhatooniKhassras.Columns["Feet"].HeaderText = "مربع فٹ";
                dgKhatooniKhassras.Columns["KhatooniId"].Visible = false;
                dgKhatooniKhassras.Columns["KhassraId"].Visible = false;
                dgKhatooniKhassras.Columns["KhassraDetailId"].Visible = false;
                dgKhatooniKhassras.Columns["AreaTypeId"].Visible = false;
            }
        }

        private void txtSearchKhassras_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhassras.Text.ToString();
            if (viewKhassra != null)
            {
                viewKhassra.RowFilter = "KhassraNo LIKE '%" + filter + "%'";
                dgKhatooniKhassras.DataSource = viewKhassra;
                this.PopulateKhassraGrid();
            }
        }

        #endregion

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void PopulateGridViewKhewatGroupFareeqainLock(DataGridView g)
        {
            g.Columns["SeqNo"].HeaderText = "نمبر شمار";
            g.Columns["CompleteName"].HeaderText = "نام مالک";
            g.Columns["FardAreaPart"].HeaderText = "حصہ";
            g.Columns["FardArea"].HeaderText = "رقبہ";
            g.Columns["RecordLockedString"].HeaderText = "حالت لاک";
            g.Columns["RecordLockingDetails"].HeaderText = "لاک تفصیل";
            g.Columns["RecordLockDate"].HeaderText = "تاریخ لاک";
            g.Columns["KhewatGroupFareeqId"].Visible = false;
            g.Columns["PersonId"].Visible = false;
            g.Columns["RecordLocked"].Visible = false;

        }

       
        

        #region Gridview Khewat group fareeqain Cell Click Event

        private void dgKhewatFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgKhewatFareeqainAll.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            string personId = row.Cells["PersonId"].Value.ToString();
                            string khataId = cbokhataNo.SelectedValue.ToString();
                            DataTable dtKhewatFareeqainByPerson = new DataTable();
                            dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(khataId, personId);

                        }
                        else
                        {
                            row.Cells[0].Value = 0;
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

        #region Fill Gridview Mushteryan by Person Id for Single Malk History and Details

        private void PopulateGridviewMushteriFareeqByPersonId()
        {
            try
            {
                if (dgMushteriFareeqainDetails.DataSource != null)
                {
                    dgMushteriFareeqainDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                    dgMushteriFareeqainDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                    dgMushteriFareeqainDetails.Columns["PersonName"].HeaderText = "نام مالک";
                    dgMushteriFareeqainDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                    dgMushteriFareeqainDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                    dgMushteriFareeqainDetails.Columns["IntiqalId"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                    dgMushteriFareeqainDetails.Columns["SellerBuyer"].HeaderText = "حیثیت";
                    dgMushteriFareeqainDetails.Columns["KhewatType"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["FardPart_Bata"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                    dgMushteriFareeqainDetails.Columns["MushtriFareeqId"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["KhatooniId"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["PersonId"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["KhewatTypeId"].Visible = false;
                    dgMushteriFareeqainDetails.Columns["RecStatus"].HeaderText = "حالت";
                    dgMushteriFareeqainDetails.Columns["PersonName"].DisplayIndex = 2;
                    dgMushteriFareeqainDetails.Columns["TransactionType"].DisplayIndex = 3;
                    dgMushteriFareeqainDetails.Columns["seqno"].DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Gridview MushteriFareeqainALL cell click event

        private void dgMushteriFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (g.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            string personId = row.Cells["PersonId"].Value.ToString();
                            string KhatooniId = row.Cells["KhatooniId"].Value.ToString();
                            DataTable dtMushteriFareeqainByPerson = new DataTable();
                            dtMushteriFareeqainByPerson = khatooni.MushteriFareeqByKhatooniIdPersonId(KhatooniId, personId);
                            this.dgMushteriFareeqainDetails.DataSource = dtMushteriFareeqainByPerson;
                            PopulateGridviewMushteriFareeqByPersonId();

                        }
                        else
                        {
                            row.Cells[0].Value = 0;
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

        #region Fill Gridview Mushteryan by Khata

        private void PopulateGridViewMushteryanAll()
        {
            if (dgMushteriFareeqainAll != null)
            {
                dgMushteriFareeqainAll.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgMushteriFareeqainAll.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                dgMushteriFareeqainAll.Columns["CompleteName"].HeaderText = "نام مالک";
                dgMushteriFareeqainAll.Columns["KhewatType"].HeaderText = "قسم مالک";
                dgMushteriFareeqainAll.Columns["FardPart_Bata"].Visible = false;
                dgMushteriFareeqainAll.Columns["seqno"].HeaderText = "نمبر شمار";
                dgMushteriFareeqainAll.Columns["MushtriFareeqId"].Visible = false;
                dgMushteriFareeqainAll.Columns["KhatooniId"].Visible = false;
                dgMushteriFareeqainAll.Columns["PersonId"].Visible = false;
                dgMushteriFareeqainAll.Columns["KhewatTypeId"].Visible = false;
                dgMushteriFareeqainAll.Columns["RecStatus"].HeaderText = "حالت";
                dgMushteriFareeqainAll.Columns["CompleteName"].DisplayIndex = 2;
                dgMushteriFareeqainAll.Columns["KhewatType"].DisplayIndex = 3;
                dgMushteriFareeqainAll.Columns["seqno"].DisplayIndex = 1;
            }
        }

        #endregion

        private void txtSearchKhanakasht_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhanakasht.Text.ToString();
            if (viewMF != null)
            {
                viewMF.RowFilter = "CompleteName LIKE '%" + filter + "%'";
                this.dgMushteriFareeqainAll.DataSource = viewMF;
                this.PopulateGridViewMushteryanAll();
            }
        }

        #region Textbox Search from Grid Key press event for auto eng to Urdu Conversion

        private void txtSearchFromGrid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnShowScanImg_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString().Length > 3 && cbokhataNo.SelectedValue.ToString().Length > 5)
            {
                string[] khataNo = cbokhataNo.Text.Split('/');
                string url = @""+ScanDataPath+"?mozaId=" + cmbMouza.SelectedValue.ToString() + "&documentTypeId=11&recordNo=" + khataNo[0];
                frmImageViewerBrowser iv = new frmImageViewerBrowser();
                iv.url = url;
                iv.Show();
                ///System.Diagnostics.Process.Start(url);
            }
            else
                MessageBox.Show("موضع اور انتقال نمبر درج کرکے سکین دستاویز دیکھئے۔");
        }
       
    }
}
