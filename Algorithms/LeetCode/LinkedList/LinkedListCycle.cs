namespace Algorithms.LeetCode.LinkedList;

/// <summary>
/// https://leetcode.com/problems/linked-list-cycle/
/// </summary>
public class LinkedListCycle
{
    [Fact]
    public void HasCycleTest()
    {
        var list1 = new ListNode(1, 2, 3, 4, 5);
        Assert.False(HasCycleWithHashSet(list1));
        Assert.False(HasCycleWithTwoPointers(list1));

        var cycledList = new ListNode(3, 2, 0, -4, 5);
        ListNode tail = cycledList;
        while (tail.next != null)
        {
            tail = tail.next;
        }
        tail.next = cycledList.next;

        Assert.True(HasCycleWithHashSet(cycledList));
        Assert.True(HasCycleWithTwoPointers(cycledList));
    }

    private static bool HasCycleWithHashSet(ListNode head)
    {
        var nodes = new HashSet<ListNode>();

        ListNode temp = head;
        while (temp != null)
        {
            if (nodes.Contains(temp))
                return true;

            nodes.Add(temp);
            temp = temp.next;
        }

        return false;
    }

    private static bool HasCycleWithTwoPointers(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast?.next != null)
        {
            if (slow == fast)
                return true;

            slow = slow.next;
            fast = fast.next.next;
        }

        return false;
    }
}
