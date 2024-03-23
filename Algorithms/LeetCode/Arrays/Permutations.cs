namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/permutations/
/// </summary>
public class Permutations
{
    [Fact]
    public void PermuteTest()
    {
        IList<IList<int>> result = Permute(new[] { 1, 2, 3, 4 });
        Assert.Equal(24, result.Count);
    }

    public IList<IList<int>> Permute(int[] nums) => RecursivePrepositions(nums);

    private static IList<IList<int>> RecursivePrepositions(IList<int> numbers)
    {
        int length = numbers.Count;
        switch (length)
        {
            case 1:
                return new List<IList<int>> { numbers };
            case 2:
                return new List<IList<int>>
                {
                    numbers,
                    numbers.Reverse().ToList()
                };
        }

        var result = new List<IList<int>>();
        for (int i = 0; i < length; i++)
        {
            List<int> shortedNumbers = numbers.ToList();
            int excludedNumber = numbers[i];
            shortedNumbers.RemoveAt(i);

            IList<IList<int>> doublePrepositions = RecursivePrepositions(shortedNumbers);
            foreach (IList<int> preposition in doublePrepositions)
                preposition.Add(excludedNumber);

            result = result.Union(doublePrepositions).ToList();
        }

        return result;
    }
}