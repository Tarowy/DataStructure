using System.Collections.Generic;

namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 150. 逆波兰表达式求值
/// https://leetcode.cn/problems/evaluate-reverse-polish-notation/
/// </summary>
public class LeetCode150
{
    public int EvalRPN(string[] tokens)
    {
        var numberStack = new Stack<int>();

        foreach (var t in tokens)
        {
            if (t is "+" or "-" or "*" or "/")
            {
                var num1 = numberStack.Pop();
                var num2 = numberStack.Pop();

                switch (t)
                {
                    case "+":
                        numberStack.Push(num2 + num1);
                        break;
                    case "-":
                        numberStack.Push(num2 - num1);
                        break;
                    case "*":
                        numberStack.Push(num2 * num1);
                        break;
                    case "/":
                        numberStack.Push(num2 / num1);
                        break;
                }

                continue;
            }

            numberStack.Push(int.Parse(t));
        }

        return numberStack.Pop();
    }
}