namespace SDC_Application.AL
{
    partial class frmRegRecFromIntiqal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbSR = new System.Windows.Forms.ComboBox();
            this.btnRegNew = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSeller = new System.Windows.Forms.TextBox();
            this.txtRegId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtJildNo = new System.Windows.Forms.TextBox();
            this.btnRegSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKafiyat = new System.Windows.Forms.TextBox();
            this.dtReg = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRegMoza = new System.Windows.Forms.ComboBox();
            this.grdvReg = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvReg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 504);
            this.panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.grdvReg);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.cmbSR);
            this.groupBox5.Controls.Add(this.btnRegNew);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.txtBuyer);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.txtSeller);
            this.groupBox5.Controls.Add(this.txtRegId);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtJildNo);
            this.groupBox5.Controls.Add(this.btnRegSave);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txtKafiyat);
            this.groupBox5.Controls.Add(this.dtReg);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtRegNo);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cmbRegMoza);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1105, 504);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "تفصیل رجسٹری";
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(511, 35);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(88, 38);
            this.label40.TabIndex = 72;
            this.label40.Text = "سب رجسٹرار";
            // 
            // cmbSR
            // 
            this.cmbSR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSR.FormattingEnabled = true;
            this.cmbSR.Location = new System.Drawing.Point(419, 70);
            this.cmbSR.Name = "cmbSR";
            this.cmbSR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSR.Size = new System.Drawing.Size(146, 34);
            this.cmbSR.TabIndex = 4;
            this.cmbSR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // btnRegNew
            // 
            this.btnRegNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegNew.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnRegNew.Location = new System.Drawing.Point(129, 124);
            this.btnRegNew.Name = "btnRegNew";
            this.btnRegNew.Size = new System.Drawing.Size(53, 48);
            this.btnRegNew.TabIndex = 9;
            this.btnRegNew.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(189, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 38);
            this.label24.TabIndex = 69;
            this.label24.Text = "مشتری";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyer.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyer.Location = new System.Drawing.Point(32, 70);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(191, 45);
            this.txtBuyer.TabIndex = 6;
            this.txtBuyer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(389, 35);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 38);
            this.label23.TabIndex = 67;
            this.label23.Text = " بائع";
            // 
            // txtSeller
            // 
            this.txtSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeller.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeller.Location = new System.Drawing.Point(229, 69);
            this.txtSeller.Name = "txtSeller";
            this.txtSeller.Size = new System.Drawing.Size(184, 45);
            this.txtSeller.TabIndex = 5;
            this.txtSeller.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // txtRegId
            // 
            this.txtRegId.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegId.Location = new System.Drawing.Point(17, 80);
            this.txtRegId.Name = "txtRegId";
            this.txtRegId.Size = new System.Drawing.Size(88, 28);
            this.txtRegId.TabIndex = 65;
            this.txtRegId.Text = "-1";
            this.txtRegId.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(747, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 38);
            this.label12.TabIndex = 64;
            this.label12.Text = "جلد نمبر";
            // 
            // txtJildNo
            // 
            this.txtJildNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJildNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJildNo.Location = new System.Drawing.Point(703, 70);
            this.txtJildNo.Name = "txtJildNo";
            this.txtJildNo.Size = new System.Drawing.Size(81, 35);
            this.txtJildNo.TabIndex = 2;
            // 
            // btnRegSave
            // 
            this.btnRegSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnRegSave.Location = new System.Drawing.Point(198, 124);
            this.btnRegSave.Name = "btnRegSave";
            this.btnRegSave.Size = new System.Drawing.Size(53, 48);
            this.btnRegSave.TabIndex = 8;
            this.btnRegSave.UseVisualStyleBackColor = true;
            this.btnRegSave.Click += new System.EventHandler(this.btnRegSave_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1033, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 38);
            this.label14.TabIndex = 61;
            this.label14.Text = "کیفیت";
            // 
            // txtKafiyat
            // 
            this.txtKafiyat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKafiyat.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKafiyat.Location = new System.Drawing.Point(366, 117);
            this.txtKafiyat.Multiline = true;
            this.txtKafiyat.Name = "txtKafiyat";
            this.txtKafiyat.Size = new System.Drawing.Size(651, 64);
            this.txtKafiyat.TabIndex = 7;
            this.txtKafiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // dtReg
            // 
            this.dtReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtReg.CustomFormat = "dd-MM-yyyy";
            this.dtReg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReg.Location = new System.Drawing.Point(571, 70);
            this.dtReg.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtReg.Name = "dtReg";
            this.dtReg.Size = new System.Drawing.Size(126, 35);
            this.dtReg.TabIndex = 3;
            this.dtReg.Tag = "3";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(638, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 38);
            this.label11.TabIndex = 55;
            this.label11.Text = "تاریخ رجسٹری";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(837, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 38);
            this.label10.TabIndex = 53;
            this.label10.Text = " رجسٹری نمبر";
            // 
            // txtRegNo
            // 
            this.txtRegNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegNo.Location = new System.Drawing.Point(790, 70);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(101, 35);
            this.txtRegNo.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1010, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 38);
            this.label9.TabIndex = 51;
            this.label9.Text = "موضع";
            // 
            // cmbRegMoza
            // 
            this.cmbRegMoza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegMoza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRegMoza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRegMoza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRegMoza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegMoza.FormattingEnabled = true;
            this.cmbRegMoza.Location = new System.Drawing.Point(897, 69);
            this.cmbRegMoza.Name = "cmbRegMoza";
            this.cmbRegMoza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbRegMoza.Size = new System.Drawing.Size(146, 34);
            this.cmbRegMoza.TabIndex = 0;
            this.cmbRegMoza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvertLang_KeyPress);
            // 
            // grdvReg
            // 
            this.grdvReg.AllowUserToAddRows = false;
            this.grdvReg.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdvReg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdvReg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdvReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvReg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdvReg.Location = new System.Drawing.Point(3, 207);
            this.grdvReg.MultiSelect = false;
            this.grdvReg.Name = "grdvReg";
            this.grdvReg.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvReg.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdvReg.RowTemplate.Height = 40;
            this.grdvReg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdvReg.Size = new System.Drawing.Size(1099, 294);
            this.grdvReg.TabIndex = 73;
            this.grdvReg.TabStop = false;
            // 
            // frmRegRecFromIntiqal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 504);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegRecFromIntiqal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رجسٹری وصول";
            this.Load += new System.EventHandler(this.frmRegRecFromIntiqal_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvReg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbSR;
        private System.Windows.Forms.Button btnRegNew;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSeller;
        private System.Windows.Forms.TextBox txtRegId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtJildNo;
        private System.Windows.Forms.Button btnRegSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKafiyat;
        private System.Windows.Forms.DateTimePicker dtReg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRegNo;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRegMoza;
        private System.Windows.Forms.DataGridView grdvReg;

    }
}