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
        public string ReceiptVerified { get; set; }
        
        
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
                    //if (sdc == "abt" && isTrans)
                    //{
                    //    FardMalkan_Abt_Trans_Test ojbktg = new FardMalkan_Abt_Trans_Test();
                    //    //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                    //    // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                    //    // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                    //    ojbktg.SetDatabaseLogon("dlis", Password, ds, db);
                    //    ojbktg.SetParameterValue("TokenID", TokenID);
                    //    //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                    //    crystalReportViewer1.ReportSource = ojbktg;
                    //}
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //crystalReportViewer1.ShowLastPage();
            UsersManagments.NoPages = 1; //Convert.ToInt32(crystalReportViewer1.GetCurrentPageNumber().ToString());
           
           

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }

}
