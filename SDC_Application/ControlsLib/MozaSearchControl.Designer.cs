namespace LandInfo.ControlsLib
{
    partial class MozaSearchControl
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
            if ( disposing && ( components != null ) )
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
            this.txtMozaName = new System.Windows.Forms.TextBox();
            this.tvwAreas = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // txtMozaName
            // 
            this.txtMozaName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMozaName.Font = new System.Drawing.Font("Nafees Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMozaName.Location = new System.Drawing.Point(5, 5);
            this.txtMozaName.Name = "txtMozaName";
            this.txtMozaName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMozaName.Size = new System.Drawing.Size(314, 44);
            this.txtMozaName.TabIndex = 0;
            this.txtMozaName.DoubleClick += new System.EventHandler(this.txtMozaName_DoubleClick);
            this.txtMozaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMozaName_KeyPress);
            // 
            // tvwAreas
            // 
            this.tvwAreas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwAreas.Location = new System.Drawing.Point(5, 55);
            this.tvwAreas.Name = "tvwAreas";
            this.tvwAreas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tvwAreas.RightToLeftLayout = true;
            this.tvwAreas.Size = new System.Drawing.Size(314, 185);
            this.tvwAreas.TabIndex = 1;
            this.tvwAreas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwAreas_NodeMouseDoubleClick);
            // 
            // MozaSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvwAreas);
            this.Controls.Add(this.txtMozaName);
            this.Name = "MozaSearchControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(324, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMozaName;
        private System.Windows.Forms.TreeView tvwAreas;
    }
}
