using System;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.BinaryTree
{
    public class BST1Set<E>: ISet<E> where E: IComparable<E>
    {
        private BST1<E> _bst1;

        public BST1Set()
        {
            _bst1 = new BST1<E>();
        }

        public int Count => _bst1.Count;
        public bool IsEmpty => _bst1.IsEmpty;
        
        public void Add(E e)
        {
            _bst1.Add(e);
        }

        public void Remove(E e)
        {
            _bst1.Remove(e);
        }

        public bool Contains(E e)
        {
            return _bst1.Contains(e);
        }

        public int MaxHeight()
        {
            return _bst1.MaxHeight();
        }
    }
}