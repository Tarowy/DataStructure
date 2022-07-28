using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 15. 三数之和
/// https://leetcode.cn/problems/3sum/
/// </summary>
public class LeetCode15
{
    /// <summary>
    /// 输入：nums = [-1,0,1,2,-1,-4]
    /// 输出：[[-1,-1,2],[-1,0,1]]
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var ans = new List<IList<int>>();

        Array.Sort(nums); // -4,-1,-1,0,1,2
        for (var i = 0; i < nums.Length; i++)
        {
            //去除重复的数，如果该数和前一个数重复就直接跳过
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            var target = 0 - nums[i];
            /*
             * 只需遍历i之后的数，如果从0开始遍历，在i逐渐增加的过程中，
             * 会由于三个数被重复计算而得到和之前一样的结果
             */
            var l = i + 1;
            var r = nums.Length - 1;

            //一旦l,r相遇
            while (l < r)
            {
                //符合条件就加入数组中，但是要注意去重
                if (nums[l] + nums[r] == target)
                {
                    //跳过左边连续重复的数
                    while (l < r && nums[l] == nums[l + 1])
                        l++;

                    //跳过右边连续重复的数
                    while (l < r && nums[r] == nums[r - 1])
                        r--;

                    ans.Add(new List<int> { nums[l], nums[r], nums[i] });
                    l++;
                    r--;
                }
                //两数相加大于target就需要将两数相加的和缩小，由于是从小到大排列，所以让右指针--
                else if (nums[l] + nums[r] > target)
                    r--;
                //两数相加小于target就需要将两数相加的和扩大，由于是从小到大排列，所以让左指针++
                else
                    l++;
            }
        }

        return ans;
    }
}