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
    public partial class frmKhassraDeletionInput : Form
    {
        public bool isCompleteDelete { get; set; }
        public frmKhassraDeletionInput()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (rbCompleteDelete.Checked || rbTypeDelete.Checked)
            {
                isCompleteDelete = rbCompleteDelete.Checked ? true : false;
                this.Close();
            }
        }
    }
}
