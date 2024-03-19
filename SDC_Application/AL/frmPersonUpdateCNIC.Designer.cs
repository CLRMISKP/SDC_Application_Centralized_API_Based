namespace SDC_Application.AL
{
    partial class frmPersonUpdateCNIC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCnic = new System.Windows.Forms.TextBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgKhatajat = new System.Windows.Forms.DataGridView();
            this.txtChkPassport = new System.Windows.Forms.CheckBox();
            this.txtPassportNo = new System.Windows.Forms.TextBox();
            this.lblPassportNo = new System.Windows.Forms.Label();
            this.txtPassportContry = new System.Windows.Forms.TextBox();
            this.lblPassportCont = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhatajat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassportContry);
            this.groupBox1.Controls.Add(this.lblPassportCont);
            this.groupBox1.Controls.Add(this.txtPassportNo);
            this.groupBox1.Controls.Add(this.lblPassportNo);
            this.groupBox1.Controls.Add(this.txtChkPassport);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtCnic);
            this.groupBox1.Controls.Add(this.lblCNIC);
            this.groupBox1.Controls.Add(this.lblPersonName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(945, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نام مالک و اندراج شناختی کارڈ نمبر";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(212, 40);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 48);
            this.btnSave.TabIndex = 5;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCnic
            // 
            this.txtCnic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnic.Location = new System.Drawing.Point(286, 44);
            this.txtCnic.MaxLength = 13;
            this.txtCnic.Name = "txtCnic";
            this.txtCnic.Size = new System.Drawing.Size(199, 39);
            this.txtCnic.TabIndex = 2;
            this.txtCnic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnic_KeyPress);
            // 
            // lblCNIC
            // 
            this.lblCNIC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCNIC.AutoSize = true;
            this.lblCNIC.Location = new System.Drawing.Point(491, 48);
            this.lblCNIC.Name = "lblCNIC";
            this.lblCNIC.Size = new System.Drawing.Size(81, 31);
            this.lblCNIC.TabIndex = 1;
            this.lblCNIC.Text = "شناختی کارڈ نمبر";
            // 
            // lblPersonName
            // 
            this.lblPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Alvi Nastaleeq", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.Location = new System.Drawing.Point(668, 42);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(42, 43);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "نام";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgKhatajat);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 147);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(945, 386);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مالک کھاتہ جات";
            // 
            // dgKhatajat
            // 
            this.dgKhatajat.AllowUserToAddRows = false;
            this.dgKhatajat.AllowUserToDeleteRows = false;
            this.dgKhatajat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKhatajat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhatajat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhatajat.Location = new System.Drawing.Point(10, 42);
            this.dgKhatajat.Name = "dgKhatajat";
            this.dgKhatajat.ReadOnly = true;
            this.dgKhatajat.RowHeadersVisible = false;
            this.dgKhatajat.RowTemplate.Height = 24;
            this.dgKhatajat.Size = new System.Drawing.Size(925, 334);
            this.dgKhatajat.TabIndex = 0;
            this.dgKhatajat.TabStop = false;
            // 
            // txtChkPassport
            // 
            this.txtChkPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChkPassport.AutoSize = true;
            this.txtChkPassport.Location = new System.Drawing.Point(825, 98);
            this.txtChkPassport.Name = "txtChkPassport";
            this.txtChkPassport.Size = new System.Drawing.Size(101, 35);
            this.txtChkPassport.TabIndex = 202;
            this.txtChkPassport.Text = "پاسپورٹ نمبر";
            this.txtChkPassport.UseVisualStyleBackColor = true;
            this.txtChkPassport.CheckedChanged += new System.EventHandler(this.txtChkPassport_CheckedChanged);
            // 
            // txtPassportNo
            // 
            this.txtPassportNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassportNo.Location = new System.Drawing.Point(286, 98);
            this.txtPassportNo.MaxLength = 13;
            this.txtPassportNo.Name = "txtPassportNo";
            this.txtPassportNo.Size = new System.Drawing.Size(199, 39);
            this.txtPassportNo.TabIndex = 4;
            this.tt.SetToolTip(this.txtPassportNo, "پاسپورٹ نمبر کی صرف نمبرات کا اندراج کرِیں۔ حروف تہجی درج نا کریں");
            this.txtPassportNo.Visible = false;
            this.txtPassportNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnic_KeyPress);
            // 
            // lblPassportNo
            // 
            this.lblPassportNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassportNo.AutoSize = true;
            this.lblPassportNo.Location = new System.Drawing.Point(491, 102);
            this.lblPassportNo.Name = "lblPassportNo";
            this.lblPassportNo.Size = new System.Drawing.Size(79, 31);
            this.lblPassportNo.TabIndex = 203;
            this.lblPassportNo.Text = "پاسپورٹ نمبر";
            this.lblPassportNo.Visible = false;
            // 
            // txtPassportContry
            // 
            this.txtPassportContry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassportContry.Location = new System.Drawing.Point(578, 98);
            this.txtPassportContry.MaxLength = 13;
            this.txtPassportContry.Name = "txtPassportContry";
            this.txtPassportContry.Size = new System.Drawing.Size(154, 39);
            this.txtPassportContry.TabIndex = 3;
            this.tt.SetToolTip(this.txtPassportContry, "پاسپورٹ جاری کنندہ ملک کی نام کی اندراج کریں");
            this.txtPassportContry.Visible = false;
            this.txtPassportContry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassportContry_KeyPress);
            // 
            // lblPassportCont
            // 
            this.lblPassportCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassportCont.AutoSize = true;
            this.lblPassportCont.Location = new System.Drawing.Point(738, 102);
            this.lblPassportCont.Name = "lblPassportCont";
            this.lblPassportCont.Size = new System.Drawing.Size(90, 31);
            this.lblPassportCont.TabIndex = 205;
            this.lblPassportCont.Text = "جاری کنندہ ملک";
            this.lblPassportCont.Visible = false;
            // 
            // frmPersonUpdateCNIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 538);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.Name = "frmPersonUpdateCNIC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "اندراج شناختی کارڈ نمبر";
            this.Load += new System.EventHandler(this.frmPersonUpdateCNIC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhatajat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCnic;
        private System.Windows.Forms.Label lblCNIC;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgKhatajat;
        public System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.CheckBox txtChkPassport;
        private System.Windows.Forms.TextBox txtPassportContry;
        private System.Windows.Forms.Label lblPassportCont;
        private System.Windows.Forms.TextBox txtPassportNo;
        private System.Windows.Forms.Label lblPassportNo;
        private System.Windows.Forms.ToolTip tt;

    }
}