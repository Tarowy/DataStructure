using System;
using DataStructure.StackAndQueue;

namespace DataStructure.PriorityQueue_HeapSort
{
    /// <summary>
    /// 最大优先队列，大的排在前面，小的排在后面
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class MaxPQ<E> : IQueue<E> where E : IComparable<E>
    {
        private MaxHeap<E> _maxHeap;

        public MaxPQ(int capacity)
        {
            _maxHeap = new MaxHeap<E>(capacity);
        }

        public bool IsEmpty => _maxHeap.IsEmpty;
        public int Count => _maxHeap.Count;

        public void EnQueue(E e)
        {
            _maxHeap.Insert(e);
        }

        public E DeQueue()
        {
            return _maxHeap.RemoveMax();
        }

        public E Peek()
        {
            return _maxHeap.Max();
        }

        public override string ToString()
        {
            return _maxHeap.ToString();
        }
    }
}