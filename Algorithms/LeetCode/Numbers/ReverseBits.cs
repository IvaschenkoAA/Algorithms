using System.Collections;
using FluentAssertions;

namespace Algorithms.LeetCode.Numbers;

/// <summary>
/// https://leetcode.com/problems/reverse-bits/
/// </summary>
public class ReverseBits
{
    [Fact]
    public void RunTest()
    {
        reverseBits(43261596).Should().Be(964176192);
    }

    public uint reverseBits(uint n)
    {
        var bitArray = new BitArray(BitConverter.GetBytes(n));

        int i = 0;
        int j = bitArray.Length - 1;

        while (i < j)
        {
            (bitArray[i], bitArray[j]) = (bitArray[j], bitArray[i]);
            i++;
            j--;
        }

        uint[] array = new uint[1];
        bitArray.CopyTo(array, 0);

        return array[0];
    }
}