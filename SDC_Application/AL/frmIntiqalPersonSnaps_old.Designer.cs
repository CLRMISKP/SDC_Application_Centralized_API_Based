namespace SDC_Application.AL
{
    partial class frmIntiqalPersonSnaps_old
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntiqalPersonSnaps_old));
            this.txtpersonID = new System.Windows.Forms.TextBox();
            this.txtIntPersonImageid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grfIntiqalPersonSanps = new System.Windows.Forms.DataGridView();
            this.Selection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PersonPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.PersonFingerPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVerifyFingerPrint = new System.Windows.Forms.Button();
            this.btnLoadPicturefromFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.pboxPicture = new System.Windows.Forms.PictureBox();
            this.btnFingerPrintReset = new System.Windows.Forms.Button();
            this.pboxFingerPrint = new System.Windows.Forms.PictureBox();
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.btnPictureReset = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.CheckImage = new System.Windows.Forms.TabControl();
            this.NewPics = new System.Windows.Forms.TabPage();
            this.ViewPics = new System.Windows.Forms.TabPage();
            this.grdImagesRetrive = new System.Windows.Forms.DataGridView();
            this.ImageSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbCamera = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.bntCapture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFingerHysoon = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grfIntiqalPersonSanps)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFingerPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            this.CheckImage.SuspendLayout();
            this.NewPics.SuspendLayout();
            this.ViewPics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesRetrive)).BeginInit();
            this.tbCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpersonID
            // 
            this.txtpersonID.Location = new System.Drawing.Point(53, 83);
            this.txtpersonID.Name = "txtpersonID";
            this.txtpersonID.Size = new System.Drawing.Size(100, 33);
            this.txtpersonID.TabIndex = 8;
            this.txtpersonID.Visible = false;
            // 
            // txtIntPersonImageid
            // 
            this.txtIntPersonImageid.Location = new System.Drawing.Point(53, 44);
            this.txtIntPersonImageid.Name = "txtIntPersonImageid";
            this.txtIntPersonImageid.Size = new System.Drawing.Size(100, 33);
            this.txtIntPersonImageid.TabIndex = 7;
            this.txtIntPersonImageid.Text = "-1";
            this.txtIntPersonImageid.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "انگوٹھے کا نشان";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(764, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = " تصویر";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1133, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "نام";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(943, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 33);
            this.txtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grfIntiqalPersonSanps);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1195, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // grfIntiqalPersonSanps
            // 
            this.grfIntiqalPersonSanps.AllowUserToAddRows = false;
            this.grfIntiqalPersonSanps.AllowUserToDeleteRows = false;
            this.grfIntiqalPersonSanps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grfIntiqalPersonSanps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grfIntiqalPersonSanps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selection,
            this.PersonPic,
            this.PersonFingerPrint});
            this.grfIntiqalPersonSanps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grfIntiqalPersonSanps.Location = new System.Drawing.Point(10, 36);
            this.grfIntiqalPersonSanps.Name = "grfIntiqalPersonSanps";
            this.grfIntiqalPersonSanps.ReadOnly = true;
            this.grfIntiqalPersonSanps.Size = new System.Drawing.Size(1175, 228);
            this.grfIntiqalPersonSanps.TabIndex = 0;
            this.grfIntiqalPersonSanps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grfIntiqalPersonSanps_CellClick);
            // 
            // Selection
            // 
            this.Selection.HeaderText = "انتخاب کریں";
            this.Selection.Name = "Selection";
            this.Selection.ReadOnly = true;
            this.Selection.Width = 318;
            // 
            // PersonPic
            // 
            this.PersonPic.HeaderText = "تصویر";
            this.PersonPic.Name = "PersonPic";
            this.PersonPic.ReadOnly = true;
            this.PersonPic.Width = 318;
            // 
            // PersonFingerPrint
            // 
            this.PersonFingerPrint.HeaderText = "انگوٹھے کا نشان";
            this.PersonFingerPrint.Name = "PersonFingerPrint";
            this.PersonFingerPrint.ReadOnly = true;
            this.PersonFingerPrint.Visible = false;
            this.PersonFingerPrint.Width = 318;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFingerHysoon);
            this.groupBox3.Controls.Add(this.btnVerifyFingerPrint);
            this.groupBox3.Controls.Add(this.btnLoadPicturefromFile);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.txtpersonID);
            this.groupBox3.Controls.Add(this.pboxPicture);
            this.groupBox3.Controls.Add(this.txtIntPersonImageid);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnFingerPrintReset);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.pboxFingerPrint);
            this.groupBox3.Controls.Add(this.imgVideo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnPictureReset);
            this.groupBox3.Controls.Add(this.btnPicture);
            this.groupBox3.Controls.Add(this.btnFingerPrint);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1195, 253);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnVerifyFingerPrint
            // 
            this.btnVerifyFingerPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerifyFingerPrint.Image = global::SDC_Application.Resource1.fingrPrint;
            this.btnVerifyFingerPrint.Location = new System.Drawing.Point(291, 106);
            this.btnVerifyFingerPrint.Name = "btnVerifyFingerPrint";
            this.btnVerifyFingerPrint.Size = new System.Drawing.Size(56, 53);
            this.btnVerifyFingerPrint.TabIndex = 12;
            this.btnVerifyFingerPrint.UseVisualStyleBackColor = true;
            this.btnVerifyFingerPrint.Click += new System.EventHandler(this.btnVerifyFingerPrint_Click);
            // 
            // btnLoadPicturefromFile
            // 
            this.btnLoadPicturefromFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadPicturefromFile.Image = global::SDC_Application.Resource1.open_file_icon;
            this.btnLoadPicturefromFile.Location = new System.Drawing.Point(842, 108);
            this.btnLoadPicturefromFile.Name = "btnLoadPicturefromFile";
            this.btnLoadPicturefromFile.Size = new System.Drawing.Size(56, 53);
            this.btnLoadPicturefromFile.TabIndex = 11;
            this.btnLoadPicturefromFile.UseVisualStyleBackColor = true;
            this.btnLoadPicturefromFile.Click += new System.EventHandler(this.btnLoadPicturefromFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 33);
            this.textBox1.TabIndex = 10;
            this.textBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveImage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1189, 83);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImage.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveImage.Location = new System.Drawing.Point(555, 19);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(57, 58);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // pboxPicture
            // 
            this.pboxPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxPicture.Location = new System.Drawing.Point(684, 44);
            this.pboxPicture.Name = "pboxPicture";
            this.pboxPicture.Size = new System.Drawing.Size(152, 117);
            this.pboxPicture.TabIndex = 0;
            this.pboxPicture.TabStop = false;
            // 
            // btnFingerPrintReset
            // 
            this.btnFingerPrintReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFingerPrintReset.Image = global::SDC_Application.Resource1.icon_refresh;
            this.btnFingerPrintReset.Location = new System.Drawing.Point(353, 44);
            this.btnFingerPrintReset.Name = "btnFingerPrintReset";
            this.btnFingerPrintReset.Size = new System.Drawing.Size(56, 53);
            this.btnFingerPrintReset.TabIndex = 4;
            this.btnFingerPrintReset.UseVisualStyleBackColor = true;
            // 
            // pboxFingerPrint
            // 
            this.pboxFingerPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxFingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxFingerPrint.Location = new System.Drawing.Point(415, 44);
            this.pboxFingerPrint.Name = "pboxFingerPrint";
            this.pboxFingerPrint.Size = new System.Drawing.Size(152, 117);
            this.pboxFingerPrint.TabIndex = 1;
            this.pboxFingerPrint.TabStop = false;
            // 
            // imgVideo
            // 
            this.imgVideo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgVideo.Location = new System.Drawing.Point(684, 44);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(152, 117);
            this.imgVideo.TabIndex = 6;
            this.imgVideo.TabStop = false;
            // 
            // btnPictureReset
            // 
            this.btnPictureReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPictureReset.Image = global::SDC_Application.Resource1.icon_refresh;
            this.btnPictureReset.Location = new System.Drawing.Point(622, 47);
            this.btnPictureReset.Name = "btnPictureReset";
            this.btnPictureReset.Size = new System.Drawing.Size(56, 53);
            this.btnPictureReset.TabIndex = 2;
            this.btnPictureReset.UseVisualStyleBackColor = true;
            this.btnPictureReset.Click += new System.EventHandler(this.btnPictureReset_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPicture.Image = global::SDC_Application.Resource1.capture_icon;
            this.btnPicture.Location = new System.Drawing.Point(622, 108);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(56, 53);
            this.btnPicture.TabIndex = 1;
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // btnFingerPrint
            // 
            this.btnFingerPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFingerPrint.Image = global::SDC_Application.Resource1.fingerPrint1;
            this.btnFingerPrint.Location = new System.Drawing.Point(353, 106);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Size = new System.Drawing.Size(56, 53);
            this.btnFingerPrint.TabIndex = 3;
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.btnFingerPrint_Click);
            // 
            // CheckImage
            // 
            this.CheckImage.Controls.Add(this.NewPics);
            this.CheckImage.Controls.Add(this.ViewPics);
            this.CheckImage.Controls.Add(this.tbCamera);
            this.CheckImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckImage.Location = new System.Drawing.Point(10, 10);
            this.CheckImage.Name = "CheckImage";
            this.CheckImage.RightToLeftLayout = true;
            this.CheckImage.SelectedIndex = 0;
            this.CheckImage.Size = new System.Drawing.Size(1209, 571);
            this.CheckImage.TabIndex = 3;
            this.CheckImage.Click += new System.EventHandler(this.CheckImage_Click);
            // 
            // NewPics
            // 
            this.NewPics.Controls.Add(this.groupBox2);
            this.NewPics.Controls.Add(this.groupBox3);
            this.NewPics.Location = new System.Drawing.Point(4, 34);
            this.NewPics.Name = "NewPics";
            this.NewPics.Padding = new System.Windows.Forms.Padding(3);
            this.NewPics.Size = new System.Drawing.Size(1201, 533);
            this.NewPics.TabIndex = 0;
            this.NewPics.Text = "تصویر محفوظ کریں";
            this.NewPics.UseVisualStyleBackColor = true;
            // 
            // ViewPics
            // 
            this.ViewPics.Controls.Add(this.grdImagesRetrive);
            this.ViewPics.Location = new System.Drawing.Point(4, 34);
            this.ViewPics.Name = "ViewPics";
            this.ViewPics.Padding = new System.Windows.Forms.Padding(3);
            this.ViewPics.Size = new System.Drawing.Size(1201, 533);
            this.ViewPics.TabIndex = 1;
            this.ViewPics.Text = "محفوظ شدہ تصویریں";
            this.ViewPics.UseVisualStyleBackColor = true;
            // 
            // grdImagesRetrive
            // 
            this.grdImagesRetrive.AllowUserToAddRows = false;
            this.grdImagesRetrive.AllowUserToDeleteRows = false;
            this.grdImagesRetrive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdImagesRetrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImagesRetrive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageSelection});
            this.grdImagesRetrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdImagesRetrive.Location = new System.Drawing.Point(3, 3);
            this.grdImagesRetrive.Name = "grdImagesRetrive";
            this.grdImagesRetrive.ReadOnly = true;
            this.grdImagesRetrive.Size = new System.Drawing.Size(1195, 527);
            this.grdImagesRetrive.TabIndex = 1;
            this.grdImagesRetrive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdImagesRetrive_CellClick);
            // 
            // ImageSelection
            // 
            this.ImageSelection.HeaderText = "انتخاب کریں";
            this.ImageSelection.Name = "ImageSelection";
            this.ImageSelection.ReadOnly = true;
            // 
            // tbCamera
            // 
            this.tbCamera.Controls.Add(this.splitContainer1);
            this.tbCamera.Location = new System.Drawing.Point(4, 34);
            this.tbCamera.Name = "tbCamera";
            this.tbCamera.Size = new System.Drawing.Size(1201, 533);
            this.tbCamera.TabIndex = 2;
            this.tbCamera.Text = "کیمرہ";
            this.tbCamera.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbCamera);
            this.splitContainer1.Panel1.Controls.Add(this.bntCapture);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1201, 533);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 10;
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(24, 29);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(196, 33);
            this.cmbCamera.TabIndex = 8;
            this.cmbCamera.SelectionChangeCommitted += new System.EventHandler(this.cmbCamera_SelectionChangeCommitted);
            // 
            // bntCapture
            // 
            this.bntCapture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntCapture.BackgroundImage")));
            this.bntCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bntCapture.Location = new System.Drawing.Point(89, 114);
            this.bntCapture.Name = "bntCapture";
            this.bntCapture.Size = new System.Drawing.Size(85, 87);
            this.bntCapture.TabIndex = 6;
            this.bntCapture.Text = "Capture";
            this.bntCapture.UseVisualStyleBackColor = true;
            this.bntCapture.Click += new System.EventHandler(this.bntCapture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(952, 533);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnFingerHysoon
            // 
            this.btnFingerHysoon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFingerHysoon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFingerHysoon.ForeColor = System.Drawing.Color.White;
            this.btnFingerHysoon.Image = global::SDC_Application.Resource1.fingerPrint1;
            this.btnFingerHysoon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFingerHysoon.Location = new System.Drawing.Point(291, 44);
            this.btnFingerHysoon.Name = "btnFingerHysoon";
            this.btnFingerHysoon.Size = new System.Drawing.Size(56, 53);
            this.btnFingerHysoon.TabIndex = 15;
            this.btnFingerHysoon.Text = "Hysoon";
            this.btnFingerHysoon.UseVisualStyleBackColor = true;
            this.btnFingerHysoon.Click += new System.EventHandler(this.btnFingerHysoon_Click);
            // 
            // frmIntiqalPersonSnaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 591);
            this.Controls.Add(this.CheckImage);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmIntiqalPersonSnaps";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تصویریں اور انگوٹھے کے نشانات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIntiqalPersonSnaps_FormClosed);
            this.Load += new System.EventHandler(this.frmIntiqalPersonSnaps_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grfIntiqalPersonSanps)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFingerPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            this.CheckImage.ResumeLayout(false);
            this.NewPics.ResumeLayout(false);
            this.ViewPics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesRetrive)).EndInit();
            this.tbCamera.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox pboxFingerPrint;
        private System.Windows.Forms.PictureBox pboxPicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grfIntiqalPersonSanps;
        private System.Windows.Forms.Button btnFingerPrintReset;
        private System.Windows.Forms.Button btnFingerPrint;
        private System.Windows.Forms.Button btnPictureReset;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.TabControl CheckImage;
        private System.Windows.Forms.TabPage NewPics;
        private System.Windows.Forms.TabPage ViewPics;
        private System.Windows.Forms.TextBox txtIntPersonImageid;
        private System.Windows.Forms.TextBox txtpersonID;
        private System.Windows.Forms.DataGridView grdImagesRetrive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImageSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLoadPicturefromFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selection;
        private System.Windows.Forms.DataGridViewImageColumn PersonPic;
        private System.Windows.Forms.DataGridViewImageColumn PersonFingerPrint;
        private System.Windows.Forms.Button btnVerifyFingerPrint;
        private System.Windows.Forms.TabPage tbCamera;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Button bntCapture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFingerHysoon;
    }
}