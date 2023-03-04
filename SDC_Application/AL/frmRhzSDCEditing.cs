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
        EFardeBadar fardBadarBL = new EFardeBadar();

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
        DataTable dtAfradRegisterEdit = new DataTable();
        Khatoonies khatooni = new Khatoonies();
        DataTable dtRHZchangeDetailsList = new DataTable();
        DataTable dtKhatooniesEdited = new DataTable();
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
        public string SelectedPersonId { get; set; }

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
            objauto.FillCombo("Proc_Get_KhewatTypes  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cbMushtriKhewatType, "KhewatType", "KhewatTypeId");
            objauto.FillCombo("Proc_Get_Qoam_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cbQoam, "Qoam", "QoamId");
            objauto.FillCombo("Proc_Get_Qoam_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cbQoamExisted, "Qoam", "QoamId");
        }

        #endregion

        #region Combo Box MOuzalist Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            resetKhataFields();
            ResetMalakEntryFields();
            resetKhatooniFields();
            resetKhassraFields();
            ResetMushteriEntryFields();
            cbSrNo.DataSource = null;
            txtDetails.Clear();
            this.Fill_Khata_DropDown();
            txtSerialNo.Text = getNextSrNoByMoza(cmbMouza.SelectedValue.ToString());
            //dtRHZchangeDetailsList = rhz.GetRHZChangeDetailsListBYMozaId(cmbMouza.SelectedValue.ToString());
            //cbSrNo.DataSource = dtRHZchangeDetailsList;
            //cbSrNo.DisplayMember = "SrNo";
            //cbSrNo.ValueMember = "RHZ_ChangeId";
            fillSrNoCombo();
            //objauto.FillCombo("Proc_Get_RHZ_Change_Details_List_By_MozaId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + cmbMouza.SelectedValue.ToString(), cbSrNo, "SrNo", "RHZ_ChangeId");
        }

        private void fillSrNoCombo()
        {
            try
            {
            dtRHZchangeDetailsList = rhz.GetRHZChangeDetailsListBYMozaId(cmbMouza.SelectedValue.ToString());
            cbSrNo.DataSource = dtRHZchangeDetailsList;
            cbSrNo.DisplayMember = "SrNo";
            cbSrNo.ValueMember = "RHZ_ChangeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Next SrNo by Moza

        private string getNextSrNoByMoza(string mozaId)
        {
            string maxSrNo = rhz.GetMaxSrNoRHZChangeBYMozaId(mozaId);
            if (maxSrNo.Length > 0)
            {
                maxSrNo = (Convert.ToInt32(maxSrNo) + 1).ToString();
            }
            return maxSrNo;
        }

        #endregion

        #region Fill Grid view method

        public void Fill_Khata_DropDown()
        {
            try
            {

                dtkj = misal.GetAllKhatajatByMoza(Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
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
            txtKhataRecId.Text = "-1";
            foreach (DataRow row in dtkj.Rows)
            {
                if (cbokhataNo.SelectedValue != null)
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
                        rbCurrentKhata.Checked = row["KhataNo"].ToString().Contains("سابقہ") ? false : true;
                        rbPreviousKhata.Checked = row["KhataNo"].ToString().Contains("سابقہ") ? true : false;
                        LoadDataByKhata();
                        FillKhatooniList();
                        objauto.FillCombo("Proc_Get_AreaTypes_List " + UsersManagments._Tehsilid.ToString(), cboAreaType, "AreaType", "AreaTypeId");
                        this.LoadKhewatFareeqainMeezan(cbokhataNo.SelectedValue.ToString());
                        tabControlMain.Enabled = true;
                        this.LoadKhataLockDetails(cbokhataNo.SelectedValue.ToString());
                        //dtKhatajatEdit = rhz.GetKhatajatEditByKhataId(cbokhataNo.SelectedValue.ToString());
                        //if (dtKhatajatEdit.Rows.Count > 0)
                        //{
                        //    cbKhataEdits.DataSource = dtKhatajatEdit;
                        //    cbKhataEdits.DisplayMember = "KhataNoProp";
                        //    cbKhataEdits.ValueMember = "KhataRecId";
                        //    txtKhataNoProp.Text = dtKhatajatEdit.Rows[0]["KhataNoProp"].ToString();
                        //    txtKhataRecId.Text = dtKhatajatEdit.Rows[0]["KhataRecId"].ToString();
                        //    txtKhataHissaProp.Text = dtKhatajatEdit.Rows[0]["TotalPartsProp"].ToString();
                        //    txtKhataKanalProp.Text = dtKhatajatEdit.Rows[0]["Khata_KanalProp"].ToString();
                        //    txtKhataMarlaProp.Text = dtKhatajatEdit.Rows[0]["Khata_MarlaProp"].ToString();
                        //    txtKhataSarsaiProp.Text = dtKhatajatEdit.Rows[0]["Khata_SarsaiProp"].ToString();
                        //    txtKhataSFTprop.Text = dtKhatajatEdit.Rows[0]["Khata_FeetProp"].ToString();

                        //    if (dtKhatajatEdit.Rows.Count > 1)
                        //    {
                        //        cbKhataEdits.Visible = true;
                        //    }
                        //    else
                        //        cbKhataEdits.Visible = false;
                        //}
                        break;
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
                    txtKhataRecId.Text = "-1";
                    //tabControlMain.Enabled = false;
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

            txtKhataMeezanKhassraRaqba.Text = intiqal.GetKhassraTotalRaqbaByKhattaId(KhataId);
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

                string KhataId = cbokhataNo.SelectedValue.ToString();
                // MessageBox.Show(KhataId);
                KhatooniesByKhata = khatooni.GetKhatooniNosListbyKhataIdforRhzEdit(KhataId.ToString());
                DataRow row = KhatooniesByKhata.NewRow();
                row["KhatooniId"] = 0;
                row["KhatooniNo"] = "- کھتونی کا انتخاب کریں -";
                KhatooniesByKhata.Rows.InsertAt(row, 0);
                cboKhatoonies.DataSource = KhatooniesByKhata;
                cboKhatoonies.DisplayMember = "KhatooniNo";
                cboKhatoonies.ValueMember = "KhatooniId";
                dtKhatooniesEdited = Khatooni.GetKhatooniEditedByKhataId(KhataId);
                fillKhatooniGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillKhatooniGridView()
        {
            dgKhatooniesEdit.DataSource = dtKhatooniesEdited;
            dgKhatooniesEdit.Columns["KhatooniNo"].HeaderText="کھتونی نمبر";
            dgKhatooniesEdit.Columns["KhatooniNoProp"].HeaderText = "مجوزہ کھتونی نمبر";
            dgKhatooniesEdit.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "تفصیل حصہ داران و کاشتکاران";
            dgKhatooniesEdit.Columns["KhatooniKashtkaranFullDetail_NewProp"].HeaderText = " مجوزہ تفصیل";
            //dgKhatooniesEdit.Columns["KhatooniLagan"].HeaderText = "کھتونی لگان";
            //dgKhatooniesEdit.Columns["Wasail_e_Abpashi"].HeaderText="وسائل آبپاشی";
            dgKhatooniesEdit.Columns["Hissa"].HeaderText = "کل حصص";
            dgKhatooniesEdit.Columns["HissaProp"].HeaderText = "مجوزہ کل حصص";
            dgKhatooniesEdit.Columns["AreaProp"].HeaderText = "مجوزہ رقبہ";
            dgKhatooniesEdit.Columns["Area"].HeaderText = "رقبہ";
            dgKhatooniesEdit.Columns["Beahshuda"].HeaderText = "بیع شدہ";
            dgKhatooniesEdit.Columns["BeahShudaProp"].HeaderText = "محوزہ بیع شدہ";
            dgKhatooniesEdit.Columns["RegisterHqDKhataId"].Visible=false;
            dgKhatooniesEdit.Columns["KhatooniId"].Visible=false;
            dgKhatooniesEdit.Columns["KhatooniRecId"].Visible = false;
            dgKhatooniesEdit.Columns["Kanal"].Visible = false;
            dgKhatooniesEdit.Columns["Marla"].Visible = false;
            dgKhatooniesEdit.Columns["Sarsai"].Visible = false;
            dgKhatooniesEdit.Columns["Feet"].Visible = false;
            dgKhatooniesEdit.Columns["KanalProp"].Visible = false;
            dgKhatooniesEdit.Columns["MarlaProp"].Visible = false;
            dgKhatooniesEdit.Columns["SarsaiProp"].Visible = false;
            dgKhatooniesEdit.Columns["FeetProp"].Visible = false;
            dgKhatooniesEdit.Columns["EditingMode"].Visible = false;
            dgKhatooniesEdit.Columns["KhatooniLagan"].Visible = false;
            dgKhatooniesEdit.Columns["Wasail_e_Abpashi"].Visible = false;


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
                    //DataTable KhatooniDetail = khatooni.GetKhatooniDetailbyKhatooniId(cboKhatoonies.SelectedValue.ToString());
                    DataTable KhatooniEditingDetails = rhz.GetKhatooniEditingDetailsByKhatooniId(cboKhatoonies.SelectedValue.ToString(), txtRHZ_ChangeId.Text);
                    foreach (DataRow row in KhatooniesByKhata.Rows)
                    {
                        if (row["KhatooniId"].ToString() == cboKhatoonies.SelectedValue.ToString())
                        {
                            //--- Existing Khatooni Fields ----
                            txtKhatooniLagan.Text = row["KhatooniLagan"].ToString();
                            txtKhatooniLaganProp.Text = row["KhatooniLagan"].ToString();
                            txtKhatooniNoProp.Text = row["KhatooniNo"].ToString();
                            txtWasailAbpashi.Text = row["Wasail_e_Abpashi"].ToString();
                            txtWasailAbpashiProp.Text = row["Wasail_e_Abpashi"].ToString();
                            txtKhatooniFullDetails.Text = row["KhatooniKashtkaranFullDetail_New"].ToString();
                            txtKhatooniFullDetailsProp.Text = row["KhatooniKashtkaranFullDetail_New"].ToString();
                            chkBeahShoda.Checked = Convert.ToBoolean(row["Beahshuda"].ToString());
                            chkBeahShudaProp.Checked = Convert.ToBoolean(row["Beahshuda"].ToString());
                            txtKhatooniHissa.Text = row["Hissa"].ToString();
                            txtKhatooniHissaProp.Text = row["Hissa"].ToString();
                            txtKhatooniKanal.Text = row["Kanal"].ToString();
                            txtKhatooniKanalProp.Text = row["Kanal"].ToString();
                            txtKhatooniMarla.Text = row["Marla"].ToString();
                            txtKhatooniMarlaProp.Text = row["Marla"].ToString();
                            txtKhatooniSarsai.Text = row["Sarsai"].ToString();
                            txtKhatooniSarsaiProp.Text = row["Sarsai"].ToString();
                            txtKhatooniFeet.Text = row["Feet"].ToString();
                            txtKhatooniFeetProp.Text = row["Feet"].ToString();
                            txtKhatooniRecId.Text = "-1";
                            //--- Proposed Khatooni Fields ----
                            //if (KhatooniEditingDetails.Rows.Count > 0)
                            //{
                            //    txtKhatooniLaganProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniLaganProp"].ToString();
                            //    txtKhatooniNoProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniNoProp"].ToString();
                            //    txtWasailAbpashiProp.Text = KhatooniEditingDetails.Rows[0]["Wasail_e_AbpashiProp"].ToString();
                            //    txtKhatooniFullDetailsProp.Text = KhatooniEditingDetails.Rows[0]["KhatooniKashtkaranFullDetail_NewProp"].ToString();
                            //    txtKhatooniRecId.Text = KhatooniEditingDetails.Rows[0]["KhatooniRecId"].ToString();
                            //}
                            //else
                            //{
                                //txtKhatooniLaganProp.Clear();
                                //txtKhatooniNoProp.Clear();
                                //txtWasailAbpashiProp.Clear();
                                //txtKhatooniFullDetailsProp.Clear();
                               
                            //}

                            //if (chkBeahShoda.Checked)
                            //{
                            //    //--- Existing Khatooni Fields ----
                            //    txtKhatooniHissa.Text = row["KhatooniHissa"].ToString();
                            //    txtKhatooniKanal.Text = row["KhatooniKanal"].ToString();
                            //    txtKhatooniMarla.Text = row["KhatooniMarla"].ToString();
                            //    txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString();
                            //    txtKhatooniFeet.Text = row["KhatooniFeet"].ToString();
                            //    //--- Proposed Khatooni Fields ----
                            //    if (KhatooniEditingDetails.Rows.Count > 0)
                            //    {

                            //        //txtKhatooniHissa.Text = row["KhatooniHissa"].ToString();
                            //        //txtKhatooniKanal.Text = row["KhatooniKanal"].ToString();
                            //        //txtKhatooniMarla.Text = row["KhatooniMarla"].ToString();
                            //        //txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString();
                            //        //txtKhatooniFeet.Text = row["KhatooniFeet"].ToString();
                            //    }
                            //}
                        }

                        this.GetKhatooniMushteryan(cboKhatoonies.SelectedValue.ToString());
                        FillMushteriFareeqainEdit();
                        this.GetKhatooniBayan(cboKhatoonies.SelectedValue.ToString());
                        btnLoadKhassras_Click(sender, e);
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
                DataTable dtKhassrasEdit = new DataTable();
                dtKhassras = khatooni.GetKhassrajatByKhatooniId(cboKhatoonies.SelectedValue.ToString());
                dtKhassrasEdit = rhz.GetKhatooniKhassraDetailEdit(cboKhatoonies.SelectedValue.ToString(), txtRHZ_ChangeId.Text);
                dgKhatooniKhassras.DataSource = dtKhassras;
                dgkhatooniKhassraEdit.DataSource = dtKhassrasEdit;
                this.viewKhassra = new DataView(dtKhassras);
                this.PopulateKhassraGrid();
                PopulateKhassraEditGrid();
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
        private void PopulateKhassraEditGrid()
        {
            dgkhatooniKhassraEdit.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
            dgkhatooniKhassraEdit.Columns["AreaType"].Visible = false;
            dgkhatooniKhassraEdit.Columns["Kanal"].HeaderText = "کنال";
            dgkhatooniKhassraEdit.Columns["Marla"].HeaderText = "مرلہ";
            dgkhatooniKhassraEdit.Columns["Sarsai"].HeaderText = "سرسائی";
            dgkhatooniKhassraEdit.Columns["Feet"].HeaderText = "مربع فٹ";
            dgkhatooniKhassraEdit.Columns["KhatooniId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["KhassraId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["KhassraDetailId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["AreaTypeId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["KhassraNo_Proposed"].HeaderText = "مجوزہ نمبر خسرہ";
            dgkhatooniKhassraEdit.Columns["AreaTypeProp"].Visible = false;
            dgkhatooniKhassraEdit.Columns["Kanal_Proposed"].HeaderText = "مجوزہ کنال";
            dgkhatooniKhassraEdit.Columns["Marla_Proposed"].HeaderText = "مجوزہ مرلہ";
            dgkhatooniKhassraEdit.Columns["Sarsai_Proposed"].HeaderText = " مجوزہ سرسائی";
            dgkhatooniKhassraEdit.Columns["Feet_Proposed"].HeaderText = " مجوزہ مربع فٹ";
            dgkhatooniKhassraEdit.Columns["KhassraRecId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["KhassraDetailRecId"].Visible = false;
            dgkhatooniKhassraEdit.Columns["AreaTypeIdProp"].Visible = false;
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
                dtKhewatFareeqainEdit = rhz.Proc_Get_KhewatFareeqeinBy_KhataId_Edite(cbokhataNo.SelectedValue.ToString(), txtRHZ_ChangeId.Text);
                dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainEdit;
                dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "موجودہ حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "موجودہ رقبہ";
                dgKhewatFreeqDetails.Columns["FardAreaPartProp"].HeaderText = "مجوزہ حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area_Prop"].HeaderText = "مجوزہ رقبہ";
                dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "موجودہ نام مالک";
                dgKhewatFreeqDetails.Columns["PersonNameProp"].HeaderText = "مجوزہ نام مالک";
                dgKhewatFreeqDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                dgKhewatFreeqDetails.Columns["KhewatType"].HeaderText = "موجودہ قسم مالک";
                dgKhewatFreeqDetails.Columns["KhewatTypeProp"].HeaderText = "مجوزہ قسم مالک";
                dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
                dgKhewatFreeqDetails.Columns["FardPart_Bata_Prop"].Visible = false;
                dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqRecId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonIdProp"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatTypeId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatTypeIdProp"].Visible = false;
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
                dgMushteriFareeqainEdit.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgMushteriFareeqainEdit.Columns["Khewat_Area"].HeaderText = "رقبہ";
                dgMushteriFareeqainEdit.Columns["PersonName"].HeaderText = "نام مالک";
                dgMushteriFareeqainEdit.Columns["TransactionType"].HeaderText = "زریعہ";
                dgMushteriFareeqainEdit.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                dgMushteriFareeqainEdit.Columns["IntiqalId"].Visible = false;
                dgMushteriFareeqainEdit.Columns["CNIC"].HeaderText = "شناختی نمبر";
                dgMushteriFareeqainEdit.Columns["SellerBuyer"].HeaderText = "حیثیت";
                dgMushteriFareeqainEdit.Columns["KhewatType"].Visible = false;
                dgMushteriFareeqainEdit.Columns["FardPart_Bata"].Visible = false;
                dgMushteriFareeqainEdit.Columns["seqno"].HeaderText = "نمبر شمار";
                dgMushteriFareeqainEdit.Columns["MushtriFareeqId"].Visible = false;
                dgMushteriFareeqainEdit.Columns["KhatooniId"].Visible = false;
                dgMushteriFareeqainEdit.Columns["PersonId"].Visible = false;
                dgMushteriFareeqainEdit.Columns["KhewatTypeId"].Visible = false;
                dgMushteriFareeqainEdit.Columns["RecStatus"].HeaderText = "حالت";
                dgMushteriFareeqainEdit.Columns["PersonName"].DisplayIndex = 2;
                dgMushteriFareeqainEdit.Columns["TransactionType"].DisplayIndex = 3;
                dgMushteriFareeqainEdit.Columns["seqno"].DisplayIndex = 1;

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
                            this.dgMushteriFareeqainEdit.DataSource = dtMushteriFareeqainByPerson;
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
                DataTable dtFardatIntiqalat = fardBadarBL.GetFardatIntiqalatOnKhewatGrpupFareeqId(txtKhewatFreeqainGroupId.Text.Length > 0 ? txtKhewatFreeqainGroupId.Text : "0");
                bool isProceed = true;
                if (dtFardatIntiqalat.Rows.Count > 0)
                {
                    if (dtFardatIntiqalat.Rows[0][0].ToString() != "0" && dtFardatIntiqalat.Rows[0][0].ToString() != "0")
                    {
                        if (DialogResult.Yes == MessageBox.Show("اپکا انتخاب کردہ ریکارڈ " + dtFardatIntiqalat.Rows[0][0].ToString() + "  فردات اور " + dtFardatIntiqalat.Rows[0][1].ToString() + "  انتقالات میں موجود ہیں، کیا اپ اس مالک کی ملکیت تبدیل کرنا چاہتے ہیں؟ ", "تبدیل کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            isProceed = true;
                        }
                        else
                            isProceed = false;
                    }
                }
             if (isProceed)
             {
                string retVal = "0";
                if (txtPersonId.Text.Length > 5 && txtPersonNetHissa.Text.Length > 0 && cboQismMalik.SelectedValue.ToString().Length > 1 && this.KhataId.Length > 5 && txtSeqNo.Text.Trim().Length > 0)
                {
                    if (txtKhewatGroupFareeqId.Text.Length < 5)
                    {
                        string[] Area = cmnFn.CalculatedAreaFromHisa(float.Parse(txtKhataHissa.Text), float.Parse(txtPersonNetHissa.Text), Convert.ToInt32(txtKhataKanal.Text), Convert.ToInt32(txtKhataMarla.Text), float.Parse(txtKhataSarsai.Text != "" ? txtKhataSarsai.Text : "0"), float.Parse(txtKhataSFT.Text != "" ? txtKhataSFT.Text : "0"));
                        retVal = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus(txtKhewatGroupFareeqId.Text, txtKhewatGroupId.Text, txtPersonId.Text, txtPersonNetHissa.Text, Area[0] != null ? Area[0].ToString() : "0", Area[1] != null ? Area[1].ToString() : "0", Area[2] != null ? Area[2].ToString() : "0", Area[3] != null ? Area[3].ToString() : "0", cboQismMalik.SelectedValue.ToString(), this.KhataId, UsersManagments.UserId.ToString(), UsersManagments.UserName, txtPersonHissaBata.Text, "Data Entry", "1");
                    }
                    else
                    {
                        retVal = txtKhewatGroupFareeqId.Text;
                    }
                    if (retVal.Length > 5)
                    {
                        string[] ExistingArea; string LastId = "0";
                        string[] Area = cmnFn.CalculatedAreaFromHisa(float.Parse(txtKhataHissa.Text), float.Parse(txtPersonNetHissa.Text), Convert.ToInt32(txtKhataKanal.Text), Convert.ToInt32(txtKhataMarla.Text), float.Parse(txtKhataSarsai.Text != "" ? txtKhataSarsai.Text : "0"), float.Parse(txtKhataSFT.Text != "" ? txtKhataSFT.Text : "0"));
                        if (dgKhewatFareeqainAll.SelectedRows.Count > 0 && dgKhewatFareeqainAll.SelectedRows[0].Cells["KhewatGroupFareeqId"].Value.ToString() == retVal)
                        {
                            ExistingArea = dgKhewatFareeqainAll.SelectedRows[0].Cells["Khewat_Area"].Value.ToString().Split('-');
                            LastId = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinEdit(txtKhewatGroupFareeqRecId.Text, retVal, txtKhewatGroupId.Text, dgKhewatFareeqainAll.SelectedRows[0].Cells["PersonId"].Value.ToString(), txtPersonId.Text, dgKhewatFareeqainAll.SelectedRows[0].Cells["FardAreaPart"].Value.ToString(),
                                txtPersonNetHissa.Text, ExistingArea[0] != null ? ExistingArea[0] : "0", Area[0] != null ? Area[0] : "0", ExistingArea[1] != null ? ExistingArea[1] : "0", Area[1] != null ? Area[1].ToString() : "0", ExistingArea[2] != null ? (Math.Round(float.Parse(ExistingArea[2]) / 30.25, 5)).ToString() : "0", Area[2] != null ? Area[2].ToString() : "0", ExistingArea[2] != null ? ExistingArea[2] : "0", Area[3] != null ? Area[3].ToString() : "0", dgKhewatFareeqainAll.SelectedRows[0].Cells["KhewatTypeId"].Value.ToString(), cboQismMalik.SelectedValue.ToString(), cbokhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, dgKhewatFareeqainAll.SelectedRows[0].Cells["FardPart_Bata"].Value.ToString(), txtPersonHissaBata.Text, "Data Entry", txtSeqNo.Text.Trim(), txtRHZ_ChangeId.Text, txtKhewatGroupFareeqId.Text.Length > 5 ? "Modified" : "Inserted");

                        }
                        else
                        {
                            ExistingArea = "0-0-0-0".Split('-');
                            LastId = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinEdit(txtKhewatGroupFareeqRecId.Text, txtKhewatGroupFareeqId.Text, txtKhewatGroupId.Text, txtPersonId.Text, txtPersonId.Text, "0",
                            txtPersonNetHissa.Text, ExistingArea[0] != null ? ExistingArea[0] : "0", Area[0] != null ? Area[0] : "0", ExistingArea[1] != null ? ExistingArea[1] : "0", Area[1] != null ? Area[1].ToString() : "0", ExistingArea[2] != null ? (Math.Round(float.Parse(ExistingArea[2]) / 30.25, 5)).ToString() : "0", Area[2] != null ? Area[2].ToString() : "0", ExistingArea[2] != null ? ExistingArea[2] : "0", Area[3] != null ? Area[3].ToString() : "0", "0", cboQismMalik.SelectedValue.ToString(), cbokhataNo.SelectedValue.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "0", txtPersonHissaBata.Text, "Data Entry", txtSeqNo.Text.Trim(), txtRHZ_ChangeId.Text, txtKhewatGroupFareeqId.Text.Length > 5 ? "Modified" : "Inserted");

                        }

                        if (LastId.Length > 5)
                        {
                            ResetMalakEntryFields();
                            //btnShowCurrent_Click(sender, e);FardAreaPart
                            PopulateGridviewKhewFareeqByPersonId();
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

        private void ResetMalakEntryFields()
        {
            txtKhewatGroupFareeqId.Text = "-1";
            txtKhewatGroupId.Text = "-1";
            txtPersonId.Text = "-1";
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
        private void ResetMushteriEntryFields()
        {
            txtMushteriFareeqId.Text = "-1";
            txtMushteriFareeqRecId.Text = "-1";
            //txtKhewatGroupId.Text = "-1";
            txtPersonIdMushteri.Text = "-1";
            txtMushtriHisaBata.Clear();
            txtMushteriHisa.Clear();
            txtMalikNameMushtri.Clear();
            txtSeqNoMushtri.Text = (GetMushteriSeqNo() + 1).ToString();
            chkRecStatus.Checked = true;
            cbMushtriKhewatType.SelectedValue = 0;

        }
        private int GetMushteriSeqNo()
        {
            int SeqNo = 0;
            foreach (DataGridViewRow row in dgMushteriFareeqainAll.Rows)
            {
                if ((row.Cells["SeqNo"].Value.ToString() != "" ? Convert.ToInt32(row.Cells["SeqNo"].Value) : 0) > SeqNo)
                {
                    SeqNo = Convert.ToInt32(row.Cells["SeqNo"].Value);
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
                            txtPersonHissaBata.Text = row.Cells["FardPart_Bata_Prop"].Value.ToString();
                            txtPersonNetHissa.Text = row.Cells["FardAreaPartProp"].Value.ToString();
                            txtPersonId.Text = row.Cells["PersonIdProp"].Value.ToString();
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
            this.txtPersonNetHissa.Text = this.calculateNetPart(this.txtPersonHissaBata.Text.Trim().Length > 0 ? txtPersonHissaBata.Text.Trim() : "0").ToString();
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

            if (txtRHZ_ChangeId.Text.Length>5 && txtKhataHissaProp.Text.Trim().Length > 0 && txtKhataKanalProp.Text.Trim().Length > 0 && txtKhataMarlaProp.Text.Trim().Length > 0 && txtKhataSarsaiProp.Text.Trim().Length > 0)
            {
                if (chkIsNewKhata.Checked)
                {
                    string KhataId = rhz.SaveNewKhata("-1", cmbMouza.SelectedValue.ToString() + "0001", txtKhataNoProp.Text, "", "", txtKhataHissaProp.Text.Trim(), txtKhataKanalProp.Text.Trim(), txtKhataMarlaProp.Text.Trim(), txtKhataSarsaiProp.Text.Trim(), txtKhataSFTprop.Text.Trim(), "", txtKhataKifiatProp.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "0", cmbMouza.SelectedValue.ToString());
                    if (KhataId.Length == 9)
                    {
                        string retVal = rhz.SaveKhataDetails(txtKhataRecId.Text, txtRHZ_ChangeId.Text, KhataId, "0", txtKhataNoProp.Text, txtKhataNoProp.Text.Trim(), "0", txtKhataHissaProp.Text.Trim(), "0", txtKhataKanalProp.Text.Trim(), "0", txtKhataMarlaProp.Text.Trim(), "0", txtKhataSarsaiProp.Text.Trim(), "0", txtKhataSFTprop.Text.Trim(), "", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtKhataKifiatProp.Text.Trim(), "Inserted", rbCurrentKhata.Checked?"1":"0");
                        if (retVal.Length == 10)
                        {
                            MessageBox.Show("انتخاب کردہ کھاتے کا مجوزہ تبدیلیاں محفوظ ہو گئے۔", "مجوزہ تبدیلیاں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDgKhataJatEdited();
                        }
                    }
                }
                else
                {
                    string retVal = rhz.SaveKhataDetails(txtKhataRecId.Text, txtRHZ_ChangeId.Text, cbokhataNo.SelectedValue.ToString(), "0", cbokhataNo.Text.Replace(" - سابقہ", ""), txtKhataNoProp.Text.Trim().Replace(" - سابقہ", ""), txtKhataHissa.Text.Trim(), txtKhataHissaProp.Text.Trim(), txtKhataKanal.Text.Trim(), txtKhataKanalProp.Text.Trim(), txtKhataMarla.Text.Trim(), txtKhataMarlaProp.Text.Trim(), txtKhataSarsai.Text.Trim(), txtKhataSarsaiProp.Text.Trim(), txtKhataSFT.Text.Trim(), txtKhataSFTprop.Text.Trim(), txtKhataKifiat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtKhataKifiatProp.Text.Trim(), "Edited", rbCurrentKhata.Checked ? "1" : "0");
                    if (retVal.Length == 10)
                    {
                        MessageBox.Show("انتخاب کردہ کھاتے کا مجوزہ تبدیلیاں محفوظ ہو گئے۔", "مجوزہ تبدیلیاں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopulateDgKhataJatEdited();
                    }
                }
            }
            else
                MessageBox.Show("محفوظ کرنے سے پہلے کھاتہ کے تمام کوائف پر کریں", "کوئف کی کمی", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnNewKhataProp_Click(object sender, EventArgs e)
        {
            resetKhataFields();
            txtKhataNoProp.Text = rhz.Proc_Get_Max_Khata_No_By_Moza(cmbMouza.SelectedValue.ToString()).Rows[0][0].ToString();
            chkIsNewKhata.Checked = true;
        }

        private void btnDelKhataProp_Click(object sender, EventArgs e)
        {
            string retVal = rhz.SaveKhataDetails(txtKhataRecId.Text, txtRHZ_ChangeId.Text, cbokhataNo.SelectedValue.ToString(), "0", cbokhataNo.Text, txtKhataNoProp.Text.Trim(), txtKhataHissa.Text.Trim(), txtKhataHissaProp.Text.Trim(), txtKhataKanal.Text.Trim(), txtKhataKanalProp.Text.Trim(), txtKhataMarla.Text.Trim(), txtKhataMarlaProp.Text.Trim(), txtKhataSarsai.Text.Trim(), txtKhataSarsaiProp.Text.Trim(), txtKhataSFT.Text.Trim(), txtKhataSFTprop.Text.Trim(), txtKhataKifiat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtKhataKifiatProp.Text.Trim(), "Deleted", rbCurrentKhata.Checked?"1":"0");
            if (retVal.Length == 10)
            {
                MessageBox.Show("انتخاب کردہ کھاتے کا مجوزہ تبدیلیاں محفوظ ہو گئے۔", "مجوزہ تبدیلیاں", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateDgKhataJatEdited();
            }
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
            if (cbokhataNo.SelectedValue.ToString().Length > 5)
            {
                if (cboKhatoonies.SelectedValue.ToString().Length > 5 && txtKhatooniNoProp.Text.Trim().Length > 0)
                {
                    string KhatooniNo = ""; string KhatooniKashtkarFullDetails = ""; string KhatooniLagan = ""; string WasaileAbpashi = "";
                    foreach (DataRow row in KhatooniesByKhata.Rows)
                    {
                        if (row["KhatooniId"].ToString() == cboKhatoonies.SelectedValue.ToString())
                        {
                            KhatooniNo = row["KhatooniNo"].ToString();
                            KhatooniKashtkarFullDetails = row["KhatooniKashtkaranFullDetail_New"].ToString();
                            KhatooniLagan = row["KhatooniLagan"].ToString();
                            WasaileAbpashi = row["Wasail_e_Abpashi"].ToString();
                            break;
                        }
                    }
                    try
                    {
                        string retVal = rhz.WEB_SP_INSERT_KhatooniRegisterEdit(txtKhatooniRecId.Text, cboKhatoonies.SelectedValue.ToString(), KhatooniNo, txtKhatooniNoProp.Text.Trim(), KhatooniKashtkarFullDetails, txtKhatooniFullDetailsProp.Text.Trim(), cbokhataNo.SelectedValue.ToString(), WasaileAbpashi, txtWasailAbpashiProp.Text, KhatooniLagan, txtKhatooniLaganProp.Text.Trim(), chkBeahShoda.Checked ? "1" : "0", chkBeahShudaProp.Checked ? "1" : "0", txtKhatooniHissa.Text, txtKhatooniHissaProp.Text.Trim(), txtKhatooniKanal.Text, txtKhatooniKanalProp.Text.Trim(), txtKhatooniMarla.Text, txtKhatooniMarlaProp.Text.Trim(), txtKhatooniSarsai.Text, txtKhatooniSarsaiProp.Text.Trim(), txtKhatooniFeet.Text, txtKhatooniFeetProp.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtRHZ_ChangeId.Text, chkIsNewKhatooni.Checked ? "Inserted" : "Updated");
                        //MessageBox.Show(retVal);

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
                                    string lastId = rhz.WEB_SP_INSERT_KhatooniRegisterEdit(txtKhatooniRecId.Text, retVal, "0", txtKhatooniNoProp.Text.Trim(), "", txtKhatooniFullDetails.Text.Trim(), cbokhataNo.SelectedValue.ToString(), "", txtWasailAbpashi.Text, "", txtKhatooniLagan.Text.Trim(), chkBeahShoda.Checked ? "1" : "0", chkBeahShudaProp.Checked ? "1" : "0", txtKhatooniHissa.Text.Length>0?txtKhatooniHissa.Text:"0", txtKhatooniHissaProp.Text.Trim().Length>0?txtKhatooniHissaProp.Text.Trim():"0", txtKhatooniKanal.Text.Length>0?txtKhatooniKanal.Text:"0", txtKhatooniKanalProp.Text.Trim().Length>0?txtKhatooniKanalProp.Text.Trim():"0", txtKhatooniMarla.Text.Length>0?txtKhatooniMarla.Text:"0", txtKhatooniMarlaProp.Text.Trim().Length>0?txtKhatooniMarlaProp.Text.Trim():"0", txtKhatooniSarsai.Text.Length>0?txtKhatooniSarsai.Text:"0", txtKhatooniSarsaiProp.Text.Trim().Length>0?txtKhatooniSarsaiProp.Text.Trim():"0", txtKhatooniFeet.Text.Length>0?txtKhatooniFeet.Text:"0", txtKhatooniFeetProp.Text.Trim().Length>0?txtKhatooniFeetProp.Text.Trim():"0", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtRHZ_ChangeId.Text, chkIsNewKhatooni.Checked ? "Inserted" : "Updated");
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
                dtKhatooniesEdited = Khatooni.GetKhatooniEditedByKhataId(KhataId);
                fillKhatooniGridView();
            }
            else
                MessageBox.Show("مجوزہ کھتونی محفوظ کرنے سے پہلے کھاتے کا انتخاب کریں۔");
        }

        private void btnNewKhatooni_Click(object sender, EventArgs e)
        {
            txtKhatooniNoProp.Text = rhz.Proc_Get_Max_Khatooni_No_By_Moza(cmbMouza.SelectedValue.ToString()).Rows[0][0].ToString();
            chkIsNewKhatooni.Checked = true;

        }

        private void btnDeleKhatooni_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ نے کوئی کھتونی منتخب نہیں کیا، کیا آپ انتخاب کردہ کھتونی کو حذف کرنا چاہتے ہے؟", "حذف کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (txtKhatooniRecId.Text.Length > 5 && dgKhatooniesEdit.SelectedRows.Count>0)
                {
                    try
                    {
                        string retVal = rhz.DeleteKhatooniEdit(txtKhatooniRecId.Text);
                        dtKhatooniesEdited = Khatooni.GetKhatooniEditedByKhataId(cbokhataNo.SelectedValue.ToString());
                        fillKhatooniGridView();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    
                }
                else if (txtKhatooniNoProp.Text.Trim() == "0" && txtKhatooniRecId.Text.Length<5)
                {
                    try
                    {
                        if (cboKhatoonies.SelectedValue.ToString().Length > 5)
                        {
                            string KhatooniNo = ""; string KhatooniKashtkarFullDetails = ""; string KhatooniLagan = ""; string WasaileAbpashi = "";
                            foreach (DataRow row in KhatooniesByKhata.Rows)
                            {
                                if (row["KhatooniId"].ToString() == cboKhatoonies.SelectedValue.ToString())
                                {
                                    KhatooniNo = row["KhatooniNo"].ToString();
                                    KhatooniKashtkarFullDetails = row["KhatooniKashtkaranFullDetail_New"].ToString();
                                    KhatooniLagan = row["KhatooniLagan"].ToString();
                                    WasaileAbpashi = row["Wasail_e_Abpashi"].ToString();
                                    break;
                                }
                            }
                            string retVal = rhz.WEB_SP_INSERT_KhatooniRegisterEdit(txtKhatooniRecId.Text, cboKhatoonies.SelectedValue.ToString(), KhatooniNo, txtKhatooniNoProp.Text.Trim(), KhatooniKashtkarFullDetails, txtKhatooniFullDetailsProp.Text.Trim(), cbokhataNo.SelectedValue.ToString(), WasaileAbpashi, txtWasailAbpashiProp.Text, KhatooniLagan, txtKhatooniLaganProp.Text.Trim(), chkBeahShoda.Checked ? "1" : "0", chkBeahShudaProp.Checked ? "1" : "0", txtKhatooniHissa.Text, txtKhatooniHissaProp.Text.Trim(), txtKhatooniKanal.Text, txtKhatooniKanalProp.Text.Trim(), txtKhatooniMarla.Text, txtKhatooniMarlaProp.Text.Trim(), txtKhatooniSarsai.Text, txtKhatooniSarsaiProp.Text.Trim(), txtKhatooniFeet.Text, txtKhatooniFeetProp.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, txtRHZ_ChangeId.Text, "deleted");

                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else
                    MessageBox.Show("کھتونی حذف کرنے کیلئے مجوزہ کھتونی نمبر 0 کریں","کھتونی حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #region Khassra Edit Code

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
                        txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
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


        private void btnSaveKhassra_Click(object sender, EventArgs e)
        {
            if (txtKhassraNo.Text.Trim().Length > 0 && cboAreaType.SelectedValue.ToString().Length > 1 && txtKhassraKanal.Text.Trim().Length > 0 && txtKhassraMarla.Text.Trim().Length > 0 && txtKhassraSarsai.Text.Trim().Length > 0)
            {
                string KhassraNo = "0", AreaTypeId = "0", KhassraKanal = "0", KhassraMarla = "0", KhassraSarsai = "0";
                foreach (DataGridViewRow row in dgKhatooniKhassras.Rows)
                {
                    if (row.Cells["KhassraDetailId"].Value.ToString() == txtKhassraDetailId.Text)
                    {
                        KhassraNo = row.Cells["KhassraNo"].Value.ToString();
                        AreaTypeId = row.Cells["AreaTypeId"].Value.ToString();
                        KhassraKanal = row.Cells["Kanal"].Value.ToString();
                        KhassraMarla = row.Cells["Marla"].Value.ToString();
                        KhassraSarsai = row.Cells["Sarsai"].Value.ToString();
                        break;
                    }
                }
                string retVal = rhz.SaveKhassraRegisterEdit(txtKhassraRecId.Text, txtKhassraDetailRecId.Text, txtKhassraId.Text, cmbMouza.SelectedValue.ToString(), KhassraNo, txtKhassraNo.Text.Trim(), txtKhassraDetailId.Text, cboKhatoonies.SelectedValue.ToString(),
                    AreaTypeId, cboAreaType.SelectedValue.ToString(), KhassraKanal, txtKhassraKanal.Text.Trim(), KhassraMarla, txtKhassraMarla.Text.Trim(), KhassraSarsai, txtKhassraSarsai.Text.Trim(), Math.Round(float.Parse(KhassraSarsai) * 30.25, 0).ToString(), Math.Round(float.Parse(txtKhassraSarsai.Text.Trim()) * 30.25, 0).ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "Edited", txtRHZ_ChangeId.Text);
                if (retVal.Length > 5)
                {
                    resetKhassraFields();
                    btnLoadKhassras_Click(sender, e);

                }

            }
        }

        private void btnNewKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhatoonies.SelectedValue.ToString().Length > 1)
                {
                    frmKhassraNewKhassraAreaType frmKhassras = new frmKhassraNewKhassraAreaType();
                    frmKhassras.FormClosed -= new FormClosedEventHandler(frmKhassras_FormClosed);
                    frmKhassras.FormClosed += new FormClosedEventHandler(frmKhassras_FormClosed);
                    frmKhassras.KhatooniId = cboKhatoonies.SelectedValue.ToString();
                    frmKhassras.KhataNo = cbokhataNo.Text;
                    frmKhassras.KhatooniNo = cboKhatoonies.Text;
                    frmKhassras.MozaId = cmbMouza.SelectedValue.ToString();
                    frmKhassras.ShowDialog();
                }
                else
                {
                    MessageBox.Show("کھتونی کا انتخاب کریں", "خسرہ , قسم زمین و رقبہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmKhassras_FormClosed(object sender, FormClosedEventArgs e)
        {
            cboKhatoonies_SelectionChangeCommitted(sender, e);
        }

        private void btnDeleteKhassra_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(" کیا آپ انتخاب کردہ خسرہ کو حذف کرنا چاہتے ہے؟", "حذف کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    int NoOfDetails = 0;
                    foreach (DataGridViewRow row in dgKhatooniKhassras.Rows)
                    {
                        if (row.Cells["KhassraNo"].Value.ToString() == txtKhassraNo.Text.Trim())
                            NoOfDetails = NoOfDetails + 1;
                    }
                    if (NoOfDetails > 1)
                    {
                        frmKhassraDeletionInput di = new frmKhassraDeletionInput();
                        di.FormClosed -= new FormClosedEventHandler(di_FormClosed);
                        di.FormClosed += new FormClosedEventHandler(di_FormClosed);
                        di.ShowDialog();
                    }
                    else
                    {
                        //string KhassraNo = "0", AreaTypeId = "0", KhassraKanal = "0", KhassraMarla = "0", KhassraSarsai = "0";
                        //foreach (DataGridViewRow row in dgKhatooniKhassras.Rows)
                        //{
                        //    if (row.Cells["KhassraDetailId"].Value.ToString() == txtKhassraDetailId.Text)
                        //    {
                        //        KhassraNo = row.Cells["KhassraNo"].Value.ToString();
                        //        AreaTypeId = row.Cells["AreaTypeId"].Value.ToString();
                        //        KhassraKanal = row.Cells["Kanal"].Value.ToString();
                        //        KhassraMarla = row.Cells["Marla"].Value.ToString();
                        //        KhassraSarsai = row.Cells["Sarsai"].Value.ToString();
                        //        break;
                        //    }
                        //}
                        //string retVal = rhz.SaveKhassraRegisterEdit(txtKhassraRecId.Text, txtKhassraDetailRecId.Text, txtKhassraId.Text, cmbMouza.SelectedValue.ToString(), KhassraNo, txtKhassraNo.Text.Trim(), txtKhassraDetailId.Text, cboKhatoonies.SelectedValue.ToString(),
                        //   AreaTypeId, cboAreaType.SelectedValue.ToString(), KhassraKanal, txtKhassraKanal.Text.Trim(), KhassraMarla, txtKhassraMarla.Text.Trim(), KhassraSarsai, txtKhassraSarsai.Text.Trim(), Math.Round(float.Parse(KhassraSarsai) * 30.25, 0).ToString(), Math.Round(float.Parse(txtKhassraSarsai.Text.Trim()) * 30.25, 0).ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "CompleteDeleted", txtRHZ_ChangeId.Text);
                        string retVal = rhz.DeleteKhassraRegisterEdit(txtKhassraDetailRecId.Text);
                        if (retVal.Length > 5)
                        {
                            resetKhassraFields();
                            btnLoadKhassras_Click(sender, e);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void di_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKhassraDeletionInput di = sender as frmKhassraDeletionInput;
            bool isCompleteDelete = false;
            isCompleteDelete = di.isCompleteDelete;
            try
            {

                //rhz.
                string KhassraNo = "0", AreaTypeId = "0", KhassraKanal = "0", KhassraMarla = "0", KhassraSarsai = "0";
                foreach (DataGridViewRow row in dgKhatooniKhassras.Rows)
                {
                    if (row.Cells["KhassraDetailId"].Value.ToString() == txtKhassraDetailId.Text)
                    {
                        KhassraNo = row.Cells["KhassraNo"].Value.ToString();
                        AreaTypeId = row.Cells["AreaTypeId"].Value.ToString();
                        KhassraKanal = row.Cells["Kanal"].Value.ToString();
                        KhassraMarla = row.Cells["Marla"].Value.ToString();
                        KhassraSarsai = row.Cells["Sarsai"].Value.ToString();
                        break;
                    }
                }
                string deletionMode = "CompleteDeleted";
                if (!isCompleteDelete)
                {
                    deletionMode = "Deleted";
                }
                string retVal = rhz.SaveKhassraRegisterEdit(txtKhassraRecId.Text, txtKhassraDetailRecId.Text, txtKhassraId.Text, cmbMouza.SelectedValue.ToString(), KhassraNo, txtKhassraNo.Text.Trim(), txtKhassraDetailId.Text, cboKhatoonies.SelectedValue.ToString(),
                    AreaTypeId, cboAreaType.SelectedValue.ToString(), KhassraKanal, txtKhassraKanal.Text.Trim(), KhassraMarla, txtKhassraMarla.Text.Trim(), KhassraSarsai, txtKhassraSarsai.Text.Trim(), Math.Round(float.Parse(KhassraSarsai) * 30.25, 0).ToString(), Math.Round(float.Parse(txtKhassraSarsai.Text.Trim()) * 30.25, 0).ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, deletionMode, txtRHZ_ChangeId.Text);
                if (retVal.Length > 5)
                {
                    resetKhassraFields();
                    btnLoadKhassras_Click(sender, e);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetKhassraFields()
        {
            txtKhassraRecId.Text = "-1";
            txtKhassraId.Text = "-1";
            txtKhassraDetailId.Text = "-1";
            txtKhassraDetailRecId.Text = "-1";
            txtKhassraKanal.Clear();
            txtKhassraMarla.Clear();
            txtKhassraSarsai.Clear();
        }


        private void dgkhatooniKhassraEdit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColKhassraEditSel"].Value = 1;
                        //txtKhatooniIdofKhassra.Text = row.Cells["KhatooniId"].Value.ToString();
                        //cboKhatoni.SelectedValue = row.Cells["KhatooniId"].Value.ToString();
                        txtKhassraNo.Text = row.Cells["KhassraNo_Proposed"].Value.ToString().Length > 0 ? row.Cells["KhassraNo_Proposed"].Value.ToString() : row.Cells["KhassraNo"].Value.ToString();
                        //txt.Text = row.Cells["KhassraNo_Proposed"].Value.ToString();
                        txtKhassraId.Text = row.Cells["KhassraId"].Value.ToString();
                        txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
                        //txtKhassraRecId.Text = row.Cells["KhassraRecId"].Value.ToString();
                        //txtKhassraDetailRecId.Text = row.Cells["KhassraDetailRecId"].Value.ToString();
                        // txtkh.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                        cboAreaType.SelectedValue = row.Cells["AreaTypeIdProp"].Value.ToString();
                        txtKhassraKanal.Text = row.Cells["Kanal_Proposed"].Value.ToString();
                        txtKhassraMarla.Text = row.Cells["Marla_Proposed"].Value.ToString();
                        txtKhassraSarsai.Text = row.Cells["Sarsai_Proposed"].Value.ToString();
                        txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();
                        txtKhassraDetailRecId.Text = row.Cells["KhassraDetailRecId"].Value.ToString().Length > 5 ? row.Cells["KhassraDetailRecId"].Value.ToString() : "0";
                        txtKhassraRecId.Text = row.Cells["KhassraRecId"].Value.ToString().Length > 5 ? row.Cells["KhassraRecId"].Value.ToString() : "-1";
                        //txtDrustKhassraKanal.Text = row.Cells["Kanal_Proposed"].Value.ToString();
                        //txtDrustKhassraMarla.Text = row.Cells["Marla_Proposed"].Value.ToString();
                        //txtDrustKhassraSarsai.Text = row.Cells["Sarsai_Proposed"].Value.ToString();

                    }
                    else
                    {
                        row.Cells["ColKhassraEditSel"].Value = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnImplementChanges_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فرد انتخاب کردہ ترامیم پر عملدرامد کرنا چاہتے ہے؟", "عمل کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (txtRHZ_ChangeId.Text.Trim().Length > 5)
                    {
                        string retVal = rhz.RHZ_ChangeImplementation(txtRHZ_ChangeId.Text);
                        if (retVal.Length > 5)
                            MessageBox.Show("انتخاب کردہ ریکارڈ پر عمل درامد ہو چکا ہے۔");
                        //cmbMouza_SelectionChangeCommitted(sender, e);
                        //cbSrNo_SelectionChangeCommitted(sender, e);
                        txtSerialNo.Text = getNextSrNoByMoza(cmbMouza.SelectedValue.ToString());
                        fillSrNoCombo();
                        cbokhataNo.SelectedValue = 0;
                        tabControlMain.Enabled = false;
                    }
                    else
                        MessageBox.Show("عملدارمد کرنے کیلئے پہلے ریکارڈ کا انتخاب کریں", "ناقابل عمل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPrintProposedChanges_Click(object sender, EventArgs e)
        {
            if (cbSrNo.SelectedValue.ToString() != "0")
            {
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 44;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.FbID = cbSrNo.SelectedValue.ToString();
                obj.MozaId = cmbMouza.SelectedValue.ToString();
                obj.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSaveSrNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSerialNo.Text.Trim().Length > 0 && txtDetails.Text.Trim().Length > 0)
                {
                    string retVal = rhz.SaveRHZChangeDetails(txtRHZ_ChangeId.Text, cmbMouza.SelectedValue.ToString(), txtSerialNo.Text.Trim(), txtDetails.Text.Trim());
                    if (retVal.Length > 5)
                    {
                        MessageBox.Show("درج شدہ تفصیل محوظ ہو چکا ہے۔");
                        txtDetails.Clear();
                        fillSrNoCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNewDetails_Click(object sender, EventArgs e)
        {
            txtSerialNo.Text = getNextSrNoByMoza(cmbMouza.SelectedValue.ToString());
            txtDetails.Clear();
            txtRHZ_ChangeId.Text = "-1";
            tabControlMain.Enabled = true;
        }

        private void cbSrNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            resetKhataFields();
            ResetMalakEntryFields();
            resetKhatooniFields();
            resetKhassraFields();
            ResetMushteriEntryFields();
            bool ImplementedBy = false;
            DataRow[] row = dtRHZchangeDetailsList.Select("RHZ_ChangeId=" + cbSrNo.SelectedValue.ToString());
            txtSerialNo.Text = row[0]["SrNo"].ToString();
            txtRHZ_ChangeId.Text = row[0]["RHZ_ChangeId"].ToString();
            txtDetails.Text = row[0]["ChangeDetails"].ToString();
            ImplementedBy = row[0]["ImplemnetedBy"].ToString() == "0" ? false : true;
            tabControlMain.Enabled = !ImplementedBy ? (row[0]["InsertUserId"].ToString() == UsersManagments.UserId.ToString() ? true : false) : false;//ImplemnetedBy
            PopulateDgKhataJatEdited();
            FillDgFBAfrad();
            btnImplementChanges.Enabled = UsersManagments._IsAdmin && !ImplementedBy;

        }

        private void PopulateDgKhataJatEdited()
        {
            DataTable dtKhatajatEdited = rhz.GetKhatajatEditedByRHZ_ChangeId(cmbMouza.SelectedValue.ToString(), txtRHZ_ChangeId.Text);
            dgKhatajatProposed.DataSource = dtKhatajatEdited;
            dgKhatajatProposed.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            dgKhatajatProposed.Columns["TotalParts"].HeaderText = "کھاتہ کل حصے";
            dgKhatajatProposed.Columns["Khata_Area"].HeaderText = "کھاتہ کل رقبہ";
            dgKhatajatProposed.Columns["Kyfiat"].HeaderText = "کیفیت";
            dgKhatajatProposed.Columns["KhataNoProp"].HeaderText = "مجوزہ نمبر ";
            dgKhatajatProposed.Columns["TotalPartsProp"].HeaderText = " مجوزہ حصے ";
            dgKhatajatProposed.Columns["Khata_AreaIProp"].HeaderText = " مجوزہ رقبہ";
            dgKhatajatProposed.Columns["KyfiatProp"].HeaderText = "مجوزہ کیفیت";
            dgKhatajatProposed.Columns["RecStatusProp"].HeaderText = "مجوزہ حالت";
            dgKhatajatProposed.Columns["RegisterHaqdaranId"].Visible = false;
            dgKhatajatProposed.Columns["RegisterHqDKhataId"].Visible = false;
            dgKhatajatProposed.Columns["KhataRecId"].Visible = false;
            dgKhatajatProposed.Columns["Kanal"].Visible = false;
            dgKhatajatProposed.Columns["Marla"].Visible = false;
            dgKhatajatProposed.Columns["sarsai"].Visible = false;
            dgKhatajatProposed.Columns["KanalProp"].Visible = false;
            dgKhatajatProposed.Columns["MarlaProp"].Visible = false;
            dgKhatajatProposed.Columns["sarsaiProp"].Visible = false;
            dgKhatajatProposed.Columns["RecStatus"].Visible = false;//RecStatusProp
            //dgKhatajatProposed.Columns["RecStatusProp"].Visible = false;

        }

        private void dgKhatajatProposed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgKhatajatProposed.SelectedRows.Count > 0)
                {
                    cbokhataNo.Enabled = true;
                    foreach (DataGridViewRow row in dgKhatajatProposed.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["dgKhataEditColSel"].Value = true;
                            bool KhataStatus = (bool)row.Cells["RecStatus"].Value;
                            //if (KhataStatus)
                            //{
                                cbokhataNo.SelectedValue = row.Cells["RegisterHqDKhataId"].Value;
                                cbokhataNo.Text = row.Cells["KhataNo"].Value.ToString();
                                //cbokhataNo_SelectionChangeCommitted(sender, e);
                                cbokhataNo.Enabled = KhataStatus;
                            //}
                            //else
                            //{
                                txtKhataNoProp.Text = row.Cells["KhataNoProp"].Value.ToString();
                                cbokhataNo.Text = row.Cells["KhataNo"].Value.ToString();
                                //cbokhataNo.Enabled = false;
                                this.txtKhataHissa.Text = row.Cells["TotalParts"].Value.ToString();
                                txtKhataHissaProp.Text = row.Cells["TotalPartsProp"].Value.ToString();
                                txtKhataMeezanKulHissay.Text = row.Cells["TotalParts"].Value.ToString();
                                this.txtKhataKanal.Text = row.Cells["Kanal"].Value.ToString();
                                this.txtKhataKanalProp.Text = row.Cells["KanalProp"].Value.ToString();
                                txtKhataMarla.Text = row.Cells["Marla"].Value.ToString();
                                txtKhataMarlaProp.Text = row.Cells["MarlaProp"].Value.ToString();
                                txtKhataSarsai.Text = row.Cells["sarsai"].Value.ToString();
                                txtKhataSarsaiProp.Text = row.Cells["sarsaiProp"].Value.ToString();
                                txtKhataSFT.Text = Math.Round(float.Parse(row.Cells["sarsai"].Value.ToString()) * (float)30.25, 0).ToString();
                                txtKhataSFTprop.Text = txtKhataSFT.Text;
                                txtKhataMeezanRaqba.Text = txtKhataKanal.Text + "-" + txtKhataMarla.Text + "-" + txtKhataSarsai.Text;
                                txtKhataKifiat.Text = row.Cells["Kyfiat"].Value.ToString();
                                txtKhataKifiatProp.Text = row.Cells["KyfiatProp"].Value.ToString();
                                this.KhataId = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                txtKhataRecId.Text = row.Cells["KhataRecId"].Value.ToString();
                                cbokhataNo_SelectionChangeCommitted(sender, e);
                            //}
                        }
                        else
                            row.Cells["dgKhataEditColSel"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelProposedKhata_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    string retVal = rhz.DeleteHaqdaranZameenKhatajatEdit(this.KhataId, txtRHZ_ChangeId.Text);
                    if (retVal.Length > 5)
                    {
                        MessageBox.Show("ریکارڈ حذف ہو گیا۔");
                        PopulateDgKhataJatEdited();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                this.cbQoamExisted.SelectedValue = ap.QoamId;
                if (!string.IsNullOrEmpty(ap.CNIC) && ap.CNIC != "0")
                {
                    txtNIC.Text = ap.CNIC;
                }
                this.txtDrustNaam.Text = ap.PersonNameForFB;
                this.txtfbShajraOldName.Text = ap.PersonNameForFB;
                this.txtName.Text = ap.PersonName;
                if (SelectedPersonId.Length > 5)
                {
                    try
                    {
                        txtPersonKhatajat.Text =rhz.GetKhatajatStringByPersonId(SelectedPersonId).Rows.Count>0? rhz.GetKhatajatStringByPersonId(SelectedPersonId).Rows[0][0].ToString():"";
                        txtPersonIntiqalat.Text =rhz.GetIntiqalatByPersonId(SelectedPersonId).Rows.Count>0 ?rhz.GetIntiqalatByPersonId(SelectedPersonId).Rows[0][0].ToString():"";
                        txtPersonFardats.Text = rhz.GetFardatsByPersonId(SelectedPersonId).Rows.Count>0? rhz.GetFardatsByPersonId(SelectedPersonId).Rows[0][0].ToString():"";
                        txtPersonFardBadrat.Text = rhz.GetFardBadratByPersonId(SelectedPersonId).Rows.Count>0? rhz.GetFardBadratByPersonId(SelectedPersonId).Rows[0][0].ToString():"";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
         
                }
            }

        }

        private void btnSaveShajra_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString() == null)
            {
                MessageBox.Show("موضع چنیے", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMouza.Focus();
                return;
            }
            else if (txtRHZ_ChangeId.Text.Length<5)
            {
                MessageBox.Show(" نمبر شمار کا انتخاب کریں ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtFardBadarDocNO.Focus();
                return;
            }
            else if (this.SelectedPersonId.Length<5 || this.txtName.Text.Trim().Length<5)
            {
                MessageBox.Show("نام درستگی کے لیے فرد کا انتخاب کریں ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cnicProp = txtDrustNIC.Text.Trim().Length>5 ? txtDrustNIC.Text : "0";
            try
            {
                string lastId = rhz.SaveProposedNameToShajra(txtPersonRecId.Text, txtRHZ_ChangeId.Text, this.SelectedPersonId, this.cbQoam.SelectedValue.ToString(),cnicProp, this.txtDrustNaam.Text, "Edited", UsersManagments.UserId.ToString(), UsersManagments.UserName);
                if (lastId.Length>5)
                {
                    MessageBox.Show("نام درستگی محفوظ ہوگیاہے۔", "ریکارڈ محفوظ ہو گیا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtDrustNaam.Clear();
                    txtPersonRecId.Text = "-1";
                    //cmbMouza.SelectedValue = 0;
                    cbQoam.SelectedValue = 0;
                    cbQoamExisted.SelectedValue = 0;
                    txtNIC.Clear();
                    txtDrustNIC.Clear();
                    this.FillDgFBAfrad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Load Save Fb Afrad gridview
        private void FillDgFBAfrad()
        {
            dtAfradRegisterEdit.Clear();
            dgFBAfrad.DataSource = null;
            dtAfradRegisterEdit = rhz.GetAfradListProposed(txtRHZ_ChangeId.Text);

            if (dtAfradRegisterEdit.Rows.Count > 0)
            {
                dgFBAfrad.DataSource = dtAfradRegisterEdit;
                dgFBAfrad.Columns["PersonId"].Visible = false;
                dgFBAfrad.Columns["QoamIdProp"].Visible = false;
                dgFBAfrad.Columns["QoamId"].Visible = false;
                dgFBAfrad.Columns["PersonRecId"].Visible = false;

                dgFBAfrad.Columns["PersonName"].HeaderText = "موجودہ نام";
                dgFBAfrad.Columns["PersonNameProp"].HeaderText = "مجوزہ نام";
                dgFBAfrad.Columns["CNIC"].HeaderText = "موجودہ شناختی کارڈ٘";
                dgFBAfrad.Columns["CNICProp"].HeaderText = "مجوزہ شناختی کارڈ";
                dgFBAfrad.Columns["Qoam"].HeaderText = "موجودہ قوم";
                dgFBAfrad.Columns["QoamProp"].HeaderText = "مجوزہ قوم";
                //loadFbData(txtFardBadarDocNO.Text);FamilyNameProposed
            }
        }
        #endregion

        private void dgFBAfrad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFBAfrad.SelectedRows.Count > 0)
            {
                txtName.Text = dgFBAfrad.SelectedRows[0].Cells["PersonName"].Value.ToString();
                SelectedPersonId = dgFBAfrad.SelectedRows[0].Cells["PersonId"].Value.ToString();
                txtDrustNaam.Text = dgFBAfrad.SelectedRows[0].Cells["PersonNameProp"].Value.ToString();
                txtNIC.Text = dgFBAfrad.SelectedRows[0].Cells["CNIC"].Value.ToString();
                txtDrustNIC.Text = dgFBAfrad.SelectedRows[0].Cells["CNICProp"].Value.ToString();
                cbQoamExisted.SelectedValue = dgFBAfrad.SelectedRows[0].Cells["QoamId"].Value;
                cbQoam.SelectedValue = dgFBAfrad.SelectedRows[0].Cells["QoamIdProp"].Value.ToString();
                txtPersonRecId.Text = dgFBAfrad.SelectedRows[0].Cells["PersonRecId"].Value.ToString();
                dgFBAfrad.SelectedRows[0].Cells["ColSelPerson"].Value = true;
            }
            foreach (DataGridViewRow row in dgFBAfrad.Rows)
            {
                if (!row.Selected)
                {
                    dgFBAfrad.SelectedRows[0].Cells["ColSelPerson"].Value = false;
                }
            }
        }

        private void dgMushteriFareeqainDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgMushteriFareeqainAll.Rows)
            {
                if (row.Selected)
                {
                    ResetMushteriEntryFields();
                    row.Cells["ColSelMushtri"].Value = true;
                    //txtKhatooniLaganProp.Text = row.Cells["KhatooniLaganProp"].ToString();
                    txtMushteriFareeqId.Text = row.Cells["MushtriFareeqId"].Value.ToString();
                    txtMalikNameMushtri.Text = row.Cells["CompleteName"].Value.ToString();
                    txtPersonIdMushteri.Text = row.Cells["PersonId"].Value.ToString();
                    txtMushteriHisa.Text = row.Cells["FardAreaPart"].Value.ToString();
                    txtMushtriHisaBata.Text = row.Cells["FardPart_Bata"].Value.ToString();
                    txtSeqNoMushtri.Text = row.Cells["SeqNo"].Value.ToString();
                    cbMushtriKhewatType.SelectedValue = row.Cells["KhewatTypeId"].Value;
                    chkRecStatus.Checked = row.Cells["RecStatus"].Value.ToString()=="موجودہ"?true:false;
                    foreach (DataGridViewRow r in dgMushteriFareeqainEdit.Rows) //ColSelMushtriEdit\
                    {
                        if (r.Cells["MushtriFareeqId"].Value.ToString() == row.Cells["MushtriFareeqId"].Value.ToString())
                        {
                            txtMushteriFareeqRecId.Text = r.Cells["MushteriFareeqRecId"].Value.ToString();
                            txtPersonIdMushteri.Text = r.Cells["PersonId_Proposed"].Value.ToString();
                            txtMalikNameMushtri.Text = r.Cells["NameProp"].Value.ToString();
                            txtMushteriHisa.Text = r.Cells["FardAreaPart_Proposed"].Value.ToString();
                            txtMushtriHisaBata.Text = r.Cells["FardPart_Bata_Proposed"].Value.ToString();
                            cbMushtriKhewatType.SelectedValue = r.Cells["KhewatTypeIdProposed"].Value;
                            chkRecStatus.Checked = bool.Parse(r.Cells["RecStatusProp"].Value.ToString());
                            txtSeqNoMushtri.Text = r.Cells["SeqNoProp"].Value.ToString();
                        }
                    }
                }
                else
                    row.Cells["ColSelMushtri"].Value = false;
            }
        }

        private void dgKhatooniesEdit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dgKhatooniesEdit.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColSelKhatooni"].Value = true;
                    //txtKhatooniLaganProp.Text = row.Cells["KhatooniLaganProp"].ToString();
                    txtKhatooniNoProp.Text = row.Cells["KhatooniNoProp"].Value.ToString();
                    //txtWasailAbpashiProp.Text = row.Cells["Wasail_e_AbpashiProp"].ToString();
                    txtKhatooniFullDetails.Text = row.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString();
                    txtKhatooniFullDetailsProp.Text = row.Cells["KhatooniKashtkaranFullDetail_NewProp"].Value.ToString();
                    txtKhatooniRecId.Text = row.Cells["KhatooniRecId"].Value.ToString();
                    chkBeahShoda.Checked = Convert.ToBoolean(row.Cells["Beahshuda"].Value.ToString());
                    chkBeahShudaProp.Checked = Convert.ToBoolean(row.Cells["BeahShudaProp"].Value.ToString());
                    txtKhatooniHissa.Text = row.Cells["Hissa"].Value.ToString();
                    txtKhatooniHissaProp.Text = row.Cells["HissaProp"].Value.ToString();
                    txtKhatooniKanal.Text = row.Cells["Kanal"].Value.ToString();
                    txtKhatooniKanalProp.Text = row.Cells["KanalProp"].Value.ToString();
                    txtKhatooniMarla.Text = row.Cells["Marla"].Value.ToString();
                    txtKhatooniMarlaProp.Text = row.Cells["MarlaProp"].Value.ToString();
                    txtKhatooniSarsai.Text = row.Cells["Sarsai"].Value.ToString();
                    txtKhatooniSarsaiProp.Text = row.Cells["SarsaiProp"].Value.ToString();
                    txtKhatooniFeet.Text = row.Cells["Feet"].Value.ToString();
                    txtKhatooniFeetProp.Text = row.Cells["FeetProp"].Value.ToString();
                    cboKhatoonies.SelectedValue = row.Cells["KhatooniId"].Value;
                    cboKhatoonies_SelectionChangeCommitted(sender, e);
                }
                else
                    row.Cells["ColSelKhatooni"].Value = false;
            }
        }

        private void txtKhatooniNoProp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar != 8 && e.KeyChar != 13) && (e.KeyChar < 45 || e.KeyChar > 58))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewMushteri_Click(object sender, EventArgs e)
        {
            ResetMushteriEntryFields();
            frmSearchPerson person = new frmSearchPerson();
            person.MozaId = cmbMouza.SelectedValue.ToString();
            person.FormClosed -= new FormClosedEventHandler(person_FormClosed);
            person.FormClosed += new FormClosedEventHandler(person_FormClosed);
            person.ShowDialog();
        }

        void person_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson p = sender as frmSearchPerson;
            txtPersonIdMushteri.Text = p.PersonId.ToString();
            txtMalikNameMushtri.Text = p.PersonName;
        }

        private void btnSelectPersonMushteri_Click(object sender, EventArgs e)
        {
            frmSearchPerson person = new frmSearchPerson();
            person.MozaId = cmbMouza.SelectedValue.ToString();
            person.FormClosed -= new FormClosedEventHandler(person_FormClosed);
            person.FormClosed += new FormClosedEventHandler(person_FormClosed);
            person.ShowDialog();
        }

        private void btnSaveMushteriFareeq_Click(object sender, EventArgs e)
        {
            if (txtPersonIdMushteri.Text.Length > 5 && cboKhatoonies.SelectedValue.ToString().Length > 5 && cbMushtriKhewatType.SelectedValue.ToString().Length > 2 && txtMushteriHisa.Text.Trim().Length > 0 && txtSeqNoMushtri.Text.Length>0)
            {
                if(txtKhatooniHissa.Text.Length<1 || txtKhatooniKanal.Text.Length<1 || txtKhatooniMarla.Text.Length<1 || txtKhatooniSarsai.Text.Length<1 )
                {
                    MessageBox.Show("کھتونی کے حصے اور رقبہ چیک کریں۔ مشتری محفوظ کرنے سے پہلے کھتونی کے حصص اور رقبہ کا تعین ضروری ہیں۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                string[] Area= cmnFn.CalculatedAreaFromHisa(float.Parse(txtKhatooniHissa.Text), float.Parse(txtMushteriHisa.Text), int.Parse(txtKhatooniKanal.Text), int.Parse(txtKhatooniMarla.Text), float.Parse(txtKhatooniSarsai.Text), float.Parse(txtKhatooniFeet.Text));
                string retVal = "0";
                if (txtMushteriFareeqId.Text == "-1")
                {
                    retVal = khatooni.SaveMushtriFareeqein(txtMushteriFareeqId.Text, "0", "Data Entry", "0", cboKhatoonies.SelectedValue.ToString(), txtSeqNoMushtri.Text, txtPersonIdMushteri.Text, "0", cbMushtriKhewatType.SelectedValue.ToString(), "0", "0", "0", "0", "0", "0", UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    txtMushteriFareeqId.Text = retVal;
                }
                if (txtMushteriFareeqId.Text.Length > 5)
                {
                    retVal = rhz.SaveMushteriFareeqEdit(txtMushteriFareeqRecId.Text, cbSrNo.SelectedValue.ToString(), txtMushteriFareeqId.Text, txtPersonIdMushteri.Text, cbMushtriKhewatType.SelectedValue.ToString(), txtMushteriHisa.Text, txtMushtriHisaBata.Text, Area[0] != null ? Area[0] : "0", Area[1] != null ? Area[1] : "0", Area[2] != null ? Area[2] : "0", Area[3] != null ? Area[3] : "0", UsersManagments.UserId.ToString(), UsersManagments.UserName, chkRecStatus.Checked ? "1" : "0", txtSeqNoMushtri.Text);
                    FillMushteriFareeqainEdit();
                    ResetMushteriEntryFields();
                }
                }
            }
            else
                MessageBox.Show("مشتری کے تمام کوائف پر کریں");
        }

        private void FillMushteriFareeqainEdit()
        {
                    DataTable dtMushteriFareeqainEdit = rhz.GetMushteriFareeqainEdit(cboKhatoonies.SelectedValue.ToString());
                    dgMushteriFareeqainEdit.DataSource = dtMushteriFareeqainEdit;
                    dgMushteriFareeqainEdit.Columns["CompleteName"].HeaderText = "نام مالک";
                    dgMushteriFareeqainEdit.Columns["NameProp"].HeaderText = "مجوزہ نام";
                    dgMushteriFareeqainEdit.Columns["KhewatType"].HeaderText = "قسم ملکیت";
                    dgMushteriFareeqainEdit.Columns["KhewatTypeProp"].HeaderText = "مجوزہ قسم";
                    dgMushteriFareeqainEdit.Columns["FardAreaPart"].HeaderText = "حصہ";
                    dgMushteriFareeqainEdit.Columns["FardAreaPart_Proposed"].HeaderText = "مجوزہ حصہ";
                    dgMushteriFareeqainEdit.Columns["Area"].HeaderText = "رقبہ";
                    dgMushteriFareeqainEdit.Columns["AreaProp"].HeaderText = "مجوزہ رقبہ";
                    dgMushteriFareeqainEdit.Columns["RecStatus"].HeaderText = "حالت";
                    dgMushteriFareeqainEdit.Columns["SeqNo"].HeaderText = "نمبر شمار";
                    dgMushteriFareeqainEdit.Columns["SeqNoProp"].HeaderText = "نمبرمجوزہ";
                    dgMushteriFareeqainEdit.Columns["MushteriFareeqRecId"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["MushtriFareeqId"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["PersonId"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["PersonId_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["KhewatTypeId"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["KhewatTypeIdProposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Farad_Kanal"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Farad_Kanal_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Marla"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Marla_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Sarsai"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Sarsai_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Feet"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["Fard_Feet_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["FardPart_Bata"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["FardPart_Bata_Proposed"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["RecStatus"].Visible = false;
                    dgMushteriFareeqainEdit.Columns["RecStatusProp"].Visible = false;
               
        }

        private void dgMushteriFareeqainEdit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetMushteriEntryFields();
            foreach (DataGridViewRow r in dgMushteriFareeqainEdit.Rows) //ColSelMushtriEdit\
            {
                
                if (r.Selected)
                {
                    r.Cells["ColSelMushtriEdit"].Value = true;
                    txtMushteriFareeqRecId.Text = r.Cells["MushteriFareeqRecId"].Value.ToString();
                    txtPersonIdMushteri.Text = r.Cells["PersonId_Proposed"].Value.ToString();
                    txtMalikNameMushtri.Text = r.Cells["NameProp"].Value.ToString();
                    txtMushteriHisa.Text = r.Cells["FardAreaPart_Proposed"].Value.ToString();
                    txtMushtriHisaBata.Text = r.Cells["FardPart_Bata_Proposed"].Value.ToString();
                    cbMushtriKhewatType.SelectedValue = r.Cells["KhewatTypeIdProposed"].Value;
                    chkRecStatus.Checked = bool.Parse(r.Cells["RecStatusProp"].Value.ToString());
                }
                else
                    r.Cells["ColSelMushtriEdit"].Value=false;
            }
        }

        private void txtMushtriHisaBata_Leave(object sender, EventArgs e)
        {
            this.txtMushteriHisa.Text = this.calculateNetPart(this.txtMushtriHisaBata.Text.Trim().Length > 0 ? txtMushtriHisaBata.Text.Trim() : "0").ToString();
            if (txtMushteriHisa.Text.Length > 0)
            {
                string[] Area = cfs.CalculatedAreaFromHisa(float.Parse(txtKhatooniHissa.Text.Length > 0 ? txtKhatooniHissa.Text : "0"), float.Parse(txtMushteriHisa.Text), int.Parse(txtKhatooniKanal.Text.Length > 0 ? txtKhatooniKanal.Text : "0"), int.Parse(txtKhatooniMarla.Text.Length > 0 ? txtKhatooniMarla.Text : "0"), float.Parse(txtKhatooniSarsai.Text.Length > 0 ? txtKhatooniSarsai.Text : "0"), float.Parse(txtKhatooniFeet.Text.Length > 0 ? txtKhatooniFeet.Text : "0"));
                //txtKashtKanal.Text = Area[0] != null ? Area[0] : "0";
                //txtKashtMarla.Text = Area[1] != null ? Area[1] : "0";
                //txtKashtSarsai.Text = Area[2] != null ? Area[2] : "0";
                //txtKashtFeet.Text = Area[3] != null ? Area[3] : "0";
            }
        }

        private void btnDelMushteri_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(" کیا آپ انتخاب کردہ مجوزہ مشتری کو حذف کرنا چاہتے ہے؟", "حذف کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (txtMushteriFareeqRecId.Text.Length > 5)
                    {
                       string retVal= rhz.DeleteMushtriFareeqEdit(txtMushteriFareeqRecId.Text);
                       if (retVal.Length > 5)
                       {
                           ResetMushteriEntryFields();
                           FillMushteriFareeqainEdit();
                       }
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