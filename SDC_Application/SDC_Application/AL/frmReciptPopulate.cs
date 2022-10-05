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
    public partial class frmReciptPopulate : Form
    {
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        BL.frmVoucher objbusines = new BL.frmVoucher();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public bool btn { get; set; }
        public string RVId { get; set; }
        public string RVNo { get; set; }
        public string PVId { get; set; }
        public string PVNo { get; set; }
        public string PVdate { get; set; }
        public string RVdate { get; set; }
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
        public string  Rvstatus { get; set; }


        public frmReciptPopulate()
        {
            InitializeComponent();
        }

       

        private void frmReciptPopulate_Load(object sender, EventArgs e)
        {
            Proc_Get_SDC_ReceiptVoucherMaster_List();
            btnSearch.Visible = false;
 
        }
        public void Proc_Get_SDC_ReceiptVoucherMaster_List()
        {
            dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherMaster_List '"+this.dateTime.Value.ToShortDateString()+"'");
            bs.DataSource = dt;
            grdReciptMaster.DataSource = bs;
            DataTable outputTable = dt.Clone();

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(dt.Rows[i]);
            }
            // grdVoucherDetails.DataSource = outputTable;
            grdReciptMaster.DataSource = outputTable;

            if(outputTable!=null)
            PopulateGrid();

                       
        }

        public void PopulateGrid()
        {
            grdReciptMaster.Columns["PV_Date"].DisplayIndex = 0;
            grdReciptMaster.Columns["RVDate"].DisplayIndex = 1;
            grdReciptMaster.Columns["RVNo"].DisplayIndex = 2;
            grdReciptMaster.Columns["TokenNo"].DisplayIndex = 3;

            grdReciptMaster.Columns["Visitor_Name"].DisplayIndex = 4;
            grdReciptMaster.Columns["Visitor_FatherName"].DisplayIndex = 5;
            grdReciptMaster.Columns["Visitor_CNIC"].DisplayIndex = 6;
            grdReciptMaster.Columns["ServiceTypeName_Urdu"].DisplayIndex = 7;
            grdReciptMaster.Columns["MozaNameUrdu"].DisplayIndex = 8;
            grdReciptMaster.Columns["RV_VerifiedStatus"].DisplayIndex = 9;

            //grdReciptMaster.Columns["RVId"].HeaderText = " رسید آیی ڈی";
            grdReciptMaster.Columns["RVNo"].HeaderText = "رسید نمبر";
            grdReciptMaster.Columns["TokenNo"].HeaderText = "چالان فارم نمبر";
            grdReciptMaster.Columns["PV_Date"].HeaderText = "چالان فارم تاریخ";
            grdReciptMaster.Columns["RVDate"].HeaderText = "رسید کی تاریخ";
            grdReciptMaster.Columns["Visitor_Name"].HeaderText = " نام";
            grdReciptMaster.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر ";
            grdReciptMaster.Columns["Visitor_CNIC"].HeaderText = "شناختی کارڈ نمبر";
            grdReciptMaster.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdReciptMaster.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdReciptMaster.Columns["RV_VerifiedStatus"].HeaderText = "تصدیق شدہ";

            grdReciptMaster.Columns["RVId"].Visible = false;
            grdReciptMaster.Columns["RVRemarks"].Visible = false;
            grdReciptMaster.Columns["TehsilId"].Visible = false;
            grdReciptMaster.Columns["TokenId"].Visible = false;
            grdReciptMaster.Columns["TokenDate"].Visible = false;
            grdReciptMaster.Columns["Visitor_FatherName"].Visible = false;
            grdReciptMaster.Columns["ServiceTypeId"].Visible = false;
            grdReciptMaster.Columns["PVId"].Visible = false;
            grdReciptMaster.Columns["MozaId"].Visible = false;
            grdReciptMaster.Columns["PV_No"].Visible = false;
            //grdReciptMaster.Columns["RV_Date"].Visible = false;
            objdatagrid.colorrbackgrid(grdReciptMaster);
            objdatagrid.gridControls(grdReciptMaster);
            grdReciptMaster.Columns["Visitor_CNIC"].Width = 180;
        }
        private void grdReciptMaster_DoubleClick(object sender, EventArgs e)
        {
            this.RVId = grdReciptMaster.CurrentRow.Cells["RVId"].Value.ToString();
            this.RVNo = grdReciptMaster.CurrentRow.Cells["RVNo"].Value.ToString();
            this.PVId = grdReciptMaster.CurrentRow.Cells["PVId"].Value.ToString();
            this.PVNo = grdReciptMaster.CurrentRow.Cells["PV_No"].Value.ToString();
            this.PVdate = grdReciptMaster.CurrentRow.Cells["PV_Date"].Value.ToString();
            this.TokenNo = grdReciptMaster.CurrentRow.Cells["TokenNo"].Value.ToString();
            this.Name = grdReciptMaster.CurrentRow.Cells["Visitor_Name"].Value.ToString();
            this.CNIC = grdReciptMaster.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
            this.ServiceName = grdReciptMaster.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
            this.Mouzaid = grdReciptMaster.CurrentRow.Cells["MozaId"].Value.ToString();
            this.Mouza = grdReciptMaster.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
            this.FatherName = grdReciptMaster.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
            this.TokenID = grdReciptMaster.CurrentRow.Cells["TokenId"].Value.ToString();
            this.Remarks = grdReciptMaster.CurrentRow.Cells["RVRemarks"].Value.ToString();
            this.ServiceType = grdReciptMaster.CurrentRow.Cells["ServiceTypeId"].Value.ToString();
            this.Rvstatus = grdReciptMaster.CurrentRow.Cells["RV_VerifiedStatus"].Value.ToString();
            this.RVdate = grdReciptMaster.CurrentRow.Cells["RVDate"].Value.ToString();

            if (Rvstatus == "")
            {
                Rvstatus = "0";

            }
            else
            {
                Rvstatus = "1";
            }
            this.btn = true;

           
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("RVNo LIKE '%{0}%'", txtSearch.Text);
            objdatagrid.colorrbackgrid(grdReciptMaster);
            objdatagrid.gridControls(grdReciptMaster);
            grdReciptMaster.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("Visitor_CNIC LIKE '%{0}%'", txtCNIC.Text);
            objdatagrid.colorrbackgrid(grdReciptMaster);
            objdatagrid.gridControls(grdReciptMaster);
            grdReciptMaster.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("Visitor_Name LIKE '%{0}%'", txtName.Text);
            objdatagrid.colorrbackgrid(grdReciptMaster);
            objdatagrid.gridControls(grdReciptMaster);
            grdReciptMaster.Columns["Visitor_CNIC"].Width = 180;
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
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar!=13)
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

        private void grdReciptMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Proc_Get_SDC_ReceiptVoucherMaster_List();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender,e);
        }


    }
}

