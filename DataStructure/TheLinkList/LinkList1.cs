using System;
using System.Text;

namespace DataStructure.TheLinkList
{
    public class LinkList1<E>
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

        private Node Head; //链表的头节点
        private int N; //链表长度

        public LinkList1()
        {
            Head = null;
            N = 0;
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        #region 添加

        public void Add(int index, E e)
        {
            if (index > N || index < 0)
            {
                throw new ArgumentException("数组越界");
            }

            //如果还没有任何节点
            if (index == 0)
            {
                // Node node = new Node(e);
                // node.Next = Head;
                // Head = node;
                //以上的简化版本
                Head = new Node(e, Head);
            }
            else //如果以及存在节点了，找到对应的索引
            {
                Node pre = Head;
                for (int i = 0; i < index - 1; i++)
                    pre = pre.Next;

                // Node node = new Node(e);
                // node.Next = pre.Next;
                // pre.Next = node;
                //以上的简化版本
                pre.Next = new Node(e, pre.Next);
            }

            N++;
        }

        public void AddLast(E e)
        {
            Add(N, e);
        }

        public void AddFirst(E e)
        {
            Add(0, e);
        }

        #endregion

        #region 获取元素

        public E Get(int index)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("数组越界");
            }

            Node cur = Head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.Next;
            }

            return cur.E;
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(N - 1);
        }

        public bool Contains(E e)
        {
            var cur = Head;
            while (cur != null)
            {
                if (cur.E.Equals(e))
                {
                    return true;
                }

                cur = cur.Next;
            }

            return false;
        }

        #endregion

        #region 修改元素

        public void Set(int index, E newE)
        {
            if (index < 0 || index >= N)
            {
                throw new ArgumentException("数组越界");
            }

            var cur = Head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.Next;
            }

            cur.E = newE;
        }

        #endregion

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var cur = Head;
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