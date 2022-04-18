using System;
using System.Diagnostics;
using System.Linq;

namespace DataStructure.OrderlyArray_Search
{
    public class OrderlyArray_SearchTest
    {
        public static void Main(string[] args)
        {
            TestBigSearch();
        }

        private static void TestSmallSearch()
        {
            const string filename1 = @"D:\C#\DataStructure\DataStructure\测试文件2\超市会员表.txt";
            const string filename2 = @"D:\C#\DataStructure\DataStructure\测试文件2\超市客户表.txt";

            var arr1 = Search.ReadFile(filename1);
            var arr2 = Search.ReadFile(filename2);
            Console.WriteLine("超市会员数量 :" + arr1.Length);
            Console.WriteLine("调查客户数量 :" + arr2.Length);

            Console.WriteLine();

            var t1 = new Stopwatch();
            var t2 = new Stopwatch();

            Console.WriteLine("顺序查找法");
            t1.Start();
            var sum1 = arr2.Count(target => Search.OrderSearch(arr1, target) == -1);   //记录普通客户数量
            t1.Stop();
            Console.WriteLine("查找到" + sum1 + "个普通客户");
            Console.WriteLine("运行时间: " + t1.ElapsedMilliseconds + "ms");

            Console.WriteLine();

            Console.WriteLine("二分查找法");
            t2.Start();
            Array.Sort(arr1); //调用C#自带的排序方法对数组进行排序，才可以使用二分查找法
            int sum2 = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                int target = arr2[i];
                if (Search.BinarySearch(arr1, target) == -1)
                {
                    // Console.WriteLine(target);
                    sum2++;
                }
            }
            t2.Stop();
            Console.WriteLine("查找到" + sum2 + "个普通客户");
            Console.WriteLine("运行时间: " + t2.ElapsedMilliseconds + "ms");
        }

        private static void TestBigSearch()
        {
            const string filename3 = @"D:\C#\DataStructure\DataStructure\测试文件2\游戏会员表.txt";
            const string filename4 = @"D:\C#\DataStructure\DataStructure\测试文件2\游戏用户表.txt";

            var arr3 = Search.ReadFile(filename3);
            var arr4 = Search.ReadFile(filename4);
            Console.WriteLine("游戏会员数量 :" + arr3.Length);
            Console.WriteLine("调查用户数量 :" + arr4.Length);

            Console.WriteLine();

            Stopwatch t3 = new Stopwatch();
            Stopwatch t4 = new Stopwatch();

            Console.WriteLine("顺序查找法");
            t3.Start();
            
            /*
             * 运行时间: 42624ms
             */
            var sum3 = arr4.Count(target => Search.OrderSearch(arr3, target) == -1);
            t3.Stop();
            Console.WriteLine("查找到 :" + sum3 + "个零充玩家");
            Console.WriteLine("运行时间: " + t3.ElapsedMilliseconds + "ms");

            Console.WriteLine();

            Console.WriteLine("二分查找法");
            t4.Start();
            Array.Sort(arr3);
            
            /*
             * 运行时间: 90ms
             */
            var sum4 = arr4.Count(target => Search.BinarySearch(arr3, target) == -1);
            t4.Stop();
            Console.WriteLine("查找到 :" + sum4 + "个零充玩家");
            Console.WriteLine("运行时间: " + t4.ElapsedMilliseconds + "ms");
        }
    }
}