//一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。 
//
// 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。 
//
// 问总共有多少条不同的路径？ 
//
// 
//
// 示例 1： 
// 
// 
//输入：m = 3, n = 7
//输出：28 
//
// 示例 2： 
//
// 
//输入：m = 3, n = 2
//输出：3
//解释：
//从左上角开始，总共有 3 条路径可以到达右下角。
//1. 向右 -> 向下 -> 向下
//2. 向下 -> 向下 -> 向右
//3. 向下 -> 向右 -> 向下
// 
//
// 示例 3： 
//
// 
//输入：m = 7, n = 3
//输出：28
// 
//
// 示例 4： 
//
// 
//输入：m = 3, n = 3
//输出：6 
//
// 
//
// 提示： 
//
// 
// 1 <= m, n <= 100 
// 题目数据保证答案小于等于 2 * 10⁹ 
// 
//
// Related Topics 数学 动态规划 组合数学 👍 1538 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

public class Solution62
{
    public int UniquePaths(int m, int n)
    {
        /*
         * 状态方程 [r][c] = [r][c-1] + [r-1][c]
         * 起始态：[0][0] = 1
         * 终止态：[m][n]
         */
        //储存网格每个位置的路径的结果集
        var resultSet = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                //边界的值都是1
                if (i is 0 || j is 0)
                {
                    resultSet[i, j] = 1;
                    continue;
                }
                //代入状态方程
                resultSet[i, j] = resultSet[i - 1, j]
                                  + resultSet[i, j - 1];
            }
        }

        return resultSet[m - 1, n - 1];
    }
}
//leetcode submit region end(Prohibit modification and deletion)