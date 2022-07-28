using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple
{
    /// <summary>
    /// 1. 两数之和
    /// https://leetcode.cn/problems/two-sum/
    /// </summary>
    public class LeetCode1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var dictionary = new Dictionary<int,int>();
            var length = nums.Length;
            //用哈希表将key设置为每个num，value为每个num的索引
            for (var i = 0; i < length; i++)
            {
                //字典的key不能重复
                if (dictionary.ContainsKey(nums[i]))
                {
                    continue;
                }
                dictionary.Add(nums[i], i);
            }

            for (var i = 0; i < length; i++)
            {
                //直接查找哈希表中有没有 目标值 减去 当前索引下的值 的值
                var num = target-nums[i];
                //哈希表中没有值则直接进行下一轮循环
                if (!dictionary.ContainsKey(num)) 
                    continue;
                
                var index = dictionary[num];
                //需要确保得到的索引不是自己
                if (index == i)
                {
                    continue;
                }

                result[0] = i;
                result[1] = index;
                return result;
            }

            return result;
        }
    }
}