using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructure.Graph
{
    /// <summary>
    /// 邻接矩阵
    /// </summary>
    public class AdjMatrix: IGraph
    {
        private int _v;
        private int _e;
        private int[,] _graph;

        public AdjMatrix(string file)
        {
            var fs = new FileStream(file, FileMode.Open);
            var sr = new StreamReader(fs);

            var graphInfo = sr.ReadLine().Split(' ');
            //取出边和顶点的信息
            _v = int.Parse(graphInfo[0]);
            _e = int.Parse(graphInfo[1]);
            _graph = new int[_v, _v];

            for (var i = 0; i < _e; i++)
            {
                graphInfo = sr.ReadLine().Split(' ');
                _graph[Convert.ToInt32(graphInfo[1]), Convert.ToInt32(graphInfo[0])] =
                    _graph[Convert.ToInt32(graphInfo[0]), Convert.ToInt32(graphInfo[1])] = 1;
            }

            fs.Close();
            sr.Close();
        }

        public int V() => _v;
        public int E() => _e;

        public bool HasEdge(int a, int b)
        {
            return _graph[a, b] == 1;
        }
        
        /// <summary>
        ///     获取与a相连接的节点 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<int> GetAdj(int a)
        {
            var adj = new List<int>();
            for (var b = 0; b < _v; b++)
            {
                if (_graph[a, b] == 1)
                {
                    adj.Add(b);
                }
            }
            return adj;
        }

        /// <summary>
        ///     获取a的度
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Degree(int a)
        {
            return ((List<int>)GetAdj(a)).Count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"V={_v} E={_e}\n");
            for (var i = -1; i < _v; i++)
            {
                for (var j = -1; j < _v; j++)
                {
                    if (i == -1)
                    {
                        if (j == -1)
                        {
                            sb.Append("  ");
                            continue;
                        }

                        sb.Append($"{j} ");
                        continue;
                    }

                    if (j == -1)
                    {
                        sb.Append($"{i} ");
                        continue;
                    }

                    sb.Append($"{_graph[i, j]} ");
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}