using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap8
{
    public class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }

        #region 以下示例多播委托，重写方法，改为返回void
        public static void MultiplyByTwo2(double value)
        {
            double result = value * 2;
            Console.WriteLine("Multiplying by 2:{0} gives {1}", value, result);
        }

        public static void Square2(double value)
        {
            double result = value * value;
            Console.WriteLine("Squaring:{0} gives {1}", value, result);
        }
        #endregion
    }
}
