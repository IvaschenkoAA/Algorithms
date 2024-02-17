namespace Algorithms.LeetCode.LinkedList;

/// <summary>
/// https://leetcode.com/problems/palindrome-linked-list/
/// </summary>
public class PalindromeLinkedList
{
    [Fact]
    public void IsPalindromeTest()
    {
        var palindrome = new ListNode(1, 2, 2, 1);
        Assert.True(IsPalindrome(palindrome));

        var palindrome2 = new ListNode(1);
        Assert.True(IsPalindrome(palindrome2));

        var palindrome3 = new ListNode(1, 0, 1);
        Assert.True(IsPalindrome(palindrome3));

        var nonPalindrome = new ListNode(1, 0, 0);
        Assert.False(IsPalindrome(nonPalindrome));
    }

    public bool IsPalindrome(ListNode head)
    {
        var numbers = new Stack<int>();

        ListNode temp = head;
        while (temp != null)
        {
            numbers.Push(temp.val);
            temp = temp.next;
        }

        int halfCount = numbers.Count / 2;
        temp = head;
        while (numbers.Count > halfCount)
        {
            if (numbers.Pop() != temp?.val)
                return false;

            temp = temp.next;
        }

        return true;
    }
}