using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application
{
    public partial class frmNewIntiqalDoc : Form
    {
        public string action_type {
            get; set; 
        }
        public string pagno
        {
            get;
            set;
        }
        public bool btn
        {
            get;
            set;
        }
        public frmNewIntiqalDoc()
        {
            InitializeComponent();
        }

        private void frmNewIntiqalDoc_Load(object sender, EventArgs e)
        {
            radLowerButton.Checked = false;
            radLowerButton.Checked = false;
            radInBetweenButton.Checked = false;
            txtPageNo.Text = "";
            txtPageNo.Visible = false;
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {

            if (radLowerButton.Checked)
            {
                action_type = radLowerButton.Text;
            }
            if (this.radUpperButton.Checked)
            {
                action_type = radUpperButton.Text;
            }
            if (radInBetweenButton.Checked)
            {
                action_type = radInBetweenButton.Text;
                pagno = this.txtPageNo.Text;
            }
            if (radInBetweenButton.Checked == true && txtPageNo.Text != "")
            {
                btn = true;
                this.Close();
            }
           
            if (this.radUpperButton.Checked || radLowerButton.Checked)
            {
                btn = true;
                this.Close();
            }
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            radLowerButton.Checked = false;          
            radLowerButton.Checked=false;   
            radInBetweenButton.Checked=false;
            btn = false;
            this.Close();

           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radInBetweenButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radInBetweenButton.Checked == true)
            { txtPageNo.Visible = true; }
            else
            {
                txtPageNo.Text = "";
                txtPageNo.Visible = false;
            }
        }

        private void radInBetweenButton_Click(object sender, EventArgs e)
        //{
        {
         
        }
    }
}
