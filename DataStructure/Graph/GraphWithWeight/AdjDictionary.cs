using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructure.Graph.GraphWithWeight
{
    /// <summary>
    /// 储存带权图
    /// </summary>
    public class AdjDictionary : IGraph
    {
        private int _v;
        private int _e;
        private Dictionary<int, int>[] _graph;

        public AdjDictionary(string file)
        {
            var fs = new FileStream(file, FileMode.Open);
            var sr = new StreamReader(fs);

            var graphInfo = sr.ReadLine().Split(' ');
            //取出边和顶点的信息
            _v = int.Parse(graphInfo[0]);
            _e = int.Parse(graphInfo[1]);
            //对每个字典数组分别初始化
            _graph = new Dictionary<int, int>[_v];
            for (var i = 0; i < _v; i++)
            {
                _graph[i] = new Dictionary<int, int>();
            }

            for (var i = 0; i < _e; i++)
            {
                graphInfo = sr.ReadLine().Split(' ');
                //储存i连接的边和权重
                _graph[int.Parse(graphInfo[0])].Add(int.Parse(graphInfo[1]), int.Parse(graphInfo[2]));
                _graph[int.Parse(graphInfo[1])].Add(int.Parse(graphInfo[0]), int.Parse(graphInfo[2]));
            }

            fs.Close();
            sr.Close();
        }

        public int V() => _v;
        public int E() => _e;

        public bool HasEdge(int a, int b) => _graph[a].ContainsKey(b);

        /// <summary>
        ///     获取与a相连接的节点 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<int> GetAdj(int a) => _graph[a].Keys;

        /// <summary>
        ///     获取a的度
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Degree(int a) => ((Dictionary<int, int>.KeyCollection)GetAdj(a)).Count;

        public int Weight(int a, int b) => _graph[a][b];

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"V={_v} E={_e}\n");
            for (var i = 0; i < _v; i++)
            {
                sb.Append(i + " : ");
                foreach (var adj in _graph[i])
                {
                    sb.Append($"(V={adj.Key}, E={adj.Value}) ");
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}