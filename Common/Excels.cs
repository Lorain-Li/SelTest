using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class Excels
    {
        /// <summary>
        /// 读取xls文件内容,返回DataGridView的数据表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object XLSX(string path)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                                                + path + ";Extended Properties=\"Excel 12.0;HDR=YES\"");
            try
            {
                conn.Open();
                DataSet table = new DataSet();
                DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string tbname = tables.Rows[0][2].ToString().Trim();
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM [" + tbname + "] ", conn);
                adp.Fill(table, "[" + tbname + "]");
                conn.Close();
                return table.Tables[0];
            }
            catch(Exception x) {
                MessageBox.Show(x.Message + "\r\n加载excel文件失败:" + path);
            }
            return null;
        }
        /// <summary>
        /// 将一串文本转换成DataGridView的数据表
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static object TXT(string txt)
        {
            string[] lines = txt.Replace("\\r", "").Split('\n');
            DataTable dt = new DataTable();
            string[] title = lines[0].Split(',');
            for (int i = 0; i < title.Length; i++)
            {
                dt.Columns.Add(title[i], typeof(string));
            }
            for (int l = 1; l < lines.Length; l++)
            {
                string[] cells = lines[l].Split(',');
                if (cells.Length == title.Length)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 0; c < cells.Length; c++)
                        dr[c] = cells[c];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        /// <summary>
        /// 将CSV文件的内容转换成DataGridView的数据表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object CSV(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("CSV文件:" + path + "不存在!");
                System.Environment.Exit(0);
                return null;
            }
            return TXT(File.ReadAllText(path));
        }
        /// <summary>
        /// 将DataGridView中指定的'列'转换成CSV格式的内容,例如:DGVToCSV(datagridview1,new int[]{1,3,5}).
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colmns"></param>
        /// <returns></returns>
        public static string DGVToCSV(DataGridView dgv, int[] colmns = null)
        {
            StringBuilder txt = new StringBuilder();
            if (colmns == null)
            {
                colmns = new int[dgv.ColumnCount];
                for (int i = 0; i < colmns.Length; i++) colmns[i] = i;
            }
            try
            {
                foreach (int c in colmns)
                {
                    txt.Append("\"" + dgv.Columns[c].HeaderText + "\"");
                    if (c < dgv.ColumnCount - 1) txt.Append(",");
                    else txt.AppendLine();
                }
                for (int r = 0; r < dgv.RowCount; r++)
                {
                    foreach (int c in colmns)
                    {
                        txt.Append("\"" + dgv.Rows[r].Cells[c].Value.ToString() + "\"");
                        if (c < dgv.ColumnCount - 1) txt.Append(",");
                        else txt.AppendLine();
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message + "\r\nDGVToCSV出错!"); }
            return txt.ToString();
        }

        /// <summary>
        /// 表格索引,若索引变化,请重新赋值修改,如:Excels.StatusIndex = 3
        /// </summary>
        public static int StatusIndex = 2, ValueIndex = 3, LimitLow = 5, LimitUp = 6, ErrorIndex = 7, StartIndex = 8, StopIndex = 9;
        /// <summary>
        /// DataGridView所支持的几种状态,不同的状态会把DataGridView设置成不同的值
        /// </summary>
        public enum Status
        {
            Pass, Fail, Start, Clear, None, Skip, Light
        }
        /// <summary>
        /// 设置DataGridView的状态,值和时间
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="step"></param>
        /// <param name="stus"></param>
        public static void SetStatus(ref DataGridView dgv, int step, Status stus, string value = "")
        {
            if (value.Length > 0) dgv.Rows[step].Cells[ValueIndex].Value = value;
            if (stus != Status.Clear) dgv.CurrentCell = dgv.Rows[step].Cells[StatusIndex];
            switch (stus)
            {
                case Status.Pass:
                    dgv.Rows[step].Cells[StatusIndex].Value = "Pass";
                    dgv.Rows[step].Cells[StatusIndex].Style.BackColor = Color.Lime;
                    dgv.Rows[step].Cells[StopIndex].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                case Status.Fail:
                    dgv.Rows[step].Cells[StatusIndex].Value = "Fail";
                    dgv.Rows[step].Cells[StatusIndex].Style.BackColor = Color.Red;
                    dgv.Rows[step].Cells[StopIndex].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                case Status.Skip:
                    dgv.Rows[step].Cells[StatusIndex].Value = "Skip";
                    dgv.Rows[step].Cells[StatusIndex].Style.BackColor = Color.Lime;
                    dgv.Rows[step].Cells[StartIndex].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                    dgv.Rows[step].Cells[StopIndex].Value  = DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                case Status.Start:
                    dgv.Rows[step].Cells[StatusIndex].Value = "Runing";
                    dgv.Rows[step].Cells[StatusIndex].Style.BackColor = Color.Blue;
                    dgv.Rows[step].Cells[StartIndex].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                case Status.Clear:
                    dgv.Rows[step].Cells[StatusIndex].Value = "Wait...";
                    dgv.Rows[step].Cells[StatusIndex].Style.BackColor = Color.Yellow;
                    dgv.Rows[step].Cells[StartIndex].Value = string.Empty;
                    dgv.Rows[step].Cells[StopIndex].Value  = string.Empty;
                    break;
                default: break;
            }
        }

        public struct RESULT
        {
            public string ERRORCODE, FPYCODE, TOTALERRORCODE, TOTALDESCRIPTION;
            public int BreakRow;
            public bool Upload;
        }

        public static RESULT GetDataGridResult(ref DataGridView dgv,int count,string Status,string StationCode)
        {
            //检查结果
            RESULT Result = new RESULT();
            Result.Upload = true;Result.BreakRow = -1;
            Result.ERRORCODE = "PASS"; Result.FPYCODE = "PASS"; Result.TOTALERRORCODE = string.Empty; Result.TOTALDESCRIPTION = string.Empty;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[Excels.StatusIndex].Value.ToString().ToUpper() == "FAIL")
                {
                    Result.ERRORCODE = "FAIL";
                    Result.FPYCODE = "FAIL";
                    Result.TOTALERRORCODE += dgv.Rows[i].Cells[Excels.ErrorIndex].Value.ToString();
                    Result.TOTALDESCRIPTION += dgv.Rows[i].Cells[1].Value.ToString() + "(" + dgv.Rows[i].Cells[Excels.StatusIndex].Value.ToString() + ");";
                }
                if (dgv.Rows[i].Cells[Excels.StatusIndex].Value.ToString().ToUpper().Contains("WAIT"))
                {
                    Result.ERRORCODE = "BREAK";
                    Result.BreakRow = i;
                    Result.Upload = false;
                    return Result;
                }
            }
            if (StationCode.Contains(Status))
            {
                if (count < 3)
                {
                    if (Result.ERRORCODE == "FAIL")
                    {
                        Result.FPYCODE = "TBD";
                        Result.TOTALERRORCODE = "";
                    }
                    else Result.FPYCODE = "RPASS";
                }
                else
                {
                    if (Result.ERRORCODE == "PASS")
                        Result.FPYCODE = "NTF";
                }
            }
            else Result.Upload = false;
            return Result;
        }
    }
}
