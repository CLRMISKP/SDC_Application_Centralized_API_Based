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
    public partial class frmImageViewerBrowser : Form
    {
        public string url { get; set; }
        public frmImageViewerBrowser()
        {
            InitializeComponent();
        }

        private void frmImageViewerBrowser_Load(object sender, EventArgs e)
        {
            wb.IsWebBrowserContextMenuEnabled = false;
            if (url != null)
            {
                wb.Url = new Uri(url);
            }
        }
    }
}
