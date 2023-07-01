namespace DataStructure.LeetCode.Medium;

/// <summary>
///  134. 加油站
/// https://leetcode.cn/problems/gas-station/
/// </summary>
public class LeetCode134
{
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int curSum = 0;
        int totalSum = 0; //记录总油量，如果小于0说明无论如何都到不了终点
        int start = 0;

        for (int i = 0; i < gas.Length; ++i) {
            curSum += gas[i] - cost[i];
            totalSum += gas[i] - cost[i];
            //从i之前任意的一个位置起步都无法经过i这个坎，所以起步需要从i+1开始
            if (curSum < 0){
                start = i + 1;
                curSum = 0;
            }
        }

        return totalSum < 0 ? -1 : start;
    }
}