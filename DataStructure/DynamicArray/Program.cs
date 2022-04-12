using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Array1 array1 = new Array1(10);
            
            for (int i = 0; i < 10; i++)
            {
                array1.AddLast(i);
            }

            Console.WriteLine(array1);

            array1.AddLast(55);
            Console.WriteLine(array1);

            for (int i = 0; i < 6; i++)
            {
                array1.RemoveLast();
            }

            Console.WriteLine(array1);
        }

        public static void Test1()
        {
            #region 测试官方的集合框架

            /*
           * ArrayList和List可以指定初始容量，不知道则为空，超出容量会自动扩容不会报错
           */
            ArrayList arrayList = new ArrayList(10);
            for (int i = 0; i < 15; i++)
            {
                arrayList.Add(i);
                Console.Write(arrayList[i]+" ");
            }

            List<int> ints = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                ints.Add(i);
                Console.Write(ints[i]+" ");
            }

            #endregion

            #region 测试自己写的集合框架

            Array1 array1 = new Array1(20);
            
            for (int i = 0; i < 10; i++)
            {
                array1.AddLast(i);
            }

            array1.AddFirst(66);
            Console.WriteLine(array1);
            
            array1.Add(2,77);
            Console.WriteLine(array1);

            Console.WriteLine(array1.GetFirst());
            Console.WriteLine(array1.GetLast());
            Console.WriteLine(array1.Get(2));

            array1.Set(1, 1000);
            Console.WriteLine(array1);
            
            //[66, 1000, 77, 1, 2, 3, 4, 5, 6, 7, 8, 9]
            array1.RemoveAt(1);
            array1.RemoveFirst();
            array1.RemoveLast();
            array1.Remove(6);
            Console.WriteLine(array1);

            #endregion
        }
    }
}