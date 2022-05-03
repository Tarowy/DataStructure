using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructure.CollectionsAndMaps;
using DataStructure.Red_BlackTree;

namespace DataStructure.TheHashTable
{
    public class TheHashTableTest
    {
        static void Main(string[] args)
        {
            TestHashDictionary();
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

        private static void TestHashSet()
        {
            Console.WriteLine("双城记");

            var words = TestHelper.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数：" + words.Count);

            Console.WriteLine();

            Console.WriteLine("(基于红黑树实现)集合");
            var rbt1Set = new RBT1Set<string>();
            var t1 = TestSet(rbt1Set, words);
            Console.WriteLine("不同单词的总数： " + rbt1Set.Count);
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("(基于哈希表实现)集合");
            var hashST1Set = new HashST1Set<string>(997);
            var t2 = TestSet(hashST1Set, words);
            Console.WriteLine("不同单词的总数： " + hashST1Set.Count);
            Console.WriteLine("运行时间： " + t2 + "ms");

            Console.WriteLine();

            Console.WriteLine("C#自带的集合");
            var set = new HashSet<string>();
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
                set.Add(word);
            t.Stop();
            Console.WriteLine("不同单词的总数： " + set.Count);
            Console.WriteLine("运行时间： " + t.ElapsedMilliseconds + "ms");
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

        private static void TestHashDictionary()
        {
            Console.WriteLine("双城记");

            var words = TestHelper.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
            Console.WriteLine("词汇量总数：" + words.Count);

            Console.WriteLine();

            Console.WriteLine("（基于红黑树实现）字典");
            var dic1 = new RBT2Dictionary<string, int>();
            var t1 = TestDictionary(dic1, words);
            Console.WriteLine("不同的单词总数： " + dic1.Count);
            Console.WriteLine("city出现的频次： " + dic1.Get("city"));
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("（基于哈希表实现）字典");
            var dic2 = new HashST2Dictionary<string, int>(997);
            var t2 = TestDictionary(dic2, words);
            Console.WriteLine("不同的单词总数： " + dic2.Count);
            Console.WriteLine("city出现的频次： " + dic2.Get("city"));
            Console.WriteLine("运行时间： " + t2 + "ms");

            Console.WriteLine();

            Console.WriteLine("C#自带基于哈希表字典");
            var dic = new Dictionary<string, int>(997);
            var t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                if (!dic.ContainsKey(word))
                    dic.Add(word, 1);
                else
                    //dic.Set(word, dic.Get(word) + 1);
                    dic[word]++; //C#自带的哈希字典可以直接数组形式访问
            }
            t.Stop();
            Console.WriteLine("不同的单词总数： " + dic.Count);
            Console.WriteLine("city出现的频次： " + dic["city"]);
            Console.WriteLine("运行时间： " + t.ElapsedMilliseconds + "ms");
        }
    }
}