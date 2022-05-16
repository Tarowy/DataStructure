using System.Collections.Generic;

namespace DataStructure.Graph.DFStraverse
{
    /// <summary>
    ///     深度优先遍历的非递归实现
    /// </summary>
    public class DFSGraphNR
    {
        private IGraph _graph;
        private bool[] _visited;
        private MyList<int> _traverseList;
        private Stack<int> _stack;

        public DFSGraphNR(IGraph graph)
        {
            _graph = graph;
            _visited = new bool[_graph.V()];
            _traverseList = new MyList<int>();
            _stack = new Stack<int>();
            /*
             * 孤立节点度为0，直接进行DFS会导致访问不到这个节点，
             * 需要再依次判断每个节点是否被访问过
             */
            for (var i = 0; i < _graph.V(); i++)
            {
                if (!_visited[i])
                {
                    DFS(i);
                }
            }
        }

        /// <summary>
        ///     和广度优先遍历差不多，只要将队列替换成栈，就会变成深度优先遍历
        /// </summary>
        /// <param name="v">遍历开始的节点</param>
        private void DFS(int v)
        {
            _stack.Push(v);
            _visited[v] = true;

            while (_stack.Count != 0)
            {
                var pop = _stack.Pop();
                _traverseList.Add(pop);

                foreach (var i in _graph.GetAdj(pop))
                {
                    if (!_visited[i])
                    {
                        _stack.Push(i);
                        _visited[i] = true;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"{_traverseList}";
        }
    }
}