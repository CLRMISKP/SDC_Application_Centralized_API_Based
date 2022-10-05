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
    public partial class frmIntiqalTaxReport : Form
    {
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        Intiqal intiqal = new Intiqal();
        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }

      
        public string IntiqalId
        {
            get;
            set;
        }

     
        public string PersonId { get; set; }
        
        public frmIntiqalTaxReport()
        {
            InitializeComponent();
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
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Self_Get_Intiqal_Tax_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalId + "'", cmbTaxType, "TaxType", "IntiqalTaxId");
           
          
        }

        #region Fill Intiqal DropDown

        public void Fill_Intiqal_Persons()
        {
            try
            {
               cmbTaxPayer.DataSource = null;
               
                if (cmbTaxType.SelectedIndex > 0)
                {
                    objauto.FillCombo("Proc_Self_Get_Intiqal_Persons_For_Tax_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalId + "'" + ",N'" + cmbTaxType.Text + "'", cmbTaxPayer, "PersonName", "PersonId");
                    cmbTaxPayer.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Tax Taype and Person Change Event

        private void cmbTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            this.Fill_Intiqal_Persons();
        }
      
        private void cmbTaxPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PersonId = cmbTaxPayer.SelectedValue.ToString();
        }

        #endregion

        #region languaage for keypress
        private void cmbTaxType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbTaxPayer_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTaxType.SelectedIndex>0)
            {
                if (cmbTaxType.Text.Contains("گین"))
                {
                    if (cmbTaxPayer.SelectedIndex > 0)
                    {
                        ReportParameter[] rp = new ReportParameter[2];
                        rp[0] = new ReportParameter("intiqalid", this.IntiqalId);
                        rp[1] = new ReportParameter("personid", cmbTaxPayer.SelectedValue.ToString());
                        this.SetCredentials("Gain_TaxChallan", rp, false);
                    }
                    else
                    {
                        ReportParameter[] rp = new ReportParameter[2];
                        rp[0] = new ReportParameter("intiqalid", "");
                        rp[1] = new ReportParameter("personid", "");
                        this.SetCredentials("Gain_TaxChallan", rp, false);
                    }
                }
                else if(cmbTaxType.Text.Contains("ودہولڈنگ"))
                {
                    if (cmbTaxPayer.SelectedIndex > 0)
                    {
                        ReportParameter[] rp = new ReportParameter[3];
                        rp[0] = new ReportParameter("intiqalid", this.IntiqalId);
                        rp[1] = new ReportParameter("personid", cmbTaxPayer.SelectedValue.ToString());
                        rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());

                        this.SetCredentials("WH_TaxChallan", rp, false);
                    }
                    else
                    {
                        ReportParameter[] rp = new ReportParameter[3];
                        rp[0] = new ReportParameter("intiqalid", "");
                        rp[1] = new ReportParameter("personid", "");
                        rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                        this.SetCredentials("WH_TaxChallan", rp, false);
                    }
                }
                else
                {
                    if (cmbTaxPayer.SelectedIndex > 0)
                    {
                        ReportParameter[] rp = new ReportParameter[5];
                        rp[0] = new ReportParameter("p_Intiqalid", this.IntiqalId);
                        rp[1] = new ReportParameter("personId", cmbTaxPayer.SelectedValue.ToString());
                        rp[2] = new ReportParameter("taxId", cmbTaxType.SelectedValue.ToString());
                        rp[3] = new ReportParameter("taxName", cmbTaxType.Text);
                        rp[4] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());

                        this.SetCredentials("Intiqal_TaxBankChallan", rp, false);
                    }
                    else
                    {
                        ReportParameter[] rp = new ReportParameter[5];
                        rp[0] = new ReportParameter("p_Intiqalid", "");
                        rp[1] = new ReportParameter("personId", "");
                        rp[2] = new ReportParameter("taxId", "");
                        rp[3] = new ReportParameter("taxName", cmbTaxType.Text);
                        rp[4] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                        this.SetCredentials("Intiqal_TaxBankChallan", rp, false);
                    }
                }

            }
            else
            {
                MessageBox.Show("فیس برائے سیلیکٹ کریں", "ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
      

    }
}
