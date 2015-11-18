using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox[] box = new PictureBox[17];

        private void Form1_Load(object sender, EventArgs e)
        {
            box[1] = this.pictureBox2;
            box[2] = this.pictureBox3;
            box[3] = this.pictureBox4;
            box[4] = this.pictureBox5;
            box[5] = this.pictureBox6;
            box[6] = this.pictureBox7;
            box[7] = this.pictureBox8;
            box[8] = this.pictureBox9;
            box[9] = this.pictureBox10;
            box[10] = this.pictureBox11;
            box[11] = this.pictureBox12;
            box[12] = this.pictureBox13;
            box[13] = this.pictureBox14;
            box[14] = this.pictureBox15;
            box[15] = this.pictureBox16;
            box[16] = this.pictureBox17;
            this.panel1.BackColor = Color.FromArgb(192, 192, 192);
            this.panel2.BackColor = Color.FromArgb(0xEE, 0x5C, 0x42);
            this.panel3.BackColor = Color.FromArgb(192, 192, 192);
            this.pictureBox1.Image = Image.FromFile("2048.png");
            this.label3.Text = 0 + " steps";
            this.label5.Text = 0 + " seconds";
            for (int i = 1; i < 17; i++)
            {
                box[i].BackColor = Color.FromArgb(0xCD, 0xCD, 0xC1);
            }
        }


        bool[] isOccupied=new bool[17];
        int[] boxValue = new int[17];
        Random rnd = new Random();
        int stepcount = 1;
        int usetimes = 0;
        void movLine(int id1, int id2, int id3, int id4)
        {
            int[] tmp=new int[5];
            int[] temp = new int[5];
            temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = 0;
            int count = 4;
            tmp[1]=boxValue[id1];
            tmp[2]=boxValue[id2];
            tmp[3]=boxValue[id3];
            tmp[4]=boxValue[id4];
            for (int i = 4; i > 0; i--)
            {
                if (tmp[i] != 0)
                    temp[count--] = tmp[i];
            }
            if (temp[1] != 0)
            {
                if (temp[1] == temp[2])
                {
                    if (temp[3] == temp[4])
                    {
                        temp[4] = temp[4] * 2;
                        temp[3] = temp[2] * 2;
                        temp[2] = 0;
                        temp[1] = 0;
                    }
                    else
                    {
                        temp[2] = temp[2] * 2;
                        temp[1] = 0;
                    }
                }
                else
                {
                    if (temp[2] == temp[3])
                    {
                        temp[3]=temp[2]*2;
                        temp[2]=temp[1];
                        temp[1] = 0;
                    }
                    else
                    {
                        if (temp[3] == temp[4])
                        {
                            temp[4] = temp[4] * 2;
                            temp[3] = temp[2];
                            temp[2] = temp[1];
                            temp[1] = 0;
                        }
                    }
                }
            }
            else if (temp[2] != 0)
            {
                if (temp[2] == temp[3])
                {
                    temp[3] = temp[3] * 2;
                    temp[2] = 0;
                }
                else
                {
                    if (temp[3] == temp[4])
                    {
                        temp[4] = temp[4] * 2;
                        temp[3] = temp[2];
                        temp[2] = 0;
                    }
                }
            }
            else if(temp[3]!=0)
            {
                if (temp[3] == temp[4])
                {
                    temp[4] = temp[4] * 2;
                    temp[3] = 0;
                }
            }
            boxValue[id1] = temp[1];
            boxValue[id2] = temp[2];
            boxValue[id3] = temp[3];
            boxValue[id4] = temp[4];
        }
        void reset()
        {
            for (int i = 1; i < 17; i++)
            {
                if (boxValue[i] == 0)
                {
                    isOccupied[i] = false;
                }
                else
                {
                    isOccupied[i] = true;
                }

            }
        }
        void rePanel1()
        {
            movLine(13, 9, 5, 1);
            movLine(14, 10, 6, 2);
            movLine(15, 11, 7, 3);
            movLine(16, 12, 8, 4);
            reset();
            this.label3.Text =Convert.ToString(stepcount++)+" steps";
        }
        void rePanel2()
        {
            movLine(1, 5, 9, 13);
            movLine(2, 6, 10, 14);
            movLine(3, 7, 11, 15);
            movLine(4, 8, 12, 16);
            reset();
            this.label3.Text = Convert.ToString(stepcount++) + " steps";
        }
        void rePanel3()
        {
            movLine(4, 3, 2, 1);
            movLine(8, 7, 6, 5);
            movLine(12, 11, 10, 9);
            movLine(16, 15, 14, 13);
            reset();
            this.label3.Text = Convert.ToString(stepcount++) + " steps";
        }
        void rePanel4()
        {
            movLine(1, 2, 3, 4);
            movLine(5, 6, 7, 8);
            movLine(9, 10, 11, 12);
            movLine(13, 14, 15, 16);
            reset();
            this.label3.Text = Convert.ToString(stepcount++) + " steps";
        }
        void keyDown(int id)
        {
            if (!CanMove())
            {
                MessageBox.Show("failed!!!");
                for (int i = 1; i < 17; i++)
                {
                    box[i].Refresh();
                    boxValue[i] = 0;
                    isOccupied[i] = false;
                }
                return;
            }
            bool flag = true;
            if (!(boxValue[1] == boxValue[2] || boxValue[2] == boxValue[3] || boxValue[3] == boxValue[4] ||
                boxValue[5] == boxValue[6] || boxValue[6] == boxValue[7] || boxValue[7] == boxValue[8] ||
                boxValue[9] == boxValue[10] || boxValue[10] == boxValue[11] || boxValue[11] == boxValue[12] ||
                boxValue[13] == boxValue[14] || boxValue[14] == boxValue[15] || boxValue[15] == boxValue[16]
                ))
            {
                for (int i = 1; i < 17; i++)
                {
                    if (boxValue[i] == 0)
                    {
                        flag = false;
                    }
                }
                if (flag&&(id == 3 || id == 4)) return;
            }
            flag=true;
            if (!(boxValue[1] == boxValue[5] || boxValue[5] == boxValue[9] || boxValue[9] == boxValue[13] ||
                boxValue[2] == boxValue[6] || boxValue[6] == boxValue[10] || boxValue[10] == boxValue[14] ||
                boxValue[3] == boxValue[7] || boxValue[7] == boxValue[11] || boxValue[11] == boxValue[15] ||
                boxValue[4] == boxValue[8] || boxValue[8] == boxValue[12] || boxValue[12] == boxValue[16]
                ))
            {
                for (int i = 1; i < 17; i++)
                {
                    if(boxValue[i]==0)
                    {
                        flag = false;
                    }
                }
                    if (flag&&(id == 1 || id == 2)) return;
            }
            switch (id)
            {
                case 1:
                    rePanel1();
                    randomP();
                    break;
                case 2:
                    rePanel2();
                    randomP();
                    break;
                case 3:
                    rePanel3();
                    randomP();
                    break;
                case 4:
                    rePanel4();
                    randomP();
                    break;
            }
        }
        void drawBox(int id)
        {
            int currValue = boxValue[id];
            switch (currValue)
            {
                case 2:
                    Graphics g = this.box[id].CreateGraphics();
                    g.Clear(Color.FromArgb(238, 228, 218));
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.DrawString("2", new Font("微软雅黑", 42, FontStyle.Bold), new SolidBrush(Color.FromArgb(121, 111, 101)), new PointF(14, 2));
                    g.Dispose();
                    break;
                case 4:
                    Graphics g4 = this.box[id].CreateGraphics();
                    g4.Clear(Color.FromArgb(236, 224, 200));
                    g4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g4.DrawString("4", new Font("微软雅黑", 42, FontStyle.Bold), new SolidBrush(Color.FromArgb(121, 111, 101)), new PointF(14, 2));
                    g4.Dispose();
                    break;
                case 8:
                    Graphics g8 = this.box[id].CreateGraphics();
                    g8.Clear(Color.FromArgb(242, 177, 121));
                    g8.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g8.DrawString("8", new Font("微软雅黑", 42, FontStyle.Bold), new SolidBrush(Color.White), new PointF(14, 2));
                    g8.Dispose();
                    break;
                case 16:
                    Graphics g16 = this.box[id].CreateGraphics();
                    g16.Clear(Color.FromArgb(245, 149, 99));
                    g16.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g16.DrawString("16", new Font("微软雅黑", 32, FontStyle.Bold), new SolidBrush(Color.White), new PointF(6, 12));
                    g16.Dispose();
                    break;
                case 32:
                    Graphics g32 = this.box[id].CreateGraphics();
                    g32.Clear(Color.FromArgb(243, 124, 94));
                    g32.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g32.DrawString("32", new Font("微软雅黑", 32, FontStyle.Bold), new SolidBrush(Color.White), new PointF(6, 12));
                    g32.Dispose();
                    break;
                case 64:
                    Graphics g64 = this.box[id].CreateGraphics();
                    g64.Clear(Color.FromArgb(246, 93, 59));
                    g64.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g64.DrawString("64", new Font("微软雅黑", 32, FontStyle.Bold), new SolidBrush(Color.White), new PointF(6, 12));
                    g64.Dispose();
                    break;
                case 128:
                case 256:
                    Graphics g128 = this.box[id].CreateGraphics();
                    g128.Clear(Color.FromArgb(237, 204, 97));
                    g128.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g128.DrawString(currValue.ToString(), new Font("微软雅黑", 26, FontStyle.Bold), new SolidBrush(Color.White), new PointF(1, 16));
                    g128.Dispose();
                    break;
                case 512:
                case 1024:
                case 2048:
                    Graphics g512 = this.box[id].CreateGraphics();
                    g512.Clear(Color.FromArgb(237, 204, 97));
                    g512.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g512.DrawString(currValue.ToString(), new Font("微软雅黑", 22, FontStyle.Bold), new SolidBrush(Color.White), new PointF(0, 20));
                    g512.Dispose();
                    break;      
                default:
                    break;
            }
        }
        void initPlay()
        {
            for (int i = 0; i < 17; i++)
            {
                isOccupied[i] = false;
            }
            for (int i = 0; i < 17; i++)
            {
                boxValue[i] = 0;
            }
            int boxNumber1 = rnd.Next(16) + 1; 
            boxValue[boxNumber1] = 2;
            drawBox(boxNumber1);
            isOccupied[boxNumber1] = true;
          
            while(true)
            {
                int boxNumber2 = rnd.Next(16) + 1;
                if (boxNumber1 == boxNumber2)
                    continue;
                boxValue[boxNumber2] = 2;
                drawBox(boxNumber2);
                isOccupied[boxNumber2] = true;
                
                break;
            }
        }

        void drawAllBox()
        {
            for (int i = 1; i < 17; i++)
            {
                if (boxValue[i] == 0)
                {
                    box[i].Refresh();
                    continue;
                }
                drawBox(i);
            }
        }
        private bool CanMove()
        {
            for (int i = 1; i < 17; i++)
            {
                if (boxValue[i] == 0) return true;
            }
                if (boxValue[1] == boxValue[2] || boxValue[2] == boxValue[3] || boxValue[3] == boxValue[4] ||
                    boxValue[5] == boxValue[6] || boxValue[6] == boxValue[7] || boxValue[7] == boxValue[8] ||
                    boxValue[9] == boxValue[10] || boxValue[10] == boxValue[11] || boxValue[11] == boxValue[12] ||
                    boxValue[13] == boxValue[14] || boxValue[14] == boxValue[15] || boxValue[15] == boxValue[16]
                    )
                    return true;
            
            if (boxValue[1] == boxValue[5] || boxValue[5] == boxValue[9] || boxValue[9] == boxValue[13] ||
                boxValue[2] == boxValue[6] || boxValue[6] == boxValue[10] || boxValue[10] == boxValue[14] ||
                boxValue[3] == boxValue[7] || boxValue[7] == boxValue[11] || boxValue[11] == boxValue[15] ||
                boxValue[4] == boxValue[8] || boxValue[8] == boxValue[12] || boxValue[12] == boxValue[16]
                )
                return true;
            return false;
        }
        void randomP()
        {
            while (true)
            {
                int boxNumber = rnd.Next(16) + 1;
                if (isOccupied[boxNumber]||boxValue[boxNumber]!=0)
                    continue;
                int number = rnd.Next(2) + 1;
                boxValue[boxNumber] = number * 2;
                drawBox(boxNumber);
                isOccupied[boxNumber] = true;

                break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 17; i++)
            {
                box[i].Refresh();
            }
            initPlay();
            usetimes = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 17; i++)
            {
                box[i].Refresh();
            }
            initPlay();
            usetimes = 0;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    keyDown(1);
                    drawAllBox();
                    break;

                case Keys.Down:
                    keyDown(2);
                    drawAllBox();
                    break;

                case Keys.Left:
                    keyDown(3);
                    drawAllBox();
                    break;

                case Keys.Right:
                    keyDown(4);
                    drawAllBox();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label5.Text = (usetimes++) + " seconds";
        }
    }
}
