namespace SDC_Application.AL
{
    partial class frmNaqalIntiqal
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewDoc = new System.Windows.Forms.Button();
            this.btnDelMain = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectedRow = new System.Windows.Forms.TextBox();
            this.txtSelectedIndex = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtLastImageID = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnListIntiqals = new System.Windows.Forms.Button();
            this.btnSearchBuyers = new System.Windows.Forms.Button();
            this.btnLoadToken = new System.Windows.Forms.Button();
            this.btnSearchSeller = new System.Windows.Forms.Button();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIntiqalNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuyerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GridWitnessDetails = new System.Windows.Forms.DataGridView();
            this.colChooseWitness = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbIntiqalnaqalDoc = new System.Windows.Forms.PictureBox();
            this.ToolTipIntiqalNaqal = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridWitnessDetails)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntiqalnaqalDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNewDoc);
            this.panel2.Controls.Add(this.btnDelMain);
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 513);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1050, 59);
            this.panel2.TabIndex = 9;
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDoc.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewDoc.Location = new System.Drawing.Point(539, 4);
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Size = new System.Drawing.Size(50, 50);
            this.btnNewDoc.TabIndex = 35;
            this.btnNewDoc.UseVisualStyleBackColor = true;
            // 
            // btnDelMain
            // 
            this.btnDelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMain.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelMain.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelMain.Location = new System.Drawing.Point(417, 5);
            this.btnDelMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnDelMain.Name = "btnDelMain";
            this.btnDelMain.Size = new System.Drawing.Size(59, 50);
            this.btnDelMain.TabIndex = 30;
            this.btnDelMain.TabStop = false;
            this.btnDelMain.UseVisualStyleBackColor = true;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImage.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveImage.Location = new System.Drawing.Point(481, 4);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(53, 51);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.UseVisualStyleBackColor = true;
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
            this.panel1.Size = new System.Drawing.Size(1050, 42);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "نقل انتقال";
            // 
            // txtSelectedRow
            // 
            this.txtSelectedRow.Location = new System.Drawing.Point(229, 6);
            this.txtSelectedRow.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.txtSelectedRow.Name = "txtSelectedRow";
            this.txtSelectedRow.Size = new System.Drawing.Size(50, 20);
            this.txtSelectedRow.TabIndex = 3;
            this.txtSelectedRow.Visible = false;
            // 
            // txtSelectedIndex
            // 
            this.txtSelectedIndex.Location = new System.Drawing.Point(178, 6);
            this.txtSelectedIndex.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.txtSelectedIndex.Name = "txtSelectedIndex";
            this.txtSelectedIndex.Size = new System.Drawing.Size(47, 20);
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
            this.txtLastImageID.Size = new System.Drawing.Size(42, 20);
            this.txtLastImageID.TabIndex = 0;
            this.txtLastImageID.Text = "-1";
            this.txtLastImageID.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnListIntiqals);
            this.groupBox5.Controls.Add(this.btnSearchBuyers);
            this.groupBox5.Controls.Add(this.btnLoadToken);
            this.groupBox5.Controls.Add(this.btnSearchSeller);
            this.groupBox5.Controls.Add(this.txtTokenNo);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtIntiqalNo);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtbuyerName);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtSellerName);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1050, 247);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // btnListIntiqals
            // 
            this.btnListIntiqals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListIntiqals.Image = global::SDC_Application.Resource1.Modify;
            this.btnListIntiqals.Location = new System.Drawing.Point(487, 188);
            this.btnListIntiqals.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnListIntiqals.Name = "btnListIntiqals";
            this.btnListIntiqals.Size = new System.Drawing.Size(59, 50);
            this.btnListIntiqals.TabIndex = 47;
            this.btnListIntiqals.TabStop = false;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnListIntiqals, "اوپر معلومات ک بنا پر انتقالات دیکھائیں");
            this.btnListIntiqals.UseVisualStyleBackColor = true;
            this.btnListIntiqals.Click += new System.EventHandler(this.btnListIntiqals_Click);
            // 
            // btnSearchBuyers
            // 
            this.btnSearchBuyers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchBuyers.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBuyers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchBuyers.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchBuyers.Location = new System.Drawing.Point(111, 136);
            this.btnSearchBuyers.Name = "btnSearchBuyers";
            this.btnSearchBuyers.Size = new System.Drawing.Size(45, 37);
            this.btnSearchBuyers.TabIndex = 46;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnSearchBuyers, "گریندگان/ مشتریان/وارثان تلاش کریں");
            this.btnSearchBuyers.UseVisualStyleBackColor = true;
            this.btnSearchBuyers.Click += new System.EventHandler(this.btnSearchBuyers_Click);
            // 
            // btnLoadToken
            // 
            this.btnLoadToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadToken.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadToken.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadToken.Image = global::SDC_Application.Resource1.search01;
            this.btnLoadToken.Location = new System.Drawing.Point(801, 22);
            this.btnLoadToken.Name = "btnLoadToken";
            this.btnLoadToken.Size = new System.Drawing.Size(35, 38);
            this.btnLoadToken.TabIndex = 45;
            this.btnLoadToken.UseVisualStyleBackColor = true;
            this.btnLoadToken.Click += new System.EventHandler(this.btnLoadToken_Click);
            // 
            // btnSearchSeller
            // 
            this.btnSearchSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSeller.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSeller.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchSeller.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchSeller.Location = new System.Drawing.Point(111, 80);
            this.btnSearchSeller.Name = "btnSearchSeller";
            this.btnSearchSeller.Size = new System.Drawing.Size(45, 39);
            this.btnSearchSeller.TabIndex = 44;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnSearchSeller, "دہندگان/بائعان/متوافی تلاش کریں");
            this.btnSearchSeller.UseVisualStyleBackColor = true;
            this.btnSearchSeller.Click += new System.EventHandler(this.btnSearchSeller_Click);
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokenNo.Enabled = false;
            this.txtTokenNo.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNo.Location = new System.Drawing.Point(839, 22);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(140, 37);
            this.txtTokenNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(920, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "نام بائع/راہن/متوافی";
            // 
            // txtIntiqalNo
            // 
            this.txtIntiqalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntiqalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIntiqalNo.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntiqalNo.Location = new System.Drawing.Point(583, 27);
            this.txtIntiqalNo.MaxLength = 13;
            this.txtIntiqalNo.Name = "txtIntiqalNo";
            this.txtIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIntiqalNo.Size = new System.Drawing.Size(140, 33);
            this.txtIntiqalNo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(985, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "ٹوکن نمبر";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(921, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام مشتری/مرتہن/وارث";
            // 
            // txtbuyerName
            // 
            this.txtbuyerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuyerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuyerName.Enabled = false;
            this.txtbuyerName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuyerName.Location = new System.Drawing.Point(164, 136);
            this.txtbuyerName.Name = "txtbuyerName";
            this.txtbuyerName.Size = new System.Drawing.Size(754, 37);
            this.txtbuyerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(730, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "انتقال نمبر";
            // 
            // txtSellerName
            // 
            this.txtSellerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSellerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellerName.Enabled = false;
            this.txtSellerName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellerName.Location = new System.Drawing.Point(164, 80);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(754, 37);
            this.txtSellerName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GridWitnessDetails);
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 289);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1050, 224);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // GridWitnessDetails
            // 
            this.GridWitnessDetails.AllowUserToAddRows = false;
            this.GridWitnessDetails.AllowUserToDeleteRows = false;
            this.GridWitnessDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridWitnessDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridWitnessDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChooseWitness});
            this.GridWitnessDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridWitnessDetails.Location = new System.Drawing.Point(249, 16);
            this.GridWitnessDetails.Name = "GridWitnessDetails";
            this.GridWitnessDetails.ReadOnly = true;
            this.GridWitnessDetails.RowHeadersVisible = false;
            this.GridWitnessDetails.RowTemplate.Height = 30;
            this.GridWitnessDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridWitnessDetails.Size = new System.Drawing.Size(798, 205);
            this.GridWitnessDetails.TabIndex = 0;
            this.GridWitnessDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridWitnessDetails_CellContentClick);
            // 
            // colChooseWitness
            // 
            this.colChooseWitness.HeaderText = "انتخاب کریں";
            this.colChooseWitness.Name = "colChooseWitness";
            this.colChooseWitness.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pbIntiqalnaqalDoc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 205);
            this.panel3.TabIndex = 0;
            // 
            // pbIntiqalnaqalDoc
            // 
            this.pbIntiqalnaqalDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIntiqalnaqalDoc.Location = new System.Drawing.Point(0, 0);
            this.pbIntiqalnaqalDoc.Name = "pbIntiqalnaqalDoc";
            this.pbIntiqalnaqalDoc.Size = new System.Drawing.Size(244, 203);
            this.pbIntiqalnaqalDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIntiqalnaqalDoc.TabIndex = 0;
            this.pbIntiqalnaqalDoc.TabStop = false;
            this.pbIntiqalnaqalDoc.Click += new System.EventHandler(this.pbIntiqalnaqalDoc_Click);
            this.pbIntiqalnaqalDoc.DoubleClick += new System.EventHandler(this.pbIntiqalnaqalDoc_DoubleClick);
            // 
            // frmNaqalIntiqal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1050, 572);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmNaqalIntiqal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "نقل انتقال";
            this.Load += new System.EventHandler(this.frmNaqalIntiqal_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridWitnessDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIntiqalnaqalDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewDoc;
        private System.Windows.Forms.Button btnDelMain;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectedRow;
        private System.Windows.Forms.TextBox txtSelectedIndex;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLastImageID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSearchSeller;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtIntiqalNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuyerName;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadToken;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView GridWitnessDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChooseWitness;
        private System.Windows.Forms.Button btnSearchBuyers;
        private System.Windows.Forms.Button btnListIntiqals;
        private System.Windows.Forms.ToolTip ToolTipIntiqalNaqal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbIntiqalnaqalDoc;
    }
}