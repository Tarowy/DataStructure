using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructure.CollectionsAndMaps
{
    public class SetAndMapTest
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            //加@可以就不需要\\转译了
            var words = TestHelper.ReadFile(@"D:\C#\DataStructure\DataStructure\测试文件1\双城记.txt");
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
    }
}