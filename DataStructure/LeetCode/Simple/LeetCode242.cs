using System.Linq;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 242. 有效的字母异位词
/// https://leetcode.cn/problems/valid-anagram/
/// </summary>
public class LeetCode242
{
    public bool IsAnagram(string s, string t)
    {
        var table = new int[26];

        foreach (var c in s)
            table[c - 'a']++;
        foreach (var c in t)
            table[c - 'a']--;

        return table.All(c => c == 0);
    }
}