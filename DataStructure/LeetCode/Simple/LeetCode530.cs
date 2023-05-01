using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  530. 二叉搜索树的最小绝对差
/// https://leetcode.cn/problems/minimum-absolute-difference-in-bst/
/// </summary>
public class LeetCode530
{
    private int minDiff = Int32.MaxValue;
    private TreeNode pre = null;
    
    void Traversal(TreeNode root) {
        if (root == null)
            return;

        //先遍历到最左边
        Traversal(root.left);

        if (pre != null)
            minDiff = Math.Min(minDiff, root.val - pre.val);

        pre = root;

        Traversal(root.right);
    }
    
    public int GetMinimumDifference(TreeNode root) {
        Traversal(root);
        return minDiff;
    }
}