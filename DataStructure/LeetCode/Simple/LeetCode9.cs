namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 9. 回文数
/// https://leetcode.cn/problems/palindrome-number/
/// </summary>
public class LeetCode9
{
    /// <summary>
    /// 输入：x = 121 输出：true
    /// 
    /// 输入：x = 10 输出：false
    /// 解释：从右向左读, 为 01 。因此它不是一个回文数。
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool IsPalindrome(int x)
    {
        //负数必定不是回文数
        if (x < 0)
            return false;

        var num = x;
        var ans = 0;

        while (x != 0)
        {
            /*
             * 由于x一定不是溢出的数，所以如果x是回文数，则一定不会溢出
             * 但如果x不是回文数，就可能导致溢出，所以需要判断
             * 溢出判断详情参考LeetCode7
             */
            if (ans > (int.MaxValue - x % 10) / 10)
            {
                return false;
            }

            ans = ans * 10 + x % 10;
            x /= 10;
        }

        return num == ans;
    }
}