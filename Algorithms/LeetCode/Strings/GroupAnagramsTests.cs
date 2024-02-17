using FluentAssertions;

namespace Algorithms.LeetCode.Strings;

/// <summary>
/// https://leetcode.com/problems/group-anagrams/
/// </summary>
public class GroupAnagramsTests
{
    [Fact]
    public void RunTest()
    {
        string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
        IList<IList<string>> groupedWords = GroupAnagrams(strs);

        groupedWords.Should().HaveCount(3);
        groupedWords[0].Should().BeEquivalentTo("eat", "tea", "ate");
        groupedWords[1].Should().BeEquivalentTo("tan", "nat");
        groupedWords[2].Should().BeEquivalentTo("bat");
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new List<IList<string>>();

        List<string> strsList = strs.ToList();
        while (strsList.Count > 0)
        {
            string s = strsList[0];
            strsList.RemoveAt(0);

            var group = new List<string> { s };

            for (int j = strsList.Count - 1; j >= 0; j--)
            {
                string t = strsList[j];
                if (IsAnagram(s, t))
                {
                    strsList.RemoveAt(j);
                    group.Add(t);
                }
            }

            res.Add(group);
        }

        return res;
    }

    private bool IsAnagram(string s, string t)
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
}