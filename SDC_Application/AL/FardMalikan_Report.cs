using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using SDC_Application.AL;
using SDC_Application.Classess;

namespace SDC_Application
{
    public partial class FardMalikan_Report : Form
    {
        public string TokenID { get; set; }
        //public string TotalPages { get; set; }
        // Pages = new UsersManagments();
        public bool isTrans { get; set; }
        
        
        public FardMalikan_Report()
        {
            InitializeComponent();
        }

        private void FardMalikan_Report_Load(object sender, EventArgs e)
        {
            //CrystalReport1 objRpt = new CrystalReport1();
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;


            DataTable dt = new DataTable();
           SDC_Application.DL.Database  dbc = new DL.Database();
           dt = dbc.fillDataTable("getReportServerCredentials");


           String DB_UserName = null;
           String DB_Password = null;
           String ReportServer_Ip = null;
           String ReportServer_DB_Name = null;
           String OS_User = null;
           String OS_Password = null;

            






            try
            {
                
               if (dt != null && dt.Rows.Count > 0)
               {
                   DB_UserName = dt.Rows[0].Field<String>("DB_UserName");
                   DB_Password = SDC_Application.Classess.Crypto.Decrypt(dt.Rows[0].Field<String>("DB_Password"));
                   ReportServer_Ip = dt.Rows[0].Field<String>("ReportServer_Ip");
                   ReportServer_DB_Name = dt.Rows[0].Field<String>("ReportServer_DB_Name");
                   OS_User = dt.Rows[0].Field<String>("OS_User");
                   OS_Password = SDC_Application.Classess.Crypto.Decrypt(dt.Rows[0].Field<String>("OS_Password"));
               }

                UsersManagments.NoPages = 0;                
                string ds = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
                string db = SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["db"]);
                string Report = ConfigurationSettings.AppSettings["Report"];
                string Password = SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["allow"]);
                String sdc = "clrmis";
                

                ds = ReportServer_Ip;
                db = ReportServer_DB_Name;
                Password = DB_Password;


                //MessageBox.Show(db);
                //MessageBox.Show(Report);
                //MessageBox.Show(Password);
                //MessageBox.Show(sdc);
                //return;

                

