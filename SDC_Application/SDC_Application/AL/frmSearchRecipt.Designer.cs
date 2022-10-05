namespace SDC_Application.AL
{
    partial class frmSearchRecipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchRecipt));
            this.errorNumeric = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorChar = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.grdTokenData = new System.Windows.Forms.DataGridView();
            this.lblmultisearch = new System.Windows.Forms.Label();
            this.txtNCIC = new System.Windows.Forms.TextBox();
            this.txtPVNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.toolTipSearchRecipt = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTokenData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorNumeric
            // 
            this.errorNumeric.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorNumeric.ContainerControl = this;
            this.errorNumeric.Icon = ((System.Drawing.Icon)(resources.GetObject("errorNumeric.Icon")));
            this.errorNumeric.RightToLeft = true;
            // 
            // errorChar
            // 
            this.errorChar.ContainerControl = this;
            this.errorChar.RightToLeft = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1394, 408);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Records Founded::";
            // 
            // grdTokenData
            // 
            this.grdTokenData.AllowUserToAddRows = false;
            this.grdTokenData.AllowUserToDeleteRows = false;
            this.grdTokenData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTokenData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTokenData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTokenData.Location = new System.Drawing.Point(3, 22);
            this.grdTokenData.Name = "grdTokenData";
            this.grdTokenData.ReadOnly = true;
            this.grdTokenData.Size = new System.Drawing.Size(1010, 303);
            this.grdTokenData.TabIndex = 59;
            this.grdTokenData.DoubleClick += new System.EventHandler(this.grdTokenData_DoubleClick);
            // 
            // lblmultisearch
            // 
            this.lblmultisearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblmultisearch.AutoSize = true;
            this.lblmultisearch.BackColor = System.Drawing.SystemColors.Control;
            this.lblmultisearch.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.lblmultisearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblmultisearch.Location = new System.Drawing.Point(270, 38);
            this.lblmultisearch.Name = "lblmultisearch";
            this.lblmultisearch.Size = new System.Drawing.Size(38, 30);
            this.lblmultisearch.TabIndex = 60;
            this.lblmultisearch.Text = "تاریخ";
            // 
            // txtNCIC
            // 
            this.txtNCIC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNCIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNCIC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCIC.Location = new System.Drawing.Point(548, 37);
            this.txtNCIC.Name = "txtNCIC";
            this.txtNCIC.Size = new System.Drawing.Size(147, 29);
            this.txtNCIC.TabIndex = 62;
            this.txtNCIC.TextChanged += new System.EventHandler(this.txtNCIC_TextChanged);
            this.txtNCIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNCIC_KeyPress);
            // 
            // txtPVNO
            // 
            this.txtPVNO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPVNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPVNO.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPVNO.Location = new System.Drawing.Point(797, 38);
            this.txtPVNO.Multiline = true;
            this.txtPVNO.Name = "txtPVNO";
            this.txtPVNO.Size = new System.Drawing.Size(147, 27);
            this.txtPVNO.TabIndex = 63;
            this.txtPVNO.TextChanged += new System.EventHandler(this.txtPVNO_TextChanged);
            this.txtPVNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPVNO_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(950, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 30);
            this.label1.TabIndex = 64;
            this.label1.Text = "چالان نمبر";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(701, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 30);
            this.label2.TabIndex = 65;
            this.label2.Text = "شناختی کارڈ نمبر";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblmultisearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNCIC);
            this.groupBox1.Controls.Add(this.txtPVNO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 76);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تلاش کریں";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(347, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 33);
            this.txtName.TabIndex = 69;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(500, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 30);
            this.label3.TabIndex = 68;
            this.label3.Text = "نام ";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SDC_Application.Resource1._1338735730_search_lense;
            this.btnSearch.Location = new System.Drawing.Point(44, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 31);
            this.btnSearch.TabIndex = 66;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTime
            // 
            this.dateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTime.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime.CustomFormat = "dd/MM/yyyy";
            this.dateTime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(113, 37);
            this.dateTime.Name = "dateTime";
            this.dateTime.RightToLeftLayout = true;
            this.dateTime.Size = new System.Drawing.Size(160, 29);
            this.dateTime.TabIndex = 67;
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1036, 443);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdTokenData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(10, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1016, 328);
            this.groupBox3.TabIndex = 67;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تفصیل";
            // 
            // frmSearchRecipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearchRecipt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "چالان نمبر تلاش کریں";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTokenData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ErrorProvider errorNumeric;
        private System.Windows.Forms.ErrorProvider errorChar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdTokenData;
        private System.Windows.Forms.Label lblmultisearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPVNO;
        private System.Windows.Forms.TextBox txtNCIC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTipSearchRecipt;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}