namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 344. 反转字符串
/// https://leetcode.cn/problems/reverse-string/
/// </summary>
public class LeetCode344
{
    /// <summary>
    /// 输入：s = ["h","e","l","l","o"]
    /// 输出：["o","l","l","e","h"]
    /// </summary>
    /// <param name="s"></param>
    public void ReverseString(char[] s)
        => Reverse(0, s.Length - 1, s);

    private void Reverse(int l, int r, char[] s)
    {
        if (l >= r)
            return;

        (s[l], s[r]) = (s[r], s[l]);
        Reverse(++l, --r, s);
    }
}