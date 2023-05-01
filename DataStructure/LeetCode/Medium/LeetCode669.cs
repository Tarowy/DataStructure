using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  669. 修剪二叉搜索树
///  https://leetcode.cn/problems/trim-a-binary-search-tree/
/// </summary>
public class LeetCode669
{
    public TreeNode TrimBST(TreeNode root, int low, int high) {
        if (root == null)
            return null;

        //所有左子树都小于根节点，根节点比low还小，那么左子树也都比low小，舍弃左子树
        if (root.val < low)
            return TrimBST(root.right,low,high);

        //所有右子树都大于根节点，根节点比high还大，那么右子树也都比high大，舍弃右子树
        if (root.val > high)
            return TrimBST(root.left,low,high);

        root.left = TrimBST(root.left, low, high);
        root.right = TrimBST(root.right, low, high);

        return root;
    }
}