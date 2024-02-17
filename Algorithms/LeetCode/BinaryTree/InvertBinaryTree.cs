namespace Algorithms.LeetCode.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/invert-binary-tree/
/// </summary>
public class InvertBinaryTree
{
    [Fact]
    public void InvertTreeTest()
    {
        //       4
        //      / \
        //     2   7
        //    /\   /\
        //   1 3   6 9
        var root = new TreeNode(4, new TreeNode(2, 1, 3), new TreeNode(7, 6, 9));
        InvertWithRecurse(root);
    }

    private static void InvertWithRecurse(TreeNode root)
    {
        while (root != null)
        {
            (root.left, root.right) = (root.right, root.left);
            InvertWithRecurse(root.left);
            root = root.right;
        }
    }
}