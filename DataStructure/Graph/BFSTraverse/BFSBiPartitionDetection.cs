using System.Collections.Generic;
using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.BFSTraverse
{
    /// <summary>
    /// 广度优先实现二分图的检测
    /// </summary>
    public class BFSBiPartitionDetection
    {
        private IGraph _graph;
        private bool[] _visited;
        private Queue<int> _queue;
        private bool _isPartition = true;
        private bool[] _colors;

        public BFSBiPartitionDetection(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _queue = new Queue<int>();
            _colors = new bool[_graph.V()];

            for (var i = 0; i < _graph.V(); i++)
            {
                if (!_visited[i])
                {
                    BFS(i);
                }
            }
        }

        private void BFS(int v)
        {
            _visited[v] = true;
            _queue.Enqueue(v);

            while (_queue.Count != 0)
            {
                var w = _queue.Dequeue();

                foreach (var i in _graph.GetAdj(w))
                {
                    if (!_visited[i])
                    {
                        _visited[i] = true;
                        _colors[i] = !_colors[w];
                        _queue.Enqueue(i);
                    }else if (_colors[i] == _colors[w])
                    {
                        _isPartition = false;
                    }
                }
            }
        }

        public bool IsPartitionGraph() => _isPartition;
    }
}