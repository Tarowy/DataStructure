using System.Collections.Generic;

namespace DataStructure.LeetCode;

/// <summary>
/// 13. 罗马数字转整数
/// https://leetcode.cn/problems/roman-to-integer/
/// </summary>
public class LeetCode13
{
    /// <summary>
    /// 输入: s = "MCMXCIV"
    /// 输出: 1994
    /// 解释: M = 1000, CM = 900, XC = 90, IV = 4
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int RomanToInt(string s)
    {
        var roman = new Dictionary<char, int>
        {
            { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
        };

        var ans = 0;
        /*
         * 如果一个字符出现在了比它大的字符的左边则减去这个字符代表的数字，
         * 否则就加上代表的数字
         */
        for (var i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && roman[s[i]] < roman[s[i + 1]])
            {
                ans -= roman[s[i]];
                continue;
            }

            ans += roman[s[i]];
        }

        return ans;
    }
}