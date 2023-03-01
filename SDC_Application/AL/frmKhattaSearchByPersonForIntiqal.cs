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
    public partial class frmKhattaSearchByPersonForIntiqal : Form
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
        string selectedPersons = "";
        public string PersonName { get; set; }
        public string FatherName { get; set; }
        public string MozaID { get; set; }
        public string PersonId { get; set; }
        public string IntiqalId { get; set; }
        public string TokenID { get; set; }
        public string FM { get; set; }

        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();

        #endregion
        public frmKhattaSearchByPersonForIntiqal()
        {
            InitializeComponent();
        }

        private void frmKhattaSearchByPerson_Load(object sender, EventArgs e)
        {
            //if(KM=="M")
            //{
                rbKhatta.Checked=true;
                rbKhatta.Enabled = false;
                rbKhatooni.Enabled = false;
            //}
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

     

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            selectedPersons = "";
            grdPersonKatajats.DataSource = null;
            if ((txtVisitorName.Text.Trim() != "" || txtFatherName.Text.Trim()!="") )
            {
               
                this.PersonName = txtVisitorName.Text.Trim();
                this.FatherName = txtFatherName.Text.Trim();
                this.Persons.Clear();
                this.Persons = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Searched_Afrad_List "+UsersManagments._Tehsilid.ToString()+"," + this.MozaID + ",1, N'" + PersonName + "',N'" + FatherName + "'");
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
                this.dataGridViewPersons.Columns["CNIC"].Visible = false;       //MozaId, QoamId, PersonName, FatherName
                this.dataGridViewPersons.Columns["MozaId"].Visible = false;
                this.dataGridViewPersons.Columns["QoamId"].Visible = false;
                this.dataGridViewPersons.Columns["PersonName"].Visible = false;
                this.dataGridViewPersons.Columns["FatherName"].Visible = false;
            }
        }

        #endregion

        #region Gridview Persons Click Event

        private void dataGridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    dataGridViewPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (e.ColumnIndex == dataGridViewPersons.CurrentRow.Cells["colchk"].ColumnIndex)
                    {
                        int b = Convert.ToInt32(dataGridViewPersons.CurrentRow.Cells["colchk"].Value);

                        if (b == 1)
                        {
                            dataGridViewPersons.CurrentRow.Cells["colchk"].Value = 0;
                           
                        }
                        else
                        {
                            dataGridViewPersons.CurrentRow.Cells["colchk"].Value = 1;
                           
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

        #region Get Person Khattas

        private void GetPersonKhattas(string PersonId)
        {
            chkAll.Visible = false;
            chkAll.Checked = false;
            DataTable dtKhattas = new DataTable();
            //dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats_WithLocks " + this.MozaID + "," + PersonId);
            //self----------------------------------
            //dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_WithLocks " + this.MozaID + "," + PersonId);
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_For_Intiqal " + this.MozaID + "," + PersonId);
            //---------------------------------------
            this.grdPersonKatajats.DataSource = dtKhattas;
            if (dtKhattas.Rows.Count > 0)
            {
                chkAll.Visible = true;
                grdPersonKatajats.Columns["CompleteName"].HeaderText = "نام";
                grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";
                grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                grdPersonKatajats.Columns["Malik_Area"].HeaderText = "مالک کا رقبہ";
                grdPersonKatajats.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                //grdPersonKatajats.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                grdPersonKatajats.Columns["HissaDifference"].HeaderText = "حصص فرق";
                //grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
                grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
                //grdPersonKatajats.Columns["Kanal"].Visible = false;
                //grdPersonKatajats.Columns["Marla"].Visible = false;
                //grdPersonKatajats.Columns["sarsai"].Visible = false;
                //grdPersonKatajats.Columns["RecordLocked"].Visible = false;
                grdPersonKatajats.Columns["PersonId"].Visible = false;
                grdPersonKatajats.Columns["KhewatTypeId"].Visible = false;
                grdPersonKatajats.Columns["KhewatGroupFareeqId"].Visible = false;
            }
            else
            {
                this.grdPersonKatajats.DataSource = null;
                MessageBox.Show("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               //this.grdPersonKatajats.ColumnCount = 1;
              //this.grdPersonKatajats.Rows.Add("انتخاب کردہ مالک کا کوئی ریکارڈ موجود نہیں");// this.grdPersonKatajats.Rows.Insert(0, "one", "two", "three", "four");
            }
            // Get Total Raqba
            if (dtKhattas.Rows.Count > 0)
            {
             
              DataTable PersonTotalArea = new DataTable();
              //PersonTotalArea = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId " + this.MozaID + "," + PersonId);
              PersonTotalArea = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId_For_Intiqal "+UsersManagments._Tehsilid.ToString()+"," + this.MozaID + "," + PersonId);
             
                foreach (DataRow row in PersonTotalArea.Rows)
              {
                  txtTotalRaqba.Text = row["Fardarea"].ToString();
                  
              }
            }
            else
            {
                txtTotalRaqba.Clear();
                txtSelectedArea.Clear();
            }

              
              


        }

        #endregion

        #region Get Person Khatoonies

        private void GetPersonKhaoonies(string PID)
        {

            DataTable dtKhatoonies = new DataTable();
            dtKhatoonies = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_Khatoonies " + PID);
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
                PersonTotalAreaKK = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_TotalRaqba_By_PersonId_MozaId_KhanaKasht " + this.MozaID + "," + PID);
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

        private void grdPersonKatajats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                grdPersonKatajats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == grdPersonKatajats.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value = 0;
                    }
                    else
                    {
                        grdPersonKatajats.CurrentRow.Cells["cbgrid"].Value = 1; ;
                    }
                }


                if (this.grdPersonKatajats.Rows.Count > 0)
                {
                    string[] spTotal = txtTotalRaqba.Text.Split('-');
                    int aa = 0;
                    int k=0, m=0, f=0;
                    for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                    {

                        string s = grdPersonKatajats.Rows[i].Cells["Malik_Area"].Value.ToString();
                       
                        string[] sp = s.Split('-');
                       
                        
           
                        int b = Convert.ToInt32(grdPersonKatajats.Rows[i].Cells["cbgrid"].Value);
                        if (b == 1)
                        {
                            aa = aa + 1;

                            k = k + Convert.ToInt32(sp[0]);
                            m = m + Convert.ToInt32(sp[1]);
                            f = f + Convert.ToInt32(sp[2]);
                        }
                        else
                        {
                            //aa = aa - 1;

                            //k = k - Convert.ToInt32(sp[0]);
                            //m = m - Convert.ToInt32(sp[1]);
                            //f = f - Convert.ToInt32(sp[2]);
                        }
                        
                    }
                   
                    if (aa == this.grdPersonKatajats.Rows.Count)
                    {
                        chkAll.Checked = true;
                    }
                    else
                    {
                        chkAll.Checked = false;
                    }

                    double sqft=  Math.Round( (k*20*272.25) + (m*272.25) + (f),0) ;
                    DataTable SelectedArea= new DataTable();
                    SelectedArea = objBusiness.filldatatable_from_storedProcedure("[dbo].[Proc_Self_Get_KMS_From_Sqft] " + sqft);
                    foreach (DataRow row in SelectedArea.Rows)
                    {
                        txtSelectedArea.Text = row["Fardarea"].ToString();         
                    }

                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.grdPersonKatajats.Rows.Count > 0)
            {

            

                for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                        {
                            if (Convert.ToInt32(grdPersonKatajats.Rows[i].Cells["cbgrid"].Value) == 1)
                            {
                                if(FM=="M")
                                {
                                    string KhataId = grdPersonKatajats.Rows[i].Cells["RegisterHqDKhataId"].Value.ToString();
                                    string PersonId = grdPersonKatajats.Rows[i].Cells["PersonId"].Value.ToString();
                                    string s = intiqal.WEB_Self_SP_INSERT_Intiqal_KhataJat_and_Sellers(IntiqalId, KhataId, PersonId, UsersManagments.UserId.ToString());
                                }
                                if(FM=="F")
                                {
                                    string KhataId = grdPersonKatajats.Rows[i].Cells["RegisterHqDKhataId"].Value.ToString();
                                    string PersonId = grdPersonKatajats.Rows[i].Cells["PersonId"].Value.ToString();
                                    string s = intiqal.WEB_Self_SP_INSERT_Fard_KhataJat_and_Malikan(TokenID, KhataId, PersonId, UsersManagments.UserId.ToString(),UsersManagments.UserName.ToString(),UsersManagments._Tehsilid.ToString());
                                }
                            }
                        }

                this.Close();
            }
            else
                this.Close();
        }

        private void txtVisitorName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (this.grdPersonKatajats.Rows.Count > 0)
            {

                for (int i = 0; i <= grdPersonKatajats.Rows.Count - 1; i++)
                {

                    if (chkAll.Checked)
                    {

                        grdPersonKatajats.Rows[i].Cells["cbgrid"].Value = true;
                        txtSelectedArea.Text = txtTotalRaqba.Text;

                    }
                    else
                    {
                        grdPersonKatajats.Rows[i].Cells["cbgrid"].Value = false;
                        txtSelectedArea.Clear();
                    }
                }


            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewPersons.Rows.Count > 0)
            {
                selectedPersons = "";
                int count = 0;
                for (int i = 0; i <= dataGridViewPersons.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dataGridViewPersons.Rows[i].Cells["colchk"].Value) == 1)
                    {
                        count = +1;
                        if (selectedPersons == "")
                        {
                            selectedPersons = dataGridViewPersons.Rows[i].Cells["PersonId"].Value.ToString();
                        }
                        else
                        {
                            selectedPersons = selectedPersons + "," + dataGridViewPersons.Rows[i].Cells["PersonId"].Value.ToString();
                        }



                    }
                }
                if (count > 0)
                {
                    GetPersonKhattas("'" + selectedPersons + "'");
                }

            }
        }


        //}
    }
}
