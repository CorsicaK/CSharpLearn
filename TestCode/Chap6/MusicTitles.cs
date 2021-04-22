using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap6
{
    public class MusicTitles
    {
        string[] names =
        {
            "TSA",
            "JhsgtU Thsn",
            "Hksja U",
            "JKSDJAnn sk"
        };
        //类支持的默认迭代是定义为返回IEnumerator()方法，命名的迭代返回IEnumerable
        public IEnumerator<string> GetEnumerator()
        {
            for(int i = 0; i < 4; i++)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Reverse()
        {
            for (int i = 3; i >= 0; i--)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Subset(int index,int length)
        {
            for(int i = index; i < index + length; i++)
            {
                yield return names[i];
            }
        }
    }
}
