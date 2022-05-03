using DataStructure.TheLinkList;

namespace DataStructure.CollectionsAndMaps
{
    public class LinkList1Set<E>: ISet<E>
    {
        private LinkList3<E> _list3;

        public LinkList1Set()
        {
            _list3 = new LinkList3<E>();
        }

        public int Count => _list3.Count;
        public bool IsEmpty => _list3.IsEmpty;
        
        public void Add(E e)
        {
            if (!_list3.Contains(e))
            {
                _list3.AddLast(e);
            }
        }

        public void Remove(E e)
        {
            _list3.Remove(e);
        }

        public bool Contains(E e)
        {
            return _list3.Contains(e);
        }
    }
}