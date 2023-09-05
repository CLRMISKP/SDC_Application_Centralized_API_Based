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
using System.Drawing.Imaging;
using System.Diagnostics;


namespace SDC_Application.AL
{
    public partial class frmDucomentRecievedForScan : Form
    {
        #region Variables
        Intiqal Iq = new Intiqal();
        DataTable dt_GetfromDocRequired = new DataTable();
        DataTable dt_InsertedImages = new DataTable();
        datagrid_controls objDataGrid = new datagrid_controls();
        BL.frmToken objbusines = new BL.frmToken();

        string SelectedRow = null;
        int SelectedIndex;
        string action_type = null;
        string pagno = null;
        int rownumber=0;
        ArrayList list = new ArrayList();
        string ToSaveFileTo = "";
        public string FileType { get; set; }
        public bool Cancelled { get; set; }
        public bool Pending { get; set; }

        public string IntiqalId
        {
            get;
            set;
        }

        public byte[] ReceivedImage { get; set; }
        #endregion

        public frmDucomentRecievedForScan()
        {
            InitializeComponent();
        }

        #region Load form
        private void frmDucomentRecievedForScan_Load(object sender, EventArgs e)
        {
            btnNewDoc.Enabled = false;

            DataGridViewColumn cmd3 = grdScanedDocStatus.Columns["PageNo"];
            cmd3.Width = 20;
            DataGridViewColumn cmd = grdScanedDocStatus.Columns["PictureLoad"];
            cmd.Width = 40;
            DataGridViewColumn cmd5 = grdScanedDocStatus.Columns["DcumentName"];
            cmd5.Width = 40;
            DataGridViewColumn cmd1 = grdScanedDocStatus.Columns["Delete"];
            cmd1.Width = 10;
            DataGridViewColumn cmd2 = grdScanedDocStatus.Columns["replace"];
            cmd2.Width = 80;
            DataGridViewColumn cmd4 = grdScanedDocStatus.Columns["insert"];
            cmd4.Width = 130; Update_Images_List();
            if (grdScannedDoc.Rows.Count > 0)
            {
            this.grdScannedDoc.Rows[0].Cells["CheckforLoad"].Value = 1;
            GetInsertedImages(grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString());
            }
            objDataGrid.Grid_Settings(grdScanedDocStatus);
        }
        #endregion

