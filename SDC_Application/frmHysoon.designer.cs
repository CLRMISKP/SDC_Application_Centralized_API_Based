namespace SDC_Application
{
    partial class frmHysoon
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
            this.Enroll = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.Varify = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.picFpImage = new System.Windows.Forms.PictureBox();
            this.txtEditId = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnSaveFp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Enroll
            // 
            this.Enroll.Location = new System.Drawing.Point(273, 68);
            this.Enroll.Name = "Enroll";
            this.Enroll.Size = new System.Drawing.Size(116, 56);
            this.Enroll.TabIndex = 0;
            this.Enroll.Text = "نیا فنگر پرنٹ";
            this.Enroll.UseVisualStyleBackColor = true;
            this.Enroll.Click += new System.EventHandler(this.Enroll_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(13, 22);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(229, 33);
            this.txtInfo.TabIndex = 2;
            // 
            // Varify
            // 
            this.Varify.Location = new System.Drawing.Point(273, 188);
            this.Varify.Name = "Varify";
            this.Varify.Size = new System.Drawing.Size(116, 66);
            this.Varify.TabIndex = 0;
            this.Varify.Text = "محفوظ شدہ فنگر پرنٹ تصدیق کریں";
            this.Varify.UseVisualStyleBackColor = true;
            this.Varify.Click += new System.EventHandler(this.Varify_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(273, 260);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(116, 62);
            this.Stop.TabIndex = 0;
            this.Stop.Text = "بیئو مٹرک آلہ بند کریں";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(273, 328);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(116, 51);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "واپس جایئں";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "Finger No";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-47, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "User id";
            this.label1.Visible = false;
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(260, 13);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(144, 49);
            this.btnInit.TabIndex = 42;
            this.btnInit.Text = "بئو مٹرک آلہ سٹارٹ کریں";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // picFpImage
            // 
            this.picFpImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFpImage.Location = new System.Drawing.Point(13, 68);
            this.picFpImage.Name = "picFpImage";
            this.picFpImage.Size = new System.Drawing.Size(224, 264);
            this.picFpImage.TabIndex = 43;
            this.picFpImage.TabStop = false;
            // 
            // txtEditId
            // 
            this.txtEditId.Location = new System.Drawing.Point(86, 346);
            this.txtEditId.Name = "txtEditId";
            this.txtEditId.Size = new System.Drawing.Size(39, 33);
            this.txtEditId.TabIndex = 44;
            this.txtEditId.Text = "1";
            this.txtEditId.Visible = false;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(188, 348);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(39, 33);
            this.txtNumber.TabIndex = 45;
            this.txtNumber.Text = "1";
            this.txtNumber.Visible = false;
            // 
            // btnSaveFp
            // 
            this.btnSaveFp.Location = new System.Drawing.Point(273, 130);
            this.btnSaveFp.Name = "btnSaveFp";
            this.btnSaveFp.Size = new System.Drawing.Size(116, 52);
            this.btnSaveFp.TabIndex = 46;
            this.btnSaveFp.Text = "فنگر پرنٹ محفوظ کریں";
            this.btnSaveFp.UseVisualStyleBackColor = true;
            this.btnSaveFp.Click += new System.EventHandler(this.btnSaveFp_Click);
            // 
            // frmHysoon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(425, 391);
            this.Controls.Add(this.btnSaveFp);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtEditId);
            this.Controls.Add(this.picFpImage);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Varify);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Enroll);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmHysoon";
            this.Text = "ہائیسون فنگر پرنٹ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFpImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Enroll;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button Varify;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInit;
        public System.Windows.Forms.PictureBox picFpImage;
        private System.Windows.Forms.TextBox txtEditId;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnSaveFp;
    }
}