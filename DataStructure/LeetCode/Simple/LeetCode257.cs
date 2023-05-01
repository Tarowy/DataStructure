using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.LeetCode.Simple;

/// <summary>
///  257. 二叉树的所有路径
///  https://leetcode.cn/problems/binary-tree-paths/
/// </summary>
public class LeetCode257
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();
        Traversal(root, new List<int>(), result, new StringBuilder());
        return result;
    }

    public void Traversal(TreeNode root, IList<int> path, IList<string> result, StringBuilder builder)
    {
        path.Add(root.val);

        if (root.left == null && root.right == null)
        {
            for (var i = 0; i < path.Count - 1; i++)
                builder.Append($"{path[i]}->");
            builder.Append($"{path[^1]}");

            result.Add(builder.ToString());
            builder.Clear();
            return;
        }

        if (root.left != null)
        {
            Traversal(root.left, path, result, builder);
            path.RemoveAt(path.Count - 1);
        }

        if (root.right != null)
        {
            Traversal(root.right, path, result, builder);
            path.RemoveAt(path.Count - 1);
        }
    }
}