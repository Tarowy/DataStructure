using System.Text;
using DataStructure.TheLinkList;

namespace DataStructure.StackAndQueue
{
    /// <summary>
    /// 基于普通单链表实现的队列
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkList1Queue<E> : IQueue<E>
    {
        private LinkList3<E> _list3;

        public bool IsEmpty => _list3.IsEmpty;
        public int Count => _list3.Count;

        public LinkList1Queue()
        {
            _list3 = new LinkList3<E>();
        }

        public void EnQueue(E e)
        {
            /*
            * 普通的单链表在尾部添加一个元素需要从头遍历到尾，时间复杂度O(n)
            */
            _list3.AddLast(e);
        }

        public E DeQueue()
        {
            /*
             * 只需要改变头指针的指向，时间复杂度O(1)
             */
            return _list3.RemoveFirst();
        }

        public E Peek()
        {
            return _list3.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Queue: top " + _list3 + " tail").ToString();
        }
    }
}