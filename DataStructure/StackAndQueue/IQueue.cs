namespace DataStructure.StackAndQueue
{
    public interface IQueue<E>
    {
        public bool IsEmpty { get; }
        public int Count { get; }
        public void EnQueue(E e);
        public E DeQueue();
        public E Peek();
    }
}