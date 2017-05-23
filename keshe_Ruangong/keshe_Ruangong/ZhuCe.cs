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
    public partial class ZhuCe : Form
    {
        public Form1 f1;
        public ZhuCe(Form1 _f1)
        {
            InitializeComponent();
            zc.ImageLocation = Application.StartupPath + "/img/注册2.png";
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/dl_beijing.jpg");
            f1 = _f1;
        }

        private void ZhuCe_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请先输入密码！");
                textBox3.Focus();
            }
        }

        private void bt_zhuce_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("请先完善信息！");
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
                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == textBox1.Text)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("该账号已经被注册过了！");
                    return;
                }
                else
                {
                    if (textBox3.Text != textBox4.Text)
                    {
                        MessageBox.Show("两次密码输入不相同！");
                    }
                    else if (textBox2.Text.Trim() != "男" && textBox2.Text.Trim() != "女")
                    {
                        MessageBox.Show("性别选项请输入男/女！");
                    }
                    else
                    {
                        int num = ds.Tables[0].Rows.Count + 1;
                        string n = num.ToString();
                        string nn = "";
                        while (nn.Length + n.Length < 5)
                            nn += "0";
                        nn += n;
                        selectcmd.CommandText = "insert into yonghu values('" + nn
                            + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                        int j = selectcmd.ExecuteNonQuery();
                        if (j == 1)
                        {
                            MessageBox.Show("注册成功！");
                            f1.Show();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