        #region Update_Required_Images_List
        public void Update_Images_List()
        {
            try
            {
                if (IntiqalId != "-1")
                {
                    // Iq.GetIntiqalDocuments_RequiredforScanning(IntiqalId);
                    dt_GetfromDocRequired = Iq.GetIntiqalDocuments_RequiredforScanning(IntiqalId);
                    ScanedPagesUpated();



                    foreach (DataGridViewRow row in grdScannedDoc.Rows)
                    {
                        DataGridViewCell cell = row.Cells["btnDialog"];//Column Index
                        cell.Value = "دستاویز منسلک کریں";
                        cell.Style.BackColor = Color.LightCyan;
                    }
                    grdScanedDocStatusInvisblecolumns(); //Grid  Details
                    grdScannedDocFill();
                    grdScanedDocStatus.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    if (grdScannedDoc.Rows.Count > 0)
                    {
                        int index = Convert.ToInt32(SelectedRow);
                        this.grdScannedDoc.Rows[index].Cells["CheckforLoad"].Value = 1;
                        this.grdScannedDoc.Rows[index].Selected = true;

                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
           
                      

        #endregion

        #region Call through update/inserted/Deleted Events
        public void ScanedPagesUpated()
        {
            try
            {
                dt_InsertedImages = Iq.GetInsertedDocumentsImage(IntiqalId);
                grdScannedDoc.DataSource = dt_GetfromDocRequired;
                for (int i = 0; i <= grdScannedDoc.Rows.Count - 1; i++)
                {
                    grdScannedDoc.Rows[i].Cells["SeqNo"].Value = i + 1;
                    string IntiqalDocRecId = grdScannedDoc.Rows[i].Cells["IntiqalDocRecId"].Value.ToString();
                    DataTable Pages = Iq.GetInsetedDocIamges(IntiqalDocRecId);
                    grdScannedDoc.Rows[i].Cells["Pages"].Value = Pages.Rows.Count;
                    grdScannedDocFill();

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region  grdScanedDocStatusInvisblecolumns 
        public void grdScanedDocStatusInvisblecolumns()
        {
            this.grdScanedDocStatus.Columns["IntiqalDocRecId_Save"].Visible = false;
            this.grdScanedDocStatus.Columns["IntiqalDocId_Save"].Visible = false;
            this.grdScanedDocStatus.Columns["IntiqalDocImageId"].Visible = false;
            this.grdScanedDocStatus.Columns["source"].Visible = false;
            this.grdScanedDocStatus.Columns["Image_Pic_DB"].Visible = false;
        }
        #endregion

        #region grdScannedDoc filling settings
        public void grdScannedDocFill()
        {
            this.grdScannedDoc.Columns["CheckforLoad"].DisplayIndex = 0;
            this.grdScannedDoc.Columns["SeqNo"].DisplayIndex = 1;
            this.grdScannedDoc.Columns["SeqNo"].HeaderText = "نمبرشمار";
            this.grdScannedDoc.Columns["IntiqalDocName_Urdu"].DisplayIndex = 2;
            this.grdScannedDoc.Columns["Pages"].DisplayIndex = 3;
         
            this.grdScannedDoc.Columns["btnDialog"].DisplayIndex = 4;
            this.grdScannedDoc.Columns["IntiqalDocName_Urdu"].HeaderText = "دستاویز کا نام";
            this.grdScannedDoc.Columns["Picture"].Visible = false;
            this.grdScannedDoc.Columns["Pages"].Visible = true;
            this.grdScannedDoc.Columns["SaveButton"].Visible = false;
            this.grdScannedDoc.Columns["IntiqalDocRecId"].Visible = false;
            this.grdScannedDoc.Columns["IntiqalDocId"].Visible = false;
            this.grdScannedDoc.Columns["Intiqalid"].Visible = false;
            this.grdScannedDoc.Columns["IntiqalNo"].Visible = false;
            this.grdScannedDoc.Columns["Path"].Visible = false;
            objDataGrid.gridControls(grdScannedDoc);
            objDataGrid.colorrbackgrid(grdScannedDoc);
            ((DataGridViewImageColumn)this.grdScannedDoc.Columns["Picture"]).DefaultCellStyle.NullValue = null;
            DataGridViewColumn Doc = grdScannedDoc.Columns["Picture"];
            Doc.Width = 180;
            DataGridViewColumn DocDel = grdScannedDoc.Columns["SaveButton"];
            DocDel.Width = 90;
            DataGridViewColumn btn = grdScannedDoc.Columns["btnDialog"];
            btn.Width = 180;
            DataGridViewColumn SNo = grdScannedDoc.Columns["SeqNo"];
            SNo.Width = 60;
            DataGridViewColumn loadcheck = grdScannedDoc.Columns["CheckforLoad"];
            loadcheck.Width = 60;
                                
        }
        #endregion        

        #region grdMaster ClickEvents
        private void grdScannedDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            try
            {
                if (e.RowIndex != -1)
                {

                    if (e.ColumnIndex == this.grdScannedDoc.CurrentRow.Cells["CheckforLoad"].ColumnIndex)
                    {

                        CheckUncheckLoadfromDB(sender, e);
                        SelectedRow = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                        this.SelectedIndex = grdScannedDoc.CurrentRow.Cells["CheckforLoad"].RowIndex;
                        txtSelectedIndex.Text = SelectedIndex.ToString();
                        txtSelectedRow.Text = SelectedRow;

                        int a = Convert.ToInt32(this.grdScannedDoc.CurrentRow.Cells["CheckforLoad"].Value.ToString());
                        if (a == 1)
                        {
                            string IntiqalDocRecId = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                            GetInsertedImages(IntiqalDocRecId);
                            if (grdScanedDocStatus.Rows.Count == 0)
                            {
                                btnNewDoc.Enabled = false;
                            }
                            this.grdScannedDoc.CurrentRow.Cells["CheckforLoad"].Value = 1;
                            grdScanedDocStatusInvisblecolumns();
                            grdScanedDocStatus_Formats();
                        }
                        foreach (DataGridViewRow row in grdScannedDoc.Rows)
                        {
                            DataGridViewCell cell = row.Cells["btnDialog"];//Column Index
                            // cell.Value = "دستاویز منسلک کریں";
                            cell.Style.BackColor = Color.LightCyan;
                        }

                    }



                    if (e.ColumnIndex == grdScannedDoc.CurrentRow.Cells["btnDialog"].ColumnIndex)
                    {
                        SelectedRow = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                        SelectedIndex = grdScannedDoc.CurrentRow.Cells["btnDialog"].RowIndex;
                        txtSelectedIndex.Text = SelectedIndex.ToString();
                        txtSelectedRow.Text = SelectedRow;
                        CheckUncheckLoadfromDB(sender, e);
                        LoadPictureFromDialog();
                        objDataGrid.gridControls(this.grdScanedDocStatus);
                        objDataGrid.colorrbackgrid(this.grdScanedDocStatus);
                        grdScanedDocStatus_Formats();
                        grdScanedDocStatusInvisblecolumns();
                    }


                    if (e.ColumnIndex == grdScannedDoc.CurrentRow.Cells["Pages"].ColumnIndex)
                    {
                        //SelectedRow = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                        //string docid = "0";
                        //frmKhataPictureViewerFunction(docid);
                    }

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region GetImages from Database GetInsertedImages(string IntiqalDocRecId)
        public void GetInsertedImages(string IntiqalDocRecId)
        {
            try
            {
                ((DataGridViewImageColumn)this.grdScanedDocStatus.Columns["PictureLoad"]).DefaultCellStyle.NullValue = null;
                DataTable RetriveImages = new DataTable();
                if (IntiqalId != "-1")
                {
                    //  string IntiqalDocRecIdd = IntiqalDocRecId;
                    RetriveImages = Iq.GetInsetedDocIamges(IntiqalDocRecId.ToString());

                    if (RetriveImages != null)
                    {

                        btnNewDoc.Enabled = true;
                        grdScanedDocStatus.Rows.Clear();
                        list.Clear();
                        int Total_Records = RetriveImages.Rows.Count;
                        for (int i = 0; i <= Total_Records - 1; i++)
                        {
                            grdScanedDocStatus.Rows.Add();
                            grdScanedDocStatus.Rows[i].Height = 70;

                        }
                        int count = 0;
                        foreach (DataRow row in RetriveImages.Rows)
                        {


                            byte[] doc = (byte[])row["IntiqalDocImage"];
                            try
                            {
                                MemoryStream stream = new MemoryStream(doc);
                                Image RetrunImgae = Image.FromStream(stream);
                                list.Add(RetrunImgae);
                                RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                                this.grdScanedDocStatus.Rows[count].Cells["PictureLoad"].Value = RetrunImgae;
                                
                                
                            }
                            catch (Exception ex)
                            {
                                
                                    list.Add(doc);
                                    Image RetrunImgae = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                                    this.grdScanedDocStatus.Rows[count].Cells["PictureLoad"].Value = RetrunImgae;
                            }
                            this.grdScanedDocStatus.Rows[count].Cells["PageNo"].Value = row["IntiqalDoc_PageNo"];
                            this.grdScanedDocStatus.Rows[count].Cells["IntiqalDocRecId_Save"].Value = row["IntiqalDocRecId"];
                            this.grdScanedDocStatus.Rows[count].Cells["IntiqalDocId_Save"].Value = row["IntiqalDocId"];
                            this.grdScanedDocStatus.Rows[count].Cells["IntiqalDocImageId"].Value = row["IntiqalDocImageId"];
                            this.grdScanedDocStatus.Rows[count].Cells["DcumentName"].Value = row["IntiqalDocName_Urdu"];
                            this.grdScanedDocStatus.Rows[count].Cells["Image_Pic_DB"].Value = row["IntiqalDocImage"];
                            this.grdScanedDocStatus.Rows[count].Cells["insert"].Value = 1;
                            count++;
                        }

                        grdScanedDocStatus_Formats();
                    }
                    else
                    {
                        btnNewDoc.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            }
        #endregion

        #region CheckforLoad true/false
        public void CheckUncheckLoadfromDB(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
              foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdScannedDoc.SelectedRows.Count > 0)
                    {

                        if (row.Selected)
                        {

                            row.Cells["CheckforLoad"].Value = 1;


                        }
                        else
                        {
                            row.Cells["CheckforLoad"].Value = 0;
                            
                        }
                    }
                }




        }
        #endregion

        #region Dialog from MAster Grid for New Insertion
        public void LoadPictureFromDialog()
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;";
                    dlg.Multiselect = true;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        grdScanedDocStatus.Rows.Clear();
                        list.Clear();
                        string tempFolder = System.IO.Path.GetTempPath();
                        foreach (string fileName in dlg.FileNames)
                        {

                            list.Add(fileName);
                        }

                        int last = list.Count;
                        if (last != null)
                        {
                            textBox1.Text = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                        }
                        for (int i = 0; i <= last - 1; i++)
                        {
                            string filepath = list[i].ToString();
                            grdScanedDocStatus.Rows.Add();
                            this.grdScanedDocStatus.Rows[i].Cells["IntiqalDocRecId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                            this.grdScanedDocStatus.Rows[i].Cells["IntiqalDocId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocId"].Value.ToString();
                            this.grdScanedDocStatus.Rows[i].Cells["DcumentName"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocName_Urdu"].Value.ToString();
                            this.grdScanedDocStatus.Rows[i].Cells["IntiqalDocImageId"].Value = "-1";
                            this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = list[i].ToString();
                            // this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocName_Urdu"].Value;
                            byte[] image = System.IO.File.ReadAllBytes(filepath);
                            MemoryStream stream = new MemoryStream(image);
                            try
                            {
                                Image img = Image.FromStream(stream);

                                this.grdScanedDocStatus.Rows[i].Cells["Image_Pic_DB"].Value = img;
                                ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;
                            }
                            catch (Exception ex)
                            {
                                this.grdScanedDocStatus.Rows[i].Cells["Image_Pic_DB"].Value = image;
                                //ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;
                                
                            }
                            
                        }

                        grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                        grdScannedDoc.Rows[SelectedIndex].Selected = true;


                    }


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #endregion

        #region GridDetails Settings
        public void grdScanedDocStatus_Formats()
        {
          

            for (int k = 0; k <= grdScanedDocStatus.Columns.Count - 1; k++)
            {
                grdScanedDocStatus.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
            {
                DataGridViewRow row = grdScanedDocStatus.Rows[i];
                row.Height = 70;
            }
            DataGridViewBand column = grdScanedDocStatus.Columns["insert"];
            column.ReadOnly = true;
            DataGridViewBand column2 = grdScanedDocStatus.Columns["Delete"];
            column2.ReadOnly = false;
            DataGridViewBand column3 = grdScanedDocStatus.Columns["Delete"];
            column3.ReadOnly = false;
            ((DataGridViewImageColumn)this.grdScanedDocStatus.Columns["PictureLoad"]).DefaultCellStyle.NullValue = null;     

            
        }
        #endregion

        #region Button Save Click Event
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                string action="";
                string action_for_inserting_Type = "-2";
                if (grdScanedDocStatus.Rows.Count > 0)
                {
                   
                        string IntiqalDocId ="";
                        string PageNo = "";
                        string IntiqalDocRecId = "";
                        string IntiqalDocImageId = "";
                        //string action = "";
                        using (var ms = new MemoryStream())
                        {
                            var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 0, 0, 0, 0);
                            iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                            document.Open();
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {
                             IntiqalDocId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocId_Save"].Value.ToString();
                             PageNo = this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value.ToString();
                             IntiqalDocRecId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocRecId_Save"].Value.ToString();
                            string path = "";
                            if (this.grdScanedDocStatus.Rows[i].Cells["actiontypefor_Inserting"].Value != null)
                            {
                                action_for_inserting_Type = this.grdScanedDocStatus.Rows[i].Cells["actiontypefor_Inserting"].Value.ToString();
                            }
                            else
                            {

                            }
                            if (grdScanedDocStatus.Rows[i].Cells["source"].Value != null)
                            {
                                path = grdScanedDocStatus.Rows[i].Cells["source"].Value.ToString();
                            
                                var imgStream = GetImageStream(path);
                                var image = iTextSharp.text.Image.GetInstance(imgStream);
                                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                document.Add(image);
                               
                              }

                                //method 1
                                IntiqalDocImageId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocImageId"].Value.ToString();

                                if (IntiqalDocImageId != "-1")
                                {
                                    action = "replace";

                                }
                                else
                                {
                                    action = "insert";


                                }
                               
                            }
                        document.Close();
                        byte[] array= ms.ToArray();
                        pagno = "1";
                        string lastID = Iq.SaveDocumentImages(IntiqalDocImageId, action, IntiqalDocRecId, IntiqalId, IntiqalDocId, PageNo, array, action_for_inserting_Type, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        if (lastID != null)
                        {
                            //this.grdScanedDocStatus.Rows[i].Cells["insert"].Value = 1;
                        }
                        
                    }


                    MessageBox.Show(" تصاویر محفوظ ہوگئے", "تصاویر محفوظ ہوگئے", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ScanedPagesUpated();
                    if (SelectedRow != "")
                    {
                        GetInsertedImages(SelectedRow);
                    }

                    grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                    grdScannedDoc.Rows[SelectedIndex].Selected = true;
                }
                else
                {
                    MessageBox.Show("پہلے تصاویر لوڈ کریں", "تصاویر", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                    grdScannedDoc.Rows[SelectedIndex].Selected = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            }
#endregion

        #region Get Stream from Image File

        /// <summary>
        /// Gets the image at the specified path, shrinks it, converts to JPG, and returns as a stream
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private Stream GetImageStream(string imagePath)
        {
            var ms = new MemoryStream();
            using (var img = Image.FromFile(imagePath))
            {
                var jpegCodec = ImageCodecInfo.GetImageEncoders()
                    .Where(x => x.MimeType == "image/jpeg")
                    .FirstOrDefault();

                var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)20);

                int dpi = 175;
                var thumb = img.GetThumbnailImage((int)(11.692 * dpi), (int)(8.267 * dpi), null, IntPtr.Zero);
                thumb.Save(ms, jpegCodec, encoderParams);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        #endregion

        #region Click Events of Details Grid

        private void grdScanedDocStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex!=-1)
            {

                if (e.ColumnIndex == this.grdScanedDocStatus.CurrentRow.Cells["Delete"].ColumnIndex)
                {

                    for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                    {
                        grdScanedDocStatus.Rows[i].Cells["replace"].Value = 0;
                    }


                    if (Convert.ToInt32(this.grdScanedDocStatus.CurrentRow.Cells["Delete"].Value) == 1)
                    {
                        this.grdScanedDocStatus.CurrentRow.Cells["Delete"].Value = 0;
                    }
                    else
                    { this.grdScanedDocStatus.CurrentRow.Cells["Delete"].Value = 1; }
                }

                if (e.ColumnIndex == this.grdScanedDocStatus.CurrentRow.Cells["replace"].ColumnIndex)
                {



                    for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                    {
                        grdScanedDocStatus.Rows[i].Cells["Delete"].Value = 0;
                    }

                    if (Convert.ToInt32(this.grdScanedDocStatus.CurrentRow.Cells["replace"].Value) == 1)
                    {

                        this.grdScanedDocStatus.CurrentRow.Cells["replace"].Value = 0;
                    }
                    else
                    {
                        this.grdScanedDocStatus.CurrentRow.Cells["replace"].Value = 1;
                     
                        callDialogBox();                       
                    }
                    
                }

                if (e.ColumnIndex == this.grdScanedDocStatus.CurrentRow.Cells["PictureLoad"].ColumnIndex)
                {
                    string path = System.IO.Path.GetTempPath();
                    string docImgid = grdScanedDocStatus.CurrentRow.Cells["IntiqalDocImageID"].Value.ToString();
                    ToSaveFileTo = "IntImgDoc";
                    DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_Intiqal_DocumentImagesByImgId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + docImgid + "'");
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            byte[] fileData = (byte[])dr["IntiqalDocImage"];
                            this.ReceivedImage = fileData;
                        }
                    }
                    try
                    {
                       
                        int Fileno = 0;
                        ToSaveFileTo = path + ToSaveFileTo + ".pdf";
                        while (File.Exists(ToSaveFileTo))
                        {
                            File.Delete(ToSaveFileTo);
                            //ToSaveFileTo = ToSaveFileTo + Fileno.ToString();
                            //Fileno++;
                        }
                        
                            
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {

                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {

                                    bw.Write(this.ReceivedImage);

                                    bw.Close();

                                }
                            }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Process p = new Process();
                    p.StartInfo.FileName= ToSaveFileTo;
                    p.EnableRaisingEvents = true;
                    p.Exited -= new EventHandler(p_Exited);
                    p.Exited += new EventHandler(p_Exited);
                    //Process.Start(ToSaveFileTo);
                    p.Start();
                    
                    //frmKhataPictureViewerFunction(docid);

                }
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
            //string fName = "IntImgDoc";
            //try
            //{
            //    File.Delete(ToSaveFileTo);
            //    int count = 0;
            //    while (File.Exists(fName + ".pdf"))
            //    {
            //        File.Delete(fName + ".pdf");
            //        fName = fName + count.ToString();
            //        count++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //
            //}
        }

        public void frmKhataPictureViewerFunction(string datagridname)
        {
            frmKhataPictureViewer frmKhataPictureViewer = new frmKhataPictureViewer();
            frmKhataPictureViewer.FormClosed -= new FormClosedEventHandler(frmKhataPictureViewer_FormClosed);
            frmKhataPictureViewer.FormClosed += new FormClosedEventHandler(frmKhataPictureViewer_FormClosed);
            DataTable RetriveImages = new DataTable();
            string Imageid = datagridname;
            RetriveImages = Iq.GetInsetedDocIamges(SelectedRow.ToString());
            frmKhataPictureViewer.DtPica = RetriveImages;
            frmKhataPictureViewer.SelectPic = Imageid;
            frmKhataPictureViewer.ShowDialog();
        }
        private void frmKhataPictureViewer_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmIntiqalDucomentViewer frmIntiqalSellers = sender as frmIntiqalDucomentViewer;

        }
        #endregion

        #region callDialogBox in griddetails for updation
        public void callDialogBox()
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {

                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF, *.PDF, *.pdf)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.PDF;*.pdf";
                    dlg.Multiselect = false;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {


                        if (action_type != null)
                        {
                            if (action_type == "اول")
                            {
                                rownumber = 0;

                                grdScanedDocStatus.Rows.Insert(rownumber);
                                this.grdScanedDocStatus.Rows[rownumber].Cells["actiontypefor_Inserting"].Value = "0";
                                this.grdScanedDocStatus.Rows[rownumber].Cells["PageNo"].Value = "1";
                            }
                            if (action_type == "آخر")
                            {

                                rownumber = grdScanedDocStatus.Rows.Count;
                                grdScanedDocStatus.Rows.Insert(rownumber);
                                this.grdScanedDocStatus.Rows[rownumber].Cells["actiontypefor_Inserting"].Value = "-1";
                                this.grdScanedDocStatus.Rows[rownumber].Cells["PageNo"].Value = grdScanedDocStatus.Rows.Count;

                            }
                            if (action_type == "درمیان میں" && pagno != null)
                            {
                                rownumber = Convert.ToInt32(pagno);
                                grdScanedDocStatus.Rows.Insert(rownumber, 1);
                                this.grdScanedDocStatus.Rows[rownumber].Cells["actiontypefor_Inserting"].Value = rownumber;
                                this.grdScanedDocStatus.Rows[rownumber].Cells["PageNo"].Value = rownumber;

                            }

                            this.grdScanedDocStatus.Rows[rownumber].Cells["IntiqalDocImageId"].Value = "-1";
                            this.grdScanedDocStatus.Rows[rownumber].Cells["IntiqalDocRecId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                            this.grdScanedDocStatus.Rows[rownumber].Cells["IntiqalDocId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocId"].Value.ToString();
                            this.grdScanedDocStatus.Rows[rownumber].Cells["DcumentName"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocName_Urdu"].Value.ToString();

                            this.grdScanedDocStatus.Rows[rownumber].Cells["Source"].Value = dlg.FileName.ToString();
                            byte[] imagefromaction = System.IO.File.ReadAllBytes(dlg.FileName);
                            MemoryStream streamaction = new MemoryStream(imagefromaction);
                            Image imge = Image.FromStream(streamaction);
                            this.grdScanedDocStatus.Rows[rownumber].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(imge, imge.Width, imge.Height, false);
                            this.grdScanedDocStatus.Rows[rownumber].Cells["Image_Pic_DB"].Value = imge;

                        }
                        else
                        {
                            string path = dlg.FileName;

                            this.grdScanedDocStatus.CurrentRow.Cells["source"].Value = path;

                            byte[] image = System.IO.File.ReadAllBytes(path);

                            MemoryStream stream = new MemoryStream(image);
                            Image img = Image.FromStream(stream);
                            ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                            this.grdScanedDocStatus.CurrentRow.Cells["PictureLoad"].Value = ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                            grdScanedDocStatus.CurrentRow.Height = 70;
                            this.grdScanedDocStatus.CurrentRow.Cells["Source"].Value = dlg.FileName.ToString();
                            this.grdScanedDocStatus.CurrentRow.Cells["Image_Pic_DB"].Value = img;
                            grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                            grdScannedDoc.Rows[SelectedIndex].Selected = true;
                        }
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {
                            grdScanedDocStatus.Rows[i].Height = 70;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {
                            grdScanedDocStatus.Rows[i].Height = 70;
                        }
                        grdScanedDocStatus.CurrentRow.Cells["replace"].Value = 0;
                    }


                    grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                    grdScannedDoc.Rows[SelectedIndex].Selected = true;

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region Delete
        private void btnDelMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdScanedDocStatus.Rows.Count > 0)
                {
                    int count = grdScanedDocStatus.Rows.Count;
                    for (int i = 0; i <= count - 1; i++)
                    {
                        if (Convert.ToInt32(grdScanedDocStatus.Rows[i].Cells["Delete"].Value) == 1)
                        {
                            string IntiqalDocId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocId_Save"].Value.ToString();
                            string PageNo = grdScanedDocStatus.Rows[i].Cells["PageNo"].Value.ToString();
                            string IntiqalDocRecId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocRecId_Save"].Value.ToString();
                            string IntiqalDocImageId = grdScanedDocStatus.Rows[i].Cells["IntiqalDocImageId"].Value.ToString();

                            Image img = (Image)grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value;
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            byte[] image = ms.ToArray();

                            string Action = "Delete";
                            string lastID = Iq.SaveDocumentImages(IntiqalDocImageId, Action, IntiqalDocRecId, IntiqalId, IntiqalDocId, PageNo, image, "", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());

                            if (lastID != null)
                            {
                                this.grdScanedDocStatus.Rows[i].Cells["Delete"].Value = 0;
                            }
                        }




                    }
                    MessageBox.Show(" تصاویر حذف ھوگئے", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkForDelete.Checked = false;

                    ScanedPagesUpated();
                    if (this.SelectedRow != null)
                    {
                        GetInsertedImages(SelectedRow.ToString());                   //update the inserted ducoments list gridview 2nd
                        if (grdScanedDocStatus.Rows.Count == 0)
                        {
                            btnNewDoc.Enabled = false;
                        }
                    }

                    grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                    grdScannedDoc.Rows[SelectedIndex].Selected = true;
                }
                else
                {

                    MessageBox.Show("پہلے تصاویر کا انتخاب کریں", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region DeleteCheck Changed
        private void chkForDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.chkReplace.Checked = false;
            if (chkForDelete.Checked)
            {
                for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                {
                    grdScanedDocStatus.Rows[i].Cells["Delete"].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                {
                    grdScanedDocStatus.Rows[i].Cells["Delete"].Value = 0;
                }
            }
        }

        private void chkReplace_CheckedChanged(object sender, EventArgs e)
        {
            chkForDelete.Checked = false;
            if (chkReplace.Checked)
            {
                for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                {
                    grdScanedDocStatus.Rows[i].Cells["replace"].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                {
                    grdScanedDocStatus.Rows[i].Cells["replace"].Value = 0;
                }
            }
        }
        #endregion

        #region Inserted Missing PAges

        private void btnNewSeller_Click(object sender, EventArgs e)
        {
            frmNewIntiqalDoc frmNewIntiqalDoc = new frmNewIntiqalDoc();
            frmNewIntiqalDoc.FormClosed -= new FormClosedEventHandler(frmNewIntiqalDoc_FormClosed);
            frmNewIntiqalDoc.FormClosed += new FormClosedEventHandler(frmNewIntiqalDoc_FormClosed);
            frmNewIntiqalDoc.ShowDialog();
         
        }
        private void frmNewIntiqalDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
            grdScannedDoc.Rows[SelectedIndex].Selected = true;
            frmNewIntiqalDoc frmNewIntiqalDoc = sender as frmNewIntiqalDoc;
            if (frmNewIntiqalDoc.btn)
            {
                GetInsertedImages(SelectedRow);
                action_type = frmNewIntiqalDoc.action_type;
                pagno = frmNewIntiqalDoc.pagno;
                if (action_type != null)
                {
                    callDialogBox();

                }
            }
            else
            { 
            }

        }
        #endregion

        #region MouseHOver Events
        private void grdScanedDocStatus_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.grdScanedDocStatus.Columns["PictureLoad"].Index)
            {
                grdScanedDocStatus.Cursor = Cursors.Hand;

            }
            else
            { grdScanedDocStatus.Cursor = Cursors.Default; 
            }
        }

        private void grdScannedDoc_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == this.grdScannedDoc.Columns["Pages"].Index)
            //{
            //    grdScannedDoc.Cursor = Cursors.Hand;

            //}
            //else
            //{
            //    grdScannedDoc.Cursor = Cursors.Default;
            //}
        }
        #endregion





       
    }
}
