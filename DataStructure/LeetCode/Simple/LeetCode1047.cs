using System.Text;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  1047. 删除字符串中的所有相邻重复项
///  https://leetcode.cn/problems/remove-all-adjacent-duplicates-in-string/
/// </summary>
public class LeetCode1047
{
    public string RemoveDuplicates(string s)
    {
        var builder = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (builder.Length == 0 || builder[^1] != s[i]) builder.Append(s[i]);
            else builder.Remove(builder.Length - 1, 1);
        }

        return builder.ToString();
    }
}