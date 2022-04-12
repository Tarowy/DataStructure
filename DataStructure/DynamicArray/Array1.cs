using System;
using System.Text;

namespace DataStructure.DynamicArray
{
    /*
     * 自己实现动态数组的框架
     */
    public class Array1
    {
        private int[] _data;
        private int _n;

        public Array1(int capacity)
        {
            _data = new int[capacity];
            _n = 0;
        }

        //如果是空参构造则默认数组长度是10
        public Array1() : this(10)
        {
        }

        public int Capacity => _data.Length; //数组的长度
        public int Count => _n; //数组实际储存的元素个数
        public bool IsEmpty => _n == 0; //数组是否为空

        #region 添加

        /// <summary>
        /// 向数组内添加元素
        /// </summary>
        /// <param name="index">指定的数组索引</param>
        /// <param name="e">要添加的元素</param>
        public void Add(int index, int e)
        {
            if (index < 0 || index > _n)
                throw new ArgumentException("数组越界");

            if (_n == _data.Length)
                ResetCapacity(_data.Length * 2); //扩容

            //讲数组的元素依次向后移动直到i<index
            for (var i = _n - 1; i >= index; i--)
                _data[i + 1] = _data[i];

            _data[index] = e;
            _n++;
        }

        /// <summary>
        /// 向末尾添加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddLast(int e)
        {
            Add(_n, e);
        }

        /// <summary>
        /// 向首部添加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddFirst(int e)
        {
            Add(0, e);
        }

        #endregion

        #region 查找

        /// <summary>
        /// 查找指定下标的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int Get(int index)
        {
            if (index < 0 || index >= _n)
            {
                throw new ArgumentException("数组越界");
            }

            return _data[index];
        }

        public int GetFirst()
        {
            return Get(0);
        }

        public int GetLast()
        {
            return Get(_n - 1);
        }

        /// <summary>
        /// 查询该集合是否包含指定元素
        /// </summary>
        /// <param name="e">要查找的元素</param>
        /// <returns></returns>
        public bool Contains(int e)
        {
            for (int i = 0; i < _n; i++)
            {
                if (_data[i] == e)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 查找指定元素的索引
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int IndexOf(int e)
        {
            for (int i = 0; i < _n; i++)
            {
                if (_data[i] == e)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 根据数组索引修改成指定的元素
        /// </summary>
        /// <param name="index">数组索引</param>
        /// <param name="newE">新元素</param>
        /// <exception cref="ArgumentException"></exception>
        public void Set(int index, int newE)
        {
            if (index < 0 || index >= _n)
            {
                throw new ArgumentException("数组越界");
            }

            _data[index] = newE;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除指定索引的元素
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>删除的元素</returns>
        /// <exception cref="ArgumentException"></exception>
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= _n)
            {
                throw new ArgumentException("数组越界");
            }

            int del = _data[index];

            for (int i = index + 1; i <= _n - 1; i++)
            {
                _data[i - 1] = _data[i];
            }

            _n--;
            _data[_n] = default(int); //让垃圾回收站回收_data[_n]的内存
            
            /*
             * 如果_n==_data.Length/2就缩容的话那么反复在
             * _data.Length/2的临界值添加或者删除元素会导致反复调用缩容扩容方法造成性能浪费
             */
            if (_n == _data.Length / 4)
            {
                ResetCapacity(_data.Length / 2);
            }

            return del;
        }

        public int RemoveFirst()
        {
            return RemoveAt(0);
        }

        public int RemoveLast()
        {
            return RemoveAt(_n - 1);
        }

        /// <summary>
        /// 删除明确知道具体值的元素
        /// </summary>
        /// <param name="e"></param>
        public void Remove(int e)
        {
            var index = IndexOf(e);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        #endregion

        /// <summary>
        /// 当数组容量不够，或者有太多没有用到的容量时对其容量进行改变
        /// </summary>
        /// <param name="newCapacity">要扩容或缩容的长度</param>
        private void ResetCapacity(int newCapacity)
        {
            var newData = new int[newCapacity];
            //将旧数组的值依次复制到新数组中
            //不能使用i < data[].length否则缩容会导致越界
            for (int i = 0; i < _n; i++)
            {
                newData[i] = _data[i];
            }

            _data = newData;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            // stringBuilder.Append(String.Format("Array1: Count:{0} Capacity:{1}\n", _n, Count));
            stringBuilder.Append($"Array1: Count:{_n} Capacity:{Capacity}\n"); //$是string.Format的语法糖
            stringBuilder.Append('[');
            for (var i = 0; i < _n; i++)
            {
                stringBuilder.Append(_data[i]);
                if (i != _n - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(']');
            return stringBuilder.ToString();
        }
    }
}