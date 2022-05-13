using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;

namespace DataStructure.Graph
{
    public class AdjMatrix_LinkedList
    {
        // public static void Main(string[] args)
        // {
        //     TestAdjMatrix();
        //     TestAdjLinkedList();
        // }

        private static void TestAdjMatrix()
        {
            var adjMatrix = new AdjMatrix($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的存储\g.txt");
            Console.WriteLine(adjMatrix.ToString());

            Console.WriteLine("V: " + adjMatrix.V());
            Console.WriteLine("E: " + adjMatrix.E());
            Console.WriteLine("Degree: " + adjMatrix.Degree(0));
            Console.WriteLine("HasEdge: " + adjMatrix.HasEdge(0, 1));
            foreach (var i in adjMatrix.GetAdj(0))
            {
                Console.Write(i + " ");
            }
        }

        private static void TestAdjLinkedList()
        {
            var adjLinkedList = new AdjLinkedList($@"{Directory.GetCurrentDirectory()}\..\..\..\图\图的存储\g.txt");
            Console.WriteLine(adjLinkedList.ToString());

            Console.WriteLine("V: " + adjLinkedList.V());
            Console.WriteLine("E: " + adjLinkedList.E());
            Console.WriteLine("Degree: " + adjLinkedList.Degree(0));
            Console.WriteLine("HasEdge: " + adjLinkedList.HasEdge(0, 1));
            foreach (var i in adjLinkedList.GetAdj(0))
            {
                Console.Write(i + " ");
            }
        }
    }
}