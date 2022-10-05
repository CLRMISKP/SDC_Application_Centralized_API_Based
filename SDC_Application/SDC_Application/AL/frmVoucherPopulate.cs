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

namespace SDC_Application.AL
{
    public partial class frmVoucherPopulate : Form
    {
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        BL.frmToken objbusines = new BL.frmToken();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string datetoken;
        public bool btn { get; set; }
        public string PVId { get; set; }
        public string PVNo { get; set; }
        public string PVdate { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string ServiceName { get; set; }
        public string Mouza { get; set; }
        public string Mouzaid { get; set; }
        public string Remarks { get; set; }
        public string TokenID { get; set; }
        public string TokenNo { get; set; }
        public string ServiceType { get; set; }
        public string Pvstatus { get; set; }


        public frmVoucherPopulate()
        {
            InitializeComponent();
        }

        private void frmVoucherPopulate_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();


            Proc_Get_SDC_PaymentVoucherMaster_List();
            //PupoulateGrid();
            TooltipPopulate();
            btnSearch.Visible = false;
        }
        public void Proc_Get_SDC_PaymentVoucherMaster_List()
        {
            DateTime date = dateTime.Value;
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string year = date.Year.ToString();
            datetoken = month + "/" + day + "/" + year;
            dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherMaster_List '" + datetoken + "'");
            if (dt != null)
            {
                DataTable outputTable = dt.Clone();

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    outputTable.ImportRow(dt.Rows[i]);
                }
                bs.DataSource = dt;
                grdPaymentMaster.DataSource = bs;
                grdPaymentMaster.DataSource = outputTable;
                if(outputTable!=null)
                PupoulateGrid();
            }

        }

