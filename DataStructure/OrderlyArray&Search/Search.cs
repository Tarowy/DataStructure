using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructure.OrderlyArray_Search
{
    public class Search
    {
        private Search()
        {
        }

        /// <summary>
        /// 根据文件位置读取文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int[] ReadFile(string filename)
        {
            var fs = new FileStream(filename, FileMode.Open);
            var sr = new StreamReader(fs);
            var list = new List<int>();

            while (!sr.EndOfStream)
            {
                list.Add(int.Parse(sr.ReadLine() ?? string.Empty));
            }

            fs.Close();
            sr.Close();

            return list.ToArray();
        }

        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int OrderSearch(int[] arr, int target)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (target == arr[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int target)
        {
            var l = 0;
            var r = arr.Length - 1;

            while (l <= r)
            {
                // var mid = (l + r) / 2;
                /*
                 * 直接用l+r的话可能会导致溢出int的可承载范围使mid的值出错，
                 * 所以需要用减法代替加法防止溢出
                 */
                var mid = l + (r - l) / 2;

                if (target > arr[mid])
                {
                    l = mid + 1;
                }
                else if (target < arr[mid])
                {
                    r = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}