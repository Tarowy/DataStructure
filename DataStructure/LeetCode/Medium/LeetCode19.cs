namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 19. 删除链表的倒数第 N 个结点
/// https://leetcode.cn/problems/remove-nth-node-from-end-of-list/
/// </summary>
public class LeetCode19
{
    /// <summary>
    /// 输入：head = [1,2,3,4,5], n = 2
    /// 输出：[1,2,3,5]
    /// 输入：head = [1], n = 1
    /// 输出：[]
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        //如果传入的链表只有一个节点，或者要删除的节点就是链表的第一个节点，则直接返回头节点的下一个节点
        if (head.next is null || FindLayers(head, n) == n)
            return head.next;

        return head;
    }

    private int FindLayers(ListNode head, int layer)
    {
        //表示到达了最底层，当前层就是1
        if (head.next is null)
            return 1;

        //下一层的层数
        var nextLayer = FindLayers(head.next, layer);
        //下一层就是要删除的节点的层数
        if (nextLayer == layer)
            head.next = head.next.next;

        return nextLayer + 1;
    }
}