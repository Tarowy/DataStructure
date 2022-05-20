namespace DataStructure.Graph.DisjointSet
{
    /// <summary>
    ///     并查集接口
    /// </summary>
    public interface IUF
    {
        int GetSize();
        void Union(int p, int q);
        bool IsConnected(int p, int q);
    }
}