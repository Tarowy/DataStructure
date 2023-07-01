namespace DataStructure.LeetCode.Medium;

public class LeetCode738
{
    public int MonotoneIncreasingDigits(int n)
    {
        var numberChars = n.ToString().ToCharArray();
        //记录从哪位开始将数字全变成9
        var flag = numberChars.Length;

        //从最后一位开始往前遍历
        for (int i = numberChars.Length - 1; i > 0; i--)
        {
            /*
             * 前一位数大于当前位数，则将前一位数减1，当前位数变为9，以确保变成这两位数之下的最大值
             * 不过这里只需要记录将数字变为9的起始位置，不需要真的变为9
             */
            if (numberChars[i - 1] > numberChars[i])
            {
                --numberChars[i - 1];
                flag = i;
            }
        }

        //从标记位开始将所有数字变为9从而得到最大值
        for (int i = flag; i < numberChars.Length; ++i)
            numberChars[i] = '9';

        return int.Parse(numberChars);
    }
}