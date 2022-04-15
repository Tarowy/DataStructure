using System.Text;
using DataStructure.DynamicArray;

namespace DataStructure.StackAndQueue
{
    /// <summary>
    /// 基于普通动态数组实现的普通队列，时间复杂度很高
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Array1Queue<E> : IQueue<E>
    {
        private Array1<E> _array1;

        public Array1Queue(int capacity)
        {
            _array1 = new Array1<E>(capacity);
        }

        public Array1Queue()
        {
            _array1 = new Array1<E>();
        }

        public bool IsEmpty => _array1.IsEmpty;
        public int Count => _array1.Count;

        public void EnQueue(E e)
        {
            _array1.AddLast(e);
        }

        /**
         * 删除第一个元素会导致后面的所有元素向后移动，导致时间复杂度为O(n)
         */
        public E DeQueue()
        {
            return _array1.RemoveFirst();
        }

        public E Peek()
        {
            return _array1.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder("Queue: top " + _array1 + " tail").ToString();
        }
    }
}