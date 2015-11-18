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
    public partial class Transfer : Form
    {
       
        public Transfer()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!DataBase.FindAccount(textBox1.Text))
            {
                ATM.ShowAccountMessage("没有此账号");
                return ;
            }
            if (ATM.CheckIsReasonable(textBox1.Text, 4) == 4)
            {
                ATM.ShowAccountMessage("账户为8位，请重新输入");
                this.textBox1.Text = "";
                return;
            }
            if(!ATM.CheckEmpty(textBox2.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("金额输入框出错");
                return;
            }
            if (ATM.CheckIsReasonable(textBox2.Text, 1) == 1 || ATM.CheckIsReasonable(textBox2.Text, 2) == 2)
            {
                ATM.ShowAccountMessage("存款金额必须为100的整数倍，请重新输入");
                this.textBox2.Text = "";
                return;
            }
            
            if (Convert.ToInt32(textBox2.Text) >= 10000)
            {
                DataBase.CheckEvent += DataBase.EventPopUp;
            }
            if(!DataBase.DrawAccountMoney(Account.getId(), Account.getPwd(), textBox2.Text))
            {
                ATM.ShowAccountMessage("账户余额不足");
                DataBase.CheckEvent -= DataBase.EventPopUp;
                return;
            }
            DataBase.TransferMoney(textBox1.Text,  textBox2.Text);
            ATM.ShowAccountMessage("转账成功");
            DataBase.CheckEvent -= DataBase.EventPopUp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
