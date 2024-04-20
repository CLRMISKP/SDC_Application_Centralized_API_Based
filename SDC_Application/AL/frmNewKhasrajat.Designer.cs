namespace SDC_Application.AL
{
    partial class frmNewKhasrajat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKhatooniNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhasraNo = new System.Windows.Forms.TextBox();
            this.chkkhasrajat = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.grdKhasrajat = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnselect = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhasrajat)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtKhatooniNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtKhasraNo);
            this.panel1.Controls.Add(this.chkkhasrajat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 55);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "کھتونی نمبر";
            // 
            // txtKhatooniNo
            // 
            this.txtKhatooniNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniNo.Location = new System.Drawing.Point(188, 14);
            this.txtKhatooniNo.Name = "txtKhatooniNo";
            this.txtKhatooniNo.Size = new System.Drawing.Size(112, 39);
            this.txtKhatooniNo.TabIndex = 4;
            this.txtKhatooniNo.TextChanged += new System.EventHandler(this.txtKhatooniNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "منتخب شدہ خسرے";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "خسرہ نمبر";
            // 
            // txtKhasraNo
            // 
            this.txtKhasraNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhasraNo.Location = new System.Drawing.Point(372, 13);
            this.txtKhasraNo.Name = "txtKhasraNo";
            this.txtKhasraNo.Size = new System.Drawing.Size(112, 39);
            this.txtKhasraNo.TabIndex = 1;
            this.txtKhasraNo.TextChanged += new System.EventHandler(this.txtKhasraNo_TextChanged);
            // 
            // chkkhasrajat
            // 
            this.chkkhasrajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkkhasrajat.AutoSize = true;
            this.chkkhasrajat.Location = new System.Drawing.Point(560, 23);
            this.chkkhasrajat.Name = "chkkhasrajat";
            this.chkkhasrajat.Size = new System.Drawing.Size(110, 35);
            this.chkkhasrajat.TabIndex = 0;
            this.chkkhasrajat.Text = "تمام منتخب کریں";
            this.chkkhasrajat.UseVisualStyleBackColor = true;
            this.chkkhasrajat.CheckedChanged += new System.EventHandler(this.chkkhasrajat_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkedListBox1);
            this.panel5.Controls.Add(this.grdKhasrajat);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 55);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(673, 323);
            this.panel5.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(2, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(200, 323);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.DoubleClick += new System.EventHandler(this.checkedListBox1_DoubleClick);
            // 
            // grdKhasrajat
            // 
            this.grdKhasrajat.AllowUserToAddRows = false;
            this.grdKhasrajat.AllowUserToDeleteRows = false;
            this.grdKhasrajat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdKhasrajat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdKhasrajat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.grdKhasrajat.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdKhasrajat.Location = new System.Drawing.Point(202, 0);
            this.grdKhasrajat.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grdKhasrajat.Name = "grdKhasrajat";
            this.grdKhasrajat.ReadOnly = true;
            this.grdKhasrajat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdKhasrajat.Size = new System.Drawing.Size(471, 323);
            this.grdKhasrajat.TabIndex = 0;
            this.grdKhasrajat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdKhasrajat_CellContentClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "انتخاب کریں";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(550, 48);
            this.btnselect.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(79, 42);
            this.btnselect.TabIndex = 4;
            this.btnselect.Text = "انتخاب کریں";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Visible = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnselect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 378);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 102);
            this.panel3.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(402, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 42);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmNewKhasrajat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(673, 480);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmNewKhasrajat";
            this.Text = "کھاتہ حال سے نمبر خسرہ جات کا انتخاب ";
            this.Load += new System.EventHandler(this.frmNewKhasrajat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKhasrajat)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView grdKhasrajat;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.CheckBox chkkhasrajat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKhasraNo;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKhatooniNo;
    }
}