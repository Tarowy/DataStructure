using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 322. 零钱兑换
/// https://leetcode.cn/problems/coin-change/
/// </summary>
public class LeetCode322
{
    private List<int> _ans = new();

    /// <summary>
    /// 输入：coins = [1, 2, 5], amount = 11
    /// 输出：3
    /// 解释：11 = 5 + 5 + 1
    /// 输入：coins = [2], amount = 3
    /// 输出：-1
    /// 示例 3：
    /// 输入：coins = [1], amount = 0
    /// 输出：0
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int CoinChange(int[] coins, int amount)
    {
        if (amount is 0)
            return 0;

        Array.Sort(coins);
        var ans = FindCoinCombination(coins, amount);
        foreach (var i in _ans)
            Console.Write($"{i} ");

        return ans;
    }

    private int FindCoinCombination(IReadOnlyList<int> coins, int amount)
    {
        //[3,5] 11  3 3 5
        for (var i = coins.Count - 1; i >= 0; i--)
        {
            if (amount < coins[i])
            {
                continue;
            }

            //得到余量，余量为0说明所有层递归都满足了条件
            var remain = amount - coins[i];
            if (remain is 0)
            {
                Console.WriteLine(coins[i]);
                return 1;
            }

            //如果下一层递归返回0，说明该层和下一层递归都满足了条件，加入到结果集中
            var result = FindCoinCombination(coins, amount - coins[i]);
            if (result is not -1)
            {
                Console.WriteLine(coins[i]);
                return result + 1;
            }
        }

        return -1;
    }
}