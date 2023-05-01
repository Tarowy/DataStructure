//斐波那契数 （通常用 F(n) 表示）形成的序列称为 斐波那契数列 。该数列由 0 和 1 开始，后面的每一项数字都是前面两项数字的和。也就是： 
//
// 
//F(0) = 0，F(1) = 1
//F(n) = F(n - 1) + F(n - 2)，其中 n > 1
// 
//
// 给定 n ，请计算 F(n) 。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 2
//输出：1
//解释：F(2) = F(1) + F(0) = 1 + 0 = 1
// 
//
// 示例 2： 
//
// 
//输入：n = 3
//输出：2
//解释：F(3) = F(2) + F(1) = 1 + 1 = 2
// 
//
// 示例 3： 
//
// 
//输入：n = 4
//输出：3
//解释：F(4) = F(3) + F(2) = 2 + 1 = 3
// 
//
// 
//
// 提示： 
//
// 
// 0 <= n <= 30 
// 
//
// Related Topics 递归 记忆化搜索 数学 动态规划 👍 525 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;

public class Solution509
{
    //记忆化数组，每个位置存放对应索引的斐波那契值
    private readonly int[] _memoryArray;

    public Solution509()
    {
        _memoryArray = new int[31];
        Array.Fill(_memoryArray, -1);
        _memoryArray[0] = 0;
        _memoryArray[1] = 1;
    }

    public int Fib(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
                return 1;
        }

        var result = _memoryArray[n];

        if (result == -1)
        {
            var fib1 = _memoryArray[n - 1];
            if (fib1 == -1)
            {
                fib1 = Fib(n - 1);
                _memoryArray[n - 1] = fib1;
            }

            var fib2 = _memoryArray[n - 2];
            if (fib2 == -1)
            {
                fib2 = Fib(n - 2);
                _memoryArray[n - 2] = fib2;
            }
            
            result = fib1 + fib2;
            _memoryArray[n] = result;
        }
        
        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)