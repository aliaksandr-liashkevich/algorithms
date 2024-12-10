/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new();
        dummy.next = head;

        int length = GetLength(dummy);
        RemoveNthFromStart(dummy, length - n - 1);

        return dummy.next;
    }

    private static int GetLength(ListNode node)
    {
        int length = 0;

        while (node is not null)
        {
            length++;
            node = node.next;
        }

        return length;
    }

    private void RemoveFromStart(ListNode node, int steps)
    {
        while (node is not null && steps > 0)
        {
            node = node.next;
            steps--;
        }

        node.next = node.next?.next;
    }
}
