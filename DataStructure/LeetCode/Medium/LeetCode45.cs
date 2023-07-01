using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  45. 跳跃游戏 II
/// https://leetcode.cn/problems/jump-game-ii/
/// </summary>
public class LeetCode45
{
    public int Jump(int[] nums) {
        if (nums.Length == 1)
            return 0;
        int result = 0;
        //当前元素的最大覆盖范围
        int curDistance = 0;
        //下一步的元素最大覆盖范围
        int nextDistance = 0;

        for (int i = 0; i < nums.Length; ++i) {
            //计算最大覆盖范围
            nextDistance = Math.Max(i + nums[i], nextDistance);
            //说明在这之前的 元素覆盖范围 都没有超过 i这个下标，此时需要更新覆盖范围
            if (i == curDistance) {
                //覆盖仍未到达终点，扩大覆盖范围
                if (curDistance < nums.Length - 1) {
                    result++;
                    //更新覆盖范围
                    curDistance = nextDistance;
                    //判断是否覆盖到元素末尾
                    if (curDistance >= nums.Length - 1)
                        break;
                }else break;
            }
        }

        return result;
    }
}