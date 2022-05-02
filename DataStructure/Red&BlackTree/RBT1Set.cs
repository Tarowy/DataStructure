using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.Red_BlackTree
{
    public class RBT1Set<E> : ISet<E> where E : IComparable<E>
    {
        private RBT1<E> _rbt1 = new RBT1<E>();

        public RBT1Set()
        {
            _rbt1 = new RBT1<E>();
        }

        public int Count => _rbt1.Count;
        public bool IsEmpty => _rbt1.IsEmpty;
        public void Add(E e)
        {
            _rbt1.Add(e);
        }

        public void Remove(E e)
        {
            Console.WriteLine("不会删除");
        }

        public bool Contains(E e)
        {
            return _rbt1.Contains(e);
        }

        public int MaxHeight()
        {
            return _rbt1.MaxHeight();
        }
    }
}