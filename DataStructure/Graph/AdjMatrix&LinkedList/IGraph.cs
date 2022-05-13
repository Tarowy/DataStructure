using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public interface IGraph
    {
        int V();
        int E();
        bool HasEdge(int a,int b);
        int Degree(int a);
        IEnumerable<int> GetAdj(int a);
    }
}