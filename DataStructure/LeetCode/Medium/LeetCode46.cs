using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  46. 全排列
///  https://leetcode.cn/problems/permutations/
/// </summary>
public class LeetCode46
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        Backtracking(result, new List<int>(), nums, new bool[nums.Length]);

        return result;
    }

    void Backtracking(ICollection<IList<int>> result, IList<int> path, IReadOnlyList<int> nums, IList<bool> used)
    {
        if (path.Count == nums.Count)
        {
            result.Add(new List<int>(path));
            return;
        }

        for (var i = 0; i < nums.Count; ++i)
        {
            if (used[i])
                continue;
            used[i] = true;
            path.Add(nums[i]);
            Backtracking(result, path, nums, used);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }
}