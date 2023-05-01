using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 349. 两个数组的交集
/// https://leetcode.cn/problems/intersection-of-two-arrays/submissions/
/// </summary>
public class LeetCode349
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var resultSet = new HashSet<int>();
        var numSet = new HashSet<int>(nums2);

        foreach (var i in nums1)
        {
            if (numSet.Contains(i))
                resultSet.Add(i);
        }

        return resultSet.ToArray();
    }
}