namespace SDC_Application.AL
{
    partial class frmUserChangePassword
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtGetOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserOldPassword = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txtUserConfPassword = new System.Windows.Forms.TextBox();
            this.txtUserNewPassword = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStrength = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(1190, 53);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Management";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1190, 681);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 660);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Change Password";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblStrength);
            this.groupBox5.Controls.Add(this.txtGetOldPassword);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtUserLoginName);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtUserOldPassword);
            this.groupBox5.Controls.Add(this.txtUserId);
            this.groupBox5.Controls.Add(this.btnSaveUser);
            this.groupBox5.Controls.Add(this.lbl5);
            this.groupBox5.Controls.Add(this.lbl4);
            this.groupBox5.Controls.Add(this.txtUserConfPassword);
            this.groupBox5.Controls.Add(this.txtUserNewPassword);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(668, 338);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // txtGetOldPassword
            // 
            this.txtGetOldPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGetOldPassword.Location = new System.Drawing.Point(72, 211);
            this.txtGetOldPassword.Name = "txtGetOldPassword";
            this.txtGetOldPassword.Size = new System.Drawing.Size(86, 30);
            this.txtGetOldPassword.TabIndex = 51;
            this.txtGetOldPassword.Text = "-1";
            this.txtGetOldPassword.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 48;
            this.label4.Text = "Login Id";
            // 
            // txtUserLoginName
            // 
            this.txtUserLoginName.Enabled = false;
            this.txtUserLoginName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLoginName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtUserLoginName.Location = new System.Drawing.Point(200, 37);
            this.txtUserLoginName.Name = "txtUserLoginName";
            this.txtUserLoginName.Size = new System.Drawing.Size(253, 30);
            this.txtUserLoginName.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 22);
            this.label2.TabIndex = 46;
            this.label2.Text = "Old Password:";
            // 
            // txtUserOldPassword
            // 
            this.txtUserOldPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserOldPassword.Location = new System.Drawing.Point(200, 76);
            this.txtUserOldPassword.Name = "txtUserOldPassword";
            this.txtUserOldPassword.PasswordChar = '*';
            this.txtUserOldPassword.Size = new System.Drawing.Size(253, 30);
            this.txtUserOldPassword.TabIndex = 1;
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Location = new System.Drawing.Point(73, 243);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(86, 30);
            this.txtUserId.TabIndex = 43;
            this.txtUserId.Text = "-1";
            this.txtUserId.Visible = false;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveUser.Location = new System.Drawing.Point(219, 219);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(54, 50);
            this.btnSaveUser.TabIndex = 4;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(66, 159);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(164, 22);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "Confirm Password:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(69, 118);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(137, 22);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "New Password:";
            // 
            // txtUserConfPassword
            // 
            this.txtUserConfPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserConfPassword.Location = new System.Drawing.Point(200, 154);
            this.txtUserConfPassword.Name = "txtUserConfPassword";
            this.txtUserConfPassword.PasswordChar = '*';
            this.txtUserConfPassword.Size = new System.Drawing.Size(253, 30);
            this.txtUserConfPassword.TabIndex = 3;
            this.txtUserConfPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserConfPassword_KeyDown);
            // 
            // txtUserNewPassword
            // 
            this.txtUserNewPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNewPassword.Location = new System.Drawing.Point(200, 115);
            this.txtUserNewPassword.Name = "txtUserNewPassword";
            this.txtUserNewPassword.PasswordChar = '*';
            this.txtUserNewPassword.Size = new System.Drawing.Size(253, 30);
            this.txtUserNewPassword.TabIndex = 2;
            this.txtUserNewPassword.TextChanged += new System.EventHandler(this.txtUserNewPassword_TextChanged);
            this.txtUserNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserNewPassword_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 692);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1190, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(469, 124);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(10, 16);
            this.lblStrength.TabIndex = 52;
            this.lblStrength.Text = ".";
            // 
            // frmUserChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1190, 734);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp);
            this.Name = "frmUserChangePassword";
            this.Text = "Users Management - Change Password";
            this.Load += new System.EventHandler(this.frmUserChangePassword_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtUserConfPassword;
        private System.Windows.Forms.TextBox txtUserNewPassword;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserOldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserLoginName;
        private System.Windows.Forms.TextBox txtGetOldPassword;
        private System.Windows.Forms.Label lblStrength;
    }
}