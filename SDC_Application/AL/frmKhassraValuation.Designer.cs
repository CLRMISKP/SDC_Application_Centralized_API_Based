namespace SDC_Application.AL
{
    partial class frmKhassraValuation
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GridViewKhassraValueation = new System.Windows.Forms.DataGridView();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelKhatta = new System.Windows.Forms.Button();
            this.btnSaveKhata = new System.Windows.Forms.Button();
            this.btnNewKhata = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKhassraType = new System.Windows.Forms.ComboBox();
            this.cboKhassraDetailList = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtValuationId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKhassraValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKhassraList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.btnPrintGardawriTemplete = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKhassraValueation)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(556, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعین قیمت اراضی برائے نمبر خسرہ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1242, 48);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1242, 393);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridViewKhassraValueation);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1240, 212);
            this.groupBox3.TabIndex = 114;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تعین شدہ قیمت نمبر خسرہ برائے انتخاب کردہ سال";
            // 
            // GridViewKhassraValueation
            // 
            this.GridViewKhassraValueation.AllowUserToAddRows = false;
            this.GridViewKhassraValueation.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.GridViewKhassraValueation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewKhassraValueation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewKhassraValueation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewKhassraValueation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck});
            this.GridViewKhassraValueation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewKhassraValueation.Location = new System.Drawing.Point(3, 29);
            this.GridViewKhassraValueation.MultiSelect = false;
            this.GridViewKhassraValueation.Name = "GridViewKhassraValueation";
            this.GridViewKhassraValueation.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewKhassraValueation.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewKhassraValueation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewKhassraValueation.Size = new System.Drawing.Size(1234, 180);
            this.GridViewKhassraValueation.TabIndex = 2;
            this.GridViewKhassraValueation.TabStop = false;
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "انتخاب کریں";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelKhatta);
            this.groupBox2.Controls.Add(this.btnSaveKhata);
            this.groupBox2.Controls.Add(this.btnNewKhata);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1240, 64);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            // 
            // btnDelKhatta
            // 
            this.btnDelKhatta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelKhatta.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelKhatta.Location = new System.Drawing.Point(494, 11);
            this.btnDelKhatta.Name = "btnDelKhatta";
            this.btnDelKhatta.Size = new System.Drawing.Size(53, 48);
            this.btnDelKhatta.TabIndex = 112;
            this.btnDelKhatta.UseVisualStyleBackColor = true;
            // 
            // btnSaveKhata
            // 
            this.btnSaveKhata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveKhata.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveKhata.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveKhata.Location = new System.Drawing.Point(568, 11);
            this.btnSaveKhata.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveKhata.Name = "btnSaveKhata";
            this.btnSaveKhata.Size = new System.Drawing.Size(53, 48);
            this.btnSaveKhata.TabIndex = 110;
            this.btnSaveKhata.UseVisualStyleBackColor = true;
            this.btnSaveKhata.Click += new System.EventHandler(this.btnSaveKhata_Click);
            // 
            // btnNewKhata
            // 
            this.btnNewKhata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewKhata.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewKhata.Location = new System.Drawing.Point(642, 11);
            this.btnNewKhata.Name = "btnNewKhata";
            this.btnNewKhata.Size = new System.Drawing.Size(53, 48);
            this.btnNewKhata.TabIndex = 111;
            this.btnNewKhata.UseVisualStyleBackColor = true;
            this.btnNewKhata.Click += new System.EventHandler(this.btnNewKhata_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboKhassraType);
            this.groupBox1.Controls.Add(this.cboKhassraDetailList);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtValuationId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtKhassraValue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboKhassraList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1240, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تفصیل تعین قیمت نمبر خسرہ";
            // 
            // cboKhassraType
            // 
            this.cboKhassraType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhassraType.DisplayMember = "KhataNo";
            this.cboKhassraType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhassraType.FormattingEnabled = true;
            this.cboKhassraType.Items.AddRange(new object[] {
            "2014-15",
            "2015-16",
            "2016-17",
            "2017-18",
            "2018-19",
            "2019-20",
            "2020-21",
            "2021-22",
            "2022-23",
            "2023-24",
            "2024-25",
            "2025-26",
            "2026-27",
            "2027-28",
            "2028-29",
            "2029-30",
            "2030-31",
            "2031-32",
            "2032-33",
            "2033-34",
            "2034-35",
            "2035-36",
            "2036-37",
            "2037-38",
            "2038-39",
            "2039-40",
            "2040-41",
            "2041-42",
            "2042-43",
            "2043-44 ",
            "2044-45",
            "2045-46",
            "2046-47",
            "2047-48",
            "2048-49",
            "2049-50",
            "2050-51",
            "2051-52",
            "2052-53",
            "2053-54"});
            this.cboKhassraType.Location = new System.Drawing.Point(520, 30);
            this.cboKhassraType.Name = "cboKhassraType";
            this.cboKhassraType.Size = new System.Drawing.Size(238, 27);
            this.cboKhassraType.TabIndex = 209;
            this.cboKhassraType.ValueMember = "RegisterHqDKhataId";
            // 
            // cboKhassraDetailList
            // 
            this.cboKhassraDetailList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhassraDetailList.DisplayMember = "KhataNo";
            this.cboKhassraDetailList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhassraDetailList.FormattingEnabled = true;
            this.cboKhassraDetailList.Items.AddRange(new object[] {
            "2014-15",
            "2015-16",
            "2016-17",
            "2017-18",
            "2018-19",
            "2019-20",
            "2020-21",
            "2021-22",
            "2022-23",
            "2023-24",
            "2024-25",
            "2025-26",
            "2026-27",
            "2027-28",
            "2028-29",
            "2029-30",
            "2030-31",
            "2031-32",
            "2032-33",
            "2033-34",
            "2034-35",
            "2035-36",
            "2036-37",
            "2037-38",
            "2038-39",
            "2039-40",
            "2040-41",
            "2041-42",
            "2042-43",
            "2043-44 ",
            "2044-45",
            "2045-46",
            "2046-47",
            "2047-48",
            "2048-49",
            "2049-50",
            "2050-51",
            "2051-52",
            "2052-53",
            "2053-54"});
            this.cboKhassraDetailList.Location = new System.Drawing.Point(838, 30);
            this.cboKhassraDetailList.Name = "cboKhassraDetailList";
            this.cboKhassraDetailList.Size = new System.Drawing.Size(148, 27);
            this.cboKhassraDetailList.TabIndex = 208;
            this.cboKhassraDetailList.ValueMember = "RegisterHqDKhataId";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(128, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 29);
            this.checkBox1.TabIndex = 114;
            this.checkBox1.Text = "chkConfirm";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // txtValuationId
            // 
            this.txtValuationId.Location = new System.Drawing.Point(11, 21);
            this.txtValuationId.Name = "txtValuationId";
            this.txtValuationId.Size = new System.Drawing.Size(100, 33);
            this.txtValuationId.TabIndex = 113;
            this.txtValuationId.Text = "-1";
            this.txtValuationId.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 68;
            this.label5.Text = "قیمت فی مرلہ";
            // 
            // txtKhassraValue
            // 
            this.txtKhassraValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraValue.Location = new System.Drawing.Point(291, 30);
            this.txtKhassraValue.Name = "txtKhassraValue";
            this.txtKhassraValue.Size = new System.Drawing.Size(143, 26);
            this.txtKhassraValue.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(992, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 65;
            this.label4.Text = "قسم آراضی";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(764, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 64;
            this.label3.Text = "نوعیت آراضی";
            // 
            // cboKhassraList
            // 
            this.cboKhassraList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhassraList.DisplayMember = "KhataNo";
            this.cboKhassraList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhassraList.FormattingEnabled = true;
            this.cboKhassraList.Location = new System.Drawing.Point(1054, 30);
            this.cboKhassraList.Name = "cboKhassraList";
            this.cboKhassraList.Size = new System.Drawing.Size(124, 27);
            this.cboKhassraList.TabIndex = 106;
            this.cboKhassraList.ValueMember = "RegisterHqDKhataId";
            this.cboKhassraList.SelectionChangeCommitted += new System.EventHandler(this.cboKhassraList_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1184, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "نمبر خسرہ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cboYear);
            this.panel4.Controls.Add(this.btnPrintGardawriTemplete);
            this.panel4.Controls.Add(this.lbl1);
            this.panel4.Controls.Add(this.cmbMouza);
            this.panel4.Controls.Add(this.lbl11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1240, 49);
            this.panel4.TabIndex = 2;
            // 
            // cboYear
            // 
            this.cboYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYear.DisplayMember = "KhataNo";
            this.cboYear.Enabled = false;
            this.cboYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "2014-15",
            "2015-16",
            "2016-17",
            "2017-18",
            "2018-19",
            "2019-20",
            "2020-21",
            "2021-22",
            "2022-23",
            "2023-24",
            "2024-25",
            "2025-26",
            "2026-27",
            "2027-28",
            "2028-29",
            "2029-30",
            "2030-31",
            "2031-32",
            "2032-33",
            "2033-34",
            "2034-35",
            "2035-36",
            "2036-37",
            "2037-38",
            "2038-39",
            "2039-40",
            "2040-41",
            "2041-42",
            "2042-43",
            "2043-44 ",
            "2044-45",
            "2045-46",
            "2046-47",
            "2047-48",
            "2048-49",
            "2049-50",
            "2050-51",
            "2051-52",
            "2052-53",
            "2053-54"});
            this.cboYear.Location = new System.Drawing.Point(806, 12);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(148, 27);
            this.cboYear.TabIndex = 207;
            this.cboYear.ValueMember = "RegisterHqDKhataId";
            this.cboYear.SelectionChangeCommitted += new System.EventHandler(this.cboYear_SelectionChangeCommitted);
            // 
            // btnPrintGardawriTemplete
            // 
            this.btnPrintGardawriTemplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintGardawriTemplete.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrintGardawriTemplete.BackgroundImage = global::SDC_Application.Resource1.Print31;
            this.btnPrintGardawriTemplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintGardawriTemplete.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintGardawriTemplete.ForeColor = System.Drawing.Color.Black;
            this.btnPrintGardawriTemplete.Location = new System.Drawing.Point(738, 6);
            this.btnPrintGardawriTemplete.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintGardawriTemplete.Name = "btnPrintGardawriTemplete";
            this.btnPrintGardawriTemplete.Padding = new System.Windows.Forms.Padding(2);
            this.btnPrintGardawriTemplete.Size = new System.Drawing.Size(54, 38);
            this.btnPrintGardawriTemplete.TabIndex = 206;
            this.btnPrintGardawriTemplete.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1190, 13);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(38, 25);
            this.lbl1.TabIndex = 52;
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
            this.cmbMouza.Location = new System.Drawing.Point(996, 12);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(188, 27);
            this.cmbMouza.TabIndex = 101;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            // 
            // lbl11
            // 
            this.lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11.AutoSize = true;
            this.lbl11.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.Location = new System.Drawing.Point(960, 13);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(29, 25);
            this.lbl11.TabIndex = 62;
            this.lbl11.Text = "سئہ ";
            // 
            // frmKhassraValuation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1242, 479);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmKhassraValuation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "خسرہ ویلویشن";
            this.Load += new System.EventHandler(this.frmKhassraValuation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKhassraValueation)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button btnPrintGardawriTemplete;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtValuationId;
        private System.Windows.Forms.Button btnDelKhatta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveKhata;
        private System.Windows.Forms.TextBox txtKhassraValue;
        private System.Windows.Forms.Button btnNewKhata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhassraList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView GridViewKhassraValueation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.ComboBox cboKhassraType;
        private System.Windows.Forms.ComboBox cboKhassraDetailList;
    }
}