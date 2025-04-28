namespace SDC_Application.AL
{
    partial class frmDetailFardReport
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FardReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FardReport);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(1407, 691);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // FardReport
            // 
            this.FardReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FardReport.DocumentMapWidth = 8;
            this.FardReport.Location = new System.Drawing.Point(3, 18);
            this.FardReport.Margin = new System.Windows.Forms.Padding(4);
            this.FardReport.Name = "rvIntiqalReport";
            this.FardReport.ShowParameterPrompts = false;
            this.FardReport.Size = new System.Drawing.Size(1401, 670);
            this.FardReport.TabIndex = 0;
            // 
            // frmDetailFardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 691);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmDetailFardReport";
            this.Text = "تفصیلی فرد پرنٹ";
            this.Load += new System.EventHandler(this.frmDetailFardReport_Load);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer FardReport;
    }
}