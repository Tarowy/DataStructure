using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  459. 重复的子字符串
///  https://leetcode.cn/problems/repeated-substring-pattern/
/// </summary>
public class LeetCode459
{
    public bool RepeatedSubstringPattern(string s)
    {
        var next = new int[s.Length];

        GetNext(next, s.ToCharArray());
        var len = s.Length;

        return next[len - 1] != 0 && len % (len - next[len - 1]) == 0;
    }

    private void GetNext(IList<int> next, IReadOnlyList<char> chars)
    {
        int i = 1, j = 0;
        next[0] = 0;

        while (i < chars.Count)
        {
            if (chars[i] == chars[j])
                next[i++] = ++j;
            else if (j == 0)
                next[i] = 0;
            else
                j = next[j-1];
        }
    }
}