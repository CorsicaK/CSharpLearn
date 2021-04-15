using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.GenericMethods
{
    public static  class Algorithm
    {
        public static decimal AccumulateSimple(IEnumerable<Account> source)
        {
            decimal sum = 0;
            foreach (Account a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }

        /// <summary>
        /// 泛型类型可以用where子句来限制
        /// 用于泛型类的子句也可用于泛型方法
        /// </summary>
        /// <typeparam name="TAccount"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source)
            where TAccount : IAccount
        {
            decimal sum = 0;
            foreach (TAccount a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }

        /// <summary>
        /// 带委托的泛型方法
        /// </summary>
        /// <typeparam name="T1">用于实现IEnumerable<T1>参数的集合</T1></typeparam>
        /// <typeparam name="T2">使用泛型委托Func<T1,T2,TResult>，前两个为输入参数，第三个为返回值</typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T2 Accumulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
        {
            T2 sum = default(T2);
            foreach (T1 item in source)
            {
                sum = action(item, sum);
            }
            return sum;
        }
    }
}
