using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 933. 最近的请求次数
/// https://leetcode.cn/problems/number-of-recent-calls/
/// </summary>
public class LeetCode933
{
    public class RecentCounter
    {
        private Queue<int> _queue = new();

        public RecentCounter()
        {
        }

        /// <summary>
        /// 输入：
        /// ["RecentCounter", "ping", "ping", "ping", "ping"]
        /// [[], [1], [100], [3001], [3002]]
        /// 输出：
        /// [null, 1, 2, 3, 3]
        /// 
        /// 解释：
        /// RecentCounter recentCounter = new RecentCounter();
        /// recentCounter.ping(1);     // requests = [1]，范围是 [-2999,1]，返回 1
        /// recentCounter.ping(100);   // requests = [1, 100]，范围是 [-2900,100]，返回 2
        /// recentCounter.ping(3001);  // requests = [1, 100, 3001]，范围是 [1,3001]，返回 3
        /// recentCounter.ping(3002);  // requests = [1, 100, 3001, 3002]，范围是 [2,3002]，返回 3
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Ping(int t)
        {
            _queue.Enqueue(t);

            //如果是负数就直接不管
            if (t - 3000 <= 0)
                return _queue.Count;

            while (_queue.Peek() < t - 3000)
                _queue.Dequeue();

            return _queue.Count;
        }
    }
}