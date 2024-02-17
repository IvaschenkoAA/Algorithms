namespace Algorithms.LeetCode.BinaryTree;

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

    public TreeNode(int val, int? left, int? right)
    {
        this.val = val;
        this.left = left.HasValue ? new TreeNode(left.Value) : null;
        this.right = right.HasValue ? new TreeNode(right.Value) : null;
    }
}