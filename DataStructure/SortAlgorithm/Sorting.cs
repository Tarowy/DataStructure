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
                    if (e.CompareTo(arr[j]) < 0)
                        arr[j + 1] = arr[j];
                    else
                        break;
                }

                arr[j + 1] = e;
            }
        }

        //用于对归并的优化
        private static void InsertSort2<TE>(TE[] arr, int l, int r) where TE : IComparable<TE>
        {
            for (var i = l + 1; i <= r; i++)
            {
                var e = arr[i];
                int j;
                for (j = i - 1; j > l - 1; j--)
                {
                    if (e.CompareTo(arr[j]) < 0)
                        arr[j + 1] = arr[j];
                    else
                        break;
                }

                arr[j + 1] = e;
            }
        }

        #endregion

        #region 归并排序

        public static void MergeSort<TE>(TE[] arr) where TE : IComparable<TE>
        {
            //temp不能放在MergeCore里面，否则重复的new对象会损失大量性能
            var temp = new TE[arr.Length];
            MergeSortMedium(arr, temp, 0, arr.Length - 1);
        }
        
        public static void MergeSort2<TE>(TE[] arr) where TE : IComparable<TE>
        {
            //temp不能放在MergeCore里面，否则重复的new对象会损失大量性能
            var temp = new TE[arr.Length];
            MergeSortMedium2(arr, temp, 0, arr.Length - 1);
        }


        /// <summary>
        ///     递归排序，每次划分成数个子数组分别进行排序，依次归并
        /// 时间复杂度O(NlogN)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="temp"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <typeparam name="TE"></typeparam>
        private static void MergeSortMedium<TE>(TE[] arr, TE[] temp, int l, int r) where TE : IComparable<TE>
        {
            //当子数组只有一个元素的时候直接退出
            if (l >= r)
            {
                // Console.WriteLine($"Sort({l},{r})无需排序，返回上一步");
                return;
            }

            var mid = l + (r - l) / 2;
            // Console.WriteLine($"Sort({l},{mid})");
            MergeSortMedium(arr, temp, l, mid); //对子数组的左半边排序
            // Console.WriteLine($"Sort({mid + 1},{r})");
            MergeSortMedium(arr, temp, mid + 1, r); //对子数组的右半边排序

            // Console.WriteLine($"MergeSortCore({l},{mid},{r});");
            MergeSortCore(arr, temp, l, mid, r);
        }

        //优化版归并
        private static void MergeSortMedium2<TE>(TE[] arr, TE[] temp, int l, int r) where TE : IComparable<TE>
        {
            /*
             * 优化一：对于小规模的子数组使用插入排序
             * 主要是避免频繁的递归调用，不一定只能是使用插入排序，还可以使用选择排序和冒泡排序。
             * 那么如何定义小数组呢？这个并没有严格的要求，在这里选择小于等于15个元素就为小数组。
             * 对于这个优化呢？大约能缩短10%-15%的运行时间。
             * 但它并不能本质的改变归并排序的时间复杂度，它还是O(NlogN)级别的。
             */
            if (r - l + 1 <= 15)
            {
                InsertSort2(arr, l, r);
                return;
            }

            var mid = l + (r - l) / 2;
            MergeSortMedium2(arr, temp, l, mid); //对子数组的左半边排序
            MergeSortMedium2(arr, temp, mid + 1, r); //对子数组的右半边排序
            
            /*
             * 优化二：判断数组是否有序
             *     归并后左右两边一定是从小到大排列的，如果左半边最大的小于右半边最小的，
             *     说明就是有序的，不需要再进行一次归并
             * 这一步的优化主要是针对于有序性很强的数组，减少不必要的merge操作，缩短运行时间。
             * 换句话说，如果对于随机性很强的数组，有优化没优化merge操作次数都是差不多的话。
             * 那么增加了这个判断，就相应的增加了耗时。有可能优化后比没优化会更慢一些。
             */
            if (arr[mid].CompareTo(arr[mid + 1]) > 0)
            {
                MergeSortCore(arr, temp, l, mid, r);
            }
        }

        /// <summary>
        /// 将数组分为两部分，然后依次比较两部分的值，小的就存入temp中
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="temp"></param>
        /// <param name="l"></param>
        /// <param name="mid"></param>
        /// <param name="r"></param>
        /// <typeparam name="TE"></typeparam>
        private static void MergeSortCore<TE>(TE[] arr, TE[] temp, int l, int mid, int r) where TE : IComparable<TE>
        {
            var i = l;
            var k = l;
            var j = mid + 1;

            while (i <= mid && j <= r)
            {
                if (arr[i].CompareTo(arr[j]) > 0)
                {
                    temp[k++] = arr[j++];
                }
                else //arr[i].CompareTo(arr[j])<0
                {
                    temp[k++] = arr[i++];
                }
            }

            //将剩下的元素直接存入temp中
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= r)
            {
                temp[k++] = arr[j++];
            }

            for (var m = l; m <= r; m++)
            {
                arr[m] = temp[m];
            }

            // TestHelperSort.Show(arr);
        }

        #endregion
    }
}