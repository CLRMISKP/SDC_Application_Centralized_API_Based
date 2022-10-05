using System;
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

        #endregion

        public frmRhzAmaladaramad()
        {
            InitializeComponent();
        }

        private void frmRhzAmaladaramad_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_SDC_TokenPurpose_List ", cboTokenPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
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
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
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
        #endregion

        #region Combo Khata No Selection Change Event

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtParentKhata.Clear();
            this.ClearKhatooniControls();
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

        private void LoadKhewatFareeqainMeezan(string KhataId)
        {
            DataTable dtKhewatFareeqainMeezan = khatooni.GetKhewatFareeqainMeezan(KhataId);
            foreach (DataRow row in dtKhewatFareeqainMeezan.Rows)
            {
                this.txtKhataMeezanKhewatFareeqainHissay.Text = row["TotalHissa"].ToString();
                this.txtKhataMeezanKhewatFareeqainRaqba.Text = row["TotalRaqba"].ToString();
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
                    txtKhataLocking.Text = row["RecordLockedDetails"].ToString();
                    txtKhataLocking.Visible = true;
                }
                else
                {
                    chkKhataLocked.Checked = false;
                    txtKhataLocking.Clear();
                    txtKhataLocking.Visible = false;
                }
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
                viewFardbader = new DataView(dtFardBadar);
                dgkhataFardbadar.DataSource = dtFardBadar;
                if (dtFardBadar != null)
                {
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
            viewIntiqalPending = new DataView(dtIntiqalPending);
            dgKhataIntiqalPending.DataSource = dtIntiqalPending;
                if (dtIntiqalPending != null)
                {
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
                viewIntiqalPendingKharij = new DataView(dtIntiqalPending);
                dgKhataIntiqalPenginKharej.DataSource = dtIntiqalPending;
                if (dtIntiqalPending != null)
                {
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
                viewIntiqalAmal = new DataView(dtIntiqalInc);
                dgKhataIntiqalAmaldaramad.DataSource = dtIntiqalInc;
                if (dtIntiqalInc != null)
                {
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
                this.dtKhewatFareeqain = khatas.Proc_Get_KhewatFareeqeinByKhataId(this.KhataId);
                this.dgKhewatFareeqainCurrent.DataSource = dtKhewatFareeqain;
                view = new DataView(dtKhewatFareeqain);
                if(dtKhewatFareeqain!=null)
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainCurrent, false);
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
                this.dgKhewatFareeqainAll.DataSource = dtKhewatFareeqainAll;
                viewAll = new DataView(dtKhewatFareeqainAll);
                if(dtKhewatFareeqainAll!=null)
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
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
            g.Columns["CNIC"].HeaderText = "شناختی نمبر";
            g.Columns["KhewatType"].HeaderText = "قسم مالک";
            g.Columns["FardPart_Bata"].Visible = false;
            g.Columns["seqno"].HeaderText = "نمبر شمار";
            g.Columns["KhewatGroupFareeqId"].Visible = false;
            g.Columns["KhewatGroupId"].Visible = false;
            g.Columns["PersonId"].Visible = false;
            if (!All)
            {
                g.Columns["darno"].Visible = false;
                g.Columns["TotalDarPart"].Visible = false;
                g.Columns["PersonDarPart"].Visible = false;
                g.Columns["OfDarPart"].Visible = false;
                g.Columns["PersonNetPart"].Visible = false;
            }
            else
            {
                g.Columns["RecStatus"].HeaderText = "حالت";
            }
            g.Columns["KhewatTypeId"].Visible = false;
            g.Columns["PersonName"].DisplayIndex = 2;
            g.Columns["KhewatType"].DisplayIndex = 3;
            g.Columns["seqno"].DisplayIndex = 1;
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
            if (view != null)
            {
                string filter = this.txtSearchCurrentKhewatFareeqain.Text.ToString();
                view.RowFilter = "PersonName LIKE '%" + filter + "%'";
                dgKhewatFareeqainCurrent.DataSource = view;
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainCurrent, false);
            }
        }

        private void txtSearchPreviousKhewatFareeqain_TextChanged(object sender, EventArgs e)
        {
            if (viewAll != null)
            {
                string filter = this.txtSearchPreviousKhewatFareeqain.Text.ToString();
                viewAll.RowFilter = "PersonName LIKE '%" + filter + "%'";
                dgKhewatFareeqainAll.DataSource = viewAll;
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, true);
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
                KhatooniesByKhata = khatooni.GetKhatooniNosListbyKhataId(KhataId.ToString());
                DataRow row = KhatooniesByKhata.NewRow();
                row["KhatooniId"] = 0;
                row["KhatooniNo"] = "- کھتونی کا انتخاب کریں -";
                KhatooniesByKhata.Rows.InsertAt(row, 0);
                cboKhatoonies.DataSource = KhatooniesByKhata;
                cboKhatoonies.DisplayMember = "KhatooniNo";
                cboKhatoonies.ValueMember = "KhatooniId";
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

            g.Columns["CompleteName"].HeaderText = "نام مشتری";
            g.Columns["KhewatType"].HeaderText = "قسم مالک";
            g.Columns["FardAreaPart"].HeaderText = "حصہ";
            g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
            // Hide Columns
            g.Columns["MushtriFareeqId"].Visible = false;
            g.Columns["PersonId"].Visible = false;
            g.Columns["SeqNo"].Visible = false;
            g.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
            g.Columns["KhatooniId"].Visible = false;
            g.Columns["TransactionType"].Visible = false;
            g.Columns["IntiqalId"].Visible = false;
            g.Columns["MurthinId"].Visible = false;
            g.Columns["KhewatTypeId"].Visible = false;
            g.Columns["FardPart_Bata"].Visible = false;
            g.Columns["Farad_Kanal"].Visible = false;
            g.Columns["Fard_Marla"].Visible = false;
            g.Columns["Fard_Sarsai"].Visible = false;
            g.Columns["Fard_Feet"].Visible = false;
            g.Columns["Mushtri_Area_KMSr"].Visible = false;

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
            this.dgKhatooniMushteryanCurrent.DataSource = null;
            this.dgKhatooniMushteryanPrevious.DataSource = null;
            this.dgKhatooniBayan.DataSource = null;
            this.dgKhatooniKhassras.DataSource = null;
        }

        #endregion

        private void GetKhatooniMushteryan(string KhatooniId)
        {
            try
            {
                DataTable mushteryanCUrrent = khatooni.Get_MushtriFareeqein_By_KhatooniId(KhatooniId);
                dgKhatooniMushteryanCurrent.DataSource = mushteryanCUrrent;
                if(mushteryanCUrrent!=null)
                PopulateGrid(dgKhatooniMushteryanCurrent);
                DataTable mushteryanPrevious = khatooni.GetMushteryanPreviousByKhatooniId(KhatooniId);
                dgKhatooniMushteryanPrevious.DataSource = mushteryanPrevious;
                if(mushteryanPrevious!=null)
                PopulateGrid(dgKhatooniMushteryanPrevious);
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
                if(dtKhassras!=null)
                    this.PopulateKhassraGrid();
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
            if (viewKhassra != null)
            {
                string filter = this.txtSearchKhassras.Text.ToString();
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
                        dtFardRecord = khatooni.GetFardDetailsByKhataIdByTokenPurposeId(cbokhataNo.SelectedValue.ToString(), cboTokenPurpose.SelectedValue.ToString(), dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString());
                        dgFardDetails.DataSource = dtFardRecord;
                        if (dtFardRecord != null)
                        {
                            dgFardDetails.Columns["VisitorName"].HeaderText = "درخوست دہندہ";
                            dgFardDetails.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                            dgFardDetails.Columns["TokenDate"].HeaderText = "بتاریخ";
                            dgFardDetails.Columns["TokenPurpose_Urdu"].HeaderText = "مقصد";
                            dgFardDetails.Columns["KhewatMalikName"].HeaderText = "نام مالک";
                            dgFardDetails.Columns["TokenId"].Visible = false;
                            dgFardDetails.Columns["PVKhataId"].Visible = false;
                        }
                    }
                    else
                    {
                        DataTable dtFardRecord = new DataTable();
                        dtFardRecord = khatooni.GetFardDetailsByKhataIdByTokenPurposeId(cbokhataNo.SelectedValue.ToString(), cboTokenPurpose.SelectedValue.ToString(),"0", "0");
                        dgFardDetails.DataSource = dtFardRecord;
                        if (dtFardRecord != null)
                        {
                            dgFardDetails.Columns["VisitorName"].HeaderText = "درخوست دہندہ";
                            dgFardDetails.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                            dgFardDetails.Columns["TokenDate"].HeaderText = "بتاریخ";
                            dgFardDetails.Columns["TokenPurpose_Urdu"].HeaderText = "مقصد";
                            dgFardDetails.Columns["KhewatMalikName"].HeaderText = "نام مالک";
                            dgFardDetails.Columns["TokenId"].Visible = false;
                            dgFardDetails.Columns["PVKhataId"].Visible = false;
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
            if (viewIntiqalAmal != null)
            {
                string filter = this.txtSearchAmalIntiqal.Text.ToString();
                viewIntiqalAmal.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                dgKhataIntiqalAmaldaramad.DataSource = viewIntiqalAmal;
                dgKhataIntiqalAmaldaramad.Columns["IntiqalNo"].HeaderText = "نمبر";
                dgKhataIntiqalAmaldaramad.Columns["IntiqalDate"].HeaderText = "بتاریخ";
                dgKhataIntiqalAmaldaramad.Columns["IntiqalId"].Visible = false;
            }
        }

        private void txtSearchPendingIntiqal_TextChanged(object sender, EventArgs e)
        {
            if (viewIntiqalPending != null)
            {
                string filter = this.txtSearchPendingIntiqal.Text.ToString();
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
            if (viewFardbader != null)
            {
                string filter = this.txtSearchKhataFardBadar.Text.ToString();
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
                dgKhewatGroupFareeqainForLocking.DataSource = dtKhewatFareeqainLock;
                if (dtKhewatFareeqainLock!=null? dtKhewatFareeqainLock.Rows.Count > 0:false)
                {
                    this.PopulateGridViewKhewatGroupFareeqainLock(dgKhewatGroupFareeqainForLocking);
                }
                else
                {
                    MessageBox.Show("کوئی ریکارڈ لاک نہیں ہے۔");
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
                dgKhewatGroupFareeqainForLocking.DataSource = dtKhewatFareeqainLock;
                if(dtKhewatFareeqainLock!=null)
                this.PopulateGridViewKhewatGroupFareeqainLock(dgKhewatGroupFareeqainForLocking);
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
                    khatooni.SaveKhewatGroupFareeqainLock(txtKhewatGroupFareeqId.Text, txtKhewatFareeqLockDetails.Text, "1");
                    MessageBox.Show("ریکارڈ لاک ہو گیا ہے۔");
                    this.txtKhewatFareeqLockDetails.Clear();
                    this.txtKhewatGroupFareeqId.Clear();
                    this.chkKhewatFareeqLock.Checked = false;
                    this.btnShowAllRecords_Click(sender, e);

                }
                else
                {
                    khatooni.SaveKhewatGroupFareeqainLock(txtKhewatGroupFareeqId.Text, txtKhewatFareeqLockDetails.Text, "0");
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
                if (viewIntiqalPendingKharij != null)
                {
                    string filter = this.txtSearchPendingKharajIntiqals.Text.ToString();
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

    }
}
