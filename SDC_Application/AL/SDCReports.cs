using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using SDC_Application.Classess;


 
 

namespace SDC_Application.AL
{
  
    public partial class SDCReports : Form
    {
       

        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }
        public int check
        {
            get; set; 
        }
        public string TokenID 
        { 
            get; 
            set; 
        }
        public string Tehsilid
        {
            get;
            set;
        }
        public string PVID
        {
            get;
            set;
        }
        public string RVID
        {
            get;
            set;
        }
        public string IntiqalId
        {
            get;
            set;
        }

        public string MozaId
        {
            get;
            set;
        }
        public SDCReports()
        {
            InitializeComponent();
        }

        private void SDCReports_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            frmMain main = new frmMain();
            string username = "Administrator";
            string password = "sdc$$mrd$$";
            this.ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            string FardFeeDepositeLoc = System.Configuration.ConfigurationSettings.AppSettings["FardChallan"];
            string hdr = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)) + "\r\n";
            
            if (UsersManagments.check== 1)
            {
               // MessageBox.Show("" + UsersManagments.check.ToString());
                string Token = TokenID;
                webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fToken_Generator&rs:Command=Render&rc:Parameters=Collapsed&TokenId=" + Token, username, password), null, null, hdr);
                //webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fToken_Generator&rs:Command=Render&rc:Parameters=Collapsed&TokenId=" + Token, username, password), null, null, hdr);                                                  //sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f   
            }

            if (UsersManagments.check == 2)
            {

                string Tehsil =Tehsilid;
                string PV = PVID;
                if (FardFeeDepositeLoc == "Bank")
                {
                    webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fFardTaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&TokenId=" + TokenID, username, password), null, null, hdr);
                   // webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fFardTaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&TokenId=" + TokenID, username, password), null, null, hdr);
                    // Challan Report Replaced by Bank Challan for Fard , for SDC Mardan only..
                }
                else
                {
                    //webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_Cahalan&rs:Command=Render&rc:Parameters=Collapsed&PVId=" + PV + "&TehsilId=" + Tehsil, username, password), null, null, hdr);
                    webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_Cahalan&rs:Command=Render&rc:Parameters=Collapsed&PVId=" + PV + "&TehsilId=" + Tehsil, username, password), null, null, hdr);
                }
            
            }
            if (UsersManagments.check == 3)
            {
               
                string RVId = RVID;
                webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_ReciptVoucherDetails&rs:Command=Render&rc:Parameters=Collapsed&RVID=" + RVId, username, password), null, null, hdr);
                //webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_ReciptVoucherDetails&rs:Command=Render&rc:Parameters=Collapsed&RVID=" + RVId, username, password), null, null, hdr);
            }
            if (UsersManagments.check == 4)
            {

                string intiqallid = IntiqalId;
                // webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2fLandWebReporting%2fIntiqalMain&rs:Command=Render&rc:Parameters=Collapsed&IntiqalId=" + intiqallid, username, password), null, null, hdr);
                webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fIntiqalMain&rs:Command=Render&rc:Parameters=Collapsed&IntiqalId=" + intiqallid, username, password), null, null, hdr);
                //webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fIntiqalMainPart_Baeh_ADC&rs:Command=Render&rc:Parameters=Collapsed&IntiqalId=" + intiqallid, username, password), null, null, hdr);
            }
            if (UsersManagments.check == 5)
            {

                string intiqallid = IntiqalId;
                webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fIntiqal_TaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&p_Intiqalid=" + intiqallid, username, password), null, null, hdr);
                //webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fIntiqal_TaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&p_Intiqalid=" + intiqallid, username, password), null, null, hdr);
            }
            if (UsersManagments.check == 6)
            {

                //string intiqallid = IntiqalId;
                // webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fIntiqal_TaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&p_Intiqalid=" + intiqallid, username, password), null, null, hdr);
               // webBrowser1.Navigate(String.Format("http://{0}:{1}@sdc2-psh-svr1/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fFardForPersonalRecord&rs:Command=Render&rc:Parameters=Collapsed&MozaId=" + this.MozaId + "&TokenId=" + this.TokenID, username, password), null, null, hdr);
                webBrowser1.Navigate(String.Format("http://{0}:{1}@MRD_SDC_SVRLive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportinFolderLand + "%2fFardForPersonalRecord&rs:Command=Render&rc:Parameters=Collapsed&MozaId=" + this.MozaId + "&TokenId=" + this.TokenID, username, password), null, null, hdr);
            }
           // string reportserver = "http://unh-pak-1860:80/ReportServer";
          
            //this.reportViewer1.ServerReport.ReportServerUrl = new Uri(reportserver);
            //this.reportViewer1.ServerReport.ReportPath = "/SDC_Reporting_Application/Token Generator";
            //this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            //ReportParameter aParam = new ReportParameter("TokenId", "11201405060001");
            //reportViewer1.ServerReport.SetParameters(aParam);
            //reportViewer1.ServerReport.Refresh();
            //reportViewer1.RefreshReport();
            

            ///////////////////////////////////Method 2nd for Multiple//////////////////////////////////////////////////

            ////ReportParameter[] parm=new ReportParameter[2];
            ////parm[0] = new ReportParameter("TokenId", "19201406120003");
            ////parm[1] = new ReportParameter("TokenNo", "3");
            ////reportViewer1.ServerReport.SetParameters(parm);

            ////////////////////////////////////////Method 2 for Multiple////////////////////////////////////////////////


           // ArrayList arrLstDefaultParam = new ArrayList();
           // arrLstDefaultParam.Add(new ReportParameter("TokenId", "11201406030001"));
           ////arrLstDefaultParam.Add(new ReportParameter("TokenNo", "3"));
           // ReportParameter[] param = new ReportParameter[arrLstDefaultParam.Count];
           // {
           //     for (int k = 0; k < arrLstDefaultParam.Count; k++)
           //         param[k] = (ReportParameter)arrLstDefaultParam[k];
           // }


           // reportViewer1.ServerReport.SetParameters(param); //Set Report Parameters
           // reportViewer1.ServerReport.Refresh();
           // reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
            webBrowser1.Print();
        }
    }
}
