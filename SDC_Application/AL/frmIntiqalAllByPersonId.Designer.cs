namespace SDC_Application.AL
{
    partial class frmIntiqalAllByPersonId
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAllMutations = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMutations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 67);
            this.panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Alvi Nastaleeq", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(483, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(139, 53);
            this.lblName.TabIndex = 57;
            this.lblName.Text = "انتقالات لیسٹ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.panel3);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(0, 67);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1122, 626);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "تمام انتقالات";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAllMutations);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1116, 588);
            this.panel3.TabIndex = 3;
            // 
            // dgvAllMutations
            // 
            this.dgvAllMutations.AllowUserToAddRows = false;
            this.dgvAllMutations.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvAllMutations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllMutations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllMutations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllMutations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllMutations.Location = new System.Drawing.Point(0, 0);
            this.dgvAllMutations.MultiSelect = false;
            this.dgvAllMutations.Name = "dgvAllMutations";
            this.dgvAllMutations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllMutations.Size = new System.Drawing.Size(1116, 588);
            this.dgvAllMutations.TabIndex = 1;
            this.dgvAllMutations.TabStop = false;
            // 
            // frmIntiqalAllByPersonId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 693);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.panel1);
            this.Name = "frmIntiqalAllByPersonId";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتخاب کردہ مالک کا انتقالات ریکارڈ";
            this.Load += new System.EventHandler(this.frmIntiqalAllByPersonId_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMutations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAllMutations;
    }
}