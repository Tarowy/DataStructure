namespace DataStructure.Graph.GraphWithWeight
{
    public class Dijkstra
    {
        private IGraph _graph;
        private int[] _dis;
        private bool[] _visited;

        public Dijkstra(IGraph graph, int source)
        {
            _graph = graph;
            _dis = new int[_graph.V()]; //dis储存的是source到dis的当前最小距离
            _visited = new bool[_graph.V()];

            for (var i = 0; i < _graph.V(); i++)
            {
                _dis[i] = int.MaxValue;
            }

            _dis[source] = 0;
            while (true)
            {
                //遍历每个dis[]找出最小的dis[]，更新curDis和cur的值
                var cur = -1; //cur相当于是个中转结点
                var curDis = int.MaxValue;
                for (var i = 0; i < _graph.V(); i++)
                {
                    if (!_visited[i] && _dis[i] < curDis)
                    {
                        /*
                         * 如果i被选中，说明source到i的最短路径已经被确定，接下来需要确定
                         * 走经过cur这个节点 到 与cur相连接的节点(adj)的路径 有没有更短距离的走法
                         */
                        cur = i;
                        curDis = _dis[i];
                    }
                }

                //如果cur依旧等于-1，说明所有节点都被访问过了直接退出循环
                if (cur == -1)
                {
                    break;
                }

                _visited[cur] = true;

                //遍历与cur相连的每个节点，算出cur到节点的权值，更新dis[]
                foreach (var adj in _graph.GetAdj(cur))
                {
                    /*
                     * cur相当于是个中转，如果(source到cur的距离)+(cur到adj的距离)<(以上一个cur为中转到adj的距离)
                     * 就更新dis[adj]的值
                     */
                    if (!_visited[adj] && _dis[cur] + ((AdjDictionary) _graph).Weight(cur, adj) < _dis[adj])
                    {
                        //走经过当前cur节点到adj的路径 比 走经过上一次cur节点到adj的路径 更短就更新adj的路径
                        _dis[adj] = _dis[cur] + ((AdjDictionary) _graph).Weight(cur, adj);
                    }
                }
            }
        }

        /// <summary>
        ///     source是否与v连通
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool IsConnected(int v) => _visited[v];

        /// <summary>
        ///     source到v的最短距离
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int DisTo(int v) => _dis[v];
    }
}