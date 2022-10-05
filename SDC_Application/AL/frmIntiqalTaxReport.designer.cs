namespace SDC_Application.AL
{
    partial class frmIntiqalTaxReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntiqalTaxReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTaxPayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvIntiqalReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbTaxPayer);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbTaxType);
            this.splitContainer1.Panel1.Controls.Add(this.lbl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1119, 444);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(343, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 58;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTaxPayer
            // 
            this.cmbTaxPayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTaxPayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTaxPayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxPayer.DropDownHeight = 500;
            this.cmbTaxPayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTaxPayer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaxPayer.FormattingEnabled = true;
            this.cmbTaxPayer.IntegralHeight = false;
            this.cmbTaxPayer.Location = new System.Drawing.Point(462, 10);
            this.cmbTaxPayer.Name = "cmbTaxPayer";
            this.cmbTaxPayer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTaxPayer.Size = new System.Drawing.Size(255, 27);
            this.cmbTaxPayer.TabIndex = 54;
            this.cmbTaxPayer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTaxPayer_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(725, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 30);
            this.label1.TabIndex = 55;
            this.label1.Text = ":ٹیکس دہندہ ";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTaxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTaxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxType.DropDownHeight = 500;
            this.cmbTaxType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTaxType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.IntegralHeight = false;
            this.cmbTaxType.Location = new System.Drawing.Point(824, 10);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTaxType.Size = new System.Drawing.Size(190, 27);
            this.cmbTaxType.TabIndex = 48;
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            this.cmbTaxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTaxType_KeyPress);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1027, 8);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(74, 30);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = ":فیس برائے ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvIntiqalReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1119, 398);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rvIntiqalReport
            // 
            this.rvIntiqalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIntiqalReport.Location = new System.Drawing.Point(3, 29);
            this.rvIntiqalReport.Name = "rvIntiqalReport";
            this.rvIntiqalReport.ShowParameterPrompts = false;
            this.rvIntiqalReport.Size = new System.Drawing.Size(1113, 366);
            this.rvIntiqalReport.TabIndex = 0;
            // 
            // frmIntiqalTaxReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 454);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmIntiqalTaxReport";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDC Print outs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSDCReportingMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvIntiqalReport;
        private System.Windows.Forms.ComboBox cmbTaxType;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbTaxPayer;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;





    }
}

