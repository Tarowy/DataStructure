using System;

namespace DataStructure.CollectionsAndMaps
{
    public interface ISet<E>
    {
        public int Count { get; }
        public bool IsEmpty { get; }
        public void Add(E e);
        public void Remove(E e);
        public bool Contains(E e);
    }
}