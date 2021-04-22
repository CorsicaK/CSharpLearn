using System;

namespace Chap6
{
    public class Person:IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            int result = string.Compare(this.LastName, other.LastName);
            if (result == 0)
            {
                result = string.Compare(this.FirstName, other.LastName);
            }
            return result;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}