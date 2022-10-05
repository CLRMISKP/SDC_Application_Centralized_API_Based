namespace SDC_Application.AL
{
    partial class frmKhattaSearchByPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalKhattajat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalRaqba = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbKhatooni = new System.Windows.Forms.RadioButton();
            this.rbKhassra = new System.Windows.Forms.RadioButton();
            this.rbKhatta = new System.Windows.Forms.RadioButton();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.txtVisitorName = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdPersonKatajats = new System.Windows.Forms.DataGridView();
            this.dgKhewatFreeqDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhewatFreeqDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(844, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // lblTotalKhattajat
            // 
            this.lblTotalKhattajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalKhattajat.Location = new System.Drawing.Point(758, 11);
            this.lblTotalKhattajat.Name = "lblTotalKhattajat";
            this.lblTotalKhattajat.Size = new System.Drawing.Size(82, 21);
            this.lblTotalKhattajat.TabIndex = 1;
            this.lblTotalKhattajat.Text = ":";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.txtTotalRaqba);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.lblTotalKhattajat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 43);
            this.panel2.TabIndex = 4;
            // 
            // txtTotalRaqba
            // 
            this.txtTotalRaqba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRaqba.Enabled = false;
            this.txtTotalRaqba.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRaqba.Location = new System.Drawing.Point(7, 8);
            this.txtTotalRaqba.Name = "txtTotalRaqba";
            this.txtTotalRaqba.Size = new System.Drawing.Size(147, 26);
            this.txtTotalRaqba.TabIndex = 26;
            this.txtTotalRaqba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(160, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 25);
            this.label23.TabIndex = 25;
            this.label23.Text = "کل رقبہ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.txtFatherName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbKhatooni);
            this.panel1.Controls.Add(this.rbKhassra);
            this.panel1.Controls.Add(this.rbKhatta);
            this.panel1.Controls.Add(this.btnPopulate);
            this.panel1.Controls.Add(this.txtVisitorName);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.cmbMouza);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 52);
            this.panel1.TabIndex = 3;
            // 
            // txtFatherName
            // 
            this.txtFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(360, 10);
            this.txtFatherName.Multiline = true;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFatherName.Size = new System.Drawing.Size(160, 31);
            this.txtFatherName.TabIndex = 43;
            this.txtFatherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatherName_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(529, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 30);
            this.label2.TabIndex = 49;
            this.label2.Text = ":والد";
            // 
            // rbKhatooni
            // 
            this.rbKhatooni.AutoSize = true;
            this.rbKhatooni.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKhatooni.Location = new System.Drawing.Point(145, 10);
            this.rbKhatooni.Name = "rbKhatooni";
            this.rbKhatooni.Size = new System.Drawing.Size(55, 29);
            this.rbKhatooni.TabIndex = 47;
            this.rbKhatooni.TabStop = true;
            this.rbKhatooni.Text = "کھتونی";
            this.rbKhatooni.UseVisualStyleBackColor = true;
            // 
            // rbKhassra
            // 
            this.rbKhassra.AutoSize = true;
            this.rbKhassra.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKhassra.Location = new System.Drawing.Point(206, 10);
            this.rbKhassra.Name = "rbKhassra";
            this.rbKhassra.Size = new System.Drawing.Size(73, 29);
            this.rbKhassra.TabIndex = 46;
            this.rbKhassra.TabStop = true;
            this.rbKhassra.Text = "خسرہ جات";
            this.rbKhassra.UseVisualStyleBackColor = true;
            // 
            // rbKhatta
            // 
            this.rbKhatta.AutoSize = true;
            this.rbKhatta.Checked = true;
            this.rbKhatta.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKhatta.Location = new System.Drawing.Point(285, 10);
            this.rbKhatta.Name = "rbKhatta";
            this.rbKhatta.Size = new System.Drawing.Size(71, 29);
            this.rbKhatta.TabIndex = 45;
            this.rbKhatta.TabStop = true;
            this.rbKhatta.Text = "کھاتہ جات";
            this.rbKhatta.UseVisualStyleBackColor = true;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopulate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPopulate.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnPopulate.Location = new System.Drawing.Point(74, 7);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(40, 35);
            this.btnPopulate.TabIndex = 44;
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // txtVisitorName
            // 
            this.txtVisitorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVisitorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVisitorName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitorName.Location = new System.Drawing.Point(584, 10);
            this.txtVisitorName.Multiline = true;
            this.txtVisitorName.Name = "txtVisitorName";
            this.txtVisitorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVisitorName.Size = new System.Drawing.Size(160, 31);
            this.txtVisitorName.TabIndex = 42;
            this.txtVisitorName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(750, 10);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(60, 30);
            this.lbl2.TabIndex = 43;
            this.lbl2.Text = ":نام مالک";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1023, 10);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(48, 30);
            this.lbl1.TabIndex = 41;
            this.lbl1.Text = ":موضع";
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.DropDownHeight = 500;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(826, 12);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 40;
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPersons);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1084, 361);
            this.splitContainer1.SplitterDistance = 786;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grdPersonKatajats);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgKhewatFreeqDetails);
            this.splitContainer2.Size = new System.Drawing.Size(784, 359);
            this.splitContainer2.SplitterDistance = 209;
            this.splitContainer2.TabIndex = 6;
            // 
            // grdPersonKatajats
            // 
            this.grdPersonKatajats.AllowUserToAddRows = false;
            this.grdPersonKatajats.AllowUserToDeleteRows = false;
            this.grdPersonKatajats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPersonKatajats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdPersonKatajats.ColumnHeadersHeight = 40;
            this.grdPersonKatajats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPersonKatajats.Location = new System.Drawing.Point(0, 0);
            this.grdPersonKatajats.Name = "grdPersonKatajats";
            this.grdPersonKatajats.ReadOnly = true;
            this.grdPersonKatajats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdPersonKatajats.RowHeadersVisible = false;
            this.grdPersonKatajats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPersonKatajats.Size = new System.Drawing.Size(784, 209);
            this.grdPersonKatajats.TabIndex = 6;
            this.grdPersonKatajats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPersonKatajats_CellContentClick);
            this.grdPersonKatajats.DoubleClick += new System.EventHandler(this.grdPersonKatajats_DoubleClick);
            // 
            // dgKhewatFreeqDetails
            // 
            this.dgKhewatFreeqDetails.AllowUserToAddRows = false;
            this.dgKhewatFreeqDetails.AllowUserToDeleteRows = false;
            this.dgKhewatFreeqDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhewatFreeqDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhewatFreeqDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhewatFreeqDetails.Location = new System.Drawing.Point(0, 0);
            this.dgKhewatFreeqDetails.Name = "dgKhewatFreeqDetails";
            this.dgKhewatFreeqDetails.ReadOnly = true;
            this.dgKhewatFreeqDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgKhewatFreeqDetails.RowHeadersVisible = false;
            this.dgKhewatFreeqDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKhewatFreeqDetails.Size = new System.Drawing.Size(784, 146);
            this.dgKhewatFreeqDetails.TabIndex = 3;
            this.dgKhewatFreeqDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKhewatFreeqDetails_CellContentClick);
            // 
            // dataGridViewPersons
            // 
            this.dataGridViewPersons.AllowUserToAddRows = false;
            this.dataGridViewPersons.AllowUserToDeleteRows = false;
            this.dataGridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPersons.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPersons.ColumnHeadersHeight = 40;
            this.dataGridViewPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk});
            this.dataGridViewPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPersons.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPersons.Name = "dataGridViewPersons";
            this.dataGridViewPersons.ReadOnly = true;
            this.dataGridViewPersons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewPersons.RowHeadersVisible = false;
            this.dataGridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPersons.Size = new System.Drawing.Size(288, 359);
            this.dataGridViewPersons.TabIndex = 6;
            this.dataGridViewPersons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPersons_CellClick);
            this.dataGridViewPersons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPersons_CellContentClick);
            // 
            // colChk
            // 
            this.colChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colChk.HeaderText = "انتخاب کریں";
            this.colChk.Name = "colChk";
            this.colChk.ReadOnly = true;
            this.colChk.Width = 80;
            // 
            // frmKhattaSearchByPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmKhattaSearchByPerson";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مالک / تفصیل ملکیت";
            this.Load += new System.EventHandler(this.frmKhattaSearchByPerson_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhewatFreeqDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalKhattajat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        public System.Windows.Forms.TextBox txtVisitorName;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewPersons;
        private System.Windows.Forms.RadioButton rbKhatooni;
        private System.Windows.Forms.RadioButton rbKhassra;
        private System.Windows.Forms.RadioButton rbKhatta;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView grdPersonKatajats;
        private System.Windows.Forms.DataGridView dgKhewatFreeqDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        public System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRaqba;
        private System.Windows.Forms.Label label23;
    }
}