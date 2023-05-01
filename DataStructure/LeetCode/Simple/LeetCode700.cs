namespace DataStructure.LeetCode.Simple;

/// <summary>
///  700. 二叉搜索树中的搜索
///  https://leetcode.cn/problems/search-in-a-binary-search-tree/
/// </summary>
public class LeetCode700
{
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null)
            return null;

        if (root.val > val)
            return SearchBST(root.left, val);
        if (root.val < val)
            return SearchBST(root.right, val);

        return root;
    }
}