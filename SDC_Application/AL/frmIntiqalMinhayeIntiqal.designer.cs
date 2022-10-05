namespace SDC_Application.AL
{
    partial class frmIntiqalMinhayeIntiqal
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgMinhayeIntiqal = new System.Windows.Forms.DataGridView();
            this.cmbIntialListForMinhayeIntiqal = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.TTMozaSelection = new System.Windows.Forms.ToolTip(this.components);
            this.ColSel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMinhayeIntiqal)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 57);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "منہائے انتقال نمبر";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 379);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 34);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(12, 20, 12, 20);
            this.panel3.Size = new System.Drawing.Size(415, 322);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.dgMinhayeIntiqal);
            this.groupBox1.Controls.Add(this.cmbIntialListForMinhayeIntiqal);
            this.groupBox1.Controls.Add(this.label89);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(389, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(24, 22);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 50);
            this.btnSave.TabIndex = 91;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgMinhayeIntiqal
            // 
            this.dgMinhayeIntiqal.AllowUserToAddRows = false;
            this.dgMinhayeIntiqal.AllowUserToDeleteRows = false;
            this.dgMinhayeIntiqal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMinhayeIntiqal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMinhayeIntiqal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSel});
            this.dgMinhayeIntiqal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgMinhayeIntiqal.Location = new System.Drawing.Point(3, 80);
            this.dgMinhayeIntiqal.Name = "dgMinhayeIntiqal";
            this.dgMinhayeIntiqal.RowHeadersVisible = false;
            this.dgMinhayeIntiqal.Size = new System.Drawing.Size(383, 195);
            this.dgMinhayeIntiqal.TabIndex = 90;
            this.dgMinhayeIntiqal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMinhayeIntiqal_CellClick);
            // 
            // cmbIntialListForMinhayeIntiqal
            // 
            this.cmbIntialListForMinhayeIntiqal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIntialListForMinhayeIntiqal.DisplayMember = "IntiqalInitiationType";
            this.cmbIntialListForMinhayeIntiqal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntialListForMinhayeIntiqal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIntialListForMinhayeIntiqal.FormattingEnabled = true;
            this.cmbIntialListForMinhayeIntiqal.Location = new System.Drawing.Point(125, 34);
            this.cmbIntialListForMinhayeIntiqal.Name = "cmbIntialListForMinhayeIntiqal";
            this.cmbIntialListForMinhayeIntiqal.Size = new System.Drawing.Size(141, 27);
            this.cmbIntialListForMinhayeIntiqal.TabIndex = 88;
            this.cmbIntialListForMinhayeIntiqal.Tag = "1";
            this.cmbIntialListForMinhayeIntiqal.ValueMember = "IntiqalInitiationId";
            // 
            // label89
            // 
            this.label89.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Alvi Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(272, 31);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(104, 30);
            this.label89.TabIndex = 89;
            this.label89.Text = "بعد از منہائے انتقال";
            // 
            // ColSel
            // 
            this.ColSel.HeaderText = "خذف کریں";
            this.ColSel.Name = "ColSel";
            // 
            // frmIntiqalMinhayeIntiqal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 413);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmIntiqalMinhayeIntiqal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب موضع";
            this.Load += new System.EventHandler(this.frmIntiqalMinhayeIntiqal_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMinhayeIntiqal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip TTMozaSelection;
        private System.Windows.Forms.DataGridView dgMinhayeIntiqal;
        private System.Windows.Forms.ComboBox cmbIntialListForMinhayeIntiqal;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewButtonColumn ColSel;
    }
}