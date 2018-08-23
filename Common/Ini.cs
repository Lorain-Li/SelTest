using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class Ini
    {
        private string file_path;
        /// <summary>
        /// 读取一个配置文档,若文档不存在将关闭程序
        /// </summary>
        /// <param name="path"></param>
        public Ini(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("配置文件:" + path + "不存在!");
                System.Environment.Exit(0);
            }
            file_path = path;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteItem(string section, string key, string value)
        {
            if(value.Length==0)
                MessageBox.Show("配置文件:\n[" + section + "]\n" + key + "=的值为空!");
            WritePrivateProfileString(section, key, value, this.file_path);
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadItem(string section, string key)
        {
            StringBuilder value = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", value, 255, this.file_path);
            if (value.ToString().Length == 0)
                MessageBox.Show("配置文件:\n[" + section + "]\n" + key + "=的值为空!");
            return value.ToString();
        }
    }
}
