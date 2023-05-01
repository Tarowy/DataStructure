using System.Collections;
using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  20. 有效的括号
///  https://leetcode.cn/problems/valid-parentheses/
/// </summary>
public class LeetCode20
{
    public bool IsValid(string s)
    {
        var size = s.Length;
        var bracketsStack = new Stack<char>();

        if (size % 2 != 0)
            return false;

        for (var i = 0; i < size; i++)
        {
            switch (s[i])
            {
                //每遇到左括号就将相应的右括号加入到栈中
                case '(':
                    bracketsStack.Push(')');
                    break;
                case '{':
                    bracketsStack.Push('}');
                    break;
                case '[':
                    bracketsStack.Push(']');
                    break;
                //遇到右括号时，如果栈已经空了，或者括号不匹配则不满足条件
                default:
                {
                    if (bracketsStack.Count == 0 || bracketsStack.Peek() != s[i])
                        return false;
                    bracketsStack.Pop();
                    break;
                }
            }
        }

        return bracketsStack.Count == 0;
    }
}