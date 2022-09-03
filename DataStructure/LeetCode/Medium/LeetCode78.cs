using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 78. 子集
/// https://leetcode.cn/problems/subsets/
/// </summary>
public class LeetCode78
{
    private readonly List<IList<int>> _subSets = new();

    /// <summary>
    /// 示例 1：
    /// 输入：nums = [1,2,3]
    /// 输出：[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
    /// 示例 2：
    /// 输入：nums = [0]
    /// 输出：[[],[0]]
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    //DFS法
#if false
    //DFS法
    public IList<IList<int>> Subsets(int[] nums)
    {
        var tempNums = new List<int>();
        _subSets.Add(tempNums.ToArray());
        GetSubSets(nums, 0, tempNums);
        return _subSets;
    }

    private void GetSubSets(int[] nums, int nextIndex, List<int> tempNumes)
    {
        for (var i = nextIndex; i < nums.Length; i++)
        {
            tempNumes.Add(nums[i]);
            _subSets.Add(tempNumes.ToArray());
            GetSubSets(nums, i + 1, tempNumes);
            tempNumes.RemoveAt(tempNumes.Count - 1);
        }
    }
#endif
#if true
    //回溯法
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>> { new List<int>() };
        //依次将对子数组长度的要求传递到函数中
        for (var i = 1; i <= nums.Length; i++)
            BackTracking(nums, i, 0, result, new List<int>());

        return result;
    }

    private void BackTracking(int[] nums, int length, int index, List<IList<int>> result, List<int> subSet)
    {
        //如果子数组的长度满足了要求的长度就将副本添加到结果集中
        if (subSet.Count == length)
        {
            result.Add(subSet.ToArray());
            return;
        }
        
        for (var i = index; i < nums.Length; i++)
        {
            //每层递归增加子数组的长度
            subSet.Add(nums[i]);
            BackTracking(nums, length, i + 1, result, subSet);
            subSet.RemoveAt(subSet.Count - 1);
        }
    }
#endif
}