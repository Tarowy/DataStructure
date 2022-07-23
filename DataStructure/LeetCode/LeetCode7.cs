using System;

namespace DataStructure.LeetCode;

/// <summary>
/// 7. 整数反转
/// https://leetcode.cn/problems/reverse-integer/
/// </summary>
public class LeetCode7
{
    /// <summary>
    /// 输入：x = 123
    /// 输出：321
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int Reverse(int x)
    {
        var ans = 0;

        while (x != 0)
        {
            //ans * 10 + x % 10 > INT.MAX 正32位整型溢出
            if (ans > 0 && ans > (int.MaxValue - x % 10) / 10)
            {
                return 0;
            }

            //ans * 10 + x % 10 < INT.MIN 负32位整型溢出
            if (ans < 0 && ans < (Int32.MinValue - x % 10) / 10)
            {
                return 0;
            }

            //x每弹出一位数，ans就乘10再加上弹出的数
            ans = ans * 10 + x % 10;
            x /= 10;
        }

        return ans;
    }
}