using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  98. 验证二叉搜索树
///  https://leetcode.cn/problems/validate-binary-search-tree/
/// </summary>
public class LeetCode98
{
    private TreeNode pre = null;
    
    public bool IsValidBST(TreeNode root) {
        if (root == null)
            return true;

        bool leftValid = IsValidBST(root.left);

        if (pre == null || root.val > pre.val) {
            pre = root;
        } else return false;

        bool rightValid = IsValidBST(root.right);

        return leftValid && rightValid;
    }
}