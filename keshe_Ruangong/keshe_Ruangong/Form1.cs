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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.97;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"/img/dl_beijing.jpg");
            denglu.ImageLocation = Application.StartupPath + @"\img\denglu2.png";
        }
    }
}
