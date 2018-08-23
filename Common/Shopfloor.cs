using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class Shopfloor
    {
        private SqlConnection sf = new SqlConnection();
        private string MonitorPortal = "MonitorPortal", BU = "NB4";
        /// <summary>
        /// 连接shopfloor数据库,例如Shopfloor("10.18.6.53","SEL")
        /// </summary>
        /// <param name="server"></param>
        /// <param name="db"></param>
        public Shopfloor(string server = "10.18.6.53", string db = "QMS", string portal = "MonitorPortal", string bu = "NB4")
        {
            sf.ConnectionString = "server=" + server + ";Database=" + db + ";Uid=sdt;Pwd=SDT#7;Integrated Security=False";
            MonitorPortal = portal;
            BU = bu;
        }
        /// <summary>
        /// 截取start和end之间的字符串,失败返回null.例如:GetStrInner("SF_CFG_CHK=PASS;*;","SF_CFG_CHK=",";")将返回"PASS".
        /// </summary>
        /// <param name="item"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStrInner(string txt, string start, string end)
        {
            try { return Regex.Matches(txt, "(?<=" + start + ").*?(?=" + end + ")")[0].ToString(); }
            catch (Exception) { return null; }
        }
        /// <summary>
        /// 查询数据库,例如:SwapData("SWDL","querydata","SN=WIPXXXXXXX;$;station=QueryData;$;MonitorAgentVer=VW20151102.01;$;")
        /// 返回:"SF_CFG_CHK=PASS"
        /// </summary>
        /// <param name="station">SWDL</param>
        /// <param name="step">querydata</param>
        /// <param name="swapstr">"SN=WIPXXXXXXX;$;station=QueryData;$;MonitorAgentVer=VW20151102.01;$;"</param>
        /// <returns>SF_CFG_CHK=PASS</returns>
        public string SwapData(string station, string step, string swapstr)
        {
            StringBuilder OutPutStr = new StringBuilder();
            try
            {
                sf.Open();
                if (sf.State == ConnectionState.Open)
                {
                    SqlCommand sqlcmd = new SqlCommand(MonitorPortal, sf);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add("@BU", SqlDbType.VarChar).Value = BU;
                    sqlcmd.Parameters.Add("@Station", SqlDbType.VarChar).Value = station;
                    sqlcmd.Parameters.Add("@Step", SqlDbType.VarChar).Value = step;
                    sqlcmd.Parameters.Add("@InPutStr", SqlDbType.VarChar).Value = swapstr;
                    sqlcmd.Parameters.Add("@OutPutStr", SqlDbType.VarChar, 8000);
                    sqlcmd.Parameters["@BU"].Direction = ParameterDirection.Input;
                    sqlcmd.Parameters["@BU"].DbType = DbType.String;
                    sqlcmd.Parameters["@Station"].Direction = ParameterDirection.Input;
                    sqlcmd.Parameters["@Station"].DbType = DbType.String;
                    sqlcmd.Parameters["@Step"].Direction = ParameterDirection.Input;
                    sqlcmd.Parameters["@Step"].DbType = DbType.String;
                    sqlcmd.Parameters["@InPutStr"].Direction = ParameterDirection.Input;
                    sqlcmd.Parameters["@InPutStr"].DbType = DbType.String;
                    sqlcmd.Parameters["@OutPutStr"].DbType = DbType.String;
                    sqlcmd.Parameters["@OutPutStr"].Direction = ParameterDirection.Output;
                    sqlcmd.ExecuteScalar();
                    OutPutStr.Append(sqlcmd.Parameters["@OutPutStr"].Value.ToString());
                    if (sf.State == ConnectionState.Open) sf.Close();
                    return OutPutStr.ToString();
                }
                else return "Connect Fail!";
            }catch(Exception x) { sf.Close();return x.Message; }
        }
    }
}
