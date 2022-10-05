using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmSDCMultipleReports : Form
    {
        string username = "Administrator";
        string password = "sdc$$mrd$$";
        string ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
        string ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
        string TehsilId = UsersManagments._Tehsilid.ToString();
        public frmSDCMultipleReports()
        {
            InitializeComponent();
        }

        private void radToken_CheckedChanged(object sender, EventArgs e)
        {
            if (radToken.Checked == true)
            {
                panToken.Visible = true;
            }
            else
            {
                panToken.Visible = false;
            }
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            string hdr = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)) + System.Environment.NewLine;
            

            if (radToken.Checked = true)
            {
                string date1 = dateTimePicker1.Value.ToShortDateString();
                string date2 = dateTimePicker2.Value.ToShortDateString();
                webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_Token_DateToDate&rs:Command=Render&rc:Parameters=Collapsed&TehsilId=" + TehsilId + "&TokenDate1=" + date1 + "&TokenDate2=" + date2, username, password), null, null, hdr);
               
            }
        }

        private void frmSDCMultipleReports_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
            
        }
    }
}
