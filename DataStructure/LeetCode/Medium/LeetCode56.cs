using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LeetCode.Medium;

public class LeetCode56
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (p1, p2) => p1[0].CompareTo(p2[0]));

        var result = new LinkedList<int[]>();

        //intervals = [[1,3],[2,6],[8,10],[15,18]]
        //intervals = [[1,4],[2,3]]
        result.AddLast(new[] { intervals[0][0], intervals[0][1] });
        for (var i = 1; i < intervals.Length; ++i)
        {
            //当前区间的左端点 小于 最后已加入到结果集区间的右端点，则更新结果集的右区间
            if (result.Last != null && (intervals[i][0] <= result.Last.Value[1]))
                //不能盲目更新，因为是求并集，所以需要确保右端点不会被缩小
                result.Last.Value[1] = Math.Max(intervals[i][1], result.Last.Value[1]);
            //否则 当前区间 与 最后已加入到结果集区间 不重叠，将该区间直接加入到结果集
            else
                result.AddLast(new[] { intervals[i][0], intervals[i][1] });
        }

        return result.ToArray();
    }
}