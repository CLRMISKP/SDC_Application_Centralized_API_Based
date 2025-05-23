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
    public partial class frmRhzAmaladaramad : Form
    {
        #region Class Variables

        Intiqal intiqal = new Intiqal();
        Misal misal = new Misal();
        AutoComplete objauto = new AutoComplete();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        Khatoonies Khatooni = new Khatoonies();

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
        DataView viewIntiqalAmal;
        DataView viewIntiqalPending;
        DataView viewIntiqalPendingKharij;
        DataView viewFardbader;
        // --------- /// ----------//

        public string MozaId { get; set; }
        LanguageConverter lang = new LanguageConverter();
        CommanFunctions cfs = new CommanFunctions();
        public string KhataId { get; set; }
        public string ScanDataPath { get; set; }

        #endregion

        public frmRhzAmaladaramad()
        {
            InitializeComponent();
        }

        private void frmRhzAmaladaramad_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            ScanDataPath = System.Configuration.ConfigurationSettings.AppSettings["ScanData"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_SDC_TokenPurpose_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cboTokenPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
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
                if (dtkj != null)
                {
                    DataRow inteqKj = dtkj.NewRow();
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
            this.txtParentKhata.Clear();
            this.ClearKhatooniControls();
            txtKhataMeezanKhassraRaqba.Clear();
            txtKhataMeezanKhewatFareeqainHissay.Clear();
            this.txtKhataMeezanKhewatFareeqainHissay.BackColor = Color.White;
            txtKhataMeezanKhewatFareeqainRaqba.Clear();
            txtKhataMeezanKulHissay.Clear();
            txtKhataMeezanRaqba.Clear();
            this.dgKhewatFareeqainAll.DataSource = null;
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
                    this.panelSdcFard.Enabled = true;
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
                    this.panelSdcFard.Enabled = false;
                }
            }
        }

        #region Load Data By Khatta Id

        private void LoadKhewatFareeqainMeezan(string KhataId)        {
            
            DataTable dtKhewatFareeqainMeezan = khatooni.GetKhewatFareeqainMeezan(KhataId);
            if (dtKhewatFareeqainMeezan != null)
            {
                foreach (DataRow row in dtKhewatFareeqainMeezan.Rows)
                {
                    this.txtKhataMeezanKhewatFareeqainHissay.Text = row["TotalHissa"].ToString();
                    this.txtKhataMeezanKhewatFareeqainRaqba.Text = row["TotalRaqba"].ToString();
                    //this.txtKhataMeezanKhewatFareeqainHissay.Text = row["TotalHissa"].ToString();
                    //this.txtKhataMeezanKhewatFareeqainRaqba.Text = row["TotalRaqba"].ToString();
                    //decimal KhataHissas, malikanhissas;
                    //Decimal.TryParse(this.txtKhataMeezanKhewatFareeqainHissay.Text, System.Globalization.NumberStyles.Float, null, out malikanhissas);
                    //Decimal.TryParse(txtKhataMeezanKulHissay.Text, System.Globalization.NumberStyles.Float, null, out KhataHissas);

                    double KhataSQFT = (double.Parse(txtKhataKanal.Text) * 20 * (double)272.25) + (double.Parse(txtKhataMarla.Text) * (double)272.25) + double.Parse(txtKhataSFT.Text);
                    double differenceInSQFT = KhataSQFT / double.Parse(txtKhataMeezanKulHissay.Text) * Math.Abs(double.Parse(txtKhataMeezanKhewatFareeqainHissay.Text) - double.Parse(txtKhataMeezanKulHissay.Text)); // Calculate Raqba Difference

                    // if (Math.Round(malikanhissas, 4) != Math.Round(KhataHissas, 4))
                    if (Math.Round(differenceInSQFT, 0) >= 30)
                    {
                        txtKhataMeezanKhewatFareeqainHissay.BackColor = Color.Red;
                        txtKhataMeezanKhewatFareeqainHissay.ForeColor = Color.White;
                    }
                    else
                    {
                        txtKhataMeezanKhewatFareeqainHissay.BackColor = Color.White;
                        txtKhataMeezanKhewatFareeqainHissay.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                this.txtKhataMeezanKhewatFareeqainHissay.Text = "0";
                this.txtKhataMeezanKhewatFareeqainRaqba.Text = "0-0-0";
            }
            txtKhataMeezanKhassraRaqba.Text=intiqal.GetKhassraTotalRaqbaByKhattaId(KhataId);
        }

        private void LoadKhataLockDetails(string KhataId)
        {
            DataTable dtKhataLock = khatooni.GetKhataLockindDetailsByKhataId(KhataId);
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

        private void LoadDataByKhata()
        {
            this.GetKhataFardBadar();
            this.GetKhataIntiqalPending();
            this.GetKhataIntiqalImplemented();
            this.GetKhataParentKhata();
            this.GetKhataIntiqalPendingKharij();
        }
        #endregion

        #endregion

        #region Get Khata Fard Badar

        private void GetKhataFardBadar()
        {
            try
            {
                DataTable dtFardBadar = new DataTable();
                dtFardBadar = misal.GetFardBaderMainByKhataId(this.KhataId);
                if (dtFardBadar != null)
                {
                    viewFardbader = new DataView(dtFardBadar);
                    dgkhataFardbadar.DataSource = dtFardBadar;
                    dgkhataFardbadar.Columns["FB_DocumentNo"].HeaderText = " دستویز نمبر";
                    dgkhataFardbadar.Columns["FB_Date"].HeaderText = "بتاریخ";
                    dgkhataFardbadar.Columns["FB_Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
     
        }

        #endregion

        #region Get Khata Pending Mutations

        private void GetKhataIntiqalPending()
        {
            try
            {
            DataTable dtIntiqalPending = new DataTable();
            dtIntiqalPending = intiqal.GetIntiqalZeretajwizPendingByKhata(this.KhataId);
                if (dtIntiqalPending != null)
                {
                    viewIntiqalPending = new DataView(dtIntiqalPending);
                    dgKhataIntiqalPending.DataSource = dtIntiqalPending;
                    dgKhataIntiqalPending.Columns["IntiqalNo"].HeaderText = "نمبر";
                    dgKhataIntiqalPending.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                    dgKhataIntiqalPending.Columns["IntiqalPendingRemakrs"].HeaderText = " حالت";
                    dgKhataIntiqalPending.Columns["IntiqalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Khata Pending Kharej Manual Inc etc Mutations

        private void GetKhataIntiqalPendingKharij()
        {
            try
            {
                DataTable dtIntiqalPending = new DataTable();
                dtIntiqalPending = intiqal.GetIntiqalPenginKharijByKhata(this.KhataId);
                if (dtIntiqalPending != null)
                {
                    viewIntiqalPendingKharij = new DataView(dtIntiqalPending);
                    dgKhataIntiqalPenginKharej.DataSource = dtIntiqalPending;
                    dgKhataIntiqalPenginKharej.Columns["IntiqalNo"].HeaderText = "نمبر";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalPendingRemakrs"].HeaderText = " حالت";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Khata Implemented Mutations

        private void GetKhataIntiqalImplemented()
        {
            try
            {
                DataTable dtIntiqalInc = new DataTable();
                dtIntiqalInc = intiqal.GetIntiqalAmalDaramadShodaByKhata(this.KhataId);
                if (dtIntiqalInc != null)
                {
                    viewIntiqalAmal = new DataView(dtIntiqalInc);
                    dgKhataIntiqalAmaldaramad.DataSource = dtIntiqalInc;
                    dgKhataIntiqalAmaldaramad.Columns["IntiqalNo"].HeaderText = "نمبر";
                    dgKhataIntiqalAmaldaramad.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                    dgKhataIntiqalAmaldaramad.Columns["IntiqalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Khata Parent Khata

        private void GetKhataParentKhata()
        {
            try
            {
                DataTable dtParentKhata = new DataTable();
                dtParentKhata = intiqal.GetKhataNoByChildKhataId(this.KhataId);
                if (dtParentKhata != null)
                {
                    foreach (DataRow row in dtParentKhata.Rows)
                    {
                        txtParentKhata.Text = row["KhataNo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Khewat Group Fareeqain Portion


        private void btnShowCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtKhewatFareeqain = khatas.Proc_Self_Get_KhewatFareeqeinByKhataId(cbokhataNo.SelectedValue.ToString());
                this.dgKhewatFareeqainAll.DataSource = null;
                if(dtKhewatFareeqain!=null)
                {
                    this.dgKhewatFareeqainAll.DataSource = dtKhewatFareeqain;
                    view = new DataView(dtKhewatFareeqain);
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                }
                else
                {
                    MessageBox.Show("کوئی ریکارڈ نہیں ملا");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void btnShowPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtKhewatFareeqainAll = intiqal.GetKhewatFareeqeinGroupByKhataPrevious(this.KhataId);
                this.dgKhewatFreeqDetails.DataSource = null;
                if(dtKhewatFareeqainAll != null)
                {
                    this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainAll;
                    viewAll = new DataView(dtKhewatFareeqainAll);
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFreeqDetails, false);
                }
                else
                {
                    MessageBox.Show("کوئی ریکارڈ نہیں ملا");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Gridview Malkan by Khata

        private void PopulateGridViewKhewatMalkanAll(DataGridView g, Boolean All)
        {
            try
            {

                g.Columns["FardAreaPart"].HeaderText = "حصہ";
                g.Columns["Khewat_Area"].HeaderText = "رقبہ";
                g.Columns["PersonName"].HeaderText = "نام مالک";
                g.Columns["CNIC"].HeaderText = "شناختی /پاسپورٹ نمبر";
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
                if (!g.Columns.Contains("ColCnicUpdate"))
                {
                    DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                    col.Name = "ColCnicUpdate";
                    g.Columns.Add(col);
                    g.Columns["ColCnicUpdate"].HeaderText = "اندراج شناختی کارڈ";
                    
                }
                g.Columns["ColCnicUpdate"].DisplayIndex = g.Columns.Count - 1;

                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Cells["CNIC"].Value.ToString().Length > 5)
                    {
                        
                    }
                    else
                    {
                        row.Cells["ColCnicUpdate"].Value = "اندراج شناختی کارڈ";
                    }
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
                if (KhatooniesByKhata!=null)
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

            //g.Columns["CompleteName"].HeaderText = "نام مشتری";
            //g.Columns["KhewatType"].HeaderText = "قسم مالک";
            //g.Columns["FardAreaPart"].HeaderText = "حصہ";
            //g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
            //// Hide Columns
            //g.Columns["MushtriFareeqId"].Visible = false;
            //g.Columns["PersonId"].Visible = false;
            //g.Columns["SeqNo"].Visible = false;
            //g.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
            //g.Columns["KhatooniId"].Visible = false;
            //g.Columns["TransactionType"].Visible = false;
            //g.Columns["IntiqalId"].Visible = false;
            //g.Columns["MurthinId"].Visible = false;
            //g.Columns["KhewatTypeId"].Visible = false;
            //g.Columns["FardPart_Bata"].Visible = false;
            //g.Columns["Farad_Kanal"].Visible = false;
            //g.Columns["Fard_Marla"].Visible = false;
            //g.Columns["Fard_Sarsai"].Visible = false;
            //g.Columns["Fard_Feet"].Visible = false;
            //g.Columns["Mushtri_Area_KMSr"].Visible = false;


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
                    foreach (DataRow row in KhatooniDetail.Rows)
                    {
                        txtKhatooniHissa.Clear();
                        txtKhatooniKanal.Clear();
                        txtKhatooniMarla.Clear();
                        txtKhatooniSarsai.Clear();
                        txtKhatooniFeet.Clear();
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
                    btnLoadKhassras_Click(sender, e);
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
                if(mushteryanCUrrent != null)
                {
                    dgMushteriFareeqainAll.DataSource = mushteryanCUrrent;
                    viewMF = new DataView(mushteryanCUrrent);
                    PopulateGrid(dgMushteriFareeqainAll);
                }
                
                
               
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
                if (dtKhatooniBayan != null)
                {
                    dgKhatooniBayan.DataSource = dtKhatooniBayan;
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
                if (dtKhassras != null)
                {
                    dgKhatooniKhassras.DataSource = dtKhassras;
                    this.viewKhassra = new DataView(dtKhassras);
                    this.PopulateKhassraGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateKhassraGrid()
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


        #region Fard Purpose Combo Box Selection Change Event

        private void cboTokenPurpose_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                if (cboTokenPurpose.SelectedValue.ToString() != "0")
                {
                    if (chkFardDateFilter.Checked)
                    {
                        DataTable dtFardRecord = new DataTable();
                        dtFardRecord = khatooni.GetFardDetailsByKhataIdByTokenPurposeId(cbokhataNo.SelectedValue.ToString(), cboTokenPurpose.SelectedValue.ToString(), dtpStartDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), dtpEndDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
                        if(dtFardRecord!=null)
                        {
                            dgFardDetails.DataSource = dtFardRecord;
                            dgFardDetails.Columns["VisitorName"].HeaderText = "درخوست دہندہ";
                            dgFardDetails.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                            dgFardDetails.Columns["TokenDate"].HeaderText = "بتاریخ";
                            dgFardDetails.Columns["TokenPurpose_Urdu"].HeaderText = "مقصد";
                            dgFardDetails.Columns["KhewatMalikName"].HeaderText = "نام مالک";
                            dgFardDetails.Columns["TokenId"].Visible = false;
                            dgFardDetails.Columns["PVKhataId"].Visible = false;
                        }
                        else
                        {
                            dgFardDetails.DataSource = null;
                        }
                       
                    }
                    else
                    {
                       
                        DataTable dtFardRecord = new DataTable();
                        dtFardRecord = khatooni.GetFardDetailsByKhataIdByTokenPurposeId(cbokhataNo.SelectedValue.ToString(), cboTokenPurpose.SelectedValue.ToString(),"0", "0");
                       if(dtFardRecord != null)
                        {
                            dgFardDetails.DataSource = dtFardRecord;
                            dgFardDetails.Columns["VisitorName"].HeaderText = "درخوست دہندہ";
                            dgFardDetails.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                            dgFardDetails.Columns["TokenDate"].HeaderText = "بتاریخ";
                            dgFardDetails.Columns["TokenPurpose_Urdu"].HeaderText = "مقصد";
                            dgFardDetails.Columns["KhewatMalikName"].HeaderText = "نام مالک";
                            dgFardDetails.Columns["TokenId"].Visible = false;
                            dgFardDetails.Columns["PVKhataId"].Visible = false;
                        }
                        else
                        {
                            dgFardDetails.DataSource = null;
                        }
                        
                    }
                }
                else
                {
                    dgFardDetails.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void chkFardDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFardDateFilter.Checked)
            {
                dtpEndDate.Visible = true;
                dtpStartDate.Visible = true;
                lblEndDate.Visible = true;
                lblStartDate.Visible = true;
            }
            else
            {
                dtpEndDate.Visible = false;
                dtpStartDate.Visible = false;
                lblStartDate.Visible = false;
                lblEndDate.Visible = false;
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            this.cboTokenPurpose_SelectionChangeCommitted(sender, e);
        }

        private void txtSearchAmalIntiqal_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchAmalIntiqal.Text.ToString();
            if(viewIntiqalAmal != null)
            {
                viewIntiqalAmal.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                dgKhataIntiqalAmaldaramad.DataSource = viewIntiqalAmal;
                dgKhataIntiqalAmaldaramad.Columns["IntiqalNo"].HeaderText = "نمبر";
                dgKhataIntiqalAmaldaramad.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                dgKhataIntiqalAmaldaramad.Columns["IntiqalId"].Visible = false;
            }
          
        }

        private void txtSearchPendingIntiqal_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchPendingIntiqal.Text.ToString();
            if (viewIntiqalPending != null)
            {
                viewIntiqalPending.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                dgKhataIntiqalPending.DataSource = viewIntiqalPending;
                dgKhataIntiqalPending.Columns["IntiqalNo"].HeaderText = "نمبر";
                dgKhataIntiqalPending.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                dgKhataIntiqalPending.Columns["IntiqalPendingRemakrs"].HeaderText = " حالت";
                dgKhataIntiqalPending.Columns["IntiqalId"].Visible = false;
            }
        }

        private void txtSearchKhataFardBadar_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhataFardBadar.Text.ToString();
            if (viewFardbader != null)
            {
                viewFardbader.RowFilter = "FB_DocumentNo LIKE '%" + filter + "%'";
                dgkhataFardbadar.DataSource = viewFardbader;
                dgkhataFardbadar.Columns["FB_DocumentNo"].HeaderText = " دستویز نمبر";
                dgkhataFardbadar.Columns["FB_Date"].HeaderText = "بتاریخ";
                dgkhataFardbadar.Columns["FB_Id"].Visible = false;
            }
        }

        private void btnShowLockRecords_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhewatFareeqainLock = khatooni.GetKhewatGroupFareeqainLockindDetailsByKhataId(cbokhataNo.SelectedValue.ToString(), "0");
                if(dtKhewatFareeqainLock != null)
                {
                    dgKhewatGroupFareeqainForLocking.DataSource = dtKhewatFareeqainLock;
                    if (dtKhewatFareeqainLock.Rows.Count > 0)
                    {
                        this.PopulateGridViewKhewatGroupFareeqainLock(dgKhewatGroupFareeqainForLocking);
                    }
                    else
                    {
                        MessageBox.Show("کوئی ریکارڈ لاک نہیں ہے۔");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void btnShowAllRecords_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhewatFareeqainLock = khatooni.GetKhewatGroupFareeqainLockindDetailsByKhataId(cbokhataNo.SelectedValue.ToString(), "1");
                if(dtKhewatFareeqainLock != null)
                {
                    dgKhewatGroupFareeqainForLocking.DataSource = dtKhewatFareeqainLock;
                    if (dtKhewatFareeqainLock.Rows.Count > 0)
                    {
                        this.PopulateGridViewKhewatGroupFareeqainLock(dgKhewatGroupFareeqainForLocking);
                    }
                    else
                    {
                        MessageBox.Show("کوئی ریکارڈ لاک نہیں ہے۔");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgKhewatGroupFareeqainForLocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            try
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["ColSel"].Value = 1;
                        this.lblKhewatMalikName.Text = row.Cells["CompleteName"].Value.ToString();
                        this.txtKhewatFareeqLockDetails.Text = row.Cells["RecordLockingDetails"].Value.ToString();
                        this.chkKhewatFareeqLock.Checked = Convert.ToBoolean(row.Cells["RecordLocked"].Value.ToString());
                        this.txtKhewatGroupFareeqId.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                    }
                    else
                    {
                        row.Cells["ColSel"].Value = 0;
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKhewatGroupFareeqId.Text != "" && lblKhewatMalikName.Text != "")
            {
                if (chkKhewatFareeqLock.Checked)
                {
                    khatooni.SaveKhewatGroupFareeqainLock(txtKhewatGroupFareeqId.Text, txtKhewatFareeqLockDetails.Text, "True");
                    MessageBox.Show("ریکارڈ لاک ہو گیا ہے۔");
                    this.txtKhewatFareeqLockDetails.Clear();
                    this.txtKhewatGroupFareeqId.Clear();
                    this.chkKhewatFareeqLock.Checked = false;
                    this.btnShowAllRecords_Click(sender, e);

                }
                else
                {
                    khatooni.SaveKhewatGroupFareeqainLock(txtKhewatGroupFareeqId.Text, txtKhewatFareeqLockDetails.Text, "False");
                    MessageBox.Show("ریکارڈ انلاک ہو گیا ہے۔");
                    this.txtKhewatFareeqLockDetails.Clear();
                    this.txtKhewatGroupFareeqId.Clear();
                    this.chkKhewatFareeqLock.Checked = false;
                    this.btnShowAllRecords_Click(sender, e);

                }
            }
        }

        private void txtSearchPendingKharajIntiqals_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = this.txtSearchPendingKharajIntiqals.Text.ToString();
                if (viewIntiqalPendingKharij != null)
                {
                    viewIntiqalPendingKharij.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                    dgKhataIntiqalPenginKharej.DataSource = viewIntiqalPendingKharij;
                    dgKhataIntiqalPenginKharej.Columns["IntiqalNo"].HeaderText = "نمبر";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalPendingRemakrs"].HeaderText = " حالت";
                    dgKhataIntiqalPenginKharej.Columns["IntiqalId"].Visible = false;
                }
            }                              
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Fill Gridview Malkan by Person Id for Single Malk History and Details

        private void PopulateGridviewKhewFareeqByPersonId()
        {
            try
            {
                dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "نام مالک";
                dgKhewatFreeqDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                dgKhewatFreeqDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                dgKhewatFreeqDetails.Columns["IntiqalId"].Visible = false;
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی/پاسپورٹ نمبر";
                dgKhewatFreeqDetails.Columns["SellerBuyer"].HeaderText = "حیثیت";
                dgKhewatFreeqDetails.Columns["KhewatType"].Visible = false;
                dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
                dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatTypeId"].Visible = false;
                dgKhewatFreeqDetails.Columns["RecStatus"].HeaderText = "حالت";
                dgKhewatFreeqDetails.Columns["PersonName"].DisplayIndex = 2;
                dgKhewatFreeqDetails.Columns["TransactionType"].DisplayIndex = 3;
                dgKhewatFreeqDetails.Columns["seqno"].DisplayIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

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
                            this.dgKhewatFreeqDetails.DataSource = null;
                            if (dtKhewatFareeqainByPerson != null)
                            {
                                this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
                                PopulateGridviewKhewFareeqByPersonId();
                                if (e.ColumnIndex == row.Cells["ColCnicUpdate"].ColumnIndex && row.Cells["ColCnicUpdate"].Value != null)
                                {
                                    frmPersonUpdateCNIC ucnic = new frmPersonUpdateCNIC();
                                    ucnic.lblPersonName.Text = row.Cells["PersonName"].Value.ToString();
                                    ucnic.PersonId = row.Cells["PersonId"].Value.ToString();
                                    ucnic.MozaId = cmbMouza.SelectedValue.ToString();
                                    ucnic.FormClosed -= new FormClosedEventHandler(ucnic_FormClosed);
                                    ucnic.FormClosed += new FormClosedEventHandler(ucnic_FormClosed);
                                    ucnic.ShowDialog();
                                }
                            }
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

        void ucnic_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPersonUpdateCNIC ucnic = sender as frmPersonUpdateCNIC;
            if(ucnic.retVal!=null)
                if (ucnic.retVal.Length > 5)
                {
                    btnShowCurrent_Click(sender, e);
                }
        }

        #endregion

        #region Fill Gridview Mushteryan by Person Id for Single Malk History and Details

        private void PopulateGridviewMushteriFareeqByPersonId()
        {
            try
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
                            if(dtMushteriFareeqainByPerson != null)
                            {
                                this.dgMushteriFareeqainDetails.DataSource = dtMushteriFareeqainByPerson;
                                PopulateGridviewMushteriFareeqByPersonId();
                            }

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

        #endregion

        private void txtSearchKhanakasht_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhanakasht.Text.ToString();
            if(viewMF != null)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgFardDetails.ColumnCount > 0)
            {
                (dgFardDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("KhewatMalikName LIKE '{0}%' OR KhewatMalikName LIKE '% {0}%'", txtSearch.Text);
            }
           
        }

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

        private void btnRaqbaBamutabiqHissa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgKhewatFareeqainAll.Rows)
                {
                    if (row.Cells["RecStatus"].Value.ToString() == "موجودہ")
                    {
                        string kgf_id = row.Cells["KhewatGroupFareeqId"].Value != null ? row.Cells["KhewatGroupFareeqId"].Value.ToString() : "0";
                        float netpart = float.Parse(row.Cells["FardAreaPart"].Value != null ? row.Cells["FardAreaPart"].Value.ToString() : "0");  //Convert.ToInt32(PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).Count() > 0 ? PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).FirstOrDefault().FardAreaPart : 0);
                        string raqba = this.PersonRaqba(netpart);
                        int kanal = raqba.Split('-').ElementAt(0) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(0)) : 0;
                        int marla = raqba.Split('-').ElementAt(1) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(1)) : 0;
                        float sarsai = raqba.Split('-').ElementAt(2) != "" ? float.Parse(raqba.Split('-').ElementAt(2)) : 0;
                        float sft = Convert.ToInt32(raqba.Split('-').ElementAt(3) != "" ? float.Parse(raqba.Split('-').ElementAt(3)) : 0);
                        intiqal.UpdateMalakRaqbaByHissa(kgf_id, "0", kanal.ToString(), marla.ToString(), sarsai.ToString(), sft.ToString()); // netpart updation disabled in SP because no need of updating fard parts
                    }
                    }
                btnShowCurrent_Click(sender, e);
                //MessageBox.Show("Under development");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Calculates Person Raqba on basis of person area parts

        private string PersonRaqba(float hissa)
        {
            //Previous Calculation
            //int totalHissay = txtKulHisay.Text.Trim() != "" ? Convert.ToInt32(txtKulHisay.Text.Trim()) : 0;

            //textBox1 is Sum of fareeqain total parts after calculation
            float totalHissay = txtKhataHissa.Text.Trim() != "" ? float.Parse(txtKhataHissa.Text.Trim()) : 0; //Modified by Yousaf
            //MessageBox.Show(textBox1.Text);
            int tkanal = txtKhataKanal.Text != "" ? Convert.ToInt32(txtKhataKanal.Text) : 0;
            int tmarla = txtKhataMarla.Text != "" ? Convert.ToInt32(txtKhataMarla.Text) : 0;
            float tsarsai = txtKhataSarsai.Text != "" ? float.Parse(txtKhataSarsai.Text) : 0;
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
        private string PersonRaqbaKhanakasht(float hissa)
        {
            //Previous Calculation
            //int totalHissay = txtKulHisay.Text.Trim() != "" ? Convert.ToInt32(txtKulHisay.Text.Trim()) : 0;

            //textBox1 is Sum of fareeqain total parts after calculation
            float totalHissay = txtKhatooniHissa.Text.Trim() != "" ? float.Parse(txtKhatooniHissa.Text.Trim()) : 0; //Modified by Yousaf
            //MessageBox.Show(textBox1.Text);
            int tkanal = txtKhatooniKanal.Text != "" ? Convert.ToInt32(txtKhatooniKanal.Text) : 0;
            int tmarla = txtKhatooniMarla.Text != "" ? Convert.ToInt32(txtKhatooniMarla.Text) : 0;
            float tsarsai = txtKhatooniSarsai.Text != "" ? float.Parse(txtKhatooniSarsai.Text) : 0;
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

        private void btnSearchAllMutations_Click(object sender, EventArgs e)
        {
            if (dgKhewatFareeqainAll.DataSource != null)
            {
                if (dgKhewatFareeqainAll.SelectedRows.Count > 0)
                {
                    frmIntiqalAllByPersonId frmIAP = new frmIntiqalAllByPersonId();
                    frmIAP.PersonId = dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonId"].Value.ToString(); //PersonName
                    frmIAP.PersonName = dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonName"].Value.ToString();
                    frmIAP.ShowDialog();
                }
            }
        }

        private void btnViewAllMutFromMushtri_Click(object sender, EventArgs e)
        {
            if (dgMushteriFareeqainAll.DataSource != null)
            {
                if (dgMushteriFareeqainAll.SelectedRows.Count > 0)
                {
                    frmIntiqalAllByPersonId frmIAP = new frmIntiqalAllByPersonId();
                    frmIAP.PersonId = dgMushteriFareeqainAll.SelectedRows[0].Cells["PersonId"].Value.ToString(); //PersonName
                    frmIAP.PersonName = dgMushteriFareeqainAll.SelectedRows[0].Cells["CompleteName"].Value.ToString();
                    frmIAP.ShowDialog();
                }
            }
        }

        private void btnGoshwaraMalkiat_Click(object sender, EventArgs e)
        {
            if (dgKhewatFareeqainAll.DataSource != null)
            {
                if (dgKhewatFareeqainAll.SelectedRows.Count > 0 && cmbMouza.SelectedValue.ToString().Length > 3)
                {
                    //frmIntiqalAllByPersonId frmIAP = new frmIntiqalAllByPersonId();
                    //frmIAP.PersonId = dataGridViewPersons.SelectedRows[0].Cells["PersonId"].Value.ToString(); //PersonName
                    //frmIAP.PersonName = dataGridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();
                    //frmIAP.ShowDialog();
                    frmSDCReportingMain frmRpt = new frmSDCReportingMain();
                    frmRpt.MozaId = cmbMouza.SelectedValue.ToString();
                    frmRpt.PersonName = dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonName"].Value.ToString();
                    frmRpt.FardPersonId = dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonId"].Value.ToString();
                    UsersManagments.check = 50;
                    frmRpt.ShowDialog();
                }
            }
        }

        private void btnShowScanImg_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString().Length > 3 && cbokhataNo.SelectedValue.ToString().Length > 5)
            {
                string[] khataNo = cbokhataNo.Text.Split('/');
                string url = @""+ScanDataPath+"?mozaId=" + cmbMouza.SelectedValue.ToString() + "&documentTypeId=11&recordNo=" + khataNo[0];
                //System.Diagnostics.Process.Start(url);
                frmImageViewerBrowser iv = new frmImageViewerBrowser();
                iv.url = url;
                iv.Show();
            }
            else
                MessageBox.Show("موضع اور انتقال نمبر درج کرکے سکین دستاویز دیکھئے۔");
        }

        private void rbCurrent_CheckedChanged(object sender, EventArgs e)
        {
            FilterMalikan();
        }

        private void rbPrev_CheckedChanged(object sender, EventArgs e)
        {
            FilterMalikan();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            FilterMalikan();
        }
        private void FilterMalikan()
        {
            if (view != null)
            {
                if (rbAll.Checked)
                {
                    view.RowFilter = "RecStatus LIKE '%%'";
                    dgKhewatFareeqainAll.DataSource = view;
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                }
                else if (rbCurrent.Checked)
                {
                    view.RowFilter = "RecStatus LIKE '%موجودہ%'";
                    dgKhewatFareeqainAll.DataSource = view;
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                }
                else if (rbPrev.Checked)
                {
                    view.RowFilter = "RecStatus LIKE '%سابقہ%'";
                    dgKhewatFareeqainAll.DataSource = view;
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                }
            }
        }

        private void btnShowKhassraRpt_Click(object sender, EventArgs e)
        {
            if (cbokhataNo.SelectedValue.ToString().Length > 5)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 61;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.KhataId = cbokhataNo.SelectedValue.ToString();
                obj.Show();
            }
            
        }

        private void btnMushteryanRaqbabyHissa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgMushteriFareeqainAll.Rows)
                {
                    if (row.Cells["RecStatus"].Value.ToString() == "موجودہ")
                    {
                        string kgf_id = row.Cells["MushtriFareeqId"].Value != null ? row.Cells["MushtriFareeqId"].Value.ToString() : "0";
                        float netpart = float.Parse(row.Cells["FardAreaPart"].Value != null ? row.Cells["FardAreaPart"].Value.ToString() : "0");  //Convert.ToInt32(PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).Count() > 0 ? PersonNetparts.Where(p => p.khewatgroupfareeqid == kgf_id).FirstOrDefault().FardAreaPart : 0);
                        string raqba = this.PersonRaqbaKhanakasht(netpart);
                        int kanal = raqba.Split('-').ElementAt(0) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(0)) : 0;
                        int marla = raqba.Split('-').ElementAt(1) != "" ? Convert.ToInt32(raqba.Split('-').ElementAt(1)) : 0;
                        float sarsai = raqba.Split('-').ElementAt(2) != "" ? float.Parse(raqba.Split('-').ElementAt(2)) : 0;
                        float sft = Convert.ToInt32(raqba.Split('-').ElementAt(3) != "" ? float.Parse(raqba.Split('-').ElementAt(3)) : 0);
                        intiqal.UpdateMushteriRaqbaByHissa(kgf_id, "0", kanal.ToString(), marla.ToString(), sarsai.ToString(), sft.ToString()); // netpart updation disabled in SP because no need of updating fard parts
                    }
                }
                this.GetKhatooniMushteryan(cboKhatoonies.SelectedValue.ToString());
                //MessageBox.Show("Under development");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchKhassra_Click(object sender, EventArgs e)
        {
            frmKhassraSearch obj = new frmKhassraSearch();
            if (cmbMouza.SelectedIndex > 0)
            {
                obj.MozaId = cmbMouza.SelectedValue.ToString();
            }
            obj.CallFor = 1;
            obj.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
            obj.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
            obj.ShowDialog();
        }


        void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmKhassraSearch ap = sender as frmKhassraSearch;
            if (ap.KhataId != "-1")
            {
                if (cmbMouza.SelectedValue.ToString() != ap.MozaId)
                {
                    cmbMouza.SelectedValue = ap.MozaId;
                    cmbMouza_SelectionChangeCommitted(sender, e);
                    cbokhataNo.SelectedValue = ap.KhataId;
                    cbokhataNo_SelectionChangeCommitted(sender, e);
                }
                else if (cbokhataNo.SelectedValue.ToString() != ap.KhataId)
                {
                    cbokhataNo.SelectedValue = ap.KhataId;
                    cbokhataNo_SelectionChangeCommitted(sender, e);
                }
            }
        }

       
    }
}
