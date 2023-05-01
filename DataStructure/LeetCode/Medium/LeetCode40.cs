using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  40. 组合总和 II
///  https://leetcode.cn/problems/combination-sum-ii/
/// </summary>
public class LeetCode40
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        Array.Sort(candidates);
        Backtracking(result, path, candidates, target, 0);

        return result;
    }
    
    private void Backtracking(ICollection<IList<int>> result, IList<int> path, IReadOnlyList<int> candidates, int target, int startIndex) {
        if (target == 0) {
            result.Add(new List<int>(path));
            return;
        }

        for (int i = startIndex; i < candidates.Count; ++i) {
            /*
             * 1,1,2,5,6,7,10
             * 如果 i = 0 时找得到组合，那么下一个i = 1 时可能会找到相同的组合导致组合重复，所以不考虑 i = 1
             * 如果 i = 0 时找不到组合，那么下一个i = 1 时可能也找不到，同样不需要考虑 i = 1
             */
            if (i > startIndex && candidates[i] == candidates[i - 1])
                continue;

            path.Add(candidates[i]);
            if (target - candidates[i] < 0) {
                path.RemoveAt(path.Count - 1);
                return;
            }
            Backtracking(result, path, candidates, target - candidates[i], i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}