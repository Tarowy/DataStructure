using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  111. 二叉树的最小深度
///  https://leetcode.cn/problems/minimum-depth-of-binary-tree/
/// </summary>
public class LeetCode111
{
    public int MinDepth(TreeNode root) {
        if (root == null)
            return 0;

        //以下两种情况只对单侧使用递归
        if (root.left == null && root.right != null)
            return MinDepth(root.right) + 1;
        
        if (root.left != null && root.right == null)
            return MinDepth(root.left) + 1;

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }
}