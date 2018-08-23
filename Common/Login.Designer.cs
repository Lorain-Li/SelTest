namespace Common
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtOPID = new System.Windows.Forms.TextBox();
            this.TxtFixID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(43, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入工号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(43, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "治具编号:";
            // 
            // TxtOPID
            // 
            this.TxtOPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtOPID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtOPID.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtOPID.Location = new System.Drawing.Point(206, 40);
            this.TxtOPID.MaxLength = 20;
            this.TxtOPID.Name = "TxtOPID";
            this.TxtOPID.Size = new System.Drawing.Size(297, 41);
            this.TxtOPID.TabIndex = 2;
            this.TxtOPID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOPID_KeyDown);
            // 
            // TxtFixID
            // 
            this.TxtFixID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFixID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFixID.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtFixID.Location = new System.Drawing.Point(206, 129);
            this.TxtFixID.MaxLength = 50;
            this.TxtFixID.Name = "TxtFixID";
            this.TxtFixID.PasswordChar = '*';
            this.TxtFixID.Size = new System.Drawing.Size(297, 41);
            this.TxtFixID.TabIndex = 3;
            this.TxtFixID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFixID_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 220);
            this.Controls.Add(this.TxtFixID);
            this.Controls.Add(this.TxtOPID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtOPID;
        private System.Windows.Forms.TextBox TxtFixID;
    }
}