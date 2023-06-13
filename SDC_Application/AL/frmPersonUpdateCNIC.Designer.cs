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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCnic = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgKhatajat = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhatajat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtCnic);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPersonName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(945, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نام مالک و اندراج شناختی کارڈ نمبر";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgKhatajat);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 114);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(945, 419);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مالک کھاتہ جات";
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "شناختی کارڈ نمبر";
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(218, 39);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 48);
            this.btnSave.TabIndex = 201;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.dgKhatajat.Size = new System.Drawing.Size(925, 367);
            this.dgKhatajat.TabIndex = 0;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgKhatajat;
        public System.Windows.Forms.Label lblPersonName;

    }
}