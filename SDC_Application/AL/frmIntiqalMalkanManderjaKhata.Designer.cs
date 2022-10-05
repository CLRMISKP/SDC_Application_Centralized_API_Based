namespace SDC_Application.AL
{
    partial class frmIntiqalMalkanManderjaKhata
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSearchByFamily = new System.Windows.Forms.CheckBox();
            this.cbFamily = new System.Windows.Forms.ComboBox();
            this.txtKhewatKhataId = new System.Windows.Forms.TextBox();
            this.txtKhewatGroupId = new System.Windows.Forms.TextBox();
            this.txtKhewatFreeqainGroupId = new System.Windows.Forms.TextBox();
            this.cbKhatas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridViewMalikanSelect = new System.Windows.Forms.DataGridView();
            this.GridViewMalikan = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(475, 6);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(207, 41);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "انتخاب مالکان";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxSearchByFamily);
            this.panel1.Controls.Add(this.cbFamily);
            this.panel1.Controls.Add(this.txtKhewatKhataId);
            this.panel1.Controls.Add(this.txtKhewatGroupId);
            this.panel1.Controls.Add(this.txtKhewatFreeqainGroupId);
            this.panel1.Controls.Add(this.cbKhatas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 58);
            this.panel1.TabIndex = 7;
            // 
            // checkBoxSearchByFamily
            // 
            this.checkBoxSearchByFamily.AutoSize = true;
            this.checkBoxSearchByFamily.Location = new System.Drawing.Point(484, 13);
            this.checkBoxSearchByFamily.Name = "checkBoxSearchByFamily";
            this.checkBoxSearchByFamily.Size = new System.Drawing.Size(92, 29);
            this.checkBoxSearchByFamily.TabIndex = 8;
            this.checkBoxSearchByFamily.Text = "انتخاب خاندان:";
            this.checkBoxSearchByFamily.UseVisualStyleBackColor = true;
            // 
            // cbFamily
            // 
            this.cbFamily.FormattingEnabled = true;
            this.cbFamily.Location = new System.Drawing.Point(190, 11);
            this.cbFamily.Name = "cbFamily";
            this.cbFamily.Size = new System.Drawing.Size(288, 33);
            this.cbFamily.TabIndex = 7;
            this.cbFamily.Visible = false;
            // 
            // txtKhewatKhataId
            // 
            this.txtKhewatKhataId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatKhataId.Enabled = false;
            this.txtKhewatKhataId.Location = new System.Drawing.Point(110, 15);
            this.txtKhewatKhataId.Name = "txtKhewatKhataId";
            this.txtKhewatKhataId.ReadOnly = true;
            this.txtKhewatKhataId.Size = new System.Drawing.Size(58, 33);
            this.txtKhewatKhataId.TabIndex = 5;
            this.txtKhewatKhataId.Visible = false;
            // 
            // txtKhewatGroupId
            // 
            this.txtKhewatGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatGroupId.Enabled = false;
            this.txtKhewatGroupId.Location = new System.Drawing.Point(57, 15);
            this.txtKhewatGroupId.Name = "txtKhewatGroupId";
            this.txtKhewatGroupId.ReadOnly = true;
            this.txtKhewatGroupId.Size = new System.Drawing.Size(47, 33);
            this.txtKhewatGroupId.TabIndex = 4;
            this.txtKhewatGroupId.Visible = false;
            // 
            // txtKhewatFreeqainGroupId
            // 
            this.txtKhewatFreeqainGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatFreeqainGroupId.Enabled = false;
            this.txtKhewatFreeqainGroupId.Location = new System.Drawing.Point(0, 15);
            this.txtKhewatFreeqainGroupId.Name = "txtKhewatFreeqainGroupId";
            this.txtKhewatFreeqainGroupId.ReadOnly = true;
            this.txtKhewatFreeqainGroupId.Size = new System.Drawing.Size(51, 33);
            this.txtKhewatFreeqainGroupId.TabIndex = 3;
            this.txtKhewatFreeqainGroupId.Visible = false;
            // 
            // cbKhatas
            // 
            this.cbKhatas.DisplayMember = "KhataNo";
            this.cbKhatas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhatas.FormattingEnabled = true;
            this.cbKhatas.Location = new System.Drawing.Point(640, 11);
            this.cbKhatas.Name = "cbKhatas";
            this.cbKhatas.Size = new System.Drawing.Size(155, 33);
            this.cbKhatas.TabIndex = 1;
            this.cbKhatas.ValueMember = "RegisterHqDKhataId";
            this.cbKhatas.SelectionChangeCommitted += new System.EventHandler(this.cbKhatas_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(801, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "انتخاب کھاتہ:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(100, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 41);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "انتخاب شدہ ملکان محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(746, 6);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(114, 41);
            this.btnCheckAll.TabIndex = 4;
            this.btnCheckAll.Text = "تمام منتخب کریں";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCheckAll);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 430);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 59);
            this.panel2.TabIndex = 8;
            // 
            // GridViewMalikanSelect
            // 
            this.GridViewMalikanSelect.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GridViewMalikanSelect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.GridViewMalikanSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewMalikanSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewMalikanSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.GridViewMalikanSelect.Location = new System.Drawing.Point(0, 58);
            this.GridViewMalikanSelect.Margin = new System.Windows.Forms.Padding(4);
            this.GridViewMalikanSelect.Name = "GridViewMalikanSelect";
            this.GridViewMalikanSelect.ReadOnly = true;
            this.GridViewMalikanSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewMalikanSelect.Size = new System.Drawing.Size(414, 372);
            this.GridViewMalikanSelect.TabIndex = 9;
            // 
            // GridViewMalikan
            // 
            this.GridViewMalikan.AllowUserToAddRows = false;
            this.GridViewMalikan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GridViewMalikan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.GridViewMalikan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewMalikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewMalikan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1});
            this.GridViewMalikan.Dock = System.Windows.Forms.DockStyle.Right;
            this.GridViewMalikan.Location = new System.Drawing.Point(427, 58);
            this.GridViewMalikan.Margin = new System.Windows.Forms.Padding(4);
            this.GridViewMalikan.Name = "GridViewMalikan";
            this.GridViewMalikan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewMalikan.Size = new System.Drawing.Size(470, 372);
            this.GridViewMalikan.TabIndex = 10;
            // 
            // col1
            // 
            this.col1.FillWeight = 48.7897F;
            this.col1.HeaderText = "انتخاب";
            this.col1.Name = "col1";
            // 
            // frmIntiqalMalkanManderjaKhata
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(897, 489);
            this.Controls.Add(this.GridViewMalikan);
            this.Controls.Add(this.GridViewMalikanSelect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIntiqalMalkanManderjaKhata";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ملکان مندرجہ کھاتہ";
            this.Load += new System.EventHandler(this.frmIntiqalMalkanManderjaKhata_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxSearchByFamily;
        private System.Windows.Forms.ComboBox cbFamily;
        private System.Windows.Forms.TextBox txtKhewatKhataId;
        private System.Windows.Forms.TextBox txtKhewatGroupId;
        private System.Windows.Forms.TextBox txtKhewatFreeqainGroupId;
        private System.Windows.Forms.ComboBox cbKhatas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GridViewMalikanSelect;
        private System.Windows.Forms.DataGridView GridViewMalikan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col1;
    }
}