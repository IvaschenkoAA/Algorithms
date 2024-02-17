namespace Algorithms.LeetCode.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class ConvertSortedArrayToBinarySearchTree
{
    [Fact]
    public void ArrayToTreeTest()
    {
        TreeNode tree1 = SortedArrayToBST(new []{ 0, 1, 2, 3, 4, 5 });
        TreeNode tree2 = SortedArrayToBST(new []{ -10, -3, 0, 5 });
    }

    public TreeNode SortedArrayToBST(int[] nums)
    {
        int i = nums.Length / 2;
        if (nums.Length == 0)
            return null;

        var root = new TreeNode(nums[i])
        {
            left = SortedArrayToBST(nums[..i]),
            right = SortedArrayToBST(nums[++i..])
        };

        return root;
    }
}