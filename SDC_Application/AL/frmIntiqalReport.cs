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
    public partial class frmIntiqalReport : Form
    {
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        Intiqal intiqal = new Intiqal();
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
        
        public frmIntiqalReport()
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

        #region Fill Intiqal DropDown

        public void Fill_Intiqal_DropDown()
        {
            try
            {
                this.MozaId = cmbMouza.SelectedValue.ToString();
                DataTable dtIntiqalNo = new DataTable();
                dtIntiqalNo = intiqal.GetintiqalByMozaIdSelf(cmbMouza.SelectedValue.ToString());
                DataRow IntiqalNo = dtIntiqalNo.NewRow();
                IntiqalNo["IntiqalId"] = "0";
                IntiqalNo["IntiqalNo"] = " - انتخاب کرِیں - ";
                dtIntiqalNo.Rows.InsertAt(IntiqalNo, 0);
                cmbIntiqalNo.DataSource = dtIntiqalNo;
                cmbIntiqalNo.DisplayMember = "IntiqalNo";
                cmbIntiqalNo.ValueMember = "IntiqalId";
                cmbIntiqalNo.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Moza and Intiqal Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Intiqal_DropDown();
        }

        private void cmbIntiqalNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.IntiqalId = cmbIntiqalNo.SelectedValue.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.IntiqalId != string.Empty && this.IntiqalId != "-1" && this.MozaId!= string.Empty && this.MozaId!="-1")
            {

                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("IntiqalId", this.IntiqalId);
                rp[1] = new ReportParameter("userId", UsersManagments.UserId.ToString());
                rp[2] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());

                if (rbMalkiat.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Baeh_ADC", rp, false);
                }
                else if (rbKasht.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaKasht", rp, false);
                }
                else if (rbTaqseem.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Baeh_ADC_Taqseem", rp, false);
                }
                else if (rbWirasat.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Warasat", rp, false);
                }
                else if (rbMalkiatKasht.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaMalkiatKasht", rp, false);
                }

                else if (rbIntiqalOldType.Checked)
                {
                    this.SetCredentials("IntiqalMain", rp, false);
                }
                else if (rbMalkiatToKasht.Checked)
                {
                    this.SetCredentials("IntiqalMainPart_Baeh_ADC_KhanaKasht_To_Malkiat", rp, false);
                }

            }
        }

    }
}
