using System;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 881. 救生艇
/// https://leetcode.cn/problems/boats-to-save-people/
/// </summary>
public class LeetCode881
{
    /// <summary>
    /// 输入：people = [1,2], limit = 3
    /// 输出：1
    /// 解释：1 艘船载 (1, 2)
    ///
    /// 输入：people = [3,2,2,1], limit = 3
    /// 输出：3
    /// 解释：3 艘船分别载 (1, 2), (2) 和 (3)
    ///
    /// 输入：people = [3,5,3,4], limit = 5
    /// 输出：4
    /// 解释：4 艘船分别载 (3), (3), (4), (5)
    /// </summary>
    /// <param name="people"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public int NumRescueBoats(int[] people, int limit)
    {
        //[1,2,2,3] 3
        Array.Sort(people);
        
        var ans = 0;
        var head = 0;
        var tail = people.Length - 1;

        while (head <= tail)
        {
            //船上能同时装下首尾指针的两个人，直接加入到结果中去
            if (people[head] + people[tail] <= limit || head == tail)
            {
                ans++;
                head++;
                tail--;
                continue;
            }

            //没法同时装下首尾指针的两个人，就只装尾指针的人
            ans++;
            tail--;
        }

        return ans;
    }
}