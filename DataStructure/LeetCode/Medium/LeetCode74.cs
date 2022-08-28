namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 74. 搜索二维矩阵
/// https://leetcode.cn/problems/search-a-2d-matrix/
/// </summary>
public class LeetCode74
{
    /// <summary>
    /// 输入：matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    /// 输出：true
    /// 输入：matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    /// 输出：false
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        //二维数组与一维数组的相互转换
        //二维 -> 一维 : x * 列长 + y
        //一维 -> 二维 : x = n/列长 y = n%列长，
        var row = matrix.Length;
        var col = matrix[0].Length;

        var l = 0;
        //矩阵的最后一位
        var r = row * col - 1;

        while (l <= r)
        {
            var mid = l + (r - l) / 2;

            if (matrix[mid / col][mid % col] < target)
                l = mid + 1;
            else if (matrix[mid / col][mid % col] > target)
                r = mid - 1;
            else
                return true;
        }

        return false;
    }
}