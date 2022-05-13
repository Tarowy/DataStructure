using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructure.Graph
{
    /// <summary>
    ///     邻接链表
    /// </summary>
    public class AdjLinkedList: IGraph
    {
         private int _v;
        private int _e;
        private LinkedList<int>[] _graph;

        public AdjLinkedList(string file)
        {
            var fs = new FileStream(file, FileMode.Open);
            var sr = new StreamReader(fs);

            var graphInfo = sr.ReadLine().Split(' ');
            //取出边和顶点的信息
            _v = int.Parse(graphInfo[0]);
            _e = int.Parse(graphInfo[1]);
            //对每个链表数组分别初始化
            _graph = new LinkedList<int>[_v];
            for (var i = 0; i < _v; i++)
            {
                _graph[i] = new LinkedList<int>();
            }

            for (var i = 0; i < _e; i++)
            {
                graphInfo = sr.ReadLine().Split(' ');
                _graph[int.Parse(graphInfo[0])].AddLast(int.Parse(graphInfo[1]));
                _graph[int.Parse(graphInfo[1])].AddLast(int.Parse(graphInfo[0]));
            }

            fs.Close();
            sr.Close();
        }

        public int V() => _v;
        public int E() => _e;

        public bool HasEdge(int a, int b)
        {
            return _graph[a].Contains(b);
        }
        
        /// <summary>
        ///     获取与a相连接的节点 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<int> GetAdj(int a)
        {
            return _graph[a];
        }

        /// <summary>
        ///     获取a的度
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Degree(int a)
        {
            return ((LinkedList<int>)GetAdj(a)).Count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"V={_v} E={_e}\n");
            for (var i = 0; i < _v; i++)
            {
                sb.Append(i + " : ");
                foreach (var adj in _graph[i])
                {
                    sb.Append($"{adj} ");
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}