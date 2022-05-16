using DataStructure.Graph.DFStraverse;

namespace DataStructure.Graph.BFSTraverse
{
    public class RandomGraph
    {
        private IGraph _g;
        private bool[] _visited;
        private RandomQueue<int> _queue = new RandomQueue<int>();
        private MyList<int> _list = new MyList<int>();

        public RandomGraph(IGraph G)
        {
            _g = G;
            _visited = new bool[G.V()];

            for (var v = 0; v < G.V(); v++)
            {
                if (!_visited[v])
                {
                    BFS(v);
                }
            }
        }


        /// <summary>
        ///     使用随机队列进行遍历，得到的遍历次序会是随机无序的
        /// </summary>
        /// <param name="s"></param>
        private void BFS(int s)
        {
            _visited[s] = true;
            _queue.Enqueue(s);

            while (_queue.Count != 0)
            {
                //从队列中随机取出一个元素
                var v = _queue.Dequeue();
                _list.Add(v);

                foreach (var w in _g.GetAdj(v))
                {
                    if (!_visited[w])
                    {
                        _visited[w] = true;
                        _queue.Enqueue(w);
                    }
                }
            }
        }

        public override string ToString() => $"{_list}";
    }
}