                if (Report == "Test")
                {
                    if (sdc == "abt" && isTrans)
                    {
                        FardMalkan_Abt_Trans_Test ojbktg = new FardMalkan_Abt_Trans_Test();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "abt" && !isTrans)
                   {
                       AL.FardMalkan_Abt_Test obj = new AL.FardMalkan_Abt_Test();
                    FardMalkan_Peshawar ojbPsh = new FardMalkan_Peshawar();
                    //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                    // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                    // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                    obj.SetDatabaseLogon("dlis", Password, ds, db);
                    obj.SetParameterValue("TokenID", TokenID);
                    //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                    crystalReportViewer1.ReportSource = obj;
                   }
                }
                else
                {
                    if (sdc == "mrd" && !isTrans)
                    {
                        AL.FardMalkan_Mardan obj = new AL.FardMalkan_Mardan();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        obj.SetDatabaseLogon("dlis", Password, ds, db);
                        obj.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = obj;
                    }
                    if (sdc == "mrd" && isTrans)
                    {
                        AL.FardMalkan_Mardan_Trans obj = new AL.FardMalkan_Mardan_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        obj.SetDatabaseLogon("dlis", Password, ds, db);
                        obj.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = obj;
                    }
                    else if (sdc == "psh" && !isTrans)
                    {
                        FardMalkan_Peshawar ojbPsh = new FardMalkan_Peshawar();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbPsh.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbPsh.SetParameterValue("TokenID", TokenID);
                        //ojbPsh.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", ds, db);
                        crystalReportViewer1.ReportSource = ojbPsh;
                    }
                    else if (sdc == "psh" && isTrans)
                    {
                        FardMalkan_Peshawar_Trans ojbPsh = new FardMalkan_Peshawar_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbPsh.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbPsh.SetParameterValue("TokenID", TokenID);
                        //ojbPsh.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", ds, db);
                        crystalReportViewer1.ReportSource = ojbPsh;
                    }
                    else if (sdc == "ktg")
                    {
                        FardMalkan_Katlang ojbktg = new FardMalkan_Katlang();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tkb" && isTrans)
                    {
                        FardMalkan_TakhtBhai_Trans ojbktg = new FardMalkan_TakhtBhai_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tkb" && !isTrans)
                    {
                        FardMalkan_TakhtBhai ojbktg = new FardMalkan_TakhtBhai();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "dc")
                    {
                        FardMalkan_LiveDC ojbdc = new FardMalkan_LiveDC();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbdc.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbdc.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbdc;
                    }
                        // --------- Abbottabad Detail Fard Reprots ------ ///
                    else if (sdc == "abtTest" && !isTrans)
                    {
                        FardMalkan_Abt_Test ojbktg = new FardMalkan_Abt_Test();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "abt" && !isTrans)
                    {
                        FardMalkan_Abt ojbktg = new FardMalkan_Abt();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "ltwl" && !isTrans)
                    {
                        FardMalkan_Ltwl ojbktg = new FardMalkan_Ltwl();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    
                    else if (sdc == "abt" && isTrans)
                    {
                        FardMalkan_Abt_Trans ojbktg = new FardMalkan_Abt_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "ltwl" && isTrans)
                    {
                        FardMalkan_Ltwl_Trans ojbktg = new FardMalkan_Ltwl_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "btg" && !isTrans)
                    {
                        FardMalkan_Btg ojbktg = new FardMalkan_Btg();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "btg" && isTrans)
                    {
                        FardMalkan_Btg_Trans ojbktg = new FardMalkan_Btg_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "chd" && !isTrans)
                    {
                        FardMalkan_Chd ojbktg = new FardMalkan_Chd();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "chd" && isTrans)
                    {
                        FardMalkan_Chd_Trans ojbktg = new FardMalkan_Chd_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                     else if (sdc == "dgr" && !isTrans)
                    {
                        FardMalkan_Dgr ojbktg = new FardMalkan_Dgr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "dgr" && isTrans)
                    {
                        FardMalkan_Dgr_Trans ojbktg = new FardMalkan_Dgr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "gra" && !isTrans)
                    {
                        FardMalkan_Gra ojbktg = new FardMalkan_Gra();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "gra" && isTrans)
                    {
                        FardMalkan_Gra_Trans ojbktg = new FardMalkan_Gra_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "hrp" && !isTrans)
                    {
                        FardMalkan_Hrp ojbktg = new FardMalkan_Hrp();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "hrp" && isTrans)
                    {
                        FardMalkan_Hrp_Trans ojbktg = new FardMalkan_Hrp_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "khk" && !isTrans)
                    {
                        FardMalkan_Khk ojbktg = new FardMalkan_Khk();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "khk" && isTrans)
                    {
                        FardMalkan_Khk_Trans ojbktg = new FardMalkan_Khk_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tpi" && !isTrans)
                    {
                        FardMalkan_Tpi ojbktg = new FardMalkan_Tpi();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tpi" && isTrans)
                    {
                        FardMalkan_Tpi_Trans ojbktg = new FardMalkan_Tpi_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bnu" && !isTrans)
                    {
                        FardMalkan_Bnu ojbktg = new FardMalkan_Bnu();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bnu" && isTrans)
                    {
                        FardMalkan_Bnu_Trans ojbktg = new FardMalkan_Bnu_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "lch" && !isTrans)
                    {
                        FardMalkan_Lch ojbktg = new FardMalkan_Lch();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "lch" && isTrans)
                    {
                        FardMalkan_Lch_Trans ojbktg = new FardMalkan_Lch_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "kht" && !isTrans)
                    {
                        FardMalkan_Kht ojbktg = new FardMalkan_Kht();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "kht" && isTrans)
                    {
                        FardMalkan_Kht_Trans ojbktg = new FardMalkan_Kht_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "ukm" && !isTrans)
                    {
                        FardMalkan_Ukm ojbktg = new FardMalkan_Ukm();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "ukm" && isTrans)
                    {
                        FardMalkan_Ukm_Trans ojbktg = new FardMalkan_Ukm_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "lkm" && !isTrans)
                    {
                        FardMalkan_Lkm ojbktg = new FardMalkan_Lkm();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "lkm" && isTrans)
                    {
                        FardMalkan_Lkm_Trans ojbktg = new FardMalkan_Lkm_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "nrg" && !isTrans)
                    {
                        FardMalkan_Nrg ojbktg = new FardMalkan_Nrg();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "nrg" && isTrans)
                    {
                        FardMalkan_Nrg_Trans ojbktg = new FardMalkan_Nrg_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bds" && !isTrans)
                    {
                        FardMalkan_Bds ojbktg = new FardMalkan_Bds();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bds" && isTrans)
                    {
                        FardMalkan_Bds_Trans ojbktg = new FardMalkan_Bds_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "krk" && !isTrans)
                    {
                        FardMalkan_Krk ojbktg = new FardMalkan_Krk();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "krk" && isTrans)
                    {
                        FardMalkan_Krk_Trans ojbktg = new FardMalkan_Krk_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tnk" && !isTrans)
                    {
                        FardMalkan_Tnk ojbktg = new FardMalkan_Tnk();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "tnk" && isTrans)
                    {
                        FardMalkan_Tnk_Trans ojbktg = new FardMalkan_Tnk_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "pbi" && !isTrans)
                    {
                        FardMalkan_Pbi ojbktg = new FardMalkan_Pbi();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "pbi" && isTrans)
                    {
                        FardMalkan_Pbi_Trans ojbktg = new FardMalkan_Pbi_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "apr" && !isTrans)
                    {
                        FardMalkan_Apr ojbktg = new FardMalkan_Apr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "apr" && isTrans)
                    {
                        FardMalkan_Apr_Trans ojbktg = new FardMalkan_Apr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "dik" && !isTrans)
                    {
                        FardMalkan_DIK ojbktg = new FardMalkan_DIK();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "dik" && isTrans)
                    {
                        FardMalkan_DIK_Trans ojbktg = new FardMalkan_DIK_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bkt" && !isTrans)
                    {
                        FardMalkan_Bkt ojbktg = new FardMalkan_Bkt();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bkt" && isTrans)
                    {
                        FardMalkan_Bkt_Trans ojbktg = new FardMalkan_Bkt_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "kpr" && !isTrans)
                    {
                        FardMalkan_Kpr ojbktg = new FardMalkan_Kpr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "kpr" && isTrans)
                    {
                        FardMalkan_Kpr_Trans ojbktg = new FardMalkan_Kpr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bsm" && !isTrans)
                    {
                        FardMalkan_Bsm ojbktg = new FardMalkan_Bsm();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "bsm" && isTrans)
                    {
                        FardMalkan_Bsm_Trans ojbktg = new FardMalkan_Bsm_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "cbh" && !isTrans)
                    {
                        FardMalkan_Cbh ojbktg = new FardMalkan_Cbh();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "cbh" && isTrans)
                    {
                        FardMalkan_Cbh_Trans ojbktg = new FardMalkan_Cbh_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Swb" && !isTrans)
                    {
                        FardMalkan_Swb ojbktg = new FardMalkan_Swb();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Swb" && isTrans)
                    {
                        FardMalkan_Swb_Trans ojbktg = new FardMalkan_Swb_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Lhr" && !isTrans)
                    {
                        FardMalkan_Lhr ojbktg = new FardMalkan_Lhr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Lhr" && isTrans)
                    {
                        FardMalkan_Lhr_Trans ojbktg = new FardMalkan_Lhr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Rzr" && !isTrans)
                    {
                        FardMalkan_Rzr ojbktg = new FardMalkan_Rzr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Rzr" && isTrans)
                    {
                        FardMalkan_Rzr_Trans ojbktg = new FardMalkan_Rzr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Kkl" && !isTrans)
                    {
                        FardMalkan_Kkl ojbktg = new FardMalkan_Kkl();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Kkl" && isTrans)
                    {
                        FardMalkan_Kkl_Trans ojbktg = new FardMalkan_Kkl_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Mnr" && !isTrans)
                    {
                        FardMalkan_Mnr ojbktg = new FardMalkan_Mnr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Mnr" && isTrans)
                    {
                        FardMalkan_Mnr_Trans ojbktg = new FardMalkan_Mnr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Dml" && !isTrans)
                    {
                        FardMalkan_Dml ojbktg = new FardMalkan_Dml();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Dml" && isTrans)
                    {
                        FardMalkan_Dml_Trans ojbktg = new FardMalkan_Dml_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Kki" && !isTrans)
                    {
                        FardMalkan_Kki ojbktg = new FardMalkan_Kki();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Kki" && isTrans)
                    {
                        FardMalkan_Kki_Trans ojbktg = new FardMalkan_Kki_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Ppr" && !isTrans)
                    {
                        FardMalkan_Ppr ojbktg = new FardMalkan_Ppr();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Ppr" && isTrans)
                    {
                        FardMalkan_Ppr_Trans ojbktg = new FardMalkan_Ppr_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Pwa" && !isTrans)
                    {
                        FardMalkan_Pwa ojbktg = new FardMalkan_Pwa();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Pwa" && isTrans)
                    {
                        FardMalkan_Pwa_Trans ojbktg = new FardMalkan_Pwa_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Jra" && !isTrans)
                    {
                        FardMalkan_Jra ojbktg = new FardMalkan_Jra();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Jra" && isTrans)
                    {
                        FardMalkan_Jra_Trans ojbktg = new FardMalkan_Jra_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Tgi" && !isTrans)
                    {
                        FardMalkan_Tgi ojbktg = new FardMalkan_Tgi();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Tgi" && isTrans)
                    {
                        FardMalkan_Tgi_Trans ojbktg = new FardMalkan_Tgi_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Brt" && !isTrans)
                    {
                        FardMalkan_Brt ojbktg = new FardMalkan_Brt();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Brt" && isTrans)
                    {
                        FardMalkan_Brt_Trans ojbktg = new FardMalkan_Brt_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Thl" && !isTrans)
                    {
                        FardMalkan_Thl ojbktg = new FardMalkan_Thl();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Thl" && isTrans)
                    {
                        FardMalkan_Thl_Trans ojbktg = new FardMalkan_Thl_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Hgu" && !isTrans)
                    {
                        FardMalkan_Hgu ojbktg = new FardMalkan_Hgu();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else if (sdc == "Hgu" && isTrans)
                    {
                        FardMalkan_Hgu_Trans ojbktg = new FardMalkan_Hgu_Trans();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbktg.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbktg;
                    }
                    else {

                        DB_UserName = dt.Rows[0].Field<String>("DB_UserName");
                        DB_Password = SDC_Application.Classess.Crypto.Decrypt(dt.Rows[0].Field<String>("DB_Password"));
                        ReportServer_Ip = dt.Rows[0].Field<String>("ReportServer_Ip");
                        ReportServer_DB_Name = dt.Rows[0].Field<String>("ReportServer_DB_Name");
                        OS_User = dt.Rows[0].Field<String>("OS_User");
                        OS_Password = SDC_Application.Classess.Crypto.Decrypt(dt.Rows[0].Field<String>("OS_Password"));


                        FardMalkan_Pwa ojbktg = new FardMalkan_Pwa();
                        ojbktg.SetDatabaseLogon(DB_UserName, DB_Password, ReportServer_Ip, ReportServer_DB_Name);
                        ojbktg.SetParameterValue("TokenID", TokenID);                        
                        crystalReportViewer1.ReportSource = ojbktg;
                    }


                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            crystalReportViewer1.ShowLastPage();
            UsersManagments.NoPages = Convert.ToInt32(crystalReportViewer1.GetCurrentPageNumber().ToString());
           
           

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }

}
