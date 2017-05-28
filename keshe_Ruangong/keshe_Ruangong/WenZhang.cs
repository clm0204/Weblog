﻿using System;
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
        bool flag1, flag2;
        int num;
        public WenZhang(string _user , string _id)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/bj_bk.jpg");
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
            flag1 = flag2 = false;
            num = 0;
            selectcmd.CommandText = "select * from comment where titid = '"+id+"'";
            custDA.SelectCommand = selectcmd;

            DataSet ds2 = new DataSet();
            custDA.Fill(ds2);
            fillpinglun(ds2, num);
            lian.Close();
        }
        public void fillpinglun(DataSet ds, int now)
        {
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            for (int i = now; i < ds.Tables[0].Rows.Count && i < now + 3; ++i)
            {
                if (i == now)
                {
                    panel6.Visible = true;
                    pictureBox2.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label14.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    label13.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    label16.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    
                }
                else if (i == now + 1)
                {
                    panel7.Visible = true;
                    pictureBox3.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label10.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    label9.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    label17.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                }
                else
                {
                    panel8.Visible = true;
                    pictureBox4.ImageLocation = Application.StartupPath + "/img/rw.png";
                    label12.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    label11.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    label18.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                }
            }
            if (now >= 3)
                flag1 = true;
            else
                flag1 = false;

            if (now < ds.Tables[0].Rows.Count - 1)
                flag2 = true;
            else
                flag2 = false; 
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            if (flag2)
                label7.ForeColor = Color.Blue;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            if (flag1)
                label8.ForeColor = Color.Blue;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }
      
    }
}
