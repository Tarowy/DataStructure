using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 108. 将有序数组转换为二叉搜索树
/// https://leetcode.cn/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class LeetCode108
{
    public TreeNode SortedArrayToBST(int[] nums) {
        return Build(nums, 0, nums.Length - 1);
    }
    
    TreeNode Build(IReadOnlyList<int> nums, int left, int right) {
        if (left < 0 || right >= nums.Count || left > right)
            return null;
        if (left == right)
            return new TreeNode(nums[left]);

        var temp = right - left;
        //temp%2 是确保当 temp/2 是奇数时，mid会落在较大的那个数上
        var mid = left + temp / 2 + temp % 2;

        var root = new TreeNode(nums[mid])
        {
            left = Build(nums, left, mid - 1),
            right = Build(nums, mid + 1, right)
        };

        return root;
    }
}