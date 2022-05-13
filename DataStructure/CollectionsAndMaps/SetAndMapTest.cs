using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DataStructure.CollectionsAndMaps
{
    public class SetAndMapTest
    {
        // public static void Main(string[] args)
        // {
        //     TestSet();
        // }

        public static void TestSet()
        {
            Stopwatch stopwatch = new Stopwatch();

            //加@可以就不需要\\转译了
            var words = TestHelperSort.ReadFile($@"{Directory.GetCurrentDirectory()}\..\..\..\测试文件1\双城记.txt");
            Console.WriteLine("单词总数：" + words.Count);

            var set = new LinkList1Set<string>();
            stopwatch.Start();
            foreach (var word in words)
            {
                set.Add(word);
            }

            stopwatch.Stop();

            Console.WriteLine("不同的单词个数：" + set.Count);
            Console.WriteLine("用时：" + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static void TestDictionary()
        {
            Stopwatch stopwatch = new Stopwatch();

            //加@可以就不需要\\转译了
            var words = TestHelperSort.ReadFile($@"{Directory.GetCurrentDirectory()}\..\..\..\测试文件1\双城记.txt");
            Console.WriteLine("单词总数：" + words.Count);

            var dic = new LinkList3Dictionary<string, int>();
            stopwatch.Start();
            foreach (var word in words)
            {
                //反复调用Get从头到尾遍历所有元素，所以十分耗费性能
                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, 1);
                }
                else
                {
                    dic.Set(word, dic.Get(word) + 1);
                }
            }

            stopwatch.Stop();

            Console.WriteLine("不同的单词个数：" + dic.Count);
            Console.WriteLine($"city的次频：{dic.Get("city")}");
            Console.WriteLine("用时：" + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}