        public void PupoulateGrid()
        {
            grdPaymentMaster.Columns["PV_Date"].DisplayIndex = 0;
            grdPaymentMaster.Columns["PV_No"].DisplayIndex = 1;
            grdPaymentMaster.Columns["Visitor_Name"].DisplayIndex = 2;
            grdPaymentMaster.Columns["Visitor_FatherName"].DisplayIndex = 3;

            grdPaymentMaster.Columns["Visitor_CNIC"].DisplayIndex = 4;
            grdPaymentMaster.Columns["ServiceTypeName_Urdu"].DisplayIndex = 5;
            grdPaymentMaster.Columns["MozaNameUrdu"].DisplayIndex = 6;
            grdPaymentMaster.Columns["PV_Verified_Status"].DisplayIndex = 7;

            // grdPaymentMaster.Columns["PVId"].HeaderText = "پی وی آیی ڈی";
            grdPaymentMaster.Columns["PV_No"].HeaderText = "چالان نمبر";
            grdPaymentMaster.Columns["PV_Date"].HeaderText = "چالان  تاریخ";
            grdPaymentMaster.Columns["Visitor_Name"].HeaderText = "نام سائل";
            grdPaymentMaster.Columns["Visitor_FatherName"].HeaderText = "ولد/شوہر ";

            grdPaymentMaster.Columns["Visitor_CNIC"].HeaderText = "شناختی کارڈ نمبر";
            grdPaymentMaster.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdPaymentMaster.Columns["MozaNameUrdu"].HeaderText = "موصغ";
            grdPaymentMaster.Columns["PV_Verified_Status"].HeaderText = "تصدیق شدہ";

            grdPaymentMaster.Columns["PVId"].Visible = false;
            grdPaymentMaster.Columns["TehsilId"].Visible = false;
            grdPaymentMaster.Columns["TokenId"].Visible = false;
            grdPaymentMaster.Columns["PV_Status"].Visible = false;
            grdPaymentMaster.Columns["PV_Remarks"].Visible = false;
            grdPaymentMaster.Columns["TokenService_For_MozaId"].Visible = false;
            grdPaymentMaster.Columns["TokenPurposeId"].Visible = false;
            grdPaymentMaster.Columns["ServiceTypeId"].Visible = false;
            grdPaymentMaster.Columns["TokenPurpose_Urdu"].Visible = false;
            grdPaymentMaster.Columns["ServiceTypeId"].Visible = false;
            grdPaymentMaster.Columns["PV_Status"].Visible = false;
            grdPaymentMaster.Columns["TokenNo"].Visible = false;

            objdatagrid.colorrbackgrid(grdPaymentMaster);
            objdatagrid.gridControls(grdPaymentMaster);
            grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
            grdPaymentMaster.ColumnHeadersHeight = 30;
            int colCount = grdPaymentMaster.RowCount;


            //for (int i = 0; i < colCount; i++)
            //{

            //    grdPaymentMaster.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, FontStyle.Regular);

            //}
        }
        private void grdPaymentMaster_DoubleClick(object sender, EventArgs e)
        {
            this.PVId = grdPaymentMaster.CurrentRow.Cells["PVId"].Value.ToString();
            this.PVNo = grdPaymentMaster.CurrentRow.Cells["PV_No"].Value.ToString();
            this.PVdate = grdPaymentMaster.CurrentRow.Cells["PV_Date"].Value.ToString();
            this.TokenNo = grdPaymentMaster.CurrentRow.Cells["TokenNo"].Value.ToString();
            this.Name = grdPaymentMaster.CurrentRow.Cells["Visitor_Name"].Value.ToString();
            this.CNIC = grdPaymentMaster.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
            this.ServiceName = grdPaymentMaster.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
            this.Mouzaid = grdPaymentMaster.CurrentRow.Cells["TokenService_For_MozaId"].Value.ToString();
            this.Mouza = grdPaymentMaster.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
            this.FatherName = grdPaymentMaster.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
            this.TokenID = grdPaymentMaster.CurrentRow.Cells["TokenId"].Value.ToString();
            this.Remarks = grdPaymentMaster.CurrentRow.Cells["PV_Remarks"].Value.ToString();
            this.ServiceType = grdPaymentMaster.CurrentRow.Cells["ServiceTypeId"].Value.ToString();
            this.Pvstatus = grdPaymentMaster.CurrentRow.Cells["PV_Verified_Status"].Value.ToString();
            if (this.Pvstatus == "")
            {
                this.Pvstatus = "False";
            }
            this.btn = true;

            //btn = true;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" PV_No LIKE '%{0}%'", txtSearch.Text);
            objdatagrid.colorrbackgrid(grdPaymentMaster);
            objdatagrid.gridControls(grdPaymentMaster);
            grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
            grdPaymentMaster.ColumnHeadersHeight = 30;
            int colCount = grdPaymentMaster.RowCount;
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("Visitor_CNIC LIKE '%{0}%' ", txtCNIC.Text);
            objdatagrid.colorrbackgrid(grdPaymentMaster);
            objdatagrid.gridControls(grdPaymentMaster);
            grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
            grdPaymentMaster.ColumnHeadersHeight = 30;
            int colCount = grdPaymentMaster.RowCount;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("Visitor_Name LIKE '%{0}%'", txtName.Text);
            objdatagrid.colorrbackgrid(grdPaymentMaster);
            objdatagrid.gridControls(grdPaymentMaster);
            grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
            grdPaymentMaster.ColumnHeadersHeight = 30;
            int colCount = grdPaymentMaster.RowCount;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
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
        public void TooltipPopulate()
        {
            toolTip.SetToolTip(txtCNIC, "شناختی کارڈ نمبر لکھ کر تلاش کریں");
            toolTip.SetToolTip(txtName, "نام لکھ کر تلاش کریں");
            toolTip.SetToolTip(txtSearch, "چالان نمبر لکھ کر تلاش کریں");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Proc_Get_SDC_PaymentVoucherMaster_List();
            //PupoulateGrid();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);

        }


    }
}
