using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.GenericMethods
{
    public interface IAccount
    {
        decimal Balance { get; }
        string Name { get; }
    }
}
