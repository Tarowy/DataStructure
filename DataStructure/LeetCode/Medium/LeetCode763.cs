using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  763. 划分字母区间
///  https://leetcode.cn/problems/partition-labels/
/// </summary>
public class LeetCode763
{
    public IList<int> PartitionLabels(string s) {
        //记录每个字母出现的最远距离
        var furthestPos = new int[27];
        for (var i = 0; i < s.Length; ++i)
            furthestPos[s[i] - 'a'] = i;

        //s = "ababcbaca defegde hijhklij"
        //     858575878
        var result = new List<int>();
        int left = 0, right = 0;
        for (var i = 0; i < s.Length; ++i) {
            //right是区间内所有字母出现的最远位置的最大值
            right = Math.Max(right, furthestPos[s[i] - 'a']);
            if (i == right) {
                result.Add(right - left + 1);
                left = i + 1;
            }
        }

        return result;
    }
}