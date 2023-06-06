using SDC_Application.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using SDC_Application.DL;
using LandInfo.ControlsLib;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SDC_Application.AL
    {
    public partial class frmStayOrder : Form
    {
        #region Calss Variables

        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        BL.frmToken objbusines = new BL.frmToken();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        int countSelectedKhata = 0;
        public byte[] ReceivedImage { get; set; }
        int countLockedKhata = 0;
        DataView dvKhatajat = new DataView();
      
        Intiqal Iq = new Intiqal();
        string ToSaveFileTo = "";
        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();
        
        ArrayList list = new ArrayList();
       
        #endregion

        #region Default Construction

        public frmStayOrder()
            {

            InitializeComponent();

            }

        #endregion

       

        #region Form Load
        private void frmStayOrder_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            tooltip();
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouzaSearch, "MozaNameUrdu", "MozaId");
        }
        #endregion

        #region Moza Selection Change Event
        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            countSelectedKhata = 0;
           if (cmbMouza.SelectedIndex>0)
           {
               DataTable dt = new DataTable();


               dt = Iq.GetKhatJatForStayOrder(cmbMouza.SelectedValue.ToString());

               dvKhatajat = dt.AsDataView();
               GridViewKhataJat.DataSource = dvKhatajat;
              
               GridViewKhataJat.Columns["RegisterHqDKhataId"].Visible = false;
               GridViewKhataJat.Columns[0].Width = 120;
               GridViewKhataJat.Columns[3].Width = 250;
           }
        }
        #endregion


        #region   GridViewKhataJat_CellClick
        private void GridViewKhataJat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                GridViewKhataJat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == GridViewKhataJat.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(GridViewKhataJat.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        GridViewKhataJat.CurrentRow.Cells["cbgrid"].Value = 0;
                        countSelectedKhata -= 1;
                    }
                    else
                    {
                        GridViewKhataJat.CurrentRow.Cells["cbgrid"].Value = 1;
                        countSelectedKhata += 1;
                    }
                }
            }
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

        #region GetImages from Database 
        public void GetKhataImages(string KhataId)
        {
            try
            {
                //((DataGridViewImageColumn)this.grdScanedDocStatus.Columns["PictureLoad"]).DefaultCellStyle.NullValue = null;
                DataTable RetriveImages = new DataTable();
               
                    RetriveImages = Iq.GetKhataIamges(KhataId);

                    if (RetriveImages != null)
                    {

                       
                        dgvLockKhata.Rows.Clear();
                        list.Clear();
                        int Total_Records = RetriveImages.Rows.Count;
                        for (int i = 0; i <= Total_Records - 1; i++)
                        {
                            dgvLockKhata.Rows.Add();
                            dgvLockKhata.Rows[i].Height = 70;

                        }
                        int count = 0;
                        foreach (DataRow row in RetriveImages.Rows)
                        {


                            byte[] doc = (byte[])row["Picture"];
                            try
                            {
                                MemoryStream stream = new MemoryStream(doc);
                                Image RetrunImgae = Image.FromStream(stream);
                                list.Add(RetrunImgae);
                                RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                                this.dgvLockKhata.Rows[count].Cells["Picture"].Value = RetrunImgae;


                            }
                            catch (Exception ex)
                            {

                                list.Add(doc);
                                Image RetrunImgae = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                                this.dgvLockKhata.Rows[count].Cells["Picture"].Value = RetrunImgae;
                            }
                            this.dgvLockKhata.Rows[count].Cells["PageNos"].Value = row["PageNos"];
                            this.dgvLockKhata.Rows[count].Cells["SNo"].Value = row["SNo"];
                            this.dgvLockKhata.Rows[count].Cells["Details"].Value = row["Details"];
                            this.dgvLockKhata.Rows[count].Cells["InsertDate"].Value = row["InsertDate"];
                            this.dgvLockKhata.Rows[count].Cells["lock"].Value = row["lock"];
                            this.dgvLockKhata.Rows[count].Cells["GetImageId"].Value = row["ImageId"];
                          
                            count++;
                        }

                        //grdScanedDocStatus_Formats();
                    }
                    else
                    {
                       // btnNewDoc.Enabled = false;
                    }

                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbLock.Checked == false && rbUnlock.Checked == false)
            {
                MessageBox.Show("لاک ہا انلاک سیلیکٹ کریں", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbMouza.SelectedIndex == 0)
            {
                MessageBox.Show("موضع سیلیکٹ کریں", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (countSelectedKhata < 1)
            {
                MessageBox.Show("کم از کم ایک کھاتہ سیلیکٹ کریں", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDetails.Text.Trim().Length < 5)
            {
                MessageBox.Show("تفصیل درج کریں", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdScanedDocStatus.Rows.Count == 0)
            {
                MessageBox.Show("دستاویزات سیلیکٹ کریں", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string lockk = "";
            if (rbLock.Checked)
            {
                lockk = "1";
            }
            else
            {
                lockk = "0";
            }
           

        
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            try
            {
               
               
                    string PageNos = "";
                   
                    string ImageId = "-1";
                   
                    using (var ms = new MemoryStream())
                    {
                        var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 0, 0, 0, 0);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                        document.Open();
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {
                            
                            PageNos = this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value.ToString();
                           
                            string path = "";
                           
                            if (grdScanedDocStatus.Rows[i].Cells["source"].Value != null)
                            {
                                path = grdScanedDocStatus.Rows[i].Cells["source"].Value.ToString();

                                var imgStream = GetImageStream(path);
                                var image = iTextSharp.text.Image.GetInstance(imgStream);
                                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                document.Add(image);

                            }

                            
                            //ImageId = grdScanedDocStatus.Rows[i].Cells["ImageId"].Value.ToString();


                        }
                        document.Close();
                        byte[] array = ms.ToArray();

                        string picId = Iq.SaveKhataImages(ImageId, cmbMouza.SelectedValue.ToString(), array, PageNos, UsersManagments.UserId.ToString(), UsersManagments.UserName);

                        countLockedKhata = 0;
                        if (this.GridViewKhataJat.Rows.Count > 0)
                        {

                            for (int i = 0; i <= GridViewKhataJat.Rows.Count - 1; i++)
                            {
                                if (Convert.ToInt32(GridViewKhataJat.Rows[i].Cells["cbgrid"].Value) == 1)
                                {


                                    string khataId = GridViewKhataJat.Rows[i].Cells["RegisterHqDKhataId"].Value.ToString();
                                    string PrevLockDetails = GridViewKhataJat.Rows[i].Cells["لاک تفصیل"].Value.ToString();

                                    string lastId = MalikanKatajat.insertKhataLockDetail(khataId, lockk, PrevLockDetails, txtDetails.Text, picId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), "1");
                                    countLockedKhata += Convert.ToInt32(lastId);
                                }
                            }


                        }

                    }



            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            string L = "";
            string K = "";
            string P = "";
            if (rbLock.Checked)
            {
                L = "لاک";
            }
            else
            {
                L = "انلاک";
            }
            if (countLockedKhata == 1)
            {
                K = countLockedKhata.ToString() + " کھاتہ";
            }
            else
            {
                K = countLockedKhata.ToString() + " کھاتہ جات";
            }

            if (PageNos == "1")
            {
                P = PageNos.ToString() + " دستاویز";
            }
            else
            {
                P = PageNos.ToString() + " دستاویزات";
            }


            MessageBox.Show(K + " " + L + "  اور " + P + "  محفوظ ہو گئے", "سٹے آرڈر", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            txtDetails.Clear();
            rbLock.Checked = false;
            rbUnlock.Checked = false;
            GridViewKhataJat.DataSource = null;
            cmbMouza.SelectedIndex = 0;
            grdScanedDocStatus.Rows.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            }

        }
#endregion

        #region cmbMouza_KeyPress
        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

        #endregion

        #region Tooltip

        public void tooltip()
        {
            toolTip.SetToolTip(cmbMouza, "موضع سیلیکٹ کریں");
            toolTip.SetToolTip(panel5, "لاک یا انلاک کریں");
            toolTip.SetToolTip(GridViewKhataJat, "کھاتہ سیلیکٹ کرین");
            toolTip.SetToolTip(txtDetails, "تفصیل درج کریں");
            toolTip.SetToolTip(panelImages, "تصویریں");
            toolTip.SetToolTip(btnPics, "دستاویزات سیلیکٹ کریں");
            toolTip.SetToolTip(btnSave, "محفوظ کریں");
       

        }

        #endregion

        #region Details Key Press
        private void txtDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

#endregion

        #region Picture open dialogue
        string[] files;
        private void btnPics_Click(object sender, EventArgs e)
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
                            //textBox1.Text = grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                        }
                        for (int i = 0; i <= last - 1; i++)
                        {
                            string filepath = list[i].ToString();
                            grdScanedDocStatus.Rows.Add();
                            //this.grdScanedDocStatus.Rows[i].Cells["IntiqalDocRecId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocRecId"].Value.ToString();
                            //this.grdScanedDocStatus.Rows[i].Cells["IntiqalDocId_Save"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocId"].Value.ToString();
                            //this.grdScanedDocStatus.Rows[i].Cells["DcumentName"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocName_Urdu"].Value.ToString();
                            this.grdScanedDocStatus.Rows[i].Cells["ImageId"].Value = "-1";
                            this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = list[i].ToString();
                            // this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = this.grdScannedDoc.CurrentRow.Cells["IntiqalDocName_Urdu"].Value;
                            byte[] image = System.IO.File.ReadAllBytes(filepath);
                            MemoryStream stream = new MemoryStream(image);
                            try
                            {
                                Image img = Image.FromStream(stream);

                               // this.grdScanedDocStatus.Rows[i].Cells["Image_Pic_DB"].Value = img;
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

                        //grdScannedDoc.Rows[SelectedIndex].Cells["checkforload"].Value = 1;
                        //grdScannedDoc.Rows[SelectedIndex].Selected = true;


                    }


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #endregion

      

        #region cmbMouzaSearch_SelectionChangeCommitted
        private void cmbMouzaSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (cmbMouzaSearch.SelectedIndex > 0)
            {
                try
                {
                    DataTable dtkj = new DataTable();
                    dtkj = Iq.GetKhataJatForintiqalByMozaId(cmbMouzaSearch.SelectedValue.ToString());
                    DataRow inteqKj = dtkj.NewRow();
                    inteqKj["RegisterHqDKhataId"] = "0";
                    inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                    dtkj.Rows.InsertAt(inteqKj, 0);
                    cbokhataNoSerach.DataSource = dtkj;
                    cbokhataNoSerach.DisplayMember = "KhataNo";
                    cbokhataNoSerach.ValueMember = "RegisterHqDKhataId";
                    cbokhataNoSerach.SelectedValue = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region cbokhataNoSerach_SelectionChangeCommitted
        private void cbokhataNoSerach_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetKhataImages(cbokhataNoSerach.SelectedValue.ToString());
           
        }

        #endregion

        #region dgvLockKhata_CellContentClick
        private void dgvLockKhata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {





                if (e.ColumnIndex == this.dgvLockKhata.CurrentRow.Cells["Picture"].ColumnIndex)
                {
                    string ImageId = dgvLockKhata.CurrentRow.Cells["GetImageId"].Value.ToString();
                    ToSaveFileTo = "IntImgDoc";
                    DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_Khata_ImagesByImageId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + ImageId + "'");
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            byte[] fileData = (byte[])dr["Image"];
                            this.ReceivedImage = fileData;
                        }
                    }
                    try
                    {

                        int Fileno = 0;
                        while (File.Exists(ToSaveFileTo + ".pdf"))
                        {
                            ToSaveFileTo = ToSaveFileTo + Fileno.ToString();
                            Fileno++;
                        }

                        ToSaveFileTo = ToSaveFileTo + ".pdf";
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
                    p.StartInfo.FileName = ToSaveFileTo;
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(p_Exited);
                    //Process.Start(ToSaveFileTo);
                    p.Start();

                    //frmKhataPictureViewerFunction(docid);

                }
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
            string fName = "IntImgDoc";
            try
            {
                File.Delete(ToSaveFileTo);
                int count = 0;
                while (File.Exists(fName + ".pdf"))
                {
                    File.Delete(fName + ".pdf");
                    fName = fName + count.ToString();
                    count++;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }


        #endregion

        #region cmbMouzaSearch_KeyPress
        private void cmbMouzaSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }
        #endregion

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Khatas = "";
                if (txtNoKhassras.Text.Length > 0)
                {
                    DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_KhataJat_By_KhassraNos " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+','+cmbMouza.SelectedValue.ToString() + ",'" + txtNoKhassras.Text + "'");
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataGridViewRow dgr in GridViewKhataJat.Rows)
                                {
                                    if (row["RegisterHqDKhataId"].ToString() == dgr.Cells["RegisterHqDKhataId"].Value.ToString())
                                    {
                                        dgr.Cells["cbgrid"].Value = true;
                                        Khatas = Khatas + row["RegisterHqDKhataId"].ToString() + ",";
                                        
                                    }
                                }
                            }
                            if(Khatas.Length>1)
                            Khatas = Khatas.Remove(Khatas.Length-1, 1);
                            dvKhatajat.RowFilter = string.Format("RegisterHqDKhataId IN "+"("+ Khatas+")");
                            //foreach (DataGridViewRow dgr in GridViewKhataJat.Rows)
                            //{
                            //    if (Convert.ToBoolean(dgr.Cells["cbgrid"].Value))
                            //    {
                            //        dgr.Visible = true;
                            //    }
                            //    else
                            //    {
                            //        dgr.Visible = false;
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetKhataList_Click(object sender, EventArgs e)
        {
            dvKhatajat.RowFilter = string.Empty;
        }

        private void txtNoKhassras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

      
    }
}