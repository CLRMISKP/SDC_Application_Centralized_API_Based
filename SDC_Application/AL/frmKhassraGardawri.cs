using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmKhassraGardawri : Form
    {

        #region Class Vderialbes

        AutoComplete objauto = new AutoComplete();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        Khatoonies Khatooni = new Khatoonies();
        DataTable dtkj = new DataTable();
        Misal misal = new Misal();
        LanguageConverter lang = new LanguageConverter();
        Gardawri gardawri = new Gardawri();
        DataTable GetGardawri = new DataTable();
        DataTable dtKhassraDetails = new DataTable();
        CommanFunctions cmn = new CommanFunctions();
        public string KhatooniKashtkaranDetails { get; set; }
        #endregion

        #region Default Constructor

        public frmKhassraGardawri()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event
        
        private void frmKhassraGardawri_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            //objauto.FillCombo("proc_Get_AreaTypes "+UsersManagments._Tehsilid.ToString(), cbAreaTypes, "AreaType", "AreaTypeId");
            objauto.FillCombo("proc_Get_AreaTypes " + UsersManagments._Tehsilid.ToString(), cbAreaTypesNew, "AreaType", "AreaTypeId");
            objauto.FillCombo("Proc_Get_Gardawri_KhassraNature ", cbKhassraNature, "KhassraNatureType", "KhassraNatureId");
        }

        #endregion

        #region Combobox Mouza Change Event

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
           
            FillKhatooniList();
     
        }

        #region Get Khatoonies List

        private void FillKhatooniList()
        {
            try
            {
                DataTable KhatooniesByKhata = new DataTable();
                string KhataId = cbokhataNo.SelectedValue.ToString();
                KhatooniesByKhata = Khatooni.GetKhatooniNosListbyKhataId(KhataId.ToString());
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

        #endregion

        #endregion

        #region Khatooni Combobox Selection Change Event

        private void cboKhatoonies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable khatooniKhassraDetail = new DataTable();
                DataTable khatooniKhassraTaghairat = new DataTable();
                string KhataId = cbokhataNo.SelectedValue.ToString();
                khatooniKhassraDetail = Khatooni.GetKhassraListByKhatooni(cboKhatoonies.SelectedValue.ToString());
                DataRow row = khatooniKhassraDetail.NewRow();
                row["KhassraId"] = 0;
                row["KhassraNo"] = "- انتخاب نمبر خسرہ  -";
                khatooniKhassraDetail.Rows.InsertAt(row, 0);
                //--- Mian Gardawri Khassra Drop down ---//
                cboKhassraList.DataSource = khatooniKhassraDetail;
                cboKhassraList.DisplayMember = "KhassraNo";
                cboKhassraList.ValueMember = "KhassraId";
                //--- Taghairat Khassra Drop down ---//
                khatooniKhassraTaghairat = Khatooni.GetKhassraListByKhatooni(cboKhatoonies.SelectedValue.ToString());
                DataRow row1 = khatooniKhassraTaghairat.NewRow();
                row1["KhassraId"] = 0;
                row1["KhassraNo"] = "- انتخاب نمبر خسرہ -";
                khatooniKhassraTaghairat.Rows.InsertAt(row1, 0);
                cbKhassrasQismZameen.DataSource = khatooniKhassraTaghairat;
                cbKhassrasQismZameen.DisplayMember = "KhassraNo";
                cbKhassrasQismZameen.ValueMember = "KhassraId";
                GetGardawriKashtFasalDetails();
                GetGardawriTaghairatDetails();
                DataTable dtkhatooniDetails = Khatooni.GetKhatooniDetailbyKhatooniId(cboKhatoonies.SelectedValue.ToString());
                if (dtkhatooniDetails.Rows.Count > 0)
                {
                    KhatooniKashtkaranDetails = dtkhatooniDetails.Rows[0]["KhatooniKashtkaranFullDetail_New"].ToString();
                    txtKhatooniLaganPossession.Text = dtkhatooniDetails.Rows[0]["KhatooniKashtkaranFullDetail_New"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Key Press Events for auto language conversion

        private void txtKhatooniLaganPossession_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Save Gardawri

        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhassraList.SelectedValue.ToString() != "0" && cboHarifRabeah.Text.Trim() != "" && cmbMouza.SelectedValue.ToString()!="0")
                {
                    string retVal = gardawri.SaveGardawriKashtFasal(txtGardawriKashtFasalId.Text,UsersManagments._Tehsilid.ToString() ,txtGardawriId.Text, cboKhatoonies.SelectedValue.ToString(), cboKhassraList.SelectedValue.ToString(), cbKhassraNature.SelectedValue.ToString(), "0", txtKhatooniLaganPossession.Text, txtFasalDetail.Text, "", txtKyfiat.Text, UsersManagments.UserName, UsersManagments.UserId.ToString());
                    if (retVal != "0")
                    {
                        //MessageBox.Show("خسرہ گرداوری اندراج محفوظ ہو گیا۔");
                        GetGardawriKashtFasalDetails();
                        this.resetFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region fill Gardawri fasal details and taghairat gridviews

        private void GetGardawriDetails()
        {
            try
            {
            this.GetGardawri = gardawri.GetGardawriByMouzaByYearByKhassra(dtpDateGardawari.Text, cmbMouza.SelectedValue.ToString(), cboKhassraList.SelectedValue.ToString());
            GridViewKhassraGardawri.DataSource = this.GetGardawri;
            GridViewKhassraGardawri.Columns["Khassrano"].HeaderText = "نمبر خسرہ";
            GridViewKhassraGardawri.Columns["FasalType"].HeaderText = "حریف/ربیعہ";
            GridViewKhassraGardawri.Columns["FasalDetails"].HeaderText = "فصل";
            GridViewKhassraGardawri.Columns["GardawriYear"].HeaderText = "سنہ";
            GridViewKhassraGardawri.Columns["KashtkaranTafseel"].HeaderText = "تبدیلی حقوق کاشت یا قبضہ و لگان";
            GridViewKhassraGardawri.Columns["WasileAbpashi"].HeaderText = "کیفیت";
            GridViewKhassraGardawri.Columns["GardawariId"].Visible = false;
            GridViewKhassraGardawri.Columns["KhassraId"].Visible = false;
            GridViewKhassraGardawri.Columns["AreaTypeId"].Visible = false;
            GridViewKhassraGardawri.Columns["GardawriDate"].Visible = false;
            GridViewKhassraGardawri.Columns["isConfirmed"].Visible = false;
            GridViewKhassraGardawri.Columns["Attested"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetGardawriKashtFasalDetails()
        {
            try
            {
                this.GetGardawri = gardawri.GetGardawriByGardawriKhatooniId(txtGardawriId.Text, cboKhatoonies.SelectedValue.ToString());
                GridViewKhassraGardawri.DataSource = this.GetGardawri;
                GridViewKhassraGardawri.Columns["Khassrano"].HeaderText = "نمبر خسرہ";
                GridViewKhassraGardawri.Columns["KashtkaranTafseel"].HeaderText = "تبدیلی حقوق کاشت یا قبضہ و لگان";
                GridViewKhassraGardawri.Columns["FasalDetails"].HeaderText = "تفصیل فصل";
                GridViewKhassraGardawri.Columns["WasileAbpashi"].HeaderText = "وسائل آبپاشی";
                GridViewKhassraGardawri.Columns["Kyfiyat"].HeaderText = "کیفیت";
                GridViewKhassraGardawri.Columns["KhassraNatureType"].HeaderText = "نوعیت خسرہ";
                GridViewKhassraGardawri.Columns["GardawariId"].Visible = false;
                GridViewKhassraGardawri.Columns["KhassraId"].Visible = false;
                GridViewKhassraGardawri.Columns["GardawriKashtFasalId"].Visible = false;
                GridViewKhassraGardawri.Columns["KhatooniId"].Visible = false;
                GridViewKhassraGardawri.Columns["KhassraTypeId"].Visible = false;
                GridViewKhassraGardawri.Columns["KhassraSubTypeId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetGardawriTaghairatDetails()
        {
            try
            {
                this.dtKhassraDetails = gardawri.GetGardawriTaghairat(txtGardawriId.Text, cboKhatoonies.SelectedValue.ToString());
                dgKhassraDetails.DataSource = this.dtKhassraDetails;
                dgKhassraDetails.Columns["Khassrano"].HeaderText = "نمبر خسرہ";
                dgKhassraDetails.Columns["Kanal"].HeaderText = "موجودہ کنال";
                dgKhassraDetails.Columns["KanalNew"].HeaderText = "مجوزہ کنال";
                dgKhassraDetails.Columns["Marla"].HeaderText = "موجودہ مرلہ";
                dgKhassraDetails.Columns["MarlaNew"].HeaderText = "مجوزہ مرلہ";
                dgKhassraDetails.Columns["Sarsai"].HeaderText = "موجودہ سرسائی";
                dgKhassraDetails.Columns["SarsaiNew"].HeaderText = "مجوزہ سرسائی";
                dgKhassraDetails.Columns["Feet"].HeaderText = "موجودہ فٹ";
                dgKhassraDetails.Columns["FeetNew"].HeaderText = "مجوزہ فٹ";
                dgKhassraDetails.Columns["AreaType"].HeaderText = "موجودہ قسم آراضی";
                dgKhassraDetails.Columns["AreaTypeNew"].HeaderText = "مجوزہ قسم آراضی";


                dgKhassraDetails.Columns["GardawriKhassraDetailId"].Visible = false;
                dgKhassraDetails.Columns["GardawriId"].Visible = false;
                dgKhassraDetails.Columns["KhassraDetailId"].Visible = false;
                dgKhassraDetails.Columns["KhassraId"].Visible = false;
                dgKhassraDetails.Columns["AreaTypeId"].Visible = false;
                dgKhassraDetails.Columns["AreaTypeIdNew"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Khassra Gardawri ByKhassra

        private void GetKhassraDetailsByKhassraId()
        {
            try
            {
                this.dtKhassraDetails = gardawri.GetKhassraDetailsByKhassra(UsersManagments._Tehsilid.ToString(), cbKhassrasQismZameen.SelectedValue.ToString());
                DataRow row = dtKhassraDetails.NewRow();
                row["KhassraDetailId"] = 0;
                row["AreaType"] = "- انتخاب قسم اراضی  -";
                dtKhassraDetails.Rows.InsertAt(row, 0);
                //--- Mian Gardawri Khassra Drop down ---//
                cbAreaTypes.DataSource = dtKhassraDetails;
                cbAreaTypes.DisplayMember = "AreaType";
                cbAreaTypes.ValueMember = "KhassraDetailId";
                //txtKhassraDetailId.Text=dtKhassraDetails.row
                //dgKhassraDetails.DataSource = this.dtKhassraDetails;
                //dgKhassraDetails.Columns["AreaType"].HeaderText = "قسم زمین";
                //dgKhassraDetails.Columns["Kanal"].HeaderText = "کنال";
                //dgKhassraDetails.Columns["Marla"].HeaderText = "مرلہ";
                //dgKhassraDetails.Columns["Sarsai"].HeaderText = "سرسائی";
                //dgKhassraDetails.Columns["KhassraDetailId"].Visible = false;
                //dgKhassraDetails.Columns["KhassraId"].Visible = false;
                //dgKhassraDetails.Columns["AreaTypeId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Grdview Khassra Gardawri List Click Event

        private void GridViewKhassraGardawri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    txtGardawriKashtFasalId.Text = g.SelectedRows[0].Cells["GardawriKashtFasalId"].Value.ToString();
                    this.txtKhatooniLaganPossession.Text = g.SelectedRows[0].Cells["KashtkaranTafseel"].Value.ToString();
                    this.txtKyfiat.Text = g.SelectedRows[0].Cells["Kyfiyat"].Value.ToString();
                    this.txtFasalDetail.Text = g.SelectedRows[0].Cells["FasalDetails"].Value.ToString();
                    this.cboKhassraList.SelectedValue = g.SelectedRows[0].Cells["KhassraId"].Value.ToString();
                    cbKhassraNature.SelectedValue = g.SelectedRows[0].Cells["KhassraTypeId"].Value;
                }
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColCheck"].Value = true;
                    }
                    else
                        row.Cells["ColCheck"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region combo khassralist selection change event

        private void cboKhassraList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //this.GetGardawriDetails();
                //GetKhassraDetailsByKhassraId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button New Click Event

        private void btnNewKhata_Click(object sender, EventArgs e)
        {
            this.resetFields();
        }

        #endregion

        #region Clear Reset Entry Fields

        private void resetFields()
        {
            this.txtFasalDetail.Clear();
            this.txtGardawriKashtFasalId.Text = "-1";
            this.txtKhatooniLaganPossession.Clear();
            this.txtKyfiat.Clear();
            txtKhatooniLaganPossession.Text = KhatooniKashtkaranDetails;
            cboKhassraList.SelectedValue = "0";
            cbKhassraNature.SelectedValue = "0";
        }

        #endregion

        #region Button Delete Gardawri Click Event

        private void btnDelKhatta_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ  خسرہ گرداوری کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (this.txtGardawriId.Text != "-1")
                    {
                        string retval = gardawri.DeleteGardawri(this.txtGardawriId.Text);
                        this.GetGardawriDetails();

                    }
                    else
                        MessageBox.Show("نیچے گریڈ سے گرداوری کا انتخاب کریں");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Confirm Gardawri Click Event

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ حتمی قرار دینے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز حتمی ہے تو یس کلک کریں۔؟", "خسرہ گرداوری کو حتمی قرار دینا", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    gardawri.UpdateGardawriConfirmationAttestation("Confirmation","0", UsersManagments.UserName, "", txtGardawriId.Text);
                    this.EnableDisableButtons(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Enable /Disable method

        private void EnableDisableButtons(bool enable)
        {
            if (enable)
            {
                this.btnSaveKhata.Enabled = true;
                this.btnDelKhatta.Enabled = true;
                this.btnNewKhata.Enabled = true;
                this.btnAmaldaramad.Enabled = false;
                this.btnConfirm.Enabled = true;
            }
            else
            {
                 this.btnSaveKhata.Enabled = false;
                this.btnDelKhatta.Enabled = false;
                this.btnNewKhata.Enabled = false;
                this.btnAmaldaramad.Enabled = true;
                this.btnConfirm.Enabled = false;
            }
        }


        #endregion

        #region Confirm Check Change Event

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.EnableDisableButtons(false);
            }
            else
            {
                this.EnableDisableButtons(true);
            }
        }

        #endregion

        #region Button Print Gardawri Template

        private void btnPrintGardawriTemplete_Click(object sender, EventArgs e)
        {
            int MozaId = Convert.ToInt32(cmbMouza.SelectedValue);
            frmSDCReportingMain rptMain = new frmSDCReportingMain();
            rptMain.MozaId = MozaId.ToString();
            UsersManagments.check = 13;
            rptMain.ShowDialog();
            
        }

        #endregion

        #region Button Amaldaramad Click Event

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            if (txtGardawriId.Text.Length > 5 && dtpDateGardawari.Text.Trim().Length>3)
            {
                frmGardawriAttestationByRO attByRo = new frmGardawriAttestationByRO();
                attByRo.FormClosed -= new FormClosedEventHandler(attByRo_FormClosed);
                attByRo.FormClosed += new FormClosedEventHandler(attByRo_FormClosed);
                attByRo.KhassraId = cboKhassraList.SelectedValue.ToString();
                attByRo.MozaId = cmbMouza.SelectedValue.ToString();
                attByRo.fasleType = cboHarifRabeah.Text;
                attByRo.Year = dtpDateGardawari.Text;
                attByRo.GardawriId = txtGardawriId.Text;
                attByRo.ShowDialog();
            }
            else
                MessageBox.Show("تصدیق کے لئے گرداوری کا انتخاب کریں۔", "تصدیق گرداوری", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        void attByRo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGardawriAttestationByRO attRo = sender as frmGardawriAttestationByRO;
            if (attRo.AttStatus)
            {
                MessageBox.Show("گرداوری کا عمل کھتونی میں رکھ دیا گیا ہے۔");
            }
        }

        #endregion

        #region Button CLick Print entered Gardawri

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Gridview Khassra Details Click Event

        private void dgKhassraDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                   
                    this.cbAreaTypesNew.SelectedValue = g.SelectedRows[0].Cells["AreaTypeIdNew"].Value.ToString();
                    this.cbKhassrasQismZameen.SelectedValue = g.SelectedRows[0].Cells["KhassraId"].Value.ToString();
                    this.cbKhassrasQismZameen_SelectionChangeCommitted(sender, e);
                    this.cbAreaTypes.SelectedValue = g.SelectedRows[0].Cells["KhassraDetailId"].Value.ToString();
                    txtKhassraKanal.Text = g.SelectedRows[0].Cells["KanalNew"].Value.ToString();
                    txtKhassraMarla.Text = g.SelectedRows[0].Cells["MarlaNew"].Value.ToString();
                    txtKhassraSarsai.Text = g.SelectedRows[0].Cells["SarsaiNew"].Value.ToString();
                    txtKhassraFeet.Text = g.SelectedRows[0].Cells["FeetNew"].Value.ToString();
                    txtGardawriKhassraDetailIId.Text = g.SelectedRows[0].Cells["GardawriKhassraDetailId"].Value.ToString();
                    txtKhassraDetailId.Text = g.SelectedRows[0].Cells["KhassraDetailId"].Value.ToString();
                }
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColSel"].Value = true;
                    }
                    else
                        row.Cells["ColSel"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Combo Khassra Qism Zameen Slection Change Evenet

        private void cbKhassrasQismZameen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetKhassraDetailsByKhassraId();

        }

        #endregion

        #region Combo Area Type selection Change Event

        private void cbAreaTypes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in dtKhassraDetails.Rows)
            {
                if (row["KhassraDetailId"].ToString() == cbAreaTypes.SelectedValue.ToString())
                {
                    txtKhassraDetailId.Text = row["KhassraDetailId"].ToString();
                    txtKhassraKanal.Text = row["Kanal"].ToString();
                    txtKhassraMarla.Text = row["Marla"].ToString();
                    txtKhassraSarsai.Text = row["Sarsai"].ToString();
                    txtKhassraFeet.Text =Math.Round((float.Parse(row["Sarsai"].ToString() != "" ? row["Sarsai"].ToString() : "0")*30.25),0).ToString();
                }
            }
        }

        #endregion

        #region BUtton Save Khassra Qism Zameen click event

        private void btnSaveKhassraQismZameen_Click(object sender, EventArgs e)
        {
            if (cbAreaTypesNew.SelectedValue.ToString().Length > 3 && cbKhassrasQismZameen.SelectedValue.ToString().Length > 5)
            {
                if (txtKhassraDetailId.Text == "-1" || txtKhassraDetailId.Text == "0")
                {

                    txtKhassraDetailId.Text = gardawri.SaveKhassraRegisterDetail(UsersManagments._Tehsilid.ToString() ,txtKhassraDetailId.Text, cbKhassrasQismZameen.SelectedValue.ToString(), cbAreaTypesNew.SelectedValue.ToString(), "0", "0", "0", "0", UsersManagments.UserId.ToString());
                    if (txtKhassraDetailId.Text.Length > 5)
                    {
                        if (txtKhassraKanal.Text.Trim().Length > 0 && txtKhassraMarla.Text.Trim().Length > 0 && txtKhassraSarsai.Text.Trim().Length > 0 && txtKhassraFeet.Text.Trim().Length > 0)
                        {
                            string retVal = gardawri.SaveGardawriTaghairat(txtGardawriKhassraDetailIId.Text,UsersManagments._Tehsilid.ToString() ,txtGardawriId.Text, txtKhassraDetailId.Text, cbKhassrasQismZameen.SelectedValue.ToString(), "0", cbAreaTypesNew.SelectedValue.ToString(), "0", txtKhassraKanal.Text.Trim(),
                                 "0", txtKhassraMarla.Text.Trim(), "0", txtKhassraSarsai.Text.Trim(), "0", txtKhassraFeet.Text.Trim(), UsersManagments.UserName, UsersManagments.UserId.ToString());

                            if (retVal.Length > 0)
                            {
                                //dtKhassraDetails= gardawri.GetGardawriTaghairat(txtGardawriId.Text, cboKhatoonies.SelectedValue.ToString());
                                GetGardawriTaghairatDetails();
                            }
                        }
                    }

                }
                else
                {
                    if (txtKhassraDetailId.Text.Length > 5)
                    {
                        foreach (DataRow row in dtKhassraDetails.Rows)
                        {
                            string AreaTypeId = "0";
                            string Kanal = "0";
                            string Marla = "0";
                            string Sarsai = "0";
                            string Feet = "0";
                            if (row["KhassraDetailId"].ToString() == cbAreaTypes.SelectedValue.ToString())
                            {
                                AreaTypeId = row["AreaTypeId"].ToString();
                                Kanal = row["Kanal"].ToString();
                                Sarsai = row["Sarsai"].ToString();
                                Feet = Math.Round((float.Parse(row["Sarsai"].ToString() != "" ? row["Sarsai"].ToString() : "0") * 30.25), 0).ToString();
                                if (
                                cbAreaTypesNew.SelectedValue.ToString() == row["AreaTypeId"].ToString() &&
                                txtKhassraKanal.Text == row["Kanal"].ToString() &&
                                txtKhassraMarla.Text == row["Marla"].ToString() &&
                                txtKhassraSarsai.Text == row["Sarsai"].ToString() &&
                                txtKhassraFeet.Text == Math.Round((float.Parse(row["Sarsai"].ToString() != "" ? row["Sarsai"].ToString() : "0") * 30.25), 0).ToString())
                                {
                                    MessageBox.Show("اندراج قدیم اور اندراج جدید میں کوئی تغیر نہیں ہے۔ ", "تغیرات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (txtKhassraKanal.Text.Trim().Length > 0 && txtKhassraMarla.Text.Trim().Length > 0 && txtKhassraSarsai.Text.Trim().Length > 0 && txtKhassraFeet.Text.Trim().Length > 0)
                                    {
                                        string retVal = gardawri.SaveGardawriTaghairat(txtGardawriKhassraDetailIId.Text,UsersManagments._Tehsilid.ToString() ,txtGardawriId.Text, cbAreaTypes.SelectedValue.ToString(), cbKhassrasQismZameen.SelectedValue.ToString(), AreaTypeId, cbAreaTypesNew.SelectedValue.ToString(), Kanal, txtKhassraKanal.Text.Trim(),
                                             Marla, txtKhassraMarla.Text.Trim(), Sarsai, txtKhassraSarsai.Text.Trim(), Feet, txtKhassraFeet.Text.Trim(), UsersManagments.UserName, UsersManagments.UserId.ToString());

                                        if (retVal.Length > 0)
                                        {
                                            //dtKhassraDetails= gardawri.GetGardawriTaghairat(txtGardawriId.Text, cboKhatoonies.SelectedValue.ToString());
                                            GetGardawriTaghairatDetails();
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("محفوظ کرنے سے پہلے نمبر خسرہ اور مجوزہ قسم اراضی کا انتخاب کریں۔", "تغیرات قسم اراضی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Combo Fasal Rabeah Hareaf Selection Change Event

        private void cboHarifRabeah_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateGardawari.Text.Trim().Length > 3)
                {
                    DataTable dtGardawriMain = gardawri.GetGardawriMain(cmbMouza.SelectedValue.ToString(), cboHarifRabeah.Text, dtpDateGardawari.Text);
                    if (dtGardawriMain.Rows.Count > 0)
                    {
                        btnSaveGardawriMain.Enabled = false;
                        txtGardawriId.Text = dtGardawriMain.Rows[0]["GardawriId"].ToString();
                        btnConfirm.Enabled = Convert.ToBoolean(dtGardawriMain.Rows[0]["isConfirmed"].ToString() == "0" ? true : false);
                        btnAmaldaramad.Enabled = Convert.ToBoolean(dtGardawriMain.Rows[0]["Attested"].ToString() == "0" ? true : false);
                        cbokhataNo.Enabled = true;
                        cboKhatoonies.Enabled = true;
                    }
                    else
                    {
                        btnSaveGardawriMain.Enabled = true;
                        cbokhataNo.Enabled = false;
                        cboKhatoonies.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save Gardawri Main Click Button

        private void btnSaveGardawriMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMouza.SelectedValue.ToString() != "0" && cboHarifRabeah.Text.Length>0 && dtpDateGardawari.Text.Trim().Length>3)
                {
                   string retVal= gardawri.SaveGardawriMain(txtGardawriId.Text,UsersManagments._Tehsilid.ToString() ,cmbMouza.SelectedValue.ToString(), cboHarifRabeah.Text, dtpDateGardawari.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                   if (retVal.Length == 10)
                   {
                       btnSaveGardawriMain.Enabled = false;
                       cbokhataNo.Enabled = true;
                       cboKhatoonies.Enabled = true;
                       txtGardawriId.Text = retVal;
                   }
                   else 
                   {
                       btnSaveGardawriMain.Enabled = true;
                       cbokhataNo.Enabled = false;
                       cboKhatoonies.Enabled = false;
                   }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        #endregion

        #region Button Delete Khassra Qism Zameen CLick Event

        private void btnDelKhassraQismZameen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ  انتخاب کردہ ریکارڈ حذف کرنا چاہتے ہیں", "حذف کریں", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                if (txtGardawriKhassraDetailIId.Text.Length > 5)
                {
                    gardawri.DeleteGardawriKhassraDetail(txtGardawriKhassraDetailIId.Text);
                    ClearFormControls(gbTaghairat);
                    txtGardawriKhassraDetailIId.Text = "-1";
                    txtKhassraDetailId.Text = "-1";
                    GetGardawriTaghairatDetails();
                }
            }
        }

        #endregion

        #region Clear Form Controls

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
        #endregion

        #region Button New Khassra QIsm Zameen CLick Event

        private void btnNewKhassraQismZameen_Click(object sender, EventArgs e)
        {
            ClearFormControls(gbTaghairat);
            txtKhassraDetailId.Text = "-1";
            txtGardawriKhassraDetailIId.Text = "-1";
        }

        #endregion

        #region Checkbox Change in Khassra Qabza Kasht check event

        private void chkChangeInKashtQabza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangeInKashtQabza.Checked)
            {
                txtKhatooniLaganPossession.Enabled = false;
            }
            else 
            {
                txtKhatooniLaganPossession.Enabled = true;
            }
        }

        #endregion

        #region text box number only check on key press event

        private void txtKhassraKanal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion
    }
}
