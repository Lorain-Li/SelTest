using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class TestSet
    {
        //flash setting
        public static string LogBakPath, MatchTable;
        public static string KeySerIP1, KeySerIP2;
        //common setting
        public static string LogSerPath, LogZipPath, FPYSerPath, DBServer, QyServer, DBName, QyName, DBPortal, QyPortal, DBBU, QyBU, VersionPath, Stage;
        public static void Init()
        {
            Common.Ini setting = new Common.Ini(Application.StartupPath + "\\SEL-TEST.ini");
            //common setting
            VersionPath = setting.ReadItem("PROGRAM", "CheckVersion");
            Stage = setting.ReadItem("PROGRAM", "Stage");

            LogSerPath = setting.ReadItem("PATH", "LogSerPath");
            LogZipPath = setting.ReadItem("PATH", "LogZipPath");
            FPYSerPath = setting.ReadItem("PATH", "FPYLstPath");
            //
            DBServer = setting.ReadItem("DBSERVER", "ServerIP");
            DBName   = setting.ReadItem("DBSERVER", "DBName");
            DBPortal = setting.ReadItem("DBSERVER", "MonitorPortal");
            DBBU     = setting.ReadItem("DBSERVER", "BU");
            QyServer = setting.ReadItem("QYSERVER", "ServerIP");
            QyName   = setting.ReadItem("QYSERVER", "DBName");
            QyPortal = setting.ReadItem("QYSERVER", "MonitorPortal");
            QyBU     = setting.ReadItem("QYSERVER", "BU");
            //nu9 flash setting
            LogBakPath = setting.ReadItem("NU9FLASH", "LogBakPath");
            MatchTable = setting.ReadItem("NU9FLASH", "MatchTable");
            KeySerIP1  = setting.ReadItem("NU9FLASH", "KeySerIP1");
            KeySerIP2  = setting.ReadItem("NU9FLASH", "KeySerIP2");
        }
    }
}
