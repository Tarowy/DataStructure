using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

public class LeetCode501
{
    //记录重复次数最多次的数字的出现次数
    private int maxCount;

    //统计当前重复数字的重复次数
    private int count;

    //当前被记录出现次数的数字
    private int modeValue;
    private TreeNode pre;
    private List<int> result;

    void Traversal(TreeNode root)
    {
        if (root == null)
            return;

        Traversal(root.left);

        if (pre != null)
        {
            //该数与前一个数相等，则增加计数器
            if (root.val == pre.val)
                count++;
            else
            {
                modeValue = root.val;
                count = 1;
            }
        }
        else
        {
            //遍历到最左边时进入这部分代码
            modeValue = root.val;
            count = 1;
        }

        pre = root;

        //该数字的出现次数大于之前出现次数最多的数字
        if (count > maxCount)
        {
            maxCount = count;
            result.Clear();
            result.Add(modeValue);
        }
        else if (count == maxCount)
            result.Add(modeValue);

        Traversal(root.right);
    }

    public int[] FindMode(TreeNode root)
    {
        maxCount = modeValue = count = 0;
        pre = null;
        result = new List<int>();

        Traversal(root);
        return result.ToArray();
    }
}