namespace SDC_Application
{
    partial class frmPersonKhattaSearch
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalKhattajat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdPersonKatajats = new System.Windows.Forms.DataGridView();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lblPersonName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.lblTotalKhattajat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 43);
            this.panel2.TabIndex = 1;
            // 
            // lblTotalKhattajat
            // 
            this.lblTotalKhattajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalKhattajat.Location = new System.Drawing.Point(453, 13);
            this.lblTotalKhattajat.Name = "lblTotalKhattajat";
            this.lblTotalKhattajat.Size = new System.Drawing.Size(82, 21);
            this.lblTotalKhattajat.TabIndex = 1;
            this.lblTotalKhattajat.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(541, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "کل کھاتہ جات:";
            // 
            // grdPersonKatajats
            // 
            this.grdPersonKatajats.AllowUserToAddRows = false;
            this.grdPersonKatajats.AllowUserToDeleteRows = false;
            this.grdPersonKatajats.ColumnHeadersHeight = 40;
            this.grdPersonKatajats.Location = new System.Drawing.Point(0, 48);
            this.grdPersonKatajats.Name = "grdPersonKatajats";
            this.grdPersonKatajats.ReadOnly = true;
            this.grdPersonKatajats.Size = new System.Drawing.Size(679, 328);
            this.grdPersonKatajats.TabIndex = 2;
            // 
            // lblPersonName
            // 
            this.lblPersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.Location = new System.Drawing.Point(0, 0);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(679, 52);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "label1";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPersonKhattaSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 409);
            this.Controls.Add(this.grdPersonKatajats);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPersonKhattaSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " تلاش کھاتہ جات ";
            this.Load += new System.EventHandler(this.frmPersonKhattaSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonKatajats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn khataNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalKhattajat;
        private System.Windows.Forms.DataGridView grdPersonKatajats;
        private System.Windows.Forms.Label lblPersonName;
    }
}