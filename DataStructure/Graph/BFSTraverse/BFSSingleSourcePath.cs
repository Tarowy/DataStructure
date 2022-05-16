using System.Collections.Generic;
using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.BFSTraverse
{
    /// <summary>
    /// 图的单源最短路径
    ///     广度优先遍历的单源路径天生就是最短路径
    /// </summary>
    public class BFSSingleSourcePath
    {
        private IGraph _graph;
        private bool[] _visited;
        private Queue<int> _queue;
        private int _source;
        private int[] _pre;
        private int[] _dis; //节点到source的距离

        public BFSSingleSourcePath(IGraph graph,int source)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _queue = new Queue<int>();
            _source = source;
            _pre = new int[_graph.V()];
            _dis = new int[_graph.V()];
            for (var i = 0; i < _graph.V(); i++)
            {
                _pre[i] = _dis[i] = -1;
            }

            //求解最短单源路径不需要判断有没有孤立节点
            BFS(source);
        }

        private void BFS(int v)
        {
            _visited[v] = true;
            _queue.Enqueue(v);
            _dis[v] = 0;

            while (_queue.Count != 0)
            {
                var w = _queue.Dequeue();

                foreach (var i in _graph.GetAdj(w))
                {
                    if (!_visited[i])
                    {
                        _visited[i] = true;
                        _pre[i] = w;
                        _dis[i] = _dis[w] + 1;
                        _queue.Enqueue(i);
                    }
                }
            }
        }
        
        public MyList<int> GetSingleSourcePath(int t)
        {
            var myList = new MyList<int>();
            //如果t节点没有被遍历过，说明它是孤立节点，没有路径
            if (!_visited[t])
            {
                return myList;
            }

            var cur = t;
            //不断获取单源路径中cur的上一个节点
            while (cur != _source)
            {
                myList.Add(cur);
                cur = _pre[cur];
            }

            myList.Add(_source);
            myList.Reverse();
            return myList;
        }

        public int GetDistance(int v) => _dis[v];
    }
}