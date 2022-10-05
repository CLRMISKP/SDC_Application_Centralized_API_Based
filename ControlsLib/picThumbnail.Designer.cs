namespace LandInfo.ControlsLib
{
    partial class picThumbnail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.txtDocumentNo);
            this.pnlFooter.Controls.Add(this.chkSelect);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 143);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(182, 33);
            this.pnlFooter.TabIndex = 0;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Location = new System.Drawing.Point(27, 5);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(150, 20);
            this.txtDocumentNo.TabIndex = 1;
            this.txtDocumentNo.TextChanged += new System.EventHandler(this.txtDocumentNo_TextChanged);
            this.txtDocumentNo.Enter += new System.EventHandler(this.txtDocumentNo_Enter);
            // 
            // chkSelect
            // 
            this.chkSelect.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSelect.Location = new System.Drawing.Point(0, 0);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(21, 31);
            this.chkSelect.TabIndex = 0;
            this.chkSelect.TabStop = false;
            this.chkSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            this.chkSelect.Enter += new System.EventHandler(this.chkSelect_Enter);
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFileName.Location = new System.Drawing.Point(0, 116);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(182, 27);
            this.lblFileName.TabIndex = 1;
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbThumbnail.Location = new System.Drawing.Point(0, 0);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(182, 143);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 1;
            this.pbThumbnail.TabStop = false;
            this.pbThumbnail.Click += new System.EventHandler(this.pbThumbnail_Click);
            // 
            // picThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.pbThumbnail);
            this.Controls.Add(this.pnlFooter);
            this.Name = "picThumbnail";
            this.Size = new System.Drawing.Size(182, 176);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtDocumentNo;
    }
}
