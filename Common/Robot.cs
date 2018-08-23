using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Modbus.Device;
using System.Threading;
using System.IO;

namespace Common
{
    public partial class Monitor : UserControl
    {
        private MonReg[] MonitorList = new MonReg[] { };
        private TcpClient client = null;
        private ModbusTcpMaster master = null;
        private bool isBusy = true;//锁
        public Monitor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// modbus是否已经连接
        /// </summary>
        public bool isReady
        {
            get
            {
                return client != null;
            }
        }
        /// <summary>
        /// 连接到Robot
        /// </summary>
        /// <param name="ip"></param>
        public void Connect(string ip)
        {
            if (ip.Length == 0) return;
            try
            {
                client = new TcpClient(ip, 502);
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                master = ModbusTcpMaster.CreateTcp(client);
                isBusy = false;
                TxtIP.Text = ip;
            }
            catch (Exception x)
            {
                ShowStatus("Modbus 连接失败!" + x.Message, false);
                if (client != null) client.Close();
                client = null;
            }
        }
        
        /// <summary>
        /// 开始监控寄存器列表
        /// </summary>
        /// <param name="list"></param>
        public void StartMonitor(MonReg[] list)
        {
            MonitorList = list;
            DataTable dt = new DataTable();
            for (int i = 0; i < list.Length; i++)
            {
                dt.Columns.Add(list[i].Address.ToString(), typeof(string));
            }
            for (int r = 0; r < 2; r++)
            {
                DataRow dr = dt.NewRow();
                for (int c = 0; c < list.Length; c++)
                    dr[c] = string.Empty;
                dt.Rows.Add(dr);
            }
            DGVData.DataSource = dt;
            TimFresh.Enabled = true;
            ShowStatus("Start Monitor", true);
        }
        /// <summary>
        /// 读数据uint16
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public ushort[] ReadData(ushort addr,int len)
        {
            while (isBusy) Thread.Sleep(20);
            isBusy = true;
            try
            {
                if (!client.Connected) throw new Exception("Connection lost!");
                ushort[] data = master.ReadHoldingRegisters(addr, (ushort)len);
                ShowStatus("成功读取地址:" + addr + ",长度:" + len, true);
                isBusy = false;
                return data;
            }
            catch(Exception x)
            {
                ShowStatus("失败读取地址:" + addr + ",长度:" + len + " " + x.Message, false);
                if (client != null) client.Close();
                client = null;
            }
            isBusy = false;
            return new ushort[] { };
        }
        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string ReadString(ushort addr,int len)
        {
            return Uint16ToString(ReadData(addr, len));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void WriteData(ushort addr,ushort[] data)
        {
            while (isBusy) Thread.Sleep(20);
            isBusy = true;
            try
            {
                if (!client.Connected) throw new Exception("Connection lost!");
                if (data.Length == 1)
                    master.WriteSingleRegister(addr, data[0]);
                else
                    master.WriteMultipleRegisters(addr, data);
                ShowStatus("成功写入地址:" + addr + ",长度:" + data.Length, true);
            }
            catch(Exception x)
            {
                ShowStatus("写入失败地址:" + addr + ",长度:" + data.Length + " " + x.Message, false);
                if (client != null) client.Close();
                client = null;
            }
            isBusy = false;
        }

        public void WriteString(ushort addr,string str)
        {
            while (isBusy) Thread.Sleep(20);
            isBusy = true;
            try
            {
                if (!client.Connected) throw new Exception("Connection lost!");
                master.WriteMultipleRegisters(addr, StringToUint16(str));
                ShowStatus("成功写入地址:" + addr + ",长度:" + str.Length, true);
            }
            catch(Exception x)
            {
                ShowStatus("写入失败地址:" + addr + ",长度:" + str.Length + " " + x.Message, false);
                if (client != null) client.Close();
                client = null;
            }
            isBusy = false;
        }

        private void TimFresh_Tick(object sender, EventArgs e)
        {
            if (client == null || isBusy) return;
            isBusy = true;
            try
            {
                if (!client.Connected) throw new Exception("Connection lost!");
                if (master != null)
                {
                    for (int i = 0; i < MonitorList.Length; i++)
                    {
                        ushort[] data = master.ReadHoldingRegisters(MonitorList[i].Address, MonitorList[i].Length);
                        string hex = string.Empty;
                        foreach (ushort dt in data) hex += dt.ToString("X2") + " ";
                        DGVData.Rows[0].Cells[i].Value = hex;
                        DGVData.Rows[1].Cells[i].Value = Uint16ToString(data);
                    }
                    ShowStatus("更新数据成功!", true);
                }
                else throw new Exception("ModbusMaster is null!");
            }
            catch (Exception x)
            {
                ShowStatus("读取数据失败!" + x.Message, false);
                if (client != null) client.Close();
                client = null;
            }
            isBusy = false;
        }

        private void ShowStatus(string msg,bool ok)
        {
            if (ok)
            {
                LabMSG.BackColor = Color.Lime;
                LabMSG.ForeColor = Color.Black;
            }else
            {
                LabMSG.BackColor = Color.Red;
                LabMSG.ForeColor = Color.White;
            }
            LabMSG.Text = DateTime.Now.ToString("[HH:mm:ss:fff]") + msg;
        }
        
        /// <summary>
        /// 数据转换工具
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Uint16ToString(ushort[] data)
        {
            string str = string.Empty;
            byte[] bts = new byte[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                bts[i * 2] = (byte)((data[i] & 0xff00) >> 8);
                bts[i * 2 + 1] = (byte)(data[i] & 0x00ff);
            }
            return Encoding.ASCII.GetString(bts);
        }

        private ushort[] StringToUint16(string str)
        {
            if (str.Length % 2 != 0) str += " ";
            ushort[] data = new ushort[str.Length / 2];
            byte[] bts = Encoding.ASCII.GetBytes(str);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (ushort)((bts[i * 2] << 8) | bts[i * 2 + 1]);
            }
            return data;
        }

