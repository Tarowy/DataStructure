namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 142. 环形链表 II
/// https://leetcode.cn/problems/linked-list-cycle-ii/
/// </summary>
public class LeetCode142
{
    public ListNode DetectCycle(ListNode head)
    {
        var fast = head;
        var slow = head;

        while (fast != null && fast.next != null)
        {
            //快指针一次走两格，慢指针一次走一格
            fast = fast.next.next;
            slow = slow.next;

            //快慢指针会在环里相遇
            if (!ReferenceEquals(fast, slow))
                continue;

            /*
            * 当快慢指针相遇，那么一个指针从相遇点出发，一个指针从头部出发，最后会在环的入口相遇
            * 相遇点到入口的距离和头部到入口的距离是一致的
            * https://www.bilibili.com/video/BV1if4y1d7ob
            */
            var index1 = slow;
            var index2 = head;
            while (!ReferenceEquals(index1, index2))
            {
                index1 = index1.next;
                index2 = index2.next;
            }

            return index1;
        }

        return null;
    }
}