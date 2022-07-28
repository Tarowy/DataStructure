namespace DataStructure.LeetCode.Medium
{
    /// <summary>
    /// 1020. 飞地的数量
    /// https://leetcode.cn/problems/number-of-enclaves/
    /// </summary>
    public class LeetCode1020
    {
        //x的方向是从上往下，y的方向是从左往右
        private int _r; //图的行
        private int _c; //图的列
        private bool[,] _visited;
        private int[][] _graph;
        private int _area;
        private int[,] dir = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}}; //一个格子的上、右、下、左

        public int NumEnclaves(int[][] grid)
        {
            _r = grid.Length;
            _c = grid[0].Length;
            _visited = new bool[_r, _c];
            _graph = grid;

            //将靠边的陆地用海水"淹没"
            for (var i = 0; i < _r; i++)
            {
                //如果第一列有陆地就调用DFS进行”淹没“
                if (_graph[i][0] == 1 && !_visited[i, 0])
                {
                    DFS(i, 0);
                }

                //如果最后一列有陆地就调用DFS进行”淹没“
                if (_graph[i][_c - 1] == 1 && !_visited[i, _c - 1])
                {
                    DFS(i, _c - 1);
                }
            }

            for (var i = 0; i < _c; i++)
            {
                //如果第一行有陆地就调用DFS进行”淹没“
                if (_graph[0][i] == 1 && !_visited[0, i])
                {
                    DFS(0, i);
                }

                //如果最后一行有陆地就调用DFS进行”淹没“
                if (_graph[_r - 1][i] == 1 && !_visited[_r - 1, i])
                {
                    DFS(_r - 1, i);
                }
            }

            for (var i = 0; i < _r; i++)
            {
                for (var j = 0; j < _c; j++)
                {
                    _area += _graph[i][j];
                }
            }

            return _area;
        }

        public void DFS(int x, int y)
        {
            _visited[x, y] = true;
            _graph[x][y] = 0; //淹没陆地

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dir[d, 0]; //X偏移
                var nextY = y + dir[d, 1]; //Y偏移
                //如果(nextX,nextY)是陆地，且没有访问过就进行遍历
                if (InArea(nextX, nextY) && _graph[nextX][nextY] == 1 && !_visited[nextX, nextY])
                {
                    DFS(nextX, nextY);
                }
            }
        }

        public bool InArea(int x, int y) => x >= 0 && x < _r && y >= 0 && y < _c;
    }
}