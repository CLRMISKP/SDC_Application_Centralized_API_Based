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

namespace SDC_Application.AL
{
    public partial class frmKhattaLocking : Form
    {
        #region Class Varialbes

        //ClientServiceClient client = new ClientServiceClient();
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        datagrid_controls datagridcontrols = new datagrid_controls();
        AutoComplete objauto = new AutoComplete();
        Misal misalBl = new Misal();
        BL.frmToken objBusiness = new BL.frmToken();
        DataTable dt = new DataTable();
        DataTable Persons = new DataTable();
        public string PersonName { get; set; }
        public string MozaID { get; set; }
        public string PersonId { get; set; }

        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();

        #endregion
        public frmKhattaLocking()
        {
            InitializeComponent();
        }

        private void frmKhattaSearchByPerson_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            //objauto.FillCombo("Proc_Get_Admin_Users_By_Tehsil_DE_Zerekar " + UsersManagments._Tehsilid.ToString(), cmbUsers, "CompleteName", "UserId");
            //if (UsersManagments._UserName.Contains("zakir") || UsersManagments._UserName.Contains("Admin"))
            //{
            //    this.cbLockKhataShowToDE.Visible = true;
            //    this.chbResetKhewatFareeqain.Visible = true;
            //    this.cmbUsers.Visible = true;
            //}
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //   this.SearchedKhattaDataBinding.DataSource = client.GetKhattajatByPersonId(CurrentUser.MozaId.ToString(), this.PersonId).ToList();
        }

        public void Proc_Get_Person_KhataJats()
        {

            dt = misalBl.GetKhatajatByMoza(Convert.ToInt32(MozaID));
            grdPersonKatajats.DataSource = dt;
            PopulateGird();



        }

        #region  DataGrid Filling
        public void PopulateGird()
        {
            this.grdPersonKatajats.Columns["KhataNo"].DisplayIndex = 0;
            grdPersonKatajats.Columns["Khata_Area"].DisplayIndex = 1;
            grdPersonKatajats.Columns["TotalParts"].DisplayIndex = 2;
            grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
            grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";

            grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
            grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
            grdPersonKatajats.Columns["Kanal"].Visible = false;
            grdPersonKatajats.Columns["Marla"].Visible = false;
            grdPersonKatajats.Columns["sarsai"].Visible = false;

            grdPersonKatajats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdPersonKatajats.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPersonKatajats.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPersonKatajats.RowHeadersDefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
            grdPersonKatajats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridcontrols.colorrbackgrid(grdPersonKatajats);
        }
        private string CalculateTotalKhatta()
        {
            int NoOfKhattas = 0;

            foreach (DataGridViewRow row in grdPersonKatajats.Rows)
            {
                NoOfKhattas = NoOfKhattas + 1;
            }
            return NoOfKhattas.ToString();
        }
        #endregion

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

        #region Get Person Khattas

        private void GetKhattasByMoza(string MozaId)
        {
            DataTable dtKhattas = new DataTable();
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Moza_Register_KhataJat_SDC_For_Locking " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",0");
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas.Rows.Count > 0)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["RecordLockedCon"].HeaderText = "موجودہ حالت";
                grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                grdPersonKatajats.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["RecordLocked"].Visible = false;
            
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }

        }
        private void GetKhattasByMozaBySearch(string MozaId, string KhataNo)
        {
            DataTable dtKhattas = new DataTable();
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Moza_Register_KhataJat_SDC_For_Locking_By_Search " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",0,'" + KhataNo + "'");
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas.Rows.Count > 0)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";
                grdPersonKatajats.Columns["RecordLockedCon"].HeaderText = "موجودہ حالت";
                grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                grdPersonKatajats.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                grdPersonKatajats.Columns["ActiveForCorrection"].Visible = false;
                grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["RecordLocked"].Visible = false;

            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                MessageBox.Show("کوئی ریکارڈ نہیں ملا");
                //this.grdPersonKatajats.ColumnCount = 1;
                //this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }

        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            MalikanKatajat.setKhataLock(txtKhewatKhataId.Text, cbLockKhata.Checked.ToString(), txtVisitorName.Text, "0", "0", UsersManagments.UserId.ToString());

            //------- for insert in KhataLockDetail -------------------------
            MalikanKatajat.insertKhataLockDetail(txtKhewatKhataId.Text, cbLockKhata.Checked.ToString(), txtPrevLockDetails.Text, txtVisitorName.Text, "0", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), "0");

            //--------------end----------------------------------------------
            this.GetKhattasByMozaBySearch(cmbMouza.SelectedValue.ToString(), txtKhataNoSearch.Text.Trim());
            if (chbResetKhewatFareeqain.Checked)
            {
                if (MessageBox.Show(" کیا آپ تمام ملکان کے حصے صفر کرنا چاہتے ہیں:::::", "ملکان حصے صفر", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string KhewatGroupId = MalikanKatajat.ResetKhewatFareeqainHisas(txtKhewatKhataId.Text);
                    if (KhewatGroupId != null && KhewatGroupId != "" && KhewatGroupId != "0")
                    {
                        MessageBox.Show("ملکان حصے زیرو کر دیئے گئے۔");
                    }
                    else
                    {
                        MessageBox.Show("ملکان حصے زیرو نیہں ہو سکے۔", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.txtVisitorName.Clear();
            this.txtKhewatKhataId.Text = "-1";
            this.txtKhataNo.Clear();
            cbLockKhataShowToDE.Checked = false;
            cbLockKhata.Checked = false;
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //txtKhewatKhataId.Text = "-1";
            //this.GetKhattasByMoza(cmbMouza.SelectedValue.ToString());
        }

        private void grdPersonKatajats_CellClick(object sender, DataGridViewCellEventArgs e)
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
                            row.Cells["colCheck"].Value = 1;
                            txtKhataNo.Text = row.Cells["KhataNo"].Value.ToString();
                            cbLockKhata.Checked =Convert.ToBoolean(row.Cells["RecordLocked"].Value);
                            cbLockKhataShowToDE.Checked = Convert.ToBoolean(row.Cells["ActiveForCorrection"].Value);
                            txtKhewatKhataId.Text = row.Cells["RegisterHqDKhataId"].Value.ToString();
                            this.txtVisitorName.Text = row.Cells["RecordLockedDetails"].Value.ToString();
                            this.txtPrevLockDetails.Text = row.Cells["RecordLockedDetails"].Value.ToString();
                         

                        }
                        else
                        {
                            row.Cells["colCheck"].Value = 0;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtKhataNoSearch.Text.Trim() != "")
            {
                txtKhewatKhataId.Text = "-1";
                string KhataNoforSearch = txtKhataNoSearch.Text.Trim();
                this.GetKhattasByMozaBySearch(cmbMouza.SelectedValue.ToString(), KhataNoforSearch);
            }
            else
                MessageBox.Show("تلاش کے لئے کھاتہ نمبر لکھیں۔");
        }
        //}
    }
}
