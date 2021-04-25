using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private string getConnStr()
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
        private void btnConnection_Click(object sender, EventArgs e)
        {
            //1、清空表的操作：清空选择框里所有的表
            lsbLeft.Items.Clear();
            lsbRight.Items.Clear();
            listLeft.Clear();
            listRight.Clear();

            try
            {
                //2、拼接连接数据库字符串
                string connstr = getConnStr();
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
        private void lsbAllToRight_Click(object sender, EventArgs e)
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
        private void btnToRight_Click(object sender, EventArgs e)
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
        private void btnToLeft_Click(object sender, EventArgs e)
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
        private void btnAllToLeft_Click(object sender, EventArgs e)
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
        private void lsbRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RightToLeft1();
        }
        /// <summary>
        /// 左边列表鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LeftToRight();
        }

        /// <summary>
        /// 目录选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrl_Click(object sender, EventArgs e)
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
        private void btnModel_Click(object sender, EventArgs e)
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
            }
            //3、其他
            string front = txtFront.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string consrt = getConnStr();
            string dataBase = txtSqlDataBase.Text.Trim();
            
            string className = tabName.Replace(front, "");
            //首字线大字
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            //获取Model模板代码
            txtCode.Text =GenModel.GetAllCode(ns,tabName,author,className,consrt,dataBase);
        }
    }
}
