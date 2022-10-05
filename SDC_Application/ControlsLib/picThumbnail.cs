#region Using Directives
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace LandInfo.ControlsLib
{
    #region Delegates
    public delegate void ThumbnailClickHandler(object sender, MyEventArgs e);
    #endregion
    public partial class picThumbnail : UserControl
    {
        #region Constructor
        public picThumbnail()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string ThumbnailImagePath { get; set; }
        private Image thumbnailimage;

        public Image ThumbnailImage
        {
            get
            {
                return thumbnailimage;
            }
            set
            {
                thumbnailimage = value;
                this.pbThumbnail.Image = value;
            }
        }
        private string thumbnailfile;

        public string ThumbnailFile
        {
            get
            {
                return thumbnailfile;
            }
            set
            {
                thumbnailfile = value;
                Image img = Image.FromFile(value);
                Bitmap bmp = new Bitmap(img, 255, 255);
                this.pbThumbnail.Image = bmp;
                img = null;
                bmp = null;
            }
        }
        private bool isselected;

        public bool isSelected
        {
            get
            {
                return isselected;
            }
            set
            {
                isselected = value;
                this.chkSelect.Checked = value;
            }
        }
        private string filename;

        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                this.lblFileName.Text = value;
            }
        }
        private string documentno;

        public string DocumentNo
        {
            get
            {
                return documentno;
            }
            set
            {
                documentno = value;
                this.txtDocumentNo.Text = value;
            }
        }

        #endregion

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.isSelected = this.chkSelect.Checked;
        }

        #region Event Members

        public event ThumbnailClickHandler ThumbnailClick;

        #endregion

        #region virtual Events
        protected virtual void OnThumbnailClick(MyEventArgs e)
        {
            ThumbnailClick(this, e);
        }

        #endregion

        #region Routed Events

        private void pbThumbnail_Click(object sender, EventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnThumbnailClick(x);
        }
        private void txtDocumentNo_Enter(object sender, EventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnThumbnailClick(x);
        }
        #endregion

        private void txtDocumentNo_TextChanged(object sender, EventArgs e)
        {
            if (txtDocumentNo.Text == string.Empty)
            {
                this.chkSelect.Checked = false;
            }
            else
            {
                this.chkSelect.Checked = true;
                documentno = this.txtDocumentNo.Text;
            }
        }

        private void chkSelect_Enter(object sender, EventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnThumbnailClick(x);
        }


    }
}