namespace DataStructure.LeetCode.Medium
{
    /// <summary>
    /// 130. 被围绕的区域
    /// https://leetcode.cn/problems/surrounded-regions/
    /// </summary>
    public class LeetCode130
    {
        //x的方向是从上往下，y的方向是从左往右
        private int _r; //图的行
        private int _c; //图的列
        private bool[,] _visited;
        private char[][] _graph;
        private int[,] dir = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}}; //一个格子的上、右、下、左

        public void Solve(char[][] board)
        {
            _r = board.Length;
            _c = board[0].Length;
            _visited = new bool[_r, _c];
            _graph = board;

            //将靠边的海水标记上特定的符号
            for (var i = 0; i < _r; i++)
            {
                //如果第一列有靠边海水就调用DFS进行标记
                if (_graph[i][0] == 'O' && !_visited[i, 0])
                {
                    DFS(i, 0);
                }

                //如果最后一列有靠边海水就调用DFS进行”淹没“
                if (_graph[i][_c - 1] == 'O' && !_visited[i, _c - 1])
                {
                    DFS(i, _c - 1);
                }
            }

            for (var i = 0; i < _c; i++)
            {
                //如果第一行有靠边海水就调用DFS进行”淹没“
                if (_graph[0][i] == 'O' && !_visited[0, i])
                {
                    DFS(0, i);
                }

                //如果最后一行有靠边海水就调用DFS进行”淹没“
                if (_graph[_r - 1][i] == 'O' && !_visited[_r - 1, i])
                {
                    DFS(_r - 1, i);
                }
            }

            for (var i = 0; i < _r; i++)
            {
                for (var j = 0; j < _c; j++)
                {
                    //将靠边的海水还原成原来的符号
                    if (_graph[i][j] == '#')
                    {
                        _graph[i][j] = 'O';
                    }
                    //将被围绕的海水填充成陆地
                    else if (_graph[i][j] == 'O')
                    {
                        _graph[i][j] = 'X';
                    }
                }
            }
        }

        public void DFS(int x, int y)
        {
            _visited[x, y] = true;
            _graph[x][y] = '#'; //将靠边的海水区域标记成别的符号

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dir[d, 0]; //X偏移
                var nextY = y + dir[d, 1]; //Y偏移
                //如果(nextX,nextY)是陆地，且没有访问过就进行遍历
                if (InArea(nextX, nextY) && _graph[nextX][nextY] == 'O' && !_visited[nextX, nextY])
                {
                    DFS(nextX, nextY);
                }
            }
        }

        public bool InArea(int x, int y) => x >= 0 && x < _r && y >= 0 && y < _c;
    }
}