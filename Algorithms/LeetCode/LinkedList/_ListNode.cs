namespace Algorithms.LeetCode.LinkedList;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode(params int[] values)
    {
        if (!values.Any())
            throw new ArgumentException("Values array can't be empty.");

        ListNode temp = this;
        temp.val = values[0];

        for (int i = 1; i < values.Length; i++)
        {
            temp.next = new ListNode(values[i]);
            temp = temp.next;
        }
    }

    public IEnumerable<int> GetValues()
    {
        ListNode node = this;
        while (node != null)
        {
            yield return node.val;
            node = node.next;
        }
    }

    public override string ToString()
    {
        var nodes = new List<ListNode>();

        ListNode temp = this;
        while (temp != null)
        {
            int cycleIndex = nodes.IndexOf(temp);
            if (cycleIndex != -1)
            {
                IEnumerable<int> uniqueValues = nodes.Take(cycleIndex).Select(n => n.val);
                IEnumerable<int> repeatValues = nodes.Skip(cycleIndex).Select(n => n.val);

                return $"{string.Join(", ", uniqueValues)} ({string.Join(", ", repeatValues)})";
            }

            nodes.Add(temp);
            temp = temp.next;
        }

        return string.Join(", ", nodes.Select(n => n.val));
    }
}