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

namespace SDC_Application.AL
{
    public partial class frmRoznamcha : Form
    {
        public string IntiqalId { get; set; }
        Intiqal Intiq = new Intiqal();
        LanguageConverter lang = new LanguageConverter();
        public string  IntiqalNo 
        { get; set; 
        }
        public bool Attested { get; set; }
        public string tokenId { get; set; }
        public string RoznamchaId { get; set; }
        public string RoznamchaNo { get; set; }
        public string dtRoznamcha { get; set; }
        public string MozaId { get; set; }

        // public string IntiqalId { get; set; }
        public frmRoznamcha()
        {
            InitializeComponent();
           


        }

        private void frmIntiqalRevenueReports_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            RoznamchaId = "-1";
            RoznamchaNo = "-1";
            GetRecordIfAvailable();
            this.lblIntiqalNo.Text = this.IntiqalNo;
            
            if(this.Attested)
            {
                //btnSave.Enabled = false;
            }
        }

       
        public void GetRecordIfAvailable()
        {
            DataTable dt = new DataTable();
             dt = Intiq.GetRoznamchaDetails(IntiqalId);

             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow data in dt.Rows)
                 {

                     txtRoznamcha.Text = data["Roznamcha"].ToString();
                    
                     RoznamchaId = data["RoznamchaId"].ToString();
                     RoznamchaNo = data["RoznamchaNo"].ToString(); 
                     //RoznamchaNo = (dt.Rows[0]["GardawarReport_Date"] != null && dt.Rows[0]["GardawarReport_Date"].ToString() != "") ? Convert.ToDateTime(dt.Rows[0]["GardawarReport_Date"].ToString()) : DateTime.Now;
                     //dtpPatwarReport.Value = (dt.Rows[0]["PatwariReport_Date"] != null && dt.Rows[0]["PatwariReport_Date"].ToString() != "") ? Convert.ToDateTime(dt.Rows[0]["PatwariReport_Date"].ToString()) : DateTime.Now;
                     //dtpTehsilReport.Value = (dt.Rows[0]["TehsildarReport_Date"] != null && dt.Rows[0]["TehsildarReport_Date"].ToString() != "") ? Convert.ToDateTime(dt.Rows[0]["TehsildarReport_Date"].ToString()) : DateTime.Now;
                     //dtpgirdawrReport.Checked = dt.Rows[0]["GardawarReport_Date"] != null ? true : false;
                     //dtpPatwarReport.Checked = dt.Rows[0]["PatwariReport_Date"] != null ? true : false;
                     //dtpTehsilReport.Checked = dt.Rows[0]["PatwariReport_Date"] != null ? true : false;

                 }
             }
             else
             {
                 //dtpgirdawrReport.Checked = false;
                 //dtpPatwarReport.Checked = false;
                 //dtpTehsilReport.Checked = false;
             }
        
        }

        #region ToolTip

        public void ToopTip()
        {
            //toolTip1.SetToolTip(btnSaveRoznamcha1,"رپورٹس مخفوظ کریں");
        
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
                DataTable dt = new DataTable();
                dt = Intiq.Proc_Get_Intiqal_Roznamcha_Report(IntiqalId);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow d in dt.Rows)
                    {
                        txtRoznamcha.Text = d["RoznamchaReport"].ToString();
                    }
                }

               
            }
            catch (Exception ex)
            { 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // if all taxes not received then tehsildar report will not save
            if (txtRoznamcha.Text.Trim().Length > 0 )
            {

               
              

                string TehsilReport = txtRoznamcha.Text;
               
                Intiq.SaveIntiqalRoznamcha(RoznamchaId, MozaId, IntiqalId, txtRoznamcha.Text.Trim(), dtRoznamcha, RoznamchaNo, Classess.UsersManagments.UserId.ToString(), Classess.UsersManagments.UserName.ToString());
                MessageBox.Show("محفوظ ہوگیا");
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            frmSDCReportingMain TokenReport = new frmSDCReportingMain();
            //TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
            //TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
            TokenReport.IntiqalId = this.IntiqalId;
            TokenReport.userId = Classess.UsersManagments.UserId.ToString();

            Classess.UsersManagments.check = 20;
           
            TokenReport.ShowDialog();     
        }

       

       

      
    }
}
