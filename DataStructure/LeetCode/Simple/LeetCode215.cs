using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 215. 数组中的第K个最大元素
/// https://leetcode.cn/problems/kth-largest-element-in-an-array/
/// </summary>
public class LeetCode215
{
    /// <summary>
    /// 输入: [3,2,1,5,6,4], k = 2
    /// 输出: 5
    /// 输入: [3,2,3,1,2,4,5,5,6], k = 4
    /// 输出: 4
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int FindKthLargest(int[] nums, int k)
    {
        var maxHeap = new MaxHeap(nums, nums.Length);
        Console.WriteLine(maxHeap.ToString());
        var ans = nums[0];

        for (var i = 0; i < k; i++)
        {
            ans = maxHeap.RemoveMax();
        }

        return ans;
    }

    private class MaxHeap
    {
        private int[] Heap { set; get; }
        private int N { set; get; }
        private int Capacity { set; get; }

        public bool IsEmpty => N == 0;

        public MaxHeap(IEnumerable enumerable, int capacity = 10) : this(capacity)
        {
            foreach (int i in enumerable)
                Insert(i);
        }

        public MaxHeap(int capacity)
        {
            //0号元素不使用
            Heap = new int[capacity + 1];
            N = 0;
            Capacity = capacity;
        }

        public MaxHeap() : this(10)
        {
        }

        public void Insert(int value)
        {
            //如果元素要满了就扩容
            if (N == Capacity)
                ResetCapacity(Capacity * 2);

            Heap[++N] = value;
            Swim(N);
        }

        /// <summary>
        /// 上游，将大的值都向上移动
        /// </summary>
        /// <param name="index"></param>
        private void Swim(int index)
        {
            //该元素如果不是第一个元素且值大于父节点，就交换位置
            while (index > 1 && Heap[index].CompareTo(Heap[index / 2]) > 0)
            {
                (Heap[index], Heap[index / 2]) = (Heap[index / 2], Heap[index]);
                index /= 2;
            }
        }

        public int RemoveMax()
        {
            if (IsEmpty)
                throw new ArgumentException("堆为空");

            //交换首尾元素，尾部元素就变成了最大的，于是就可以直接返回最大元素了
            (Heap[1], Heap[N]) = (Heap[N], Heap[1]);
            var max = Heap[N];
            Heap[N--] = default;

            // 0 1 2 3 4  N=4 4/4=1
            if (N == Capacity / 4)
                ResetCapacity(Capacity / 2);

            //交换完元素后开始下沉操作
            Sink(1);
            return max;
        }

        /// <summary>
        /// 下沉，将小的值都向下移动
        /// </summary>
        /// <param name="index"></param>
        private void Sink(int index)
        {
            var t = 2 * index;
            //循环直到没有左子元素为止
            while (t <= N)
            {
                //如果index索引下有右子元素，且右子元素大于左子元素，就将t索引切换到更大元素的位置
                if (t + 1 <= N && Heap[t].CompareTo(Heap[t + 1]) < 0)
                    t++;

                //如果比较大的那个(左/右)子元素都小于等于index，那么就不需要交换了
                if (Heap[t].CompareTo(Heap[index]) <= 0)
                    break;

                //如果t索引的元素大于index索引的元素，就交换位置
                (Heap[t], Heap[index]) = (Heap[index], Heap[t]);

                index = t;
                t = 2 * index;
            }
        }

        private void ResetCapacity(int capacity)
        {
            var newHeap = new int[capacity + 1];

            for (var i = 0; i <= N; i++)
                newHeap[i] = Heap[i];

            Heap = newHeap;
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Array1: Count:{N}\n");
            stringBuilder.Append('[');
            for (var i = 1; i <= N; i++)
            {
                stringBuilder.Append(Heap[i]);
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