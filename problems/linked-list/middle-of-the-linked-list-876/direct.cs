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
    public ListNode MiddleNode(ListNode head)
    {
        ListNode curr = head;

        int length = 0;

        // O(n)
        while (curr is not null)
        {
            length++;
            curr = curr.next;
        }

        if (length == 0)
        {
            return null;
        }

        int middle = length / 2;
        curr = head;

        // O(n)
        while (middle > 0)
        {
            curr = curr.next;
            middle--;
        }

        return curr;
    }
}
