using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyCodeBuilder
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 选择框左后台
        /// </summary>
        List<string> listLeft = new List<string>();
        /// <summary>
        /// 选择框右后台
        /// </summary>
        List<string> listRight = new List<string>();

        /// <summary>
        /// 获取数据连接字符串
        /// </summary>
        /// <returns>数据连接字符串</returns>
        private string GetConnStr()
        {
            string sqladdress =Tools.GetSafeSQL( txtSqlAdd.Text.Trim());
            string sqluid = Tools.GetSafeSQL(txtSqlUid.Text.Trim());
            string sqlpwd = Tools.GetSafeSQL(txtSqlPwd.Text.Trim());
            string database = Tools.GetSafeSQL(txtSqlDataBase.Text.Trim());
            string connstr = "server="+sqladdress+";database="+ database + ";userid="+sqluid+";password="+sqlpwd;
            return connstr;
        }
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接数据库按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnection_Click(object sender, EventArgs e)
        {
            //1、清空表的操作：清空选择框里所有的表
            lsbLeft.Items.Clear();
            lsbRight.Items.Clear();
            listLeft.Clear();
            listRight.Clear();

            try
            {
                //2、拼接连接数据库字符串
                string connstr = GetConnStr();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();


                //3、查询所有的表，并填充到表的操作中
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='"+ Tools.GetSafeSQL(txtSqlDataBase.Text.Trim()) + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                //将查询到的表名添加到listLeft中
                while (dr.Read())
                {
                    listLeft.Add(dr["TABLE_NAME"].ToString());
                }

                ////将查询到的表名从listLeft中添加到lsbLeft中
                foreach (string item in listLeft)
                {
                    lsbLeft.Items.Add(item);
                }


                //关闭数据库
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
            //
        }

        /// <summary>
        /// 将左列表所有的表移动到右边列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbAllToRight_Click(object sender, EventArgs e)
        {
            //移动
            foreach (string item in lsbLeft.Items)
            {
                listRight.Add(item);
                listLeft.Remove(item);
            }
            //排序
            listLeft.Sort();
            listRight.Sort();

            lsbRight.Items.Clear();

            foreach (string item in listRight)
            {
                lsbRight.Items.Add(item);
            }

            lsbLeft.Items.Clear();
        }
        /// <summary>
        /// 从左列表移动至右列表按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToRight_Click(object sender, EventArgs e)
        {
            LeftToRight();
        }


        /// <summary>
        /// 从左列表移动至右列表方法
        /// </summary>
        private void LeftToRight()
        {
            foreach (string item in lsbLeft.SelectedItems)
            {
                listRight.Add(item);
                listLeft.Remove(item);
            }

            //排序
            listLeft.Sort();
            listRight.Sort();

            lsbRight.Items.Clear();

            foreach (string item in listRight)
            {
                lsbRight.Items.Add(item);
            }
            lsbLeft.Items.Clear();

            foreach (string item in listLeft)
            {
                lsbLeft.Items.Add(item);
            }
        }

        /// <summary>
        /// 从右列表移动至左列表按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToLeft_Click(object sender, EventArgs e)
        {
            RightToLeft1();
        }

        /// <summary>
        /// 从右列表移动至左列表方法
        /// </summary>
        private void RightToLeft1()
        {
            foreach (string item in lsbRight.SelectedItems)
            {
                listRight.Remove(item);
                listLeft.Add(item);
            }

            listLeft.Sort();
            listRight.Sort();
            lsbLeft.Items.Clear();
            foreach (string item in listLeft)
            {
                lsbLeft.Items.Add(item);
            }
            lsbRight.Items.Clear();
            foreach (string item in listRight)
            {
                lsbRight.Items.Add(item);
            }

        }
        /// <summary>
        /// 从右边全部移到到左边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllToLeft_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbRight.Items)
            {
                listRight.Remove(item);
                listLeft.Add(item);
            }

            listLeft.Sort();
            listRight.Sort();

            lsbLeft.Items.Clear();
            foreach (String item in listLeft)
            {
                lsbLeft.Items.Add(item);
            }

            lsbRight.Items.Clear();
        }
      
        /// <summary>
        /// 右边列表鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RightToLeft1();
        }
        /// <summary>
        /// 左边列表鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LeftToRight();
        }

        /// <summary>
        /// 目录选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUrl_Click(object sender, EventArgs e)
        {
            string path = SelectPath();
            txtOutPath.Text = path;
        }
        /// <summary>
        /// 获取保存路径
        /// </summary>
        /// <returns>保存路径</returns>
        private string SelectPath()
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }

            return path;
        }
        /// <summary>
        /// Model预览按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModel_Click(object sender, EventArgs e)
        {
            //1、判断用户是否选择了表
            if (lsbRight.Items.Count==0)
            {
                MessageBox.Show("请选择要操作的表！");
                return;
            }
            string tabName = lsbRight.Items[0].ToString();
            //2、判断命名空间输入是否为空
            string ns = txtNameSpace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }
            //3、其他
            string front = txtFront.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string consrt = GetConnStr();
            string dataBase = txtSqlDataBase.Text.Trim();
            
            string className = tabName.Replace(front, "");
            //首字线大字
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            //获取Model模板代码
            txtCode.Text =GenModel.GetAllCode(ns,tabName,author,className,consrt,dataBase);
        }

        /// <summary>
        /// 生成DAL模板代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDAL_Click(object sender, EventArgs e)
        {
            //1、判断用户是否选择了表
            if (lsbRight.Items.Count == 0)
            {
                MessageBox.Show("请选择要操作的表！");
                return;
            }
            string tabName = lsbRight.Items[0].ToString();
            //2、判断命名空间输入是否为空
            string ns = txtNameSpace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }
            //3、其他
            string front = txtFront.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string consrt = GetConnStr();
            string dataBase = txtSqlDataBase.Text.Trim();

            string className = tabName.Replace(front, "");
            //首字线大字
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            txtCode.Text =GenDAL.GetDALCode(ns,tabName,author,className,consrt,dataBase);
        }

        /// <summary>
        /// 一键批量生成的代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            //1、判断用户是否选择了表
            if (lsbRight.Items.Count == 0)
            {
                MessageBox.Show("请选择要操作的表！");
                return;
            }
            string tabName = lsbRight.Items[0].ToString();
            //2、判断命名空间输入是否为空
            string ns = txtNameSpace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }
            //3、判断路径
            string output = txtOutPath.Text.Trim();
            if (output.ToString()=="")
            {
                output ="D:\\CodeHere\\";
                txtOutPath.Text = output;
            }
            if (!Directory.Exists(output))
            {
                try
                {
                    Directory.CreateDirectory(output);
                }
                catch (Exception)
                {
                    MessageBox.Show("请选择正确的生成目录！");
                    return;
                }
            }
            //当条件满足

            #region 生成Model

            string output_model = "";
            if (output.LastIndexOf("\\")==0)
            {
                output_model = output + "Model\\";
            }
            else
            {
                output_model = output+"\\Model\\";
            }

            if (!Directory.Exists(output_model))
            {
                Directory.CreateDirectory(output_model);
            }


            //3、其他
            string front = txtFront.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string conStr = GetConnStr();
            string dataBase = txtSqlDataBase.Text.Trim();
            string className="" ;
            foreach (string tableName in lsbRight.Items)
            {
                className = tableName.Replace(front, "");
            //首字线大字
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);
                string filePath = output_model + className + ".cs";
                StreamWriter sw1 = new StreamWriter(filePath,false);
                sw1.Write(GenModel.GetAllCode(ns, tableName, author, className, conStr, dataBase));
                sw1.Flush();
                sw1.Close();
                sw1.Dispose();
            }



            #endregion

            #region 生成DAL
            string output_dal = "";
            if (output.LastIndexOf("\\")==0)
            {
                output_dal = output + "DAL\\";
            }
            else
            {
                output_dal = output + "\\DAL\\";
            }
            if (!Directory.Exists(output_dal))
            {
                Directory.CreateDirectory(output_dal);
            }

            
            foreach (string tableName  in lsbRight.Items)
            {
                //txtCode显示第一张表
                if (tableName==lsbRight.Items[0].ToString())
                {
                    if (txtCode.Text.Trim()=="")
                    {
                        txtCode.Text = GenDAL.GetDALCode(ns, tableName, author, className, conStr, dataBase);
                    }
                }

                className = tableName.Replace(front, "");
                //首字线大字
                className = className.Substring(0, 1).ToUpper() + className.Substring(1);
                string filePath = output_dal + className + ".cs";
                StreamWriter sw2 = new StreamWriter(filePath, false);
                sw2.Write(GenDAL.GetDALCode(ns, tableName, author, className, conStr, dataBase));
                sw2.Flush();
                sw2.Close();
                sw2.Dispose();
            }

            #endregion


            #region 数据库助手类
            string filePath2 =output_dal+ "DBHelper.cs";
            StreamWriter sw3 = new StreamWriter(filePath2, false);
            sw3.Write(GenDAL.GetnSQLHelper(ns,conStr));
            sw3.Flush();
            sw3.Close();
            sw3.Dispose();
            #endregion

            #region 数据库帮助HTML文件
            string output_sqlfile = "";
            if (output.LastIndexOf("\\")>0)
            {
                output_sqlfile = output + "\\";
            }

            string path3 = output_sqlfile + txtSqlDataBase.Text.Trim()+"数据库表结构";

            #endregion

        }
    }
}
