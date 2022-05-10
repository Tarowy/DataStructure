using System;

namespace DataStructure.PriorityQueue_HeapSort
{
    public class PriorityQueueHeapSortTest
    {
        // public static void Main(string[] args)
        // {
        //     TestHeap();
        // }

        private static void TestHeap()
        {
            /////////////////////////////////////////////////////////////////////////
            // 3      3          3              5               5            4     //
            //      /          /   \          /   \           /   \        /   \   //
            //     2          2     1        3     1         4     1      3     1  //
            //                              /               / \          /         // 
            //                             2               2   3        2          // 
            /////////////////////////////////////////////////////////////////////////

            var maxHeap = new MaxHeap<int>();
            int[] a = { 3, 2, 1, 5, 4 };
            foreach (var t in a)
            {
                maxHeap.Insert(t);
                Console.WriteLine(maxHeap);
            }

            maxHeap.RemoveMax();
            Console.WriteLine(maxHeap);
        }
    }
}