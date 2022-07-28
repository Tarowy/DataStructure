namespace DataStructure.LeetCode.Medium;

/// <summary>
/// 12. 整数转罗马数字
/// https://leetcode.cn/problems/integer-to-roman/
/// </summary>
public class LeetCode12
{
    public string IntToRoman(int num) {
        /*
         * I  1      C  100
         * V  5      D  500
         * X  10     M  1000
         * L  50
         */
        //如果用new定义，字符串数组会被放在堆内存而不是字符串常量池，从而大幅降低速度
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        //将各位数字剥离出来再对照上面的表打印出罗马数字
        return thousands[num / 1000] + hundreds[num / 100 % 10] + tens[num / 10 % 10] + ones[num % 10];
    }
}