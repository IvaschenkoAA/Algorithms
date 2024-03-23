namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/majority-element/
/// </summary>
public class MajorityElementTests
{
    [Fact]
    public void RunTest()
    {
        Assert.Equal(2, MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 }));
    }

    public int MajorityElement(int[] nums)
    {
        int halfLength = nums.Length / 2;

        var dic = new Dictionary<int, ReferenceInt>();
        foreach (int num in nums)
        {
            if (dic.TryGetValue(num, out ReferenceInt countRef))
            {
                countRef.Count++;
                if (countRef.Count > halfLength)
                    return num;
            }
            else
            {
                dic[num] = new ReferenceInt();
            }
        }

        return dic.MaxBy(p => p.Value).Key;
    }

    private class ReferenceInt { public int Count { get; set; } = 1; }

    public IEnumerable<int> ReverseCollection(IEnumerable<int> enumerable)
    {
        if (enumerable is IReadOnlyList<int> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }
        else
        {
            var stack = new Stack<int>(enumerable);
            if (stack.Count == 0)
                yield break;

            foreach (int item in stack)
                yield return item;
        }
    }
}