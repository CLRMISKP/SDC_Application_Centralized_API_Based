namespace SDC_Application
{
    partial class frmSearchPerson
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
            if ( disposing && ( components != null ) )
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonaName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridViewPersons = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAndarajAfrad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.procGetSearchedAfradListResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procGetSearchedAfradListResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCNIC);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPersonaName);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 30);
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
            this.txtCNIC.Size = new System.Drawing.Size(261, 30);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "فرد کا نام";
            // 
            // txtPersonaName
            // 
            this.txtPersonaName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonaName.Location = new System.Drawing.Point(89, 32);
            this.txtPersonaName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtPersonaName.Name = "txtPersonaName";
            this.txtPersonaName.Size = new System.Drawing.Size(261, 37);
            this.txtPersonaName.TabIndex = 1;
            this.txtPersonaName.Enter += new System.EventHandler(this.txtPersonaName_Enter);
            this.txtPersonaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonaName_KeyPress);
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
            this.GridViewPersons.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.GridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewPersons.Location = new System.Drawing.Point(3, 32);
            this.GridViewPersons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GridViewPersons.MultiSelect = false;
            this.GridViewPersons.Name = "GridViewPersons";
            this.GridViewPersons.ReadOnly = true;
            this.GridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPersons.Size = new System.Drawing.Size(607, 376);
            this.GridViewPersons.TabIndex = 0;
            this.GridViewPersons.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridViewPersons_CellMouseDoubleClick);
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
            // frmSearchPerson
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 546);
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
            this.Name = "frmSearchPerson";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تلاش افراد";
            this.Load += new System.EventHandler(this.frmSearchPerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procGetSearchedAfradListResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPersonaName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridViewPersons;
        private System.Windows.Forms.BindingSource procGetSearchedAfradListResultBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personFullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Button btnAndarajAfrad;
    }
}