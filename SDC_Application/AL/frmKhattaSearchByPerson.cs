﻿using System;
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
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            cmbMouza.Focus();
            tooltip();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //   this.SearchedKhattaDataBinding.DataSource = client.GetKhattajatByPersonId(CurrentUser.MozaId.ToString(), this.PersonId).ToList();
        }

        #region Tooltip
        public void tooltip()
        {
            toolTip1.SetToolTip(txtCNIC, " شناختی کارڈ نمبر کے ذریعے تحصیل میں یا کسی موضع میں تلاش کریں");
        }
        #endregion
        public void Proc_Get_Person_KhataJats()
        {

            dt = MalikanKatajat.GetPersonKhattajat(MozaID, PersonId);
            grdPersonKatajats.DataSource = dt;
            PopulateGird();



        }

        #region  DataGrid Filling
        public void PopulateGird()
        {
            if(grdPersonKatajats.DataSource != null)
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
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");
            }
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
            dataGridViewPersons.DataSource = null;
            dgKhewatFreeqDetails.DataSource = null;
            grdPersonKatajats.DataSource = null;
            if(this.Persons!=null) this.Persons.Clear();
            if ((txtVisitorName.Text.Trim() != "" || txtFatherName.Text.Trim() != "" ) && Convert.ToInt32(cmbMouza.SelectedValue) > 0) // search on moza and (name or father name)
            {
                this.MozaID = cmbMouza.SelectedValue.ToString();
                this.PersonName = txtVisitorName.Text.Trim();
                this.FatherName = txtFatherName.Text.Trim();
                txtCNIC.Clear();

                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Searched_Afrad_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + ",1, N'" + PersonName + "',N'" + FatherName + "'");

            }
            else if (txtCNIC.Text.Trim().Length > 3 && txtCNIC.Text.Trim().Length < 14)  // Search on cnic by providing cnic nubmer from 4 to 13 digists. Both in select moza or whole tehsil
            {
                 txtVisitorName.Clear();
                 txtFatherName.Clear();
                if(cmbMouza.SelectedIndex>0)
                {
                   this.MozaID = cmbMouza.SelectedValue.ToString();
                }
                else
                {
                    this.MozaID = "-1";
                }


                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Searched_Afrad_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + ",1, N'" + PersonName + "',N'" + FatherName + "'," + txtCNIC.Text.ToString() + "," + UsersManagments.SubSdcId.ToString());  
            }
            else if ((txtCNIC.Text.Trim().Length > 0) && (txtCNIC.Text.Trim().Length < 4 || txtCNIC.Text.Trim().Length > 13))
            {
                MessageBox.Show("شناختی کارڈ نمبر درست نہیں ہے ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
                if (this.Persons != null)
                {
                    this.FillPersonGridview(Persons);
                }
               // Proc_Get_Person_KhataJats();
            
        }

        #region Fill Person Gridview

        private void FillPersonGridview(DataTable datatable)
        {
            if (datatable != null)
            {
                if (datatable.Rows.Count > 0)
                {
                    this.dataGridViewPersons.DataSource = datatable;
                    this.dataGridViewPersons.Columns["PersonFullName"].HeaderText = "نام مالک";
                    //this.dataGridViewPersons.Columns["FatherName"].HeaderText = "نام والد / شوہر";
                    this.dataGridViewPersons.Columns["PersonId"].Visible = false;
                    this.dataGridViewPersons.Columns["CNIC"].Visible = false;
                    this.dataGridViewPersons.Columns["MozaId"].Visible = false;
                    this.dataGridViewPersons.Columns["QoamId"].Visible = false;
                    this.dataGridViewPersons.Columns["PersonName"].Visible = false;
                    this.dataGridViewPersons.Columns["FatherName"].Visible = false;

                    if (txtCNIC.Text.Trim().Length > 0)
                    {
                        this.dataGridViewPersons.Columns["CNIC"].Visible = true;
                        this.dataGridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ";
                        if (this.MozaID != "-1")
                        {
                            this.dataGridViewPersons.Columns["موضع"].Visible = false;
                        }

                    }

                }
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
            if (dtKhattas != null)
            {
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
                    grdPersonKatajats.Columns["RecordLockedCon"].Visible = false;
                    grdPersonKatajats.Columns["Kanal"].Visible = false;
                    grdPersonKatajats.Columns["Marla"].Visible = false;
                    grdPersonKatajats.Columns["sarsai"].Visible = false;
                    grdPersonKatajats.Columns["RecordLocked"].Visible = false;
                    grdPersonKatajats.Columns["PersonId"].Visible = false;
                }
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }
            // Get Total Raqba
            if (dtKhattas != null)
            {
                if (dtKhattas.Rows.Count > 0)
                {

                    DataTable PersonTotalArea = new DataTable();
                    PersonTotalArea = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaID + "," + PersonId);
                    if (PersonTotalArea != null)
                    {
                        foreach (DataRow row in PersonTotalArea.Rows)
                        {
                            txtTotalRaqba.Text = row["Fardarea"].ToString();

                        }
                    }
                }
                else
                {
                    txtTotalRaqba.Clear();
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
                if (rbKhatta.Checked && grdPersonKatajats.CurrentRow != null) //  bro adding null check cause of current row null 
                {
                    DataTable dtKhewatFareeqainByPerson = new DataTable();
                    dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(grdPersonKatajats.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString(), grdPersonKatajats.CurrentRow.Cells["PersonId"].Value.ToString());
                    this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
                    PopulateGridviewKhewFareeqByPersonId();
                    
                }

                if (rbKhatooni.Checked && grdPersonKatajats.CurrentRow != null)
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
                if (dgKhewatFreeqDetails.DataSource != null)
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
                else
                {
                    this.dgKhewatFreeqDetails.DataSource = null;
                    this.dgKhewatFreeqDetails.ColumnCount = 1;
                    this.dgKhewatFreeqDetails.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");
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
                if (dgKhewatFreeqDetails != null)
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
                else
                {
                    this.dgKhewatFreeqDetails.DataSource = null;
                    this.dgKhewatFreeqDetails.ColumnCount = 1;
                    this.dgKhewatFreeqDetails.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");
                }
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
            if (dtKhassras != null)
            {
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
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
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
            if (dtKhatoonies != null)
            {
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
            else
            {
                this.grdPersonKatajats.DataSource = null;
                this.grdPersonKatajats.ColumnCount = 1;
                this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
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

        private void btnGoshwaraMalkiat_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersons.DataSource != null)
            {
                if (dataGridViewPersons.SelectedRows.Count > 0 && cmbMouza.SelectedValue.ToString().Length>3)
                {
                    //frmIntiqalAllByPersonId frmIAP = new frmIntiqalAllByPersonId();
                    //frmIAP.PersonId = dataGridViewPersons.SelectedRows[0].Cells["PersonId"].Value.ToString(); //PersonName
                    //frmIAP.PersonName = dataGridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();
                    //frmIAP.ShowDialog();
                    frmSDCReportingMain frmRpt = new frmSDCReportingMain();
                    frmRpt.MozaId = cmbMouza.SelectedValue.ToString();
                    frmRpt.PersonName = dataGridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();
                    frmRpt.FardPersonId = dataGridViewPersons.SelectedRows[0].Cells["PersonId"].Value.ToString();
                    UsersManagments.check = 50;
                    frmRpt.ShowDialog();
                }
            }
        }

        private void grdPersonKatajats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            try
            {
                if (rbKhatta.Checked)
                {


                    if (e.RowIndex != -1)
                    {
                        if (grdPersonKatajats.Columns.Count > 1 && rbKhatta.Checked)
                        {


                            if (e.ColumnIndex == grdPersonKatajats.CurrentRow.Cells["خانہ کاشت"].ColumnIndex)
                            {
                                frmMessageBox mb = new frmMessageBox();
                                string val = intiqal.CheckKKinKhata(grdPersonKatajats.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString());
                                if (val == "1")
                                {
                                    mb.lbMessageBox.ForeColor = Color.White;
                                    mb.lbMessageBox.Text = "کھاتے میں خانہ کاشت موجود ہے";
                                    // mb.btnOK.ForeColor = System.Drawing.Color.Red;
                                    mb.BackColor = Color.Red;
                                }

                                else
                                {
                                    mb.lbMessageBox.ForeColor = Color.DarkGreen;
                                    mb.lbMessageBox.Text = "کھاتے میں خانہ کاشت موجو دنہیں ہے";
                                    mb.btnOK.ForeColor = Color.DarkGreen;
                                }
                                mb.ShowDialog();
                            }

                            if (e.ColumnIndex == grdPersonKatajats.CurrentRow.Cells["رقبہ بعد از منہائے"].ColumnIndex)
                            {
                                frmMessageBox mb = new frmMessageBox();
                                string val = intiqal.RemAreaofPersonByKhata(dataGridViewPersons.CurrentRow.Cells["PersonId"].Value.ToString(), grdPersonKatajats.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString());
                                if (val != grdPersonKatajats.CurrentRow.Cells["Malik_Area"].Value.ToString())
                                {
                                    mb.lbMessageBox.ForeColor = Color.White;
                                    mb.lbAfterMenhay.ForeColor = Color.White;
                                    mb.lbAfterMenhay.Text = "رقبہ بعد از منہائے";
                                    mb.lbMessageBox.Text = val;
                                    // mb.btnOK.ForeColor = System.Drawing.Color.Red;
                                    mb.BackColor = Color.Red;
                                }

                                else
                                {
                                    mb.lbMessageBox.ForeColor = Color.DarkGreen;
                                    mb.lbAfterMenhay.ForeColor = Color.DarkGreen;
                                    mb.lbAfterMenhay.Text = "رقبہ بعد از منہائے";
                                    mb.lbMessageBox.Text = val;
                                    mb.btnOK.ForeColor = Color.DarkGreen;
                                }
                                mb.ShowDialog();

                            }

                        }



                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            txtVisitorName.Clear();
            txtFatherName.Clear();
        }


        //}
    }
}
