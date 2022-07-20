namespace DataStructure.LeetCode
{
    public class LeetCode733
    {
        //x的方向是从上往下，y的方向是从左往右
        private int _r; //图的行
        private int _c; //图的列
        private bool[,] _visited;
        private int[][] _image;
        private int _oldColor;
        private int[,] dir = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}}; //一个格子的上、右、下、左

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            _r = image.Length;
            _c = image[0].Length;
            _visited = new bool[_r, _c];
            _image = image;
            _oldColor = image[sr][sc];

            DFS(sr, sc, newColor);
            return _image;
        }

        public void DFS(int x,int y,int newColor)
        {
            _visited[x, y] = true;
            _image[x][y] = newColor;

            for (var d = 0; d < 4; d++)
            {
                var nextX = x + dir[d, 0]; //X偏移
                var nextY = y + dir[d, 1]; //Y偏移
                //如果(nextX,nextY)是陆地，且没有访问过就进行遍历
                if (InArea(nextX, nextY) && _image[nextX][nextY] == _oldColor && !_visited[nextX, nextY])
                {
                    DFS(nextX, nextY, newColor);
                }
            }
        }
        
        public bool InArea(int x, int y) => x >= 0 && x < _r && y >= 0 && y < _c;
    }
}