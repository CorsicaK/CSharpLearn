using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap3
{
    class MainEntryPoint
    {
        //用于区分值传递和引用传递
        static void SomeFunction(int[] ints, int i)
        {
            ints[0] = 100;
            i = 100;
        }
   
        static void Main(string[] args)
        {
            //尝试调用静态方法
            Console.WriteLine("pi:" + MathTest.GetPi());
            int x = MathTest.GetSquareOf(5);
            Console.WriteLine("Square of 5 is:" + x);
            //实例化一个MathTest对象
            MathTest math = new MathTest();
            //调用非静态方法
            math.value = 30;
            Console.WriteLine(math.value);
            Console.WriteLine(math.GetSquare());

            //值传递和引用传递示例
            int i = 0;
            int[] ints = { 0, 1, 2, 4, 8 };
            // 显示原始值
            Console.WriteLine("i = " + i);
            Console.WriteLine("ints[0] = " + ints[0]);
            Console.WriteLine("Calling SomeFunction...");
            // 调用该方法之后，值传递的i不会改变，引用传递的ints[0]改变
            SomeFunction(ints, i);
            Console.WriteLine("i = " + i);//i = 0
            Console.WriteLine("ints[0] = " + ints[0]);//ints[0] = 100

            //调用重写的ToString()方法
            Money money = new Money();
            money.Amount = 40M;
            Console.WriteLine(money.ToString());

            Console.ReadKey();
        }

        //定义一个MathTest类
        class MathTest
        {
            public int value;
            public int GetSquare()
            {
                return value * value;
            }
            public static int GetSquareOf(int x)
            {
                return x * x;
            }
            public static double GetPi()
            {
                return 3.14159;
            }
        }

        //重写ToString()方法
        public class Money
        {
            private decimal amount;
            public decimal Amount
            {
                get
                {
                    return amount;
                }
                set
                {
                    amount = value;
                }
            }
            public override string ToString()
            {
                return "$" + Amount.ToString();
            }
        }
    }
}
