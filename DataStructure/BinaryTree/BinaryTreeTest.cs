using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructure.CollectionsAndMaps;
using DataStructure.OrderlyArray_Search;

namespace DataStructure.BinaryTree
{
    public class BinaryTreeTest
    {
        // public static void Main(string[] args)
        // {
        //     TestBstDictionary();
        // }

        public static void TestBst()
        {
            int[] a = { 8, 4, 12, 2, 6, 10, 14 };

            ///////////////////////
            //         8         //
            //     /       \     //
            //    4        12    //
            //  /   \     /   \  //
            // 2     6   10   14 //
            ///////////////////////

            var bst = new BST1<int>();

            foreach (var t in a)
                bst.Add(t);
            
            // bst.PreOrder();
            // Console.WriteLine();
            // bst.InOrder();
            // Console.WriteLine();
            // bst.PostOrder();
            // Console.WriteLine();
            // bst.LevelOrder();

            // bst.RemoveMax();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.InOrder();
            // Console.WriteLine();
            // Console.WriteLine(bst.Min());
            // Console.WriteLine(bst.Max());

            // bst.Remove(10);
            // bst.Remove(8);
            // bst.InOrder();

            Console.WriteLine(bst.MaxHeight());
        }
        
        private static long TestSet(CollectionsAndMaps.ISet<string> set, List<string> words)
        {
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
                set.Add(word);
            t.Stop();
            return t.ElapsedMilliseconds;
        }
        

        private static void TestBstSet()
        {
            Console.WriteLine("双城记");

            var words = TestHelperSort.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数：" + words.Count);

            Console.WriteLine();

            Console.WriteLine("(基于二叉查找树实现)集合");
            var bst1Set = new BST1Set<string>();
            var t1 = TestSet(bst1Set, words);
            Console.WriteLine("不同单词的总数： " + bst1Set.Count);
            Console.WriteLine("运行时间： " + t1 + "ms");
            Console.WriteLine("树的最大高度： " + bst1Set.MaxHeight());

            Console.WriteLine();

            Console.WriteLine("(基于有序数组实现)集合");
            var sortedArray1Set = new SortedArray1Set<string>();
            var t2 = TestSet(sortedArray1Set, words);
            Console.WriteLine("不同单词的总数： " + sortedArray1Set.Count);
            Console.WriteLine("运行时间： " + t2 + "ms");

            //对于随机性非常强的测试用例，二叉树的性能非常的好，因为树的高度很矮
            //但是对于有序性非常强（顺序或逆序）的用例呢，二叉树的性能就会变得非常的差，显然是不能接受的
            //因为树的高度会非常的高。我们递归的添加呢，有可能会出现栈溢出的情况。

            // var r = new Random();
            // //r.Next() 会随机出[0,2147483647)的整型号
            // var t = new Stopwatch();
            // t.Start();
            // var set = new BST1Set<int>();
            // /*
            //  * 由于是递归添加数据，如果是升序添加过多数据
            //  * 就会导致树的深度过高而堆栈溢出
            //  */
            // for (var i = 0; i < 2000000; i++)
            //     set.Add(r.Next());
            // t.Stop();
            // Console.WriteLine("运行时间： " + t.ElapsedMilliseconds + "ms");
            // Console.WriteLine("树的最大高度： " + set.MaxHeight());
        }

        private static long TestDictionary(CollectionsAndMaps.IDictionary<string, int> dic, List<string> words)
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

        private static void TestBstDictionary()
        {
            Console.WriteLine("双城记");

            var words = TestHelperSort.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数：" + words.Count);

            Console.WriteLine();

            Console.WriteLine("（基于二叉查找树实现）字典");
            var dic1 = new BST2Dictionary<string, int>();
            var t1 = TestDictionary(dic1, words);
            Console.WriteLine("不同的单词总数： " + dic1.Count);
            Console.WriteLine("city出现的频次： " + dic1.Get("city"));
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("（基于有序数组实现）字典");
            var dic2 = new SortedArray2Dictionary<string, int>();
            var t2 = TestDictionary(dic2, words);
            Console.WriteLine("不同的单词总数： " + dic2.Count);
            Console.WriteLine("city出现的频次： " + dic2.Get("city"));
            Console.WriteLine("运行时间： " + t2 + "ms");
        }
    }
}