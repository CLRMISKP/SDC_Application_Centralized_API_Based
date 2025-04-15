using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
using SDC_Application.LanguageManager;
//using Classess.Validations;
namespace SDC_Application.AL
{
    public partial class frmSearchRecipt : Form
    {


        /// <summary>
        /// variables
        /// </summary>

        AutoComplete objauto = new AutoComplete();
        DL.Database ojbdb = new DL.Database();
        BL.frmRecipt objbusines = new BL.frmRecipt();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
       
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public bool btn { get; set; }
        public string tokenID { get; set; }
        public string tokennum { get; set; }
        public string name { get; set; }
        public string father_name { get; set; }
        public string tokendate { get; set; }
        public string pvdate { get; set; }
        public string mouzaid { get; set; }
        public string mouzaname { get; set; }
        public string cnic { get; set; }
        public string pvno { get; set; }
        public string pvid { get; set; }
        public string servicename { get; set; }
        string datetoken;
        public frmSearchRecipt()
        {
            //    this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            Tooltip_forSearchRecipt();
            Proc_Get_SDC_TokensList_For_ReceiptVoucher();
            btnSearch.Visible = false;
            

        }
        public void Proc_Get_SDC_TokensList_For_ReceiptVoucher()
          {
              DateTime date = dateTime.Value;
              string month = date.Month.ToString();
              string day = date.Day.ToString();
              string year = date.Year.ToString();
              datetoken = month + "/" + day + "/" + year;
              dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_TokensList_For_ReceiptVoucher " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + datetoken + "',"+UsersManagments.SubSdcId.ToString());
            if (dt != null)
            {
                bs.DataSource = dt;
                grdTokenData.DataSource = bs;
                DataTable outputTable = dt.Clone();

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    outputTable.ImportRow(dt.Rows[i]);
                }
                // grdVoucherDetails.DataSource = outputTable;
                grdTokenData.DataSource = outputTable;
                PopulateGrid();
            }
        }
        public void PopulateGrid()
        {
            if (grdTokenData.DataSource != null)
            {
                grdTokenData.Columns["PV_ShortDate"].DisplayIndex = 1;
                grdTokenData.Columns["PV_No"].DisplayIndex = 2;
                grdTokenData.Columns["TokenNo"].DisplayIndex = 3;
                grdTokenData.Columns["Visitor_Name"].DisplayIndex = 4;
                grdTokenData.Columns["Visitor_FatherName"].DisplayIndex = 5;
                grdTokenData.Columns["Visitor_CNIC"].DisplayIndex = 6;
                grdTokenData.Columns["ServiceTypeName_Urdu"].DisplayIndex = 7;
                grdTokenData.Columns["MozaNameUrdu"].DisplayIndex = 8;

                grdTokenData.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                grdTokenData.Columns["PV_No"].HeaderText = "چالان نمبر";
                grdTokenData.Columns["PV_ShortDate"].HeaderText = "چالان تاریخ";
                grdTokenData.Columns["Visitor_Name"].HeaderText = "نام سائل";
                grdTokenData.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر ";
                grdTokenData.Columns["Visitor_CNIC"].HeaderText = "شناختی کارڈ نمبر";
                grdTokenData.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
                grdTokenData.Columns["MozaNameUrdu"].HeaderText = "موضع";

                grdTokenData.Columns["PV_Date"].Visible = false;
                grdTokenData.Columns["TokenId"].Visible = false;
                grdTokenData.Columns["PV_Verified_Status"].Visible = false;
                grdTokenData.Columns["TokenDate"].Visible = false;
                grdTokenData.Columns["ServiceTypeId"].Visible = false;
                grdTokenData.Columns["PV_Verified_Status"].Visible = false;
                grdTokenData.Columns["TokenService_For_MozaId"].Visible = false;
                grdTokenData.Columns["TokenId"].Visible = false;
                grdTokenData.Columns["PVId"].Visible = false;
                grdTokenData.Columns["Token_Verified"].Visible = false;



                objdatagrid.colorrbackgrid(grdTokenData);
                objdatagrid.gridControls(grdTokenData);
                grdTokenData.Columns["Visitor_CNIC"].Width = 180;
            }
        }
       


