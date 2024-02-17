using FluentAssertions;

namespace Algorithms.LeetCode.Strings;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LongestSubstringWithoutRepeatingCharacters
{
    [Fact]
    public void RunTest()
    {
        LengthOfLongestSubstring("abcabcbb").Should().Be(3);
        LengthOfLongestSubstring(" ").Should().Be(1);
        LengthOfLongestSubstring("dvdf").Should().Be(3);
    }

    public int LengthOfLongestSubstring(string s)
    {
        int max = 0;
        var hs = new HashSet<char>();
        int i = 0;
        int j = 0;

        while (i < s.Length && j < s.Length)
        {
            if (!hs.Contains(s[j]))
            {
                hs.Add(s[j]);
                j++;

                max = Math.Max(max, j - i);
            }
            else
            {
                hs.Remove(s[i]);
                i++;
            }
        }

        return max;
    }
}