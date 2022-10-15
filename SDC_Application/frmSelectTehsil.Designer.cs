namespace SDC_Application
{
    partial class frmSelectTehsil
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
            this.cmdDistrict = new System.Windows.Forms.ComboBox();
            this.cmbTehsil = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDistrict
            // 
            this.cmdDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmdDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDistrict.Font = new System.Drawing.Font("Alvi Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDistrict.FormattingEnabled = true;
            this.cmdDistrict.Location = new System.Drawing.Point(94, 34);
            this.cmdDistrict.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDistrict.Name = "cmdDistrict";
            this.cmdDistrict.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdDistrict.Size = new System.Drawing.Size(427, 44);
            this.cmdDistrict.TabIndex = 0;
            this.cmdDistrict.SelectedIndexChanged += new System.EventHandler(this.cmdDistrict_SelectedIndexChanged);
            // 
            // cmbTehsil
            // 
            this.cmbTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTehsil.Font = new System.Drawing.Font("Alvi Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTehsil.FormattingEnabled = true;
            this.cmbTehsil.Location = new System.Drawing.Point(94, 107);
            this.cmbTehsil.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTehsil.Name = "cmbTehsil";
            this.cmbTehsil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTehsil.Size = new System.Drawing.Size(427, 44);
            this.cmbTehsil.TabIndex = 1;
            this.cmbTehsil.SelectedIndexChanged += new System.EventHandler(this.cmbTehsil_SelectedIndexChanged);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(179, 183);
            this.ok.Margin = new System.Windows.Forms.Padding(4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(155, 49);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(342, 183);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(155, 49);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(532, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "ضلع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Alvi Nastaleeq", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(532, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "تحصیل";
            // 
            // frmSelectTehsil
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(707, 292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cmbTehsil);
            this.Controls.Add(this.cmdDistrict);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectTehsil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ضلع اور تحصیل کا انتخاب";
            this.Load += new System.EventHandler(this.frmSelectTehsil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmdDistrict;
        private System.Windows.Forms.ComboBox cmbTehsil;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}