namespace SDC_Application.AL
{
    partial class frmUsersTokenRole
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
            this.cbFard = new System.Windows.Forms.CheckBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.cbRegistry = new System.Windows.Forms.CheckBox();
            this.cbIntiqal = new System.Windows.Forms.CheckBox();
            this.dgExistingUsers = new System.Windows.Forms.DataGridView();
            this.grp.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExistingUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(1173, 53);
            this.grp.TabIndex = 1;
            this.grp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token Role";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbIntiqal);
            this.groupBox5.Controls.Add(this.cbRegistry);
            this.groupBox5.Controls.Add(this.cbFard);
            this.groupBox5.Controls.Add(this.txtUserId);
            this.groupBox5.Controls.Add(this.btnSaveUser);
            this.groupBox5.Controls.Add(this.lbl3);
            this.groupBox5.Controls.Add(this.lbl2);
            this.groupBox5.Controls.Add(this.lbl1);
            this.groupBox5.Controls.Add(this.txtLoginId);
            this.groupBox5.Controls.Add(this.txtLastName);
            this.groupBox5.Controls.Add(this.txtFirstName);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 53);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1173, 66);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // cbFard
            // 
            this.cbFard.AutoSize = true;
            this.cbFard.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFard.Location = new System.Drawing.Point(671, 23);
            this.cbFard.Name = "cbFard";
            this.cbFard.Size = new System.Drawing.Size(53, 20);
            this.cbFard.TabIndex = 45;
            this.cbFard.Text = "Fard";
            this.cbFard.UseVisualStyleBackColor = true;
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Location = new System.Drawing.Point(1017, 17);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(86, 26);
            this.txtUserId.TabIndex = 43;
            this.txtUserId.Text = "-1";
            this.txtUserId.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(443, 23);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(63, 19);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "Login Id:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(222, 20);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(79, 19);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Last Name:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(4, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(80, 19);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "First Name:";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginId.Location = new System.Drawing.Point(517, 19);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(130, 26);
            this.txtLoginId.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(307, 19);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(130, 26);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(91, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(130, 26);
            this.txtFirstName.TabIndex = 0;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUser.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSaveUser.Location = new System.Drawing.Point(912, 6);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(54, 50);
            this.btnSaveUser.TabIndex = 41;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // cbRegistry
            // 
            this.cbRegistry.AutoSize = true;
            this.cbRegistry.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRegistry.Location = new System.Drawing.Point(818, 23);
            this.cbRegistry.Name = "cbRegistry";
            this.cbRegistry.Size = new System.Drawing.Size(74, 20);
            this.cbRegistry.TabIndex = 46;
            this.cbRegistry.Text = "Registry";
            this.cbRegistry.UseVisualStyleBackColor = true;
            // 
            // cbIntiqal
            // 
            this.cbIntiqal.AutoSize = true;
            this.cbIntiqal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIntiqal.Location = new System.Drawing.Point(748, 23);
            this.cbIntiqal.Name = "cbIntiqal";
            this.cbIntiqal.Size = new System.Drawing.Size(62, 20);
            this.cbIntiqal.TabIndex = 47;
            this.cbIntiqal.Text = "Intiqal";
            this.cbIntiqal.UseVisualStyleBackColor = true;
            // 
            // dgExistingUsers
            // 
            this.dgExistingUsers.AllowUserToAddRows = false;
            this.dgExistingUsers.AllowUserToDeleteRows = false;
            this.dgExistingUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgExistingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExistingUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExistingUsers.Location = new System.Drawing.Point(0, 119);
            this.dgExistingUsers.Name = "dgExistingUsers";
            this.dgExistingUsers.ReadOnly = true;
            this.dgExistingUsers.RowHeadersVisible = false;
            this.dgExistingUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExistingUsers.Size = new System.Drawing.Size(1173, 358);
            this.dgExistingUsers.TabIndex = 3;
            this.dgExistingUsers.DoubleClick += new System.EventHandler(this.dgExistingUsers_DoubleClick);
            // 
            // frmUsersTokenRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 477);
            this.Controls.Add(this.dgExistingUsers);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grp);
            this.Name = "frmUsersTokenRole";
            this.Text = "Token Role";
            this.Load += new System.EventHandler(this.frmUsersTokenRole_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExistingUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbFard;
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
    }
}