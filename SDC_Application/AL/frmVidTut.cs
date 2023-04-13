using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmVidTut : Form
    {
        public frmVidTut()
        {
            InitializeComponent();
        }

        private void lbRHZ_Khata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wb.Url = new Uri("https://youtu.be/pxUvTMwXGWM");
        }
    }
}
