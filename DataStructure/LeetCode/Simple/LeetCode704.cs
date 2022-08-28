namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 704. 二分查找
/// https://leetcode.cn/problems/binary-search/
/// </summary>
public class LeetCode704
{
    /// <summary>
    /// 输入: nums = [-1,0,3,5,9,12], target = 9
    /// 输出: 4
    /// 解释: 9 出现在 nums 中并且下标为 4
    ///
    /// 输入: nums = [-1,0,3,5,9,12], target = 2
    /// 输出: -1
    /// 解释: 2 不存在 nums 中因此返回 -1
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            //防止溢出
            var mid = l + (r - l) / 2;

            //建议使用正常写法，这种写法有点耗时间和内存
            switch (target.CompareTo(nums[mid]))
            {
                case > 0: l = mid + 1;
                    break;
                case < 0: r = mid - 1;
                    break;
                default : return mid ; 
            }
        }

        return -1;
    }
}