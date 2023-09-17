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
    public partial class frmSearch : Form
    {
        /// <summary>
        /// variables
        /// </summary>

        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        BL.frmToken objbusines = new BL.frmToken();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public bool btn { get; set; }
        public string tokenID { get; set; }
        public string tokenno { get; set; }
        public string name { get; set; }
        public string fathername { get; set; }
        public string cnic { get; set; }
        public string service { get; set; }
        public string mouza { get; set; }
        public string mouzaid { get; set; }
        public string pvid { get; set; }
        public string pvno { get; set; }
        public string hiddenservvicetypeid { get; set; }
        public string tokenPurposeId { get; set; }
        public string sequenceid { get; set; }
        public string pvddetailslastid { get; set; }
        public string fromform { get; set; }
        public DateTime tokenDate = DateTime.Now; //{ get; set; }
        public string IntiqalId { get; set; }
        public string IntiqalTypeId { get; set; }
        public string PV_Verified { get; set; }
        public string KKM { get; set; }


        public frmSearch()
        {
            //    this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
            tokenID = "-1";
            Proc_Get_SDC_TokenList_For_PaymentVoucher();
            btnSearch.Visible = false;
        }

        public void Proc_Get_SDC_TokenList_For_PaymentVoucher()
        {
        try
            {
                if (fromform == "1" || fromform == "2" || fromform == "4")
                {
                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_Only_Fard " + UsersManagments._Tehsilid.ToString() + ",'" + dateTime.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + fromform + "',"+UsersManagments.SubSdcId.ToString());
                }

                else if (fromform == "3")
                {
                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_Only_Naqal_Intiqal " + UsersManagments._Tehsilid.ToString() + ",'" + dateTime.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + fromform + "', "+UsersManagments.SubSdcId.ToString());
                }
                else
                {
                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_TokenList_For_PaymentVoucher " + UsersManagments._Tehsilid.ToString() + ",'" + dateTime.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "' ,"+UsersManagments.SubSdcId.ToString());
                }
                DataTable outputTable = dt.Clone();

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    outputTable.ImportRow(dt.Rows[i]);
                }
                grdTokenData.DataSource = outputTable;
                TT_forSearch();


                Populategrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }}
        public void   Populategrid()

        {
            grdTokenData.Columns["Token_ShortDate"].DisplayIndex = 0; 
            grdTokenData.Columns["TokenNo"].DisplayIndex = 1;
            grdTokenData.Columns["Visitor_Name"].DisplayIndex = 2;
            grdTokenData.Columns["Visitor_FatherName"].DisplayIndex = 3;
            grdTokenData.Columns["Visitor_CNIC"].DisplayIndex = 4;
            grdTokenData.Columns["ServiceTypeName_Urdu"].DisplayIndex =5;        
            grdTokenData.Columns["Token_Verified"].DisplayIndex = 6;
            grdTokenData.Columns["MozaNameUrdu"].DisplayIndex = 7;
          

            
            grdTokenData.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
            grdTokenData.Columns["Token_ShortDate"].HeaderText = "ٹوکن کی تاریخ";
            grdTokenData.Columns["Visitor_Name"].HeaderText = "نام";
            grdTokenData.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر";
            grdTokenData.Columns["Visitor_CNIC"].HeaderText = "شناختی کارڈ";
            grdTokenData.Columns["Token_Verified"].HeaderText =  "تصدیق شدہ";
            grdTokenData.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdTokenData.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdTokenData.Columns["TokenService_For_MozaId"].Visible = false;
            grdTokenData.Columns["TokenDate"].Visible = false;
            grdTokenData.Columns["ServiceTypeId"].Visible = false;
            grdTokenData.Columns["TokenId"].Visible = false;

            if (fromform == "1" || fromform == "2" || fromform == "3" || fromform == "4")
            {
                grdTokenData.Columns["TokenPurposeId"].Visible = false;
            }

            if (fromform == "3")
            {
                grdTokenData.Columns["IntiqalId"].Visible = false;
                grdTokenData.Columns["IntiqalTypeId"].Visible = false;
                grdTokenData.Columns["KKM"].Visible = false;
                grdTokenData.Columns["PV_Verified_Status"].Visible = false;
            }
            if (fromform == "4")
            {
                grdTokenData.Columns["pvstatus"].Visible = false;
            }
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
            
        }
        public void fillgv_by_filter(string Condition)
        {
           
            DataView v = new DataView(dt);
            v.RowFilter = Condition;
            grdTokenData.DataSource = v;
        }



        public void filldatagrid(string query)
        {
            dt.Clear();
            dt = this.objbusines.filldatatable_from_storedProcedure(query);
           // bs.DataSource = dt;
            grdTokenData.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                objdatagrid.gridControls(grdTokenData);
                //lblrecordfound.Text = dt.Rows.Count.ToString();
            }
            else
            {
                //lblrecordfound.Text = "0";
            }
            objdatagrid.colorrbackgrid(grdTokenData);

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

        private void grdTokenData_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("M clecked");
            grdTokenData.RowsDefaultCellStyle.SelectionBackColor = Color.LightPink;
        }

        

        private void grdTokenData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grdTokenData.RowsDefaultCellStyle.SelectionBackColor = Color.LightPink;

        }

      
        private void grdTokenData_DoubleClick(object sender, EventArgs e)
        {
            this.tokenID = grdTokenData.CurrentRow.Cells["TokenId"].Value.ToString();
            this.tokenno = grdTokenData.CurrentRow.Cells["TokenNo"].Value.ToString();
            this.name = grdTokenData.CurrentRow.Cells["Visitor_Name"].Value.ToString();
            this.mouza = grdTokenData.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
            this.mouzaid = grdTokenData.CurrentRow.Cells["TokenService_For_MozaId"].Value.ToString();
            this.service = grdTokenData.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
            this.fathername = grdTokenData.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
            this.cnic = grdTokenData.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
            this.hiddenservvicetypeid = grdTokenData.CurrentRow.Cells["ServiceTypeId"].Value.ToString();
            this.tokenDate = Convert.ToDateTime(grdTokenData.CurrentRow.Cells["TokenDate"].Value);
            if (fromform == "1" || fromform == "2")
            {
                this.tokenPurposeId = grdTokenData.CurrentRow.Cells["TokenPurposeId"].Value.ToString();
            }
            if (fromform == "3")
            {
                this.IntiqalId = grdTokenData.CurrentRow.Cells["IntiqalId"].Value.ToString();
                this.IntiqalTypeId = grdTokenData.CurrentRow.Cells["IntiqalTypeId"].Value.ToString();
                this.KKM = grdTokenData.CurrentRow.Cells["KKM"].Value.ToString();
                this.PV_Verified = grdTokenData.CurrentRow.Cells["PV_Verified_Status"].Value.ToString();
            }

            if (fromform == "4")
            {
                this.PV_Verified = grdTokenData.CurrentRow.Cells["pvstatus"].Value.ToString();
            }
           
            btn = true;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }

        }



        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != 13)
            {
                e.Handled = true;

            }


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


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           // bs.Filter = string.Format("TokenNo LIKE '%{0}%'", txtToken.Text);
            string filter=txtToken.Text.ToString();
            fillgv_by_filter("TokenNo LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }
        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtCNIC.Text.ToString();
            fillgv_by_filter("Visitor_CNIC LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtName.Text.ToString();
            fillgv_by_filter("Visitor_Name LIKE '%" + filter + "%'");
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }
        public void TT_forSearch()
        {
            toolTipSearch.SetToolTip(txtCNIC,"شناختی کارڈ نمبرلکھ کر تلاش کریں");
            toolTipSearch.SetToolTip(txtName, "نام لکھ کر تلاش کریں");
            toolTipSearch.SetToolTip(txtToken,"ٹوکن نمبر لکھ کر تلاش کریں");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt.Clear();
            Proc_Get_SDC_TokenList_For_PaymentVoucher();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            objdatagrid.colorrbackgrid(grdTokenData);
            objdatagrid.gridControls(grdTokenData);
            grdTokenData.Columns["Visitor_CNIC"].Width = 180;
        }

        private void grdTokenData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

    }
}
