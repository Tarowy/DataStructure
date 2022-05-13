using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructure.DynamicArray
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     //获取和设置当前目录（即该进程从中启动的目录）的完全限定路径
        //     Console.WriteLine(Process.GetCurrentProcess().MainModule.FileName); 
        //     /*
        //      * 备注 按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠（如“C:\”）
        //      * 如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径（如“C:\mySubDirectory”）
        //      */
        //     Console.WriteLine(Environment.CurrentDirectory);
        //     //获取应用程序的当前工作目录
        //     Console.WriteLine(Directory.GetCurrentDirectory());
        //     //获取基目录，它由程序集冲突解决程序用来探测程序集
        //     Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory); 
        //     //获取或设置包含该应用程序的目录的名称
        //     Console.WriteLine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
        //     // Console.WriteLine(MediaTypeNames.Application.StartupPath);
        // }

        /// <summary>
        /// 测试官方的集合框架
        /// </summary>
        public static void TestOfficialList1()
        {
            /*
           * ArrayList和List可以指定初始容量，不知道则为空，超出容量会自动扩容不会报错
           */
            ArrayList arrayList = new ArrayList(10);
            for (int i = 0; i < 15; i++)
            {
                arrayList.Add(i);
                Console.Write(arrayList[i] + " ");
            }

            List<int> ints = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                ints.Add(i);
                Console.Write(ints[i] + " ");
            }
        }

        /// <summary>
        /// 测试自己写的集合框架
        /// </summary>
        public static void TestSelfList()
        {
            Array1<int> array1 = new Array1<int>(20);

            for (int i = 0; i < 10; i++)
            {
                array1.AddLast(i);
            }

            array1.AddFirst(66);
            Console.WriteLine(array1);

            array1.Add(2, 77);
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

            Array1<int> array2 = new Array1<int>(10);

            for (int i = 0; i < 10; i++)
            {
                array2.AddLast(i);
            }

            Console.WriteLine(array2);

            array2.AddLast(55);
            Console.WriteLine(array2);

            for (int i = 0; i < 6; i++)
            {
                array2.RemoveLast();
            }

            Console.WriteLine(array2);
            
            //测试泛型
            Array1<string> stringArray1 = new Array1<string>();
            for (int i = 0; i < 10; i++)
            {
                stringArray1.AddLast("X");
            }

            Console.WriteLine(stringArray1);
        }

        /// <summary>
        /// 官方集合框架的装箱与拆箱，推荐使用List<T>
        /// 由于以前没有泛型的存在，只能用ArrayList储存各种类型的值
        /// 如果直接删除ArrayList会导致旧项目无法运行所以保留至今
        /// </summary>
        public static void TestOfficialList2()
        {
            var n = 10000000;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<int> ints = new List<int>();
            /*
             * 43ms
             * 使用泛型指定了类型不发生装箱与拆箱，效率最佳
             */
            for (var i = 0; i < n; i++) 
            {
                ints.Add(i); //不发生装箱
                var x = ints[i]; //不发生拆箱
            }

            stopwatch.Stop();
            Console.WriteLine("List's Time:" + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Reset();

            stopwatch.Start();
            ArrayList arrayList = new ArrayList();
            /*
             * 587ms
             * ArrayList默认是应用Object进行储存，这样虽然可以储存多种类型的值
             * 但是储存值类型的数据会频繁导致拆箱与装箱
             */
            for (var i = 0; i < n; i++)
            {
                arrayList.Add(i); //发生装箱
                int x = (int) arrayList[i]; //发生拆箱
            }

            stopwatch.Stop();
            Console.WriteLine("ArrayList's Time:" + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Reset();

            stopwatch.Start();
            var stringList = new List<string>();
            /*
             * 99ms
             * 用泛型指定储存引用类型的数据
             */
            for (int i = 0; i < n; i++)
            {
                stringList.Add("X"); //不发生装箱
                var x = stringList[i]; //不发生拆箱
            }

            stopwatch.Stop();

            stopwatch.Stop();
            Console.WriteLine("List's Time:" + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Reset();

            stopwatch.Start();
            var arrayList2 = new ArrayList();
            /*
             * 190ms
             * 虽然ArrayList储存引用类型的数据不会发生装箱拆箱
             * 但是一个应用类型转换到另一个引用类型也会导致损耗
             */
            for (int i = 0; i < n; i++)
            {
                arrayList2.Add("X"); //不发生装箱
                var x = (string) arrayList2[i]; //不发生拆箱 
            }
            stopwatch.Stop();
            Console.WriteLine("ArrayList's Time:" + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}