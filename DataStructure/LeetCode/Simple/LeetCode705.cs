namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 705. 设计哈希集合
/// https://leetcode.cn/problems/design-hashset/
/// </summary>
public class LeetCode705
{
    /// <summary>
    /// 输入：
    /// ["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
    /// [[], [1], [2], [1], [3], [2], [2], [2], [2]]
    /// 输出：
    /// [null, null, null, true, false, null, true, null, false]
    ///
    /// 解释：
    /// MyHashSet myHashSet = new MyHashSet();
    /// myHashSet.add(1);      // set = [1]
    /// myHashSet.add(2);      // set = [1, 2]
    /// myHashSet.contains(1); // 返回 True
    /// myHashSet.contains(3); // 返回 False ，（未找到）
    /// myHashSet.add(2);      // set = [1, 2]
    /// myHashSet.contains(2); // 返回 True
    /// myHashSet.remove(2);   // set = [1]
    /// myHashSet.contains(2); // 返回 False ，（已移除）
    /// </summary>
    public class MyHashSet
    {
        private readonly bool[] _hashSet  = new bool[1000001];

        public void Add(int key) => _hashSet[key] = true;

        public void Remove(int key) => _hashSet[key] = false;

        public bool Contains(int key) => _hashSet[key];
    }
}