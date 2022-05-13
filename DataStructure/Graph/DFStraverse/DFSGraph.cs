using System.Collections.Generic;

namespace DataStructure.Graph.DFStraverse
{
    /// <summary>
    ///     深度优先遍历
    /// </summary>
    public class DFSGraph
    {
        private IGraph _graph;
        private bool[] _visited;
        private MyList<int> _traverseList;

        public DFSGraph(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _traverseList = new MyList<int>();
            /*
             * 孤立节点度为0，直接进行DFS会导致访问不到这个节点，
             * 需要再依次判断每个节点是否被访问过
             */
            for (var i = 0; i < _graph.V(); i++)
            {
                if (!_visited[i])
                {
                    DFS(i);
                    Components++;
                }
            }
        }

        //连通分量，表示有几个分散的图
        public int Components { get; private set; }

        /// <summary>
        ///     递归进行深度优先遍历
        /// </summary>
        /// <param name="v">遍历开始的节点</param>
        private void DFS(int v)
        {
            _traverseList.Add(v);
            _visited[v] = true; //v节点已遍历

            //获取与V连接的节点，再对这些节点进行深度遍历
            foreach (var i in _graph.GetAdj(v))
            {
                if (!_visited[i])
                {
                    DFS(i);
                }
            }
        }

        public List<int> GetTraverseList() => _traverseList;

        public override string ToString()
        {
            return $"连通分量：{Components}\n{_traverseList}";
        }
    }
}