namespace Common
{
    partial class MainUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GrpTitle = new System.Windows.Forms.GroupBox();
            this.LabBoot = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LabReset = new System.Windows.Forms.Label();
            this.TxtSN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTest = new System.Windows.Forms.TextBox();
            this.LabInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LabRPass = new System.Windows.Forms.Label();
            this.LabFPY = new System.Windows.Forms.Label();
            this.LabTotal = new System.Windows.Forms.Label();
            this.LabFail = new System.Windows.Forms.Label();
            this.LabPass = new System.Windows.Forms.Label();
            this.LabCount = new System.Windows.Forms.Label();
            this.LabNote = new System.Windows.Forms.Label();
            this.LabSpend = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGVOnline = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TxtMSG = new System.Windows.Forms.TextBox();
            this.TimPending = new System.Windows.Forms.Timer(this.components);
            this.TimOut = new System.Windows.Forms.Timer(this.components);
            this.TimFresh = new System.Windows.Forms.Timer(this.components);
            this.TimDevice = new System.Windows.Forms.Timer(this.components);
            this.TimElapse = new System.Windows.Forms.Timer(this.components);
            this.GrpTitle.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOnline)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpTitle
            // 
            this.GrpTitle.AutoSize = true;
            this.GrpTitle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GrpTitle.Controls.Add(this.LabBoot);
            this.GrpTitle.Controls.Add(this.tableLayoutPanel2);
            this.GrpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GrpTitle.Location = new System.Drawing.Point(0, 0);
            this.GrpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.GrpTitle.Name = "GrpTitle";
            this.GrpTitle.Padding = new System.Windows.Forms.Padding(2);
            this.GrpTitle.Size = new System.Drawing.Size(1202, 234);
            this.GrpTitle.TabIndex = 6;
            this.GrpTitle.TabStop = false;
            this.GrpTitle.Text = "Product-Station Version:2018.04.28 Assembly:2018.08.03.1126 IP:10.18.6.47";
            // 
            // LabBoot
            // 
            this.LabBoot.AutoSize = true;
            this.LabBoot.BackColor = System.Drawing.Color.Transparent;
            this.LabBoot.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabBoot.ForeColor = System.Drawing.Color.Red;
            this.LabBoot.Location = new System.Drawing.Point(877, 17);
            this.LabBoot.Name = "LabBoot";
            this.LabBoot.Size = new System.Drawing.Size(266, 20);
            this.LabBoot.TabIndex = 7;
            this.LabBoot.Text = "距上次维护时间:00:00:00s";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1198, 206);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(305, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 95);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Information";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.LabReset, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.TxtSN, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.TxtTest, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.LabInfo, 5, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(882, 70);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // LabReset
            // 
            this.LabReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabReset.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabReset.Location = new System.Drawing.Point(3, 12);
            this.LabReset.Name = "LabReset";
            this.LabReset.Size = new System.Drawing.Size(44, 45);
            this.LabReset.TabIndex = 0;
            this.LabReset.Text = "SN:";
            this.LabReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabReset.DoubleClick += new System.EventHandler(this.Reset_DoubleClick);
            // 
            // TxtSN
            // 
            this.TxtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSN.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSN.Location = new System.Drawing.Point(53, 15);
            this.TxtSN.Name = "TxtSN";
            this.TxtSN.Size = new System.Drawing.Size(194, 41);
            this.TxtSN.TabIndex = 0;
            this.TxtSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSN_KeyDown);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(253, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Testing:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtTest
            // 
            this.TxtTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTest.Enabled = false;
            this.TxtTest.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtTest.Location = new System.Drawing.Point(383, 15);
            this.TxtTest.Name = "TxtTest";
            this.TxtTest.Size = new System.Drawing.Size(194, 41);
            this.TxtTest.TabIndex = 3;
            // 
            // LabInfo
            // 
            this.LabInfo.AutoSize = true;
            this.LabInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabInfo.Location = new System.Drawing.Point(593, 12);
            this.LabInfo.Name = "LabInfo";
            this.LabInfo.Size = new System.Drawing.Size(286, 45);
            this.LabInfo.TabIndex = 4;
            this.LabInfo.Text = "OPID:A7421912\r\nFixID:J-M19-FLASH-01";
            this.LabInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(305, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 95);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fixture FPY";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 7;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.LabRPass, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabFPY, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabTotal, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabFail, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabPass, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabCount, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.LabNote, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.LabSpend, 5, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(882, 70);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // LabRPass
            // 
            this.LabRPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabRPass.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabRPass.Location = new System.Drawing.Point(243, 0);
            this.LabRPass.Name = "LabRPass";
            this.LabRPass.Size = new System.Drawing.Size(114, 40);
            this.LabRPass.TabIndex = 5;
            this.LabRPass.Text = "RPASS:0";
            this.LabRPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabFPY
            // 
            this.LabFPY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabFPY.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabFPY.Location = new System.Drawing.Point(603, 0);
            this.LabFPY.Name = "LabFPY";
            this.LabFPY.Size = new System.Drawing.Size(144, 40);
            this.LabFPY.TabIndex = 4;
            this.LabFPY.Text = "FPY:100.00%";
            this.LabFPY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabTotal
            // 
            this.LabTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTotal.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabTotal.Location = new System.Drawing.Point(483, 0);
            this.LabTotal.Name = "LabTotal";
            this.LabTotal.Size = new System.Drawing.Size(114, 40);
            this.LabTotal.TabIndex = 3;
            this.LabTotal.Text = "TOTAL:0";
            this.LabTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabFail
            // 
            this.LabFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabFail.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabFail.Location = new System.Drawing.Point(363, 0);
            this.LabFail.Name = "LabFail";
            this.LabFail.Size = new System.Drawing.Size(114, 40);
            this.LabFail.TabIndex = 2;
            this.LabFail.Text = "FAIL:0";
            this.LabFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabPass
            // 
            this.LabPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabPass.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabPass.Location = new System.Drawing.Point(123, 0);
            this.LabPass.Name = "LabPass";
            this.LabPass.Size = new System.Drawing.Size(114, 40);
            this.LabPass.TabIndex = 1;
            this.LabPass.Text = "PASS:0";
            this.LabPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabCount
            // 
            this.LabCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabCount.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabCount.Location = new System.Drawing.Point(3, 0);
            this.LabCount.Name = "LabCount";
            this.LabCount.Size = new System.Drawing.Size(114, 40);
            this.LabCount.TabIndex = 0;
            this.LabCount.Text = "COUNT:0";
            this.LabCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabNote
            // 
            this.LabNote.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.LabNote, 5);
            this.LabNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabNote.Font = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabNote.Location = new System.Drawing.Point(3, 40);
            this.LabNote.Name = "LabNote";
            this.LabNote.Size = new System.Drawing.Size(594, 30);
            this.LabNote.TabIndex = 6;
            this.LabNote.Text = "Result:";
            this.LabNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabSpend
            // 
            this.LabSpend.AutoSize = true;
            this.LabSpend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabSpend.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabSpend.Location = new System.Drawing.Point(603, 40);
            this.LabSpend.Name = "LabSpend";
            this.LabSpend.Size = new System.Drawing.Size(144, 30);
            this.LabSpend.TabIndex = 7;
            this.LabSpend.Text = "00:00:000ms";
            this.LabSpend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel2.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 196);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.DGVOnline);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DUT Online";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGVOnline
            // 
            this.DGVOnline.AllowUserToAddRows = false;
            this.DGVOnline.AllowUserToDeleteRows = false;
            this.DGVOnline.AllowUserToResizeRows = false;
            this.DGVOnline.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVOnline.Location = new System.Drawing.Point(3, 3);
            this.DGVOnline.Name = "DGVOnline";
            this.DGVOnline.RowTemplate.Height = 23;
            this.DGVOnline.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DGVOnline.Size = new System.Drawing.Size(278, 162);
            this.DGVOnline.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.TxtMSG);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(286, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TxtMSG
            // 
            this.TxtMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMSG.Location = new System.Drawing.Point(3, 3);
            this.TxtMSG.Multiline = true;
            this.TxtMSG.Name = "TxtMSG";
            this.TxtMSG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMSG.Size = new System.Drawing.Size(278, 162);
            this.TxtMSG.TabIndex = 4;
            // 
            // TimPending
            // 
            this.TimPending.Enabled = true;
            this.TimPending.Interval = 1000;
            this.TimPending.Tick += new System.EventHandler(this.TimPending_Tick);
            // 
            // TimOut
            // 
            this.TimOut.Interval = 30000;
            this.TimOut.Tick += new System.EventHandler(this.TimOut_Tick);
            // 
            // TimFresh
            // 
            this.TimFresh.Enabled = true;
            this.TimFresh.Interval = 1000;
            this.TimFresh.Tick += new System.EventHandler(this.TimFresh_Tick);
            // 
            // TimDevice
            // 
            this.TimDevice.Interval = 2000;
            this.TimDevice.Tick += new System.EventHandler(this.TimDevice_Tick);
            // 
            // TimElapse
            // 
            this.TimElapse.Enabled = true;
            this.TimElapse.Tick += new System.EventHandler(this.TimElapse_Tick);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.GrpTitle);
            this.Name = "MainUI";
            this.Size = new System.Drawing.Size(1202, 234);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.GrpTitle.ResumeLayout(false);
            this.GrpTitle.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVOnline)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label LabReset;
        private System.Windows.Forms.TextBox TxtSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTest;
        private System.Windows.Forms.Label LabInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label LabRPass;
        private System.Windows.Forms.Label LabFPY;
        private System.Windows.Forms.Label LabTotal;
        private System.Windows.Forms.Label LabFail;
        private System.Windows.Forms.Label LabPass;
        private System.Windows.Forms.Label LabCount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DGVOnline;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TxtMSG;
        private System.Windows.Forms.Timer TimPending;
        private System.Windows.Forms.Label LabBoot;
        private System.Windows.Forms.Timer TimOut;
        private System.Windows.Forms.Timer TimFresh;
        private System.Windows.Forms.Timer TimDevice;
        private System.Windows.Forms.Label LabNote;
        private System.Windows.Forms.Label LabSpend;
        private System.Windows.Forms.Timer TimElapse;
    }
}
