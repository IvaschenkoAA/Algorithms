namespace Algorithms.LeetCode.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/maximum-depth-of-binary-tree/
/// </summary>
public class MaximumDepthOfBinaryTree
{
    [Fact]
    public void MaxDepthTest()
    {
        //       3
        //      / \
        //     9   20
        //         /\
        //        15 7
        var node1 = new TreeNode(3, new TreeNode(9), new TreeNode(20, 15, 7));
        int depth1 = MaxDepth(node1);
        Assert.Equal(3, depth1);

        //      1
        //       \
        //        2
        var node2 = new TreeNode(1, null, 2);
        int depth2 = MaxDepth(node2);
        Assert.Equal(2, depth2);
    }

    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        int maxLeft = MaxDepth(root.left);
        int maxRight = MaxDepth(root.right);
        return Math.Max(maxLeft, maxRight) + 1;
    }
}