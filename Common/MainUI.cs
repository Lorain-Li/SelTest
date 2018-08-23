using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Common
{
    /// <summary>
    /// 自定义控件MainUI
    /// 1.属性 OnLineRow,设置DataGridView中的行数
    /// 2.属性 DUTTimeOut ,设置是否验证DUT在线
    /// 3.属性 EnabledADB,设置是否自动获取adb devices
    /// 4.属性 Station,设置程序的站别标识
    /// 5.属性 Product,设置程序适用的产品标识
    /// 6.属性 Note,用于显示提示信息
    /// 7.方法 SetPass(),设置一个sn pass,并且允许开始新的测试
    /// 8.方法 SetFail(),设置一个sn fail,并且允许开始新的测试
    /// 9.方法 AllowNew(),允许控件开始一个新的测试
    /// 10.属性 SpendTime.获取测试花费的时间
    /// </summary>
    public partial class MainUI : UserControl
    {
        EXE adb = new EXE(Path.Combine(Application.StartupPath, "adb.exe"));
        Stopwatch Runer = new Stopwatch();
        public MainUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 自定义OnlineRow属性,当值改变时自动改变DataGridView的行数
        /// </summary>
        [Description("用于设置DataGridView中可以显示的DUT的行数"), Category("MainUI")]
        public int OnLineRow
        {
            get
            {
                return DGVOnline.RowCount;
            }
            set
            {
                if (DGVOnline.RowCount != value)
                {
                    string txt = "___DUT_Online___,MLB_SN_______________________";
                    for (int i = 0; i < value; i++) txt += "\n,";
                    DGVOnline.DataSource = Excels.TXT(txt);
                }
            }
        }
        /// <summary>
        /// 自定义DUTTimeOut属性,将此变量设置为true可启动等待超时功能，超时30s
        /// </summary>
        [Description("用于设置是否检查DUT在线,超时时间30s"), Category("MainUI")]
        public bool DUTTimeOut
        {
            get
            {
                return TimOut.Enabled;
            }
            set
            {
                TimOut.Enabled = value;
            }
        }
        /// <summary>
        /// 自定义ADBDevices属性将此变量设置为true可启动等待超时功能，超时30s
        /// </summary>
        [Description("用于设置是否自动刷新adb devices"), Category("MainUI")]
        public bool EnabledADB
        {
            get
            {
                return TimDevice.Enabled;
            }
            set
            {
                TimDevice.Enabled = value;
            }
        }
        /// <summary>
        /// 自定义属性
        /// </summary>
        private string iStation = "Station";
        [Description("用于设置程序的站别标识"),Category("MainUI")]
        public string Station
        {
            get
            {
                return iStation;
            }
            set
            {
                GrpTitle.Text = GrpTitle.Text.Replace(iStation, value);
                iStation = value;
            }
        }
        /// <summary>
        /// 自定义属性
        /// </summary>
        private string iProduct = "Product";
        [Description("用于设置程序的所适用的产品标识"), Category("MainUI")]
        public string Product
        {
            get
            {
                return iProduct;
            }
            set
            {
                GrpTitle.Text = GrpTitle.Text.Replace(iProduct, value);
                iProduct = value;
            }
        }
        /// <summary>
        /// 自定义属性
        /// </summary>
        [Description("可显示一些提示信息"), Category("MainUI")]
        public string Note
        {
            get
            {
                return LabNote.Text;
            }
            set
            {
                LabNote.Text = value;
            }
        }
        /// <summary>
        /// 重写BackColor属性
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                GrpTitle.BackColor = value;
            }
        }
        /// <summary>
        /// 模拟扫码动作
        /// </summary>
        /// <param name="txt"></param>
        public void Scan(string txt)
        {
            if (TxtSN.Text.Length > 0) return;
            TxtSN.Text = txt;
            TxtSN_KeyDown(TxtSN, new KeyEventArgs(Keys.Enter));
        }
        /// <summary>
        /// 扫入SN直接用timer挂起,由timer调用测试进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //支持B条码
                if (!TxtSN.Text.StartsWith("WIP") && TxtSN.Text.Contains("WIP"))
                    TxtSN.Text = TxtSN.Text.Substring(TxtSN.Text.IndexOf("WIP"));
                //挂起
                TxtSN.Enabled = false;
                if (BoxSNEnterDown != null)
                {
                    TimPending.Enabled = false;
                    LabCount.Text = "COUNT:" + FPY.GetCount(TxtSN.Text);
                    new Thread(() => { BoxSNEnterDown(TxtSN, new BoxEventArgs(TxtSN.Text)); }).Start();
                }
                else
                {
                    TimPending.Enabled = true;
                    TimPending.Start();
                    if (TimOut.Enabled)
                    {
                        TimOut.Stop();
                        TimOut.Start();
                    }
                }
            }
        }
        /// <summary>
        /// 在线的DUT,以','分隔符号隔开
        /// </summary>
        public string DutOnline = string.Empty;
        /// <summary>
        /// 有多个DUT时测试挂起,若DUTTimeOut为true,则需等待DUT Boot成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimPending_Tick(object sender, EventArgs e)
        {
            if (TxtSN.Text.Length == 0) return;
            TxtMSG.AppendText("Wait for DUT:" + TxtSN.Text + "\r\n");
            if (!DutOnline.Contains(TxtSN.Text)) return;
            if (TxtTest.Text.Length == 0 && (!TxtSN.Enabled))
            {
                Runer.Restart();
                TxtTest.Text = TxtSN.Text;
                Reset_DoubleClick(null, null);
                LabCount.Text = "COUNT:" + FPY.GetCount(TxtTest.Text);
                new Thread(() => { BoxTestEnterDown?.Invoke(TxtTest, new BoxEventArgs(TxtTest.Text)); }).Start();
            }
        }
        /// <summary>
        /// DUT TimeOut 提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimOut_Tick(object sender, EventArgs e)
        {
            TimOut.Stop();
            if (!DutOnline.Contains(TxtSN.Text))
            {
                MessageBox.Show("DUT等待超时!");
                Reset_DoubleClick(null, null);
            }
        }
        /// <summary>
        /// 刷新在界面上显示的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimFresh_Tick(object sender, EventArgs e)
        {
            if (TxtMSG.Text.Length > 1000) TxtMSG.Clear();
            int TickSecond = Environment.TickCount / 1000;
            LabBoot.Location = new Point(this.Width - 300, 15);
            LabBoot.Text = String.Format("距上次维护时间:{0:00}:{1:00}:{2:00}s", TickSecond / 3600, (TickSecond % 3600) / 60, TickSecond % 60);
            LabPass.Text = "PASS:" + FPY.Pass; LabRPass.Text = "RPASS:" + FPY.rPass;
            LabFail.Text = "FAIL:" + FPY.Fail; LabTotal.Text = "TOTAL:" + FPY.Total;
            LabInfo.Text = "OPID:" + Information.OPID + "\nFixID:" + Information.FixID;
            if (FPY.Total > 0) LabFPY.Text = "FPY:" + ((float)FPY.Pass / FPY.Total).ToString("P2");
        }
        /// <summary>
        /// 使用UserControll.FPY.SetPass("WIP.....")
        /// </summary>
        public Yield FPY = new Yield();
        /// <summary>
        /// 统计一个pass的结果,并且允许开始新的测试
        /// </summary>
        /// <param name="sn"></param>
        public void SetPass(string sn)
        {
            FPY.SetPass(sn);
            Runer.Stop();
        }
        /// <summary>
        /// 统计一个fail的结果,并且允许开始新的测试
        /// </summary>
        /// <param name="sn"></param>
        public void SetFail(string sn)
        {
            FPY.SetFail(sn);
            Runer.Stop();
        }
        /// <summary>
        /// 允许控件开始新的测试
        /// </summary>
        public void AllowNew()
        {
            Runer.Stop();
            if (BoxTestEnterDown != null)
                TxtTest.Clear();
            if (BoxSNEnterDown != null)
            {
                Reset_DoubleClick(null, null);
            }
        }
        /// <summary>
        /// 定时器刷新在线列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimDevice_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    string OutStr = adb.RunCmd("devices").Replace("device", ",");
                    string listnew = Regex.Replace(OutStr.Substring(OutStr.IndexOf("attached") + 8), "\\s+", string.Empty);
                    DutOnline = listnew;
                    for (int r = 0; r < DGVOnline.RowCount; r++)
                    {
                        if (DGVOnline.Rows[r].Cells[0].Value.ToString().Length > 0)
                        {
                            if (!DutOnline.Contains(DGVOnline.Rows[r].Cells[0].Value.ToString()))
                            {   //清除离线的sn
                                DGVOnline.Rows[r].Cells[0].Value = string.Empty;
                                DGVOnline.Rows[r].Cells[1].Value = string.Empty;
                            }
                            else//移除已经显示的sn
                            {
                                listnew = listnew.Replace(DGVOnline.Rows[r].Cells[0].Value.ToString(), string.Empty);
                            }
                        }
                    }
                    foreach (string sn in listnew.Split(','))
                    {
                        if (sn.Length == 0) continue;
                        for (int r = 0; r < DGVOnline.RowCount; r++)
                        {
                            if (DGVOnline.Rows[r].Cells[0].Value.ToString().Length == 0)
                            {
                                DGVOnline.Rows[r].Cells[0].Value = sn;
                                string mlb = adb.RunCmd("-s " + sn + " shell cat /factory_setting/mlb_sn.txt");
                                DGVOnline.Rows[r].Cells[1].Value = mlb;
                                break;
                            }
                        }
                    }
                }
                catch (Exception x) { TxtMSG.AppendText("adb devices错误!\r\n" + x.Message + "\r\n"); }
            }).Start();
        }
        /// <summary>
        /// 保存一个测试开始的时间,结束时间,和时间开销,和测试是否完成
        /// </summary>
        public TimeSpan SpendTime = new TimeSpan();

        public delegate void EnterDown(object sendor, BoxEventArgs e);
        [Description("当TextBox SN中键入回车时产生事件,用e.ToString()方法获取文本"), Category("MainUI")]
        public event EnterDown BoxSNEnterDown = null;
        [Description("当TextBox Test中键入回车时产生事件,用e.ToString()方法获取文本"), Category("MainUI")]
        public event EnterDown BoxTestEnterDown = null;


        private void MainUI_Load(object sender, EventArgs e)
        {
            Information.InitPC();
            GrpTitle.Text = iProduct + "-" + iStation + " Version:" + Application.ProductVersion 
                + " Assembly:" + Information.GetAssemblyTime() + " HostIP:" + Information.HostIP;
        }

        private void TimElapse_Tick(object sender, EventArgs e)
        {
            SpendTime = Runer.Elapsed;
            LabSpend.Text = String.Format("{0:00}:{1:00}:{2:000}ms", SpendTime.Minutes,
                    SpendTime.Seconds, SpendTime.Milliseconds);
        }
        
        private void Reset_DoubleClick(object sender, EventArgs e)
        {
            TxtSN.Enabled = true;
            TxtSN.Clear();
            TxtSN.Focus();
        }
    }

    public class BoxEventArgs : EventArgs
    {
        private string message;
        public string Text
        {
            get { return message; }
        }
        public BoxEventArgs(string txt)
        {
            message = txt;
        }
    }
}
