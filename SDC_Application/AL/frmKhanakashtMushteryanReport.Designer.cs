namespace SDC_Application.AL
{
    partial class frmKhanakashtMushteryanReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.cmbKhataNos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.chkAllByMoza = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkAllByMoza);
            this.panel1.Controls.Add(this.btnViewReport);
            this.panel1.Controls.Add(this.cmbKhataNos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.cmbMouza);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 189);
            this.panel1.TabIndex = 0;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Enabled = false;
            this.btnViewReport.Image = global::SDC_Application.Resource1.showIcon1;
            this.btnViewReport.Location = new System.Drawing.Point(59, 124);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(50, 48);
            this.btnViewReport.TabIndex = 52;
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // cmbKhataNos
            // 
            this.cmbKhataNos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhataNos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKhataNos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKhataNos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbKhataNos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhataNos.FormattingEnabled = true;
            this.cmbKhataNos.Location = new System.Drawing.Point(59, 81);
            this.cmbKhataNos.Name = "cmbKhataNos";
            this.cmbKhataNos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbKhataNos.Size = new System.Drawing.Size(190, 27);
            this.cmbKhataNos.TabIndex = 51;
            this.cmbKhataNos.SelectionChangeCommitted += new System.EventHandler(this.cmbKhataNos_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "کھاتہ نمبر";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(255, 33);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(48, 30);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = ":موضع";
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.Location = new System.Drawing.Point(59, 32);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 48;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            // 
            // chkAllByMoza
            // 
            this.chkAllByMoza.AutoSize = true;
            this.chkAllByMoza.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllByMoza.Location = new System.Drawing.Point(177, 129);
            this.chkAllByMoza.Name = "chkAllByMoza";
            this.chkAllByMoza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAllByMoza.Size = new System.Drawing.Size(126, 34);
            this.chkAllByMoza.TabIndex = 53;
            this.chkAllByMoza.Text = "تمام کھاتوں کا رپورٹ";
            this.chkAllByMoza.UseVisualStyleBackColor = true;
            // 
            // frmKhanakashtMushteryanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 201);
            this.Controls.Add(this.panel1);
            this.Name = "frmKhanakashtMushteryanReport";
            this.Text = "حقوق ملکیت با خانہ کاشت";
            this.Load += new System.EventHandler(this.frmKhanakashtMushteryanReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.ComboBox cmbKhataNos;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.CheckBox chkAllByMoza;
    }
}