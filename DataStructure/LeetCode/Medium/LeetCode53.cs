using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 53. 最大子数组和
/// https://leetcode.cn/problems/maximum-subarray/
/// </summary>
public class LeetCode53
{
    /// <summary>
    /// 输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
    /// 输出：6
    /// 解释：连续子数组[4,-1,2,1] 的和最大，为6 。
    /// 示例 2：
    /// 输入：nums = [1]
    /// 输出：1
    /// 示例 3：
    /// 输入：nums = [5,4,-1,7,8]
    /// 输出：23
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArray(int[] nums)
    {
        return GetMaxSubArray(nums, 0, nums.Length - 1);
    }

    private int GetMaxSubArray(int[] nums, int left, int right)
    {
        if (left == right)
            return nums[left];

        var mid = left + (right - left) / 2;
        //从mid开始向左依次计算和，选出连续子数组的最大值
        var leftMax = GetMaxSubArray(nums, left, mid);
        //从mid+1开始向右依次计算和，选出连续子数组的最大值
        var rightMax = GetMaxSubArray(nums, mid + 1, right);
        //左右两边的连续子数组连在一起的和
        var crossMax = GetCrossMax(nums, left, right);

        /*
         * 从 左边的连续子数组和的最大值
         *   右边连续子数组的和的最大值
         *   左右子数组合并的和的最大值
         * 中筛选出最大值
         */
        var tempMax = leftMax > rightMax ? leftMax : rightMax;
        return tempMax > crossMax ? tempMax : crossMax;
    }

    private int GetCrossMax(int[] nums, int left, int right)
    {
        var mid = left + (right - left) / 2;

        //从中间向两边扩散，分别得出左边和右边的连续数组最大值
        int leftSum = nums[mid], leftMax = leftSum;
        for (var i = mid - 1; i >= left; i--)
        {
            leftSum += nums[i];
            leftMax = Math.Max(leftMax, leftSum);
        }

        int rightSum = nums[mid + 1], rightMax = rightSum;
        for (var i = mid + 2; i <= right; i++)
        {
            rightSum += nums[i];
            rightMax = Math.Max(rightSum, rightMax);
        }

        return leftMax + rightMax;
    }
}