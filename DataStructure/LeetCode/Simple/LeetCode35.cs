using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 35. 搜索插入位置
/// https://leetcode.cn/problems/search-insert-position/
/// </summary>
public class LeetCode35
{
    /// <summary>
    /// 输入: nums = [1,3,5,6], target = 5
    /// 输出: 2
    ///
    /// 输入: nums = [1,3,5,6], target = 2
    /// 输出: 1
    ///
    /// 输入: nums = [1,3,5,6], target = 7
    /// 输出: 4
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int SearchInsert(int[] nums, int target)
    {
        if (target < nums[0])
            return 0;

        var l = 0;
        var r = nums.Length - 1;
        var mid = -1;

        while (l <= r)
        {
            mid = l + (r - l) / 2;

            if (target < nums[mid])
                r = mid - 1;
            else if (target > nums[mid])
                l = mid + 1;
            else
                return mid;
        }

        return nums[mid] > target ? mid : mid + 1;
    }
}