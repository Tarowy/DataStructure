namespace DataStructure.LeetCode.Simple;

/// <summary>
///  860. 柠檬水找零
///  https://leetcode.cn/problems/lemonade-change/
/// </summary>
public class LeetCode860
{
    public bool LemonadeChange(int[] bills) {
        int five = 0, ten = 0;
        foreach (var bill in bills)
        {
            switch (bill) {
                case 5: //直接支付5元
                    five++;
                    break;
                case 10: //支付10元，找回5元
                    if (five == 0)
                        return false;
                    five--;
                    ten++;
                    break;
                case 20: //支付20元，找回10元和5元 或者 三张5元
                    if (ten > 0 && five > 0) {
                        ten--;
                        five--;
                    } else if (five >= 3)
                        five -= 3;
                    else return false;

                    break;
                default:
                    return false;
            }
        }
        return true;
    }
}