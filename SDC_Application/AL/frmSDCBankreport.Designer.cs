namespace SDC_Application.AL
{
    partial class frmSDCBankreport
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtKhatano = new System.Windows.Forms.TextBox();
            this.txthiddnPersonName = new System.Windows.Forms.TextBox();
            this.btnBuyerSearch = new System.Windows.Forms.Button();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.txthiddnPersonId = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.t1 = new System.Windows.Forms.DateTimePicker();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.t2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radpass = new System.Windows.Forms.RadioButton();
            this.radInti = new System.Windows.Forms.RadioButton();
            this.radFard = new System.Windows.Forms.RadioButton();
            this.radsdc = new System.Windows.Forms.RadioButton();
            this.radbank = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radbankslip = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(951, 278);
            this.webBrowser1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.txthiddnPersonId);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تفصیلات";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.TxtKhatano);
            this.panel3.Controls.Add(this.txthiddnPersonName);
            this.panel3.Controls.Add(this.btnBuyerSearch);
            this.panel3.Controls.Add(this.cmbMouza);
            this.panel3.Location = new System.Drawing.Point(314, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(562, 69);
            this.panel3.TabIndex = 3;
            // 
            // TxtKhatano
            // 
            this.TxtKhatano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKhatano.Location = new System.Drawing.Point(6, 14);
            this.TxtKhatano.Name = "TxtKhatano";
            this.TxtKhatano.Size = new System.Drawing.Size(159, 37);
            this.TxtKhatano.TabIndex = 8;
            // 
            // txthiddnPersonName
            // 
            this.txthiddnPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txthiddnPersonName.Enabled = false;
            this.txthiddnPersonName.Location = new System.Drawing.Point(171, 14);
            this.txthiddnPersonName.Name = "txthiddnPersonName";
            this.txthiddnPersonName.Size = new System.Drawing.Size(158, 37);
            this.txthiddnPersonName.TabIndex = 7;
            // 
            // btnBuyerSearch
            // 
            this.btnBuyerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuyerSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuyerSearch.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnBuyerSearch.Location = new System.Drawing.Point(504, 13);
            this.btnBuyerSearch.Name = "btnBuyerSearch";
            this.btnBuyerSearch.Size = new System.Drawing.Size(40, 38);
            this.btnBuyerSearch.TabIndex = 9;
            this.btnBuyerSearch.UseVisualStyleBackColor = true;
            this.btnBuyerSearch.Click += new System.EventHandler(this.btnBuyerSearch_Click);
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.Location = new System.Drawing.Point(335, 13);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.Size = new System.Drawing.Size(161, 27);
            this.cmbMouza.TabIndex = 6;
            // 
            // txthiddnPersonId
            // 
            this.txthiddnPersonId.Location = new System.Drawing.Point(6, 50);
            this.txthiddnPersonId.Name = "txthiddnPersonId";
            this.txthiddnPersonId.Size = new System.Drawing.Size(16, 37);
            this.txthiddnPersonId.TabIndex = 10;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReport.Location = new System.Drawing.Point(877, 29);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 50);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.t1);
            this.panel2.Controls.Add(this.chkRange);
            this.panel2.Controls.Add(this.t2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(314, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 69);
            this.panel2.TabIndex = 5;
            // 
            // t1
            // 
            this.t1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.t1.CustomFormat = "dd/mm/yyyy";
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.t1.Location = new System.Drawing.Point(98, 22);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(112, 26);
            this.t1.TabIndex = 0;
            // 
            // chkRange
            // 
            this.chkRange.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkRange.AutoSize = true;
            this.chkRange.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRange.Location = new System.Drawing.Point(223, 24);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(61, 19);
            this.chkRange.TabIndex = 5;
            this.chkRange.Text = "Range";
            this.chkRange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            // 
            // t2
            // 
            this.t2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.t2.CustomFormat = "dd/mm/yyyy";
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.t2.Location = new System.Drawing.Point(297, 22);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(115, 26);
            this.t2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radbankslip);
            this.panel1.Controls.Add(this.radpass);
            this.panel1.Controls.Add(this.radInti);
            this.panel1.Controls.Add(this.radFard);
            this.panel1.Controls.Add(this.radsdc);
            this.panel1.Controls.Add(this.radbank);
            this.panel1.Location = new System.Drawing.Point(45, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 72);
            this.panel1.TabIndex = 2;
            // 
            // radpass
            // 
            this.radpass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radpass.AutoSize = true;
            this.radpass.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radpass.Location = new System.Drawing.Point(90, 41);
            this.radpass.Name = "radpass";
            this.radpass.Size = new System.Drawing.Size(64, 29);
            this.radpass.TabIndex = 7;
            this.radpass.TabStop = true;
            this.radpass.Text = "پاس بک";
            this.radpass.UseVisualStyleBackColor = true;
            this.radpass.CheckedChanged += new System.EventHandler(this.radpass_CheckedChanged);
            // 
            // radInti
            // 
            this.radInti.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radInti.AutoSize = true;
            this.radInti.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radInti.Location = new System.Drawing.Point(186, 39);
            this.radInti.Name = "radInti";
            this.radInti.Size = new System.Drawing.Size(62, 29);
            this.radInti.TabIndex = 6;
            this.radInti.TabStop = true;
            this.radInti.Text = "انتقالات";
            this.radInti.UseVisualStyleBackColor = true;
            this.radInti.CheckedChanged += new System.EventHandler(this.radInti_CheckedChanged);
            // 
            // radFard
            // 
            this.radFard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radFard.AutoSize = true;
            this.radFard.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radFard.Location = new System.Drawing.Point(27, 6);
            this.radFard.Name = "radFard";
            this.radFard.Size = new System.Drawing.Size(43, 29);
            this.radFard.TabIndex = 5;
            this.radFard.TabStop = true;
            this.radFard.Text = "فرد";
            this.radFard.UseVisualStyleBackColor = true;
            this.radFard.CheckedChanged += new System.EventHandler(this.radFard_CheckedChanged);
            // 
            // radsdc
            // 
            this.radsdc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radsdc.AutoSize = true;
            this.radsdc.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radsdc.Location = new System.Drawing.Point(90, 6);
            this.radsdc.Name = "radsdc";
            this.radsdc.Size = new System.Drawing.Size(75, 29);
            this.radsdc.TabIndex = 4;
            this.radsdc.TabStop = true;
            this.radsdc.Text = "ایس ڈی سی";
            this.radsdc.UseVisualStyleBackColor = true;
            this.radsdc.CheckedChanged += new System.EventHandler(this.radsdc_CheckedChanged);
            // 
            // radbank
            // 
            this.radbank.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radbank.AutoSize = true;
            this.radbank.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radbank.Location = new System.Drawing.Point(201, 6);
            this.radbank.Name = "radbank";
            this.radbank.Size = new System.Drawing.Size(47, 29);
            this.radbank.TabIndex = 3;
            this.radbank.TabStop = true;
            this.radbank.Text = "بنک";
            this.radbank.UseVisualStyleBackColor = true;
            this.radbank.CheckedChanged += new System.EventHandler(this.radbank_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(957, 297);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // radbankslip
            // 
            this.radbankslip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radbankslip.AutoSize = true;
            this.radbankslip.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.radbankslip.Location = new System.Drawing.Point(3, 41);
            this.radbankslip.Name = "radbankslip";
            this.radbankslip.Size = new System.Drawing.Size(68, 29);
            this.radbankslip.TabIndex = 8;
            this.radbankslip.TabStop = true;
            this.radbankslip.Text = "بنک سلف";
            this.radbankslip.UseVisualStyleBackColor = true;
            this.radbankslip.CheckedChanged += new System.EventHandler(this.radbankslip_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cmbtype);
            this.panel4.Controls.Add(this.dt2);
            this.panel4.Controls.Add(this.dt1);
            this.panel4.Location = new System.Drawing.Point(315, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(562, 69);
            this.panel4.TabIndex = 3;
            // 
            // dt1
            // 
            this.dt1.CustomFormat = "dd/mm/yyyy";
            this.dt1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(81, 34);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(130, 26);
            this.dt1.TabIndex = 0;
            // 
            // dt2
            // 
            this.dt2.CustomFormat = "dd/mm/yyyy";
            this.dt2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(224, 35);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(117, 26);
            this.dt2.TabIndex = 1;
            // 
            // cmbtype
            // 
            this.cmbtype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtype.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            " --انتخاب کریں--",
            "فرد",
            "انتقال"});
            this.cmbtype.Location = new System.Drawing.Point(355, 34);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(125, 27);
            this.cmbtype.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(488, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "رپورٹ قسم";
            // 
            // frmSDCBankreport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(967, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSDCBankreport";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmSDCBankreport";
            this.Load += new System.EventHandler(this.frmSDCBankreport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radsdc;
        private System.Windows.Forms.RadioButton radbank;
        private System.Windows.Forms.DateTimePicker t2;
        private System.Windows.Forms.DateTimePicker t1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radInti;
        private System.Windows.Forms.RadioButton radFard;
        private System.Windows.Forms.RadioButton radpass;
        private System.Windows.Forms.TextBox TxtKhatano;
        private System.Windows.Forms.TextBox txthiddnPersonName;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.Button btnBuyerSearch;
        private System.Windows.Forms.TextBox txthiddnPersonId;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radbankslip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.DateTimePicker dt1;
    }
}