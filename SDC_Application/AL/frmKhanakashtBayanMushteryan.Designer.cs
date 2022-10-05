namespace SDC_Application.AL
{
    partial class frmKhanakashtBayanMushteryan
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
            this.tabSavedBayan = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgBayanKhataKhatooni = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgPerson = new System.Windows.Forms.DataGridView();
            this.ColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.txtBayaName = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tabBayanByName = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.btnSearchUnsaveBaya = new System.Windows.Forms.Button();
            this.txtBayaNameUnsave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgUnsavBayanKhataKhatooni = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabSavedBayan.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBayanKhataKhatooni)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabBayanByName.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnsavBayanKhataKhatooni)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSavedBayan);
            this.tabControl1.Controls.Add(this.tabBayanByName);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 413);
            this.tabControl1.TabIndex = 2;
            // 
            // tabSavedBayan
            // 
            this.tabSavedBayan.Controls.Add(this.panel4);
            this.tabSavedBayan.Controls.Add(this.panel3);
            this.tabSavedBayan.Controls.Add(this.panel1);
            this.tabSavedBayan.Location = new System.Drawing.Point(4, 34);
            this.tabSavedBayan.Name = "tabSavedBayan";
            this.tabSavedBayan.Padding = new System.Windows.Forms.Padding(3);
            this.tabSavedBayan.Size = new System.Drawing.Size(922, 375);
            this.tabSavedBayan.TabIndex = 0;
            this.tabSavedBayan.Text = "تلاش محفوظ شدہ بائعان ";
            this.tabSavedBayan.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgBayanKhataKhatooni);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 53);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(559, 319);
            this.panel4.TabIndex = 2;
            // 
            // dgBayanKhataKhatooni
            // 
            this.dgBayanKhataKhatooni.AllowUserToAddRows = false;
            this.dgBayanKhataKhatooni.AllowUserToDeleteRows = false;
            this.dgBayanKhataKhatooni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBayanKhataKhatooni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBayanKhataKhatooni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBayanKhataKhatooni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBayanKhataKhatooni.Location = new System.Drawing.Point(5, 5);
            this.dgBayanKhataKhatooni.Name = "dgBayanKhataKhatooni";
            this.dgBayanKhataKhatooni.RowHeadersVisible = false;
            this.dgBayanKhataKhatooni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBayanKhataKhatooni.Size = new System.Drawing.Size(547, 268);
            this.dgBayanKhataKhatooni.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(5, 273);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(547, 39);
            this.panel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgPerson);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(562, 53);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(357, 319);
            this.panel3.TabIndex = 1;
            // 
            // dgPerson
            // 
            this.dgPerson.AllowUserToAddRows = false;
            this.dgPerson.AllowUserToDeleteRows = false;
            this.dgPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPerson.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSel});
            this.dgPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPerson.Location = new System.Drawing.Point(5, 5);
            this.dgPerson.Name = "dgPerson";
            this.dgPerson.RowHeadersVisible = false;
            this.dgPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPerson.Size = new System.Drawing.Size(345, 307);
            this.dgPerson.TabIndex = 0;
            this.dgPerson.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPerson_CellClick);
            // 
            // ColSel
            // 
            this.ColSel.HeaderText = "انتخاب کریں";
            this.ColSel.Name = "ColSel";
            this.ColSel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColSel.Width = 85;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPopulate);
            this.panel1.Controls.Add(this.txtBayaName);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopulate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPopulate.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnPopulate.Location = new System.Drawing.Point(602, 6);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(41, 35);
            this.btnPopulate.TabIndex = 47;
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // txtBayaName
            // 
            this.txtBayaName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBayaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBayaName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayaName.Location = new System.Drawing.Point(664, 9);
            this.txtBayaName.Multiline = true;
            this.txtBayaName.Name = "txtBayaName";
            this.txtBayaName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBayaName.Size = new System.Drawing.Size(160, 31);
            this.txtBayaName.TabIndex = 45;
            this.txtBayaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVisitorName_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(830, 6);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(55, 30);
            this.lbl2.TabIndex = 46;
            this.lbl2.Text = "نام بائعہ:";
            // 
            // tabBayanByName
            // 
            this.tabBayanByName.Controls.Add(this.panel7);
            this.tabBayanByName.Controls.Add(this.panel2);
            this.tabBayanByName.Location = new System.Drawing.Point(4, 34);
            this.tabBayanByName.Name = "tabBayanByName";
            this.tabBayanByName.Padding = new System.Windows.Forms.Padding(3);
            this.tabBayanByName.Size = new System.Drawing.Size(922, 375);
            this.tabBayanByName.TabIndex = 1;
            this.tabBayanByName.Text = "تفصیل غیر محفوظ شدہ بائعان ";
            this.tabBayanByName.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgUnsavBayanKhataKhatooni);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 54);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(10);
            this.panel7.Size = new System.Drawing.Size(916, 318);
            this.panel7.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSearchUnsaveBaya);
            this.panel2.Controls.Add(this.txtBayaNameUnsave);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 51);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lbl1);
            this.panel6.Controls.Add(this.cmbMouza);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(930, 50);
            this.panel6.TabIndex = 2;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(808, 10);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(38, 25);
            this.lbl1.TabIndex = 54;
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
            this.cmbMouza.Location = new System.Drawing.Point(650, 11);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(152, 27);
            this.cmbMouza.TabIndex = 53;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVisitorName_KeyPress);
            // 
            // btnSearchUnsaveBaya
            // 
            this.btnSearchUnsaveBaya.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUnsaveBaya.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchUnsaveBaya.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearchUnsaveBaya.Location = new System.Drawing.Point(618, 6);
            this.btnSearchUnsaveBaya.Name = "btnSearchUnsaveBaya";
            this.btnSearchUnsaveBaya.Size = new System.Drawing.Size(41, 35);
            this.btnSearchUnsaveBaya.TabIndex = 50;
            this.btnSearchUnsaveBaya.UseVisualStyleBackColor = true;
            this.btnSearchUnsaveBaya.Click += new System.EventHandler(this.btnSearchUnsaveBaya_Click);
            // 
            // txtBayaNameUnsave
            // 
            this.txtBayaNameUnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBayaNameUnsave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBayaNameUnsave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayaNameUnsave.Location = new System.Drawing.Point(680, 9);
            this.txtBayaNameUnsave.Multiline = true;
            this.txtBayaNameUnsave.Name = "txtBayaNameUnsave";
            this.txtBayaNameUnsave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBayaNameUnsave.Size = new System.Drawing.Size(160, 31);
            this.txtBayaNameUnsave.TabIndex = 48;
            this.txtBayaNameUnsave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVisitorName_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(846, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 30);
            this.label1.TabIndex = 49;
            this.label1.Text = "نام بائعہ:";
            // 
            // dgUnsavBayanKhataKhatooni
            // 
            this.dgUnsavBayanKhataKhatooni.AllowUserToAddRows = false;
            this.dgUnsavBayanKhataKhatooni.AllowUserToDeleteRows = false;
            this.dgUnsavBayanKhataKhatooni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgUnsavBayanKhataKhatooni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgUnsavBayanKhataKhatooni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUnsavBayanKhataKhatooni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUnsavBayanKhataKhatooni.Location = new System.Drawing.Point(10, 10);
            this.dgUnsavBayanKhataKhatooni.Name = "dgUnsavBayanKhataKhatooni";
            this.dgUnsavBayanKhataKhatooni.RowHeadersVisible = false;
            this.dgUnsavBayanKhataKhatooni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUnsavBayanKhataKhatooni.Size = new System.Drawing.Size(894, 296);
            this.dgUnsavBayanKhataKhatooni.TabIndex = 2;
            // 
            // frmKhanakashtBayanMushteryan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 463);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel6);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmKhanakashtBayanMushteryan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "کھتونی بائعان/مشتریان";
            this.Load += new System.EventHandler(this.frmKhanakashtBayanMushteryan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSavedBayan.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBayanKhataKhatooni)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabBayanByName.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnsavBayanKhataKhatooni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSavedBayan;
        private System.Windows.Forms.TabPage tabBayanByName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.Button btnPopulate;
        public System.Windows.Forms.TextBox txtBayaName;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DataGridView dgPerson;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSel;
        private System.Windows.Forms.DataGridView dgBayanKhataKhatooni;
        private System.Windows.Forms.Button btnSearchUnsaveBaya;
        public System.Windows.Forms.TextBox txtBayaNameUnsave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgUnsavBayanKhataKhatooni;
    }
}