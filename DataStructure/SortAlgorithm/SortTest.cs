using System;
using System.IO;
using DataStructure.CollectionsAndMaps;
using DataStructure.OrderlyArray_Search;
using DataStructure.PriorityQueue_HeapSort;

namespace DataStructure.SortAlgorithm
{
    public class SortTest
    {
        // public static void Main(string[] args)
        // {
        //     OuterSort();
        // }

        #region 测试冒泡、选择排序

        private static void TestSomeSort()
        {
            int[] a = {4, 3, 5, 2, 1, 0};
            char[] a2 = {'C', 'A', 'D', 'B', 'G', 'F', 'E'};
            float[] a3 = {0.21f, 0.10f, 0.78f, 0.15f, 0.17f};

            Date[] dates =
            {
                new(2020, 7, 7, "七夕节"),
                new(2020, 8, 15, "中秋节"),
                new(2020, 1, 1, "元旦节"),
                new(2020, 3, 8, "妇女节"),
                new(2020, 4, 4, "清明节"),
                new(2020, 5, 1, "劳动节"),
                new(2020, 9, 10, "教师节"),
                new(2020, 1, 25, "春节"),
                new(2020, 2, 14, "情人节"),
                new(2020, 10, 1, "国庆节"),
                new(2020, 12, 25, "圣诞节"),
                new(2020, 6, 1, "儿童节")
            };

            // Sorting.BubbleSort(dates);
            Sorting.SelectSort(dates);

            foreach (var t in dates)
                Console.WriteLine(t);
        }

        #endregion

        #region 测试插入、归并排序

        private static void TestSomeSort2()
        {
            //数组规模大小
            var n = 1000000;

            //随机数组a [0...N]
            var a=TestHelperSort.RandomArray(n, n);
            //插入排序对近乎有序的数组排序非常快，这种数量级都只需要 31ms左右
            // var a = TestHelperSort.NearlyOrderedArray(n, 100);

            //将a数组的数据复制到b数组中
            var b = TestHelperSort.CopyArray(a);

            //对同样的测试用例进行性能测试
            //提示：不要将类名打错否则将抛出异常
            //如果你的排序算法编写正确，排序成功，得到运行时间。
            //如果你的排序算法编写错误 IsSorted 将会检测排序失败。
            
            //最简单粗暴的排序
            // TestHelperSort.TestSort("BubbleSort", a);
            
            //
            // TestHelperSort.TestSort("SelectSort", a);
            
            //对于近乎有序的数组排序非常快
            // TestHelperSort.TestSort("InsertSort", a);
            
            // TestHelperSort.TestSort("MergeSort", a);
            
            //优化过的归并排序
            // TestHelperSort.TestSort("MergeSort2", a);


            // TestHelperSort.TestSort("QuickSort1", a);
            // TestHelperSort.TestSort("QuickSort2", b);
            // TestHelperSort.TestSort("QuickSort3", a);
        }

        #endregion

        #region 测试快速、归并、堆排序

        private static void TestMostSort()
        {
            var N = 10000000;

            Console.WriteLine("测试随机数组： ");
            var a = TestHelperSort.RandomArray(N, N);
            var b = TestHelperSort.CopyArray(a);
            var c = TestHelperSort.CopyArray(a);
            var d = TestHelperSort.CopyArray(a);
            var e = TestHelperSort.CopyArray(a);
            var f = TestHelperSort.CopyArray(a);
            TestHelperSort.TestSort("QuickSort1", a); //快速排序
            TestHelperSort.TestSort("QuickSort2", b); //随机化快速排序
            TestHelperSort.TestSort("QuickSort3", c); //三向切片随机化快速排序
            TestHelperSort.TestSort("MergeSort2", d); //优化后的归并排序
            TestHelperSort.TestSort("HeapSort1", e); //堆排序
            TestHelperSort.TestSort("HeapSort2", f); //原地堆排序
            Console.WriteLine();

            Console.WriteLine("测试近乎有序数组： ");
            a = TestHelperSort.NearlyOrderedArray(N, 100);
            b = TestHelperSort.CopyArray(a);
            c = TestHelperSort.CopyArray(a);
            e = TestHelperSort.CopyArray(a);
            f = TestHelperSort.CopyArray(a);
            // TestHelperSort.TestSort("QuickSort2", a); //极其耗费时间
            TestHelperSort.TestSort("QuickSort3", b);
            TestHelperSort.TestSort("MergeSort2", c);
            TestHelperSort.TestSort("HeapSort1", e);
            TestHelperSort.TestSort("HeapSort2", f);
            Console.WriteLine();

            Console.WriteLine("测试大量重复元素数组： ");
            a = TestHelperSort.RandomArray(N, 10);
            b = TestHelperSort.CopyArray(a);
            e = TestHelperSort.CopyArray(a);
            f = TestHelperSort.CopyArray(a);
            TestHelperSort.TestSort("QuickSort3", a);
            TestHelperSort.TestSort("MergeSort2", b);
            TestHelperSort.TestSort("HeapSort1", e);
            TestHelperSort.TestSort("HeapSort2", f);
        }

        #endregion

        #region 测试外部排序

        private static void OuterSort()
        {
            //在100W个元素中，找出最小的前十个元素。（Top M）
                //第一种：排序算法
                var a = Search.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件3\TopM.txt");
                Sorting.QuickSort3(a);
                for (var i = 0; i < 10; i++)
                    Console.Write(a[i]+", ");

                Console.WriteLine();

                //第二种：优先队列
                var pq = new MaxPQ<int>(10);
                var fs = new FileStream(@"D:\C#\DataStructure\DataStructure\测试文件3\TopM.txt", FileMode.Open);
                var sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    var value = int.Parse(sr.ReadLine());
                    if (pq.Count < 10)
                        pq.EnQueue(value);
                    //如果新的value小于队列中最大的数就将最大的数出队
                    else if(value < pq.Peek())
                    {
                        pq.DeQueue();
                        pq.EnQueue(value);
                    }
                }
                Console.WriteLine(pq);

                //同理也可以使用最小优先队列。找出最大的前十个元素。
                //最小优先队列和最大优先队列都是C#中没有提供，但是却很实用的数据结构
        }

        #endregion
    }
}