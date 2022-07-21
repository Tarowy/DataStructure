namespace DataStructure.LeetCode
{
    /// <summary>
    /// 21. 合并两个有序链表
    /// https://leetcode.cn/problems/merge-two-sorted-lists/
    /// </summary>
    public class LeetCode21
    {
        /// <summary>
        /// 输入：l1 = [1,2,4], l2 = [1,3,4]
        /// 输出：[1,1,2,3,4,4]
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            //如果其中一方为空就将另一方剩下的链表全部返回
            if (list1 is null || list2 is null)
            {
                return list1 ?? list2;
            }
            
            /*
             * 每次递归都是将更大value的链表原封不动传下去，
             * 这样return的时候每次会从比当前value大的值return回来，
             * 再将链表连接上，就形成从小到大的链表
             */
            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }

            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}