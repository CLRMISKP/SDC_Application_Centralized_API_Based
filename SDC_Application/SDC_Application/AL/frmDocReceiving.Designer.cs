namespace SDC_Application.AL
{
    partial class frmDocReceiving
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoOfPages = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoOfDocs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cboMouza = new System.Windows.Forms.ComboBox();
            this.dtpReceivingDate = new System.Windows.Forms.DateTimePicker();
            this.lbl11 = new System.Windows.Forms.Label();
            this.txtRcId = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtDocDetails = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDocEntry = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gridviewRcByDate = new System.Windows.Forms.DataGridView();
            this.colSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabStatusUpdate = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridveiwDocs = new System.Windows.Forms.DataGridView();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtReceivingIdForUpdate = new System.Windows.Forms.TextBox();
            this.rbComplete = new System.Windows.Forms.RadioButton();
            this.rbPending = new System.Windows.Forms.RadioButton();
            this.rbInProcess = new System.Windows.Forms.RadioButton();
            this.rbRecieved = new System.Windows.Forms.RadioButton();
            this.btnSaveDocStatus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboMouzaSearch = new System.Windows.Forms.ComboBox();
            this.txtDocNoSearch = new System.Windows.Forms.TextBox();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.btnPrintMisalBadar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDocEntry.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewRcByDate)).BeginInit();
            this.tabStatusUpdate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridveiwDocs)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 47);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1252, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "سروس ڈیلیوری سنٹر پر وصول شدہ دستویزات کی اندراج";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1252, 10);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNoOfPages);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNoOfDocs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDocType);
            this.groupBox1.Controls.Add(this.label77);
            this.groupBox1.Controls.Add(this.txtDocNo);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.cboMouza);
            this.groupBox1.Controls.Add(this.dtpReceivingDate);
            this.groupBox1.Controls.Add(this.lbl11);
            this.groupBox1.Controls.Add(this.txtRcId);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtDocDetails);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(660, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 404);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تفصیل دستویز";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 25);
            this.label8.TabIndex = 209;
            this.label8.Text = "تعداد صفحات";
            // 
            // txtNoOfPages
            // 
            this.txtNoOfPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoOfPages.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfPages.Location = new System.Drawing.Point(28, 117);
            this.txtNoOfPages.Name = "txtNoOfPages";
            this.txtNoOfPages.Size = new System.Drawing.Size(198, 26);
            this.txtNoOfPages.TabIndex = 6;
            this.txtNoOfPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumericOnly_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(498, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 25);
            this.label7.TabIndex = 207;
            this.label7.Text = "تعداد دستویزات";
            // 
            // txtNoOfDocs
            // 
            this.txtNoOfDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoOfDocs.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDocs.Location = new System.Drawing.Point(303, 118);
            this.txtNoOfDocs.Name = "txtNoOfDocs";
            this.txtNoOfDocs.Size = new System.Drawing.Size(185, 26);
            this.txtNoOfDocs.TabIndex = 5;
            this.txtNoOfDocs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumericOnly_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 205;
            this.label2.Text = "قسم دستویز";
            // 
            // cboDocType
            // 
            this.cboDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDocType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDocType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDocType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point(28, 30);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboDocType.Size = new System.Drawing.Size(198, 27);
            this.cboDocType.TabIndex = 2;
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(498, 73);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(58, 25);
            this.label77.TabIndex = 37;
            this.label77.Text = " دستویز نمبر";
            // 
            // txtDocNo
            // 
            this.txtDocNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNo.Location = new System.Drawing.Point(303, 72);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(185, 26);
            this.txtDocNo.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(498, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(38, 25);
            this.lbl1.TabIndex = 50;
            this.lbl1.Text = "موضع";
            // 
            // cboMouza
            // 
            this.cboMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMouza.FormattingEnabled = true;
            this.cboMouza.Location = new System.Drawing.Point(303, 30);
            this.cboMouza.Name = "cboMouza";
            this.cboMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboMouza.Size = new System.Drawing.Size(185, 27);
            this.cboMouza.TabIndex = 1;
            this.cboMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // dtpReceivingDate
            // 
            this.dtpReceivingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReceivingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReceivingDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceivingDate.Location = new System.Drawing.Point(28, 74);
            this.dtpReceivingDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpReceivingDate.Name = "dtpReceivingDate";
            this.dtpReceivingDate.Size = new System.Drawing.Size(198, 26);
            this.dtpReceivingDate.TabIndex = 4;
            this.dtpReceivingDate.Tag = "2";
            this.dtpReceivingDate.ValueChanged += new System.EventHandler(this.dtpReceivingDate_ValueChanged);
            // 
            // lbl11
            // 
            this.lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(236, 73);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(59, 25);
            this.lbl11.TabIndex = 46;
            this.lbl11.Text = "تاریخ وصولی";
            // 
            // txtRcId
            // 
            this.txtRcId.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRcId.Location = new System.Drawing.Point(50, 271);
            this.txtRcId.Name = "txtRcId";
            this.txtRcId.Size = new System.Drawing.Size(88, 21);
            this.txtRcId.TabIndex = 44;
            this.txtRcId.Text = "-1";
            this.txtRcId.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(236, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 48);
            this.btnSave.TabIndex = 8;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(498, 165);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(41, 25);
            this.label73.TabIndex = 39;
            this.label73.Text = " تفصیل";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNew.Location = new System.Drawing.Point(304, 260);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(53, 48);
            this.btnNew.TabIndex = 9;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtDocDetails
            // 
            this.txtDocDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocDetails.Location = new System.Drawing.Point(28, 165);
            this.txtDocDetails.Multiline = true;
            this.txtDocDetails.Name = "txtDocDetails";
            this.txtDocDetails.Size = new System.Drawing.Size(460, 77);
            this.txtDocDetails.TabIndex = 7;
            this.txtDocDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDocEntry);
            this.tabControl1.Controls.Add(this.tabStatusUpdate);
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1252, 448);
            this.tabControl1.TabIndex = 2;
            // 
            // tabDocEntry
            // 
            this.tabDocEntry.Controls.Add(this.groupBox4);
            this.tabDocEntry.Controls.Add(this.groupBox1);
            this.tabDocEntry.Location = new System.Drawing.Point(4, 34);
            this.tabDocEntry.Name = "tabDocEntry";
            this.tabDocEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocEntry.Size = new System.Drawing.Size(1244, 410);
            this.tabDocEntry.TabIndex = 0;
            this.tabDocEntry.Text = "اندراج دستویزات";
            this.tabDocEntry.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridviewRcByDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(47, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(613, 404);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "انتخاب کردہ تاریخ پر محفوظ شدہ دستویزات";
            // 
            // gridviewRcByDate
            // 
            this.gridviewRcByDate.AllowUserToAddRows = false;
            this.gridviewRcByDate.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridviewRcByDate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridviewRcByDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridviewRcByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewRcByDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSel});
            this.gridviewRcByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridviewRcByDate.Location = new System.Drawing.Point(3, 29);
            this.gridviewRcByDate.MultiSelect = false;
            this.gridviewRcByDate.Name = "gridviewRcByDate";
            this.gridviewRcByDate.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridviewRcByDate.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridviewRcByDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewRcByDate.Size = new System.Drawing.Size(607, 372);
            this.gridviewRcByDate.TabIndex = 2;
            this.gridviewRcByDate.TabStop = false;
            this.gridviewRcByDate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewRcByDate_CellClick);
            // 
            // colSel
            // 
            this.colSel.HeaderText = "انتخاب کریں";
            this.colSel.Name = "colSel";
            this.colSel.ReadOnly = true;
            // 
            // tabStatusUpdate
            // 
            this.tabStatusUpdate.Controls.Add(this.groupBox2);
            this.tabStatusUpdate.Location = new System.Drawing.Point(4, 34);
            this.tabStatusUpdate.Name = "tabStatusUpdate";
            this.tabStatusUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatusUpdate.Size = new System.Drawing.Size(1244, 410);
            this.tabStatusUpdate.TabIndex = 1;
            this.tabStatusUpdate.Text = "تلاش و تبدیلی حالت دستویزات";
            this.tabStatusUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridveiwDocs);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(354, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(887, 404);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // gridveiwDocs
            // 
            this.gridveiwDocs.AllowUserToAddRows = false;
            this.gridveiwDocs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.gridveiwDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridveiwDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridveiwDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridveiwDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck});
            this.gridveiwDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridveiwDocs.Location = new System.Drawing.Point(3, 159);
            this.gridveiwDocs.MultiSelect = false;
            this.gridveiwDocs.Name = "gridveiwDocs";
            this.gridveiwDocs.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridveiwDocs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridveiwDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridveiwDocs.Size = new System.Drawing.Size(881, 242);
            this.gridveiwDocs.TabIndex = 1;
            this.gridveiwDocs.TabStop = false;
            this.gridveiwDocs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridveiwDocs_CellClick);
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "انتخاب کریں";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.cboMouzaSearch);
            this.panel4.Controls.Add(this.txtDocNoSearch);
            this.panel4.Controls.Add(this.dtpDateStart);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.dtpDateEnd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(881, 130);
            this.panel4.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtReceivingIdForUpdate);
            this.groupBox3.Controls.Add(this.rbComplete);
            this.groupBox3.Controls.Add(this.rbPending);
            this.groupBox3.Controls.Add(this.rbInProcess);
            this.groupBox3.Controls.Add(this.rbRecieved);
            this.groupBox3.Controls.Add(this.btnSaveDocStatus);
            this.groupBox3.Location = new System.Drawing.Point(23, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(843, 73);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حالت دستویز";
            // 
            // txtReceivingIdForUpdate
            // 
            this.txtReceivingIdForUpdate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivingIdForUpdate.Location = new System.Drawing.Point(24, 32);
            this.txtReceivingIdForUpdate.Name = "txtReceivingIdForUpdate";
            this.txtReceivingIdForUpdate.Size = new System.Drawing.Size(88, 21);
            this.txtReceivingIdForUpdate.TabIndex = 47;
            this.txtReceivingIdForUpdate.Text = "-1";
            this.txtReceivingIdForUpdate.Visible = false;
            // 
            // rbComplete
            // 
            this.rbComplete.AutoSize = true;
            this.rbComplete.Location = new System.Drawing.Point(549, 30);
            this.rbComplete.Name = "rbComplete";
            this.rbComplete.Size = new System.Drawing.Size(66, 29);
            this.rbComplete.TabIndex = 46;
            this.rbComplete.Text = "مکمل شدہ";
            this.rbComplete.UseVisualStyleBackColor = true;
            // 
            // rbPending
            // 
            this.rbPending.AutoSize = true;
            this.rbPending.Location = new System.Drawing.Point(621, 30);
            this.rbPending.Name = "rbPending";
            this.rbPending.Size = new System.Drawing.Size(57, 29);
            this.rbPending.TabIndex = 45;
            this.rbPending.Text = "زیر التوا";
            this.rbPending.UseVisualStyleBackColor = true;
            // 
            // rbInProcess
            // 
            this.rbInProcess.AutoSize = true;
            this.rbInProcess.Location = new System.Drawing.Point(689, 30);
            this.rbInProcess.Name = "rbInProcess";
            this.rbInProcess.Size = new System.Drawing.Size(53, 29);
            this.rbInProcess.TabIndex = 44;
            this.rbInProcess.Text = "زیر کار";
            this.rbInProcess.UseVisualStyleBackColor = true;
            // 
            // rbRecieved
            // 
            this.rbRecieved.AutoSize = true;
            this.rbRecieved.Location = new System.Drawing.Point(748, 30);
            this.rbRecieved.Name = "rbRecieved";
            this.rbRecieved.Size = new System.Drawing.Size(73, 29);
            this.rbRecieved.TabIndex = 43;
            this.rbRecieved.Text = "وصول شدہ";
            this.rbRecieved.UseVisualStyleBackColor = true;
            // 
            // btnSaveDocStatus
            // 
            this.btnSaveDocStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDocStatus.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveDocStatus.Location = new System.Drawing.Point(454, 20);
            this.btnSaveDocStatus.Name = "btnSaveDocStatus";
            this.btnSaveDocStatus.Size = new System.Drawing.Size(53, 48);
            this.btnSaveDocStatus.TabIndex = 42;
            this.btnSaveDocStatus.TabStop = false;
            this.btnSaveDocStatus.UseVisualStyleBackColor = true;
            this.btnSaveDocStatus.Click += new System.EventHandler(this.btnSaveDocStatus_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(672, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 25);
            this.label6.TabIndex = 54;
            this.label6.Text = "موضع";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(813, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 48;
            this.label3.Text = " دستویز نمبر";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 50;
            this.label4.Text = "تاریخ";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Image = global::SDC_Application.Resource1.search01;
            this.btnSearch.Location = new System.Drawing.Point(47, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 29);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboMouzaSearch
            // 
            this.cboMouzaSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMouzaSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMouzaSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMouzaSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboMouzaSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMouzaSearch.FormattingEnabled = true;
            this.cboMouzaSearch.Location = new System.Drawing.Point(477, 15);
            this.cboMouzaSearch.Name = "cboMouzaSearch";
            this.cboMouzaSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboMouzaSearch.Size = new System.Drawing.Size(185, 27);
            this.cboMouzaSearch.TabIndex = 9;
            // 
            // txtDocNoSearch
            // 
            this.txtDocNoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocNoSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNoSearch.Location = new System.Drawing.Point(722, 15);
            this.txtDocNoSearch.Name = "txtDocNoSearch";
            this.txtDocNoSearch.Size = new System.Drawing.Size(81, 26);
            this.txtDocNoSearch.TabIndex = 8;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateStart.Checked = false;
            this.dtpDateStart.CustomFormat = "dd/MM/yyyy";
            this.dtpDateStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart.Location = new System.Drawing.Point(287, 15);
            this.dtpDateStart.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowCheckBox = true;
            this.dtpDateStart.Size = new System.Drawing.Size(144, 26);
            this.dtpDateStart.TabIndex = 10;
            this.dtpDateStart.Tag = "2";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 52;
            this.label5.Text = "تا";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateEnd.Checked = false;
            this.dtpDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpDateEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(105, 15);
            this.dtpDateEnd.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(144, 26);
            this.dtpDateEnd.TabIndex = 11;
            this.dtpDateEnd.Tag = "2";
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.btnPrintMisalBadar);
            this.tabReport.Location = new System.Drawing.Point(4, 34);
            this.tabReport.Name = "tabReport";
            this.tabReport.Size = new System.Drawing.Size(1244, 410);
            this.tabReport.TabIndex = 2;
            this.tabReport.Text = "رپورٹ دستویزات";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // btnPrintMisalBadar
            // 
            this.btnPrintMisalBadar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintMisalBadar.BackgroundImage = global::SDC_Application.Resource1.Print3;
            this.btnPrintMisalBadar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintMisalBadar.Location = new System.Drawing.Point(596, 178);
            this.btnPrintMisalBadar.Name = "btnPrintMisalBadar";
            this.btnPrintMisalBadar.Size = new System.Drawing.Size(53, 55);
            this.btnPrintMisalBadar.TabIndex = 203;
            this.btnPrintMisalBadar.UseVisualStyleBackColor = true;
            // 
            // frmDocReceiving
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1252, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDocReceiving";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "سروس ڈیلیوری سنٹر پر وصول شدہ دستویزات کی اندراج";
            this.Load += new System.EventHandler(this.frmDocReceiving_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDocEntry.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewRcByDate)).EndInit();
            this.tabStatusUpdate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridveiwDocs)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cboMouza;
        private System.Windows.Forms.DateTimePicker dtpReceivingDate;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.TextBox txtRcId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.TextBox txtDocDetails;
        private System.Windows.Forms.Label label77;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDocEntry;
        private System.Windows.Forms.TabPage tabStatusUpdate;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridveiwDocs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbComplete;
        private System.Windows.Forms.RadioButton rbPending;
        private System.Windows.Forms.RadioButton rbInProcess;
        private System.Windows.Forms.RadioButton rbRecieved;
        private System.Windows.Forms.Button btnSaveDocStatus;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboMouzaSearch;
        private System.Windows.Forms.TextBox txtDocNoSearch;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoOfPages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoOfDocs;
        private System.Windows.Forms.Button btnPrintMisalBadar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gridviewRcByDate;
        private System.Windows.Forms.TextBox txtReceivingIdForUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSel;
    }
}