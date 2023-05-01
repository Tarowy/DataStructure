using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  225. 用队列实现栈
///  https://leetcode.cn/problems/implement-stack-using-queues/
/// </summary>
public class LeetCode225
{
    public class MyStack
    {
        private readonly Queue<int> _que;

        public MyStack()
        {
            _que = new Queue<int>();
        }

        public void Push(int x)
        {
            /*
             * 每加进来一个元素，都将所有元素移动位置
             * 使加进来的元素位于第一位
             */
            _que.Enqueue(x);
            int size = _que.Count;
            size--;
            while (size-- > 0)
                _que.Enqueue(_que.Dequeue());
        }

        public int Pop()
        {
            return _que.Dequeue();
        }

        public int Top()
        {
            return _que.Peek();
        }

        public bool Empty()
        {
            return _que.Count == 0;
        }
    }
}