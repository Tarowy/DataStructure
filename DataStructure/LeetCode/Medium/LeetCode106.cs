using System.Collections.Generic;
using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  106. 从中序与后序遍历序列构造二叉树
///  https://leetcode.cn/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
/// </summary>
public class LeetCode106
{
    private Dictionary<int, int> _elementIndex = new();

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        for (var i = 0; i < inorder.Length; i++)
            _elementIndex.Add(inorder[i], i);

        return Build(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inorder">中序遍历结果</param>
    /// <param name="postorder">后序遍历结果</param>
    /// <param name="il">中序遍历结果的左指针</param>
    /// <param name="ir">中序遍历结果的右指针</param>
    /// <param name="pl">后序遍历结果的左指针</param>
    /// <param name="pr">后序遍历结果的右指针</param>
    /// <returns></returns>
    private TreeNode Build(int[] inorder, int[] postorder, int il, int ir, int pl, int pr)
    {
        if (il > ir || pl > pr)
            return null;
        if (ir == il)
            return new TreeNode(inorder[ir]);

        //后序遍历 子序列 的最后一个元素就是根节点
        var midNode = postorder[pr];
        //获取根节点在中序遍历中的下标位置，从而将中序遍历切割成 左-中(根节点)-右 的序列
        var midIndex = _elementIndex[midNode];

        var node = new TreeNode(midNode)
        {
            //il到midIndex的数量 就是 左子树节点的数量，所以从 后序序列中 挑选出 对应的数量的子序列，那么 后序序列中剩下的 就是 右子树节点的数量
            left = Build(inorder, postorder, il, midIndex - 1, pl, pl + (midIndex - il) - 1),
            right = Build(inorder, postorder, midIndex + 1, ir, pl + (midIndex - il), pr - 1)
        };

        return node;
    }
}