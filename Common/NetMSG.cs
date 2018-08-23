using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class NetMSG
    {
        public delegate void RecivedMSG(string msg);
        private BackgroundWorker BKWorkNetMSG = new BackgroundWorker();
        private UdpClient udpc = null;
        private IPEndPoint ipedp = null;
        /// <summary>
        /// 通过指定一个1-65535端口初始化一个类,建议使用10000以后的端口号
        /// </summary>
        /// <param name="port"></param>
        public NetMSG(int port)
        {
            try
            {
                udpc = new UdpClient(port);
                ipedp = new IPEndPoint(IPAddress.Any, port);
            }catch(Exception x) { MessageBox.Show(x.Message + "\r\nNetMSG出错!"); }
        }
        /// <summary>
        /// 发送一串msg到指定的ip和端口号
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        public static void SendMSG(string msg, int port, string ip)
        {
            try
            {
                Socket skt = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress ipdr = IPAddress.Parse(ip);
                IPEndPoint ipdp = new IPEndPoint(ipdr, port);
                skt.SendTo(Encoding.ASCII.GetBytes(msg), ipdp);
                skt.Close();
            }
            catch (Exception x) { MessageBox.Show(x.Message + "\r\nSendMSG出错"); }
        }
        /// <summary>
        /// 类内部调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BKWorkNetMSG_DoWork(object sender, DoWorkEventArgs e)
        {
            try//dll里面,win7环境下无法释放端口
            {
                RecivedMSG MSGHandle = (RecivedMSG)e.Argument;
                while (!BKWorkNetMSG.CancellationPending)
                {
                    byte[] rsv = udpc.Receive(ref ipedp);
                    string msg = Encoding.ASCII.GetString(rsv);
                    MSGHandle?.Invoke(msg);
                    Application.DoEvents();
                }
                udpc.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                if (udpc != null) udpc.Close();
            }
        }
        /// <summary>
        /// 开始接收网络消息,需要一个函数名作为参数传入,用于回调处理msg数据
        /// </summary>
        /// <param name="HandleMSG"></param>
        public void ListenMSG(RecivedMSG HandleMSG)
        {
            BKWorkNetMSG.WorkerSupportsCancellation = true;
            BKWorkNetMSG.DoWork += new DoWorkEventHandler(BKWorkNetMSG_DoWork);
            BKWorkNetMSG.RunWorkerAsync(HandleMSG);
        }
        /// <summary>
        /// 用于释放端口,否则端口被占用无法再次使用.
        /// </summary>
        public void StopNetMSG()
        {
            BKWorkNetMSG.CancelAsync();
            BKWorkNetMSG.Dispose();
        }
    }
}
