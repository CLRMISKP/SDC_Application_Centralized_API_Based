using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

// Based upon code from http://www.codeproject.com/KB/graphics/ImageResizer.aspx
// and various codeproject articles

// Some known annoyances:

// o When form is moved the crop rect is resized to the selected drop down size
//   even if the user had already resized it
// o No portrait mode support
// o Image processing needs a quick preview thumbnail
// o Preview of crop
// o There are some rounding errors
// o I know absolutely nothing about using the image quality interpolations
//   so everything is the default
// o Code is not very clean

namespace SDC_Application  // machines have no conscience
{
    public partial class ImageCropForm : Form
    {
        // image processing stuff
        public Image ImageIn = null;
        protected Image ImageInWorking = null;
        Bitmap bmpPicture;
        System.Drawing.Imaging.ImageAttributes iaPicture;
        System.Drawing.Imaging.ColorMatrix cmPicture;
        Graphics gfxPicture;
        Rectangle rctPicture;
        float brightness;
        float contrast;

        // cropping view stuff
        Rectangle CropRect;
        Rectangle rcLT, rcRT, rcLB, rcRB;
        Rectangle rcOld, rcNew;
        Rectangle rcOriginal;
        Rectangle rcBegin;
        SolidBrush BrushRect;
        HatchBrush BrushRectSmall;
        Color BrushColor;

        int AlphaBlend;
        int nSize;
        int nWd;
        int nHt;
        int nResizeRT;
        int nResizeBL;
        int nResizeLT;
        int nResizeRB;
        int nThatsIt;
        int nCropRect;
        int CropWidth;

        int imageWidth;
        int imageHeight;
        int HeightOffset;

        double CropAspectRatio;
        double ImageAspectRatio;
        double ZoomedRatio;

        Point ptOld;
        Point ptNew;

        string imageStats;
        string filename;

        List<double> ratios;

        public ImageCropForm()
        {
            InitializeComponent();

            // double buffer
            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true);

            // build list of crop ratios
            ratios = new List<double>();
            cmbSelectedAspectRatio.Items.Add("7:9  (0.77)  Passport");
            ratios.Add(3.5 / 4.5);

            cmbSelectedAspectRatio.Items.Add("4:3  (1.3)  Normal Display");
            ratios.Add(4.0 / 3.0);
            cmbSelectedAspectRatio.Items.Add("16:9 (1.78) High Definition");
            ratios.Add(16.0 / 9.0);
            cmbSelectedAspectRatio.Items.Add("3:2 (1.5) Digital Camera");
            ratios.Add(3.0 / 2.0);
            cmbSelectedAspectRatio.Items.Add("1:1 (1.0) Square");
            ratios.Add(1.0);
            cmbSelectedAspectRatio.SelectedIndex = 0;

            // build list of common sizes
            //cmbSelectedCropBoxSize.Items.Add("320");
            cmbSelectedCropBoxSize.Items.Add("800");
            cmbSelectedCropBoxSize.Items.Add("1024");
            cmbSelectedCropBoxSize.Items.Add("1280");
            cmbSelectedCropBoxSize.Items.Add("1440");
            cmbSelectedCropBoxSize.Items.Add("1920");



            cmbSelectedCropBoxSize.SelectedIndex = 1;
            CropWidth = Convert.ToInt16(cmbSelectedCropBoxSize.Text);

            numUpDnBrightnessImage_ValueChanged(null, null);
            numUpDnContrastImage_ValueChanged(null, null);

            // offset to make width & height proportional to image
            HeightOffset = panel1.Height + statusStrip1.Height +
                            SystemInformation.CaptionHeight + (SystemInformation.BorderSize.Height * 2);

            // do initializations
            UpdateAspectRatio();
            InitializeCropRectangle();
        }

