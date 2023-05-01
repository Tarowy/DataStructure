namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 977. 有序数组的平方
/// https://leetcode.cn/problems/squares-of-a-sorted-array/
/// </summary>
public class LeetCode977
{
    public int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];
        //result数组的索引
        var k = nums.Length - 1;

        //nums数组的左端指针
        var l = 0;
        //nums数组的右端指针
        var r = nums.Length - 1;

        while (l <= r) {
            var lSquare = nums[l] * nums[l];
            var rSquare = nums[r] * nums[r];

            //做指针
            if (lSquare > rSquare) {
                result[k--] = lSquare;
                l++;
                continue;
            }

            result[k--] = rSquare;
            r--;
        }

        return result;
    }
}