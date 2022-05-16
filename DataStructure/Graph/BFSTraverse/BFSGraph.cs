using System.Collections.Generic;
using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.BFSTraverse
{
    /// <summary>
    /// 图的广度优先遍历
    /// </summary>
    public class BFSGraph
    {
        private IGraph _graph;
        private bool[] _visited;
        private Queue<int> _queue;
        private MyList<int> _myList;
        private int _components;

        public BFSGraph(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _queue = new Queue<int>();
            _myList = new MyList<int>();

            //防止孤立节点遍历不到
            for (var i = 0; i < _graph.V(); i++)
            {
                if (!_visited[i])
                {
                    BFS(i);
                    _components++;
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
                _myList.Add(w);

                foreach (var i in _graph.GetAdj(w))
                {
                    if (!_visited[i])
                    {
                        _visited[i] = true;
                        _queue.Enqueue(i);
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"连通分量：{_components}\n{_myList}";
        }
    }
}