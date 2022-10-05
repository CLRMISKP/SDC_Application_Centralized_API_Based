namespace SDC_Application.AL
{
    partial class frmIntiqalAttestationByRO
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
            this.verificationControl1 = new DPFP.Gui.Verification.VerificationControl();
            this.gbSelectRO = new System.Windows.Forms.GroupBox();
            this.lblRoName = new System.Windows.Forms.Label();
            this.cboROs = new System.Windows.Forms.ComboBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbSelectRO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // verificationControl1
            // 
            this.verificationControl1.Active = true;
            this.verificationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verificationControl1.Location = new System.Drawing.Point(287, 22);
            this.verificationControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.verificationControl1.Name = "verificationControl1";
            this.verificationControl1.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.verificationControl1.Size = new System.Drawing.Size(48, 116);
            this.verificationControl1.TabIndex = 1;
            this.verificationControl1.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.verificationControl1_OnComplete);
            // 
            // gbSelectRO
            // 
            this.gbSelectRO.Controls.Add(this.lblRoName);
            this.gbSelectRO.Controls.Add(this.cboROs);
            this.gbSelectRO.Controls.Add(this.lbl5);
            this.gbSelectRO.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSelectRO.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectRO.Location = new System.Drawing.Point(5, 5);
            this.gbSelectRO.Name = "gbSelectRO";
            this.gbSelectRO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbSelectRO.Size = new System.Drawing.Size(513, 88);
            this.gbSelectRO.TabIndex = 3;
            this.gbSelectRO.TabStop = false;
            this.gbSelectRO.Text = "ریونیو افیسر کا انتخاب کریں";
            // 
            // lblRoName
            // 
            this.lblRoName.AutoSize = true;
            this.lblRoName.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRoName.Location = new System.Drawing.Point(128, 35);
            this.lblRoName.Name = "lblRoName";
            this.lblRoName.Size = new System.Drawing.Size(17, 25);
            this.lblRoName.TabIndex = 17;
            this.lblRoName.Text = ":";
            // 
            // cboROs
            // 
            this.cboROs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboROs.DisplayMember = "IntiqalType";
            this.cboROs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboROs.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboROs.FormattingEnabled = true;
            this.cboROs.Location = new System.Drawing.Point(274, 35);
            this.cboROs.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboROs.Name = "cboROs";
            this.cboROs.Size = new System.Drawing.Size(159, 28);
            this.cboROs.TabIndex = 15;
            this.cboROs.Tag = "1";
            this.cboROs.ValueMember = "IntiqalTypeId";
            this.cboROs.SelectionChangeCommitted += new System.EventHandler(this.cboROs_SelectionChangeCommitted);
            // 
            // lbl5
            // 
            this.lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl5.Location = new System.Drawing.Point(439, 38);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(66, 25);
            this.lbl5.TabIndex = 16;
            this.lbl5.Text = "ریونیو افیسر";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(222, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 50);
            this.btnSave.TabIndex = 21;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(102, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 175);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(513, 84);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تصدیق کے بعد محفوظ کریں";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.verificationControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(513, 216);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "حیثیت تصدیق";
            // 
            // frmIntiqalAttestationByRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 398);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSelectRO);
            this.Name = "frmIntiqalAttestationByRO";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "تصدیق انتقال";
            this.Load += new System.EventHandler(this.frmVerificationFinger_Load);
            this.gbSelectRO.ResumeLayout(false);
            this.gbSelectRO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DPFP.Gui.Verification.VerificationControl verificationControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbSelectRO;
        private System.Windows.Forms.ComboBox cboROs;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRoName;
    }
}