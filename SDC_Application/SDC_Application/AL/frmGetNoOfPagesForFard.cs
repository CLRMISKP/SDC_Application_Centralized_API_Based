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
    public partial class frmGetNoOfPagesForFard : Form
    {
        public int NoOfPages { get; set; }
        public frmGetNoOfPagesForFard()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		 this.NoOfPages = txtNoOfPages.Text.Trim()!=""?Convert.ToInt32(txtNoOfPages.Text.Trim()):0;
                this.Close();
	        }
	        catch (Exception ex)
	        {
		
		        MessageBox.Show(ex.Message);
	        }
           
        }

        private void frmGetNoOfPagesForFard_Load(object sender, EventArgs e)
        {
            this.txtNoOfPages.Text=UsersManagments.NoPages.ToString();
            this.txtNoOfPages.Focus();
            tooltip_for_pages();
        }

        private void txtNoOfPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }
        public void tooltip_for_pages()
        {
            toolTippages.SetToolTip(txtNoOfPages,"صفحات کی تعداد");
            toolTippages.SetToolTip(btnSave,"مخفوظ کریں");
           
        }

    }
}
