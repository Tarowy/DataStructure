using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  406. 根据身高重建队列
/// https://leetcode.cn/problems/queue-reconstruction-by-height/
/// </summary>
public class LeetCode406
{
    public int[][] ReconstructQueue(int[][] people)
    {
        Array.Sort(people, (p1, p2) => p1[0] == p2[0] ? p1[1].CompareTo(p2[1]) : p2[0].CompareTo(p1[0]));
        //[7,0][7,1][6,1][5,0][5,2][4,4]
        
        /*
         * 每次遍历的身高都是小于等于之前的元素的，而且将比它小的身高插入到它之前不会影响元素的第二个值代表的含义
         * 第二个元素代表有多少个元素比大于等于它的身高，所以插入的时候插入到元素对应的下标处即可
         */
        var result = new List<int[]>();
        foreach (var person in people)
            result.Insert(person[1], person);

        return result.ToArray();
    }
}