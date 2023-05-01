using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  110. 平衡二叉树
///  https://leetcode.cn/problems/balanced-binary-tree/
/// </summary>
public class LeetCode110
{
    public bool IsBalanced(TreeNode root)
    {
        return GetHeight(root) != -1;
    }

    public int GetHeight(TreeNode root)
    {
        if (root == null) return 0;

        var leftHeight = GetHeight(root.left);
        if (leftHeight == -1) return -1;
        var rightHeight = GetHeight(root.right);
        if (rightHeight == -1) return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1) 
            return -1;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}