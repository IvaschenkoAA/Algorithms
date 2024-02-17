namespace Algorithms.LeetCode.Numbers;

/// <summary>
/// https://leetcode.com/problems/happy-number/
/// </summary>
public class HappyNumber
{
    [Fact]
    public void RunTest()
    {
        Assert.True(IsHappy(1111111));
    }

    public bool IsHappy(int n)
    {
        while (true)
        {
            int[] nums = n.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            int sum = nums.Sum(a => a * a);

            if (sum % 10 == 1)
                return true;

            n = sum;
        }
    }
}