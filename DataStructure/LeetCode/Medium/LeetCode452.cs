using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  452. 用最少数量的箭引爆气球
/// https://leetcode.cn/problems/minimum-number-of-arrows-to-burst-balloons/
/// </summary>
public class LeetCode452
{
    public int FindMinArrowShots(int[][] points)
    {
        if (points.Length == 0)
            return 0;
        
        Array.Sort(points, (p1, p2) => p1[0].CompareTo(p2[0]));
        
        //气球不为空则至少需要1支箭
        var result = 1;
        //[[1,6],[2,8],[7,12],[10,16]]
        for (int i = 1; i < points.Length; ++i) {
            //如果当前气球的左边界大于前一个气球的右边界，这两个气球不相邻，需要增加一支箭
            if (points[i][0] > points[i - 1][1]) {
                result++;
            } else {
                /*
                 * 当前气球的左边界小于前一个气球的右边界，两个气球重叠
                 * 更新当前气球的右边界为两者的最小右边界，应付后一个气球也和当前气球重叠的情况
                 * 这样一箭可以贯穿两个以上的气球
                 */
                points[i][1] = Math.Min(points[i - 1][1], points[i][1]);
            }
        }

        return result;
    }
}