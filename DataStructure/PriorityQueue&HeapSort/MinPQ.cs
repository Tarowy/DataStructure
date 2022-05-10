using System;
using DataStructure.StackAndQueue;

namespace DataStructure.PriorityQueue_HeapSort
{
    /// <summary>
    /// 最小优先队列，小的先出队，大的排在后面
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class MinPQ<E> : IQueue<E> where E : IComparable<E>
    {
        private MinHeap<E> _minHeap;

        public MinPQ(int capacity)
        {
            _minHeap = new MinHeap<E>(capacity);
        }

        public bool IsEmpty => _minHeap.IsEmpty;
        public int Count => _minHeap.Count;

        public void EnQueue(E e)
        {
            _minHeap.Insert(e);
        }

        public E DeQueue()
        {
            return _minHeap.RemoveMin();
        }

        public E Peek()
        {
            return _minHeap.Min();
        }
        
        public override string ToString()
        {
            return _minHeap.ToString();
        }
    }
}