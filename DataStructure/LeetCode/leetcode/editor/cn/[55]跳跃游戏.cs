//给定一个非负整数数组 nums ，你最初位于数组的 第一个下标 。 
//
// 数组中的每个元素代表你在该位置可以跳跃的最大长度。 
//
// 判断你是否能够到达最后一个下标。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [2,3,1,1,4]
//输出：true
//解释：可以先跳 1 步，从下标 0 到达下标 1, 然后再从下标 1 跳 3 步到达最后一个下标。
// 
//
// 示例 2： 
//
// 
//输入：nums = [3,2,1,0,4]
//输出：false
//解释：无论怎样，总会到达下标为 3 的位置。但该下标的最大跳跃长度是 0 ， 所以永远不可能到达最后一个下标。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 3 * 10⁴ 
// 0 <= nums[i] <= 10⁵ 
// 
//
// Related Topics 贪心 数组 动态规划 👍 1989 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

public class Solution55
{
    public bool CanJump(int[] nums)
    {
        var (cur, i) = (nums[0], 1);
        for (; cur != 0 && i < nums.Length; i++)
        {
            //每遍历一步就减一
            // cur--;
            
            /*
             * 如果该数组位置的数大于当前拥有的数
             * 就将当前拥有的数换成该数组位置的数
             */
            // if (cur < nums[i])
            //     cur = nums[i];

            cur = --cur < nums[i] ? nums[i] : cur;
        }

        //如果cur提前归零，则i必定没有到达终点，否则i必定已经走完数组
        return i == nums.Length;
    }
}
//leetcode submit region end(Prohibit modification and deletion)