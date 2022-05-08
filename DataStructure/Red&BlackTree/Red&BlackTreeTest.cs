using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructure.BinaryTree;
using DataStructure.CollectionsAndMaps;

namespace DataStructure.Red_BlackTree
{
    public class Red_BlackTreeTest
    {
        // static void Main(string[] args)
        // {
        //     TestRBT2Dictionary();
        // }
        
        private static long TestSet(CollectionsAndMaps.ISet<string> set, List<string> words)
        {
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
                set.Add(word);
            t.Stop();
            return t.ElapsedMilliseconds;
        }

        private static void TestRBT1Set()
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
            
            /*
             * 由于普通二叉树本来就比较矮，虽然红黑树能把高度进一步压缩，
             * 但是压缩本身也有性能消耗，导致时间比不上普通的二叉树
             */
            Console.WriteLine("(基于红黑树实现)集合");
            var rbt1Set = new RBT1Set<string>();
            var t2 = TestSet(rbt1Set, words);
            Console.WriteLine("不同单词的总数： " + rbt1Set.Count);
            Console.WriteLine("运行时间： " + t2 + "ms");
            Console.WriteLine("树的最大高度： " + rbt1Set.MaxHeight());


            // var t = new Stopwatch();
            // t.Start();
            // var set = new RBT1Set<int>();
            // for (var i = 0; i < 10000000; i++)
            //     set.Add(i);
            // t.Stop();
            // Console.WriteLine("运行时间： " + t.ElapsedMilliseconds + "ms");
            // Console.WriteLine("树的最大高度： " + set.MaxHeight());


            // Console.WriteLine("C#自带的红黑树集合");
            // var set = new SortedSet<int>();
        }
        
        public static long TestDictionary(CollectionsAndMaps.IDictionary<string, int> dic, List<string> words)
        {
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                //如果单词不存在字典中，说明是第一次遇见这个单词，频次设为1
                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, 1);
                }
                else //如果单词已经存在在字典中，将单词对应的频次+1
                {
                    dic.Set(word, dic.Get(word) + 1);
                }
            }
            t.Stop();
            return t.ElapsedMilliseconds;
        }

        public static void TestRBT2Dictionary()
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

            Console.WriteLine("（基于红黑树实现）字典");
            var dic2 = new RBT2Dictionary<string, int>();
            var t2 = TestDictionary(dic2, words);
            Console.WriteLine("不同的单词总数： " + dic2.Count);
            Console.WriteLine("city出现的频次： " + dic2.Get("city"));
            Console.WriteLine("运行时间： " + t2 + "ms");
            
            // Console.WriteLine("C#中自带的红黑树字典");
            // var dic = new SortedDictionary<string, int>();
        }
    }
}