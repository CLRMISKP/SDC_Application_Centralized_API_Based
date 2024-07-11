using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using System.Net;

namespace SDC_Application.AL
{
    public partial class frmIntiqalMissingReport : Form
    {
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        Intiqal intiqal = new Intiqal();
        DL.Database db = new DL.Database();
        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }

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

        public frmIntiqalMissingReport()
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
                rvIntiqalReport.ShowParameterPrompts = true;
            }
            rvIntiqalReport.RefreshReport();
        }

        private void frmSDCReportingMain_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            this.IntiqalId = "-1";
            this.MozaId = "-1";
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
           
          

            //if (UsersManagments.check == 14)
            //{
            //    ReportParameter[] rp = new ReportParameter[3];
            //    rp[0] = new ReportParameter("MozaId", this.MozaId);
            //    rp[1] = new ReportParameter("TokenId", this.TokenID);
            //    rp[2] = new ReportParameter("currentUser", UsersManagments.UserName);
            //    this.SetCredentials("FardForPersonalRecordTrans", rp, false);

            //}
        }

        #region Moza and Intiqal Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.Fill_Intiqal_DropDown();
        }
        #endregion

        #region languaage for keypress
        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion


        private void btnIdentifyMissMut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("کلک کرکے انتظار کرِیں OK  گمشدہ انتقالات کے شناخت میں وقت لگے گا۔");
            db.ExecUpdateStoredProcedureWithNoRet("Proc_Get_Missing_Mutations " + UsersManagments._Tehsilid.ToString());
            MessageBox.Show("گمشدہ انتقالات کی شناخت کر لی گئی ہے۔ پرنٹ بٹن کلک کریں");
        }

        private void PrintMissingMut_Click(object sender, EventArgs e)
        {
           
                ReportParameter[] rp = new ReportParameter[1];
                rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
                this.SetCredentials("Missing_Mutation", rp, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportParameter[] rp = new ReportParameter[1];
            rp[0] = new ReportParameter("TehsilId", UsersManagments._Tehsilid.ToString());
            this.SetCredentials("Locked_Khatajat", rp, false);
        }

    }
}
