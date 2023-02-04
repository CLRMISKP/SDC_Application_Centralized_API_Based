namespace SDC_Application.AL
{
    partial class frmAdminPendingTaskDashboard
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRHZ = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgTaskDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCompleted = new System.Windows.Forms.RadioButton();
            this.rbAllTasks = new System.Windows.Forms.RadioButton();
            this.rbPending = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgTasksSummary = new System.Windows.Forms.DataGridView();
            this.dgKhataEditColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPagePendingMutations = new System.Windows.Forms.TabPage();
            this.tabPageAllIncompleteTask = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnShowAllPendingTasks = new System.Windows.Forms.Button();
            this.dgAllPendingTasks = new System.Windows.Forms.DataGridView();
            this.btnImplementTask = new System.Windows.Forms.Button();
            this.txtRHZ_ChangeId = new System.Windows.Forms.TextBox();
            this.dgPendingMutations = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtIntiqalId = new System.Windows.Forms.TextBox();
            this.btnImplementMutation = new System.Windows.Forms.Button();
            this.btnShowAllPendingMutations = new System.Windows.Forms.Button();
            this.ColSelIntiqal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColSelAllPendingTask = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtMozaId = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRHZ.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasksSummary)).BeginInit();
            this.tabPagePendingMutations.SuspendLayout();
            this.tabPageAllIncompleteTask.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllPendingTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendingMutations)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 55);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 627);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1210, 46);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 572);
            this.panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRHZ);
            this.tabControl1.Controls.Add(this.tabPagePendingMutations);
            this.tabControl1.Controls.Add(this.tabPageAllIncompleteTask);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRHZ
            // 
            this.tabPageRHZ.Controls.Add(this.groupBox3);
            this.tabPageRHZ.Controls.Add(this.groupBox2);
            this.tabPageRHZ.Controls.Add(this.groupBox1);
            this.tabPageRHZ.Location = new System.Drawing.Point(4, 40);
            this.tabPageRHZ.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabPageRHZ.Name = "tabPageRHZ";
            this.tabPageRHZ.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabPageRHZ.Size = new System.Drawing.Size(1202, 528);
            this.tabPageRHZ.TabIndex = 0;
            this.tabPageRHZ.Text = "تبدیلی ملکیت، نام مالک، کھتونی، خسرہ جات";
            this.tabPageRHZ.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgTaskDetails);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1196, 209);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "موضع وار مکمل شدہ / زیر تجویز کام";
            // 
            // dgTaskDetails
            // 
            this.dgTaskDetails.AllowUserToAddRows = false;
            this.dgTaskDetails.AllowUserToDeleteRows = false;
            this.dgTaskDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTaskDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaskDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.dgTaskDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaskDetails.Location = new System.Drawing.Point(3, 35);
            this.dgTaskDetails.Name = "dgTaskDetails";
            this.dgTaskDetails.ReadOnly = true;
            this.dgTaskDetails.RowHeadersVisible = false;
            this.dgTaskDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaskDetails.Size = new System.Drawing.Size(1190, 171);
            this.dgTaskDetails.TabIndex = 3;
            this.dgTaskDetails.TabStop = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "انتخاب کریں";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCompleted);
            this.groupBox2.Controls.Add(this.rbAllTasks);
            this.groupBox2.Controls.Add(this.rbPending);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1196, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rbCompleted
            // 
            this.rbCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCompleted.AutoSize = true;
            this.rbCompleted.Location = new System.Drawing.Point(844, 38);
            this.rbCompleted.Name = "rbCompleted";
            this.rbCompleted.Size = new System.Drawing.Size(80, 35);
            this.rbCompleted.TabIndex = 2;
            this.rbCompleted.Text = "مکمل شدہ";
            this.rbCompleted.UseVisualStyleBackColor = true;
            this.rbCompleted.CheckedChanged += new System.EventHandler(this.rbPending_CheckedChanged);
            // 
            // rbAllTasks
            // 
            this.rbAllTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAllTasks.AutoSize = true;
            this.rbAllTasks.Location = new System.Drawing.Point(727, 38);
            this.rbAllTasks.Name = "rbAllTasks";
            this.rbAllTasks.Size = new System.Drawing.Size(86, 35);
            this.rbAllTasks.TabIndex = 0;
            this.rbAllTasks.Text = "تمام ٹاسک";
            this.rbAllTasks.UseVisualStyleBackColor = true;
            this.rbAllTasks.CheckedChanged += new System.EventHandler(this.rbPending_CheckedChanged);
            // 
            // rbPending
            // 
            this.rbPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPending.AutoSize = true;
            this.rbPending.Checked = true;
            this.rbPending.Location = new System.Drawing.Point(950, 38);
            this.rbPending.Name = "rbPending";
            this.rbPending.Size = new System.Drawing.Size(77, 35);
            this.rbPending.TabIndex = 1;
            this.rbPending.TabStop = true;
            this.rbPending.Text = "زیر تجویز";
            this.rbPending.UseVisualStyleBackColor = true;
            this.rbPending.CheckedChanged += new System.EventHandler(this.rbPending_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgTasksSummary);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تحصیل وار مکمل شدہ / زیر تجویز کام";
            // 
            // dgTasksSummary
            // 
            this.dgTasksSummary.AllowUserToAddRows = false;
            this.dgTasksSummary.AllowUserToDeleteRows = false;
            this.dgTasksSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTasksSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasksSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgKhataEditColSel});
            this.dgTasksSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTasksSummary.Location = new System.Drawing.Point(3, 35);
            this.dgTasksSummary.Name = "dgTasksSummary";
            this.dgTasksSummary.ReadOnly = true;
            this.dgTasksSummary.RowHeadersVisible = false;
            this.dgTasksSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTasksSummary.Size = new System.Drawing.Size(1190, 178);
            this.dgTasksSummary.TabIndex = 3;
            this.dgTasksSummary.TabStop = false;
            this.dgTasksSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTasksSummary_CellClick);
            // 
            // dgKhataEditColSel
            // 
            this.dgKhataEditColSel.HeaderText = "انتخاب کریں";
            this.dgKhataEditColSel.Name = "dgKhataEditColSel";
            this.dgKhataEditColSel.ReadOnly = true;
            // 
            // tabPagePendingMutations
            // 
            this.tabPagePendingMutations.Controls.Add(this.dgPendingMutations);
            this.tabPagePendingMutations.Controls.Add(this.groupBox5);
            this.tabPagePendingMutations.Location = new System.Drawing.Point(4, 40);
            this.tabPagePendingMutations.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabPagePendingMutations.Name = "tabPagePendingMutations";
            this.tabPagePendingMutations.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabPagePendingMutations.Size = new System.Drawing.Size(1202, 528);
            this.tabPagePendingMutations.TabIndex = 1;
            this.tabPagePendingMutations.Text = "زیر تجویز دستی انتقالات";
            this.tabPagePendingMutations.UseVisualStyleBackColor = true;
            // 
            // tabPageAllIncompleteTask
            // 
            this.tabPageAllIncompleteTask.Controls.Add(this.dgAllPendingTasks);
            this.tabPageAllIncompleteTask.Controls.Add(this.groupBox4);
            this.tabPageAllIncompleteTask.Location = new System.Drawing.Point(4, 40);
            this.tabPageAllIncompleteTask.Name = "tabPageAllIncompleteTask";
            this.tabPageAllIncompleteTask.Size = new System.Drawing.Size(1202, 528);
            this.tabPageAllIncompleteTask.TabIndex = 2;
            this.tabPageAllIncompleteTask.Text = "تمام نا مکمل ٹاسک";
            this.tabPageAllIncompleteTask.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRHZ_ChangeId);
            this.groupBox4.Controls.Add(this.btnImplementTask);
            this.groupBox4.Controls.Add(this.btnShowAllPendingTasks);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1202, 98);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تمام نا مکمل ٹاسک دیکھنے کےلئے بٹن کلک کریں";
            // 
            // btnShowAllPendingTasks
            // 
            this.btnShowAllPendingTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAllPendingTasks.Location = new System.Drawing.Point(530, 32);
            this.btnShowAllPendingTasks.Name = "btnShowAllPendingTasks";
            this.btnShowAllPendingTasks.Size = new System.Drawing.Size(195, 46);
            this.btnShowAllPendingTasks.TabIndex = 0;
            this.btnShowAllPendingTasks.Text = "تمام نا مکمل ٹاسک دیکھیئے";
            this.btnShowAllPendingTasks.UseVisualStyleBackColor = true;
            this.btnShowAllPendingTasks.Click += new System.EventHandler(this.btnShowAllPendingTasks_Click);
            // 
            // dgAllPendingTasks
            // 
            this.dgAllPendingTasks.AllowUserToAddRows = false;
            this.dgAllPendingTasks.AllowUserToDeleteRows = false;
            this.dgAllPendingTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAllPendingTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllPendingTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelAllPendingTask});
            this.dgAllPendingTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllPendingTasks.Location = new System.Drawing.Point(0, 98);
            this.dgAllPendingTasks.Name = "dgAllPendingTasks";
            this.dgAllPendingTasks.ReadOnly = true;
            this.dgAllPendingTasks.RowHeadersVisible = false;
            this.dgAllPendingTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAllPendingTasks.Size = new System.Drawing.Size(1202, 430);
            this.dgAllPendingTasks.TabIndex = 4;
            this.dgAllPendingTasks.TabStop = false;
            this.dgAllPendingTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAllPendingTasks_CellClick);
            // 
            // btnImplementTask
            // 
            this.btnImplementTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImplementTask.Enabled = false;
            this.btnImplementTask.Location = new System.Drawing.Point(314, 32);
            this.btnImplementTask.Name = "btnImplementTask";
            this.btnImplementTask.Size = new System.Drawing.Size(195, 46);
            this.btnImplementTask.TabIndex = 1;
            this.btnImplementTask.Text = "انتخاب کردہ ٹاسک پر عمل کریں";
            this.btnImplementTask.UseVisualStyleBackColor = true;
            this.btnImplementTask.Click += new System.EventHandler(this.btnImplementTask_Click);
            // 
            // txtRHZ_ChangeId
            // 
            this.txtRHZ_ChangeId.Location = new System.Drawing.Point(81, 39);
            this.txtRHZ_ChangeId.Name = "txtRHZ_ChangeId";
            this.txtRHZ_ChangeId.Size = new System.Drawing.Size(203, 39);
            this.txtRHZ_ChangeId.TabIndex = 2;
            this.txtRHZ_ChangeId.Text = "-1";
            this.txtRHZ_ChangeId.Visible = false;
            // 
            // dgPendingMutations
            // 
            this.dgPendingMutations.AllowUserToAddRows = false;
            this.dgPendingMutations.AllowUserToDeleteRows = false;
            this.dgPendingMutations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPendingMutations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPendingMutations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelIntiqal});
            this.dgPendingMutations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPendingMutations.Location = new System.Drawing.Point(3, 104);
            this.dgPendingMutations.Name = "dgPendingMutations";
            this.dgPendingMutations.ReadOnly = true;
            this.dgPendingMutations.RowHeadersVisible = false;
            this.dgPendingMutations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPendingMutations.Size = new System.Drawing.Size(1196, 418);
            this.dgPendingMutations.TabIndex = 6;
            this.dgPendingMutations.TabStop = false;
            this.dgPendingMutations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPendingMutations_CellClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMozaId);
            this.groupBox5.Controls.Add(this.txtIntiqalId);
            this.groupBox5.Controls.Add(this.btnImplementMutation);
            this.groupBox5.Controls.Add(this.btnShowAllPendingMutations);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1196, 98);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "تمام غیر عمل شدہ دستی انتقالات دیکھنے کیلئے بٹن کلک کریں";
            // 
            // txtIntiqalId
            // 
            this.txtIntiqalId.Location = new System.Drawing.Point(102, 39);
            this.txtIntiqalId.Name = "txtIntiqalId";
            this.txtIntiqalId.Size = new System.Drawing.Size(182, 39);
            this.txtIntiqalId.TabIndex = 2;
            this.txtIntiqalId.Text = "-1";
            this.txtIntiqalId.Visible = false;
            // 
            // btnImplementMutation
            // 
            this.btnImplementMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImplementMutation.Enabled = false;
            this.btnImplementMutation.Location = new System.Drawing.Point(308, 32);
            this.btnImplementMutation.Name = "btnImplementMutation";
            this.btnImplementMutation.Size = new System.Drawing.Size(195, 46);
            this.btnImplementMutation.TabIndex = 1;
            this.btnImplementMutation.Text = "انتخاب کردہ انتقال پر عمل کریں";
            this.btnImplementMutation.UseVisualStyleBackColor = true;
            this.btnImplementMutation.Click += new System.EventHandler(this.btnImplementMutation_Click);
            // 
            // btnShowAllPendingMutations
            // 
            this.btnShowAllPendingMutations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAllPendingMutations.Location = new System.Drawing.Point(524, 32);
            this.btnShowAllPendingMutations.Name = "btnShowAllPendingMutations";
            this.btnShowAllPendingMutations.Size = new System.Drawing.Size(212, 46);
            this.btnShowAllPendingMutations.TabIndex = 0;
            this.btnShowAllPendingMutations.Text = "تمام غیر عمل شدہ انتقالات دیکھیئے";
            this.btnShowAllPendingMutations.UseVisualStyleBackColor = true;
            this.btnShowAllPendingMutations.Click += new System.EventHandler(this.btnShowAllPendingMutations_Click);
            // 
            // ColSelIntiqal
            // 
            this.ColSelIntiqal.HeaderText = "انتخاب کریں";
            this.ColSelIntiqal.Name = "ColSelIntiqal";
            this.ColSelIntiqal.ReadOnly = true;
            // 
            // ColSelAllPendingTask
            // 
            this.ColSelAllPendingTask.HeaderText = "انتخاب کریں";
            this.ColSelAllPendingTask.Name = "ColSelAllPendingTask";
            this.ColSelAllPendingTask.ReadOnly = true;
            // 
            // txtMozaId
            // 
            this.txtMozaId.Location = new System.Drawing.Point(20, 37);
            this.txtMozaId.Name = "txtMozaId";
            this.txtMozaId.Size = new System.Drawing.Size(76, 39);
            this.txtMozaId.TabIndex = 3;
            this.txtMozaId.Text = "-1";
            this.txtMozaId.Visible = false;
            // 
            // frmAdminPendingTaskDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 673);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmAdminPendingTaskDashboard";
            this.Text = "ایڈمن زیر التواء کام ڈش بورڈ";
            this.Load += new System.EventHandler(this.frmAdminPendingTaskDashboard_Load);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRHZ.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTasksSummary)).EndInit();
            this.tabPagePendingMutations.ResumeLayout(false);
            this.tabPageAllIncompleteTask.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllPendingTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendingMutations)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRHZ;
        private System.Windows.Forms.TabPage tabPagePendingMutations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCompleted;
        private System.Windows.Forms.RadioButton rbPending;
        private System.Windows.Forms.RadioButton rbAllTasks;
        private System.Windows.Forms.DataGridView dgTaskDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridView dgTasksSummary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgKhataEditColSel;
        private System.Windows.Forms.TabPage tabPageAllIncompleteTask;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnShowAllPendingTasks;
        private System.Windows.Forms.DataGridView dgAllPendingTasks;
        private System.Windows.Forms.Button btnImplementTask;
        private System.Windows.Forms.TextBox txtRHZ_ChangeId;
        private System.Windows.Forms.DataGridView dgPendingMutations;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtIntiqalId;
        private System.Windows.Forms.Button btnImplementMutation;
        private System.Windows.Forms.Button btnShowAllPendingMutations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelIntiqal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelAllPendingTask;
        private System.Windows.Forms.TextBox txtMozaId;
    }
}