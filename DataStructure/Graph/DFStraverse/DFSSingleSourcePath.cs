using System.Linq;

namespace DataStructure.Graph.DFStraverse
{
    /// <summary>
    /// 求解图的单源路径问题
    /// </summary>
    public class DFSSingleSourcePath
    {
        private IGraph _graph;
        private bool[] _visited;
        private int _source; //DFS的源头
        private int[] _pre; //储存节点的上一个路径节点

        public DFSSingleSourcePath(IGraph graph, int source)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _source = source;
            _pre = new int[_graph.V()];
            for (var i = 0; i < _pre.Length; i++)
            {
                _pre[i] = -1;
            }

            //单源路径不需要判断是否有孤立节点，孤立节点本来就没有路径
            DFS(_source);
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
    }
}