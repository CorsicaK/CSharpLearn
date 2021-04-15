using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5
{
    //创建链表节点的泛型版本
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }
        public T Value
        {
            get;
            internal set;
        }
        public LinkedListNode<T> Next
        {
            get;
            internal set;
        }
        public LinkedListNode<T> Prev
        {
            get;
            internal set;
        }
    }
}
