﻿using System;
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
    public partial class frmTokenPopulate : Form
    {
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        BL.frmVoucher objbusines = new BL.frmVoucher();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string datetoken;
        public bool btn { get; set; }
        public bool InteqalMain { get; set; }
        public string TokenID { get; set; }
        public string TokenNo { get; set; }
        public string Tokendate { get; set; }
        public string NameVisitor { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string VisitorContactNo { get; set; }
        public string Mouza { get; set; }
        public string Mouzaid { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string PurposeName { get; set; }
        public string PurposeID { get; set; }
        public string TokenStatus { get; set; }
        public string TempAdd  { get; set; }
        public string PerAdd { get; set; }
        public string DuplicatePRint { get; set; }
        public string tokentime { get; set; }

        public string ServiceTypeId { get; set; } // for filtering Token on basis of Service generated for


        public  frmTokenPopulate()
        {
            InitializeComponent();
        }

       
        public void PupulateGrid()
        {
         

            //grdToken.Columns["TokenID"].DisplayIndex = 0;

            grdToken.Columns["Token_ShortDate"].DisplayIndex = 0;
            grdToken.Columns["TokenNo"].DisplayIndex = 1;
            grdToken.Columns["Visitor_Name"].DisplayIndex =2;
            grdToken.Columns["Visitor_FatherName"].DisplayIndex = 3;
            grdToken.Columns["Visitor_CNIC"].DisplayIndex = 4;
            grdToken.Columns["ServiceTypeName_Urdu"].DisplayIndex = 5;
            grdToken.Columns["MozaNameUrdu"].DisplayIndex = 6;
            grdToken.Columns["TokenPurpose_Urdu"].DisplayIndex = 7;
            grdToken.Columns["Token_CurrentStatus"].DisplayIndex = 8;                 
            grdToken.Columns["TokenID"].HeaderText = "ٹوکن آئی ڈی";
            grdToken.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
            grdToken.Columns["Token_ShortDate"].HeaderText = "ٹوکن کی تاریخ";
            grdToken.Columns["Visitor_Name"].HeaderText = "نام";
            grdToken.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر ";
            grdToken.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdToken.Columns["Visitor_CNIC"].HeaderText = "شناختی کارڈ نمبر";
            grdToken.Columns["VisitorContactNo"].HeaderText = "ربطہ نمبر";
            grdToken.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdToken.Columns["TokenPurpose_Urdu"].HeaderText = "مقصد";
            grdToken.Columns["Token_CurrentStatus"].HeaderText = "تصدیق شدہ";
            grdToken.Columns["TokenId"].Visible = false;
            grdToken.Columns["TokenDate"].Visible = false;
            grdToken.Columns["TokenPurposeId"].Visible = false;
            grdToken.Columns["Token_Verified"].Visible = false;
            grdToken.Columns["TehsilId"].Visible = false;
            grdToken.Columns["Visitor_TempAddress"].Visible = false;
            grdToken.Columns["Visitor_PermAddress"].Visible = false;
            grdToken.Columns["ServiceTypeId"].Visible = false;
            grdToken.Columns["ServiceTypeId"].Visible = false;
            grdToken.Columns["TokenPurposeId"].Visible = false;
            grdToken.Columns["ServiceTypeId"].Visible = false;
            grdToken.Columns["Token_DuplicatePrint"].Visible = false;
            grdToken.Columns["TokenService_For_MozaId"].Visible = false;
            grdToken.Columns["TehsilNameUrdu"].Visible = false;
            grdToken.Columns["Token_Time"].Visible = false;
            objdatagrid.colorrbackgrid(grdToken);
            objdatagrid.gridControls(grdToken);
            grdToken.Columns["Visitor_CNIC"].Width = 180;
        }
        private void grdToken_DoubleClick(object sender, EventArgs e)
        {



        }

        private void frmTokenPopulate_Load(object sender, EventArgs e)
        {
            TooltipPopulate();
            Proc_Get_SDCToken_Detail_All();
            //objdatagrid.colorrbackgrid(grdToken);
            //objdatagrid.gridControls(grdToken);
            //grdToken.Columns["Visitor_CNIC"].Width = 180;
            btnSearch.Visible = false;
           
        }
        public void Proc_Get_SDCToken_Detail_All()
    {   try
            {

                DateTime date = dateTime.Value;
                string month = date.Month.ToString();
                string day = date.Day.ToString();
                string year = date.Year.ToString();
                datetoken = month + "/" + day + "/" + year;
                //if (this.ServiceTypeId != null && this.ServiceTypeId != "0")
                //{
                //    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDCToken_Detail_All_Test '" + datetoken + "', 19003");
                //}
                //else
                //{
                dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDCToken_Detail_All '" + datetoken + "', "+UsersManagments._Tehsilid.ToString());
                // }
                if (dt != null)
                {
                    DataTable outputTable = dt.Clone();

                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        outputTable.ImportRow(dt.Rows[i]);
                    }
                    grdToken.DataSource = outputTable;
                    if (dt != null)
                    {
                        PupulateGrid();
                    }
                    else
                    { MessageBox.Show(""); }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        public void fillgrid_byfilter(string Condition)
        {
            if (dt != null)
            {
                DataView v = new DataView(dt);
                v.RowFilter = Condition;
                grdToken.DataSource = v;           
            }
        
        }

        private void grdToken_DoubleClick_1(object sender, EventArgs e)
        {
            if (InteqalMain)
            {
                this.TokenID = grdToken.CurrentRow.Cells["TokenId"].Value.ToString();
                this.TokenNo = grdToken.CurrentRow.Cells["TokenNo"].Value.ToString();
            }
            else
            {
                this.TokenID = grdToken.CurrentRow.Cells["TokenId"].Value.ToString();
                this.TokenNo = grdToken.CurrentRow.Cells["TokenNo"].Value.ToString();
                this.NameVisitor = grdToken.CurrentRow.Cells["Visitor_Name"].Value.ToString();
                this.CNIC = grdToken.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
                this.VisitorContactNo = grdToken.CurrentRow.Cells["VisitorContactNo"].Value.ToString();
                this.FatherName = grdToken.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
                this.Tokendate = grdToken.CurrentRow.Cells["Token_ShortDate"].Value.ToString();
                this.ServiceName = grdToken.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
                this.ServiceType = grdToken.CurrentRow.Cells["ServiceTypeId"].Value.ToString();
                this.PurposeID = grdToken.CurrentRow.Cells["TokenPurposeId"].Value.ToString();
                this.PurposeName = grdToken.CurrentRow.Cells["TokenPurpose_Urdu"].Value.ToString();
                this.Mouzaid = grdToken.CurrentRow.Cells["TokenService_For_MozaId"].Value.ToString();
                this.Mouza = grdToken.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
                this.TempAdd = grdToken.CurrentRow.Cells["Visitor_TempAddress"].Value.ToString();
                this.PerAdd = grdToken.CurrentRow.Cells["Visitor_PermAddress"].Value.ToString();
                this.DuplicatePRint = grdToken.CurrentRow.Cells["Token_DuplicatePrint"].Value.ToString();
                this.TokenStatus = grdToken.CurrentRow.Cells["Token_CurrentStatus"].Value.ToString();
                //MessageBox.Show(TokenStatus);
                this.btn = true;
                //if (this.TokenStatus == "")
                //{
                //    this.TokenStatus = "False";
                //}
                //this.btn = true;                      
                
            }
             this.tokentime = grdToken.CurrentRow.Cells["Token_Time"].Value.ToString();
            this.TokenID = grdToken.CurrentRow.Cells["TokenId"].Value.ToString();
            this.TokenNo = grdToken.CurrentRow.Cells["TokenNo"].Value.ToString();
            this.NameVisitor = grdToken.CurrentRow.Cells["Visitor_Name"].Value.ToString();
            this.CNIC = grdToken.CurrentRow.Cells["Visitor_CNIC"].Value.ToString();
            this.VisitorContactNo = grdToken.CurrentRow.Cells["VisitorContactNo"].Value.ToString();
            this.FatherName = grdToken.CurrentRow.Cells["Visitor_FatherName"].Value.ToString();
            this.Tokendate = grdToken.CurrentRow.Cells["Token_ShortDate"].Value.ToString();
            this.ServiceName = grdToken.CurrentRow.Cells["ServiceTypeName_Urdu"].Value.ToString();
            this.ServiceType = grdToken.CurrentRow.Cells["ServiceTypeId"].Value.ToString();
            this.PurposeID = grdToken.CurrentRow.Cells["TokenPurposeId"].Value.ToString();
            this.PurposeName = grdToken.CurrentRow.Cells["TokenPurpose_Urdu"].Value.ToString();
            this.Mouzaid = grdToken.CurrentRow.Cells["TokenService_For_MozaId"].Value.ToString();
            this.Mouza = grdToken.CurrentRow.Cells["MozaNameUrdu"].Value.ToString();
            this.TempAdd = grdToken.CurrentRow.Cells["Visitor_TempAddress"].Value.ToString();
            this.PerAdd = grdToken.CurrentRow.Cells["Visitor_PermAddress"].Value.ToString();
            this.DuplicatePRint=grdToken.CurrentRow.Cells["Token_DuplicatePrint"].Value.ToString();
            this.TokenStatus = grdToken.CurrentRow.Cells["Token_CurrentStatus"].Value.ToString();
            //MessageBox.Show(TokenStatus);
            this.btn = true;
            //if (this.TokenStatus == "")
            //{
            //    this.TokenStatus = "False";
            //}
            //this.btn = true;                      
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            this.fillgrid_byfilter("Visitor_Name like '%"+Name+"%'");
            objdatagrid.colorrbackgrid(grdToken);
            objdatagrid.gridControls(grdToken);
            grdToken.Columns["Visitor_CNIC"].Width = 180;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 45 || e.KeyChar > 57  )
                if(e.KeyChar!=45)
                    if(e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void txtToken_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 45 || e.KeyChar > 57)
                if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            string Nic = txtCNIC.Text;
            this.fillgrid_byfilter("Visitor_CNIC like '%"+Nic+"%'");
            objdatagrid.colorrbackgrid(grdToken);
            objdatagrid.gridControls(grdToken);
            grdToken.Columns["Visitor_CNIC"].Width = 180;

        }
        public void TooltipPopulate()
        {
            toolTip.SetToolTip(txtCNIC,"شناختی کارڈ نمبر لکھ کر تلاش کریں");
            toolTip.SetToolTip(txtName,"نام لکھ کر تلاش کریں");
            toolTip.SetToolTip(txtToken,"ٹوکن نمبر لکھ کر تلاش کریں");
        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt=null;
            Proc_Get_SDCToken_Detail_All();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            if (grdToken.DataSource != null)
            {
                objdatagrid.colorrbackgrid(grdToken);
                objdatagrid.gridControls(grdToken);
                grdToken.Columns["Visitor_CNIC"].Width = 180;
            }
        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {
            string token = this.txtToken.Text;
            this.fillgrid_byfilter("TokenNo like '%" + token + "%'");
            objdatagrid.colorrbackgrid(grdToken);
            objdatagrid.gridControls(grdToken);
            grdToken.Columns["Visitor_CNIC"].Width = 180;

        }


    }
}
