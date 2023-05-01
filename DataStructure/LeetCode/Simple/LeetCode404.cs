namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 
/// </summary>
public class LeetCode404
{
    public int SumOfLeftLeaves(TreeNode root)
    {
        var result = 0;
        if (root.left != null)
        {
            if (root.left.left == null && root.left.right == null)
                result += root.left.val;
            else
                result += SumOfLeftLeaves(root.left);
        }

        if (root.right != null)
        {
            result += SumOfLeftLeaves(root.right);
        }

        return result;
    }
}