namespace SDC_Application.AL
{
    partial class frmStayOrderPics
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
            this.gpImage = new System.Windows.Forms.GroupBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.gpImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gpImage
            // 
            this.gpImage.Controls.Add(this.pbImage);
            this.gpImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpImage.Location = new System.Drawing.Point(0, 0);
            this.gpImage.Name = "gpImage";
            this.gpImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpImage.Size = new System.Drawing.Size(684, 661);
            this.gpImage.TabIndex = 0;
            this.gpImage.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(3, 16);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(678, 642);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // frmStayOrderPics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.gpImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStayOrderPics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دستاویزات";
            this.gpImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gpImage;
        public System.Windows.Forms.PictureBox pbImage;



    }
}