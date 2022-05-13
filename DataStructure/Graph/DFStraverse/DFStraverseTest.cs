using System;
using System.IO;

namespace DataStructure.Graph.DFStraverse
{
    public class DFStraverseTest
    {
        public static void Main(string[] args)
        {
            IGraph graph = new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的深度优先遍历\g2.txt");
            Console.WriteLine(new DFSGraph(graph));
        }
    }
}