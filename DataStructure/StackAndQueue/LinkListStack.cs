using System.Text;
using DataStructure.TheLinkList;

namespace DataStructure.StackAndQueue
{
    public class LinkListStack<E>: IStack<E>
    {
        private LinkList3<E> _linkList3;

        public LinkListStack()
        {
            _linkList3 = new LinkList3<E>();
        }

        public bool IsEmpty => _linkList3.IsEmpty;
        public int Count => _linkList3.Count;
        
        public void Push(E e)
        {
            /*
             * 链表的头部访问是常数的时间复杂度，所以用头部作为栈顶能更快
             */
            _linkList3.AddFirst(e);
        }

        public E Pop()
        {
            return _linkList3.RemoveFirst();
        }

        public E Peek()
        {
            return _linkList3.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Stack: top " + _linkList3).ToString();
        }
    }
}