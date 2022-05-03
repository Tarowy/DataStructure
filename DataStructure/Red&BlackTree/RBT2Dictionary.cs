using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.Red_BlackTree
{
    public class RBT2Dictionary<Key,Value> : IDictionary<Key,Value> where Key : IComparable<Key>
    {
        private RBT2<Key, Value> _rbt2;

        public RBT2Dictionary()
        {
            _rbt2 = new RBT2<Key, Value>();
        }

        public void Add(Key key, Value value)
        {
            _rbt2.Add(key, value);
        }

        public void Remove(Key key)
        {
            Console.WriteLine("不会删除");
        }

        public bool ContainsKey(Key key)
        {
            return _rbt2.Contains(key);
        }

        public Value Get(Key key)
        {
            return _rbt2.Get(key);
        }

        public void Set(Key key, Value value)
        {
            _rbt2.Set(key, value);
        }

        public int Count => _rbt2.Count;
        public bool IsEmpty => _rbt2.IsEmpty;
    }
}