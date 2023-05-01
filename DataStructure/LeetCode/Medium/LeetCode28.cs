namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 28. 找出字符串中第一个匹配项的下标
/// https://leetcode.cn/problems/find-the-index-of-the-first-occurrence-in-a-string/
/// </summary>
public class LeetCode28
{
    public int StrStr(string haystack, string needle)
    {
        var chars = needle.ToCharArray();
        var targetChars = haystack.ToCharArray();
        var next = new int[needle.Length];

        GetNext(next, chars);

        var i = 0;
        var j = 0;
        for (; i < haystack.Length; i++)
        {
            while (j > 0 && targetChars[i] != chars[j])
                j = next[j - 1];

            if (targetChars[i] == chars[j])
                j++;

            if (j == next.Length)
                return i - next.Length + 1;
        }

        return -1;
    }

    public void GetNext(int[] next, char[] chars)
    {
        var i = 1;
        var j = 0;
        next[0] = 0;

        while (i < chars.Length)
        {
            if (chars[i] == chars[j])
                next[i++] = ++j;
            else if (j == 0)
                next[i++] = 0;
            else
                j = next[j - 1];
        }
    }
}