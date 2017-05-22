using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
