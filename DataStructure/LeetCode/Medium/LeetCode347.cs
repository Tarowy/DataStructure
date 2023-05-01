using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 347. 前 K 个高频元素
/// https://leetcode.cn/problems/top-k-frequent-elements/
/// </summary>
public class LeetCode347
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var statisticDict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (statisticDict.TryGetValue(num, out var count))
            {
                statisticDict[num] = count + 1;
                continue;
            }

            statisticDict.Add(num, 1);
        }

        var priorityQueue = new PriorityQueue<int, int>();
        foreach (var i in statisticDict)
        {
            priorityQueue.Enqueue(i.Key, i.Value);
            if (priorityQueue.Count > k)
                priorityQueue.Dequeue();
        }

        var result = new int[k];
        for (var i = k - 1; i >= 0; i--)
            result[i] = priorityQueue.Dequeue();

        return result;
    }
}