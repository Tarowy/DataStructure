using System.Collections.Generic;
using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  513. 找树左下角的值
///  https://leetcode.cn/problems/find-bottom-left-tree-value/
/// </summary>
public class LeetCode513
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            root = queue.Dequeue();

            if (root.right!=null)
                queue.Enqueue(root.right);
            if (root.left!=null)
                queue.Enqueue(root.left);
        }

        return root.val;
    }
}