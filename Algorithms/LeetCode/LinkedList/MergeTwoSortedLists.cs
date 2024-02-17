namespace Algorithms.LeetCode.LinkedList;

/// <summary>
/// https://leetcode.com/problems/merge-two-sorted-lists/
/// </summary>
public class MergeTwoSortedLists
{
    [Fact]
    public void MergeTwoListsTest1()
    {
        var list1 = new ListNode(1, 2, 4);
        var list2 = new ListNode(1, 3, 4);
        ListNode result = MergeTwoLists(list1, list2);

        int[] values = result.GetValues().ToArray();
        Assert.Equal(new[] { 1, 1, 2, 3, 4, 4 }, values);
    }

    [Fact]
    public void MergeTwoListsTest2()
    {
        var list1 = new ListNode(1);
        var list2 = new ListNode(2);
        ListNode result = MergeTwoLists(list1, list2);

        int[] values = result.GetValues().ToArray();
        Assert.Equal(new[] { 1, 2 }, values);
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        if (list1.val < list2.val)
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }

        list2.next = MergeTwoLists(list1, list2.next);
        return list2;
    }
}