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
    public partial class frmGardawarVerfiication : Form
    {
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        Intiqal intiqal = new Intiqal();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
 
        public string MozaId { get; set; }

        public string intiqalId { get; set; }



        public frmGardawarVerfiication()
        {
            InitializeComponent();
        }

     

        public void Proc_Self_Get_SDC_Intiqal_For_Gardawar_Verification(string intiqalId)
        {
            
            dt = objdb.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_Intiqal_For_Gardawar_Verification "+SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+"," + intiqalId);
            DataTable outputTable = dt.Clone();

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(dt.Rows[i]);
            }
            bs.DataSource = dt;
            grdIntiqalList.DataSource = bs;
            grdIntiqalList.DataSource = outputTable;

        }

        #region Fill Intiqal DropDown

        public void Fill_Intiqal_DropDown()
        {
            try
            {
                this.MozaId = cmbMouza.SelectedValue.ToString();
                DataTable dtIntiqalNo = new DataTable();
                dtIntiqalNo = intiqal.GetintiqalByMozaIdSelf(cmbMouza.SelectedValue.ToString());
                DataRow IntiqalNo = dtIntiqalNo.NewRow();
                IntiqalNo["IntiqalId"] = "0";
                IntiqalNo["IntiqalNo"] = " - انتقال نمبر کا انتخاب کرِیں - ";
                dtIntiqalNo.Rows.InsertAt(IntiqalNo, 0);
                cmbIntiqalNo.DataSource = dtIntiqalNo;
                cmbIntiqalNo.DisplayMember = "IntiqalNo";
                cmbIntiqalNo.ValueMember = "IntiqalId";
                cmbIntiqalNo.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public void PupoulateGrid()
        {
            
            grdIntiqalList.Columns["IntiqalNo"].DisplayIndex = 0;
            grdIntiqalList.Columns["IntiqalType"].DisplayIndex = 1;
            grdIntiqalList.Columns["IntiqalInitiationType"].DisplayIndex = 2;
            grdIntiqalList.Columns["MozaNameUrdu"].DisplayIndex = 3;
            
            grdIntiqalList.Columns["IntiqalAndrajDate"].DisplayIndex = 4;
            grdIntiqalList.Columns["TokenNo"].DisplayIndex = 5;
            grdIntiqalList.Columns["LandValue"].DisplayIndex = 6;
            grdIntiqalList.Columns["Raqba"].DisplayIndex = 7;
            grdIntiqalList.Columns["Status"].DisplayIndex = 8;
            grdIntiqalList.Columns["Token_CurrentStatus"].DisplayIndex = 9;
            grdIntiqalList.Columns["InsertLoginName"].DisplayIndex = 10;
            grdIntiqalList.Columns["Remarks"].DisplayIndex = 11;
           

        
            grdIntiqalList.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
            grdIntiqalList.Columns["IntiqalType"].HeaderText = "قسم انتقال";
            grdIntiqalList.Columns["IntiqalInitiationType"].HeaderText = "انتقال بذریعہ";
            grdIntiqalList.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdIntiqalList.Columns["IntiqalAndrajDate"].HeaderText = "تاریخ انتقال";
            grdIntiqalList.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
            grdIntiqalList.Columns["LandValue"].HeaderText = "قیمت";
            grdIntiqalList.Columns["Raqba"].HeaderText = "رقبہ";
            grdIntiqalList.Columns["Status"].HeaderText = " حالت انتقال";
            grdIntiqalList.Columns["Token_CurrentStatus"].HeaderText = " حالت ٹوکن";
            grdIntiqalList.Columns["InsertLoginName"].HeaderText = "آپریٹر";
            grdIntiqalList.Columns["Remarks"].HeaderText = "ریمارکس";


            grdIntiqalList.Columns["GardawarId"].Visible = false;
            grdIntiqalList.Columns["IntiqalId"].Visible = false;
            grdIntiqalList.Columns["TokenId"].Visible = false;

           // objdatagrid.colorrbackgrid(grdIntiqalList);
            objdatagrid.gridControls(grdIntiqalList);
            //grdPaymentMaster.Columns["Visitor_CNIC"].Width = 180;
            grdIntiqalList.ColumnHeadersHeight = 30;
            int colCount = grdIntiqalList.RowCount;

        }
      

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MozaId = "-1";
            intiqalId = "-1";
           
            if (cmbMouza.SelectedIndex > 0)
            {
                MozaId = cmbMouza.SelectedValue.ToString();
            }
            if (cmbIntiqalNo.SelectedIndex > 0)
            {
                intiqalId = cmbIntiqalNo.SelectedValue.ToString();
            }
            if (MozaId == "-1" || intiqalId == "-1" || cboROs.SelectedIndex==0)
            {
                MessageBox.Show("موضع اور انتقال نمبر  اور گرداور چنیئے", "گرداوار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Proc_Self_Get_SDC_Intiqal_For_Gardawar_Verification(intiqalId);
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

        private void frmGardawarVerfiication_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            dt = objdb.filldatatable_from_storedProcedure("Proc_Get_Girdawars " + Classess.UsersManagments._Tehsilid.ToString());
            DataRow row = dt.NewRow();
            row["UserId"] = "0";
            row["CompleteName"] = "--انتخاب کریں--";
            dt.Rows.InsertAt(row, 0);
            cboROs.DataSource = dt;
            cboROs.DisplayMember = "CompleteName";
            cboROs.ValueMember = "UserId";
            cboROs.SelectedValue = 0;
        }

        void IntiqalAtt_FormClosed(object sender, FormClosedEventArgs e)
        {
            // reload Intiqal Data
           btnSearch_Click(sender, e);
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Intiqal_DropDown();
        }

        private void cmbIntiqalNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.intiqalId = cmbIntiqalNo.SelectedValue.ToString();
        }

        private void grdIntiqalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (grdIntiqalList.Rows[e.RowIndex].Cells["GardawarId"].Value.ToString() == "0")
                {
                    frmIntiqalAttestationByGardawar IntiqalAtt = new frmIntiqalAttestationByGardawar();
                    IntiqalAtt.intiqalId = grdIntiqalList.Rows[e.RowIndex].Cells["IntiqalId"].Value.ToString();
                    IntiqalAtt.tokenId = grdIntiqalList.Rows[e.RowIndex].Cells["TokenId"].Value.ToString();
                    IntiqalAtt.gardawarId = cboROs.SelectedValue.ToString();
                    IntiqalAtt.FormClosed -= new FormClosedEventHandler(IntiqalAtt_FormClosed);
                    IntiqalAtt.FormClosed += new FormClosedEventHandler(IntiqalAtt_FormClosed);
                    IntiqalAtt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("اس انتقال کی پڑتال ہو چکی ہے", "گرداور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }

        }

      

    }
}
