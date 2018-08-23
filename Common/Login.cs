using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class Login : Form
    {
        private Shopfloor db = new Shopfloor("10.18.6.31", "SEL");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TxtOPID.Focus();
            TxtFixID.Enabled = false;
        }

        private void TxtOPID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtOPID.Text.Length == 8)
                {
                    string sqlop = db.SwapData("", "QueryOPID", "OPID=" + TxtOPID.Text);
                    if (sqlop.Contains("SF_CFG_CHK=PASS"))
                    {
                        TxtOPID.Enabled = false;
                        TxtFixID.Enabled = true;
                        TxtFixID.Focus();
                        Information.OPID = TxtOPID.Text;
                    }
                    else if (sqlop.Contains("SF_CFG_CHK"))
                    {
                        MessageBox.Show("工号不存在!");
                        TxtOPID.Clear();
                    }
                    else
                    {
                        MessageBox.Show("无法验证OP!\r\n" + sqlop);
                        TxtOPID.Enabled = false;
                        TxtFixID.Enabled = true;
                        TxtFixID.Focus();
                        Information.OPID = TxtOPID.Text;
                    }
                }
                else
                {
                    MessageBox.Show("工号长度错误:" + TxtOPID.Text);
                    TxtOPID.Clear();
                }
            }
        }

        private void TxtFixID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Regex.IsMatch(TxtFixID.Text, "START-\\w-\\w+-\\w+-\\d+-END"))
                {
                    MessageBox.Show("治具编号格式错误:" + TxtFixID.Text);
                    TxtFixID.Clear();
                }
                else
                {
                    TxtFixID.Enabled = false;
                    Information.FixID = TxtFixID.Text.Substring(6, TxtFixID.Text.Length - 10);
                    this.Close();
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Information.OPID.Length == 0 || Information.FixID.Length == 0)
                System.Environment.Exit(0);
        }
    }
}
