namespace SDC_Application.AL
{
    partial class frmIntiqalReportOptions
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
            this.rbIntitialInfo = new System.Windows.Forms.RadioButton();
            this.rbAttestation = new System.Windows.Forms.RadioButton();
            this.print = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbKhanaMalkiat = new System.Windows.Forms.RadioButton();
            this.rbKhanaKaasht = new System.Windows.Forms.RadioButton();
            this.rbKhanaMalkiatKasht = new System.Windows.Forms.RadioButton();
            this.rbWerasath = new System.Windows.Forms.RadioButton();
            this.rbPartition = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbIntitialInfo
            // 
            this.rbIntitialInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbIntitialInfo.AutoSize = true;
            this.rbIntitialInfo.Checked = true;
            this.rbIntitialInfo.Location = new System.Drawing.Point(168, 14);
            this.rbIntitialInfo.Name = "rbIntitialInfo";
            this.rbIntitialInfo.Size = new System.Drawing.Size(200, 29);
            this.rbIntitialInfo.TabIndex = 0;
            this.rbIntitialInfo.TabStop = true;
            this.rbIntitialInfo.Text = "ابتدائی معلومات براٰئے انتقال درخواست گزار";
            this.rbIntitialInfo.UseVisualStyleBackColor = true;
            // 
            // rbAttestation
            // 
            this.rbAttestation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAttestation.AutoSize = true;
            this.rbAttestation.Location = new System.Drawing.Point(235, 49);
            this.rbAttestation.Name = "rbAttestation";
            this.rbAttestation.Size = new System.Drawing.Size(133, 29);
            this.rbAttestation.TabIndex = 1;
            this.rbAttestation.Text = "براٰئے پڑتال و تصدیق انتقال";
            this.rbAttestation.UseVisualStyleBackColor = true;
            this.rbAttestation.CheckedChanged += new System.EventHandler(this.rbAttestation_CheckedChanged);
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.print.BackgroundImage = global::SDC_Application.Resource1.Print31;
            this.print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.print.Location = new System.Drawing.Point(66, 14);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(73, 64);
            this.print.TabIndex = 32;
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPartition);
            this.groupBox1.Controls.Add(this.rbWerasath);
            this.groupBox1.Controls.Add(this.rbKhanaMalkiatKasht);
            this.groupBox1.Controls.Add(this.rbKhanaKaasht);
            this.groupBox1.Controls.Add(this.rbKhanaMalkiat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(5, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 120);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "قسم انتقال";
            this.groupBox1.Visible = false;
            // 
            // rbKhanaMalkiat
            // 
            this.rbKhanaMalkiat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKhanaMalkiat.AutoSize = true;
            this.rbKhanaMalkiat.Checked = true;
            this.rbKhanaMalkiat.Location = new System.Drawing.Point(360, 32);
            this.rbKhanaMalkiat.Name = "rbKhanaMalkiat";
            this.rbKhanaMalkiat.Size = new System.Drawing.Size(71, 29);
            this.rbKhanaMalkiat.TabIndex = 2;
            this.rbKhanaMalkiat.TabStop = true;
            this.rbKhanaMalkiat.Text = "خانہ ملکیت";
            this.rbKhanaMalkiat.UseVisualStyleBackColor = true;
            // 
            // rbKhanaKaasht
            // 
            this.rbKhanaKaasht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKhanaKaasht.AutoSize = true;
            this.rbKhanaKaasht.Location = new System.Drawing.Point(284, 32);
            this.rbKhanaKaasht.Name = "rbKhanaKaasht";
            this.rbKhanaKaasht.Size = new System.Drawing.Size(70, 29);
            this.rbKhanaKaasht.TabIndex = 3;
            this.rbKhanaKaasht.Text = "خانہ کاشت";
            this.rbKhanaKaasht.UseVisualStyleBackColor = true;
            // 
            // rbKhanaMalkiatKasht
            // 
            this.rbKhanaMalkiatKasht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKhanaMalkiatKasht.AutoSize = true;
            this.rbKhanaMalkiatKasht.Location = new System.Drawing.Point(162, 32);
            this.rbKhanaMalkiatKasht.Name = "rbKhanaMalkiatKasht";
            this.rbKhanaMalkiatKasht.Size = new System.Drawing.Size(100, 29);
            this.rbKhanaMalkiatKasht.TabIndex = 4;
            this.rbKhanaMalkiatKasht.Text = "خانہ ملکیت و کاشت";
            this.rbKhanaMalkiatKasht.UseVisualStyleBackColor = true;
            // 
            // rbWerasath
            // 
            this.rbWerasath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbWerasath.AutoSize = true;
            this.rbWerasath.Location = new System.Drawing.Point(100, 32);
            this.rbWerasath.Name = "rbWerasath";
            this.rbWerasath.Size = new System.Drawing.Size(56, 29);
            this.rbWerasath.TabIndex = 5;
            this.rbWerasath.Text = "وراثت";
            this.rbWerasath.UseVisualStyleBackColor = true;
            // 
            // rbPartition
            // 
            this.rbPartition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPartition.AutoSize = true;
            this.rbPartition.Location = new System.Drawing.Point(14, 32);
            this.rbPartition.Name = "rbPartition";
            this.rbPartition.Size = new System.Drawing.Size(79, 29);
            this.rbPartition.TabIndex = 6;
            this.rbPartition.Text = "تقسیم ؛ ایوارڈ";
            this.rbPartition.UseVisualStyleBackColor = true;
            // 
            // frmIntiqalReportOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(453, 220);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.print);
            this.Controls.Add(this.rbAttestation);
            this.Controls.Add(this.rbIntitialInfo);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmIntiqalReportOptions";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتقال رپورٹ پرنٹ کریں";
            this.Load += new System.EventHandler(this.frmIntiqalReportOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbIntitialInfo;
        private System.Windows.Forms.RadioButton rbAttestation;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbKhanaMalkiat;
        private System.Windows.Forms.RadioButton rbPartition;
        private System.Windows.Forms.RadioButton rbWerasath;
        private System.Windows.Forms.RadioButton rbKhanaMalkiatKasht;
        private System.Windows.Forms.RadioButton rbKhanaKaasht;
    }
}