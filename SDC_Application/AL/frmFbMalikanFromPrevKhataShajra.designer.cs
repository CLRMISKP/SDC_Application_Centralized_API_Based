namespace SDC_Application.AL
{
    partial class frmFbMalikanFromPrevKhataShajra
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridViewMalikan = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridViewMalikanSelect = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSearchByFamily = new System.Windows.Forms.CheckBox();
            this.cbFamily = new System.Windows.Forms.ComboBox();
            this.txtKhewatKhataId = new System.Windows.Forms.TextBox();
            this.txtKhewatGroupId = new System.Windows.Forms.TextBox();
            this.txtKhewatFreeqainGroupId = new System.Windows.Forms.TextBox();
            this.cbKhatas = new System.Windows.Forms.ComboBox();
            this.GetKhatajatDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GetMalikanbyKhataIdDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetMalikanSelectedDataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhatajatDataSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanbyKhataIdDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanSelectedDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewMalikan
            // 
            this.GridViewMalikan.AllowUserToAddRows = false;
            this.GridViewMalikan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GridViewMalikan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewMalikan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewMalikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewMalikan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1});
            this.GridViewMalikan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewMalikan.Location = new System.Drawing.Point(0, 0);
            this.GridViewMalikan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridViewMalikan.Name = "GridViewMalikan";
            this.GridViewMalikan.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewMalikan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewMalikan.Size = new System.Drawing.Size(546, 435);
            this.GridViewMalikan.TabIndex = 0;
            this.GridViewMalikan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewMalikan_CellClick);
            // 
            // col1
            // 
            this.col1.FillWeight = 48.7897F;
            this.col1.HeaderText = "انتخاب";
            this.col1.Name = "col1";
            // 
            // GridViewMalikanSelect
            // 
            this.GridViewMalikanSelect.AllowUserToAddRows = false;
            this.GridViewMalikanSelect.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GridViewMalikanSelect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewMalikanSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewMalikanSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewMalikanSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewMalikanSelect.Location = new System.Drawing.Point(0, 0);
            this.GridViewMalikanSelect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridViewMalikanSelect.Name = "GridViewMalikanSelect";
            this.GridViewMalikanSelect.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewMalikanSelect.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewMalikanSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewMalikanSelect.Size = new System.Drawing.Size(376, 435);
            this.GridViewMalikanSelect.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(493, 8);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(114, 55);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 57);
            this.panel1.TabIndex = 3;
            // 
            // checkBoxSearchByFamily
            // 
            this.checkBoxSearchByFamily.AutoSize = true;
            this.checkBoxSearchByFamily.Location = new System.Drawing.Point(494, 6);
            this.checkBoxSearchByFamily.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.checkBoxSearchByFamily.Name = "checkBoxSearchByFamily";
            this.checkBoxSearchByFamily.Size = new System.Drawing.Size(112, 35);
            this.checkBoxSearchByFamily.TabIndex = 8;
            this.checkBoxSearchByFamily.Text = "انتخاب خاندان:";
            this.checkBoxSearchByFamily.UseVisualStyleBackColor = true;
            this.checkBoxSearchByFamily.CheckedChanged += new System.EventHandler(this.checkBoxSearchByFamily_CheckedChanged);
            // 
            // cbFamily
            // 
            this.cbFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFamily.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFamily.FormattingEnabled = true;
            this.cbFamily.Location = new System.Drawing.Point(297, 4);
            this.cbFamily.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbFamily.Name = "cbFamily";
            this.cbFamily.Size = new System.Drawing.Size(193, 39);
            this.cbFamily.TabIndex = 7;
            this.cbFamily.Visible = false;
            this.cbFamily.SelectionChangeCommitted += new System.EventHandler(this.cbFamily_SelectionChangeCommitted);
            this.cbFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFamily_KeyPress);
            // 
            // txtKhewatKhataId
            // 
            this.txtKhewatKhataId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatKhataId.Enabled = false;
            this.txtKhewatKhataId.Location = new System.Drawing.Point(73, 20);
            this.txtKhewatKhataId.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtKhewatKhataId.Name = "txtKhewatKhataId";
            this.txtKhewatKhataId.ReadOnly = true;
            this.txtKhewatKhataId.Size = new System.Drawing.Size(39, 39);
            this.txtKhewatKhataId.TabIndex = 5;
            this.txtKhewatKhataId.Visible = false;
            // 
            // txtKhewatGroupId
            // 
            this.txtKhewatGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatGroupId.Enabled = false;
            this.txtKhewatGroupId.Location = new System.Drawing.Point(38, 20);
            this.txtKhewatGroupId.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtKhewatGroupId.Name = "txtKhewatGroupId";
            this.txtKhewatGroupId.ReadOnly = true;
            this.txtKhewatGroupId.Size = new System.Drawing.Size(32, 39);
            this.txtKhewatGroupId.TabIndex = 4;
            this.txtKhewatGroupId.Visible = false;
            // 
            // txtKhewatFreeqainGroupId
            // 
            this.txtKhewatFreeqainGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatFreeqainGroupId.Enabled = false;
            this.txtKhewatFreeqainGroupId.Location = new System.Drawing.Point(0, 20);
            this.txtKhewatFreeqainGroupId.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtKhewatFreeqainGroupId.Name = "txtKhewatFreeqainGroupId";
            this.txtKhewatFreeqainGroupId.ReadOnly = true;
            this.txtKhewatFreeqainGroupId.Size = new System.Drawing.Size(35, 39);
            this.txtKhewatFreeqainGroupId.TabIndex = 3;
            this.txtKhewatFreeqainGroupId.Visible = false;
            // 
            // cbKhatas
            // 
            this.cbKhatas.DataSource = this.GetKhatajatDataSource;
            this.cbKhatas.DisplayMember = "KhataNo";
            this.cbKhatas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhatas.FormattingEnabled = true;
            this.cbKhatas.Location = new System.Drawing.Point(614, 4);
            this.cbKhatas.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbKhatas.Name = "cbKhatas";
            this.cbKhatas.Size = new System.Drawing.Size(228, 39);
            this.cbKhatas.TabIndex = 1;
            this.cbKhatas.ValueMember = "RegisterHqDKhataId";
            this.cbKhatas.SelectionChangeCommitted += new System.EventHandler(this.cbKhatas_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(863, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "انتخاب کھاتہ:";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCheckAll);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 494);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 79);
            this.panel2.TabIndex = 4;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(797, 4);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(137, 55);
            this.btnCheckAll.TabIndex = 4;
            this.btnCheckAll.Text = "تمام منتخب کریں";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(67, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 55);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "انتخاب شدہ مالکان محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.GridViewMalikan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(398, 57);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 437);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.GridViewMalikanSelect);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 57);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 437);
            this.panel4.TabIndex = 6;
            // 
            // frmFbMalikanFromPrevKhataShajra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 573);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmFbMalikanFromPrevKhataShajra";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پچھلے کھاتے سے مالکان کا انتخاب";
            this.Load += new System.EventHandler(this.frmTestMalkanSelcIntiqalWirasath_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhatajatDataSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanbyKhataIdDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanSelectedDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewMalikan;
        private System.Windows.Forms.DataGridView GridViewMalikanSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.BindingSource GetMalikanbyKhataIdDataSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource GetMalikanSelectedDataSource;
        private System.Windows.Forms.ComboBox cbKhatas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource GetKhatajatDataSource;
        private System.Windows.Forms.TextBox txtKhewatFreeqainGroupId;
        private System.Windows.Forms.TextBox txtKhewatGroupId;
        private System.Windows.Forms.TextBox txtKhewatKhataId;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.ComboBox cbFamily;
        private System.Windows.Forms.CheckBox checkBoxSearchByFamily;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn personNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn fardAreaPartDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatGroupFareeqIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatGroupIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatAreaDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn registerHqDKhataIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn kanalDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn marlaDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn sarsaiDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn personNameDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn fardAreaPartDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatGroupFareeqIdDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatGroupIdDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatTypeIdDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn khewatAreaDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn registerHqDKhataIdDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn kanalDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn marlaDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn sarsaiDataGridViewTextBoxColumn1;
    }
}
