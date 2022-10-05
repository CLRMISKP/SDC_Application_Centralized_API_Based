namespace SDC_Application.AL
{
    partial class frmKhattaLocking
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
            this.grdPersonKatajats = new System.Windows.Forms.DataGridView();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalKhattajat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrevLockDetails = new System.Windows.Forms.TextBox();
            this.chbResetKhewatFareeqain = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.cbLockKhataShowToDE = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKhataNoSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKhewatKhataId = new System.Windows.Forms.TextBox();
            this.txtKhataNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLockKhata = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVisitorName = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPersonKatajats
            // 
            this.grdPersonKatajats.AllowUserToAddRows = false;
            this.grdPersonKatajats.AllowUserToDeleteRows = false;
            this.grdPersonKatajats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPersonKatajats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdPersonKatajats.ColumnHeadersHeight = 40;
            this.grdPersonKatajats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck});
            this.grdPersonKatajats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPersonKatajats.Location = new System.Drawing.Point(0, 233);
            this.grdPersonKatajats.Name = "grdPersonKatajats";
            this.grdPersonKatajats.ReadOnly = true;
            this.grdPersonKatajats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdPersonKatajats.RowHeadersVisible = false;
            this.grdPersonKatajats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPersonKatajats.Size = new System.Drawing.Size(1238, 223);
            this.grdPersonKatajats.TabIndex = 5;
            this.grdPersonKatajats.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPersonKatajats_CellClick);
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "انتخاب کریں";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.ReadOnly = true;
            this.ColCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1098, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // lblTotalKhattajat
            // 
            this.lblTotalKhattajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalKhattajat.Location = new System.Drawing.Point(1012, 11);
            this.lblTotalKhattajat.Name = "lblTotalKhattajat";
            this.lblTotalKhattajat.Size = new System.Drawing.Size(82, 21);
            this.lblTotalKhattajat.TabIndex = 1;
            this.lblTotalKhattajat.Text = ":";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.lblTotalKhattajat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1238, 198);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.txtPrevLockDetails);
            this.panel1.Controls.Add(this.chbResetKhewatFareeqain);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbUsers);
            this.panel1.Controls.Add(this.cbLockKhataShowToDE);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKhataNoSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtKhewatKhataId);
            this.panel1.Controls.Add(this.txtKhataNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbLockKhata);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtVisitorName);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.cmbMouza);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 233);
            this.panel1.TabIndex = 3;
            // 
            // txtPrevLockDetails
            // 
            this.txtPrevLockDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevLockDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrevLockDetails.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrevLockDetails.Location = new System.Drawing.Point(12, 48);
            this.txtPrevLockDetails.Multiline = true;
            this.txtPrevLockDetails.Name = "txtPrevLockDetails";
            this.txtPrevLockDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrevLockDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrevLockDetails.Size = new System.Drawing.Size(87, 47);
            this.txtPrevLockDetails.TabIndex = 56;
            this.txtPrevLockDetails.Visible = false;
            // 
            // chbResetKhewatFareeqain
            // 
            this.chbResetKhewatFareeqain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbResetKhewatFareeqain.AutoSize = true;
            this.chbResetKhewatFareeqain.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbResetKhewatFareeqain.Location = new System.Drawing.Point(52, 8);
            this.chbResetKhewatFareeqain.Name = "chbResetKhewatFareeqain";
            this.chbResetKhewatFareeqain.Size = new System.Drawing.Size(209, 34);
            this.chbResetKhewatFareeqain.TabIndex = 55;
            this.chbResetKhewatFareeqain.Text = "درستگی کیلئے تمام ملکان کا حصہ زیرو کر دیں";
            this.chbResetKhewatFareeqain.UseVisualStyleBackColor = true;
            this.chbResetKhewatFareeqain.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(463, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 30);
            this.label4.TabIndex = 54;
            this.label4.Text = "آپریٹر";
            this.label4.Visible = false;
            // 
            // cmbUsers
            // 
            this.cmbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUsers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(267, 10);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbUsers.Size = new System.Drawing.Size(190, 27);
            this.cmbUsers.TabIndex = 53;
            this.cmbUsers.Visible = false;
            // 
            // cbLockKhataShowToDE
            // 
            this.cbLockKhataShowToDE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLockKhataShowToDE.AutoSize = true;
            this.cbLockKhataShowToDE.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLockKhataShowToDE.Location = new System.Drawing.Point(522, 7);
            this.cbLockKhataShowToDE.Name = "cbLockKhataShowToDE";
            this.cbLockKhataShowToDE.Size = new System.Drawing.Size(114, 34);
            this.cbLockKhataShowToDE.TabIndex = 52;
            this.cbLockKhataShowToDE.Text = "فعال برائے درستگی";
            this.cbLockKhataShowToDE.UseVisualStyleBackColor = true;
            this.cbLockKhataShowToDE.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearch.Location = new System.Drawing.Point(969, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtKhataNoSearch
            // 
            this.txtKhataNoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhataNoSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhataNoSearch.Location = new System.Drawing.Point(1017, 64);
            this.txtKhataNoSearch.Name = "txtKhataNoSearch";
            this.txtKhataNoSearch.Size = new System.Drawing.Size(142, 29);
            this.txtKhataNoSearch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1165, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 30);
            this.label3.TabIndex = 49;
            this.label3.Text = "کھاتہ نمبر";
            // 
            // txtKhewatKhataId
            // 
            this.txtKhewatKhataId.Location = new System.Drawing.Point(15, 9);
            this.txtKhewatKhataId.Name = "txtKhewatKhataId";
            this.txtKhewatKhataId.Size = new System.Drawing.Size(71, 33);
            this.txtKhewatKhataId.TabIndex = 48;
            this.txtKhewatKhataId.Text = "-1";
            this.txtKhewatKhataId.Visible = false;
            // 
            // txtKhataNo
            // 
            this.txtKhataNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhataNo.Enabled = false;
            this.txtKhataNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhataNo.Location = new System.Drawing.Point(755, 9);
            this.txtKhataNo.Name = "txtKhataNo";
            this.txtKhataNo.Size = new System.Drawing.Size(119, 29);
            this.txtKhataNo.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(880, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 46;
            this.label2.Text = "کھاتہ نمبر";
            // 
            // cbLockKhata
            // 
            this.cbLockKhata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLockKhata.AutoSize = true;
            this.cbLockKhata.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLockKhata.Location = new System.Drawing.Point(667, 7);
            this.cbLockKhata.Name = "cbLockKhata";
            this.cbLockKhata.Size = new System.Drawing.Size(82, 34);
            this.cbLockKhata.TabIndex = 45;
            this.cbLockKhata.Text = "کھاتہ لاک ";
            this.cbLockKhata.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(405, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 53);
            this.btnSave.TabIndex = 44;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVisitorName
            // 
            this.txtVisitorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVisitorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVisitorName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitorName.Location = new System.Drawing.Point(15, 113);
            this.txtVisitorName.Multiline = true;
            this.txtVisitorName.Name = "txtVisitorName";
            this.txtVisitorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVisitorName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVisitorName.Size = new System.Drawing.Size(1144, 114);
            this.txtVisitorName.TabIndex = 42;
            this.txtVisitorName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(1167, 139);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(68, 30);
            this.lbl2.TabIndex = 43;
            this.lbl2.Text = "لاک تفصیل";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1165, 9);
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
            this.cmbMouza.DropDownHeight = 550;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(969, 8);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 0;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // frmKhattaLocking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1238, 456);
            this.Controls.Add(this.grdPersonKatajats);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmKhattaLocking";
            this.Text = "مالک / تفصیل ملکیت";
            this.Load += new System.EventHandler(this.frmKhattaSearchByPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPersonKatajats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalKhattajat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        public System.Windows.Forms.TextBox txtVisitorName;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbLockKhata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKhataNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.TextBox txtKhewatKhataId;
        private System.Windows.Forms.TextBox txtKhataNoSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbLockKhataShowToDE;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.CheckBox chbResetKhewatFareeqain;
        public System.Windows.Forms.TextBox txtPrevLockDetails;
    }
}