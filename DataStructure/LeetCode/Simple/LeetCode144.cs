using System.Collections.Generic;
using System.ComponentModel;

namespace DataStructure.LeetCode.Simple;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

/// <summary>
/// 144. 二叉树的前序遍历
/// https://leetcode.cn/problems/binary-tree-preorder-traversal/
/// </summary>
public class LeetCode144
{
    /// <summary>
    /// 输入：root = [1,null,2,3]
    /// 输出：[1,2,3]
    ///     1              
    ///   /  \
    ///  4    2
    ///     /  \
    ///    5    3
    ///   /
    ///  6 
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var ans = new List<int>();
        //根-左-右：1 4 2 5 3
        var stack = new Stack<TreeNode>();

        while (true)
        {
            if (root is not null)
            {
                ans.Add(root.val);
                stack.Push(root);
                root = root.left;
            }
            else
            {
                if (stack.Count == 0)
                    break;

                //节点出栈说明左子树已经访问完毕，直接向右子树走即可
                root = stack.Pop();
                root = root.right;
            }
        }

        return ans;
    }
}