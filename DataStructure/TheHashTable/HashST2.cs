using DataStructure.TheLinkList;

namespace DataStructure.TheHashTable
{
    /// <summary>
    ///     键值对哈希表
    /// </summary>
    public class HashST2<Key,Value>
    {
        private LinkList3<Key,Value>[] _linkList3;
        private int N;
        private int M;

        public HashST2(int M)
        {
            this.M = M;
            N = 0;
            _linkList3 = new LinkList3<Key,Value>[this.M];
            /*
             * 对数组初始化后只是开辟了一串内存空间，但每个数组本身还没有实例化
             * 需要再逐一进行实例化
             */
            for (var i = 0; i < this.M; i++)
            {
                _linkList3[i] = new LinkList3<Key,Value>();
            }
        }

        public HashST2() : this(97)
        {
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        private int Hash(Key key)
        {
            /*
             * Math.ABS()遇到特别小的数就会抛出异常，所以不能使用Math.ABS()
             * 由于有些类型获取哈希函数会是负数，而索引不能是负数，
             * 所以需要和0111 1111 ...按位与使符号位归0，得到绝对值
             */
            return ( key.GetHashCode() & 0x7fffffff )%M;
        }

        public void Add(Key key,Value value)
        {
            //key取余后找到对应索引的链表
            var list3 = _linkList3[Hash(key)];
            if (list3.Contains(key))
            {
                return;
            }

            list3.Add(key,value);
            N++;
        }

        public void Remove(Key key)
        {
            var list3 = _linkList3[Hash(key)];
            if (!list3.Contains(key)) return;
            list3.Remove(key);
            N--;
        }

        public bool Contains(Key key)
        {
            return _linkList3[Hash(key)].Contains(key);
        }

        public Value Get(Key key)
        {
            
            return _linkList3[Hash(key)].Get(key);
        }

        public void Set(Key key,Value value)
        {
            _linkList3[Hash(key)].Set(key, value);
        }
    }
}