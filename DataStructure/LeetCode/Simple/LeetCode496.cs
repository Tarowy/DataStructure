using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 496. 下一个更大元素 I
/// https://leetcode.cn/problems/next-greater-element-i/
/// </summary>
public class LeetCode496
{
    /// <summary>
    /// 输入：nums1 = [4,1,2], nums2 = [1,3,4,2].
    /// 输出：[-1,3,-1]
    /// 解释：nums1 中每个值的下一个更大元素如下所述：
    /// - 4 ，用加粗斜体标识，nums2 = [1,3,4,2]。不存在下一个更大元素，所以答案是 -1
    /// - 1 ，用加粗斜体标识，nums2 = [1,3,4,2]。下一个更大元素是 3 。
    /// - 2 ，用加粗斜体标识，nums2 = [1,3,4,2]。不存在下一个更大元素，所以答案是 -1
    ///
    /// 输入：nums1 = [2,4], nums2 = [1,2,3,4].
    /// 输出：[3,-1]
    /// 解释：nums1 中每个值的下一个更大元素如下所述：
    /// - 2 ，用加粗斜体标识，nums2 = [1,2,3,4]。下一个更大元素是 3
    /// - 4 ，用加粗斜体标识，nums2 = [1,2,3,4]。不存在下一个更大元素，所以答案是 -1
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var ans = new int[nums1.Length];

        var stack = new Stack<int>();
        //key是num2里的元素，value是key所对应的num2里的下一个更大元素
        var dictionary = new Dictionary<int, int>();

        foreach (var i in nums2)
        {
            //如果栈不为空且i大于栈顶元素，说明i就是栈顶元素的下一个更大元素
            //[1,3,4,2,5]
            while (stack.Count != 0 && stack.Peek() < i)
                dictionary.Add(stack.Pop(), i);

            stack.Push(i);
        }

        //如果字典里有该元素，就可以直接获得该元素的下一个更大元素
        for (var i = 0; i < nums1.Length; i++)
            ans[i] = dictionary.ContainsKey(nums1[i]) ? dictionary[nums1[i]] : -1;

        return ans;
    }
}