namespace DataStructure.LeetCode.Medium
{
    /// <summary>
    /// 2. 两数相加
    /// https://leetcode.cn/problems/add-two-numbers/
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LeetCode2
    {
        // public static void Main(string[] args)
        // {
        //     var listNode1 = new ListNode(9).next = new ListNode(9);
        //     var listNode2 = new ListNode(9);
        //     new LeetCode2().AddTwoNumbers(listNode1, listNode2);
        // }
        
        /*
         * 输入：l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
         * 输出：[8,9,9,9,0,0,0,1]
         * [9,9,0] 
         * [9,0,0]
         * [8,0,1]
         */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var total = l1.val + l2.val;
            var next = total / 10;
            var res = new ListNode(total % 10);
            /*
             * 其中一个链表的下一个节点如果是null但另一条链表还有节点，
             * 且next这个进位标记不为0，就得新建一个值为0的下一节点，
             * 再将next附加到第一条链表上
             */
            if (l1.next is not null || l2.next is not null || next != 0)
            {
                if (l1.next is null)
                    l1.next = new ListNode();

                if (l2.next is null)
                    l2.next = new ListNode();

                if (next != 0)
                {
                    //将next的值保留到下一次递归
                    l1.next.val += next;
                }

                res.next = AddTwoNumbers(l1.next, l2.next);
            }

            return res;
        }
    }
}