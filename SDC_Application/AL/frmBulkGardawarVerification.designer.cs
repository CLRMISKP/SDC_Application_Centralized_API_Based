namespace SDC_Application.AL
    {
    partial class frmBulkGardawarVerification
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        ///  this.tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
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
        ///  this.tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbGardawarVerification = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GridViewIntiqalat = new System.Windows.Forms.DataGridView();
            this.cbgrid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label33 = new System.Windows.Forms.Label();
            this.txtIntiqalNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbIntiqal = new System.Windows.Forms.RadioButton();
            this.rbRegistry = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verificationControl1 = new DPFP.Gui.Verification.VerificationControl();
            this.gbSelectRO = new System.Windows.Forms.GroupBox();
            this.lblRoName = new System.Windows.Forms.Label();
            this.cboROs = new System.Windows.Forms.ComboBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnFingerHysoon = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbGardawarVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIntiqalat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSelectRO.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbGardawarVerification);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1202, 555);
            this.tabControl1.TabIndex = 51;
            // 
            // tbGardawarVerification
            // 
            this.tbGardawarVerification.BackColor = System.Drawing.Color.White;
            this.tbGardawarVerification.Controls.Add(this.splitContainer1);
            this.tbGardawarVerification.Location = new System.Drawing.Point(4, 34);
            this.tbGardawarVerification.Name = "tbGardawarVerification";
            this.tbGardawarVerification.Padding = new System.Windows.Forms.Padding(3);
            this.tbGardawarVerification.Size = new System.Drawing.Size(1194, 517);
            this.tbGardawarVerification.TabIndex = 0;
            this.tbGardawarVerification.Text = "گرداور پڑتال";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.gbSelectRO);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1188, 511);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 499);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 499);
            this.panel2.TabIndex = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkAll);
            this.groupBox8.Controls.Add(this.panel3);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.txtIntiqalNo);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 76);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.groupBox8.Size = new System.Drawing.Size(528, 423);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "انتقالات";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(43, 23);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAll.Size = new System.Drawing.Size(89, 29);
            this.chkAll.TabIndex = 73;
            this.chkAll.Text = "تمام منتخب کریں";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GridViewIntiqalat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 364);
            this.panel3.TabIndex = 3;
            // 
            // GridViewIntiqalat
            // 
            this.GridViewIntiqalat.AllowUserToAddRows = false;
            this.GridViewIntiqalat.AllowUserToDeleteRows = false;
            this.GridViewIntiqalat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewIntiqalat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewIntiqalat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbgrid});
            this.GridViewIntiqalat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewIntiqalat.Location = new System.Drawing.Point(0, 0);
            this.GridViewIntiqalat.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GridViewIntiqalat.Name = "GridViewIntiqalat";
            this.GridViewIntiqalat.ReadOnly = true;
            this.GridViewIntiqalat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewIntiqalat.Size = new System.Drawing.Size(522, 364);
            this.GridViewIntiqalat.TabIndex = 1;
            this.GridViewIntiqalat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewIntiqalat_CellClick);
            // 
            // cbgrid
            // 
            this.cbgrid.HeaderText = "انتخاب کریں";
            this.cbgrid.Name = "cbgrid";
            this.cbgrid.ReadOnly = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(387, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(54, 25);
            this.label33.TabIndex = 72;
            this.label33.Text = "تلاش کریں";
            // 
            // txtIntiqalNo
            // 
            this.txtIntiqalNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIntiqalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIntiqalNo.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntiqalNo.Location = new System.Drawing.Point(233, 24);
            this.txtIntiqalNo.Multiline = true;
            this.txtIntiqalNo.Name = "txtIntiqalNo";
            this.txtIntiqalNo.Size = new System.Drawing.Size(105, 27);
            this.txtIntiqalNo.TabIndex = 71;
            this.txtIntiqalNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIntiqalNo.TextChanged += new System.EventHandler(this.txtIntiqalNo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.rbIntiqal);
            this.panel5.Controls.Add(this.rbRegistry);
            this.panel5.Location = new System.Drawing.Point(366, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(147, 42);
            this.panel5.TabIndex = 62;
            // 
            // rbIntiqal
            // 
            this.rbIntiqal.AutoSize = true;
            this.rbIntiqal.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIntiqal.Location = new System.Drawing.Point(77, 4);
            this.rbIntiqal.Name = "rbIntiqal";
            this.rbIntiqal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbIntiqal.Size = new System.Drawing.Size(58, 34);
            this.rbIntiqal.TabIndex = 87;
            this.rbIntiqal.Text = "انتقال";
            this.rbIntiqal.UseVisualStyleBackColor = true;
            this.rbIntiqal.CheckedChanged += new System.EventHandler(this.rbIntiqal_CheckedChanged);
            // 
            // rbRegistry
            // 
            this.rbRegistry.AutoSize = true;
            this.rbRegistry.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRegistry.Location = new System.Drawing.Point(4, 4);
            this.rbRegistry.Name = "rbRegistry";
            this.rbRegistry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbRegistry.Size = new System.Drawing.Size(66, 34);
            this.rbRegistry.TabIndex = 86;
            this.rbRegistry.Text = "رجسٹری";
            this.rbRegistry.UseVisualStyleBackColor = true;
            this.rbRegistry.CheckedChanged += new System.EventHandler(this.rbRegistry_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.verificationControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(628, 411);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "حیثیت تصدیق";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFingerHysoon);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(622, 84);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "پڑتال کے بعد محفوظ کریں";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(331, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 50);
            this.btnSave.TabIndex = 21;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(102, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 175);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // verificationControl1
            // 
            this.verificationControl1.Active = true;
            this.verificationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verificationControl1.Location = new System.Drawing.Point(287, 77);
            this.verificationControl1.Margin = new System.Windows.Forms.Padding(3, 23, 3, 23);
            this.verificationControl1.Name = "verificationControl1";
            this.verificationControl1.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.verificationControl1.Size = new System.Drawing.Size(48, 425);
            this.verificationControl1.TabIndex = 1;
            this.verificationControl1.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.verificationControl1_OnComplete);
            // 
            // gbSelectRO
            // 
            this.gbSelectRO.Controls.Add(this.lblRoName);
            this.gbSelectRO.Controls.Add(this.cboROs);
            this.gbSelectRO.Controls.Add(this.lbl5);
            this.gbSelectRO.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSelectRO.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectRO.Location = new System.Drawing.Point(5, 5);
            this.gbSelectRO.Name = "gbSelectRO";
            this.gbSelectRO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbSelectRO.Size = new System.Drawing.Size(628, 88);
            this.gbSelectRO.TabIndex = 4;
            this.gbSelectRO.TabStop = false;
            this.gbSelectRO.Text = "گرداور کا انتخاب کریں";
            // 
            // lblRoName
            // 
            this.lblRoName.AutoSize = true;
            this.lblRoName.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRoName.Location = new System.Drawing.Point(128, 35);
            this.lblRoName.Name = "lblRoName";
            this.lblRoName.Size = new System.Drawing.Size(17, 25);
            this.lblRoName.TabIndex = 17;
            this.lblRoName.Text = ":";
            // 
            // cboROs
            // 
            this.cboROs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboROs.DisplayMember = "IntiqalType";
            this.cboROs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboROs.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboROs.FormattingEnabled = true;
            this.cboROs.Location = new System.Drawing.Point(389, 35);
            this.cboROs.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboROs.Name = "cboROs";
            this.cboROs.Size = new System.Drawing.Size(159, 28);
            this.cboROs.TabIndex = 15;
            this.cboROs.Tag = "1";
            this.cboROs.ValueMember = "IntiqalTypeId";
            this.cboROs.SelectionChangeCommitted += new System.EventHandler(this.cboROs_SelectionChangeCommitted);
            // 
            // lbl5
            // 
            this.lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl5.Location = new System.Drawing.Point(554, 36);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(48, 25);
            this.lbl5.TabIndex = 16;
            this.lbl5.Text = "گرداور";
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // btnFingerHysoon
            // 
            this.btnFingerHysoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFingerHysoon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFingerHysoon.ForeColor = System.Drawing.Color.White;
            this.btnFingerHysoon.Image = global::SDC_Application.Resource1.fingerPrint1;
            this.btnFingerHysoon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFingerHysoon.Location = new System.Drawing.Point(242, 25);
            this.btnFingerHysoon.Name = "btnFingerHysoon";
            this.btnFingerHysoon.Size = new System.Drawing.Size(56, 50);
            this.btnFingerHysoon.TabIndex = 25;
            this.btnFingerHysoon.Text = "Hysoon";
            this.btnFingerHysoon.UseVisualStyleBackColor = true;
            this.btnFingerHysoon.Click += new System.EventHandler(this.btnFingerHysoon_Click);
            // 
            // frmBulkGardawarVerification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 555);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmBulkGardawarVerification";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "گرداور پڑتال";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStayOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbGardawarVerification.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIntiqalat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSelectRO.ResumeLayout(false);
            this.gbSelectRO.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbGardawarVerification;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GridViewIntiqalat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbgrid;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbIntiqal;
        private System.Windows.Forms.RadioButton rbRegistry;
        private System.Windows.Forms.GroupBox gbSelectRO;
        private System.Windows.Forms.Label lblRoName;
        private System.Windows.Forms.ComboBox cboROs;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DPFP.Gui.Verification.VerificationControl verificationControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIntiqalNo;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnFingerHysoon;
    }
    }