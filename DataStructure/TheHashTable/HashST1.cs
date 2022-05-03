using System.Linq;
using DataStructure.TheLinkList;

namespace DataStructure.TheHashTable
{
    /// <summary>
    /// 哈希表，一串连续的链表数组，每个位置储存一个LinkList1(链表在LinkList1里面，它本身不是链表)
    ///         哈希表的性能与链表的长度有关，典型的空间换时间，只要数组长度足够长，也就是M参数是够大的素数，
    ///     就能增加数组长度，且缩短链表长度。但是哈希表的Hash操作会损失元素的有序性，如果注重元素的有序性，
    ///     还是使用红黑树更为合适。C#自带的哈希不能自己传入M，但它会根据储存的长度来改变M。
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class HashST1<Key>
    {
        private LinkList3<Key>[] _linkList1;
        private int N;
        private int M;

        public HashST1(int M)
        {
            this.M = M;
            N = 0;
            _linkList1 = new LinkList3<Key>[this.M];
            /*
             * 对数组初始化后只是开辟了一串内存空间，但每个数组本身还没有实例化
             * 需要再逐一进行实例化
             */
            for (var i = 0; i < this.M; i++)
            {
                _linkList1[i] = new LinkList3<Key>();
            }
        }

        public HashST1() : this(97)
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

        public void Add(Key key)
        {
            //key取余后找到对应索引的链表
            var list1 = _linkList1[Hash(key)];
            if (list1.Contains(key))
            {
                return;
            }

            list1.AddFirst(key);
            N++;
        }

        public void Remove(Key key)
        {
            var list1 = _linkList1[Hash(key)];
            if (!list1.Contains(key)) return;
            list1.Remove(key);
            N--;
        }

        public bool Contains(Key key)
        {
            return _linkList1[Hash(key)].Contains(key);
        }
    }
}