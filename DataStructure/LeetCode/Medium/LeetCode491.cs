using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

public class LeetCode491
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var result = new List<IList<int>>();
        Backtracking(result, new List<int>(), nums, 0, -1);

        return result;
    }

    public void Backtracking(IList<IList<int>> result, IList<int> path, IReadOnlyList<int> nums, int startIndex,
        int lastNumIndex)
    {
        if (path.Count >= 2)
            result.Add(new List<int>(path));

        //记录在当前层，哪个数字已经用过
        var used = new int[201];
        for (int i = startIndex; i < nums.Count; ++i)
        {
            if (used[nums[i] + 100] == 1 || (lastNumIndex != -1 && nums[i] < nums[lastNumIndex]))
                continue;
            path.Add(nums[i]);
            Backtracking(result, path, nums, i + 1, i);
            used[nums[i] + 100] = 1;
            path.RemoveAt(path.Count - 1);
        }
    }
}