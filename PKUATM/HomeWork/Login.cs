using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();// exit the app;
        }

        private void button1_Click(object sender, EventArgs e)//是否已经注册
        {
            //与数据库中的信息比较
            //进行文本匹配
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckEmpty(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            if (!ATM.CheckIsNum(textBox1.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            if (ATM.CheckIsReasonable(textBox1.Text, 4) == 4)
            {
                ATM.ShowAccountMessage("账户为8位，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            if (ATM.CheckIsReasonable(textBox2.Text,3) == 3)
            {
                ATM.ShowAccountMessage("密码为6位，请重新设定");
                this.textBox2.Text = "";
                return;
            }
            
            //检测数据
            //
            if (!DataBase.FindAccount(textBox1.Text))
            {
                DataBase.OpenAccount(textBox1.Text, textBox2.Text);
                ATM.ShowAccountMessage("账户注册成功");
            }
            else
            {
                ATM.ShowAccountMessage("已有此账号，不需要重复注册");
            }

        }

        private void button2_Click(object sender, EventArgs e)//可以登录否？
        {
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckEmpty(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            if (!ATM.CheckIsNum(textBox1.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            if (ATM.CheckIsReasonable(textBox1.Text, 4) == 4)
            {
                ATM.ShowAccountMessage("账户为8位，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            if (ATM.CheckIsReasonable(textBox2.Text,3) == 3)
            {
                ATM.ShowAccountMessage("密码为6位，请重新输入");
                this.textBox2.Text = "";
                return;
            }
            //与数据库中的信息比较
            //新的界面；
            if (DataBase.ToMatchIdAndPwd(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Account.setId(textBox1.Text);
                Account.setPwd(textBox2.Text);
                Account.money = DataBase.CheckMoney(textBox1.Text, textBox2.Text);
                new MainForm().Show();
            }
            else
            {
                ATM.ShowAccountMessage("账号与密码不匹配");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
