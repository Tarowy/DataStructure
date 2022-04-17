namespace DataStructure.CollectionsAndMaps
{
    public interface IDictionary<Key,Value>
    {
        public void Add(Key key, Value value);
        public void Remove(Key key);
        public bool ContainsKey(Key key);
        public Value Get(Key key);
        public void Set(Key key, Value value);
        public int Count { get; }
        public bool IsEmpty { get; }
    }
}