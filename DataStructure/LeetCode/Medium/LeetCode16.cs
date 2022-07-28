using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 16. 最接近的三数之和
/// https://leetcode.cn/problems/3sum-closest/
/// </summary>
public class LeetCode16
{
    /// <summary>
    /// 输入：nums = [-1,2,1,-4], target = 1
    /// 输出：2
    /// 解释：与 target 最接近的和是 2 (-1 + 2 + 1 = 2) 。
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int ThreeSumClosest(int[] nums, int target)
    {
        var ans = nums[0] + nums[1] + nums[2];
        var length = nums.Length;
        Array.Sort(nums); //-4,-1,1,2  -5,-5,-4,0,0,3,3,4,5 -2

        // ans = nums[i] + nums[l] + nums[length - 1]
        for (var i = 0; i < length; i++)
        {
            var l = i + 1;
            var r = length - 1;
            while (l < r)
            {
                var sum = nums[i] + nums[l] + nums[r];
                if (sum == target)
                {
                    return sum;
                }
                //将ans替换成最接近target的那个值
                ans = Math.Abs(target - ans) > Math.Abs(target - sum) ? sum : ans;
                //三数之和小于目标值，就要将三数之和的值扩大，即l++
                if (sum < target)
                {
                    l++;
                    continue;
                }
                //三数之和大于目标值，就要将三数之和的值缩小，即r--
                r--;
            }
        }

        return ans;
    }
}