namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 283. 移动零
/// https://leetcode.cn/problems/move-zeroes/
/// </summary>
public class LeetCode283
{
    /// <summary>
    /// 输入: nums = [0,1,0,3,12]
    /// 输出: [1,3,12,0,0]
    /// </summary>
    /// <param name="nums"></param>
    public void MoveZeroes(int[] nums)
    {
        var pre = nums[0] == 0 ? -1 : 0;

        for (var cur = 1; cur < nums.Length; cur++)
        {
            if (nums[cur] != 0)
            {
                pre++;
                (nums[pre], nums[cur]) = (nums[cur], nums[pre]);
            }
        }
    }
}