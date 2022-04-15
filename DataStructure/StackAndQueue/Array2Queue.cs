using System.Text;
using DataStructure.DynamicArray;

namespace DataStructure.StackAndQueue
{
    /// <summary>
    /// 基于Array2循环数组实现的循环队列
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Array2Queue<E>: IQueue<E>
    {
        private Array2<E> _array2;

        public Array2Queue(int capacity)
        {
            _array2 = new Array2<E>(capacity);
        }

        public Array2Queue()
        {
            _array2 = new Array2<E>();
        }

        public bool IsEmpty => _array2.IsEmpty;
        public int Count => _array2.Count;
        
        public void EnQueue(E e)
        {
            _array2.AddLast(e);
        }

        public E DeQueue()
        {
            return _array2.RemoveFirst();
        }

        public E Peek()
        {
            return _array2.GetFirst();
        }

        public override string ToString()
        {
            return new StringBuilder("Queue: top " + _array2 + " tail").ToString();
        }
    }
}