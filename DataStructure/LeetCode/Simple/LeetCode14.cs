namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 14. 最长公共前缀
/// https://leetcode.cn/problems/longest-common-prefix/
/// </summary>
public class LeetCode14
{
    /// <summary>
    /// 输入：strs = ["flower","flow","flight"]
    /// 输出："fl"
    /// 
    /// 输入：strs = ["dog","racecar","car"]
    /// 输出：""
    /// 解释：输入不存在公共前缀。
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public string LongestCommonPrefix(string[] strs)
    {
        for (var i = 0; i < strs[0].Length; i++)
        {
            //以第一个字符串为基准依次比较每一位的字符
            var c = strs[0][i];
            
            for (var j = 1; j < strs.Length; j++)
            {
                /*
                 * 如果i已经大于其他字符串的长度，或者已经不再匹配当前字符了，
                 * 就返回截止到当前i的子字符串
                 */
                if (i >= strs[j].Length || strs[j][i] != c)
                {
                    return strs[0].Substring(0, i);
                }
            }
        }

        //全部都能匹配上，说明第一个字符串的所有字符就是最长公共前缀
        return strs[0];
    }
}