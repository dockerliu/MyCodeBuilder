using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCodeBuilder
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tools
    {
        #region 过滤SQL非法字符串

        /// <summary>
        /// 过滤SQL非法字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSafeSQL(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            value = Regex.Replace(value, @";", string.Empty);
            value = Regex.Replace(value, @"'", string.Empty);
            value = Regex.Replace(value, @"&", string.Empty);
            value = Regex.Replace(value, @"%20", string.Empty);
            value = Regex.Replace(value, @"--", string.Empty);
            value = Regex.Replace(value, @"==", string.Empty);
            value = Regex.Replace(value, @"<", string.Empty);
            value = Regex.Replace(value, @">", string.Empty);
            value = Regex.Replace(value, @"%", string.Empty);
            return value;
        }

        #endregion

        #region 将SQLServer数据类型转换为
        /// <summary> 
        /// 将SQLServer数据类型转换为.Net类型
        /// </summary> 
        /// <param name="sqlTypeString">SQLServer数据类型</param> 
        /// <returns></returns> 
        public static string SqlTypeName2DotNetType(string sqlTypeString)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bool" ,"datetime","decimal","float","image","money",
                                                "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
                                                "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] DotNetTypes = new string[] {"int?", "string","bool" ,"DateTime?","Decimal","Double","Byte[]","Single",
                                                "string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
                                                "Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};

            int i = Array.IndexOf(SqlTypeNames, sqlTypeString.ToLower());

            return DotNetTypes[i];
        }
        #endregion

        #region 获取数据库字段默认值
        /// <summary>
        /// 获取数据库字段默认值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string DbDefaultToCSharp(string v)
        {
            string str;
            //取时间
            if (v.Contains("getdate()"))
            {
                str = " = DateTime.Now";
            }
            //取数字
            str = GetRegexResult(@"\(\((\d+)\)\)", v, "num");
            //取字符串
            if (str == "")
            {
                str = GetRegexResult(@"\(N?'(.+)'\)", v, "string");
            }
            return str;
        }

        /// <summary>
        /// 根据正则表达式获取结果
        /// </summary>
        /// <param name="pat">正则表达式</param>
        /// <param name="v">需要匹配的内容</param>
        /// <param name="type">匹配内容的类型（num|数字 string|字符串）</param>
        /// <returns></returns>
        public static string GetRegexResult(string pat, string v, string type)
        {
            string str = "";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(v);
            //int matchCount;
            if (m.Success)
            {
                //++matchCount;
                Group g = m.Groups[1];
                if (type == "num")
                {
                    str = " = " + g.Value;
                }
                else if (type == "string")
                {
                    str = " = \"" + g.Value + "\"";
                }
            }
            return str;
        }
        #endregion
    }
}
