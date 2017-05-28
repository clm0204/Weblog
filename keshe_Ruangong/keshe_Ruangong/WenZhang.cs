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
    public partial class WenZhang : Form
    {
        string user, id;
        string neirong, timu;
        public WenZhang(string _user , string _id)
        {
            InitializeComponent();
            user = _user;
            id = _id;
            pictureBox1.ImageLocation = Application.StartupPath + "/img/人物2.png";
            panel1.BackColor = Color.Snow;
            label1.Text = user;
            SqlConnection lian = new SqlConnection();
            lian.ConnectionString = conn.con;
            lian.Open();

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = lian;
            selectcmd.CommandText = "select * from title where id = '"+id+"'";
            SqlDataAdapter custDA = new SqlDataAdapter();
            custDA.SelectCommand = selectcmd;

            DataSet ds = new DataSet();
            custDA.Fill(ds);
            int i;
            for ( i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                if (ds.Tables[0].Rows[i].ItemArray[0].ToString() == id)
                    break;
            }
            timu = label2.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            neirong = label3.Text = "  " + ds.Tables[0].Rows[i].ItemArray[3].ToString();

            //查看评论
            label4.Location= new Point(label4.Location.X, panel1.Location.Y + panel1.Size.Height + 20);
            panel5.Location = new Point(panel5.Location.X,label4.Location.Y+label4.Size.Height )　;
        }

      
    }
}
