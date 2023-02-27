namespace SDC_Application.AL
{
    partial class frmMessageBox
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
            this.lbMessageBox = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbAfterMenhay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMessageBox
            // 
            this.lbMessageBox.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessageBox.Location = new System.Drawing.Point(0, 71);
            this.lbMessageBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMessageBox.Name = "lbMessageBox";
            this.lbMessageBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbMessageBox.Size = new System.Drawing.Size(663, 46);
            this.lbMessageBox.TabIndex = 1;
            this.lbMessageBox.Text = "label1";
            this.lbMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(260, 154);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 69);
            this.btnOK.TabIndex = 13;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // lbAfterMenhay
            // 
            this.lbAfterMenhay.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAfterMenhay.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbAfterMenhay.Location = new System.Drawing.Point(0, 14);
            this.lbAfterMenhay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAfterMenhay.Name = "lbAfterMenhay";
            this.lbAfterMenhay.Size = new System.Drawing.Size(663, 46);
            this.lbAfterMenhay.TabIndex = 14;
            this.lbAfterMenhay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 258);
            this.ControlBox = false;
            this.Controls.Add(this.lbAfterMenhay);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbMessageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbMessageBox;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lbAfterMenhay;
    }
}