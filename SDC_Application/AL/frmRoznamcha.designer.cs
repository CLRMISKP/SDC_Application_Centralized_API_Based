namespace SDC_Application.AL
{
    partial class frmRoznamcha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoznamcha));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIntiqalNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btntehsildarreport = new System.Windows.Forms.Button();
            this.txtRoznamcha = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblIntiqalNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 70);
            this.panel1.TabIndex = 0;
            // 
            // lblIntiqalNo
            // 
            this.lblIntiqalNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIntiqalNo.Font = new System.Drawing.Font("Alvi Nastaleeq", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntiqalNo.ForeColor = System.Drawing.Color.Blue;
            this.lblIntiqalNo.Location = new System.Drawing.Point(437, 8);
            this.lblIntiqalNo.Name = "lblIntiqalNo";
            this.lblIntiqalNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIntiqalNo.Size = new System.Drawing.Size(200, 36);
            this.lblIntiqalNo.TabIndex = 1;
            this.lblIntiqalNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Alvi Nastaleeq", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(643, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 36);
            this.label8.TabIndex = 0;
            this.label8.Text = "انتقال نمبر:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btntehsildarreport);
            this.groupBox1.Controls.Add(this.txtRoznamcha);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(993, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackgroundImage = global::SDC_Application.Resource1.Print31;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(336, 236);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(59, 50);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SDC_Application.Resource1.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(444, 234);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 50);
            this.btnSave.TabIndex = 12;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btntehsildarreport
            // 
            this.btntehsildarreport.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntehsildarreport.Location = new System.Drawing.Point(912, 56);
            this.btntehsildarreport.Name = "btntehsildarreport";
            this.btntehsildarreport.Size = new System.Drawing.Size(75, 52);
            this.btntehsildarreport.TabIndex = 11;
            this.btntehsildarreport.Text = "روزنامچہ";
            this.btntehsildarreport.UseVisualStyleBackColor = true;
            this.btntehsildarreport.Click += new System.EventHandler(this.btntehsildarreport_Click);
            // 
            // txtRoznamcha
            // 
            this.txtRoznamcha.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoznamcha.Location = new System.Drawing.Point(12, 6);
            this.txtRoznamcha.Multiline = true;
            this.txtRoznamcha.Name = "txtRoznamcha";
            this.txtRoznamcha.Size = new System.Drawing.Size(894, 214);
            this.txtRoznamcha.TabIndex = 4;
            this.txtRoznamcha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTehsilReport_KeyPress);
            // 
            // frmRoznamcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 389);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRoznamcha";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "روزنامچہ";
            this.Load += new System.EventHandler(this.frmIntiqalRevenueReports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRoznamcha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblIntiqalNo;
        private System.Windows.Forms.Button btntehsildarreport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
    }
}