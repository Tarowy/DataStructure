using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  47. 全排列 II
///  https://leetcode.cn/problems/permutations-ii/
/// </summary>
public class LeetCode47
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        Backtracking(result, new List<int>(), nums, new bool[nums.Length]);

        return result;
    }

    private void Backtracking(ICollection<IList<int>> result, IList<int> path, IReadOnlyList<int> nums,
        IList<bool> used)
    {
        if (path.Count == nums.Count)
        {
            result.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < nums.Count; ++i)
        {
            //去重操作。前一个数和当前数相同，且前一个数未使用过，说明前一个数和当前数在同一层，且遍历过，所以跳过该数
            if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i-1]))
                continue;
            used[i] = true;
            path.Add(nums[i]);
            Backtracking(result, path, nums, used);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }
}