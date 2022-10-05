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
    public partial class frmKhattaSearchByPerson : Form
    {
        #region Class Varialbes

        //ClientServiceClient client = new ClientServiceClient();
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        datagrid_controls datagridcontrols = new datagrid_controls();
        AutoComplete objauto = new AutoComplete();
        BL.frmToken objBusiness = new BL.frmToken();
        DataTable dt = new DataTable();
        DataTable Persons = new DataTable();
        public string PersonName { get; set; }
        public string MozaID { get; set; }
        public string PersonId { get; set; }

        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();

        #endregion
        public frmKhattaSearchByPerson()
        {
            InitializeComponent();
        }

        private void frmKhattaSearchByPerson_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //   this.SearchedKhattaDataBinding.DataSource = client.GetKhattajatByPersonId(CurrentUser.MozaId.ToString(), this.PersonId).ToList();
        }

        public void Proc_Get_Person_KhataJats()
        {

            dt = MalikanKatajat.GetPersonKhattajat(MozaID, PersonId);
            grdPersonKatajats.DataSource = dt;
            if(dt!=null)
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
            grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";

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

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            if (txtVisitorName.Text.Trim() != "" && Convert.ToInt32(cmbMouza.SelectedValue)>0)
            {
                this.MozaID = cmbMouza.SelectedValue.ToString();
                this.PersonName = txtVisitorName.Text.Trim();
                if(Persons!=null)
                this.Persons.Clear();
                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Searched_Afrad_List_Name_FatherName " + this.MozaID + ", N'" + PersonName + "', N'"+txtFatherName.Text.Trim()+"'");
                if (this.Persons != null)
                {
                    this.FillPersonGridview(Persons);
                }
               // Proc_Get_Person_KhataJats();
            }
        }

        #region Fill Person Gridview

        private void FillPersonGridview(DataTable datatable)
        {
            if (datatable!=null)
            {
                this.dataGridViewPersons.DataSource = datatable;
                this.dataGridViewPersons.Columns["PersonFullName"].HeaderText = "نام مالک";
                this.dataGridViewPersons.Columns["PersonId"].Visible = false;
       
            }
        }

        #endregion

        #region Gridview Persons Click Event

        private void dataGridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string PersonId = "0";
                // Check box column check uncheck.
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Cells["colchk"].RowIndex == e.RowIndex)
                    {
                        row.Cells["colchk"].Value = true;
                    }
                    else
                    {
                        row.Cells["colchk"].Value = false;
                    }
                }

                // Get Malikiat Information
                PersonId = g.Rows[e.RowIndex].Cells["PersonId"].Value.ToString();
                if (PersonId != "0")
                {
                    if (rbKhatta.Checked)
                    {
                        GetPersonKhattas(PersonId);
                    }
                    if (rbKhassra.Checked)
                    {
                        GetPersonKhassras(PersonId);
                    }
                    if (rbKhatooni.Checked)
                    {
                        GetPersonKhaoonies(PersonId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Get Person Khattas

        private void GetPersonKhattas(string PersonId)
        {
            DataTable dtKhattas = new DataTable();
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats_WithLocks " + this.MozaID + "," + PersonId);
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas!=null)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["RecordLockedCon"].HeaderText = "موجودہ حالت";
                grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                grdPersonKatajats.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";
                grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["Kanal"].Visible = false;
                grdPersonKatajats.Columns["Marla"].Visible = false;
                grdPersonKatajats.Columns["sarsai"].Visible = false;
                grdPersonKatajats.Columns["RecordLocked"].Visible = false;
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                if (grdPersonKatajats.Rows.Count < 1)
                    this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }

        }

        #endregion

        #region Get Person Khassras

        private void GetPersonKhassras(string PersonId)
        {
            DataTable dtKhassras = new DataTable();
            dtKhassras = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_Khassrajat " + this.MozaID + "," + PersonId);
            this.grdPersonKatajats.DataSource = dtKhassras;
            if (dtKhassras!=null)
            {
                grdPersonKatajats.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                grdPersonKatajats.Columns["AreaType"].HeaderText = "قسم اراضی";
                grdPersonKatajats.Columns["Khassra_Area"].HeaderText = "رقبہ";
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["KhassraId"].Visible = false;
                grdPersonKatajats.Columns["KhatooniId"].Visible = false;
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                if(grdPersonKatajats.Rows.Count<1)
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }

        }

        #endregion

        #region Get Person Khatoonies

        private void GetPersonKhaoonies(string PID)
        {

            DataTable dtKhatoonies = new DataTable();
            dtKhatoonies = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_Khatoonies " + PID);
            this.grdPersonKatajats.DataSource = dtKhatoonies;
            if (dtKhatoonies!=null)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["KhatooniId"].Visible = false;
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                if (grdPersonKatajats.Rows.Count < 1)
                    this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }
        }

        #endregion


        //}
    }
}
