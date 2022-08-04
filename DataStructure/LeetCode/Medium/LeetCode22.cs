using System.Collections.Generic;
using System.Text;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 22. 括号生成
/// https://leetcode.cn/problems/generate-parentheses/
/// </summary>
public class LeetCode22
{
    private List<string> ans = new();

    /// <summary>
    /// 输入：n = 3
    /// 输出：["((()))","(()())","(())()","()(())","()()()"]
    /// 输入：n = 1
    /// 输出：["()"]
    /// 括号序列合法的充要条件：
    ///     1.在任意位置分割括号，'('的数量永远>=')'的数量
    ///     2.左右括号数量相等
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public IList<string> GenerateParenthesis(int n)
    {
        Dfs(0, 0, n, new StringBuilder());
        return ans;
    }

    /// <summary>
    /// 使用Dfs添加括号，依次将所有可能的括号组合添加进去
    /// </summary>
    /// <param name="lc">左括号数量</param>
    /// <param name="rc">右括号数量</param>
    /// <param name="n">括号总对数</param>
    /// <param name="seq">括号序列</param>
    private void Dfs(int lc, int rc, int n, StringBuilder seq)
    {
        //括号添加完毕
        if (lc == n && rc == n)
        {
            ans.Add(seq.ToString());
            return;
        }

        //(()) ()()
        //优先添加左括号
        if (lc < n)
        {
            Dfs(lc + 1, rc, n, seq.Append('('));
            seq.Remove(seq.Length - 1, 1);
        }

        //限制左括号数量必须大于右括号，否则会添加多个右括号导致匹配不上
        if (rc < n && lc > rc)
        {
            Dfs(lc, rc + 1, n, seq.Append(')'));
            seq.Remove(seq.Length - 1, 1);
        }
    }
}