namespace Algorithms.LeetCode.Arrays;

/// <summary>
/// https://leetcode.com/problems/maximum-69-number/
/// </summary>
public class Maximum69NumberTests
{
    [Fact]
    public void Maximum69NumberTest()
    {
        Assert.Equal(9, Maximum69Number(6));
        Assert.Equal(9, Maximum69Number(9));
        Assert.Equal(96, Maximum69Number(66));
        Assert.Equal(99, Maximum69Number(69));
        Assert.Equal(99, Maximum69Number(96));
        Assert.Equal(99, Maximum69Number(99));
        Assert.Equal(9999, Maximum69Number(9996));
    }

    public int Maximum69Number(int num)
    {
        int tempNum = num;
        while (true)
        {
            int digit = 1;

            int n = tempNum;
            while (n >= 10)
            {
                n /= 10;
                digit *= 10;
            }

            if (n % 2 == 0)
            {
                num += 3 * digit;
                return num;
            }

            tempNum %= digit;
            switch (tempNum)
            {
                case 6:
                    num += 3 * digit / 10;
                    return num;
                case 0:
                case 9:
                    return num;
            }
        }
    }
}