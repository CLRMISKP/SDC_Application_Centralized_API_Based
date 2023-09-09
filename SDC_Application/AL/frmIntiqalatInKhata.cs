using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.IO;
using System.Diagnostics;
using SDC_Application.LanguageManager;
using iTextSharp.text;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmIntiqalatInKhata : Form
    {

        #region Class Variables and Properties

        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        BL.frmToken objbusines = new BL.frmToken();
       
        public string MozaId { get; set; }

        Misal misal = new Misal();
        public string SellerId = "";

        public string BuyerId = "";

        
        DataTable IntiqalList = new System.Data.DataTable();
        DataTable dtkj = new DataTable();

        #endregion

        public frmIntiqalatInKhata()
        {
            InitializeComponent();
        }

        private void frmNaqalIntiqal_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }



        #region List Searched Intiqals

        private void btnListIntiqals_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

    
      
        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MozaId = cmbMouza.SelectedValue.ToString();

            this.Fill_Khata_DropDown();
            GridIntiqalList.DataSource = null;
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

        private void cmbMouza_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void Fill_Khata_DropDown()
        {
            try
            {

                dtkj = misal.GetAllKhatajatByMoza(Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbokhataNo.DataSource = dtkj;
                cbokhataNo.DisplayMember = "KhataNo";
                cbokhataNo.ValueMember = "RegisterHqDKhataId";
                cbokhataNo.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GridIntiqalList.Columns.Clear();
            if (this.MozaId != "")
            {


                IntiqalList = this.objbusines.filldatatable_from_storedProcedure("proc_Self_Get_Intiqal_List_of_Khata "+UsersManagments._Tehsilid.ToString()+"," + cbokhataNo.SelectedValue.ToString());

                if (IntiqalList != null)
                {
                    this.GridIntiqalList.DataSource = IntiqalList;

                    if (IntiqalList != null)
                    {

                        GridIntiqalList.Columns["IntiqalId"].Visible = false;
                        GridIntiqalList.Columns["IntiqalTypeId"].Visible = false;
                        GridIntiqalList.Columns["KKM"].Visible = false;

                        GridIntiqalList.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                        GridIntiqalList.Columns["IntiqalAndrajDate"].HeaderText = "تاریخ اندراج انتقال";
                        GridIntiqalList.Columns["IntiqalAmaldramadDate"].HeaderText = "تاریخ انتقال عملدرامد";
                        GridIntiqalList.Columns["AmalDaramadStatus"].HeaderText = "کیفیت";
                        GridIntiqalList.Columns["IntiqalPendingRemakrs"].HeaderText = "ریمارکس";
                        GridIntiqalList.Columns["IntiqalPendingRemakrs"].HeaderText = "ریمارکس";
                     

                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        GridIntiqalList.Columns.Add(btn);
                        btn.HeaderText = "پرنٹ";
                        btn.Text = "پرنٹ دیکھئے";
                        btn.Name = "btnPrint";
                        btn.UseColumnTextForButtonValue = true;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.DefaultCellStyle.BackColor = Color.Green;
                        btn.DefaultCellStyle.ForeColor = Color.White;

                       

                    }


                }
            }
          
        }

        private void GridIntiqalList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 9)
            if (e.ColumnIndex == GridIntiqalList.CurrentRow.Cells["btnPrint"].ColumnIndex)
            {
                
                frmSDCReportingMain TokenReport = new frmSDCReportingMain();

                TokenReport.IntiqalId = GridIntiqalList.CurrentRow.Cells["IntiqalId"].Value.ToString();
                string intiqalTypeId = GridIntiqalList.CurrentRow.Cells["IntiqalTypeId"].Value.ToString();
                string KKM = GridIntiqalList.CurrentRow.Cells["KKM"].Value.ToString();
                TokenReport.userId = UsersManagments.UserId.ToString();
                
                if (intiqalTypeId == "37")
                    UsersManagments.check = 18;
                else if (intiqalTypeId == "15")
                    UsersManagments.check = 19;
                else if (KKM=="KK")
                    UsersManagments.check = 16;
                else if (KKM == "MK")
                    UsersManagments.check = 17;
                else if (KKM == "KTM")
                    UsersManagments.check = 25;
                else if (KKM == "M")
                    UsersManagments.check = 4;

                TokenReport.ShowDialog();     
            }
        }

    }
}
