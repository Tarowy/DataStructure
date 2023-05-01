namespace DataStructure.LeetCode.Simple;

/// <summary>
///  102. 二叉树的层序遍历
///  https://leetcode.cn/problems/binary-tree-level-order-traversal/
/// </summary>
public class LeetCode226
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return root;

        (root.left, root.right) = (root.right, root.left);
        root.left = InvertTree(root.left);
        root.right = InvertTree(root.right);

        return root;
    }
}