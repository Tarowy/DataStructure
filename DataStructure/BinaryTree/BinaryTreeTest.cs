using System;

namespace DataStructure.BinaryTree
{
    public class BinaryTreeTest
    {
        public static void Main(string[] args)
        {
            int[] a = { 8, 4, 12, 2, 6, 10, 14 };

            ///////////////////////
            //         8         //
            //     /       \     //
            //    4        12    //
            //  /   \     /   \  //
            // 2     6   10   14 //
            ///////////////////////

            var bst = new BST1<int>();

            foreach (var t in a)
                bst.Add(t);
            
            bst.PreOrder();
            Console.WriteLine();
            bst.InOrder();
            Console.WriteLine();
            bst.PostOrder();
            Console.WriteLine();
            bst.LevelOrder();
        }
    }
}