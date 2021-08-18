using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap7
{
    //定义Currency的结构
    public struct Currency
    {
        public uint Dollars;
        public uint Cents;
        public Currency(uint dollars,uint cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        public override string ToString()
        {
            return string.Format("${0}.{1,2:00}", Dollars, Cents);
        }
        //隐式的写自定义类型强制转换的方法
        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
        //显示的写自定义类型强制转换方法
        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }
        //隐式的从Currency转换为uint
        public static implicit operator Currency(uint value)
        {
            return new Currency(value, 0);
        }
        //隐式的从uint转换为Currency
        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }

        public static string GetCurrencyUnit()
        {
            return "Dollar";
        }
    }
}
