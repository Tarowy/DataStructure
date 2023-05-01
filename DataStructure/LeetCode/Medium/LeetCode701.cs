using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  701. 二叉搜索树中的插入操作
///  https://leetcode.cn/problems/insert-into-a-binary-search-tree/
/// </summary>
public class LeetCode701
{
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null)
            return new TreeNode(val);

        if (val < root.val)
            root.left = InsertIntoBST(root.left,val);

        if (val > root.val)
            root.right = InsertIntoBST(root.right,val);

        return root;
    }
}