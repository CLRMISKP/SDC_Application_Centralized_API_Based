using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Drawing2D;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using SDC_Application.DL;
using SDC_Application.BL;
using System.Data.SqlClient;

namespace SDC_Application.AL
{
    public partial class frmIntiqalDucomentViewer : Form
    {
        Intiqal Iq = new Intiqal();
        DataTable dt_GetfromDocRequired = new DataTable();
        DataTable dt_InsertedImages = new DataTable();
        datagrid_controls objDataGrid = new datagrid_controls();
        ArrayList list = new ArrayList();
        List<PictureBox> listPB = new List<PictureBox>();
        List<CheckBox> chkBoxList = new List<CheckBox>();
        List<TextBox> txtbox = new List<TextBox>();
        int check;

        private Image imgOriginal;
        public string filepath
        {
            get;
            set;
        }
        public string IntiqalDocImageID
        {
            get;
            set;
        }
        public string IntiqalDocRecId
        {
            get;
            set;
        }
        int wi;
        int hi;
        public frmIntiqalDucomentViewer()
        {
            InitializeComponent();
        }

        private void frmIntiqalDucomentViewer_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 5;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;

            // reduce flickering
            this.DoubleBuffered = true;

            if (IntiqalDocRecId != null)
            {
                DataTable RetriveImages = new DataTable();
                RetriveImages = Iq.GetInsetedDocIamges(IntiqalDocRecId);
                int Total_Records = RetriveImages.Rows.Count;

                if (RetriveImages != null)
                {

                    int count = 0;
                    foreach (DataRow row in RetriveImages.Rows)
                    {
                        string name = row["IntiqalDocImageID"].ToString();
                        byte[] doc1 = (byte[])row["IntiqalDocImage"];
                        MemoryStream stream1 = new MemoryStream(doc1);
                        Image RetrunImgae1 = Image.FromStream(stream1);
                        Call_Pictures(RetrunImgae1, name, count);
                        count++;
                    }
                    foreach (DataRow row in RetriveImages.Rows)
                    {
                        string a = row["IntiqalDocImageID"].ToString();

                        if (a == IntiqalDocImageID.ToString())
                        {

                            byte[] doc = (byte[])row["IntiqalDocImage"];
                            MemoryStream stream = new MemoryStream(doc);
                            Image RetrunImgae = Image.FromStream(stream);

                            if (pictureBox1.Width < RetrunImgae.Width && pictureBox1.Height < RetrunImgae.Height)
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                            }
                            this.Height = RetrunImgae.Height + 50;
                            this.Width = RetrunImgae.Width + 50;


                            pictureBox1.Image = RetrunImgae;
                            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                            imgOriginal = RetrunImgae;

                            break;
                        }

                    }


                }


            }
            else
            {

                pictureBox1.Image = new Bitmap(filepath);



                if (pictureBox1.Width < pictureBox1.Image.Width && pictureBox1.Height < pictureBox1.Image.Height)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                imgOriginal = pictureBox1.Image;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (this.trackBar1.Value > 0)
            {
                this.pictureBox1.Image = null;
                pictureBox1.Image = this.PictureBoxZoom(imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
            }

        }
        public Image PictureBoxZoom(Image img, Size size)
        {

            Bitmap bm = new Bitmap(imgOriginal, Convert.ToInt32((imgOriginal.Width * size.Width)), Convert.ToInt32((imgOriginal.Height * size.Height - 100)));
            Graphics grap = Graphics.FromImage(bm);
            return bm;
        }


        public void Call_Pictures(Image Imagee, string Name, int location)
        {


            PictureBox pb = new PictureBox();

            pb.Name = Name.ToString();
            pb.Size = new Size(159, 159);
            pb.Location = new Point(location * 216, 1);
            pb.BorderStyle = BorderStyle.None;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Imagee;


            //TextBox tx = new TextBox
            //{
            //    Name = list[i].ToString(),
            //    Location = new Point(i * 216, 30),
            //    Size = new Size(60, 22)
            //};





            this.listPB.Add(pb);

            pb.Click += new EventHandler(pb_Click);



            foreach (PictureBox p in listPB)
            {


                this.panel1.Controls.Add(p);



            }

            //foreach (TextBox text in txtbox)
            //{
            //    this.panel2.Controls.Add(text);

            //}


        }

        void pb_Click(object sender, EventArgs e)
        {

            if (sender is PictureBox)
            {
                PictureBox pb1 = (PictureBox)sender;
                //MessageBox.Show(pb1.Name + " was clicked!");

                pictureBox1.Image = pb1.Image;
                // pictureBox1.Size = pictureBox1.Image.Size;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            }

        }
    }
}
