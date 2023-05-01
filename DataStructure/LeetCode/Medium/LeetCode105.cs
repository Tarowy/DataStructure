using System.Collections.Generic;
using DataStructure.LeetCode.Simple;

namespace DataStructure.LeetCode.Medium;

/// <summary>
///  105. 从前序与中序遍历序列构造二叉树
///  https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
/// </summary>
public class LeetCode105
{
    private Dictionary<int, int> _elementIndex = new();

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        for (var i = 0; i < inorder.Length; i++)
            _elementIndex.Add(inorder[i], i);

        return Build(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] preorder, int[] inorder, int pl, int pr, int il, int ir)
    {
        if (pl > pr || il > ir)
            return null;
        if (ir == il)
            return new TreeNode(inorder[il]);

        //先序序列的第一个元素就是根节点
        var midNode = preorder[pl];
        //根节点所在的中序序列的索引
        var midIndex = _elementIndex[midNode];

        var root = new TreeNode(midNode);

        //从 il到midIndex 的距离，即 根节点 的 左子树的数量，那么剩下的就是右子树
        var count = midIndex - il;
        root.left = Build(preorder, inorder, pl + 1, pl + count, il, midIndex - 1);
        root.right = Build(preorder, inorder, pl + count + 1, pr, midIndex + 1, ir);

        return root;
    }
}