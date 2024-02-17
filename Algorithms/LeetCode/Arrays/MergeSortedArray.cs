using FluentAssertions;

namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/merge-sorted-array/
/// </summary>
public class MergeSortedArray
{
    [Fact]
    public void RunTest()
    {
        int[] nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        int[] nums2 = new[] { 2, 5, 6 };
        Merge(nums1, 3, nums2, 3);
        nums1.Should().BeEquivalentTo(new[] { 1, 2, 2, 3, 5, 6 });
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0, j = 0;
        int[] nums3 = nums1.Take(m).ToArray();

        while (i + j < nums1.Length)
        {
            if (i == m)
            {
                nums1[i + j] = nums2[j];
                j++;
            }
            else if (j == n)
            {
                nums1[i + j] = nums3[i];
                i++;
            }
            else
            {
                if (nums3[i] <= nums2[j])
                {
                    nums1[i + j] = nums3[i];
                    i++;
                }
                else
                {
                    nums1[i + j] = nums2[j];
                    j++;
                }
            }
        }
    }
}