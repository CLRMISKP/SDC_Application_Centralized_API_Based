namespace SDC_Application.AL
{
    partial class frmKhassraNewKhassraAreaType
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNewKhassra = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.dgKhatooniKhassras = new System.Windows.Forms.DataGridView();
            this.ColSelKhassras = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelKhassra = new System.Windows.Forms.Panel();
            this.txtKhassraId = new System.Windows.Forms.TextBox();
            this.btnNewKhassra = new System.Windows.Forms.Button();
            this.btnDeleteKhassra = new System.Windows.Forms.Button();
            this.btnSaveKhassra = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.txtKhassraNo = new System.Windows.Forms.TextBox();
            this.tabNewAreaType = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgKhassraDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbKhassras = new System.Windows.Forms.ComboBox();
            this.txtKhassraDetailId = new System.Windows.Forms.TextBox();
            this.btnNewKhassraArea = new System.Windows.Forms.Button();
            this.btnDelKhassraArea = new System.Windows.Forms.Button();
            this.btnSaveKhassraArea = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.txtKhassraMarla = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtKhassraKanal = new System.Windows.Forms.TextBox();
            this.txtKhassraSarsai = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cboAreaType = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKhatooniNo = new System.Windows.Forms.TextBox();
            this.txtKhataNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabNewKhassra.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhatooniKhassras)).BeginInit();
            this.panelKhassra.SuspendLayout();
            this.tabNewAreaType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhassraDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNewKhassra);
            this.tabControl1.Controls.Add(this.tabNewAreaType);
            this.tabControl1.Location = new System.Drawing.Point(0, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNewKhassra
            // 
            this.tabNewKhassra.Controls.Add(this.groupBox16);
            this.tabNewKhassra.Controls.Add(this.panelKhassra);
            this.tabNewKhassra.Location = new System.Drawing.Point(4, 40);
            this.tabNewKhassra.Name = "tabNewKhassra";
            this.tabNewKhassra.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewKhassra.Size = new System.Drawing.Size(1202, 409);
            this.tabNewKhassra.TabIndex = 0;
            this.tabNewKhassra.Text = "نیا خسرہ";
            this.tabNewKhassra.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.dgKhatooniKhassras);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox16.Location = new System.Drawing.Point(3, 75);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(1196, 331);
            this.groupBox16.TabIndex = 3;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "موجودہ نمبر خسرہ جات";
            // 
            // dgKhatooniKhassras
            // 
            this.dgKhatooniKhassras.AllowUserToAddRows = false;
            this.dgKhatooniKhassras.AllowUserToDeleteRows = false;
            this.dgKhatooniKhassras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhatooniKhassras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhatooniKhassras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelKhassras});
            this.dgKhatooniKhassras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhatooniKhassras.Location = new System.Drawing.Point(3, 35);
            this.dgKhatooniKhassras.Name = "dgKhatooniKhassras";
            this.dgKhatooniKhassras.ReadOnly = true;
            this.dgKhatooniKhassras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKhatooniKhassras.Size = new System.Drawing.Size(1190, 293);
            this.dgKhatooniKhassras.TabIndex = 3;
            // 
            // ColSelKhassras
            // 
            this.ColSelKhassras.HeaderText = "انتخاب کریں";
            this.ColSelKhassras.Name = "ColSelKhassras";
            this.ColSelKhassras.ReadOnly = true;
            // 
            // panelKhassra
            // 
            this.panelKhassra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKhassra.Controls.Add(this.txtKhassraId);
            this.panelKhassra.Controls.Add(this.btnNewKhassra);
            this.panelKhassra.Controls.Add(this.btnDeleteKhassra);
            this.panelKhassra.Controls.Add(this.btnSaveKhassra);
            this.panelKhassra.Controls.Add(this.label57);
            this.panelKhassra.Controls.Add(this.txtKhassraNo);
            this.panelKhassra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKhassra.Location = new System.Drawing.Point(3, 3);
            this.panelKhassra.Name = "panelKhassra";
            this.panelKhassra.Size = new System.Drawing.Size(1196, 72);
            this.panelKhassra.TabIndex = 1;
            // 
            // txtKhassraId
            // 
            this.txtKhassraId.Location = new System.Drawing.Point(18, 3);
            this.txtKhassraId.Name = "txtKhassraId";
            this.txtKhassraId.Size = new System.Drawing.Size(35, 39);
            this.txtKhassraId.TabIndex = 406;
            this.txtKhassraId.Text = "-1";
            this.txtKhassraId.Visible = false;
            // 
            // btnNewKhassra
            // 
            this.btnNewKhassra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewKhassra.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewKhassra.Location = new System.Drawing.Point(616, 15);
            this.btnNewKhassra.Name = "btnNewKhassra";
            this.btnNewKhassra.Size = new System.Drawing.Size(89, 39);
            this.btnNewKhassra.TabIndex = 310;
            this.btnNewKhassra.Text = "نیا خسرہ";
            this.btnNewKhassra.UseVisualStyleBackColor = true;
            this.btnNewKhassra.Click += new System.EventHandler(this.btnNewKhassra_Click);
            // 
            // btnDeleteKhassra
            // 
            this.btnDeleteKhassra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteKhassra.Location = new System.Drawing.Point(510, 15);
            this.btnDeleteKhassra.Name = "btnDeleteKhassra";
            this.btnDeleteKhassra.Size = new System.Drawing.Size(89, 39);
            this.btnDeleteKhassra.TabIndex = 31;
            this.btnDeleteKhassra.Text = "خذف کریں";
            this.btnDeleteKhassra.UseVisualStyleBackColor = true;
            this.btnDeleteKhassra.Click += new System.EventHandler(this.btnDeleteKhassra_Click);
            // 
            // btnSaveKhassra
            // 
            this.btnSaveKhassra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveKhassra.Location = new System.Drawing.Point(722, 15);
            this.btnSaveKhassra.Name = "btnSaveKhassra";
            this.btnSaveKhassra.Size = new System.Drawing.Size(89, 39);
            this.btnSaveKhassra.TabIndex = 30;
            this.btnSaveKhassra.Text = "محفوظ کریں";
            this.btnSaveKhassra.UseVisualStyleBackColor = true;
            this.btnSaveKhassra.Click += new System.EventHandler(this.btnSaveKhassra_Click);
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(1122, 19);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(66, 31);
            this.label57.TabIndex = 16;
            this.label57.Text = " نمبر خسرہ:";
            // 
            // txtKhassraNo
            // 
            this.txtKhassraNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraNo.Location = new System.Drawing.Point(834, 19);
            this.txtKhassraNo.Name = "txtKhassraNo";
            this.txtKhassraNo.Size = new System.Drawing.Size(282, 30);
            this.txtKhassraNo.TabIndex = 401;
            // 
            // tabNewAreaType
            // 
            this.tabNewAreaType.Controls.Add(this.groupBox2);
            this.tabNewAreaType.Controls.Add(this.panel1);
            this.tabNewAreaType.Location = new System.Drawing.Point(4, 40);
            this.tabNewAreaType.Name = "tabNewAreaType";
            this.tabNewAreaType.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewAreaType.Size = new System.Drawing.Size(1202, 409);
            this.tabNewAreaType.TabIndex = 1;
            this.tabNewAreaType.Text = "نئی قسم زمین خسرہ";
            this.tabNewAreaType.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgKhassraDetails);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1196, 331);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "موجودہ تفصیل قسم زمین و رقبہ خسرہ جات";
            // 
            // dgKhassraDetails
            // 
            this.dgKhassraDetails.AllowUserToAddRows = false;
            this.dgKhassraDetails.AllowUserToDeleteRows = false;
            this.dgKhassraDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhassraDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhassraDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.dgKhassraDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhassraDetails.Location = new System.Drawing.Point(3, 35);
            this.dgKhassraDetails.Name = "dgKhassraDetails";
            this.dgKhassraDetails.ReadOnly = true;
            this.dgKhassraDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKhassraDetails.Size = new System.Drawing.Size(1190, 293);
            this.dgKhassraDetails.TabIndex = 3;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "انتخاب کریں";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbKhassras);
            this.panel1.Controls.Add(this.txtKhassraDetailId);
            this.panel1.Controls.Add(this.btnNewKhassraArea);
            this.panel1.Controls.Add(this.btnDelKhassraArea);
            this.panel1.Controls.Add(this.btnSaveKhassraArea);
            this.panel1.Controls.Add(this.label54);
            this.panel1.Controls.Add(this.txtKhassraMarla);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.txtKhassraKanal);
            this.panel1.Controls.Add(this.txtKhassraSarsai);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Controls.Add(this.cboAreaType);
            this.panel1.Controls.Add(this.label46);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 72);
            this.panel1.TabIndex = 1;
            // 
            // cbKhassras
            // 
            this.cbKhassras.FormattingEnabled = true;
            this.cbKhassras.Location = new System.Drawing.Point(992, 16);
            this.cbKhassras.Name = "cbKhassras";
            this.cbKhassras.Size = new System.Drawing.Size(128, 39);
            this.cbKhassras.TabIndex = 408;
            this.cbKhassras.SelectionChangeCommitted += new System.EventHandler(this.cbKhassras_SelectionChangeCommitted);
            // 
            // txtKhassraDetailId
            // 
            this.txtKhassraDetailId.Location = new System.Drawing.Point(4, 17);
            this.txtKhassraDetailId.Name = "txtKhassraDetailId";
            this.txtKhassraDetailId.Size = new System.Drawing.Size(35, 39);
            this.txtKhassraDetailId.TabIndex = 407;
            this.txtKhassraDetailId.Text = "-1";
            this.txtKhassraDetailId.Visible = false;
            // 
            // btnNewKhassraArea
            // 
            this.btnNewKhassraArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewKhassraArea.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewKhassraArea.Location = new System.Drawing.Point(161, 16);
            this.btnNewKhassraArea.Name = "btnNewKhassraArea";
            this.btnNewKhassraArea.Size = new System.Drawing.Size(116, 39);
            this.btnNewKhassraArea.TabIndex = 310;
            this.btnNewKhassraArea.Text = "نئی قسم زمین خسرہ";
            this.btnNewKhassraArea.UseVisualStyleBackColor = true;
            this.btnNewKhassraArea.Click += new System.EventHandler(this.btnNewKhassraArea_Click);
            // 
            // btnDelKhassraArea
            // 
            this.btnDelKhassraArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelKhassraArea.Location = new System.Drawing.Point(65, 16);
            this.btnDelKhassraArea.Name = "btnDelKhassraArea";
            this.btnDelKhassraArea.Size = new System.Drawing.Size(83, 39);
            this.btnDelKhassraArea.TabIndex = 31;
            this.btnDelKhassraArea.Text = "خذف کریں";
            this.btnDelKhassraArea.UseVisualStyleBackColor = true;
            this.btnDelKhassraArea.Click += new System.EventHandler(this.btnDelKhassraArea_Click);
            // 
            // btnSaveKhassraArea
            // 
            this.btnSaveKhassraArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveKhassraArea.Location = new System.Drawing.Point(290, 16);
            this.btnSaveKhassraArea.Name = "btnSaveKhassraArea";
            this.btnSaveKhassraArea.Size = new System.Drawing.Size(83, 39);
            this.btnSaveKhassraArea.TabIndex = 30;
            this.btnSaveKhassraArea.Text = "محفوظ کریں";
            this.btnSaveKhassraArea.UseVisualStyleBackColor = true;
            this.btnSaveKhassraArea.Click += new System.EventHandler(this.btnSaveKhassraArea_Click);
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(565, 20);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(44, 31);
            this.label54.TabIndex = 20;
            this.label54.Text = "مرلہ:";
            // 
            // txtKhassraMarla
            // 
            this.txtKhassraMarla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraMarla.Enabled = false;
            this.txtKhassraMarla.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraMarla.Location = new System.Drawing.Point(524, 20);
            this.txtKhassraMarla.Name = "txtKhassraMarla";
            this.txtKhassraMarla.Size = new System.Drawing.Size(34, 30);
            this.txtKhassraMarla.TabIndex = 404;
            this.txtKhassraMarla.Text = "0";
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(719, 20);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(44, 31);
            this.label55.TabIndex = 19;
            this.label55.Text = "کنال:";
            // 
            // txtKhassraKanal
            // 
            this.txtKhassraKanal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraKanal.Enabled = false;
            this.txtKhassraKanal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraKanal.Location = new System.Drawing.Point(615, 20);
            this.txtKhassraKanal.Name = "txtKhassraKanal";
            this.txtKhassraKanal.Size = new System.Drawing.Size(98, 30);
            this.txtKhassraKanal.TabIndex = 403;
            this.txtKhassraKanal.Text = "0";
            // 
            // txtKhassraSarsai
            // 
            this.txtKhassraSarsai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhassraSarsai.Enabled = false;
            this.txtKhassraSarsai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhassraSarsai.Location = new System.Drawing.Point(385, 20);
            this.txtKhassraSarsai.Name = "txtKhassraSarsai";
            this.txtKhassraSarsai.Size = new System.Drawing.Size(71, 30);
            this.txtKhassraSarsai.TabIndex = 405;
            this.txtKhassraSarsai.Text = "0";
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(918, 20);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(68, 31);
            this.label56.TabIndex = 21;
            this.label56.Text = "قسم اراضی:";
            // 
            // cboAreaType
            // 
            this.cboAreaType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaType.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreaType.FormattingEnabled = true;
            this.cboAreaType.Location = new System.Drawing.Point(771, 16);
            this.cboAreaType.Name = "cboAreaType";
            this.cboAreaType.Size = new System.Drawing.Size(141, 39);
            this.cboAreaType.TabIndex = 402;
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(462, 20);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(54, 31);
            this.label46.TabIndex = 18;
            this.label46.Text = "سرسائی:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1122, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = " نمبر خسرہ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKhatooniNo);
            this.groupBox1.Controls.Add(this.txtKhataNo);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " کھاتہ و کھتونی نمبر";
            // 
            // txtKhatooniNo
            // 
            this.txtKhatooniNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniNo.Enabled = false;
            this.txtKhatooniNo.Location = new System.Drawing.Point(409, 22);
            this.txtKhatooniNo.Name = "txtKhatooniNo";
            this.txtKhatooniNo.Size = new System.Drawing.Size(253, 39);
            this.txtKhatooniNo.TabIndex = 58;
            // 
            // txtKhataNo
            // 
            this.txtKhataNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhataNo.Enabled = false;
            this.txtKhataNo.Location = new System.Drawing.Point(746, 21);
            this.txtKhataNo.Name = "txtKhataNo";
            this.txtKhataNo.Size = new System.Drawing.Size(253, 39);
            this.txtKhataNo.TabIndex = 57;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(668, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 38);
            this.label17.TabIndex = 56;
            this.label17.Text = "کھتونی نمبر";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1005, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 38);
            this.label9.TabIndex = 55;
            this.label9.Text = "کھاتہ نمبر";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmKhassraNewKhassraAreaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmKhassraNewKhassraAreaType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "نیا خسرہ و نئی قسم زمین خسرہ ";
            this.Load += new System.EventHandler(this.frmKhassraNewKhassraAreaType_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNewKhassra.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhatooniKhassras)).EndInit();
            this.panelKhassra.ResumeLayout(false);
            this.panelKhassra.PerformLayout();
            this.tabNewAreaType.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhassraDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNewKhassra;
        private System.Windows.Forms.TabPage tabNewAreaType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtKhatooniNo;
        private System.Windows.Forms.TextBox txtKhataNo;
        private System.Windows.Forms.Panel panelKhassra;
        private System.Windows.Forms.TextBox txtKhassraId;
        private System.Windows.Forms.Button btnNewKhassra;
        private System.Windows.Forms.Button btnDeleteKhassra;
        private System.Windows.Forms.Button btnSaveKhassra;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtKhassraNo;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.DataGridView dgKhatooniKhassras;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelKhassras;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtKhassraDetailId;
        private System.Windows.Forms.Button btnNewKhassraArea;
        private System.Windows.Forms.Button btnDelKhassraArea;
        private System.Windows.Forms.Button btnSaveKhassraArea;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtKhassraMarla;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox txtKhassraKanal;
        private System.Windows.Forms.TextBox txtKhassraSarsai;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cboAreaType;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKhassras;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgKhassraDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}