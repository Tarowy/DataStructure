using DataStructure.TheLinkList;

namespace DataStructure.CollectionsAndMaps
{
    public class LinkList1Set<E>: ISet<E>
    {
        private LinkList1<E> _list1;

        public LinkList1Set()
        {
            _list1 = new LinkList1<E>();
        }

        public int Count => _list1.Count;
        public bool IsEmpty => _list1.IsEmpty;
        
        public void Add(E e)
        {
            if (!_list1.Contains(e))
            {
                _list1.AddLast(e);
            }
        }

        public void Remove(E e)
        {
            _list1.Remove(e);
        }

        public bool Contains(E e)
        {
            return _list1.Contains(e);
        }
    }
}