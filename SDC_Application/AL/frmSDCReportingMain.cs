﻿using System;
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
        public string FardPersonId { get; set; }
        public string ReceiptVerified { get; set; }
        public string UserName { get; set; }


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
        public string RegFardDispatchMainId { get; set; }
        public string PersonName { get; set; }
        public string SubSdcId { get; set; }
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
            //string Server = "http://" + SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["rptserver"]) + UsersManagments._rptPort + "/ReportServer";//ReportServerTextBox.Text;
            //string reportProject = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            //string reportProjectLand = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string Server = "http://175.107.59.12/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/LandWebReportingCLRMIS/";// + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            string reportProjectLand = "/LandWebReportingCLRMIS/";// + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            rvIntiqalReport.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = rvIntiqalReport.ServerReport;

            string usr = "rptUserCLRMIS";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = "Pmu@#reports";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = "localhost";// SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = "LandWebReportingCLRMIS";// System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = "LandWebReportingCLRMIS";// System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
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
            if ((UsersManagments.check > 24 && UsersManagments.check < 60 && UsersManagments.check != 51 && UsersManagments.check != 50 && UsersManagments.check != 44 && UsersManagments.check != 47) || UsersManagments.check == 63 || (UsersManagments.check > 69 && UsersManagments.check != 82))
            {
                //ReportParameter param = new ReportParameter();
                //param.Name = "TehsilId";
                //param.Values.Add(Tehsilid);
                //ReportParameter param2 = new ReportParameter();
                //param2.Name = "SubSdcId";
                //param2.Values.Add(SubSdcId);
                rvIntiqalReport.ServerReport.SetParameters(r);
                rvIntiqalReport.ShowParameterPrompts = true;
            }
            else if (UsersManagments.check >= 44 && UsersManagments.check != 52)
            {
                rvIntiqalReport.ServerReport.SetParameters(rp);
            }
            else if (UsersManagments.check != 7 && UsersManagments.check != 52)
            {
                rvIntiqalReport.ServerReport.SetParameters(rp);
            }
            else if (UsersManagments.check == 61) //-- Khata Khatooni Khassra Detail Report
            {

                rvIntiqalReport.ServerReport.SetParameters(r);
            }
            else
            {
                ReportParameter param = new ReportParameter();
                param.Name = "TehsilId";
                param.Values.Add(Tehsilid);
                rvIntiqalReport.ServerReport.SetParameters(param);
                rvIntiqalReport.ShowParameterPrompts = true;
            }
            rvIntiqalReport.RefreshReport();
        }

        private void frmSDCReportingMain_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text; DataGridViewHelper.addHelpterToAllFormGridViews(this);

            if (UsersManagments.check == 6)
            {
                ReportParameter[] rp = new ReportParameter[3];
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
            if (UsersManagments.check == 25)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("AikSala_Type_dem", rp, false);

            }
            if (UsersManagments.check == 26)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("AikSala_Makhloot_dem", rp, false);

            }
            if (UsersManagments.check == 27)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("DRA_FardFee_dem", rp, false);

            }
            if (UsersManagments.check == 28)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("DRA_IntiqalParthFee_dem", rp, false);

            }
            if (UsersManagments.check == 29)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("DRA_IntiqalTax_dem", rp, false);

            }
            if (UsersManagments.check == 30)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Intiqal_Tehsildar_Report_dem", rp, false);

            }
            if (UsersManagments.check == 31)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Registry_Intiqal_Pending_dem", rp, false);

            }
            if (UsersManagments.check == 32)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Registry_Intiqal_Detail_dem", rp, false); //Registry_Intiqal_Pending_dem

            }
            if (UsersManagments.check == 33)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Intiqal_Entered_Daily_dem", rp, false);

            }
            if (UsersManagments.check == 34)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("RTS_Mutation_Entry_dem", rp, false);

            }
            if (UsersManagments.check == 35)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("RTS_Fard_Issueance_dem", rp, false);

            }
            if (UsersManagments.check == 36)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Attestation_Mutation_For_AntiCorruption_Drive", rp, false);

            }
            if (UsersManagments.check == 37)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Fard_Issuance_Report_For_AntiCorruptionDrive", rp, false);
            }
            if (UsersManagments.check == 38)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAndrajDetailReportForBeahIntiqalsFBR", rp, false);

            }
            if (UsersManagments.check == 39)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAttestationDateReport", rp, false);

            }
            if (UsersManagments.check == 40)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalInsertReportByOperator", rp, false);

            }
            if (UsersManagments.check == 41)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalKharijshudaDetailReport", rp, false);

            }
            if (UsersManagments.check == 42)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalInsertReportByOperator", rp, false);

            }
            if (UsersManagments.check == 43)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAttestedNotImplementedReport", rp, false);

            }
            if (UsersManagments.check == 44)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("fbId", this.FbID);
                rp[2] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("Rhz_Change_Details", rp, false);

            }
            if (UsersManagments.check == 45)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", this.userId);
                rp[2] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaKasht_To_Malkiat", rp, false);
            }
            if (UsersManagments.check == 46)
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("RegFardDispatchMainId", this.RegFardDispatchMainId);
                this.SetCredentials("RegistriesDispatchMain", rp, false);
            }
            if (UsersManagments.check == 47)
            {
                ReportParameter[] rp = new ReportParameter[5];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("TokenId", this.TokenID);
                rp[2] = new ReportParameter("UserName", UsersManagments.UserName);
                rp[3] = new ReportParameter("ReceiptVerified", this.ReceiptVerified);
                rp[4] = new ReportParameter("TehsilId", this.Tehsilid);
                this.SetCredentials("ShortFardForPersonalRecord", rp, false);
            }
            if (UsersManagments.check == 48)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalBoimetricCapturedNotAttestedReport", rp, false);

            }
            if (UsersManagments.check == 49)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("StateLandDataReport", rp, false);

            }
            if (UsersManagments.check == 50)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("PersonId", this.FardPersonId);
                rp[1] = new ReportParameter("Person_Name", this.PersonName);
                rp[2] = new ReportParameter("MozaId", this.MozaId);
                this.SetCredentials("PersonMalkiatMain", rp, false);

            }
            if (UsersManagments.check == 51)
            {
                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("MozaId", this.MozaId);
                rp[1] = new ReportParameter("fbId", this.FbID);
                rp[2] = new ReportParameter("tehsilid", this.Tehsilid);
                this.SetCredentials("eFard_e_Bader_Min_Khatajat", rp, false);

            }
            if (UsersManagments.check == 52)
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Mutation_UnAttested_dem", rp, false);

            }
            if (UsersManagments.check == 53) //IntiqalAttestationDateReport
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAttestedNotImplementedReport", rp, false);

            }
            if (UsersManagments.check == 54) //IntiqalAttestationDateReport
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAttestationDateReport", rp, false);

            }
            if (UsersManagments.check == 55) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("AreaDifference_KhataKhewatKhatooni", rp, false);

            }
            if (UsersManagments.check == 56) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("Intiqal_Pending", rp, false);

            }
            if (UsersManagments.check == 57) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Attested_Mutation_For_Audit", rp, false);//FardBadarEntryReport

            }
            if (UsersManagments.check == 58) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("FardBadarEntryReport", rp, false);//FardBadarEntryReport

            }
            if (UsersManagments.check == 59) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Registry_Intiqal_Entry_Detail_dem", rp, false);//FardBadarEntryReport

            }
            if (UsersManagments.check == 61) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("KhataKhatooniKhassras", rp, false);

            }
            if (UsersManagments.check == 62) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("KhanakashDetail_Transposition", rp, false);

            }
            if (UsersManagments.check == 63) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("IntiqalPendingEnteredAttestedCanceledRemaing", rp, false);

            }
            if (UsersManagments.check == 64) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                //rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("KhanakashDetails", rp, false);

            }
            if (UsersManagments.check == 65) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                //rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("AreaDifference_KhataKhewatKhatooniByTehsil", rp, false);

            }
            if (UsersManagments.check == 66) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                //rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("AreaDifference_KhataKhewatKhatooniHissasDiffByTehsil", rp, false);

            }
            if (UsersManagments.check == 67) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("FardBadarImplementedReport", rp, false);

            }
            if (UsersManagments.check == 68) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("FardBadarCancelReport", rp, false);

            }
            if (UsersManagments.check == 69) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("FardBadarNotImplementedReport", rp, false);

            }
            if (UsersManagments.check == 70) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("TokensDetailReport", rp, false);

            }
            if (UsersManagments.check == 71) //Inconsistent Khata Jat
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("Intiqal_Entered_Pending_dem", rp, false);

            }
            if (UsersManagments.check == 72) //DRA Taxes Detail Report - Swat Demand
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("DRA_Attested_Mutation", rp, false);

            }
            if (UsersManagments.check == 73) //DRA Taxes Detail Report - Swat Demand
            {
                ReportParameter[] rp = new ReportParameter[2]; //
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("Area_Malkan_In_Acre_8_Kanal_Plus", rp, false);

            }
            if (UsersManagments.check == 74) //DRA Taxes Detail Report - Swat Demand
            {
                ReportParameter[] rp = new ReportParameter[2]; //FardBadarEnteredNumberOnly
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("FardBadarEnteredNumberOnly", rp, false);

            }
            if (UsersManagments.check == 75) //Month Wise Tax Fee Report - D I Khan Need
            {
                ReportParameter[] rp = new ReportParameter[1]; //FardBadarEnteredNumberOnly
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                //rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("Month_Wise_Tax_Mutation_Fardat", rp, false);

            }
            if (UsersManagments.check == 76 || UsersManagments.check == 77) //Bayan Halfi Report - Swat Need
            {
                ReportParameter[] rp = new ReportParameter[2]; //FardBadarEnteredNumberOnly
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("DRA_Attested_Mutation_Bayan_Halfi", rp, false);

            }
            if (UsersManagments.check == 78) //Qism Zameen Wise Report
            {
                ReportParameter[] rp = new ReportParameter[2]; //FardBadarEnteredNumberOnly
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSDCId", UsersManagments.SubSdcId.ToString());
                //rp[1] = new ReportParameter("KhataId", this.KhataId);
                this.SetCredentials("QismZameenAreaMozaWise", rp, false);

            }

            if (UsersManagments.check == 79) //Registry Fardat for Registrar Report
            {
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("RegFardDispatchMainId", this.RegFardDispatchMainId);
                this.SetCredentials("RegistrarFardatMain", rp, false);

            }


           

                if (UsersManagments.check == 80) //Registry Fardat for Registrar Report
                {
                    ReportParameter[] rp = new ReportParameter[2];
                    rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                    rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                    this.SetCredentials("IntiqalImplementedPendingDataEntryManual", rp, false);

                }
                if (UsersManagments.check == 81) //Registry Fardat for Registrar Report
                {
                    ReportParameter[] rp = new ReportParameter[2];
                    rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                    rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                    this.SetCredentials("DRA_Attested_Mutation_and_Fardat_Bayan_Halfi", rp, false);

                }

                if (UsersManagments.check == 82) //Fard i Badar Challan
                {
                    ReportParameter[] rp = new ReportParameter[2];
                    rp[0] = new ReportParameter("TokenId",  this.TokenID.ToString());
                    rp[1] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                    this.SetCredentials("FardBadarTaxBankChallan", rp, false);

                }
                if (UsersManagments.check == 83) //Khata Lock Details
                {
                    ReportParameter[] rp = new ReportParameter[1];
                    rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                    this.SetCredentials("KhataLockDetails", rp, false);

                }
                if (UsersManagments.check == 84) //Khata Lock Details
                {
                    ReportParameter[] rp = new ReportParameter[1];
                    rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                    this.SetCredentials("AikSala_Type_By_AreaType", rp, false);

                }
                if (UsersManagments.check == 85) //Registry Fardat for Registrar Report
                {
                    ReportParameter[] rp = new ReportParameter[2];
                    rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                    rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                    this.SetCredentials("Entered_Mutation_After_Operationalization", rp, false);

                }
            if (UsersManagments.check == 86) //Registry Fardat for Registrar Report //IntiqalAllImplementedPendingManualSdc
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IntiqalAllImplementedPendingManualSdc", rp, false);

            }
            if (UsersManagments.check == 87) //Registry Fardat for Registrar Report //IntiqalAllImplementedPendingManualSdc
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IndexKhassra", rp, false);

            }
            if (UsersManagments.check == 88) //Registry Fardat for Registrar Report //IntiqalAllImplementedPendingManualSdc
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("IndexRadeefWar", rp, false);

            }
            if (UsersManagments.check == 89) //Registry Fardat for Registrar Report //IntiqalAllImplementedPendingManualSdc
            {
                ReportParameter[] rp = new ReportParameter[2];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                rp[1] = new ReportParameter("SubSdcId", UsersManagments.SubSdcId.ToString());
                this.SetCredentials("Malkan_Search_By_Tehsil", rp, false);

            }
        }

        }
    
}
