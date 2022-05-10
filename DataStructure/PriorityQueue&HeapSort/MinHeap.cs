using System;
using System.Text;

namespace DataStructure.PriorityQueue_HeapSort
{
    /// <summary>
    /// 最小二叉堆
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class MinHeap<E> where E : IComparable<E>
    {
        private E[] _heap;
        private int _n;

        public MinHeap(int capacity)
        {
            //数组的0索引不使用
            _heap = new E[capacity + 1];
            _n = 0;
        }

        public MinHeap() : this(10)
        {
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        /// <summary>
        /// 每插入一个元素都要进行上游
        /// </summary>
        /// <param name="e"></param>
        public void Insert(E e)
        {
            if (_n == _heap.Length - 1)
            {
                ResetCapacity(_heap.Length * 2);
            }

            _heap[++_n] = e;
            Swim(_n);
        }

        /// <summary>
        /// 元素的上游，如果一个节点小于它的父节点就交换位置
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 1 && _heap[k].CompareTo(_heap[k / 2]) < 0)
            {
                (_heap[k], _heap[k / 2]) = (_heap[k / 2], _heap[k]);
                k /= 2;
            }
        }

        /// <summary>
        /// 先交换首尾元素的位置，这样原本的首元素即最小元素就到了最后一个节点可以直接删除
        /// 删除后需要对交换后的首元素进行下沉
        /// </summary>
        /// <returns>被删除的元素</returns>
        public E RemoveMin()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("堆为空!");
            }

            (_heap[1], _heap[_n]) = (_heap[_n], _heap[1]);
            var min = _heap[_n];
            _heap[_n--] = default;

            if (_n == (_heap.Length - 1) / 4)
            {
                ResetCapacity(_heap.Length / 2);
            }

            Sink(1);
            return min;
        }

        /// <summary>
        /// 元素的下沉，删除最大元素后需要确保根节点的元素大于子节点的所有元素
        /// </summary>
        /// <param name="k"></param>
        private void Sink(int k)
        {
            //确保节点k至少有一个左孩子
            while (2 * k <= _n)
            {
                //k的左孩子
                var j = 2 * k;

                /*
                 * 如果k节点有右孩子且右孩子小于左孩子，说明右孩子小于左孩子及左孩子
                 * 的所有子节点，让j指向右孩子
                 */
                if (j + 1 <= _n && _heap[j + 1].CompareTo(_heap[j]) < 0)
                {
                    j++;
                }

                /*
                 * 如果k节点小于或等于左/右孩子(j)节点，说明k节点小于或等于
                 * 所有子节点，k节点则无需下沉操作
                 */
                if (_heap[k].CompareTo(_heap[j]) <= 0)
                {
                    break;
                }

                (_heap[j], _heap[k]) = (_heap[k], _heap[j]);
                k = j;
            }
        }

        public E Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("堆为空!");
            }

            return _heap[1];
        }

        private void ResetCapacity(int newCapacity)
        {
            var newHeap = new E[newCapacity];
            for (var i = 0; i <= _n; i++)
            {
                newHeap[i] = _heap[i];
            }

            _heap = newHeap;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Array1: Count:{_n}\n");
            stringBuilder.Append('[');
            for (var i = 1; i <= _n; i++)
            {
                stringBuilder.Append(_heap[i]);
                if (i != _n)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(']');
            return stringBuilder.ToString();
        }
    }
}