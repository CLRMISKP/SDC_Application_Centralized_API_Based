using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
namespace SDC_Application.AL
{
    public partial class frmSetPath : Form
    {
        public frmSetPath()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            try
            {
                if (folderBrowserDialog1.SelectedPath!=null)
                {
                   this.txtPath.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\" ;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please select a Folder");
            }
        }

        private void frmSetPath_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            this.txtPath.Text = ImagePathManger.ImageLocation;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim() != "")
            {
                ImagePathManger.ImageLocation = this.txtPath.Text;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
