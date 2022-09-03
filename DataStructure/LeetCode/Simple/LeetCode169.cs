using System.Linq;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 169. 多数元素
/// https://leetcode.cn/problems/majority-element/
/// </summary>
public class LeetCode169
{
    /// <summary>
    /// 输入：nums = [3,2,3]
    /// 输出：3
    /// 示例 2：
    /// 输入：nums = [2,2,1,1,1,2,2]
    /// 输出：2
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement(int[] nums)
    {
        return GetMajorityElement(nums, 0, nums.Length - 1);
    }

    /// <summary>
    /// 使用分治法来寻找多数元素
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private int GetMajorityElement(int[] nums, int left, int right)
    {
        if (left == right)
            return nums[left];

        var mid = left + (right - left) / 2;
        //得到左子数组的多数元素
        var leftMajority = GetMajorityElement(nums, left, mid);
        //得到右子数组的多数元素
        var rightMajority = GetMajorityElement(nums, mid + 1, right);

        //如果左右子数组的多数元素一样就返回该多数元素
        if (leftMajority == rightMajority)
            return leftMajority;

        int leftCount = 0, rightCount = 0;
        //左右子数组的多数元素不一样就从left遍历到right看看到底哪个数更多
        for (var i = left; i <= right; i++)
        {
            if (nums[i] == leftMajority)
                leftCount++;
            else if (nums[i] == rightMajority)
                rightCount++;
        }

        return leftCount > rightCount ? leftMajority : rightMajority;
    }
}