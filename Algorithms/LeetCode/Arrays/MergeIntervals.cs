using FluentAssertions;

namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/merge-intervals/
/// </summary>
public class MergeIntervals
{
    [Fact]
    public void RunTest()
    {
        // Input: intervals = [[1, 3], [2, 6], [8, 10], [15, 18]]
        // Output: [[1,6],[8,10],[15,18]]
        // Explanation: Since intervals[1, 3] and[2, 6] overlap, merge them into[1, 6].

        int[][] output = Merge(new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } });
        output.Should().BeEquivalentTo(new[] { new[] { 1, 6 }, new[] { 8, 10 }, new[] { 15, 18 } });
    }

    public int[][] Merge(int[][] intervals)
    {
        if (!intervals.Any())
            return intervals;

        var unionIntervals = new List<int[]>();

        int[][] orderedIntervals = intervals.OrderBy(x => x[0]).ToArray();
        int[] firstInterval = orderedIntervals.First();
        int lastStart = firstInterval[0];
        int lastEnd = firstInterval[1];

        foreach (int[] interval in orderedIntervals)
        {
            int end = interval[1];
            if (lastEnd >= interval[0])
            {
                lastEnd = Math.Max(lastEnd, end);
            }
            else
            {
                unionIntervals.Add(new[] { lastStart, lastEnd });
                lastStart = interval[0];
                lastEnd = interval[1];
            }
        }

        int[] lastInterval = new[] { lastStart, lastEnd };
        if (!unionIntervals.Any() || !unionIntervals.Last().SequenceEqual(lastInterval))
        {
            unionIntervals.Add(lastInterval);
        }

        return unionIntervals.ToArray();
    }
}