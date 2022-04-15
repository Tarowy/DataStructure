namespace DataStructure.StackAndQueue
{
    public interface IStack<E>
    {
        public bool IsEmpty { get; }
        public int Count { get; }
        public void Push(E e);
        public E Pop();
        public E Peek();
    }
}