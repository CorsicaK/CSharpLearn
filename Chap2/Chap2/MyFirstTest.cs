using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap2
{
    class MyFirstTest
    {
        public static void Main(string[] args)
        {
            MathLib mathObj = new MathLib();
            Console.WriteLine("Hello from Wrox.");
            Console.WriteLine(mathObj.Add(7,8));
            return;
        }
    }
}
