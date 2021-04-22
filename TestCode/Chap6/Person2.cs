using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap6
{
    /// <summary>
    /// 显示实现IStructuralEquatable接口
    /// 用于比较两个元组或者数组是否有相同的内容
    /// </summary>
    public class Person2:IEquatable<Person2>
    {
        public int Id
        {
            get;
            private set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Id, FirstName, LastName);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }
            return Equals(obj as Person2);
        }

        public bool Equals(Person2 other)
        {
            if (other == null)
                return base.Equals(other);
            return this.Id == other.Id && this.FirstName == other.FirstName && this.LastName == other.LastName;
        }

    }
}
