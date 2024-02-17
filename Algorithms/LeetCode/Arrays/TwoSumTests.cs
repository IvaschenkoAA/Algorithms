namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/two-sum/
/// </summary>
public class TwoSumTests
{
    [Fact]
    public void TwoSumTest()
    {
        Assert.Equal(new[] { 0, 1 }, TwoSum(new[] { 2, 7, 11, 15 }, 9));
        Assert.Equal(new[] { 1, 2 }, TwoSum(new[] { 3, 2, 4 }, 6));
        Assert.Equal(new[] { 0, 1 }, TwoSum(new[] { 3, 3 }, 6));
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var d = new Dictionary<int, int>(nums.Length);

        for (int i = 0; i < nums.Length; i++)
        {
            int first = nums[i];
            int diff = target - first;
            if (d.TryGetValue(diff, out int index))
                return new[] { index, i };

            d[first] = i;
        }

        throw new Exception();
    }

    [Fact]
    public void ThreeSumTest()
    {
        const int count = 5000;
        int[] bigArray = Enumerable.Repeat(0, count).Concat(Enumerable.Repeat(1, count)).Concat(Enumerable.Repeat(-1, count)).ToArray();

        Assert.Equal(2, ThreeSum(bigArray).Count);
        Assert.Equal(2, ThreeSum(new[] { -1, 0, 1, 2, -1, -4 }).Count);
        Assert.Equal(0, ThreeSum(new[] { 0, 1, 1 }).Count);
        Assert.Equal(1, ThreeSum(new[] { 0, 0, 0 }).Count);
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var resNums = new List<int>();
        foreach (int num in nums)
        {
            int maxCount = num == 0 ? 3 : 2;

            int count = resNums.Count(n => n == num);
            if (count < maxCount)
                resNums.Add(num);
        }

        nums = resNums.ToArray();

        var res = new List<IList<int>>();

        var d = new Dictionary<int, int>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
            d[nums[i]] = i;

        for (int i = 0; i < nums.Length; i++)
        {
            int first = nums[i];

            foreach (IList<int> sums in GetSums(nums, -first, d, i + 1))
            {
                int[] arr = { first, sums[0], sums[1] };
                Array.Sort(arr);
                if (!res.Exists(x => x.SequenceEqual(arr)))
                    res.Add(arr);
            }
        }

        return res.ToList();
    }

    private static IEnumerable<IList<int>> GetSums(IReadOnlyList<int> nums, int target, IReadOnlyDictionary<int, int> d, int startIndex)
    {
        for (int i = startIndex; i < nums.Count; i++)
        {
            int first = nums[i];
            int diff = target - first;

            if (d.TryGetValue(diff, out int index) && index > i)
            {
                yield return new[] { first, diff };
            }
        }
    }
}