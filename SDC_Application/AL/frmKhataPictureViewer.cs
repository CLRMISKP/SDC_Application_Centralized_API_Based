using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using SDC_Application.DL;
using SDC_Application.BL;
using System.Data.SqlClient;

namespace SDC_Application
{
    public partial class frmKhataPictureViewer : Form
    {

        fileIndexing fi = new fileIndexing();
        DataTable ddi = new DataTable();
        DL.Database obj = new Database();
        static int i = 0;
        picThumbnail pb;
        double actualWidth;
        double actualHeight;
        Image ResetImage;

        public DataTable DtPica { get; set; }
        public string SelectPic { get; set; }

        public frmKhataPictureViewer()
        {
            InitializeComponent();
        }
        private void frmKhataPictureViewer_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            if (this.DtPica != null)
            {
                this.ddi = this.DtPica;
                //
                LoadPicturesfromIntiqalDocuments();

                //
            }
            else
            {

                this.LoadFiles(this.KhataPictures);
            }
            
            
        }

        #region Properties

        #region LoadPicturesfromIntiqalDocuments
        public void LoadPicturesfromIntiqalDocuments()
        {
            foreach (DataRow row in ddi.Rows)
            {
              
                byte[] imgData = (byte[])row["IntiqalDocImage"];
                string Page = row["IntiqalDoc_PageNo"].ToString();
                using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                {
                    ms.Write(imgData, 0, imgData.Length);
                    pb = new picThumbnail();
                    pb.ThumbnailImage = Image.FromStream(ms, true);
                    pb.Dock = DockStyle.Fill;
                    pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
                    pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
                    this.tblThumbnails.Controls.Add(pb);
                                    }

                if (SelectPic == row["IntiqalDocImageId"].ToString())
                {


                    //byte[] doc = (byte[])row["IntiqalDocImage"];
                    //MemoryStream stream = new MemoryStream(doc);
                    //Image RetrunImgae = Image.FromStream(stream);
                 
                    pbImageViewer.Image = pb.ThumbnailImage;
                    pbImageViewer.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                  

                    //byte[] doc = (byte[])ddi.Rows[0]["IntiqalDocImage"];
                    //MemoryStream stream = new MemoryStream(doc);
                    //Image RetrunImgae = Image.FromStream(stream);
                    //pbImageViewer.Image = RetrunImgae;
                    //pbImageViewer.SizeMode = PictureBoxSizeMode.CenterImage;
                    
                    pbImageViewer.Image = pb.ThumbnailImage;
                    pbImageViewer.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }
        #endregion
        public List<KhataNoIndex> KhataPictures { get; set; }
        #endregion

        #region Load Files



        public void LoadFiles(List<KhataNoIndex> KhataPics)
        {

            //for (int x = 0; x < KhataPics.Count; x++)
            //{
            //    pb = new picThumbnail();
            //    pb.ThumbnailFile = KhataPics[x].DocumentNo.ToString();
            //    pb.FileName = KhataPics[x].DocumentNo.ToString();
            //    pb.ThumbnailImagePath = @"C:\\Users\\Yousaf Gill\\Desktop\\Output\\";
            //    pb.Dock = DockStyle.Fill;
            //    pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
            //    pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
            //    this.tblThumbnails.Controls.Add(pb);


                //----------------------------Code to Retrive Image from DB without saving on physical drive------------------------ 
                this.ddi = fi.GetDocumentImage();     
                foreach (DataRow row in ddi.Rows)
                {

                        byte[] imgData = (byte[])row["DocImage"];
                        using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                        {
                            ms.Write(imgData, 0, imgData.Length);
                            pb = new picThumbnail();
                            pb.ThumbnailImage = Image.FromStream(ms, true);
                            pb.Dock = DockStyle.Fill;
                            pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
                            pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
                            this.tblThumbnails.Controls.Add(pb);

                        }

                    // ------------------------- End of Image Retrival Code -------------------------------------------
                }
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
        //    this.ResumeLayout();
        //}

        void pb_ThumbnailClick(object sender, MyEventArgs e)
        {
            picThumbnail p = sender as picThumbnail;
            this.pbImageViewer.Image = p.ThumbnailImage;
            ResetImage = pbImageViewer.Image;
            actualWidth = this.pbImageViewer.Width;
            actualHeight = this.pbImageViewer.Height;
            btnReset_Click(sender, e);
       }

        #endregion

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            //
            Image img;
            img = ResetImage;
            if (img!=null)
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
            img = ResetImage ;
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

       
    }
}
