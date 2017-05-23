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
            psw = _psw;
            user = _user;
            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/beijing_main.jpg");
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 我的好友ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

       

        

    }
}
