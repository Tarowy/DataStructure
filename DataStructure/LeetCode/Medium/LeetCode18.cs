using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 18. 四数之和
/// https://leetcode.cn/problems/4sum/
/// </summary>
public class LeetCode18
{
    /// <summary>
    /// 输入：nums = [1,0,-1,0,-2,2], target = 0
    /// 输出：[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
    /// 
    /// 输入：nums = [2,2,2,2,2], target = 8
    /// 输出：[[2,2,2,2]]
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var ans = new List<IList<int>>();
        Array.Sort(nums); //-2,-1,0,0,1,2

        //应对LeetCode的刁钻用例，如果最小的数都即将溢出，则结果也必定溢出
        if (nums[0] >= 1000000000)
            return ans;

        //剩下的位置已经不足3位时就不必再循环
        for (var i = 0; i <= nums.Length - 4; i++)
        {
            //去除连续重复的数
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            //剩下的位置不足2位时就不必再循环
            for (var j = i + 1; j <= nums.Length - 3; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                    continue;

                var t = target - nums[i] - nums[j];
                var l = j + 1;
                var r = nums.Length - 1;
                while (l < r)
                {
                    if (nums[l] + nums[r] == t)
                    {
                        while (l < r && nums[l] == nums[l + 1])
                            l++;
                        while (l < r && nums[r] == nums[r - 1])
                            r--;

                        var num = (long)nums[i] + nums[j] + nums[l] + nums[r];
                        if (num is > int.MaxValue or < int.MinValue)
                            break;

                        ans.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                        l++;
                        r--;
                    }
                    else if (nums[l] + nums[r] < t)
                        l++;
                    else
                        r--;
                }
            }
        }

        return ans;
    }
}