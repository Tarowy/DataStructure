using DataStructure.LeetCode.Medium;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 206. 反转链表
/// https://leetcode.cn/problems/reverse-linked-list/
/// </summary>
public class LeetCode206
{
    /// <summary>
    /// 输入：head = [1,2,3,4,5]
    /// 输出：[5,4,3,2,1]
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode ReverseList(ListNode head)
    {
        if (head?.next is null)
            return head;

        //每次返回的last都是链表的最后一个元素
        var last = ReverseList(head.next);
        //将下一个元素的下一个指针指向自己
        head.next.next = head;
        head.next = null;

        return last;
    }
}