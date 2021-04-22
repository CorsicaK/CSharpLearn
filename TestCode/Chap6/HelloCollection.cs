using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap6
{
    /// <summary>
    /// 实现数组枚举
    /// yield的使用
    /// </summary>
    public class HelloCollection
    {
        //包含yield语句的方法或属性也成为了迭代块
        //迭代块必须声明为返回IEnumerator或IEnumerable接口，或者这些接口的泛型版本
        //这个块可以包含多条yield return语句或yield break 语句，但不能包含return语句
        public IEnumerator<string> GetEnumerator()
        {

            yield return "HEllo";
            yield return "World";
        }
        public void HelloWorld()
        {
            var helloCol = new HelloCollection();
            foreach(var s in helloCol)
            {
                //...
            }
        }
    }
}
