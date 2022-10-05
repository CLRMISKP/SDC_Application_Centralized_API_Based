namespace LandInfo.ControlsLib
{
    partial class khasraControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgKhasra = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewKhasrajat = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKhasra)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 175);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgKhasra);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 171);
            this.panel3.TabIndex = 0;
            // 
            // dgKhasra
            // 
            this.dgKhasra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKhasra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKhasra.Location = new System.Drawing.Point(0, 0);
            this.dgKhasra.Name = "dgKhasra";
            this.dgKhasra.Size = new System.Drawing.Size(411, 171);
            this.dgKhasra.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnNewKhasrajat);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 35);
            this.panel1.TabIndex = 4;
            // 
            // btnNewKhasrajat
            // 
            this.btnNewKhasrajat.Location = new System.Drawing.Point(114, 1);
            this.btnNewKhasrajat.Name = "btnNewKhasrajat";
            this.btnNewKhasrajat.Size = new System.Drawing.Size(136, 31);
            this.btnNewKhasrajat.TabIndex = 1;
            this.btnNewKhasrajat.Text = "نیےحسرہ کا اندراج کریں";
            this.btnNewKhasrajat.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(256, 1);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 31);
            this.btnModify.TabIndex = 0;
            this.btnModify.Text = "تبدیل کریں";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // khatooniControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "khatooniControl";
            this.Size = new System.Drawing.Size(415, 210);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKhasra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgKhasra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewKhasrajat;
        private System.Windows.Forms.Button btnModify;
    }
}
