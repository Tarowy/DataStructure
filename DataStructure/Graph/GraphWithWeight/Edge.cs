using System;

namespace DataStructure.Graph.GraphWithWeight
{
    /// <summary>
    /// 储存带权图的边的两个节点以及权重
    /// </summary>
    public class Edge: IComparable<Edge>
    {
        private int _a;
        private int _b;
        private int _w;

        public Edge(int a, int b, int w)
        {
            _a = a;
            _b = b;
            _w = w;
        }

        public int GetA() => _a;
        public int GetB() => _b;
        public int GetW() => _w;

        public override string ToString() => $"{_a}-{_b} : {_w}";

        //升序排列
        public int CompareTo(Edge other) => _w - other._w;
    }
}