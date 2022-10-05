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
    public partial class frmIntiqalRevenueReports : Form
    {
        public string IntiqalId { get; set; }
        Intiqal Intiq = new Intiqal();
        LanguageConverter lang = new LanguageConverter();
        public string  IntiqalNo 
        { get; set; 
        }

        // public string IntiqalId { get; set; }
        public frmIntiqalRevenueReports()
        {
            InitializeComponent();
           


        }

        private void frmIntiqalRevenueReports_Load(object sender, EventArgs e)
        {

            GetRecordIfAvailable();
            this.lblIntiqalNo.Text = this.IntiqalNo;
        }

        private void btnDetailIntiqalInderaj_Click(object sender, EventArgs e)
        {

            string GRDate;
            string PRDate;
            string TRDate;
            if (dtpgirdawrReport.Checked)
            {
                DateTime date = dtpgirdawrReport.Value;
                string month = date.Month.ToString();
                string day = date.Day.ToString();
                string year = date.Year.ToString();
                GRDate = month + "/" + day + "/" + year;
                  
            }
            else
            {
                 GRDate = null;
            }
            if (dtpPatwarReport.Checked)
            {
                DateTime date = dtpPatwarReport.Value;
                string month = date.Month.ToString();
                string day = date.Day.ToString();
                string year = date.Year.ToString();
                PRDate = month + "/" + day + "/" + year;
                 
            }
            else
            {
                PRDate =null;
            }
            if (dtpTehsilReport.Checked)
            {
                DateTime date = dtpTehsilReport.Value;
                string month = date.Month.ToString();
                string day = date.Day.ToString();
                string year = date.Year.ToString();
                TRDate = month + "/" + day + "/" + year;               

            }
            else
            {
                TRDate = null;
            }
           
            string GirdawrReport = txtGirdawrReport.Text;
            string PatwarReport = txtPatwariReport.Text;
            string TehsilReport = txtTehsilReport.Text;

            Intiq.SaveIntiqalMainReports(IntiqalId, PatwarReport, PRDate, GirdawrReport, GRDate, TehsilReport, TRDate, Classess.UsersManagments.UserId.ToString());
            MessageBox.Show("محفوظ ہوگیا");
        }
        public void GetRecordIfAvailable()
        {
            DataTable dt = new DataTable();
            dt = Intiq.GetIntiqalMainReports(IntiqalId);
            if (dt != null)
            {
                txtGirdawrReport.Text = dt.Rows[0]["GardawarReport"].ToString();
                txtPatwariReport.Text = dt.Rows[0]["PatwariReport"].ToString();
                txtTehsilReport.Text = dt.Rows[0]["TehsildarReport"].ToString();
                dtpgirdawrReport.Value =(dt.Rows[0]["GardawarReport_Date"]!=null && dt.Rows[0]["GardawarReport_Date"].ToString()!="")? Convert.ToDateTime(dt.Rows[0]["GardawarReport_Date"].ToString()):DateTime.Now;
                dtpPatwarReport.Value = (dt.Rows[0]["PatwariReport_Date"] != null&& dt.Rows[0]["PatwariReport_Date"].ToString()!="") ? Convert.ToDateTime(dt.Rows[0]["PatwariReport_Date"].ToString()) : DateTime.Now;
                dtpTehsilReport.Value = (dt.Rows[0]["TehsildarReport_Date"] != null && dt.Rows[0]["TehsildarReport_Date"].ToString()!="") ? Convert.ToDateTime(dt.Rows[0]["TehsildarReport_Date"].ToString()) : DateTime.Now;
                dtpgirdawrReport.Checked =dt.Rows[0]["GardawarReport_Date"]!=null? true:false;
                dtpPatwarReport.Checked = dt.Rows[0]["PatwariReport_Date"]!=null?true:false;
                dtpTehsilReport.Checked =dt.Rows[0]["PatwariReport_Date"]!=null? true:false;

            }
            else
            {
                dtpgirdawrReport.Checked = false;
                dtpPatwarReport.Checked = false;
                dtpTehsilReport.Checked = false;
            }
        
        }

        #region ToolTip

        public void ToopTip()
        {
            toolTip1.SetToolTip(btnDetailIntiqalInderaj,"رپورٹس مخفوظ کریں");
        
        }
        #endregion

        private void txtPatwariReport_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGirdawrReport_KeyPress(object sender, KeyPressEventArgs e)
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
                dt = Intiq.Proc_Get_Intiqal_TehsilDar_Report(IntiqalId);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow d in dt.Rows)
                    {
                        txtTehsilReport.Text = d["TehsildarReport"].ToString();
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

       

      
    }
}
