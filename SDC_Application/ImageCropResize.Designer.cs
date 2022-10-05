namespace SDC_Application
{
    partial class ImageCropForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCropForm));
            this.btnContrastImage = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.numUpDnBrightnessImage = new System.Windows.Forms.NumericUpDown();
            this.numUpDnContrastImage = new System.Windows.Forms.NumericUpDown();
            this.btnBrightnessImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGrayScaleImage = new System.Windows.Forms.Button();
            this.btnInvertColors = new System.Windows.Forms.Button();
            this.btnRotateImage = new System.Windows.Forms.Button();
            this.btnCenterCropBox = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbSelectedCropBoxSize = new System.Windows.Forms.ComboBox();
            this.cmbSelectedAspectRatio = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabelCropboxLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnBrightnessImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnContrastImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContrastImage
            // 
            this.btnContrastImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnContrastImage.Enabled = false;
            this.btnContrastImage.ImageIndex = 7;
            this.btnContrastImage.ImageList = this.imageList1;
            this.btnContrastImage.Location = new System.Drawing.Point(648, 1);
            this.btnContrastImage.Name = "btnContrastImage";
            this.btnContrastImage.Size = new System.Drawing.Size(36, 23);
            this.btnContrastImage.TabIndex = 18;
            this.btnContrastImage.Tag = "";
            this.btnContrastImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnContrastImage, "Image Contrast");
            this.btnContrastImage.UseVisualStyleBackColor = false;
            this.btnContrastImage.Click += new System.EventHandler(this.btnContrastImage_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "refresh.png");
            this.imageList1.Images.SetKeyName(2, "window_view.png");
            this.imageList1.Images.SetKeyName(3, "redo.png");
            this.imageList1.Images.SetKeyName(4, "redo.png");
            this.imageList1.Images.SetKeyName(5, "palette.png");
            this.imageList1.Images.SetKeyName(6, "rotateclockw16.gif");
            this.imageList1.Images.SetKeyName(7, "contrast_high.png");
            this.imageList1.Images.SetKeyName(8, "color_wheel.png");
            this.imageList1.Images.SetKeyName(9, "shape_move_backwards.png");
            this.imageList1.Images.SetKeyName(10, "picture_empty.png");
            this.imageList1.Images.SetKeyName(11, "cropImage.png");
            // 
            // numUpDnBrightnessImage
            // 
            this.numUpDnBrightnessImage.Enabled = false;
            this.numUpDnBrightnessImage.Location = new System.Drawing.Point(588, 3);
            this.numUpDnBrightnessImage.Name = "numUpDnBrightnessImage";
            this.numUpDnBrightnessImage.Size = new System.Drawing.Size(50, 20);
            this.numUpDnBrightnessImage.TabIndex = 15;
            this.numUpDnBrightnessImage.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDnBrightnessImage.ValueChanged += new System.EventHandler(this.numUpDnBrightnessImage_ValueChanged);
            // 
            // numUpDnContrastImage
            // 
            this.numUpDnContrastImage.Enabled = false;
            this.numUpDnContrastImage.Location = new System.Drawing.Point(684, 3);
            this.numUpDnContrastImage.Name = "numUpDnContrastImage";
            this.numUpDnContrastImage.Size = new System.Drawing.Size(50, 20);
            this.numUpDnContrastImage.TabIndex = 14;
            this.numUpDnContrastImage.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDnContrastImage.ValueChanged += new System.EventHandler(this.numUpDnContrastImage_ValueChanged);
            // 
            // btnBrightnessImage
            // 
            this.btnBrightnessImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrightnessImage.Enabled = false;
            this.btnBrightnessImage.ImageIndex = 8;
            this.btnBrightnessImage.ImageList = this.imageList1;
            this.btnBrightnessImage.Location = new System.Drawing.Point(553, 2);
            this.btnBrightnessImage.Name = "btnBrightnessImage";
            this.btnBrightnessImage.Size = new System.Drawing.Size(35, 23);
            this.btnBrightnessImage.TabIndex = 12;
            this.btnBrightnessImage.Tag = "";
            this.btnBrightnessImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnBrightnessImage, "Image Brightness");
            this.btnBrightnessImage.UseVisualStyleBackColor = false;
            this.btnBrightnessImage.Click += new System.EventHandler(this.btnBrightnessImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 519);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Jpeg Image*.jpg|*.jpg|Gif Image *.gif|*.gif|BMP Image*.bmp|*.bmp";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.numUpDnContrastImage);
            this.panel1.Controls.Add(this.btnContrastImage);
            this.panel1.Controls.Add(this.numUpDnBrightnessImage);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnGrayScaleImage);
            this.panel1.Controls.Add(this.btnBrightnessImage);
            this.panel1.Controls.Add(this.btnInvertColors);
            this.panel1.Controls.Add(this.btnRotateImage);
            this.panel1.Controls.Add(this.btnCenterCropBox);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.cmbSelectedCropBoxSize);
            this.panel1.Controls.Add(this.cmbSelectedAspectRatio);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 28);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Enabled = false;
            this.btnOK.ImageIndex = 0;
            this.btnOK.Location = new System.Drawing.Point(41, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(36, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.toolTip1.SetToolTip(this.btnOK, "Save Image (Orginal is NOT modified)");
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGrayScaleImage
            // 
            this.btnGrayScaleImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGrayScaleImage.Enabled = false;
            this.btnGrayScaleImage.ImageIndex = 10;
            this.btnGrayScaleImage.ImageList = this.imageList1;
            this.btnGrayScaleImage.Location = new System.Drawing.Point(450, 2);
            this.btnGrayScaleImage.Name = "btnGrayScaleImage";
            this.btnGrayScaleImage.Size = new System.Drawing.Size(36, 23);
            this.btnGrayScaleImage.TabIndex = 7;
            this.btnGrayScaleImage.Tag = "";
            this.btnGrayScaleImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnGrayScaleImage, "Convert Image  to Grayscale");
            this.btnGrayScaleImage.UseVisualStyleBackColor = false;
            this.btnGrayScaleImage.Click += new System.EventHandler(this.btnGrayScaleImage_Click);
            // 
            // btnInvertColors
            // 
            this.btnInvertColors.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInvertColors.Enabled = false;
            this.btnInvertColors.ImageIndex = 9;
            this.btnInvertColors.ImageList = this.imageList1;
            this.btnInvertColors.Location = new System.Drawing.Point(415, 2);
            this.btnInvertColors.Name = "btnInvertColors";
            this.btnInvertColors.Size = new System.Drawing.Size(36, 23);
            this.btnInvertColors.TabIndex = 6;
            this.btnInvertColors.Tag = "";
            this.btnInvertColors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnInvertColors, "Invert Colors");
            this.btnInvertColors.UseVisualStyleBackColor = false;
            this.btnInvertColors.Click += new System.EventHandler(this.btnInvertColors_Click);
            // 
            // btnRotateImage
            // 
            this.btnRotateImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRotateImage.Enabled = false;
            this.btnRotateImage.ImageIndex = 6;
            this.btnRotateImage.ImageList = this.imageList1;
            this.btnRotateImage.Location = new System.Drawing.Point(380, 2);
            this.btnRotateImage.Name = "btnRotateImage";
            this.btnRotateImage.Size = new System.Drawing.Size(36, 23);
            this.btnRotateImage.TabIndex = 5;
            this.btnRotateImage.Tag = "";
            this.btnRotateImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRotateImage, "Rotate Image 90 CW");
            this.btnRotateImage.UseVisualStyleBackColor = false;
            this.btnRotateImage.Click += new System.EventHandler(this.btnRotateImage_Click);
            // 
            // btnCenterCropBox
            // 
            this.btnCenterCropBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCenterCropBox.Enabled = false;
            this.btnCenterCropBox.ImageIndex = 2;
            this.btnCenterCropBox.ImageList = this.imageList1;
            this.btnCenterCropBox.Location = new System.Drawing.Point(334, 2);
            this.btnCenterCropBox.Name = "btnCenterCropBox";
            this.btnCenterCropBox.Size = new System.Drawing.Size(36, 23);
            this.btnCenterCropBox.TabIndex = 4;
            this.btnCenterCropBox.Tag = "";
            this.btnCenterCropBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnCenterCropBox, "Center Crop Rectangle");
            this.btnCenterCropBox.UseVisualStyleBackColor = false;
            this.btnCenterCropBox.Click += new System.EventHandler(this.btnCenterCropBox_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReset.Enabled = false;
            this.btnReset.ImageIndex = 1;
            this.btnReset.ImageList = this.imageList1;
            this.btnReset.Location = new System.Drawing.Point(298, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(36, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Tag = "";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnReset, "Reset");
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbSelectedCropBoxSize
            // 
            this.cmbSelectedCropBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedCropBoxSize.Enabled = false;
            this.cmbSelectedCropBoxSize.FormattingEnabled = true;
            this.cmbSelectedCropBoxSize.Location = new System.Drawing.Point(231, 3);
            this.cmbSelectedCropBoxSize.Name = "cmbSelectedCropBoxSize";
            this.cmbSelectedCropBoxSize.Size = new System.Drawing.Size(61, 21);
            this.cmbSelectedCropBoxSize.TabIndex = 2;
            this.cmbSelectedCropBoxSize.Tag = "Crop Box Size";
            this.cmbSelectedCropBoxSize.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectedCropBoxSize_SelectionChangeCommitted);
            // 
            // cmbSelectedAspectRatio
            // 
            this.cmbSelectedAspectRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedAspectRatio.Enabled = false;
            this.cmbSelectedAspectRatio.FormattingEnabled = true;
            this.cmbSelectedAspectRatio.Location = new System.Drawing.Point(80, 4);
            this.cmbSelectedAspectRatio.Name = "cmbSelectedAspectRatio";
            this.cmbSelectedAspectRatio.Size = new System.Drawing.Size(145, 21);
            this.cmbSelectedAspectRatio.TabIndex = 1;
            this.cmbSelectedAspectRatio.Tag = "Crop Box Aspect Ratio";
            this.cmbSelectedAspectRatio.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectedAspectRatio_SelectionChangeCommitted);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpen.ImageIndex = 0;
            this.btnOpen.ImageList = this.imageList1;
            this.btnOpen.Location = new System.Drawing.Point(3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Tag = "";
            this.toolTip1.SetToolTip(this.btnOpen, "Load Image");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabelCropboxLocation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabelCropboxLocation
            // 
            this.tsLabelCropboxLocation.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsLabelCropboxLocation.Name = "tsLabelCropboxLocation";
            this.tsLabelCropboxLocation.Size = new System.Drawing.Size(86, 17);
            this.tsLabelCropboxLocation.Text = "No image loaded";
            this.tsLabelCropboxLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 519);
            this.panel2.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "jpg";
            this.saveFileDialog1.FileName = "testImage.jpg";
            this.saveFileDialog1.Filter = "Jpeg (*.jpg)|*.jpg";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ImageIndex = 11;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(492, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 7;
            this.button1.Tag = "";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button1, "Crop Image");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageCropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageCropForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crop / Resize Image";
            this.Load += new System.EventHandler(this.ImageCropForm_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnBrightnessImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnContrastImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrightnessImage;
        private System.Windows.Forms.NumericUpDown numUpDnBrightnessImage;
        private System.Windows.Forms.NumericUpDown numUpDnContrastImage;
        private System.Windows.Forms.Button btnContrastImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRotateImage;
        private System.Windows.Forms.Button btnCenterCropBox;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbSelectedCropBoxSize;
        private System.Windows.Forms.ComboBox cmbSelectedAspectRatio;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnGrayScaleImage;
        private System.Windows.Forms.Button btnInvertColors;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelCropboxLocation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
    }
}

