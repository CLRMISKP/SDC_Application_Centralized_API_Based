using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.DL;
using DPFP.Capture;
using DPFP.Gui;
using DPFP.Gui.Verification;
using DPFP.Processing;
using DPFP.Verification;
using DPFP.Gui.Enrollment;
using DPFP.Error;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using AForge.Video;
using AForge.Video.DirectShow;
using Newtonsoft.Json;
//using iTextSharp.text;

namespace SDC_Application.AL
{
    public partial class frmIntiqalPersonSnaps : Form
    {
        #region Properties and Class Variables

        DPFP.Capture.Capture ObjCap = new Capture();
        Classess.DPFP fpObj = new Classess.DPFP();
        DPFP.Sample samp = new DPFP.Sample();
        datagrid_controls objdatagird = new datagrid_controls();
        DataTable dt = new DataTable();
        fileIndexing fi = new fileIndexing();
        Intiqal intiqal = new Intiqal();
        public byte[] imgDataPerson = null;
        public byte[] imgDataFinger = null;
        public byte[] imgDataFingerSaved = null;
        byte[] DeSerializee=null; 
        public string IntiqalId { get; set; }
        public bool Attested { get; set; }
        public bool Amaldaramad { get; set; }
        
        BL.frmToken objbusines = new BL.frmToken();

        private FilterInfoCollection captureDevices;
        private VideoCaptureDevice videoSource;

        public bool Cancelled = false;

        WebCam cam=new WebCam();
        string InsertUserId = UsersManagments.UserId != null ? UsersManagments.UserId.ToString() : "Null";
        string InsertLoginName = UsersManagments.UserName != null ? UsersManagments.UserName.ToString() : "Null";
        string UpdateUserId = UsersManagments.UserId != null ? UsersManagments.UserId.ToString() : "Null";
        string UpdateLoginName = UsersManagments.UserName != null ? UsersManagments.UserName.ToString() : "Null";
        APIClient client = new APIClient();
        frmMain camindx = new frmMain();


        #endregion

        public frmIntiqalPersonSnaps()
        {
            InitializeComponent();
            DPFP.Capture.Capture ObjCap = new Capture();
            fpObj.OnFingerTouch(ObjCap, "serial");
        }

