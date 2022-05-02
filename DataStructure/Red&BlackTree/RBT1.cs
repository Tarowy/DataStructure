using System;

namespace DataStructure.Red_BlackTree
{
    /// <summary>
    ///     红黑树
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class RBT1<E> where E : IComparable<E>
    {
        private const bool Red = true;
        private const bool Black = false;

        private class Node
        {
            public E e;
            public Node left;
            public Node right;
            public bool Color;

            public Node(E e)
            {
                this.e = e;
                left = null;
                right = null;
                /*
                 * 新加入的节点都是红色，方便进行融合
                 * 而null节点和根节点规定为黑色
                 */
                Color = Red;
            }
        }

        private Node _root;
        private int _n;

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        public RBT1()
        {
            _root = null;
            _n = 0;
        }

        #region 红黑树规则

        private bool IsRed(Node node)
        {
            return node is not null && node.Color;
        }


        /// <summary>
        /// 如果出现右结点为红色而左结点是黑色，进行左旋转操作
        /// 左旋转：将红色右结点转换为左结点
        ///   node|b                     x|b
        ///  /    \      左旋转         /    \
        /// T1    x|r   --------->  node|r  T3
        ///      / \                /   \
        ///     T2 T3              T1   T2
        /// 旋转完之后，x的颜色更改成node原本的颜色，node的颜色一定改成红色
        /// </summary>
        /// <param name="node">要旋转的根节点</param>
        /// <returns>旋转完成后的根节点</returns>
        private Node LeftRotate(Node node)
        {
            var x = node.right;
            node.right = x.left;
            x.left = node;
            x.Color = node.Color;
            node.Color = Red;
            return x;
        }

        /// <summary>
        /// 如果一个节点的左右子树都是红色的，那么就需要颜色翻转
        ///     1.node节点变为红色，左右子树变为黑色
        ///     2.如果node节点是根节点就也变为黑色
        ///       x|b     FlipColor     x|r
        ///      /   \     ------>    /    \
        ///    T1|r T2|r            T1|b  T2|b
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void FlipColor(Node node)
        {
            node.Color = Red;
            node.left.Color = Black;
            node.right.Color = Black;
        }

        /// <summary>
        /// 如果出现连续两个红色的左子结点，进行右旋转操作
        ///     node|b                  x|b
        ///    /    \     右旋转       /   \
        ///   x|r   T2   ------->   T3|r  node|r
        ///  /   \                        /   \
        /// T3|r T1                      T1   T2
        /// 旋转完之后，x的颜色更改成node原本的颜色，node的颜色一定改成红色
        /// </summary>
        /// <param name="node">要旋转的根节点</param>
        /// <returns>旋转完成后的根节点</returns>
        private Node RightRotate(Node node)
        {
            var x = node.left;
            node.left = x.right;
            x.right = node;
            x.Color = node.Color;
            node.Color = Red;
            return x;
        }

        #endregion

        #region 添加

        public void Add(E e)
        {
            _root = Add(_root, e);
            _root.Color = Black;
        }

        /// <summary>
        ///     递归方式添加子节点，每个节点都要注意不能违反红黑树的定义
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

            //如果右节点是红色的，就左旋
            if (!IsRed(node.left) && IsRed(node.right))
            {
                node = LeftRotate(node);
            }

            //如果两个连续的左节点都是红色，则右旋
            if (IsRed(node.left) && IsRed(node.left.left))
            {
                node = RightRotate(node);
            }

            //如果两个左右节点都是红色，则颜色翻转
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColor(node);
            }

            return node;
        }

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

            //语法糖写法
            return node.e.CompareTo(e) switch
            {
                0 => true,
                < 0 => Contains(node.left, e),
                _ => Contains(node.right, e)
            };
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

            return Math.Max(MaxHeight(node.left) + 1, MaxHeight(node.right) + 1);
        }

        #region 删除

        //红黑树的删除比较复杂，无法理解

        #endregion
    }
}