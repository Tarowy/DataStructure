using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 217. 存在重复元素
/// https://leetcode.cn/problems/contains-duplicate/
/// </summary>
public class LeetCode217
{
    /// <summary>
    /// 输入：nums = [1,2,3,1]
    /// 输出：true
    ///
    /// 输入：nums = [1,1,1,3,3,4,3,2,4,2]
    /// 输出：true
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool ContainsDuplicate(int[] nums)
    {
        Array.Sort(nums);
        
        for (var i = 1; i < nums.Length; i++)
            if (nums[i] == nums[i - 1])
                return true;

        return false;
    }
}