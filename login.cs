using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 安永水果超市管理系统
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        DataSet ds;
        public static string username;
        public static int role;
        private void Form1_Load(object sender, EventArgs e)
        {   
            //skinEngine2.SkinFile = Application.StartupPath + @"\皮肤\Diamond\DiamondGreen.ssk";
            this.skinEngine2.SkinFile = "WaveColor1.ssk";//打开皮肤
            ds = DBAccess.EXE_DS("select Username from userInfo");
            this.comboBox1.DataSource = ds.Tables[0];
            this.comboBox1.DisplayMember = "Username";
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //数据完整性检验
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                this.textBox1.Focus();
                return;
            }
            if (this.comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("请选择身份!");
                this.comboBox2.Focus();
                return;
            }
            //用户的合法性
            username = this.comboBox1.Text;
            role = this.comboBox2.SelectedIndex;
            string strcmd = string.Format("select * from userInfo where UserName='{0}' and PWD='{1}' and Role={2}",
                username,
                this.textBox1.Text,
                role);

            try
            {
                if (DBAccess.EXE_select(strcmd) == true)
                {
                    MessageBox.Show("login successful!");
                    username = this.comboBox1.Text;
                    role = this.comboBox2.SelectedIndex;
                    main f1 = new main();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("login failed!");
                   
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
