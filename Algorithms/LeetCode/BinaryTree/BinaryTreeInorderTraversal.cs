namespace Algorithms.LeetCode.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/binary-tree-inorder-traversal/
/// </summary>
public class BinaryTreeInorderTraversal
{
    [Fact]
    public void InorderTraversalTest()
    {
        //   1
        //    \
        //     2
        //    /
        //   3
        var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
        IList<int> stackNodes = ReadWithStack(root).ToArray();
        IList<int> recursiveNodes = ReadRecursive(root).ToArray();

        Assert.Equal(recursiveNodes, stackNodes);
    }

    private static IEnumerable<int> ReadWithStack(TreeNode root)
    {
        TreeNode node = root;
        var stack = new Stack<TreeNode>();
        while (node != null || stack.Count > 0)
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            else
            {
                node = stack.Pop();
                yield return node.val;
                node = node.right;
            }
        }
    }

    private static IEnumerable<int> ReadRecursive(TreeNode root)
    {
        if (root == null)
            yield break;

        foreach (int i in ReadRecursive(root.left))
            yield return i;

        yield return root.val;

        foreach (int i in ReadRecursive(root.right))
            yield return i;
    }
}