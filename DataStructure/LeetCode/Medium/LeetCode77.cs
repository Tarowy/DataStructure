using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  77. 组合
///  https://leetcode.cn/problems/combinations/
/// </summary>
public class LeetCode77
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var temp = new List<int>();
        Backtracking(result, temp, 1, n, k);

        return result;
    }

    public void Backtracking(IList<IList<int>> result, IList<int> temp, int index, int n, int k)
    {
        if (k == 0)
        {
            result.Add(new List<int>(temp));
            return;
        }

        for (var i = index; i <= n - k + 1; ++i)
        {
            temp.Add(i);
            Backtracking(result, temp, i + 1, n, k - 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}