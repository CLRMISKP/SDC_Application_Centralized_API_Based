namespace SDC_Application.AL
{
    partial class frmFingerPrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enrollmentControl1 = new DPFP.Gui.Enrollment.EnrollmentControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveThumb = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enrollmentControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 438);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "کسی ایک انگلی کا انتخاب کر یں";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // enrollmentControl1
            // 
            this.enrollmentControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enrollmentControl1.EnrolledFingerMask = 0;
            this.enrollmentControl1.Location = new System.Drawing.Point(18, 48);
            this.enrollmentControl1.MaxEnrollFingerCount = 10;
            this.enrollmentControl1.Name = "enrollmentControl1";
            this.enrollmentControl1.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.enrollmentControl1.Size = new System.Drawing.Size(495, 314);
            this.enrollmentControl1.TabIndex = 1;
            this.enrollmentControl1.OnEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnEnroll(this.enrollmentControl1_OnEnroll);
            this.enrollmentControl1.OnFingerTouch += new DPFP.Gui.Enrollment.EnrollmentControl._OnFingerTouch(this.enrollmentControl1_OnFingerTouch);
            this.enrollmentControl1.OnComplete += new DPFP.Gui.Enrollment.EnrollmentControl._OnComplete(this.enrollmentControl1_OnComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveThumb);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 446);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSaveThumb
            // 
            this.btnSaveThumb.Location = new System.Drawing.Point(114, 19);
            this.btnSaveThumb.Name = "btnSaveThumb";
            this.btnSaveThumb.Size = new System.Drawing.Size(93, 51);
            this.btnSaveThumb.TabIndex = 0;
            this.btnSaveThumb.Text = "SAVE";
            this.btnSaveThumb.UseVisualStyleBackColor = true;
            this.btnSaveThumb.Click += new System.EventHandler(this.btnSaveThumb_Click);
            // 
            // frmFingerPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFingerPrint";
            this.Text = "نشان انگوٹھا محفوظگی";
            this.Load += new System.EventHandler(this.frmFingerPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveThumb;
        private DPFP.Gui.Enrollment.EnrollmentControl enrollmentControl1;
    }
}