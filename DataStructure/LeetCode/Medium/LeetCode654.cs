using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  654. 最大二叉树
///  https://leetcode.cn/problems/maximum-binary-tree/
/// </summary>
public class LeetCode654
{
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        return Build(nums, 0, nums.Length - 1);
    }
    
    TreeNode Build(int[] nums, int l, int r) {
        if (l > r)
            return null;

        if (l == r)
            return new TreeNode(nums[l]);

        var maxIndex = l;
        //寻找区间最大值的下标
        for (int i = l + 1; i <= r; ++i) {
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
        }

        var root = new TreeNode(nums[maxIndex]);
        root.left = Build(nums, l, maxIndex - 1);
        root.right = Build(nums, maxIndex + 1, r);

        return root;
    }
}