        private void LabSetIP_DoubleClick(object sender, EventArgs e)
        {
            TxtIP.Enabled = true;
        }

        public void Close()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }

        private void TxtIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (client != null) client.Close();
                TxtIP.Enabled = false;
                File.WriteAllText("C:\\Robot.ini",TxtIP.Text);
                Connect(TxtIP.Text);
            }
        }
    }

    public class FlowDUT
    {
        public Status Stus = Status.FailOnece;
        public string SN = string.Empty;
        
        /// <summary>
        /// 治具状态定义
        /// </summary>
        public enum Status
        {
            None = 0, FailOnece = 1, FailTwice = 2, TrueFail = 3, Pass = 4, Testing = 5
        }
        /// <summary>
        /// DUT站别比对
        /// </summary>
        public enum Route
        {
            None = 0, Pass = 1, Lost = 2, Tested = 3, Failed = 4
        }

        private static string[] Flow = { ":01", ":02", ":04", ":20", "SYS_AUDIO:23", "SUB_TOUCH:24", "SUB_LED:26", "RF2:19", ":50" };
        /// <summary>
        /// 设置测试流程其他机种需要修改,默认NU9流程{ ":01", ":02", ":04", ":20", "SYS_AUDIO:23", "SUB_TOUCH:24", "SUB_LED:26", "RF2:19", ":50" }
        /// </summary>
        /// <param name="flow"></param>
        public static Route CheckStation(Shopfloor sf, string SN, string Station,ref string OutStr, string[] flow = null)
        {
            try
            {
                if (flow != null) Flow = flow;
                string dbret = sf.SwapData("SWDL", "querydata", "SN=" + SN + ";$;station=QueryData;$;SWDateTime="
                        + DateTime.Now.ToString("yyyyMMddHHmmss") + ";$;MonitorAgentVer=VW20151102.01;$;").ToUpper();
                OutStr = dbret;
                if (dbret.Contains("STATUS=") && dbret.Contains("SF_CFG_CHK=PASS"))
                {
                    string Status = Shopfloor.GetStrInner(dbret, "STATUS=", ";");
                    int fix = 10, dut = -1;
                    for (int i = 0; i < Flow.Length; i++)
                    {
                        if (Flow[i].Contains(Station)) fix = i - 1;
                        if (Flow[i].Contains(Status)) dut = i;
                    }
                    if (dut == -1) return Route.Failed;
                    if (dut == fix) return Route.Pass;
                    if (dut > fix) return Route.Tested;
                    if (dut < fix) return Route.Lost;
                }
                return Route.None;
            }
            catch (Exception) { return Route.None; }
        }
    }

    public class MonReg
    {
        public ushort Address = 9000;
        public ushort Length = 1;
        public MonReg(ushort add, ushort len)
        {
            Address = add; Length = len;
        }
    }
}
