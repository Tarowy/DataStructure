using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 90. 子集 II
/// https://leetcode.cn/problems/subsets-ii/
/// </summary>
public class LeetCode90
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        Backtracking(result,new List<int>(),nums,0);

        return result;
    }

    public void Backtracking(IList<IList<int>> result, IList<int> path, IReadOnlyList<int> nums, int startIndex)
    {
        result.Add(new List<int>(path));

        for (var i = startIndex; i < nums.Count; ++i)
        {
            //上一个数和当前数相同，那么上一个循环时已经将包含当前数的集合加入过结果集，会导致重复
            if (i > startIndex && nums[i] == nums[i - 1])
                continue;
            path.Add(nums[i]);
            Backtracking(result, path, nums, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}