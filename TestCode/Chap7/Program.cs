using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap7
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vect1, vect2, vect3;
            vect1 = new Vector(3.0, 3.0, 1.0);
            vect2 = new Vector(2.0, -4.0, -4.0);
            vect3 = vect1 + vect2;
            Console.WriteLine("vect3=" + vect3.ToString());
            vect3 += vect2;
            Console.WriteLine("vect3=vect2 gives:" + vect3.ToString());
            double dot = vect1 * vect1;
            Console.WriteLine("dot:" +dot);
            Console.WriteLine("vect1==vect2：" + (vect1 == vect2));
            Console.WriteLine("vect1!=vect2：" + (vect1 != vect2));

            //Currency balance = new Currency(10, 50);
            ////自定义类型强制转换使用
            //float f = balance;
            //float amount = 45.63f;
            //Currency amount2 = amount;//wrong

            try
            {
                Currency balance = new Currency(50, 35);
                Console.WriteLine(balance);
                Console.WriteLine("balance is" + balance);
                Console.WriteLine("balance is(using ToString()):" + balance.ToString());
                float balance2 = balance;
                Console.WriteLine("to float:" + balance2);
                balance = (Currency)balance2;
                Console.WriteLine("After converting back to Currency,=" + balance);
                Console.ReadKey();
                checked
                {
                    balance = (Currency)(-50.50);
                    Console.WriteLine("result:" + balance.ToString());
                }
            }
            catch (Exception e)
            {

            }

            try
            {
                Currency balance2 = new Currency(50, 35);
                Console.WriteLine(balance2);
                Console.WriteLine("balance2 is" + balance2);
                Console.WriteLine("balance2 is(using ToString()):" + balance2.ToString());
                uint balance3 = (uint)balance2;
                Console.WriteLine("Converting to uint gives" + balance3);
                Console.ReadKey();
            }
            catch(Exception ex) { }
            Console.ReadKey();
        }

    }
}
