namespace SDC_Application.AL
{
    partial class frmIntiqalReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntiqalReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rbIntiqalOldType = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.rbKasht = new System.Windows.Forms.RadioButton();
            this.rbMalkiat = new System.Windows.Forms.RadioButton();
            this.cmbIntiqalNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbMalkiatKasht = new System.Windows.Forms.RadioButton();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.rbWirasat = new System.Windows.Forms.RadioButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.rbTaqseem = new System.Windows.Forms.RadioButton();
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
            this.splitContainer1.Panel1.Controls.Add(this.rbIntiqalOldType);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.rbKasht);
            this.splitContainer1.Panel1.Controls.Add(this.rbMalkiat);
            this.splitContainer1.Panel1.Controls.Add(this.cmbIntiqalNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.rbMalkiatKasht);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMouza);
            this.splitContainer1.Panel1.Controls.Add(this.rbWirasat);
            this.splitContainer1.Panel1.Controls.Add(this.lbl1);
            this.splitContainer1.Panel1.Controls.Add(this.rbTaqseem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1254, 444);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 0;
            // 
            // rbIntiqalOldType
            // 
            this.rbIntiqalOldType.AutoSize = true;
            this.rbIntiqalOldType.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIntiqalOldType.Location = new System.Drawing.Point(216, 5);
            this.rbIntiqalOldType.Name = "rbIntiqalOldType";
            this.rbIntiqalOldType.Size = new System.Drawing.Size(98, 34);
            this.rbIntiqalOldType.TabIndex = 59;
            this.rbIntiqalOldType.Text = "تفصیلی فارمیٹ";
            this.rbIntiqalOldType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbIntiqalOldType.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(132, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 20);
            this.button1.TabIndex = 58;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbKasht
            // 
            this.rbKasht.AutoSize = true;
            this.rbKasht.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKasht.Location = new System.Drawing.Point(557, 5);
            this.rbKasht.Name = "rbKasht";
            this.rbKasht.Size = new System.Drawing.Size(77, 34);
            this.rbKasht.TabIndex = 57;
            this.rbKasht.Text = "خانہ کاشت";
            this.rbKasht.UseVisualStyleBackColor = true;
            // 
            // rbMalkiat
            // 
            this.rbMalkiat.AutoSize = true;
            this.rbMalkiat.Checked = true;
            this.rbMalkiat.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMalkiat.Location = new System.Drawing.Point(643, 5);
            this.rbMalkiat.Name = "rbMalkiat";
            this.rbMalkiat.Size = new System.Drawing.Size(78, 34);
            this.rbMalkiat.TabIndex = 56;
            this.rbMalkiat.TabStop = true;
            this.rbMalkiat.Text = "خانہ ملکیت";
            this.rbMalkiat.UseVisualStyleBackColor = true;
            // 
            // cmbIntiqalNo
            // 
            this.cmbIntiqalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIntiqalNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbIntiqalNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIntiqalNo.DropDownHeight = 500;
            this.cmbIntiqalNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbIntiqalNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIntiqalNo.FormattingEnabled = true;
            this.cmbIntiqalNo.IntegralHeight = false;
            this.cmbIntiqalNo.Location = new System.Drawing.Point(740, 5);
            this.cmbIntiqalNo.Name = "cmbIntiqalNo";
            this.cmbIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIntiqalNo.Size = new System.Drawing.Size(175, 27);
            this.cmbIntiqalNo.TabIndex = 54;
            this.cmbIntiqalNo.SelectionChangeCommitted += new System.EventHandler(this.cmbIntiqalNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(928, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 30);
            this.label1.TabIndex = 55;
            this.label1.Text = ":انتقال نمبر";
            // 
            // rbMalkiatKasht
            // 
            this.rbMalkiatKasht.AutoSize = true;
            this.rbMalkiatKasht.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMalkiatKasht.Location = new System.Drawing.Point(316, 5);
            this.rbMalkiatKasht.Name = "rbMalkiatKasht";
            this.rbMalkiatKasht.Size = new System.Drawing.Size(112, 34);
            this.rbMalkiatKasht.TabIndex = 53;
            this.rbMalkiatKasht.Text = "خانہ کاشت و ملکیت";
            this.rbMalkiatKasht.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMalkiatKasht.UseVisualStyleBackColor = true;
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
            this.cmbMouza.Location = new System.Drawing.Point(1002, 5);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 48;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // rbWirasat
            // 
            this.rbWirasat.AutoSize = true;
            this.rbWirasat.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWirasat.Location = new System.Drawing.Point(429, 5);
            this.rbWirasat.Name = "rbWirasat";
            this.rbWirasat.Size = new System.Drawing.Size(64, 34);
            this.rbWirasat.TabIndex = 52;
            this.rbWirasat.Text = "وراثت";
            this.rbWirasat.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1192, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(48, 30);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = ":موضع";
            // 
            // rbTaqseem
            // 
            this.rbTaqseem.AutoSize = true;
            this.rbTaqseem.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTaqseem.Location = new System.Drawing.Point(499, 5);
            this.rbTaqseem.Name = "rbTaqseem";
            this.rbTaqseem.Size = new System.Drawing.Size(57, 34);
            this.rbTaqseem.TabIndex = 51;
            this.rbTaqseem.Text = "تقسیم";
            this.rbTaqseem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvIntiqalReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1254, 398);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rvIntiqalReport
            // 
            this.rvIntiqalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIntiqalReport.Location = new System.Drawing.Point(3, 29);
            this.rvIntiqalReport.Name = "rvIntiqalReport";
            this.rvIntiqalReport.ShowParameterPrompts = false;
            this.rvIntiqalReport.Size = new System.Drawing.Size(1248, 366);
            this.rvIntiqalReport.TabIndex = 0;
            // 
            // frmIntiqalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 454);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmIntiqalReport";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDC Print outs";
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
        private System.Windows.Forms.RadioButton rbMalkiatKasht;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.RadioButton rbWirasat;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.RadioButton rbTaqseem;
        private System.Windows.Forms.RadioButton rbKasht;
        private System.Windows.Forms.RadioButton rbMalkiat;
        private System.Windows.Forms.ComboBox cmbIntiqalNo;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbIntiqalOldType;





    }
}

