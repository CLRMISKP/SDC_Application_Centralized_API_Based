namespace SDC_Application.AL
{
    partial class frmUserLogs
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAfradRegister = new System.Windows.Forms.TabPage();
            this.tabKhewatFareeqain = new System.Windows.Forms.TabPage();
            this.tabIntiqal = new System.Windows.Forms.TabPage();
            this.tabMisal = new System.Windows.Forms.TabPage();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersonaName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridViewPersons = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.lblInsertDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInsertLoginName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUpdateLoginName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblKFGupdateLoginName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblKFGupdatedate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblKFGinserloginName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblKFGinsertDate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblKhewatFareqName = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgKhataMalkan = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbKhataNo = new System.Windows.Forms.ComboBox();
            this.btnLoadKhata = new System.Windows.Forms.Button();
            this.ColSelKFG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAfradRegister.SuspendLayout();
            this.tabKhewatFareeqain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhataMalkan)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grp.Name = "grp";
            this.grp.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grp.Size = new System.Drawing.Size(1227, 66);
            this.grp.TabIndex = 1;
            this.grp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "تفصیل اندراجات، آپریٹر";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAfradRegister);
            this.tabControl1.Controls.Add(this.tabKhewatFareeqain);
            this.tabControl1.Controls.Add(this.tabIntiqal);
            this.tabControl1.Controls.Add(this.tabMisal);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1227, 376);
            this.tabControl1.TabIndex = 2;
            // 
            // tabAfradRegister
            // 
            this.tabAfradRegister.Controls.Add(this.groupBox3);
            this.tabAfradRegister.Controls.Add(this.groupBox1);
            this.tabAfradRegister.Location = new System.Drawing.Point(4, 34);
            this.tabAfradRegister.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabAfradRegister.Name = "tabAfradRegister";
            this.tabAfradRegister.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabAfradRegister.Size = new System.Drawing.Size(1219, 338);
            this.tabAfradRegister.TabIndex = 0;
            this.tabAfradRegister.Text = "تفصیل افراد";
            this.tabAfradRegister.UseVisualStyleBackColor = true;
            // 
            // tabKhewatFareeqain
            // 
            this.tabKhewatFareeqain.Controls.Add(this.groupBox4);
            this.tabKhewatFareeqain.Controls.Add(this.groupBox5);
            this.tabKhewatFareeqain.Location = new System.Drawing.Point(4, 34);
            this.tabKhewatFareeqain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabKhewatFareeqain.Name = "tabKhewatFareeqain";
            this.tabKhewatFareeqain.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabKhewatFareeqain.Size = new System.Drawing.Size(1219, 338);
            this.tabKhewatFareeqain.TabIndex = 1;
            this.tabKhewatFareeqain.Text = "تفصیل ملکان";
            this.tabKhewatFareeqain.UseVisualStyleBackColor = true;
            // 
            // tabIntiqal
            // 
            this.tabIntiqal.Location = new System.Drawing.Point(4, 34);
            this.tabIntiqal.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabIntiqal.Name = "tabIntiqal";
            this.tabIntiqal.Size = new System.Drawing.Size(1219, 338);
            this.tabIntiqal.TabIndex = 2;
            this.tabIntiqal.Text = "تفصیل انتقلات";
            this.tabIntiqal.UseVisualStyleBackColor = true;
            // 
            // tabMisal
            // 
            this.tabMisal.Location = new System.Drawing.Point(4, 34);
            this.tabMisal.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabMisal.Name = "tabMisal";
            this.tabMisal.Size = new System.Drawing.Size(1219, 338);
            this.tabMisal.TabIndex = 3;
            this.tabMisal.Text = "تفصیل درستگی / مثل";
            this.tabMisal.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(645, 10);
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
            this.cmbMouza.Location = new System.Drawing.Point(445, 11);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(194, 27);
            this.cmbMouza.TabIndex = 51;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.cmbMouza);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 47);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1227, 376);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(683, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تلاش آفراد";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnFind.Location = new System.Drawing.Point(73, 9);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(50, 37);
            this.btnFind.TabIndex = 5;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "فرد کا نام";
            // 
            // txtPersonaName
            // 
            this.txtPersonaName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonaName.Location = new System.Drawing.Point(129, 9);
            this.txtPersonaName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtPersonaName.Name = "txtPersonaName";
            this.txtPersonaName.Size = new System.Drawing.Size(261, 37);
            this.txtPersonaName.TabIndex = 3;
            this.txtPersonaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonaName_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridViewPersons);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Size = new System.Drawing.Size(527, 242);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // GridViewPersons
            // 
            this.GridViewPersons.AllowUserToAddRows = false;
            this.GridViewPersons.AllowUserToDeleteRows = false;
            this.GridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewPersons.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.GridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSel});
            this.GridViewPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewPersons.Location = new System.Drawing.Point(3, 32);
            this.GridViewPersons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GridViewPersons.MultiSelect = false;
            this.GridViewPersons.Name = "GridViewPersons";
            this.GridViewPersons.ReadOnly = true;
            this.GridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPersons.Size = new System.Drawing.Size(521, 204);
            this.GridViewPersons.TabIndex = 0;
            this.GridViewPersons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewPersons_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFind);
            this.panel3.Controls.Add(this.txtPersonaName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(527, 52);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(527, 242);
            this.panel4.TabIndex = 8;
            // 
            // ColSel
            // 
            this.ColSel.HeaderText = "انتخاب کریں";
            this.ColSel.Name = "ColSel";
            this.ColSel.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblUpdateLoginName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblUpdateDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblInsertLoginName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblInsertDate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblPersonName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(25, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(658, 326);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تفصیل اندراج فرد";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(504, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "نام فرد:";
            // 
            // lblPersonName
            // 
            this.lblPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.Location = new System.Drawing.Point(270, 67);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(23, 33);
            this.lblPersonName.TabIndex = 1;
            this.lblPersonName.Text = "۔";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInsertDate
            // 
            this.lblInsertDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsertDate.AutoSize = true;
            this.lblInsertDate.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertDate.Location = new System.Drawing.Point(270, 119);
            this.lblInsertDate.Name = "lblInsertDate";
            this.lblInsertDate.Size = new System.Drawing.Size(23, 33);
            this.lblInsertDate.TabIndex = 3;
            this.lblInsertDate.Text = "۔";
            this.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(504, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 33);
            this.label5.TabIndex = 2;
            this.label5.Text = "تاریخ و وقت اندراج:";
            // 
            // lblInsertLoginName
            // 
            this.lblInsertLoginName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsertLoginName.AutoSize = true;
            this.lblInsertLoginName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertLoginName.Location = new System.Drawing.Point(270, 164);
            this.lblInsertLoginName.Name = "lblInsertLoginName";
            this.lblInsertLoginName.Size = new System.Drawing.Size(23, 33);
            this.lblInsertLoginName.TabIndex = 5;
            this.lblInsertLoginName.Text = "۔";
            this.lblInsertLoginName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(504, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 33);
            this.label7.TabIndex = 4;
            this.label7.Text = "  آپریٹر اندراج:";
            // 
            // lblUpdateLoginName
            // 
            this.lblUpdateLoginName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdateLoginName.AutoSize = true;
            this.lblUpdateLoginName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateLoginName.Location = new System.Drawing.Point(273, 253);
            this.lblUpdateLoginName.Name = "lblUpdateLoginName";
            this.lblUpdateLoginName.Size = new System.Drawing.Size(23, 33);
            this.lblUpdateLoginName.TabIndex = 11;
            this.lblUpdateLoginName.Text = "۔";
            this.lblUpdateLoginName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(507, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "  آپریٹر تبدیلی:";
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDate.Location = new System.Drawing.Point(273, 208);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(23, 33);
            this.lblUpdateDate.TabIndex = 9;
            this.lblUpdateDate.Text = "۔";
            this.lblUpdateDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(507, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 33);
            this.label9.TabIndex = 8;
            this.label9.Text = "تاریخ و وقت تبدیلی:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblKFGupdateLoginName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblKFGupdatedate);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lblKFGinserloginName);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblKFGinsertDate);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.lblKhewatFareqName);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(25, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(658, 326);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تفصیل اندراج فرد";
            // 
            // lblKFGupdateLoginName
            // 
            this.lblKFGupdateLoginName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKFGupdateLoginName.AutoSize = true;
            this.lblKFGupdateLoginName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKFGupdateLoginName.Location = new System.Drawing.Point(273, 253);
            this.lblKFGupdateLoginName.Name = "lblKFGupdateLoginName";
            this.lblKFGupdateLoginName.Size = new System.Drawing.Size(23, 33);
            this.lblKFGupdateLoginName.TabIndex = 11;
            this.lblKFGupdateLoginName.Text = "۔";
            this.lblKFGupdateLoginName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(507, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "  آپریٹر تبدیلی:";
            // 
            // lblKFGupdatedate
            // 
            this.lblKFGupdatedate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKFGupdatedate.AutoSize = true;
            this.lblKFGupdatedate.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKFGupdatedate.Location = new System.Drawing.Point(273, 208);
            this.lblKFGupdatedate.Name = "lblKFGupdatedate";
            this.lblKFGupdatedate.Size = new System.Drawing.Size(23, 33);
            this.lblKFGupdatedate.TabIndex = 9;
            this.lblKFGupdatedate.Text = "۔";
            this.lblKFGupdatedate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(507, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 33);
            this.label11.TabIndex = 8;
            this.label11.Text = "تاریخ و وقت تبدیلی:";
            // 
            // lblKFGinserloginName
            // 
            this.lblKFGinserloginName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKFGinserloginName.AutoSize = true;
            this.lblKFGinserloginName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKFGinserloginName.Location = new System.Drawing.Point(270, 164);
            this.lblKFGinserloginName.Name = "lblKFGinserloginName";
            this.lblKFGinserloginName.Size = new System.Drawing.Size(23, 33);
            this.lblKFGinserloginName.TabIndex = 5;
            this.lblKFGinserloginName.Text = "۔";
            this.lblKFGinserloginName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(504, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 33);
            this.label13.TabIndex = 4;
            this.label13.Text = "  آپریٹر اندراج:";
            // 
            // lblKFGinsertDate
            // 
            this.lblKFGinsertDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKFGinsertDate.AutoSize = true;
            this.lblKFGinsertDate.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKFGinsertDate.Location = new System.Drawing.Point(270, 119);
            this.lblKFGinsertDate.Name = "lblKFGinsertDate";
            this.lblKFGinsertDate.Size = new System.Drawing.Size(23, 33);
            this.lblKFGinsertDate.TabIndex = 3;
            this.lblKFGinsertDate.Text = "۔";
            this.lblKFGinsertDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(504, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 33);
            this.label15.TabIndex = 2;
            this.label15.Text = "تاریخ و وقت اندراج:";
            // 
            // lblKhewatFareqName
            // 
            this.lblKhewatFareqName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhewatFareqName.AutoSize = true;
            this.lblKhewatFareqName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhewatFareqName.Location = new System.Drawing.Point(270, 67);
            this.lblKhewatFareqName.Name = "lblKhewatFareqName";
            this.lblKhewatFareqName.Size = new System.Drawing.Size(23, 33);
            this.lblKhewatFareqName.TabIndex = 1;
            this.lblKhewatFareqName.Text = "۔";
            this.lblKhewatFareqName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(504, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 33);
            this.label17.TabIndex = 0;
            this.label17.Text = "نام مالک:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Controls.Add(this.panel6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(683, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(533, 326);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "انتخاب کھاتہ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(527, 242);
            this.panel5.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgKhataMalkan);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox6.Size = new System.Drawing.Size(527, 242);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            // 
            // dgKhataMalkan
            // 
            this.dgKhataMalkan.AllowUserToAddRows = false;
            this.dgKhataMalkan.AllowUserToDeleteRows = false;
            this.dgKhataMalkan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhataMalkan.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgKhataMalkan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhataMalkan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelKFG});
            this.dgKhataMalkan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhataMalkan.Location = new System.Drawing.Point(3, 32);
            this.dgKhataMalkan.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgKhataMalkan.MultiSelect = false;
            this.dgKhataMalkan.Name = "dgKhataMalkan";
            this.dgKhataMalkan.ReadOnly = true;
            this.dgKhataMalkan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKhataMalkan.Size = new System.Drawing.Size(521, 204);
            this.dgKhataMalkan.TabIndex = 0;
            this.dgKhataMalkan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKhataMalkan_CellClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLoadKhata);
            this.panel6.Controls.Add(this.cmbKhataNo);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 29);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(527, 52);
            this.panel6.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(315, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 30);
            this.label18.TabIndex = 4;
            this.label18.Text = "کھاتہ نمبر:";
            // 
            // cmbKhataNo
            // 
            this.cmbKhataNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhataNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKhataNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKhataNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbKhataNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhataNo.FormattingEnabled = true;
            this.cmbKhataNo.Location = new System.Drawing.Point(115, 16);
            this.cmbKhataNo.Name = "cmbKhataNo";
            this.cmbKhataNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbKhataNo.Size = new System.Drawing.Size(194, 27);
            this.cmbKhataNo.TabIndex = 52;
            this.cmbKhataNo.SelectionChangeCommitted += new System.EventHandler(this.cmbKhataNo_SelectionChangeCommitted);
            // 
            // btnLoadKhata
            // 
            this.btnLoadKhata.Location = new System.Drawing.Point(400, 8);
            this.btnLoadKhata.Name = "btnLoadKhata";
            this.btnLoadKhata.Size = new System.Drawing.Size(99, 36);
            this.btnLoadKhata.TabIndex = 53;
            this.btnLoadKhata.Text = "کھاتہ جات لوڈ کریں";
            this.btnLoadKhata.UseVisualStyleBackColor = true;
            this.btnLoadKhata.Click += new System.EventHandler(this.btnLoadKhata_Click);
            // 
            // ColSelKFG
            // 
            this.ColSelKFG.HeaderText = "انتخاب کریں";
            this.ColSelKFG.Name = "ColSelKFG";
            this.ColSelKFG.ReadOnly = true;
            // 
            // frmUserLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 489);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmUserLogs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تصیل اندراجات آپریٹر";
            this.Load += new System.EventHandler(this.frmUserLogs_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAfradRegister.ResumeLayout(false);
            this.tabKhewatFareeqain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhataMalkan)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAfradRegister;
        private System.Windows.Forms.TabPage tabKhewatFareeqain;
        private System.Windows.Forms.TabPage tabIntiqal;
        private System.Windows.Forms.TabPage tabMisal;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPersonaName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridViewPersons;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInsertLoginName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInsertDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUpdateLoginName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblKFGupdateLoginName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblKFGupdatedate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblKFGinserloginName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblKFGinsertDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblKhewatFareqName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgKhataMalkan;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbKhataNo;
        private System.Windows.Forms.Button btnLoadKhata;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelKFG;
    }
}