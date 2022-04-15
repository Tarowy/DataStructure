using System.Text;
using DataStructure.TheLinkList;

namespace DataStructure.StackAndQueue
{
    public class LinkListStack<E>: IStack<E>
    {
        private LinkList1<E> _linkList1;

        public LinkListStack()
        {
            _linkList1 = new LinkList1<E>();
        }

        public bool IsEmpty => _linkList1.IsEmpty;
        public int Count => _linkList1.Count;
        
        public void Push(E e)
        {
            /*
             * 链表的头部访问是常数的时间复杂度，所以用头部作为栈顶能更快
             */
            _linkList1.AddFirst(e);
        }

        public E Pop()
        {
            return _linkList1.RemoveFirst();
        }

        public E Peek()
        {
            return _linkList1.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Stack: top " + _linkList1).ToString();
        }
    }
}