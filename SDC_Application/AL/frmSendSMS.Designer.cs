namespace SDC_Application.AL
{
    partial class frmSendSMS
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvContactList = new System.Windows.Forms.ListView();
            this.btnSelectContact = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.txtMesage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearNumbers = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSendSms);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 356);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 55);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtMesage);
            this.splitContainer1.Size = new System.Drawing.Size(641, 309);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvContactList
            // 
            this.lvContactList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContactList.Location = new System.Drawing.Point(0, 0);
            this.lvContactList.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lvContactList.Name = "lvContactList";
            this.lvContactList.Size = new System.Drawing.Size(305, 258);
            this.lvContactList.TabIndex = 0;
            this.lvContactList.UseCompatibleStateImageBehavior = false;
            // 
            // btnSelectContact
            // 
            this.btnSelectContact.Location = new System.Drawing.Point(163, 7);
            this.btnSelectContact.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSelectContact.Name = "btnSelectContact";
            this.btnSelectContact.Size = new System.Drawing.Size(139, 35);
            this.btnSelectContact.TabIndex = 1;
            this.btnSelectContact.Text = "موبائل نمبرات کا انتخاب کریں";
            this.btnSelectContact.UseVisualStyleBackColor = true;
            this.btnSelectContact.Click += new System.EventHandler(this.btnSelectContact_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearNumbers);
            this.panel3.Controls.Add(this.btnSelectContact);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 49);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lvContactList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 258);
            this.panel4.TabIndex = 1;
            // 
            // btnSendSms
            // 
            this.btnSendSms.Location = new System.Drawing.Point(239, 9);
            this.btnSendSms.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(160, 35);
            this.btnSendSms.TabIndex = 2;
            this.btnSendSms.Text = "ٹیکسٹ میسج بھیجیں";
            this.btnSendSms.UseVisualStyleBackColor = true;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // txtMesage
            // 
            this.txtMesage.Location = new System.Drawing.Point(7, 48);
            this.txtMesage.Multiline = true;
            this.txtMesage.Name = "txtMesage";
            this.txtMesage.Size = new System.Drawing.Size(314, 250);
            this.txtMesage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ٹیکسٹ میسج";
            // 
            // btnClearNumbers
            // 
            this.btnClearNumbers.Location = new System.Drawing.Point(3, 7);
            this.btnClearNumbers.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClearNumbers.Name = "btnClearNumbers";
            this.btnClearNumbers.Size = new System.Drawing.Size(122, 35);
            this.btnClearNumbers.TabIndex = 3;
            this.btnClearNumbers.Text = "نمبرات لسٹ صاف کریں";
            this.btnClearNumbers.UseVisualStyleBackColor = true;
            this.btnClearNumbers.Click += new System.EventHandler(this.btnClearNumbers_Click);
            // 
            // frmSendSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 411);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmSendSMS";
            this.Text = "ٹیکسٹ میسج سروس";
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvContactList;
        private System.Windows.Forms.Button btnSelectContact;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSendSms;
        private System.Windows.Forms.TextBox txtMesage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearNumbers;
    }
}