namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 24. 两两交换链表中的节点
/// https://leetcode.cn/problems/swap-nodes-in-pairs/
/// </summary>
public class LeetCode24
{
    /// <summary>
    /// 输入：head = [1,2,3,4,5]
    /// 输出：[2,1,4,3,5]
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode SwapPairs(ListNode head)
    {
        //虚拟头节点指向head 0,[1,2,3,4,5]
        var virtualHead = new ListNode(0, head);

        var pre = virtualHead;
        var cur = head;

        //当链表长度为奇数时，cur.next为空，偶数时cur本身为空
        while (cur is not null && cur.next is not null)
        {
            var curNext = cur.next;

            pre.next = curNext;
            cur.next = curNext.next;
            curNext.next = cur;

            //0,[2,1,3,4,5]
            pre = cur;
            cur = cur.next;
        }

        return virtualHead.next;
    }
}