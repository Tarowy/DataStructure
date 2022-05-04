using System;

namespace DataStructure.SortAlgorithm
{
    public class Sorting
    {
        #region 冒泡排序

        /// <summary>
        ///     冒泡排序，可以直接将泛型加在方法上
        /// </summary>
        /// <param name="arr"></param>
        /// <typeparam name="E"></typeparam>
        public static void BubbleSort<E>(E[] arr) where E : IComparable<E>
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
    }
}