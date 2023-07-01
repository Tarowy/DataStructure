using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  122. 买卖股票的最佳时机 II
///  https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/
/// </summary>
public class LeetCode122
{
    public int MaxProfit(int[] prices) {
        int result = 0;

        for (int i = 1; i < prices.Length; ++i) {
            //只添加前后一天差值为正利润时所得的利润
            result += Math.Max(prices[i] - prices[i - 1], 0);
        }

        return result;
    }
}