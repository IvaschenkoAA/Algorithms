using FluentAssertions;

namespace Algorithms.LeetCode.Strings;

/// <summary>
/// https://leetcode.com/problems/valid-anagram/
/// </summary>
public class ValidAnagram
{
    [Fact]
    public void RunTest()
    {
        IsAnagram("anagram", "nagaram").Should().BeTrue();
        IsAnagram("rat", "car").Should().BeFalse();
    }

    public bool IsAnagram(string s, string t)
    {
        return IsAnagramWithAlphabet(s, t);
    }

    private bool IsAnagramWithAlphabet(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        char[] abCount = new char[26];
        for (int i = 0; i < s.Length; i++)
        {
            char inc = s[i];
            char dec = t[i];

            abCount[inc - 'a']++;
            abCount[dec - 'a']--;
        }

        return abCount.All(x => x == 0);
    }

    private bool IsAnagramWithDictionary(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, IntWrapper> sd = ToCharCountMap(s);
        foreach (char c in t)
        {
            if (sd.TryGetValue(c, out IntWrapper count))
            {
                count.Value--;
                if (count.Value < 0)
                    return false;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    private Dictionary<char, IntWrapper> ToCharCountMap(string s)
    {
        var d = new Dictionary<char, IntWrapper>();
        foreach (char c in s)
        {
            if (d.TryGetValue(c, out IntWrapper wrapper))
            {
                wrapper.Value++;
            }
            else
            {
                d[c] = new IntWrapper(1);
            }
        }

        return d;
    }

    class IntWrapper
    {
        public int Value;

        public IntWrapper(int value)
        {
            Value = value;
        }
    }
}