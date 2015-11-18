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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)//取款
        {
          
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            if (ATM.CheckIsReasonable(textBox1.Text,1) == 1 || ATM.CheckIsReasonable(textBox1.Text,2) == 2)
            {
                ATM.ShowAccountMessage("取款金额必须为100的整数倍，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            if (Convert.ToInt32(textBox1.Text) >= 10000)
            {
                DataBase.CheckEvent += DataBase.EventPopUp;
            }
            if (DataBase.DrawAccountMoney(Account.getId(), Account.getPwd(), textBox1.Text))
            {
                ATM.ShowAccountMessage("取款成功");
            }
            else
            {
                ATM.ShowAccountMessage("账户余额不足");
            }
            DataBase.CheckEvent -= DataBase.EventPopUp;
         
        }

        private void button2_Click(object sender, EventArgs e)//存款
        {
          
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            if (ATM.CheckIsReasonable(textBox1.Text,1) == 1||ATM.CheckIsReasonable(textBox1.Text,2) == 2)
            {
                ATM.ShowAccountMessage("存款金额必须为100的整数倍，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            DataBase.UpdataAccountMoney(Account.getId(), Account.getPwd(), textBox1.Text);
            ATM.ShowAccountMessage("存款成功");

        }

        private void button3_Click(object sender, EventArgs e)//更改密码
        {
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            if (ATM.CheckIsReasonable(textBox1.Text,3) == 3)
            {
                ATM.ShowAccountMessage("密码必须为6位，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            DataBase.UpdateAccountPwd(Account.getId(), textBox1.Text);
            ATM.ShowAccountMessage("密码更改成功");
            ATM.ShowAccountMessage("更改后的密码为：" + textBox1.Text + "，请牢记");
        }

        private void button4_Click(object sender, EventArgs e)//查询余额
        {
            ATM.ShowAccountMessage("账户余额：" + DataBase.CheckMoney(Account.getId(), Account.getPwd()));
        }

        private void button5_Click(object sender, EventArgs e)//转账
        {
            this.Hide();
            new Transfer().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
