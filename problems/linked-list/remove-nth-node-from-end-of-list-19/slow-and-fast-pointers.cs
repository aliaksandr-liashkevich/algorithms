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

        ListNode slow = dummy;
        ListNode fast = FindNode(dummy, n + 1);

        while (fast is not null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next?.next;

        return dummy.next;
    }

    private static ListNode FindNode(ListNode node, int steps)
    {
        while (node is not null && steps > 0)
        {
            node = node.next;
            steps--;
        }

        return node;
    }
}
