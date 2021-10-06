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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }
        SqlConnection cn;//连接数据库
        SqlDataAdapter da;//
        SqlCommandBuilder cb;//不加会导致更新数据库不成功
        DataSet ds;//存放数据
        private void UserManagement_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\皮肤\Diamond\DiamondGreen.ssk";//导入皮肤
            cn = new SqlConnection(
                "server=.;database=storeMIS;integrated security=true");//创建连接
            da = new SqlDataAdapter("select userName AS 用户名,PWD AS 密码,role AS 身份 from userInfo", cn);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds,"users");
            this.dataGridView1.DataSource = ds.Tables["users"];//将表展示到dataGridView1界面
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //检测身份的取值只能是0或者1
            for (int i = 0; i <= this.dataGridView1.Rows.Count - 2; i++)
            {
                string s1 = this.dataGridView1.Rows[i].Cells[2].Value.ToString();//定义到单元格的内容
                if (s1 != "0" && s1 != "1")
                {
                    MessageBox.Show("用户角色只能是0或者是1哟！");
                    this.dataGridView1.Rows[i].Selected = true;
                    return;
                }
            }
                da.Update(ds.Tables[0]);//也可以用表名称"users"
                MessageBox.Show("数据库更新成功！");//此时会提醒失败，要想更新必须加上SqlCommandBuilder cb
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除用户选择的行
            foreach (DataGridViewRow r in this.dataGridView1.SelectedRows)//可能不只一行，给一个循环
            {
                this.dataGridView1.Rows.Remove(r);//删除选择的行
            }
            //用for循环也行，只不过比较繁琐，建议用foreach循环
            //for (int i = 0; i < this.dataGridView1.Rows.Count - 1;i>=0 i++)
            //{
            //    if (this.dataGridView1.Rows[i].Selected == true)
            //    {

            //        this.dataGridView1.Rows.RemoveAt(i);
            //    }
            //}
        }
    }
}
