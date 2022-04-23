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
            
            // bst.PreOrder();
            // Console.WriteLine();
            // bst.InOrder();
            // Console.WriteLine();
            // bst.PostOrder();
            // Console.WriteLine();
            // bst.LevelOrder();

            // bst.RemoveMax();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.RemoveMin();
            // bst.InOrder();
            // Console.WriteLine();
            // Console.WriteLine(bst.Min());
            // Console.WriteLine(bst.Max());

            // bst.Remove(10);
            bst.Remove(8);
            bst.InOrder();
        }
    }
}