using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  454. 四数相加 II
///  https://leetcode.cn/problems/4sum-ii/
/// </summary>
public class LeetCode454
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var result = new Dictionary<int, int>();
        var count = 0;

        //将所有 nums1和nums2中的元素两两相加的结果 增加其在map中对应的次数
        foreach (var num1 in nums1)
        foreach (var num2 in nums2)
            result[num1 + num2] = result.TryGetValue(num1 + num2, out var resultCount) ? resultCount + 1 : 1;

        //从result_map中查找能和 nums3和nums4两两相加的结果 等于0的 数值对应的次数
        foreach (var num3 in nums3)
        foreach (var num4 in nums4)
            if (result.TryGetValue(0 - (num3 + num4), out var resultCount))
                count += resultCount;

        return count;
    }
}