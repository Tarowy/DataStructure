namespace DataStructure.LeetCode.Medium;

/// <summary>
///  707. 设计链表
///  https://leetcode.cn/problems/design-linked-list/
/// </summary>
public class LeetCode707
{
    
}

public class MyLinkedList {
    private int _size = 0;
    private ListNode dummyHead;

    public MyLinkedList()
    {
        _size = 0;
        dummyHead = new ListNode();
    }
    
    public int Get(int index) {
        if (index < 0 || index > _size - 1)
            return -1;

        var current = dummyHead.next;
        //找到第index个节点
        while (index-- != 0)
            current = current.next;

        return current.val;
    }
    
    public void AddAtHead(int val) {
        var newHead = new ListNode(val, dummyHead.next);
        dummyHead.next = newHead;
        _size++;
    }
    
    public void AddAtTail(int val) {
        var newNode = new ListNode(val);
        var current = dummyHead;

        while (current.next != null)
            current = current.next;
        current.next = newNode;
        _size++;
    }
    
    public void AddAtIndex(int index, int val) {
        if(index > _size) return;
        if(index < 0) index = 0;

        var current = dummyHead;

        //找到第index个节点的前一个节点
        while (index-- != 0)
            current = current.next;
        var newNode = new ListNode(val, current.next);
        current.next = newNode;
        _size++;
    }
    
    public void DeleteAtIndex(int index) {
        if (index >= _size || index < 0)
            return;

        var current = dummyHead;

        //找到第index个节点的前一个节点
        while (index-- != 0)
            current = current.next;
        
        var temp = current.next;
        current.next = current.next.next;
        _size--;
    }
}