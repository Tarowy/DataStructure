namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 101. 对称二叉树
/// https://leetcode.cn/problems/symmetric-tree/
/// </summary>
public class LeetCode101
{
    public bool IsSymmetric(TreeNode root)
    {
        return root != null && TreeCompare(root.left, root.right);
    }

    public static bool TreeCompare(TreeNode left, TreeNode right)
    {
        if (left == null && right == null)
            return true;
        else if (left == null && right != null)
            return false;
        else if (left != null && right == null)
            return false;
        else if (left.val != right.val)
            return false;

        var outside = TreeCompare(left.left, right.right);
        var inside = TreeCompare(left.right, right.left);
        return outside && inside;
    }
}