using System.Collections.Generic;
using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 107. 二叉树的层序遍历 II
/// https://leetcode.cn/problems/binary-tree-level-order-traversal-ii/
/// </summary>
public class LeetCode107
{
    /// <summary>
    /// 输入：root = [3,9,20,null,null,15,7]
    /// 输出：[[15,7],[9,20],[3]]
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
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

        ans.Reverse();
        return ans;
    }
}