        #region Load Form
        private void frmIntiqalPersonSnaps_Load(object sender, EventArgs e)
        {
            try
            {
               if (IntiqalId != "-1" && IntiqalId!=null)
                {
                    btnSaveImage.Enabled = false;
                   
                    this.pboxPicture.Visible = true;
                    this.imgVideo.Visible = true;
                    DataTable dt = new DataTable();
                    dt = intiqal.GetIntiqalPersonsList(this.IntiqalId);
                    grfIntiqalPersonSanps.DataSource = dt;
                    grfIntiqalPersonSanpsss();
                    
                    
                    objdatagird.gridControls(grfIntiqalPersonSanps);
                    objdatagird.colorrbackgrid(grfIntiqalPersonSanps);
                    if (dt != null)
                    {
                        if (grfIntiqalPersonSanps.Rows.Count > 0)
                        {
                            grfIntiqalPersonSanps.Rows[0].Cells["Selection"].Value = 1;
                            this.txtName.Text = grfIntiqalPersonSanps.Rows[0].Cells["CompleteName"].Value.ToString();
                            this.txtpersonID.Text = grfIntiqalPersonSanps.Rows[0].Cells["PersonID"].Value.ToString();
                            this.txtCNIC.Text = grfIntiqalPersonSanps.Rows[0].Cells["CNIC"].Value.ToString();
                            txtIntPersonImageid.Text = "-1";
                        }
                    }
                    try
                    {
                        RetriveSavedimageS();
                        captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        if(captureDevices.Count>0)
                        {
                            //cmbCamera.Items.Add("انتخاب کریں");
                            foreach (FilterInfo Device in captureDevices)
                            {
                                cmbCamera.Items.Add(Device.Name);
                            }
                            
                            if (frmMain.cameraindex!= -1)
                            {
                                cmbCamera.SelectedIndex = frmMain.cameraindex;
                                videoSource = new VideoCaptureDevice();
                                videoSource = new VideoCaptureDevice(captureDevices[frmMain.cameraindex].MonikerString);
                                videoSource.NewFrame += VideoSource_NewFrame;
                                videoSource.Start();
                                cmbCamera.Enabled = false;
                               
                            }
                        }
                      
                       else
                        {
                            frmMain.cameraindex = -1;
                        }
                                              
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                  
                }
                else
                {
                    MessageBox.Show("انتقال لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Declaring DataGrids of Pictures shoots and Pictures Retrives
        public void grdImagesRetrivListe()
        {
            if (grdImagesRetrive.DataSource != null)
            {
                grdImagesRetrive.Columns["ImageSelection"].DisplayIndex = 0;
                grdImagesRetrive.Columns["CompleteName"].DisplayIndex = 1;
                grdImagesRetrive.Columns["PersonPic"].DisplayIndex = 2;
                grdImagesRetrive.Columns["PersonFingerPrint"].DisplayIndex = 3;
                grdImagesRetrive.Columns["CompleteName"].HeaderText = "فرد تفصیل";
                grdImagesRetrive.Columns["PersonPic"].HeaderText = "تصویر";
                grdImagesRetrive.Columns["PersonFingerPrint"].HeaderText = "انگوٹھے کی نشان";
                grdImagesRetrive.Columns["IntialPersonImageId"].Visible = false;
                grdImagesRetrive.Columns["PersonFingerPrint"].Visible = false;
                grdImagesRetrive.Columns["PersonId"].Visible = false;

                grdImagesRetrive.Columns["PersonPic"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdImagesRetrive.Columns["PersonFingerPrint"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdImagesRetrive.Columns["CompleteName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        public void grfIntiqalPersonSanpsss()
        {
            if (grfIntiqalPersonSanps.DataSource != null)
            {
                grfIntiqalPersonSanps.Columns["Selection"].DisplayIndex = 0;
                grfIntiqalPersonSanps.Columns["PersonType"].DisplayIndex = 1;
                grfIntiqalPersonSanps.Columns["CompleteName"].DisplayIndex = 2;
                grfIntiqalPersonSanps.Columns["PersonPic"].DisplayIndex = 3;
                grfIntiqalPersonSanps.Columns["PersonFingerPrint"].DisplayIndex = 4;
                grfIntiqalPersonSanps.Columns["PersonType"].HeaderText = "قسم افراد";
                grfIntiqalPersonSanps.Columns["CompleteName"].HeaderText = "فرد تفصیل";
                grfIntiqalPersonSanps.Columns["cnic"].HeaderText = "شناختی کارڈ";
                grfIntiqalPersonSanps.Columns["PersonID"].Visible = false;
                ((DataGridViewImageColumn)this.grfIntiqalPersonSanps.Columns["PersonPic"]).DefaultCellStyle.NullValue = null;
                ((DataGridViewImageColumn)this.grfIntiqalPersonSanps.Columns["PersonFingerPrint"]).DefaultCellStyle.NullValue = null;
            }



        }
        #endregion

        #region Picture Button Click
        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (cmbCamera.Items.Count > 0)
            {
                this.CheckImage.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("کیمرہ موجود نہیں ہے۔", "کیمرہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        #endregion

        #region Picture Reset Button
        private void btnPictureReset_Click(object sender, EventArgs e)
        {
            this.pboxPicture.Visible = false;
            this.pboxPicture.Image = null;
            this.imgVideo.Visible = true;
            try
            {
                
                //cam.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //cam.Continue();
            //cam.Stop();
            //cam.Continue();

        }
        #endregion

        #region Empty
        private void grfIntiqalPersonSanps_SelectionChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region selection from Grid for Taking Pictures
        private void grfIntiqalPersonSanps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grfIntiqalPersonSanps.CurrentRow.Cells["Selection"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grfIntiqalPersonSanps.SelectedRows.Count > 0)
                    {

                        if (row.Selected)
                        {

                            row.Cells["Selection"].Value = 1;
                           if(this.Attested || this.Amaldaramad || this.Cancelled)
                           {
                               btnSaveImage.Enabled = false;
                           }
                            else
                           {
                               btnSaveImage.Enabled = true;
                           }
                            
                            this.txtName.Text = row.Cells["CompleteName"].Value.ToString();
                            this.txtpersonID.Text = row.Cells["PersonID"].Value.ToString();
                            this.txtCNIC.Text = row.Cells["CNIC"].Value.ToString();
                            txtIntPersonImageid.Text = "-1";
                             // Get and Load if Person Pics are already saved... 
                            GetPersonImageFingerPrint(this.txtpersonID.Text);
                            GetPersonImageFingerPrintSaved(this.txtpersonID.Text, this.txtCNIC.Text);
                                if(pboxFingerPrint.Image==null)
                                {
                                    if(pbSavedFingerPrint.Image==null)
                                    {
                                        GBSavedFingerPrints.Visible = false;
                                    }
                                    else
                                    {
                                        GBSavedFingerPrints.Visible = true;
                                    }
                                    
                                }
                                else
                                {
                                    GBSavedFingerPrints.Visible = false;
                                }


                        }
                        else
                        {
                            row.Cells["Selection"].Value = 0;
                            //grfIntiqalPersonSanps.Rows.Clear();
                        }
                    }
                }
            }
        }
        #endregion

        #region Get Person Finger Print and Image if Already saved for this personid..

        private void GetPersonImageFingerPrintSaved(string PersonId, string cnic)
        {
            DataTable PersonPics = new System.Data.DataTable();
            PersonPics = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_FingerPrints_By_PersonId "+UsersManagments._Tehsilid.ToString()+",'" + PersonId + "','" + cnic + "'");
            if (PersonPics != null)
            {
                if (PersonPics.Rows.Count > 0)
                {
                    foreach (DataRow dr in PersonPics.Rows)
                    {



                        pbSavedFingerPrint.Image = dr["PersonFingerPrint"] != null ? Resource1.FingerprintImage : null;
                        imgDataFingerSaved =Convert.FromBase64String( Convert.ToBase64String(Encoding.ASCII.GetBytes(dr["PersonFingerPrint"].ToString())));
                       
                    }
                }
                else
                {
                    
                    pbSavedFingerPrint.Image = null;
                    imgDataFingerSaved = null;
                }



            }
            else
            {

                pbSavedFingerPrint.Image = null;
                imgDataFingerSaved = null;
            }
        }

        #endregion

        #region Check Dawra validity
        bool isDowraAllowedToday()
        {
            try
            {
                int idValue = Convert.ToInt32(intiqal.GetDawraValidity(DateTime.Today.ToString(System.Globalization.CultureInfo.InvariantCulture)));

                return idValue == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Get Person Finger Print and Image if Already saved for this intiqal..

        private void GetPersonImageFingerPrint(string PersonId)
        {
            DataTable PersonPics = new System.Data.DataTable();
            //var list1 = client.GetIntiqalPersonImagesBase64(UsersManagments._Tehsilid.ToString(), IntiqalId, "0", UsersManagments.userToken);
            var list = client.GetIntiqalPersonImages(UsersManagments._Tehsilid.ToString(), IntiqalId, PersonId, UsersManagments.userToken);
            //PersonPics = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_Intiqal_PersonFingerPrintImage_By_PersonId "+UsersManagments._Tehsilid.ToString()+",'" + PersonId + "', " + this.IntiqalId);
            // string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            //PersonPics = JsonConvert.DeserializeObject<DataTable>(json);
            //foreach (var dr in list1)
            //{
            //    if (dr.PersonId == grfIntiqalPersonSanps.SelectedRows[0].Cells["PersonId"].Value.ToString())
            //    {
            //        this.txtStatus.Text = dr["Token_CurrentStatus"].ToString();
            //        this.label12.Text = dr["TokenNo"].ToString();
            //        pboxPicture.Image = MStream(Convert.FromBase64String(dr.PersonPic)); //MStream(Encoding.ASCII.GetBytes(dr["PersonPic"].ToString()));
            //        pboxFingerPrint.Image = dr.PersonFingerPrint != null ? Resource1.FingerprintImage : null;
            //        imgDataFinger = Convert.FromBase64String(dr.PersonFingerPrint);
            //    }

            //}
            if (list != null)
            {
                if (list.Count()>0)
                {
                    foreach (var  dr in list)
                    {
                        if (dr.PersonId == grfIntiqalPersonSanps.SelectedRows[0].Cells["PersonId"].Value.ToString())
                        {
                            //this.txtStatus.Text = dr["Token_CurrentStatus"].ToString();
                            //this.label12.Text = dr["TokenNo"].ToString();
                            pboxPicture.Image = MStream(dr.PersonPic); //MStream(Encoding.ASCII.GetBytes(dr["PersonPic"].ToString()));
                            pboxFingerPrint.Image = dr.PersonFingerPrint != null ? Resource1.FingerprintImage : null;
                            imgDataFinger = dr.PersonFingerPrint;
                        }
                        //txtDate.Text = dr["TokenDate"].ToString();
                        //this.txttokenid.Text = dr["TokenId"].ToString();
                        //this.txtToken.Text = dr["TokenNo"].ToString();
                        // this.labeltimetoken.Text = dr["TokenTime"].ToString();
                        // string PrintDuplicateStatus = dr["Token_DuplicatePrint"].ToString();

                        if (this.Attested || this.Amaldaramad || this.Cancelled)
                        {
                            btnDel.Enabled = false;
                        }
                        else
                        {
                            btnDel.Enabled = true;
                        }
                    }
                }
                else
                {
                    pboxPicture.Image = null;
                    pboxFingerPrint.Image = null;
                    imgDataFinger = null;
                }



            }
        }

        #endregion

        #region Save Images and fill grid of Saving Picture From DB
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            bool InsertionSuccesfull = false;
           
            if (txtIntPersonImageid.Text == "-1" && txtName.Text != "" && pboxPicture.Image!=null && imgDataFinger!=null)
            {
                string IntialPersonImageId = this.txtIntPersonImageid.Text.Trim();
                string IntiqalId = this.IntiqalId;
                string PersonId = this.txtpersonID.Text;

                //string DawraValidity = intiqal.CheckIntiqalDawraDateValidity(this.IntiqalId.ToString());
                if (!isDowraAllowedToday())
                {
                   string today = DateTime.Now.DayOfWeek.ToString();
                    MessageBox.Show("Dowra is not allowed on " + today,"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Image imgPerson = pboxPicture.Image;
                Image imgfinger = pboxFingerPrint.Image;

                if (pboxPicture.Image != null)
                {
                    imgDataPerson = imageToByteArray(imgPerson);
                }
                
                try
                {
                
                    string DI = fi.saveCamFingerImage(IntialPersonImageId, IntiqalId, PersonId, imgDataPerson, imgDataFinger, InsertUserId, InsertLoginName, UpdateUserId, UpdateLoginName).ToString();
                   
                    if (DI != null)
                    {
                        //foreach(DataGridViewRow row in grfIntiqalPersonSanps.Rows)
                        //{
                        //   if( row.Cells["PersonPic"].Value!=null)
                        //   {
                        //       row.Cells["PersonPic"].Value = null;
                        //       row.Cells["PersonFingerPrint"].Value = null;
                        //       row.Height = 30;
                        //   }
                           
                        //}
                        txtIntPersonImageid.Text = DI;                      
                        InsertionSuccesfull = true;
                        btnSaveImage.Enabled = false;
                        GBSavedFingerPrints.Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("نام،تصویر اور انگھوٹے کا انتخاب کیجیئے", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (InsertionSuccesfull)
            {
                RetriveimageS();
                grfIntiqalPersonSanps.CurrentRow.Selected = true;
            }


        }
        #endregion

        #region saved Images
        public void RetriveimageS()
        {

            string RetriveImageIntiqalID = this.IntiqalId;
            string PersonID = txtpersonID.Text.ToString();
            var dtImages = intiqal.GetCamFingerImage(RetriveImageIntiqalID, PersonID);
            //if (dt != null) {
            //    foreach (DataRow row in dt.Rows)
            //    {

            //        // string personIdSelected = grfIntiqalPersonSanps.CurrentRow.Cells["PersonId"].Value.ToString();
            //        // string personIdFromDB = row["PersonId"].ToString();

            //        for (int i = 0; i <= this.grfIntiqalPersonSanps.Rows.Count - 1; i++)
            //        {
            //            if (row["PersonId"].ToString() == grfIntiqalPersonSanps.Rows[i].Cells["PersonId"].Value.ToString())
            //            {
            //                byte[] Person = Encoding.ASCII.GetBytes(row["PersonPic"].ToString());
            //                //byte[] Finger = (byte[])row["PersonFingerPrint"];
            //                Image RetrunImgae = MStream(Person);
            //                //Image ReturnFinger = MStream(Finger);
            //                RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
            //                // ReturnFinger = ResizeImages.ResizeImage(ReturnFinger, ReturnFinger.Width, ReturnFinger.Height, false);
            //                grfIntiqalPersonSanps.Rows[i].Cells["PersonPic"].Value = RetrunImgae;
            //                //grfIntiqalPersonSanps.CurrentRow.Cells["PersonFingerPrint"].Value = ReturnFinger;
            //                grfIntiqalPersonSanps.CurrentRow.Height = 70;
            //                DataGridViewColumn PersonPic = grfIntiqalPersonSanps.Columns["PersonPic"];
            //                PersonPic.Width = 120;
            //                DataGridViewColumn PersonFingerPrint = grfIntiqalPersonSanps.Columns["PersonFingerPrint"];
            //                PersonFingerPrint.Width = 120;
            //                DataGridViewColumn Selection = grfIntiqalPersonSanps.Columns["Selection"];
            //                Selection.Width = 40;
            //            }
            //        }
            //    }

            //}
            foreach (var row in dtImages)
            {

                // string personIdSelected = grfIntiqalPersonSanps.CurrentRow.Cells["PersonId"].Value.ToString();
                // string personIdFromDB = row["PersonId"].ToString();

                for (int i = 0; i <= this.grfIntiqalPersonSanps.Rows.Count - 1; i++)
                {
                    if (row.PersonId == grfIntiqalPersonSanps.Rows[i].Cells["PersonId"].Value.ToString())
                    {
                        byte[] Person = row.PersonPic;
                        //byte[] Finger = (byte[])row["PersonFingerPrint"];
                        Image RetrunImgae = MStream(Person);
                        //Image ReturnFinger = MStream(Finger);
                        RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                        // ReturnFinger = ResizeImages.ResizeImage(ReturnFinger, ReturnFinger.Width, ReturnFinger.Height, false);
                        grfIntiqalPersonSanps.Rows[i].Cells["PersonPic"].Value = RetrunImgae;
                        //grfIntiqalPersonSanps.CurrentRow.Cells["PersonFingerPrint"].Value = ReturnFinger;
                        grfIntiqalPersonSanps.Rows[i].Height = 70;
                        DataGridViewColumn PersonPic = grfIntiqalPersonSanps.Columns["PersonPic"];
                        PersonPic.Width = 120;
                        DataGridViewColumn PersonFingerPrint = grfIntiqalPersonSanps.Columns["PersonFingerPrint"];
                        PersonFingerPrint.Width = 120;
                        DataGridViewColumn Selection = grfIntiqalPersonSanps.Columns["Selection"];
                        Selection.Width = 40;
                    }
                }
            }

        }


        //+++++++++++++++++ Retrievs Saved Images ++++++++++++++++++++++
        public void RetriveSavedimageS()
        {

            string RetriveImageIntiqalID = this.IntiqalId;
            string PersonID = txtpersonID.Text.ToString();
            //dt = intiqal.GetCamFingerImage(RetriveImageIntiqalID, PersonID);
            var list = client.GetIntiqalPersonImages(UsersManagments._Tehsilid.ToString(), this.IntiqalId, PersonID, UsersManagments.userToken);
            foreach (var row in list)
            {

                // string personIdSelected = grfIntiqalPersonSanps.CurrentRow.Cells["PersonId"].Value.ToString();
                // string personIdFromDB = row["PersonId"].ToString();

                for (int i = 0; i <= this.grfIntiqalPersonSanps.Rows.Count - 1; i++)
                {
                    if (row.PersonId == grfIntiqalPersonSanps.Rows[i].Cells["PersonId"].Value.ToString())
                    {
                        byte[] Person = row.PersonPic;
                        //byte[] Finger = (byte[])row["PersonFingerPrint"];
                        Image RetrunImgae = MStream(Person);
                        //Image ReturnFinger = MStream(Finger);
                        RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                        // ReturnFinger = ResizeImages.ResizeImage(ReturnFinger, ReturnFinger.Width, ReturnFinger.Height, false);
                        grfIntiqalPersonSanps.Rows[i].Cells["PersonPic"].Value = RetrunImgae;
                        //grfIntiqalPersonSanps.CurrentRow.Cells["PersonFingerPrint"].Value = ReturnFinger;
                        grfIntiqalPersonSanps.Rows[i].Height = 70;
                        DataGridViewColumn PersonPic = grfIntiqalPersonSanps.Columns["PersonPic"];
                        PersonPic.Width = 120;
                        DataGridViewColumn PersonFingerPrint = grfIntiqalPersonSanps.Columns["PersonFingerPrint"];
                        PersonFingerPrint.Width = 120;
                        DataGridViewColumn Selection = grfIntiqalPersonSanps.Columns["Selection"];
                        Selection.Width = 40;
                    }
                }
            }

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Image MStream(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);

            return Image.FromStream(stream);

        }
        public byte[] imageToByteArray(Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        #endregion

        #region Retrive Images current Shot and olds if have
        private void CheckImage_Click(object sender, EventArgs e)
        {
            if (CheckImage.SelectedIndex == 1)
            {
                if (txtpersonID.Text != null)
                {
                    string PersonID = txtpersonID.Text.ToString();
                    var dtImages = intiqal.GetCamFingerImage(IntiqalId, PersonID);
                    grdImagesRetrive.DataSource = dtImages;
                    int count=0;
                    foreach (var row in dtImages)
                    {
                        grdImagesRetrive.Rows[count].Cells["CompleteName"].Value = row.CompleteName; //row["CompleteName"].ToString();
                        byte[] Person = row.PersonPic; //Encoding.ASCII.GetBytes(row["PersonPic"].ToString());
                       // byte[] Finger = (byte[])row["PersonFingerPrint"];
                        Image RetrunImgae = MStream(Person);
                        //Image ReturnFinger = MStream(Finger);
                        RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                      //  ReturnFinger = ResizeImages.ResizeImage(ReturnFinger, ReturnFinger.Width, ReturnFinger.Height, false);
                        grdImagesRetrive.Rows[count].Cells["PersonPic"].Value = RetrunImgae;
                       // grdImagesRetrive.Rows[count].Cells["PersonFingerPrint"].Value = ReturnFinger;
                        count++;                    
                    }
                }
                grdImagesRetrivListe();
                objdatagird.gridControls(grdImagesRetrive);
                objdatagird.colorrbackgrid(grdImagesRetrive);
                ((DataGridViewImageColumn)this.grdImagesRetrive.Columns["PersonFingerPrint"]).DefaultCellStyle.NullValue = null;
                DataGridViewColumn ImageSelection = grdImagesRetrive.Columns["ImageSelection"];
                ImageSelection.Width = 60;
                DataGridViewColumn PersonPic = grdImagesRetrive.Columns["PersonPic"];
                PersonPic.Width = 120;
                DataGridViewColumn PersonFingerPrint = grdImagesRetrive.Columns["PersonFingerPrint"];
                PersonFingerPrint.Width = 200;
                foreach (DataGridViewRow row in grdImagesRetrive.Rows)
                {
                    row.Height = 70;
                }

            }
            else if (CheckImage.SelectedIndex == 2)
            {
                this.CheckImage.SelectedIndex = 0;
            }

        }
        #endregion

        private void grdImagesRetrive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == grdImagesRetrive.CurrentRow.Cells["ImageSelection"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grfIntiqalPersonSanps.SelectedRows.Count > 0)
                        {

                            if (row.Selected)
                            {
                                row.Cells["ImageSelection"].Value = 1;
                                row.Selected = false;                                                    
                            }
                            else
                            {
                                row.Cells["ImageSelection"].Value = 0;

                            }
                        }
                    }
                }
            }
        }
        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            
            frmFingerPrint Populate = new frmFingerPrint();
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);
            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);          
            Populate.ShowDialog();           
          
        }


        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFingerPrint Populate = sender as frmFingerPrint;
            
            if (Populate.Btn)
            {
                if (Populate.FPTempByte != null)
                {
                    imgDataFinger = Populate.FPTempByte;
                    pboxFingerPrint.Image = Resource1.FingerprintImage;
                }
            
            }

        }

     
        #region Load PersonImageFrom File
        private void btnLoadPicturefromFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG,*.TIFF,*.TIF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;*.TIFF;*.TIF;";
                    dlg.Multiselect = false;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        imgVideo.Visible = false;
                        pboxPicture.Visible = true;
                        string path = dlg.FileName;                      
                        byte[] image = System.IO.File.ReadAllBytes(path);
                        MemoryStream stream = new MemoryStream(image);
                        Image img = Image.FromStream(stream);
                       
                        this.pboxPicture.Image = ResizeImages.ResizeImagePerson(img, img.Width, img.Height, false);
                        
                    }
                }
            }
            catch (Exception ex)
            { 

            }
        }

        #endregion

        #region Finger Print Verification

        private void btnVerifyFingerPrint_Click(object sender, EventArgs e)
        {
            if (pboxFingerPrint.Image == null)
            {
                MessageBox.Show("انگھوٹا پہلے سے محفوظ نہیں ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            frmVerificationFinger verifyFingerPrint = new frmVerificationFinger();
            verifyFingerPrint.name = this.txtName.Text;
            verifyFingerPrint.PersonFingerPrint = imgDataFinger;
            verifyFingerPrint.ShowDialog();
            }
        }


        private void btnVerifySavedFingerPrint_Click(object sender, EventArgs e)
        {
            if(pbSavedFingerPrint.Image==null)
            {
                MessageBox.Show("انگھوٹا پہلے سے محفوظ نہیں ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmVerificationFinger verifyFingerPrint = new frmVerificationFinger();
                verifyFingerPrint.PersonFingerPrint = imgDataFingerSaved;
                verifyFingerPrint.name = this.txtName.Text;
                verifyFingerPrint.FormClosed -= new FormClosedEventHandler(verifyFingerPrint_FormClosed);
                verifyFingerPrint.FormClosed += new FormClosedEventHandler(verifyFingerPrint_FormClosed);   
                verifyFingerPrint.ShowDialog();
            }
        }
        #endregion

        private void verifyFingerPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVerificationFinger verifyFingerPrint = sender as frmVerificationFinger;

            if (verifyFingerPrint.matched)
            {
                pboxFingerPrint.Image = pbSavedFingerPrint.Image;
                imgDataFinger = imgDataFingerSaved;
            }
            else
            {
                pboxFingerPrint.Image = null;
                imgDataFinger = null;

            }

        }


        private void bntCapture_Click(object sender, EventArgs e)
        {
            Image imm = (Bitmap)pictureBox1.Image.Clone();
            pboxPicture.Image = ResizeImages.ResizeImagePerson(imm, imm.Width, imm.Height, false); //imm; 

            this.CheckImage.SelectedIndex = 0;
        }

      
        private void frmIntiqalPersonSnaps_FormClosed(object sender, FormClosedEventArgs e)
        {
            
               
                if (frmMain.cameraindex != -1)
                {
                    videoSource.Stop();
                }

        }

    

        private void cmbCamera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCamera.Items.Count > 0)
            {
                frmMain.cameraindex = cmbCamera.SelectedIndex;
                videoSource = new VideoCaptureDevice();
                videoSource = new VideoCaptureDevice(captureDevices[frmMain.cameraindex].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
                cmbCamera.Enabled = false;
            }
        }

        private void pboxPicture_DoubleClick(object sender, EventArgs e)
        {
            if(pboxPicture.Image!=null && txtName.Text != "")
            {
                frmPicView picview = new frmPicView();
                picview.img = pboxPicture.Image;
                picview.name = this.txtName.Text;
                picview.ShowDialog();
            }
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            try
            {
                string retVal;
                retVal=intiqal.DeleteIntiqalPersonSnaps(this.txtpersonID.Text, this.IntiqalId,UsersManagments.UserId.ToString());
                if(retVal=="0")
                {
                    for (int i = 0; i <= this.grfIntiqalPersonSanps.Rows.Count - 1; i++)
                    {
                        if (txtpersonID.Text == grfIntiqalPersonSanps.Rows[i].Cells["PersonId"].Value.ToString())
                        {

                            grfIntiqalPersonSanps.Rows[i].Cells["PersonPic"].Value = null;

                        }
                    }


                    btnSaveImage.Enabled = false;
                    GBSavedFingerPrints.Visible = false;
                    btnDel.Enabled = false;

                    this.txtName.Clear();
                    this.txtpersonID.Clear();
                    this.txtCNIC.Clear();
                    txtIntPersonImageid.Text = "-1";

                    pboxFingerPrint.Image = null;
                    pbSavedFingerPrint.Image = null;
                    pboxPicture.Image = null;
                }
                else
                {
                    MessageBox.Show("Only " + retVal + "  can delete this entry","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }

       

    }
}

