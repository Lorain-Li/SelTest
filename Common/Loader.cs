using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 若从服务器启动则运行Loader,否则关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loader_Load(object sender, EventArgs e)
        {
            if (Application.StartupPath.StartsWith("\\\\10."))
            {
                CopyThread.RunWorkerAsync();
            }
            else
            {
                TestSet.Init();
                this.Close();
            }
        }
        /// <summary>
        /// 复制文件,并创建快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyThread_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo Startup = new DirectoryInfo(Application.StartupPath);
            LabTitle.Text = Startup.Name;
            DirectoryInfo desktop = new DirectoryInfo(Environment.GetFolderPath((Environment.SpecialFolder.Desktop)));
            String shortcutPath = Path.Combine(desktop.FullName, Startup.Name + ".lnk");
            String exePath = Process.GetCurrentProcess().MainModule.FileName;
            IWshRuntimeLibrary.IWshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.WshShortcut shortcut = (IWshRuntimeLibrary.WshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = exePath;
            shortcut.Description = "应用程序说明";
            shortcut.WorkingDirectory = Environment.CurrentDirectory;
            shortcut.IconLocation = exePath;
            shortcut.WindowStyle = 1;
            shortcut.Save();
            BarPross.Maximum = FilesCounter(new DirectoryInfo(Application.StartupPath));
            DeepCopyDirectory(Startup, new DirectoryInfo(Path.Combine("D:\\", Startup.Name)));
            BarPross.Value = BarPross.Maximum;
            if (Startup.Name.ToUpper().Contains("USBBOOT"))
            {
                Process reboot = new Process();
                reboot.StartInfo.FileName = Path.Combine("D:\\", Startup.Name, "run_a0.bat");
                reboot.Start();
            }
            else
            {
                Process reboot = new Process();
                reboot.StartInfo.FileName = Path.Combine("D:\\", Startup.Name, Application.ProductName + ".exe");
                reboot.Start();
            }
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtInfo.AppendText(e.UserState.ToString());
            if (e.ProgressPercentage == 10) BarPross.Value++;
        }
        /// <summary>
        /// 获取文件总数
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int FilesCounter(DirectoryInfo root)
        {
            int count = 0;
            foreach(DirectoryInfo sub in root.GetDirectories())
            {
                count += FilesCounter(sub);
            }
            return count + root.GetFiles().Length;
        }
        /// <summary>
        /// 递归复制文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        private void DeepCopyDirectory(DirectoryInfo source, DirectoryInfo dest)
        {
            if (!source.Exists) { MessageBox.Show("目标文件夹不存在!"); return; }
            if (!dest.Exists) dest.Create();
            foreach (FileInfo fl in source.GetFiles())
            {
                try
                {
                    CopyThread.ReportProgress(10, "Copy:" + fl.Name + "\n");
                    File.Copy(fl.FullName, Path.Combine(dest.FullName, fl.Name), true);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message + "\r\n复制文件出错:" + fl.FullName);
                }
            }
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                try
                {
                    DirectoryInfo sub = new DirectoryInfo(Path.Combine(dest.FullName, dir.Name));
                    if (!sub.Exists) {
                        sub.Create();
                        CopyThread.ReportProgress(11, "Create Dir:" + dir.Name + "\n");
                    }
                    DeepCopyDirectory(dir, sub);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message + "\r\n创建文件夹出错:" + dir.FullName);
                }
            }
        }
        
    }
}
