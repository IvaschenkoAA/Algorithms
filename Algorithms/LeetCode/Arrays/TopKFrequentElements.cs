using FluentAssertions;

namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/top-k-frequent-elements
/// </summary>
public class TopKFrequentElements
{
    [Fact]
    public void RunTest()
    {
        int[] result = TopKFrequent(new[] { 1, 1, 1, 2, 2, 3 }, 2);
        result.Should().BeEquivalentTo(new[] { 1, 2 });
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        return nums
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .Take(k)
            .Select(g => g.First())
            .ToArray();
    }
}