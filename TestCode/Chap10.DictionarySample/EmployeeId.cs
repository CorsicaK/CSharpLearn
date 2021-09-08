using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.DictionarySample
{
    public class EmployeeIdException : Exception
    {
        public EmployeeIdException(string message):base (message) { }
    }

    [Serializable]
    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;
        public EmployeeId(string id)
        {
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(id != null);
            prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (FormatException)
            {
                throw new EmployeeIdException("Invalid EmplyeeId Format");
            }
        }

        public override string ToString()
        {
            return prefix.ToString() + string.Format("{0,6:000000}", number);
        }

        public override int GetHashCode()
        {
            //将数字左移16位后与原来的数字进行异或操作，最后将结果乘以十六进制数15051505
            //使得散列代码在整数取值区域上分布相当均匀
            return (number ^ number << 16) * 0x15051505;
        }

        public static bool operator ==(EmployeeId left,EmployeeId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left==right);
        }
        public bool Equals(EmployeeId other)
        {
            if (other == null) return false;
            return (prefix == other.prefix && number == other.number);

        }

        public override  bool Equals(object obj)
        {
            return Equals((EmployeeId)obj);
        }
    }
}