        void InitializeCropRectangle()
        {
            AlphaBlend = 48;

            nSize     = 8;
            nWd = CropWidth =Convert.ToInt16(cmbSelectedCropBoxSize.Text);
            nHt       = 1;

            nThatsIt  = 0;
            nResizeRT = 0;
            nResizeBL = 0;
            nResizeLT = 0;
            nResizeRB = 0;

            CropAspectRatio = ratios[cmbSelectedAspectRatio.SelectedIndex];

            BrushColor = Color.White;
            BrushRect  = new SolidBrush(Color.FromArgb(AlphaBlend, BrushColor.R, BrushColor.G, BrushColor.B));

            BrushColor = Color.Yellow;
            BrushRectSmall = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(192, BrushColor.R, BrushColor.G, BrushColor.B));

            ptOld = new Point(0, 0);
            rcBegin = new Rectangle();
            rcOriginal = new Rectangle(0, 0, 0, 0);
            rcLT = new Rectangle(0, 0, nSize, nSize);
            rcRT = new Rectangle(0, 0, nSize, nSize);
            rcLB = new Rectangle(0, 0, nSize, nSize);
            rcRB = new Rectangle(0, 0, nSize, nSize);
            rcOld = CropRect = new Rectangle(0, 0, nWd, nHt);
  
