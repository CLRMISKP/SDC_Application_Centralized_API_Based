using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SDC_Application.Classess;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Net;

namespace SDC_Application
{
    public partial class frmIntiqalTaxAIT : Form
    {
        public string IntiqalId { get; set; }
        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }

        public frmIntiqalTaxAIT()
        {
            InitializeComponent();
        }

        private void frmIntiqalTaxAIT_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("intiqalid", this.IntiqalId);
                SetCredentials("Land_Seller_TaxChallan", rp, false);
                SetCredentialsBuyer("Land_Buyer_TaxChallan", rp, false);

            //this.reportViewerSeller.RefreshReport();
            //this.reportViewerBuyers.RefreshReport();
        }

        private void SetCredentials(string report, ReportParameter[] r, bool isSdcReports)
        {
            this.reportViewerSeller.RefreshReport();
            string Server = "http://" + SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["rptserver"]) + UsersManagments._rptPort + "/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            string reportProjectLand = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            reportViewerSeller.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = reportViewerSeller.ServerReport;

            string usr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            //

            NetworkCredential myCred = new
                NetworkCredential(usr, password, domain);//"sdc2-psh-svr1");
            reportViewerSeller.ServerReport.ReportServerCredentials.NetworkCredentials =
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

            //You can add Parameter if need
            ReportParameter[] rp = new ReportParameter[1];
            rp = r;

            reportViewerSeller.ServerReport.SetParameters(rp);
        }

        private void SetCredentialsBuyer(string report, ReportParameter[] r, bool isSdcReports)
        {
            this.reportViewerSeller.RefreshReport();
            string Server = "http://" + SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["rptserver"]) + UsersManagments._rptPort + "/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            string reportProjectLand = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            reportViewerBuyers.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = reportViewerBuyers.ServerReport;

            string usr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            //

            NetworkCredential myCred = new
               NetworkCredential(usr, password, domain);//"sdc2-psh-svr1");
            reportViewerBuyers.ServerReport.ReportServerCredentials.NetworkCredentials =
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

            //You can add Parameter if need
            ReportParameter[] rp = new ReportParameter[1];
            rp = r;
            reportViewerBuyers.ServerReport.SetParameters(rp);
        }
    }
}
