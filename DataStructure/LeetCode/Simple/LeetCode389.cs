namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 389. 找不同
/// https://leetcode.cn/problems/find-the-difference/
/// </summary>
public class LeetCode389
{
    /// <summary>
    /// 输入：s = "abcd", t = "abcde"
    /// 输出："e"
    /// 解释：'e' 是那个被添加的字母。
    ///
    /// 输入：s = "", t = "y"
    /// 输出："y"
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public char FindTheDifference(string s, string t)
    {
        //异或的特性：x^x=0 , x^0 = x 所以偶数个的字母异或值必定为0，奇数个相同的字母异或就会留下一个字母
        //s和t如果有重复的字母那么出现的字数必定为偶数次，出现奇数次的字母便是多出来的字母
        var ans = 0;
        
        foreach (var str in s)
        {
            ans ^= str;
        }

        foreach (var str in t)
        {
            ans ^= str;
        }

        return (char)ans;
    }
}