namespace SDC_Application.AL
{
    partial class frmVidTut
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.lbRHZ_Khata = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbRHZ_Khata);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(822, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(246, 625);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ویڈیو لسٹ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wb);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Size = new System.Drawing.Size(822, 625);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 38);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(816, 581);
            this.wb.TabIndex = 0;
            // 
            // lbRHZ_Khata
            // 
            this.lbRHZ_Khata.AutoSize = true;
            this.lbRHZ_Khata.Location = new System.Drawing.Point(64, 56);
            this.lbRHZ_Khata.Name = "lbRHZ_Khata";
            this.lbRHZ_Khata.Size = new System.Drawing.Size(142, 31);
            this.lbRHZ_Khata.TabIndex = 0;
            this.lbRHZ_Khata.TabStop = true;
            this.lbRHZ_Khata.Text = "کھاتہ وغیرہ ڈیٹا انٹری درستگی ";
            this.lbRHZ_Khata.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRHZ_Khata_LinkClicked);
            // 
            // frmVidTut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmVidTut";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "یو ٹیوب ویڈیو ٹیوٹورئل";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.LinkLabel lbRHZ_Khata;
    }
}