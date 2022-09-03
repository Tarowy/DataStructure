using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 1456. 定长子串中元音的最大数目
/// https://leetcode.cn/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
/// </summary>
public class LeetCode1456
{
    /// <summary>
    /// 示例 1：
    /// 输入：s = "abciiidef", k = 3
    /// 输出：3
    /// 解释：子字符串 "iii" 包含 3 个元音字母。
    /// 示例 2：
    /// 输入：s = "aeiou", k = 2
    /// 输出：2
    /// 解释：任意长度为 2 的子字符串都包含 2 个元音字母。
    /// 示例 3：
    /// 输入：s = "leetcode", k = 3
    /// 输出：2
    /// 解释："lee"、"eet" 和 "ode" 都包含 2 个元音字母。
    /// 示例 4：
    /// 输入：s = "rhythms", k = 4
    /// 输出：0
    /// 解释：字符串 s 中不含任何元音字母。
    /// 示例 5：
    /// 输入：s = "tryhard", k = 4
    /// 输出：1
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int MaxVowels(string s, int k)
    {
        var vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        int ans = 0, count = 0;

        for (var i = 0; i < k; i++)
            if (vowel.Contains(s[i]))
                count++;

        /*
         * 由于下面的循环是先对count做操作再记录最大值，
         * 所以可能会导致count先--再被ans记录，这样会获取不到最大值
         */
        ans = count;

        for (var i = k; i < s.Length; i++)
        {
            //右端多包含了一个元音就数量+1
            if (vowel.Contains(s[i]))
                count++;

            //左端剔除了一个元音就数量-1
            if (vowel.Contains(s[i - k]))
                count--;

            ans = Math.Max(ans, count);
        }

        return ans;
    }
}