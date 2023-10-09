using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SDC_Application
{
    public partial class frmHysoon : Form
    {
        FingerPrintReaderNoor mFingerPrintReaderNoor;// = new FingerPrintReaderNoor(mFingerPrintReaderNoor.picFpImage);

        public int intiqalPersonImageId { get; set; }
        public long PersonId { get; set; }
        public byte[] FPTempByte { get; set; }
        public byte[] FPSaved { get; set; }
        public bool Status { get; set; }

        public frmHysoon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            mFingerPrintReaderNoor = new FingerPrintReaderNoor(picFpImage);

            Status = false;

            //mFingerPrintReaderNoor.SaveFingerPrintImage =
            //     delegate (int userId, int fingerId, int imageCountOfUserFingerId, byte[] imagedata, int imagedataLength) {
            //         string currPathImage = Application.StartupPath;

            //         string subPathImage = currPathImage + string.Format("\\FpImage\\{0}", userId.ToString());
            //         if (false == System.IO.Directory.Exists(subPathImage))
            //         {
            //             System.IO.Directory.CreateDirectory(subPathImage);
            //         }
            //         using (var fs = new FileStream(string.Format("FpImage\\{0}\\{1}({2}).bmp", userId.ToString(), fingerId.ToString(), imageCountOfUserFingerId), FileMode.OpenOrCreate))
            //         {
            //             BinaryWriter bw = new BinaryWriter(fs);
            //             bw.Write(imagedata, 0, imagedata.Length);
            //         }
            //     };


            mFingerPrintReaderNoor.SaveFingerPrintData =
                 delegate (long intiqalImageId, long userId, int fingerId, byte[] imagedata, int imagedataLength) {
                     //Write to file   
                     //string currPath = Application.StartupPath;
                     FPTempByte = imagedata;
                     Status = true;
                     //string subPath = currPath + string.Format("\\FpDateFile\\{0}", userId.ToString());
                     //if (false == System.IO.Directory.Exists(subPath))
                     //{
                     //    //Create folder
                     //    System.IO.Directory.CreateDirectory(subPath);
                     //}
                     //using (var fs = new FileStream(string.Format("FpDateFile\\{0}\\{1}.dat", userId.ToString(), fingerId.ToString()), FileMode.OpenOrCreate))
                     //{
                     //    fs.Write(imagedata, 0, imagedataLength);
                     //}

                 };
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            String retVal = mFingerPrintReaderNoor.Initialize();
            //mFingerPrintReaderNoor.picFpImage = this.picFpImage; 
            if (retVal == "SUCCESS")
            {

                // DEAR NOOR IT IS FOR LOADING FINGER PRINT DATA FROM DB/FILES TO DEVICES MEMORY
                String path = System.Windows.Forms.Application.StartupPath + "\\FpDateFile";
                System.IO.Directory.CreateDirectory(path);// Create if not created
                byte[] template = new byte[mFingerPrintReaderNoor.templateSize];

                //DirectoryInfo dir = new DirectoryInfo(path);
                //FileInfo[] fil = dir.GetFiles();
                //DirectoryInfo[] dii = dir.GetDirectories();

                ////Get a list of files in the subfolder, recursion traversal 
                //foreach (DirectoryInfo d in dii)
                //{
                //    // System.Diagnostics.Debug.WriteLine(d.FullName);
                //    DirectoryInfo dir2 = new DirectoryInfo(d.FullName);
                //    foreach (FileInfo f in dir2.GetFiles())
                //    {
                //        //long size = f.Length;

                //        int FPID = 0;
                //        string FileName = f.Name.Replace(".dat", "");
                //        int personid = int.Parse(d.Name);
                //        int person_fingerid = int.Parse(FileName);



                //        using (var fs = new FileStream(string.Format("{0}", f.FullName), FileMode.Open))
                //        {
                //            fs.Read(template, 0, template.Length);
                //        }

                //        retVal = mFingerPrintReaderNoor.addToDeviceArray(personid, person_fingerid, ref template);
                //        if (retVal != "SUCCESS")
                //        {

                //        }

                //    }
                //}
                if (FPSaved == null)
                {
                    retVal = mFingerPrintReaderNoor.addToDeviceArray(-1, -1, ref template);

                }
                else
                {
                    template = FPSaved;
                    retVal = mFingerPrintReaderNoor.addToDeviceArray(1, 1, ref template);
                }


            }
            else
            {
                // fail goes here
            }

            txtInfo.Text = retVal;
        }

        private void Enroll_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(txtEditId.Text);
            int fingerId = Convert.ToInt32(txtNumber.Text);
            mFingerPrintReaderNoor.Enroll(ref txtInfo, userId, fingerId);
        }

        private void Varify_Click(object sender, EventArgs e)
        {
            int userId = -1, fingerId = -1;
            String Message = "";
            if (FPSaved != null)
            {  userId = 1; 
               fingerId = 1;
                Message = String.Format("User={0}, Finger={1}", userId, fingerId);
               txtInfo.Text = Message;
            }
            //mFingerPrintReaderNoor.StopFlag = false; // to stop blocking function 
            String retStr = mFingerPrintReaderNoor.Verify(ref userId, ref fingerId);
            Message = String.Format("User={0}, Finger={1}", userId, fingerId);
            txtInfo.Text = Message;
            MessageBox.Show(Message);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            mFingerPrintReaderNoor.StopFlag = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            mFingerPrintReaderNoor.Exit();
            //Application.Exit();
            this.Close();
        }

        private void btnSaveFp_Click(object sender, EventArgs e)
        {
            FPTempByte = FPTempByte;
            this.Close();
        }
    }
}
