using System;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  151. 反转字符串中的单词
///  https://leetcode.cn/problems/reverse-words-in-a-string/
/// </summary>
public class LeetCode151
{
    public string ReverseWords(string s)
    {
        var removedExtraSpaceArray = RemoveExtraSpace(s.ToCharArray());

        //将整个字符串反转
        Reverse(removedExtraSpaceArray, 0, removedExtraSpaceArray.Length - 1);
        
        var start = 0;
        //再将每个单词反转，即可得到反转单词的字符串
        for (var i = 0; i <= removedExtraSpaceArray.Length; i++)
        {
            if (removedExtraSpaceArray[i] == ' ' || i == removedExtraSpaceArray.Length)
            {
                Reverse(removedExtraSpaceArray, start, i - 1);
                start = i + 1;
            }
        }

        return new string(removedExtraSpaceArray);
    }


    public char[] RemoveExtraSpace(char[] chars)
    {
        var fast = 0;
        var slow = 0;

        //先移除多余的空格
        for (; fast < chars.Length; ++fast)
        {
            if (chars[fast] != ' ')
            {
                if (slow != 0)
                    chars[slow++] = ' ';

                //将当前单词全都移动到slow指向的地方
                while (fast < chars.Length && chars[fast] != ' ')
                    chars[slow++] = chars[fast++];
            }
        }

        var newChars = new char[slow];
        Array.Copy(chars, newChars, slow);
        return newChars;
    }

    /// <summary>
    /// 反转数组值，左闭右闭
    /// </summary>
    public void Reverse(char[] chars, int begin, int end)
    {
        for (int i = begin, j = end; i < j; i++, j--)
        {
            chars[i] ^= chars[j];
            chars[j] ^= chars[i];
            chars[i] ^= chars[j];
        }
    }
}