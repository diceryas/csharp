using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public partial class ATMError: ApplicationException
    {
        //a可以表示错误
        public ATMError(string a) : base(a) { }
    }
}
