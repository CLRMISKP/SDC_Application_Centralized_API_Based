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
    public partial class frmTaxNotificationDetails : Form
    {


        #region Class Variables
        
       
        Taxes tax = new Taxes();


        AutoComplete objauto = new AutoComplete();
        //DL.Database objdb = new DL.Database();
        BL.frmVoucher objbusines = new BL.frmVoucher();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
      
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public bool btn { get; set; }
        public string Intiqal_Id { get; set; }
        public string LandValue { get; set; }

        #endregion
        public frmTaxNotificationDetails()
        {
            InitializeComponent();
        }
        #region Fill Grid Method TehsilID


        public void fillGridTaxByThesilID()
        {
            try
            {
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxNotificationDetails(UsersManagments._Tehsilid.ToString());
          
            gridTextDetails.DataSource = dt;

            gridTextDetails.Columns["TaxNotificationId"].Visible = false;
            gridTextDetails.Columns["TaxNotificationNo"].HeaderText = "نوٹیفکیشن نمبر";
            gridTextDetails.Columns["PaymentType_Urdu"].HeaderText = "رقم کی ادائیگی بزریغہ";
            gridTextDetails.Columns["TehsilId"].Visible = false;
            gridTextDetails.Columns["TaxNotificationActive"].Visible = false;
            gridTextDetails.Columns["TaxNotificationDetailId"].Visible = false;
            gridTextDetails.Columns["TaxRate"].HeaderText = "نرخ";
            gridTextDetails.Columns["TaxeId"].Visible = false;
            gridTextDetails.Columns["paymenttypeid"].Visible = false;
            gridTextDetails.Columns["TaxName_Urdu"].HeaderText = "ٹیکس";
            gridTextDetails.Columns["SDCUnitId"].Visible = false;
            gridTextDetails.Columns["SDCUnitName_Urdu"].HeaderText = "اکائی";
            gridTextDetails.Columns["TaxRateType"].Visible = false;
           
            
            gridTextDetails.Columns["cbgrid"].Width = 70;
            gridTextDetails.Columns["TaxRate"].Width = 60;
            gridTextDetails.Columns["TaxNotificationNo"].Width = 80;
            gridTextDetails.Columns["TaxName_Urdu"].Width = 200;
            gridTextDetails.Columns["SDCUnitName_Urdu"].Width = 80;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


       
        }
        #endregion


        #region form Load event


        private void frmTaxNotificationDetails_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            fillGridTaxByThesilID();
        
            
        }
        #endregion

        #region Grid Selection Change Event
        
        

        private void gridTextDetails_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView g = sender as DataGridView;


            //foreach (DataGridViewRow row in g.Rows)
            //{
            //    if (gridTextDetails.SelectedRows.Count > 0)
            //    {
                    
            //        if (row.Selected)
            //        {

   
            //                row.Cells["cbgrid"].Value = 1;
            //            }
                    
            //        else
            //        {
            //            row.Cells["cbgrid"].Value = 0;
            //        }
                    
            //    }





            //}
        }

        #endregion

        #region Button Save Event
        
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                for(int i=0; i<=gridTextDetails.Rows.Count-1; i++)
                {
                    if (Convert.ToInt32(gridTextDetails.Rows[i].Cells["cbgrid"].Value) == 1)
                    {
                        double TaxableQuantity = 0;
                        double TaxAmount = 0;
                        string intiqalTaxId = "-1";
                        string TaxNotificationId = gridTextDetails.Rows[i].Cells["TaxNotificationId"].Value.ToString();
                        string TaxNotificationDetailsId = gridTextDetails.Rows[i].Cells["TaxNotificationDetailId"].Value.ToString();
                        string SeqNo = "NULL";
                        string TaxId = gridTextDetails.Rows[i].Cells["TaxeId"].Value.ToString();
                        string SDCunitId = gridTextDetails.Rows[i].Cells["SDCUnitId"].Value.ToString();
                        string TaxRate = gridTextDetails.Rows[i].Cells["TaxRate"].Value.ToString();
                        string TaxRateType = gridTextDetails.Rows[i].Cells["TaxRateType"].Value.ToString();
                        if (TaxRateType == "PKR")
                        {
                            TaxableQuantity = 1;
                            TaxAmount = Convert.ToDouble(gridTextDetails.Rows[i].Cells["TaxRate"].Value.ToString()) * TaxableQuantity;

                        }
                        else
                        {
                            if (LandValue != "" && LandValue != null)
                            {
                                TaxableQuantity = Convert.ToDouble(LandValue);
                                TaxAmount = Convert.ToDouble(gridTextDetails.Rows[i].Cells["TaxRate"].Value.ToString()) * TaxableQuantity;

                            }
                            else
                            {
                                TaxableQuantity = 0;
                                TaxAmount = 0;
                            }
                        }
                        string InsertUserId = UsersManagments.UserId.ToString();
                        string InsertLoginName = UsersManagments.UserName.ToString();
                        string UpdateUserId = UsersManagments.UserId.ToString();
                        string UpdateLoginName = UsersManagments.UserName.ToString();
                        if (Intiqal_Id != null)
                        {
                            string lastId = tax.SaveIntiqalTaxDetails(intiqalTaxId, Intiqal_Id, TaxNotificationId, TaxNotificationDetailsId, SeqNo, TaxId, SDCunitId, TaxRate, TaxableQuantity.ToString(), TaxAmount.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        }
                    }
                }
                this.btn = true;
                this.Close();
               
            

        }
        #endregion

        private void gridTextDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                gridTextDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == gridTextDetails.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(gridTextDetails.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        gridTextDetails.CurrentRow.Cells["cbgrid"].Value = 0;
                    }
                    else
                    {
                        gridTextDetails.CurrentRow.Cells["cbgrid"].Value = 1; ;
                    }
                }
            }
        }

        private void gridTextDetails_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }


       
    }
}
