namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 26. 删除有序数组中的重复项
/// https://leetcode.cn/problems/remove-duplicates-from-sorted-array/
/// </summary>
public class LeetCode26
{
    /// <summary>
    /// 输入：nums = [0,0,1,1,1,2,2,3,3,4]
    /// 输出：5, nums = [0,1,2,3,4]
    /// 解释：函数应该返回新的长度 5 ，并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。不需要考虑数组中超出新长度后面的元素
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        int pre = 0, cur = 1;
        for (; cur < nums.Length; cur++)
        {
            //[0,1,2,3,4,0,2,1,3,1]
            if (nums[pre] != nums[cur])
            {
                (nums[pre + 1], nums[cur]) = (nums[cur], nums[pre + 1]);
                pre++;
            }
        }

        return pre + 1;
    }
}