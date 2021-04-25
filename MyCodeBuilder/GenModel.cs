using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeBuilder
{
    /// <summary>
    /// 生成Model类
    /// </summary>
    public class GenModel
    {
        /// <summary>
        /// 生成Mode模板代码
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tableName">表名</param>
        /// <param name="Author">作者</param>
        /// <param name="className">类名</param>
        /// <param name="connStr">数据连接字符串</param>
        /// <param name="database">数据库名字</param>
        /// <returns>Mode模板代码</returns>
        public static string GetAllCode(string ns,string tableName,string Author,string className,string connStr,string database)
        {
            #region 拼接模板
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\r\n");
            sb.Append("namespace "+ ns + ".Model \r\n");
            sb.Append(" {\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// ["+tableName+"]表实体类\r\n");
            sb.Append("        /// 作者:"+ Author + "\r\n");
            sb.Append("        /// 创建时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        [Serializable]\r\n");
            sb.Append("        public partial class "+className+"\r\n");
            sb.Append("       {\r\n");
            sb.Append("            public "+className+"()\r\n");
            sb.Append("            { }\r\n");
            //从数据库中读取表中字段名及属性
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "select COLUMN_NAME 字段名,DATA_TYPE 类型, COLUMN_COMMENT 字段说明,COLUMN_DEFAULT 默认值 from information_schema.columns where table_schema='"+database+"' and table_name='"+tableName+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                sb.Append("            private "+ Tools.SqlTypeName2DotNetType(dr["类型"].ToString())+"  _"+ dr["字段名"].ToString() + " "+Tools.DbDefaultToCSharp(dr["默认值"].ToString()) + ";\r\n");
                sb.Append("           /// <summary>\r\n");
                sb.Append("            /// "+dr["字段说明"].ToString()+"\r\n");
                sb.Append("           /// </summary>\r\n");
                sb.Append("            public " + Tools.SqlTypeName2DotNetType(dr["类型"].ToString()) +" "+  dr["字段名"].ToString() + "\r\n");
                sb.Append("           {\r\n");
                sb.Append("                set { _" +dr["字段名"].ToString() + " = value; }\r\n");
                sb.Append("                get { return _" + dr["字段名"].ToString() + "; }\r\n");
                sb.Append("            }\r\n");
            }

            conn.Clone();
            sb.Append("         }\r\n");
            sb.Append("   }\r\n");


            #endregion

            return sb.ToString();
        }

    }
}
