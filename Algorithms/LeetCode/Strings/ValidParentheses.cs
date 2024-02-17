using FluentAssertions;

namespace Algorithms.LeetCode.Strings;

// https://leetcode.com/problems/valid-parentheses/
public class ValidParentheses
{
    [Fact]
    public void RunTest()
    {
        IsValid("a + (b-3) [(c)] { (b) + (d) }").Should().BeTrue();
        IsValid("(").Should().BeFalse();
        IsValid("]").Should().BeFalse();
        IsValid("((]))").Should().BeFalse();
    }

    public bool IsValid(string s)
    {
        var braces = new Stack<char>();
        foreach (char c in s)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    braces.Push(c);
                    break;
                case ')':
                    if (CheckLastBrace(braces, '('))
                        break;

                    return false;
                case ']':
                    if (CheckLastBrace(braces, '['))
                        break;

                    return false;
                case '}':
                    if (CheckLastBrace(braces, '{'))
                        break;

                    return false;
            }
        }

        return braces.Count == 0;
    }

    private static bool CheckLastBrace(Stack<char> braces, char expectedBrace)
    {
        if (braces.Count == 0)
            return false;

        char lastBrace = braces.Pop();
        return lastBrace == expectedBrace;
    }
}

// https://leetcode.com/problems/valid-anagram/