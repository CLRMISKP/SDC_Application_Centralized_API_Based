namespace SDC_Application.AL
{
    partial class frmSystemRegistration
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
            this.cmbTehsil = new System.Windows.Forms.ComboBox();
            this.cmdDistrict = new System.Windows.Forms.ComboBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.macList = new System.Windows.Forms.ListBox();
            this.ipList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbTehsil
            // 
            this.cmbTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTehsil.Enabled = false;
            this.cmbTehsil.FormattingEnabled = true;
            this.cmbTehsil.Location = new System.Drawing.Point(241, 244);
            this.cmbTehsil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTehsil.Name = "cmbTehsil";
            this.cmbTehsil.Size = new System.Drawing.Size(571, 24);
            this.cmbTehsil.TabIndex = 3;
            this.cmbTehsil.SelectedIndexChanged += new System.EventHandler(this.cmbTehsil_SelectedIndexChanged);
            this.cmbTehsil.SelectionChangeCommitted += new System.EventHandler(this.cmbTehsil_SelectionChangeCommitted);
            // 
            // cmdDistrict
            // 
            this.cmdDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDistrict.Enabled = false;
            this.cmdDistrict.FormattingEnabled = true;
            this.cmdDistrict.Location = new System.Drawing.Point(241, 198);
            this.cmdDistrict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDistrict.Name = "cmdDistrict";
            this.cmdDistrict.Size = new System.Drawing.Size(571, 24);
            this.cmdDistrict.TabIndex = 2;
            this.cmdDistrict.SelectedIndexChanged += new System.EventHandler(this.cmdDistrict_SelectedIndexChanged);
            this.cmdDistrict.SelectionChangeCommitted += new System.EventHandler(this.cmdDistrict_SelectionChangeCommitted);
            // 
            // txtMachineName
            // 
            this.txtMachineName.Enabled = false;
            this.txtMachineName.Location = new System.Drawing.Point(241, 340);
            this.txtMachineName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(571, 22);
            this.txtMachineName.TabIndex = 7;
            // 
            // macList
            // 
            this.macList.FormattingEnabled = true;
            this.macList.ItemHeight = 16;
            this.macList.Location = new System.Drawing.Point(241, 386);
            this.macList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.macList.Name = "macList";
            this.macList.Size = new System.Drawing.Size(571, 116);
            this.macList.TabIndex = 8;
            // 
            // ipList
            // 
            this.ipList.FormattingEnabled = true;
            this.ipList.ItemHeight = 16;
            this.ipList.Location = new System.Drawing.Point(241, 519);
            this.ipList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipList.Name = "ipList";
            this.ipList.Size = new System.Drawing.Size(571, 116);
            this.ipList.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(565, 665);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(243, 28);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add System";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(243, 100);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(571, 22);
            this.txtPass.TabIndex = 1;
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(243, 59);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(571, 22);
            this.txtUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "District";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tehsil";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 346);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Machine";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 388);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mac Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 519);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "IP Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 137);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Verify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 297);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Counter";
            // 
            // cboCounter
            // 
            this.cboCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboCounter.Location = new System.Drawing.Point(241, 290);
            this.cboCounter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(571, 24);
            this.cboCounter.TabIndex = 4;
            // 
            // frmSystemRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 731);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ipList);
            this.Controls.Add(this.macList);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.cboCounter);
            this.Controls.Add(this.cmbTehsil);
            this.Controls.Add(this.cmdDistrict);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Registration";
            this.Load += new System.EventHandler(this.SystemRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTehsil;
        private System.Windows.Forms.ComboBox cmdDistrict;
        public System.Windows.Forms.TextBox txtMachineName;
        public System.Windows.Forms.ListBox macList;
        public System.Windows.Forms.ListBox ipList;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCounter;
    }
}