            AdjustResizeRects();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                LoadImage(filename);
                btnReset.Enabled = true;
                btnCenterCropBox.Enabled = true;
                btnRotateImage.Enabled = true;
                btnInvertColors.Enabled = true;
                btnGrayScaleImage.Enabled = true;
                btnBrightnessImage.Enabled = true;
                numUpDnBrightnessImage.Enabled = true;
                btnContrastImage.Enabled = true;
                numUpDnContrastImage.Enabled = true;
                cmbSelectedAspectRatio.Enabled = true;
                cmbSelectedCropBoxSize.Enabled = true;
                btnOK.Enabled = true;
            }
        }



        private void LoadImage(string file)
        {
            Cursor = Cursors.AppStarting;

            pictureBox1.Image = Image.FromFile(file);

            imageWidth = pictureBox1.Image.Width;
            imageHeight = pictureBox1.Image.Height;

            imageStats = String.Format("{0} | {1}x{2} | Aspect {3:0.0}",
                System.IO.Path.GetFileName(file), imageWidth, imageHeight,
                (double)((double)imageWidth / (double)imageHeight)
                );


            // logic for portrait mode ???
            if (imageWidth > imageHeight)
            {
                ImageAspectRatio = (double)imageWidth / (double)imageHeight;
                this.Width = 800 + (SystemInformation.BorderSize.Width * 2);
                this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;
            }
            else
            {
                ImageAspectRatio = (double)imageHeight / (double)imageWidth;
                this.Height = 800;
                this.Width = (int)((this.Height / ImageAspectRatio)) + HeightOffset;
            }

            btnCenterCropBox_Click(null, null);
            Form1_ResizeEnd(null, null);
            Cursor = Cursors.Default;
        }
        private void LoadImage(Image img)
        {
            Cursor = Cursors.AppStarting;

            if (img == null) img = new Bitmap (700,900);
            pictureBox1.Image = img;

            imageWidth = pictureBox1.Image.Width;
            imageHeight = pictureBox1.Image.Height;

            imageStats = String.Format("{0} | {1}x{2} | Aspect {3:0.0}",
                "Image", imageWidth, imageHeight,
                (double)((double)imageWidth / (double)imageHeight)
                );


            // logic for portrait mode ???
            if (imageWidth > imageHeight)
            {
                ImageAspectRatio = (double)imageWidth / (double)imageHeight;
                this.Width = 800 + (SystemInformation.BorderSize.Width * 2);
                this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;
            }
            else
            {
                ImageAspectRatio = (double)imageHeight / (double)imageWidth;
                this.Height = 800;
                this.Width = (int)((this.Height / ImageAspectRatio)) + HeightOffset;
            }

            btnCenterCropBox_Click(null, null);
            Form1_ResizeEnd(null, null);
            Cursor = Cursors.Default;
        }

        private void btnRotateImage_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();
            Cursor = Cursors.Default;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                // display checkerboard
                bool xGrayBox = true;
                int backgroundX = 0;
                while (backgroundX < pictureBox1.Width)
                {
                    int backgroundY = 0;
                    bool yGrayBox = xGrayBox;
                    while (backgroundY < pictureBox1.Height)
                    {
                        int recWidth = (int)((backgroundX + 50 > pictureBox1.Width) ? pictureBox1.Width - backgroundX : 50);
                        int recHeight = (int)((backgroundY + 50 > pictureBox1.Height) ? pictureBox1.Height - backgroundY : 50);
                        e.Graphics.FillRectangle(((Brush)(yGrayBox ? Brushes.LightGray : Brushes.Gainsboro)), backgroundX, backgroundY, recWidth + 2, recHeight + 2);
                        backgroundY += 50;
                        yGrayBox = !yGrayBox;
                    }
                    backgroundX += 50;
                    xGrayBox = !xGrayBox;
                }
            }
            else
            {
                // main crop box 
                e.Graphics.FillRectangle((BrushRect), CropRect);

                // corner drag boxes
                e.Graphics.FillRectangle((BrushRectSmall), rcLT);
                e.Graphics.FillRectangle((BrushRectSmall), rcRT);
                e.Graphics.FillRectangle((BrushRectSmall), rcLB);
                e.Graphics.FillRectangle((BrushRectSmall), rcRB);

                AdjustResizeRects();
                
           }
            base.OnPaint(e);
        }

        private void btnCenterCropBox_Click(object sender, EventArgs e)
        {
            UpdateAspectRatio();

            CropRect.X = (pictureBox1.ClientRectangle.Width - CropRect.Width) / 2;
            CropRect.Y = (pictureBox1.ClientRectangle.Height - CropRect.Height)/ 2;

            AdjustResizeRects();
            pictureBox1.Refresh();
        }

        public void AdjustResizeRects()
        {
            rcLT.X = CropRect.Left;
            rcLT.Y = CropRect.Top;

            rcRT.X = CropRect.Right - rcRT.Width;
            rcRT.Y = CropRect.Top;

            rcLB.X = CropRect.Left;
            rcLB.Y = CropRect.Bottom - rcLB.Height;

            rcRB.X = CropRect.Right - rcRB.Width;
            rcRB.Y = CropRect.Bottom - rcRB.Height;
        }
        
        private void DrawDragRect(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AdjustResizeRects();
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Point pt = new Point(e.X, e.Y);

            if (rcLT.Contains(pt))
                Cursor = Cursors.SizeNWSE;
            else
                if (rcRT.Contains(pt))
                    Cursor = Cursors.SizeNESW;
                else
                    if (rcLB.Contains(pt))
                        Cursor = Cursors.SizeNESW;
                    else
                        if (rcRB.Contains(pt))
                            Cursor = Cursors.SizeNWSE;
                        else
                            if (CropRect.Contains(pt))
                                Cursor = Cursors.SizeAll;
                            else
                                Cursor = Cursors.Default;


            if (e.Button == MouseButtons.Left)
            {
               if (nResizeRB == 1) 
                {
                    rcNew.X = CropRect.X;
                    rcNew.Y = CropRect.Y;
                    rcNew.Width = pt.X - rcNew.Left;
                    rcNew.Height = pt.Y - rcNew.Top;

                    if (rcNew.X > rcNew.Right)
                    {
                        rcNew.Offset(-nWd, 0);
                        if (rcNew.X < 0)
                            rcNew.X = 0;
                    }
                    if (rcNew.Y > rcNew.Bottom)
                    {
                        rcNew.Offset(0, -nHt);
                        if (rcNew.Y < 0)
                            rcNew.Y = 0;
                    }

                    DrawDragRect(e);
                    rcOld = CropRect = rcNew;
                    Cursor = Cursors.SizeNWSE;
                }
                else
                    if (nResizeBL == 1)
                    {
                        rcNew.X = pt.X;
                        rcNew.Y = CropRect.Y;
                        rcNew.Width = CropRect.Right - pt.X;
                        rcNew.Height = pt.Y - rcNew.Top;

                        if (rcNew.X > rcNew.Right)
                        {
                            rcNew.Offset(nWd, 0);
                            if (rcNew.Right > ClientRectangle.Width)
                                rcNew.Width = ClientRectangle.Width - rcNew.X;
                        }
                        if (rcNew.Y > rcNew.Bottom)
                        {
                            rcNew.Offset(0, -nHt);
                            if (rcNew.Y < 0)
                                rcNew.Y = 0;
                        }

                        DrawDragRect(e);
                        rcOld = CropRect = rcNew;
                        Cursor = Cursors.SizeNESW;
                    }
                    else
                        if (nResizeRT == 1)
                        {
                            rcNew.X = CropRect.X;
                            rcNew.Y = pt.Y;
                            rcNew.Width = pt.X - rcNew.Left;
                            rcNew.Height = CropRect.Bottom - pt.Y;

                            if (rcNew.X > rcNew.Right)
                            {
                                rcNew.Offset(-nWd, 0);
                                if (rcNew.X < 0)
                                    rcNew.X = 0;
                            }
                            if (rcNew.Y > rcNew.Bottom)
                            {
                                rcNew.Offset(0, nHt);
                                if (rcNew.Bottom > ClientRectangle.Height)
                                    rcNew.Y = ClientRectangle.Height - rcNew.Height;
                            }

                            DrawDragRect(e);
                            rcOld = CropRect = rcNew;
                            Cursor = Cursors.SizeNESW;
                        }
                        else
                            if (nResizeLT == 1)
                            {
                                rcNew.X = pt.X;
                                rcNew.Y = pt.Y;
                                rcNew.Width = CropRect.Right - pt.X;
                                rcNew.Height = CropRect.Bottom - pt.Y;

                                if (rcNew.X > rcNew.Right)
                                {
                                    rcNew.Offset(nWd, 0);
                                    if (rcNew.Right > ClientRectangle.Width)
                                        rcNew.Width = ClientRectangle.Width - rcNew.X;
                                }
                                if (rcNew.Y > rcNew.Bottom)
                                {
                                    rcNew.Offset(0, nHt);
                                    if (rcNew.Bottom > ClientRectangle.Height)
                                        rcNew.Height = ClientRectangle.Height - rcNew.Y;
                                }

                                DrawDragRect(e);
                                rcOld = CropRect = rcNew;
                                Cursor = Cursors.SizeNWSE;
                            }
                            else
                                if (nCropRect == 1) //Moving the rectangle
                                {
                                    ptNew = pt;
                                    int dx = ptNew.X - ptOld.X;
                                    int dy = ptNew.Y - ptOld.Y;
                                    CropRect.Offset(dx, dy);
                                    rcNew = CropRect;
                                    DrawDragRect(e);
                                    ptOld = ptNew;
                                }

                AdjustResizeRects();
                DisplayLocation();
                pictureBox1.Update();
            }

            base.OnMouseMove(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            rcOriginal = CropRect;
            rcBegin = CropRect;

            if (rcRB.Contains(pt))
            {
                rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                rcNew = rcOld;
                nResizeRB = 1;
            }
            else
                if (rcLB.Contains(pt))
                {
                    rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                    rcNew = rcOld;
                    nResizeBL = 1;
                }
                else
                    if (rcRT.Contains(pt))
                    {
                        rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                        rcNew = rcOld;
                        nResizeRT = 1;
                    }
                    else
                        if (rcLT.Contains(pt))
                        {
                            rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                            rcNew = rcOld;
                            nResizeLT = 1;
                        }
                        else
                            if (CropRect.Contains(pt))
                            {
                                nResizeBL = nResizeLT = nResizeRB = nResizeRT = 0;
                                nCropRect = 1;
                                ptNew = ptOld = pt;
                            }
            nThatsIt = 1;
            base.OnMouseDown(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (nThatsIt == 0) 
                return;
            
            nCropRect = 0;
            nResizeRB = 0;
            nResizeBL = 0;
            nResizeRT = 0;
            nResizeLT = 0;

            if (CropRect.Width <= 0 || CropRect.Height <= 0)
                CropRect = rcOriginal;

            if (CropRect.Right > ClientRectangle.Width)
                CropRect.Width = ClientRectangle.Width - CropRect.X;

            if (CropRect.Bottom > ClientRectangle.Height)
                CropRect.Height = ClientRectangle.Height - CropRect.Y;

            if (CropRect.X < 0)
                CropRect.X = 0;

            if (CropRect.Y < 0)
                CropRect.Y = 0;
 
            // need to add logic for portrait mode of crop box in this
            // area

            // now that the crop box position is established
            // force it to the proper aspect ratio
            // and scale it

            if (CropRect.Width > CropRect.Height)
            {
                CropRect.Height = (int)(CropRect.Width / CropAspectRatio);
            }
            else
            {
                CropRect.Width = (int)(CropRect.Height * CropAspectRatio);
            }

            AdjustResizeRects();
            pictureBox1.Refresh();

            base.OnMouseUp(e);

            nWd = rcNew.Width;
            nHt = rcNew.Height;
            rcBegin = rcNew;

            DisplayLocation();
        }
        
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void cmbSelectedAspectRatio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateAspectRatio();
        }

        private void cmbSelectedCropBoxSize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CropWidth = Convert.ToInt16(cmbSelectedCropBoxSize.Text);

            CropRect.X = 0;
            CropRect.Y = 0;

            UpdateAspectRatio();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (ImageAspectRatio == 0)
                return;

            this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;

            // logic for portrait mode goes here
            // for form resize

            UpdateAspectRatio();
            this.Refresh();
        }

        private void PreparePicture()
        {
            // If there's a picture
            if (pictureBox1.Image != null)
            {
                // Create new Bitmap object with the size of the picture
                bmpPicture = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

                // Image attributes for setting the attributes of the picture
                iaPicture = new System.Drawing.Imaging.ImageAttributes();
            }
        }

        private void FinalizePicture()
        {
            // Set the new color matrix
            iaPicture.SetColorMatrix(cmPicture);

            // Set the Graphics object from the bitmap
            gfxPicture = Graphics.FromImage(bmpPicture);

            // New rectangle for the picture, same size as the original picture
            rctPicture = new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);

            // Draw the new image
            gfxPicture.DrawImage(pictureBox1.Image, rctPicture, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, iaPicture);

            // Set the PictureBox to the new bitmap
            pictureBox1.Image = bmpPicture;
        }

        private void btnInvertColors_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            PreparePicture();
            cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });
            FinalizePicture();

            Cursor = Cursors.Default;
        }

        private void btnGrayScaleImage_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            PreparePicture();
            cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[] {0.30f, 0.30f, 0.30f, 0, 0},
                new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
            FinalizePicture();

            Cursor = Cursors.Default;
        }

        private void btnBrightnessImage_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            float bf = brightness;

            PreparePicture();
            cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{1f,    0f,    0f,    0f,    0f},
                new float[]{0f,    1f,    0f,    0f,    0f},
                new float[]{0f,    0f,    1f,    0f,    0f},
                new float[]{0f,    0f,    0f,    1f,    0f},
                new float[]{bf,    bf,    bf,    1f,    1f}
            });
            FinalizePicture();

            Cursor = Cursors.Default;
        }

        private void btnContrastImage_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            float cf = 0.04f * contrast; 

            PreparePicture();

            cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{cf,    0f,    0f,    0f,   0f},
                new float[]{0f,    cf,    0f,    0f,   0f},
                new float[]{0f,    0f,    cf,    0f,   0f},
                new float[]{0f,    0f,    0f,    1f,   0f},
                new float[]{0.001f,    0.001f,    0.001f,    0f,   1f}
            });
            FinalizePicture();

            Cursor = Cursors.Default;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadImage(ImageIn);
        }

        private void numUpDnBrightnessImage_ValueChanged(object sender, EventArgs e)
        {
            //“brightness” ranges from -1 to +1
            // numeric up down is 0 to 100
            brightness = (float)(Convert.ToDouble(numUpDnBrightnessImage.Value) - 50.0) / 50.0f;
        }

        private void numUpDnContrastImage_ValueChanged(object sender, EventArgs e)
        {
            contrast = (float)(Convert.ToDouble(numUpDnContrastImage.Value));
        }

        private void DisplayLocation()
        {
            // assume not yet initialized
            if (pictureBox1.Image == null)
                return;

            tsLabelCropboxLocation.Text = String.Format("{0} |  Scale {1:0.00}% | Crop Area {2} x {3} | Crop X, Y {4}, {5}",
                                imageStats,
                                ZoomedRatio * 100.0, 
                                (int)((double)CropRect.Width / ZoomedRatio),
                                (int)((double)CropRect.Height / ZoomedRatio),
                                (int)((double)CropRect.X / ZoomedRatio),
                                (int)((double)CropRect.Y / ZoomedRatio)
                            );
        }

        private void UpdateAspectRatio()
        {
            int ratioIndex = cmbSelectedAspectRatio.SelectedIndex;

            CropAspectRatio = ratios[ratioIndex];
            int CropHeight = (int)((CropWidth / CropAspectRatio));

            try
            {
                ZoomedRatio = pictureBox1.ClientRectangle.Width / (double)imageWidth;
            }
            catch
            {
                // imageWidth is not yet established (division by zero)
                // force a value
                ZoomedRatio = 1.0;
            }

            // scale crop rect to image scale
            CropRect.Width  = (int)((double)CropWidth * ZoomedRatio); 
            CropRect.Height = (int)((double)CropHeight * ZoomedRatio); 

            // update crop box and refresh everything
            nThatsIt = 1;
            pictureBox1_MouseUp(null, null);
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            try {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CropImage()");
            }
            return null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // output image size is based upon the visible crop rectangle and scaled to 
            // the ratio of actual image size to displayed image size
            Bitmap bmp = null;

            Rectangle ScaledCropRect = new Rectangle();
            ScaledCropRect.X = (int)(CropRect.X / ZoomedRatio);
            ScaledCropRect.Y = (int)(CropRect.Y / ZoomedRatio);
            ScaledCropRect.Width = (int)((double)(CropRect.Width) / ZoomedRatio);
            ScaledCropRect.Height = (int)((double)(CropRect.Height) / ZoomedRatio);


                try
                {
                    ImageInWorking = (Bitmap)CropImage(pictureBox1.Image, ScaledCropRect);
                    LoadImage(ImageInWorking);
                    // 85% quality
                    //saveJpeg(saveFileDialog1.FileName, bmp, 85);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message, "btnOK_Click()");
                }
            

            if (bmp != null)
                bmp.Dispose();
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, (long)quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
            {
                MessageBox.Show("Can't find JPEG encoder?", "saveJpeg()");
                return;
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ImageIn = new Bitmap(ImageInWorking);
            this.Close();
        }

        private void ImageCropForm_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            ImageInWorking = ImageIn;
            LoadImage(ImageInWorking);
            btnReset.Enabled = true;
            btnCenterCropBox.Enabled = true;
            btnRotateImage.Enabled = true;
            btnInvertColors.Enabled = true;
            btnGrayScaleImage.Enabled = true;
            btnBrightnessImage.Enabled = true;
            numUpDnBrightnessImage.Enabled = true;
            btnContrastImage.Enabled = true;
            numUpDnContrastImage.Enabled = true;
            cmbSelectedAspectRatio.Enabled = true;
            cmbSelectedCropBoxSize.Enabled = true;
            btnOK.Enabled = true;  
        }
    }
}
