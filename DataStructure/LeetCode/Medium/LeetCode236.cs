using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  236. 二叉树的最近公共祖先
///  https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-tree/
/// </summary>
public class LeetCode236
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return null;

        if (root == p || root == q)
            return root;

        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if (left == null)
            return right;
        else if (right == null)
            return left;
        else
            return root;
    }
}