using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap4
{
    class BankAccount
    {
        static void Main(string[] args)
        {
            IBankAccount venusAccount = new SaverAccount();
            IBankAccount jupiterAccount = new GoldAccount();
            venusAccount.PayIn(200);
            venusAccount.Withdraw(100);
            Console.WriteLine(venusAccount.ToString());
            jupiterAccount.PayIn(500);
            jupiterAccount.Withdraw(600);
            jupiterAccount.Withdraw(100);
            Console.WriteLine(jupiterAccount.ToString());
            ITransferBankAccount jupAccount = new CurrentAccount();
            jupAccount.PayIn(500);
            jupAccount.TransferTo(venusAccount, 100);
            Console.WriteLine(venusAccount.ToString());
            Console.WriteLine(jupAccount.ToString());
            Console.ReadKey();
        }
    }
}
