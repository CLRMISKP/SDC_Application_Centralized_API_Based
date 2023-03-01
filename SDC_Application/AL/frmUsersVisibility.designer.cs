namespace SDC_Application.AL
{
    partial class frmUsersVisibility
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMisal = new System.Windows.Forms.CheckBox();
            this.cbImplementation = new System.Windows.Forms.CheckBox();
            this.cbTransFard = new System.Windows.Forms.CheckBox();
            this.cbIntiqal = new System.Windows.Forms.CheckBox();
            this.cbRegistry = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerach = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.dgExistingUsers = new System.Windows.Forms.DataGridView();
            this.grp.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExistingUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Margin = new System.Windows.Forms.Padding(4);
            this.grp.Name = "grp";
            this.grp.Padding = new System.Windows.Forms.Padding(4);
            this.grp.Size = new System.Drawing.Size(1152, 57);
            this.grp.TabIndex = 1;
            this.grp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(550, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visibility";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtSerach);
            this.groupBox5.Controls.Add(this.txtUserId);
            this.groupBox5.Controls.Add(this.btnSaveUser);
            this.groupBox5.Controls.Add(this.lbl3);
            this.groupBox5.Controls.Add(this.lbl2);
            this.groupBox5.Controls.Add(this.lbl1);
            this.groupBox5.Controls.Add(this.txtLoginId);
            this.groupBox5.Controls.Add(this.txtLastName);
            this.groupBox5.Controls.Add(this.txtFirstName);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 57);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1152, 116);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Misal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMisal);
            this.groupBox1.Controls.Add(this.cbImplementation);
            this.groupBox1.Controls.Add(this.cbTransFard);
            this.groupBox1.Controls.Add(this.cbIntiqal);
            this.groupBox1.Controls.Add(this.cbRegistry);
            this.groupBox1.Location = new System.Drawing.Point(714, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(339, 87);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // cbMisal
            // 
            this.cbMisal.AutoSize = true;
            this.cbMisal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMisal.Location = new System.Drawing.Point(8, 55);
            this.cbMisal.Margin = new System.Windows.Forms.Padding(4);
            this.cbMisal.Name = "cbMisal";
            this.cbMisal.Size = new System.Drawing.Size(70, 23);
            this.cbMisal.TabIndex = 49;
            this.cbMisal.Text = "Misal";
            this.cbMisal.UseVisualStyleBackColor = true;
            // 
            // cbImplementation
            // 
            this.cbImplementation.AutoSize = true;
            this.cbImplementation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImplementation.Location = new System.Drawing.Point(115, 55);
            this.cbImplementation.Margin = new System.Windows.Forms.Padding(4);
            this.cbImplementation.Name = "cbImplementation";
            this.cbImplementation.Size = new System.Drawing.Size(138, 23);
            this.cbImplementation.TabIndex = 48;
            this.cbImplementation.Text = "Implementation";
            this.cbImplementation.UseVisualStyleBackColor = true;
            // 
            // cbTransFard
            // 
            this.cbTransFard.AutoSize = true;
            this.cbTransFard.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransFard.Location = new System.Drawing.Point(8, 23);
            this.cbTransFard.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransFard.Name = "cbTransFard";
            this.cbTransFard.Size = new System.Drawing.Size(101, 23);
            this.cbTransFard.TabIndex = 45;
            this.cbTransFard.Text = "Trans Fard";
            this.cbTransFard.UseVisualStyleBackColor = true;
            // 
            // cbIntiqal
            // 
            this.cbIntiqal.AutoSize = true;
            this.cbIntiqal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIntiqal.Location = new System.Drawing.Point(136, 23);
            this.cbIntiqal.Margin = new System.Windows.Forms.Padding(4);
            this.cbIntiqal.Name = "cbIntiqal";
            this.cbIntiqal.Size = new System.Drawing.Size(74, 23);
            this.cbIntiqal.TabIndex = 47;
            this.cbIntiqal.Text = "Intiqal";
            this.cbIntiqal.UseVisualStyleBackColor = true;
            // 
            // cbRegistry
            // 
            this.cbRegistry.AutoSize = true;
            this.cbRegistry.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRegistry.Location = new System.Drawing.Point(227, 23);
            this.cbRegistry.Margin = new System.Windows.Forms.Padding(4);
            this.cbRegistry.Name = "cbRegistry";
            this.cbRegistry.Size = new System.Drawing.Size(89, 23);
            this.cbRegistry.TabIndex = 46;
            this.cbRegistry.Text = "Registry";
            this.cbRegistry.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 49;
            this.label2.Text = "Search :";
            // 
            // txtSerach
            // 
            this.txtSerach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerach.Location = new System.Drawing.Point(121, 76);
            this.txtSerach.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerach.Name = "txtSerach";
            this.txtSerach.Size = new System.Drawing.Size(130, 30);
            this.txtSerach.TabIndex = 48;
            this.txtSerach.TextChanged += new System.EventHandler(this.txtSerach_TextChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Location = new System.Drawing.Point(587, 65);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(113, 30);
            this.txtUserId.TabIndex = 43;
            this.txtUserId.Text = "-1";
            this.txtUserId.Visible = false;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveUser.Location = new System.Drawing.Point(1058, 28);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(72, 62);
            this.btnSaveUser.TabIndex = 41;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(489, 28);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(82, 22);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "Login Id:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(261, 25);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 22);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Last Name:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(5, 25);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(104, 22);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "First Name:";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginId.Location = new System.Drawing.Point(587, 23);
            this.txtLoginId.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(119, 30);
            this.txtLoginId.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(374, 23);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(105, 30);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(121, 21);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(130, 30);
            this.txtFirstName.TabIndex = 0;
            // 
            // dgExistingUsers
            // 
            this.dgExistingUsers.AllowUserToAddRows = false;
            this.dgExistingUsers.AllowUserToDeleteRows = false;
            this.dgExistingUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgExistingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExistingUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExistingUsers.Location = new System.Drawing.Point(0, 173);
            this.dgExistingUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dgExistingUsers.Name = "dgExistingUsers";
            this.dgExistingUsers.ReadOnly = true;
            this.dgExistingUsers.RowHeadersVisible = false;
            this.dgExistingUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExistingUsers.Size = new System.Drawing.Size(1152, 414);
            this.dgExistingUsers.TabIndex = 3;
            this.dgExistingUsers.DoubleClick += new System.EventHandler(this.dgExistingUsers_DoubleClick);
            // 
            // frmUsersVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 587);
            this.Controls.Add(this.dgExistingUsers);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grp);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsersVisibility";
            this.Text = "Visibility";
            this.Load += new System.EventHandler(this.frmUsersTokenRole_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExistingUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbTransFard;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.CheckBox cbIntiqal;
        private System.Windows.Forms.CheckBox cbRegistry;
        private System.Windows.Forms.DataGridView dgExistingUsers;
        private System.Windows.Forms.TextBox txtSerach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbMisal;
        private System.Windows.Forms.CheckBox cbImplementation;
    }
}