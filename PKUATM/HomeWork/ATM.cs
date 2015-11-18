using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HomeWork
{
   class ATM
   {
       static Regex RegexInText = new Regex("^(\\d|\b)+$");
       
       static public bool CheckIsNum( string str )
       {
           if (!RegexInText.IsMatch(str) && str != "")
           {
               return false;
           }
           else
           {
               return true;
           }
       }

       static public bool CheckEmpty(string str)
       {
           if(str != "")
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       static public void ShowAccountMessage(string str)
       {
           MessageBox.Show(str);
       }

       static public int CheckIsReasonable(string str,int number)
       {
           if (Convert.ToDouble(str) <= 0 && number==1)
           {
               return 1;
           }
           if ((Convert.ToDouble(str)) % 100.0 != 0&& number==2)
           {
               return 2;
           }
           if (str.Length!=6 && number==3)
           {
               return 3;
           }
           if (str.Length != 8 && number == 4)
           {
               return 4;
           }
           return 0;
       }
    }
}
