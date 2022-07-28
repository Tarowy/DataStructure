namespace DataStructure.LeetCode.Medium
{
    public class LeetCode200
    {
        //x的方向是从上往下，y的方向是从左往右
        private int _r; //图的行
        private int _c; //图的列
        private bool[,] _visited;
        private char[][] _graph;
        private int _count;
        private int[,] dir = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}}; //一个格子的上、右、下、左

        public int NumIslands(char[][] grid)
        {
            _graph = grid;
            _r = _graph.Length; //第一维度的长即为行
            _c = _graph[0].Length; //第二维度的长即为列
            _visited = new bool[_r, _c];

            for (var i = 0; i < _r; i++)
            {
                for (var j = 0; j < _c; j++)
                {
                    //只有陆地和未访问过的区域才需要访问
                    if (_graph[i][j] == '1' && !_visited[i, j])
                    {
                        DFS(i, j);
                        _count++;
                    }
                }
            }

            return _count;
        }

        public void DFS(int x, int y)
        {
            _visited[x, y] = true;
            
            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dir[d, 0]; //X偏移
                var nextY = y + dir[d, 1]; //Y偏移
                //如果(nextX,nextY)是陆地，且没有访问过就进行遍历
                if (InArea(nextX, nextY) && _graph[nextX][nextY] == '1' && !_visited[nextX, nextY])
                {
                    DFS(nextX, nextY);
                }
            }
        }

        public bool InArea(int x, int y) => x >= 0 && x < _r && y >= 0 && y < _c;
    }
}