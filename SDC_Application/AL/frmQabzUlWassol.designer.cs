namespace SDC_Application.AL
{
    partial class frmQabzUlWassol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQabzUlWassol));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbIntiqalNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvIntiqalReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
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
            this.splitContainer1.Location = new System.Drawing.Point(7, 6);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtNote);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtAmount);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbIntiqalNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMouza);
            this.splitContainer1.Panel1.Controls.Add(this.lbl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1133, 652);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1061, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 38);
            this.label3.TabIndex = 212;
            this.label3.Text = ":نوٹ ";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNote.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(20, 39);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(1040, 38);
            this.txtNote.TabIndex = 211;
            this.txtNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNote_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 38);
            this.label2.TabIndex = 210;
            this.label2.Text = ":رقم ";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(92, 8);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(173, 30);
            this.txtAmount.TabIndex = 209;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(20, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 34);
            this.button1.TabIndex = 58;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbIntiqalNo
            // 
            this.cmbIntiqalNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbIntiqalNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbIntiqalNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIntiqalNo.DropDownHeight = 500;
            this.cmbIntiqalNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbIntiqalNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIntiqalNo.FormattingEnabled = true;
            this.cmbIntiqalNo.IntegralHeight = false;
            this.cmbIntiqalNo.Location = new System.Drawing.Point(601, 7);
            this.cmbIntiqalNo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIntiqalNo.Name = "cmbIntiqalNo";
            this.cmbIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIntiqalNo.Size = new System.Drawing.Size(157, 31);
            this.cmbIntiqalNo.TabIndex = 54;
            this.cmbIntiqalNo.SelectionChangeCommitted += new System.EventHandler(this.cmbIntiqalNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(776, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 38);
            this.label1.TabIndex = 55;
            this.label1.Text = ":انتقال نمبر";
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.DropDownHeight = 500;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(863, 13);
            this.cmbMouza.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(197, 31);
            this.cmbMouza.TabIndex = 48;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1061, 13);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(62, 38);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = ":موضع";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvIntiqalReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1133, 566);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rvIntiqalReport
            // 
            this.rvIntiqalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIntiqalReport.Location = new System.Drawing.Point(4, 36);
            this.rvIntiqalReport.Margin = new System.Windows.Forms.Padding(4);
            this.rvIntiqalReport.Name = "rvIntiqalReport";
            this.rvIntiqalReport.ShowParameterPrompts = false;
            this.rvIntiqalReport.Size = new System.Drawing.Size(1125, 526);
            this.rvIntiqalReport.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(490, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 38);
            this.label4.TabIndex = 214;
            this.label4.Text = "جابرانہ + ٹیکس";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(309, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 30);
            this.textBox1.TabIndex = 213;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tt.SetToolTip(this.textBox1, "جابرانہ اور تما م ٹیکس کی ایک ساتھ فیصد درج کریں");
            // 
            // frmQabzUlWassol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 664);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQabzUlWassol";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
        private System.Windows.Forms.ComboBox cmbMouza;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmbIntiqalNo;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip tt;





    }
}

