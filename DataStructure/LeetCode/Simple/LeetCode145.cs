using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 145. 二叉树的后序遍历
/// https://leetcode.cn/problems/binary-tree-postorder-traversal/
/// </summary>
public class LeetCode145
{
    /// <summary>
    /// 输入：root = [1,null,2,3]
    /// 输出：[3,2,1]
    ///     1 -            
    ///   /  \
    ///  4    2
    ///     /  \
    ///    5    3
    ///   / \
    ///  6   8
    ///
    /// [1,null,4,3,null,null,2]
    ///        1
    ///         \
    ///          4 -
    ///         / 
    ///        3
    ///        \
    ///         2   2 3 4 1
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> PostorderTraversal(TreeNode root)
    {
        //左-右-根：4 6 8 5 3 2 1
        var ans = new List<int>();
        var stack = new Stack<TreeNode>();
        TreeNode flag = null;

        while (true)
        {
            if (root is not null)
            {
                //先往左边走
                stack.Push(root);
                root = root.left;
            }
            else
            {
                if (stack.Count == 0)
                    break;

                //直接向右走
                root = stack.Peek().right;
                /*
                 * 两种情况都说明左右两边访问完毕，直接记录中间节点的值，然后返回上一层节点
                 * 情况1. 如果右边没有值，则直接出栈，回到上一层节点，并记录上一层节点的值
                 * 情况2. 右边已经被访问过了，直接出栈，并标记出栈的节点，
                 *       防止下一次 (stack.Peek().right;) 右重新访问到当前节点
                 */
                if (root is null || root == flag)
                {
                    flag = stack.Pop();
                    ans.Add(flag.val);
                    //让下一次循环能直接往上一层节点的右边走
                    root = null;
                }
                else
                    //如果右边有值，则对这个节点做标记，防止重复访问这个节点
                    flag = root;
            }
        }

        return ans;
    }
}