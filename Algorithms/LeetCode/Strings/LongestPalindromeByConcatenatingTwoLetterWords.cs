namespace Algorithms.LeetCode.Strings;

/// <summary>
/// https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/
/// </summary>
public class LongestPalindromeByConcatenatingTwoLetterWords
{
    [Fact]
    public void RunTest()
    {
        string[] words = { "em","pe","mp","ee","pp","me","ep","em","em","me" };
        Assert.Equal(14, LongestPalindrome(words));
    }

    public int LongestPalindrome(string[] words)
    {
        int length = 0;

        ILookup<bool, string> splittedWords = words.ToLookup(IsPalindromeWord);
        string[] palindroms = splittedWords[true].ToArray();

        int[] palindromsCountArray = palindroms.GroupBy(x => x).Select(x => x.Count()).OrderByDescending(x => x).ToArray();
        if (palindromsCountArray.Length == 1)
        {
            length += palindromsCountArray[0] * 2;
        }
        else if (palindromsCountArray.Length > 1)
        {
            length += palindromsCountArray[0] * 2;

            if (palindromsCountArray[0] % 2 == 1)
            {
                foreach (int count in palindromsCountArray.Skip(1))
                {
                    if (count % 2 == 0)
                    {
                        length += count * 2;
                    }
                    else
                    {
                        length += (count - 1) * 2;
                    }
                }
            }
            else
            {
                length += palindromsCountArray[^1] % 2 == 0
                    ? (palindromsCountArray[^1] - 1) * 2
                    : palindromsCountArray[^1] * 2;

                foreach (int count in palindromsCountArray.Skip(1).SkipLast(1))
                {
                    if (count % 2 == 0)
                    {
                        length += count * 2;
                    }
                    else
                    {
                        length += (count - 1) * 2;
                    }
                }
            }
        }


        List<string> nonPalindroms = splittedWords[false].ToList();
        for (int i = 0; i < nonPalindroms.Count; i++)
        {
            string dWord = nonPalindroms[i];
            string rWord = new(new[] { dWord[1], dWord[0] });

            int dWordsCount = nonPalindroms.RemoveAll(x => x == dWord);
            int rWordsCount = nonPalindroms.RemoveAll(x => x == rWord);

            length += Math.Min(dWordsCount, rWordsCount) * 4;
        }

        length += nonPalindroms.Count(w => HasReversed(nonPalindroms, w)) * 2;

        return length;
    }

    private static bool IsPalindromeWord(string word) => word[0] == word[1];

    private static bool HasReversed(IEnumerable<string> words, string word)
    {
        string reversedWord = new(new[] { word[1], word[0] });
        return words.Contains(reversedWord);
    }
}