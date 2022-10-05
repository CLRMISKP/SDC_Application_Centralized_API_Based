namespace SDC_Application.AL
{
    partial class frmStayOrderDocs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLockKhata = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.PageNos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockKhata)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLockKhata
            // 
            this.dgvLockKhata.AllowUserToAddRows = false;
            this.dgvLockKhata.AllowUserToDeleteRows = false;
            this.dgvLockKhata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLockKhata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLockKhata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.Picture,
            this.PageNos,
            this.InsertDate,
            this.GetImageId});
            this.dgvLockKhata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLockKhata.Location = new System.Drawing.Point(0, 0);
            this.dgvLockKhata.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgvLockKhata.Name = "dgvLockKhata";
            this.dgvLockKhata.ReadOnly = true;
            this.dgvLockKhata.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvLockKhata.RowHeadersWidth = 50;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLockKhata.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLockKhata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLockKhata.RowTemplate.Height = 28;
            this.dgvLockKhata.Size = new System.Drawing.Size(1070, 749);
            this.dgvLockKhata.TabIndex = 2;
            this.dgvLockKhata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLockKhata_CellContentClick);
            // 
            // SNo
            // 
            this.SNo.FillWeight = 57.68635F;
            this.SNo.HeaderText = "سیریل نمبر";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            // 
            // Picture
            // 
            this.Picture.FillWeight = 93.65734F;
            this.Picture.HeaderText = "دستاویز";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            // 
            // PageNos
            // 
            this.PageNos.FillWeight = 54.01516F;
            this.PageNos.HeaderText = "صفحات";
            this.PageNos.Name = "PageNos";
            this.PageNos.ReadOnly = true;
            // 
            // InsertDate
            // 
            this.InsertDate.FillWeight = 63.45178F;
            this.InsertDate.HeaderText = "تاریخ";
            this.InsertDate.Name = "InsertDate";
            this.InsertDate.ReadOnly = true;
            // 
            // GetImageId
            // 
            this.GetImageId.HeaderText = "ImageId";
            this.GetImageId.Name = "GetImageId";
            this.GetImageId.ReadOnly = true;
            this.GetImageId.Visible = false;
            // 
            // frmStayOrderDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 749);
            this.Controls.Add(this.dgvLockKhata);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStayOrderDocs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سٹے آرڈر دستاویزات";
            this.Load += new System.EventHandler(this.frmStayOrderDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockKhata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLockKhata;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNos;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetImageId;

    }
}