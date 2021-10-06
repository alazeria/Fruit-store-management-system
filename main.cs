using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 安永水果超市管理系统
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.skinEngine2.SkinFile = "WaveColor1.ssk";//打开皮肤
            this.treeView1.ExpandAll();//展开所有节点
            this.toolStripStatusLabel1.Text = "当前用户:" + login.username;
            if (login.role == 0)
            {
                this.toolStripStatusLabel2.Text = "用户身份:经理";
            }
            else
            {
                this.toolStripStatusLabel2.Text = "用户身份:员工";
                添加应用ToolStripMenuItem.Enabled = false;
                修改密码ToolStripMenuItem.Enabled = false;
                营业查询ToolStripMenuItem.Enabled = false;
                销售排行ToolStripMenuItem.Enabled = false;
                this.pictureBox4.Enabled = false;
                this.pictureBox4.Image = Image.FromFile(Application.StartupPath + @"\image\yellow1.jpg");
                label6.Enabled = false;
                this.pictureBox2.Enabled = false;
                this.pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\image\xs1.jpg");
                label4.Enabled = false;

                findNode(this.treeView1.Nodes[0]);//0表示根结点
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "当前时间：" + DateTime.Now.ToString();
        }

        string[] findString = { "营业额","营业查询","销售排行","添加用户"};
        private void findNode(TreeNode t)//从根结点一直往下遍历
        {
            if (t == null)
                return;
            foreach (string s1 in findString)
            {
                if (t.Text == s1)
                {
                    t.ForeColor = Color.Gray;
                    break;
                }
            }
            foreach (TreeNode child in t.Nodes)
            {
                findNode(child);
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //判断什么样的情况是不可见
            if (e.Node.ForeColor == Color.Gray)//当前用户所选择的结点
            {
                e.Cancel = true;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //判断选择了哪一个结点  不同的结点出现不同的界面
            switch (e.Node.Text)
            { 
                case "添加用户":
                    添加应用ToolStripMenuItem_Click(null,null);
                    break;
            }

        }

        private void 添加应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagement f1 = new UserManagement();
            f1.ShowDialog();

        }

        
    }
}
