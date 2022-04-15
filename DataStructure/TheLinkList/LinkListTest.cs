using System;

namespace DataStructure.TheLinkList
{
    public class LinkListTest
    {
        // public static void Main(string[] args)
        // {
        //     
        // }

        public static void TestLinkList1()
        {
            var list1 = new LinkList1<int>();
            for (int i = 0; i < 5; i++)
            {
                list1.AddFirst(i);
                Console.WriteLine(list1);
            }

            list1.AddLast(10);
            Console.WriteLine(list1);
            
            Console.WriteLine(list1.Get(3));

            list1.Set(2,1000);
            Console.WriteLine(list1);
            
            //4->3->1000->1->0->10->null
            list1.RemoveAt(3);
            list1.RemoveFirst();
            list1.RemoveLast();
            Console.WriteLine(list1);

            list1.Remove(1000);
            Console.WriteLine(list1);
        }
    }
}