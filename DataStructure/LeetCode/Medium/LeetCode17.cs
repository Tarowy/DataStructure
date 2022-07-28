using System.Collections.Generic;
using System.Text;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 17. 电话号码的字母组合
/// https://leetcode.cn/problems/letter-combinations-of-a-phone-number/
/// </summary>
public class LeetCode17
{
    private List<string> _list = new();

    private string[] _maps =
        { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

    /// <summary>
    /// 2:abc 3:def 4:ghi 5:jkl 6:mno 7:pqrs 8:tuv 9:wxyz
    /// 输入：digits = "23"
    /// 输出：["ad","ae","af","bd","be","bf","cd","ce","cf"]
    /// 使用dfs算法，每次取一位digits，逐一向下搜索
    ///      a            b             c
    ///    / | \        / | \         / | \
    ///   d  e  f      d  e  f       d  e  f
    ///  /   |   \    /   |   \     /   |   \
    /// ad   ae  af   bd  be  bf   cd  ce   cf
    /// </summary>
    /// <param name="digits"></param>
    /// <returns></returns>
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return _list;
        }

        Dfs(digits, 0, new StringBuilder(""));
        return _list;
    }

    private void Dfs(string digits, int idx, StringBuilder stack)
    {
        //digits越界，表示排列完成，直接将结果添加到列表中
        if (idx == digits.Length)
        {
            _list.Add(stack.ToString());
            return;
        }

        //获取当前位的digits映射的字符串
        var s = _maps[digits[idx] - '0'];
        //以树形结构向下依次排列组合各字符串
        for (var i = 0; i < s.Length; i++)
        {
            stack.Append(s[i]);
            //以s[i]为根，将下一位digits映射的字符串连接为子节点
            Dfs(digits, idx + 1, stack);
            stack.Remove(stack.Length - 1, 1);
        }
    }
}