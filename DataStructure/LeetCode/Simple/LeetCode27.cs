namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 27. 移除元素
/// https://leetcode.cn/problems/remove-element/
/// </summary>
public class LeetCode27
{
    /// <summary>
    /// 输入：nums = [3,2,2,3], val = 3
    /// 输出：2, nums = [2,2]
    /// 解释：函数应该返回新的长度 2, 并且 nums 中的前两个元素均为 2。
    /// 你不需要考虑数组中超出新长度后面的元素。
    /// 例如，函数返回的新长度为 2 ，而 nums = [2,2,3,3] 或 nums = [2,2,0,0]，也会被视作正确答案。
    /// 
    /// 输入：nums = [0,1,2,2,3,0,4,2], val = 2
    /// 输出：5, nums = [0,1,4,0,3]
    /// 解释：函数应该返回新的长度 5, 并且 nums 中的前五个元素为 0, 1, 3, 0, 4。
    /// 注意这五个元素可为任意顺序。你不需要考虑数组中超出新长度后面的元素。
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;

        /*
         * 如果第一个数就是val则需要将pre设为-1，这样就能将非val值交换到第一位
         * 要是直接设为0，若第一位数就是val会被跳过
         */
        var pre = nums[0] == val ? -1 : 0;
        var cur = 1;

        for (; cur < nums.Length; cur++)
        {
            //[0,1,2,2,3,0,4,2] 2
            // [pre] [2,3,3,3] 3
            /*
             * 当cur不是指定值时，cur和pre一起移动，
             * cur是指定值时，pre原地不动，直到遇到下一个非val值的时候就交换两者的值
             */
            if (nums[cur] == val) continue;
            pre++;
            if (nums[pre] == val)
                (nums[pre], nums[cur]) = (nums[cur], nums[pre]);
        }

        return pre + 1;
    }
}