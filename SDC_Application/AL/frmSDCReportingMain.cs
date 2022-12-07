using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using System.Net;

namespace SDC_Application.AL
{
    public partial class frmSDCReportingMain : Form
    {
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();

        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }
        public string  FardPersonId { get; set; }


        public int check
        {
            get;
            set;
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

        public string userId
        {
            get;
            set;
        }

        public string MozaId
        {
            get;
            set;
        }
        public string FamilyId
        {
            get;
            set;
        }
        public string KhataId
        {
            get;
            set;
        }
        public string FbID { get; set; }
        public string TokenDate { get; set; }
        
        public frmSDCReportingMain()
        {
            InitializeComponent();
        }

        private void cboMoza_KeyPress(object sender, KeyPressEventArgs e)
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

       

      

        private void SetCredentials(string report, ReportParameter[] r, bool isSdcReports)
        {
            this.rvIntiqalReport.RefreshReport();
            string Server = "http://" + SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["rptserver"]) + UsersManagments._rptPort + "/ReportServer";//ReportServerTextBox.Text;
            string reportProject ="/"+ System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"]+"/";
            string reportProjectLand = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            rvIntiqalReport.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = rvIntiqalReport.ServerReport;

            string usr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            //

            NetworkCredential myCred = new
                NetworkCredential(usr, password, domain);//"sdc2-psh-svr1");
            rvIntiqalReport.ServerReport.ReportServerCredentials.NetworkCredentials =
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
            if (UsersManagments.check != 7)  
            {
                rvIntiqalReport.ServerReport.SetParameters(rp);
            }
            else
            {
                rvIntiqalReport.ServerReport.SetParameters(rp);
                rvIntiqalReport.ShowParameterPrompts = true;
            }
            rvIntiqalReport.RefreshReport();
        }

        private void frmSDCReportingMain_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            if (UsersManagments.check == 6)
            {
                ReportParameter[] rp=new ReportParameter[3];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("TokenId", this.TokenID);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());

                this.SetCredentials("FardForPersonalRecord", rp, false);

            }
            if (UsersManagments.check == 8)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("KhatooniMushteryanDetails", rp, false);

            }
            if (UsersManagments.check == 10)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                this.SetCredentials("KhatooniMushteryanDetailsByMoza", rp, false);

            }
            if (UsersManagments.check == 11)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("p_moza", this.MozaId);
                rp[1] = new ReportParameter("s_family", this.FamilyId);
                this.SetCredentials("SajraNasab_ByFamilies", rp, false);

            }
            if (UsersManagments.check == 9)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("fbId", this.FbID);
                this.SetCredentials("Fard_e_Bader_Main_From_App", rp, false);

            }
            if (UsersManagments.check == 2)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TokenId", this.TokenID);
                rp[1] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("FardTaxBankChallan", rp, false);

            }
            if (UsersManagments.check == 1)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TokenId", this.TokenID);
                this.SetCredentials("Token_Generator", rp, true);

            }
            if (UsersManagments.check == 3)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("RVID", this.RVID);
                this.SetCredentials("Report_ReciptVoucherDetails", rp, true);

            }
            if (UsersManagments.check == 4)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Baeh_ADC", rp, false);

            }

            if (UsersManagments.check == 5)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("p_Intiqalid", this.IntiqalId);
                this.SetCredentials("Intiqal_TaxBankChallan", rp, false);

            }

            if (UsersManagments.check == 7)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("FeeCollectionReport", rp, false);

            }


            if (UsersManagments.check == 12)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("fbId", this.FbID);
                this.SetCredentials("eFard_e_Bader_MultiKhata", rp, false);

            }
            if (UsersManagments.check == 13)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("p_MozaId", this.MozaId);
                this.SetCredentials("GradawariFromApp", rp, false);
            }

            if (UsersManagments.check == 14)
            {
                ReportParameter[] rp = new ReportParameter[4];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("TokenId", this.TokenID);
                rp[2] = new ReportParameter("currentUser", UsersManagments.UserName);
                rp[3] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());

                this.SetCredentials("FardForPersonalRecordTrans", rp, false);

            }

            if (UsersManagments.check == 15)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TokenDate", this.TokenDate);
                this.SetCredentials("Covid19_Booking_Details", rp, false);

            }
            if (UsersManagments.check == 16)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaKasht", rp, false);

            }
            if (UsersManagments.check == 17)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaMalkiatKasht", rp, false);

            }

            if (UsersManagments.check == 18)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Warasat", rp, false);

            }
            if (UsersManagments.check == 19)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Baeh_ADC_Taqseem", rp, false);

            }

            if (UsersManagments.check == 20)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("v_IntiqalId", this.IntiqalId);
                this.SetCredentials("Roznamcha", rp, false);

            }

            if (UsersManagments.check == 21)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TokenId", this.TokenID);
                rp[1] = new ReportParameter("currentUser", this.userId);
                this.SetCredentials("DetailedFardKK", rp, false);

            }
            if (UsersManagments.check == 22)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("PersonId", this.FardPersonId);
                this.SetCredentials("Land_Fard_TaxChallan", rp, false);

            }
            if (UsersManagments.check == 23)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("intiqalid", this.IntiqalId);
                rp[1] = new ReportParameter("PersonId", this.FardPersonId);
                this.SetCredentials("Land_Seller_TaxChallan", rp, false);

            }
            if (UsersManagments.check == 24)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("intiqalid", this.IntiqalId);
                rp[1] = new ReportParameter("PersonId", this.FardPersonId);
                this.SetCredentials("Land_Buyer_TaxChallan", rp, false);

            }
        }

    }
}
