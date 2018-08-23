using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class Yield
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        public int Pass = 0, rPass = 0, Fail = 0, Total = 0, rFail = 0;
        private DirectoryInfo TestListFolder = new DirectoryInfo("TestFolder");
        private FileInfo PassList = new FileInfo("PassList.csv");
        private FileInfo FailList = new FileInfo("FailList.csv");
        private bool FreshLocked = false;
        /// <summary>
        /// 设置AABfail统计的路径
        /// </summary>
        /// <param name="path"></param>
        public void SetFPYFolder(string path)
        {
            FreshLocked = true;
            TestListFolder = new DirectoryInfo(Path.Combine(path, DateTime.Now.ToString("yyyyMMdd")));
            if (!TestListFolder.Exists) TestListFolder.Create();
            string comm = "-" + Information.FixID + "-" + Information.HostIP + "-" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            PassList = new FileInfo(Path.Combine(TestListFolder.FullName, "PassList" + comm));
            FailList = new FileInfo(Path.Combine(TestListFolder.FullName, "FailList" + comm));
            FreshLocked = false;
            FreshYield();
        }
        /// <summary>
        /// 定时刷新FPY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreshYield()
        {
            while (FreshLocked) Application.DoEvents();
            FreshLocked = true;
            Hashtable totaltable = new Hashtable();
            if (PassList.Exists)
            {
                string[] passsns = File.ReadAllText(PassList.FullName).Replace("\r","").Split('\n');
                Hashtable passtable = new Hashtable();
                foreach (string sn in passsns)
                {
                    if (!passtable.ContainsKey(sn) && sn.Length > 0) passtable.Add(sn, 1);
                    if (!totaltable.ContainsKey(sn) && sn.Length > 0) totaltable.Add(sn, 1);
                }
                if (FailList.Exists)
                {
                    rPass = 0;
                    string failtxt = File.ReadAllText(FailList.FullName);
                    foreach (DictionaryEntry item in passtable)
                    {
                        if (failtxt.Contains(item.Key.ToString())) rPass++;
                    }
                }
                else rPass = 0;
                Pass = passtable.Count - rPass;
            }
            else Pass = 0;
            if (FailList.Exists)
            {
                string[] failsns = File.ReadAllText(FailList.FullName).Replace("\r","").Split('\n');
                foreach (string sn in failsns)
                {
                    if (!totaltable.ContainsKey(sn) && sn.Length > 0) totaltable.Add(sn, 1);
                }
            }
            Total = totaltable.Count;
            Fail = Total - Pass - rPass;
            FreshLocked = false;
        }
        /// <summary>
        /// 记录pass
        /// </summary>
        /// <param name="sn"></param>
        public void SetPass(string sn)
        {
            while (FreshLocked) Application.DoEvents();
            FreshLocked = true;
            StreamWriter passfile = new StreamWriter(PassList.FullName, true);
            passfile.WriteLine(sn);
            passfile.Close();
            FreshLocked = false;
            FreshYield();
        }
        /// <summary>
        /// 记录fail
        /// </summary>
        /// <param name="sn"></param>
        public void SetFail(string sn)
        {
            while (FreshLocked) Application.DoEvents();
            FreshLocked = true;
            StreamWriter failfile = new StreamWriter(FailList.FullName, true);
            failfile.WriteLine(sn);
            failfile.Close();
            FreshLocked = false;
            FreshYield();
        }
        /// <summary>
        /// 获取测试次数
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public int GetCount(string sn)
        {
            int cnt = 0;
            while (FreshLocked) Application.DoEvents();
            FreshLocked = true;
            StringBuilder all = new StringBuilder();
            foreach (FileInfo file in TestListFolder.GetFiles())
            {
                if (file.Name.EndsWith(".csv")) all.Append(File.ReadAllText(file.FullName));
            }
            FreshLocked = false;
            foreach(string line in all.ToString().Replace("\r","").Split('\n'))
            {
                if (line.Contains(sn)) cnt++;
            }
            return cnt;
        }
    }
}
