using System.Collections.Generic;

namespace DataStructure.Graph.BFSTraverse
{
    public class BFSCycleDetection
    {
        private IGraph _graph;
        private bool[] _visited;
        private Queue<int> _queue;
        private int[] _pre;
        private bool _hasCycle;

        public BFSCycleDetection(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _queue = new Queue<int>();
            _pre = new int[_graph.V()];
            for (var i = 0; i < _graph.V(); i++)
            {
                _pre[i] = -1;
            }

            //需要判断所有分图有没有环
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
                        _pre[i] = w;
                        _queue.Enqueue(i);
                    }
                    //如果w节点的上一个节点不是i说明w和i不是边，构成了环
                    else if (i != _pre[w])
                    {
                        _hasCycle = true;
                    }
                }
            }
        }

        public bool HasCycle() => _hasCycle;
    }
}