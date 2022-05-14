using System;

namespace DataStructure.Graph.DFStraverse
{
    /// <summary>
    /// 图的环检测
    /// </summary>
    public class DFSCycleDetection
    {
        private IGraph _graph;
        private bool[] _visited;
        private int[] _pre; //储存节点的上一个路径节点
        private bool _hasCycle;

        public DFSCycleDetection(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _pre = new int[_graph.V()];

            for (var i = 0; i < _graph.V(); i++)
            {
                if (!_visited[i])
                {
                    DFS(i);
                }
            }
        }

        private void DFS(int v)
        {
            _visited[v] = true; //v节点已遍历

            //获取与V连接的节点，再对这些节点进行深度遍历
            foreach (var i in _graph.GetAdj(v))
            {
                if (!_visited[i])
                {
                    _pre[i] = v;
                    DFS(i);
                }
                /*
                 * 对节点进行检测，是否有环
                 *      1.如果i == pre[v]，说明i只是v的上一个节点而已，忽略
                 *      2.如果i != pre[v]，说明i没有被访问过，继续深度遍历
                 *      3.如果i != pre[v]，且i被访问过，说明构成了环
                 */
                else if (i != _pre[v])
                {
                    _hasCycle = true;
                    break;
                }
            }
        }

        public bool HasCycle() => _hasCycle;
    }
}