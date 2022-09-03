namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 509. 斐波那契数
/// https://leetcode.cn/problems/fibonacci-number/
/// </summary>
public class LeetCode509
{
    /// <summary>
    /// 输入：n = 2
    /// 输出：1
    /// 解释：F(2) = F(1) + F(0) = 1 + 0 = 1
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Fib(int n)
    {
        if (n is 1)
            return 1;

        if (n is 0)
            return 0;

        return Fib(n - 1) + Fib(n - 2);
    }
}