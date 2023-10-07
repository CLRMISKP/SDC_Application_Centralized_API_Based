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
    public partial class frmRegistrySearch : Form
    {
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
       
        public bool btn { get; set; }
  


        public frmRegistrySearch()
        {
            InitializeComponent();
        }

       
        public void Proc_Self_Get_Registry_Status(string mouzaId, string regNo, string Entered, string Received)
        {


            dt = objdb.filldatatable_from_storedProcedure("Proc_Self_Get_Registry_Status " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mouzaId + "," + regNo + "," + Entered + "," + Received);
            DataTable outputTable = dt.Clone();

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(dt.Rows[i]);
            }
            bs.DataSource = dt;
            grdPaymentMaster.DataSource = bs;
            grdPaymentMaster.DataSource = outputTable;


        }

        public void PupoulateGrid()
        {
            grdPaymentMaster.Columns["IntiqalHawalaNo"].DisplayIndex = 0;
            grdPaymentMaster.Columns["IntiqalNo"].DisplayIndex = 1;
            grdPaymentMaster.Columns["MozaNameUrdu"].DisplayIndex = 2;
            grdPaymentMaster.Columns["DegreeDate"].DisplayIndex = 3;
            grdPaymentMaster.Columns["IntiqalAndrajDate"].DisplayIndex = 4;
            grdPaymentMaster.Columns["TokenNo"].DisplayIndex = 5;
            grdPaymentMaster.Columns["LandValue"].DisplayIndex = 6;
            grdPaymentMaster.Columns["Raqba"].DisplayIndex = 7;
            grdPaymentMaster.Columns["Status"].DisplayIndex = 8;
            grdPaymentMaster.Columns["InsertLoginName"].DisplayIndex = 9;
            grdPaymentMaster.Columns["Remarks"].DisplayIndex = 9;

            grdPaymentMaster.Columns["IntiqalHawalaNo"].HeaderText = "رجسٹری نمبر";
            grdPaymentMaster.Columns["IntiqalNo"].HeaderText = "انتقال نمبر"; 
            grdPaymentMaster.Columns["MozaNameUrdu"].HeaderText = "موضع"; 
            grdPaymentMaster.Columns["DegreeDate"].HeaderText = "تاریخ رجسٹری"; 
            grdPaymentMaster.Columns["IntiqalAndrajDate"].HeaderText = "تاریخ انتقال";
            grdPaymentMaster.Columns["TokenNo"].HeaderText = "ٹوکن نمبر"; 
            grdPaymentMaster.Columns["LandValue"].HeaderText = "قیمت"; 
            grdPaymentMaster.Columns["Raqba"].HeaderText = "رقبہ"; 
            grdPaymentMaster.Columns["Status"].HeaderText = "حالت"; 
            grdPaymentMaster.Columns["InsertLoginName"].HeaderText = "آپریٹر"; 
            grdPaymentMaster.Columns["Remarks"].HeaderText = "ریمارکس"; 

            
            objdatagrid.colorrbackgrid(grdPaymentMaster);
            objdatagrid.gridControls(grdPaymentMaster);
           // grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
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

       
        public void TooltipPopulate()
        {
            
            toolTip.SetToolTip(txtRegNo, "رجسٹری نمبر لکھ کر تلاش کریں");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string mouzaId = "-1";
            string regNo = "-1";
            string entered = "-1";
            string received = "-1";
            if(rbEntered.Checked)
            {
                entered = "1";
            }
            else
            {
                received = "1";
            }
            if(cmbMouza.SelectedIndex>0)
            {
                mouzaId = cmbMouza.SelectedValue.ToString();
            }
            if (txtRegNo.Text.Trim().Length>0)
            {
                regNo = txtRegNo.Text;
            }
            if(mouzaId=="-1" && regNo=="-1")
            {
                MessageBox.Show("موضع یا رجسٹری نمبر کا اندراج کریں", "تلاش رجسٹری", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
            Proc_Self_Get_Registry_Status(mouzaId,regNo,entered,received);
            PupoulateGrid();
            }
        }

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

        private void frmRegistrySearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            txtRegNo.Focus();
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }

      


    }
}
