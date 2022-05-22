namespace DataStructure.Graph.DisjointSet
{
    /// <summary>
    /// 第二版并查集，以树的形式储存自己属于的集合，每个元素储存的是父节点的索引
    /// 元素越多，树的高度会压缩的很低，查询速度大幅上升
    /// </summary>
    public class UnionFind2: IUF
    {
        private int[] _parent;

        public UnionFind2(int size)
        {
            _parent = new int[size];

            //每个元素初始都指向自己
            for (var i = 0; i < size; i++)
            {
                _parent[i] = i;
            }
        }

        public int GetSize() => _parent.Length;

        //查询p是哪个集合的 O(h)和树的高度有关
        public int Find(int p)
        {
            //如果_parent[p] != p说明p不是根节点
            while (_parent[p] != p)
            {
                p = _parent[p];
            }

            return _parent[p];
        }

        //将p、q合并到一个集合中去，p的父节点直接指向q O(h)和树的高度有关
        public void Union(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);

            if (pRoot == qRoot)
            {
                return;
            }

            _parent[pRoot] = qRoot;
        }

        //查询p和q是不是同一个集合的 O(h)和树的高度有关
        public bool IsConnected(int p, int q) => Find(p) == Find(q);
    }
}