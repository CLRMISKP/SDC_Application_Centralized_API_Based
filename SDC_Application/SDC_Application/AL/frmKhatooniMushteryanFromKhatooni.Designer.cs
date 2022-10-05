namespace SDC_Application
{
    partial class frmKhatooniMushteryanFromKhatooni
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboKhatoonies = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbokhataNo = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAmaldaramad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridviewNewKhatooniMushteryan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridviewOldKhatooniMushteryan = new System.Windows.Forms.DataGridView();
            this.btnDelMushteri = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewNewKhatooniMushteryan)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewOldKhatooniMushteryan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboKhatoonies);
            this.panel1.Controls.Add(this.label89);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbokhataNo);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 48);
            this.panel1.TabIndex = 0;
            // 
            // cboKhatoonies
            // 
            this.cboKhatoonies.DisplayMember = "KhatooniId";
            this.cboKhatoonies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhatoonies.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhatoonies.FormattingEnabled = true;
            this.cboKhatoonies.Location = new System.Drawing.Point(78, 6);
            this.cboKhatoonies.Name = "cboKhatoonies";
            this.cboKhatoonies.Size = new System.Drawing.Size(112, 33);
            this.cboKhatoonies.TabIndex = 6;
            this.cboKhatoonies.ValueMember = "KhatooniId";
            this.cboKhatoonies.SelectionChangeCommitted += new System.EventHandler(this.cboKhatoonies_SelectionChangeCommitted);
            // 
            // label89
            // 
            this.label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label89.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(196, 6);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(84, 33);
            this.label89.TabIndex = 5;
            this.label89.Text = "کھتونی نمبر";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(455, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 33);
            this.label9.TabIndex = 3;
            this.label9.Text = "کھاتہ نمبر";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbokhataNo
            // 
            this.cbokhataNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbokhataNo.DisplayMember = "RegisterHqDKhataId";
            this.cbokhataNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbokhataNo.FormattingEnabled = true;
            this.cbokhataNo.Location = new System.Drawing.Point(302, 5);
            this.cbokhataNo.Name = "cbokhataNo";
            this.cbokhataNo.Size = new System.Drawing.Size(147, 33);
            this.cbokhataNo.TabIndex = 4;
            this.cbokhataNo.ValueMember = "RegisterHqDKhataId";
            this.cbokhataNo.SelectionChangeCommitted += new System.EventHandler(this.cbokhataNo_SelectionChangeCommitted);
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(524, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(274, 35);
            this.label29.TabIndex = 1;
            this.label29.Text = "کھتونی مشتریان بمطابق سابقہ کھتونی";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnDelMushteri);
            this.panel2.Controls.Add(this.btnAmaldaramad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 43);
            this.panel2.TabIndex = 1;
            // 
            // btnAmaldaramad
            // 
            this.btnAmaldaramad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAmaldaramad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmaldaramad.Location = new System.Drawing.Point(321, 5);
            this.btnAmaldaramad.Name = "btnAmaldaramad";
            this.btnAmaldaramad.Size = new System.Drawing.Size(110, 34);
            this.btnAmaldaramad.TabIndex = 24;
            this.btnAmaldaramad.Text = "محفوظ کریں";
            this.btnAmaldaramad.UseVisualStyleBackColor = true;
            this.btnAmaldaramad.Click += new System.EventHandler(this.btnAmaldaramad_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 401);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridviewNewKhatooniMushteryan);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 376);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "موجودہ کھتونی مشتریان";
            // 
            // gridviewNewKhatooniMushteryan
            // 
            this.gridviewNewKhatooniMushteryan.AllowUserToAddRows = false;
            this.gridviewNewKhatooniMushteryan.AllowUserToDeleteRows = false;
            this.gridviewNewKhatooniMushteryan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridviewNewKhatooniMushteryan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridviewNewKhatooniMushteryan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewNewKhatooniMushteryan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridviewNewKhatooniMushteryan.Location = new System.Drawing.Point(3, 22);
            this.gridviewNewKhatooniMushteryan.MultiSelect = false;
            this.gridviewNewKhatooniMushteryan.Name = "gridviewNewKhatooniMushteryan";
            this.gridviewNewKhatooniMushteryan.ReadOnly = true;
            this.gridviewNewKhatooniMushteryan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewNewKhatooniMushteryan.Size = new System.Drawing.Size(365, 351);
            this.gridviewNewKhatooniMushteryan.TabIndex = 1;
            this.gridviewNewKhatooniMushteryan.DoubleClick += new System.EventHandler(this.gridviewNewKhatooniMushteryan_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridviewOldKhatooniMushteryan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(380, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "سابقہ کھتونی مشتریان";
            // 
            // gridviewOldKhatooniMushteryan
            // 
            this.gridviewOldKhatooniMushteryan.AllowUserToAddRows = false;
            this.gridviewOldKhatooniMushteryan.AllowUserToDeleteRows = false;
            this.gridviewOldKhatooniMushteryan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridviewOldKhatooniMushteryan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridviewOldKhatooniMushteryan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewOldKhatooniMushteryan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridviewOldKhatooniMushteryan.Location = new System.Drawing.Point(3, 22);
            this.gridviewOldKhatooniMushteryan.Name = "gridviewOldKhatooniMushteryan";
            this.gridviewOldKhatooniMushteryan.ReadOnly = true;
            this.gridviewOldKhatooniMushteryan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewOldKhatooniMushteryan.Size = new System.Drawing.Size(414, 351);
            this.gridviewOldKhatooniMushteryan.TabIndex = 0;
            this.gridviewOldKhatooniMushteryan.DoubleClick += new System.EventHandler(this.gridviewIntiqalKhata_DoubleClick);
            // 
            // btnDelMushteri
            // 
            this.btnDelMushteri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMushteri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelMushteri.Location = new System.Drawing.Point(25, 3);
            this.btnDelMushteri.Name = "btnDelMushteri";
            this.btnDelMushteri.Size = new System.Drawing.Size(110, 34);
            this.btnDelMushteri.TabIndex = 25;
            this.btnDelMushteri.Text = "حذف کریں";
            this.btnDelMushteri.UseVisualStyleBackColor = true;
            // 
            // frmKhatooniMushteryanFromKhatooni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 492);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmKhatooniMushteryanFromKhatooni";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفصیل مالکان بمعہ حصہ و رقبہ ";
            this.Load += new System.EventHandler(this.frmFardbyMozaSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewNewKhatooniMushteryan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewOldKhatooniMushteryan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridviewOldKhatooniMushteryan;
        private System.Windows.Forms.Button btnAmaldaramad;
        private System.Windows.Forms.DataGridView gridviewNewKhatooniMushteryan;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn faradKanalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardAreaPartDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardPartBataDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardFeetDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardMarlaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardSarsaiDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn intiqalIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn khatooniIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn khatooniKhewatFareeqRecIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn murthinIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriFareeqIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriAreaKMSqftDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriAreaKMSrDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seqNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faradKanalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardAreaPartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardPartBataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardFeetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardMarlaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fardSarsaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intiqalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khatooniIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khatooniKhewatFareeqRecIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn murthinIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriFareeqIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriAreaKMSqftDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mushtriAreaKMSrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seqNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbokhataNo;
        private System.Windows.Forms.ComboBox cboKhatoonies;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Button btnDelMushteri;
    }
}