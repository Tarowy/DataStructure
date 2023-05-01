using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  538. 把二叉搜索树转换为累加树
///  https://leetcode.cn/problems/convert-bst-to-greater-tree/
/// </summary>
public class LeetCode538
{
    private TreeNode pre;
    public TreeNode ConvertBST(TreeNode root) {
        if (root == null) return null;

        root.right = ConvertBST(root.right);

        if (pre != null) root.val += pre.val;
        pre = root;

        root.left = ConvertBST(root.left);

        return root;
    }
}