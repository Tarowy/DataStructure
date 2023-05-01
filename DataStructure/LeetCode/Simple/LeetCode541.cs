using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  541. 反转字符串 II
/// https://leetcode.cn/problems/reverse-string-ii/
/// </summary>
public class LeetCode541
{
    public string ReverseStr(string s, int k)
    {
        var chars = s.ToCharArray();
        for (var i = 0; i < s.Length; i += (2 * k))
        {
            var start = i;
            //反转 i ~ i+k-1 的字符，如果 i+k-1 大于字符串总长度则全部反转
            var end = Math.Min(i + k - 1, s.Length - 1);

            while (start < end)
            {
                //使用异或反转数组
                chars[start] ^= chars[end];
                chars[end] ^= chars[start];
                chars[start] ^= chars[end];
                start++;
                end--;
            }
        }

        return new string(chars);
    }
}