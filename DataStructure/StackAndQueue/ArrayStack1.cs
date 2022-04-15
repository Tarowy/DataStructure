using System.Text;
using DataStructure.DynamicArray;

namespace DataStructure.StackAndQueue
{
    public class ArrayStack1<E> : IStack<E>
    {
        private Array1<E> _array1;

        public ArrayStack1(int capacity)
        {
            _array1 = new Array1<E>(capacity);
        }

        public ArrayStack1()
        {
            _array1 = new Array1<E>();
        }

        public bool IsEmpty => _array1.IsEmpty;
        public int Count => _array1.Count;

        public void Push(E e)
        {
            /*
             * 用数组的末尾作为栈顶，如果用数组的头作为栈顶的话
             * 每插入一个元素就得将所有元素都向后移动一位
             */
            _array1.AddLast(e);
        }

        public E Pop()
        {
            return _array1.RemoveLast();
        }

        public E Peek()
        {
            return _array1.GetLast();
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Stack: " + _array1 + "top").ToString();
        }
    }
}