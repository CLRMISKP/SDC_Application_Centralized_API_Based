using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using System.IO;
using System.Drawing.Drawing2D;

namespace SDC_Application.AL
{
    public partial class frmRecordVarification : Form
    {

        #region Class Variables

        public string  TokenId { get; set;}
        public string TokenServiceId { get; set; }
        public string MozaId { get; set; }
        public string KhattaId { get; set; }
        public List<KhataNoIndex> KhataPictures { get; set; }
        List<IntiqalFB> IntnFB = new List<IntiqalFB>();

        picThumbnail pb;
        double actualWidth;
        double actualHeight;
        Image ResetImage;

        BL.frmToken objDb=new BL.frmToken();
            		 
	    #endregion

        #region Form Initialization

        public frmRecordVarification()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmRecordVarification_Load(object sender, EventArgs e)
        {
            this.FillGridviewKhattas();
        }

        #endregion

        #region Get Service Type By TokenId

        private string GetServiceType()
        {
            string serviceType = "0";
            DataTable dtToken = new DataTable();
            dtToken = objDb.filldatatable_from_storedProcedure("Proc_Get_SDC_TokenService_By_TokenId "+TokenId);
            if (dtToken.Rows.Count > 0)
            {
                serviceType = dtToken.Rows[0]["ServiceTypeName_Eng"].ToString();
            }
            return serviceType;
        }

        #endregion

        #region Get Khattajat for Verification

