namespace SDC_Application.AL
{
    partial class frmIntiqalTaxes
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtRaqba = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTaxReceipt = new System.Windows.Forms.Button();
            this.txtRateInPercentage = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.hdntxtInteqalID = new System.Windows.Forms.TextBox();
            this.hdntxtNotificationDetailID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdNotificationdetails = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotificationdetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnUpdate.Location = new System.Drawing.Point(394, 26);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 48);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtRaqba
            // 
            this.txtRaqba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaqba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRaqba.Location = new System.Drawing.Point(635, 38);
            this.txtRaqba.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRaqba.Name = "txtRaqba";
            this.txtRaqba.Size = new System.Drawing.Size(96, 33);
            this.txtRaqba.TabIndex = 1;
            this.txtRaqba.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRaqba_KeyPress);
            this.txtRaqba.Leave += new System.EventHandler(this.txtRaqba_Leave);
            // 
            // txtRate
            // 
            this.txtRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRate.Location = new System.Drawing.Point(832, 39);
            this.txtRate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(96, 33);
            this.txtRate.TabIndex = 0;
            this.txtRate.Visible = false;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTaxReceipt);
            this.groupBox3.Controls.Add(this.txtRateInPercentage);
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnLoad);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.txtRate);
            this.groupBox3.Controls.Add(this.txtRaqba);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 36);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(1103, 82);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnTaxReceipt
            // 
            this.btnTaxReceipt.BackgroundImage = global::SDC_Application.Resource1.TaxRes;
            this.btnTaxReceipt.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F);
            this.btnTaxReceipt.Location = new System.Drawing.Point(190, 26);
            this.btnTaxReceipt.Name = "btnTaxReceipt";
            this.btnTaxReceipt.Size = new System.Drawing.Size(50, 48);
            this.btnTaxReceipt.TabIndex = 10;
            this.btnTaxReceipt.UseVisualStyleBackColor = true;
            this.btnTaxReceipt.Click += new System.EventHandler(this.btnTaxReceipt_Click);
            // 
            // txtRateInPercentage
            // 
            this.txtRateInPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRateInPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRateInPercentage.Enabled = false;
            this.txtRateInPercentage.Location = new System.Drawing.Point(832, 38);
            this.txtRateInPercentage.Name = "txtRateInPercentage";
            this.txtRateInPercentage.Size = new System.Drawing.Size(100, 33);
            this.txtRateInPercentage.TabIndex = 9;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDel.Location = new System.Drawing.Point(260, 26);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 48);
            this.btnDel.TabIndex = 8;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnLoad.Location = new System.Drawing.Point(328, 26);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(50, 48);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(582, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "کل رقم";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(751, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "رقبہ/قیمت";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(948, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "ریٹ";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(466, 39);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(96, 33);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // hdntxtInteqalID
            // 
            this.hdntxtInteqalID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hdntxtInteqalID.Location = new System.Drawing.Point(12, 467);
            this.hdntxtInteqalID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.hdntxtInteqalID.Name = "hdntxtInteqalID";
            this.hdntxtInteqalID.Size = new System.Drawing.Size(110, 33);
            this.hdntxtInteqalID.TabIndex = 9;
            this.hdntxtInteqalID.Visible = false;
            // 
            // hdntxtNotificationDetailID
            // 
            this.hdntxtNotificationDetailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hdntxtNotificationDetailID.Location = new System.Drawing.Point(128, 467);
            this.hdntxtNotificationDetailID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.hdntxtNotificationDetailID.Name = "hdntxtNotificationDetailID";
            this.hdntxtNotificationDetailID.Size = new System.Drawing.Size(110, 33);
            this.hdntxtNotificationDetailID.TabIndex = 10;
            this.hdntxtNotificationDetailID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 49);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1103, 36);
            this.panel2.TabIndex = 12;
            // 
            // grdNotificationdetails
            // 
            this.grdNotificationdetails.AllowUserToAddRows = false;
            this.grdNotificationdetails.AllowUserToDeleteRows = false;
            this.grdNotificationdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNotificationdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.grdNotificationdetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNotificationdetails.Location = new System.Drawing.Point(0, 118);
            this.grdNotificationdetails.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdNotificationdetails.Name = "grdNotificationdetails";
            this.grdNotificationdetails.ReadOnly = true;
            this.grdNotificationdetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNotificationdetails.RowTemplate.Height = 30;
            this.grdNotificationdetails.Size = new System.Drawing.Size(1103, 295);
            this.grdNotificationdetails.TabIndex = 0;
            this.grdNotificationdetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdNotificationdetails_CellClick);
            this.grdNotificationdetails.DoubleClick += new System.EventHandler(this.grdNotificationdetails_DoubleClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "انتخاب کریں";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            // 
            // frmIntiqalTaxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 462);
            this.Controls.Add(this.grdNotificationdetails);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hdntxtNotificationDetailID);
            this.Controls.Add(this.hdntxtInteqalID);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmIntiqalTaxes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتقال ٹیکس";
            this.Load += new System.EventHandler(this.frmIntiqalTaxes_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotificationdetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtRaqba;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox hdntxtInteqalID;
        private System.Windows.Forms.TextBox hdntxtNotificationDetailID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grdNotificationdetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtRateInPercentage;
        private System.Windows.Forms.Button btnTaxReceipt;
    }
}