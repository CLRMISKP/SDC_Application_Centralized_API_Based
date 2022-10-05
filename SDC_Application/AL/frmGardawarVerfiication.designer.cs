namespace SDC_Application.AL
{
    partial class frmGardawarVerfiication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdIntiqalList = new System.Windows.Forms.DataGridView();
            this.Verification = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboROs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIntiqalNo = new System.Windows.Forms.ComboBox();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntiqalList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIntiqalList
            // 
            this.grdIntiqalList.AllowUserToAddRows = false;
            this.grdIntiqalList.AllowUserToDeleteRows = false;
            this.grdIntiqalList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdIntiqalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIntiqalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Verification});
            this.grdIntiqalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIntiqalList.Location = new System.Drawing.Point(3, 22);
            this.grdIntiqalList.Margin = new System.Windows.Forms.Padding(4);
            this.grdIntiqalList.Name = "grdIntiqalList";
            this.grdIntiqalList.ReadOnly = true;
            this.grdIntiqalList.RowHeadersWidth = 50;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdIntiqalList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIntiqalList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdIntiqalList.RowTemplate.Height = 28;
            this.grdIntiqalList.Size = new System.Drawing.Size(1336, 444);
            this.grdIntiqalList.TabIndex = 0;
            this.grdIntiqalList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIntiqalList_CellContentClick);
            // 
            // Verification
            // 
            this.Verification.HeaderText = "پڑتال";
            this.Verification.Name = "Verification";
            this.Verification.ReadOnly = true;
            this.Verification.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Verification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Verification.Text = "پڑتال کریں";
            this.Verification.UseColumnTextForLinkValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1362, 589);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdIntiqalList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(10, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(1342, 469);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboROs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbIntiqalNo);
            this.groupBox2.Controls.Add(this.cmbMouza);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1342, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(653, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 30);
            this.label2.TabIndex = 58;
            this.label2.Text = "گرداور";
            // 
            // cboROs
            // 
            this.cboROs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboROs.DisplayMember = "IntiqalType";
            this.cboROs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboROs.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboROs.FormattingEnabled = true;
            this.cboROs.Location = new System.Drawing.Point(488, 26);
            this.cboROs.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboROs.Name = "cboROs";
            this.cboROs.Size = new System.Drawing.Size(159, 27);
            this.cboROs.TabIndex = 57;
            this.cboROs.Tag = "1";
            this.cboROs.ValueMember = "IntiqalTypeId";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(912, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 30);
            this.label1.TabIndex = 56;
            this.label1.Text = "انتقال نمبر";
            // 
            // cmbIntiqalNo
            // 
            this.cmbIntiqalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIntiqalNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbIntiqalNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIntiqalNo.DropDownHeight = 500;
            this.cmbIntiqalNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbIntiqalNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIntiqalNo.FormattingEnabled = true;
            this.cmbIntiqalNo.IntegralHeight = false;
            this.cmbIntiqalNo.Location = new System.Drawing.Point(731, 26);
            this.cmbIntiqalNo.Name = "cmbIntiqalNo";
            this.cmbIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIntiqalNo.Size = new System.Drawing.Size(175, 27);
            this.cmbIntiqalNo.TabIndex = 55;
            this.cmbIntiqalNo.SelectionChangeCommitted += new System.EventHandler(this.cmbIntiqalNo_SelectionChangeCommitted);
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
            this.cmbMouza.Location = new System.Drawing.Point(996, 27);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 27);
            this.cmbMouza.TabIndex = 51;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            this.cmbMouza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMouza_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1202, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 30);
            this.label5.TabIndex = 50;
            this.label5.Text = "موضع";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearch.Location = new System.Drawing.Point(367, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 38);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmGardawarVerfiication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 589);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGardawarVerfiication";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گرداور پڑتال";
            this.Load += new System.EventHandler(this.frmGardawarVerfiication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntiqalList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdIntiqalList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbMouza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIntiqalNo;
        private System.Windows.Forms.DataGridViewLinkColumn Verification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboROs;
    }
}