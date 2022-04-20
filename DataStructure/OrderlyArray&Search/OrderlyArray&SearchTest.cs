using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.OrderlyArray_Search
{
    public class OrderlyArray_SearchTest
    {
        public static void Main(string[] args)
        {
            TestSortedArray2Dictionary();
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
            var sum2 = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                var target = arr2[i];
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

        private static void TestSortedArray1()
        {
            int[] arr = {84, 48, 68, 10, 18, 98, 12, 23, 54, 57, 33, 16, 77, 11, 29};

            var sortedArray1 = new SortedArray1<int>();
            foreach (var a in arr)
            {
                sortedArray1.Add(a);
            }

            Console.WriteLine(sortedArray1);
            Console.WriteLine(sortedArray1.Min());
            Console.WriteLine(sortedArray1.Max());
            Console.WriteLine(sortedArray1.Select(5));
            Console.WriteLine(sortedArray1.Ceiling(15));
            Console.WriteLine(sortedArray1.Floor(15));
            sortedArray1.Remove(23);
            Console.WriteLine(sortedArray1);

            var sortedStudent = new SortedArray1<Student>();
            Student[] students =
            {
                new Student("小明", 177),
                new Student("小红", 158),
                new Student("小芳", 163),
                new Student("小强", 188),
                new Student("小美", 165),
            };

            foreach (var student in students)
            {
                sortedStudent.Add(student);
            }

            Console.WriteLine(sortedStudent);
        }

        private static void TestSortedArray1List()
        {
            Console.WriteLine("双城记");

            var words=TestHelper.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数："+words.Count);

            Console.WriteLine();

            Console.WriteLine("链表集合");
            var linkedList1Set = new LinkList1Set<string>();
            var t1=TestSet(linkedList1Set, words);
            Console.WriteLine("不同单词的总数： "+linkedList1Set.Count);
            Console.WriteLine("运行时间： "+t1+"ms");

            Console.WriteLine();

            /*
             * 有序数组集合的Add、Remove操作都需要移动所有元素的位置，导致时间复杂度为O(n)
             * 而Contains操作使用的是二分查找，所以时间复杂度是O(log2n)
             */
            Console.WriteLine("有序数组集合");
            var sortedArray1Set = new SortedArray1Set<string>();
            var t2 = TestSet(sortedArray1Set, words);
            Console.WriteLine("不同单词的总数： " + sortedArray1Set.Count);
            Console.WriteLine("运行时间： " + t2 + "ms");
        }

        private static void TestSortedArray2Dictionary()
        {
            Console.WriteLine("双城记");

            var words=TestHelper.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数："+words.Count);

            Console.WriteLine();

            Console.WriteLine("链表字典");
            var dic1 = new LinkList3Dictionary<string, int>();
            var t1= TestDictionary(dic1, words);
            Console.WriteLine("不同的单词总数： " + dic1.Count);
            Console.WriteLine("city出现的频次： " + dic1.Get("city"));
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("有序数组字典");
            var dic2 = new SortedArray2Dictionary<string, int>();
            var t2 = TestDictionary(dic2, words);
            Console.WriteLine("不同的单词总数： " + dic2.Count);
            Console.WriteLine("city出现的频次： " + dic2.Get("city"));
            Console.WriteLine("运行时间： " + t2 + "ms");
        }
        
        /// <summary>
        /// 测试将元素添加到有序数组集合中花费的时间
        /// </summary>
        /// <param name="set"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static long TestSet(CollectionsAndMaps.ISet<string> set,List<string> words)
        {
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
                set.Add(word);
            t.Stop();
            return t.ElapsedMilliseconds;
        }
        
        /// <summary>
        /// 测试将元素添加到有序数组字典中花费的时间
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static long TestDictionary(CollectionsAndMaps.IDictionary<string,int> dic,List<string> words)
        {
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                //如果单词不存在字典中，说明是第一次遇见这个单词，频次设为1
                if (!dic.ContainsKey(word))
                    dic.Add(word, 1);
                else  //如果单词已经存在在字典中，将单词对应的频次+1
                    dic.Set(word, dic.Get(word) + 1);
            }
            t.Stop();
            return t.ElapsedMilliseconds;
        }
    }
}