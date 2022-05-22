using System;
using System.Collections.Generic;
using DataStructure.Graph.DFStraverse;
using DataStructure.Graph.DisjointSet;

namespace DataStructure.Graph.GraphWithWeight
{
    public class Kruskal
    {
        private IGraph _graph;
        private MyList<Edge> _minimumSpanningTreeList; //储存最小生成树的边集

        public Kruskal(IGraph graph)
        {
            _graph = graph;
            _minimumSpanningTreeList = new MyList<Edge>();
            var edges = new MyList<Edge>();

            //如果传进来的图有多个连通分量则无法形成最小生成树
            var dfsGraph = new DFSGraph(graph);
            if (dfsGraph.Components > 1)
            {
                return;
            }

            //将所有边以及权重都储存到List中去
            for (var a = 0; a < _graph.V(); a++)
            {
                foreach (var b in _graph.GetAdj(a))
                {
                    //防止添加重复的边
                    if (a < b)
                    {
                        edges.Add(new Edge(a, b, ((AdjDictionary) _graph).Weight(a, b)));
                    }
                }
            }

            /*
             * 权重从小到大排列，依次从小到大选择边，
             * 使用并查集可以快速判断两个节点相连会不会构成环
             */
            edges.Sort();
            Console.WriteLine(edges);

            var unionFind2 = new UnionFind2(_graph.V());
            foreach (var edge in edges)
            {
                //如果a,b两个节点属于同一个集合，那么这两个节点相连必定会产生环
                if (!unionFind2.IsConnected(edge.GetA(), edge.GetB()))
                {
                    //每选择一条边就将对应的两个节点合并成一个集合
                    _minimumSpanningTreeList.Add(edge);
                    unionFind2.Union(edge.GetA(), edge.GetB());
                }
            }
        }

        public MyList<Edge> GetList() => _minimumSpanningTreeList;
    }
}