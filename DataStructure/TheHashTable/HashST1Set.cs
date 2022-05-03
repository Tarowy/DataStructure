using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.TheHashTable
{
    public class HashST1Set<Key>: ISet<Key> where Key : IComparable<Key>
    {
        private HashST1<Key> _hashSt1;

        public HashST1Set(int M)
        {
            _hashSt1 = new HashST1<Key>(M);
        }
        
        public HashST1Set()
        {
            _hashSt1 = new HashST1<Key>();
        }

        public int Count => _hashSt1.Count;
        public bool IsEmpty => _hashSt1.IsEmpty;
        public void Add(Key key)
        {
            _hashSt1.Add(key);
        }

        public void Remove(Key key)
        {
            _hashSt1.Remove(key);
        }

        public bool Contains(Key key)
        {
            return _hashSt1.Contains(key);
        }
    }
}