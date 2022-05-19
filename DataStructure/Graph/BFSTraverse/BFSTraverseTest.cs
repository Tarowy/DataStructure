using System;
using System.IO;
using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.BFSTraverse
{
    public class BFSTraverseTest
    {
        // public static void Main(string[] args)
        // {
        //     // TestBFSGraph();
        //     // TestBFSSingleSourcePath();
        //     // TestBFSBiPartitionDetection();
        //     // TestBFSCycleDetection();
        //     TestRandomGraph();
        // }

        private static void TestBFSGraph()
        {
            var bfsGraph =
                new BFSGraph(new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的广度优先遍历\g.txt"));
            Console.WriteLine(bfsGraph);
        }

        private static void TestBFSSingleSourcePath()
        {
            var bfsSingleSourcePath = new BFSSingleSourcePath(
                new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的广度优先遍历\g.txt"), 0);
            Console.WriteLine("BFS 0->6: " + bfsSingleSourcePath.GetSingleSourcePath(6));
            Console.WriteLine("BFS 0->4: " + bfsSingleSourcePath.GetSingleSourcePath(4));
            Console.WriteLine("到达5的最短路径的距离: " + bfsSingleSourcePath.GetDistance(5));
        }

        private static void TestBFSBiPartitionDetection()
        {
            var bfsBiPartitionDetection =
                new BFSBiPartitionDetection(
                    new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的二分检测\g2.txt"));
            Console.WriteLine("是否是二分图: " + bfsBiPartitionDetection.IsPartitionGraph());
        }

        private static void TestBFSCycleDetection()
        {
            var bfsCycleDetection =
                new BFSCycleDetection(new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的环检测\g.txt"));
            Console.WriteLine("是否有环: " + bfsCycleDetection.HasCycle());
        }

        private static void TestRandomGraph()
        {
            Console.Write("深度优先遍历: \n");
            DFStraverseTest.TestDFS();
            Console.Write("广度优先遍历: \n");
            TestBFSGraph();
            Console.Write("随机队列遍历: \n");
            var randomGraph =
                new RandomGraph(new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的广度优先遍历\g.txt"));
            Console.WriteLine(randomGraph);
        }
    }
}