using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeBuilder
{
    public class GenDAL
    {
        /// <summary>
        /// 生成DAL模板代码
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tableName">表名</param>
        /// <param name="Author">作者</param>
        /// <param name="className">类名</param>
        /// <param name="connStr">数据连接字符串</param>
        /// <param name="database">数据库名字</param>
        /// <returns>DAL模板代码</returns>
        public static string GetDALCode(string ns, string tableName, string Author, string className, string connStr, string database)
        {
            #region 生成DAL代码
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "select COLUMN_NAME 字段名,DATA_TYPE 类型, COLUMN_COMMENT 字段说明,COLUMN_DEFAULT 默认值 from information_schema.columns where table_schema='" + database + "' and table_name='" + tableName + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);//添加到DataTable
            conn.Close();
            StringBuilder sb = new StringBuilder();
            string temp1 = "";
            string temp2 = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                if (i == dt.Rows.Count - 1)
                {
                    temp1 += "[" + row["字段名"].ToString() + "]";
                    temp2 += "@" + row["字段名"].ToString() + " ";
                }
                else
                {
                    temp1 += "[" + row["字段名"].ToString() + "],";
                    temp2 += "@" + row["字段名"].ToString() + ", ";
                }
            }
            sb.Append("using System;\r\n");
            sb.Append("using System.Collections.Generic;\r\n");
            sb.Append("using System.Linq;\r\n");
            sb.Append("using System.Text;\r\n");
            sb.Append("using System.Data;\r\n");
            sb.Append("namespace " + ns + ".DAL\r\n");
            sb.Append("{\r\n");
            sb.Append("/// <summary>\r\n");
            sb.Append("/// [" + tableName + "]表数据访问类\r\n");
            sb.Append("/// 作者:" + Author + "\r\n");
            sb.Append("/// 创建时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public class " + className + "\r\n");
            sb.Append("{\r\n");
            sb.Append("public " + className + "DAL()\r\n");
            sb.Append("{ }\r\n");


            #region 增加一条数据

            sb.Append("/// <summary>\r\n");
            sb.Append("/// 增加一条数据\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public int Add(" + ns + ".Model.Category model)\r\n");
            sb.Append("{\r\n");
            sb.Append("StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("strSql.Append(\"insert into [" + tableName + "](\");\r\n");
            sb.Append("strSql.Append(\"" + temp1 + " )\");\r\n");
            sb.Append("strSql.Append(\" values (\");\r\n");
            sb.Append("strSql.Append(\"" + temp2 + " )\");\r\n");
            sb.Append("strSql.Append(\";select @@IDENTITY\");\r\n");
            sb.Append("MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("h.CreateCommand(strSql.ToString());\r\n");

            foreach (DataRow row in dt.Rows)
            {
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                else if (row["类型"].ToString() == "datatime")
                {
                    sb.Append("if (model." + row["字段名"] + " == null)\r\n");
                    sb.Append("{\r\n");
                    sb.Append("    h.AddParameter(\"@" + row["字段名"] + "\", DateTime,Now);\r\n\");\r\n");
                    sb.Append("}\r\n");
                    sb.Append("else\r\n");
                    sb.Append("{\r\n");
                    sb.Append("    h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                    sb.Append("}\r\n");
                }
                else
                {
                    sb.Append("if (model." + row["字段名"] + " == null)\r\n");
                    sb.Append("{\r\n");
                    sb.Append("    h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n\");\r\n");
                    sb.Append("}\r\n");
                    sb.Append("else\r\n");
                    sb.Append("{\r\n");
                    sb.Append("    h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                    sb.Append("}\r\n");
                }
            }



            sb.Append("int result;\r\n");
            sb.Append("string obj = h.ExecuteScalar();\r\n");
            sb.Append("if (!int.TryParse(obj, out result))\r\n");
            sb.Append("{\r\n");
            sb.Append("    return 0;\r\n");
            sb.Append("}\r\n");
            sb.Append("return result;\r\n");
            sb.Append("            }\r\n");



            string temp3 = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                if (i == dt.Rows.Count - 1)
                {
                    temp3 += "[" + row["字段名"].ToString() + "]=@" + row["字段名"].ToString();
                }
                else
                {
                    temp3 += "[" + row["字段名"].ToString() + "]=@" + row["字段名"].ToString() + ",";
                }
            }

            #endregion

            #region 更新一条数据

            sb.Append("/// <summary>\r\n");
            sb.Append("/// 更新一条数据\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public bool Update(" + ns + ".Model." + className + " model)\r\n");
            sb.Append("{\r\n");
            sb.Append("    StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("    strSql.Append(\"update [" + tableName + "] set \");\r\n");
            sb.Append("    strSql.Append(\"" + temp3 + "   \");\r\n");
            sb.Append("    strSql.Append(\" where id=@id \");\r\n");
            sb.Append("    MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("    h.CreateCommand(strSql.ToString());\r\n");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("    if (model." + row["字段名"] + " == null)\r\n");
                sb.Append("    {\r\n");
                sb.Append("        h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n");
                sb.Append("    }\r\n");
                sb.Append("    else\r\n");
                sb.Append("    {\r\n");
                sb.Append("        h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n/");
                sb.Append("    }\r\n");
            }

            sb.Append("    return h.ExecuteNonQuery();\r\n");
            sb.Append("}\r\n");

            #endregion


            #region 删除一条数据

            sb.Append("/// <summary>\r\n");
            sb.Append("/// 删除一条数据\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public bool Delete(int id)\r\n");
            sb.Append("{\r\n");
            sb.Append("    StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("    strSql.Append(\"delete from [" + tableName + "] \");\r\n");
            sb.Append("    strSql.Append(\" where id=@id \");\r\n");
            sb.Append("    MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("    h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("    h.AddParameter(\"@id\", id);\r\n");
            sb.Append("    return h.ExecuteNonQuery();\r\n");
            sb.Append("}\r\n");

            #endregion

            #region 根据条件删除数据

            sb.Append("/// <summary>\r\n");
            sb.Append("/// 根据条件删除数据\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public bool DeleteByCond(string cond)\r\n");
            sb.Append("{\r\n");
            sb.Append("    StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("    strSql.Append(\"delete from [" + tableName + "] \");\r\n");
            sb.Append("    if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("    {\r\n");
            sb.Append("        strSql.Append(\" where \" + cond);\r\n");
            sb.Append("    }\r\n");
            sb.Append("    MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("    h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("    return h.ExecuteNonQuery();\r\n");
            sb.Append("}\r\n");

            #endregion

            #region 获得数据列表

            sb.Append("/// <summary>\r\n");
            sb.Append("/// 获得数据列表\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public DataSet GetList(string strWhere)\r\n");
            sb.Append("{\r\n");
            sb.Append("    StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("    strSql.Append(\"select * \");\r\n");
            sb.Append("    strSql.Append(\" FROM [" + tableName + "] \");\r\n");
            sb.Append("    if (strWhere.Trim() != \"\")\r\n");
            sb.Append("    {\r\n");
            sb.Append("        strSql.Append(\" where \" + strWhere);\r\n");
            sb.Append("    }\r\n");
            sb.Append("    MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("    h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("    DataTable dt = h.ExecuteQuery();\r\n");
            sb.Append("    DataSet ds = new DataSet();\r\n");
            sb.Append("    ds.Tables.Add(dt);\r\n");
            sb.Append("    return ds;\r\n");
            sb.Append("}\r\n");

            sb.Append("}\r\n");
            sb.Append("}\r\n");

            #endregion


            #endregion

            return sb.ToString();
        }

        #region 生成数据库助手帮助类
        /// <summary>
        /// 数据库助手帮助类
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GetnSQLHelper(string ns,string connstr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using MySql.Data.MySqlClient;\r\n");
            sb.Append("using System;\r\n");
            sb.Append("using System.Collections.Generic;\r\n");
            sb.Append("using System.Data;\r\n");
            sb.Append("using System.Linq;\r\n");
            sb.Append("using System.Text;\r\n");
            sb.Append("using System.Threading.Tasks;\r\n");
            sb.Append("\r\n");
            sb.Append("namespace "+ns+"\r\n");
            sb.Append("\r\n");
            sb.Append("        #region DBHelper帮助类\r\n");
            sb.Append("\r\n");
            sb.Append("        public class DBHelper\r\n");
            sb.Append("        {\r\n");
            sb.Append("            private MySqlConnection conn = null;\r\n");
            sb.Append("            private MySqlCommand cmd = null;\r\n");
            sb.Append("            private MySqlDataReader dr = null;\r\n");
            sb.Append("            public DBHelper()\r\n");
            sb.Append("            {\r\n");

            sb.Append("                conn = new MySqlConnection("+ connstr + ");\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 创建Command对象\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"sql\">sql语句</param>\r\n");
            sb.Append("            public void CreateCommand(string sql)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                conn.Open();\r\n");
            sb.Append("                cmd = new MySqlCommand(sql, conn);\r\n");
            sb.Append("\r\n");
            sb.Append("            }\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 创建存储过程Command对象\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"proName\"></param>\r\n");
            sb.Append("            public void CreateStoredCommand(string proName)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                conn.Open();\r\n");
            sb.Append("\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 添加参数，默认是输入参数\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"paramName\"></param>\r\n");
            sb.Append("            /// <param name=\"value\"></param>\r\n");
            sb.Append("            public void AddParamter(string paramName, object value)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                MySqlParameter p = new MySqlParameter(paramName, value);\r\n");
            sb.Append("                cmd.Parameters.Add(p);\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 添加输出参数，用于存储过程\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"paramName\"></param>\r\n");
            sb.Append("            public void AddOutPutParameter(string paramName)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                MySqlParameter p = new MySqlParameter();\r\n");
            sb.Append("                p.ParameterName = paramName;\r\n");
            sb.Append("                p.Direction = ParameterDirection.Output;\r\n");
            sb.Append("                p.Size = 20;\r\n");
            sb.Append("                cmd.Parameters.Add(p);\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 获取输出参数的值\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"paramName\">输出参数名</param>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public string GetOutPutParameter(string paramName)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return cmd.Parameters[paramName].Value.ToString();\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 执行增删改SQL语句或存储过程\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public bool ExecuteNonQuery()\r\n");
            sb.Append("            {\r\n");
            sb.Append("                int res;\r\n");
            sb.Append("                try\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    res = cmd.ExecuteNonQuery();\r\n");
            sb.Append("                    if (res > 0)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        return true;\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("                catch (Exception ex)\r\n");
            sb.Append("                {\r\n");
            sb.Append("\r\n");
            sb.Append("                    throw ex;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                finally\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        conn.Close();\r\n");
            sb.Append("                        conn.Dispose();\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("\r\n");
            sb.Append("                return false;\r\n");
            sb.Append("\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 执行查询SQL语句或存储过程\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public DataTable ExecuteQuery()\r\n");
            sb.Append("            {\r\n");
            sb.Append("                DataTable dt = new DataTable();\r\n");
            sb.Append("                using (dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    dt.Load(dr);\r\n");
            sb.Append("                }\r\n");
            sb.Append("                return dt;\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 返回查询SQL语句或存储过程查询出结果的第一行第一列值\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public string ExcuteScalar()\r\n");
            sb.Append("            {\r\n");
            sb.Append("                string res = \"\";\r\n");
            sb.Append("                try\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    object obj = cmd.ExecuteScalar();\r\n");
            sb.Append("                    if (obj != null)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        res = obj.ToString();\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("                catch (Exception ex)\r\n");
            sb.Append("                {\r\n");
            sb.Append("\r\n");
            sb.Append("                    throw ex;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                finally\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        conn.Close();\r\n");
            sb.Append("                        conn.Dispose();\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("\r\n");
            sb.Append("                return res;\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 返回IDataReader只读数据流\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public IDataReader ExcuteReader()\r\n");
            sb.Append("            {\r\n");
            sb.Append("                try\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    dr = cmd.ExecuteReader();\r\n");
            sb.Append("                    return dr;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                catch (Exception ex)\r\n");
            sb.Append("                {\r\n");
            sb.Append("\r\n");
            sb.Append("                    throw ex;\r\n");
            sb.Append("                }\r\n");
            sb.Append("\r\n");
            sb.Append("            }\r\n");
            sb.Append("\r\n");
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 关闭数据库连接\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public void CloseConn()\r\n");
            sb.Append("            {\r\n");
            sb.Append("                try\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        conn.Close();\r\n");
            sb.Append("                        conn.Dispose();\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("                catch (Exception)\r\n");
            sb.Append("                {\r\n");
            sb.Append("\r\n");
            sb.Append("                    throw;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                finally\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        conn.Close();\r\n");
            sb.Append("                        conn.Dispose();\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n");
            sb.Append("\r\n");
            sb.Append("        #endregion\r\n");
            return sb.ToString();
        }

        #endregion

    }
}
