using System.Collections.Generic;
using System.Text;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 131. 分割回文串
/// https://leetcode.cn/problems/palindrome-partitioning/
/// </summary>
public class LeetCode131
{
    public IList<IList<string>> Partition(string s)
    {
        var result = new List<IList<string>>();
        Backtracking(result, new List<string>(), s, 0);

        return result;
    }

    private void Backtracking(ICollection<IList<string>> result, IList<string> path, string s, int startIndex)
    {
        if (startIndex >= s.Length)
        {
            result.Add(new List<string>(path));
            return;
        }

        for (var i = startIndex; i < s.Length; ++i)
        {
            //从startIndex到i的子串不是回文字串，那么直接不考虑这次回溯
            if (!IsPalindrome(s, startIndex, i))
                continue;
            var str = s.Substring(startIndex, i - startIndex + 1);
            path.Add(str);
            Backtracking(result, path, s, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }

    private bool IsPalindrome(string s, int start, int end)
    {
        for (int i = start, j = end; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                return false;
            }
        }

        return true;
    }
}