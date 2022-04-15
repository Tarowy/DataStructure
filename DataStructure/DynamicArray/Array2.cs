using System;
using System.Text;

namespace DataStructure.DynamicArray
{
    /// <summary>
    /// 用于队列的循环数组
    /// </summary>
    public class Array2<E>
    {
        private E[] _data;
        private int _first;
        private int _last;
        private int _n;

        public Array2(int capacity)
        {
            _data = new E[capacity];

            _first = _last = _n = 0;
        }

        public Array2() : this(10)
        {
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        public void AddLast(E e)
        {
            if (_n == _data.Length)
            {
                ResetCapacity(_data.Length * 2);
            }

            _data[_last] = e;
            //让last的指针能在0-data.Length直接循环
            _last = (_last + 1) % _data.Length;
            _n++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("数组已空");
            }

            var ret = _data[_first];
            _data[_first] = default;

            _first = (_first + 1) % _data.Length;
            _n--;

            if (_n == _data.Length / 4)
            {
                ResetCapacity(_data.Length / 2);
            }

            return ret;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("数组已空");
            }

            return _data[_first];
        }

        public void ResetCapacity(int capacity)
        {
            var newData = new E[capacity];

            //依次将n个元素从first到last存入新数组的0-n个位置中去
            for (int i = 0; i < _n; i++)
            {
                newData[i] = _data[(_first + i) % _data.Length];
            }

            _data = newData;
            _first = 0;
            _last = _n;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Capacity: {_data.Length} Count: {_n} \n");
            stringBuilder.Append('[');
            for (int i = 0; i < _n; i++)
            {
                stringBuilder.Append(_data[(_first + i) % _data.Length]);
                if ((_first + i + 1) % _data.Length != _last)
                {
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.Append(']').ToString();
        }
    }
}