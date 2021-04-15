using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.GenericMethods
{
    public class Account:IAccount
    {
        public string Name
        {
            get;
            private set;
        }
        public decimal Balance
        {
            get;
            private set;
        }
        public Account(string name, Decimal balance)
        {
            this.Name = name;
            this.Balance = Balance;
        }
    }
}
