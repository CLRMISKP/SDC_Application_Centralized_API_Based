namespace SDC_Application.AL
{
    partial class frmKhassraDeletionInput
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
            this.rbCompleteDelete = new System.Windows.Forms.RadioButton();
            this.rbTypeDelete = new System.Windows.Forms.RadioButton();
            this.btnProceed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbCompleteDelete
            // 
            this.rbCompleteDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCompleteDelete.AutoSize = true;
            this.rbCompleteDelete.Location = new System.Drawing.Point(12, 30);
            this.rbCompleteDelete.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rbCompleteDelete.Name = "rbCompleteDelete";
            this.rbCompleteDelete.Size = new System.Drawing.Size(214, 35);
            this.rbCompleteDelete.TabIndex = 0;
            this.rbCompleteDelete.TabStop = true;
            this.rbCompleteDelete.Text = "مکمل خسرہ بمع تمام تفصیل حذف کریں";
            this.rbCompleteDelete.UseVisualStyleBackColor = true;
            // 
            // rbTypeDelete
            // 
            this.rbTypeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTypeDelete.AutoSize = true;
            this.rbTypeDelete.Location = new System.Drawing.Point(12, 88);
            this.rbTypeDelete.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rbTypeDelete.Name = "rbTypeDelete";
            this.rbTypeDelete.Size = new System.Drawing.Size(319, 35);
            this.rbTypeDelete.TabIndex = 1;
            this.rbTypeDelete.TabStop = true;
            this.rbTypeDelete.Text = "صرف انتخاب کردہ تفصیل خسرہ (خسرہ کے بغیر) حذف کریں";
            this.rbTypeDelete.UseVisualStyleBackColor = true;
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(61, 153);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(232, 39);
            this.btnProceed.TabIndex = 311;
            this.btnProceed.Text = "انتخاب کردہ قسم حذف کے ساتھ اگے جائے";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // frmKhassraDeletionInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 227);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.rbTypeDelete);
            this.Controls.Add(this.rbCompleteDelete);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmKhassraDeletionInput";
            this.Text = "خسرہ حذف کریں";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCompleteDelete;
        private System.Windows.Forms.RadioButton rbTypeDelete;
        private System.Windows.Forms.Button btnProceed;
    }
}