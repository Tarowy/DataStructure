using System.Security;

namespace DataStructure.Graph.DFStraverse
{
    /// <summary>
    /// 检测图是否是二分图
    ///     二分图：每个边连接的两个节点都不一样
    /// </summary>
    public class DFSBiPartitionDetection
    {
        private IGraph _graph;
        private bool[] _visited;
        private bool[] _colors; //节点的颜色
        private bool _isBiPartition = true; //图是否是二分图

        public DFSBiPartitionDetection(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _colors = new bool[_graph.V()];
            
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
                    //让下一个节点染上与当前节点不一样的颜色
                    _colors[i] = !_colors[v];
                    DFS(i);
                }
                //如果节点i已经被访问过，但v和i的颜色却是相同的，说明不是二分图
                else if (_colors[v] == _colors[i])
                {
                    _isBiPartition = false;
                }
            }
        }

        public bool IsPartition() => _isBiPartition;
    }
}