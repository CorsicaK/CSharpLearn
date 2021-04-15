using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.GenericMethods
{
    /// <summary>
    /// 泛型方法的举例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<Account>()
            {
                new Account("A",1500),
                new Account("B",2200),
                new Account("C",1800),
                new Account("D",2400)
            };
            decimal amount = Algorithm.AccumulateSimple(accounts);
            Console.WriteLine(amount);
            amount = Algorithm.Accumulate<Account>(accounts);
            Console.WriteLine(amount);
            amount = Algorithm.Accumulate(accounts);
            Console.WriteLine(amount);
            //Chap8讲Lambda表达式
            amount = Algorithm.Accumulate<Account, decimal>(
                accounts, (item, sum) => sum += item.Balance);
            Console.WriteLine(amount);
            Console.ReadKey();
        }
    }
}
