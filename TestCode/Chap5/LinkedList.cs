using System;
using System.Collections.Generic;


namespace Chap5
{
    //创建列表的泛型类
    public class LinkedList<T>:IEnumerable<T>
    {
        public LinkedListNode<T> First
        {
            get;
            private set;
        }
        private LinkedListNode<T> Last
        {
            get;
            private set;
        }
        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                LinkedListNode<T> previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
