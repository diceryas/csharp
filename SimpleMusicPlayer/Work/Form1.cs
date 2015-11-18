using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Work
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(192,192,192);
            this.panel2.BackColor = Color.FromArgb(192,192,192);
            this.pictureBox1.Image = Image.FromFile("pic.png");
            this.textBox2.Text = "12345678";
            this.textBox1.Text = "youansheng";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            this.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label2.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label3.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label4.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label5.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label6.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label7.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label8.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            this.label4.Left -= 3;
            this.label4.Top += 8;
            this.label5.Top += 8;
            this.label6.Top += 8;
            this.label6.Left += 3;
            this.label7.Left += 5;
            this.label7.Top += 8;
            this.label3.Left -= 5;
            this.label3.Top += 8;
            this.label8.Left += 7;
            this.label8.Top += 8;
            this.label2.Left -= 7;
            this.label2.Top += 8;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer("music.wav");  //播放音乐
            sp.PlayLooping();   //循环播放

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出？", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.panel1.Enabled=false;
                SoundPlayer sp = new SoundPlayer("music.wav");  //播放音乐
                sp.Stop();
                MessageBox.Show("双击恢复音乐播放器！！！");
            }         
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.panel1.Enabled = true;
            MessageBox.Show("Welcome to Music Player!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer("music.wav");  //播放音乐
            sp.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.label4.SetBounds(175, 16, 11, 12);
            this.label2.SetBounds(175, 16, 11, 12);
            this.label3.SetBounds(175, 16, 11, 12);
            this.label5.SetBounds(175, 16, 11, 12);
            this.label6.SetBounds(175, 16, 11, 12);
            this.label7.SetBounds(175, 16, 11, 12);
            this.label8.SetBounds(175, 16, 11, 12);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "youansheng" && textBox2.Text == "12345678")
            {
                MessageBox.Show("登录成功！！！");
                this.panel2.Controls.Clear();
                System.Windows.Forms.Label label13;
                label13 = new System.Windows.Forms.Label();
                label13.AutoSize = true;
                label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label13.Location = new System.Drawing.Point(3, 9);
                label13.Name = "label13";
                label13.Size = new System.Drawing.Size(80, 16);
                label13.TabIndex = 1;
                label13.Text = "User: youansheng";
                this.panel2.Controls.Add(label13);
            }
        }       
    }
}
