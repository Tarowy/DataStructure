using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  235. 二叉搜索树的最近公共祖先
///  https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-search-tree/
/// </summary>
public class LeetCode235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return null;

        if ((root.val >= p.val && root.val <= q.val) || (root.val >= q.val && root.val <= p.val))
            return root;

        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if (left == null) return right;
        else if (right == null) return left;
        return null;
    }
}