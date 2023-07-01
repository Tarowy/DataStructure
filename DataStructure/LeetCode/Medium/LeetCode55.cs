using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  55. 跳跃游戏
///  https://leetcode.cn/problems/jump-game/
/// </summary>
public class LeetCode55
{
    public bool CanJump(int[] nums)
    {
        if (nums.Length == 1)
            return true;

        var cover = 0;
        for (var i = 0; i <= cover; i++)
        {
            //如果遇到比cover跳的更远的值，则更新cover
            cover = Math.Max(i + nums[i], cover);
            if (cover >= nums.Length - 1)
                return true;
        }

        return false;
    }
}