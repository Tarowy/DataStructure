using System;
using System.Collections.Generic;

namespace DataStructure.BinaryTree
{
    public class BST1<E> where E : IComparable<E>
    {
        private class Node
        {
            public E e;
            public Node left;
            public Node right;

            public Node(E e)
            {
                this.e = e;
                left = null;
                right = null;
            }
        }

        private Node _root;
        private int _n;

        public BST1()
        {
            _root = null;
            _n = 0;
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        #region 添加

        /// <summary>
        /// 非递归方式添加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddByOrder(E e)
        {
            //如果二叉查找树为空，直接在根节点添加
            if (_root == null)
            {
                _root = new Node(e);
                _n++;
                return;
            }

            Node pre = null;
            var cur = _root;

            while (cur != null)
            {
                if (e.CompareTo(cur.e) == 0)
                {
                    return;
                }

                pre = cur;
                //如果要添加的元素小于当前元素则向左查找，否则向右查找
                cur = e.CompareTo(cur.e) < 0 ? cur.left : cur.right;
            }

            cur = new Node(e);

            if (e.CompareTo(pre.e) < 0)
            {
                pre.left = cur;
            }
            else
            {
                pre.right = cur;
            }

            _n++;
        }

        public void Add(E e)
        {
            _root = Add(_root, e);
        }

        /// <summary>
        /// 递归方式添加子节点
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="e">要添加的节点元素</param>
        /// <returns>返回根节点的地址</returns>
        private Node Add(Node node, E e)
        {
            //这一步执行了才表明真正把元素添加进去了
            if (node == null)
            {
                _n++;
                return new Node(e);
            }

            switch (e.CompareTo(node.e))
            {
                case < 0:
                    node.left = Add(node.left, e);
                    break;
                case > 0:
                    node.right = Add(node.right, e);
                    break;
            }

            return node;
        }

        #endregion

        #region 包含

        public bool Contains(E e)
        {
            return Contains(_root, e);
        }

        private bool Contains(Node node, E e)
        {
            if (node == null)
            {
                return false;
            }

            // if (node.e.CompareTo(e) == 0)
            // {
            //     return true;
            // }
            // else if (node.e.CompareTo(e) < 0)
            // {
            //     return Contains(node.left, e);
            // }
            // else //node.e.CompareTo(e) > 0
            // {
            //     return Contains(node.right, e);
            // }

            //语法糖写法
            return node.e.CompareTo(e) switch
            {
                0 => true,
                < 0 => Contains(node.left, e),
                _ => Contains(node.right, e)
            };
        }

        #endregion

        #region 遍历

        public void PreOrder()
        {
            PreOrder(_root);
        }

        /// <summary>
        ///     先序遍历 根左右
        /// </summary>
        /// <param name="node"></param>
        private void PreOrder(Node node)
        {
            if (node is null)
            {
                return;
            }

            Console.Write(node.e + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void InOrder()
        {
            InOrder(_root);
        }

        /// <summary>
        ///     中序遍历 左根右
        /// </summary>
        /// <param name="node"></param>
        private void InOrder(Node node)
        {
            if (node is null)
            {
                return;
            }

            InOrder(node.left);
            Console.Write(node.e + " ");
            InOrder(node.right);
        }

        public void PostOrder()
        {
            PostOrder(_root);
        }

        /// <summary>
        ///     后序遍历 左右根
        /// </summary>
        /// <param name="node"></param>
        private void PostOrder(Node node)
        {
            if (node is null)
            {
                return;
            }

            PostOrder(node.left);
            PostOrder(node.right);
            Console.Write(node.e + " ");
        }

        /// <summary>
        /// 借助队列进行层序遍历
        ///     每出队一个元素，就先后将该元素的左孩子和右孩子入队到队尾
        /// </summary>
        public void LevelOrder()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(_root);

            while (queue.Count != 0)
            {
                var dequeue = queue.Dequeue();
                Console.Write(dequeue.e + " ");

                if (dequeue.left != null)
                {
                    queue.Enqueue(dequeue.left);
                }

                if (dequeue.right != null)
                {
                    queue.Enqueue(dequeue.right);
                }
            }
        }

        #endregion
    }
}