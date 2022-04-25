using System;
using System.Collections.Generic;

namespace DataStructure.BinaryTree
{
    public class BST2<Key, Value> where Key : IComparable<Key>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;

            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                left = null;
                right = null;
            }
        }

        private Node _root;
        private int _n;

        public BST2()
        {
            _root = null;
            _n = 0;
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        #region 添加

        public void Add(Key key, Value value)
        {
            _root = Add(_root, key, value);
        }

        /// <summary>
        /// 递归方式添加子节点
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="key">要添加的键</param>
        /// <param name="value">要添加的值</param>
        /// <returns>返回根节点的地址</returns>
        private Node Add(Node node, Key key, Value value)
        {
            //这一步执行了才表明真正把元素添加进去了
            if (node == null)
            {
                _n++;
                return new Node(key, value);
            }

            switch (key.CompareTo(node.key))
            {
                case < 0:
                    node.left = Add(node.left, key, value);
                    break;
                case > 0:
                    node.right = Add(node.right, key, value);
                    break;
                default:
                    node.value = value;
                    break;
            }

            return node;
        }

        #endregion

        #region 包含

        public bool Contains(Key key)
        {
            return GetNode(_root, key) != null;
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

            Console.Write(node.key + " ");
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
            Console.Write(node.key + " ");
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
            Console.Write(node.key + " ");
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
                Console.Write(dequeue.key + " ");

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

        #region 查找

        public Key Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树!");
            }

            return Min(_root).key;
        }

        /// <summary>
        ///     查找最小值
        /// </summary>
        /// <param name="node">根节点</param>
        /// <returns>最小值所在的节点</returns>
        private Node Min(Node node)
        {
            if (node.left is null)
            {
                return node;
            }

            return Min(node.left);
        }

        public Key Max()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树!");
            }

            return Max(_root).key;
        }

        /// <summary>
        ///     查找最大值
        /// </summary>
        /// <param name="node">根节点</param>
        /// <returns>最大值所在的节点</returns>
        private Node Max(Node node)
        {
            if (node.right is null)
            {
                return node;
            }

            return Max(node.right);
        }

        public Value Get(Key key)
        {
            var node = GetNode(_root,key);

            if (node ==null)
            {
                throw new ArgumentException($"键{key}不存在");
            }

            return node.value;
        }

        public void Set(Key key,Value value)
        {
            var node = GetNode(_root,key);

            if (node ==null)
            {
                throw new ArgumentException($"键{key}不存在");
            }

            node.value = value;
        }

        #endregion

        #region 删除

        public Key RemoveMin()
        {
            var ret = Min();
            _root = RemoveMin(_root);
            return ret;
        }

        /// <summary>
        ///     删除最小元素
        /// </summary>
        /// <param name="node">要删除最小元素的二叉树的根节点地址</param>
        /// <returns>删除了最小元素之后的根节点地址</returns>
        private Node RemoveMin(Node node)
        {
            //如果左子树为空，那么节点本身就是最小值，无论右子树是否有值，都需要让右子树替换自己
            if (node.left is null)
            {
                _n--;
                //node只是个指针，这一步只改变node指针的指向，并没有改变node所指向的内存的地址
                node = node.right;
                return node;
            }

            //每个节点挂接删除最小元素之后的左节点
            node.left = RemoveMin(node.left);
            /*
             * 最后终会返回根节点，这样做是为了根节点只有左子树或只有右子树的的时候
             * 再删除根节点的元素不会出现问题。否则会导致_root还是指向原来的位置
             */
            return node;
        }

        public Key RemoveMax()
        {
            var ret = Max();
            _root = RemoveMax(_root);
            return ret;
        }

        /// <summary>
        ///     删除最大元素
        /// </summary>
        /// <param name="node">要删除最大元素的二叉树的根节点地址</param>
        /// <returns>删除了最大元素之后的根节点地址</returns>
        private Node RemoveMax(Node node)
        {
            //如果右子树为空，那么节点本身就是最大值，无论左子树是否有值，都需要让左子树替换自己
            if (node.right is null)
            {
                _n--;
                //node只是个指针，这一步只改变node指针的指向，并没有改变node所指向的内存的地址
                node = node.left;
                return node;
            }

            //每个节点挂接删除最小元素之后的左节点
            node.right = RemoveMax(node.right);
            /*
             * 最后终会返回根节点，这样做是为了根节点只有左子树或只有右子树的的时候
             * 再删除根节点的元素不会出现问题。否则会导致_root还是指向原来的位置
             */
            return node;
        }

        public void Remove(Key key)
        {
            _root = Remove(_root, key);
        }

        /// <summary>
        ///     删除指定元素
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key">要删除的元素</param>
        /// <returns>删除出完元素之后的二叉树根节点</returns>
        private Node Remove(Node node, Key key)
        {
            if (node is null)
            {
                return null;
            }

            switch (key.CompareTo(node.key))
            {
                //如果删除的元素小于本节点元素就向左查找
                case < 0:
                    node.left = Remove(node.left, key);
                    return node;
                //如果删除的元素大于本节点元素就向右查找
                case > 0:
                    node.right = Remove(node.right, key);
                    return node;
                //如果等于本节点元素就真正删除该元素
                default:
                {
                    //如果该节点左孩子为空，就直接让右孩子替代自己
                    if (node.left is null)
                    {
                        node = node.right;
                        return node;
                    }

                    //如果该节点右孩子为空，就直接让左孩子替代自己
                    if (node.right is null)
                    {
                        node = node.left;
                        return node;
                    }

                    /*
                     * 如果左右孩子都有元素
                     *  1.则查找比待删除元素大的最小节点min，即右孩子中最小的元素
                     *  2.删除min获取右孩子的根节点
                     *  3.然后让该元素挂接待删元素的左孩子和右孩子
                     */
                    var min = Min(node.right);
                    min.right = RemoveMin(node.right);
                    min.left = node.left;
                    return min;
                }
            }
        }

        #endregion

        public int MaxHeight()
        {
            return MaxHeight(_root);
        }

        /// <summary>
        ///     计算树的最大高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int MaxHeight(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            // var l = MaxHeight(node.left) + 1;
            // var r = MaxHeight(node.right) + 1;
            // return Math.Max(l, r);

            return Math.Max(MaxHeight(node.left) + 1, MaxHeight(node.right) + 1);
        }

        private Node GetNode(Node node, Key key)
        {
            if (node is null)
            {
                return null;
            }

            return node.key.CompareTo(key) switch
            {
                0 => node,
                > 0 => GetNode(node.left, key),
                _ => GetNode(node.right, key)
            };
        }
    }
}