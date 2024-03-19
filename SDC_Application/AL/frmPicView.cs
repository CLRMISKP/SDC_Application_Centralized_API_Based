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
    public partial class frmPicView : Form
    {

        public Image img;
        public string name;
        public frmPicView()
        {
            InitializeComponent();
        }

        private void frmPicView_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = img;
            pictureBox1.Image = img.GetThumbnailImage(500, 400, null, IntPtr.Zero);
            this.Text = name;
        }
    }
}
