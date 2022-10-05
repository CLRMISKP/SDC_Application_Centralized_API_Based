using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmFardOperatorReport : Form
    {
        public string IntiqalId { get; set; }
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        LanguageConverter lang = new LanguageConverter();
        public string  FPG_ID 
        { get; set; 
        }

        // public string IntiqalId { get; set; }
        public frmFardOperatorReport()
        {
            InitializeComponent();
           


        }

        private void frmIntiqalRevenueReports_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            GetRecordIfAvailable();
        }
       
        public void GetRecordIfAvailable()
        {
            DataTable dt = new DataTable();
            dt = mnk.GetFardOperatorReport(this.FPG_ID);
            if (dt != null)
            {
                txtTehsilReport.Text = dt.Rows[0]["OperatorReport"].ToString();
             }
            
        
        }

        #region ToolTip

        public void ToopTip()
        {
            toolTip1.SetToolTip(btnSave,"رپورٹس مخفوظ کریں");
        
        }
        #endregion

        private void txtTehsilReport_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btntehsildarreport_Click(object sender, EventArgs e)
        {
            try
            {

                txtTehsilReport.Text = "بائع قبل از دو سال مالک ہے۔ عدالتی کاروئی سے پاک ہے۔ کمیٹی حدود سے باہر ہے۔";
                 
            }
            catch (Exception ex)
            { 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
	            {	        
		              mnk.InsertFardOperatorReport(this.FPG_ID, this.txtTehsilReport.Text.Trim(),UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    MessageBox.Show("رپورٹ محفوظ ہو گیا ہے۔");
                    this.Close();
	            }
	            catch (Exception ex)
	            {
		
		            MessageBox.Show(ex.Message);
	            }
          
        }

       

      
    }
}
