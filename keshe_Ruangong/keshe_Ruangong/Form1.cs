using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace keshe_Ruangong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.97;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/dl_beijing.jpg");
            denglu.ImageLocation = Application.StartupPath + @"\img\denglu2.png";
        }

        private void bt_denglu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入账号！");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码！");
            }
            else
            {
                SqlConnection lian = new SqlConnection();
                lian.ConnectionString = conn.con;
                lian.Open();

                SqlCommand selectcmd = new SqlCommand();
                selectcmd.Connection = lian;
                selectcmd.CommandText = "select * from yonghu";

                SqlDataAdapter custDA = new SqlDataAdapter();
                custDA.SelectCommand = selectcmd;

                DataSet ds = new DataSet();
                custDA.Fill(ds);

                int flag = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                {
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == textBox1.Text &&
                        ds.Tables[0].Rows[i].ItemArray[2].ToString() == textBox2.Text)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("登录成功！");       
                }
                else
                {
                    MessageBox.Show("账号或密码输入错误！");
                }
            }
        }
    }
}
