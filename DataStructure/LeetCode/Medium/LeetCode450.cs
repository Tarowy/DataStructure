using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  450. 删除二叉搜索树中的节点
/// https://leetcode.cn/problems/delete-node-in-a-bst/
/// </summary>
public class LeetCode450
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;

        if (key < root.val) root.left = DeleteNode(root.left, key);

        if (key > root.val) root.right = DeleteNode(root.right, key);

        if (root.val == key)
        {
            //值匹配，开始删除该节点
            if (root.left == null && root.right == null) return null;
            
            if (root.left == null) return root.right;
            
            if (root.right == null) return root.left;

            //左右孩子都不为空
            TreeNode tempRight = root.right;

            /*
             * 将该节点的左子树挂到右子树的最左边
             * 因为左子树的所有节点必定小于右子树的所有元素
             * 而右子树最左边的元素就是右子树中的最小元素
             * 挂到右子树的最小元素上可以保证二叉树的性质
             */
            TreeNode temp = tempRight;
            while (temp.left != null)
                temp = temp.left;

            temp.left = root.left;
            return tempRight;
        }

        return root;
    }
}