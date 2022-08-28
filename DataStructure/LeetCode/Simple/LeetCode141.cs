using DataStructure.LeetCode.Medium;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 141. 环形链表
/// https://leetcode.cn/problems/linked-list-cycle/
/// </summary>
public class LeetCode141
{
    /// <summary>
    /// 输入：head = [3,2,0,-4], pos = 1
    /// 输出：true
    /// 解释：链表中有一个环，其尾部连接到第二个节点。
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycle(ListNode head)
    {
        ListNode fast = head, low = head;
        while (fast?.next != null)
        {
            //快指针一次移动两步
            fast = fast.next.next;

            //两指针相遇则有环
            if (fast == low)
                return true;

            //慢指针一次移动一步
            low = low.next;
        }

        return false;
    }
}