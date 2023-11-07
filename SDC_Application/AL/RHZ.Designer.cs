namespace SDC_Application.AL
{
    partial class RHZ
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
            this.rbAmalDaramad = new System.Windows.Forms.RadioButton();
            this.rbZereKar = new System.Windows.Forms.RadioButton();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.txtKhattaEnd = new System.Windows.Forms.TextBox();
            this.txtKhattaStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShowRpt = new System.Windows.Forms.Button();
            this.cboMoza = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbAmalDaramad);
            this.panel1.Controls.Add(this.rbZereKar);
            this.panel1.Controls.Add(this.txtPageNo);
            this.panel1.Controls.Add(this.txtKhattaEnd);
            this.panel1.Controls.Add(this.txtKhattaStart);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnShowRpt);
            this.panel1.Controls.Add(this.cboMoza);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 71);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rbAmalDaramad
            // 
            this.rbAmalDaramad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAmalDaramad.AutoSize = true;
            this.rbAmalDaramad.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAmalDaramad.Location = new System.Drawing.Point(307, 19);
            this.rbAmalDaramad.Margin = new System.Windows.Forms.Padding(4);
            this.rbAmalDaramad.Name = "rbAmalDaramad";
            this.rbAmalDaramad.Size = new System.Drawing.Size(86, 35);
            this.rbAmalDaramad.TabIndex = 221;
            this.rbAmalDaramad.Text = "عمل درامد";
            this.rbAmalDaramad.UseVisualStyleBackColor = true;
            this.rbAmalDaramad.Visible = false;
            // 
            // rbZereKar
            // 
            this.rbZereKar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbZereKar.AutoSize = true;
            this.rbZereKar.Checked = true;
            this.rbZereKar.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbZereKar.Location = new System.Drawing.Point(396, 19);
            this.rbZereKar.Margin = new System.Windows.Forms.Padding(4);
            this.rbZereKar.Name = "rbZereKar";
            this.rbZereKar.Size = new System.Drawing.Size(63, 35);
            this.rbZereKar.TabIndex = 220;
            this.rbZereKar.TabStop = true;
            this.rbZereKar.Text = "زیر کار";
            this.rbZereKar.UseVisualStyleBackColor = true;
            this.rbZereKar.Visible = false;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNo.Location = new System.Drawing.Point(497, 21);
            this.txtPageNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(44, 30);
            this.txtPageNo.TabIndex = 219;
            // 
            // txtKhattaEnd
            // 
            this.txtKhattaEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhattaEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhattaEnd.Location = new System.Drawing.Point(622, 21);
            this.txtKhattaEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhattaEnd.Name = "txtKhattaEnd";
            this.txtKhattaEnd.Size = new System.Drawing.Size(39, 30);
            this.txtKhattaEnd.TabIndex = 218;
            // 
            // txtKhattaStart
            // 
            this.txtKhattaStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhattaStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhattaStart.Location = new System.Drawing.Point(776, 21);
            this.txtKhattaStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhattaStart.Name = "txtKhattaStart";
            this.txtKhattaStart.Size = new System.Drawing.Size(41, 30);
            this.txtKhattaStart.TabIndex = 217;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(61, 31);
            this.label5.TabIndex = 216;
            this.label5.Text = "صفحہ نمبر:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(665, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(78, 31);
            this.label3.TabIndex = 215;
            this.label3.Text = "کھاتہ آختتام:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(822, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(66, 31);
            this.label4.TabIndex = 213;
            this.label4.Text = "کھاتہ آغاز:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowRpt
            // 
            this.btnShowRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRpt.Enabled = false;
            this.btnShowRpt.Location = new System.Drawing.Point(174, 15);
            this.btnShowRpt.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowRpt.Name = "btnShowRpt";
            this.btnShowRpt.Size = new System.Drawing.Size(101, 43);
            this.btnShowRpt.TabIndex = 211;
            this.btnShowRpt.Text = "رپورٹ دیکھئے";
            this.btnShowRpt.UseVisualStyleBackColor = true;
            this.btnShowRpt.Click += new System.EventHandler(this.btnShowRpt_Click);
            // 
            // cboMoza
            // 
            this.cboMoza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoza.DisplayMember = "MozaNameUrdu";
            this.cboMoza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoza.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoza.FormattingEnabled = true;
            this.cboMoza.Location = new System.Drawing.Point(895, 17);
            this.cboMoza.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.cboMoza.Name = "cboMoza";
            this.cboMoza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboMoza.Size = new System.Drawing.Size(208, 39);
            this.cboMoza.TabIndex = 209;
            this.cboMoza.ValueMember = "MozaId";
            this.cboMoza.SelectionChangeCommitted += new System.EventHandler(this.cbNonHeadMoza_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1105, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(52, 31);
            this.label1.TabIndex = 210;
            this.label1.Text = "مو ضع:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 71);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1171, 525);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelWidth = 267;
            // 
            // RHZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 596);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RHZ";
            this.Text = "RHZ Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RHZ_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cboMoza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowRpt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.TextBox txtKhattaEnd;
        private System.Windows.Forms.TextBox txtKhattaStart;
        private System.Windows.Forms.RadioButton rbAmalDaramad;
        private System.Windows.Forms.RadioButton rbZereKar;
    }
}

