namespace SDC_Application.AL
{
    partial class frmIntiqalPendingReasons
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalKhattajat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchedKhattaDataBinding = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboIntiqalPendingReasons = new System.Windows.Forms.ComboBox();
            this.btnSaveIntiqalPendingStatus = new System.Windows.Forms.Button();
            this.txtPendingRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchedKhattaDataBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lblPersonName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 52);
            this.panel1.TabIndex = 0;
            // 
            // lblPersonName
            // 
            this.lblPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.Location = new System.Drawing.Point(0, 0);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(678, 52);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "انتقال زیر التواء ";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTotalKhattajat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 43);
            this.panel2.TabIndex = 1;
            // 
            // lblTotalKhattajat
            // 
            this.lblTotalKhattajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalKhattajat.Location = new System.Drawing.Point(450, 13);
            this.lblTotalKhattajat.Name = "lblTotalKhattajat";
            this.lblTotalKhattajat.Size = new System.Drawing.Size(82, 21);
            this.lblTotalKhattajat.TabIndex = 1;
            this.lblTotalKhattajat.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "کل کھاتہ جات:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "وجہ التواء";
            // 
            // cboIntiqalPendingReasons
            // 
            this.cboIntiqalPendingReasons.FormattingEnabled = true;
            this.cboIntiqalPendingReasons.Location = new System.Drawing.Point(12, 64);
            this.cboIntiqalPendingReasons.Name = "cboIntiqalPendingReasons";
            this.cboIntiqalPendingReasons.Size = new System.Drawing.Size(590, 27);
            this.cboIntiqalPendingReasons.TabIndex = 3;
            // 
            // btnSaveIntiqalPendingStatus
            // 
            this.btnSaveIntiqalPendingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveIntiqalPendingStatus.Location = new System.Drawing.Point(290, 140);
            this.btnSaveIntiqalPendingStatus.Name = "btnSaveIntiqalPendingStatus";
            this.btnSaveIntiqalPendingStatus.Size = new System.Drawing.Size(91, 31);
            this.btnSaveIntiqalPendingStatus.TabIndex = 6;
            this.btnSaveIntiqalPendingStatus.Text = "محفوظ کریں";
            this.btnSaveIntiqalPendingStatus.UseVisualStyleBackColor = true;
            this.btnSaveIntiqalPendingStatus.Click += new System.EventHandler(this.btnSaveIntiqalPendingStatus_Click);
            // 
            // txtPendingRemarks
            // 
            this.txtPendingRemarks.Location = new System.Drawing.Point(12, 97);
            this.txtPendingRemarks.Name = "txtPendingRemarks";
            this.txtPendingRemarks.Size = new System.Drawing.Size(590, 26);
            this.txtPendingRemarks.TabIndex = 25;
            this.txtPendingRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPendingRemarks_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "تفصیل";
            // 
            // frmIntiqalPendingReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 220);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPendingRemarks);
            this.Controls.Add(this.btnSaveIntiqalPendingStatus);
            this.Controls.Add(this.cboIntiqalPendingReasons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIntiqalPendingReasons";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = " تلاش خسرہ ";
            this.Load += new System.EventHandler(this.frmIntiqalPendingReasons_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchedKhattaDataBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource SearchedKhattaDataBinding;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalKhattajat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboIntiqalPendingReasons;
        private System.Windows.Forms.Button btnSaveIntiqalPendingStatus;
        private System.Windows.Forms.TextBox txtPendingRemarks;
        private System.Windows.Forms.Label label3;
    }
}