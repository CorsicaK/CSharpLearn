using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chap7;
using System.Windows;

namespace Chap8
{
    class Program
    {
        //定义简单示例的委托
        private delegate string GetAString();

        //定义简单使用例子的委托
        delegate double DoubleOp(double x);
        static void Main(string[] args)
        {
            #region 简单示例说明委托调用方法
            int x = 40;
            GetAString firstStringMethod = x.ToString;
            Console.WriteLine("string is {0}", firstStringMethod());

            Currency balance = new Currency(64, 50);
            firstStringMethod = balance.ToString;
            Console.WriteLine("string is {0}", firstStringMethod());

            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine("string is {0}", firstStringMethod());

            #endregion

            #region 简单使用委托的例子
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("using operations[{0}]：", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            #endregion


            #region 泛型委托的例子
            Employee[] employees =
            {
                new Employee ("Bugs Bunny",20000),
                new Employee ("Elmr Fudd",10000),
                new Employee ("Hsk sds",15203),
                new Employee ("Jksll sss",62222),
                new Employee ("Ksnnn sa",13622),
                new Employee ("Zhang Hansj",50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            #endregion

            #region 多播委托 
            Console.WriteLine("多播委托");
            Action<double> operationsd = MathOperations.MultiplyByTwo2;
            operationsd += MathOperations.Square2;
            ProcessAndDisplayNumber(operationsd, 2.0);
            ProcessAndDisplayNumber(operationsd, 3.5);
            ProcessAndDisplayNumber(operationsd, 5.36);
            operationsd -= MathOperations.Square2;
            ProcessAndDisplayNumber(operationsd, 2.0);
            #endregion

            #region 避免多播委托因其中一个方法异常中断迭代问题
            Action d1 = One;
            d1 += Two;
            //Delegate类定义GetInvocationList()方法，返回一个Degelate对象数组
            Delegate[] delegates = d1.GetInvocationList();
            //遍历，捕获异常后继续迭代
            foreach (Action d in delegates)
            {
                try
                {
                    d();
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception caught");
                }
            }

            #endregion


            #region 匿名方法
            string mid = ",middle part,";
            Func<string, string> anonDel = delegate (string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Console.WriteLine(anonDel("Start of string"));

            //lambda改写
            Func<string, string> lambda = param =>
            {
              param += mid;
              param += " and this was added to the string.";
              return param;
            };
            Console.WriteLine(lambda("Start of string"));
            #endregion

            #region  事件的订阅与退订
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.newCar("Ferri");

            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;

            dealer.newCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;
            dealer.newCar("Red Bull Racing");
            #endregion


            Console.ReadKey();
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double res = action(value);
            Console.WriteLine("Value is {0},result of operation is {1}", value, res);
        }

        //使用多播委托重新该方法
        static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            Console.WriteLine("ProcessAndDisplayNumber called with value={0}", value);
            action(value);
        }


        static void One()
        {
            Console.WriteLine("One");
            throw new Exception("Error in one");
        }

        static void Two()
        {
            Console.WriteLine("Two");
        }



    }
}
