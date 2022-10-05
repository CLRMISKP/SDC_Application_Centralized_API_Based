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
            this.SuspendLayout();
            // 
            // cmdDistrict
            // 
            this.cmdDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDistrict.FormattingEnabled = true;
            this.cmdDistrict.Location = new System.Drawing.Point(108, 67);
            this.cmdDistrict.Name = "cmdDistrict";
            this.cmdDistrict.Size = new System.Drawing.Size(371, 21);
            this.cmdDistrict.TabIndex = 0;
            this.cmdDistrict.SelectedIndexChanged += new System.EventHandler(this.cmdDistrict_SelectedIndexChanged);
            // 
            // cmbTehsil
            // 
            this.cmbTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTehsil.FormattingEnabled = true;
            this.cmbTehsil.Location = new System.Drawing.Point(108, 113);
            this.cmbTehsil.Name = "cmbTehsil";
            this.cmbTehsil.Size = new System.Drawing.Size(371, 21);
            this.cmbTehsil.TabIndex = 1;
            this.cmbTehsil.SelectedIndexChanged += new System.EventHandler(this.cmbTehsil_SelectedIndexChanged);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(241, 165);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(116, 40);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(363, 165);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(116, 40);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // frmSelectTehsil
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(530, 237);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cmbTehsil);
            this.Controls.Add(this.cmdDistrict);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectTehsil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tehsil";
            this.Load += new System.EventHandler(this.frmSelectTehsil_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmdDistrict;
        private System.Windows.Forms.ComboBox cmbTehsil;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}