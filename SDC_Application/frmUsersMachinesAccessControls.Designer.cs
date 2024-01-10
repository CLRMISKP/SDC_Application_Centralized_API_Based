namespace SDC_Application
{
    partial class frmUsersMachinesAccessControls
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUserAccess = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grdExistingUsers = new System.Windows.Forms.DataGridView();
            this.ChkSelUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpLogin = new System.Windows.Forms.MaskedTextBox();
            this.dtpLogout = new System.Windows.Forms.MaskedTextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.chkLoginOnWeekend = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMachineAccess = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridSystems = new System.Windows.Forms.DataGridView();
            this.ChkSelMachine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpMachineLogout = new System.Windows.Forms.MaskedTextBox();
            this.dtpMachineLogin = new System.Windows.Forms.MaskedTextBox();
            this.chkEnableSystemLogin = new System.Windows.Forms.CheckBox();
            this.btnSaveMachine = new System.Windows.Forms.Button();
            this.chkMachineLoginOnWeekend = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtRegId = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabUserAccess.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExistingUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabMachineAccess.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSystems)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUserAccess);
            this.tabControl1.Controls.Add(this.tabMachineAccess);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1399, 635);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUserAccess
            // 
            this.tabUserAccess.Controls.Add(this.groupBox6);
            this.tabUserAccess.Controls.Add(this.groupBox1);
            this.tabUserAccess.Location = new System.Drawing.Point(4, 31);
            this.tabUserAccess.Margin = new System.Windows.Forms.Padding(4);
            this.tabUserAccess.Name = "tabUserAccess";
            this.tabUserAccess.Padding = new System.Windows.Forms.Padding(6);
            this.tabUserAccess.Size = new System.Drawing.Size(1391, 600);
            this.tabUserAccess.TabIndex = 0;
            this.tabUserAccess.Text = "Users Access Control";
            this.tabUserAccess.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.grdExistingUsers);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(6, 88);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox6.Size = new System.Drawing.Size(1379, 506);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Existing Users";
            // 
            // grdExistingUsers
            // 
            this.grdExistingUsers.AllowUserToAddRows = false;
            this.grdExistingUsers.AllowUserToDeleteRows = false;
            this.grdExistingUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdExistingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExistingUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChkSelUser});
            this.grdExistingUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExistingUsers.Location = new System.Drawing.Point(3, 26);
            this.grdExistingUsers.Name = "grdExistingUsers";
            this.grdExistingUsers.ReadOnly = true;
            this.grdExistingUsers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdExistingUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdExistingUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdExistingUsers.Size = new System.Drawing.Size(1373, 477);
            this.grdExistingUsers.TabIndex = 0;
            this.grdExistingUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdExistingUsers_CellClick);
            // 
            // ChkSelUser
            // 
            this.ChkSelUser.HeaderText = "Select";
            this.ChkSelUser.Name = "ChkSelUser";
            this.ChkSelUser.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.dtpLogin);
            this.groupBox1.Controls.Add(this.dtpLogout);
            this.groupBox1.Controls.Add(this.btnSaveUser);
            this.groupBox1.Controls.Add(this.chkLoginOnWeekend);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1379, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpLogin
            // 
            this.dtpLogin.Location = new System.Drawing.Point(121, 29);
            this.dtpLogin.Mask = "00:00:00";
            this.dtpLogin.Name = "dtpLogin";
            this.dtpLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpLogin.Size = new System.Drawing.Size(80, 30);
            this.dtpLogin.TabIndex = 47;
            // 
            // dtpLogout
            // 
            this.dtpLogout.Location = new System.Drawing.Point(371, 29);
            this.dtpLogout.Mask = "00:00:00";
            this.dtpLogout.Name = "dtpLogout";
            this.dtpLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpLogout.Size = new System.Drawing.Size(86, 30);
            this.dtpLogout.TabIndex = 46;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveUser.Location = new System.Drawing.Point(792, 19);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(54, 50);
            this.btnSaveUser.TabIndex = 42;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // chkLoginOnWeekend
            // 
            this.chkLoginOnWeekend.AutoSize = true;
            this.chkLoginOnWeekend.Location = new System.Drawing.Point(497, 31);
            this.chkLoginOnWeekend.Name = "chkLoginOnWeekend";
            this.chkLoginOnWeekend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkLoginOnWeekend.Size = new System.Drawing.Size(177, 26);
            this.chkLoginOnWeekend.TabIndex = 4;
            this.chkLoginOnWeekend.Text = "Login on Weekend";
            this.chkLoginOnWeekend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Logout Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login Time";
            // 
            // tabMachineAccess
            // 
            this.tabMachineAccess.Controls.Add(this.groupBox3);
            this.tabMachineAccess.Controls.Add(this.groupBox2);
            this.tabMachineAccess.Location = new System.Drawing.Point(4, 31);
            this.tabMachineAccess.Margin = new System.Windows.Forms.Padding(4);
            this.tabMachineAccess.Name = "tabMachineAccess";
            this.tabMachineAccess.Padding = new System.Windows.Forms.Padding(4);
            this.tabMachineAccess.Size = new System.Drawing.Size(1391, 600);
            this.tabMachineAccess.TabIndex = 1;
            this.tabMachineAccess.Text = "Machine Access Control";
            this.tabMachineAccess.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridSystems);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(1383, 510);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registered Systems";
            // 
            // gridSystems
            // 
            this.gridSystems.AllowUserToAddRows = false;
            this.gridSystems.AllowUserToDeleteRows = false;
            this.gridSystems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSystems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSystems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChkSelMachine});
            this.gridSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSystems.Location = new System.Drawing.Point(3, 26);
            this.gridSystems.Name = "gridSystems";
            this.gridSystems.ReadOnly = true;
            this.gridSystems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridSystems.RowHeadersVisible = false;
            this.gridSystems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridSystems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSystems.Size = new System.Drawing.Size(1377, 481);
            this.gridSystems.TabIndex = 0;
            this.gridSystems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSystems_CellClick);
            // 
            // ChkSelMachine
            // 
            this.ChkSelMachine.HeaderText = "Select";
            this.ChkSelMachine.Name = "ChkSelMachine";
            this.ChkSelMachine.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRegId);
            this.groupBox2.Controls.Add(this.dtpMachineLogout);
            this.groupBox2.Controls.Add(this.dtpMachineLogin);
            this.groupBox2.Controls.Add(this.chkEnableSystemLogin);
            this.groupBox2.Controls.Add(this.btnSaveMachine);
            this.groupBox2.Controls.Add(this.chkMachineLoginOnWeekend);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1383, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dtpMachineLogout
            // 
            this.dtpMachineLogout.Location = new System.Drawing.Point(342, 31);
            this.dtpMachineLogout.Mask = "00:00:00";
            this.dtpMachineLogout.Name = "dtpMachineLogout";
            this.dtpMachineLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMachineLogout.Size = new System.Drawing.Size(86, 30);
            this.dtpMachineLogout.TabIndex = 45;
            // 
            // dtpMachineLogin
            // 
            this.dtpMachineLogin.Location = new System.Drawing.Point(121, 31);
            this.dtpMachineLogin.Mask = "00:00:00";
            this.dtpMachineLogin.Name = "dtpMachineLogin";
            this.dtpMachineLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMachineLogin.Size = new System.Drawing.Size(80, 30);
            this.dtpMachineLogin.TabIndex = 44;
            // 
            // chkEnableSystemLogin
            // 
            this.chkEnableSystemLogin.AutoSize = true;
            this.chkEnableSystemLogin.Location = new System.Drawing.Point(449, 33);
            this.chkEnableSystemLogin.Name = "chkEnableSystemLogin";
            this.chkEnableSystemLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkEnableSystemLogin.Size = new System.Drawing.Size(198, 26);
            this.chkEnableSystemLogin.TabIndex = 43;
            this.chkEnableSystemLogin.Text = "Enable System Login";
            this.chkEnableSystemLogin.UseVisualStyleBackColor = true;
            // 
            // btnSaveMachine
            // 
            this.btnSaveMachine.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMachine.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveMachine.Location = new System.Drawing.Point(955, 21);
            this.btnSaveMachine.Name = "btnSaveMachine";
            this.btnSaveMachine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSaveMachine.Size = new System.Drawing.Size(54, 50);
            this.btnSaveMachine.TabIndex = 42;
            this.btnSaveMachine.UseVisualStyleBackColor = true;
            this.btnSaveMachine.Click += new System.EventHandler(this.btnSaveMachine_Click);
            // 
            // chkMachineLoginOnWeekend
            // 
            this.chkMachineLoginOnWeekend.AutoSize = true;
            this.chkMachineLoginOnWeekend.Location = new System.Drawing.Point(671, 33);
            this.chkMachineLoginOnWeekend.Name = "chkMachineLoginOnWeekend";
            this.chkMachineLoginOnWeekend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMachineLoginOnWeekend.Size = new System.Drawing.Size(177, 26);
            this.chkMachineLoginOnWeekend.TabIndex = 4;
            this.chkMachineLoginOnWeekend.Text = "Login on Weekend";
            this.chkMachineLoginOnWeekend.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 35);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(109, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Logout Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 35);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Login Time";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1399, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Users and Machine Access Control";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1399, 635);
            this.panel2.TabIndex = 2;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(998, 32);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 30);
            this.txtUserId.TabIndex = 48;
            this.txtUserId.Text = "-1";
            this.txtUserId.Visible = false;
            // 
            // txtRegId
            // 
            this.txtRegId.Location = new System.Drawing.Point(1120, 32);
            this.txtRegId.Name = "txtRegId";
            this.txtRegId.Size = new System.Drawing.Size(100, 30);
            this.txtRegId.TabIndex = 49;
            this.txtRegId.Text = "-1";
            this.txtRegId.Visible = false;
            // 
            // frmUsersMachinesAccessControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 685);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsersMachinesAccessControls";
            this.Text = "صارفین، مشین اکسیس کنٹرول";
            this.Load += new System.EventHandler(this.frmUsersMachinesAccessControls_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUserAccess.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExistingUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMachineAccess.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSystems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUserAccess;
        private System.Windows.Forms.TabPage tabMachineAccess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView grdExistingUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLoginOnWeekend;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveMachine;
        private System.Windows.Forms.CheckBox chkMachineLoginOnWeekend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnableSystemLogin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridSystems;
        private System.Windows.Forms.MaskedTextBox dtpMachineLogin;
        private System.Windows.Forms.MaskedTextBox dtpMachineLogout;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChkSelMachine;
        private System.Windows.Forms.MaskedTextBox dtpLogin;
        private System.Windows.Forms.MaskedTextBox dtpLogout;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChkSelUser;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtRegId;
    }
}