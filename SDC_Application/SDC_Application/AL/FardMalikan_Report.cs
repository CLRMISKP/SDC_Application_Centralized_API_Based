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
        
        
        public FardMalikan_Report()
        {
            InitializeComponent();
        }

        private void FardMalikan_Report_Load(object sender, EventArgs e)
        {
            //CrystalReport1 objRpt = new CrystalReport1();

            try
            {
                UsersManagments.NoPages = 0;
                string ds = ""; // System.Configuration.ConfigurationSettings.AppSettings["server"];
                string db = ""; // ConfigurationSettings.AppSettings["db"];
                string Report = "Live";// ConfigurationSettings.AppSettings["Report"];
                string Password = "";// ConfigurationSettings.AppSettings["allow"];
                string sdc = "dc";// ConfigurationSettings.AppSettings["sdc"];
                
                if (Report == "Test")
                {
                   
                    AL.FardMalkan_Mardan_Test obj = new AL.FardMalkan_Mardan_Test();
                    FardMalkan_Peshawar ojbPsh = new FardMalkan_Peshawar();
                    //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                    // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                    // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                    obj.SetDatabaseLogon("dlis", Password, ds, db);
                    obj.SetParameterValue("TokenID", TokenID);
                    //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                    crystalReportViewer1.ReportSource = obj;
                }
                else
                {
                    if (sdc == "mrd")
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
                    else if (sdc == "psh")
                    {
                        FardMalkan_Peshawar ojbPsh = new FardMalkan_Peshawar();
                        //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                        // string server = "192.168.1.100";// ConfigurationSettings.AppSettings["192.168.1.100"];
                        // string db ="Mardan_AmalDaramad";// ConfigurationSettings.AppSettings["Mardan_AmalDaramad"];
                        //ojbPsh.SetDatabaseLogon("dlis", Password, ds, db);
                        ojbPsh.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
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
                    else if (sdc == "tkb")
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
                        ojbdc.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "175.107.63.31", "LRMIS_SDC_Test_Ent");
                        ojbdc.SetParameterValue("TokenID", TokenID);
                        //obj.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013sdcmrd##", server, db);
                        crystalReportViewer1.ReportSource = ojbdc;
                        crystalReportViewer1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           // crystalReportViewer1.ShowLastPage();
            //UsersManagments.NoPages = Convert.ToInt32(crystalReportViewer1.GetCurrentPageNumber().ToString());
           
           

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }

}
