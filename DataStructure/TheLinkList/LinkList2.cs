using System;
using System.Text;

namespace DataStructure.TheLinkList
{
    public class LinkList2<E>
    {
        private class Node
        {
            public E E; //该节点储存的元素
            public Node Next; //该节点的下一个节点类

            //明确知道下一个节点是指向谁
            public Node(E e, Node next)
            {
                this.E = e;
                this.Next = next;
            }

            //不知道下一个节点指向谁
            public Node(E e)
            {
                this.E = e;
                Next = null;
            }

            public override string ToString()
            {
                return E.ToString();
            }
        }

        private Node _head;
        private Node _tail;
        private int _n;

        public LinkList2()
        {
            _head = _tail = null;
            _n = 0;
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        public void AddLast(E e)
        {
            var node = new Node(e);
            if (IsEmpty)
            {
                _head = _tail = node;
            }
            else
            {
                _tail = _tail.Next = node;
            }

            _n++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("链表为空");
            }

            var e = _head.E;
            _head = _head.Next;

            _n--;

            //删除了链表中所有的元素之后tail还指着原来的元素，也需要将tail置为空
            if (IsEmpty)
            {
                _tail = null;
            }

            return e;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("链表为空");
            }
            
            return _head.E;
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var cur = _head;
            while (cur != null)
            {
                stringBuilder.Append($"{cur.E}" + "->");
                cur = cur.Next;
            }

            stringBuilder.Append("null");
            return stringBuilder.ToString();
        }
    }
}