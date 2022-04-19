using System;
using System.Text;

namespace DataStructure.OrderlyArray_Search
{
    /// <summary>
    /// 有序数组，数组内储存的值都是有序的
    /// </summary>
    /// <typeparam name="Key">
    ///     泛型必须是继承了IComparable接口的类，即可排序的
    /// </typeparam>
    public class SortedArray1<Key> where Key : IComparable<Key>
    {
        private Key[] _keys;
        private int _n;

        public SortedArray1(int capacity)
        {
            _keys = new Key[capacity];
            _n = 0;
        }

        public SortedArray1() : this(10)
        {
        }

        public int Count => _n;
        public bool IsEmpty => _n == 0;

        /// <summary>
        /// 返回小于key的元素个数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            var l = 0;
            var r = _n - 1;

            while (l <= r)
            {
                // var mid = (l + r) / 2;
                /*
                 * 直接用l+r的话可能会导致溢出int的可承载范围使mid的值出错，
                 * 所以需要用减法代替加法防止溢出
                 */
                var mid = l + (r - l) / 2;

                /*
                 * 由于key是泛型，无法用来直接比较，需要调用重写过的排序接口
                 * 的排序方法才能实现比较
                 */
                switch (key.CompareTo(_keys[mid]))
                {
                    case > 0:
                        l = mid + 1;
                        break;
                    case < 0:
                        r = mid - 1;
                        break;
                    default:
                        return mid;
                }
            }

            //找不到就直接返回l的索引，这个索引也代表着小于key的元素个数
            return l;
        }

        public void Add(Key key)
        {
            var i = Rank(key);

            if (_n == _keys.Length)
            {
                ResetCapacity(_keys.Length * 2);
            }

            /*
             * 如果已经存在该元素或者索引没有越界，就什么都不做
             *      如果索引越界，说明要添加的元素大于所有已存在的元素，
             *      则直接在i索引位置添加该元素即可
             */
            if (i < _n && _keys[i].CompareTo(key) == 0)
            {
                return;
            }

            //如果不存在该元素，则在刚好大于该元素的索引位置添加该元素
            for (var j = _n - 1; j >= i; j--)
            {
                _keys[j + 1] = _keys[j];
            }

            _keys[i] = key;
            _n++;
        }

        public void Remove(Key key)
        {
            if (IsEmpty)
            {
                return;
            }

            var i = Rank(key);
            /*
             * 如果key小于任何一个元素，则i的值是0，再则i索引的值和key不相等就直接返回
             * 如果key大于任何一个元素，则i的值是n，已经越界
             */
            if (i == _n || _keys[i].CompareTo(key) != 0)
            {
                return;
            }

            //将该索引位置之后的所有值都向前覆盖一位从而删除该元素
            for (var j = i + 1; j <= _n - 1; j++)
            {
                _keys[j - 1] = _keys[j];
            }

            _n--;
            _keys[_n] = default;

            if (_n == _keys.Length / 4)
            {
                ResetCapacity(_keys.Length / 2);
            }
        }

        public Key Min()
        {
            return _keys[0];
        }

        public Key Max()
        {
            return _keys[_n - 1];
        }

        public Key Select(int k)
        {
            if (k < 0 || k > _n - 1)
            {
                throw new ArgumentException("索引越界");
            }

            return _keys[k];
        }

        public bool Contains(Key key)
        {
            var i = Rank(key);

            return i < _n && _keys[i].CompareTo(key) == 0;
        }


        /// <summary>
        /// 找出小于或等于key的最大键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Key Floor(Key key)
        {
            var i = Rank(key);

            //如果查找到了等于key的值就直接返回i索引的值,i < _n是为了防止keys[i]越界
            if (i < _n && _keys[i].CompareTo(key) == 0)
            {
                return _keys[i];
            }

            //如果该值小于keys中的所有元素，i的值就会为0，查找失败
            if (i == 0)
            {
                throw new ArgumentException($"没有找到小于或等于{key.ToString()}的最大值");
            }

            //如果keys中没有等于该值的元素，就返回i索引的前一个元素
            return _keys[i - 1];
        }

        /// <summary>
        /// 查找大于或等于key的最小元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Key Ceiling(Key key)
        {
            var i = Rank(key);

            //如果key大于所有元素，i的值就会为_n，查找失败
            if (i == _n)
            {
                throw new ArgumentException($"没有找到大于或等于{key.ToString()}的最小值");
            }

            return _keys[i];
        }

        private void ResetCapacity(int capacity)
        {
            var newKey = new Key[capacity];

            for (var i = 0; i < _n; i++)
            {
                newKey[i] = _keys[i];
            }

            _keys = newKey;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Array1: Count:{_n} Capacity:{_keys.Length}\n");
            stringBuilder.Append('[');
            for (var i = 0; i < _n; i++)
            {
                stringBuilder.Append(_keys[i]);
                if (i != _n - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.Append(']').ToString();
        }
    }
}