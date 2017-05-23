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
    public partial class add_friend : Form
    {
        public string user;
        public add_friend(string _user)
        {
            InitializeComponent();
            user = _user;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "/img/dl_beijing.jpg");

        }

        private void bt_zhuce_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("请填写好友账号！");
                return;
            }
            else if (textBox1.Text == user)
            {
                MessageBox.Show("账号不能为自己本身！");
                return;
            }
            SqlConnection lian = new SqlConnection();
            lian.ConnectionString = conn.con;
            lian.Open();

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = lian;
            selectcmd.CommandText = "select username,sex from yonghu where username like '" + textBox1.Text + "' order by username";
            SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;

            DataSet ds = new DataSet();
            custDA.Fill(ds);
            
            selectcmd.CommandText = "select username,sex from yonghu where username not like '"+textBox1.Text
                +"' and username like '" + textBox1.Text + "%' order by username";
            //SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;
            custDA.Fill(ds);
            
            ds.Tables[0].Columns.Add(new DataColumn("bt", typeof(string)));
            string bt = "添加";
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "昵称";
            dataGridView1.Columns[1].HeaderText = "性别";
            dataGridView1.Columns[2].HeaderText = "";
            for (int i = 0; i < ds.Tables[0].Columns.Count; ++i)
            {
                // dataGridView1.Columns[i].HeaderText = "aaa";
                dataGridView1.Columns[i].Width = (dataGridView1.Size.Width /*- dataGridView1.RowHeadersWidth*/) / 3;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                //bt.Name = "lables" + i.ToString();
                dataGridView1.Rows[i].Cells[2].Value = bt;
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
            if (x != 2  || row < 0 || row >= dataGridView1.Rows.Count)
                return;
            dataGridView1.Rows[row].Cells[x].Style.ForeColor = Color.Blue;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex;
            int row = e.RowIndex;
            if (x != 2 || row < 0 || row >= dataGridView1.Rows.Count)
                return;
            dataGridView1.Rows[row].Cells[x].Style.ForeColor = Color.Black;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x = e.ColumnIndex;
            int row = e.RowIndex;
            if (x != 2|| row < 0 || row >= dataGridView1.Rows.Count)
                return;
            DialogResult rs = MessageBox.Show("确认添加该好友？", "提示", MessageBoxButtons.OKCancel);
            if (rs == DialogResult.Cancel)
                return;
            SqlConnection lian = new SqlConnection();
            lian.ConnectionString = conn.con;
            lian.Open();

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = lian;
            selectcmd.CommandText = "select * from  friend where username1 = '"+user
                +"' and username2 = '"+dataGridView1.Rows[row].Cells[0].Value.ToString()+"'";
            SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;

            DataSet ds = new DataSet();
            custDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("你已经关注了该好友！");
                return;
            }
            selectcmd.CommandText = "insert into friend values('" + user
                + "','" + dataGridView1.Rows[row].Cells[0].Value.ToString() + "')";
          int j =  selectcmd.ExecuteNonQuery();
          if (j == 1)
              MessageBox.Show("关注成功！");
        }

    
    }
}
