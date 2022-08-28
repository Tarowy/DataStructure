using System.Collections.Generic;

namespace DataStructure.LeetCode.Simple;

/// <summary>
/// 94. 二叉树的中序遍历
/// https://leetcode.cn/problems/binary-tree-inorder-traversal/
/// </summary>
public class LeetCode94
{
    /// <summary>
    /// 输入：root = [1,null,2,3]
    /// 输出：[1,3,2]
    ///       1              
    ///     /  \
    ///    4    2
    ///       /  \
    ///      5    3
    ///     /
    ///    6 
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> InorderTraversal(TreeNode root)
    {
        //左-根-右： 4 1 6 5 2 3 右-根-左
        var ans = new List<int>();

        var stack = new Stack<TreeNode>();

        while (true)
        {
            if (root is not null)
            {
                stack.Push(root);
                root = root.left;
            }
            //走不通了就Pop回去
            else
            {
                //无论往左还是往右都是空值，说明已经遍历完了
                if (stack.Count == 0)
                    break;
                //被Pop出来就说明该节点的左子树已经完全访问完毕，直接向右走
                root = stack.Pop();
                ans.Add(root.val);
                root = root.right;
            }
        }

        return ans;
    }
}