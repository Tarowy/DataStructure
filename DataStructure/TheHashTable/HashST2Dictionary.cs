using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.TheHashTable
{
    public class HashST2Dictionary<Key,Value> : IDictionary<Key,Value> where Key : IComparable<Key>
    {
        private HashST2<Key, Value> _hashSt2;

        public HashST2Dictionary(int M)
        {
            _hashSt2 = new HashST2<Key, Value>(M);
        }

        public HashST2Dictionary()
        {
            _hashSt2 = new HashST2<Key, Value>();
        }

        public void Add(Key key, Value value)
        {
            _hashSt2.Add(key, value);
        }

        public void Remove(Key key)
        {
            _hashSt2.Remove(key);
        }

        public bool ContainsKey(Key key)
        {
            return _hashSt2.Contains(key);
        }

        public Value Get(Key key)
        {
            return _hashSt2.Get(key);
        }

        public void Set(Key key, Value value)
        {
            _hashSt2.Set(key, value);
        }

        public int Count => _hashSt2.Count;
        public bool IsEmpty => _hashSt2.IsEmpty;
    }
}