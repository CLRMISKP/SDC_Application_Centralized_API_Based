namespace SDC_Application.AL
{
    partial class frmIntiqalSelectKhatajatForBadastoor
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
            this.components = new System.ComponentModel.Container();
            this.clbKhatajat = new System.Windows.Forms.CheckedListBox();
            this.btnBadastoorMalikan = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblBadastoorKhata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clbKhatajat
            // 
            this.clbKhatajat.FormattingEnabled = true;
            this.clbKhatajat.Location = new System.Drawing.Point(4, 12);
            this.clbKhatajat.MultiColumn = true;
            this.clbKhatajat.Name = "clbKhatajat";
            this.clbKhatajat.Size = new System.Drawing.Size(633, 242);
            this.clbKhatajat.TabIndex = 0;
            // 
            // btnBadastoorMalikan
            // 
            this.btnBadastoorMalikan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBadastoorMalikan.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBadastoorMalikan.Location = new System.Drawing.Point(4, 260);
            this.btnBadastoorMalikan.Name = "btnBadastoorMalikan";
            this.btnBadastoorMalikan.Size = new System.Drawing.Size(111, 39);
            this.btnBadastoorMalikan.TabIndex = 39;
            this.btnBadastoorMalikan.Tag = "";
            this.btnBadastoorMalikan.Text = "محفوظ کریں";
            this.tt.SetToolTip(this.btnBadastoorMalikan, "انتخاب کردہ کھاتہ جات کے مالکان بدستور کھاتہ میں محفوظ کریں");
            this.btnBadastoorMalikan.UseVisualStyleBackColor = true;
            this.btnBadastoorMalikan.Click += new System.EventHandler(this.btnBadastoorMalikan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 31);
            this.label1.TabIndex = 40;
            this.label1.Text = "بدستور کھاتہ";
            // 
            // lblBadastoorKhata
            // 
            this.lblBadastoorKhata.AutoSize = true;
            this.lblBadastoorKhata.Location = new System.Drawing.Point(478, 264);
            this.lblBadastoorKhata.Name = "lblBadastoorKhata";
            this.lblBadastoorKhata.Size = new System.Drawing.Size(20, 31);
            this.lblBadastoorKhata.TabIndex = 41;
            this.lblBadastoorKhata.Text = ".";
            // 
            // frmIntiqalSelectKhatajatForBadastoor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 311);
            this.Controls.Add(this.lblBadastoorKhata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBadastoorMalikan);
            this.Controls.Add(this.clbKhatajat);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntiqalSelectKhatajatForBadastoor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = " بدستور کھاتہ مالکان ";
            this.Load += new System.EventHandler(this.frmIntiqalSelectKhatajatForBadastoor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbKhatajat;
        private System.Windows.Forms.Button btnBadastoorMalikan;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBadastoorKhata;
    }
}