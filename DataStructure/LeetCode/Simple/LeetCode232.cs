using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  232. 用栈实现队列
///  https://leetcode.cn/problems/implement-queue-using-stacks/
/// </summary>
public class LeetCode232
{
    public class MyQueue
    {
        private readonly Stack<int> _stackIn;
        private readonly Stack<int> _stackOut;

        public MyQueue()
        {
            _stackIn = new Stack<int>();
            _stackOut = new Stack<int>();
        }

        public void Push(int x)
        {
            _stackIn.Push(x);
        }

        public int Pop()
        {
            if (_stackOut.Count == 0)
            {
                while (_stackIn.Count > 0)
                    _stackOut.Push(_stackIn.Pop());
            }

            return _stackOut.Pop();
        }

        public int Peek()
        {
            //不能直接Peek，需要Pop一下使stackIn的元素移动到stackOut中去
            var result = Pop();
            _stackOut.Push(result);
            return result;
        }

        public bool Empty()
        {
            return _stackIn.Count == 0 && _stackOut.Count == 0;
        }
    }
}