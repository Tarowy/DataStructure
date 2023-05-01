namespace DataStructure.LeetCode.Simple;

/// <summary>
///  112. 路径总和
///  https://leetcode.cn/problems/path-sum/
/// </summary>
public class LeetCode112
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;

        if (root.left == null && root.right == null) return targetSum - root.val == 0;

        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }
}