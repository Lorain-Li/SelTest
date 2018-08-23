using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class Information
    {
        public static string OPID = string.Empty, FixID = string.Empty, HostIP = string.Empty, HostName = string.Empty, Line = string.Empty;
        public static int Height = 100, Width = 100;
        /// <summary>
        /// 用于子程序启动时保存的参数
        /// </summary>
        public static string[] args = new string[] { };
        /// <summary>
        /// 初始化显示器宽度和高度,还有ip地址
        /// </summary>
        public static void InitPC()
        {
            string[] ipPriority = { "169.", "10.", "172.", "192." };
            HostName = Dns.GetHostName();
            foreach (string stip in ipPriority)
            {
                foreach (IPAddress ip in Dns.GetHostAddresses(HostName))
                {
                    if (ip.ToString().StartsWith(stip))
                    {
                        HostIP = ip.ToString(); break;
                    }
                }
                if (HostIP.Length > 0) break;
            }
            Width = SystemInformation.WorkingArea.Width;//屏幕宽度
            Height = SystemInformation.WorkingArea.Height;//屏幕高度
            //用于flash子程序传递参数
            if (args.Length == 3)
            {
                OPID = args[1];
                FixID = args[2];
            }
        }
        /// <summary>
        /// 显示登录窗口,初始化OPID和FixID,DEBUG模式无效
        /// </summary>
        public static void ShowLogin()
        {
#if !DEBUG
            Login lg = new Login();
            lg.Show();
            while (!lg.IsDisposed) Application.DoEvents();
#else
            OPID = "A7421912";
            FixID = "J-M19-FLASH-01";
#endif
        }
        /// <summary>
        /// 检查程序版本的方式
        /// 1.ByVersion 通过版本号控制
        /// 2.ByAssembly 通过编译时间控制
        /// </summary>
        public enum CheckType { ByVersion, ByAssembly }
        /// <summary>
        /// 检查程序版本号,若版本号错误,将结束程序.
        /// 1.ByVersion  默认方式ProductVersion
        /// 2.ByAssembly 可选方式AssemblyTime
        /// </summary>
        /// <param name="path"></param>
        /// <param name="version"></param>
        public static void CheckVersion(string path, CheckType type = CheckType.ByVersion)
        {
            if (File.Exists(path))
            {
                if (File.ReadAllText(path).Contains(GetAssemblyTime()) && type == CheckType.ByAssembly)
                    return;
                else if (File.ReadAllText(path).Contains(Application.ProductVersion))
                    return;
                MessageBox.Show("此版本已停止使用,请从服务器上打开新程序!");
                System.Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("版本管控文件:" + path + "不存在!");
                System.Environment.Exit(0);
            }
        }
        /// <summary>
        /// 获取程序的编译时间,返回格式:2018.08.03.0904
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyTime()
        {
            return File.GetLastWriteTime(Path.Combine(Application.StartupPath, Application.ProductName + ".exe")).ToString("yyyy.MM.dd.HHmm");
        }
    }
}
