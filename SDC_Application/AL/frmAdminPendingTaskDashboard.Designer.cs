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
            this.dgPendingMutations = new System.Windows.Forms.DataGridView();
            this.ColSelIntiqal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMozaId = new System.Windows.Forms.TextBox();
            this.txtIntiqalId = new System.Windows.Forms.TextBox();
            this.btnImplementMutation = new System.Windows.Forms.Button();
            this.btnShowAllPendingMutations = new System.Windows.Forms.Button();
            this.tabPageAllIncompleteTask = new System.Windows.Forms.TabPage();
            this.dgAllPendingTasks = new System.Windows.Forms.DataGridView();
            this.ColSelAllPendingTask = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMozaIdAllPendingTask = new System.Windows.Forms.TextBox();
            this.btnPrintProposedChanges = new System.Windows.Forms.Button();
            this.txtRHZ_ChangeId = new System.Windows.Forms.TextBox();
            this.btnImplementTask = new System.Windows.Forms.Button();
            this.btnShowAllPendingTasks = new System.Windows.Forms.Button();
            this.tabKhanakasht = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabKhewatFareeqain = new System.Windows.Forms.TabPage();
            this.tabMushtriFareeqain = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtKhatooniFeet = new System.Windows.Forms.TextBox();
            this.cbokhataNo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboKhatoonies = new System.Windows.Forms.ComboBox();
            this.txtKhatooniSarsai = new System.Windows.Forms.TextBox();
            this.chkBeahShoda = new System.Windows.Forms.CheckBox();
            this.txtKhatooniHissa = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKhatooniKanal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKhatooniMarla = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbPreviousKhata = new System.Windows.Forms.RadioButton();
            this.rbCurrentKhata = new System.Windows.Forms.RadioButton();
            this.cbKhattajatAll = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMouza = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRHZ.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasksSummary)).BeginInit();
            this.tabPagePendingMutations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendingMutations)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabPageAllIncompleteTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllPendingTasks)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabKhanakasht.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabKhanakasht);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 572);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            // ColSelIntiqal
            // 
            this.ColSelIntiqal.HeaderText = "انتخاب کریں";
            this.ColSelIntiqal.Name = "ColSelIntiqal";
            this.ColSelIntiqal.ReadOnly = true;
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
            // txtMozaId
            // 
            this.txtMozaId.Location = new System.Drawing.Point(20, 37);
            this.txtMozaId.Name = "txtMozaId";
            this.txtMozaId.Size = new System.Drawing.Size(76, 39);
            this.txtMozaId.TabIndex = 3;
            this.txtMozaId.Text = "-1";
            this.txtMozaId.Visible = false;
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
            this.btnImplementMutation.Size = new System.Drawing.Size(207, 46);
            this.btnImplementMutation.TabIndex = 1;
            this.btnImplementMutation.Text = "انتخاب کردہ انتقال عمل کیلئے فعال کریں";
            this.btnImplementMutation.UseVisualStyleBackColor = true;
            this.btnImplementMutation.Click += new System.EventHandler(this.btnImplementMutation_Click);
            // 
            // btnShowAllPendingMutations
            // 
            this.btnShowAllPendingMutations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAllPendingMutations.Location = new System.Drawing.Point(533, 32);
            this.btnShowAllPendingMutations.Name = "btnShowAllPendingMutations";
            this.btnShowAllPendingMutations.Size = new System.Drawing.Size(212, 46);
            this.btnShowAllPendingMutations.TabIndex = 0;
            this.btnShowAllPendingMutations.Text = "تمام غیر عمل شدہ انتقالات دیکھیئے";
            this.btnShowAllPendingMutations.UseVisualStyleBackColor = true;
            this.btnShowAllPendingMutations.Click += new System.EventHandler(this.btnShowAllPendingMutations_Click);
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
            // ColSelAllPendingTask
            // 
            this.ColSelAllPendingTask.HeaderText = "انتخاب کریں";
            this.ColSelAllPendingTask.Name = "ColSelAllPendingTask";
            this.ColSelAllPendingTask.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMozaIdAllPendingTask);
            this.groupBox4.Controls.Add(this.btnPrintProposedChanges);
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
            // txtMozaIdAllPendingTask
            // 
            this.txtMozaIdAllPendingTask.Location = new System.Drawing.Point(115, 38);
            this.txtMozaIdAllPendingTask.Name = "txtMozaIdAllPendingTask";
            this.txtMozaIdAllPendingTask.Size = new System.Drawing.Size(91, 39);
            this.txtMozaIdAllPendingTask.TabIndex = 206;
            this.txtMozaIdAllPendingTask.Text = "-1";
            this.txtMozaIdAllPendingTask.Visible = false;
            // 
            // btnPrintProposedChanges
            // 
            this.btnPrintProposedChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintProposedChanges.BackgroundImage = global::SDC_Application.Resource1.Print3;
            this.btnPrintProposedChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintProposedChanges.Enabled = false;
            this.btnPrintProposedChanges.Location = new System.Drawing.Point(284, 32);
            this.btnPrintProposedChanges.Name = "btnPrintProposedChanges";
            this.btnPrintProposedChanges.Size = new System.Drawing.Size(53, 48);
            this.btnPrintProposedChanges.TabIndex = 205;
            this.btnPrintProposedChanges.UseVisualStyleBackColor = true;
            this.btnPrintProposedChanges.Click += new System.EventHandler(this.btnPrintProposedChanges_Click);
            // 
            // txtRHZ_ChangeId
            // 
            this.txtRHZ_ChangeId.Location = new System.Drawing.Point(8, 37);
            this.txtRHZ_ChangeId.Name = "txtRHZ_ChangeId";
            this.txtRHZ_ChangeId.Size = new System.Drawing.Size(91, 39);
            this.txtRHZ_ChangeId.TabIndex = 2;
            this.txtRHZ_ChangeId.Text = "-1";
            this.txtRHZ_ChangeId.Visible = false;
            // 
            // btnImplementTask
            // 
            this.btnImplementTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImplementTask.Enabled = false;
            this.btnImplementTask.Location = new System.Drawing.Point(374, 32);
            this.btnImplementTask.Name = "btnImplementTask";
            this.btnImplementTask.Size = new System.Drawing.Size(195, 46);
            this.btnImplementTask.TabIndex = 1;
            this.btnImplementTask.Text = "انتخاب کردہ ٹاسک پر عمل کریں";
            this.btnImplementTask.UseVisualStyleBackColor = true;
            this.btnImplementTask.Click += new System.EventHandler(this.btnImplementTask_Click);
            // 
            // btnShowAllPendingTasks
            // 
            this.btnShowAllPendingTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAllPendingTasks.Location = new System.Drawing.Point(590, 32);
            this.btnShowAllPendingTasks.Name = "btnShowAllPendingTasks";
            this.btnShowAllPendingTasks.Size = new System.Drawing.Size(195, 46);
            this.btnShowAllPendingTasks.TabIndex = 0;
            this.btnShowAllPendingTasks.Text = "تمام نا مکمل ٹاسک دیکھیئے";
            this.btnShowAllPendingTasks.UseVisualStyleBackColor = true;
            this.btnShowAllPendingTasks.Click += new System.EventHandler(this.btnShowAllPendingTasks_Click);
            // 
            // tabKhanakasht
            // 
            this.tabKhanakasht.Controls.Add(this.tabControl2);
            this.tabKhanakasht.Controls.Add(this.groupBox7);
            this.tabKhanakasht.Controls.Add(this.groupBox6);
            this.tabKhanakasht.Location = new System.Drawing.Point(4, 40);
            this.tabKhanakasht.Name = "tabKhanakasht";
            this.tabKhanakasht.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhanakasht.Size = new System.Drawing.Size(1202, 528);
            this.tabKhanakasht.TabIndex = 3;
            this.tabKhanakasht.Text = "کھاتہ، کھتونی حیثیت";
            this.tabKhanakasht.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabKhewatFareeqain);
            this.tabControl2.Controls.Add(this.tabMushtriFareeqain);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 239);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1196, 286);
            this.tabControl2.TabIndex = 2;
            this.tabControl2.Visible = false;
            // 
            // tabKhewatFareeqain
            // 
            this.tabKhewatFareeqain.Location = new System.Drawing.Point(4, 40);
            this.tabKhewatFareeqain.Name = "tabKhewatFareeqain";
            this.tabKhewatFareeqain.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhewatFareeqain.Size = new System.Drawing.Size(1188, 242);
            this.tabKhewatFareeqain.TabIndex = 0;
            this.tabKhewatFareeqain.Text = "کھاتہ مالکان";
            this.tabKhewatFareeqain.UseVisualStyleBackColor = true;
            // 
            // tabMushtriFareeqain
            // 
            this.tabMushtriFareeqain.Location = new System.Drawing.Point(4, 40);
            this.tabMushtriFareeqain.Name = "tabMushtriFareeqain";
            this.tabMushtriFareeqain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMushtriFareeqain.Size = new System.Drawing.Size(1188, 242);
            this.tabMushtriFareeqain.TabIndex = 1;
            this.tabMushtriFareeqain.Text = "کھتونی مشتریان";
            this.tabMushtriFareeqain.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtKhatooniFeet);
            this.groupBox7.Controls.Add(this.cbokhataNo);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.cboKhatoonies);
            this.groupBox7.Controls.Add(this.txtKhatooniSarsai);
            this.groupBox7.Controls.Add(this.chkBeahShoda);
            this.groupBox7.Controls.Add(this.txtKhatooniHissa);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txtKhatooniKanal);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.txtKhatooniMarla);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 125);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1196, 114);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "مطلوبہ کھتونی کا انتخاب کرکے بیع شدہ حیثیت تبدیل کریں";
            // 
            // txtKhatooniFeet
            // 
            this.txtKhatooniFeet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniFeet.Enabled = false;
            this.txtKhatooniFeet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhatooniFeet.Location = new System.Drawing.Point(4, 55);
            this.txtKhatooniFeet.Name = "txtKhatooniFeet";
            this.txtKhatooniFeet.Size = new System.Drawing.Size(52, 30);
            this.txtKhatooniFeet.TabIndex = 32;
            // 
            // cbokhataNo
            // 
            this.cbokhataNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbokhataNo.DisplayMember = "KhataNo";
            this.cbokhataNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbokhataNo.FormattingEnabled = true;
            this.cbokhataNo.Location = new System.Drawing.Point(946, 55);
            this.cbokhataNo.Name = "cbokhataNo";
            this.cbokhataNo.Size = new System.Drawing.Size(169, 31);
            this.cbokhataNo.TabIndex = 61;
            this.cbokhataNo.ValueMember = "RegisterHqDKhataId";
            this.cbokhataNo.SelectionChangeCommitted += new System.EventHandler(this.cbokhataNo_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(876, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 31);
            this.label17.TabIndex = 64;
            this.label17.Text = "کھتونی نمبر";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1121, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 38);
            this.label9.TabIndex = 62;
            this.label9.Text = "کھاتہ نمبر";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 31);
            this.label12.TabIndex = 27;
            this.label12.Text = "مربع فٹ";
            // 
            // cboKhatoonies
            // 
            this.cboKhatoonies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhatoonies.DisplayMember = "KhatooniId";
            this.cboKhatoonies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhatoonies.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhatoonies.FormattingEnabled = true;
            this.cboKhatoonies.Location = new System.Drawing.Point(758, 51);
            this.cboKhatoonies.Name = "cboKhatoonies";
            this.cboKhatoonies.Size = new System.Drawing.Size(109, 39);
            this.cboKhatoonies.TabIndex = 63;
            this.cboKhatoonies.ValueMember = "KhatooniId";
            this.cboKhatoonies.SelectionChangeCommitted += new System.EventHandler(this.cboKhatoonies_SelectionChangeCommitted);
            // 
            // txtKhatooniSarsai
            // 
            this.txtKhatooniSarsai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniSarsai.Enabled = false;
            this.txtKhatooniSarsai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhatooniSarsai.Location = new System.Drawing.Point(129, 55);
            this.txtKhatooniSarsai.Name = "txtKhatooniSarsai";
            this.txtKhatooniSarsai.Size = new System.Drawing.Size(57, 30);
            this.txtKhatooniSarsai.TabIndex = 31;
            // 
            // chkBeahShoda
            // 
            this.chkBeahShoda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBeahShoda.AutoSize = true;
            this.chkBeahShoda.Location = new System.Drawing.Point(630, 53);
            this.chkBeahShoda.Name = "chkBeahShoda";
            this.chkBeahShoda.Size = new System.Drawing.Size(121, 35);
            this.chkBeahShoda.TabIndex = 65;
            this.chkBeahShoda.Text = "بیع شدہ خانہ کاشت";
            this.chkBeahShoda.UseVisualStyleBackColor = true;
            this.chkBeahShoda.Click += new System.EventHandler(this.chkBeahShoda_CheckedChanged);
            // 
            // txtKhatooniHissa
            // 
            this.txtKhatooniHissa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniHissa.Enabled = false;
            this.txtKhatooniHissa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhatooniHissa.Location = new System.Drawing.Point(480, 55);
            this.txtKhatooniHissa.Name = "txtKhatooniHissa";
            this.txtKhatooniHissa.Size = new System.Drawing.Size(87, 30);
            this.txtKhatooniHissa.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(572, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 31);
            this.label16.TabIndex = 23;
            this.label16.Text = "کل حصے";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(191, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 31);
            this.label13.TabIndex = 26;
            this.label13.Text = "سرسائی";
            // 
            // txtKhatooniKanal
            // 
            this.txtKhatooniKanal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniKanal.Enabled = false;
            this.txtKhatooniKanal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhatooniKanal.Location = new System.Drawing.Point(360, 55);
            this.txtKhatooniKanal.Name = "txtKhatooniKanal";
            this.txtKhatooniKanal.Size = new System.Drawing.Size(69, 30);
            this.txtKhatooniKanal.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(315, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 31);
            this.label15.TabIndex = 24;
            this.label15.Text = " مرلہ";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(434, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 31);
            this.label14.TabIndex = 25;
            this.label14.Text = " کنال";
            // 
            // txtKhatooniMarla
            // 
            this.txtKhatooniMarla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhatooniMarla.Enabled = false;
            this.txtKhatooniMarla.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhatooniMarla.Location = new System.Drawing.Point(249, 55);
            this.txtKhatooniMarla.Name = "txtKhatooniMarla";
            this.txtKhatooniMarla.Size = new System.Drawing.Size(61, 30);
            this.txtKhatooniMarla.TabIndex = 30;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbPreviousKhata);
            this.groupBox6.Controls.Add(this.rbCurrentKhata);
            this.groupBox6.Controls.Add(this.cbKhattajatAll);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.cmbMouza);
            this.groupBox6.Controls.Add(this.lbl1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1196, 122);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "مطلوبہ کھاتے کا انتخاب کرکے سابقہ / موجودہ حیثیت تبدیل کریں";
            // 
            // rbPreviousKhata
            // 
            this.rbPreviousKhata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPreviousKhata.AutoSize = true;
            this.rbPreviousKhata.Location = new System.Drawing.Point(397, 54);
            this.rbPreviousKhata.Name = "rbPreviousKhata";
            this.rbPreviousKhata.Size = new System.Drawing.Size(60, 35);
            this.rbPreviousKhata.TabIndex = 319;
            this.rbPreviousKhata.TabStop = true;
            this.rbPreviousKhata.Text = "سابقہ";
            this.rbPreviousKhata.UseVisualStyleBackColor = true;
            this.rbPreviousKhata.Click += new System.EventHandler(this.rbCurrentKhata_Click);
            // 
            // rbCurrentKhata
            // 
            this.rbCurrentKhata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentKhata.AutoSize = true;
            this.rbCurrentKhata.Location = new System.Drawing.Point(468, 54);
            this.rbCurrentKhata.Name = "rbCurrentKhata";
            this.rbCurrentKhata.Size = new System.Drawing.Size(70, 35);
            this.rbCurrentKhata.TabIndex = 318;
            this.rbCurrentKhata.TabStop = true;
            this.rbCurrentKhata.Text = "موجودہ";
            this.rbCurrentKhata.UseVisualStyleBackColor = true;
            this.rbCurrentKhata.Click += new System.EventHandler(this.rbCurrentKhata_Click);
            // 
            // cbKhattajatAll
            // 
            this.cbKhattajatAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKhattajatAll.DisplayMember = "KhataNo";
            this.cbKhattajatAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKhattajatAll.FormattingEnabled = true;
            this.cbKhattajatAll.Location = new System.Drawing.Point(558, 56);
            this.cbKhattajatAll.Name = "cbKhattajatAll";
            this.cbKhattajatAll.Size = new System.Drawing.Size(267, 31);
            this.cbKhattajatAll.TabIndex = 63;
            this.cbKhattajatAll.ValueMember = "RegisterHqDKhataId";
            this.cbKhattajatAll.SelectionChangeCommitted += new System.EventHandler(this.cbKhattajatAll_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(831, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 38);
            this.label1.TabIndex = 64;
            this.label1.Text = "کھاتہ نمبر";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMouza
            // 
            this.cmbMouza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMouza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMouza.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMouza.DropDownHeight = 500;
            this.cmbMouza.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMouza.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMouza.FormattingEnabled = true;
            this.cmbMouza.IntegralHeight = false;
            this.cmbMouza.Location = new System.Drawing.Point(925, 52);
            this.cmbMouza.Name = "cmbMouza";
            this.cmbMouza.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMouza.Size = new System.Drawing.Size(190, 39);
            this.cmbMouza.TabIndex = 59;
            this.cmbMouza.SelectionChangeCommitted += new System.EventHandler(this.cmbMouza_SelectionChangeCommitted);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Alvi Nastaleeq", 14F);
            this.lbl1.Location = new System.Drawing.Point(1121, 52);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(55, 38);
            this.lbl1.TabIndex = 60;
            this.lbl1.Text = "موضع";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgPendingMutations)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPageAllIncompleteTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllPendingTasks)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabKhanakasht.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.Button btnPrintProposedChanges;
        private System.Windows.Forms.TextBox txtMozaIdAllPendingTask;
        private System.Windows.Forms.TabPage tabKhanakasht;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbMouza;
        public System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cbokhataNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboKhatoonies;
        private System.Windows.Forms.CheckBox chkBeahShoda;
        private System.Windows.Forms.TextBox txtKhatooniFeet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtKhatooniSarsai;
        private System.Windows.Forms.TextBox txtKhatooniHissa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtKhatooniMarla;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKhatooniKanal;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cbKhattajatAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPreviousKhata;
        private System.Windows.Forms.RadioButton rbCurrentKhata;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabKhewatFareeqain;
        private System.Windows.Forms.TabPage tabMushtriFareeqain;
    }
}