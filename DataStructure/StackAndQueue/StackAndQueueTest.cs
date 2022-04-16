using System;
using System.Diagnostics;

namespace DataStructure.StackAndQueue
{
    public class StackAndQueueTest
    {
        // public static void Main(string[] args)
        // {
        // }

        public static void TestSelfStack()
        {
            var stack1 = new LinkListStack<int>();
            for (var i = 0; i < 5; i++)
            {
                stack1.Push(i);
                Console.WriteLine(stack1);
            }

            stack1.Pop();
            Console.WriteLine(stack1);

            #region 测试普通数组栈和普通单链表栈的效率

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

            #endregion
        }

        public static long TestStack(IStack<int> stack, int N)
        {
            var stopwatch = new Stopwatch();
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

            #region 测试普通数组队列和循环数组队列的效率

            var n = 200000;

            var array1Queue = new Array1Queue<int>();
            Console.WriteLine(TestQueue(array1Queue, n));

            var array2Queue = new Array2Queue<int>();
            Console.WriteLine(TestQueue(array2Queue, n));

            #endregion

            #region 测试普通单链表队列和带首尾指针的单链表队列的效率

            var n1 = 200000;

            LinkList1Queue<int> list1Queue = new LinkList1Queue<int>();
            Console.WriteLine("Linklist1Queue: " + TestQueue(list1Queue, n1) + "ms");

            LinkList2Queue<int> list2Queue = new LinkList2Queue<int>();
            Console.WriteLine("Linklist2Queue: " + TestQueue(list2Queue, n1) + "ms");

            #endregion
        }

        public static long TestQueue(IQueue<int> queue, int N)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < N; i++)
            {
                /*
                 * 普通单链表添加一个元素需要从头遍历到尾才能添加，时间复杂度O(n)，循环n次则是O(n^2)
                 * 而带首尾指针的单链表只需要移动tail指针就行了
                 */
                queue.EnQueue(i);
            }

            
            for (int i = 0; i < N; i++)
            { 
                /*
                 * 普通动态数组向头部添加一个元素会导致所有元素向后移动一位，时间复杂度O(n)，循环n次时间复杂度为O(n^2)
                 * 而循环数组只需要移动first指针
                 */
                queue.DeQueue();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}