using System;
using System.IO;

namespace DataStructure.Graph.DFStraverse
{
    public class DFStraverseTest
    {
        // public static void Main(string[] args)
        // {
        //     // TestDFS();
        //     // TestSinglePath();
        //     // TestCycleDetection();
        //     // TestBiPartitionDetection();
        //     TestDFSGraphNR();
        // }

        public static void TestDFS()
        {
            IGraph graph = new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的深度优先遍历\g2.txt");
            Console.WriteLine(new DFSGraph(graph));
        }

        private static void TestSinglePath()
        {
            var singleSource =
                new DFSSingleSourcePath(
                    new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的深度优先遍历\g2.txt"), 0);
            Console.WriteLine(singleSource.GetSingleSourcePath(6));
            Console.WriteLine(singleSource.GetSingleSourcePath(5));
        }

        private static void TestCycleDetection()
        {
            var cycleDetection =
                new DFSCycleDetection(
                    new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的环检测\g.txt"));
            Console.WriteLine(cycleDetection.HasCycle());
        }

        private static void TestBiPartitionDetection()
        {
            var dfsBiPartitionDetection = new DFSBiPartitionDetection(
                new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的二分检测\g2.txt"));
            Console.WriteLine(dfsBiPartitionDetection.IsPartition());
        }

        private static void TestDFSGraphNR()
        {
            var dfsGraphNr =
                new DFSGraphNR(new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的深度优先遍历\g.txt"));
            Console.WriteLine(dfsGraphNr.ToString());
        }
    }
}