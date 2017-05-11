using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadBuilder
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            for (int i = 0; i < this.Width; i += Convert.ToInt32(textBox1.Text))
            {
                g.DrawLine(Pens.Black, i, 0, i, this.Height);
            }
            for (int i = 0; i < this.Height; i += Convert.ToInt32(textBox2.Text))
            {
                g.DrawLine(Pens.Black, 0, i, this.Width, i);
            }
            g.Dispose();
        }
    }
}
