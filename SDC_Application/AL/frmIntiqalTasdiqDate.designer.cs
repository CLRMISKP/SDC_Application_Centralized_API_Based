namespace SDC_Application.AL
{
    partial class frmIntiqalTasdiqDate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridViewAssignedDates = new System.Windows.Forms.DataGridView();
            this.ColChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.btnSearchExistingRecord = new System.Windows.Forms.Button();
            this.txthdnMozaId = new System.Windows.Forms.TextBox();
            this.txthdnIntiqalId = new System.Windows.Forms.TextBox();
            this.txthdnTokenId = new System.Windows.Forms.TextBox();
            this.txthdnVisPlanId = new System.Windows.Forms.TextBox();
            this.txtIntiqalNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.txtTokenNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRO = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbStatus = new System.Windows.Forms.CheckBox();
            this.btnNewVoucher = new System.Windows.Forms.Button();
            this.btnMasterSave = new System.Windows.Forms.Button();
            this.txtIntiqalNoNew = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVdateTime = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTokenNoNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssignedDates)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 40);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(452, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 33);
            this.label9.TabIndex = 0;
            this.label9.Text = "تاریخ و وقت برائے تصدیق انتقال";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 47);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1040, 456);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1028, 320);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " تفویض شدہ تاریخ تصدیق انتقال";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gridViewAssignedDates);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 78);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1022, 239);
            this.panel5.TabIndex = 1;
            // 
            // gridViewAssignedDates
            // 
            this.gridViewAssignedDates.AllowUserToAddRows = false;
            this.gridViewAssignedDates.AllowUserToDeleteRows = false;
            this.gridViewAssignedDates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewAssignedDates.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridViewAssignedDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewAssignedDates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChk});
            this.gridViewAssignedDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewAssignedDates.Location = new System.Drawing.Point(0, 0);
            this.gridViewAssignedDates.Name = "gridViewAssignedDates";
            this.gridViewAssignedDates.ReadOnly = true;
            this.gridViewAssignedDates.RowHeadersVisible = false;
            this.gridViewAssignedDates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewAssignedDates.Size = new System.Drawing.Size(1022, 239);
            this.gridViewAssignedDates.TabIndex = 0;
            this.gridViewAssignedDates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewAssignedDates_CellClick);
            // 
            // ColChk
            // 
            this.ColChk.FillWeight = 50F;
            this.ColChk.HeaderText = "انتخاب کریں";
            this.ColChk.Name = "ColChk";
            this.ColChk.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSearchExistingRecord);
            this.panel4.Controls.Add(this.txthdnMozaId);
            this.panel4.Controls.Add(this.txthdnIntiqalId);
            this.panel4.Controls.Add(this.txthdnTokenId);
            this.panel4.Controls.Add(this.txthdnVisPlanId);
            this.panel4.Controls.Add(this.txtIntiqalNo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpDateFilter);
            this.panel4.Controls.Add(this.txtTokenNO);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lbl1);
            this.panel4.Controls.Add(this.cmbMouza);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1022, 49);
            this.panel4.TabIndex = 0;
            // 
            // dt
            // 
            this.dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt.CustomFormat = "dd/MM/yyyy";
            this.dt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt.Location = new System.Drawing.Point(6, 89);
            this.dt.Name = "dt";
            this.dt.RightToLeftLayout = true;
            this.dt.Size = new System.Drawing.Size(185, 29);
            this.dt.TabIndex = 53;
            this.dt.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dt.Visible = false;
            // 
            // btnSearchExistingRecord
            // 
            this.btnSearchExistingRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchExistingRecord.BackgroundImage = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearchExistingRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchExistingRecord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchExistingRecord.Location = new System.Drawing.Point(212, 9);
            this.btnSearchExistingRecord.Name = "btnSearchExistingRecord";
            this.btnSearchExistingRecord.Size = new System.Drawing.Size(35, 31);
            this.btnSearchExistingRecord.TabIndex = 52;
            this.toolTip1.SetToolTip(this.btnSearchExistingRecord, "محفوظ شدہ ریکارڈ میں سے تلاش کریں");
            this.btnSearchExistingRecord.UseVisualStyleBackColor = true;
            this.btnSearchExistingRecord.Click += new System.EventHandler(this.btnSearchExistingRecord_Click);
            // 
            // txthdnMozaId
            // 
            this.txthdnMozaId.Location = new System.Drawing.Point(77, 7);
            this.txthdnMozaId.Name = "txthdnMozaId";
            this.txthdnMozaId.Size = new System.Drawing.Size(15, 33);
            this.txthdnMozaId.TabIndex = 51;
            this.txthdnMozaId.Visible = false;
            // 
            // txthdnIntiqalId
            // 
            this.txthdnIntiqalId.Location = new System.Drawing.Point(54, 7);
            this.txthdnIntiqalId.Name = "txthdnIntiqalId";
            this.txthdnIntiqalId.Size = new System.Drawing.Size(15, 33);
            this.txthdnIntiqalId.TabIndex = 50;
            this.txthdnIntiqalId.Visible = false;
            // 
            // txthdnTokenId
            // 
            this.txthdnTokenId.Location = new System.Drawing.Point(31, 8);
            this.txthdnTokenId.Name = "txthdnTokenId";
            this.txthdnTokenId.Size = new System.Drawing.Size(15, 33);
            this.txthdnTokenId.TabIndex = 49;
            this.txthdnTokenId.Visible = false;
            // 
            // txthdnVisPlanId
            // 
            this.txthdnVisPlanId.Location = new System.Drawing.Point(3, 9);
            this.txthdnVisPlanId.Name = "txthdnVisPlanId";
            this.txthdnVisPlanId.Size = new System.Drawing.Size(20, 33);
            this.txthdnVisPlanId.TabIndex = 48;
            this.txthdnVisPlanId.Visible = false;
            // 
            // txtIntiqalNo
            // 
            this.txtIntiqalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntiqalNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtIntiqalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIntiqalNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntiqalNo.Location = new System.Drawing.Point(269, 10);
            this.txtIntiqalNo.Name = "txtIntiqalNo";
            this.txtIntiqalNo.Size = new System.Drawing.Size(113, 26);
            this.txtIntiqalNo.TabIndex = 46;
            this.txtIntiqalNo.TabStop = false;
            this.toolTip1.SetToolTip(this.txtIntiqalNo, "اگر انتقال نمبر سے تلاش مطلب ہو تو انتقال نمبر درج کریں");
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(389, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 30);
            this.label5.TabIndex = 47;
            this.label5.Text = "انتقال نمبر";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(592, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 30);
            this.label3.TabIndex = 45;
            this.label3.Text = "تاریخ";
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateFilter.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFilter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFilter.Location = new System.Drawing.Point(462, 10);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.RightToLeftLayout = true;
            this.dtpDateFilter.Size = new System.Drawing.Size(124, 26);
            this.dtpDateFilter.TabIndex = 44;
            this.toolTip1.SetToolTip(this.dtpDateFilter, "تلاش کرنے کیلئے مطلوبہ تاریخ انتخاب کریں");
            this.dtpDateFilter.ValueChanged += new System.EventHandler(this.dtpDateFilter_ValueChanged);
            // 
            // txtTokenNO
            // 
            this.txtTokenNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtTokenNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokenNO.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNO.Location = new System.Drawing.Point(643, 10);
            this.txtTokenNO.Name = "txtTokenNO";
            this.txtTokenNO.Size = new System.Drawing.Size(113, 26);
            this.txtTokenNO.TabIndex = 42;
            this.txtTokenNO.TabStop = false;
            this.toolTip1.SetToolTip(this.txtTokenNO, "تلاش کیلئے ٹوکن نمبر انٹر کریں");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(763, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 30);
            this.label4.TabIndex = 43;
            this.label4.Text = "ٹوکن نمبر";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(973, 8);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(42, 30);
            this.lbl1.TabIndex = 41;
            this.lbl1.Text = "موضع";
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.Location = new System.Drawing.Point(832, 10);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(135, 27);
            this.cmbMouza.TabIndex = 40;
            this.toolTip1.SetToolTip(this.cmbMouza, "تلاش کیلئے موضع کا انتخاب کرِیں");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbRO);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chbStatus);
            this.groupBox1.Controls.Add(this.btnNewVoucher);
            this.groupBox1.Controls.Add(this.btnMasterSave);
            this.groupBox1.Controls.Add(this.txtIntiqalNoNew);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpVdateTime);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtTokenNoNew);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اندراج/تبدیلی تاریخ تصدیق انتقال";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(959, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 30);
            this.label8.TabIndex = 56;
            this.label8.Text = "ریونیو افسر";
            // 
            // cmbRO
            // 
            this.cmbRO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRO.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRO.FormattingEnabled = true;
            this.cmbRO.Location = new System.Drawing.Point(766, 78);
            this.cmbRO.Name = "cmbRO";
            this.cmbRO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbRO.Size = new System.Drawing.Size(187, 27);
            this.cmbRO.TabIndex = 55;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(272, 76);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(426, 26);
            this.txtRemarks.TabIndex = 53;
            this.txtRemarks.TabStop = false;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(704, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 30);
            this.label7.TabIndex = 54;
            this.label7.Text = "ریمارکس";
            // 
            // chbStatus
            // 
            this.chbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbStatus.AutoSize = true;
            this.chbStatus.Location = new System.Drawing.Point(268, 31);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbStatus.Size = new System.Drawing.Size(52, 29);
            this.chbStatus.TabIndex = 52;
            this.chbStatus.Text = "موئثر";
            this.chbStatus.UseVisualStyleBackColor = true;
            // 
            // btnNewVoucher
            // 
            this.btnNewVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewVoucher.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewVoucher.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewVoucher.Location = new System.Drawing.Point(141, 32);
            this.btnNewVoucher.Name = "btnNewVoucher";
            this.btnNewVoucher.Size = new System.Drawing.Size(50, 50);
            this.btnNewVoucher.TabIndex = 51;
            this.toolTip1.SetToolTip(this.btnNewVoucher, "نئے ریکارڈ کے اندراج کے لئے کلک کریں");
            this.btnNewVoucher.UseVisualStyleBackColor = true;
            this.btnNewVoucher.Click += new System.EventHandler(this.btnNewVoucher_Click);
            // 
            // btnMasterSave
            // 
            this.btnMasterSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMasterSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMasterSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMasterSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnMasterSave.Location = new System.Drawing.Point(200, 32);
            this.btnMasterSave.Name = "btnMasterSave";
            this.btnMasterSave.Size = new System.Drawing.Size(50, 50);
            this.btnMasterSave.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnMasterSave, "ریکارڈ محفوظ کریں");
            this.btnMasterSave.UseVisualStyleBackColor = true;
            this.btnMasterSave.Click += new System.EventHandler(this.btnMasterSave_Click);
            // 
            // txtIntiqalNoNew
            // 
            this.txtIntiqalNoNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntiqalNoNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtIntiqalNoNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIntiqalNoNew.Enabled = false;
            this.txtIntiqalNoNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntiqalNoNew.Location = new System.Drawing.Point(607, 31);
            this.txtIntiqalNoNew.Name = "txtIntiqalNoNew";
            this.txtIntiqalNoNew.Size = new System.Drawing.Size(91, 26);
            this.txtIntiqalNoNew.TabIndex = 48;
            this.txtIntiqalNoNew.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(702, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 30);
            this.label6.TabIndex = 49;
            this.label6.Text = "انتقال نمبر";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(532, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "تاریخ و وقت";
            // 
            // dtpVdateTime
            // 
            this.dtpVdateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpVdateTime.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpVdateTime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVdateTime.Location = new System.Drawing.Point(324, 30);
            this.dtpVdateTime.Name = "dtpVdateTime";
            this.dtpVdateTime.RightToLeftLayout = true;
            this.dtpVdateTime.Size = new System.Drawing.Size(206, 29);
            this.dtpVdateTime.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Location = new System.Drawing.Point(766, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 31);
            this.btnSearch.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSearch, "ٹوکن نمبر لوڈ کریں");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTokenNoNew
            // 
            this.txtTokenNoNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenNoNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtTokenNoNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokenNoNew.Enabled = false;
            this.txtTokenNoNew.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNoNew.Location = new System.Drawing.Point(809, 32);
            this.txtTokenNoNew.Name = "txtTokenNoNew";
            this.txtTokenNoNew.Size = new System.Drawing.Size(144, 29);
            this.txtTokenNoNew.TabIndex = 8;
            this.txtTokenNoNew.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(959, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "ٹوکن نمبر";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmIntiqalTasdiqDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 543);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmIntiqalTasdiqDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتقال تصدیق تاریخ";
            this.Load += new System.EventHandler(this.frmIntiqalTasdiqDate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssignedDates)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridViewAssignedDates;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.TextBox txtTokenNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTokenNoNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpVdateTime;
        private System.Windows.Forms.TextBox txtIntiqalNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIntiqalNoNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNewVoucher;
        private System.Windows.Forms.Button btnMasterSave;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbStatus;
        private System.Windows.Forms.TextBox txthdnVisPlanId;
        private System.Windows.Forms.TextBox txthdnTokenId;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRO;
        private System.Windows.Forms.TextBox txthdnIntiqalId;
        private System.Windows.Forms.TextBox txthdnMozaId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchExistingRecord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColChk;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dt;
    }
}