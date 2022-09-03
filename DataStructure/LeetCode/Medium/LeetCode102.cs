using System.Collections.Generic;
using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 102. 二叉树的层序遍历
/// https://leetcode.cn/problems/binary-tree-level-order-traversal/
/// </summary>
public class LeetCode102
{
    /// <summary>
    /// 输入：root = [3,9,20,null,null,15,7]
    /// 输出：[[3],[9,20],[15,7]]
    /// 输入：root = [1]
    /// 输出：[[1]]
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var ans = new List<IList<int>>();
        if (root is null)
            return ans;
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            //记录这一层的元素数量
            var listCount = queue.Count;
            var subAns = new List<int>();
            //将这一层的元素放到一个集合里
            for (var i = 0; i < listCount; i++)
            {
                //每出队一个元素就将子元素加入到队列中
                var node = queue.Dequeue();
                if (node.left is not null)
                    queue.Enqueue(node.left);
                if (node.right is not null)
                    queue.Enqueue(node.right);
                subAns.Add(node.val);
            }
            ans.Add(subAns);
        }
        return ans;
    }
}