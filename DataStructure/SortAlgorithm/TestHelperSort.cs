using System;
using System.Diagnostics;
using System.Reflection;

namespace DataStructure.SortAlgorithm
{
    //排序算法测试辅助工具类
    public class TestHelperSort
    {
        /// <summary>
        /// 生成有n个元素的随机数组,每个元素的随机范围为[0, maxValue]
        /// Random.next是[0,maxValue)的区间，所以想要[0, maxValue]得maxValue+1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int[] RandomArray(int n, int maxValue)
        {
            var r = new Random();
            var arr = new int[n];

            for (var i = 0; i < n; i++)
                arr[i] = r.Next(maxValue + 1);

            return arr;
        }

        /// <summary>
        /// 生成有n个元素的近乎有序数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="swapTimes"></param>
        /// <returns></returns>
        public static int[] NearlyOrderedArray(int n, int swapTimes)
        {
            var arr = new int[n];
            for (var i = 0; i < n; i++)
                arr[i] = i;

            var r = new Random();

            for (var i = 0; i < swapTimes; i++)
            {
                var a = r.Next(n);
                var b = r.Next(n);

                (arr[a], arr[b]) = (arr[b], arr[a]);
            }

            return arr;
        }

        /// <summary>
        ///     判断arr数组是否有序(从小到大)
        /// </summary>
        /// <param name="arr"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void IsSorted(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    throw new ArgumentException("排序失败");
        }
        
        /// <summary>
        ///     拷贝arr数组的所有内容得到相同的数组并返回
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] CopyArray(int[] arr)
        {
            var n = arr.Length;
            var temp = new int[n];

            for (var i = 0; i < n; i++)
                temp[i] = arr[i];

            return temp;
        }

        /// <summary>
        /// 测试sortClassName所对应的排序算法排序arr数组所得到结果的正确性和算法运行时间
        /// </summary>
        /// <param name="sortClassName"></param>
        /// <param name="arr"></param>
        public static void TestSort(string sortClassName, int[] arr)
        {
            var type = Type.GetType("DataStructure.SortAlgorithm.Sorting");
            /*
             * 反射的是泛型方法，非泛型方法直接GetMethod()即可，泛型方法需要用MakeGenericMethod指定泛型类型
             */
            var sortMethod = type.GetMethod(sortClassName).MakeGenericMethod(typeof(int));
            var paramsArr = new object[] { arr };
            var sw = new Stopwatch();
            sw.Start();
            sortMethod.Invoke(null, paramsArr);
            sw.Stop();
            IsSorted(arr);
            Console.WriteLine(sortClassName + " : " + sw.ElapsedMilliseconds + "ms");
        }

        public static void Show<TE>(TE[] arr)
        {
            foreach (var a in arr)   
            {
                Console.Write(a+" ");
            }

            Console.WriteLine();
        }
    }
}