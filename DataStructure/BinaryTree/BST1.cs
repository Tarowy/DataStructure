using System;

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
                _root.e = e;
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

            if (e.CompareTo(cur.e) < 0)
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
            Add(_root, e);
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
    }
}