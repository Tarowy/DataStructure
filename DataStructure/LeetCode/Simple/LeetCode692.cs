using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 692. 前K个高频单词
/// https://leetcode.cn/problems/top-k-frequent-words/
/// </summary>
public class LeetCode692
{
    /// <summary>
    /// 输入: words = ["i", "love", "leetcode", "i", "love", "coding"], k = 2
    /// 输出: ["i", "love"]
    /// 解析: "i" 和 "love" 为出现次数最多的两个单词，均为2次。
    /// 注意，按字母顺序 "i" 在 "love" 之前。
    /// 
    /// 输入: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
    /// 输出: ["the", "is", "sunny", "day"]
    /// 解析: "the", "is", "sunny" 和 "day" 是出现次数最多的四个单词，
    /// 出现次数依次为 4, 3, 2 和 1 次。
    /// </summary>
    /// <param name="words"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var dictionary = new Dictionary<string, int>();
        var minHeap = new MinHeap<int, string>();
        var ans = new List<string>();

        foreach (var word in words)
        {
            if (!dictionary.ContainsKey(word))
            {
                dictionary.Add(word, 0);
                continue;
            }

            dictionary[word] += 1;
            Console.WriteLine(dictionary[word]);
        }

        foreach (var i in dictionary)
        {
            minHeap.Insert(i.Value, i.Key);

            //超过k个元素就移除最小值，这样到最后就会保留最大的k个值
            if (minHeap.N > k)
                minHeap.RemoveMin();
        }

        Console.WriteLine(minHeap.ToString());

        while (minHeap.N > 0)
            ans.Add(minHeap.RemoveMin().value);


        ans.Reverse();

        return ans;
    }

    /// <summary>
    /// 键值对最小堆
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    private class MinHeap<TKey, TValue> where TKey : IComparable<TKey> where TValue : IComparable<TValue>
    {
        //["i","love","leetcode","i","love","coding"]
        private TKey[] KeyHeap { set; get; }
        private TValue[] ValueHeap { set; get; }
        private int Capacity { set; get; }

        public int N { set; get; }
        public bool IsEmpty => N == 0;

        public MinHeap() : this(10)
        {
        }

        public MinHeap(int capacity)
        {
            Capacity = capacity;
            N = 0;
            KeyHeap = new TKey[capacity + 1];
            ValueHeap = new TValue[capacity + 1];
        }

        public MinHeap(IDictionary<TKey, TValue> dictionary, int capacity = 10) : this(capacity)
        {
            foreach (var i in dictionary)
                Insert(i.Key, i.Value);
        }

        public void Insert(TKey key, TValue value)
        {
            if (N == Capacity)
                ResetCapacity(Capacity * 2);

            KeyHeap[++N] = key;
            ValueHeap[N] = value;

            Swim(N);
        }

        private void Swim(int index)
        {
            //如果频率一样，就将在字典中后出现的单词排在前面，如果频率不一样就将频率小的换到前面
            while (index > 1 && ((KeyHeap[index].CompareTo(KeyHeap[index / 2]) == 0 &&
                                  ValueHeap[index].CompareTo(ValueHeap[index / 2]) > 0) ||
                                 KeyHeap[index].CompareTo(KeyHeap[index / 2]) < 0))
            {
                (KeyHeap[index], KeyHeap[index / 2]) = (KeyHeap[index / 2], KeyHeap[index]);
                (ValueHeap[index], ValueHeap[index / 2]) = (ValueHeap[index / 2], ValueHeap[index]);
                index /= 2;
            }
        }

        /// <summary>
        /// 移除最小元素，获取键值对的元组
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public (TKey key, TValue value) RemoveMin()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("堆为空");
            }

            //将最小元素交换到最后并移除，如果第一个元素和最后一个元素相同就不改变位置
            (KeyHeap[1], KeyHeap[N]) = (KeyHeap[N], KeyHeap[1]);
            (ValueHeap[1], ValueHeap[N]) = (ValueHeap[N], ValueHeap[1]);

            var minKey = KeyHeap[N];
            var minValue = ValueHeap[N];

            KeyHeap[N] = default;
            ValueHeap[N--] = default;

            if (N <= Capacity / 4)
                ResetCapacity(Capacity / 2);

            Sink(1);
            return (key: minKey, value: minValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        private void Sink(int index)
        {
            var t = index * 2;
            while (t <= N)
            {
                //存在右子元素，且左子元素比右子元素还大，就将t切换到更小的右子元素
                //如果左右元素相同
                if (t + 1 <= N && (KeyHeap[t].CompareTo(KeyHeap[t + 1]) > 0) ||
                    (KeyHeap[t].CompareTo(KeyHeap[index]) == 0
                     && ValueHeap[t].CompareTo(ValueHeap[index]) < 0))
                    t++;

                //如果t比它的父元素index还要大，说明父元素已经比所有子元素小了，不需要再进行交换
                //如果键相同，比较值，按字典顺序，让小的那个值排在前面
                if (KeyHeap[t].CompareTo(KeyHeap[index]) < 0
                    || (KeyHeap[t].CompareTo(KeyHeap[index]) == 0
                        && ValueHeap[t].CompareTo(ValueHeap[index]) < 0))
                    break;

                (KeyHeap[index], KeyHeap[t]) = (KeyHeap[t], KeyHeap[index]);
                (ValueHeap[index], ValueHeap[t]) = (ValueHeap[t], ValueHeap[index]);

                index = t;
                t = index * 2;
            }
        }

        public void ResetCapacity(int capacity)
        {
            var keys = new TKey[capacity + 1];
            var values = new TValue[capacity + 1];

            for (var i = 0; i <= N; i++)
            {
                keys[i] = KeyHeap[i];
                values[i] = ValueHeap[i];
            }

            KeyHeap = keys;
            ValueHeap = values;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Array1: Count:{N}\n");
            stringBuilder.Append('[');
            for (var i = 1; i <= N; i++)
            {
                stringBuilder.Append($"{KeyHeap[i]}:{ValueHeap[i]}");
                if (i != N)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(']');
            return stringBuilder.ToString();
        }
    }
}