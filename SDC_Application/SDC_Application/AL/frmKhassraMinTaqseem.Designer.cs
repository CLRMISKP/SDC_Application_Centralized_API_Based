namespace SDC_Application.AL
{
    partial class frmKhassraMinTaqseem
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
            this.txtKhassraNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewKhassra = new System.Windows.Forms.DataGridView();
            this.GetKhassraJatByKhattaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKhassra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhassraJatByKhattaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtKhassraNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 76);
            this.panel1.TabIndex = 0;
            // 
            // txtKhassraNo
            // 
            this.txtKhassraNo.Location = new System.Drawing.Point(382, 39);
            this.txtKhassraNo.Name = "txtKhassraNo";
            this.txtKhassraNo.Size = new System.Drawing.Size(236, 26);
            this.txtKhassraNo.TabIndex = 3;
            this.txtKhassraNo.TextChanged += new System.EventHandler(this.txtKhassraNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "خسرہ نمبر:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(732, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "انتخاب خسرہ جات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel3.Size = new System.Drawing.Size(734, 461);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheckAll);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(602, 17);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(114, 41);
            this.btnCheckAll.TabIndex = 5;
            this.btnCheckAll.Text = "تمام منتخب کریں";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "انتخاب شدہ خسرہ جات محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridViewKhassra);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gridViewKhassra
            // 
            this.gridViewKhassra.AllowUserToAddRows = false;
            this.gridViewKhassra.AllowUserToDeleteRows = false;
            this.gridViewKhassra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewKhassra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewKhassra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.gridViewKhassra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewKhassra.Location = new System.Drawing.Point(3, 22);
            this.gridViewKhassra.Name = "gridViewKhassra";
            this.gridViewKhassra.ReadOnly = true;
            this.gridViewKhassra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewKhassra.Size = new System.Drawing.Size(716, 359);
            this.gridViewKhassra.TabIndex = 0;
            this.gridViewKhassra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewKhassra_CellClick);
            // 
            // chk
            // 
            this.chk.FalseValue = "0";
            this.chk.HeaderText = "انتخاب";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.TrueValue = "1";
            // 
            // frmKhassraMinTaqseem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 537);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKhassraMinTaqseem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "خسرہ جات";
            this.Load += new System.EventHandler(this.frmKhassraMinTaqseem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKhassra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetKhassraJatByKhattaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridViewKhassra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource GetKhassraJatByKhattaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn khassraNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khassraAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khassraIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerHqDKhataIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtKhassraNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
    }
}