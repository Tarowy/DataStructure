using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 938. 二叉搜索树的范围和
/// https://leetcode.cn/problems/range-sum-of-bst/
/// </summary>
public class LeetCode938
{
    /// <summary>
    /// 输入：root = [10,5,15,3,7,null,18], low = 7, high = 15
    /// 输出：32
    /// </summary>
    /// <param name="root"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        if (root is null)
            return 0;

        //计算左子树的总和
        var leftSum =  RangeSumBST(root.left, low, high);
        //计算右子树的总和
        var rightSum =  RangeSumBST(root.right, low, high);

        //如果自己也满足条件就将自己也加上
        if (low <= root.val && root.val <=high)
            return root.val + leftSum + rightSum;
        else
            return leftSum + rightSum;
    }
}