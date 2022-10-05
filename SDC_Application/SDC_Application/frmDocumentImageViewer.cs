using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandInfo.ControlsLib;
using SDC_Application.Classess;
using System.Drawing.Drawing2D;

namespace SDC_Application
{
    public partial class frmDocumentImageViewer : Form
    {
        picThumbnail pb;
        double actualWidth;
        double actualHeight;
        Image ResetImage;

        #region Properties

        public List<KhataNoIndex> KhataPictures { get; set; }

        #endregion

        public frmDocumentImageViewer()
        {
            InitializeComponent();
        }

        #region Load Files

        public void LoadFiles(List<KhataNoIndex> KhataPics)
        {

            for (int x = 0; x < KhataPics.Count; x++)
            {
                pb = new picThumbnail();
                pb.ThumbnailFile = KhataPics[x].DocumentNo.ToString();
                pb.FileName = KhataPics[x].DocumentNo.ToString();
                pb.ThumbnailImagePath = @"C:\\Users\\Yousaf Gill\\Desktop\\Output\\";
                pb.Dock = DockStyle.Fill;
                pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
                pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
                this.tblThumbnails.Controls.Add(pb);
            }
            //foreach (string f in Directory.GetFiles(this.folderBrowserDialog1.SelectedPath))
            //{
            //    FileInfo fi = new FileInfo(f);
            //    if (fi.Extension == ".jpg")
            //    {
            //        pb = new picThumbnail();
            //        pb.ThumbnailFile = fi.FullName;
            //        pb.FileName = fi.Name;
            //        pb.ThumbnailImagePath = Path.GetDirectoryName(fi.FullName);
            //        pb.Dock = DockStyle.Fill;
            //        pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
            //        pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
            //        this.tblThumbnails.Controls.Add(pb);
            //        Files.Add(fi.Name);
            //    }
            //}
            this.ResumeLayout();
        }

        void pb_ThumbnailClick(object sender, MyEventArgs e)
        {
            picThumbnail p = sender as picThumbnail;
            this.pbImageViewer.Image = Image.FromFile(p.ThumbnailFile);
            ResetImage = pbImageViewer.Image;
            actualWidth = this.pbImageViewer.Width;
            actualHeight = this.pbImageViewer.Height;
            //this.pbImageViewer.Dock = DockStyle.Fill;
            btnReset_Click(sender, e);
        }
        #endregion

        private void btnZoomout_Click(object sender, EventArgs e)
        {
            Image img;
            img = this.pbImageViewer.Image;
            if (img != null)
            {
                double zoom = 50.0 / 100.0;
                Bitmap bmp = new Bitmap(img, Convert.ToInt32(pbImageViewer.Width * zoom), Convert.ToInt32(pbImageViewer.Height * zoom));
                Graphics g = Graphics.FromImage(bmp);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                pbImageViewer.Image = bmp;
                img = pbImageViewer.Image;

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Image img;
            img = ResetImage;
            if (img != null)
            {
                //double zoom = 150.0 / 100.0;
                Bitmap bmp = new Bitmap(img, Convert.ToInt32(actualWidth), Convert.ToInt32(actualHeight));
                Graphics g = Graphics.FromImage(bmp);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                pbImageViewer.Image = bmp;
                img = pbImageViewer.Image;
                pbImageViewer.Dock = DockStyle.Fill;

            }
        }

        private void frmDocumentImageViewer_Load(object sender, EventArgs e)
        {
            this.LoadFiles(this.KhataPictures);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            //
            Image img;
            img = ResetImage;
            if (img != null)
            {
                double zoom = 150.0 / 100.0;
                Bitmap bmp = new Bitmap(img, Convert.ToInt32(pbImageViewer.Width * zoom), Convert.ToInt32(pbImageViewer.Height * zoom));
                Graphics g = Graphics.FromImage(bmp);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                pbImageViewer.Image = bmp;
                img = pbImageViewer.Image;
                pbImageViewer.Dock = DockStyle.None;

            }
        }
    }
}
