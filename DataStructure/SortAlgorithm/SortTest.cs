using System;

namespace DataStructure.SortAlgorithm
{
    public class SortTest
    {
        public static void Main(string[] args)
        {
            TestBubble();
        }

        #region 测试冒泡

        private static void TestBubble()
        {
            int[] a = { 4, 3, 5, 2, 1, 0 };
            char[] a2 = { 'C', 'A', 'D', 'B', 'G', 'F', 'E'};
            float[] a3 = { 0.21f, 0.10f, 0.78f, 0.15f, 0.17f };

            Date[] dates =
            {
                new(2020,7,7,"七夕节"),
                new(2020,8,15,"中秋节"),
                new(2020,1,1,"元旦节"),
                new(2020,3,8,"妇女节"),
                new(2020,4,4,"清明节"),
                new(2020,5,1,"劳动节"),
                new(2020,9,10,"教师节"),
                new(2020,1,25,"春节"),
                new(2020,2,14,"情人节"),
                new(2020,10,1,"国庆节"),
                new(2020,12,25,"圣诞节"),
                new(2020,6,1,"儿童节")
            };

            Sorting.BubbleSort(dates);

            foreach (var t in dates)
                Console.WriteLine(t);
        }

        #endregion
        
    }
}