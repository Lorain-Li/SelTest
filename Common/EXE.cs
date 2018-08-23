using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class EXE
    {
        public delegate void RealTimeOutput(string txt);
        private StringBuilder Collectlog = new StringBuilder();
        private FileInfo exe = new FileInfo("cmd.exe");
        private RealTimeOutput ShowTXTOnTime;
        public const string SH_NU9_FCT = " shell /home/flex/bin/fct.sh ";
        private string Command = string.Empty;
        /// <summary>
        /// 获取最后一次执行的命令
        /// </summary>
        public string LastCMD
        {
            get { return Command; }
        }
        /// <summary>
        /// 实例化一个外部程序调用
        /// </summary>
        /// <param name="path"></param>
        public EXE(string path)
        {
            if (File.Exists(path)) exe = new FileInfo(path);
            else exe = new FileInfo(new FileInfo(path).Name);
        }
        /// <summary>
        /// 执行一条命令,接收一个函数名为参数,执行中会将输出实时传递给该函数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public string RunCmd(string cmd, RealTimeOutput fun)
        {
            Command = "[" + DateTime.Now.ToString("HH:mm:ss") + "]" + exe.Name + " " + cmd;
            ShowTXTOnTime = new RealTimeOutput(fun);
            ShowTXTOnTime(Command + "\r\n");
            Collectlog.Clear();
            Process p = new Process();
            p.StartInfo.FileName = exe.FullName;
            p.StartInfo.Arguments = cmd;            // 执行参数
            p.StartInfo.UseShellExecute = false;        // 关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   // 重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  // 重定向标准输出
            p.StartInfo.RedirectStandardError = true;   // 重定向错误输出
            p.StartInfo.CreateNoWindow = true;          // 设置不显示窗口
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("GB2312");//支持中文输出
            p.StartInfo.StandardErrorEncoding = Encoding.GetEncoding("GB2312");
            p.OutputDataReceived += new DataReceivedEventHandler(P_OutputDataReceived);
            p.Start();                  //启动
            p.BeginOutputReadLine();    //行输出
            while (!p.HasExited) Thread.Sleep(200);     //时间太短异步输出有问题？
            return Collectlog.ToString();
        }
        /// <summary>
        /// 执行一条命令,执行完毕返回结果.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public string RunCmd(string cmd)
        {
            Command = "[" + DateTime.Now.ToString("HH:mm:ss") + "]" + exe.Name + " " + cmd;
            Collectlog.Clear();
            Process p = new Process();
            p.StartInfo.FileName = exe.FullName;
            p.StartInfo.Arguments = cmd;                // 执行参数
            p.StartInfo.UseShellExecute = false;        // 关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   // 重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  // 重定向标准输出
            p.StartInfo.RedirectStandardError = true;   // 重定向错误输出
            p.StartInfo.CreateNoWindow = true;          // 设置不显示窗口
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("GB2312");
            p.StartInfo.StandardErrorEncoding = Encoding.GetEncoding("GB2312");
            p.Start();   //启动
            p.WaitForExit();
            Thread.Sleep(200);
            Collectlog.Append(p.StandardOutput.ReadToEnd());
            return Collectlog.ToString();
        }
        /// <summary>
        /// 内部函数,实时输出调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                ShowTXTOnTime?.Invoke(e.Data.ToString() + "\r\n");
                Collectlog.AppendLine(e.Data.ToString());
            }
        }
    }
}
