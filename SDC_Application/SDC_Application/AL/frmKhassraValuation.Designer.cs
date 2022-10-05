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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabValueationByKhassra = new System.Windows.Forms.TabPage();
            this.tabValuationByMoza = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDelMozValue = new System.Windows.Forms.Button();
            this.btnSaveMozaValue = new System.Windows.Forms.Button();
            this.btnNewMozaValue = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboAreaType = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKhassraValueByMoza = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKhassraValueation)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabValueationByKhassra.SuspendLayout();
            this.tabValuationByMoza.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1242, 441);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridViewKhassraValueation);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1226, 198);
            this.groupBox3.TabIndex = 114;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تعین شدہ قیمت نمبر خسرہ برائے انتخاب کردہ سال";
            // 
            // GridViewKhassraValueation
            // 
            this.GridViewKhassraValueation.AllowUserToAddRows = false;
            this.GridViewKhassraValueation.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            this.GridViewKhassraValueation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridViewKhassraValueation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewKhassraValueation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewKhassraValueation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck});
            this.GridViewKhassraValueation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewKhassraValueation.Location = new System.Drawing.Point(3, 29);
            this.GridViewKhassraValueation.MultiSelect = false;
            this.GridViewKhassraValueation.Name = "GridViewKhassraValueation";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewKhassraValueation.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridViewKhassraValueation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewKhassraValueation.Size = new System.Drawing.Size(1220, 166);
            this.GridViewKhassraValueation.TabIndex = 2;
            this.GridViewKhassraValueation.TabStop = false;
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "انتخاب کریں";
            this.ColCheck.Name = "ColCheck";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelKhatta);
            this.groupBox2.Controls.Add(this.btnSaveKhata);
            this.groupBox2.Controls.Add(this.btnNewKhata);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1226, 73);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            // 
            // btnDelKhatta
            // 
            this.btnDelKhatta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelKhatta.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelKhatta.Location = new System.Drawing.Point(480, 18);
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
            this.btnSaveKhata.Location = new System.Drawing.Point(554, 18);
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
            this.btnNewKhata.Location = new System.Drawing.Point(628, 18);
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
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1226, 75);
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
            this.cboKhassraType.Location = new System.Drawing.Point(506, 30);
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
            this.cboKhassraDetailList.Location = new System.Drawing.Point(824, 30);
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
            this.label5.Location = new System.Drawing.Point(426, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 68;
            this.label5.Text = "قیمت فی مرلہ";
            // 
            // txtKhassraValue
            // 
            this.txtKhassraValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraValue.Location = new System.Drawing.Point(277, 30);
            this.txtKhassraValue.Name = "txtKhassraValue";
            this.txtKhassraValue.Size = new System.Drawing.Size(143, 26);
            this.txtKhassraValue.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(978, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 65;
            this.label4.Text = "قسم آراضی";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(750, 31);
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
            this.cboKhassraList.Location = new System.Drawing.Point(1040, 30);
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
            this.label2.Location = new System.Drawing.Point(1170, 31);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabValueationByKhassra);
            this.tabControl1.Controls.Add(this.tabValuationByMoza);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 390);
            this.tabControl1.TabIndex = 3;
            // 
            // tabValueationByKhassra
            // 
            this.tabValueationByKhassra.Controls.Add(this.panel5);
            this.tabValueationByKhassra.Controls.Add(this.panel2);
            this.tabValueationByKhassra.Controls.Add(this.groupBox1);
            this.tabValueationByKhassra.Location = new System.Drawing.Point(4, 34);
            this.tabValueationByKhassra.Name = "tabValueationByKhassra";
            this.tabValueationByKhassra.Padding = new System.Windows.Forms.Padding(3);
            this.tabValueationByKhassra.Size = new System.Drawing.Size(1232, 352);
            this.tabValueationByKhassra.TabIndex = 0;
            this.tabValueationByKhassra.Text = "تشخیص قیمت نمبر خسرہ ";
            this.tabValueationByKhassra.UseVisualStyleBackColor = true;
            // 
            // tabValuationByMoza
            // 
            this.tabValuationByMoza.Controls.Add(this.groupBox4);
            this.tabValuationByMoza.Controls.Add(this.groupBox5);
            this.tabValuationByMoza.Controls.Add(this.groupBox6);
            this.tabValuationByMoza.Location = new System.Drawing.Point(4, 34);
            this.tabValuationByMoza.Name = "tabValuationByMoza";
            this.tabValuationByMoza.Padding = new System.Windows.Forms.Padding(3);
            this.tabValuationByMoza.Size = new System.Drawing.Size(1232, 352);
            this.tabValuationByMoza.TabIndex = 1;
            this.tabValuationByMoza.Text = "تشحیص قیمت موضع و قسم زمین";
            this.tabValuationByMoza.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1226, 73);
            this.panel2.TabIndex = 111;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 151);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1226, 198);
            this.panel5.TabIndex = 112;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelMozValue);
            this.groupBox5.Controls.Add(this.btnSaveMozaValue);
            this.groupBox5.Controls.Add(this.btnNewMozaValue);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1226, 73);
            this.groupBox5.TabIndex = 116;
            this.groupBox5.TabStop = false;
            // 
            // btnDelMozValue
            // 
            this.btnDelMozValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMozValue.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelMozValue.Location = new System.Drawing.Point(516, 19);
            this.btnDelMozValue.Name = "btnDelMozValue";
            this.btnDelMozValue.Size = new System.Drawing.Size(53, 48);
            this.btnDelMozValue.TabIndex = 112;
            this.btnDelMozValue.UseVisualStyleBackColor = true;
            // 
            // btnSaveMozaValue
            // 
            this.btnSaveMozaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMozaValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMozaValue.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveMozaValue.Location = new System.Drawing.Point(590, 19);
            this.btnSaveMozaValue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveMozaValue.Name = "btnSaveMozaValue";
            this.btnSaveMozaValue.Size = new System.Drawing.Size(53, 48);
            this.btnSaveMozaValue.TabIndex = 110;
            this.btnSaveMozaValue.UseVisualStyleBackColor = true;
            // 
            // btnNewMozaValue
            // 
            this.btnNewMozaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewMozaValue.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewMozaValue.Location = new System.Drawing.Point(664, 19);
            this.btnNewMozaValue.Name = "btnNewMozaValue";
            this.btnNewMozaValue.Size = new System.Drawing.Size(53, 48);
            this.btnNewMozaValue.TabIndex = 111;
            this.btnNewMozaValue.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboAreaType);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txtKhassraValueByMoza);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1226, 75);
            this.groupBox6.TabIndex = 115;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "تفصیل تعین قیمت";
            // 
            // cboAreaType
            // 
            this.cboAreaType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaType.DisplayMember = "KhataNo";
            this.cboAreaType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreaType.FormattingEnabled = true;
            this.cboAreaType.Items.AddRange(new object[] {
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
            this.cboAreaType.Location = new System.Drawing.Point(696, 32);
            this.cboAreaType.Name = "cboAreaType";
            this.cboAreaType.Size = new System.Drawing.Size(238, 27);
            this.cboAreaType.TabIndex = 209;
            this.cboAreaType.ValueMember = "RegisterHqDKhataId";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(128, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 29);
            this.checkBox2.TabIndex = 114;
            this.checkBox2.Text = "chkConfirm";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 33);
            this.textBox1.TabIndex = 113;
            this.textBox1.Text = "-1";
            this.textBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 25);
            this.label6.TabIndex = 68;
            this.label6.Text = "قیمت فی مرلہ";
            // 
            // txtKhassraValueByMoza
            // 
            this.txtKhassraValueByMoza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraValueByMoza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraValueByMoza.Location = new System.Drawing.Point(480, 32);
            this.txtKhassraValueByMoza.Name = "txtKhassraValueByMoza";
            this.txtKhassraValueByMoza.Size = new System.Drawing.Size(143, 26);
            this.txtKhassraValueByMoza.TabIndex = 109;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(940, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 25);
            this.label8.TabIndex = 64;
            this.label8.Text = "نوعیت آراضی";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1226, 198);
            this.groupBox4.TabIndex = 117;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تعین شدہ قیمت نمبر خسرہ برائے انتخاب کردہ سال";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 29);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1220, 166);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.TabStop = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "انتخاب کریں";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // frmKhassraValuation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1242, 479);
            this.Controls.Add(this.panel3);
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
            this.tabControl1.ResumeLayout(false);
            this.tabValueationByKhassra.ResumeLayout(false);
            this.tabValuationByMoza.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabValueationByKhassra;
        private System.Windows.Forms.TabPage tabValuationByMoza;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDelMozValue;
        private System.Windows.Forms.Button btnSaveMozaValue;
        private System.Windows.Forms.Button btnNewMozaValue;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboAreaType;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKhassraValueByMoza;
        private System.Windows.Forms.Label label8;
    }
}