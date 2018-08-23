using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class GetOTPKey
    {
        private EXE curl = new EXE(Path.Combine(Application.StartupPath, "curl.exe"));
        private string log = string.Empty, perl = string.Empty, dutsn = string.Empty, key = string.Empty, serip = string.Empty;
        public string Log { get { return log; } }
        public string KeyFile { get { return Path.Combine(local.FullName, dutsn + "_" + key + ".tbz2"); } }
        private DirectoryInfo local = new DirectoryInfo("D:\\GetOTPKey\\" + DateTime.Now.ToString("yyyyMMdd"));

        public GetOTPKey(string ip, string pl = "phikey-joplin.pl")
        {
            serip = ip; perl = pl;
            if (!local.Exists)
            {
                local.Create();
                Directory.CreateDirectory(Path.Combine(local.FullName, "log"));
            }
        }

        public string Alloc(string sn)
        {
            dutsn = sn;
            foreach(FileInfo file in local.GetFiles())
            {
                if (file.Name.Contains(sn) && file.Name.EndsWith(".tbz2"))
                {
                    log = File.ReadAllText(Path.Combine(local.FullName, "log", dutsn + ".log"));
                    key = file.Name.Substring(file.Name.IndexOf("-") + 1, 6);
                    return key;
                }
            }
            log = curl.RunCmd("-d \"cmd=alloc&sn=" + sn + "\" http://" + serip + "/cgi-bin/" + perl);
            File.WriteAllText(Path.Combine(local.FullName, "log", dutsn + ".log"), log);
            try
            {
                if (Regex.IsMatch(log.Split('\n')[1], "^L\\B{5}&"))
                {
                    key = log.Split('\n')[1];
                }
            }
            catch (Exception) {}
            return key;
        }

        public bool Download()
        {
            curl.RunCmd("\"http://" + serip + "/cgi-bin/" + perl + "?cmd=get&sn=" + dutsn + "&key=" + key + "\" >" + KeyFile);
            return File.Exists(KeyFile);
        }

        public void Mark()
        {
            curl.RunCmd("-d \"cmd=mark&sn=" + dutsn + "&key=" + key + "\" http://" + serip + "/cgi-bin/" + perl);
        }
    }
}
