namespace SDC_Application.AL
{
    partial class frmSelfPersonDetails
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgKhewatFreeqDetails = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhewatFreeqDetails)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgKhewatFreeqDetails);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.tabPage3.Size = new System.Drawing.Size(1242, 703);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تفصیل مالکان بمع سابقہ و موجودہ حیثیت";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgKhewatFreeqDetails
            // 
            this.dgKhewatFreeqDetails.AllowUserToAddRows = false;
            this.dgKhewatFreeqDetails.AllowUserToDeleteRows = false;
            this.dgKhewatFreeqDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhewatFreeqDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhewatFreeqDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhewatFreeqDetails.Location = new System.Drawing.Point(3, 12);
            this.dgKhewatFreeqDetails.Name = "dgKhewatFreeqDetails";
            this.dgKhewatFreeqDetails.ReadOnly = true;
            this.dgKhewatFreeqDetails.RowHeadersVisible = false;
            this.dgKhewatFreeqDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKhewatFreeqDetails.Size = new System.Drawing.Size(1236, 679);
            this.dgKhewatFreeqDetails.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1250, 741);
            this.tabControl1.TabIndex = 1;
            // 
            // frmSelfPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 741);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmSelfPersonDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "عمل انتقال، کھاتہ در کھاتہ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIntiqalAmalDaramadByKhata_Load);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhewatFreeqDetails)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgKhewatFreeqDetails;
        private System.Windows.Forms.TabControl tabControl1;

    }
}