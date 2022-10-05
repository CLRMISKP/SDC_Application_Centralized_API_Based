using System;
using System.Collections.Generic;
using System.Text;
using FpReader.Core;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SDC_Application
{

    class FingerPrintReaderNoor
    {
        public delegate void SaveImgSignature(int userId, int fingerId, int imageCountOfUserFingerId, byte[] imagedata, int imagedataLength);
        public delegate void SaveFpDataSignature(long IntiqalImageId, long userId, int fingerId, byte[] data, int dataLength);

        public SaveImgSignature SaveFingerPrintImage = null;
        public SaveFpDataSignature SaveFingerPrintData = null;

        public List<string> devIdList = new List<string>();
        public List<byte[]> fpDataList = new List<byte[]>();
        public uint contextId = 1;
        public int deviceCompany;
        public int Enroll_flag;
        public int imageWidth, imageHeight, imageRes, featureSize, templateSize, updatedFlag;
        public int fpAreaTh, noCheckCountTh;
        public byte[] imageBuffer, template, updatedTemplate, rawImgBuffer;
        public const int maxContinuosFpPressCount = 5;

        public byte[][] feature = new byte[3][];

        public bool StopFlag = false;
        public bool initflag = true;

        public System.Windows.Forms.ComboBox cbbDevice = new System.Windows.Forms.ComboBox();
        public System.Windows.Forms.PictureBox picFpImage; //= new System.Windows.Forms.PictureBox();
        public FingerPrintReaderNoor(System.Windows.Forms.PictureBox picFpImageT)
        {
            this.picFpImage = picFpImageT;
        }
        ~FingerPrintReaderNoor()
        {

        }

        public String Initialize()
        {
            Exit();
            if (Init())
            {
                OpenDev(0);
                StopFlag = true;
                //UseDevButtons();
            }
            else
                return "Unable to get AST2600 device identifier!";

            return "SUCCESS";
        }

        private String OpenDev(int Index)
        {
            String ret = "SUCCESS";
            string vDevId = string.Empty;
            int vnRet;
            if (!GetDevIdFromListIndex(Index, ref vDevId))
            {
                return ("Unable to get AST2600 device identifier!");
            }
            vnRet = ObjFpReader.pisCreateContext(ref contextId);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ret = ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.CREATE_CONTEXT_FUNC, vnRet);
            }


            vnRet = ObjFpReader.pisOpenDevice(contextId, vDevId);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                ret = ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.OPEN_DEVICE_FUNC, vnRet);
                return "Failed to open device!";
            }

            //txtInfo.Text = "Open the device successfully!";

            vnRet = ObjFpReader.pisGetDeviceInfo(contextId, ObjFpReader.PISFP_PARAM_KIND_COMPANY, ref deviceCompany);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                deviceCompany = ObjFpReader.PRODUCT_PEFIS;
            }

            fpAreaTh = 18;
            noCheckCountTh = 20;
            int temp_DeviceCompany = deviceCompany;
            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
                fpAreaTh = 17;
                noCheckCountTh = 20;
            }


            byte[] engineInfo = new byte[1024];
            vnRet = ObjFpReader.pisGetInfo(contextId, ref engineInfo[0], ref imageWidth, ref imageHeight, ref imageRes,
                        ref featureSize, ref templateSize);

            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON || temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            }

            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                return ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.GET_INFO_FUNC, vnRet);

            }

            picFpImage.Width = imageWidth;
            picFpImage.Height = imageHeight;
            picFpImage.Image = null;

            imageBuffer = new byte[picFpImage.Width * picFpImage.Height];
            feature[0] = new byte[featureSize];
            feature[1] = new byte[featureSize];
            feature[2] = new byte[featureSize];
            template = new byte[templateSize];
            updatedTemplate = new byte[templateSize];
            rawImgBuffer = new byte[ObjFpReader.IMPORT_RAW_IMAGE_WIDTH * ObjFpReader.IMPORT_RAW_IMAGE_HEIGHT];

            memset(imageBuffer, 0x55, picFpImage.Width * picFpImage.Height);

            vnRet = ObjFpReader.pisSetMatchParameter(contextId, ObjFpReader.PISFP_DEFAULT_ROTATION_RANGE, ObjFpReader.PISFP_DEFAULT_THRESHOLD);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                ObjFpReader.pisDestroyContext(contextId);
                ErrorDescription(ObjFpReader.INIT_PROC, ObjFpReader.GET_INFO_FUNC, vnRet);
                return "Setting image parameters failed!";

            }
            //Get the current folder path

            //UseDevButtons();
            return ret;
        }
        /// <summary>
        /// Close device
        /// </summary>
        /// 




        public String clearDeviceArray()
        {
            uint contextId = 1;
            ObjFpReader.pisClearTptArray(contextId);
            fpDataList.Clear();  //clear list
            return "SUCCESS";
        }
        // return for SUCCESS
        public String addToDeviceArray(int personid, int person_fingerid, ref byte[] fingerData)
        {
            uint contextId = 1;
            int FPID = personid * 100 + person_fingerid;
            //Add in recognition
            int vnRet = ObjFpReader.pisAddTptArray(contextId, FPID, fingerData);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                return ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.ADD_TPT_ARRAY_FUNC, vnRet);
            }

            return "SUCCESS";
        }

        public void delFromDeviceArray(int personid, int person_fingerid)
        {
            uint contextId = 1;
            int FPID = personid * 100 + person_fingerid;
            //Add in recognition
            ObjFpReader.pisDeleteAtTptArray(contextId, FPID);
        }


        private bool Init()
        {
            devIdList.Clear();
            cbbDevice.Items.Clear();

            for (int i = 0; i < ObjFpReader.PISFP_MAX_DEVICE_COUNTS; i++)
            {
                byte[] vstrDeviceDescription = new byte[1024];
                byte[] vstrDevId = new byte[1024];

                int RSLT = ObjFpReader.pisEnumerateDevice(i, ref vstrDevId[0], ref vstrDeviceDescription[0]);
                if (RSLT == ObjFpReader.PISFP_OK)
                {
                    var X = Encoding.Default.GetString(vstrDeviceDescription, 0, vstrDeviceDescription.Length);
                    cbbDevice.Items.Add(X);
                    var X1 = Encoding.Default.GetString(vstrDevId, 0, vstrDevId.Length);
                    devIdList.Add(X1);
                }
            }

            if (cbbDevice.Items.Count > 0)
            {
                initflag = false;
                cbbDevice.SelectedIndex = 0;
                initflag = true;
                return true;
            }

            return false;
        }




        public Image DrawFpImage()
        {
            Image img = ToGrayBitmap(imageBuffer, imageWidth, imageHeight);
            picFpImage.Image = img;
            return img;

        }

        /// <summary>
        /// Convert a byte array to 8bit gray bitmap
        /// </summary>
        /// <param name="rawValues">Display byte array</param>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <returns></returns>
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            //// Apply the variables of the target bitmap and lock the memory area.
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            //// Get image parameters
            int stride = bmpData.Stride;  // Width of scan line
            int offset = stride - width;  // Gap between width and scan line width
            IntPtr iptr = bmpData.Scan0;  // Get the memory start position of bmpData.
            int scanBytes = stride * height;   // Use stride width to indicate that this is the size of memory area.

            //// The original display size byte array is converted to the actual byte array in memory.
            int posScan = 0, posReal = 0;   // Set two location pointers respectively, pointing to the source array and the target array.
            byte[] pixelValues = new byte[scanBytes];  //Allocate memory for target array
            for (int x = 0; x < height; x++)
            {
                //// The following loop section is simulated row scan.
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;  //When the line scan ends, the target position pointer should be moved over the gap.
            }

            //// Using the Copy method of Marshal, copy the memory byte array that has just been obtained to BitmapData.
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  // Unlock memory area
            //// The following code is used to modify the index table for generating bitmaps, from pseudo color to grayscale.
            System.Drawing.Imaging.ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;

            //// The algorithm ends here, and returns the result.
            return bmp;
        }

        public static void memset(byte[] buf, byte val, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                buf[i] = val;
        }

        public bool GetDevIdFromListIndex(int index, ref string pDevId)
        {
            if ((index < 0) || (index >= cbbDevice.Items.Count)) return false;
            pDevId = devIdList[index].PadRight(36, '0');
            return true;
        }

        public String ErrorDescription(string ProcDesc, string FuncDesc, int ErrValue)
        {
            string errStr = string.Empty;
            switch (ErrValue)
            {
                case ObjFpReader.PISFP_ERR_INVALID_CONTEXT:
                    errStr = "ContextID is not valid.";
                    break;
                case ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV:
                    errStr = "Device is not connect.";
                    break;
                case ObjFpReader.PISFP_ERR_FUNC_PARAMETER:
                    errStr = "Function's parameter is not valid.";
                    break;
                case ObjFpReader.PISFP_ERR_SYSTEM_MEMORY_ALLOC:
                    errStr = "System's memory can't alloc.";
                    break;
                case ObjFpReader.PISFP_ERR_TEMPLATE_ARRAY_OVER:
                    errStr = "TptArray is over.";
                    break;
                case ObjFpReader.PISFP_ERR_DEV_STOP:
                    errStr = "Device is stop.";
                    break;
                case ObjFpReader.PISFP_ERR_DEV_BUSY:
                    errStr = "Device is busy.";
                    break;
                case ObjFpReader.PISFP_ERR_CONTEXT_OVER:
                    errStr = "Context is over.";
                    break;
                default:
                    errStr = string.Format("Fail =  {0}", ErrValue);
                    break;
            }

            return string.Format("{0} Fail : ({1}:<{2}>)", ProcDesc, FuncDesc, errStr);

        }


        /// <summary>
        /// Enroll
        /// </summary>
        public void Enroll(ref TextBox infoString, int userId, int FingerId)
        {

            int vnRet;
            int flag = 1;
            //int FingerId = 0;

            // SWITCH ON LED ;)
            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);

            if (StopFlag) StopFlag = false;
            int isCheckFp = 0, fpArea = 0;
            int fpExtractCount = 0;
            int continuosFpPressCount = 0;
            bool doubleCheckFlag = true;
            byte[] RECardNo = new byte[256];
            string CardNo = "";
            ObjFpReader.CaptureFpStatus capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
            while (!StopFlag)
            {
                Application.DoEvents();

                vnRet = ObjFpReader.pisCapture(contextId, imageBuffer);
                if (vnRet == ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV)
                {
                    infoString.Text = ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);

                    ObjFpReader.pisCloseDevice(contextId);

                    vnRet = ObjFpReader.pisOpenDevice(contextId, devIdList[cbbDevice.SelectedIndex]);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                else if (vnRet != ObjFpReader.PISFP_OK)
                {
                    infoString.Text = ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);
                    ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                    return;
                }

                DrawFpImage();

                vnRet = ObjFpReader.pisCheckFp(contextId, imageBuffer, imageWidth, imageHeight, imageRes, ref isCheckFp, ref fpArea);

                //Initialization
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_Init)
                {
                    if (isCheckFp != 0)
                    {
                        infoString.Text = "Please leave your fingers.";
                        continue;
                    }
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger;
                        continuosFpPressCount = 0;
                    }
                }

                //Wait for the finger to press down.
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger)
                {
                    if (isCheckFp == 0) // NO FINGER PRINT PRESSED ON DEVICE YET
                    {
                        String RetStr = "";
                        promptPressFinger(fpExtractCount + 1, ref RetStr);
                        infoString.Text = RetStr;
                        Enroll_flag = fpExtractCount + 1;
                        if (continuosFpPressCount < 2)
                        {
                            continuosFpPressCount = 0;
                            continue;
                        }

                    }

                    continuosFpPressCount++;
                    if (fpArea > 80 && continuosFpPressCount > maxContinuosFpPressCount)
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured;
                    }
                }

                //Processing captured images
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured)
                {
                    // extract fp features in feature array using max fp finger print image in imageBuffer captured ealrier 
                    if (ObjFpReader.pisProcess(contextId, imageBuffer, imageWidth, imageHeight, imageRes,
                        feature[fpExtractCount]) != ObjFpReader.PISFP_OK)
                    {
                        ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.PROCESS_FUNC, vnRet);
                        //
                        return;
                    }

                    //Check whether fingerprint data already exists.
                    if (doubleCheckFlag == true)
                    {
                        int identifiedID = 0;
                        vnRet = ObjFpReader.pisIdentify(contextId, feature[fpExtractCount],
                                                         ref identifiedID, updatedTemplate, ref updatedFlag);

                        if (vnRet == ObjFpReader.PISFP_OK)
                        {
                            infoString.Text = string.Format(("Fingerprint duplication!"));
                            return;
                        }
                    }

                    //Save Fp image
                    SaveFpImage(fpExtractCount, userId, FingerId);
                    fpExtractCount++;
                    continuosFpPressCount = 0;

                    if (flag >= 3)
                        flag = 1;
                    if (fpExtractCount == 3)
                    {
                        break;
                    }
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_PromptTakeoffFinger;
                    }
                }

                //Tips for finger operation after getting pictures
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_PromptTakeoffFinger)
                {
                    if (isCheckFp != 0)
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
                        continue;
                    }
                    continue;

                }
            }

            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);

            if (StopFlag == true)
            {
                infoString.Text = "Stop Enroll!";
                return;
            }

            //Generating template
            vnRet = ObjFpReader.pisCreateTemplate(contextId, feature[0], feature[1], feature[2], template);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                infoString.Text = ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.CREATE_TEMPLATE_FUNC, vnRet);
                //Delete data
                delFromDeviceArray(userId, FingerId);
                return;
            }

            int FPID = 0;
            FPID = userId * 100 + FingerId;
            //Add in recognition
            vnRet = ObjFpReader.pisAddTptArray(contextId, FPID, template);
            if (vnRet != ObjFpReader.PISFP_OK)
            {
                infoString.Text = ErrorDescription(ObjFpReader.ENROLL_PROC, ObjFpReader.ADD_TPT_ARRAY_FUNC, vnRet);

                return;
            }

            //
            fpDataList.Add(template);

            try
            {
                if (SaveFingerPrintData != null) SaveFingerPrintData(1, userId, FingerId, template, template.Length);
            }
            catch (Exception ex) { }

            // SAK_DEBUG FINGERPRINT DATA

            infoString.Text = string.Format(" Enroll {0}-{1} fingerprint success!", userId.ToString(), FingerId.ToString());
            FingerId++;
            infoString.Text = FingerId.ToString();
        }
        /// <summary>
        /// Exit button
        /// </summary>

        public void Exit()
        {
            StopFlag = true;
            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
            ObjFpReader.pisCloseDevice(contextId);
            ObjFpReader.pisDestroyContext(contextId);
        }
        private void SaveFpImage(int fpExtractCount, int userId, int fingerId)
        {
            // SAK_DEBUG SAVE FINGERPRINT IMAGE
            Image img = ToGrayBitmap(imageBuffer, imageWidth, imageHeight);
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            imagedata = ms.GetBuffer();

            /*            string currPathImage = Application.StartupPath;

                        string subPathImage = currPathImage + string.Format("\\FpImage\\{0}", userId.ToString());
                        if (false == System.IO.Directory.Exists(subPathImage))
                        {
                            System.IO.Directory.CreateDirectory(subPathImage);
                        }
                        using (var fs = new FileStream(string.Format("FpImage\\{0}\\{1}({2}).bmp", userId.ToString(), fingerId.ToString(), fpExtractCount), FileMode.OpenOrCreate))
                        {
                            BinaryWriter bw = new BinaryWriter(fs);
                            bw.Write(imagedata, 0, imagedata.Length);
                        }
                        */

            try
            {
                if (SaveFingerPrintImage != null) SaveFingerPrintImage(userId, fingerId, fpExtractCount, imagedata, imagedata.Length);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void promptPressFinger(int PressCount, ref String infoString)
        {
            if (PressCount < 0) infoString = "Please press your finger!";
            else infoString = string.Format("Please press your finger - {0}", PressCount);
            Application.DoEvents();
        }

        public String Verify(ref int user, ref int finger)
        {
            user = -1;
            finger = -1;
            int vnRet;
            //Control equipment lamp
            int temp_DeviceCompany = deviceCompany;
            if (temp_DeviceCompany == ObjFpReader.PRODUCT_HYSOON)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);
            }
            else if (temp_DeviceCompany == ObjFpReader.PRODUCT_TAIWAN)
            {
                ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_ON);

            }

            if (StopFlag) StopFlag = false;
            int isCheckFp = 0, fpArea = 0;
            bool doubleCheckFlag = true;
            byte[] RECardNo = new byte[256];
            string CardNo = "";
            ObjFpReader.CaptureFpStatus capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;

            while (!StopFlag)
            //while (true)
            {
                Application.DoEvents();
                RECardNo = new byte[256];
                memset(feature[0], 0x00, featureSize);
                memset(updatedTemplate, 0x00, templateSize);

                vnRet = ObjFpReader.pisGetCardNumber(contextId, RECardNo);
                if (vnRet == 0)
                {
                    CardNo = GetWGCardNo(RECardNo);

                    //txtCardNum.Text = CardNo;

                }

                vnRet = ObjFpReader.pisCapture(contextId, imageBuffer);
                if (vnRet == ObjFpReader.PISFP_ERR_NOT_CONNECT_DEV)
                {

                    ObjFpReader.pisCloseDevice(contextId);

                    vnRet = ObjFpReader.pisOpenDevice(contextId, devIdList[cbbDevice.SelectedIndex]);
                    System.Threading.Thread.Sleep(1000);
                    //continue;
                    return ErrorDescription(ObjFpReader.VERIFY_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);
                }
                else if (vnRet != ObjFpReader.PISFP_OK)
                {

                    ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_ALLLED, ObjFpReader.PISFP_LED_OFF);
                    return ErrorDescription(ObjFpReader.VERIFY_PROC, ObjFpReader.CAPTURE_FUNC, vnRet);
                }

                DrawFpImage();

                vnRet = ObjFpReader.pisCheckFp(contextId, imageBuffer, imageWidth, imageHeight, imageRes, ref isCheckFp, ref fpArea);
                // txtInfo.Text = string.Empty;
                //Initialization
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_Init)
                {
                    if (isCheckFp != 0)
                    {
                        // txtInfo.Text = ("Please leave your fingers.");
                        continue;
                    }
                    else
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger;
                    }
                }

                //Wait for the finger to press down.
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_WaitPressFinger)
                {
                    if (isCheckFp == 0)
                    {
                        continue;
                    }

                    if (fpArea > 80)
                    {
                        capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured;
                    }
                }

                //Processing captured images
                if (capFpStatus == ObjFpReader.CaptureFpStatus.CapFp_GoodFpCaptured)
                {
                    // Dear Noor Fingerprint extraction FROM CAPTURED imageBuffer to feature byte array using maximum fingerprint image
                    if (ObjFpReader.pisProcess(contextId, imageBuffer, imageWidth, imageHeight, imageRes,
                        feature[0]) != ObjFpReader.PISFP_OK)
                    {
                        continue;
                    }

                    //Check if fpdata is already there.
                    if (doubleCheckFlag == true)
                    {
                        int identifiedID = 0;
                        vnRet = ObjFpReader.pisIdentify(contextId, feature[0],
                                                         ref identifiedID, updatedTemplate, ref updatedFlag);

                        if (vnRet == ObjFpReader.PISFP_OK)
                        {
                            //txtInfo.Text = string.Format("User number {0}-{1} identifies successfully", identifiedID / 100, identifiedID % 10);
                            user = identifiedID / 100;
                            finger = identifiedID % 10;
                            ObjFpReader.pisLedControl(contextId, ObjFpReader.PISFP_BKLED, ObjFpReader.PISFP_LED_OFF);
                            return "SUCCESS";
                        }
                        else
                        {
                            if (isCheckFp != 0)
                                //txtInfo.Text = ("Please press your finger again.");
                                MessageBox.Show("Please press your finger again.");
                        }
                        //txtInfo.Text = string.Empty;
                        if (isCheckFp == 0)
                            capFpStatus = ObjFpReader.CaptureFpStatus.CapFp_Init;
                        continue;
                    }

                }

            }

            return "SUCCESS";
        }

        public string GetWGCardNo(byte[] CardNo)
        {
            long a = 0;

            string card = string.Format("{0:X8}", Convert.ToInt64(Convert.ToInt64(Encoding.Default.GetString(CardNo)).ToString("0000000000")));
            //if (!)
            //    card = card.Substring(2, card.Length - 2);
            a = Convert.ToInt64(card, 16);
            return a.ToString();
        }

    }

}
