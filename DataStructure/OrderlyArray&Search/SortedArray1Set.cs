using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.OrderlyArray_Search
{
    public class SortedArray1Set<Key>: ISet<Key> where Key: IComparable<Key>
    {
        private SortedArray1<Key> _sortedArray1;

        public int Count => _sortedArray1.Count;
        public bool IsEmpty => _sortedArray1.IsEmpty;

        public SortedArray1Set()
        {
            _sortedArray1 = new SortedArray1<Key>();
        }

        public void Add(Key e)
        {
            _sortedArray1.Add(e);
        }

        public void Remove(Key e)
        {
            _sortedArray1.Remove(e);
        }

        public bool Contains(Key e)
        {
            return _sortedArray1.Contains(e);
        }
    }
}