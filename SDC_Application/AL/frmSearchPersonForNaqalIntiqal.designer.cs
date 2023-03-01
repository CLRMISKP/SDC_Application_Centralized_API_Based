namespace SDC_Application
{
    partial class frmSearchPersonForNaqalIntiqal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if ( disposing && ( components != null ) )
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GridBuyersList = new System.Windows.Forms.DataGridView();
            this.chk1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonaName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridViewPersons = new System.Windows.Forms.DataGridView();
            this.cbgrid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAndarajAfrad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBuyersList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPersonaName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCNIC);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(182, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(444, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "افراد کی تلاش کے لئے لکھیں";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GridBuyersList);
            this.panel1.Location = new System.Drawing.Point(7, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 26);
            this.panel1.TabIndex = 7;
            // 
            // GridBuyersList
            // 
            this.GridBuyersList.AllowUserToAddRows = false;
            this.GridBuyersList.AllowUserToDeleteRows = false;
            this.GridBuyersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridBuyersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridBuyersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk1});
            this.GridBuyersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridBuyersList.Location = new System.Drawing.Point(0, 0);
            this.GridBuyersList.Name = "GridBuyersList";
            this.GridBuyersList.ReadOnly = true;
            this.GridBuyersList.RowTemplate.Height = 30;
            this.GridBuyersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridBuyersList.Size = new System.Drawing.Size(58, 26);
            this.GridBuyersList.TabIndex = 3;
            this.GridBuyersList.Visible = false;
            // 
            // chk1
            // 
            this.chk1.HeaderText = "انتخاب کریں";
            this.chk1.Name = "chk1";
            this.chk1.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(194, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 38);
            this.label3.TabIndex = 9;
            this.label3.Text = "ولدیت";
            // 
            // txtFname
            // 
            this.txtFname.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(89, 26);
            this.txtFname.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(99, 45);
            this.txtFname.TabIndex = 8;
            this.txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "نام";
            // 
            // txtPersonaName
            // 
            this.txtPersonaName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonaName.Location = new System.Drawing.Point(248, 26);
            this.txtPersonaName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtPersonaName.Name = "txtPersonaName";
            this.txtPersonaName.Size = new System.Drawing.Size(102, 45);
            this.txtPersonaName.TabIndex = 6;
            this.txtPersonaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFname_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "شناختی کارڈ نمبر";
            // 
            // txtCNIC
            // 
            this.txtCNIC.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNIC.Location = new System.Drawing.Point(89, 74);
            this.txtCNIC.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtCNIC.MaxLength = 13;
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(261, 35);
            this.txtCNIC.TabIndex = 4;
            this.txtCNIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCNIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNIC_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnFind.Location = new System.Drawing.Point(15, 51);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(50, 37);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridViewPersons);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Size = new System.Drawing.Size(613, 414);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // GridViewPersons
            // 
            this.GridViewPersons.AllowUserToAddRows = false;
            this.GridViewPersons.AllowUserToDeleteRows = false;
            this.GridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbgrid});
            this.GridViewPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewPersons.Location = new System.Drawing.Point(3, 38);
            this.GridViewPersons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GridViewPersons.Name = "GridViewPersons";
            this.GridViewPersons.ReadOnly = true;
            this.GridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPersons.Size = new System.Drawing.Size(607, 370);
            this.GridViewPersons.TabIndex = 0;
            this.GridViewPersons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewPersons_CellClick);
            this.GridViewPersons.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridViewPersons_CellMouseDoubleClick);
            // 
            // cbgrid
            // 
            this.cbgrid.HeaderText = "انتخاب کریں";
            this.cbgrid.Name = "cbgrid";
            this.cbgrid.ReadOnly = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::SDC_Application.Resource1.Check_Res;
            this.btnAccept.Location = new System.Drawing.Point(126, 47);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(50, 50);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnAndarajAfrad
            // 
            this.btnAndarajAfrad.Image = global::SDC_Application.Resource1.family_icon21;
            this.btnAndarajAfrad.Location = new System.Drawing.Point(70, 47);
            this.btnAndarajAfrad.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnAndarajAfrad.Name = "btnAndarajAfrad";
            this.btnAndarajAfrad.Size = new System.Drawing.Size(50, 50);
            this.btnAndarajAfrad.TabIndex = 5;
            this.btnAndarajAfrad.UseVisualStyleBackColor = true;
            this.btnAndarajAfrad.Click += new System.EventHandler(this.btnAndarajAfrad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::SDC_Application.Resource1.back_icon;
            this.btnCancel.Location = new System.Drawing.Point(14, 47);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSearchPersonForNaqalIntiqal
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 546);
            this.Controls.Add(this.btnAndarajAfrad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchPersonForNaqalIntiqal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تلاش افراد";
            this.Load += new System.EventHandler(this.frmSearchPerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridBuyersList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridViewPersons;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personFullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Button btnAndarajAfrad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbgrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPersonaName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView GridBuyersList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk1;
    }
}