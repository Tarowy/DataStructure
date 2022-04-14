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

        #region 添加元素

        /// <summary>
        /// 在指定的索引添加元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// 获取指定索引的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public E Get(int index)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("数组越界");
            }

            var cur = Head;
            for (var i = 0; i < index; i++)
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

        #region 删除元素

        /// <summary>
        /// 根据索引删除元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public E RemoveAt(int index)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("数组越界");
            }

            if (index == 0)
            {
                var del = Head;
                Head = Head.Next;
                N--;
                return del.E;
            }
            else
            {
                var pre = Head;
                for (var i = 0; i < index - 1; i++)
                {
                    pre = pre.Next;
                }

                var del = pre.Next;
                pre.Next = del.Next;
                N--;
                return del.E;
            }
        }

        public E RemoveFirst()
        {
            return RemoveAt(0);
        }

        public E RemoveLast()
        {
            return RemoveAt(N - 1);
        }

        /// <summary>
        /// 查找指定的值并删除该元素
        /// </summary>
        /// <param name="e"></param>
        public void Remove(E e)
        {
            if (Head == null)
            {
                return;
            }

            if (Head.E.Equals(e))
            {
                Head = Head.Next;
                N--;
            }
            else
            {
                var cur = Head;
                Node pre = null;

                while (cur != null)
                {
                    if (cur.E.Equals(e))
                    {
                        pre.Next = cur.Next;
                        N--;
                        break;
                    }

                    pre = cur;
                    cur = cur.Next;
                }
            }
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