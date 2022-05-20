using System;
using System.Diagnostics;

namespace DataStructure.Graph.DisjointSet
{
    public class DisjointSetTest
    {
        public static void Main(string[] args)
        {
            var size = 100000;
            var m = 100000;
            var unionFind1 = new UnionFind1(size);
            Console.WriteLine($"unionFind1: {TestIUF(unionFind1,m)}ms");

            var unionFind2 = new UnionFind2(size);
            Console.WriteLine($"unionFind2: {TestIUF(unionFind2, m)}ms");
        }

        private static long TestIUF(IUF uf, int m)
        {
            var size = uf.GetSize();
            var random = new Random();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //随机产生两个数，让这两个数相合并到一个集合中去
            for (var i = 0; i < m; i++)
            {
                var a = random.Next(size);
                var b = random.Next(size);

                uf.Union(a, b);
            }

            //测试随机两个数是否相连接，即是否属于同一个集合
            for (var i = 0; i < m; i++)
            {
                var a = random.Next(size);
                var b = random.Next(size);

                uf.IsConnected(a, b);
            }
            
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}