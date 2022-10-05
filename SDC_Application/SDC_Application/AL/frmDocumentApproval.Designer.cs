namespace SDC_Application.AL
{
    partial class frmDocumentApproval
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.verificationControl1 = new DPFP.Gui.Verification.VerificationControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateExact = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cbdisAprove = new System.Windows.Forms.CheckBox();
            this.cbApprove = new System.Windows.Forms.CheckBox();
            this.cbprev = new System.Windows.Forms.CheckBox();
            this.btndisApprove = new System.Windows.Forms.Button();
            this.gridViewDocments = new System.Windows.Forms.DataGridView();
            this.gridcb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Verify = new System.Windows.Forms.DataGridViewLinkColumn();
            this.toolTipDocApp = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocments)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 64);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1161, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "تصدیق دستاویزات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 591);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1163, 64);
            this.panel2.TabIndex = 1;
            // 
            // btnApprove
            // 
            this.btnApprove.BackgroundImage = global::SDC_Application.Resource1.Accept;
            this.btnApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApprove.Location = new System.Drawing.Point(106, 7);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(85, 47);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // verificationControl1
            // 
            this.verificationControl1.Active = true;
            this.verificationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verificationControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verificationControl1.Location = new System.Drawing.Point(49, 32);
            this.verificationControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.verificationControl1.Name = "verificationControl1";
            this.verificationControl1.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.verificationControl1.Size = new System.Drawing.Size(55, 53);
            this.verificationControl1.TabIndex = 10;
            this.verificationControl1.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.verificationControl1_OnComplete);
            this.verificationControl1.Load += new System.EventHandler(this.verificationControl1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.verificationControl1);
            this.groupBox1.Controls.Add(this.dateExact);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.txtsearch);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.cbprev);
            this.groupBox1.Controls.Add(this.btndisApprove);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 490);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1163, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dateExact
            // 
            this.dateExact.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateExact.Location = new System.Drawing.Point(1011, 49);
            this.dateExact.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dateExact.Name = "dateExact";
            this.dateExact.Size = new System.Drawing.Size(104, 33);
            this.dateExact.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(942, 48);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 33);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "نام  /ٹوکن";
            // 
            // btnsearch
            // 
            this.btnsearch.BackgroundImage = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnsearch.Location = new System.Drawing.Point(771, 46);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 36);
            this.btnsearch.TabIndex = 5;
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsearch.Location = new System.Drawing.Point(818, 48);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(120, 33);
            this.txtsearch.TabIndex = 4;
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTo);
            this.panel3.Controls.Add(this.lblFrom);
            this.panel3.Controls.Add(this.dtpFrom);
            this.panel3.Controls.Add(this.dtpTo);
            this.panel3.Controls.Add(this.cbdisAprove);
            this.panel3.Controls.Add(this.cbApprove);
            this.panel3.Location = new System.Drawing.Point(235, 27);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 66);
            this.panel3.TabIndex = 3;
            this.panel3.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(20, 21);
            this.lblTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 25);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "تک";
            this.lblTo.Visible = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(137, 17);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(28, 25);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "سے";
            this.lblFrom.Visible = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(163, 17);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(75, 33);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.Visible = false;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(51, 17);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(75, 33);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.Visible = false;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // cbdisAprove
            // 
            this.cbdisAprove.AutoSize = true;
            this.cbdisAprove.Location = new System.Drawing.Point(241, 17);
            this.cbdisAprove.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbdisAprove.Name = "cbdisAprove";
            this.cbdisAprove.Size = new System.Drawing.Size(60, 29);
            this.cbdisAprove.TabIndex = 4;
            this.cbdisAprove.Text = "نا منظور";
            this.cbdisAprove.UseVisualStyleBackColor = true;
            this.cbdisAprove.Visible = false;
            this.cbdisAprove.CheckedChanged += new System.EventHandler(this.cbdisAprove_CheckedChanged);
            // 
            // cbApprove
            // 
            this.cbApprove.AutoSize = true;
            this.cbApprove.Location = new System.Drawing.Point(293, 17);
            this.cbApprove.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbApprove.Name = "cbApprove";
            this.cbApprove.Size = new System.Drawing.Size(53, 29);
            this.cbApprove.TabIndex = 3;
            this.cbApprove.Text = "منظور";
            this.cbApprove.UseVisualStyleBackColor = true;
            this.cbApprove.Visible = false;
            this.cbApprove.CheckedChanged += new System.EventHandler(this.cbApprove_CheckedChanged);
            // 
            // cbprev
            // 
            this.cbprev.AutoSize = true;
            this.cbprev.Location = new System.Drawing.Point(604, 46);
            this.cbprev.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbprev.Name = "cbprev";
            this.cbprev.Size = new System.Drawing.Size(108, 17);
            this.cbprev.TabIndex = 2;
            this.cbprev.Text = "گزشتہ دستاویزات";
            this.cbprev.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbprev.UseVisualStyleBackColor = true;
            this.cbprev.CheckedChanged += new System.EventHandler(this.cbprev_CheckedChanged);
            // 
            // btndisApprove
            // 
            this.btndisApprove.BackgroundImage = global::SDC_Application.Resource1.Reject;
            this.btndisApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndisApprove.Location = new System.Drawing.Point(116, 35);
            this.btndisApprove.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btndisApprove.Name = "btndisApprove";
            this.btndisApprove.Size = new System.Drawing.Size(89, 46);
            this.btndisApprove.TabIndex = 1;
            this.btndisApprove.UseVisualStyleBackColor = true;
            this.btndisApprove.Click += new System.EventHandler(this.btndisApprove_Click);
            // 
            // gridViewDocments
            // 
            this.gridViewDocments.AllowUserToAddRows = false;
            this.gridViewDocments.AllowUserToDeleteRows = false;
            this.gridViewDocments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewDocments.ColumnHeadersHeight = 33;
            this.gridViewDocments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridcb,
            this.Verify});
            this.gridViewDocments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewDocments.Location = new System.Drawing.Point(0, 64);
            this.gridViewDocments.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridViewDocments.Name = "gridViewDocments";
            this.gridViewDocments.RowTemplate.Height = 30;
            this.gridViewDocments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewDocments.Size = new System.Drawing.Size(1163, 426);
            this.gridViewDocments.TabIndex = 3;
            this.gridViewDocments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewDocments_CellContentClick);
            this.gridViewDocments.SelectionChanged += new System.EventHandler(this.gridViewDocments_SelectionChanged);
            // 
            // gridcb
            // 
            this.gridcb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gridcb.HeaderText = "";
            this.gridcb.Name = "gridcb";
            this.gridcb.Width = 50;
            // 
            // Verify
            // 
            this.Verify.HeaderText = "ویریفیکیشن";
            this.Verify.Name = "Verify";
            this.Verify.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Verify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Verify.Text = "تصدیق";
            this.Verify.UseColumnTextForLinkValue = true;
            // 
            // frmDocumentApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 655);
            this.Controls.Add(this.gridViewDocments);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "frmDocumentApproval";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تصدیق دستاویز";
            this.Load += new System.EventHandler(this.frmDocumentApproval_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridViewDocments;
        private System.Windows.Forms.Button btndisApprove;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.CheckBox cbprev;
        private System.Windows.Forms.CheckBox cbdisAprove;
        private System.Windows.Forms.CheckBox cbApprove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ToolTip toolTipDocApp;
        private System.Windows.Forms.DateTimePicker dateExact;
        private DPFP.Gui.Verification.VerificationControl verificationControl1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridcb;
        private System.Windows.Forms.DataGridViewLinkColumn Verify;
    }
}