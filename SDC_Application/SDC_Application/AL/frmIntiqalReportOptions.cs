using SDC_Application.Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmIntiqalReportOptions : Form
    {
        #region Class Veriables
        public string  intiqalId { get; set; }
        public bool khanaKasht { get; set; }
        public bool khanaMalkiat { get; set; }
        public bool KhanaMalkiatKasht { get; set; }

        #endregion
        public frmIntiqalReportOptions()
        {
            InitializeComponent();
        }

        private void frmIntiqalReportOptions_Load(object sender, EventArgs e)
        {
            rbKhanaMalkiat.Checked = khanaMalkiat;
            rbKhanaKaasht.Checked = khanaKasht;
            rbKhanaMalkiatKasht.Checked = KhanaMalkiatKasht;
        }

        private void rbAttestation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAttestation.Checked)
            { this.groupBox1.Visible = true; }
            else
            { this.groupBox1.Visible = false; }
        }

        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                if(rbIntitialInfo.Checked)
                {
                    frmSDCReportingMain rptMain = new frmSDCReportingMain();
                    rptMain.IntiqalId = this.intiqalId;
                    UsersManagments.check = 4;
                    rptMain.ShowDialog();
                }
                else
                {
                    if(rbKhanaMalkiat.Checked)
                    {
                        frmSDCReportingMain rptMain = new frmSDCReportingMain();
                        rptMain.IntiqalId = this.intiqalId;
                        UsersManagments.check = 14;
                        rptMain.ShowDialog();
                    }
                    else if(rbKhanaKaasht.Checked)
                    {
                        frmSDCReportingMain rptMain = new frmSDCReportingMain();
                        rptMain.IntiqalId = this.intiqalId;
                        UsersManagments.check = 15;
                        rptMain.ShowDialog();
                    }
                    else if(rbKhanaMalkiatKasht.Checked)
                    {
                        frmSDCReportingMain rptMain = new frmSDCReportingMain();
                        rptMain.IntiqalId = this.intiqalId;
                        UsersManagments.check = 16;
                        rptMain.ShowDialog();
                    }
                    else if(rbWerasath.Checked)
                    {
                        frmSDCReportingMain rptMain = new frmSDCReportingMain();
                        rptMain.IntiqalId = this.intiqalId;
                        UsersManagments.check = 17;
                        rptMain.ShowDialog();
                    }
                    else if(rbPartition.Checked)
                    {
                        frmSDCReportingMain rptMain = new frmSDCReportingMain();
                        rptMain.IntiqalId = this.intiqalId;
                        UsersManagments.check = 18;
                        rptMain.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
