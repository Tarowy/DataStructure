using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.BinaryTree
{
    public class BST2Dictionary<Key,Value> : IDictionary<Key,Value> where Key : IComparable<Key>
    {
        private BST2<Key, Value> _bst2;

        public BST2Dictionary()
        {
            _bst2 = new BST2<Key, Value>();
        }

        public void Add(Key key, Value value)
        {
            _bst2.Add(key, value);
        }

        public void Remove(Key key)
        {
            _bst2.Remove(key);
        }

        public bool ContainsKey(Key key)
        {
            return _bst2.Contains(key);
        }

        public Value Get(Key key)
        {
            return _bst2.Get(key);
        }

        public void Set(Key key, Value value)
        {
            _bst2.Set(key, value);
        }

        public int Count => _bst2.Count;
        public bool IsEmpty => _bst2.IsEmpty;
    }
}