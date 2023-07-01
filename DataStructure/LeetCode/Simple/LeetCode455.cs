using System;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  455. 分发饼干
///  https://leetcode.cn/problems/assign-cookies/
/// </summary>
public class LeetCode455
{
    public int FindContentChildren(int[] g, int[] s) {
        if (g.Length == 0 || s.Length == 0)
            return 0;

        int result = 0;
        Array.Sort(g);
        Array.Sort(s);

        int sIndex = s.Length - 1;
        //选择胃口
        for (int i = g.Length - 1; i >= 0; --i) {
            //如果当前最大的饼干大于当前小孩的胃口，就将饼干分出去
            if (s[sIndex] >= g[i]) {
                result++;
                sIndex--;
            }
            if (sIndex < 0)
                break;
        }

        return result;
    }
}