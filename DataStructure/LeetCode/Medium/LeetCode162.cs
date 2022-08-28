namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 162. 寻找峰值
/// https://leetcode.cn/problems/find-peak-element/
/// </summary>
public class LeetCode162
{
    /// <summary>
    /// 输入：nums = [1,2,3,1]
    /// 输出：2
    /// 解释：3 是峰值元素，你的函数应该返回其索引 2。
    ///
    /// 输入：nums = [1,2,1,3,5,6,4]
    /// 输出：1 或 5
    /// 解释：你的函数可以返回索引 1，其峰值元素为 2；
    /// 或者返回索引 5， 其峰值元素为 6。
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindPeakElement(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;
        var mid = 0;
        
        while (l < r)
        {
            mid = l + (r - l) / 2;
            
            //如果mid大于mid的下一个元素，说明峰值在左边，改变r的值
            if (nums[mid] > nums[mid + 1])
                r = mid;
            //否则峰值在右边，改变l的值
            else
                l = mid + 1;
        }

        return l;
    }
}