        private void FillGridviewKhattas()
        {
            try
            {
                DataTable dt = new DataTable();
                string ServiceType=this.GetServiceType();
                if (ServiceType != "0" && ServiceType == "Fard")
                {
                    dt = objDb.filldatatable_from_storedProcedure("Proc_Get_SDC_FardKhatasByTokenId_Verif " + (this.TokenId != null ? this.TokenId : "0"));

                    this.GridviewKhattajat.DataSource = dt;
                    if (dt != null)
                    {
                        this.GridviewKhattajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                        this.GridviewKhattajat.Columns["TotalParts"].HeaderText = "کل حصے";
                        this.GridviewKhattajat.Columns["Khata_Total_Area"].HeaderText = "کل رقبہ";
                        this.GridviewKhattajat.Columns["PVKhataRecId"].Visible = false;
                        this.GridviewKhattajat.Columns["PVKhataSeqNo"].Visible = false;
                        this.GridviewKhattajat.Columns["KhattaId"].Visible = false;
                    }
                }
                else if (ServiceType != "0" && ServiceType != "Fard")
                {
                    dt = objDb.filldatatable_from_storedProcedure("Proc_Get_SDC_IntiqalKhatasByTokenId " + (this.TokenId != null ? this.TokenId : "0"));

                    this.GridviewKhattajat.DataSource = dt;
                    if (dt != null)
                    {
                        this.GridviewKhattajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                        this.GridviewKhattajat.Columns["TotalParts"].HeaderText = "کل حصے";
                        this.GridviewKhattajat.Columns["Khata_Total_Area"].HeaderText = "کل رقبہ";
                        this.GridviewKhattajat.Columns["IntiqalKhataRecId"].Visible = false;
                        this.GridviewKhattajat.Columns["KhattaId"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }

	    #endregion

        #region GridviewKhatta Cell Content Click Event

        private void GridviewKhattajat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridView g = sender as DataGridView;
                // Load khatta Images for the Selected Record.
                string khattaNo = g.Rows[e.RowIndex].Cells["KhataNo"].Value != null ? g.Rows[e.RowIndex].Cells["KhataNo"].Value.ToString() : "0";
                this.KhattaId = g.Rows[e.RowIndex].Cells["KhattaId"].Value != null ? g.Rows[e.RowIndex].Cells["KhattaId"].Value.ToString() : "0";
                this.LoadKhattaPics(khattaNo);
                this.LoadKhattaIntiqalsFBs();
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["colChk"].Value = 1;
                    }
                    else
                    {
                        row.Cells["colChk"].Value = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        #endregion

        #region Load Khatta Intiqals and Fard_e_Bader List

        private void LoadKhattaIntiqalsFBs()
        {
            try
            {


                if (this.KhattaId != null && this.KhattaId != "0")
                {
                    DataTable Intiqals = new DataTable();
                    DataTable Fbs = new DataTable();
                    Intiqals = objDb.filldatatable_from_storedProcedure("proc_Get_Intiqal_List_By_KhattaId " + this.KhattaId);
                    Fbs = objDb.filldatatable_from_storedProcedure("proc_Get_FardBader_List_By_KhattaId " + this.KhattaId);
                    if (Intiqals != null)
                    {
                        foreach (DataRow dr in Intiqals.Rows)
                        {
                            IntiqalFB ifb = new IntiqalFB();
                            //listViewLinks.Items.Add(dr["IntiqalId"].ToString(),":انتقال نمبر="+ dr["IntiqalNo"].ToString(),0);
                            ifb.ItemId = dr["IntiqalNo"].ToString();
                            ifb.ItemName = "انتقال نمبر=" + dr["IntiqalNo"].ToString();
                            ifb.ItemType = "12";
                            IntnFB.Add(ifb);

                        }
                    }
                    if (Fbs != null)
                    {
                        foreach (DataRow dr in Fbs.Rows)
                        {
                            IntiqalFB ifb = new IntiqalFB();
                            //listViewLinks.Items.Add(dr["FB_ID"].ToString(), ":فرد بدر نمبر=" + dr["FB_DocumentNo"].ToString(), 0);
                            ifb.ItemId = dr["FB_DocumentNo"].ToString();
                            ifb.ItemName = "فرد بدر نمبر=" + dr["FB_DocumentNo"].ToString();
                            ifb.ItemType = "13";
                            IntnFB.Add(ifb);

                        }
                    }

                    listBoxlinks.DataSource = IntnFB;
                    if (IntnFB != null)
                    {
                        listBoxlinks.DisplayMember = "ItemName";
                        listBoxlinks.ValueMember = "ItemId";
                    }                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        #endregion

        #region Load Khatta Pictures

        private void LoadKhattaPics(string khattaNo)
        {
            if (this.MozaId != null && this.MozaId != "0")
            {
                if (ImagePathManger.ImageLocation == null)
                {
                    frmSetPath f = new frmSetPath();
                    f.ShowDialog();
                }
                List<KhataNoIndex> KhataPics = new List<KhataNoIndex>();
                DataTable dt = new DataTable();
                dt = objDb.filldatatable_from_storedProcedure("Proc_Get_IndexedFiles_by_Khata " + this.MozaId + ",'" + khattaNo+"'");
                if (ImagePathManger.ImageLocation != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        KhataNoIndex pic = new KhataNoIndex();
                        pic.KhataNo = dr["RecordNo"].ToString(); //d.RecordNo;
                        pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(ImagePathManger.ImageLocation, dr["FileName"].ToString() + ".jpg"));
                        //pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(q.DestinationFolder, q.FileName + ".jpg"));
                        //MessageBox.Show(pic.DocumentNo);
                        KhataPics.Add(pic);
                    }
                }

                if (dt.Rows.Count > 0 && ImagePathManger.ImageLocation != null)
                {
                    //Load Pics
                    //frmKhataPictureViewer fv = new frmKhataPictureViewer();
                    //fv.KhataPictures = KhataPics;
                    //fv.Show();
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
                    this.ResumeLayout();

                }
                else if (dt.Rows.Count > 0 && ImagePathManger.ImageLocation == null)
                {
                    MessageBox.Show("اس کھاتے کی انڈکسڈ دستاویز کی جگہ تعین نہیں ");
                }
                else
                {
                    MessageBox.Show("اس کھاتے کی انڈکسڈ دستاویز موجود نہیں");
                }
               

            }
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

        #region Zoom Buttons Click Events

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


        #endregion

        #region List Box Links click event

        private void listBoxlinks_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listBoxlinks.SelectedIndex >= 0)
                {
                    string docId = listBoxlinks.SelectedValue.ToString();
                    string docType= IntnFB.Where(panel1=>panel1.ItemId==listBoxlinks.SelectedValue.ToString()).FirstOrDefault().ItemType;
                    DataTable dt = objDb.filldatatable_from_storedProcedure("Proc_Get_FileIndexingRecords_SDC " + this.MozaId + ", " + docType + "," + docId);
                    if (dt != null)
                    {
                        if (ImagePathManger.ImageLocation == null)
                        {
                            frmSetPath f = new frmSetPath();
                            f.ShowDialog();
                        }
                        List<KhataNoIndex> KhataPics = new List<KhataNoIndex>();
                        KhataPics.Clear();
                        //string[] khattaNo = txtKhatatNo.Text.Trim().Split('/');
                        if (ImagePathManger.ImageLocation != null)
                        {

                            foreach (DataRow  q in dt.Rows)
                            {
                                KhataNoIndex pic = new KhataNoIndex();
                                pic.KhataNo = q["RecordNo"].ToString();
                                pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(ImagePathManger.ImageLocation, q["FileName"].ToString() + ".jpg"));
                                //pic.DocumentNo = @"" + Path.GetFullPath(Path.Combine(q.DestinationFolder, q.FileName + ".jpg"));
                                //MessageBox.Show(pic.DocumentNo);
                                KhataPics.Add(pic);
                            }
                        }
                        if (dt.Rows.Count > 0 && ImagePathManger.ImageLocation != null)
                        {
                            frmDocumentImageViewer fv = new frmDocumentImageViewer();
                            fv.KhataPictures = KhataPics;
                            fv.Show();
                        }
                        else if (dt.Rows.Count > 0 && ImagePathManger.ImageLocation == null)
                        {
                            MessageBox.Show("اس کھاتے کی انڈکسڈ دستاویز کی جگہ تعین نہیں ");
                        }
                        else
                        {
                            MessageBox.Show("اس کھاتے کی انڈکسڈ دستاویز موجود نہیں");
                        }

                    }
                    //MessageBox.Show("Item Clicked="+IntnFB.Where(panel1=>panel1.ItemId==listBoxlinks.SelectedValue.ToString()).FirstOrDefault().ItemType+"  , Selected Value="+listBoxlinks.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
     
            }
        }

        #endregion

    }
}
