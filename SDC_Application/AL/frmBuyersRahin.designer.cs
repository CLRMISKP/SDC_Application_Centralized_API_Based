namespace SDC_Application.AL
{
    partial class frmBuyersRahin
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
            this.GridViewSellers = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKhewatKhataId = new System.Windows.Forms.TextBox();
            this.txtKhewatGroupId = new System.Windows.Forms.TextBox();
            this.txtKhewatFreeqainGroupId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GridViewMalikanSelect = new System.Windows.Forms.DataGridView();
            this.GetMalikanbyKhataIdDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetMalikanSelectedDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetKhatajatDataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSellers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanbyKhataIdDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanSelectedDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhatajatDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewSellers
            // 
            this.GridViewSellers.AllowUserToAddRows = false;
            this.GridViewSellers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GridViewSellers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewSellers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewSellers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewSellers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1});
            this.GridViewSellers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewSellers.Location = new System.Drawing.Point(0, 0);
            this.GridViewSellers.Margin = new System.Windows.Forms.Padding(4);
            this.GridViewSellers.Name = "GridViewSellers";
            this.GridViewSellers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewSellers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewSellers.Size = new System.Drawing.Size(470, 306);
            this.GridViewSellers.TabIndex = 0;
            this.GridViewSellers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewMalikan_CellClick);
            // 
            // col1
            // 
            this.col1.FillWeight = 48.7897F;
            this.col1.HeaderText = "انتخاب";
            this.col1.Name = "col1";
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
            this.panel1.Controls.Add(this.txtKhewatKhataId);
            this.panel1.Controls.Add(this.txtKhewatGroupId);
            this.panel1.Controls.Add(this.txtKhewatFreeqainGroupId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 58);
            this.panel1.TabIndex = 3;
            // 
            // txtKhewatKhataId
            // 
            this.txtKhewatKhataId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhewatKhataId.Enabled = false;
            this.txtKhewatKhataId.Location = new System.Drawing.Point(110, 15);
            this.txtKhewatKhataId.Name = "txtKhewatKhataId";
            this.txtKhewatKhataId.ReadOnly = true;
            this.txtKhewatKhataId.Size = new System.Drawing.Size(58, 26);
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
            this.txtKhewatGroupId.Size = new System.Drawing.Size(47, 26);
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
            this.txtKhewatFreeqainGroupId.Size = new System.Drawing.Size(51, 26);
            this.txtKhewatFreeqainGroupId.TabIndex = 3;
            this.txtKhewatFreeqainGroupId.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCheckAll);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 366);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 59);
            this.panel2.TabIndex = 4;
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
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(100, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 41);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "انتخاب شدہ مالکان محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.GridViewSellers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(430, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 308);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.GridViewMalikanSelect);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 58);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(416, 308);
            this.panel4.TabIndex = 6;
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
            this.GridViewMalikanSelect.Margin = new System.Windows.Forms.Padding(4);
            this.GridViewMalikanSelect.Name = "GridViewMalikanSelect";
            this.GridViewMalikanSelect.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewMalikanSelect.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewMalikanSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewMalikanSelect.Size = new System.Drawing.Size(414, 306);
            this.GridViewMalikanSelect.TabIndex = 1;
            // 
            // frmBuyersRahin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 425);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuyersRahin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راہن بائعان /مشتریان";
            this.Load += new System.EventHandler(this.frmBuyersRahin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSellers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMalikanSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanbyKhataIdDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetMalikanSelectedDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhatajatDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewSellers;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.BindingSource GetMalikanbyKhataIdDataSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource GetMalikanSelectedDataSource;
        private System.Windows.Forms.BindingSource GetKhatajatDataSource;
        private System.Windows.Forms.TextBox txtKhewatFreeqainGroupId;
        private System.Windows.Forms.TextBox txtKhewatGroupId;
        private System.Windows.Forms.TextBox txtKhewatKhataId;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView GridViewMalikanSelect;
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
