
namespace MyCodeBuilder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnDAL = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnModel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUrl = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFront = new System.Windows.Forms.TextBox();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.lsbAllToRight = new System.Windows.Forms.Button();
            this.lsbRight = new System.Windows.Forms.ListBox();
            this.lsbLeft = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtSqlPwd = new System.Windows.Forms.TextBox();
            this.txtSqlAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSqlDataBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSqlUid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGen);
            this.panel1.Controls.Add(this.btnDAL);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnModel);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 511);
            this.panel1.TabIndex = 0;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(219, 457);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 0;
            this.btnGen.Text = "批量生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnDAL
            // 
            this.btnDAL.Location = new System.Drawing.Point(116, 457);
            this.btnDAL.Name = "btnDAL";
            this.btnDAL.Size = new System.Drawing.Size(75, 23);
            this.btnDAL.TabIndex = 0;
            this.btnDAL.Text = "DAL预览";
            this.btnDAL.UseVisualStyleBackColor = true;
            this.btnDAL.Click += new System.EventHandler(this.BtnDAL_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(15, 490);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Copyright 2021 All Right Reserve By Author";
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(13, 457);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(75, 23);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "Model预览";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.BtnModel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUrl);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtFront);
            this.groupBox3.Controls.Add(this.txtOutPath);
            this.groupBox3.Controls.Add(this.txtNameSpace);
            this.groupBox3.Controls.Add(this.txtAuthor);
            this.groupBox3.Location = new System.Drawing.Point(9, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 111);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他项";
            // 
            // btnUrl
            // 
            this.btnUrl.Location = new System.Drawing.Point(255, 73);
            this.btnUrl.Name = "btnUrl";
            this.btnUrl.Size = new System.Drawing.Size(31, 23);
            this.btnUrl.TabIndex = 2;
            this.btnUrl.Text = "•••";
            this.btnUrl.UseVisualStyleBackColor = true;
            this.btnUrl.Click += new System.EventHandler(this.BtnUrl_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "表前缀:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "生成目录:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "命名空间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "创作者:";
            // 
            // txtFront
            // 
            this.txtFront.Location = new System.Drawing.Point(214, 20);
            this.txtFront.Name = "txtFront";
            this.txtFront.Size = new System.Drawing.Size(73, 21);
            this.txtFront.TabIndex = 1;
            this.txtFront.Text = "tb_";
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(65, 74);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(184, 21);
            this.txtOutPath.TabIndex = 1;
            this.txtOutPath.Text = "D:\\CodeGen\\";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(65, 47);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(222, 21);
            this.txtNameSpace.TabIndex = 1;
            this.txtNameSpace.Text = "MyCodeBuilder";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(65, 20);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(73, 21);
            this.txtAuthor.TabIndex = 1;
            this.txtAuthor.Text = "DockerLiu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAllToLeft);
            this.groupBox2.Controls.Add(this.btnToLeft);
            this.groupBox2.Controls.Add(this.btnToRight);
            this.groupBox2.Controls.Add(this.lsbAllToRight);
            this.groupBox2.Controls.Add(this.lsbRight);
            this.groupBox2.Controls.Add(this.lsbLeft);
            this.groupBox2.Location = new System.Drawing.Point(3, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 198);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表操作";
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Location = new System.Drawing.Point(132, 149);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(42, 26);
            this.btnAllToLeft.TabIndex = 1;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.BtnAllToLeft_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(132, 106);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(42, 26);
            this.btnToLeft.TabIndex = 1;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.BtnToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(133, 63);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(42, 26);
            this.btnToRight.TabIndex = 1;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.BtnToRight_Click);
            // 
            // lsbAllToRight
            // 
            this.lsbAllToRight.Location = new System.Drawing.Point(133, 20);
            this.lsbAllToRight.Name = "lsbAllToRight";
            this.lsbAllToRight.Size = new System.Drawing.Size(42, 26);
            this.lsbAllToRight.TabIndex = 1;
            this.lsbAllToRight.Text = ">>";
            this.lsbAllToRight.UseVisualStyleBackColor = true;
            this.lsbAllToRight.Click += new System.EventHandler(this.LsbAllToRight_Click);
            // 
            // lsbRight
            // 
            this.lsbRight.FormattingEnabled = true;
            this.lsbRight.ItemHeight = 12;
            this.lsbRight.Location = new System.Drawing.Point(181, 20);
            this.lsbRight.Name = "lsbRight";
            this.lsbRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbRight.Size = new System.Drawing.Size(120, 172);
            this.lsbRight.TabIndex = 0;
            this.lsbRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsbRight_MouseDoubleClick);
            // 
            // lsbLeft
            // 
            this.lsbLeft.FormattingEnabled = true;
            this.lsbLeft.ItemHeight = 12;
            this.lsbLeft.Location = new System.Drawing.Point(6, 20);
            this.lsbLeft.Name = "lsbLeft";
            this.lsbLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbLeft.Size = new System.Drawing.Size(120, 172);
            this.lsbLeft.TabIndex = 0;
            this.lsbLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsbLeft_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnection);
            this.groupBox1.Controls.Add(this.txtSqlPwd);
            this.groupBox1.Controls.Add(this.txtSqlAdd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSqlDataBase);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSqlUid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(193, 78);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(100, 23);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "连接";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.BtnConnection_Click);
            // 
            // txtSqlPwd
            // 
            this.txtSqlPwd.Location = new System.Drawing.Point(193, 47);
            this.txtSqlPwd.Name = "txtSqlPwd";
            this.txtSqlPwd.PasswordChar = '$';
            this.txtSqlPwd.Size = new System.Drawing.Size(100, 21);
            this.txtSqlPwd.TabIndex = 1;
            this.txtSqlPwd.Text = "111111";
            // 
            // txtSqlAdd
            // 
            this.txtSqlAdd.Location = new System.Drawing.Point(193, 20);
            this.txtSqlAdd.Name = "txtSqlAdd";
            this.txtSqlAdd.Size = new System.Drawing.Size(100, 21);
            this.txtSqlAdd.TabIndex = 1;
            this.txtSqlAdd.Text = "192.168.1.95";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地址：";
            // 
            // txtSqlDataBase
            // 
            this.txtSqlDataBase.Location = new System.Drawing.Point(55, 74);
            this.txtSqlDataBase.Name = "txtSqlDataBase";
            this.txtSqlDataBase.Size = new System.Drawing.Size(89, 21);
            this.txtSqlDataBase.TabIndex = 1;
            this.txtSqlDataBase.Text = "build";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据库：";
            // 
            // txtSqlUid
            // 
            this.txtSqlUid.Location = new System.Drawing.Point(55, 47);
            this.txtSqlUid.Name = "txtSqlUid";
            this.txtSqlUid.Size = new System.Drawing.Size(89, 21);
            this.txtSqlUid.TabIndex = 1;
            this.txtSqlUid.Text = "build";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "登陆名：";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(55, 20);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(89, 21);
            this.txtType.TabIndex = 1;
            this.txtType.Text = "MySql";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(319, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 511);
            this.panel2.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.Size = new System.Drawing.Size(489, 511);
            this.txtCode.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCodeBuilder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSqlPwd;
        private System.Windows.Forms.TextBox txtSqlAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSqlDataBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSqlUid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnDAL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFront;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAllToLeft;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button lsbAllToRight;
        private System.Windows.Forms.ListBox lsbRight;
        private System.Windows.Forms.ListBox lsbLeft;
        private System.Windows.Forms.TextBox txtCode;
    }
}

