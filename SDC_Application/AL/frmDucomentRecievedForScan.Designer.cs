namespace SDC_Application.AL
{
    partial class frmDucomentRecievedForScan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectedRow = new System.Windows.Forms.TextBox();
            this.txtSelectedIndex = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtLastImageID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ladgroubbox = new System.Windows.Forms.GroupBox();
            this.grdScanedDocStatus = new System.Windows.Forms.DataGridView();
            this.PageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actiontypefor_Inserting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image_Pic_DB = new System.Windows.Forms.DataGridViewImageColumn();
            this.DcumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntiqalDocId_Save = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntiqalDocRecId_Save = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntiqalDocImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureLoad = new System.Windows.Forms.DataGridViewImageColumn();
            this.insert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.replace = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.replaceImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radUpperButton = new System.Windows.Forms.RadioButton();
            this.radLowerButton = new System.Windows.Forms.RadioButton();
            this.radInBetweenButton = new System.Windows.Forms.RadioButton();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkForDelete = new System.Windows.Forms.CheckBox();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewDoc = new System.Windows.Forms.Button();
            this.btnDelMain = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckforLoad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDialog = new System.Windows.Forms.DataGridViewLinkColumn();
            this.grdScannedDoc = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ladgroubbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanedDocStatus)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScannedDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSelectedRow);
            this.panel1.Controls.Add(this.txtSelectedIndex);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtLastImageID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(799, 42);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "دستاویزات انتقال";
            // 
            // txtSelectedRow
            // 
            this.txtSelectedRow.Location = new System.Drawing.Point(229, 6);
            this.txtSelectedRow.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.txtSelectedRow.Name = "txtSelectedRow";
            this.txtSelectedRow.Size = new System.Drawing.Size(50, 28);
            this.txtSelectedRow.TabIndex = 3;
            this.txtSelectedRow.Visible = false;
            // 
            // txtSelectedIndex
            // 
            this.txtSelectedIndex.Location = new System.Drawing.Point(178, 6);
            this.txtSelectedIndex.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.txtSelectedIndex.Name = "txtSelectedIndex";
            this.txtSelectedIndex.Size = new System.Drawing.Size(47, 28);
            this.txtSelectedIndex.TabIndex = 2;
            this.txtSelectedIndex.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SDC_Application.Resource1.attachment;
            this.pictureBox1.Location = new System.Drawing.Point(100, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 42);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // txtLastImageID
            // 
            this.txtLastImageID.Location = new System.Drawing.Point(9, 5);
            this.txtLastImageID.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.txtLastImageID.Name = "txtLastImageID";
            this.txtLastImageID.Size = new System.Drawing.Size(42, 28);
            this.txtLastImageID.TabIndex = 0;
            this.txtLastImageID.Text = "-1";
            this.txtLastImageID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ladgroubbox);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.grdScannedDoc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(799, 707);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // ladgroubbox
            // 
            this.ladgroubbox.Controls.Add(this.grdScanedDocStatus);
            this.ladgroubbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ladgroubbox.Location = new System.Drawing.Point(10, 258);
            this.ladgroubbox.Margin = new System.Windows.Forms.Padding(10);
            this.ladgroubbox.Name = "ladgroubbox";
            this.ladgroubbox.Padding = new System.Windows.Forms.Padding(10);
            this.ladgroubbox.Size = new System.Drawing.Size(779, 439);
            this.ladgroubbox.TabIndex = 6;
            this.ladgroubbox.TabStop = false;
            // 
            // grdScanedDocStatus
            // 
            this.grdScanedDocStatus.AllowUserToAddRows = false;
            this.grdScanedDocStatus.AllowUserToDeleteRows = false;
            this.grdScanedDocStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Alvi Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdScanedDocStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdScanedDocStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScanedDocStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PageNo,
            this.actiontypefor_Inserting,
            this.Image_Pic_DB,
            this.DcumentName,
            this.IntiqalDocId_Save,
            this.IntiqalDocRecId_Save,
            this.IntiqalDocImageId,
            this.source,
            this.PictureLoad,
            this.insert,
            this.Delete,
            this.replace,
            this.replaceImage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Alvi Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdScanedDocStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdScanedDocStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScanedDocStatus.Location = new System.Drawing.Point(10, 31);
            this.grdScanedDocStatus.Name = "grdScanedDocStatus";
            this.grdScanedDocStatus.ReadOnly = true;
            this.grdScanedDocStatus.Size = new System.Drawing.Size(759, 398);
            this.grdScanedDocStatus.TabIndex = 4;
            this.grdScanedDocStatus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScanedDocStatus_CellClick);
            this.grdScanedDocStatus.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScanedDocStatus_CellMouseEnter);
            // 
            // PageNo
            // 
            this.PageNo.FillWeight = 70.07016F;
            this.PageNo.HeaderText = "صفحہ نمبر";
            this.PageNo.Name = "PageNo";
            this.PageNo.ReadOnly = true;
            // 
            // actiontypefor_Inserting
            // 
            this.actiontypefor_Inserting.HeaderText = "actiontypefor_Inserting";
            this.actiontypefor_Inserting.Name = "actiontypefor_Inserting";
            this.actiontypefor_Inserting.ReadOnly = true;
            this.actiontypefor_Inserting.Visible = false;
            // 
            // Image_Pic_DB
            // 
            this.Image_Pic_DB.HeaderText = "Image_Pic_DB";
            this.Image_Pic_DB.Name = "Image_Pic_DB";
            this.Image_Pic_DB.ReadOnly = true;
            this.Image_Pic_DB.Visible = false;
            // 
            // DcumentName
            // 
            this.DcumentName.FillWeight = 50.33458F;
            this.DcumentName.HeaderText = "دستاویز کا نام";
            this.DcumentName.Name = "DcumentName";
            this.DcumentName.ReadOnly = true;
            // 
            // IntiqalDocId_Save
            // 
            this.IntiqalDocId_Save.HeaderText = "IntiqalDocId_Save";
            this.IntiqalDocId_Save.Name = "IntiqalDocId_Save";
            this.IntiqalDocId_Save.ReadOnly = true;
            this.IntiqalDocId_Save.Visible = false;
            // 
            // IntiqalDocRecId_Save
            // 
            this.IntiqalDocRecId_Save.HeaderText = "IntiqalDocRecId_Save";
            this.IntiqalDocRecId_Save.Name = "IntiqalDocRecId_Save";
            this.IntiqalDocRecId_Save.ReadOnly = true;
            this.IntiqalDocRecId_Save.Visible = false;
            // 
            // IntiqalDocImageId
            // 
            this.IntiqalDocImageId.HeaderText = "StatusSaveReplaceDelete";
            this.IntiqalDocImageId.Name = "IntiqalDocImageId";
            this.IntiqalDocImageId.ReadOnly = true;
            this.IntiqalDocImageId.Visible = false;
            // 
            // source
            // 
            this.source.HeaderText = "pathee";
            this.source.Name = "source";
            this.source.ReadOnly = true;
            this.source.Visible = false;
            // 
            // PictureLoad
            // 
            this.PictureLoad.FillWeight = 52.67343F;
            this.PictureLoad.HeaderText = "تصویر";
            this.PictureLoad.Name = "PictureLoad";
            this.PictureLoad.ReadOnly = true;
            this.PictureLoad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PictureLoad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // insert
            // 
            this.insert.FillWeight = 9.664506F;
            this.insert.HeaderText = "محفوظ";
            this.insert.Name = "insert";
            this.insert.ReadOnly = true;
            this.insert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.insert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 137.0558F;
            this.Delete.HeaderText = "حذف";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // replace
            // 
            this.replace.FillWeight = 280.2015F;
            this.replace.HeaderText = "تبدیل";
            this.replace.Name = "replace";
            this.replace.ReadOnly = true;
            // 
            // replaceImage
            // 
            this.replaceImage.HeaderText = "تصاویر تبدیل کریں";
            this.replaceImage.Name = "replaceImage";
            this.replaceImage.ReadOnly = true;
            this.replaceImage.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radUpperButton);
            this.groupBox3.Controls.Add(this.radLowerButton);
            this.groupBox3.Controls.Add(this.radInBetweenButton);
            this.groupBox3.Controls.Add(this.txtPageNo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.chkForDelete);
            this.groupBox3.Controls.Add(this.chkReplace);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(10, 188);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(779, 70);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // radUpperButton
            // 
            this.radUpperButton.AutoSize = true;
            this.radUpperButton.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUpperButton.Location = new System.Drawing.Point(505, 22);
            this.radUpperButton.Name = "radUpperButton";
            this.radUpperButton.Size = new System.Drawing.Size(47, 34);
            this.radUpperButton.TabIndex = 9;
            this.radUpperButton.TabStop = true;
            this.radUpperButton.Text = "اوپر";
            this.radUpperButton.UseVisualStyleBackColor = true;
            this.radUpperButton.Visible = false;
            // 
            // radLowerButton
            // 
            this.radLowerButton.AutoSize = true;
            this.radLowerButton.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLowerButton.Location = new System.Drawing.Point(410, 22);
            this.radLowerButton.Name = "radLowerButton";
            this.radLowerButton.Size = new System.Drawing.Size(51, 34);
            this.radLowerButton.TabIndex = 8;
            this.radLowerButton.TabStop = true;
            this.radLowerButton.Text = "نیچے";
            this.radLowerButton.UseVisualStyleBackColor = true;
            this.radLowerButton.Visible = false;
            // 
            // radInBetweenButton
            // 
            this.radInBetweenButton.AutoSize = true;
            this.radInBetweenButton.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInBetweenButton.Location = new System.Drawing.Point(596, 22);
            this.radInBetweenButton.Name = "radInBetweenButton";
            this.radInBetweenButton.Size = new System.Drawing.Size(87, 34);
            this.radInBetweenButton.TabIndex = 7;
            this.radInBetweenButton.TabStop = true;
            this.radInBetweenButton.Text = "درمیان میں";
            this.radInBetweenButton.UseVisualStyleBackColor = true;
            this.radInBetweenButton.Visible = false;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Enabled = false;
            this.txtPageNo.Location = new System.Drawing.Point(685, 18);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(81, 28);
            this.txtPageNo.TabIndex = 6;
            this.txtPageNo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "تمام کا انتخاب کریں";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "تمام تبدیل کریں";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 28);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // chkForDelete
            // 
            this.chkForDelete.AutoSize = true;
            this.chkForDelete.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkForDelete.Location = new System.Drawing.Point(237, 37);
            this.chkForDelete.Name = "chkForDelete";
            this.chkForDelete.Size = new System.Drawing.Size(15, 14);
            this.chkForDelete.TabIndex = 1;
            this.chkForDelete.UseVisualStyleBackColor = true;
            this.chkForDelete.CheckedChanged += new System.EventHandler(this.chkForDelete_CheckedChanged);
            // 
            // chkReplace
            // 
            this.chkReplace.AutoSize = true;
            this.chkReplace.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReplace.Location = new System.Drawing.Point(109, 34);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(15, 14);
            this.chkReplace.TabIndex = 0;
            this.chkReplace.UseVisualStyleBackColor = true;
            this.chkReplace.Visible = false;
            this.chkReplace.CheckedChanged += new System.EventHandler(this.chkReplace_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNewDoc);
            this.panel2.Controls.Add(this.btnDelMain);
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 690);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(799, 59);
            this.panel2.TabIndex = 7;
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDoc.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewDoc.Location = new System.Drawing.Point(448, 3);
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Size = new System.Drawing.Size(50, 50);
            this.btnNewDoc.TabIndex = 35;
            this.btnNewDoc.UseVisualStyleBackColor = true;
            this.btnNewDoc.Click += new System.EventHandler(this.btnNewSeller_Click);
            // 
            // btnDelMain
            // 
            this.btnDelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMain.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelMain.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelMain.Location = new System.Drawing.Point(326, 4);
            this.btnDelMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnDelMain.Name = "btnDelMain";
            this.btnDelMain.Size = new System.Drawing.Size(59, 50);
            this.btnDelMain.TabIndex = 30;
            this.btnDelMain.TabStop = false;
            this.btnDelMain.UseVisualStyleBackColor = true;
            this.btnDelMain.Click += new System.EventHandler(this.btnDelMain_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImage.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveImage.Location = new System.Drawing.Point(390, 3);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(53, 51);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Picture
            // 
            this.Picture.HeaderText = "تصویر";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // SaveButton
            // 
            this.SaveButton.HeaderText = "محفوظ کریں";
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.ReadOnly = true;
            // 
            // Pages
            // 
            this.Pages.HeaderText = "محفوظ کئے گئے صفحات";
            this.Pages.Name = "Pages";
            this.Pages.ReadOnly = true;
            // 
            // CheckforLoad
            // 
            this.CheckforLoad.HeaderText = "لوڈ کریں";
            this.CheckforLoad.Name = "CheckforLoad";
            this.CheckforLoad.ReadOnly = true;
            // 
            // btnDialog
            // 
            this.btnDialog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnDialog.HeaderText = "دستاویز";
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.ReadOnly = true;
            this.btnDialog.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grdScannedDoc
            // 
            this.grdScannedDoc.AllowUserToAddRows = false;
            this.grdScannedDoc.AllowUserToDeleteRows = false;
            this.grdScannedDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScannedDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDialog,
            this.CheckforLoad,
            this.Pages,
            this.SaveButton,
            this.Path,
            this.Picture});
            this.grdScannedDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdScannedDoc.Location = new System.Drawing.Point(10, 31);
            this.grdScannedDoc.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.grdScannedDoc.Name = "grdScannedDoc";
            this.grdScannedDoc.ReadOnly = true;
            this.grdScannedDoc.Size = new System.Drawing.Size(779, 157);
            this.grdScannedDoc.TabIndex = 0;
            this.grdScannedDoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScannedDoc_CellClick);
            this.grdScannedDoc.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScannedDoc_CellMouseEnter);
            // 
            // frmDucomentRecievedForScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Name = "frmDucomentRecievedForScan";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دستاویزات انتقالات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDucomentRecievedForScan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ladgroubbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScanedDocStatus)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScannedDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.TextBox txtLastImageID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView grdScanedDocStatus;
        private System.Windows.Forms.CheckBox chkForDelete;
        private System.Windows.Forms.CheckBox chkReplace;
        private System.Windows.Forms.Button btnDelMain;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewDoc;
        private System.Windows.Forms.GroupBox ladgroubbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radUpperButton;
        private System.Windows.Forms.RadioButton radLowerButton;
        private System.Windows.Forms.RadioButton radInBetweenButton;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn actiontypefor_Inserting;
        private System.Windows.Forms.DataGridViewImageColumn Image_Pic_DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DcumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntiqalDocId_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntiqalDocRecId_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntiqalDocImageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn source;
        private System.Windows.Forms.DataGridViewImageColumn PictureLoad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn insert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn replace;
        private System.Windows.Forms.DataGridViewButtonColumn replaceImage;
        private System.Windows.Forms.TextBox txtSelectedRow;
        private System.Windows.Forms.TextBox txtSelectedIndex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdScannedDoc;
        private System.Windows.Forms.DataGridViewLinkColumn btnDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckforLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pages;
        private System.Windows.Forms.DataGridViewButtonColumn SaveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
    }
}