﻿namespace SDC_Application.AL
{
    partial class frmVerificationFinger
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPersonName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // verificationControl1
            // 
            this.verificationControl1.Active = true;
            this.verificationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verificationControl1.Location = new System.Drawing.Point(253, 279);
            this.verificationControl1.Name = "verificationControl1";
            this.verificationControl1.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.verificationControl1.Size = new System.Drawing.Size(48, 47);
            this.verificationControl1.TabIndex = 1;
            this.verificationControl1.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.verificationControl1_OnComplete);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(181, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 168);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbPersonName
            // 
            this.lbPersonName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPersonName.AutoSize = true;
            this.lbPersonName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonName.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbPersonName.Location = new System.Drawing.Point(225, 43);
            this.lbPersonName.Name = "lbPersonName";
            this.lbPersonName.Size = new System.Drawing.Size(85, 30);
            this.lbPersonName.TabIndex = 6;
            this.lbPersonName.Text = "انگوٹھے کا نشان";
            this.lbPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVerificationFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 435);
            this.Controls.Add(this.lbPersonName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verificationControl1);
            this.Name = "frmVerificationFinger";
            this.Text = "تصدیق انگوٹھا";
            this.Load += new System.EventHandler(this.frmVerificationFinger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DPFP.Gui.Verification.VerificationControl verificationControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPersonName;
    }
}