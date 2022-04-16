using System.Text;
using DataStructure.TheLinkList;

namespace DataStructure.StackAndQueue
{
    /// <summary>
    /// 基于带首尾指针的单链表实现的队列
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkList2Queue<E>: IQueue<E>
    {
        private LinkList2<E> _list2;

        public bool IsEmpty => _list2.IsEmpty;
        public int Count => _list2.Count;
        
        public LinkList2Queue()
        {
            _list2 = new LinkList2<E>();
        }
        
        public void EnQueue(E e)
        {
            _list2.AddLast(e);
        }

        public E DeQueue()
        {
            return _list2.RemoveFirst();
        }

        public E Peek()
        {
            return _list2.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Queue: top " + _list2 + " tail").ToString();
        }
    }
}