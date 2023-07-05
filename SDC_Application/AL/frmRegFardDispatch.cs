using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using SDC_Application.BL;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using SDC_Application.Classess;
using System.Windows.Forms;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmRegFardDispatch : Form

    {
        BL.Users objuser = new BL.Users();
        BL.Malikan_n_Khattajat obj = new BL.Malikan_n_Khattajat();
        public string Roleid { get; set; }
        ArrayList array = new ArrayList();
        AutoComplete objauto = new AutoComplete();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        DataTable dt = new DataTable();
        BL.frmToken objbusines = new BL.frmToken();
        datagrid_controls objdatagrid = new datagrid_controls();
        LanguageConverter lang = new LanguageConverter();
        Intiqal Intiqal = new Intiqal();
        public string DispatchId { get; set; }
        public frmRegFardDispatch()
        {
            InitializeComponent();
        }

       
  

        private void grdRoleonObject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdFardToInsert.CurrentRow.Cells["chkselectlist"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdFardToInsert.CurrentRow.Cells["chkselectlist"].Value) == 1)
                    {
                        this.grdFardToInsert.CurrentRow.Cells["chkselectlist"].Value = 0;
                    }
                    else
                    {
                        this.grdFardToInsert.CurrentRow.Cells["chkselectlist"].Value = 1;
                    }
                }
            }
        }

        private void grdObjectNames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdInsertedFardat.CurrentRow.Cells["chkselect"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdInsertedFardat.CurrentRow.Cells["chkselect"].Value) == 1)
                    {
                        this.grdInsertedFardat.CurrentRow.Cells["chkselect"].Value = 0;
                    }
                    else
                    {
                        this.grdInsertedFardat.CurrentRow.Cells["chkselect"].Value = 1;
                    }
                }
            }
        }

     

        private void chkAllDetails_Click(object sender, EventArgs e)
        {
            if (this.grdInsertedFardat.Rows.Count > 0)
            {
                if (this.chkAllDetails.Checked)
                {
                    foreach (DataGridViewRow row in grdInsertedFardat.Rows)
                    {

                        row.Cells["colCheckInserted"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdInsertedFardat.Rows)
                    {

                        row.Cells["colCheckInserted"].Value = 0;

                    }
                }
            }
            //chkAllObject.Checked = false;
        }


        private void btnNewLetter_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ رجسٹرار آفس کے لئے نیا ڈاک بنا رہے ہیں؟", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                dtDispatchDate.Enabled = true;
                dtDispatchDate.Value = DateTime.Today;
                cbLetterNo.SelectedIndex = 0;
                btnSave.Enabled = true;
                btnInsert.Enabled = false;
                btnRemove.Enabled = false;
                btnPrint.Enabled = false;
                btnConfirm.Enabled = false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ لیٹر محفوظ کرنا چاہتے ہے؟", "محفوظ کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                string dtDispatch = dtDispatchDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                string lastId = mnk.SaveFardDispatchToRegistrar("F", dtDispatch, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                dtDispatchDate.Enabled = false;
                objauto.FillCombo("Proc_Self_Get_Letter_List" + "'F'", cbLetterNo, "number", "RegFardDispatchMainId");
                cbLetterNo.SelectedValue = lastId;
                btnSave.Enabled = false;
                btnDel.Enabled = true;
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt.Clear();
            Proc_Get_SDC_TokenList_For_PaymentVoucher();
        }


        public void Proc_Get_SDC_TokenList_For_PaymentVoucher()
        {
            try
            {
                
                    dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_Only_Fard '" + dateTime.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + "1" + "'");
               
                DataTable outputTable = dt.Clone();

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    outputTable.ImportRow(dt.Rows[i]);
                }
                grdFardToInsert.DataSource = outputTable;
               

                Populategrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public void Populategrid()
        {
            grdFardToInsert.Columns["Token_ShortDate"].DisplayIndex = 1;
            grdFardToInsert.Columns["TokenNo"].DisplayIndex = 2;
            grdFardToInsert.Columns["Visitor_Name"].DisplayIndex = 3;
            grdFardToInsert.Columns["Visitor_FatherName"].DisplayIndex = 4;
            grdFardToInsert.Columns["ServiceTypeName_Urdu"].DisplayIndex = 5;
            grdFardToInsert.Columns["MozaNameUrdu"].DisplayIndex = 6;



            grdFardToInsert.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
            grdFardToInsert.Columns["Token_ShortDate"].HeaderText = "تاریخ ٹوکن";
            grdFardToInsert.Columns["Visitor_Name"].HeaderText = "نام";
            grdFardToInsert.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر";
            grdFardToInsert.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdFardToInsert.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdFardToInsert.Columns["TokenService_For_MozaId"].Visible = false;
            grdFardToInsert.Columns["TokenDate"].Visible = false;
            grdFardToInsert.Columns["ServiceTypeId"].Visible = false;
            grdFardToInsert.Columns["TokenId"].Visible = false;
            grdFardToInsert.Columns["Visitor_CNIC"].Visible = false;
            grdFardToInsert.Columns["Token_Verified"].Visible = false;

                grdFardToInsert.Columns["TokenPurposeId"].Visible = false;
           
        }



        public void Load_TokenList_Saved_For_Registrar_Dispatch()
        {
            try
            {

                dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_Registrar_Dispatch " + DispatchId );

                DataTable outputTable = dt.Clone();

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    outputTable.ImportRow(dt.Rows[i]);
                }
                grdInsertedFardat.DataSource = outputTable;
                PopulategridSavedTokens();
                LbFardatNos.Text = grdInsertedFardat.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public void PopulategridSavedTokens()
        {
            grdInsertedFardat.Columns["Token_ShortDate"].DisplayIndex = 1;
            grdInsertedFardat.Columns["TokenNo"].DisplayIndex = 2;
            grdInsertedFardat.Columns["Visitor_Name"].DisplayIndex = 3;
            grdInsertedFardat.Columns["Visitor_FatherName"].DisplayIndex = 4;
            grdInsertedFardat.Columns["ServiceTypeName_Urdu"].DisplayIndex = 5;
            grdInsertedFardat.Columns["MozaNameUrdu"].DisplayIndex = 6;



            grdInsertedFardat.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
            grdInsertedFardat.Columns["Token_ShortDate"].HeaderText = "تاریخ ٹوکن";
            grdInsertedFardat.Columns["Visitor_Name"].HeaderText = "نام";
            grdInsertedFardat.Columns["Visitor_FatherName"].HeaderText = "والد/شوہر";
            grdInsertedFardat.Columns["MozaNameUrdu"].HeaderText = "موضع";
            grdInsertedFardat.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت";
            grdInsertedFardat.Columns["TokenService_For_MozaId"].Visible = false;
            grdInsertedFardat.Columns["TokenDate"].Visible = false;
            grdInsertedFardat.Columns["ServiceTypeId"].Visible = false;
            grdInsertedFardat.Columns["TokenId"].Visible = false;
            grdInsertedFardat.Columns["Visitor_CNIC"].Visible = false;
            grdInsertedFardat.Columns["Token_Verified"].Visible = false;

            grdInsertedFardat.Columns["TokenPurposeId"].Visible = false;



        }
       
      


        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
           
        }

       
        private void txtToken_TextChanged(object sender, EventArgs e)
        {
           
            if (this.grdFardToInsert.Rows.Count > 0)
            {

                for (int i = 0; i <= grdFardToInsert.Rows.Count - 1; i++)
                {

                    if (grdFardToInsert.Rows[i].Cells["TokenNo"].Value.ToString().Contains(txtToken.Text.Trim()))
                    {

                        grdFardToInsert.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdFardToInsert.DataSource];
                        currencyManager1.SuspendBinding();
                        grdFardToInsert.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        grdFardToInsert.Rows[i].Visible = false;


                    }
                }


            }
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
            if (this.grdFardToInsert.Rows.Count > 0)
            {

                for (int i = 0; i <= grdFardToInsert.Rows.Count - 1; i++)
                {

                    if (grdFardToInsert.Rows[i].Cells["Visitor_Name"].Value.ToString().Contains(txtName.Text.Trim()))
                    {

                        grdFardToInsert.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdFardToInsert.DataSource];
                        currencyManager1.SuspendBinding();
                        grdFardToInsert.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        grdFardToInsert.Rows[i].Visible = false;


                    }
                }


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

        private void grdFardToInsert_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdFardToInsert.CurrentRow.Cells["colCheck"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdFardToInsert.CurrentRow.Cells["colCheck"].Value) == 1)
                    {
                        this.grdFardToInsert.CurrentRow.Cells["colCheck"].Value = 0;
                    }
                    else
                    {
                        this.grdFardToInsert.CurrentRow.Cells["colCheck"].Value = 1;
                    }
                }
            }
        }


        private void cbLetterNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbLetterNo.SelectedIndex > 0)
            {
                DispatchId = cbLetterNo.SelectedValue.ToString();
                Load_TokenList_Saved_For_Registrar_Dispatch();
               


                dt = obj.GetRegistrarFardatStatus(DispatchId);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        dtDispatchDate.Value = Convert.ToDateTime(row["DispatchDate"]);
                        if (row["status"].ToString() == "0")
                        {
                            btnPrint.Enabled = false;
                            btnConfirm.Enabled = true;
                            btnInsert.Enabled = true;
                            btnRemove.Enabled = true;
                        }
                        else
                        {
                            btnPrint.Enabled = true;
                            btnConfirm.Enabled = false;
                            btnInsert.Enabled = false;
                            btnRemove.Enabled = false;
                        }
                    }
                }

            }
            else
            {
                DispatchId = cbLetterNo.SelectedValue.ToString();
                Load_TokenList_Saved_For_Registrar_Dispatch();
                btnInsert.Enabled = false;
                btnRemove.Enabled = false;
                btnPrint.Enabled = false;
                btnConfirm.Enabled = false;

            }
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
           

            for (int i = 0; i <= this.grdFardToInsert.Rows.Count - 1; i++)
            {
                int b = Convert.ToInt32(grdFardToInsert.Rows[i].Cells["colCheck"].Value);
                if (b == 1)
                {

                    bool isExists = false;

                    string TokenId = grdFardToInsert.Rows[i].Cells["TokenId"].Value.ToString();

                    string retVal = Intiqal.GetRegFardDispatchStatus(TokenId, DispatchId);
                    if (retVal != "1")
                    {
                        MessageBox.Show(retVal, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                    }

                    else
                    {

                    try
                    {
                        if (this.grdInsertedFardat.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in grdInsertedFardat.Rows)
                            {
                                
                                if (row.Cells["TokenId"].Value.ToString() == grdFardToInsert.Rows[i].Cells["TokenId"].Value.ToString())
                                {
                                    isExists = true;
                                    break;
                                }
                                else
                                {
                                    isExists = false;
                                }
                            }

                        }

                        if (!isExists)
                        {
                           
                            string s = obj.SaveRegFardatDispatchDetails(TokenId,DispatchId,UsersManagments.UserId.ToString(), UsersManagments.UserName);
                           
                            
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                }
                
            }

            for (int k = 0; k <= grdFardToInsert.Rows.Count - 1; k++)
            {
                grdFardToInsert.Rows[k].Cells["colCheck"].Value = 0;
            }
            
            this.chkAllToSave.Checked = false;
            Load_TokenList_Saved_For_Registrar_Dispatch();
        }

        private void chkAllToSave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.grdFardToInsert.Rows.Count > 0)
            {

                for (int i = 0; i <= grdFardToInsert.Rows.Count - 1; i++)
                {

                    if (chkAllToSave.Checked)
                    {

                        grdFardToInsert.Rows[i].Cells["colCheck"].Value = true;

                    }
                    else
                    {

                        grdFardToInsert.Rows[i].Cells["colCheck"].Value = false;
                    }
                }


            }
        }

        private void chkAllToSave_Click(object sender, EventArgs e)
        {
            if (this.grdFardToInsert.Rows.Count > 0)
            {
                if (this.chkAllToSave.Checked)
                {
                    foreach (DataGridViewRow row in grdFardToInsert.Rows)
                    {

                        row.Cells["colCheck"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdFardToInsert.Rows)
                    {

                        row.Cells["colCheck"].Value = 0;

                    }
                }
            }
            //chkAllObject.Checked = false;
        }

        private void frmRegFardDispatch_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Self_Get_Letter_List" +"'F'", cbLetterNo, "number", "RegFardDispatchMainId");
        }

        private void chkAllDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (this.grdInsertedFardat.Rows.Count > 0)
            {

                for (int i = 0; i <= grdInsertedFardat.Rows.Count - 1; i++)
                {

                    if (chkAllDetails.Checked)
                    {

                        grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value = true;

                    }
                    else
                    {

                        grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value = false;
                    }
                }


            }
        }

        private void grdInsertedFardat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value) == 1)
                    {
                        this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value = 0;
                    }
                    else
                    {
                        this.grdInsertedFardat.CurrentRow.Cells["colCheckInserted"].Value = 1;
                    }
                }
            }
        }

        private void txtTokenInserted_TextChanged(object sender, EventArgs e)
        {
            if (this.grdInsertedFardat.Rows.Count > 0)
            {

                for (int i = 0; i <= grdInsertedFardat.Rows.Count - 1; i++)
                {

                    if (grdInsertedFardat.Rows[i].Cells["TokenNo"].Value.ToString().Contains(txtTokenInserted.Text.Trim()))
                    {

                        grdInsertedFardat.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdInsertedFardat.DataSource];
                        currencyManager1.SuspendBinding();
                        grdInsertedFardat.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        grdInsertedFardat.Rows[i].Visible = false;


                    }
                }


            }
            
        }

        private void txtNameInserted_TextChanged(object sender, EventArgs e)
        {
            if (this.grdInsertedFardat.Rows.Count > 0)
            {

                for (int i = 0; i <= grdInsertedFardat.Rows.Count - 1; i++)
                {

                    if (grdInsertedFardat.Rows[i].Cells["Visitor_Name"].Value.ToString().Contains(txtNameInserted.Text.Trim()))
                    {

                        grdInsertedFardat.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdInsertedFardat.DataSource];
                        currencyManager1.SuspendBinding();
                        grdInsertedFardat.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        grdInsertedFardat.Rows[i].Visible = false;


                    }
                }


            }
        }

        private void txtNameInserted_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {


            DataGridView g = sender as DataGridView;


            if (this.grdInsertedFardat.Rows.Count > 0)
            {
                for (int i = 0; i < grdInsertedFardat.Rows.Count; i++)
                {
                    int rowvalue = Convert.ToInt32(grdInsertedFardat.Rows[i].Cells["colCheckInserted"].Value);

                    if (rowvalue == 1)
                    {
                        string TokenId = grdInsertedFardat.Rows[i].Cells["TokenId"].Value.ToString();

                        obj.DeleteSavedFardat(TokenId);
                       
                    }
                }
                
            }
           

            this.chkAllDetails.Checked = false;
            Load_TokenList_Saved_For_Registrar_Dispatch();


        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            frmSDCReportingMain TokenReport = new frmSDCReportingMain();
            TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
            TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
            TokenReport.RegFardDispatchMainId = this.DispatchId;
            TokenReport.userId = UsersManagments.UserId.ToString();
           
                UsersManagments.check = 23;
           
            TokenReport.ShowDialog();     
        }


        private void TokenReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSDCReportingMain Populate = sender as frmSDCReportingMain;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ فائنل کرنے کے بعد اس میں تبدیلی نہیں کر سکتے۔ اگر یہ دستاویز فائنل ہے تو یس کلک کریں۔؟", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    bool isConfirmed = mnk.ConfirmRegistryFardat(this.DispatchId.ToString());
                    btnPrint.Enabled = true;
                    this.btnConfirm.Enabled = false; ;
                    btnInsert.Enabled = false;
                    btnRemove.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      
    }
}
