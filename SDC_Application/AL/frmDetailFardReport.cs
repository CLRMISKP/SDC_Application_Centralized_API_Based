using Microsoft.Reporting.WinForms;
using SDC_Application.Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmDetailFardReport : Form
    {
        public string TehsilId { get; set; }
        public string MozaId { get; set; }
        public string TokenId { get; set; }
        public string currentUser { get; set; }
        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }
        public frmDetailFardReport()
        {
            InitializeComponent();
        }

        private void frmDetailFardReport_Load(object sender, EventArgs e)
        {
            ReportParameter[] r = new ReportParameter[4];
            r[0] = new ReportParameter("TehsilId", this.TehsilId);
            r[1] = new ReportParameter("MozaId", this.MozaId);
            r[2] = new ReportParameter("TokenId", this.TokenId);
            r[3] = new ReportParameter("CurrentUser", UsersManagments.UserName);
            SetCredentials("DetailFard",r ,true);
        }
        private void SetCredentials(string report, ReportParameter[] r, bool isSdcReports)
        {
            this.FardReport.RefreshReport();
            string Server = "http://175.107.59.12/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/LandWebReportingCLRMIS/";// + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            string reportProjectLand = "/LandWebReportingCLRMIS/";// + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            FardReport.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = FardReport.ServerReport;

            string usr = "rptUserCLRMIS";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = "Pmu@#reports";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = "localhost";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = "LandWebReportingCLRMIS";// System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = "LandWebReportingCLRMIS";// System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            //
            //

            NetworkCredential myCred = new
                NetworkCredential(usr, password, domain);//"sdc2-psh-svr1");
            FardReport.ServerReport.ReportServerCredentials.NetworkCredentials =
                myCred;
            //
            serverReport.ReportServerUrl = new Uri(Server);
            if (isSdcReports)
            {
                serverReport.ReportPath = reportProject + reportName; //FolderTextBox.Text + ReportNameTextBox1.Text;
            }
            else
            {
                serverReport.ReportPath = reportProjectLand + reportName;
            }
                FardReport.ServerReport.SetParameters(r);
            
            FardReport.RefreshReport();
        }

    }
}
