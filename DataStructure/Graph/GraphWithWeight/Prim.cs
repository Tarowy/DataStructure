using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.GraphWithWeight
{
    public class Prim
    {
        private IGraph _graph;
        private MyList<Edge> _minimumSpanningTreeList; //储存最小生成树的边集
        private bool[] _colors;

        public Prim(IGraph graph)
        {
            _graph = graph;
            _minimumSpanningTreeList = new MyList<Edge>();
            _colors = new bool[_graph.V()];

            //如果传进来的图有多个连通分量则无法形成最小生成树
            var dfsGraph = new DFSGraph(graph);
            if (dfsGraph.Components > 1)
            {
                return;
            }

            _colors[0] = true;
            //选择V-1条边即可构成最小生成树
            for (var i = 0; i < _graph.V() - 1; i++)
            {
                var minEdge = new Edge(-1, -1, int.MaxValue);
                
                //依次遍历每个已经被选择过的节点，找出与已选择节点相连接的最小的边
                for (var j = 0; j < _graph.V(); j++)
                {
                    if (!_colors[j]) continue;

                    foreach (var adj in _graph.GetAdj(j))
                    {
                        /*
                         * 如果与该节点相连的边没有被选择过，且权值小于上一次已经选择了的权值最小的边，
                         * 那么就将此边选择出来
                         */
                        if (!_colors[adj] && ((AdjDictionary) _graph).Weight(j, adj) < minEdge.GetW())
                        {
                            minEdge = new Edge(j, adj, ((AdjDictionary) _graph).Weight(j, adj));
                        }
                    }
                }

                //选择出边后，将边的两个节点都染上同样的颜色
                _minimumSpanningTreeList.Add(minEdge);
                _colors[minEdge.GetA()] = _colors[minEdge.GetB()] = true;
            }
        }

        public MyList<Edge> GetList() => _minimumSpanningTreeList;
    }
}