        public void filldatagrid(string query)
        {
            //dt.Clear();
            //dt = this.objbusines.filldatatable_from_storedProcedure(query);
            //bs.DataSource = dt;
            //grdTokenData.DataSource = bs;
            //if (dt.Rows.Count > 0)
            //{
            //    objdatagrid.gridControls(grdTokenData);
            //    //lblrecordfound.Text = dt.Rows.Count.ToString();
            //}
            //else
            //{
            //    //lblrecordfound.Text = "0";
            //}
            //objdatagrid.colorrbackgrid(grdTokenData);
            //grdTokenData.Columns[0].HeaderText = "ٹوکن نمبر";
            //grdTokenData.Columns[1].HeaderText = "ںام";
            //grdTokenData.Columns[2].HeaderText = "شناختی کارڈ";
            //grdTokenData.Columns[3].HeaderText = "مقصد";
            //grdTokenData.Columns[4].HeaderText = "سہولت";
            //grdTokenData.Columns[5].HeaderText = "ٹوکن کا موجودہ حالت";
            //grdTokenData.Columns[6].HeaderText = "تاریخ";
            //grdTokenData.Columns[7].Visible = false;
            //grdTokenData.Columns[8].Visible = false;
            //grdTokenData.Columns[9].Visible = false;
            //grdTokenData.Columns[10].Visible = false;

        }


        public void fillgv_by_filter(string Condition)
        {
            if (dt != null) { 
            DataView v = new DataView(dt);
            v.RowFilter = Condition;
            grdTokenData.DataSource = v;
        }
        }

        private void grdTokenData_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("M clecked");
            grdTokenData.RowsDefaultCellStyle.SelectionBackColor = Color.LightPink;
        }

        

        private void grdTokenData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grdTokenData.RowsDefaultCellStyle.SelectionBackColor = Color.LightPink;

        }

        //private void textBox1_TextChanged_1(object sender, EventArgs e)
        //{

          
        //}

        private void grdTokenData_DoubleClick(object sender, EventArgs e)
        {
            this.tokenID = grdTokenData.CurrentRow.Cells["TokenId"].Value.ToString();
            this.tokennum = grdTokenData.CurrentRow.Cells["TokenNo"].Value.ToString();
            this.name = grdTokenData.CurrentRow.Cells["Visitor_Name"].Value.ToString();
            this.father_name = grdTokenData.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
            
            
            //this.pvdate = grdTokenData.CurrentRow.Cells["PV_Date"].Value.ToString();
            object pvDateObj = grdTokenData.CurrentRow.Cells["PV_Date"].Value;
            DateTime pvDate;

            if (pvDateObj is DateTime)
            {
                pvDate = (DateTime)pvDateObj;
                this.pvdate = pvDate.ToString("dd MMM yyyy");
            }
            else if (pvDateObj is string)
            {
                string pvDateStr = (string)pvDateObj;
                if (DateTime.TryParse(pvDateStr, out pvDate))
                {
                    this.pvdate = pvDate.ToString("dd MMM yyyy");
                }
                else
                {
                    this.pvdate = DateTime.Now.ToString("dd MMM yyyy");
                }
            }
            else
            {
                this.pvdate = DateTime.Now.ToString("dd MMM yyyy");
            }


                this.cnic = grdTokenData.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
                this.mouzaid = grdTokenData.CurrentRow.Cells["TokenService_For_MozaId"].Value.ToString();
                this.mouzaname = grdTokenData.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
                this.pvno = grdTokenData.CurrentRow.Cells["PV_No"].Value.ToString();
                this.pvid = grdTokenData.CurrentRow.Cells["PVId"].Value.ToString();
                this.servicename = grdTokenData.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
                btn = true;
                this.Close();
        }

       
        

        private void txtPVNO_TextChanged(object sender, EventArgs e)
        {

            string filter = this.txtPVNO.Text.ToString();
            fillgv_by_filter("PV_No LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtNCIC_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtNCIC.Text.ToString();
            fillgv_by_filter("Visitor_CNIC LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtPVNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }

           
        }

        private void txtTokenNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }


        }

        private void txtNCIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != 13)
            {
                e.Handled = true;

            }


          
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }
        public void Tooltip_forSearchRecipt()
        {
            toolTipSearchRecipt.SetToolTip(txtName,"نام لکھ کر تلاش کریں");
            toolTipSearchRecipt.SetToolTip(txtNCIC,"شناختی کارڈ نمبر لکھ کر تلاش کریں");
            toolTipSearchRecipt.SetToolTip(txtPVNO,"ٹوکن نمبر لکھ کر تلاش کریں");
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Proc_Get_SDC_TokensList_For_ReceiptVoucher();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender,e);
            if (grdTokenData.DataSource != null)
            {
                objdatagrid.colorrbackgrid(grdTokenData);
                objdatagrid.gridControls(grdTokenData);
                grdTokenData.Columns["Visitor_CNIC"].Width = 180;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

            string filter = this.txtName.Text.ToString();
            fillgv_by_filter("Visitor_Name LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;

        }

        private void txtTokenNo_TextChanged(object sender, EventArgs e)
        {
           
            string filter = this.txtTokenNo.Text.ToString();
            fillgv_by_filter("TokenNo LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }


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

        private void grdTokenData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      

       

    


    }
}
