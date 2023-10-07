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
    public partial class frmSDCBankreport : Form
    {
        public string ReportingFolder { get; set; }
        
        public string ReportinFolderLand { get; set; }
        string datefrom, dateto,hdr,from,to;
        string username = "Administrator";
        string password = "sdc$$mrd$$";
        AutoComplete objauto = new AutoComplete();
        public frmSDCBankreport()
        {
            InitializeComponent();
        }

        private void frmSDCBankreport_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            txthiddnPersonId.Visible = false;
            t2.Visible = false;
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            hdr = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)) + System.Environment.NewLine;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (radbank.Checked==true || radFard.Checked==true || radInti.Checked==true || radsdc.Checked==true)
            {
                MessageBox.Show("your not in raspass and radslip");
                if (chkRange.Checked == true)
                {
                    DateTime dt = Convert.ToDateTime(this.t1.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
                    DateTime dt2 = Convert.ToDateTime(this.t2.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
                    DateTime dt3 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
                    // MessageBox.Show(""+dt3);
                    if (dt > dt2 || dt > dt3)
                    {
                        MessageBox.Show("Range Date should be greater than today date");
                    }
                    else
                    {
                        datefrom = this.t1.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                        dateto = this.t2.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                        Report();
                    }
                }
                else
                {
                    datefrom = this.t1.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    dateto = datefrom;
                    Report();
                }
            }
            else if (radpass.Checked == true)
            {              
                Report();
            }
            else if(radbankslip.Checked==true)
            {
                
                DateTime dt = Convert.ToDateTime(this.dt1.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
                DateTime dt2 = Convert.ToDateTime(this.dt2.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()));
                DateTime dt3 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
                // MessageBox.Show(""+dt3);
                if (dt > dt2 || dt > dt3)
                {
                    MessageBox.Show("Range Date should be greater than today date");
                }
                else
                {
                    from = this.dt1.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    to = this.dt2.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    Report();
                }
               // Report();
            }
           
            
        }

        public void Report()
        {




            if (radbank.Checked == true)
            {

                webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_SDCBankRecipt&rs:Command=Render&rc:Parameters=Collapsed&date1=" + datefrom + "&date2=" + dateto, username, password), null, null, hdr);
                //webBrowser1.Print();
            }
            else if (radsdc.Checked == true)
            {
                webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fReport_For_Bank_SDC_Cash&rs:Command=Render&rc:Parameters=Collapsed&date1=" + datefrom + "&date2=" + dateto, username, password), null, null, hdr);
                //webBrowser1.Print();
            }
            else if (radFard.Checked == true)
            {
               // MessageBox.Show("");
                if (UsersManagments.UserName == "zakir.ali" || UsersManagments.UserName == "muhammad.kabir" || UsersManagments.UserName == "Admin")
                {
                    webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fSDC_Fard_Profarma&rs:Command=Render&rc:Parameters=Collapsed&date1=" + datefrom + "&date2=" + dateto, username, password), null, null, hdr);
                }
            }
            else if (radInti.Checked == true)
            {
                if (UsersManagments.UserName == "zakir.ali" || UsersManagments.UserName == "muhammad.kabir" || UsersManagments.UserName == "Admin")
                {
                    webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fSDC_Intiqal_Profarma&rs:Command=Render&rc:Parameters=Collapsed&date1=" + datefrom + "&date2=" + dateto, username, password), null, null, hdr);
                }
            }
            else if (radpass.Checked == true)
            {
                if (UsersManagments.UserName == "zakir.ali" || UsersManagments.UserName == "muhammad.kabir" || UsersManagments.UserName == "Admin")
                {
                    {
                        if (cmbMouza.SelectedIndex != 1 && txthiddnPersonId.Text != string.Empty)
                        {
                            int persion = Convert.ToInt32(this.txthiddnPersonId.Text.ToString());
                            int mozaid = Convert.ToInt32(this.cmbMouza.SelectedValue.ToString());
                            // webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fSDC_Passbook&rs:Command=Render&rc:Parameters=Collapsed&p="' username, password), null, null, hdr);
                            webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fPassbook&rs:Command=Render&rc:Parameters=Collapsed&mozaid=" + mozaid + "&personid=" + persion + "&kata=" + this.TxtKhatano.Text + "", username, password), null, null, hdr);
                        }
                    }
                }
            }
            else if (radbankslip.Checked == true)
            {
                string type = "Fard";
                if (cmbtype.SelectedItem == "فرد")
                {
                    type = "Fard";
                }
                else
                {
                    type = "Inteqal";
                }
                webBrowser1.Navigate(String.Format("http://{0}:{1}@mrd_sdc_svrlive:8080/ReportServer/Pages/ReportViewer.aspx?%2f" + ReportingFolder + "%2fIntiqalTaxBankChallan&rs:Command=Render&rc:Parameters=Collapsed&type=" + type + "&id=" + UsersManagments.UserId.ToString() + "&date1=" + from + "&date2=" + to, username, password), null, null, hdr);
            }
            else
            { }
        
        }
        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked == true)
            {
                t2.Visible = true;
            }
            else
            {
                t2.Visible = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuyerSearch_Click(object sender, EventArgs e)
        {
            frmSearchPerson Sp = new frmSearchPerson();
            Sp.MozaId = this.cmbMouza.SelectedValue.ToString();
            Sp.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
            Sp.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
            Sp.ShowDialog();
        }
        void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson ap = sender as frmSearchPerson;
            this.txthiddnPersonId.Text = ap.PersonId.ToString();
            this.txthiddnPersonName.Text = ap.PersonName;
           // btnFamilySelection.Visible = true;

        }

        private void radpass_CheckedChanged(object sender, EventArgs e)
        {
            if (radpass.Checked == true)
            {
                panel3.Visible =true;
                panel2.Visible = false;
                radbank.Checked = false;
                radFard.Checked = false;
                radInti.Checked = false;
                panel4.Visible = false;
                radsdc.Checked = false;
                radpass.Checked = true;

            }
            
        }

        private void radFard_CheckedChanged(object sender, EventArgs e)
        {
            if (radFard.Checked==true)
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel2.Visible = true;
            }
           

        }

        private void radsdc_CheckedChanged(object sender, EventArgs e)
        {
            if (radsdc.Checked == true)
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel2.Visible = true;
             }
        }

        private void radInti_CheckedChanged(object sender, EventArgs e)
        {
            if (radInti.Checked == true)
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel2.Visible = true;
            }

        }

        private void radbank_CheckedChanged(object sender, EventArgs e)
        {
            if (radbank.Checked == true)
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel2.Visible = true;
            }
        }

        private void radbankslip_CheckedChanged(object sender, EventArgs e)
        {
            if (radbankslip.Checked == true)
            {
            panel3.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            cmbtype.SelectedIndex = 0;
            }
        }
    }
}
