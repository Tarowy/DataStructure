namespace DataStructure.LeetCode.Medium
{
    /// <summary>
    /// 785. 判断二分图
    /// https://leetcode.cn/problems/is-graph-bipartite/
    /// </summary>
    public class LeetCode785
    {
        // public static void Main(string[] args)
        // {
        //     int[][] graph1 =
        //     {
        //         new int[]{1,2,3},
        //         new int[]{0,2},
        //         new int[]{0,1,3},
        //         new int[]{0,2},
        //
        //     };
        //
        //     int[][] graph2 =
        //     {
        //         new int[]{1,3},
        //         new int[]{0,2},
        //         new int[]{1,3},
        //         new int[]{0,2},
        //
        //     };
        //     
        //     Console.WriteLine(new LeetCode785().IsBipartite(graph1));
        //     Console.WriteLine(new LeetCode785().IsBipartite(graph2));
        // }

        private int[][] _graph;
        private bool[] _visited;
        private bool[] _color;
        private bool _isBipartite = true;
        
        public bool IsBipartite(int[][] graph)
        {
            _graph = graph;
            _visited = new bool[_graph.Length];
            _color = new bool[_graph.Length];

            for (var i = 0; i < _graph.Length; i++)
            {
                if (!_visited[i])
                {
                    DFS(i);
                }
            }

            return _isBipartite;
        }

        public void DFS(int v)
        {
            _visited[v] = true;

            foreach (var i in _graph[v])
            {
                if (!_visited[i])
                {
                    _color[i] = !_color[v];
                    DFS(i);
                }
                else if (_color[v] == _color[i])
                {
                    _isBipartite = false;
                }
            }
        }
    }
}