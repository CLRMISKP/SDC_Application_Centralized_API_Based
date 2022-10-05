namespace SDC_Application.AL
{
    partial class frmIntiqalDucomentCheckList
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
            this.gdrDucoments = new System.Windows.Forms.DataGridView();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckList = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.increment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIntiqalDocRecId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntiwal = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDucomentsUpdate = new System.Windows.Forms.DataGridView();
            this.DeleteDucoment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntiqalDocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAddDoc = new System.Windows.Forms.CheckBox();
            this.chkDelDoc = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdrDucoments)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDucomentsUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // gdrDucoments
            // 
            this.gdrDucoments.AllowUserToAddRows = false;
            this.gdrDucoments.AllowUserToDeleteRows = false;
            this.gdrDucoments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdrDucoments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdrDucoments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.CheckList,
            this.increment});
            this.gdrDucoments.Dock = System.Windows.Forms.DockStyle.Right;
            this.gdrDucoments.Location = new System.Drawing.Point(537, 63);
            this.gdrDucoments.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gdrDucoments.Name = "gdrDucoments";
            this.gdrDucoments.ReadOnly = true;
            this.gdrDucoments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdrDucoments.Size = new System.Drawing.Size(477, 392);
            this.gdrDucoments.TabIndex = 0;
            this.gdrDucoments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdrDucoments_CellClick);
            // 
            // Seq
            // 
            this.Seq.FillWeight = 111.9289F;
            this.Seq.HeaderText = "نمبر شمار";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Visible = false;
            // 
            // CheckList
            // 
            this.CheckList.FillWeight = 76.14214F;
            this.CheckList.HeaderText = "انتخاب کریں";
            this.CheckList.Name = "CheckList";
            this.CheckList.ReadOnly = true;
            // 
            // increment
            // 
            this.increment.FillWeight = 111.9289F;
            this.increment.HeaderText = "increment";
            this.increment.Name = "increment";
            this.increment.ReadOnly = true;
            // 
            // txtIntiqalDocRecId
            // 
            this.txtIntiqalDocRecId.Location = new System.Drawing.Point(910, 62);
            this.txtIntiqalDocRecId.Name = "txtIntiqalDocRecId";
            this.txtIntiqalDocRecId.Size = new System.Drawing.Size(66, 33);
            this.txtIntiqalDocRecId.TabIndex = 1;
            this.txtIntiqalDocRecId.Text = "-1";
            this.txtIntiqalDocRecId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDelDoc);
            this.groupBox1.Controls.Add(this.chkAddDoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 63);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دستاویزات ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "منتخب شدہ دستاویزات ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "دستاویزات کا انتخاب کریں";
            // 
            // txtIntiwal
            // 
            this.txtIntiwal.Location = new System.Drawing.Point(910, 12);
            this.txtIntiwal.Name = "txtIntiwal";
            this.txtIntiwal.Size = new System.Drawing.Size(66, 33);
            this.txtIntiwal.TabIndex = 22;
            this.txtIntiwal.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::SDC_Application.Resource1.LeftImage;
            this.btnDelete.Location = new System.Drawing.Point(460, 241);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 66);
            this.btnDelete.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف کریں");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.rightimage;
            this.btnSave.Location = new System.Drawing.Point(460, 152);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 66);
            this.btnSave.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnSave, "محفوظ کریں");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 455);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1014, 72);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // grdDucomentsUpdate
            // 
            this.grdDucomentsUpdate.AllowUserToAddRows = false;
            this.grdDucomentsUpdate.AllowUserToDeleteRows = false;
            this.grdDucomentsUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDucomentsUpdate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteDucoment,
            this.SeqNo,
            this.Doc,
            this.IntiqalDocId});
            this.grdDucomentsUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdDucomentsUpdate.Location = new System.Drawing.Point(0, 63);
            this.grdDucomentsUpdate.Name = "grdDucomentsUpdate";
            this.grdDucomentsUpdate.ReadOnly = true;
            this.grdDucomentsUpdate.Size = new System.Drawing.Size(454, 392);
            this.grdDucomentsUpdate.TabIndex = 24;
            this.grdDucomentsUpdate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDucomentsUpdate_CellClick);
            // 
            // DeleteDucoment
            // 
            this.DeleteDucoment.HeaderText = "انتخاب کریں";
            this.DeleteDucoment.Name = "DeleteDucoment";
            this.DeleteDucoment.ReadOnly = true;
            this.DeleteDucoment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteDucoment.Width = 50;
            // 
            // SeqNo
            // 
            this.SeqNo.HeaderText = "نمبرشمار";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.ReadOnly = true;
            this.SeqNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SeqNo.Visible = false;
            // 
            // Doc
            // 
            this.Doc.HeaderText = "دستاویزکا نام";
            this.Doc.Name = "Doc";
            this.Doc.ReadOnly = true;
            // 
            // IntiqalDocId
            // 
            this.IntiqalDocId.HeaderText = "IntiqalDocId";
            this.IntiqalDocId.Name = "IntiqalDocId";
            this.IntiqalDocId.ReadOnly = true;
            // 
            // chkAddDoc
            // 
            this.chkAddDoc.AutoSize = true;
            this.chkAddDoc.Location = new System.Drawing.Point(375, 26);
            this.chkAddDoc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkAddDoc.Name = "chkAddDoc";
            this.chkAddDoc.Size = new System.Drawing.Size(102, 34);
            this.chkAddDoc.TabIndex = 2;
            this.chkAddDoc.Text = "تمام منتخب کریں";
            this.chkAddDoc.UseVisualStyleBackColor = true;
            this.chkAddDoc.Click += new System.EventHandler(this.chkAddDoc_Click);
            // 
            // chkDelDoc
            // 
            this.chkDelDoc.AutoSize = true;
            this.chkDelDoc.Location = new System.Drawing.Point(907, 30);
            this.chkDelDoc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkDelDoc.Name = "chkDelDoc";
            this.chkDelDoc.Size = new System.Drawing.Size(102, 34);
            this.chkDelDoc.TabIndex = 3;
            this.chkDelDoc.Text = "تمام منتخب کریں";
            this.chkDelDoc.UseVisualStyleBackColor = true;
            this.chkDelDoc.Click += new System.EventHandler(this.chkDelDoc_Click);
            // 
            // frmIntiqalDucomentCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 527);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gdrDucoments);
            this.Controls.Add(this.grdDucomentsUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtIntiwal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIntiqalDocRecId);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmIntiqalDucomentCheckList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "دستاویزات انتقالات ";
            this.Load += new System.EventHandler(this.frmIntiqalDucomentCheckList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdrDucoments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDucomentsUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdrDucoments;
        private System.Windows.Forms.TextBox txtIntiqalDocRecId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIntiwal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdDucomentsUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckList;
        private System.Windows.Forms.DataGridViewTextBoxColumn increment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeleteDucoment;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntiqalDocId;
        private System.Windows.Forms.CheckBox chkDelDoc;
        private System.Windows.Forms.CheckBox chkAddDoc;
    }
}