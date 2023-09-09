namespace SDC_Application.AL
{
    partial class frmUserManagement
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
            this.txtUserRoleId = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grdExistingUsers = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnFingerHysoon = new System.Windows.Forms.Button();
            this.chbIsRO = new System.Windows.Forms.CheckBox();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btncancelUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.lbl6 = new System.Windows.Forms.Label();
            this.rbUserInActive = new System.Windows.Forms.RadioButton();
            this.rbUserAcive = new System.Windows.Forms.RadioButton();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.grdUserRoles = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbUserRoles = new System.Windows.Forms.ComboBox();
            this.lblCycleRoles = new System.Windows.Forms.Label();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnInsRole = new System.Windows.Forms.Button();
            this.btnDelRole = new System.Windows.Forms.Button();
            this.lbl7 = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExistingUsers)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRoles)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtUserRoleId);
            this.grp.Controls.Add(this.txtRole);
            this.grp.Controls.Add(this.textBox1);
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(1290, 53);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            // 
            // txtUserRoleId
            // 
            this.txtUserRoleId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserRoleId.Location = new System.Drawing.Point(1213, 16);
            this.txtUserRoleId.Name = "txtUserRoleId";
            this.txtUserRoleId.Size = new System.Drawing.Size(37, 30);
            this.txtUserRoleId.TabIndex = 13;
            this.txtUserRoleId.Text = "-1";
            this.txtUserRoleId.Visible = false;
            // 
            // txtRole
            // 
            this.txtRole.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.Location = new System.Drawing.Point(968, 21);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(130, 30);
            this.txtRole.TabIndex = 3;
            this.txtRole.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1136, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 30);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "-1";
            this.textBox1.Visible = false;
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
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1290, 681);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(767, 660);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add/Edit Users";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.grdExistingUsers);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 175);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(761, 482);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Existing Users";
            // 
            // grdExistingUsers
            // 
            this.grdExistingUsers.AllowUserToAddRows = false;
            this.grdExistingUsers.AllowUserToDeleteRows = false;
            this.grdExistingUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdExistingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExistingUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExistingUsers.Location = new System.Drawing.Point(3, 18);
            this.grdExistingUsers.Name = "grdExistingUsers";
            this.grdExistingUsers.ReadOnly = true;
            this.grdExistingUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdExistingUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdExistingUsers.Size = new System.Drawing.Size(755, 461);
            this.grdExistingUsers.TabIndex = 0;
            this.grdExistingUsers.DoubleClick += new System.EventHandler(this.grdExistingUsers_DoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnFingerHysoon);
            this.groupBox5.Controls.Add(this.chbIsRO);
            this.groupBox5.Controls.Add(this.btnFingerPrint);
            this.groupBox5.Controls.Add(this.txtUserId);
            this.groupBox5.Controls.Add(this.btncancelUser);
            this.groupBox5.Controls.Add(this.btnSaveUser);
            this.groupBox5.Controls.Add(this.btnModifyUser);
            this.groupBox5.Controls.Add(this.btnNewUser);
            this.groupBox5.Controls.Add(this.lbl6);
            this.groupBox5.Controls.Add(this.rbUserInActive);
            this.groupBox5.Controls.Add(this.rbUserAcive);
            this.groupBox5.Controls.Add(this.lbl5);
            this.groupBox5.Controls.Add(this.lbl4);
            this.groupBox5.Controls.Add(this.lbl3);
            this.groupBox5.Controls.Add(this.lbl2);
            this.groupBox5.Controls.Add(this.lbl1);
            this.groupBox5.Controls.Add(this.txtConfPassword);
            this.groupBox5.Controls.Add(this.txtPassword);
            this.groupBox5.Controls.Add(this.txtLoginId);
            this.groupBox5.Controls.Add(this.txtLastName);
            this.groupBox5.Controls.Add(this.txtFirstName);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(761, 157);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // btnFingerHysoon
            // 
            this.btnFingerHysoon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFingerHysoon.ForeColor = System.Drawing.Color.White;
            this.btnFingerHysoon.Image = global::SDC_Application.Resource1.fingerPrint1;
            this.btnFingerHysoon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFingerHysoon.Location = new System.Drawing.Point(153, 98);
            this.btnFingerHysoon.Name = "btnFingerHysoon";
            this.btnFingerHysoon.Size = new System.Drawing.Size(56, 53);
            this.btnFingerHysoon.TabIndex = 48;
            this.btnFingerHysoon.Text = "Hysoon";
            this.btnFingerHysoon.UseVisualStyleBackColor = true;
            this.btnFingerHysoon.Click += new System.EventHandler(this.btnFingerHysoon_Click);
            // 
            // chbIsRO
            // 
            this.chbIsRO.AutoSize = true;
            this.chbIsRO.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsRO.Location = new System.Drawing.Point(566, 113);
            this.chbIsRO.Name = "chbIsRO";
            this.chbIsRO.Size = new System.Drawing.Size(160, 23);
            this.chbIsRO.TabIndex = 45;
            this.chbIsRO.Text = "Is Revenue Officer";
            this.chbIsRO.UseVisualStyleBackColor = true;
            // 
            // btnFingerPrint
            // 
            this.btnFingerPrint.Image = global::SDC_Application.Resource1.fingerPrint1;
            this.btnFingerPrint.Location = new System.Drawing.Point(215, 98);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Size = new System.Drawing.Size(56, 53);
            this.btnFingerPrint.TabIndex = 44;
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.btnFingerPrint_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Location = new System.Drawing.Point(10, 114);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(43, 30);
            this.txtUserId.TabIndex = 43;
            this.txtUserId.Text = "-1";
            this.txtUserId.Visible = false;
            // 
            // btncancelUser
            // 
            this.btncancelUser.BackgroundImage = global::SDC_Application.Resource1.Cancel1;
            this.btncancelUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancelUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelUser.Location = new System.Drawing.Point(510, 99);
            this.btncancelUser.Name = "btncancelUser";
            this.btncancelUser.Size = new System.Drawing.Size(54, 50);
            this.btncancelUser.TabIndex = 42;
            this.btncancelUser.TabStop = false;
            this.btncancelUser.UseVisualStyleBackColor = true;
            this.btncancelUser.Visible = false;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveUser.Location = new System.Drawing.Point(390, 99);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(54, 50);
            this.btnSaveUser.TabIndex = 41;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyUser.Image = global::SDC_Application.Resource1.Modify;
            this.btnModifyUser.Location = new System.Drawing.Point(450, 99);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(54, 50);
            this.btnModifyUser.TabIndex = 40;
            this.btnModifyUser.TabStop = false;
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Visible = false;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Image = global::SDC_Application.Resource1.New_icon1_res;
            this.btnNewUser.Location = new System.Drawing.Point(330, 99);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(54, 50);
            this.btnNewUser.TabIndex = 39;
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(486, 67);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(63, 22);
            this.lbl6.TabIndex = 12;
            this.lbl6.Text = "Status:";
            // 
            // rbUserInActive
            // 
            this.rbUserInActive.AutoSize = true;
            this.rbUserInActive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUserInActive.Location = new System.Drawing.Point(636, 65);
            this.rbUserInActive.Name = "rbUserInActive";
            this.rbUserInActive.Size = new System.Drawing.Size(103, 26);
            this.rbUserInActive.TabIndex = 11;
            this.rbUserInActive.TabStop = true;
            this.rbUserInActive.Text = "In Active";
            this.rbUserInActive.UseVisualStyleBackColor = true;
            // 
            // rbUserAcive
            // 
            this.rbUserAcive.AutoSize = true;
            this.rbUserAcive.Checked = true;
            this.rbUserAcive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUserAcive.Location = new System.Drawing.Point(556, 65);
            this.rbUserAcive.Name = "rbUserAcive";
            this.rbUserAcive.Size = new System.Drawing.Size(84, 26);
            this.rbUserAcive.TabIndex = 10;
            this.rbUserAcive.TabStop = true;
            this.rbUserAcive.Text = "Active";
            this.rbUserAcive.UseVisualStyleBackColor = true;
            this.rbUserAcive.CheckedChanged += new System.EventHandler(this.rbUserAcive_CheckedChanged);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(219, 67);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(164, 22);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "Confirm Password:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(6, 67);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(94, 22);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "Password:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(488, 23);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(82, 22);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "Login Id:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(240, 20);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 22);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Last Name:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(4, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(104, 22);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "First Name:";
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPassword.Location = new System.Drawing.Point(383, 64);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.PasswordChar = '*';
            this.txtConfPassword.Size = new System.Drawing.Size(100, 30);
            this.txtConfPassword.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(102, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(109, 30);
            this.txtPassword.TabIndex = 3;
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginId.Location = new System.Drawing.Point(583, 19);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(130, 30);
            this.txtLoginId.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(352, 19);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(130, 30);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(109, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(130, 30);
            this.txtFirstName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(770, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 660);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Roles";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.grdUserRoles);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 100);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(511, 557);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            // 
            // grdUserRoles
            // 
            this.grdUserRoles.AllowUserToAddRows = false;
            this.grdUserRoles.AllowUserToDeleteRows = false;
            this.grdUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserRoles.Location = new System.Drawing.Point(3, 18);
            this.grdUserRoles.Name = "grdUserRoles";
            this.grdUserRoles.ReadOnly = true;
            this.grdUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUserRoles.Size = new System.Drawing.Size(505, 536);
            this.grdUserRoles.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbUserRoles);
            this.groupBox7.Controls.Add(this.lblCycleRoles);
            this.groupBox7.Controls.Add(this.btnAssignRole);
            this.groupBox7.Controls.Add(this.btnInsRole);
            this.groupBox7.Controls.Add(this.btnDelRole);
            this.groupBox7.Controls.Add(this.lbl7);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(511, 82);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // cbUserRoles
            // 
            this.cbUserRoles.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUserRoles.FormattingEnabled = true;
            this.cbUserRoles.Location = new System.Drawing.Point(108, 23);
            this.cbUserRoles.Name = "cbUserRoles";
            this.cbUserRoles.Size = new System.Drawing.Size(206, 30);
            this.cbUserRoles.TabIndex = 11;
            // 
            // lblCycleRoles
            // 
            this.lblCycleRoles.AutoSize = true;
            this.lblCycleRoles.Location = new System.Drawing.Point(456, 32);
            this.lblCycleRoles.Name = "lblCycleRoles";
            this.lblCycleRoles.Size = new System.Drawing.Size(21, 17);
            this.lblCycleRoles.TabIndex = 10;
            this.lblCycleRoles.Text = "->";
            this.lblCycleRoles.Visible = false;
            this.lblCycleRoles.Click += new System.EventHandler(this.lblCycleRoles_Click);
            // 
            // btnAssignRole
            // 
            this.btnAssignRole.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignRole.Location = new System.Drawing.Point(317, 24);
            this.btnAssignRole.Name = "btnAssignRole";
            this.btnAssignRole.Size = new System.Drawing.Size(155, 29);
            this.btnAssignRole.TabIndex = 4;
            this.btnAssignRole.Text = "Click to Assign Role";
            this.btnAssignRole.UseVisualStyleBackColor = true;
            this.btnAssignRole.Click += new System.EventHandler(this.btnAssignRole_Click);
            // 
            // btnInsRole
            // 
            this.btnInsRole.Location = new System.Drawing.Point(478, 27);
            this.btnInsRole.Name = "btnInsRole";
            this.btnInsRole.Size = new System.Drawing.Size(16, 22);
            this.btnInsRole.TabIndex = 9;
            this.btnInsRole.Text = "+";
            this.btnInsRole.UseVisualStyleBackColor = true;
            this.btnInsRole.Visible = false;
            this.btnInsRole.Click += new System.EventHandler(this.btnInsRole_Click);
            // 
            // btnDelRole
            // 
            this.btnDelRole.Location = new System.Drawing.Point(491, 27);
            this.btnDelRole.Name = "btnDelRole";
            this.btnDelRole.Size = new System.Drawing.Size(16, 22);
            this.btnDelRole.TabIndex = 9;
            this.btnDelRole.Text = "-";
            this.btnDelRole.UseVisualStyleBackColor = true;
            this.btnDelRole.Visible = false;
            this.btnDelRole.Click += new System.EventHandler(this.btnDelRole_Click);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(12, 28);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(96, 22);
            this.lbl7.TabIndex = 8;
            this.lbl7.Text = "User Role:";
            // 
            // frmUserManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1290, 734);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp);
            this.Name = "frmUserManagement";
            this.Text = "frmUserManagement";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExistingUsers)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRoles)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.RadioButton rbUserInActive;
        private System.Windows.Forms.RadioButton rbUserAcive;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataGridView grdExistingUsers;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView grdUserRoles;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Button btncancelUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnFingerPrint;
        private System.Windows.Forms.CheckBox chbIsRO;
        private System.Windows.Forms.Button btnFingerHysoon;
        private System.Windows.Forms.Button btnInsRole;
        private System.Windows.Forms.Button btnDelRole;
        private System.Windows.Forms.Label lblCycleRoles;
        private System.Windows.Forms.ComboBox cbUserRoles;
        private System.Windows.Forms.TextBox txtUserRoleId;
        private System.Windows.Forms.TextBox textBox1;
    }
}