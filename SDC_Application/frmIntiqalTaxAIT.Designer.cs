namespace SDC_Application
{
    partial class frmIntiqalTaxAIT
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSeller = new System.Windows.Forms.TabPage();
            this.tabBayan = new System.Windows.Forms.TabPage();
            this.reportViewerSeller = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerBuyers = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabControl1.SuspendLayout();
            this.tabSeller.SuspendLayout();
            this.tabBayan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSeller);
            this.tabControl1.Controls.Add(this.tabBayan);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSeller
            // 
            this.tabSeller.Controls.Add(this.reportViewerSeller);
            this.tabSeller.Location = new System.Drawing.Point(4, 34);
            this.tabSeller.Name = "tabSeller";
            this.tabSeller.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeller.Size = new System.Drawing.Size(970, 421);
            this.tabSeller.TabIndex = 0;
            this.tabSeller.Text = "لینڈ ٹیکس چیک بائعان/متوافی/دہندہ";
            this.tabSeller.UseVisualStyleBackColor = true;
            // 
            // tabBayan
            // 
            this.tabBayan.Controls.Add(this.reportViewerBuyers);
            this.tabBayan.Location = new System.Drawing.Point(4, 34);
            this.tabBayan.Name = "tabBayan";
            this.tabBayan.Padding = new System.Windows.Forms.Padding(3);
            this.tabBayan.Size = new System.Drawing.Size(970, 421);
            this.tabBayan.TabIndex = 1;
            this.tabBayan.Text = " لینڈ ٹیکس چیک مشتریان/وارثان/گریندہ";
            this.tabBayan.UseVisualStyleBackColor = true;
            // 
            // reportViewerSeller
            // 
            this.reportViewerSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerSeller.Location = new System.Drawing.Point(3, 3);
            this.reportViewerSeller.Name = "reportViewerSeller";
            this.reportViewerSeller.Size = new System.Drawing.Size(964, 415);
            this.reportViewerSeller.TabIndex = 0;
            // 
            // reportViewerBuyers
            // 
            this.reportViewerBuyers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerBuyers.Location = new System.Drawing.Point(3, 3);
            this.reportViewerBuyers.Name = "reportViewerBuyers";
            this.reportViewerBuyers.Size = new System.Drawing.Size(964, 415);
            this.reportViewerBuyers.TabIndex = 0;
            // 
            // frmIntiqalTaxAIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 459);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmIntiqalTaxAIT";
            this.Text = "لینڈ ٹیکس";
            this.Load += new System.EventHandler(this.frmIntiqalTaxAIT_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSeller.ResumeLayout(false);
            this.tabBayan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSeller;
        private System.Windows.Forms.TabPage tabBayan;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerSeller;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBuyers;
    }
}