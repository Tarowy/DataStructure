using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  93. 复原 IP 地址
///  https://leetcode.cn/problems/restore-ip-addresses/
/// </summary>
public class LeetCode93
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var result = new List<string>();
        BackTracking(result, s, 0, 0);

        return result;
    }

    public void BackTracking(IList<string> result, string s, int startIndex, int pointNum)
    {
        if (pointNum == 3)
        {
            if (!IsValid(s, startIndex, s.Length - 1))
                return;
            result.Add(new string(s));
            return;
        }

        for (var i = startIndex; i < s.Length; i++)
        {
            if (!IsValid(s, startIndex, i))
                break;
            s = $"{s[..(i + 1)]}.{s[(i + 1)..]}";
            pointNum++;
            BackTracking(result, s, i + 2, pointNum);
            pointNum--;
            s = $"{s[..(i + 1)]}{s[(i + 2)..]}";
        }
    }

    public bool IsValid(string s, int start, int end)
    {
        if (start > end)
            return false;

        //只有0单独存在的时候才合法，此时s[start]等于s[end]
        if (s[start] is '0' && start != end)
        {
            // 0开头的数字不合法
            return false;
        }

        var num = 0;
        for (var i = start; i <= end; i++)
        {
            if (s[i] > '9' || s[i] < '0')
            {
                // 遇到非数字字符不合法
                return false;
            }

            num = num * 10 + (s[i] - '0');
            if (num > 255)
            {
                // 如果大于255了不合法
                return false;
            }
        }

        return true;
    }
}