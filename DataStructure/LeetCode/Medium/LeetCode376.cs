namespace DataStructure.LeetCode.Medium;

/// <summary>
///  376. 摆动序列
///  https://leetcode.cn/problems/wiggle-subsequence/
/// </summary>
public class LeetCode376
{
    public int WiggleMaxLength(int[] nums) {
        if (nums.Length <= 1) return nums.Length;

        int preDiff = 0;
        int curDiff = 0;
        int result = 1;

        for (int i = 0; i < nums.Length - 1; ++i) {
            //后一个数与当前数的差值是向上摆动还是向下摆动
            curDiff = nums[i + 1] - nums[i];
            if ((preDiff >= 0 && curDiff < 0) || (preDiff <= 0 && curDiff > 0)) {
                result++;
                /*
                 * 只有当前数字左右梯度不一样才会更新preDiff，
                 * 不进入该if条件，说明左右梯度一致，所以也没必要更新preDiff
                 */
                preDiff = curDiff;
            }
        }

        return result;
    }
}