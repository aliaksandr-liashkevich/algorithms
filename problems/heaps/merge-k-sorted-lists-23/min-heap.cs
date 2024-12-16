public class Solution
{
    // k - the number of linked lists
    // n - the number of elements per linked list
    // Time: O(k * n * log(k))
    // Space: O(k)
    public ListNode MergeKLists(ListNode[] lists)
    {
        // O(k)
        IEnumerable<(ListNode Node, int Priority)> nodesForQueue = lists
            .Where(node => node is not null)
            .Select(node => (node, node.val));
        // O(k)
        PriorityQueue<ListNode, int> minQueue = new(nodesForQueue);

        ListNode dummy = new();
        ListNode curr = dummy;

        // O(k*n)
        while (minQueue.Count > 0)
        {
            // O(log k)
            ListNode minNode = minQueue.Dequeue();

            if (minNode.next is not null)
            {
                // O(log k)
                minQueue.Enqueue(minNode.next, minNode.next.val);
            }

            curr.next = minNode;
            curr = curr.next;
        }

        return dummy.next;
    }
}
