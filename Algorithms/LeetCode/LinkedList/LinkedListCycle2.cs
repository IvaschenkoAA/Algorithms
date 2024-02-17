namespace Algorithms.LeetCode.LinkedList;

/// <summary>
/// https://leetcode.com/problems/linked-list-cycle-ii/
/// </summary>
public class LinkedListCycle2
{
    [Fact]
    public void DetectCycleTest()
    {
        var list1 = new ListNode(1, 2, 3, 4, 5);
        Assert.Null(DetectCycleWithHashSet(list1));
        Assert.Null(DetectCycleWithReverse(list1));

        var cycledList = new ListNode(3, 2, 0, -4, 5);
        ListNode tail = cycledList;
        while (tail.next != null)
        {
            tail = tail.next;
        }
        tail.next = cycledList.next;

        Assert.NotNull(DetectCycleWithHashSet(cycledList));
        Assert.NotNull(DetectCycleWithReverse(cycledList));
    }

    public ListNode DetectCycleWithHashSet(ListNode head)
    {
        var nodes = new HashSet<ListNode>();

        ListNode temp = head;
        while (temp != null)
        {
            if (nodes.Contains(temp))
                return temp;

            nodes.Add(temp);
            temp = temp.next;
        }

        return null;
    }

    private static ListNode DetectCycleWithReverse(ListNode head)
    {
        if (head?.next == null)
            return null;

        ListNode direct = head;
        var tail = new ListNode(direct.val);

        while (direct.next != null)
        {
            direct = direct.next;
            tail = new ListNode(direct.val, tail);

            ListNode reverse = tail.next;
            while (reverse != null)
            {
                if (direct.val == reverse.val)
                    return direct;

                reverse = reverse.next;
            }
        }

        return null;
    }
}