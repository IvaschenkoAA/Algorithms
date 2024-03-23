namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/move-zeroes/
/// </summary>
public class MoveZeroesTests
{
    [Fact]
    public void MoveZeroesTest()
    {
        int[] nums1 = { 0, 1, 2, 3, 0, 4, 5 };
        MoveZeroes(nums1);
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 0, 0 }, nums1);

        int[] nums2 = { 0, 1, 2, 3, 0 };
        MoveZeroes(nums2);
        Assert.Equal(new[] { 1, 2, 3, 0, 0 }, nums2);

        int[] nums3 = { 1, 0, 0, 2 };
        MoveZeroes(nums3);
        Assert.Equal(new[] { 1, 2, 0, 0 }, nums3);
    }

    public void MoveZeroes(int[] nums)
    {
        int zeroesCount = 0;
        int length = nums.Length;
        for (int i = 0; i < length - zeroesCount; i++)
        {
            while (nums[i] == 0 && length - zeroesCount > i)
            {
                for (int j = i + 1; j < length - zeroesCount; j++)
                {
                    nums[j - 1] = nums[j];
                }

                zeroesCount++;
                nums[^zeroesCount] = 0;
            }
        }
    }
}