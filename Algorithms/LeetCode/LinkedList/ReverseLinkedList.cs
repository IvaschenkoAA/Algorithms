namespace Algorithms.LeetCode.LinkedList;

/// <summary>
/// https://leetcode.com/problems/reverse-linked-list/
/// </summary>
public class ReverseLinkedList
{
    [Fact]
    public void ReverseListTest()
    {
        int[] sourceValues = { 1, 2, 3 };
        int[] reversedValues = sourceValues.Reverse().ToArray();

        var list = new ListNode(sourceValues);

        ListNode reversed1 = ReverseList(list);
        Assert.Equal(reversedValues, reversed1.GetValues().ToArray());

        ListNode reversed2 = ReverseListWithStack(list);
        Assert.Equal(reversedValues, reversed2.GetValues().ToArray());
    }

    public ListNode ReverseList(ListNode head)
    {
        if (head?.next == null)
            return head;

        ListNode current = head;
        var rearNode = new ListNode(current.val);

        while (current.next != null)
        {
            current = current.next;
            rearNode = new ListNode(current.val, rearNode);
        }

        return rearNode;
    }

    private static ListNode ReverseListWithStack(ListNode head)
    {
        ListNode current = head;
        var stack = new Stack<int>();

        do
        {
            stack.Push(current.val);
            current = current.next;
        } while (current != null);


        var temp = new ListNode(stack.Pop());
        ListNode result = temp;

        while (stack.TryPop(out int val))
        {
            temp.next = new ListNode(val);
            temp = temp.next;
        }

        return result;
    }
}