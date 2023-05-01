using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  104. 二叉树的最大深度
///  https://leetcode.cn/problems/maximum-depth-of-binary-tree/
/// </summary>
public class LeetCode104
{
    public int MaxDepth(TreeNode root) {
        if (root == null)
            return 0;

        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}