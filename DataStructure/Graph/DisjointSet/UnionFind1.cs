namespace DataStructure.Graph.DisjointSet
{
    /// <summary>
    /// 第一版并查集，每个元素各自储存自己属于的集合
    /// </summary>
    public class UnionFind1 : IUF
    {
        private int[] _id;

        public UnionFind1(int size)
        {
            _id = new int[size];
            
            //每个元素初始都指向自己
            for (var i = 0; i < size; i++)
            {
                _id[i] = i;
            }
        }

        public int GetSize() => _id.Length;

        //查询p是哪个集合的 O(1)
        public int Find(int p) => _id[p];

        //将p、q合并到一个集合中去 O(n)
        public void Union(int p, int q)
        {
            var pId = _id[p]; //p属于的集合
            var qId = _id[q]; //q属于的集合

            if (pId == qId)
            {
                return;
            }

            //不仅需要将p合并到q属于的集合中，还要将所有属于pId集合的元素都合并到qId中去
            for (var i = 0; i < GetSize(); i++)
            {
                //如果i属于pId的集合，则将pId合并到qId的集合中去
                if (_id[i] == pId)
                {
                    _id[i] = qId;
                }
            }
        }

        //查询p和q是不是同一个集合的 O(1)
        public bool IsConnected(int p, int q) => Find(p) == Find(q);
    }
}