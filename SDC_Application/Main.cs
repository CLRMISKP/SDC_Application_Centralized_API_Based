using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SDC_Application.AL;
using System.Windows.Forms;
using SDC_Application.Classess;

namespace SDC_Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public bool IsFrmOpen(string f_Name)
        {
        bool isOpen = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == f_Name)
                {
                    
                    form.Activate();
                    isOpen = true;
                }
            }
            return isOpen;
        }
        private void menuRegestration_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmToken");
            if (!isOpen)
            {
                frmToken token = new frmToken();
                try
                {
                    token.MdiParent = this;
                    token.WindowState = this.WindowState;
                    //token.Dock = DockStyle.Fill;
                    token.Show();

                }
                catch (Exception ex)
                {
                    token.Dispose();
                }
            }
        }

        private void menuSearchToken_Click(object sender, EventArgs e)
       {
        //    bool isOpen = IsFrmOpen("frmSearch");
        //      if (!isOpen)
        //      {
        //          frmSearch token = new frmSearch();
        //          try
        //          {
        //              token.MdiParent = this;
        //              token.Dock = DockStyle.Fill;
        //              token.Show();

        //          }
        //          catch (Exception ex)
        //          {
        //              token.Dispose();
        //          }
        //      }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bool isOpen = IsFrmOpen("Form1");
            //if (!isOpen)
            //{
            //    Form1 token = new Form1();
            //    try
            //    {
            //        token.MdiParent = this;
            //        token.Dock = DockStyle.Fill;
            //        token.Show();

            //    }
            //    catch (Exception ex)
            //    {
            //        token.Dispose();
            //    }
            //}
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("کیا اپ اپلیکیشن بند کرنا چہاتے ہیں:::::", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
               
            }
            else
            {
                
            }
        }

        private void نیارسیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmVoucher");
            if (!isOpen)
            {
                frmVoucher token = new frmVoucher();
                try
                {
                    token.MdiParent = this;
                    token.WindowState = this.WindowState;
                   // token.Dock = DockStyle.Fill;
                    token.Show();

                }
                catch (Exception ex)
                {
                    token.Dispose();
                }
            }
        }

        private void rptDatetoDate_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("Reports");
            if (!isOpen)
            {
                Reports token = new Reports();
                try
                {
                    token.MdiParent = this;
                    token.WindowState = this.WindowState;
                 //  token.Dock = DockStyle.Fill;
                    token.Show();

                }
                catch (Exception ex)
                {
                    token.Dispose();
                }
            }
        }

        private void linkLabelMoza_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UsersManagments._Tehsilid = 19;
                frmMozaSelection f = new frmMozaSelection();
                f.ShowDialog();
                if (UsersManagments.MozaId == 0)
                {
                    this.Close();
                }
                else
                {
                    this.txtMozaID.Text = UsersManagments.MozaId.ToString();
                    this.lblMozaName.Text = UsersManagments.MozaName;
                }
                //this.kashtkaran = client.GetAfraadListByMozaByTypeByPersonName(CurrentUser.MozaId, 2, "").ToList();
                //this.filtered = client.GetAfraadListByMozaByTypeByPersonName(CurrentUser.MozaId, 2, "").ToList();
                //this.GetSearchedAfradListBindingSource.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ReciptMenu_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmRecipt");
            if (!isOpen)
            {
                frmRecipt frmRecipt = new frmRecipt();
                try
                {
                    frmRecipt.MdiParent = this;
                    frmRecipt.WindowState = this.WindowState;
                   // frmRecipt.Dock = DockStyle.Fill;
                    frmRecipt.Show();

                }
                catch (Exception ex)
                {
                    frmRecipt.Dispose();
                }
            }
        }

        private void mnuMalikKhattasForFard_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSearchPersonByMoza");
            if (!isOpen)
            {
                frmSearchPersonByMoza spm = new frmSearchPersonByMoza();
                try
                {
                    spm.MdiParent = this;
                    spm.WindowState = this.WindowState;
                    // frmRecipt.Dock = DockStyle.Fill;
                    spm.Show();

                }
                catch (Exception ex)
                {
                    spm.Dispose();
                }
            }
        }

        
    }
}
