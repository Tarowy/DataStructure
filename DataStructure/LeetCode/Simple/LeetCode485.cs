using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 485. 最大连续 1 的个数
/// https://leetcode.cn/problems/max-consecutive-ones/
/// </summary>
public class LeetCode485
{
    /// <summary>
    /// 输入：nums = [1,1,0,1,1,1]
    /// 输出：3
    /// 解释：开头的两位和最后的三位都是连续 1 ，所以最大连续 1 的个数是 3.
    ///
    /// 输入：nums = [1,0,1,1,0,1]
    /// 输出：2
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var cur = 0;
        var max = 0;
        
        foreach (var t in nums)
        {
            //遇到1就加1，遇到0会被清零
            cur = (cur + t) * t;
            if (cur > max)
                max = cur;
        }

        return max;
    }
}