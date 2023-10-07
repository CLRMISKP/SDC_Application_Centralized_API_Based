using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Net;

namespace SDC_Application.AL
{
    public partial class frmReportViewer : Form
    {
        public string IntiqalId { get; set; }
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            this.objReportViewer.RefreshReport();
            string Server = "http://192.168.1.100/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/LandWebReportingLive/";
            string reportName = "IntiqalMainPart_Baeh_ADC";
            objReportViewer.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = objReportViewer.ServerReport;
            //

            NetworkCredential myCred = new
                NetworkCredential("Administrator", "abc$$123", "psh-sdc2-svr01");
            objReportViewer.ServerReport.ReportServerCredentials.NetworkCredentials =
                myCred;
            //
            serverReport.ReportServerUrl = new Uri(Server);
            serverReport.ReportPath = reportProject + reportName; //FolderTextBox.Text + ReportNameTextBox1.Text;

            // You can add Parameter if need
            ReportParameter[] rp = new ReportParameter[1];
            rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
            objReportViewer.ServerReport.SetParameters(rp);
            objReportViewer.RefreshReport();

        }
    }
}
