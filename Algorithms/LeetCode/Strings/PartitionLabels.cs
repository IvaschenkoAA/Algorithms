using FluentAssertions;

namespace Algorithms.LeetCode.Strings;

/// <summary>
/// https://leetcode.com/problems/partition-labels/
/// </summary>
public class PartitionLabelsTests
{
    [Fact]
    public void RunTest()
    {
        IList<int> partLength = PartitionLabels("ababcbacadefegdehijhklij");
        partLength.Should().BeEquivalentTo(new[] { 9, 7, 8 }); // ababcbaca, defegde, hijhklij
    }

    public IList<int> PartitionLabels(string s)
    {
        int[][] intervals = GetIntervals(s);
        int[][] mergedIntervals = MergeIntervals(intervals);

        return mergedIntervals.Select(i => i[1] - i[0] + 1).ToList();
    }

    private static int[][] GetIntervals(string s)
    {
        var intervals = new Dictionary<char, int[]>();

        for (int i = 0; i < s.Length; i++)
        {
            char start = s[i];
            if (intervals.ContainsKey(start))
                continue;

            for (int j = s.Length - 1; j >= i; j--)
            {
                char end = s[j];
                if (start != end)
                    continue;

                intervals.Add(start, new[] { i, j });
                break;
            }
        }

        return intervals.Values.ToArray();
    }

    private static int[][] MergeIntervals(int[][] intervals)
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