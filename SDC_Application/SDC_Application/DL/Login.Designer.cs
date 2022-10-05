namespace SDC_Application.DL
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnSaveLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTehsil = new System.Windows.Forms.ComboBox();
            this.cmbDist = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "پاس ورڈ";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(21, 23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 29);
            this.txtUsername.TabIndex = 3;
            // 
            // btnSaveLogin
            // 
            this.btnSaveLogin.Image = global::SDC_Application.Resource1.unlock;
            this.btnSaveLogin.Location = new System.Drawing.Point(164, 119);
            this.btnSaveLogin.Name = "btnSaveLogin";
            this.btnSaveLogin.Size = new System.Drawing.Size(58, 58);
            this.btnSaveLogin.TabIndex = 5;
            this.btnSaveLogin.UseVisualStyleBackColor = true;
            this.btnSaveLogin.Click += new System.EventHandler(this.btnSaveLogin_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbTehsil);
            this.groupBox1.Controls.Add(this.cmbDist);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSaveLogin);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 189);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cmbTehsil
            // 
            this.cmbTehsil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTehsil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTehsil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTehsil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTehsil.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTehsil.FormattingEnabled = true;
            this.cmbTehsil.Location = new System.Drawing.Point(281, 71);
            this.cmbTehsil.Name = "cmbTehsil";
            this.cmbTehsil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTehsil.Size = new System.Drawing.Size(137, 27);
            this.cmbTehsil.TabIndex = 2;
            this.cmbTehsil.SelectionChangeCommitted += new System.EventHandler(this.cmbTehsil_SelectionChangeCommitted);
            this.cmbTehsil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMalikName_KeyPress);
            // 
            // cmbDist
            // 
            this.cmbDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDist.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDist.FormattingEnabled = true;
            this.cmbDist.Location = new System.Drawing.Point(281, 24);
            this.cmbDist.Name = "cmbDist";
            this.cmbDist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDist.Size = new System.Drawing.Size(137, 27);
            this.cmbDist.TabIndex = 1;
            this.cmbDist.SelectionChangeCommitted += new System.EventHandler(this.cmbDist_SelectionChangeCommitted);
            this.cmbDist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMalikName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(424, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "ضلع";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(424, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "تحصیل";
            // 
            // button2
            // 
            this.button2.Image = global::SDC_Application.Resource1.icon_refresh;
            this.button2.Location = new System.Drawing.Point(245, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 58);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(21, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(152, 29);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(179, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "صارف کا نام";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SDC_Application.Resource1.secrecy_icon1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 189);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لنڈ ریکارڈ منجمنٹ انفارمیشن سستم";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSaveLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTehsil;
        private System.Windows.Forms.ComboBox cmbDist;
    }
}