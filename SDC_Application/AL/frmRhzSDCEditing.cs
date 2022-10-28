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
    public partial class frmRhzSDCEditing : Form
    {
        #region Class Variables

        Intiqal intiqal = new Intiqal();
        Misal misal = new Misal();
        AutoComplete objauto = new AutoComplete();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        Khatoonies Khatooni = new Khatoonies();
        RhzSDC rhz = new RhzSDC();
        CommanFunctions cmnFn = new CommanFunctions();

        // Data Tables //----------
        DataTable dtkj = new DataTable();
        DataTable dtFardBadar = new DataTable();
        DataTable dtKhewatFareeqain = new DataTable();
        DataTable dtKhewatFareeqainAll = new DataTable();
        DataTable dtKhewatFareeqainEdit = new DataTable();
        DataTable dtMushteriFareeqain = new DataTable();
        DataTable dtMushteriFareeqainSel = new DataTable();
        DataTable dtKhatajatEdit = new DataTable();
        DataTable KhatooniesByKhata = new DataTable();
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

        #endregion

        #region Default Constructor

        public frmRhzSDCEditing()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmRhzSDCEditing_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_KhewatTypes  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cboQismMalik, "KhewatType", "KhewatTypeId");
        }

        #endregion

        #region Combo Box MOuzalist Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Khata_DropDown();
        }

        #endregion

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
            dgKhewatFreeqDetails.DataSource = null;
            dgKhewatFareeqainAll.DataSource = null;
            dgKhatooniKhassras.DataSource = null;
            dgKhatooniBayan.DataSource = null;
            chkIsNewKhata.Checked = false;
            this.txtParentKhata.Clear();
            this.ClearKhatooniControls();
            foreach (DataRow row in dtkj.Rows)
            {
                if ((row["RegisterHqDKhataId"].ToString() == cbokhataNo.SelectedValue.ToString()) && cbokhataNo.SelectedValue.ToString() != "0")
                {
                    this.txtKhataHissa.Text = row["TotalParts"].ToString();
                    txtKhataHissaProp.Text = row["TotalParts"].ToString();
                    txtKhataMeezanKulHissay.Text = row["TotalParts"].ToString();
                    this.txtKhataKanal.Text = row["Kanal"].ToString();
                    this.txtKhataKanalProp.Text = row["Kanal"].ToString();
                    txtKhataMarla.Text = row["Marla"].ToString();
                    txtKhataMarlaProp.Text = row["Marla"].ToString();
                    txtKhataSarsai.Text = row["sarsai"].ToString();
                    txtKhataSarsaiProp.Text = row["sarsai"].ToString();
                    txtKhataSFT.Text = Math.Round(float.Parse(row["sarsai"].ToString()) * (float)30.25, 0).ToString();
                    txtKhataSFTprop.Text = txtKhataSFT.Text;
                    txtKhataMeezanRaqba.Text = txtKhataKanal.Text + "-" + txtKhataMarla.Text + "-" + txtKhataSarsai.Text;
                    txtKhataKifiat.Text = row["Kyfiat"].ToString();
                    txtKhataKifiatProp.Text = row["Kyfiat"].ToString();
                    this.KhataId = row["RegisterHqDKhataId"].ToString();
                    txtKhataNoProp.Text = row["KhataNo"].ToString();
                    LoadDataByKhata();
                    FillKhatooniList();
                    objauto.FillCombo("Proc_Get_AreaTypes_List " + UsersManagments._Tehsilid.ToString(), cboAreaType, "AreaType", "AreaTypeId");
                    this.LoadKhewatFareeqainMeezan(cbokhataNo.SelectedValue.ToString());
                    tabControl1.Enabled = true;
                    this.LoadKhataLockDetails(cbokhataNo.SelectedValue.ToString());
                    dtKhatajatEdit = rhz.GetKhatajatEditByKhataId(cbokhataNo.SelectedValue.ToString());
                        if(dtKhatajatEdit.Rows.Count>0)
                        {
                            cbKhataEdits.DataSource=dtKhatajatEdit;
                            cbKhataEdits.DisplayMember="KhataNoProp";
                            cbKhataEdits.ValueMember="KhataRecId";
                            txtKhataNoProp.Text = dtKhatajatEdit.Rows[0]["KhataNoProp"].ToString();
                            txtKhataRecId.Text = dtKhatajatEdit.Rows[0]["KhataRecId"].ToString();
                            txtKhataHissaProp.Text = dtKhatajatEdit.Rows[0]["TotalPartsProp"].ToString();
                            txtKhataKanalProp.Text = dtKhatajatEdit.Rows[0]["Khata_KanalProp"].ToString();
                            txtKhataMarlaProp.Text = dtKhatajatEdit.Rows[0]["Khata_MarlaProp"].ToString();
                            txtKhataSarsaiProp.Text = dtKhatajatEdit.Rows[0]["Khata_SarsaiProp"].ToString();
                            txtKhataSFTprop.Text = dtKhatajatEdit.Rows[0]["Khata_FeetProp"].ToString();

                            if (dtKhatajatEdit.Rows.Count > 1)
                            {
                                cbKhataEdits.Visible = true;
                            }
                            else
                                cbKhataEdits.Visible = false;
                        }
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
            this.GetKhataParentKhata();
        }
        #endregion

        #endregion

        #region Get Khata Parent Khata

        private void GetKhataParentKhata()
        {
            try
            {
                DataTable dtParentKhata = new DataTable();
                dtParentKhata = intiqal.GetKhataNoByChildKhataId(this.KhataId);

                foreach (DataRow row in dtParentKhata.Rows)
                {
                    txtParentKhata.Text = row["KhataNo"].ToString();
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
                this.dtKhewatFareeqain = khatas.Proc_Self_Get_KhewatFareeqeinByKhataId(this.KhataId);
                this.dgKhewatFareeqainAll.DataSource = dtKhewatFareeqain;
                view = new DataView(dtKhewatFareeqain);
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                this.PopulateGridviewKhewFareeqByPersonId();
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
                this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainAll;
                viewAll = new DataView(dtKhewatFareeqainAll);
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFreeqDetails, false);
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
                g.Columns["KhewatTypeId"].Visible = false;
                g.Columns["RecStatus"].HeaderText = "حالت";
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

        #region Search active khewat malikan

        private void txtSearchCurrentKhewatFareeqain_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchCurrentKhewatFareeqain.Text.ToString();
            view.RowFilter = "PersonName LIKE '%" + filter + "%'";
            dgKhewatFareeqainAll.DataSource = view;
            this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
        }

        #endregion

        #region         Serach textbox auto lanuage conversion

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

        #endregion

        #region Khatoonies Controls and Methods

        private void FillKhatooniList()
        {
            try
            {
               
                string KhataId =cbokhataNo.SelectedValue.ToString();
               // MessageBox.Show(KhataId);
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
                    DataTable KhatooniEditingDetails = rhz.GetKhatooniEditingDetailsByKhatooniId(cboKhatoonies.SelectedValue.ToString());
                    foreach (DataRow row in KhatooniDetail.Rows)
                    {
                        //--- Existing Khatooni Fields ----
                        txtKhatooniLagan.Text = row["KhatooniLagan"].ToString();
                        txtKhatooniNoProp.Text = row["KhatooniNo"].ToString();
                        txtWasailAbpashi.Text = row["Wasail_e_Abpashi"].ToString();
                        txtKhatooniFullDetails.Text = row["KhatooniKashtkaranFullDetail_New"].ToString();
                        chkBeahShoda.Checked = Convert.ToBoolean(row["BeahShud"].ToString());
                        //--- Proposed Khatooni Fields ----
                        if (KhatooniEditingDetails.Rows.Count > 0)
                        {
                            txtKhatooniLaganProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniLaganProp"].ToString();
                            txtKhatooniNoProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniNoProp"].ToString();
                            txtWasailAbpashiProp.Text = KhatooniEditingDetails.Rows[0]["Wasail_e_AbpashiProp"].ToString();
                            txtKhatooniFullDetailsProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniKashtkaranFullDetail_NewProp"].ToString();
                            txtKhatooniRecId.Text = KhatooniEditingDetails.Rows[0]["KhatooniRecId"].ToString();
                        }
                        else 
                        {
                            txtKhatooniLaganProp.Clear();
                            txtKhatooniNoProp.Clear();
                            txtWasailAbpashiProp.Clear();
                            txtKhatooniFullDetailsProp.Clear();
                            txtKhatooniRecId.Text = "-1";
                        }

                        if (chkBeahShoda.Checked)
                        {
                            //--- Existing Khatooni Fields ----
                            txtKhatooniHissa.Text = row["KhatooniHissa"].ToString();
                            txtKhatooniKanal.Text = row["KhatooniKanal"].ToString();
                            txtKhatooniMarla.Text = row["KhatooniMarla"].ToString();
                            txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString();
                            txtKhatooniFeet.Text = row["KhatooniFeet"].ToString();
                            //--- Proposed Khatooni Fields ----
                            if (KhatooniEditingDetails.Rows.Count > 0)
                            {

                                //txtKhatooniHissa.Text = row["KhatooniHissa"].ToString();
                                //txtKhatooniKanal.Text = row["KhatooniKanal"].ToString();
                                //txtKhatooniMarla.Text = row["KhatooniMarla"].ToString();
                                //txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString();
                                //txtKhatooniFeet.Text = row["KhatooniFeet"].ToString();
                            }
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
            txtKhatooniFullDetails.Clear();
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
            viewKhassra.RowFilter = "KhassraNo LIKE '%" + filter + "%'";
            dgKhatooniKhassras.DataSource = viewKhassra;
            this.PopulateKhassraGrid();
        }

        #endregion

        #region KhewatgroupFareeqain GridView Populate

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

        #endregion

        #region Fill Gridview Malkan by Person Id for Single Malk History and Details

        private void PopulateGridviewKhewFareeqByPersonId()
        {
            try
            {
                dtKhewatFareeqainEdit = rhz.Proc_Get_KhewatFareeqeinBy_KhataId_Edite(cbokhataNo.SelectedValue.ToString());
                dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainEdit;
                dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "نام مالک";
                dgKhewatFreeqDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                dgKhewatFreeqDetails.Columns["KhewatType"].HeaderText = "قسم مالک";
                dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
                dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqRecId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatTypeId"].Visible = false;
                //dgKhewatFreeqDetails.Columns["RecStatus"].HeaderText = "حالت";
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
                            //DataTable dtKhewatFareeqainByPerson = new DataTable();
                            //dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(khataId, personId);
                            //this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
                            //PopulateGridviewKhewFareeqByPersonId();
                            txtSeqNo.Text = row.Cells["seqno"].Value.ToString();
                            txtPersonName.Text = row.Cells["PersonName"].Value.ToString();
                            cboQismMalik.SelectedValue = row.Cells["KhewatTypeId"].Value;
                            txtPersonHissaBata.Text = row.Cells["FardPart_Bata"].Value.ToString();
                            txtPersonNetHissa.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtPersonId.Text = row.Cells["PersonId"].Value.ToString();
                            txtKhewatGroupId.Text = row.Cells["KhewatGroupId"].Value.ToString();
                            txtKhewatGroupFareeqId.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
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

        #region Search Khanakasht 

        private void txtSearchKhanakasht_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhanakasht.Text.ToString();
            viewMF.RowFilter = "CompleteName LIKE '%" + filter + "%'";
            this.dgMushteriFareeqainAll.DataSource = viewMF;
            this.PopulateGridViewMushteryanAll();
        }

        #endregion

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

        #region auto urdu language conversion

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

        #endregion

        #region Text Box entry restriction to 

        private void txtSeqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar != 8 && e.KeyChar != 13) && (e.KeyChar < 47 || e.KeyChar > 58))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save Malik click event

        private void btnPersonSave_Click(object sender, EventArgs e)
        {
            try 
            {
                string retVal="0";
                if(txtPersonId.Text.Length>5 && txtPersonNetHissa.Text.Length>0&& cboQismMalik.SelectedValue.ToString().Length>1 && cbokhataNo.SelectedValue.ToString().Length>5)
                {
                    if (txtKhewatGroupFareeqId.Text.Length<2)
                    {
                        string[] Area = cmnFn.CalculatedAreaFromHisa(float.Parse(txtKhataHissa.Text), float.Parse(txtPersonNetHissa.Text), Convert.ToInt32(txtKhataKanal.Text), Convert.ToInt32(txtKhataMarla.Text), float.Parse(txtKhataSarsai.Text != "" ? txtKhataSarsai.Text : "0"), float.Parse(txtKhataSFT.Text != "" ? txtKhataSFT.Text : "0"));
                        retVal = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus(txtKhewatGroupFareeqId.Text, txtKhewatGroupId.Text, txtPersonId.Text, txtPersonNetHissa.Text, Area[0].ToString(), Area[1].ToString(), Area[2].ToString(), Area[3].ToString(), cboQismMalik.SelectedValue.ToString(), cbokhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtPersonHissaBata.Text, "Data Entry","0");
                    }
                    else 
                    {
                        retVal = txtKhewatGroupFareeqId.Text;
                    }
                        if (retVal.Length > 5)
                        {
                            string[] ExistingArea = dgKhewatFareeqainAll.SelectedRows[0].Cells["Khewat_Area"].Value.ToString().Split('-');
                            string[] Area = cmnFn.CalculatedAreaFromHisa(float.Parse(txtKhataHissa.Text), float.Parse(txtPersonNetHissa.Text), Convert.ToInt32(txtKhataKanal.Text), Convert.ToInt32(txtKhataMarla.Text), float.Parse(txtKhataSarsai.Text != "" ? txtKhataSarsai.Text : "0"), float.Parse(txtKhataSFT.Text != "" ? txtKhataSFT.Text : "0"));
                            string LastId = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinEdit(txtKhewatGroupFareeqRecId.Text, txtKhewatGroupFareeqId.Text, txtKhewatGroupId.Text, dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonId"].Value.ToString(), txtPersonId.Text, dgKhewatFareeqainAll.SelectedRows[0].Cells["FardAreaPart"].Value.ToString(),
                                txtPersonNetHissa.Text, ExistingArea[0], Area[0], ExistingArea[1], Area[1].ToString(), ExistingArea[2], Area[2].ToString(), (float.Parse(ExistingArea[2])*30.25).ToString(), Area[3].ToString(), dgKhewatFareeqainAll.SelectedRows[0].Cells["KhewatTypeId"].Value.ToString(), cboQismMalik.SelectedValue.ToString(), cbokhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, dgKhewatFareeqainAll.SelectedRows[0].Cells["FardAreaPart"].Value.ToString(), txtPersonHissaBata.Text, "Data Entry", txtSeqNo.Text.Trim());
                            if (LastId.Length > 5)
                            {
                                ResetMalakEntryFields();
                                //btnShowCurrent_Click(sender, e);FardAreaPart
                                PopulateGridviewKhewFareeqByPersonId();
                            }
                        } 
                }
	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message);
	        }
          
        }

        private void ResetMalakEntryFields()
        {
            txtKhewatGroupFareeqId.Text="-1";
            txtKhewatGroupId.Text="-1";
            txtPersonId.Text="-1";
            txtPersonNetHissa.Clear();
            txtPersonHissaBata.Clear();
            txtPersonName.Clear();
            txtSeqNo.Text = (GetSeqNo() + 1).ToString();
            
        }
        private int GetSeqNo()
        {
            int SeqNo = 0;
            foreach (DataGridViewRow row in dgKhewatFareeqainAll.Rows)
            {
                if ((row.Cells["seqno"].Value.ToString() != "" ? Convert.ToInt32(row.Cells["seqno"].Value) : 0) > SeqNo)
                {
                    SeqNo = Convert.ToInt32(row.Cells["seqno"].Value);
                }
            }
            return SeqNo;
        }
        #endregion

        #region Gridview KHewat Malkan Edite Cell Click Evenet

        private void dgKhewatFreeqDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgKhewatFreeqDetails.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            txtSeqNo.Text = row.Cells["seqno"].Value.ToString();
                            txtPersonName.Text = row.Cells["PersonName"].Value.ToString();
                            cboQismMalik.SelectedValue = row.Cells["KhewatTypeId"].Value;
                            txtPersonHissaBata.Text = row.Cells["FardPart_Bata"].Value.ToString();
                            txtPersonNetHissa.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtPersonId.Text = row.Cells["PersonId"].Value.ToString();
                            txtKhewatGroupId.Text = row.Cells["KhewatGroupId"].Value.ToString();
                            txtKhewatGroupFareeqId.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                            txtKhewatGroupFareeqRecId.Text = row.Cells["KhewatGroupFareeqRecId"].Value.ToString();
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

        #region Button Search Person selection click event

        private void btnSearchPerson_Click(object sender, EventArgs e)
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
            this.txtPersonName.Text = searchp.PersonName;
        }

        #endregion

        #region Calculate net part from fard part bata

        private void txtPersonHissaBata_Leave(object sender, EventArgs e)
        {
            this.txtPersonNetHissa.Text = this.calculateNetPart(this.txtPersonHissaBata.Text.Trim().Length>0?txtPersonHissaBata.Text.Trim():"0").ToString();
        }
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

        #endregion

        #region Button Delete Malik click event

        private void btnDeleteMalik_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فرد انتخاب کردہ ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    string retVal = rhz.DeleteKhewatGroupFareeqEdite(txtKhewatGroupFareeqRecId.Text);
                    if (retVal == "1")
                    {
                        ResetMalakEntryFields();
                        PopulateGridviewKhewFareeqByPersonId();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Button new Malik click event

        private void btnNewMalik_Click(object sender, EventArgs e)
        {
            ResetMalakEntryFields();
        }

        #endregion

        #region Khata Button click events

        private void btnSaveKhataProp_Click(object sender, EventArgs e)
        {
           
            if (cbokhataNo.SelectedValue.ToString() != "0" && txtKhataHissaProp.Text.Trim().Length>0 && txtKhataKanalProp.Text.Trim().Length>0 && txtKhataMarlaProp.Text.Trim().Length>0 && txtKhataSarsaiProp.Text.Trim().Length>0)
            {
                if (chkIsNewKhata.Checked)
                {
                    string KhataId = rhz.SaveNewKhata("-1", cmbMouza.SelectedValue.ToString() + "0001", txtKhataNoProp.Text, "", "", txtKhataHissaProp.Text.Trim(), txtKhataKanalProp.Text.Trim(), txtKhataMarlaProp.Text.Trim(), txtKhataSarsaiProp.Text.Trim(), txtKhataSFTprop.Text.Trim(), "", txtKhataKifiatProp.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (KhataId.Length == 9)
                    {
                        string retVal = rhz.SaveKhataDetails(txtKhataRecId.Text, KhataId, "0", txtKhataNoProp.Text, txtKhataNoProp.Text.Trim(), "0", txtKhataHissaProp.Text.Trim(), "0", txtKhataKanalProp.Text.Trim(), "0", txtKhataMarlaProp.Text.Trim(), "0", txtKhataSarsaiProp.Text.Trim(), "0", txtKhataSFTprop.Text.Trim(), "", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtKhataKifiatProp.Text.Trim());
                        if (retVal.Length == 10)
                        {
                            MessageBox.Show("انتخاب کردہ کھاتے کا مجوزہ تبدیلیاں محفوظ ہو گئے۔", "مجوزہ تبدیلیاں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    string retVal = rhz.SaveKhataDetails(txtKhataRecId.Text, cbokhataNo.SelectedValue.ToString(), "0", cbokhataNo.Text, txtKhataNoProp.Text.Trim(), txtKhataHissa.Text.Trim(), txtKhataHissaProp.Text.Trim(), txtKhataKanal.Text.Trim(), txtKhataKanalProp.Text.Trim(), txtKhataMarla.Text.Trim(), txtKhataMarlaProp.Text.Trim(), txtKhataSarsai.Text.Trim(), txtKhataSarsaiProp.Text.Trim(), txtKhataSFT.Text.Trim(), txtKhataSFTprop.Text.Trim(), txtKhataKifiat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtKhataKifiatProp.Text.Trim());
                    if (retVal.Length == 10)
                    {
                        MessageBox.Show("انتخاب کردہ کھاتے کا مجوزہ تبدیلیاں محفوظ ہو گئے۔", "مجوزہ تبدیلیاں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnNewKhataProp_Click(object sender, EventArgs e)
        {
            resetKhataFields();
            txtKhataNoProp.Text = rhz.Proc_Get_Max_Khata_No_By_Moza(cmbMouza.SelectedValue.ToString()).Rows[0][0].ToString();
            chkIsNewKhata.Checked = true;
        }

        private void btnDelKhataProp_Click(object sender, EventArgs e)
        {

        }

        private void resetKhataFields()
        {
            txtKhataNoProp.Clear();
            txtKhataHissaProp.Clear();
            txtKhataKanalProp.Clear();
            txtKhataMarlaProp.Clear();
            txtKhataSFTprop.Clear();
            txtKhataKifiatProp.Clear();
            txtKhataRecId.Text = "-1";
        }

        #endregion

        #region Khata Edits Combo box selection change event

        private void cbKhataEdits_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in dtKhatajatEdit.Rows)
            {
                if (row["KhataRecId"].ToString() == cbKhataEdits.SelectedValue.ToString())
                {
                    txtKhataNoProp.Text = row["KhataNoProp"].ToString();
                    txtKhataRecId.Text = row["KhataRecId"].ToString();
                    txtKhataHissaProp.Text = row["TotalPartsProp"].ToString();
                    txtKhataKanalProp.Text = row["Khata_KanalProp"].ToString();
                    txtKhataMarlaProp.Text = row["Khata_MarlaProp"].ToString();
                    txtKhataSarsaiProp.Text = row["Khata_SarsaiProp"].ToString();
                    txtKhataSFTprop.Text = row["Khata_FeetProp"].ToString();
                    break;
                }
            }
        }

        #endregion

        #region Khatooni Operations Buttons Click Events

        private void btnSaveKhatooni_Click(object sender, EventArgs e)
        {
            if (cboKhatoonies.SelectedValue.ToString().Length > 5 && txtKhatooniNoProp.Text.Trim().Length>0)
            {
                string KhatooniNo=""; string KhatooniKashtkarFullDetails=""; string KhatooniLagan=""; string WasaileAbpashi="";
                foreach(DataRow row in KhatooniesByKhata.Rows)
                {
                    if (row["KhatooniId"].ToString() == cboKhatoonies.SelectedValue.ToString())
                    {
                        KhatooniNo=row["KhatooniNo"].ToString();
                        KhatooniKashtkarFullDetails=row["KhatooniKashtkaranFullDetail_New"].ToString();
                        KhatooniLagan=row["KhatooniLagan"].ToString();
                        WasaileAbpashi=row["Wasail_e_Abpashi"].ToString();
                        break;
                    }
                }
                try
                {
                    string retVal = rhz.WEB_SP_INSERT_KhatooniRegisterEdit(txtKhatooniRecId.Text, cboKhatoonies.SelectedValue.ToString(), KhatooniNo, txtKhatooniNoProp.Text.Trim(), KhatooniKashtkarFullDetails, txtKhatooniFullDetailsProp.Text.Trim(), cbokhataNo.SelectedValue.ToString(), WasaileAbpashi, txtWasailAbpashiProp.Text, KhatooniLagan, txtKhatooniLaganProp.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    MessageBox.Show(retVal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (txtKhatooniFullDetailsProp.Text.Trim().Length > 1 && txtKhatooniNoProp.Text.Trim().Length > 0)
                {
                if (DialogResult.Yes == MessageBox.Show("آپ نے کوئی کھتونی منتخب نہیں کیا، کیا آپ نیئے کھتونی کااندراج کرنا چاہتے ہے؟", "اندراج کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string retVal = rhz.WEB_SP_INSERT_KhatooniRegister("-1", txtKhatooniNoProp.Text.Trim(), txtKhatooniFullDetails.Text.Trim(), cbokhataNo.SelectedValue.ToString(), txtWasailAbpashi.Text.Trim(), txtKhatooniLagan.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                        if (retVal.Length > 5)
                        {
                            string lastId = rhz.WEB_SP_INSERT_KhatooniRegisterEdit(txtKhatooniRecId.Text, retVal, "0", txtKhatooniNoProp.Text.Trim(), "", txtKhatooniFullDetails.Text.Trim(), cbokhataNo.SelectedValue.ToString(), "", txtWasailAbpashi.Text, "", txtKhatooniLagan.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            resetKhatooniFields();
                            FillKhatooniList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                }
            }
        }

        private void btnNewKhatooni_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleKhatooni_Click(object sender, EventArgs e)
        {

        }

        private void resetKhatooniFields()
        {
            txtKhatooniNoProp.Clear();
            txtWasailAbpashiProp.Clear();
            txtKhatooniLaganProp.Clear();
            txtKhatooniFullDetailsProp.Clear();
            txtKhatooniRecId.Text = "-1";
        }

        #endregion

        #region Gridview Khatooni Khassra Click Event

        private void dgKhatooniKhassras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                        if (row.Selected)
                        {
                            row.Cells["ColSelKhassras"].Value = 1;
                            //txtKhatooniIdofKhassra.Text = row.Cells["KhatooniId"].Value.ToString();
                            //cboKhatoni.SelectedValue = row.Cells["KhatooniId"].Value.ToString();
                            txtKhassraNo.Text = row.Cells["KhassraNo"].Value.ToString();
                            //txtDrustKhassraNo.Text = row.Cells["KhassraNo_Proposed"].Value.ToString();
                            txtKhassraId.Text = row.Cells["KhassraId"].Value.ToString();
                            txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
                            //txtKhassraRecId.Text = row.Cells["KhassraRecId"].Value.ToString();
                            //txtKhassraDetailRecId.Text = row.Cells["KhassraDetailRecId"].Value.ToString();
                            // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                            cboAreaType.SelectedValue = row.Cells["AreaTypeId"].Value.ToString();
                            txtKhassraKanal.Text = row.Cells["Kanal"].Value.ToString();
                            txtKhassraMarla.Text = row.Cells["Marla"].Value.ToString();
                            txtKhassraSarsai.Text = row.Cells["Sarsai"].Value.ToString();
                            //txtDrustKhassraKanal.Text = row.Cells["Kanal_Proposed"].Value.ToString();
                            //txtDrustKhassraMarla.Text = row.Cells["Marla_Proposed"].Value.ToString();
                            //txtDrustKhassraSarsai.Text = row.Cells["Sarsai_Proposed"].Value.ToString();

                        }
                        else
                        {
                            row.Cells["ColSelKhassras"].Value = 0;
                        }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
