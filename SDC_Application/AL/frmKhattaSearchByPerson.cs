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
        Intiqal intiqal = new Intiqal();
        Khatoonies khatooni = new Khatoonies();
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        datagrid_controls datagridcontrols = new datagrid_controls();
        AutoComplete objauto = new AutoComplete();
        BL.frmToken objBusiness = new BL.frmToken();
        DataTable dt = new DataTable();
        DataTable Persons = new DataTable();
        public string PersonName { get; set; }
        public string FatherName { get; set; }
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
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            cmbMouza.Focus();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //   this.SearchedKhattaDataBinding.DataSource = client.GetKhattajatByPersonId(CurrentUser.MozaId.ToString(), this.PersonId).ToList();
        }

        public void Proc_Get_Person_KhataJats()
        {

            dt = MalikanKatajat.GetPersonKhattajat(MozaID, PersonId);
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
            dgKhewatFreeqDetails.DataSource = null;
            grdPersonKatajats.DataSource = null;
            if ((txtVisitorName.Text.Trim() != "" || txtFatherName.Text.Trim()!="") && Convert.ToInt32(cmbMouza.SelectedValue)>0)
            {
                this.MozaID = cmbMouza.SelectedValue.ToString();
                this.PersonName = txtVisitorName.Text.Trim();
                this.FatherName = txtFatherName.Text.Trim();
                this.Persons.Clear();
                //this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Searched_Afrad_List " + this.MozaID + ",1, N'" + PersonName + "'");
                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Searched_Afrad_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + ",1, N'" + PersonName + "',N'" + FatherName + "'");
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
            if (datatable.Rows.Count > 0)
            {
                this.dataGridViewPersons.DataSource = datatable;
                this.dataGridViewPersons.Columns["PersonFullName"].HeaderText = "نام مالک";
                this.dataGridViewPersons.Columns["PersonId"].Visible = false;
                this.dataGridViewPersons.Columns["CNIC"].Visible = false;
                this.dataGridViewPersons.Columns["MozaId"].Visible = false;
                this.dataGridViewPersons.Columns["QoamId"].Visible = false;
                this.dataGridViewPersons.Columns["PersonName"].Visible = false;

            }
        }

        #endregion

        #region Gridview Persons Click Event

        private void dataGridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgKhewatFreeqDetails.DataSource = null;
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
                //MessageBox.Show(PersonId);
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
            //dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats_WithLocks " + this.MozaID + "," + PersonId);
            //self----------------------------------
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_WithLocks " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + "," + PersonId);
            //---------------------------------------
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas.Rows.Count > 0)
            {
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["Malik_Area"].HeaderText = "مالک کا رقبہ";
                //grdPersonKatajats.Columns["Tran_Fard"].HeaderText = "ٹرانزیکشنل فرد";
               // grdPersonKatajats.Columns["Malik_Part"].HeaderText = "مالک کے حصے";
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
                grdPersonKatajats.Columns["PersonId"].Visible = false;
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }
            // Get Total Raqba
            if (dtKhattas.Rows.Count > 0)
            {
             
              DataTable PersonTotalArea = new DataTable();
              PersonTotalArea = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + "," + PersonId);
              foreach (DataRow row in PersonTotalArea.Rows)
              {
                  txtTotalRaqba.Text = row["Fardarea"].ToString();
                  
              }
            }
            else
            {
                txtTotalRaqba.Clear();
            }

              
              


        }

        #endregion

        private void grdPersonKatajats_DoubleClick(object sender, EventArgs e)
        {

          
            if (grdPersonKatajats.DataSource != null)
            {
                if (rbKhatta.Checked)
                {
                    DataTable dtKhewatFareeqainByPerson = new DataTable();
                    dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(grdPersonKatajats.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString(), grdPersonKatajats.CurrentRow.Cells["PersonId"].Value.ToString());
                    this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
                    PopulateGridviewKhewFareeqByPersonId();
                    
                }

                if (rbKhatooni.Checked)
                {

                   
                    DataTable dtMushteriFareeqainByPerson = new DataTable();
                    dtMushteriFareeqainByPerson = khatooni.MushteriFareeqByKhatooniIdPersonId(grdPersonKatajats.CurrentRow.Cells["KhatooniId"].Value.ToString(), grdPersonKatajats.CurrentRow.Cells["PersonId"].Value.ToString());
                    this.dgKhewatFreeqDetails.DataSource = dtMushteriFareeqainByPerson;
                    PopulateGridviewMushteriFareeqByPersonId();
                }
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
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
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

        #region Fill Gridview Mushteryan by Person Id for Single Malk History and Details

        private void PopulateGridviewMushteriFareeqByPersonId()
        {
            try
            {
                dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "نام مالک";
                dgKhewatFreeqDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                dgKhewatFreeqDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                dgKhewatFreeqDetails.Columns["IntiqalId"].Visible = false;
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                dgKhewatFreeqDetails.Columns["SellerBuyer"].HeaderText = "حیثیت";
                dgKhewatFreeqDetails.Columns["KhewatType"].Visible = false;
                dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
                dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                dgKhewatFreeqDetails.Columns["MushtriFareeqId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhatooniId"].Visible = false;
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


        #region Get Person Khassras

        private void GetPersonKhassras(string PersonId)
        {
            DataTable dtKhassras = new DataTable();
            dtKhassras = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_Khassrajat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + "," + PersonId);
            this.grdPersonKatajats.DataSource = dtKhassras;
            if (dtKhassras.Rows.Count > 0)
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
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }

        }

        #endregion

        #region Get Person Khatoonies

        private void GetPersonKhaoonies(string PID)
        {

            DataTable dtKhatoonies = new DataTable();
            dtKhatoonies = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_Khatoonies " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PID);
            this.grdPersonKatajats.DataSource = dtKhatoonies;
            if (dtKhatoonies.Rows.Count > 0)
            {
                //grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                //grdPersonKatajats.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                //grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                //grdPersonKatajats.Columns["KhatooniId"].Visible = false;







                //grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                //grdPersonKatajats.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                //grdPersonKatajats.Columns["Khatooni_Hissa"].HeaderText = "کل حصے";
                //grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";
                //grdPersonKatajats.Columns["Khatooni_Area"].HeaderText = "کل رقبہ";
                //grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                //grdPersonKatajats.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                grdPersonKatajats.Columns["KhatooniId"].Visible = false;
                grdPersonKatajats.Columns["PersonId"].Visible = false;
               
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }


            // Get Total Raqba
            if (dtKhatoonies.Rows.Count > 0)
            {
              
                DataTable PersonTotalAreaKK = new DataTable();
                PersonTotalAreaKK = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId_KhanaKasht " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + "," + PID);
                foreach (DataRow row in PersonTotalAreaKK.Rows)
                {
                    txtTotalRaqba.Text = row["Fardarea"].ToString();

                }
            }
            else
            {
                txtTotalRaqba.Clear();
            }
        }

        #endregion

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgKhewatFreeqDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdPersonKatajats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //}
    }
}
