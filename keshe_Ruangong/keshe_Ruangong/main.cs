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
    public partial class main : Form
    {
        public string user, psw;
        public main(string _user ,string _psw)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Application.StartupPath + "/img/博客.png";
            psw = _psw;
            user = _user;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/beijing.jpg");
            //好友
            dataGridView1.Visible = true;
            panel3.Visible = true;
            dataGridView1.AllowUserToAddRows = false;
            SqlConnection lian = new SqlConnection();
            lian.ConnectionString = conn.con;
            lian.Open();

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = lian;
            selectcmd.CommandText = "select username2 from friend where username1 = '" + user
                + "' order by username2";
            SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;

            DataSet ds = new DataSet();
            custDA.Fill(ds);
            ds.Tables[0].Columns.Add(new DataColumn("bt", typeof(string)));
            ds.Tables[0].Columns.Add(new DataColumn("bt2", typeof(string)));
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "好友昵称";
            dataGridView1.Columns[1].HeaderText = "";
            dataGridView1.Columns[2].HeaderText = "";
            //dataGridView1.BackgroundColor = Color.Blue;
            string bt = "查看";
            string bt2 = "删除";
            for (int i = 0; i < ds.Tables[0].Columns.Count; ++i)
            {
                // dataGridView1.Columns[i].HeaderText = "aaa";
                dataGridView1.Columns[i].Width = (dataGridView1.Size.Width /*- dataGridView1.RowHeadersWidth*/) / 3;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                //bt.Name = "lables" + i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = bt;
                dataGridView1.Rows[i].Cells[2].Value = bt2;
                //MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[3].ToString() + "   " + bt);
            }
            dataGridView1.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[1].DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[2].DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.Columns[2].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ReadOnly = true;
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex;
            int row = e.RowIndex;
            if ((x != 1&&x != 2)|| row < 0 || row >= dataGridView1.Rows.Count)
                return;
            dataGridView1.Rows[row].Cells[x].Style.ForeColor = Color.Blue;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex;
            int row = e.RowIndex;
            if ((x != 1 && x != 2)|| row < 0 || row >= dataGridView1.Rows.Count)
                return;
            dataGridView1.Rows[row].Cells[x].Style.ForeColor = Color.Black;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x = e.ColumnIndex;
            int row = e.RowIndex;
            if (x != 2 || row < 0 || row >= dataGridView1.Rows.Count)
                return;
            DialogResult rs = MessageBox.Show("确认要删除该好友吗！", "提示", MessageBoxButtons.OKCancel);
            if (rs == DialogResult.OK)
            {
                SqlConnection lian = new SqlConnection();
                lian.ConnectionString = conn.con;
                lian.Open();

                SqlCommand selectcmd = new SqlCommand();
                selectcmd.Connection = lian;
                selectcmd.CommandText = "delete from friend where username1 = '"+user + "' and username2 = '"+
                    dataGridView1.Rows[row].Cells[0].Value.ToString()+"'";
               // MessageBox.Show(selectcmd.CommandText);
                int j = selectcmd.ExecuteNonQuery();
                if (j == 1)
                {
                    MessageBox.Show("删除成功！");
                    selectcmd.CommandText = "select username2 from friend where username1 = '" + user
                + "' order by username2";
                    SqlDataAdapter custDA = new SqlDataAdapter();
                    custDA.SelectCommand = selectcmd;

                    DataSet ds = new DataSet();
                    //ds.Tables[0].Columns.Add(new DataColumn("bt0", typeof()));
                    custDA.Fill(ds);
                    ds.Tables[0].Columns.Add(new DataColumn("bt", typeof(string)));
                    ds.Tables[0].Columns.Add(new DataColumn("bt2", typeof(string)));
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].HeaderText = "好友昵称";
                    dataGridView1.Columns[1].HeaderText = "";
                    dataGridView1.Columns[2].HeaderText = "";
                    //dataGridView1.BackgroundColor = Color.Blue;
                    string bt = "查看";
                    string bt2 = "删除";
                    for (int i = 0; i < ds.Tables[0].Columns.Count; ++i)
                    {
                        // dataGridView1.Columns[i].HeaderText = "aaa";
                        dataGridView1.Columns[i].Width = (dataGridView1.Size.Width /*- dataGridView1.RowHeadersWidth*/) / 3;
                    }
                    for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                    {
                        //bt.Name = "lables" + i.ToString();
                        dataGridView1.Rows[i].Cells[1].Value = bt;
                        dataGridView1.Rows[i].Cells[2].Value = bt2;
                        //MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[3].ToString() + "   " + bt);
                    }
                    dataGridView1.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView1.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridView1.Columns[1].DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView1.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridView1.Columns[2].DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView1.Columns[2].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridView1.ReadOnly = true;
                }
            }
            else
                return;
        }

        private void bt_zhuce_Click(object sender, EventArgs e)
        {
            add_friend f1 = new add_friend(user);
            f1.Show();
        }
        public bool flag1, flag2;
        int num;
        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            panel5.Visible = true;
            
           // panel3.Visible = false;
            label3.Text = user;
            SqlConnection lian = new SqlConnection();
            lian.ConnectionString = conn.con;
            lian.Open();

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = lian;
            selectcmd.CommandText = "select * from title where username = '"+user+"' order by time";
            SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;

            DataSet ds = new DataSet();
            custDA.Fill(ds);
            flag1 = flag2 = false;
            num = 0;
            filltitle(ds,num);
        }
        
        public void filltitle(DataSet ds,int now)
        {
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            for (int i = now; i < ds.Tables[0].Rows.Count && i<now+3; ++i)
            {
                if (i == now)
                {
                    panel6.Visible = true;
                    pictureBox2.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label7.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    label8.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                }
                else if (i == now + 1)
                {
                    panel7.Visible = true;
                    pictureBox3.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label10.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    label9.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                }
                else
                {
                    panel8.Visible = true;
                    pictureBox4.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label12.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    label1.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                }
            }
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Azure;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Snow;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Azure;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Azure;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Snow;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Azure;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Snow;
        }

       
        
       

        

    }
}
