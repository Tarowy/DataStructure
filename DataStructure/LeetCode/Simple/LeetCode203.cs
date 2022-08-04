using DataStructure.LeetCode.Medium;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 203. 移除链表元素
/// https://leetcode.cn/problems/remove-linked-list-elements/
/// </summary>
public class LeetCode203
{
    /// <summary>
    /// 输入：head = [1,2,6,3,4,5,6], val = 6
    /// 输出：[1,2,3,4,5]
    ///
    /// 输入：head = [7,7,7,7], val = 7
    /// 输出：[]
    /// </summary>
    /// <param name="head"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public ListNode RemoveElements(ListNode head, int val)
    {
        var listNode = new ListNode(0, head);
        var cur = listNode;

        while (cur.next is not null)
        {
            if (cur.next.val == val)
            {
                //改变next的指向后让cur留在原地不动，防止改变后的指向的值还是等于val
                cur.next = cur.next.next;
                continue;
            }

            cur = cur.next;
        }

        return listNode.next;
    }
}