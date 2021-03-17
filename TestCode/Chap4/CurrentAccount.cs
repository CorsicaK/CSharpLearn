using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4
{
    //派生自派生接口的类
    class CurrentAccount:ITransferBankAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("Withdrawal attempt failed.");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public override string ToString()
        {
            return String.Format("Venus Bank Gold:Balance={0,6:C}", balance);
        }
        public bool TransferTo(IBankAccount destination, decimal amount)
        {
            bool result;
            result = Withdraw(amount);
            if (result)
            {
                destination.PayIn(amount);
            }
            return result;
        }

    }
}
