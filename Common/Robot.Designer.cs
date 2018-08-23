namespace Common
{
    partial class Monitor
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
            this.DGVData = new System.Windows.Forms.DataGridView();
            this.TimFresh = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabMSG = new System.Windows.Forms.Label();
            this.LabSetIP = new System.Windows.Forms.Label();
            this.TxtIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVData
            // 
            this.DGVData.AllowUserToAddRows = false;
            this.DGVData.AllowUserToDeleteRows = false;
            this.DGVData.AllowUserToResizeRows = false;
            this.DGVData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.DGVData, 2);
            this.DGVData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVData.Location = new System.Drawing.Point(3, 3);
            this.DGVData.Name = "DGVData";
            this.DGVData.RowTemplate.Height = 23;
            this.DGVData.Size = new System.Drawing.Size(335, 78);
            this.DGVData.TabIndex = 0;
            // 
            // TimFresh
            // 
            this.TimFresh.Interval = 1000;
            this.TimFresh.Tick += new System.EventHandler(this.TimFresh_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGVData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabMSG, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabSetIP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtIP, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 131);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LabMSG
            // 
            this.LabMSG.AutoSize = true;
            this.LabMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.LabMSG, 2);
            this.LabMSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabMSG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabMSG.Location = new System.Drawing.Point(3, 84);
            this.LabMSG.Name = "LabMSG";
            this.LabMSG.Size = new System.Drawing.Size(335, 20);
            this.LabMSG.TabIndex = 1;
            this.LabMSG.Text = "[12:13:14:111]";
            this.LabMSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabSetIP
            // 
            this.LabSetIP.AutoSize = true;
            this.LabSetIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabSetIP.Location = new System.Drawing.Point(3, 104);
            this.LabSetIP.Name = "LabSetIP";
            this.LabSetIP.Size = new System.Drawing.Size(94, 27);
            this.LabSetIP.TabIndex = 2;
            this.LabSetIP.Text = "Set Robot IP:";
            this.LabSetIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabSetIP.DoubleClick += new System.EventHandler(this.LabSetIP_DoubleClick);
            // 
            // TxtIP
            // 
            this.TxtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtIP.Enabled = false;
            this.TxtIP.Location = new System.Drawing.Point(103, 107);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(235, 21);
            this.TxtIP.TabIndex = 3;
            this.TxtIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIP_KeyDown);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Monitor";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(347, 137);
            ((System.ComponentModel.ISupportInitialize)(this.DGVData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVData;
        private System.Windows.Forms.Timer TimFresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabMSG;
        private System.Windows.Forms.Label LabSetIP;
        private System.Windows.Forms.TextBox TxtIP;
    }
}
