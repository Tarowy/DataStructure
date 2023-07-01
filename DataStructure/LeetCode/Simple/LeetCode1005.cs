using System;
using System.Linq;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  1005. K 次取反后最大化的数组和
/// https://leetcode.cn/problems/maximize-sum-of-array-after-k-negations/
/// </summary>
public class LeetCode1005
{
    public int LargestSumAfterKNegations(int[] nums, int k)
    {
        Array.Sort(nums, (a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));

        for (var i = 0; i < nums.Length; i++)
        {
            if (k > 0 && nums[i] < 0)
            {
                k--;
                nums[i] *= -1;
            }
        }

        /*
        * 如果k没用完，则对绝对值最小的数反复取反，消耗k的次数，
        * 这样即使最后取反的结果是负数，对结果的影响也最小
        */
        if (k % 2 == 1)
            nums[^1] *= -1;

        var result = 0;
        for (var i = 0; i < nums.Length; i++)
            result += nums[i];

        return result;
    }
}