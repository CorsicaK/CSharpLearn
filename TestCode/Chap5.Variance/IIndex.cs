using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.Variance
{
    //接口IIndex与类型T是协变的，并从一个只读索引器中返回这个类型
    public interface IIndex<out T>
    {     
        T this[int index] { get; }
        int Count { get; }
    }
}
