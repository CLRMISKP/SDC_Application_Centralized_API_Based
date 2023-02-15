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
            this.rvIntiqalReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbIntiqalOldType
            // 
            this.rbIntiqalOldType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbIntiqalOldType.AutoSize = true;
            this.rbIntiqalOldType.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIntiqalOldType.Location = new System.Drawing.Point(116, 38);
            this.rbIntiqalOldType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbIntiqalOldType.Name = "rbIntiqalOldType";
            this.rbIntiqalOldType.Size = new System.Drawing.Size(123, 42);
            this.rbIntiqalOldType.TabIndex = 59;
            this.rbIntiqalOldType.Text = "تفصیلی فارمیٹ";
            this.rbIntiqalOldType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbIntiqalOldType.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(4, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 44);
            this.button1.TabIndex = 58;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbKasht
            // 
            this.rbKasht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKasht.AutoSize = true;
            this.rbKasht.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKasht.Location = new System.Drawing.Point(569, 38);
            this.rbKasht.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbKasht.Name = "rbKasht";
            this.rbKasht.Size = new System.Drawing.Size(96, 42);
            this.rbKasht.TabIndex = 57;
            this.rbKasht.Text = "خانہ کاشت";
            this.rbKasht.UseVisualStyleBackColor = true;
            // 
            // rbMalkiat
            // 
            this.rbMalkiat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMalkiat.AutoSize = true;
            this.rbMalkiat.Checked = true;
            this.rbMalkiat.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMalkiat.Location = new System.Drawing.Point(677, 38);
            this.rbMalkiat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMalkiat.Name = "rbMalkiat";
            this.rbMalkiat.Size = new System.Drawing.Size(98, 42);
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
            this.cmbIntiqalNo.Location = new System.Drawing.Point(784, 38);
            this.cmbIntiqalNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIntiqalNo.Name = "cmbIntiqalNo";
            this.cmbIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIntiqalNo.Size = new System.Drawing.Size(137, 31);
            this.cmbIntiqalNo.TabIndex = 54;
            this.cmbIntiqalNo.SelectionChangeCommitted += new System.EventHandler(this.cmbIntiqalNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1216, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 38);
            this.label1.TabIndex = 55;
            this.label1.Text = "موضع";
            // 
            // rbMalkiatKasht
            // 
            this.rbMalkiatKasht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMalkiatKasht.AutoSize = true;
            this.rbMalkiatKasht.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMalkiatKasht.Location = new System.Drawing.Point(249, 38);
            this.rbMalkiatKasht.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMalkiatKasht.Name = "rbMalkiatKasht";
            this.rbMalkiatKasht.Size = new System.Drawing.Size(140, 42);
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
            this.cmbMouza.Location = new System.Drawing.Point(1019, 38);
            this.cmbMouza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(189, 31);
            this.cmbMouza.TabIndex = 48;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // rbWirasat
            // 
            this.rbWirasat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbWirasat.AutoSize = true;
            this.rbWirasat.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWirasat.Location = new System.Drawing.Point(400, 38);
            this.rbWirasat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbWirasat.Name = "rbWirasat";
            this.rbWirasat.Size = new System.Drawing.Size(81, 42);
            this.rbWirasat.TabIndex = 52;
            this.rbWirasat.Text = "وراثت";
            this.rbWirasat.UseVisualStyleBackColor = true;
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
            // rbTaqseem
            // 
            this.rbTaqseem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTaqseem.AutoSize = true;
            this.rbTaqseem.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTaqseem.Location = new System.Drawing.Point(491, 38);
            this.rbTaqseem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTaqseem.Name = "rbTaqseem";
            this.rbTaqseem.Size = new System.Drawing.Size(71, 42);
            this.rbTaqseem.TabIndex = 51;
            this.rbTaqseem.Text = "تقسیم";
            this.rbTaqseem.UseVisualStyleBackColor = true;
            // 
            // rvIntiqalReport
            // 
            this.rvIntiqalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIntiqalReport.DocumentMapWidth = 8;
            this.rvIntiqalReport.Location = new System.Drawing.Point(3, 18);
            this.rvIntiqalReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvIntiqalReport.Name = "rvIntiqalReport";
            this.rvIntiqalReport.ShowParameterPrompts = false;
            this.rvIntiqalReport.Size = new System.Drawing.Size(1272, 426);
            this.rvIntiqalReport.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbIntiqalOldType);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbTaqseem);
            this.groupBox1.Controls.Add(this.rbKasht);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.rbMalkiat);
            this.groupBox1.Controls.Add(this.rbWirasat);
            this.groupBox1.Controls.Add(this.cmbIntiqalNo);
            this.groupBox1.Controls.Add(this.cmbMouza);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbMalkiatKasht);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(929, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 38);
            this.label2.TabIndex = 60;
            this.label2.Text = "انتقال نمبر";
            // 
            // frmIntiqalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 559);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmIntiqalReport";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDC Print outs";
            this.Load += new System.EventHandler(this.frmSDCReportingMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;





    }
}

