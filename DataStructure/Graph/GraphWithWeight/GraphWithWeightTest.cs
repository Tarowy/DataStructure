using System;
using System.IO;

namespace DataStructure.Graph.GraphWithWeight
{
    public class GraphWithWeightTest
    {
        public static void Main(string[] args)
        {
            // TestAdjDictionary();
            // TestKruskal();
            // TestPrim();
            TestDijkstra();
        }

        private static void TestAdjDictionary()
        {
            var adjDictionary = new AdjDictionary($@"{Directory.GetCurrentDirectory()}\..\..\..\图\带权图\g.txt");
            Console.WriteLine(adjDictionary.Degree(1));
            Console.WriteLine(adjDictionary.HasEdge(0,1));
            Console.WriteLine(adjDictionary.Weight(0, 1));
            Console.WriteLine(adjDictionary);
        }

        private static void TestKruskal()
        {
            var adjDictionary = new AdjDictionary($@"{Directory.GetCurrentDirectory()}\..\..\..\图\带权图\g.txt");
            var kruskal = new Kruskal(adjDictionary);
            Console.WriteLine(kruskal.GetList());
        }

        private static void TestPrim()
        {
            var adjDictionary = new AdjDictionary($@"{Directory.GetCurrentDirectory()}\..\..\..\图\带权图\g.txt");
            var prim = new Prim(adjDictionary);
            Console.WriteLine(prim.GetList());
        }
        
        private static void TestDijkstra()
        {
            var adjDictionary = new AdjDictionary($@"{Directory.GetCurrentDirectory()}\..\..\..\图\带权图最短路径\g.txt");
            var dijkstra = new Dijkstra(adjDictionary,0);
            for (var i = 0; i < adjDictionary.V(); i++)
            {
                Console.Write(dijkstra.DisTo(i)+" ");
            }
        }
    }
}