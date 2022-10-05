namespace SDC_Application.AL
{
    partial class frmReportViewer
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
            this.objReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // objReportViewer
            // 
            this.objReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objReportViewer.Location = new System.Drawing.Point(0, 0);
            this.objReportViewer.Name = "objReportViewer";
            this.objReportViewer.ShowParameterPrompts = false;
            this.objReportViewer.Size = new System.Drawing.Size(911, 391);
            this.objReportViewer.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 391);
            this.Controls.Add(this.objReportViewer);
            this.Name = "frmReportViewer";
            this.Text = "رپورٹ فارم";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer objReportViewer;
    }
}