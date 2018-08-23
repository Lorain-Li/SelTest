namespace Common
{
    partial class Loader
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabTitle = new System.Windows.Forms.Label();
            this.BarPross = new System.Windows.Forms.ProgressBar();
            this.TxtInfo = new System.Windows.Forms.TextBox();
            this.CopyThread = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LabTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BarPross, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtInfo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 142);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabTitle.Location = new System.Drawing.Point(4, 1);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(317, 40);
            this.LabTitle.TabIndex = 0;
            this.LabTitle.Text = "Program";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarPross
            // 
            this.BarPross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarPross.Location = new System.Drawing.Point(4, 114);
            this.BarPross.Name = "BarPross";
            this.BarPross.Size = new System.Drawing.Size(317, 24);
            this.BarPross.TabIndex = 1;
            // 
            // TxtInfo
            // 
            this.TxtInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TxtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtInfo.Enabled = false;
            this.TxtInfo.Location = new System.Drawing.Point(4, 45);
            this.TxtInfo.Multiline = true;
            this.TxtInfo.Name = "TxtInfo";
            this.TxtInfo.Size = new System.Drawing.Size(317, 62);
            this.TxtInfo.TabIndex = 2;
            // 
            // CopyThread
            // 
            this.CopyThread.WorkerReportsProgress = true;
            this.CopyThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CopyThread_DoWork);
            this.CopyThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CopyThread_ProgressChanged);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 162);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loader";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loader";
            this.Load += new System.EventHandler(this.Loader_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.ProgressBar BarPross;
        private System.Windows.Forms.TextBox TxtInfo;
        private System.ComponentModel.BackgroundWorker CopyThread;
    }
}