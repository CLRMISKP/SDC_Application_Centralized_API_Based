namespace SDC_Application.AL
{
    partial class frmPictureIndexMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPictureIndexMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBarStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSource = new System.Windows.Forms.ToolStripButton();
            this.btnDestination = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartIndexing = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabPageDataSource = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboQanoongoi = new System.Windows.Forms.ComboBox();
            this.labelMoza = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPatwarCicrl = new System.Windows.Forms.ComboBox();
            this.cboVillage = new System.Windows.Forms.ComboBox();
            this.cboDocumentType = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pbImageViewer = new System.Windows.Forms.PictureBox();
            this.tblThumbnails = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tabPageDataSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ProgressBarStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Progress :";
            // 
            // ProgressBarStatus
            // 
            this.ProgressBarStatus.Name = "ProgressBarStatus";
            this.ProgressBarStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSource,
            this.btnDestination,
            this.toolStripSeparator1,
            this.btnStartIndexing});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 46);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSource
            // 
            this.btnSource.Image = ((System.Drawing.Image)(resources.GetObject("btnSource.Image")));
            this.btnSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(47, 43);
            this.btnSource.Text = "Source";
            this.btnSource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSource.ToolTipText = "Source Folder";
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnDestination
            // 
            this.btnDestination.Image = ((System.Drawing.Image)(resources.GetObject("btnDestination.Image")));
            this.btnDestination.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDestination.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(71, 43);
            this.btnDestination.Text = "Destination";
            this.btnDestination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDestination.ToolTipText = "Destination Folder";
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnStartIndexing
            // 
            this.btnStartIndexing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartIndexing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartIndexing.Name = "btnStartIndexing";
            this.btnStartIndexing.Size = new System.Drawing.Size(83, 43);
            this.btnStartIndexing.Text = "Start Indexing";
            this.btnStartIndexing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartIndexing.Click += new System.EventHandler(this.btnStartIndexing_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 438);
            this.panel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabOptions);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1200, 438);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabPageDataSource);
            this.tabOptions.Location = new System.Drawing.Point(10, 10);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(255, 416);
            this.tabOptions.TabIndex = 2;
            // 
            // tabPageDataSource
            // 
            this.tabPageDataSource.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageDataSource.Controls.Add(this.textBox1);
            this.tabPageDataSource.Controls.Add(this.label1);
            this.tabPageDataSource.Controls.Add(this.cboQanoongoi);
            this.tabPageDataSource.Controls.Add(this.labelMoza);
            this.tabPageDataSource.Controls.Add(this.label32);
            this.tabPageDataSource.Controls.Add(this.txtDestinationPath);
            this.tabPageDataSource.Controls.Add(this.listBox1);
            this.tabPageDataSource.Controls.Add(this.label5);
            this.tabPageDataSource.Controls.Add(this.label4);
            this.tabPageDataSource.Controls.Add(this.cboPatwarCicrl);
            this.tabPageDataSource.Controls.Add(this.cboVillage);
            this.tabPageDataSource.Controls.Add(this.cboDocumentType);
            this.tabPageDataSource.Location = new System.Drawing.Point(4, 28);
            this.tabPageDataSource.Name = "tabPageDataSource";
            this.tabPageDataSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataSource.Size = new System.Drawing.Size(247, 384);
            this.tabPageDataSource.TabIndex = 0;
            this.tabPageDataSource.Text = "Data Source";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 26);
            this.textBox1.TabIndex = 219;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 218;
            this.label1.Text = "قانون گوئی:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboQanoongoi
            // 
            this.cboQanoongoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQanoongoi.FormattingEnabled = true;
            this.cboQanoongoi.Location = new System.Drawing.Point(18, 26);
            this.cboQanoongoi.Name = "cboQanoongoi";
            this.cboQanoongoi.Size = new System.Drawing.Size(218, 27);
            this.cboQanoongoi.TabIndex = 217;
            this.cboQanoongoi.SelectionChangeCommitted += new System.EventHandler(this.cboQanoongoi_SelectionChangeCommitted);
            // 
            // labelMoza
            // 
            this.labelMoza.AutoSize = true;
            this.labelMoza.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoza.Location = new System.Drawing.Point(188, 112);
            this.labelMoza.Name = "labelMoza";
            this.labelMoza.Size = new System.Drawing.Size(38, 15);
            this.labelMoza.TabIndex = 216;
            this.labelMoza.Text = "موضع:";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(146, 57);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label32.Size = new System.Drawing.Size(90, 20);
            this.label32.TabIndex = 215;
            this.label32.Text = " پٹوار سرکل:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Location = new System.Drawing.Point(18, 240);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDestinationPath.Size = new System.Drawing.Size(218, 26);
            this.txtDestinationPath.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(3, 318);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(239, 61);
            this.listBox1.TabIndex = 2;
            this.listBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = " مقصود فولڈر Destination Path :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = " قسم دستاویز";
            // 
            // cboPatwarCicrl
            // 
            this.cboPatwarCicrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatwarCicrl.FormattingEnabled = true;
            this.cboPatwarCicrl.Location = new System.Drawing.Point(18, 80);
            this.cboPatwarCicrl.Name = "cboPatwarCicrl";
            this.cboPatwarCicrl.Size = new System.Drawing.Size(218, 27);
            this.cboPatwarCicrl.TabIndex = 0;
            this.cboPatwarCicrl.SelectionChangeCommitted += new System.EventHandler(this.cboPatwarCicrl_SelectionChangeCommitted);
            // 
            // cboVillage
            // 
            this.cboVillage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVillage.FormattingEnabled = true;
            this.cboVillage.Location = new System.Drawing.Point(18, 134);
            this.cboVillage.Name = "cboVillage";
            this.cboVillage.Size = new System.Drawing.Size(218, 27);
            this.cboVillage.TabIndex = 0;
            // 
            // cboDocumentType
            // 
            this.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentType.FormattingEnabled = true;
            this.cboDocumentType.Location = new System.Drawing.Point(18, 188);
            this.cboDocumentType.Name = "cboDocumentType";
            this.cboDocumentType.Size = new System.Drawing.Size(218, 27);
            this.cboDocumentType.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.pbImageViewer);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.tblThumbnails);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(913, 438);
            this.splitContainer2.SplitterDistance = 281;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 0;
            // 
            // pbImageViewer
            // 
            this.pbImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImageViewer.Location = new System.Drawing.Point(10, 10);
            this.pbImageViewer.Name = "pbImageViewer";
            this.pbImageViewer.Size = new System.Drawing.Size(891, 259);
            this.pbImageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageViewer.TabIndex = 0;
            this.pbImageViewer.TabStop = false;
            // 
            // tblThumbnails
            // 
            this.tblThumbnails.AutoSize = true;
            this.tblThumbnails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblThumbnails.ColumnCount = 1;
            this.tblThumbnails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblThumbnails.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblThumbnails.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tblThumbnails.Location = new System.Drawing.Point(10, 10);
            this.tblThumbnails.Name = "tblThumbnails";
            this.tblThumbnails.Padding = new System.Windows.Forms.Padding(5);
            this.tblThumbnails.RowCount = 1;
            this.tblThumbnails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblThumbnails.Size = new System.Drawing.Size(12, 125);
            this.tblThumbnails.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // frmPictureIndexMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1200, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmPictureIndexMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تصویر انڈیکسنگ یوٹیلیٹی";
            this.Load += new System.EventHandler(this.frmPictureIndexMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabPageDataSource.ResumeLayout(false);
            this.tabPageDataSource.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cboPatwarCicrl;
        private System.Windows.Forms.ComboBox cboVillage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDocumentType;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tblThumbnails;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pbImageViewer;
        private System.Windows.Forms.ToolStripButton btnSource;
        private System.Windows.Forms.ToolStripButton btnDestination;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabPageDataSource;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBarStatus;
        private System.Windows.Forms.ToolStripButton btnStartIndexing;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label labelMoza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQanoongoi;
        private System.Windows.Forms.TextBox textBox1;
    }
}
