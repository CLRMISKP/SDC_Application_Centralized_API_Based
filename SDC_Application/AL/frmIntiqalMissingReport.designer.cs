namespace SDC_Application.AL
{
    partial class frmIntiqalMissingReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.rvIntiqalReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIdentifyMissMut = new System.Windows.Forms.Button();
            this.PrintMissingMut = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 38);
            this.label1.TabIndex = 55;
            this.label1.Text = "موضع";
            this.label1.Visible = false;
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.DropDownHeight = 500;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(33, 46);
            this.cmbMouza.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(189, 31);
            this.cmbMouza.TabIndex = 48;
            this.cmbMouza.Visible = false;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1679, 36);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(62, 38);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = ":موضع";
            // 
            // rvIntiqalReport
            // 
            this.rvIntiqalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIntiqalReport.DocumentMapWidth = 8;
            this.rvIntiqalReport.Location = new System.Drawing.Point(3, 18);
            this.rvIntiqalReport.Margin = new System.Windows.Forms.Padding(4);
            this.rvIntiqalReport.Name = "rvIntiqalReport";
            this.rvIntiqalReport.ShowParameterPrompts = false;
            this.rvIntiqalReport.Size = new System.Drawing.Size(1272, 426);
            this.rvIntiqalReport.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.cmbMouza);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1278, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتقال کا انتخاب کریں";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(355, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 61);
            this.panel2.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 31);
            this.label2.TabIndex = 70;
            this.label2.Text = "لاک کھاتا جات بمع مالکان خانہ کاشت وغیرہ پرنٹ کریں";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::SDC_Application.Resource1.Print3;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(3, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 69;
            this.tt.SetToolTip(this.button3, "لاک کھاتا جات پرنٹ کریں");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnIdentifyMissMut);
            this.panel1.Controls.Add(this.PrintMissingMut);
            this.panel1.Location = new System.Drawing.Point(713, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 61);
            this.panel1.TabIndex = 59;
            // 
            // btnIdentifyMissMut
            // 
            this.btnIdentifyMissMut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIdentifyMissMut.Location = new System.Drawing.Point(98, 6);
            this.btnIdentifyMissMut.Margin = new System.Windows.Forms.Padding(4);
            this.btnIdentifyMissMut.Name = "btnIdentifyMissMut";
            this.btnIdentifyMissMut.Size = new System.Drawing.Size(170, 44);
            this.btnIdentifyMissMut.TabIndex = 70;
            this.btnIdentifyMissMut.Text = "گمشدہ انتقالات کی شناخت کریں";
            this.btnIdentifyMissMut.UseVisualStyleBackColor = true;
            this.btnIdentifyMissMut.Click += new System.EventHandler(this.btnIdentifyMissMut_Click);
            // 
            // PrintMissingMut
            // 
            this.PrintMissingMut.BackgroundImage = global::SDC_Application.Resource1.Print3;
            this.PrintMissingMut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintMissingMut.Location = new System.Drawing.Point(14, 6);
            this.PrintMissingMut.Name = "PrintMissingMut";
            this.PrintMissingMut.Size = new System.Drawing.Size(50, 50);
            this.PrintMissingMut.TabIndex = 69;
            this.tt.SetToolTip(this.PrintMissingMut, "گمشدہ انتقالات پرنٹ کریں");
            this.PrintMissingMut.UseVisualStyleBackColor = true;
            this.PrintMissingMut.Click += new System.EventHandler(this.PrintMissingMut_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rvIntiqalReport);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(7, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(1278, 447);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // frmIntiqalMissingReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1292, 559);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIntiqalMissingReport";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDC Print outs";
            this.Load += new System.EventHandler(this.frmSDCReportingMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvIntiqalReport;
        private System.Windows.Forms.ComboBox cmbMouza;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIdentifyMissMut;
        private System.Windows.Forms.Button PrintMissingMut;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;





    }
}

