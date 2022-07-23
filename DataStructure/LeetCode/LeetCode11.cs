using System;

namespace DataStructure.LeetCode;

/// <summary>
/// 11. 盛最多水的容器
/// https://leetcode.cn/problems/container-with-most-water/
/// </summary>
public class LeetCode11
{
    /// <summary>
    /// 输入：[1,8,6,2,5,4,8,3,7]
    /// 输出：49
    /// 解释：图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。
    /// 在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为49。
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxArea(int[] height)
    {
        var area = 0;
        int l = 0, r = height.Length - 1;

        //需保证l与r不会交错
        while (l < r)
        {
            //无论长板多长，面积都由短板决定
            area = Math.Max(area, Math.Min(height[l], height[r]) * (r - l));
            //让短板向中间靠一位，因为面积由短板决定，所以如果移动长板，面积只会更小
            if (height[l] < height[r])
            {
                l++;
                continue;
            }

            r--;
        }

        return area;
    }
}