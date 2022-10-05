namespace SDC_Application.AL
{
    partial class frmCovid19Booking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTokenBooking = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCNIC = new System.Windows.Forms.MaskedTextBox();
            this.btnSearchBookingForUpdate = new System.Windows.Forms.Button();
            this.cmbPurpose = new System.Windows.Forms.ComboBox();
            this.cmbServiceId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegNew = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtBookingId = new System.Windows.Forms.TextBox();
            this.btnRegSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKafiyat = new System.Windows.Forms.TextBox();
            this.dtToken = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRegMoza = new System.Windows.Forms.ComboBox();
            this.grdvBooking = new System.Windows.Forms.DataGridView();
            this.TokenTime = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTokenBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBooking)).BeginInit();
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
            this.label1.Text = "ٹوکن بکنگ";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTokenBooking);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1252, 448);
            this.tabControl1.TabIndex = 2;
            // 
            // tabTokenBooking
            // 
            this.tabTokenBooking.Controls.Add(this.splitContainer1);
            this.tabTokenBooking.Location = new System.Drawing.Point(4, 34);
            this.tabTokenBooking.Name = "tabTokenBooking";
            this.tabTokenBooking.Size = new System.Drawing.Size(1244, 410);
            this.tabTokenBooking.TabIndex = 3;
            this.tabTokenBooking.Text = "ٹوکن بکنگ";
            this.tabTokenBooking.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdvBooking);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1244, 410);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnPrint);
            this.groupBox5.Controls.Add(this.TokenTime);
            this.groupBox5.Controls.Add(this.txtCNIC);
            this.groupBox5.Controls.Add(this.btnSearchBookingForUpdate);
            this.groupBox5.Controls.Add(this.cmbPurpose);
            this.groupBox5.Controls.Add(this.cmbServiceId);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtContactNo);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.btnRegNew);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.txtFatherName);
            this.groupBox5.Controls.Add(this.txtBookingId);
            this.groupBox5.Controls.Add(this.btnRegSave);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txtKafiyat);
            this.groupBox5.Controls.Add(this.dtToken);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cmbRegMoza);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1244, 161);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "تفصیل";
            // 
            // txtCNIC
            // 
            this.txtCNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNIC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNIC.Location = new System.Drawing.Point(468, 75);
            this.txtCNIC.Mask = "00000-0000000-0";
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.PromptChar = ' ';
            this.txtCNIC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCNIC.Size = new System.Drawing.Size(158, 26);
            this.txtCNIC.TabIndex = 6;
            // 
            // btnSearchBookingForUpdate
            // 
            this.btnSearchBookingForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchBookingForUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchBookingForUpdate.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchBookingForUpdate.Location = new System.Drawing.Point(312, 28);
            this.btnSearchBookingForUpdate.Name = "btnSearchBookingForUpdate";
            this.btnSearchBookingForUpdate.Size = new System.Drawing.Size(42, 29);
            this.btnSearchBookingForUpdate.TabIndex = 80;
            this.btnSearchBookingForUpdate.UseVisualStyleBackColor = true;
            this.btnSearchBookingForUpdate.Visible = false;
            this.btnSearchBookingForUpdate.Click += new System.EventHandler(this.btnSearchBookingForUpdate_Click);
            // 
            // cmbPurpose
            // 
            this.cmbPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurpose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPurpose.FormattingEnabled = true;
            this.cmbPurpose.Location = new System.Drawing.Point(597, 28);
            this.cmbPurpose.Name = "cmbPurpose";
            this.cmbPurpose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPurpose.Size = new System.Drawing.Size(156, 27);
            this.cmbPurpose.TabIndex = 2;
            this.cmbPurpose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPurpose_KeyPress);
            // 
            // cmbServiceId
            // 
            this.cmbServiceId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbServiceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServiceId.FormattingEnabled = true;
            this.cmbServiceId.Location = new System.Drawing.Point(818, 28);
            this.cmbServiceId.Name = "cmbServiceId";
            this.cmbServiceId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbServiceId.Size = new System.Drawing.Size(161, 27);
            this.cmbServiceId.TabIndex = 1;
            this.cmbServiceId.SelectedIndexChanged += new System.EventHandler(this.cmbServiceId_SelectedIndexChanged);
            this.cmbServiceId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbServiceId_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 77;
            this.label4.Text = "شناختی کارڈ نمبر";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(999, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 25);
            this.label3.TabIndex = 75;
            this.label3.Text = "والد";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(597, 75);
            this.txtContactNo.MaxLength = 11;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(156, 26);
            this.txtContactNo.TabIndex = 5;
            this.txtContactNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactNo_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 72;
            this.label2.Text = "مقصد";
            // 
            // btnRegNew
            // 
            this.btnRegNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegNew.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnRegNew.Location = new System.Drawing.Point(849, 115);
            this.btnRegNew.Name = "btnRegNew";
            this.btnRegNew.Size = new System.Drawing.Size(53, 48);
            this.btnRegNew.TabIndex = 70;
            this.btnRegNew.UseVisualStyleBackColor = true;
            this.btnRegNew.Click += new System.EventHandler(this.btnRegNew_Click);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1207, 68);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 25);
            this.label24.TabIndex = 69;
            this.label24.Text = "نام";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(1042, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 33);
            this.txtName.TabIndex = 3;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(753, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 25);
            this.label23.TabIndex = 67;
            this.label23.Text = "رابطہ نمبر";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFatherName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(818, 68);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(160, 33);
            this.txtFatherName.TabIndex = 4;
            this.txtFatherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // txtBookingId
            // 
            this.txtBookingId.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookingId.Location = new System.Drawing.Point(352, 126);
            this.txtBookingId.Name = "txtBookingId";
            this.txtBookingId.Size = new System.Drawing.Size(88, 21);
            this.txtBookingId.TabIndex = 65;
            this.txtBookingId.Text = "-1";
            this.txtBookingId.Visible = false;
            // 
            // btnRegSave
            // 
            this.btnRegSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnRegSave.Location = new System.Drawing.Point(780, 115);
            this.btnRegSave.Name = "btnRegSave";
            this.btnRegSave.Size = new System.Drawing.Size(53, 48);
            this.btnRegSave.TabIndex = 7;
            this.btnRegSave.UseVisualStyleBackColor = true;
            this.btnRegSave.Click += new System.EventHandler(this.btnRegSave_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(293, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 25);
            this.label14.TabIndex = 61;
            this.label14.Text = "ریمارکس";
            // 
            // txtKafiyat
            // 
            this.txtKafiyat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKafiyat.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKafiyat.Location = new System.Drawing.Point(8, 28);
            this.txtKafiyat.Multiline = true;
            this.txtKafiyat.Name = "txtKafiyat";
            this.txtKafiyat.Size = new System.Drawing.Size(279, 77);
            this.txtKafiyat.TabIndex = 6;
            this.txtKafiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // dtToken
            // 
            this.dtToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToken.CustomFormat = "dd-MM-yyyy";
            this.dtToken.Enabled = false;
            this.dtToken.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToken.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToken.Location = new System.Drawing.Point(8, 120);
            this.dtToken.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtToken.Name = "dtToken";
            this.dtToken.Size = new System.Drawing.Size(156, 26);
            this.dtToken.TabIndex = 3;
            this.dtToken.Tag = "2";
            this.dtToken.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(524, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 25);
            this.label11.TabIndex = 55;
            this.label11.Text = "وقت";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(985, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 25);
            this.label10.TabIndex = 53;
            this.label10.Text = "سہولت";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1194, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 25);
            this.label9.TabIndex = 51;
            this.label9.Text = "موضع";
            // 
            // cmbRegMoza
            // 
            this.cmbRegMoza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegMoza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRegMoza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRegMoza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRegMoza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegMoza.FormattingEnabled = true;
            this.cmbRegMoza.Location = new System.Drawing.Point(1042, 28);
            this.cmbRegMoza.Name = "cmbRegMoza";
            this.cmbRegMoza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbRegMoza.Size = new System.Drawing.Size(146, 27);
            this.cmbRegMoza.TabIndex = 0;
            this.cmbRegMoza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // grdvBooking
            // 
            this.grdvBooking.AllowUserToAddRows = false;
            this.grdvBooking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            this.grdvBooking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdvBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdvBooking.Location = new System.Drawing.Point(0, 0);
            this.grdvBooking.MultiSelect = false;
            this.grdvBooking.Name = "grdvBooking";
            this.grdvBooking.ReadOnly = true;
            this.grdvBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdvBooking.Size = new System.Drawing.Size(1244, 245);
            this.grdvBooking.TabIndex = 56;
            this.grdvBooking.TabStop = false;
            this.grdvBooking.DoubleClick += new System.EventHandler(this.grdvBooking_DoubleClick);
            // 
            // TokenTime
            // 
            this.TokenTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenTime.CustomFormat = "HH:mm";
            this.TokenTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokenTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TokenTime.Location = new System.Drawing.Point(386, 30);
            this.TokenTime.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TokenTime.Name = "TokenTime";
            this.TokenTime.ShowUpDown = true;
            this.TokenTime.Size = new System.Drawing.Size(122, 26);
            this.TokenTime.TabIndex = 81;
            this.TokenTime.Tag = "2";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.BackgroundImage = global::SDC_Application.Resource1.Print31;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(700, 115);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(2);
            this.btnPrint.Size = new System.Drawing.Size(73, 48);
            this.btnPrint.TabIndex = 82;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmCovid19Booking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1252, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCovid19Booking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ٹوکن بکنگ";
            this.Load += new System.EventHandler(this.frmDocReceiving_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTokenBooking.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBooking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTokenBooking;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtToken;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRegMoza;
        private System.Windows.Forms.Button btnRegSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKafiyat;
        private System.Windows.Forms.TextBox txtBookingId;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Button btnRegNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.ComboBox cmbServiceId;
        private System.Windows.Forms.ComboBox cmbPurpose;
        private System.Windows.Forms.Button btnSearchBookingForUpdate;
        private System.Windows.Forms.MaskedTextBox txtCNIC;
        private System.Windows.Forms.DataGridView grdvBooking;
        private System.Windows.Forms.DateTimePicker TokenTime;
        public System.Windows.Forms.Button btnPrint;
    }
}