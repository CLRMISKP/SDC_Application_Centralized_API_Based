namespace SDC_Application.AL
{
    partial class frmInteqalWitness
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GridWitnessDetails = new System.Windows.Forms.DataGridView();
            this.colChooseWitness = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelWitness = new System.Windows.Forms.Button();
            this.btnSaveWitness = new System.Windows.Forms.Button();
            this.btnNewWitness = new System.Windows.Forms.Button();
            this.txtWitnessPersonId = new System.Windows.Forms.TextBox();
            this.txtWitnessId = new System.Windows.Forms.TextBox();
            this.txtPersonId = new System.Windows.Forms.TextBox();
            this.txtWittnessPersonName = new System.Windows.Forms.TextBox();
            this.txtWitnessFatherName = new System.Windows.Forms.TextBox();
            this.txtWitnessCNIC = new System.Windows.Forms.TextBox();
            this.txtWitnessAddress = new System.Windows.Forms.TextBox();
            this.chkWitnessFemale = new System.Windows.Forms.RadioButton();
            this.chkWitnessMale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchByNIC = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridWitnessDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1132, 359);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "گواہان انتقال";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GridWitnessDetails);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(10, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1112, 235);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // GridWitnessDetails
            // 
            this.GridWitnessDetails.AllowUserToAddRows = false;
            this.GridWitnessDetails.AllowUserToDeleteRows = false;
            this.GridWitnessDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridWitnessDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridWitnessDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChooseWitness});
            this.GridWitnessDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridWitnessDetails.Location = new System.Drawing.Point(3, 33);
            this.GridWitnessDetails.Name = "GridWitnessDetails";
            this.GridWitnessDetails.ReadOnly = true;
            this.GridWitnessDetails.RowHeadersVisible = false;
            this.GridWitnessDetails.RowTemplate.Height = 30;
            this.GridWitnessDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridWitnessDetails.Size = new System.Drawing.Size(1106, 199);
            this.GridWitnessDetails.TabIndex = 0;
            this.GridWitnessDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridWitnessDetails_CellClick);
            // 
            // colChooseWitness
            // 
            this.colChooseWitness.HeaderText = "انتخاب کریں";
            this.colChooseWitness.Name = "colChooseWitness";
            this.colChooseWitness.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelWitness);
            this.groupBox3.Controls.Add(this.btnSaveWitness);
            this.groupBox3.Controls.Add(this.btnNewWitness);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(10, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(1112, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnDelWitness
            // 
            this.btnDelWitness.Enabled = false;
            this.btnDelWitness.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelWitness.Image = global::SDC_Application.Resource1.edit_delete1;
            this.btnDelWitness.Location = new System.Drawing.Point(490, 22);
            this.btnDelWitness.Name = "btnDelWitness";
            this.btnDelWitness.Size = new System.Drawing.Size(50, 52);
            this.btnDelWitness.TabIndex = 2;
            this.btnDelWitness.UseVisualStyleBackColor = true;
            this.btnDelWitness.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSaveWitness
            // 
            this.btnSaveWitness.Enabled = false;
            this.btnSaveWitness.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWitness.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveWitness.Location = new System.Drawing.Point(556, 22);
            this.btnSaveWitness.Name = "btnSaveWitness";
            this.btnSaveWitness.Size = new System.Drawing.Size(50, 52);
            this.btnSaveWitness.TabIndex = 1;
            this.btnSaveWitness.UseVisualStyleBackColor = true;
            this.btnSaveWitness.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewWitness
            // 
            this.btnNewWitness.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewWitness.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewWitness.Location = new System.Drawing.Point(615, 22);
            this.btnNewWitness.Name = "btnNewWitness";
            this.btnNewWitness.Size = new System.Drawing.Size(50, 52);
            this.btnNewWitness.TabIndex = 0;
            this.btnNewWitness.UseVisualStyleBackColor = true;
            this.btnNewWitness.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtWitnessPersonId
            // 
            this.txtWitnessPersonId.Location = new System.Drawing.Point(1077, 84);
            this.txtWitnessPersonId.Name = "txtWitnessPersonId";
            this.txtWitnessPersonId.Size = new System.Drawing.Size(55, 20);
            this.txtWitnessPersonId.TabIndex = 12;
            this.txtWitnessPersonId.Text = "-1";
            this.txtWitnessPersonId.Visible = false;
            // 
            // txtWitnessId
            // 
            this.txtWitnessId.Location = new System.Drawing.Point(1077, 110);
            this.txtWitnessId.Name = "txtWitnessId";
            this.txtWitnessId.Size = new System.Drawing.Size(55, 20);
            this.txtWitnessId.TabIndex = 10;
            this.txtWitnessId.Text = "-1";
            this.txtWitnessId.Visible = false;
            // 
            // txtPersonId
            // 
            this.txtPersonId.Location = new System.Drawing.Point(1077, 109);
            this.txtPersonId.Name = "txtPersonId";
            this.txtPersonId.Size = new System.Drawing.Size(55, 20);
            this.txtPersonId.TabIndex = 11;
            this.txtPersonId.Text = "-1";
            this.txtPersonId.Visible = false;
            // 
            // txtWittnessPersonName
            // 
            this.txtWittnessPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWittnessPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWittnessPersonName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWittnessPersonName.Location = new System.Drawing.Point(901, 27);
            this.txtWittnessPersonName.Name = "txtWittnessPersonName";
            this.txtWittnessPersonName.Size = new System.Drawing.Size(165, 37);
            this.txtWittnessPersonName.TabIndex = 0;
            this.txtWittnessPersonName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWitnessFatherName_KeyPress);
            // 
            // txtWitnessFatherName
            // 
            this.txtWitnessFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWitnessFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWitnessFatherName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWitnessFatherName.Location = new System.Drawing.Point(660, 27);
            this.txtWitnessFatherName.Name = "txtWitnessFatherName";
            this.txtWitnessFatherName.Size = new System.Drawing.Size(165, 37);
            this.txtWitnessFatherName.TabIndex = 1;
            this.txtWitnessFatherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWitnessFatherName_KeyPress);
            // 
            // txtWitnessCNIC
            // 
            this.txtWitnessCNIC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWitnessCNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWitnessCNIC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWitnessCNIC.Location = new System.Drawing.Point(404, 32);
            this.txtWitnessCNIC.MaxLength = 13;
            this.txtWitnessCNIC.Name = "txtWitnessCNIC";
            this.txtWitnessCNIC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWitnessCNIC.Size = new System.Drawing.Size(165, 26);
            this.txtWitnessCNIC.TabIndex = 2;
            this.txtWitnessCNIC.TextChanged += new System.EventHandler(this.txtCNIC_TextChanged);
            this.txtWitnessCNIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNIC_KeyPress);
            this.txtWitnessCNIC.Leave += new System.EventHandler(this.txtWitnessCNIC_Leave);
            // 
            // txtWitnessAddress
            // 
            this.txtWitnessAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWitnessAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWitnessAddress.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWitnessAddress.Location = new System.Drawing.Point(11, 27);
            this.txtWitnessAddress.Name = "txtWitnessAddress";
            this.txtWitnessAddress.Size = new System.Drawing.Size(165, 37);
            this.txtWitnessAddress.TabIndex = 3;
            this.txtWitnessAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdress_KeyPress);
            // 
            // chkWitnessFemale
            // 
            this.chkWitnessFemale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWitnessFemale.AutoSize = true;
            this.chkWitnessFemale.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWitnessFemale.Location = new System.Drawing.Point(225, 26);
            this.chkWitnessFemale.Name = "chkWitnessFemale";
            this.chkWitnessFemale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkWitnessFemale.Size = new System.Drawing.Size(63, 34);
            this.chkWitnessFemale.TabIndex = 4;
            this.chkWitnessFemale.Text = "عورت";
            this.chkWitnessFemale.UseVisualStyleBackColor = true;
            // 
            // chkWitnessMale
            // 
            this.chkWitnessMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWitnessMale.AutoSize = true;
            this.chkWitnessMale.Checked = true;
            this.chkWitnessMale.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWitnessMale.Location = new System.Drawing.Point(290, 26);
            this.chkWitnessMale.Name = "chkWitnessMale";
            this.chkWitnessMale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkWitnessMale.Size = new System.Drawing.Size(48, 34);
            this.chkWitnessMale.TabIndex = 5;
            this.chkWitnessMale.TabStop = true;
            this.chkWitnessMale.Text = "مرد";
            this.chkWitnessMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "پتہ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(576, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "شناختی کارڈ نمبر";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(831, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "ولدیت";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(565, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "تفصیل گواہان";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1071, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "نام";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtWitnessPersonId);
            this.groupBox1.Controls.Add(this.txtWitnessId);
            this.groupBox1.Controls.Add(this.txtPersonId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1132, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSearchByNIC);
            this.groupBox5.Controls.Add(this.txtWitnessAddress);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtWitnessCNIC);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtWitnessFatherName);
            this.groupBox5.Controls.Add(this.txtWittnessPersonName);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.chkWitnessFemale);
            this.groupBox5.Controls.Add(this.chkWitnessMale);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(10, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1112, 80);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(10, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 52);
            this.panel1.TabIndex = 13;
            // 
            // btnSearchByNIC
            // 
            this.btnSearchByNIC.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByNIC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchByNIC.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchByNIC.Location = new System.Drawing.Point(356, 32);
            this.btnSearchByNIC.Name = "btnSearchByNIC";
            this.btnSearchByNIC.Size = new System.Drawing.Size(37, 25);
            this.btnSearchByNIC.TabIndex = 44;
            this.btnSearchByNIC.UseVisualStyleBackColor = true;
            this.btnSearchByNIC.Click += new System.EventHandler(this.btnSearchByNIC_Click);
            // 
            // frmInteqalWitness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmInteqalWitness";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "گواہان انتقال";
            this.Load += new System.EventHandler(this.frmInteqalWitness_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridWitnessDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridWitnessDetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDelWitness;
        private System.Windows.Forms.Button btnSaveWitness;
        private System.Windows.Forms.Button btnNewWitness;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChooseWitness;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWitnessPersonId;
        private System.Windows.Forms.TextBox txtWitnessId;
        private System.Windows.Forms.TextBox txtPersonId;
        private System.Windows.Forms.TextBox txtWittnessPersonName;
        private System.Windows.Forms.TextBox txtWitnessFatherName;
        private System.Windows.Forms.TextBox txtWitnessAddress;
        private System.Windows.Forms.RadioButton chkWitnessFemale;
        private System.Windows.Forms.RadioButton chkWitnessMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtWitnessCNIC;
        private System.Windows.Forms.Button btnSearchByNIC;
    }
}