using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using SDC_Application.BL;
using SDC_Application.DL;
namespace SDC_Application.AL
{
    public partial class frmPictureIndexMain : Form
    {
        picThumbnail pb;
DL.Database obj = new Database();
SqlCommand insertCommand;
        //List<Proc_Entry_PatwarCircles_Result> PC = new List<Proc_Entry_PatwarCircles_Result>();
        //List<Proc_Entry_Qanoongois_Result> Qn = new List<Proc_Entry_Qanoongois_Result>();
        //List<Proc_Get_Moza_by_PatwarCircle_Result> moza = new List<Proc_Get_Moza_by_PatwarCircle_Result>();
        //List<proc_Get_DocumentTypes_Result> DT = new List<proc_Get_DocumentTypes_Result>();
        //ClientServiceClient client = new ClientServiceClient();
        List<string> Files = new List<string>();
        List<KhataPicture> KhataPics = new List<KhataPicture>();
        fileIndexing fi = new fileIndexing();

        DataTable PC = new DataTable();
        DataTable Qn = new DataTable();
        DataTable moza = new DataTable();
        DataTable DT = new DataTable();

        //Create a List of Khata No Index that will hold our split Values
        List<KhataNoIndex> Khatas = new List<KhataNoIndex>();
        
        int _thesilId;
        public int ThesilId
        {
            get
            {
                return _thesilId;
            }

            set
            {
                _thesilId = value;
            }
        }
        
        public frmPictureIndexMain()
        {
            InitializeComponent();
        }

        void pb_ThumbnailClick(object sender, MyEventArgs e)
        {
            picThumbnail p = sender as picThumbnail;
            this.pbImageViewer.Image = Image.FromFile(p.ThumbnailFile);
        }


