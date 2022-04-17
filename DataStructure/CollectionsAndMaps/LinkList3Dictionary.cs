using DataStructure.TheLinkList;

namespace DataStructure.CollectionsAndMaps
{
    public class LinkList3Dictionary<Key,Value>: IDictionary<Key,Value>
    {
        private LinkList3<Key, Value> _list3;

        public LinkList3Dictionary()
        {
            _list3 = new LinkList3<Key, Value>();
        }

        public void Add(Key key, Value value)
        {
            _list3.Add(key,value);
        }

        public void Remove(Key key)
        {
            _list3.Remove(key);
        }

        public bool ContainsKey(Key key)
        {
            return _list3.Contains(key);
        }

        public Value Get(Key key)
        {
            return _list3.Get(key);
        }

        public void Set(Key key, Value value)
        {
            _list3.Set(key, value);
        }

        public int Count => _list3.Count;
        public bool IsEmpty => _list3.ISEmpty;
    }
}