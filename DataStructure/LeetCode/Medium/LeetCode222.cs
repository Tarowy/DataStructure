using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  222. 完全二叉树的节点个数
///  https://leetcode.cn/problems/count-complete-tree-nodes/
/// </summary>
public class LeetCode222
{
    public int CountNodes(TreeNode root)
    {
        if (root == null)
            return 0;

        var left = root.left;
        var leftDepth = 0;
        var right = root.right;
        var rightDepth = 0;

        //求左深度
        while (left != null)
        {
            leftDepth++;
            left = left.left;
        }

        //求右深度
        while (right != null)
        {
            rightDepth++;
            right = right.right;
        }

        //如果左右深度相等，利用满二叉树
        if (leftDepth == rightDepth)
            return (2 << leftDepth) - 1;

        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }
}