        private void LoadFiles()
        {
            this.folderBrowserDialog1.ShowDialog();
            this.SuspendLayout();
            try
            {

                foreach (string f in Directory.GetFiles(this.folderBrowserDialog1.SelectedPath))
                {
                    FileInfo fi = new FileInfo(f);
                    if (fi.Extension == ".jpg" || fi.Extension == ".JPG")
                    {
                        pb = new picThumbnail();
                        pb.ThumbnailFile = fi.FullName;
                        pb.FileName = fi.Name;
                        pb.ThumbnailImagePath = Path.GetDirectoryName(fi.FullName);
                        pb.Dock = DockStyle.Fill;
                        pb.ThumbnailClick -= new ThumbnailClickHandler(pb_ThumbnailClick);
                        pb.ThumbnailClick += new ThumbnailClickHandler(pb_ThumbnailClick);
                        this.tblThumbnails.Controls.Add(pb);
                        Files.Add(fi.Name);
                    }
                }
                this.ResumeLayout();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private static List<string> GetAllFiles(string directory)
        {
            List<string> FilesList = new List<string>();
            FilesList= Directory.GetFiles(directory, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
            if (FilesList.Count <= 0)
            {
                FilesList=Directory.GetFiles(directory, "*.JPG", SearchOption.TopDirectoryOnly).ToList();
            }
            return FilesList;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        #region Form Load Event

        private void frmPictureIndexMain_Load(object sender, EventArgs e)
        {
            //fi.ThesilId = ThesilId;
            this.fillQanoongoi();
            //this.fillPatwarCircle();
            this.fillDocTypes();
        }

        #endregion

        #region Cutom Methods

        private void fillQanoongoi()
        {
            this.Qn = fi.GetEntryQanoonGoi(ThesilId.ToString());
            DataRow QanoonGoiRow = Qn.NewRow();
            QanoonGoiRow["QanoongoiId"] = "0";
            QanoonGoiRow["QanoongoiNameUrdu"] = " - قانون گوئی چنیے - ";
            Qn.Rows.InsertAt(QanoonGoiRow, 0);
            cboQanoongoi.DataSource = Qn;
            cboQanoongoi.DisplayMember = "QanoongoiNameUrdu";
            cboQanoongoi.ValueMember = "QanoongoiId";
            cboQanoongoi.SelectedValue = 0;
        }


        private void fillPatwarCircle(string qanongoiId)
        {
            this.PC = fi.GetEntryPatwarCircle(qanongoiId);
            DataRow PCRow = PC.NewRow();
            PCRow["PatwarCircleId"] = "0";
            PCRow["PatwarCircleNameUrdu"] = " - پٹوار سرکل چنیے - ";
            PC.Rows.InsertAt(PCRow, 0);
            cboPatwarCicrl.DataSource = PC;
            cboPatwarCicrl.DisplayMember = "PatwarCircleNameUrdu";
            cboPatwarCicrl.ValueMember = "PatwarCircleId";
            cboPatwarCicrl.SelectedValue = 0;
        }

        private void fillMoza()
        {
            this.moza = fi.GetMozaByPatwarCircle(_thesilId.ToString(),cboPatwarCicrl.SelectedValue.ToString());

            DataRow mozaRow = moza.NewRow();
            mozaRow["MozaId"] = "0";
            mozaRow["MozaNameUrdu"] = " - موضع چنیے - ";
            moza.Rows.InsertAt(mozaRow, 0);
            cboVillage.DataSource = moza;
            cboVillage.DisplayMember = "MozaNameUrdu";
            cboVillage.ValueMember = "MozaId";
            cboVillage.SelectedValue = 0;
        }

        private void fillDocTypes()
        {
            this.DT = fi.GetDocumentType();
            DataRow DTRow = DT.NewRow();
            DTRow["DocumentTypeID"] = "0";
            DTRow["DocumentTypeDescription"] = " - قسم دستاویز چنیے - ";
            DT.Rows.InsertAt(DTRow, 0);
            cboDocumentType.DataSource = DT;
            cboDocumentType.DisplayMember = "DocumentTypeDescription";
            cboDocumentType.ValueMember = "DocumentTypeID";
            cboDocumentType.SelectedValue = 0;
        }

        #endregion

        #region Drop down patwar circle selection changed event

        private void cboPatwarCicrl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.fillMoza();
        }

        #endregion

        private void btnStartIndexing_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(tblThumbnails.RowCount.ToString());


//..........................Save Document Image in Database................................
        
        //    public void SaveImage( string ImgPath)
        //{
            
        //        // create table if not exists
                
        //        // Converts image file into byte[]
        //    byte[] imgData = File.ReadAllBytes(ImgPath);

        //        string insertXmlQuery = @"Insert Into [DocumentImages] (indexid,[docImage]) Values(1,@Photo)";

        //        // Insert Image Value into Sql Table by SqlParameter
        //        insertCommand = new SqlCommand(insertXmlQuery, CreateConn());
        //        SqlParameter sqlParam = insertCommand.Parameters.AddWithValue("@Photo", imgData);
        //        sqlParam.DbType = DbType.Binary;
        //        insertCommand.ExecuteNonQuery();
            
        //}

//..........................End Save Document Image................................


//----------------------------Code to Retrive Image from DB without saving on physical drive------------------------
           // SDC_Application.DL.Database db = new DL.Database();                         
           //// db.SaveImage("D:\\Desert.jpg");
           //string insertXmlQuery = "Select DocImage From [DocumentImages] Where IndexId='1'";

           //// Insert Image Value into Sql Table by SqlParameter
           //insertCommand = new SqlCommand(insertXmlQuery, Database.CreateConn());
           //  // Dim imageData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            
           //       object imgage =insertCommand.ExecuteScalar();
           //       SqlDataReader reader = insertCommand.ExecuteReader();

           //       if (reader.Read())
           //       {
           //           byte[] imgData = (byte[])reader[0];
           //           using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
           //           {
           //               ms.Write(imgData, 0, imgData.Length);
           //               //pictureBox1.BackgroundImage = Image.FromStream(ms, true);
           //               pictureBox1.Image = Image.FromStream(ms, true);
           //               pictureBox1.Refresh();

           //           }

           //       }
           //       return;

           // ------------------------- End of Image Retrival Code -------------------------------------------


            //MessageBox.Show(Files.Count.ToString());
            if (Convert.ToInt32(cboDocumentType.SelectedValue) > 0 && Convert.ToInt32(cboPatwarCicrl.SelectedValue) > 0 && Convert.ToInt32(cboQanoongoi.SelectedValue) > 0 && Convert.ToInt32(cboVillage.SelectedValue) > 0 && txtDestinationPath.Text.Trim() != "")
            {
                KhataPics.Clear();
                StringBuilder fileStringBuilder = new StringBuilder();



                this.ProgressBarStatus.Maximum = Files.Count;
                for (int x = 0; x < Files.Count; x++)
                {
                    string path = this.txtDestinationPath.Text;
                    picThumbnail tb = (picThumbnail)this.tblThumbnails.GetControlFromPosition(x, 0);


                    if (tb.isSelected == true)
                    {
                        //--
                        // add picture to stack
                        KhataPicture p = new KhataPicture();
                        p.FileName = tb.FileName;
                        // p.KhataNo = tb.DocumentNo;
                        KhataPics.Add(p);
                        //First Split Comma Seperated Values if found
                        List<string> TempFiles = new List<string>(tb.DocumentNo.Split(','));
                        for (int n = 0; n < TempFiles.Count; n++)
                        {
                            p.KhataNo = TempFiles[n].ToString();

                            string imgnum = KhataPics.Count(m => m.KhataNo == TempFiles[n].ToString()).ToString();

                            this.listBox1.Items.Add(tb.ThumbnailFile);

                            Image img = Image.FromFile(tb.ThumbnailFile);

                            //Autogenerated File Number Need to be corrected by Asim
                            string fwm = GetFileInfo(path, TempFiles[n].ToString(), imgnum, img);
                            //string fwm =  TempFiles[n].ToString()+"_"+imgnum.ToString();

                            string fn = fwm + ".jpg";
                            fwm = fwm + "\r\n source: BOR-KPK";
                            string imgWM = fwm.Replace("-", "/");
                            Image imgwm = WaterMarkedImage(img, imgWM);


                            imgwm.Save(@path + fn);
                        }

                    }

                    this.ProgressBarStatus.Value = x + 1;
                }
                this.ProgressBarStatus.Value = 0;
                this.listBox1.Items.Clear();
                MessageBox.Show("File Indexing completed successfully");
            }
            else
            {
                MessageBox.Show("Unable to start indexing!, kindly check the indexing details", "Error in Indexing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static Image WaterMarkedImage(Image image, string watermarkText)
        {
            Font font = new Font("Verdana", 46, FontStyle.Bold, GraphicsUnit.Pixel);
            //Adds a transparent watermark with an 100 alpha value.
            Color color = Color.FromArgb(255, Color.Yellow);  //Color color = Color.FromArgb(80, 0, 0, 250);
            //The position where to draw the watermark on the image
            Point pt = new Point(10, 40);
            SolidBrush sbrush = new SolidBrush(color);
            Graphics gr = null;
            try
            {
                gr = Graphics.FromImage(image);
            }
            catch
            {

                Image img1 = image;
                image = new Bitmap(image.Width, image.Height);
                gr = Graphics.FromImage(image);
                gr.DrawImage(img1, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                img1.Dispose();
            }

            gr.DrawString(watermarkText, font, sbrush, pt);

            return image;
        }
        private void btnDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            this.txtDestinationPath.Text = this.folderBrowserDialog1.SelectedPath + @"\";
            //ResetForm();
        }

        private void ResetForm()
        {
            foreach (Control ctl in this.tabPageDataSource.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox t = ctl as TextBox;
                    t.Clear();
                }
                else if (ctl.GetType() == typeof(ComboBox))
                {
                    ComboBox b = ctl as ComboBox;
                    b.SelectedIndex = 0;
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = ctl as CheckBox;
                    chk.Checked = false;
                }
            }
        }
        private string GetFileInfo(string destinationfolder, string khatano, string imagenumber,Image img)
        {
            string tehsilid = UsersManagments._Tehsilid.ToString();
            string mozaid = this.cboVillage.SelectedValue.ToString();
            string dest = destinationfolder;
            string doctypeid = this.cboDocumentType.SelectedValue.ToString();
            string KhataNo = khatano;
            string imgnum = imagenumber.ToString();
            string filename = "";
            string usr = UsersManagments.UserId.ToString();
            string usrName = "";
            byte[] imgData = imageToByteArray(img);
            string fn = fi.saveFileIndexing("-1", tehsilid, mozaid, dest, doctypeid, KhataNo, imgnum, filename, usr).ToString();
            // fn is fed to the sp as bigint where fn is string , causes the error 
            // string DI = fi.saveDocImage(fn, imgData, usr, usrName, usr, usrName).ToString();
           
            // MessageBox.Show(fn);
            return fn;
           // return DI;
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void cboQanoongoi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string qanongoId = cboQanoongoi.SelectedValue.ToString();
            this.fillPatwarCircle(qanongoId);
        }

    }
}
