namespace SDC_Application
{
    partial class frmNewIntiqalDoc
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
            this.radUpperButton = new System.Windows.Forms.RadioButton();
            this.radLowerButton = new System.Windows.Forms.RadioButton();
            this.radInBetweenButton = new System.Windows.Forms.RadioButton();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radUpperButton
            // 
            this.radUpperButton.AutoSize = true;
            this.radUpperButton.Location = new System.Drawing.Point(391, 20);
            this.radUpperButton.Name = "radUpperButton";
            this.radUpperButton.Size = new System.Drawing.Size(45, 29);
            this.radUpperButton.TabIndex = 13;
            this.radUpperButton.TabStop = true;
            this.radUpperButton.Text = "اول";
            this.radUpperButton.UseVisualStyleBackColor = true;
            // 
            // radLowerButton
            // 
            this.radLowerButton.AutoSize = true;
            this.radLowerButton.Location = new System.Drawing.Point(333, 20);
            this.radLowerButton.Name = "radLowerButton";
            this.radLowerButton.Size = new System.Drawing.Size(41, 29);
            this.radLowerButton.TabIndex = 12;
            this.radLowerButton.TabStop = true;
            this.radLowerButton.Text = "آخر";
            this.radLowerButton.UseVisualStyleBackColor = true;
            // 
            // radInBetweenButton
            // 
            this.radInBetweenButton.AutoSize = true;
            this.radInBetweenButton.Location = new System.Drawing.Point(242, 19);
            this.radInBetweenButton.Name = "radInBetweenButton";
            this.radInBetweenButton.Size = new System.Drawing.Size(79, 29);
            this.radInBetweenButton.TabIndex = 11;
            this.radInBetweenButton.TabStop = true;
            this.radInBetweenButton.Text = "درمیان میں";
            this.radInBetweenButton.UseVisualStyleBackColor = true;
            this.radInBetweenButton.CheckedChanged += new System.EventHandler(this.radInBetweenButton_CheckedChanged);
            this.radInBetweenButton.Click += new System.EventHandler(this.radInBetweenButton_Click);
            // 
            // txtPageNo
            // 
            this.txtPageNo.Location = new System.Drawing.Point(90, 19);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(146, 33);
            this.txtPageNo.TabIndex = 10;
            this.txtPageNo.Visible = false;
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenDialog.Location = new System.Drawing.Point(342, 2);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(88, 44);
            this.btnOpenDialog.TabIndex = 14;
            this.btnOpenDialog.Text = "تصویر چنیئے";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radInBetweenButton);
            this.groupBox1.Controls.Add(this.radLowerButton);
            this.groupBox1.Controls.Add(this.txtPageNo);
            this.groupBox1.Controls.Add(this.radUpperButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 167);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(225, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 44);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "منسوح کیچیئے";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnOpenDialog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 50);
            this.panel1.TabIndex = 17;
            // 
            // frmNewIntiqalDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 167);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmNewIntiqalDoc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تصویر کا انتخاب کریں";
            this.Load += new System.EventHandler(this.frmNewIntiqalDoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radUpperButton;
        private System.Windows.Forms.RadioButton radLowerButton;
        private System.Windows.Forms.RadioButton radInBetweenButton;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
    }
}