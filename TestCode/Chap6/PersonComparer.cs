using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap6
{
    /// <summary>
    /// 枚举用于PersonComparer的排序选项：FirstName/LastName
    /// </summary>
    public enum PersonCompareType
    {
        FirstName,
        LastName
    }
    /// <summary>
    /// 此方法用于与之前不同的排序方式，或者不能修改在数组中用作元素的类
    /// </summary>
    public class PersonComparer : IComparer<Person>
    {
        private PersonCompareType compareType;
        public PersonComparer(PersonCompareType compareType)
        {
            this.compareType = compareType;
        }
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            switch (compareType)
            {
                case PersonCompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case PersonCompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                default:
                    throw new ArgumentException("UNEXCEPTED COMPARE TYPE");
            }
        }
    }
}
