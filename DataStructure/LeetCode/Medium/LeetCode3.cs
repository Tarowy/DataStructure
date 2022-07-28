using System;

namespace DataStructure.LeetCode.Medium
{
    /// <summary>
    /// 3. 无重复字符的最长子串
    /// https://leetcode.cn/problems/longest-substring-without-repeating-characters/
    /// </summary>
    public class LeetCode3
    {
        /// <summary>
        /// 输入: s = "abcabcbb"
        /// 输出: 3
        /// 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// 使用滑动窗口法
        public int LengthOfLongestSubstring(string s)
        {
            var ans = 0;
            /*
             * 字符串包含了字母、数字、空格，所以用128位长度的int数组对应每个字符ASCII的值
             * 每个int的值储存的是对应ASCII字符串中上一次出现的位置
             */
            var pos = new int[128];
            for (var i = 0; i < 128; i++)
                pos[i] = -1;

            //i是右窗口，j是左窗口
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                //j的值更新为上一次相同字符出现位置的下一个索引位置，用MAX来确保遇到从未出现的字符j不会被重制成0
                j = Math.Max(pos[s[i]] + 1, j);
                //每遍历到一个字符就将其最新出现的索引更新到ASCII记录数组中
                pos[s[i]] = i;
                //更新最大长度
                ans = Math.Max(ans, i - j + 1);
            }

            return ans;
        }
    }
}