using System;

namespace DataStructure.SortAlgorithm
{
    public class Sorting
    {
        #region 冒泡排序

        /// <summary>
        ///     冒泡排序，从头到尾两两比较元素，可以直接将泛型加在方法上
        /// </summary>
        /// <param name="arr"></param>
        /// <typeparam name="TE"></typeparam>
        public static void BubbleSort<TE>(TE[] arr) where TE : IComparable<TE>
        {
            var n = arr.Length;

            for (var i = 0; i < n - 1; i++)
            {
                //n-1-i：不需要对已经排序完的元素再进行比较
                for (var j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // var tmp = arr[j + 1];
                        // arr[j + 1] = arr[j];
                        // arr[j] = tmp;
                        //C#写法
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    }
                }
            }
        }

        #endregion

        #region 选择排序

        /// <summary>
        ///     选择排序，每次循环选择出最小的元素并将其交换位置到前排
        /// </summary>
        /// <param name="arr"></param>
        /// <typeparam name="TE"></typeparam>
        public static void SelectSort<TE>(TE[] arr) where TE : IComparable<TE>
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min].CompareTo(arr[j]) > 0)
                    {
                        min = j;
                    }
                }

                (arr[min], arr[i]) = (arr[i], arr[min]);
            }
        }

        #endregion

        #region 插入排序

        /// <summary>
        ///     插入排序，每次拿出一个元素e，e之前的所有元素边向后移动边与e作比较，
        /// 如果该元素大于等于某个元素arr[j]，就在arr[j+1]的位置放入该元素
        ///     该排序方法最差的时间复杂度是O(n^2)，如果数组是近乎有序的，
        /// 那么就能基本忽略掉内存循环，使复杂度降为0(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <typeparam name="TE"></typeparam>
        public static void InsertSort<TE>(TE[] arr) where TE : IComparable<TE>
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var e = arr[i];
                int j;
                for (j = i - 1; j > -1; j--)
                {
                    if (e.CompareTo(arr[j])<0)
                        arr[j+1] = arr[j];
                    else
                        break;
                }
                arr[j + 1] = e;
            }
        }

        #endregion
    }
}