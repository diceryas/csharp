using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.FromArgb(192,192,192);
            //this.label1.BackColor = Color.FromArgb(255,255,255);
            this.comboBox1.SelectedIndex = 0;
            this.label4.BackColor = Color.FromArgb(255, 255, 255);
            this.label6.BackColor = Color.FromArgb(255, 255, 255);
            //this.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.panel1.BackColor=Color.FromArgb(255, 255, 255);
            int testnum = Convert.ToInt32(this.comboBox1.Text.ToString());
            int count=0;
            drawline();
            Thread.Sleep(500);
            Random rnd = new Random();
            for (int i = 0; i < testnum; i++)
            {
                Graphics g = this.panel1.CreateGraphics();
                Pen p = new Pen(Color.FromArgb (rnd.Next(255),rnd.Next(255),rnd.Next(255)));
                double x_1 = rnd.Next(this.panel1.Width);  //其中的一个端点
                double y_1 = rnd.Next(this.panel1.Height);
                double deg = rnd.Next(360);   //直线偏移度数
                double x_2, y_2;
                x_2 = x_1 + this.panel1.Height*1.0 / 16.0 * Math.Cos(deg);
                y_2 = y_1 + this.panel1.Height*1.0 / 16.0 * Math.Sin(deg);
                g.DrawLine(p, Convert.ToInt32(x_1), Convert.ToInt32(y_1), Convert.ToInt32(x_2), Convert.ToInt32(y_2));
                if (JudgeIntersection(x_1, y_1, x_2, y_2))
                {
                    count++;
                }
                p.Dispose();
                g.Dispose();
            }
            this.label4.Text = Convert.ToString(count);
            double pie = testnum * 1.0 / (count * 1.0);
            this.label6.Text = Convert.ToString(pie);

        }
        void drawline()
        {
            this.panel1.Refresh();
            Graphics g = this.panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            Pen p1 = new Pen(Color.Red, 2);
            g.DrawLine(p1, 0, 0, this.panel1.Width, 0);
            g.DrawLine(p, 0, this.panel1.Height / 8*1, this.panel1.Width, this.panel1.Height / 8*1);
            g.DrawLine(p, 0, this.panel1.Height / 8*2, this.panel1.Width, this.panel1.Height / 8*2);
            g.DrawLine(p, 0, this.panel1.Height / 8*3, this.panel1.Width, this.panel1.Height / 8*3);
            g.DrawLine(p, 0, this.panel1.Height / 8*4, this.panel1.Width, this.panel1.Height / 8*4);
            g.DrawLine(p, 0, this.panel1.Height / 8*5, this.panel1.Width, this.panel1.Height / 8*5);
            g.DrawLine(p, 0, this.panel1.Height / 8*6, this.panel1.Width, this.panel1.Height / 8*6);
            g.DrawLine(p, 0, this.panel1.Height / 8*7, this.panel1.Width, this.panel1.Height / 8*7);
            g.DrawLine(p1, 0, Convert.ToInt32(this.panel1.Height * 1.0 / 8.0 * 8), this.panel1.Width, Convert.ToInt32(this.panel1.Height * 1.0 / 8.0 * 8));
            g.DrawLine(p1, 0, 0, 0, this.panel1.Height);
            g.DrawLine(p1, this.panel1.Width, 0, this.panel1.Width, this.panel1.Height);
            p.Dispose();
            p1.Dispose();
            g.Dispose();
        }
        bool JudgeIntersection(double x1, double y1, double x2, double y2)
        {
            double max_y, min_y;
            if (y1 > y2)
            {
                max_y = y1;
                min_y = y2;
            }
            else
            {
                max_y = y2;
                min_y = y1;
            }
            for (int i = 0; i < 9; i++)
            {
                if (max_y >= this.panel1.Height*1.0/ 8.0 * i && min_y < this.panel1.Height*1.0 / 8.0 * i)
                    return true;
            }
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
