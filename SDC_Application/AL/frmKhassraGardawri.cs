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
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
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
                string KhataId = cbokhataNo.SelectedValue.ToString();
                khatooniKhassraDetail = Khatooni.GetKhassrajatByKhatooniId(cboKhatoonies.SelectedValue.ToString());
                DataRow row = khatooniKhassraDetail.NewRow();
                row["KhassraId"] = 0;
                row["KhassraNo"] = "- نمبر خسرے کا انتخاب کریں -";
                khatooniKhassraDetail.Rows.InsertAt(row, 0);
                cboKhassraList.DataSource = khatooniKhassraDetail;
                cboKhassraList.DisplayMember = "KhassraNo";
                cboKhassraList.ValueMember = "KhassraId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

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

        #region Save Gardawri

        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhassraList.SelectedValue.ToString() != "0" && cboHarifRabeah.Text.Trim() != "" && cmbMouza.SelectedValue.ToString()!="0")
                {
                    string retVal=gardawri.SaveGardawri(txtGardawriId.Text, cmbMouza.SelectedValue.ToString(), cboHarifRabeah.Text, DateTime.Now.ToShortDateString(), dtpDateGardawari.Value.Year.ToString(), cboKhassraList.SelectedValue.ToString(), txtKhatooniLaganPossession.Text,txtFasalDetail.Text, txtKyfiat.Text, UsersManagments.UserId, UsersManagments.UserName);
                    if (retVal != "0")
                    {
                        MessageBox.Show("خسرہ گرداوری اندراج محفوظ ہو گیا۔");
                        GetGardawriDetails();
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

        #region Get Khassra Gardawri ByKhassra

        private void GetGardawriDetails()
        {
            try
            {
            this.GetGardawri = gardawri.GetGardawriByMouzaByYearByKhassra(dtpDateGardawari.Value.Year.ToString(), cmbMouza.SelectedValue.ToString(), cboKhassraList.SelectedValue.ToString());
            GridViewKhassraGardawri.DataSource = this.GetGardawri;
            GridViewKhassraGardawri.Columns["Khassrano"].HeaderText = "نمبر خسرہ";
            GridViewKhassraGardawri.Columns["FasalType"].HeaderText = "حریف/ربیعہ";
            GridViewKhassraGardawri.Columns["FasalDetails"].HeaderText = "فصل";
            GridViewKhassraGardawri.Columns["GardawriYear"].HeaderText = "سنہ";
            GridViewKhassraGardawri.Columns["KashtkaranTafseel"].HeaderText = "تبدیلی حقوق کاشت یا قبضہ و لگان";
            GridViewKhassraGardawri.Columns["WasileAbpashi"].HeaderText = "کیفیت";
            GridViewKhassraGardawri.Columns["GardawariId"].Visible = false;
            GridViewKhassraGardawri.Columns["KhassraId"].Visible = false;
            GridViewKhassraGardawri.Columns["GardawriDate"].Visible = false;
            GridViewKhassraGardawri.Columns["isConfirmed"].Visible = false;
            GridViewKhassraGardawri.Columns["Attested"].Visible = false;
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
                    this.txtGardawriId.Text = g.SelectedRows[0].Cells["GardawariId"].Value.ToString();
                    this.txtKhatooniLaganPossession.Text = g.SelectedRows[0].Cells["KashtkaranTafseel"].Value.ToString();
                    this.txtKyfiat.Text = g.SelectedRows[0].Cells["WasileAbpashi"].Value.ToString();
                    this.txtFasalDetail.Text = g.SelectedRows[0].Cells["FasalDetails"].Value.ToString();
                    this.cboKhassraList.SelectedValue = g.SelectedRows[0].Cells["KhassraId"].Value.ToString();
                    this.cboHarifRabeah.SelectedValue = g.SelectedRows[0].Cells["FasalType"].Value.ToString();
                    //this.checkBox1.Checked = Convert.ToBoolean(g.SelectedRows[0].Cells["isConfirmed"].Value.ToString());
                    //this.dtpDateGardawari.Value = g.SelectedRows[0].Cells["GardawriYear"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void cboKhassraList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.GetGardawriDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            this.txtGardawriId.Text = "-1";
            this.txtKhatooniLaganPossession.Clear();
            this.txtKyfiat.Clear();
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
                if (DialogResult.Yes == MessageBox.Show("آپ فائنل کرنے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز فائنل ہے تو یس کلک کریں۔؟", "Confirmation of Fard e Badar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    gardawri.UpdateGardawriConfirmationAttestation("Confirmation","0", UsersManagments.UserName, "", dtpDateGardawari.Value.Year.ToString(), cmbMouza.SelectedValue.ToString(), cboHarifRabeah.Text);
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

        private void btnPrintGardawriTemplete_Click(object sender, EventArgs e)
        {
            int MozaId = Convert.ToInt32(cmbMouza.SelectedValue);
            frmSDCReportingMain rptMain = new frmSDCReportingMain();
            rptMain.MozaId = MozaId.ToString();
            UsersManagments.check = 13;
            rptMain.ShowDialog();
            
        }
    }
}
