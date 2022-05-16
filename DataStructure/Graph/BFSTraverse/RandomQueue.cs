using System;
using System.Collections.Generic;

namespace DataStructure.Graph.BFSTraverse
{
    /// <summary>
    ///    随机队列，取数的时候会随机返回一个元素
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class RandomQueue<E>
    {
        private List<E> queue;
        private Random _r = new Random();

        public RandomQueue()
        {
            queue = new List<E>();
        }

        public void Enqueue(E e)
        {
            queue.Add(e);
        }

        public E Dequeue()
        {
            //随机索引randIndex 
            var randIndex = (int)(_r.NextDouble() * queue.Count);

            //取出随机索引元素e
            var e = queue[randIndex];

            //最后一个元素,覆盖代替元素e
            queue[randIndex] = queue[^1];

            //删掉最后一个元素
            queue.RemoveAt(queue.Count - 1);

            //返回元素e
            return e;
        }

        public int Count => queue.Count;
        public bool IsEmpty => Count == 0;
    }
}