using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 209. 长度最小的子数组
/// https://leetcode.cn/problems/minimum-size-subarray-sum/
/// </summary>
public class LeetCode209
{
    /// <summary>
    /// 输入：target = 7, nums = [2,3,1,2,4,3]
    /// 解释：子数组[4,3]是该条件下的长度最小的子数组。
    /// 示例 2：
    /// 输入：target = 4, nums = [1,4,4]
    /// 输出：1
    /// 示例 3：
    /// 输入：target = 11, nums = [1,1,1,1,1,1,1,1]
    /// 输出：0
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MinSubArrayLen(int target, int[] nums)
    {
        int l = 0, r = 0, sum = 0, ans = int.MaxValue;

        foreach (var i in nums)
        {
            //无脑加入下一个数，并扩大右窗口
            sum += nums[r++];
            while (sum - nums[l] >= target)
                sum -= nums[l++];

            if (sum >= target && ans > r - l)
                ans = r - l;
        }

        return sum < target ? 0 : ans;
    }
}