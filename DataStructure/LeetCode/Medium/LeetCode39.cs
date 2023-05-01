using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  39. 组合总和
///  https://leetcode.cn/problems/combination-sum/
/// </summary>
public class LeetCode39
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
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

        for (var i = startIndex; i < candidates.Count; ++i) {
            path.Add(candidates[i]);
            //减去当前的值已经小于0了，那么该元素之后的元素也不满足条件，所以直接结束当前递归
            if (target - candidates[i] < 0){
                path.RemoveAt(path.Count - 1);
                return;
            }
            /*
             * 直接将当前的索引向下传递，这样下一层递归会直接从当前索引开始，
             * 从而避免了比i小的值又被遍历导致的集合重复
             */
            Backtracking(result, path, candidates, target - candidates[i], i);
            path.RemoveAt(path.Count - 1);
        }
    }
}