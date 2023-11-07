using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions;
using System.Configuration;
using SDC_Application.Classess;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class RHZ : Form
    {
        #region Class Variables
        AutoComplete objAuto = new AutoComplete();
        public int mozaId { get; set; }

        #endregion

        #region properties

        /// <summary>
        /// get or set moza id
        /// </summary>
        public int MozaId { get; set; }

        #endregion

        public RHZ()
        {
            InitializeComponent();
        }

        private void RHZ_Load(object sender, EventArgs e)
        {
            try
            {
                objAuto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + UsersManagments.SubSdcId.ToString(), cboMoza, "MozaNameUrdu", "MozaId");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Selection change event of moza drop down
        /// <summary>
        /// enables the show buttons and assign moza id to mozaid property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbNonHeadMoza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.mozaId = Convert.ToInt32(this.cboMoza.SelectedValue.ToString());

                this.btnShowRpt.Enabled = true;
            }
            catch (Exception)
            { }
        }

        #endregion

        #region Funtion Set parameters for Report source

        /// <summary>
        /// assign database and moza parameter
        /// </summary>
        /// <param name="MozaId"></param>
        public void assignParams(int MozaId, int FromKhatta, int ToKhatta, int PageNo, bool isZereKar, string RptDb)
        {
            try
            {
                if (isZereKar)
                {
                    MainKhata_New_Sel rptKhata = new MainKhata_New_Sel();
                    //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                    string server = "172.16.100.227";
                    string db = "CLRMIS";
                    rptKhata.SetDatabaseLogon("dlis", "$$#Un#hAbItAt@@2013##", server, db);
                    rptKhata.SetParameterValue("Moza", MozaId);
                    rptKhata.SetParameterValue("From_KhataNo", FromKhatta);
                    rptKhata.SetParameterValue("To_KhataNo", ToKhatta);
                    rptKhata.SetParameterValue("StartingPageNo", PageNo);
                    crystalReportViewer1.ReportSource = rptKhata;
                }
                else
                {
                    //MainKhata_New_Sel_AmalDaramad rptKhata = new MainKhata_New_Sel_AmalDaramad();
                    ////rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", "172.88.10.6", "Peshawar");
                    //string server = ConfigurationSettings.AppSettings["server"];
                    //string db = ConfigurationSettings.AppSettings["RptDb"];
                    //rptKhata.SetDatabaseLogon("dlis", "$$UnhAbitat@@2013##", server, db);
                    //rptKhata.SetParameterValue("Moza", MozaId);
                    //rptKhata.SetParameterValue("From_KhataNo", FromKhatta);
                    //rptKhata.SetParameterValue("To_KhataNo", ToKhatta);
                    //rptKhata.SetParameterValue("StartingPageNo", PageNo);
                    //crystalReportViewer1.ReportSource = rptKhata;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnShowRpt_Click(object sender, EventArgs e)
        {
            if (this.mozaId > 0)
            {
                if (rbZereKar.Checked)
                {
                    try
                    {
                        int FromKhatta = Convert.ToInt32(txtKhattaStart.Text.Trim());
                        int ToKhatta = Convert.ToInt32(txtKhattaEnd.Text.Trim());
                        int pageNo = Convert.ToInt32(txtPageNo.Text.Trim());
                        assignParams(mozaId, FromKhatta, ToKhatta, pageNo, true, "ZereKar");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (rbAmalDaramad.Checked)
                {
                    try
                    {
                        int FromKhatta = Convert.ToInt32(txtKhattaStart.Text.Trim());
                        int ToKhatta = Convert.ToInt32(txtKhattaEnd.Text.Trim());
                        int pageNo = Convert.ToInt32(txtPageNo.Text.Trim());
                        assignParams(mozaId, FromKhatta, ToKhatta, pageNo, false, "AmalDaramad");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Moza to view the report");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
