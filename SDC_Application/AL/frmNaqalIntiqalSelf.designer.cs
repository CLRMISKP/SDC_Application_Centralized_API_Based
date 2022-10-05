namespace SDC_Application.AL
{
    partial class frmNaqalIntiqalSelf
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.btnListIntiqals = new System.Windows.Forms.Button();
            this.btnSearchBuyers = new System.Windows.Forms.Button();
            this.btnSearchSeller = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuyerName = new System.Windows.Forms.TextBox();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.GridIntiqalList = new System.Windows.Forms.DataGridView();
            this.colChooseWitness = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ToolTipIntiqalNaqal = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridIntiqalList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1050, 42);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "نقل انتقال";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbMouza);
            this.groupBox5.Controls.Add(this.btnListIntiqals);
            this.groupBox5.Controls.Add(this.btnSearchBuyers);
            this.groupBox5.Controls.Add(this.btnSearchSeller);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtbuyerName);
            this.groupBox5.Controls.Add(this.txtSellerName);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1050, 247);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.DropDownHeight = 500;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(728, 25);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 49;
            this.cmbMouza.SelectedIndexChanged += new System.EventHandler(this.cmbMouza_SelectedIndexChanged);
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // btnListIntiqals
            // 
            this.btnListIntiqals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListIntiqals.Image = global::SDC_Application.Resource1.Modify;
            this.btnListIntiqals.Location = new System.Drawing.Point(487, 188);
            this.btnListIntiqals.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnListIntiqals.Name = "btnListIntiqals";
            this.btnListIntiqals.Size = new System.Drawing.Size(59, 50);
            this.btnListIntiqals.TabIndex = 47;
            this.btnListIntiqals.TabStop = false;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnListIntiqals, "اوپر معلومات ک بنا پر انتقالات دیکھائیں");
            this.btnListIntiqals.UseVisualStyleBackColor = true;
            this.btnListIntiqals.Click += new System.EventHandler(this.btnListIntiqals_Click);
            // 
            // btnSearchBuyers
            // 
            this.btnSearchBuyers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchBuyers.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBuyers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchBuyers.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchBuyers.Location = new System.Drawing.Point(111, 136);
            this.btnSearchBuyers.Name = "btnSearchBuyers";
            this.btnSearchBuyers.Size = new System.Drawing.Size(45, 37);
            this.btnSearchBuyers.TabIndex = 46;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnSearchBuyers, "گریندگان/ مشتریان/وارثان تلاش کریں");
            this.btnSearchBuyers.UseVisualStyleBackColor = true;
            this.btnSearchBuyers.Click += new System.EventHandler(this.btnSearchBuyers_Click);
            // 
            // btnSearchSeller
            // 
            this.btnSearchSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSeller.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSeller.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchSeller.Image = global::SDC_Application.Resource1.search01;
            this.btnSearchSeller.Location = new System.Drawing.Point(111, 80);
            this.btnSearchSeller.Name = "btnSearchSeller";
            this.btnSearchSeller.Size = new System.Drawing.Size(45, 39);
            this.btnSearchSeller.TabIndex = 44;
            this.ToolTipIntiqalNaqal.SetToolTip(this.btnSearchSeller, "دہندگان/بائعان/متوافی تلاش کریں");
            this.btnSearchSeller.UseVisualStyleBackColor = true;
            this.btnSearchSeller.Click += new System.EventHandler(this.btnSearchSeller_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(920, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "نام بائع/راہن/متوافی";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(924, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "موضع";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(921, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام مشتری/مرتہن/وارث";
            // 
            // txtbuyerName
            // 
            this.txtbuyerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuyerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuyerName.Enabled = false;
            this.txtbuyerName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuyerName.Location = new System.Drawing.Point(164, 136);
            this.txtbuyerName.Name = "txtbuyerName";
            this.txtbuyerName.Size = new System.Drawing.Size(754, 37);
            this.txtbuyerName.TabIndex = 1;
            // 
            // txtSellerName
            // 
            this.txtSellerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSellerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellerName.Enabled = false;
            this.txtSellerName.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellerName.Location = new System.Drawing.Point(164, 80);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(754, 37);
            this.txtSellerName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GridIntiqalList);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 289);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1050, 283);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // GridIntiqalList
            // 
            this.GridIntiqalList.AllowUserToAddRows = false;
            this.GridIntiqalList.AllowUserToDeleteRows = false;
            this.GridIntiqalList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridIntiqalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridIntiqalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChooseWitness});
            this.GridIntiqalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridIntiqalList.Location = new System.Drawing.Point(3, 16);
            this.GridIntiqalList.Name = "GridIntiqalList";
            this.GridIntiqalList.ReadOnly = true;
            this.GridIntiqalList.RowHeadersVisible = false;
            this.GridIntiqalList.RowTemplate.Height = 30;
            this.GridIntiqalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridIntiqalList.Size = new System.Drawing.Size(1044, 264);
            this.GridIntiqalList.TabIndex = 0;
            // 
            // colChooseWitness
            // 
            this.colChooseWitness.HeaderText = "انتخاب کریں";
            this.colChooseWitness.Name = "colChooseWitness";
            this.colChooseWitness.ReadOnly = true;
            // 
            // frmNaqalIntiqalSelf
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1050, 572);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Name = "frmNaqalIntiqalSelf";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "نقل انتقال";
            this.Load += new System.EventHandler(this.frmNaqalIntiqal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridIntiqalList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSearchSeller;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuyerName;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView GridIntiqalList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChooseWitness;
        private System.Windows.Forms.Button btnSearchBuyers;
        private System.Windows.Forms.Button btnListIntiqals;
        private System.Windows.Forms.ToolTip ToolTipIntiqalNaqal;
        private System.Windows.Forms.ComboBox cmbMouza;
    }
}