using System;
using System.Diagnostics;

namespace DataStructure.StackAndQueue
{
    public class StackAndQueueTest
    {
        public static void Main(string[] args)
        {
            var n = 200000;

            var array1Queue = new Array1Queue<int>();
            Console.WriteLine(TestQueue(array1Queue, n));

            var array2Queue = new Array2Queue<int>();
            Console.WriteLine(TestQueue(array2Queue, n));
        }

        public static void TestSelfStack()
        {
            var stack1 = new LinkListStack<int>();
            for (int i = 0; i < 5; i++)
            {
                stack1.Push(i);
                Console.WriteLine(stack1);
            }

            stack1.Pop();
            Console.WriteLine(stack1);

            var n = 10000000;
            /*
             * 数组栈在内存中是顺序访问的，C#对顺序访问有优化，所以对于出入栈的操作速度非常快
             * 主要损耗在于扩容，但要是能提前指定合适的容量，忽略扩容操作能进一步提升效率
             * 官方的Stack就是使用动态数组实现的栈
             */
            var arrayStack = new ArrayStack1<int>();
            Console.WriteLine("arrayStack: " + TestStack(arrayStack, n) + "ms");

            var linkListStack = new LinkListStack<int>();
            /*
             * 链表栈在内存中不是顺序访问，每增加一个新的节点就要在堆内存中寻找空间，
             * 并且每个节点还要储存下一个节点的地址，导致性能损耗很大，远不如数组栈
             */
            Console.WriteLine("LinkListStack: " + TestStack(linkListStack, n) + "ms");
        }

        public static long TestStack(IStack<int> stack, int N)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < N; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < N; i++)
            {
                stack.Pop();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void TestSelfQueue()
        {
            var arrayQueue = new Array2Queue<int>();
            for (var i = 0; i < 12; i++)
            {
                arrayQueue.EnQueue(i);
                Console.WriteLine(arrayQueue);
            }

            for (int i = 0; i < 8; i++)
            {
                arrayQueue.DeQueue();
                Console.WriteLine(arrayQueue);
            }

            Console.WriteLine(arrayQueue);
        }

        public static long TestQueue(IQueue<int> queue, int N)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < N; i++)
            {
                queue.EnQueue(i);
            }

            /*
             * 普通动态数组：向头部添加一个元素会导致所有元素向后移动一位，时间复杂度O(n)，
             * 而且又执行n次循环导致时间复杂度变为O(n^2)
             */
            for (int i = 0; i < N; i++)
            {
                queue.DeQueue();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}