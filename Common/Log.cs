using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Excels;

namespace Common
{
    public class Log
    {
        /// <summary>
        /// log分割线
        /// </summary>
        public static string Segment
        {
            get
            {
                return "*************************************************************************************\r\n"
                     + "*************************************************************************************\r\n"
                     + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            }
        }
        /// <summary>
        /// 将richTextBox中的指定内容选中,并根据状态设置不同的背景色和前景色
        /// Status引用Excels.Status
        /// </summary>
        /// <param name="tBox"></param>
        /// <param name="stus"></param>
        /// <param name="txt"></param>
        public static void TxtStatus(ref RichTextBox tBox, Status stus, string txt = "\n")
        {
            txt = Regex.Replace(txt, "[\r\n|\n]+", "\n");
            if (txt.Length > 0) tBox.AppendText(txt);
            switch (stus)
            {
                case Status.Pass:
                    tBox.BackColor = Color.Lime;
                    break;
                case Status.Light:
                    tBox.Select(tBox.Text.IndexOf(txt), txt.Length);
                    tBox.SelectionColor = Color.White;
                    tBox.SelectionBackColor = Color.Red;
                    break;
                case Status.Fail:
                    tBox.BackColor = Color.Red;
                    tBox.Select(tBox.Text.IndexOf(txt), txt.Length);
                    tBox.SelectionColor = Color.White;
                    break;
                case Status.Clear:
                    tBox.Clear();
                    tBox.BackColor = Color.White;
                    tBox.ForeColor = Color.Black;
                    tBox.AppendText(txt);
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 文件名中包含,FixID,OPID或Time或者All(全部)
        /// </summary>
        public enum NameType
        {
            None = 0x00, FixID = 0x01, OPID = 0x01 << 1, Time = 0x01 << 2,
            FixIDOPID = FixID | OPID, OPIDTime = OPID | Time, FixIDTime = FixID | Time,
            All = 0xff
        }

        private string i_name = string.Empty, i_path = string.Empty;
        public void Create(string fullname)
        {
            FileInfo log = new FileInfo(fullname);
            DirectoryInfo dir = new DirectoryInfo(fullname.Substring(0, fullname.LastIndexOf("\\")));
            if (!dir.Exists) dir.Create();
            if (!log.Exists) log.Create().Close();
        }
        /// <summary>
        /// 创建一个文件,例如:Create("C:\","WIPXXXXX",".log",NameType.OPIDTime).
        /// 将会创建一个C:\WIPXXXXX-A74219XX-20180712031211.log文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sn"></param>
        /// <param name="ext"></param>
        /// <param name="type"></param>
        public void Create(string path, string sn, string ext,NameType type = NameType.None)
        {
            i_name = sn;
            if ((type & NameType.FixID) > 0) i_name += "-" + Information.FixID;
            if ((type & NameType.OPID) > 0) i_name += "-" + Information.OPID;
            if ((type & NameType.Time) > 0) i_name += "-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            i_name += ext;
            i_path = path;
            if (!Directory.Exists(i_path)) Directory.CreateDirectory(i_path);
            StreamWriter wt = new StreamWriter(i_path + "\\" + i_name, true);
            wt.Close();
        }
        /// <summary>
        /// 创建一个.log文件
        /// </summary>
        /// <param name="tpath"></param>
        /// <param name="tsn"></param>
        /// <param name="ttype"></param>
        public void CreateTXT(string tpath, string tsn, NameType ttype = NameType.None)
        {
            Create(tpath, tsn, ".log", ttype);
        }
        /// <summary>
        /// 创建一个.csv文件
        /// </summary>
        /// <param name="cpath"></param>
        /// <param name="csn"></param>
        /// <param name="ctype"></param>
        public void CreateCSV(string cpath, string csn, NameType ctype = NameType.None)
        {
            Create(cpath, csn, ".csv", ctype);
        }
        /// <summary>
        /// 向文件追加内容
        /// </summary>
        /// <param name="txt"></param>
        public void Append(string txt)
        {
            if (txt.Length > 0)
            {
                StreamWriter wt = new StreamWriter(i_path + "\\" + i_name, true);
                wt.Write(Regex.Replace(txt, "[\r\n|\n]+", "\r\n")); wt.Flush(); wt.Close();
            }
        }
        /// <summary>
        /// 重写文件内容
        /// </summary>
        /// <param name="txt"></param>
        public void WriteAll(string txt)
        {
            if (txt.Length > 0)
            {
                StreamWriter wt = new StreamWriter(i_path + "\\" + i_name, false);
                wt.Write(Regex.Replace(txt, "[\r\n|\n]+", "\r\n")); wt.Flush(); wt.Close();
            }
            else MessageBox.Show("WriteAll:内容为空!");
        }
        /// <summary>
        /// 复制文件到新的路径
        /// </summary>
        /// <param name="npth"></param>
        public void CopyTo(string npth)
        {
            if (!Directory.Exists(npth)) Directory.CreateDirectory(npth);
            File.Copy(i_path + "\\" + i_name, npth + "\\" + i_name);
        }
        /// <summary>
        /// 复制文件到新的路径并且重命名
        /// </summary>
        /// <param name="npth"></param>
        /// <param name="nName"></param>
        public void CopyTo(string npth, string nName)
        {
            if (!Directory.Exists(npth)) Directory.CreateDirectory(npth);
            File.Copy(i_path + "\\" + i_name, npth + "\\" + nName);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        public void Delete()
        {
            if (File.Exists(i_path + "\\" + i_name)) File.Delete(i_path + "\\" + i_name);
        }
        /// <summary>
        /// 向多个log里写入相同的内容
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="txt"></param>
        public static void WriteLogs(Log[] logs,string txt)
        {
            foreach(Log log in logs)
            {
                log.Append(txt);
            }
        }
    }
}
