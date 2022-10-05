namespace SDC_Application
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ریجیسٹریشنToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegestration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearchToken = new System.Windows.Forms.ToolStripMenuItem();
            this.رقمکیرسیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.نیارسیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReciptMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ریپورٹسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rptDatetoDate = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMozaName = new System.Windows.Forms.Label();
            this.linkLabelMoza = new System.Windows.Forms.LinkLabel();
            this.txtMozaID = new System.Windows.Forms.TextBox();
            this.labelMoza = new System.Windows.Forms.Label();
            this.mnuMalikKhattasForFard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ریجیسٹریشنToolStripMenuItem,
            this.رقمکیرسیدToolStripMenuItem,
            this.ریپورٹسToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1098, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ریجیسٹریشنToolStripMenuItem
            // 
            this.ریجیسٹریشنToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegestration,
            this.menuSearchToken,
            this.mnuMalikKhattasForFard});
            this.ریجیسٹریشنToolStripMenuItem.Name = "ریجیسٹریشنToolStripMenuItem";
            this.ریجیسٹریشنToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.ریجیسٹریشنToolStripMenuItem.Text = "ٹوکن";
            // 
            // menuRegestration
            // 
            this.menuRegestration.Name = "menuRegestration";
            this.menuRegestration.Size = new System.Drawing.Size(221, 24);
            this.menuRegestration.Text = "ٹوکن رجسٹریشن";
            this.menuRegestration.Click += new System.EventHandler(this.menuRegestration_Click);
            // 
            // menuSearchToken
            // 
            this.menuSearchToken.Name = "menuSearchToken";
            this.menuSearchToken.Size = new System.Drawing.Size(221, 24);
            this.menuSearchToken.Text = "ٹوکن تلاش کریں";
            this.menuSearchToken.Click += new System.EventHandler(this.menuSearchToken_Click);
            // 
            // رقمکیرسیدToolStripMenuItem
            // 
            this.رقمکیرسیدToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.نیارسیدToolStripMenuItem,
            this.ReciptMenu});
            this.رقمکیرسیدToolStripMenuItem.Name = "رقمکیرسیدToolStripMenuItem";
            this.رقمکیرسیدToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.رقمکیرسیدToolStripMenuItem.Text = "فیس";
            // 
            // نیارسیدToolStripMenuItem
            // 
            this.نیارسیدToolStripMenuItem.Name = "نیارسیدToolStripMenuItem";
            this.نیارسیدToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.نیارسیدToolStripMenuItem.Text = "چلان";
            this.نیارسیدToolStripMenuItem.Click += new System.EventHandler(this.نیارسیدToolStripMenuItem_Click);
            // 
            // ReciptMenu
            // 
            this.ReciptMenu.Name = "ReciptMenu";
            this.ReciptMenu.Size = new System.Drawing.Size(152, 24);
            this.ReciptMenu.Text = "رسید";
            this.ReciptMenu.Click += new System.EventHandler(this.ReciptMenu_Click);
            // 
            // ریپورٹسToolStripMenuItem
            // 
            this.ریپورٹسToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rptDatetoDate});
            this.ریپورٹسToolStripMenuItem.Name = "ریپورٹسToolStripMenuItem";
            this.ریپورٹسToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.ریپورٹسToolStripMenuItem.Text = "ریپورٹس";
            this.ریپورٹسToolStripMenuItem.Visible = false;
            // 
            // rptDatetoDate
            // 
            this.rptDatetoDate.Name = "rptDatetoDate";
            this.rptDatetoDate.Size = new System.Drawing.Size(176, 24);
            this.rptDatetoDate.Text = "ریپوٹ ٹوکن تاریخ ";
            this.rptDatetoDate.Click += new System.EventHandler(this.rptDatetoDate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMozaID);
            this.panel1.Controls.Add(this.labelMoza);
            this.panel1.Controls.Add(this.lblMozaName);
            this.panel1.Controls.Add(this.linkLabelMoza);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 29);
            this.panel1.TabIndex = 4;
            // 
            // lblMozaName
            // 
            this.lblMozaName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMozaName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMozaName.ForeColor = System.Drawing.Color.Red;
            this.lblMozaName.Location = new System.Drawing.Point(109, 0);
            this.lblMozaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMozaName.Name = "lblMozaName";
            this.lblMozaName.Size = new System.Drawing.Size(154, 29);
            this.lblMozaName.TabIndex = 77;
            this.lblMozaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelMoza
            // 
            this.linkLabelMoza.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelMoza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelMoza.Location = new System.Drawing.Point(0, 0);
            this.linkLabelMoza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelMoza.Name = "linkLabelMoza";
            this.linkLabelMoza.Size = new System.Drawing.Size(109, 29);
            this.linkLabelMoza.TabIndex = 76;
            this.linkLabelMoza.TabStop = true;
            this.linkLabelMoza.Text = " موضع تبدیل کریں";
            this.linkLabelMoza.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelMoza.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMoza_LinkClicked);
            // 
            // txtMozaID
            // 
            this.txtMozaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMozaID.Enabled = false;
            this.txtMozaID.Location = new System.Drawing.Point(359, 3);
            this.txtMozaID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMozaID.Name = "txtMozaID";
            this.txtMozaID.ReadOnly = true;
            this.txtMozaID.Size = new System.Drawing.Size(18, 26);
            this.txtMozaID.TabIndex = 213;
            this.txtMozaID.Text = "0";
            this.txtMozaID.Visible = false;
            // 
            // labelMoza
            // 
            this.labelMoza.AutoSize = true;
            this.labelMoza.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoza.Location = new System.Drawing.Point(271, 5);
            this.labelMoza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoza.Name = "labelMoza";
            this.labelMoza.Size = new System.Drawing.Size(90, 19);
            this.labelMoza.TabIndex = 75;
            this.labelMoza.Text = "منتخب موضع:-";
            // 
            // mnuMalikKhattasForFard
            // 
            this.mnuMalikKhattasForFard.Name = "mnuMalikKhattasForFard";
            this.mnuMalikKhattasForFard.Size = new System.Drawing.Size(221, 24);
            this.mnuMalikKhattasForFard.Text = "مالک کھاتہ جات برائے فرد";
            this.mnuMalikKhattasForFard.Click += new System.EventHandler(this.mnuMalikKhattasForFard_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ریجیسٹریشنToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRegestration;
        private System.Windows.Forms.ToolStripMenuItem menuSearchToken;
        private System.Windows.Forms.ToolStripMenuItem رقمکیرسیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem نیارسیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ریپورٹسToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rptDatetoDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMozaName;
        private System.Windows.Forms.LinkLabel linkLabelMoza;
        private System.Windows.Forms.Label labelMoza;
        private System.Windows.Forms.TextBox txtMozaID;
        private System.Windows.Forms.ToolStripMenuItem ReciptMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMalikKhattasForFard;
    }
}